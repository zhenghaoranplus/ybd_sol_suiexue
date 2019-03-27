using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Appoa.Manage.pc
{
    public class PageListHelper
    {
        public static string OutPageList(int totalCount, int pageIndex, int pageSize, string pageurl)
        {
            int total_page = 0;
            if (totalCount % pageSize == 0)
            {
                total_page = Convert.ToInt32(totalCount / pageSize);
            }
            else
            {
                total_page = Convert.ToInt32(totalCount / pageSize) + 1;
            }

            StringBuilder stb = new StringBuilder();

            if (total_page > 1)
            {
                stb.Append("<li page='1'>首页</li>");

                string classnoom = string.Empty;
                for (var i = 1; i <= total_page; i++)
                {
                    if (i == pageIndex)
                    {
                        classnoom = " class='thisclass'";
                    }
                    else
                    {
                        classnoom = "";
                    }

                    stb.Append("<li page='" + i + "' " + classnoom + "><a href='" + pageurl.Replace("__id__", i + "") + "'>" + i + "</a></li>");
                }

                stb.Append("<li page='" + total_page + "'>末页</li>");
            }
            else
            {
                stb.Append("<li page='1' class='thisclass'>1</li>");
            }

            return stb.ToString();
        }
    }
}