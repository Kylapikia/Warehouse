namespace Assignment3UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWarehouse = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonRetailShop = new System.Windows.Forms.Button();
            this.buttonInvestor = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelScm = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labQuant = new System.Windows.Forms.Label();
            this.textBoxQuant = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRenovations = new System.Windows.Forms.Button();
            this.buttonTrackItems = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWarehouse
            // 
            this.buttonWarehouse.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonWarehouse.Location = new System.Drawing.Point(350, 10);
            this.buttonWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWarehouse.Name = "buttonWarehouse";
            this.buttonWarehouse.Size = new System.Drawing.Size(108, 44);
            this.buttonWarehouse.TabIndex = 2;
            this.buttonWarehouse.Text = "WAREHOUSE";
            this.buttonWarehouse.UseVisualStyleBackColor = false;
            this.buttonWarehouse.Click += new System.EventHandler(this.buttonWarehouse_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.richTextBox1.Location = new System.Drawing.Point(-12, 1);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(202, 512);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // buttonRetailShop
            // 
            this.buttonRetailShop.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonRetailShop.Location = new System.Drawing.Point(484, 10);
            this.buttonRetailShop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRetailShop.Name = "buttonRetailShop";
            this.buttonRetailShop.Size = new System.Drawing.Size(108, 44);
            this.buttonRetailShop.TabIndex = 4;
            this.buttonRetailShop.Text = "RETAIL SHOP";
            this.buttonRetailShop.UseVisualStyleBackColor = false;
            this.buttonRetailShop.Click += new System.EventHandler(this.buttonRetailShop_Click);
            // 
            // buttonInvestor
            // 
            this.buttonInvestor.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonInvestor.Location = new System.Drawing.Point(39, 209);
            this.buttonInvestor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInvestor.Name = "buttonInvestor";
            this.buttonInvestor.Size = new System.Drawing.Size(108, 58);
            this.buttonInvestor.TabIndex = 5;
            this.buttonInvestor.Text = "INVESTOR";
            this.buttonInvestor.UseVisualStyleBackColor = false;
            this.buttonInvestor.Click += new System.EventHandler(this.buttonInvestor_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonReport.Location = new System.Drawing.Point(39, 305);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(108, 58);
            this.buttonReport.TabIndex = 6;
            this.buttonReport.Text = "REPORT";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.DarkKhaki;
            this.richTextBox2.Location = new System.Drawing.Point(186, 1);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(578, 67);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSend.Location = new System.Drawing.Point(793, 375);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(126, 43);
            this.buttonSend.TabIndex = 13;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelScm
            // 
            this.labelScm.AutoSize = true;
            this.labelScm.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScm.Location = new System.Drawing.Point(48, 38);
            this.labelScm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScm.Name = "labelScm";
            this.labelScm.Size = new System.Drawing.Size(84, 36);
            this.labelScm.TabIndex = 22;
            this.labelScm.Text = "SCM";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSearch.Location = new System.Drawing.Point(637, 78);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(126, 28);
            this.buttonSearch.TabIndex = 35;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.AllowUserToAddRows = false;
            this.dataGridViewWarehouse.AllowUserToDeleteRows = false;
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.Price,
            this.Quantity});
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(222, 115);
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.ReadOnly = true;
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(540, 378);
            this.dataGridViewWarehouse.TabIndex = 38;
            this.dataGridViewWarehouse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWarehouse_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ItemId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // buttonSupplier
            // 
            this.buttonSupplier.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonSupplier.Location = new System.Drawing.Point(222, 10);
            this.buttonSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSupplier.Name = "buttonSupplier";
            this.buttonSupplier.Size = new System.Drawing.Size(108, 44);
            this.buttonSupplier.TabIndex = 39;
            this.buttonSupplier.Text = "SUPPLIER";
            this.buttonSupplier.UseVisualStyleBackColor = false;
            this.buttonSupplier.Click += new System.EventHandler(this.buttonSupplier_Click);
            // 
            // listViewItems
            // 
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.Location = new System.Drawing.Point(223, 538);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(540, 370);
            this.listViewItems.TabIndex = 37;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(779, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(58, 25);
            this.labelTitle.TabIndex = 44;
            this.labelTitle.Text = "Title";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(805, 117);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(58, 13);
            this.labelName.TabIndex = 46;
            this.labelName.Text = "Item Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(805, 140);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 45;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(805, 184);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 48;
            this.labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(805, 207);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 47;
            // 
            // labQuant
            // 
            this.labQuant.AutoSize = true;
            this.labQuant.Location = new System.Drawing.Point(805, 248);
            this.labQuant.Name = "labQuant";
            this.labQuant.Size = new System.Drawing.Size(40, 13);
            this.labQuant.TabIndex = 50;
            this.labQuant.Text = "Qantity";
            // 
            // textBoxQuant
            // 
            this.textBoxQuant.Location = new System.Drawing.Point(805, 271);
            this.textBoxQuant.Name = "textBoxQuant";
            this.textBoxQuant.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuant.TabIndex = 49;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSave.Location = new System.Drawing.Point(779, 63);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(78, 43);
            this.buttonSave.TabIndex = 53;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonDelete.Location = new System.Drawing.Point(861, 63);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(78, 43);
            this.buttonDelete.TabIndex = 52;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonClear.Location = new System.Drawing.Point(793, 435);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(126, 43);
            this.buttonClear.TabIndex = 51;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRenovations
            // 
            this.buttonRenovations.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonRenovations.Location = new System.Drawing.Point(622, 10);
            this.buttonRenovations.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRenovations.Name = "buttonRenovations";
            this.buttonRenovations.Size = new System.Drawing.Size(108, 44);
            this.buttonRenovations.TabIndex = 55;
            this.buttonRenovations.Text = "RENOVATIONS";
            this.buttonRenovations.UseVisualStyleBackColor = false;
            this.buttonRenovations.Click += new System.EventHandler(this.buttonRenovations_Click);
            // 
            // buttonTrackItems
            // 
            this.buttonTrackItems.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonTrackItems.Location = new System.Drawing.Point(39, 115);
            this.buttonTrackItems.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrackItems.Name = "buttonTrackItems";
            this.buttonTrackItems.Size = new System.Drawing.Size(108, 58);
            this.buttonTrackItems.TabIndex = 56;
            this.buttonTrackItems.Text = "TRACK ITEMS";
            this.buttonTrackItems.UseVisualStyleBackColor = false;
            this.buttonTrackItems.Click += new System.EventHandler(this.buttonTrackItems_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(222, 83);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(392, 20);
            this.textBoxSearch.TabIndex = 83;
            // 
            // comboCustomer
            // 
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.Location = new System.Drawing.Point(805, 330);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(100, 21);
            this.comboCustomer.TabIndex = 84;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(805, 305);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(51, 13);
            this.labelCustomer.TabIndex = 85;
            this.labelCustomer.Text = "Customer";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonAddUser.Location = new System.Drawing.Point(39, 404);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(108, 58);
            this.buttonAddUser.TabIndex = 86;
            this.buttonAddUser.Text = "ADD USER";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(967, 514);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.comboCustomer);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonTrackItems);
            this.Controls.Add(this.buttonRenovations);
            this.Controls.Add(this.buttonRetailShop);
            this.Controls.Add(this.buttonWarehouse);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labQuant);
            this.Controls.Add(this.textBoxQuant);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonSupplier);
            this.Controls.Add(this.dataGridViewWarehouse);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelScm);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonInvestor);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Track Items";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonWarehouse;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonRetailShop;
        private System.Windows.Forms.Button buttonInvestor;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelScm;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
        private System.Windows.Forms.Button buttonSupplier;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labQuant;
        private System.Windows.Forms.TextBox textBoxQuant;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button buttonRenovations;
        private System.Windows.Forms.Button buttonTrackItems;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Button buttonAddUser;
    }
}

