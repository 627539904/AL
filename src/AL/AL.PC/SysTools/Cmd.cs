using System;
using System.Collections.Generic;
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
}
