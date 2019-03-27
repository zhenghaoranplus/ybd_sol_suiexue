using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Appoa.API.WeChat
{
    public class FileUtility
    {
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>string</returns>
        public static string Read(string path)
        {
            string result = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(fs, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }
        public static void StringToTxt(string str)
        {
            string ws = System.AppDomain.CurrentDomain.BaseDirectory;

            string f = ws + "/EXECsqllog/EXECsqllog" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!System.IO.Directory.Exists(ws + "/EXECsqllog/"))
            {
                Directory.CreateDirectory(ws + "/EXECsqllog/");
            }
            if (!File.Exists(f))
            {
                using (FileStream fs1 = new FileStream(f, FileMode.Create, FileAccess.Write))//创建写入文件 
                {
                    using (StreamWriter sw = new StreamWriter(fs1))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + ":" + str);//开始写入值
                    }
                }
            }
            else
            {
                using (FileStream fs = new FileStream(f, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.WriteLine(DateTime.Now.ToString() + ":" + str);//开始写入值
                    }
                }

            }
        }
    }
}
