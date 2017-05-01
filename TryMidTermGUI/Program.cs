using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryMidTermGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileStream fs = new FileStream(@"C:\Users\alex\Documents\Visual Studio 2015\Projects\TryMidTermGUI\TryMidTermGUI\Jammin.wav", FileMode.Open, FileAccess.Read);

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(fs);

            //sp.Play();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
