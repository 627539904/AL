using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    public class CallProcModel : ReceivedModel
    {
        /// <summary>
        /// exePath
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// cmdArgs
        /// </summary>
        public string Arguments { get; set; }
        /// <summary>
        /// 如果不需要看到cmd窗口，可以设置为true
        /// </summary>
        public bool CreateNoWindow { get; set; } = false;
        public string OkMark { get; set; } = "successfully";
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Output { get; set; } = null;
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Error { get; set; } = null;
    }

    public class CallProcessBatAPIModel: CallProcModel
    {
        public CallProcessBatAPIModel() 
        { 
            this.OkMark = "服务已启动并准备就绪";
        }
        public string BatPath { get; set; }
        public string WorkingDirectory { get; set; } = "";
        public Func<bool> CheckAPIHealth { get; set; } = null;
        public ProcessWindowStyle WindowStyle { get; set; } = ProcessWindowStyle.Normal;


        //public static void Received_Output(this Process process, Action<string> appendText, Action<DataReceivedEventArgs, Action<string>> dataHandle)
        
    }

    public class ReceivedModel: IReceived
    {
        public Action<string> Write { get; set; } = (text)=>Console.WriteLine(text);
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Output { get; set; } = null;
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Error { get; set; } = null;
    }

    public class ReceivedModelBase
    {
        public Action<DataReceivedEventArgs> DataHandle_Output { get; set; } = e=> e.DataHandle();
        public Action<DataReceivedEventArgs> DataHandle_Error { get; set; } = e=> e.ErrorHandle();
    }

    public interface IReceived
    {
        public Action<string> Write { get; set; }
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Output { get; set; }
        public Action<DataReceivedEventArgs, Action<string>> DataHandle_Error { get; set; }
    }
}
