using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileWorx
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
           Application.Run(new Login());
            // Console.WriteLine(Guid.NewGuid());

            //String ss = "Qais2%%$$##QQ%%$$##woow%%$$##6de597a2 - 3c88 - 4f16 - 9f1f - 8f898e5a3b59.txt";
           // String[] arr = ss.Split(new string[] { "%%$$##" }, StringSplitOptions.None);

             //MessageBox.Show(Directory.GetCurrentDirectory());
        }
    }
}
