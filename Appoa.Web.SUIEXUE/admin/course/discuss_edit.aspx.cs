using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class discuss_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int chapter = 0;
        private int page = 1;

        protected string course_name = string.Empty;
        protected string chapter_name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.chapter = RequestHelper.GetQueryInt("chapter");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.id > 0)
            {
                if (!new BLL.common_article().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }

            if (this.chapter > 0)
            {
                Model.course_chapter model = new BLL.course_chapter().GetModel(this.chapter);
                if (model == null)
                {
                    JscriptMsg("没有此章节！", "back");
                    return;
                }
                else
                {
                    this.chapter_name = model.name;
                    Model.course_info course = new BLL.course_info().GetModel(model.course_id);
                    if (course != null)
                    {
                        this.course_name = course.name;
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_discuss", EnumCollection.ActionEnum.View.ToString()); //检查权限

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(_id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }


            txttitle.Text = model.title + "";
            txtcontents.Text = model.contents + "";

            this.rptAlbumList.DataSource = new BLL.common_albums().GetList(" group_id = " + (int)EnumCollection.img_group.精品微课问题讨论图片 + " and rc_data_id = " + _id);
            this.rptAlbumList.DataBind();
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();

            model.group_id = (int)EnumCollection.article_group.精品微课问题讨论;
            model.user_id = 0;
            model.category_id = this.chapter;
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text);
            model.img_src = "";
            model.click = 0;
            model.upvote = 0;
            model.status = (int)EnumCollection.examine_status.审核通过;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                #region 保存图片
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                if (albumArr != null && albumArr.Length > 0)
                {
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        if (imgArr.Length == 3)
                        {
                            var img = new Model.common_albums
                            {
                                group_id = (int)EnumCollection.img_group.精品微课问题讨论图片,
                                rc_type = 0,
                                rc_data_id = id,
                                add_time = DateTime.Now,
                                original_path = imgArr[1],
                                thumb_path = imgArr[2],
                                remark = ""
                            };

                            new BLL.common_albums().Add(img);
                        }
                    }
                }
                #endregion 保存图片

                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加问题讨论信息，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);

            model.group_id = (int)EnumCollection.article_group.精品微课问题讨论;
            model.user_id = 0;
            model.category_id = this.chapter;
            model.title = Convert.ToString(txttitle.Text);
            model.contents = Convert.ToString(txtcontents.Text);

            if (bll.Update(model))
            {
                #region 保存图片
                string[] albumArr = Request.Form.GetValues("hid_photo_name");

                if (albumArr != null && albumArr.Length > 0)
                {
                    DBUtility.DbHelperSQL.ExecuteSql("delete ybd_common_albums where rc_guid=" + model.id + " and group_id=" + (int)EnumCollection.img_group.精品微课问题讨论图片);//删除图片
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        if (imgArr.Length == 3)
                        {
                            var img = new Model.common_albums
                            {
                                group_id = (int)EnumCollection.img_group.精品微课问题讨论图片,
                                rc_type = 0,
                                rc_data_id = id,
                                add_time = DateTime.Now,
                                original_path = imgArr[1],
                                thumb_path = imgArr[2],
                                remark = ""
                            };

                            new BLL.common_albums().Add(img);
                        }
                    }
                }
                #endregion 保存图片

                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改问题讨论信息，主键:" + model.id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_course_discuss", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改问题讨论信息成功！", "discuss_list.aspx?page=" + this.page + "&chapter=" + this.chapter);
            }
            else //添加
            {
                ChkAdminLevel("_course_discuss", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加问题讨论信息成功！", "discuss_list.aspx?chapter=" + this.chapter);
            }
        }
    }
}