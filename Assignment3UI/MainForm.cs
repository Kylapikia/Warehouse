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
    public partial class MainForm : Form
    {
        /*
         There is only a warehouse, supplier, store and renovation
         1 = Supplier (S)
         2 = Warehouse (W)
         3 = Rental Store (R)
         4 = Renovation (H)
        */
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //const string CSTRING = @"Server=inv-vdi-bitsql1;Database=SCM;Trusted_Connection=True;";
        private string currentProperty = null;
        private int currentItemID = -1;
        private int currentItemQuant = -1;
        private string level;

        public MainForm(string pLevel)
        {
            InitializeComponent();
            level = pLevel;
            currentProperty = "R";
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
                    buttonRenovations.Enabled = false;
                    buttonWarehouse.Enabled = false;
                    buttonSupplier.Enabled = false;
                    break;
                case "I":
                    buttonAddUser.Enabled = false;
                    buttonInvestor.Enabled = true;
                    buttonReport.Enabled = true;
                    buttonTrackItems.Enabled = false;
                    break;
            }
        }

        // populates table with Item data based on 'currentProperty'
        private void SetUpGrid()
        {
            buttonSend.Enabled = true;
            buttonSend.Show();// = true;
            comboCustomer.Hide();
            labelCustomer.Hide();
            if (currentProperty == "S")
            {
                labelTitle.Text = "Supplier";
                buttonSend.Text = "Send to Warehouse";
            }
            else if (currentProperty == "W")
            {
                labelTitle.Text = "Warehouse";
                buttonSend.Text = "Take Items";
            }
            else if (currentProperty == "R")
            {
                comboCustomer.Show();
                labelCustomer.Show();
                labelTitle.Text = "Retail Shop";
                buttonSend.Text = "Buy from Retail Store";
            }
            else if (currentProperty == "H")
            {
                labelTitle.Text = "Renovations";
                buttonSend.Text = "Use Item";
                buttonSend.Hide();
            }
            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT ItemID,ItemName,Price,Quantity FROM Items where Location='" + currentProperty + "'", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridViewWarehouse.DataSource = dtbl;

                conn.Close();
            }

        }
        // add all investors to combobox
        private void SetUpCustomerBox()
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
                    comboCustomer.Items.Add(string.Format("{0}:{1}", rdr[0].ToString(), rdr[1].ToString()));
                }
                conn.Close();
            }
            comboCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCustomer.SelectedIndex = 0;
        }
        // selecting clicked Item
        private void dataGridViewWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string test = dataGridViewWarehouse.CurrentRow.Cells[0].Value.ToString();
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "SELECT * FROM Items where ItemID='" + test + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("@Fname", fName);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        currentItemID = int.Parse(rdr["ItemID"].ToString());
                        currentItemQuant = int.Parse(rdr["Quantity"].ToString());
                        textBoxName.Text = rdr["ItemName"].ToString();
                        textBoxPrice.Text = rdr["Price"].ToString();
                        textBoxQuant.Text = rdr["Quantity"].ToString();
                        comboCustomer.Text = string.Format("{0}:{1}", rdr[3].ToString(), rdr[4].ToString());
                    }
                    conn.Close();
                }
            }
            catch
            {

            }
        }

        // Selected Item general functions
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int propID = GetPropID();
            // new Item
            if (ValidTextBoxes())
            {
                if (currentItemID == -1)
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        string sql = "insert into Items values (@PROPID,@ITEMNAME,@PRICE,@LOCATION,@QUANT)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@PROPID", propID);
                        cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        cmd.Parameters.AddWithValue("@LOCATION", currentProperty);
                        cmd.Parameters.AddWithValue("@QUANT", int.Parse(textBoxQuant.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        SendToTransactionLog("Insert", string.Format("{0},{1},{2},{3},{4}", propID, textBoxName.Text.ToString().Trim(), decimal.Parse(textBoxPrice.Text.ToString().Trim()), currentProperty, int.Parse(textBoxQuant.Text.ToString().Trim())));
                    }
                }
                // update Item
                else
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        string sql = "UPDATE Items SET ItemName = @ITEMNAME, Price = @PRICE, Quantity = @QUANT WHERE ItemID = @ITEMID; ";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
                        cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        cmd.Parameters.AddWithValue("@QUANT", int.Parse(textBoxQuant.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        SendToTransactionLog("Update", currentItemID.ToString());
                    }
                }
            }
            SetUpGrid();
            ClearTextBoxes();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentItemID == -1)
            {
                MessageBox.Show("Please select an item to delete!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    SendToTransactionLog("Delete", currentItemID.ToString());
                    string sql = "DELETE FROM Items WHERE ItemID = @ITEMID;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
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
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT ItemID,ItemName,Price,Quantity FROM Items where Location='" + currentProperty + "' and ItemName = '" + textBoxSearch.Text + "'", conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridViewWarehouse.DataSource = dtbl;

                conn.Close();
            }
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            textBoxQuant.Text = "";
            textBoxSearch.Text = "";
            currentItemID = -1;
            comboCustomer.Items.Clear();
            SetUpCustomerBox();
        }
        // Send selected item to another building
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (ValidTextBoxes())
            {
                int propID = GetPropID();
                if (currentItemID == -1)
                {
                    MessageBox.Show("Please select an item!");
                }
                else
                {
                    string sendTo = null;

                    if (currentProperty == "S")
                    {
                        sendTo = "W";
                    }
                    else if (currentProperty == "W")
                    {
                        DialogResult dr = MessageBox.Show("Yes = Shop, No = Property", "Shop or Property", MessageBoxButtons.YesNoCancel);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                sendTo = "R";
                                break;
                            case DialogResult.No:
                                sendTo = "H";
                                break;
                        }
                    }
                    else if (currentProperty == "R")
                    {
                        PurchaseItem(true);
                    }
                    else if (currentProperty == "H")
                    {
                        PurchaseItem(false);

                    }
                    if (sendTo != null)
                    {
                        using (SqlConnection conn = new SqlConnection(CSTRING))
                        {
                            string sql = "UPDATE Items SET ItemName = @ITEMNAME, Price = @PRICE, Quantity = @QUANT, Location = @LOCATION WHERE ItemID = @ITEMID; ";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
                            cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@LOCATION", sendTo);
                            cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                            cmd.Parameters.AddWithValue("@QUANT", int.Parse(textBoxQuant.Text.ToString().Trim()));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            SendToTransactionLog("Sending", string.Format("{0}: {1} to {2}", textBoxName.Text.ToString().Trim(), currentProperty, sendTo));
                        }
                    }
                }
                SetUpGrid();
                ClearTextBoxes();
            }
        }
        private void PurchaseItem(bool purchase)
        {
            if (purchase && ValidTextBoxes())
            {
                if (int.Parse(textBoxQuant.Text.ToString().Trim()) <= 0)
                {
                    MessageBox.Show("Don't insert negitive numbers please.....................");
                }
                else if (currentItemQuant >= int.Parse(textBoxQuant.Text.ToString().Trim()))
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        string sql = "insert into Purchase values(@CUSTID,@ITEMID,@DATE,@QUANT);";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@CUSTID", GetCustomerID());
                        cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
                        cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                        cmd.Parameters.AddWithValue("@QUANT", int.Parse(textBoxQuant.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        sql = "UPDATE Items SET ItemName = @ITEMNAME, Price = @PRICE, Quantity = @QUANT WHERE ItemID = @ITEMID; ";
                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
                        cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        cmd.Parameters.AddWithValue("@QUANT", currentItemQuant - int.Parse(textBoxQuant.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        SendToTransactionLog("Update", currentItemID.ToString());
                        SendToTransactionLog("Buy", string.Format("{0},{1},{2},{3}", currentItemID, textBoxName.Text.ToString().Trim(), decimal.Parse(textBoxPrice.Text.ToString().Trim()), currentItemQuant - int.Parse(textBoxQuant.Text.ToString().Trim())));
                    }
                }
                else
                {
                    MessageBox.Show("There aren't enough of that item in stock");
                }
            }
            else
            {
                if (int.Parse(textBoxQuant.Text.ToString().Trim()) <= 0)
                {
                    MessageBox.Show("Don't insert negitive numbers please.....................");
                }
                else if (currentItemQuant >= int.Parse(textBoxQuant.Text.ToString().Trim()))
                {
                    using (SqlConnection conn = new SqlConnection(CSTRING))
                    {
                        string sql = "UPDATE Items SET ItemName = @ITEMNAME, Price = @PRICE, Quantity = @QUANT WHERE ItemID = @ITEMID; ";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ITEMID", currentItemID);
                        cmd.Parameters.AddWithValue("@ITEMNAME", textBoxName.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBoxPrice.Text.ToString().Trim()));
                        cmd.Parameters.AddWithValue("@QUANT", currentItemQuant - int.Parse(textBoxQuant.Text.ToString().Trim()));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        SendToTransactionLog("Renovate", string.Format("{0},{1},{2},{3}", currentItemID, textBoxName.Text.ToString().Trim(), decimal.Parse(textBoxPrice.Text.ToString().Trim()), int.Parse(textBoxQuant.Text.ToString().Trim())));
                        SendToTransactionLog("Update", currentItemID.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There aren't enough of that item in stock");
                }
            }
        }


        // Tools
        private void ClearTextBoxes()
        {
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            textBoxQuant.Text = "";
            textBoxSearch.Text = "";
            currentItemID = -1;
            SetUpGrid();
            comboCustomer.Items.Clear();
            SetUpCustomerBox();
        }
        private int GetPropID()
        {
            int propID;
            if (currentProperty == "S")
            {
                propID = 1;
            }
            else if (currentProperty == "W")
            {
                propID = 2;
            }
            else if (currentProperty == "R")
            {
                propID = 3;
            }
            else
            {
                propID = 4;
            }
            return propID;
        }
        private bool ValidTextBoxes()
        {
            if (textBoxName.Text.Trim() != "" && textBoxPrice.Text.Trim() != "" && textBoxQuant.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                if (textBoxName.Text.Trim() == "")
                {
                    MessageBox.Show("Item Name is required");
                }
                else if (textBoxPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Price is required");
                }
                else if (textBoxQuant.Text.Trim() == "")
                {
                    MessageBox.Show("Quantity is required");
                }
                return false;
            }
        }
        private void SendToTransactionLog(string action, string data)
        {
            string item = "";
            if(currentItemID != -1)
            {
                using (SqlConnection conn = new SqlConnection(CSTRING))
                {
                    string sql = "SELECT * FROM Items where ItemID=" + currentItemID + "";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        item = string.Format("{0},{1},{2},{3}", int.Parse(rdr["ItemID"].ToString()), rdr["ItemName"].ToString(), rdr["Price"].ToString(), rdr["Quantity"].ToString());
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
                cmd.Parameters.AddWithValue("@TYPE", "Item");
                cmd.Parameters.AddWithValue("@DATA", item);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private int GetCustomerID()
        {
            string[] parts = comboCustomer.Text.Split(':');
            return int.Parse(parts[0]);
        }

        // Toogle between different buildings
        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            currentProperty = "S";
            ClearTextBoxes();
        }
        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            currentProperty = "W";
            ClearTextBoxes();
        }
        private void buttonRetailShop_Click(object sender, EventArgs e)
        {
            currentProperty = "R";
            ClearTextBoxes();
        }
        private void buttonRenovations_Click(object sender, EventArgs e)
        {
            currentProperty = "H";
            ClearTextBoxes();
        }

        // Other tabs
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

        private void buttonTrackItems_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUser objFormMain = new AddUser(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }
    }
}
