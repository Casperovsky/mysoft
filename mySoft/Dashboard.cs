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
using System.Configuration; //
using MySql.Data.MySqlClient;

namespace mySoft
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.sifarnikSubMenu.Visible = false;
            this.top_panel.MouseDown += Panel_MouseDown; //pomjeranje forme naslovne
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
        
        private void izlazButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sifarnikButton_Click(object sender, EventArgs e)
        {
            this.sifarnikSubMenu.Visible = true;
        }
        private void sifarnikSubMenu_MouseLeave(object sender, EventArgs e)
        {
            this.sifarnikSubMenu.Visible = false;
            System.Diagnostics.Debug.WriteLine("button1_MouseCaptureChanged");
        }
        private void button_OnMouseLeave(object sender, EventArgs e)
        {
            this.sifarnikSubMenu.Visible = false;
        }

        private void artikliButton_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = new List<string> { "Aktivan", "Neaktivan"};
            statusArtiklaComboBox.DataSource = bs;
            this.titleLabel.Text = "Šifarnik artikala i usluga";
            
            MySqlDataAdapter sda = mySQLConnection.myDataAdapterSQL("SELECT * FROM proizvodjac_robe");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            proizvodjacArtiklaComboBox.ValueMember = "Id";
            proizvodjacArtiklaComboBox.DisplayMember = "Naziv";
            proizvodjacArtiklaComboBox.DataSource = dt;
            sda = mySQLConnection.myDataAdapterSQL("SELECT * FROM jedinica_mjere");
            DataTable dt2 = new DataTable();
            sda.Fill(dt2);
            jedinicaMjereArtiklaComboBox.ValueMember = "Id";
            jedinicaMjereArtiklaComboBox.DisplayMember = "Naziv";
            jedinicaMjereArtiklaComboBox.DataSource = dt2;


        }


    }
}
