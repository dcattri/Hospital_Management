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
    public partial class frmRefAmount : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        //private BindingSource bindingSource = null;
        public frmRefAmount()
        {
            InitializeComponent();
        }

        private void FrmRefAmount_Load(object sender, EventArgs e)
        {
            //getRefAmount();
            getDoctorName();
            getRefAmountSearch();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer rpt = new frmReportViewer();
                rpt.rptName = "report/rptRefAmount.rdlc";
                rpt.dt = getReportDT();
                rpt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void getDoctorName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "Select 0 as DoctorID,'ALL' as DoctorName from tbl_doctormaster UNION select distinct ID as DoctorID, DoctorName from tbl_doctormaster";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cbDoctorName.DataSource = dt.Tables[0];
            cbDoctorName.DisplayMember = "DoctorName";
            cbDoctorName.ValueMember = "DoctorID";

            cbDoctorName.BindingContext = this.BindingContext;

            //dt.Clear();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            getRefAmountSearch();
        }
        private void getRefAmountSearch()
        {
            try
            {
                //DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                dt = new DataTable();
                cmd = con.CreateCommand();
                if (cbDoctorName.Text == "ALL")
                {
                    cmd.CommandText = "SELECT a.ID as BillID,tbl_doctormaster.DoctorName, case when a.RefAmount Is Null then 0 else a.RefAmount end AS RefAmount, a.PatientName, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate, a.Age, a.Address, a.Gender, a.NetAmount, GROUP_CONCAT(b.TestName) as TestName,a.UserName,a.isRefPaid FROM tbl_cashreceipt AS a LEFT JOIN tbl_doctormaster ON a.DoctorID = tbl_doctormaster.ID LEFT JOIN tbl_cashreceipt_details cd ON a.ID = cd.cashreceipt_ID LEFT JOIN tbl_testmaster b ON cd.test_ID = b.ID  where CAST(a.BillDate AS DATE) >= @from and CAST(a.BillDate AS DATE) <= @to group by tbl_doctormaster.DoctorName, case when a.RefAmount Is Null then 0 else a.RefAmount end , a.PatientName, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') , a.Age, a.Address, a.Gender, a.NetAmount,a.UserName,a.isRefPaid,a.ID";
                    cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    cmd.CommandText = "SELECT a.ID as BillID,tbl_doctormaster.DoctorName, case when a.RefAmount Is Null then 0 else a.RefAmount end AS RefAmount, a.PatientName, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate, a.Age, a.Address, a.Gender, a.NetAmount, GROUP_CONCAT(b.TestName) as TestName,a.UserName,a.isRefPaid FROM tbl_cashreceipt AS a LEFT JOIN tbl_doctormaster ON a.DoctorID = tbl_doctormaster.ID LEFT JOIN tbl_cashreceipt_details cd ON a.ID = cd.cashreceipt_ID LEFT JOIN tbl_testmaster b ON cd.test_ID = b.ID where a.DoctorID=@docId and CAST(a.BillDate AS DATE) >= @from and CAST(a.BillDate AS DATE) <= @to group by tbl_doctormaster.DoctorName, case when a.RefAmount Is Null then 0 else a.RefAmount end , a.PatientName, DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') , a.Age, a.Address, a.Gender, a.NetAmount,a.UserName,a.isRefPaid,a.ID";
                    cmd.Parameters.AddWithValue("@docId", cbDoctorName.SelectedValue);
                    cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
                }
                cmd.Connection = con;
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //dgRefAmount.ReadOnly = true;
                dgRefAmount.DataSource = dt;
                foreach (DataGridViewColumn dc in dgRefAmount.Columns)
                {
                    if (dc.Index.Equals(11))
                    {
                        dc.ReadOnly = false;
                    }
                    else
                    {
                        dc.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private DataTable getReportDT()
        {

            DataSet ds = new DataSet();
            cmd = con.CreateCommand();
            if (cbDoctorName.Text == "ALL")
            {
                cmd.CommandText = "select DoctorName,case when RefAmount Is Null then 0 else RefAmount end AS RefAmount,PatientName,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,Age,Address,Gender,TotalAmount,Discount,NetAmount,TestName,OrgName,UserName,isRefPaid from vw_report where CAST(BillDate AS DATE) >= @from and CAST(BillDate AS DATE) <= @to order by DoctorName";
                cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                cmd.CommandText = "select DoctorName,case when RefAmount Is Null then 0 else RefAmount end AS RefAmount,PatientName,DATE_FORMAT(BillDate,'%d-%b-%y %h:%i:%s %p') AS BillDate,Age,Address,Gender,TotalAmount,Discount,NetAmount,TestName,OrgName,UserName,isRefPaid from vw_report where DoctorID=@docId and CAST(BillDate AS DATE) >= @from and CAST(BillDate AS DATE) <= @to order by DoctorName";
                cmd.Parameters.AddWithValue("@docId", cbDoctorName.SelectedValue);
                cmd.Parameters.AddWithValue("@from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo.Value.ToString("yyyy-MM-dd"));
            }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDoctorName.SelectedValue.ToString() != "0")
                {
                    var sqlQuery = "UPDATE tbl_cashreceipt SET isRefPaid = @isPaid WHERE DoctorID = @docId";
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = sqlQuery;
                    cmd.Parameters.AddWithValue("@isPaid", true);
                    cmd.Parameters.AddWithValue("@docId", cbDoctorName.SelectedValue);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    getRefAmountSearch();
                    MessageBox.Show("Referral amount is marked as paid for doctor  " + cbDoctorName.Text + "", "Congratulations");
                    AuditTrail.Log(Globals.username, nameof(frmRefAmount), "BulkIsRefPaidUpdate", $"DoctorID={cbDoctorName.SelectedValue}, DoctorName={cbDoctorName.Text}, FromDate={dtpFrom.Text}, ToDate={dtpTo.Text}, SetTo=true, RowsAffected={rows}");
                }
                else
                {
                    MessageBox.Show("Please select a Doctor name from the list", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgRefAmount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                try
                {
                    this.dgRefAmount.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    var isPaid = this.dgRefAmount[e.ColumnIndex, e.RowIndex].Value;
                    var id = this.dgRefAmount[0, e.RowIndex].Value;
                    string paid;
                    if ((bool)isPaid == true)
                    { paid = "Paid"; }
                    else
                    { paid = "UnPaid"; }
                    // Read previous value from DB, then perform parameterized update and log audit
                    if (Globals.username == "admin" && (paid == "UnPaid" || paid == "Paid") || (Globals.username != "admin" && paid == "Paid"))
                    {
                        bool oldVal = false;
                        try
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "SELECT isRefPaid FROM tbl_cashreceipt WHERE ID = @id";
                            cmd.Parameters.AddWithValue("@id", id);
                            var obj = cmd.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                oldVal = Convert.ToBoolean(obj);

                            cmd.Parameters.Clear();
                            cmd.CommandText = "UPDATE tbl_cashreceipt SET isRefPaid = @isPaid WHERE ID = @id";
                            cmd.Parameters.AddWithValue("@isPaid", Convert.ToBoolean(isPaid));
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        finally
                        {
                            if (con.State == System.Data.ConnectionState.Open) con.Close();
                        }

                        AuditTrail.Log(Globals.username, nameof(frmRefAmount), "UpdateIsRefPaid", $"ID={id}, Old={oldVal}, New={isPaid}");
                    }
                    else
                    {
                        MessageBox.Show("You need admin rights to mark Unpaid");
                        dgRefAmount[e.ColumnIndex, e.RowIndex].Value = true;
                        dgRefAmount.RefreshEdit();
                    }
                    //MessageBox.Show("Referral amount is marked as " + paid + " for ID  " + id + "", "Congratulations");
                    //getRefAmountSearch();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
