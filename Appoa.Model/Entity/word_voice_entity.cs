using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class word_voice_entity
    {
        /// <summary>
        /// 单词
        /// </summary>
        public string word_name { get; set; }
        /// <summary>
        /// 词性
        /// </summary>
        public string word_nature { get; set; }
        /// <summary>
        /// 翻译
        /// </summary>
        public string word_translate { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string word_sort { get; set; }
        /// <summary>
        /// 音频地址
        /// </summary>
        public string video_path { get; set; }
    }
}
