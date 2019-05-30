using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;


using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Font = System.Drawing.Font;

using iTextSharp.text.pdf.fonts;


namespace Assignment3UI
{
    public partial class Report : Form
    {
        public Report(string pLevel)
        {
            InitializeComponent();
            level = pLevel;
            SetPremissions();
        }
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string level;

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

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            //MainForm objFormMain = new MainForm();
            //this.Hide();
            //objFormMain.Closed += (s, args) => this.Close();
            //objFormMain.Show();
        }

        private void buttonInvestor_Click(object sender, EventArgs e)
        {
            Investor objFormMain = new Investor(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            GlobalData db = new GlobalData();
            //dataGridView.DataSource = db.GetData("select * from Items");
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            String message = Environment.UserName;
            Font messageFont = new Font("Arial",
                24, GraphicsUnit.Point);

            using (SqlConnection conn = new SqlConnection(CSTRING))
            {
                string sql = "SELECT * FROM Items";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@Fname", fName);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    message = rdr[0].ToString();
                    g.DrawString(message, messageFont, Brushes.Black, 100, 100);

                }

                conn.Close();
            }


        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Document doc = new Document(PageSize.A4);


            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf", FileMode.Create));
                //doc.AddHeader(Header,"Purchased Report");
                doc.Open();
                //for (int i = 0; i < 10; i++)
                //{
                //    Paragraph para = new Paragraph( new Font(Font.FontFamily.HELVETICA, 22));
                //    para.Alignment = Element.ALIGN_CENTER;
                //    doc.Add(para);
                //    doc.NewPage();
                //}

                //Report Header
                //BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Font fntHead = new Font(bfntHead, 16, 1, Color.Gray);
                iTextSharp.text.Font fntHead = iTextSharp.text.FontFactory.GetFont("Time New Roman", 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                //Font font = FontFactory.GetFont("Time new Roman", 18.0f, BaseColor.GRAY);
                Paragraph prgHeading = new Paragraph();
                prgHeading.Alignment = Element.ALIGN_CENTER;
               // prgHeading.Add(new Chunk(ToUpper(), fntHead));
                doc.Add(prgHeading);
                // doc.AddAuthor("Rose/Kyla/Pam");
                //Author
                Paragraph prgAuthor = new Paragraph();
                //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Font fntAuthor = new Font(btnAuthor, 8, 2, Color.Gray);
                iTextSharp.text.Font fntAuthor = iTextSharp.text.FontFactory.GetFont("Time New Roman", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                prgAuthor.Alignment = Element.ALIGN_RIGHT;
                prgAuthor.Add(new Chunk("Author : Kyla,Rose,Pam", fntAuthor));
                prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString() + "\n\n", fntAuthor));

                doc.Add(prgAuthor);

                PdfPTable tbl = new PdfPTable(5);
                DataTable dt = new GlobalData().GetData("select p.PurchaseID, c.Name, i.ItemName, p.PurchaseDate, p.Quantity from Purchase p , Users c, Items i where p.UserID = c.UserID AND p.ItemID = i.ItemID");
                foreach (DataColumn c in dt.Columns)
                {
                    tbl.AddCell(new Phrase(c.Caption));
                }
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                var fnt = new iTextSharp.text.Font(bf, 13.0f, 1, BaseColor.BLUE);
                foreach (DataRow row in dt.Rows)
                {

                    tbl.AddCell(new Phrase(row[0].ToString()));
                    tbl.AddCell(new Phrase(row[1].ToString()));
                    tbl.AddCell(new Phrase(row[2].ToString()));
                    tbl.AddCell(new Phrase(row[3].ToString()));
                    tbl.AddCell(new Phrase(row[4].ToString(), fnt));
                }
                doc.Add(tbl);
                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf");
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private void buttonTrackItems_Click(object sender, EventArgs e)
        {
            MainForm objFormMain = new MainForm(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        private void buttonInvestor_Click_1(object sender, EventArgs e)
        {
            Investor objFormMain = new Investor(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

       
        //#region Events
        //void ExportDataTableToPdf(DataTable dtbleTable, String strPdfPath, string strHeader)
        //{
        //    System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
        //    Document document = new Document();
        //    document.SetPageSize(iTextSharp.text.PageSize.A4);
        //    PdfWriter writer = PdfWriter.GetInstance(document, fs);
        //    document.Open();

        //    //Report Header
        //     //BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    //Font fntHead = new Font(bfntHead, 16, 1, Color.Gray);
        //    iTextSharp.text.Font fntHead = iTextSharp.text.FontFactory.GetFont("Time New Roman",16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
        //    //Font font = FontFactory.GetFont("Time new Roman", 18.0f, BaseColor.GRAY);
        //    Paragraph prgHeading = new Paragraph();
        //    prgHeading.Alignment = Element.ALIGN_CENTER;
        //    prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
        //    document.Add(prgHeading);

        //    //Author
        //    Paragraph prgAuthor = new Paragraph();
        //    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    //Font fntAuthor = new Font(btnAuthor, 8, 2, Color.Gray);
        //    iTextSharp.text.Font fntAuthor = iTextSharp.text.FontFactory.GetFont("Time New Roman", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
        //    prgAuthor.Alignment = Element.ALIGN_RIGHT;
        //    prgAuthor.Add(new Chunk("Author : Kyla,Rose,Pam", fntAuthor));
        //    prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
        //    document.Add(prgAuthor);

        //    //Add a line seperate
        //    Paragraph p = new Paragraph(new Chunk(iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.Black, Element.ALIGN_LEFT)));
        //    document.Add(p);

        //    //Write the table
        //    PdfPTable table = new PdfPTable(dtbleTable.Columns.Count);
        //    //table header
        //    //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    // Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.White);
        //    iTextSharp.text.Font fntColumnHeader = iTextSharp.text.FontFactory.GetFont("Time New Roman", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
        //    for (int i = 0; i < dtbleTable.Columns.Count; i++)
        //    {
        //        PdfPCell cell = new PdfPCell();
        //        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#C2D69B");
        //        cell.AddElement(new Chunk(dtbleTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
        //        table.AddCell(cell);

        //    }
        //    // TABLE DATA
        //    for (int i = 0; i < dtbleTable.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dtbleTable.Columns.Count; j++)
        //        {
        //            table.AddCell(dtbleTable.Rows[i][j].ToString());

        //        }
        //        document.Add(table);
        //        document.Close();
        //        fs.Close();
        //    }

        //}
        private void btntry_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        DataTable dtbl = MakeDataTable();
        //        ExportDataTableToPdf(dtbl, @"C:\test.pdf");
        //        if (cbxOpen.Checked)
        //        {
        //            System.Diagnostics.Process.Start(@"C:\test.pdf");
        //            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        //    }
                
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error Message");
        //    }

        //}
        //#endregion
        //#region Functions
        //DataTable MakeDataTable()
        //{
        //    DataTable friend = new DataTable();
        //    friend.Columns.Add("No");
        //    friend.Columns.Add("Name");
        //    friend.Columns.Add("Country");
        //    friend.Columns.Add("Region");
        //    friend.Rows.Add("1", "Kyla", "United State", "California");
        //    friend.Rows.Add("2", "Rose", "New Zealand", "Southland");
        //    friend.Rows.Add("3", "Pam", "Australia", "Adelaide");


        //    return friend;
        }

        private void btnInvestor_Click(object sender, EventArgs e)
        {

            Document doc = new Document(PageSize.A4);

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf", FileMode.Create));
                doc.Open();

                //Report Header
                //BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Font fntHead = new Font(bfntHead, 16, 1, Color.Gray);
                iTextSharp.text.Font fntHead = iTextSharp.text.FontFactory.GetFont("Time New Roman", 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                //Font font = FontFactory.GetFont("Time new Roman", 18.0f, BaseColor.GRAY);
                Paragraph prgHeading = new Paragraph();
                prgHeading.Alignment = Element.ALIGN_CENTER;
                // prgHeading.Add(new Chunk(ToUpper(), fntHead));
                doc.Add(prgHeading);
                // doc.AddAuthor("Rose/Kyla/Pam");
                //Author
                Paragraph prgAuthor = new Paragraph();
                //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Font fntAuthor = new Font(btnAuthor, 8, 2, Color.Gray);
                iTextSharp.text.Font fntAuthor = iTextSharp.text.FontFactory.GetFont("Time New Roman", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
                prgAuthor.Alignment = Element.ALIGN_RIGHT;
                prgAuthor.Add(new Chunk("Author : Kyla,Rose,Pam", fntAuthor));
                prgAuthor.Add(new Chunk("\n Date : " + DateTime.Now.ToShortDateString() + "\n\n", fntAuthor));
                doc.Add(prgAuthor);

                PdfPTable tbl = new PdfPTable(6);
                DataTable dt = new GlobalData().GetData("select * from Users where Type='Investor'");
                foreach (DataColumn c in dt.Columns)
                {
                    tbl.AddCell(new Phrase(c.Caption));
                }
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                var fnt = new iTextSharp.text.Font(bf, 13.0f, 1, BaseColor.BLUE);
                foreach (DataRow row in dt.Rows)
                {

                    tbl.AddCell(new Phrase(row[0].ToString()));
                    tbl.AddCell(new Phrase(row[1].ToString()));
                    tbl.AddCell(new Phrase(row[2].ToString()));
                    tbl.AddCell(new Phrase(row[3].ToString()));
                    tbl.AddCell(new Phrase(row[4].ToString()));
                    tbl.AddCell(new Phrase(row[5].ToString()));
                    //tbl.AddCell(new Phrase(row[6].ToString(), fnt));
                }
                doc.Add(tbl);
                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf");
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message);
            }

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUser objFormMain = new AddUser(level);
            this.Hide();
            objFormMain.Closed += (s, args) => this.Close();
            objFormMain.Show();
        }

        //#endregion

    }
}

