using AL.PC.SysTools;
using Arvin.Extensions;
using Arvin.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AL.PC
{
    public static class ProcessExtension
    {
        #region Process
        public static void DataHandle(this DataReceivedEventArgs e)
        {
            ALog.Write(e.Data + Environment.NewLine);
        }
        public static void ErrorHandle(this DataReceivedEventArgs e)
        {
            ALog.Write("Error: " + e.Data + Environment.NewLine);
        }
        #endregion

        /// <summary>
        /// 接收输出
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appendText">输出目标</param>
        /// <param name="dataHandle">数据处理</param>
        public static void Received_Output(this Process process, Action<string> appendText, Action<DataReceivedEventArgs, Action<string>> dataHandle)
        {
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    dataHandle(e, appendText);
                }
            };
        }

        public static void Received_Output(this Process process, Action<DataReceivedEventArgs> dataHandle, StringBuilder sb = null)
        {
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    if (sb != null)
                        sb.Append(e.Data);
                    dataHandle(e);
                }
            };
        }

        /// <summary>
        /// 接收错误
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appendText"></param>
        /// <param name="dataHandle"></param>
        public static void Received_Error(this Process process, Action<string> appendText, Action<DataReceivedEventArgs, Action<string>> dataHandle)
        {
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    dataHandle(e, appendText);
                }
            };
        }
        public static void Received_Error(this Process process, Action<DataReceivedEventArgs> dataHandle,StringBuilder sb=null)
        {
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    if (sb != null)
                        sb.Append(e.Data);
                    dataHandle(e);
                }
            };
        }
        public static void Received_ErrorHandle_Cmd(this Process process, RunCmdModel cmdModel)
        {
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Task.Run(() => ErrorHandle(cmdModel));
                }
            };
        }

        //设置Process为后台窗口
        public static Process SetBackWindow(this Process process)
        {
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            return process;
        }

        public static void ErrorHandle(this RunCmdModel cmdModel,int index=0)
        {
            if (cmdModel.Error.Length <= 0)
                return;
            int maxIndex = 10;
            if (index > maxIndex) //避免递归死循环
                return;
            string cmdHandle = AError.CmdHandle(cmdModel.Error.ToString());
            if (cmdHandle.IsNullOrWhiteSpace()) 
                return;
            ALog.WriteLine("存在错误处理命令");
            var newCmdModel= ACmd.Run(cmdHandle, workDir: cmdModel.WorkDir);

            if(newCmdModel.Error.Length > 0)
                ErrorHandle(newCmdModel,++index);
            else if(index == 0)
                ACmd.Run(cmdModel.Cmd, workDir: cmdModel.WorkDir);
        }
    }
}
