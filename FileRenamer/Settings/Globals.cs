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
        internal enum eAppAction { runDefault, showHelp, encrypt };

        internal static OptionSet p = new OptionSet() { 
                { "p|prompt", "Prompt after running",  v => GlobalSettings.PromptAfter = true  }, 
                { "e|encrypt", "Encrypt settings",  v => GlobalSettings.AppAction = eAppAction.encrypt }, 
                { "d|days=", "Number of days", v => GlobalSettings.sDays = v},
                { "s|start=", "Start date (mm/dd/yy)", v => GlobalSettings.sStartDate = v},
                { "t|today", "Use today as start date (for testing only)", v => GlobalSettings.StartToday = true },
                { "h|?|help",  "Show help message and exit - list valid tag paths",  v => GlobalSettings.AppAction = eAppAction.showHelp }
            };

        private static string sDays;
        private static string sStartDate;

        /// <summary>
        /// parse the command line and assign to CommandLineSettings as outlined in the OptionSet object.
        /// return TRUE if help was shown.
        /// </summary>
        internal static void ParseCommandLine(string[] args)
        {
            List<string> extra = p.Parse(args);
            if (extra.Count > 0)
                throw new Exception("Invalid option(s): " + string.Join(" ", extra.ToArray()));
        }

       
        internal static void ShowHelp()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Console.WriteLine(string.Format("Usage: {0} [OPTIONS]+ ", asm.GetName().Name));
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        internal static bool PromptAfter { get; set; }

        internal static bool StartToday { get; set; }

        internal static eAppAction AppAction { get; set; }

        /// <summary>
        /// Send alerts for items that were modified in the time range starting with this date. 
        /// </summary>
        internal static DateTime DocumentDateMin { get; set; }
        /// <summary>
        /// Time range ends with this date.  Normally the same as DocumentDateMin
        /// </summary>
        internal static DateTime DocumentDateMax { get; set; }
    }
}
