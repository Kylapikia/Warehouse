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
    public partial class AddUser : Form
    {
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //const string CSTRING = @"Server=inv-vdi-bitsql1;Database=SCM;Trusted_Connection=True;";
        private string currentType = null;
        private int currentUserID = -1;
        private string level;

        public AddUser(string pLevel)
        {
            InitializeComponent();
            level = pLevel;
            currentType = "I";
            ClearTextBoxes();
            SetPremissions();
        }
        private void SetPremissions()
        {
            switch (level)
            {
                case "A":
                    buttonAddUser.Enabled = true;
                    buttonInvestor.Enabled = true;
                    buttonReport.Enabled = true;
                    buttonTrackItems.Enabled = true;
                    break;
                case "E":
                    buttonAddUser.Enabled = false;
                    buttonInvestor.Enabled = false;
                    buttonReport.Enabled = false;
                    buttonTrackItems.Enabled = true;

                    break;
                case "I":
                    buttonAddUser.Enabled = false;
                    buttonInvestor.Enabled = true;
                    buttonReport.Enabled = true;
                    buttonTrackItems.Enabled = false;
                    break;
            }
        }

        // populates table with Item data based on 'currentType'
        private void SetUpGrid()
        {
            if (currentType == "E")
            {
                labelTitle.Text = "Employee";
            }
            else if (currentType == "I")
            {
                labelTitle.Text = "Investor";
            }
            else if (currentType == "C")
            {
                labelTitle.Text = "Customer";
            }
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select userid,name,PhoneNumber,Email from users where Level='" + currentType + "'", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView.DataSource = dtbl;

                conn.Close();
            }

        }
        private void buttonTrackItems_Click(object sender, EventArgs e)
        {
            MainForm objFormMain = new MainForm(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void buttonInvestor_Click(object sender, EventArgs e)
        {
            Investor objFormMain = new Investor(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Report objFormMain = new Report(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //int investorID = GetInvestorID();
            // new Item


            if (currentUserID == -1)
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "insert into Users values (@USERNAME, @PASSWORD,@LEVEL,@NAME,@PHONENUMBER,@EMAIL,@DOB,@ADDRESS)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@USERNAME", textBoxUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@PASSWORD", Encrypt(textBoxPassword.Text.Trim()));
                    cmd.Parameters.AddWithValue("@LEVEL", textBoxType.Text.Trim());
                    cmd.Parameters.AddWithValue("@NAME", textBoxName.Text.Trim());
                    cmd.Parameters.AddWithValue("@PHONENUMBER", int.Parse(textBoxPhone.Text.Trim()));
                    cmd.Parameters.AddWithValue("@EMAIL", textBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", textBoxDOB.Text.Trim());
                    cmd.Parameters.AddWithValue("@ADDRESS", textBoxAddress.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    SendToTransactionLog("Insert", string.Format("{0},{1},{2},{3},{4},{5},{6}", textBoxUsername.Text.Trim(), textBoxType.Text.Trim(), textBoxName.Text.Trim(), int.Parse(textBoxPhone.Text.Trim()), textBoxEmail.Text.Trim(), textBoxDOB.Text.Trim(), textBoxAddress.Text.Trim()));
                }
            }
            // update Item
            else
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "UPDATE Users SET Username = @USERNAME,Password = @PASSWORD,Level = @LEVEL,Name = @NAME,PhoneNumber = @PHONENUMBER,Email = @EMAIL,DateOfBirth = @DOB,Address = @ADDRESS where userid="+ currentUserID +";";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@USERNAME", textBoxUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@PASSWORD", Encrypt(textBoxPassword.Text.Trim()));
                    cmd.Parameters.AddWithValue("@LEVEL", textBoxType.Text.Trim());
                    cmd.Parameters.AddWithValue("@NAME", textBoxName.Text.Trim());
                    cmd.Parameters.AddWithValue("@PHONENUMBER", int.Parse(textBoxPhone.Text.Trim()));
                    cmd.Parameters.AddWithValue("@EMAIL", textBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", textBoxDOB.Text.Trim());
                    cmd.Parameters.AddWithValue("@ADDRESS", textBoxAddress.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SendToTransactionLog("Update", currentUserID.ToString());
                }
            }

            SetUpGrid();
            ClearTextBoxes();
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
        private void buttonInvestorn_Click(object sender, EventArgs e)
        {
            currentType = "I";
            ClearTextBoxes();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            currentType = "E";
            ClearTextBoxes();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            currentType = "C";
            ClearTextBoxes();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentUserID == -1)
            {
                MessageBox.Show("Please select an item to delete!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    SendToTransactionLog("Delete", currentUserID.ToString());
                    string sql = "DELETE FROM Users WHERE UserID = @USERID;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@USERID", currentUserID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            SetUpGrid();
            ClearTextBoxes();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
                string test = dataGridView.CurrentRow.Cells[0].Value.ToString();
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "SELECT * FROM Users where UserID='" + test + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("@Fname", fName);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        currentUserID = int.Parse(rdr[0].ToString());
                        textBoxUsername.Text = rdr[1].ToString();
                        textBoxType.Text = rdr[3].ToString();
                        textBoxName.Text = rdr[4].ToString();
                        textBoxPhone.Text = rdr[5].ToString();
                        textBoxEmail.Text = rdr[6].ToString();
                        textBoxDOB.Text = rdr[7].ToString();
                        textBoxAddress.Text = rdr[8].ToString();
                    }
                    conn.Close();
                }
            //}
            //catch
            //{

            //}
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select userid,name,PhoneNumber,Email from users where Level='" + currentType + "' and Name = '" + textBoxSearch.Text + "'", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView.DataSource = dtbl;

                conn.Close();
            }
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxType.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxDOB.Text = "";
            textBoxAddress.Text = "";
            textBoxSearch.Text = "";
            currentUserID = -1; 
        }

        private void ClearTextBoxes()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxType.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxDOB.Text = "";
            textBoxAddress.Text = "";
            textBoxSearch.Text = "";
            currentUserID = -1;
            SetUpGrid();
        }

        //private bool ValidTextBoxes()
        //{
        //    if (textBoxName.Text.Trim() != "" && textBoxPrice.Text.Trim() != "" && textBoxQuant.Text.Trim() != "")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (textBoxName.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Item Name is required");
        //        }
        //        else if (textBoxPrice.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Price is required");
        //        }
        //        else if (textBoxQuant.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Quantity is required");
        //        }
        //        return false;
        //    }
        //}


        private void SendToTransactionLog(string action, string data)
        {
            string item = "";
            if (currentUserID != -1)
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "SELECT * FROM Users where UserID=" + currentUserID + "";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        item = string.Format("{0},{1},{2},{3},{4},{5},{6}", int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[3].ToString());
                    }
                    conn.Close();
                }
            }
            else
            {
                item = data;
            }
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                string sql = "insert into TransactionLog values (@DATE,@ACTION,@TYPE,@DATA);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@ACTION", action);
                cmd.Parameters.AddWithValue("@TYPE", "User");
                cmd.Parameters.AddWithValue("@DATA", item);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}
