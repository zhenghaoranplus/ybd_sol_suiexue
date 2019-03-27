using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections;

namespace Appoa.Common
{
    /// <summary>
    /// JSON数据处理类
    /// </summary>
    public static class JsonUtil
    {
        #region 将DataSet转化成JSON数据
        /// <summary>
        /// 将DataSet转化成JSON数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToJson(DataSet ds)
        {
            string json = string.Empty;
            try
            {
                if (ds.Tables.Count == 0)
                    throw new Exception("DataSet中Tables为0");
                json = "[{\"BoolSuccess\":\"yes\",\"Exception\":\"\"},{";
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    json += "\"T" + (i + 1) + "\":[";
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        json += "{";
                        for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                        {
                            json += "\"" + ds.Tables[i].Columns[k].ColumnName + "\":\"" + ds.Tables[i].Rows[j][k].ToString() + "\"";

                            if (k != ds.Tables[i].Columns.Count - 1)
                                json += ",";
                        }
                        json += "}";
                        if (j != ds.Tables[i].Rows.Count - 1)
                            json += ",";
                    }
                    json += "]";
                    if (i != ds.Tables.Count - 1)
                        json += ",";
                }
                json += "}]";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            json = json.Replace("\r\n", "\\r\\n");
            return json;
        }

        /// <summary>
        /// 将DataTable转化成JSON数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataTableToJSON(DataTable dt)
        {
            string json = string.Empty;
            try
            {
                //json = "[{\"BoolSuccess\":\"yes\",\"Exception\":\"\"},{";

                //json += "\"T" + (1) + "\":[";
                json += "[";
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                        json += "{";
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            //兼容嵌套数组
                            if (dt.Columns[k].ColumnName == "ordergoods" || dt.Columns[k].ColumnName == "children")
                            {
                                json += "\"" + dt.Columns[k].ColumnName + "\":" + dt.Rows[j][k].ToString() + "";
                            }
                            else
                            {
                                json += "\"" + dt.Columns[k].ColumnName + "\":\"" + dt.Rows[j][k].ToString() + "\"";

                                if (k != dt.Columns.Count - 1)
                                    json += ",";
                            }
                        }
                        json += "}";
                        if (j != dt.Rows.Count - 1)
                            json += ",";
                    

                }
                json += "]";

                //json += "}]";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            json = json.Replace("\r", "\\r").Replace("\n", "\\n");
            return json;
        }
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(string json, string tableName)
        {
            DataTable dataTable = new DataTable();  //实例化
            dataTable.TableName = tableName;
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
        #endregion
    }
}
