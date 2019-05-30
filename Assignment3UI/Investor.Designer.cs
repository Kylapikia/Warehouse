namespace Assignment3UI
{
    partial class Investor
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
            this.buttonTrackItems = new System.Windows.Forms.Button();
            this.buttonListProp = new System.Windows.Forms.Button();
            this.buttonRenovation = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labInvestorName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonBrought = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelScm = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonInvestor = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboInvestor = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvestorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTrackItems
            // 
            this.buttonTrackItems.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonTrackItems.Location = new System.Drawing.Point(39, 115);
            this.buttonTrackItems.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrackItems.Name = "buttonTrackItems";
            this.buttonTrackItems.Size = new System.Drawing.Size(108, 58);
            this.buttonTrackItems.TabIndex = 80;
            this.buttonTrackItems.Text = "TRACK ITEMS";
            this.buttonTrackItems.UseVisualStyleBackColor = false;
            this.buttonTrackItems.Click += new System.EventHandler(this.buttonTrackItems_Click);
            // 
            // buttonListProp
            // 
            this.buttonListProp.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonListProp.Location = new System.Drawing.Point(581, 10);
            this.buttonListProp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonListProp.Name = "buttonListProp";
            this.buttonListProp.Size = new System.Drawing.Size(108, 44);
            this.buttonListProp.TabIndex = 59;
            this.buttonListProp.Text = "LISTED";
            this.buttonListProp.UseVisualStyleBackColor = false;
            this.buttonListProp.Click += new System.EventHandler(this.buttonListProp_Click);
            // 
            // buttonRenovation
            // 
            this.buttonRenovation.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonRenovation.Location = new System.Drawing.Point(420, 10);
            this.buttonRenovation.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRenovation.Name = "buttonRenovation";
            this.buttonRenovation.Size = new System.Drawing.Size(108, 44);
            this.buttonRenovation.TabIndex = 57;
            this.buttonRenovation.Text = "RENOVATION";
            this.buttonRenovation.UseVisualStyleBackColor = false;
            this.buttonRenovation.Click += new System.EventHandler(this.buttonRenovation_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSave.Location = new System.Drawing.Point(779, 63);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(78, 43);
            this.buttonSave.TabIndex = 77;
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
            this.buttonDelete.TabIndex = 76;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonClear.Location = new System.Drawing.Point(793, 404);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(126, 43);
            this.buttonClear.TabIndex = 75;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labInvestorName
            // 
            this.labInvestorName.AutoSize = true;
            this.labInvestorName.Location = new System.Drawing.Point(805, 248);
            this.labInvestorName.Name = "labInvestorName";
            this.labInvestorName.Size = new System.Drawing.Size(76, 13);
            this.labInvestorName.TabIndex = 74;
            this.labInvestorName.Text = "Investor Name";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(805, 184);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 72;
            this.labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(805, 207);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 71;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(805, 117);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(45, 13);
            this.labelAddress.TabIndex = 70;
            this.labelAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(805, 140);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddress.TabIndex = 69;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(779, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(58, 25);
            this.labelTitle.TabIndex = 68;
            this.labelTitle.Text = "Title";
            // 
            // buttonBrought
            // 
            this.buttonBrought.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonBrought.Location = new System.Drawing.Point(257, 10);
            this.buttonBrought.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrought.Name = "buttonBrought";
            this.buttonBrought.Size = new System.Drawing.Size(108, 44);
            this.buttonBrought.TabIndex = 67;
            this.buttonBrought.Text = "BROUGHT";
            this.buttonBrought.UseVisualStyleBackColor = false;
            this.buttonBrought.Click += new System.EventHandler(this.buttonBrought_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Address,
            this.Price,
            this.InvestorName});
            this.dataGridView.Location = new System.Drawing.Point(222, 115);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(540, 378);
            this.dataGridView.TabIndex = 66;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSearch.Location = new System.Drawing.Point(637, 78);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(126, 28);
            this.buttonSearch.TabIndex = 65;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelScm
            // 
            this.labelScm.AutoSize = true;
            this.labelScm.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScm.Location = new System.Drawing.Point(48, 38);
            this.labelScm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScm.Name = "labelScm";
            this.labelScm.Size = new System.Drawing.Size(84, 36);
            this.labelScm.TabIndex = 64;
            this.labelScm.Text = "SCM";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.DarkKhaki;
            this.richTextBox2.Location = new System.Drawing.Point(186, 1);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(578, 67);
            this.richTextBox2.TabIndex = 62;
            this.richTextBox2.Text = "";
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonReport.Location = new System.Drawing.Point(39, 305);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(108, 58);
            this.buttonReport.TabIndex = 61;
            this.buttonReport.Text = "REPORT";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonInvestor
            // 
            this.buttonInvestor.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonInvestor.Location = new System.Drawing.Point(39, 209);
            this.buttonInvestor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInvestor.Name = "buttonInvestor";
            this.buttonInvestor.Size = new System.Drawing.Size(108, 58);
            this.buttonInvestor.TabIndex = 60;
            this.buttonInvestor.Text = "INVESTOR";
            this.buttonInvestor.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.richTextBox1.Location = new System.Drawing.Point(-12, 1);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(202, 512);
            this.richTextBox1.TabIndex = 58;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // comboInvestor
            // 
            this.comboInvestor.FormattingEnabled = true;
            this.comboInvestor.Location = new System.Drawing.Point(805, 271);
            this.comboInvestor.Name = "comboInvestor";
            this.comboInvestor.Size = new System.Drawing.Size(100, 21);
            this.comboInvestor.TabIndex = 81;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(222, 83);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(392, 20);
            this.textBoxSearch.TabIndex = 82;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonSend.Location = new System.Drawing.Point(793, 347);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(126, 43);
            this.buttonSend.TabIndex = 83;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonAddUser.Location = new System.Drawing.Point(39, 404);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(108, 58);
            this.buttonAddUser.TabIndex = 84;
            this.buttonAddUser.Text = "ADD USER";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "HouseId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.DataPropertyName = "PropertyAddress";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "PropertyPrice";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // InvestorName
            // 
            this.InvestorName.DataPropertyName = "Name";
            this.InvestorName.HeaderText = "Investor Name";
            this.InvestorName.Name = "InvestorName";
            this.InvestorName.ReadOnly = true;
            // 
            // Investor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(954, 514);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboInvestor);
            this.Controls.Add(this.buttonTrackItems);
            this.Controls.Add(this.buttonListProp);
            this.Controls.Add(this.buttonRenovation);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labInvestorName);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonBrought);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelScm);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonInvestor);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Investor";
            this.Text = "Investor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTrackItems;
        private System.Windows.Forms.Button buttonListProp;
        private System.Windows.Forms.Button buttonRenovation;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labInvestorName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonBrought;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelScm;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonInvestor;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboInvestor;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvestorName;
    }
}