using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class frmReportViewer : BaseForm
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }
        public string rptName;
        public DataTable dt;
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            loadreport();
            AuditTrail.Log(Globals.username, nameof(frmReportViewer), "Open", "Report viewer opened for " + rptName);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void loadreport()
        {

            /*MySqlConnection con = new MySqlConnection(Global.con());
            MySqlCommand cmd = con.CreateCommand();
            DataSet dt = new DataSet();

            cmd.CommandText = "SELECT tbl_cashreceipt.*,tbl_cashreceipt.ID as BillNo, 1 as Qty, Rate as Amount,EmailAddress, tbl_testmaster.TestName, tblorg.OrgName, tblorg.OrgAddress, tblorg.OrgPhone, tblorg.OrgMobile1, tblorg.OrgMobile2, Format(BillDate, \"dd - mmm - yy\") AS BillDateOnly FROM(tbl_cashreceipt INNER JOIN tbl_testmaster ON tbl_cashreceipt.TestID = tbl_testmaster.ID) INNER JOIN tblorg ON tbl_cashreceipt.OrgID = tblorg.ID where tbl_cashreceipt.ID = " + BillNo + ";";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            */

            //string reportPath = Path.Combine(exeFolder, @"Reports\SessionReport.rdlc");
            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("ds_Report", dt);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportPath = rptName; //"rptRefAmount.rdlc";
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();

        }
    }
}
