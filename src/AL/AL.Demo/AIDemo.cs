using AL.PC.SysTools;
using Arvin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Demo
{
    internal class AIDemo
    {
        public static void Demo()
        {
            Console.Write("请输入命令：");
            string input=Console.ReadLine();
            //Client("你好");
            Cmd(input);
        }

        static void Client(string input)
        {
            ALog.WriteLine("Client: " + input);
        }

        static void Cmd(string cmd)
        {
            ACmd.Run(cmd);
        }
    }
}
