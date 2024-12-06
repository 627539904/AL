using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Arvin.Extensions;
using System.Collections;
using Arvin.Helpers;
using AL.PC.Models;
using AL.PC;

namespace AL.PC.SysTools
{
    public partial class ProcessHelper
    {

        #region Call Process
        /// <summary>
        /// Process默认初始设置（不启动,有窗口，无重定向）
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="cmdArgs"></param>
        /// <returns></returns>
        public static Process GetDefaultProcess(string exePath, string cmdArgs)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = cmdArgs,
                UseShellExecute = false,
                CreateNoWindow = false,
            };
            return new Process { StartInfo = startInfo };
        }
        public static Process GetDefaultCmd(string cmdArgs="")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = cmdArgs,
                UseShellExecute = false,
                CreateNoWindow = false,
            };
            return new Process { StartInfo = startInfo };
        }
        public static void RunCmd(string cmd, ReceivedModel receivedModel=null)
        {
            //runtime\python.exe api.py -dr "Voice\Lumi\Ref\Lumi.mp3" -dt "¹��������Գ���ֱ���� ���ҿ��ܸ�ϲ��¹�����˸���ľ�ϲŶ" -dl "zh"
            //ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c F:\\AI-Speech\\GPT-SoVITS-beta\\go-webui.bat")  // 示例命令：列出当前目录内容  
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {cmd}")  // 示例命令：列出当前目录内容  
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process process = new Process { StartInfo = startInfo };

            if (receivedModel != null)
            {
                process.Received_Output(receivedModel.Write, receivedModel.DataHandle_Output);
                process.Received_Error(receivedModel.Write, receivedModel.DataHandle_Error);
            }

            process.Start();
            if (receivedModel != null)
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            process.WaitForExit();
            process.Close();
        }

        /// <summary>
        /// 直接进行Process调用,无参数
        /// </summary>
        /// <param name="cmdArgs"></param>
        /// <param name="okMark"></param>
        public static void CallProcessNoArgs(string exePath, string okMark = "successfully")
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = exePath.GetDirectoryFromPath(),
                    UseShellExecute = false,
                    CreateNoWindow = false,// 如果不需要看到cmd窗口，可以设置为true  
                    RedirectStandardOutput = true,// 通常不需要重定向输出，除非你想捕获它  
                    RedirectStandardError = true, // 同上
                    Verb = "runas" // 尝试以管理员身份运行
                };

                using (Process process = Process.Start(startInfo))
                {
                    ALog.WriteLine(okMark);
                }
            }
            catch (Exception ex)
            {
                ALog.WriteLine("无法以管理员身份启动进程: " + ex.Message);
            }
        }

        /// <summary>
        /// 根据cmd调用FFmpeg，使用该方法需要配置FFmpeg环境变量
        /// </summary>
        /// <param name="command"></param>
        /// <param name="okMark"></param>
        public static void CallProcessByCmd(string command, string okMark = "successfully", string proccessName = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(startInfo))
            {
                // 异步读取输出和错误流  
                Task.Run(() =>
                {
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine($"{proccessName} Output:");
                    Console.WriteLine(output);
                });

                Task.Run(() =>
                {
                    string error = process.StandardError.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"{proccessName} Error:");
                        Console.WriteLine(error);
                    }
                });
                process.WaitForExit();
                Console.WriteLine(okMark);
            }
        }

        /// <summary>
        /// 启动进程服务,需要等待服务启动完成
        /// </summary>
        /// <param name="batPath"></param>
        public static void CallProcessBatAPI(CallProcessBatAPIModel model)
        {
            ALog.WriteLine("【CallProcessBatAPI 启动服务中...】");
            if(model==null)
                throw new ArgumentNullException(nameof(model));
            //已经启动则无需启动
            if (model.CheckAPIHealth != null)
            {
                if (model.CheckAPIHealth())
                {
                    model.Write("【服务已启动，无需重复启动！】"+Environment.NewLine);
                    return;
                }
            }
            model.BatPath = model.BatPath.DefaultValue(@"F:\AI-Speech\GPT-SoVITS-beta\go-api.bat");
            model.WorkingDirectory = model.WorkingDirectory.DefaultValue(Path.GetDirectoryName(model.BatPath));
            //Process.Start(batPath);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = model.BatPath.ToAbsolutePath(),
                WorkingDirectory = model.WorkingDirectory.ToAbsolutePath(), // 设置工作目录为批处理文件所在的目录
                UseShellExecute = false, // 设置为false以允许重定向输出  
                CreateNoWindow = model.CreateNoWindow, // 如果不需要看到批处理文件的窗口，可以设置为true  
                WindowStyle= model.WindowStyle
            };
            model.Write($"【CallProcessBatAPI Bat路径：{startInfo.FileName}】" + Environment.NewLine);
            model.Write($"【CallProcessBatAPI 工作目录：{startInfo.WorkingDirectory}】" + Environment.NewLine);
            model.Write("【CallProcessBatAPI 启动服务中... 1】" + Environment.NewLine);
            Process process = new Process { StartInfo = startInfo };
            if (model.DataHandle_Output != null)
                startInfo.RedirectStandardOutput = true;
                process.Received_Output(model.Write, model.DataHandle_Output);
            if (model.DataHandle_Error != null)
                startInfo.RedirectStandardError = true;
                process.Received_Error(model.Write, model.DataHandle_Error);
            process.Start();
            model.Write("【CallProcessBatAPI 启动服务中... 2】" + Environment.NewLine);
            //Process.Start(startInfo);
            if (model.DataHandle_Output != null)
                process.BeginOutputReadLine();
            if (model.DataHandle_Error != null)
                process.BeginErrorReadLine();
            // 在这里等待服务启动  
            if (model.CheckAPIHealth != null)
            {
                int waitTime = 0;
                while (!model.CheckAPIHealth() && waitTime < 30)
                {
                    Thread.Sleep(1000);
                    waitTime++;
                }
                model.Write($"服务启动耗时:{waitTime}s"+Environment.NewLine);
            }
            model.Write("【CallProcessBatAPI 启动服务中... 3】" + Environment.NewLine);
            // 现在可以安全地继续执行后续代码  
            model.Write(model.OkMark+Environment.NewLine);
        }

        private static void WaitForServiceToBeReady(Process process)
        {
            // 这里需要根据你的服务实现一个检查逻辑  
            // 例如，你可以尝试连接到服务的某个API端点，直到它返回成功的响应  
            // 下面的代码只是一个示例，需要根据你的实际情况进行调整  

            bool isServiceReady = false;
            int attempts = 0;
            const int maxAttempts = 10; // 最大尝试次数  
            const int delay = 5000; // 每次尝试之间的延迟时间（毫秒）  

            while (!isServiceReady && attempts < maxAttempts)
            {
                // 尝试检查服务是否就绪（这里需要根据你的服务API进行实现）  
                // 示例：尝试连接到服务的某个健康检查API  
                // isServiceReady = CheckServiceHealth(); // 这个方法需要你自己实现  

                // 如果没有实现健康检查API，这里只是简单地等待一段时间  
                System.Threading.Thread.Sleep(delay);
                attempts++;
            }

            if (!isServiceReady)
            {
                throw new Exception("服务启动失败或超时未就绪");
            }
        }

        #endregion

        #region Cmd
        //在WinForms中嵌入CMD窗口
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        /// <summary>
        /// 在WinForms中嵌入CMD窗口
        /// </summary>
        /// <param name="containerHandle"></param>
        private void StartAndEmbedCmdProcess(nint containerHandle)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = false,
                CreateNoWindow = true,  // 不创建默认窗口  
                WindowStyle = ProcessWindowStyle.Hidden  // 隐藏窗口，稍后我们会嵌入它  
            };

            Process process = new Process { StartInfo = startInfo };
            process.Start();

            // 等待CMD窗口句柄创建  
            process.WaitForInputIdle();
            IntPtr hwndCmd = process.MainWindowHandle;

            // 将CMD窗口嵌入到WinForms的Panel或其他控件中  
            SetParent(hwndCmd, containerHandle);  // 假设你有一个名为panelCmdContainer的Panel控件
        }
        #endregion

        #region Kill Process
        /// <summary>
        /// 根据进程ID结束进程
        /// </summary>
        /// <param name="pId"></param>
        public static void KillProccessByID(int pId)
        {
            try
            {
                // 尝试找到进程号为pId的进程
                Process process = Process.GetProcessById(pId);

                // 如果找到了该进程，则关闭它  
                if (process != null)
                {
                    process.Kill();
                    Console.WriteLine($"进程已成功关闭。");
                }
                else
                {
                    Console.WriteLine($"未找到{pId}进程。");
                }
            }
            catch (ArgumentException)
            {
                // 如果进程不存在，GetProcessById会抛出ArgumentException  
                Console.WriteLine($"[{pId}]进程ID无效或进程不存在。");
            }
            catch (Exception ex)
            {
                // 处理其他可能的异常  
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
        #endregion
    }
}
