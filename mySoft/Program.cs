using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Prijava prijava = new Prijava();
            DialogResult loginRezultat = prijava.ShowDialog();
            if (loginRezultat == DialogResult.OK)
            {
                // login was successful
                Application.Run(new Dashboard());

            }
        }
    }
}
