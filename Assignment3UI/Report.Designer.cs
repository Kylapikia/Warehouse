namespace Assignment3UI
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.buttonTrackItems = new System.Windows.Forms.Button();
            this.labelScm = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonInvestor = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.btnInvestor = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTrackItems
            // 
            this.buttonTrackItems.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonTrackItems.Location = new System.Drawing.Point(39, 115);
            this.buttonTrackItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTrackItems.Name = "buttonTrackItems";
            this.buttonTrackItems.Size = new System.Drawing.Size(108, 58);
            this.buttonTrackItems.TabIndex = 103;
            this.buttonTrackItems.Text = "TRACK ITEMS";
            this.buttonTrackItems.UseVisualStyleBackColor = false;
            this.buttonTrackItems.Click += new System.EventHandler(this.buttonTrackItems_Click);
            // 
            // labelScm
            // 
            this.labelScm.AutoSize = true;
            this.labelScm.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScm.Location = new System.Drawing.Point(48, 38);
            this.labelScm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScm.Name = "labelScm";
            this.labelScm.Size = new System.Drawing.Size(84, 36);
            this.labelScm.TabIndex = 90;
            this.labelScm.Text = "SCM";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.DarkKhaki;
            this.richTextBox2.Location = new System.Drawing.Point(186, 1);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(578, 67);
            this.richTextBox2.TabIndex = 89;
            this.richTextBox2.Text = "";
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonReport.Location = new System.Drawing.Point(39, 315);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(108, 58);
            this.buttonReport.TabIndex = 88;
            this.buttonReport.Text = "REPORT";
            this.buttonReport.UseVisualStyleBackColor = false;
            // 
            // buttonInvestor
            // 
            this.buttonInvestor.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonInvestor.Location = new System.Drawing.Point(39, 215);
            this.buttonInvestor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInvestor.Name = "buttonInvestor";
            this.buttonInvestor.Size = new System.Drawing.Size(108, 58);
            this.buttonInvestor.TabIndex = 87;
            this.buttonInvestor.Text = "INVESTOR";
            this.buttonInvestor.UseVisualStyleBackColor = false;
            this.buttonInvestor.Click += new System.EventHandler(this.buttonInvestor_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.richTextBox1.Location = new System.Drawing.Point(-12, 1);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(202, 512);
            this.richTextBox1.TabIndex = 85;
            this.richTextBox1.Text = "";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(486, 101);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 56);
            this.btnPrint.TabIndex = 107;
            this.btnPrint.Text = "Purchased Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonAddUser.Location = new System.Drawing.Point(39, 402);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(108, 58);
            this.buttonAddUser.TabIndex = 108;
            this.buttonAddUser.Text = "ADD USER";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // btnInvestor
            // 
            this.btnInvestor.Location = new System.Drawing.Point(312, 101);
            this.btnInvestor.Name = "btnInvestor";
            this.btnInvestor.Size = new System.Drawing.Size(150, 56);
            this.btnInvestor.TabIndex = 111;
            this.btnInvestor.Text = "Investor List ";
            this.btnInvestor.UseVisualStyleBackColor = true;
            this.btnInvestor.Click += new System.EventHandler(this.btnInvestor_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(211, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(58, 25);
            this.labelTitle.TabIndex = 94;
            this.labelTitle.Text = "Title";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(764, 512);
            this.Controls.Add(this.btnInvestor);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.buttonTrackItems);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelScm);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonInvestor);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonTrackItems;
        private System.Windows.Forms.Label labelScm;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonInvestor;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button btnInvestor;
        private System.Windows.Forms.Label labelTitle;
    }
}