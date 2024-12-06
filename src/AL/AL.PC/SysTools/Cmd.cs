using AL.PC.Models;
using Arvin.Extensions;
using Arvin.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.SysTools
{
    public class Cmd
    {
        public static string Read(string cmd)
        {
            return ProcessHelper.ReadCmd(cmd);
        }

        public static void Run(string cmd)
        {
            ProcessHelper.RunCmd(cmd);
        }

        public static void RunExe(string cmd)
        {
            ProcessHelper.RunExe(cmd);
        }
    }

    public class ACmd
    {
        public static ReceivedModelBase ReceivedModel = new ReceivedModelBase();
        //public static Action<string> OutputThread=text=> ALog.WriteLine(text);
        public static RunCmdModel Run(string cmd = "dir", string workDir = "")
        {
            ALog.WriteLine($"运行指令:{cmd}");
            var res = ACmd.RunCmd(cmd, true, workDir);
            ALog.WriteLine($"运行指令完成!");
            return res;
        }

        public static RunCmdModel RunCmd(string cmd, bool isRecData = true, string workDir = "")
        {
            RunCmdModel res = new RunCmdModel()
            {
                Cmd = cmd,
                WorkDir = workDir,
            };
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {cmd}")  // 示例命令：列出当前目录内容  
            {
                WorkingDirectory = workDir.DefaultValue(Environment.CurrentDirectory),  // 设置工作目录为当前目录
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process process = new Process { StartInfo = startInfo };

            if (isRecData)
            {
                res.Output = new StringBuilder();
                process.Received_Output(ReceivedModel.DataHandle_Output, res.Output);
                res.Error = new StringBuilder();
                process.Received_Error(ReceivedModel.DataHandle_Error, res.Error);
                process.Received_ErrorHandle_Cmd(res);
            }

            process.Start();
            if (isRecData)
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            process.WaitForExit();
            process.Close();
            return res;
        }
    }

    public class RunCmdModel
    {
        public string Cmd { get; set; }
        public string WorkDir { get; set; }
        public StringBuilder Output { get; set; }
        public StringBuilder Error { get; set; }
    }
}
