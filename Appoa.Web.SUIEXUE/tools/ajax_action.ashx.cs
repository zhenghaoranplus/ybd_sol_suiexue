using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Appoa.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Appoa.Manage.tools
{
    /// <summary>
    /// ajax_action 的摘要说明
    /// </summary>
    public class ajax_action : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["action"];

            switch (action)
            {
                case "UpdateSpec"://修改规格
                    UpdateSpec(context);
                    break;
                case "SetRecommend"://推荐课程
                    SetRecommend(context);
                    break;
                case "ExamineVerify"://审核加入课堂申请
                    ExamineVerify(context);
                    break;
                case "SetSalesStatus"://设置商品上架
                    SetSalesStatus();
                    break;
                case "SetGoodsIndex"://设置商品首页展示
                    SetGoodsIndex();
                    break;
                case "SetIsShow"://设置课程是否显示
                    SetIsShow();
                    break;
                case "SetAnswerIsTruth"://设置答案正确/错误
                    SetAnswerIsTruth();
                    break;
                case "SetAnswerScore"://设置答案分数
                    SetAnswerScore();
                    break;
                case "saveWordVoice"://保存英文发音资源
                    saveWordVoice();
                    break;
                case "getWordVoice"://查询英文发音资源
                    getWordVoice();
                    break;
                case "SetClassroomIsShow"://设置课堂是否显示
                    SetClassroomIsShow();
                    break;
                case "saveQuestionOptions"://保存题目信息
                    saveQuestionOptions();
                    break;
                case "getQuestionOptions"://查询题目信息
                    getQuestionOptions();
                    break;
                case "SetBusinessIsShow"://设置业务版块是否显示
                    SetBusinessIsShow();
                    break;
                case "SetProductIsShow"://设置产品是否显示
                    SetProductIsShow();
                    break;
                case "SetCaseIsShow"://设置案例是否显示
                    SetCaseIsShow();
                    break;
                case "SetPartnerIsShow"://设置合作伙伴是否显示
                    SetPartnerIsShow();
                    break;
                case "GetCourseResource"://查询微课资源
                    GetCourseResource();
                    break;
                case "SaveClassroomResource"://保存课堂资源
                    SaveClassroomResource();
                    break;
            }
        }

        #region 修改规格
        private void UpdateSpec(HttpContext context)
        {
            int id = RequestHelper.GetFormInt("id");
            string price = RequestHelper.GetFormString("price");
            Model.goods_spec_type spec = new BLL.goods_spec_type().GetModel(id);
            if (spec != null)
            {
                spec.price = Utils.StrToDecimal(price, 0);
                if (new BLL.goods_spec_type().Update(spec))
                {
                    context.Response.Write("1");
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("0");
                    context.Response.End();
                }
            }
            else
            {
                context.Response.Write("0");
                context.Response.End();
            }
        }
        #endregion

        #region 推荐课程
        private void SetRecommend(HttpContext context)
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = bll.GetModel("ad_data_id=" + id + " and ad_group_id=" + (int)EnumCollection.adR_group.精品微课推荐课程);
            if (model != null)
            {
                new BLL.common_adR().Delete(model.id);
            }
            else
            {
                model = new Model.common_adR();
                model.ad_group_id = (int)EnumCollection.adR_group.精品微课推荐课程;
                model.ad_group_name = EnumCollection.adR_group.精品微课推荐课程.ToString();
                model.ad_type_id = 0;
                model.ad_type_name = "";
                model.ad_data_title = "";
                model.ad_data_subtitle = "";
                model.ad_data_img = "";
                model.ad_data_url = "";
                model.ad_data_id = id;
                model.ad_sort_id = 0;
                model.add_time = System.DateTime.Now;

                bll.Add(model);
            }

            context.Response.Write("1");
            context.Response.End();
        }
        #endregion

        #region 审核加入课堂申请
        private void ExamineVerify(HttpContext context)
        {
            int id = RequestHelper.GetFormInt("id");
            int type = RequestHelper.GetFormInt("type");
            BLL.classroom_user bll = new BLL.classroom_user();
            Model.classroom_user model = bll.GetModel(id);
            if (model != null)
            {
                model.status = type;

                bll.Update(model);
            }

            context.Response.Write("1");
            context.Response.End();
        }
        #endregion

        #region 设置商品上架
        private void SetSalesStatus()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = bll.GetModel(id);
            if (model != null)
            {
                if (model.status == (int)EnumCollection.sales_status.上架)
                {
                    model.status = (int)EnumCollection.sales_status.下架;
                    model.xj_time = System.DateTime.Now;
                }
                else
                {
                    model.status = (int)EnumCollection.sales_status.上架;
                    model.sj_time = System.DateTime.Now;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 设置商品首页展示
        private void SetGoodsIndex()
        {
            int id = RequestHelper.GetFormInt("id");

            Model.goods_goods goods = new BLL.goods_goods().GetModel(id);
            if (goods != null)
            {
                BLL.common_adR bll = new BLL.common_adR();
                if (goods.group_id == (int)EnumCollection.goods_group.教育商城)
                {
                    Model.common_adR model = bll.GetModel("ad_data_id=" + id + " and ad_group_id=" + (int)EnumCollection.adR_group.教育商城推荐商品);
                    if (model != null)
                    {
                        new BLL.common_adR().Delete(model.id);
                    }
                    else
                    {
                        model = new Model.common_adR();
                        model.ad_group_id = (int)EnumCollection.adR_group.教育商城推荐商品;
                        model.ad_group_name = EnumCollection.adR_group.教育商城推荐商品.ToString();
                        model.ad_type_id = 0;
                        model.ad_type_name = "";
                        model.ad_data_title = "";
                        model.ad_data_subtitle = "";
                        model.ad_data_img = "";
                        model.ad_data_url = "";
                        model.ad_data_id = id;
                        model.ad_sort_id = 0;
                        model.add_time = System.DateTime.Now;

                        bll.Add(model);
                    }

                    HttpContext.Current.Response.Write("1");
                    HttpContext.Current.Response.End();
                    return;
                }
                if (goods.group_id == (int)EnumCollection.goods_group.积分专区)
                {
                    Model.common_adR model = bll.GetModel("ad_data_id=" + id + " and ad_group_id=" + (int)EnumCollection.adR_group.积分商城推荐商品);
                    if (model != null)
                    {
                        new BLL.common_adR().Delete(model.id);
                    }
                    else
                    {
                        model = new Model.common_adR();
                        model.ad_group_id = (int)EnumCollection.adR_group.积分商城推荐商品;
                        model.ad_group_name = EnumCollection.adR_group.积分商城推荐商品.ToString();
                        model.ad_type_id = 0;
                        model.ad_type_name = "";
                        model.ad_data_title = "";
                        model.ad_data_subtitle = "";
                        model.ad_data_img = "";
                        model.ad_data_url = "";
                        model.ad_data_id = id;
                        model.ad_sort_id = 0;
                        model.add_time = System.DateTime.Now;

                        bll.Add(model);
                    }

                    HttpContext.Current.Response.Write("1");
                    HttpContext.Current.Response.End();
                    return;
                }
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
                return;
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
                return;
            }
        }
        #endregion

        #region 设置课程是否显示
        private void SetIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_show == (int)EnumCollection.course_is_show.是)
                {
                    model.is_show = (int)EnumCollection.course_is_show.否;
                }
                else
                {
                    model.is_show = (int)EnumCollection.course_is_show.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 设置答案正确/错误
        private void SetAnswerIsTruth()
        {
            int id = RequestHelper.GetFormInt("id");
            int score = RequestHelper.GetFormInt("score");

            BLL.answer_record bll = new BLL.answer_record();
            Model.answer_record model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_truth == (int)EnumCollection.YesOrNot.是)
                {
                    model.is_truth = (int)EnumCollection.YesOrNot.否;
                }
                else if (model.is_truth == (int)EnumCollection.YesOrNot.否)
                {
                    model.is_truth = (int)EnumCollection.YesOrNot.是;
                }
                else
                {
                    score = 0;
                }

                model.score = score;
                bll.Update(model);

                SumScore(model.exa_id, model.user_id);
            }
        }
        #endregion

        #region 设置答案分数
        private void SetAnswerScore()
        {
            int id = RequestHelper.GetFormInt("id");
            int score = RequestHelper.GetFormInt("score");

            BLL.answer_record bll = new BLL.answer_record();
            Model.answer_record model = bll.GetModel(id);
            if (model != null)
            {
                model.score = score;
                bll.Update(model);
            }
        }
        #endregion

        #region 结算总分
        private void SumScore(int exa_id, int uid)
        {
            int truth_count = 0;
            int score = 0;

            BLL.common_questions qBll = new BLL.common_questions();
            BLL.answer_record arBll = new BLL.answer_record();
            BLL.common_answers aBll = new BLL.common_answers();
            Model.user_info user = new BLL.user_info().GetModel(uid);
            Model.common_examination exa = new BLL.common_examination().GetModel(exa_id);
            if (exa != null)
            {
                DataTable dt = arBll.GetList(" exa_id = " + exa_id + " and user_id = " + uid);

                foreach (DataRow item in dt.Rows)
                {
                    #region 批改作业按老师选择对错为准
                    int is_truth = Convert.ToInt32(item["is_truth"]);

                    if (is_truth == 1)
                    {
                        truth_count++;
                        score += Convert.ToInt32(item["score"]);
                    }
                    #endregion

                    #region 批改作业按答题记录为准
                    //int q_id = Convert.ToInt32(item["q_id"]);
                    //string answer = item["answer"].ToString();

                    //Model.common_questions question = qBll.GetModel(q_id);
                    //if (!string.IsNullOrEmpty(answer))//没有答题
                    //{
                    //    if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                    //    {
                    //        Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(answer));
                    //        if (anModel.options == question.answer)
                    //        {
                    //            truth_count++;
                    //            score += Convert.ToInt32(item["score"]);
                    //        }
                    //    }
                    //    if (question.type == (int)EnumCollection.questions_type.多选题)
                    //    {
                    //        string[] ids = answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //        string anids = string.Empty;
                    //        foreach (string id in ids)
                    //        {
                    //            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                    //            anids += anModel.options + ",";
                    //        }
                    //        if (question.answer == Utils.DelLastComma(anids))
                    //        {
                    //            truth_count++;
                    //            score += Convert.ToInt32(item["score"]);
                    //        }
                    //    }
                    //    if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                    //    {
                    //        if (answer.Contains(question.answer))
                    //        {
                    //            truth_count++;
                    //            score += Convert.ToInt32(item["score"]);
                    //        }
                    //    }
                    //}
                    #endregion
                }

                BLL.answer_result bll = new BLL.answer_result();
                Model.answer_result model = bll.GetModel(" group_id = " + (int)EnumCollection.examination_group.课堂作业 + " and exa_id = " + exa_id + " and user_id = " + uid);
                if (model != null)
                {
                    model.truth_num = truth_count;
                    model.count = exa.nums;
                    model.truth_ratio = Convert.ToDecimal((decimal)model.truth_num / (decimal)model.count) * 100;
                    model.score = score;
                    model.status = (int)EnumCollection.correcting_status.已批改;

                    bll.Update(model);
                }
                else
                {
                    model = new Model.answer_result();
                    model.group_id = (int)EnumCollection.examination_group.课堂作业;
                    model.exa_id = exa_id;
                    model.exa_title = exa.name;
                    model.user_id = uid;
                    model.avatar = user.avatar;
                    model.nick_name = user.nick_name;
                    model.use_min = 0;
                    model.use_sec = 0;
                    model.truth_num = truth_count;
                    model.count = exa.nums;
                    model.truth_ratio = 0;
                    model.score = score;
                    model.status = (int)EnumCollection.correcting_status.未批改;
                    model.add_time = System.DateTime.Now;

                    bll.Add(model);
                }
            }
        }
        #endregion

        #region 保存英文发音资源
        private void saveWordVoice()
        {
            int id = RequestHelper.GetFormInt("id");
            int group = RequestHelper.GetFormInt("group");
            int school = RequestHelper.GetFormInt("school");
            string school_name = RequestHelper.GetFormString("school_name");
            int chapter = RequestHelper.GetFormInt("chapter");
            string title = RequestHelper.GetFormString("title");
            string userids = RequestHelper.GetFormString("userids");
            string words = RequestHelper.GetFormString("words");

            Appoa.Web.UI.ManagePage mngPage = new Web.UI.ManagePage();
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);

            if (model != null)
            {
                model.group_id = group;
                if (model.group_id == (int)EnumCollection.resource_group.公共资源)
                {
                    model.school_id = 0;
                    model.school_name = "";
                }
                else
                {
                    model.school_id = school;
                    model.school_name = school_name;
                }

                model.data_id = chapter;
                model.user_id = mngPage.GetAdminInfo().id;

                model.title = title;
                model.path = words;
                model.share_user = userids;

                if (bll.Update(model))
                {
                    mngPage.AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改英文发音资源信息，主键:" + id); //记录日志

                    writeMsgSuccess("保存成功");
                }
                else
                {
                    writeMsgError("保存失败");
                }
            }
            else
            {
                model = new Model.common_resource();
                model.from_id = (int)EnumCollection.resource_from.精品微课;
                model.group_id = group;
                model.type = (int)EnumCollection.resource_type.英文发音;

                if (model.group_id == (int)EnumCollection.resource_group.公共资源)
                {
                    model.school_id = 0;
                    model.school_name = "";
                }
                else
                {
                    model.school_id = school;
                    model.school_name = school_name;
                }
                model.data_id = chapter;
                model.user_id = mngPage.GetAdminInfo().id;

                model.title = title;
                model.cover = "";
                model.path = words;
                model.qrcode = "";
                model.file_name = "";
                model.extend = "";
                model.likn_url = "";
                model.add_time = System.DateTime.Now;
                model.share_user = userids;

                int row = bll.Add(model);
                if (row > 0)
                {
                    model.id = row;
                    model.qrcode = "/QrCode.aspx?type=re&id=" + row;
                    bll.Update(model);

                    mngPage.AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加英文发音资源信息，主键:" + row); //记录日志

                    writeMsgSuccess("保存成功");
                }
                else
                {
                    writeMsgError("保存失败");
                }
            }
        }
        #endregion

        #region 查询英文发音资源
        private void getWordVoice()
        {
            int id = RequestHelper.GetFormInt("id");

            Model.common_resource model = new BLL.common_resource().GetModel(id);

            writeMsgSuccess("", model);
        }
        #endregion

        #region 设置课堂是否公开
        private void SetClassroomIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.classroom_info bll = new BLL.classroom_info();
            Model.classroom_info model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_show == (int)EnumCollection.course_is_show.是)
                {
                    model.is_show = (int)EnumCollection.course_is_show.否;
                }
                else
                {
                    model.is_show = (int)EnumCollection.course_is_show.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 保存题目信息
        private void saveQuestionOptions()
        {
            int id = RequestHelper.GetFormInt("id");
            int group = RequestHelper.GetFormInt("group", 0);
            int type = RequestHelper.GetFormInt("type", 0);
            int chapter = RequestHelper.GetFormInt("chapter", 0);
            string title = RequestHelper.GetFormString("title");
            int score = RequestHelper.GetFormInt("score", 0);
            string answers = RequestHelper.GetFormString("answers");
            string analysis = RequestHelper.GetFormString("analysis");
            string options = RequestHelper.GetFormString("options");

            Appoa.Web.UI.ManagePage mngPage = new Web.UI.ManagePage();
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = bll.GetModel(id);

            if (model != null)
            {
                #region 修改题目信息
                model.group_id = group;
                model.type = type;
                model.data_id = chapter;
                model.number = 0;
                model.title = title;
                model.answer = (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题
                    || model.type == (int)EnumCollection.questions_type.判断题) ? answers.Trim().ToUpper() : answers.Trim();
                model.score = score;
                model.analysis = HttpUtility.UrlDecode(analysis, System.Text.Encoding.UTF8);

                if (bll.Update(model))
                {
                    try
                    {
                        #region 选择题设置选项
                        if (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题 || model.type == (int)EnumCollection.questions_type.判断题)
                        {
                            JArray optionArr = JsonConvert.DeserializeObject<JArray>(options);
                            BLL.common_answers anBll = new BLL.common_answers();
                            Model.common_answers anModel = null;

                            List<int> ids = new List<int>();
                            foreach (JObject obj in optionArr)
                            {
                                ids.Add(Convert.ToInt32(obj["options_id"].ToString()));
                            }

                            DataTable dt = anBll.GetList(" question_id = " + model.id);
                            foreach (DataRow item in dt.Rows)
                            {
                                int afid = Convert.ToInt32(item["id"]);
                                if (afid > 0)
                                {
                                    if (!ids.Contains(afid))
                                    {
                                        anBll.Delete(afid);
                                    }
                                }
                            }

                            foreach (JObject item in optionArr)
                            {
                                int options_id = Convert.ToInt32(item["options_id"]);
                                anModel = anBll.GetModel(options_id);
                                if (anModel != null)
                                {
                                    #region 修改选项
                                    anModel.question_id = model.id;
                                    anModel.options = item["options"].ToString();
                                    anModel.contents = item["options_contents"].ToString();
                                    anModel.score = Convert.ToInt32(item["options_score"].ToString());
                                    if (anBll.Update(anModel))
                                    {
                                        mngPage.AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改选项信息，主键:" + options_id); //记录日志
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region 添加选项
                                    anModel = new Model.common_answers();
                                    anModel.question_id = model.id;
                                    anModel.options = item["options"].ToString();
                                    anModel.contents = item["options_contents"].ToString();
                                    anModel.score = Convert.ToInt32(item["options_score"].ToString());
                                    anModel.add_time = System.DateTime.Now;

                                    int anid = anBll.Add(anModel);
                                    if (anid > 0)
                                    {
                                        mngPage.AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加选项信息，主键:" + anid); //记录日志
                                    }
                                    #endregion
                                }
                            }
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        writeMsgError("系统错误：" + e.Message);
                    }

                    mngPage.AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改试题信息，主键:" + model.id); //记录日志

                    writeMsgSuccess("修改题目信息成功");
                }
                else
                {
                    writeMsgError("修改题目信息失败");
                }
                #endregion
            }
            else
            {
                #region 添加题目信息
                model = new Model.common_questions();
                model.group_id = group;
                model.type = type;
                model.data_id = chapter;
                model.number = 0;
                model.title = title;
                model.answer = (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题
                    || model.type == (int)EnumCollection.questions_type.判断题) ? answers.Trim().ToUpper() : answers.Trim();
                model.score = score;
                model.analysis = HttpUtility.UrlDecode(analysis, System.Text.Encoding.UTF8);
                model.add_time = System.DateTime.Now;

                int qid = bll.Add(model);
                if (qid > 0)
                {
                    try
                    {
                        #region 选择题设置选项
                        if (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题 || model.type == (int)EnumCollection.questions_type.判断题)
                        {
                            JArray optionArr = JsonConvert.DeserializeObject<JArray>(options);
                            BLL.common_answers anBll = new BLL.common_answers();
                            Model.common_answers anModel = null;

                            foreach (JObject item in optionArr)
                            {
                                int options_id = Convert.ToInt32(item["options_id"]);
                                if (options_id > 0)
                                {
                                    #region 修改选项
                                    anModel = anBll.GetModel(options_id);
                                    if (anModel != null)
                                    {
                                        anModel.question_id = qid;
                                        anModel.options = item["options"].ToString();
                                        anModel.contents = item["options_contents"].ToString();
                                        anModel.score = Convert.ToInt32(item["options_score"].ToString());
                                        if (anBll.Update(anModel))
                                        {
                                            mngPage.AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改选项信息，主键:" + options_id); //记录日志
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region 添加选项
                                    anModel = new Model.common_answers();
                                    anModel.question_id = qid;
                                    anModel.options = item["options"].ToString();
                                    anModel.contents = item["options_contents"].ToString();
                                    anModel.score = Convert.ToInt32(item["options_score"].ToString());
                                    anModel.add_time = System.DateTime.Now;

                                    int anid = anBll.Add(anModel);
                                    if (anid > 0)
                                    {
                                        mngPage.AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加选项信息，主键:" + anid); //记录日志
                                    }
                                    #endregion
                                }
                            }
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        writeMsgError("系统错误：" + e.Message);
                    }

                    mngPage.AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加试题信息，主键:" + qid); //记录日志

                    writeMsgSuccess("添加题目信息成功");
                }
                else
                {
                    writeMsgError("添加题目信息失败");
                }
                #endregion
            }
        }
        #endregion

        #region 查询题目信息
        private void getQuestionOptions()
        {
            int id = RequestHelper.GetFormInt("id");

            Model.common_questions question = new BLL.common_questions().GetModel(id);
            if (question == null)
            {
                writeMsgError("没有此题目");
                return;
            }

            DataTable dt = new BLL.common_answers().GetList(" question_id = " + id + " order by options asc ");

            writeMsgSuccess("", dt);
        }
        #endregion

        #region 设置业务版块是否显示
        private void SetBusinessIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(id);
            if (model != null)
            {
                if (model.upvote == (int)EnumCollection.YesOrNot.是)
                {
                    model.upvote = (int)EnumCollection.YesOrNot.否;
                }
                else
                {
                    model.upvote = (int)EnumCollection.YesOrNot.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 设置产品是否显示
        private void SetProductIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(id);
            if (model != null)
            {
                if (model.upvote == (int)EnumCollection.YesOrNot.是)
                {
                    model.upvote = (int)EnumCollection.YesOrNot.否;
                }
                else
                {
                    model.upvote = (int)EnumCollection.YesOrNot.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 设置案例是否显示
        private void SetCaseIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_del == (int)EnumCollection.YesOrNot.是)
                {
                    model.is_del = (int)EnumCollection.YesOrNot.否;
                }
                else
                {
                    model.is_del = (int)EnumCollection.YesOrNot.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 设置合作伙伴是否显示
        private void SetPartnerIsShow()
        {
            int id = RequestHelper.GetFormInt("id");

            BLL.company_partner bll = new BLL.company_partner();
            Model.company_partner model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_show == (int)EnumCollection.YesOrNot.是)
                {
                    model.is_show = (int)EnumCollection.YesOrNot.否;
                }
                else
                {
                    model.is_show = (int)EnumCollection.YesOrNot.是;
                }

                bll.Update(model);

                HttpContext.Current.Response.Write("1");
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("0");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 查询微课资源
        private void GetCourseResource()
        {
            int type = RequestHelper.GetFormInt("type");
            string keywords = RequestHelper.GetFormString("keywords");
            int page = RequestHelper.GetFormInt("pageIndex", 1);
            int pageSize = RequestHelper.GetFormInt("pageSize", 10);

            Utils.WriteCookie("manager_page_size", "AppoaPage", pageSize.ToString(), 14400);

            #region 组装查询条件
            string whereStr = " from_id = " + (int)EnumCollection.resource_from.精品微课 + " and is_del = 0 and type = " + type;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    writeMsgError("搜索关键词中包含危险字符，检索终止！");
                    return;
                }
            }

            #endregion

            BLL.common_resource bll = new BLL.common_resource();
            DataTable dt = bll.GetListByPage("*", "View_ChapterResource", whereStr, " sort asc ", page, pageSize);

            int totalCount = bll.GetRecordCount("View_ChapterResource", whereStr);

            int pageCount = 0;
            if (totalCount % pageSize == 0)
            {
                pageCount = (int)(totalCount / pageSize);
            }
            else
            {
                pageCount = ((int)(totalCount / pageSize)) + 1;
            }

            var obj = new
            {
                DataList = dt,
                TotalCount = totalCount,
                PageCount = pageCount
            };

            writeMsgSuccess("", new List<object>() { obj });
        }
        #endregion

        #region 把选中的微课资源复制到课堂资源里
        private void SaveClassroomResource()
        {
            int class_id = RequestHelper.GetFormInt("class_id");
            string ids = RequestHelper.GetFormString("ids");

            string[] idArr = ids.Split(',');
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = null;
            Model.common_resource newModel = null;
            for (int i = 0; i < idArr.Length; i++)
            {
                int id = Convert.ToInt32(idArr[i]);

                model = bll.GetModel(id);
                if (model != null)
                {
                    newModel = model;
                    newModel.id = 0;
                    newModel.from_id = (int)EnumCollection.resource_from.课堂;
                    newModel.data_id = class_id;

                    bll.Add(newModel);
                }
            }

            writeMsgSuccess("成功");
        }
        #endregion

        #region 输出json

        #region 失败输出
        /// <summary>
        /// 失败输出
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgError(string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.error(msg));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 失败输出
        /// <summary>
        /// 失败输出
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgError(int code, string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.error(code, msg));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 成功输出
        /// <summary>
        /// 成功输出
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="o">不返回数据为null,其他位数组对象</param>
        private void writeMsgSuccess(string msg, object o = null)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.success(msg, o));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}