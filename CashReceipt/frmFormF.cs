using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    public partial class frmFormF : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmFormF()
        {
            InitializeComponent();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            insertReceipt();
            btnPrint.Enabled = true;
            MessageBox.Show("Record Submitted", "Congrats");
            con.Close();
        }

        private void frmFormF_Load(object sender, EventArgs e)
        {
            getDoctorName();
        }
        private void getDoctorName()
        {
            List<string> doctors = new List<string>();
            doctors = File.ReadAllLines("doctors.txt").Select(x => x.Split('_')[0]).ToList();
            foreach (var doctor in doctors)
            {
                cboDoctorName.Items.Add(doctor);
            }


        }
        private DataTable getReportDT()
        {
            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_formf where BillNo = @id;";
            cmd.Parameters.AddWithValue("@id", txtBillNo.Text);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Tables[0];
        }
        public void LoadSearch(string BillNo)
        {
            try
            {

                DataSet dt = new DataSet();

                cmd = new MySqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from tbl_formf where BillNo = @id;";
                cmd.Parameters.AddWithValue("@id", BillNo);
                cmd.Connection = con;
                MySqlDataAdapter daformf = new MySqlDataAdapter(cmd);
                daformf.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    txt1.Text = dt.Tables[0].Rows[0]["txt1"].ToString();
                    txt2.Text = dt.Tables[0].Rows[0]["txt2"].ToString();
                    txt3.Text = dt.Tables[0].Rows[0]["txt3"].ToString();
                    txt3a.Text = dt.Tables[0].Rows[0]["txt3a"].ToString();
                    txt4.Text = dt.Tables[0].Rows[0]["txt4"].ToString();
                    txt4a.Text = dt.Tables[0].Rows[0]["txt4a"].ToString();
                    txt4b.Text = dt.Tables[0].Rows[0]["txt4b"].ToString();
                    txt5.Text = dt.Tables[0].Rows[0]["txt5"].ToString();
                    txt6.Text = dt.Tables[0].Rows[0]["txt6"].ToString();
                    txt7a.Text = dt.Tables[0].Rows[0]["txt7a"].ToString();
                    txt7b.Text = dt.Tables[0].Rows[0]["txt7b"].ToString();
                    txt8.Text = dt.Tables[0].Rows[0]["txt8"].ToString();
                    cboDoctorName.SelectedItem = dt.Tables[0].Rows[0]["txt9"].ToString();
                    txt10.Text = dt.Tables[0].Rows[0]["txt10"].ToString();
                    chk11a.Checked = (bool)dt.Tables[0].Rows[0]["txt11a"];
                    chk11b.Checked = (bool)dt.Tables[0].Rows[0]["txt11b"];
                    txt11.Text = dt.Tables[0].Rows[0]["txt11c"].ToString();
                    dtp12.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["txt12"]);
                    dtp13.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["txt13"]);
                    txt14.Text = dt.Tables[0].Rows[0]["txt14"].ToString();
                    txt15.Text = dt.Tables[0].Rows[0]["txt15"].ToString();
                    txt16.Text = dt.Tables[0].Rows[0]["txt16"].ToString();
                }
                else
                {
                    dt.Tables.Clear();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "select a.*,DoctorName from tbl_cashreceipt a left join tbl_doctormaster b on a.DoctorID=b.ID where a.ID = @id;";
                    cmd.Parameters.AddWithValue("@id", BillNo);
                    cmd.Connection = con;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    txtBillNo.Text = dt.Tables[0].Rows[0]["ID"].ToString();
                    txt3.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                    txt5.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
                    txt7a.Text = dt.Tables[0].Rows[0]["DoctorName"].ToString();
                    txt3a.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                    txt6.Text = dt.Tables[0].Rows[0]["Address"].ToString() + " - Mobile No :" + dt.Tables[0].Rows[0]["Mobile"].ToString();
                    txt15.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txtBillNo_Leave(object sender, EventArgs e)
        {
            if (txtBillNo.Text.Length > 2)
            { LoadSearch(txtBillNo.Text); }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            if (txtBillNo.Text != "" && txt1.Text != "" && txt2.Text != "" && txt3.Text != "" && txt3a.Text != "" && txt4.Text != "" && txt5.Text != "" && txt6.Text != "" && txt7a.Text != "" && txt7b.Text != "" && txt8.Text != ""
                && cboDoctorName.Text != "" && txt10.Text != "" && txt14.Text != "" && txt15.Text != "" && txt16.Text != "")
            {
                con.Open();
                insertReceipt();
                con.Close();
                frmReportViewer rpt = new frmReportViewer();
                rpt.rptName = "rptFormF.rdlc";
                rpt.dt = getReportDT();
                rpt.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the details before print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportViewer rpt = new frmReportViewer();
            rpt.rptName = "rptFormF.rdlc";
            rpt.dt = getReportDT();
            rpt.Show();
        }
        private void insertReceipt()
        {
            if (txtBillNo.Text != "")
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM tbl_formf WHERE BillNo = @billno;";
                cmd.Parameters.AddWithValue("@billno", txtBillNo.Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tbl_formf (BillNo,txt1,txt2,txt3,txt3a,txt4,txt4a,txt4b,txt5,txt6,txt7a,txt7b,txt8,txt9,txt10,txt11a,txt11b,txt11c,txt12,txt13,txt14,txt15,txt16) " +
                    "VALUES(@billno,@txt1,@txt2,@txt3,@txt3a,@txt4,@txt4a,@txt4b,@txt5,@txt6,@txt7a,@txt7b,@txt8,@txt9,@txt10,@txt11a,@txt11b,@txt11c,@txt12,@txt13,@txt14,@txt15,@txt16)";
                cmd.Parameters.AddWithValue("@billno", txtBillNo.Text);
                cmd.Parameters.AddWithValue("@txt1", txt1.Text);
                cmd.Parameters.AddWithValue("@txt2", txt2.Text);
                cmd.Parameters.AddWithValue("@txt3", txt3.Text);
                cmd.Parameters.AddWithValue("@txt3a", txt3a.Text);
                cmd.Parameters.AddWithValue("@txt4", txt4.Text);
                cmd.Parameters.AddWithValue("@txt4a", txt4a.Text);
                cmd.Parameters.AddWithValue("@txt4b", txt4b.Text);
                cmd.Parameters.AddWithValue("@txt5", txt5.Text);
                cmd.Parameters.AddWithValue("@txt6", txt6.Text);
                cmd.Parameters.AddWithValue("@txt7a", txt7a.Text);
                cmd.Parameters.AddWithValue("@txt7b", txt7b.Text);
                cmd.Parameters.AddWithValue("@txt8", txt8.Text);
                cmd.Parameters.AddWithValue("@txt9", cboDoctorName.Text);
                cmd.Parameters.AddWithValue("@txt10", txt10.Text);
                cmd.Parameters.AddWithValue("@txt11a", chk11a.Checked);
                cmd.Parameters.AddWithValue("@txt11b", chk11b.Checked);
                cmd.Parameters.AddWithValue("@txt11c", txt11.Text);
                cmd.Parameters.AddWithValue("@txt12", dtp12.Value);
                cmd.Parameters.AddWithValue("@txt13", dtp13.Value);
                cmd.Parameters.AddWithValue("@txt14", txt14.Text);
                cmd.Parameters.AddWithValue("@txt15", txt15.Text);
                cmd.Parameters.AddWithValue("@txt16", txt16.Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
