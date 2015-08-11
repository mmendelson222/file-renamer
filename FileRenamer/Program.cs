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
            try
            {
                GlobalSettings.ParseCommandLine(args);
                switch (GlobalSettings.AppAction)
                {
                    case GlobalSettings.eAppAction.showHelp:
                        GlobalSettings.ShowHelp();
                        break;
                    default:
                        Console.WriteLine("default!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Prompt();
            }
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
