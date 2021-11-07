using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Settings
{
    public static class InputControl
    {
        public static string InputOption(string text)
        {
            System.Console.Write($"Enter {text} : ");
            return System.Console.ReadLine();
        }
    }
}
