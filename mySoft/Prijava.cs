using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; //potrebno za pomjeranje forme
using MySql.Data;
using MySql.Data.MySqlClient;

namespace mySoft
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearLabel(){
            if (passwordLabel.Text.Equals("Pogrešna lozinka"))
            {
              this.password ="";
              passwordLabel.Text ="";
            }
        }
        private void num1_Click(object sender, EventArgs e)
        {
            clearLabel();
            {
                this.password += 1;
                passwordLabel.Text += "*";
            }
        }

        private void num2_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 2;
            passwordLabel.Text += "*";
        }

        private void num3_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 3;
            passwordLabel.Text += "*";
        }

        private void num4_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 4;
            passwordLabel.Text += "*";
        }

        private void num5_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 5;
            passwordLabel.Text += "*";
        }

        private void num6_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 6;
            passwordLabel.Text += "*";
        }

        private void num7_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 7;
            passwordLabel.Text += "*";
        }

        private void num8_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 8;
            passwordLabel.Text += "*";
        }

        private void num9_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 9;
            passwordLabel.Text += "*";
        }

        private void num0_Click(object sender, EventArgs e)
        {
            clearLabel();
            this.password += 0;
            passwordLabel.Text += "*";
        }

        private void deleteLastChar_Click(object sender, EventArgs e)
        {
            clearLabel();
            if (this.password.Length > 0)
            {
                this.password = password.Remove(this.password.Length - 1);
                passwordLabel.Text = passwordLabel.Text.Remove(passwordLabel.Text.Length - 1);
            }
        }
        private static string mySqlExecute(String command)
        {
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();

            MySqlConnection conn = new MySqlConnection(@"server=" + server + ";userid=" + username + ";"
            + "password=" + password + ";database=" + database);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand(@command, conn);
            string com = "0";
            if (sqlCommand.ExecuteScalar() != null)
            {
                com = sqlCommand.ExecuteScalar().ToString();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return com;
        }

        private void prijavaButton_Click(object sender, EventArgs e)
        {
            String command = "SELECT korisnik.Id FROM korisnik "
                + "where korisnik.Sifra = \"" + password + "\"";
           // MessageBox.Show(command);
            int korisnikId = Convert.ToInt32(mySqlExecute(command));
            if (korisnikId > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                passwordLabel.Text = "Pogrešna lozinka";
            }
        }

    }
}
