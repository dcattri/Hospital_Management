using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    public partial class frmDailyCollection : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        public frmDailyCollection()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getRefAmountSearch();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportViewer rpt = new frmReportViewer();
            rpt.rptName = "rptDailyCollection.rdlc";
            rpt.dt = getReportDT();
            rpt.Show();
        }

        private void frmDailyCollection_Load(object sender, EventArgs e)
        {
            //getRefAmountSearch();
        }
        private void getRefAmountSearch()
        {
            var checkedButton = gbCategory.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            //DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            dt = new DataTable();
            if (checkedButton.Text == "All")
            {
                cmd.CommandText = "SELECT a.ID as BillID,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,a.PatientName, GROUP_CONCAT(b.TestName) as TestName, tbl_doctormaster.DoctorName, a.NetAmount, case when a.RefAmount Is Null then 0 else a.RefAmount end AS RefAmount, a.Age, a.Address, a.Gender,a.UserName,a.isRefPaid,de.Amount AS ExpenseAmount FROM tbl_cashreceipt AS a LEFT JOIN tbl_doctormaster ON a.DoctorID = tbl_doctormaster.ID LEFT JOIN tbl_cashreceipt_details cd ON a.ID = cd.cashreceipt_ID LEFT JOIN tbl_testmaster b ON cd.test_ID = b.ID LEFT JOIN (SELECT tbl_dailyexpense.ExpenseDate AS ExpenseDate,SUM(tbl_dailyexpense.Amount) AS Amount FROM tbl_dailyexpense GROUP BY tbl_dailyexpense.ExpenseDate) de ON CAST(a.BillDate AS DATE) = de.ExpenseDate where CAST(a.BillDate AS DATE) >= @from and CAST(a.BillDate AS DATE) <= @to group by a.ID, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') ,a.PatientName, tbl_doctormaster.DoctorName, a.NetAmount, case when a.RefAmount Is Null then 0 else a.RefAmount end , a.Age, a.Address, a.Gender,a.UserName,a.isRefPaid,de.Amount";
                cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                cmd.CommandText = "SELECT a.ID as BillID,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,a.PatientName, GROUP_CONCAT(b.TestName) as TestName, tbl_doctormaster.DoctorName, a.NetAmount, case when a.RefAmount Is Null then 0 else a.RefAmount end AS RefAmount, a.Age, a.Address, a.Gender,a.UserName,a.isRefPaid,de.Amount AS ExpenseAmount FROM tbl_cashreceipt AS a LEFT JOIN tbl_doctormaster ON a.DoctorID = tbl_doctormaster.ID LEFT JOIN tbl_cashreceipt_details cd ON a.ID = cd.cashreceipt_ID LEFT JOIN tbl_testmaster b ON cd.test_ID = b.ID LEFT JOIN (SELECT tbl_dailyexpense.ExpenseDate AS ExpenseDate,SUM(tbl_dailyexpense.Amount) AS Amount FROM tbl_dailyexpense GROUP BY tbl_dailyexpense.ExpenseDate) de ON CAST(a.BillDate AS DATE) = de.ExpenseDate where CAST(a.BillDate AS DATE) >= @from and CAST(a.BillDate AS DATE) <= @to and b.Category=@cat group by a.ID, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') ,a.PatientName, tbl_doctormaster.DoctorName, a.NetAmount, case when a.RefAmount Is Null then 0 else a.RefAmount end , a.Age, a.Address, a.Gender,a.UserName,a.isRefPaid,de.Amount";
                cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@cat", checkedButton.Text);
            }
            cmd.Connection = con;
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgRefAmount.ReadOnly = true;
            dgRefAmount.DataSource = dt;

            //foreach (DataGridViewColumn dc in dgRefAmount.Columns)
            //{
            //    if (dc.Index.Equals(11))
            //    {
            //        dc.ReadOnly = false;
            //    }
            //    else
            //    {
            //        dc.ReadOnly = true;
            //    }
            //}


        }
        private DataTable getReportDT()
        {
            var checkedButton = gbCategory.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked);
            string query="";
            cmd = new MySqlCommand();
            DataSet ds = new DataSet();
            if (checkedButton.Text == "All")
            { query = "select DoctorName,case when RefAmount Is Null then 0 else RefAmount end AS RefAmount,PatientName,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,Age,Address,Gender,NetAmount,TestName,OrgName,UserName,isRefPaid,ExpenseAmount,Category from vw_report where CAST(BillDate AS DATE) >= '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and CAST(BillDate AS DATE) <='" + dtpTo.Value.ToString("yyyy-MM-dd") + "' order by Category,DoctorName,BillDate"; }
            else
            {
                query = "select DoctorName,case when RefAmount Is Null then 0 else RefAmount end AS RefAmount,PatientName,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,Age,Address,Gender,NetAmount,TestName,OrgName,UserName,isRefPaid,ExpenseAmount,Category from vw_report where CAST(BillDate AS DATE) >= '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and CAST(BillDate AS DATE) <='" + dtpTo.Value.ToString("yyyy-MM-dd") + "' and Category='" + checkedButton.Text + "' order by Category,DoctorName,BillDate";
            }
            cmd.CommandText = query;
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        private void dgRefAmount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 11)
            {
                try
                {
                    //        this.dgRefAmount.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    //        var isPaid = this.dgRefAmount[e.ColumnIndex, e.RowIndex].Value;
                    //        var id = this.dgRefAmount[0, e.RowIndex].Value;
                    //        string paid;
                    //        if ((bool)isPaid == true)
                    //        { paid = "Paid"; }
                    //        else
                    //        { paid = "UnPaid"; }

                    //        var sqlQuery = "UPDATE tbl_cashreceipt SET isRefPaid = " + isPaid + " WHERE ID = " + id + "";
                    //        con.Open();
                    //        cmd = con.CreateCommand();
                    //        cmd.CommandText = sqlQuery;
                    //        cmd.Connection = con;
                    //        cmd.ExecuteNonQuery();
                    //        con.Close();
                    //        MessageBox.Show("Referral amount is marked as " + paid + " for ID  " + id + "", "Congratulations");
                    if (Globals.username == "admin")
                    { }
                    else
                    {
                        MessageBox.Show("You need admin rights to mark Unpaid");
                        //dgRefAmount[e.ColumnIndex, e.RowIndex].Value = true;
                        dgRefAmount.RefreshEdit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }


        }
    }
}
