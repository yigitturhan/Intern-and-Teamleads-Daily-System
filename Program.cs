using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
            if (!IsAnyWindowVisible())
            {
                return;
            }
        }
        static bool IsAnyWindowVisible()
        {
            return Process.GetProcesses().Any(p => !string.IsNullOrEmpty(p.MainWindowTitle));
        }
    }
}
