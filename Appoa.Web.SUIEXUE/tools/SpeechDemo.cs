using System;
using System.Collections.Generic;
using System.IO;
using Baidu.Aip.Speech;

namespace Baidu.Aip.Demo
{
    class SpeechDemo
    {
        //private readonly Asr _asrClient;
        private readonly Tts _ttsClient;

        public SpeechDemo()
        {
            //_asrClient = new Asr("Api Key", "Secret Key");
            _ttsClient = new Tts("SjasQWCPjMIl8oidHKCCn6mh", "cd0945f3f5d1cdeea7504c5885764131");
        }

        // 识别本地文件
        //public void AsrData()
        //{
        //    var data = File.ReadAllBytes("语音pcm文件地址");
        //    var result = _asrClient.Recognize(data, "pcm", 16000);
        //    Console.Write(result);
        //}

        // 识别URL中的语音文件
        //public void AsrUrl()
        //{
        //    var result = _asrClient.Recoginze(
        //        "http://xxx.com/待识别的pcm文件地址", 
        //        "http://xxx.com/识别结果回调地址", 
        //        "pcm", 
        //        16000);
        //    Console.WriteLine(result);
        //}

        // 合成
        public void Tts(string contents, string path)
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"ctp",1}, //客户端类型选择，web端填写1
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 4}  // 发音人，0：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(contents, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes(path, result.Data);
            }
        }

    }
}