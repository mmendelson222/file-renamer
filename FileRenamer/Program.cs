using FileRenamer.Settings;
using NDesk.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalSettings.ParseCommandLine(args);

            switch (GlobalSettings.AppAction)
            {
                case GlobalSettings.eAppAction.showHelp:
                    GlobalSettings.ShowHelp();
                    break;
                case GlobalSettings.eAppAction.encrypt:
                    Console.WriteLine("Encrypt!");
                    break;
                default:
                    Console.WriteLine("default!");
                    break;
            }

            Prompt();
        }

        private static void Prompt()
        {
            if (GlobalSettings.PromptAfter)
            {
                Console.WriteLine("press any key");
                Console.ReadKey(true);
            }
        }       
    }
}
