using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3UI
{
    public partial class Investor : Form
    {
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //const string CSTRING = @"Server=inv-vdi-bitsql1;Database=SCM;Trusted_Connection=True;";
        private string currentStatus = null;
        private int houseID = -1;
        private string level;
        /*
         3 Statuses
         1 = Brought (B)
         2 = Renovating (R)
         3 = Listed (L)
         */
        // Constructor
        public Investor(string pLevel)
        {
            InitializeComponent();
            level = pLevel;
            currentStatus = "B";
            ClearTextBoxes();
            SetPremissions();
            buttonSend.Hide();
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

        // setup
        // add all investors to combobox
        private void SetUpInvestorBox()
        {
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                string sql = "select UserID,Name from Users;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@Fname", fName);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // investorID = int.Parse(rdr[0].ToString());
                    //comboInvestor.. = rdr[0].ToString();
                    comboInvestor.Items.Add(string.Format("{0}:{1}", rdr[0].ToString(), rdr[1].ToString()));
                }
                conn.Close();
            }
            comboInvestor.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboInvestor.SelectedIndex = comboInvestor.Items.Count - 1;
        }
        // populates table with Item data based on 'currentStatus'
        private void SetUpGrid()
        {
            if (currentStatus == "B")
            {
                labelTitle.Text = "Brought";
            }
            else if (currentStatus == "R")
            {
                labelTitle.Text = "Renovation";
            }
            else if (currentStatus == "L")
            {
                labelTitle.Text = "Listed";
            }

            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT h.HouseId,h.PropertyAddress,h.PropertyPrice,u.Name FROM House AS h, Users AS U where H.UserID = U.UserID and h.Status ='" + currentStatus + "';", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView.DataSource = dtbl;

                conn.Close();
            }
        }

        // selecting clicked Item
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string test = dataGridView.CurrentRow.Cells[0].Value.ToString();
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                string sql = "SELECT h.HouseId,h.PropertyAddress,h.PropertyPrice,u.Name,u.userid FROM House AS h, Users AS U where H.UserID = U.UserID and h.HouseId = '" + test + "';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@Fname", fName);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    houseID = int.Parse(rdr[0].ToString());
                    textBoxAddress.Text = rdr[1].ToString();
                    textBoxPrice.Text = rdr[2].ToString();
                    comboInvestor.Text = string.Format("{0}:{1}", rdr[3].ToString(), rdr[4].ToString());
                }
                conn.Close();
            }
        }

        // Selected House general functions
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //int propID = GetPropID();
            int investorID = GetInvestorID();
            // new Item
            if (ValidateTextBoxes())
            {
                if (houseID == -1)
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        //h.HouseId,h.PropertyAddress,h.PropertyPrice,i.InvestorName FROM House AS h, Investor AS i where H.InvestorID = I.InvestorID and h.HouseId = '" + test + "';
                        string sql = "insert into House values (@INVESTORID,@PROPADDRESS,@STATUS,@PROPPRICE)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@INVESTORID", investorID);
                        cmd.Parameters.AddWithValue("@PROPADDRESS", textBoxAddress.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@STATUS", currentStatus);
                        cmd.Parameters.AddWithValue("@PROPPRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        SendToTransactionLog("Insert", string.Format("", investorID, textBoxAddress.Text.ToString().Trim(), currentStatus, decimal.Parse(textBoxPrice.Text.ToString().Trim())));
                    }
                }
                // update Item
                else
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        string sql = "UPDATE House SET UserID = @USERID, PropertyAddress = @PROPADDRESS, Status = @STATUS, PropertyPrice = @PRICE WHERE HouseId = @HOUSEID;; ";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@USERID", investorID);
                        cmd.Parameters.AddWithValue("@HOUSEID", houseID);
                        cmd.Parameters.AddWithValue("@PROPADDRESS", textBoxAddress.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        cmd.Parameters.AddWithValue("@STATUS", currentStatus);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        SendToTransactionLog("Update", houseID.ToString());
                    }
                }
                SetUpGrid();
                ClearTextBoxes();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (houseID == -1)
            {
                MessageBox.Show("Please select an item to delete!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    SendToTransactionLog("Delete", houseID.ToString());
                    string sql = "DELETE FROM House WHERE HouseID = @HOUSEID;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@HOUSEID", houseID);
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
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT h.HouseId,h.PropertyAddress,h.PropertyPrice,i.Name FROM House AS h, Users AS i where H.UserID = I.UserID and h.Status = '" + currentStatus + "' and h.PropertyAddress = '" + textBoxSearch.Text + "';", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView.DataSource = dtbl;

                conn.Close();
            }
            ClearOnlyTextBoxes();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int propID = GetPropID();
                if (houseID == -1)
                {
                    MessageBox.Show("Please select an item!");
                }
                else
                {
                    string sendTo = null;

                    if (currentStatus == "B")
                    {
                        sendTo = "R";
                    }
                    else if (currentStatus == "R")
                    {
                        sendTo = "L";
                    }
                    if (sendTo != null)
                    {
                        int investorID = GetInvestorID();
                        using (SqlConnection conn = new SqlConnection(CSTRING))
                        {
                            string sql = "UPDATE House SET InvestorID = @INVESTORID, PropertyAddress = @PROPADDRESS, Status = @STATUS, PropertyPrice = @PRICE WHERE HouseId = @HOUSEID;; ";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@INVESTORID", investorID);
                            cmd.Parameters.AddWithValue("@HOUSEID", houseID);
                            cmd.Parameters.AddWithValue("@PROPADDRESS", textBoxAddress.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                            cmd.Parameters.AddWithValue("@STATUS", sendTo);
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            conn.Close();
                            SendToTransactionLog("Sending", string.Format("{0}: {1} to {2}", houseID, currentStatus, sendTo));
                        }
                    }
                    /*else if(currentStatus)*/

                    //using (SqlConnection conn = new SqlConnection(CSTRING))
                    //{
                    //    string sql = "SELECT * FROM Items where ItemID='" + test + "'";
                    //    SqlCommand cmd = new SqlCommand(sql, conn);
                    //    conn.Open();
                    //    SqlDataReader rdr = cmd.ExecuteReader();
                    //    while (rdr.Read())
                    //    {
                    //        houseID = int.Parse(rdr["ItemID"].ToString());
                    //        textBoxName.Text = rdr["ItemName"].ToString();
                    //        textBoxPrice.Text = rdr["Price"].ToString();
                    //        textBoxQuant.Text = rdr["Quantity"].ToString();
                    //    }
                    //    conn.Close();
                    //}
                    //using (SqlConnection conn = new SqlConnection(CSTRING))
                    //{
                    //    string sql = "UPDATE Items SET ItemName = @ITEMNAME, Price = @PRICE, Quantity = @QUANT WHERE ItemID = @ITEMID; ";
                    //    SqlCommand cmd = new SqlCommand(sql, conn);
                    //    cmd.Parameters.AddWithValue("@ITEMID", houseID);
                    //    cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                    //    cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                    //    cmd.Parameters.AddWithValue("@QUANT", int.Parse(textBoxQuant.Text.ToString().Trim()));
                    //    conn.Open();
                    //    cmd.ExecuteNonQuery();

                    //    conn.Close();
                    //}
                }
                SetUpGrid();
                ClearTextBoxes();
            }
        }

        // Tools
        private void ClearTextBoxes()
        {
            textBoxAddress.Text = "";
            textBoxPrice.Text = "";
            comboInvestor.Items.Clear();
            textBoxSearch.Text = "";
            houseID = -1;
            SetUpGrid();
            SetUpInvestorBox();
        }
        private void ClearOnlyTextBoxes()
        {
            textBoxAddress.Text = "";
            textBoxPrice.Text = "";
            comboInvestor.Text = "";
            textBoxSearch.Text = "";
            houseID = -1;
        }
        private int GetPropID()
        {
            int propID = -1;
            if (currentStatus == "B")
            {
                propID = 1;
            }
            else if (currentStatus == "R")
            {
                propID = 2;
            }
            else if (currentStatus == "L")
            {
                propID = 3;
            }
            return propID;
        }
        private int GetInvestorID()
        {
            string[] parts = comboInvestor.Text.Split(':');
            return int.Parse(parts[0]);
        }
        private bool ValidateTextBoxes()
        {
            if (textBoxAddress.Text.Trim() != "" && textBoxPrice.Text.Trim() != "" && comboInvestor.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                if (textBoxAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Address is required");
                }
                else if (textBoxPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Price is required");
                }
                else if (comboInvestor.Text.Trim() == "")
                {
                    MessageBox.Show("Investor is required");
                }
                return false;
            }
        }
        private void SendToTransactionLog(string action, string data)
        {
            string house = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "SELECT * FROM House where HouseID=" + houseID + "";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        house = string.Format("{0},{1},{2},{3}", int.Parse(rdr["InvestorID"].ToString()), rdr["PropertyAddress"].ToString(), rdr["Status"].ToString(), rdr["PropertyPrice"].ToString());
                    }
                    conn.Close();
                }
            }
            catch
            {
                house = data;
            }
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                string sql = "insert into TransactionLog values (@DATE,@ACTION,@TYPE,@DATA);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@ACTION", action);
                cmd.Parameters.AddWithValue("@TYPE", "House");
                cmd.Parameters.AddWithValue("@DATA", house);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Toogle between different buildings
        private void buttonBrought_Click(object sender, EventArgs e)
        {
            currentStatus = "B";
            ClearTextBoxes();
        }
        private void buttonRenovation_Click(object sender, EventArgs e)
        {
            currentStatus = "R";
            ClearTextBoxes();
        }
        private void buttonListProp_Click(object sender, EventArgs e)
        {
            currentStatus = "L";
            ClearTextBoxes();
        }

        // Other tabs
        private void buttonTrackItems_Click(object sender, EventArgs e)
        {
            MainForm objFormMain = new MainForm(level);
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
            AddUser objFormMain = new AddUser(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
