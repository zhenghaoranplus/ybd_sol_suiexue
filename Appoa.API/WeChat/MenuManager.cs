using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;


namespace Appoa.API.WeChat
{
    public static class MenuManager
    {
        /// <summary>
        /// 菜单文件路径
        /// </summary>
        private static readonly string Menu_Data_Path = System.AppDomain.CurrentDomain.BaseDirectory + "/menu.txt";
        /// <summary>
        /// 获取菜单
        /// </summary>
        public static string GetMenu()
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", WeChatContext.AccessToken);

            return HttpUtility.GetData(url);
        }
        /// <summary>
        /// 创建菜单
        /// </summary>
        public static string CreateMenu(string menu)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", WeChatContext.AccessToken);
            //string menu = FileUtility.Read(Menu_Data_Path);
            return HttpUtility.SendHttpRequest(url, menu);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        public static string DeleteMenu()
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", WeChatContext.AccessToken);
            return HttpUtility.GetData(url);
        }
        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public static string LoadMenu()
        {
            return FileUtility.Read(Menu_Data_Path);
        }
    }
}
