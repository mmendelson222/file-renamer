using NDesk.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Settings
{
    internal static class GlobalSettings
    {
        internal enum eAppAction { runDefault, showHelp };

        internal static OptionSet p = new OptionSet() { 
                { "p|prompt", "Prompt after running",  v => GlobalSettings.PromptAfter = true  }, 
                { "n|name", "File name pattern",  v => GlobalSettings.FileNamePattern = v}, 
                { "r|hourshift", "Time shift, in hours",  v => GlobalSettings.sHourShift = v}, 
                { "h|?|help",  "Show help message and exit - list valid tag paths",  v => GlobalSettings.AppAction = eAppAction.showHelp }
            };

        /// <summary>
        /// parse the command line and assign to CommandLineSettings as outlined in the OptionSet object.
        /// return TRUE if help was shown.
        /// </summary>
        internal static void ParseCommandLine(string[] args)
        {
            List<string> extra = p.Parse(args);
            if (extra.Count > 0)
                throw new Exception("Invalid option(s): " + string.Join(" ", extra.ToArray()));
            if (!int.TryParse(sHourShift, out HourShift))
                throw new Exception("Hour Shift must be an integer");
        }


        internal static void ShowHelp()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Console.WriteLine(string.Format("Usage: {0} [OPTIONS]+ ", asm.GetName().Name));
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        private static string sHourShift = "0";

        internal static bool PromptAfter = false;
        internal static string FileNamePattern = "yyyyMMdd-hhmm";
        internal static int HourShift;
        internal static eAppAction AppAction { get; set; }
    }
}
