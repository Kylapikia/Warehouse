using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3UI
{
    public partial class Login : Form
    {
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string password = Encrypt(textBoxPassword.Text.Trim());
            SqlConnection conn = new SqlConnection(CSTRING);
            String query = "Select * from Users Where Username = '" + textBoxUsername.Text.Trim() + "' and Password = '" + password + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[3].ToString() == "Investor")
                {
                    Investor objFormMain = new Investor(reader[3].ToString());
                    this.Hide();
                    objFormMain.Closed += (s, args) => this.Close();
                    objFormMain.Show();
                }
                else
                {
                    MainForm objFormMain = new MainForm(reader[3].ToString());
                    this.Hide();
                    objFormMain.Closed += (s, args) => this.Close();
                    objFormMain.Show();

                }
                conn.Close();
                //MainForm objFormMain = new MainForm("Investor");
                //this.Hide();
                //objFormMain.Closed += (s, args) => this.Close();
                //objFormMain.Show();
            }
            else
            {
                conn.Close();
                MessageBox.Show("Check your username and password");
            }
        }

        private string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
