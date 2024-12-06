using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL.PC.Models;
using Arvin.Extensions;

namespace AL.PC.SysTools
{
    public partial class ProcessHelper
    {
        public static void RunCmd(string cmd)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {cmd}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,

                //FileName = exePath,
                //WorkingDirectory = exePath.GetDirectoryFromPath(),
                //UseShellExecute = false,
                //CreateNoWindow = false,// 如果不需要看到cmd窗口，可以设置为true  
                //RedirectStandardOutput = true,// 通常不需要重定向输出，除非你想捕获它  
                //RedirectStandardError = true, // 同上
                //Verb = "runas" // 尝试以管理员身份运行
            };

            using (Process process = Process.Start(startInfo))
            {
                // 等待进程退出  
                process.WaitForExit();
                process.Close();
            }
        }
        public static string ReadCmd(string cmd)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {cmd}") 
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            string result = "";
            using (Process process = Process.Start(startInfo))
            {
                // 读取命令行的输出  
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
                // 等待进程退出  
                process.WaitForExit();
                process.Close();
            }
            return result;
        }

        public static void RunExe(string exePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {exePath}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = exePath.GetDirectoryFromPath(),
                //FileName = exePath,
                //WorkingDirectory = exePath.GetDirectoryFromPath(),
                //UseShellExecute = false,
                //CreateNoWindow = false,// 如果不需要看到cmd窗口，可以设置为true  
                //RedirectStandardOutput = true,// 通常不需要重定向输出，除非你想捕获它  
                //RedirectStandardError = true, // 同上
                //Verb = "runas" // 尝试以管理员身份运行
            };

            using (Process process = Process.Start(startInfo))
            {
                // 等待进程退出  
                //process.WaitForExit();
                process.Close();
            }
        }

        /// <summary>
        /// 直接通过exe文件命令调用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="WriteLine">自定义重定向路径</param>
        public static void CallProcess(CallProcModel model, Action<string> WriteLine = null)
        {
            if (WriteLine == null)
                WriteLine = Console.WriteLine;
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = model.FileName,
                Arguments = model.Arguments,
                WorkingDirectory = model.FileName.GetDirectoryFromPath(),
                UseShellExecute = false,
                CreateNoWindow = model.CreateNoWindow,// 如果不需要看到cmd窗口，可以设置为true  
                RedirectStandardOutput = true,// 通常不需要重定向输出，除非你想捕获它  
                RedirectStandardError = true // 同上
            };
            // 打印即将执行的命令行  
            WriteLine($"【发送命令】: {startInfo.FileName} {startInfo.Arguments}" + Environment.NewLine);
            // 打印工作目录  
            string workingDirectory = !string.IsNullOrEmpty(startInfo.WorkingDirectory)
                ? startInfo.WorkingDirectory
                : Environment.CurrentDirectory;

            WriteLine($"【工作目录】: {workingDirectory}" + Environment.NewLine);
            using (Process process = Process.Start(startInfo))
            {
                // 异步读取输出和错误流  
                if (model.DataHandle_Output != null)
                {
                    process.Received_Output(model.Write, model.DataHandle_Output);
                }
                else
                {
                    Task.Run(() =>
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        WriteLine($"Output:");
                        WriteLine(output);
                    });
                }

                if (model.DataHandle_Error != null)
                {
                    process.Received_Error(model.Write, model.DataHandle_Error);
                }
                else
                {
                    Task.Run(() =>
                    {
                        string error = process.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error))
                        {
                            WriteLine($"Error:");
                            WriteLine(error);
                        }
                    });
                }
                process.WaitForExit();
                WriteLine("【命令完成】" + Environment.NewLine);
                WriteLine(model.OkMark + Environment.NewLine);
            }
        }
    }
}
