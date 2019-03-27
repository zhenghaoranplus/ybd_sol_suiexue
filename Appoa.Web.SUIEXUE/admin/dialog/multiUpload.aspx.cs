using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class multiUpload : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static Dictionary<string, int> GetQuestionDic()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_type), "name", "id");
            foreach (DataRow item in dt.Rows)
            {
                dic.Add(item["name"].ToString(), Convert.ToInt32(item["id"]));
            }
            return dic;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = this.fupload.PostedFile;
            if (file.ContentLength > 0 && file.FileName != "")
            {
                string RootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()).Replace("\\", "/");
                string pat_url_name = "/upload/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
                string pathName = RootDir + pat_url_name;
                if (!System.IO.Directory.Exists(pathName))
                    System.IO.Directory.CreateDirectory(pathName); // 不存在创建文件夹

                int index = file.FileName.LastIndexOf('.');
                string extend = file.FileName.Substring(index, file.FileName.Length - index);
                string picPath = Guid.NewGuid().ToString() + extend;

                if (extend != ".xls" && extend != ".xlsx")
                {
                    this.divResult.InnerText = "请上传xls或xlsx格式的Excel文档";
                    return;
                }

                pathName += picPath;
                if (System.IO.File.Exists(pathName))
                    File.Delete(pathName);//删除之前的文件

                file.SaveAs(pathName);

                DataTable dt = ExcelToDataTable(pathName, true);

                this.divResult.InnerText = "共上传 " + dt.Rows.Count + " 道题目";
            }
            else
            {
                this.divResult.InnerText = "请选择Excel文档";
            }
        }

        private DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            int chapter = RequestHelper.GetQueryInt("chapter");

            DataTable dataTable = null;
            DataTable dtOption = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheetQuestion = null;
            ISheet sheetOption = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;

            BLL.common_questions qbll = new BLL.common_questions();
            BLL.common_answers obll = new BLL.common_answers();
            int group = Convert.ToInt32(this.rbtnGroup.SelectedValue);

            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    Dictionary<string, int> dic = GetQuestionDic();
                    if (workbook != null)
                    {
                        #region 问题表
                        sheetQuestion = workbook.GetSheetAt(0);//读取第一个sheetQuestion，当然也可以循环读取每个sheetQuestion  
                        dataTable = new DataTable();
                        if (sheetQuestion != null)
                        {
                            int rowCount = sheetQuestion.LastRowNum;//总行数  
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheetQuestion.GetRow(0);//第一行  
                                int cellCount = firstRow.LastCellNum;//列数  

                                //构建datatable的列  
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                //填充行  
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheetQuestion.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                        #endregion

                        Model.common_questions question = null;

                        foreach (DataRow item in dataTable.Rows)
                        {
                            question = qbll.GetModel(" group_id = " + group + " and title = '" + item[0].ToString() + "' ");
                            if (question == null)
                            {
                                question = new Model.common_questions();
                                question.group_id = group;
                                question.type = dic[item[1].ToString()];
                                question.data_id = chapter;
                                question.number = 0;
                                question.title = item[0].ToString();
                                question.answer = item[2].ToString();
                                question.score = Convert.ToDecimal(item[3]);
                                question.analysis = item[4].ToString();
                                question.add_time = System.DateTime.Now;

                                qbll.Add(question);
                            }
                            else
                            {
                                question.group_id = group;
                                question.type = dic[item[1].ToString()];
                                question.data_id = chapter;
                                question.number = 0;
                                question.answer = item[2].ToString();
                                question.score = Convert.ToDecimal(item[3]);
                                question.analysis = item[4].ToString();

                                qbll.Update(question);
                            }
                        }

                        #region 选项表
                        sheetOption = workbook.GetSheetAt(1);//读取第一个sheetOption，当然也可以循环读取每个sheetOption
                        dtOption = new DataTable();
                        if (sheetOption != null)
                        {
                            int rowCount = sheetOption.LastRowNum;//总行数  
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheetOption.GetRow(0);//第一行  
                                int cellCount = firstRow.LastCellNum;//列数  

                                //构建datatable的列  
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dtOption.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dtOption.Columns.Add(column);
                                    }
                                }

                                //填充行  
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheetOption.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dtOption.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dtOption.Rows.Add(dataRow);
                                }
                            }
                        }
                        #endregion

                        Model.common_questions qModle = null;
                        Model.common_answers option = null;

                        foreach (DataRow item in dtOption.Rows)
                        {
                            qModle = qbll.GetModel(" group_id = " + group + " and title = '" + item[0].ToString() + "' ");
                            if (qModle != null)
                            {
                                option = obll.GetModel(" question_id = " + qModle.id + " and contents = '" + item[2].ToString() + "' ");
                                if (option == null)
                                {
                                    option = new Model.common_answers();
                                    option.question_id = qModle.id;
                                    option.options = item[1].ToString();
                                    option.contents = item[2].ToString();
                                    option.score = dtOption.Columns.Count > 3 ? Convert.ToInt32(item[3].ToString()) : 0;
                                    option.add_time = System.DateTime.Now;

                                    obll.Add(option);
                                }
                                else
                                {
                                    option.options = item[1].ToString();
                                    option.score = dtOption.Columns.Count > 3 ? Convert.ToInt32(item[3].ToString()) : 0;

                                    obll.Update(option);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
        }
    }
}