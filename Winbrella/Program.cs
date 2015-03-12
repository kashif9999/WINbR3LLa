using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using CFManzana;

namespace Winbrella
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
		Type checkiTunes = Type.GetTypeFromProgID("iTunes.Application");
        try
        {
            if (checkiTunes == null)
            {
                MessageBox.Show("Failed to load, are you sure you have iTunes(v10+) Installed on your system.\r\nYou will need to Intall iTunes once done. Restart application.", "W|NbR3LL@" + winbrella.appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //     ProcessStartInfo iTunes = new ProcessStartInfo("www.apple.com/itunes/download/");
                //     Process.Start(iTunes);
           //     Application.EnableVisualStyles();
             //   Application.SetCompatibleTextRenderingDefault(false);
             //   Application.Run(new winbrella());
              return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new winbrella());
            }
        }
            catch(Exception e)
        {
            MessageBox.Show(e.Message);
            return;
        }
        }
    }
}
