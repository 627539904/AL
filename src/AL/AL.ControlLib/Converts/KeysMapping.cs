using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.ControlLib.Converts
{
    public class KeysMapping
    {
        public static string KeyString(Keys key)
        {
            string keyString = string.Empty;
            // 检查按键并转换为所需的字符串
            switch (key)
            {
                case Keys.Escape:
                    keyString = "Esc";
                    break;
                case Keys.Back:
                    keyString = "Back";
                    break;
                case Keys.Tab:
                    keyString = "Tab";
                    break;
                case Keys.Clear:
                    keyString = "Clear";
                    break;
                case Keys.Enter:
                    keyString = "Enter";
                    break;
                case Keys.Shift:
                case Keys.ShiftKey:
                    keyString = "Shift";
                    break;
                case Keys.LShiftKey:
                    keyString = "LShift";
                    break;
                case Keys.RShiftKey:
                    keyString = "RShift";
                    break;
                case Keys.Control:
                case Keys.ControlKey:
                    keyString = "Ctrl";
                    break;
                case Keys.LControlKey:
                    keyString = "LCtrl";
                    break;
                case Keys.RControlKey:
                    keyString = "RCtrl";
                    break;
                case Keys.LMenu:
                    keyString = "LAlt";
                    break;
                case Keys.RMenu:
                    keyString = "RAlt";
                    break;
                case Keys.Left:
                    keyString = "←";
                    break;
                case Keys.Up:
                    keyString = "↑";
                    break;
                case Keys.Right:
                    keyString = "→";
                    break;
                case Keys.Down:
                    keyString = "↓";
                    break;
                case Keys.Oem3:
                    keyString = "`";
                    break;
                case Keys.OemMinus: // 通常是减号（-）键，但可能带有Shift时是下划线（_）
                    keyString = "-"; // 根据需要，您可以添加逻辑来处理Shift状态
                    break;
                case Keys.Add: // 通常是加号（+）键
                    keyString = "+";
                    break;
                case Keys.Oem4: // 通常是方括号的一部分（[或{），但可能因键盘布局而异
                    keyString = "["; // 或根据布局使用"{"
                    break;
                case Keys.Oem6: // 通常是方括号的一部分（]或}），但可能因键盘布局而异
                    keyString = "]"; // 或根据布局使用"}"
                    break;
                case Keys.OemPipe: // 通常是反斜杠（\）或竖线（|），但可能因键盘布局而异
                    keyString = "\\"; // 或根据布局使用"|"
                    break;
                case Keys.Oem7: // 通常是单引号（'）或双引号（"），但可能因键盘布局而异
                    keyString = "'"; // 或根据布局使用"\""
                    break;
                case Keys.Oemcomma: // 通常是逗号（,）或小于号（<）
                    keyString = ","; // 或根据布局使用"<"
                    break;
                case Keys.OemPeriod: // 通常是句号（.）或大于号（>）
                    keyString = "。"; // 或根据布局使用">"
                    break;
                case Keys.Oem2: // 通常是斜杠（/）或问号（?）
                    keyString = "/"; // 或根据布局使用"?"
                    break;
                case Keys.Decimal:
                    keyString = "."; // 小键盘上的点键
                    break;
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.D0:
                    // 对于主键盘上的数字键，去掉 'D' 前缀并转换为数字字符串
                    keyString = key.ToString().Substring(1);
                    break;

                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.NumPad0:
                    // 对于小键盘上的数字键，添加 'Num' 前缀
                    keyString = "Num" + key.ToString().Substring(6); // "NumPad" 长度为 6
                    break;

                default:
                    // 对于其他键，可以返回按键的原始名称或进行其他处理
                    keyString = key.ToString();
                    break;
            }
            return keyString;
        }
    }
}
