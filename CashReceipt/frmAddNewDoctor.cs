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
    public partial class frmAddNewDoctor : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmAddNewDoctor()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            con.Open();
            if (lblDocid.Text == "0")
            { insertDoctor(); }
            else
            { updateDoctor(); }
            txtDoctorName.Text = "";
            getDoctorName();
            con.Close();
        }
        private void getDoctorName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select ID as DoctorID,DoctorName,isDeleted from tbl_doctormaster order by DoctorName";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvTest.DataSource = dt.Tables[0];
            gvTest.BindingContext = this.BindingContext;

            //dt.Clear();
        }

        private void FrmAddNewDoctor_Load(object sender, EventArgs e)
        {
            getDoctorName();
        }
        private void insertDoctor()
        {
            try
            {
                if (txtDoctorName.Text != "")
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into tbl_doctormaster(DoctorName,isDeleted) Values(@name,@deleted)";
                    cmd.Parameters.AddWithValue("@name", txtDoctorName.Text);
                    cmd.Parameters.AddWithValue("@deleted", chkDelete.Checked);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmAddNewDoctor), "Insert", $"DoctorName={txtDoctorName.Text}, isDeleted={chkDelete.Checked}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void updateDoctor()
        {
            try
            {
                if (txtDoctorName.Text != "" && lblDocid.Text != "0")
                {
                    // read old
                    string oldName = null;
                    bool oldDeleted = false;
                    try
                    {
                        var rcmd = con.CreateCommand();
                        rcmd.CommandText = "select DoctorName,isDeleted from tbl_doctormaster where id=@id";
                        rcmd.Parameters.AddWithValue("@id", lblDocid.Text);
                        using (var rdr = rcmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                oldName = rdr[0].ToString();
                                oldDeleted = Convert.ToBoolean(rdr[1]);
                            }
                        }
                    }
                    catch { }

                    cmd = con.CreateCommand();
                    cmd.CommandText = "update tbl_doctormaster set DoctorName = @name, isDeleted=@deleted where id=@id";
                    cmd.Parameters.AddWithValue("@name", txtDoctorName.Text);
                    cmd.Parameters.AddWithValue("@deleted", chkDelete.Checked);
                    cmd.Parameters.AddWithValue("@id", lblDocid.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmAddNewDoctor), "Update", $"ID={lblDocid.Text}, OldName={oldName}, NewName={txtDoctorName.Text}, OldDeleted={oldDeleted}, NewDeleted={chkDelete.Checked}");
                    lblDocid.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void GvTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDoctorName.Text = gvTest.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblDocid.Text = gvTest.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

    }
}
