using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //potrebno za pomjeranje forme
using System.Security.Cryptography; //potrebno hesovanje sifri

namespace mySoft
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
            this.titleBar.MouseDown += Panel_MouseDown; //pomjeranje forme naslovne
        }
        //Potrebno za pomjeranje forme
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //kraj pomjeranje forme
        private void Panel_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prijavaButton_Click(object sender, EventArgs e)
        {
            String command = "SELECT korisnik.Id FROM korisnik "
                + " where korisnik.Ime = \"" + korisnikTextBox.Text + "\"";
            //MessageBox.Show(command);
            int korisnikId = Convert.ToInt32(mySQLConnection.mySqlExecute(command));
            if (korisnikId > 0)
            {
                command = "SELECT korisnik.Sifra FROM korisnik "
                + " where korisnik.Id = " + korisnikId;
                /* Extract the bytes */

                byte[] hashBytes = Convert.FromBase64String(mySQLConnection.mySqlExecute(command));
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(lozinkaTextBox.Text, salt, 1000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        errorLabel.Text = "Pogrešna lozinka.";
                        break;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else errorLabel.Text = "Pogrešno korisničko ime.";
        }

    }
}
