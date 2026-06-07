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
    public partial class frmAddNewTest : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmAddNewTest()
        {
            InitializeComponent();
        }
        private void getTestName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select ID as TestID,TestName,Price,isDeleted,Category from tbl_testmaster order by TestName";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvTest.DataSource = dt.Tables[0];
            gvTest.BindingContext = this.BindingContext;

            //dt.Clear();
        }

        private void frmAddNewTest_Load(object sender, EventArgs e)
        {
            getTestName();
        }
        private void insertTest()
        {
            try
            {
                if (txtTestName.Text != "" && txtID.Text == "")
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into tbl_testmaster(TestName,Price,isDeleted,Category) Values(@name,@price,@deleted,@cat)";
                    cmd.Parameters.AddWithValue("@name", txtTestName.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@deleted", chkDelete.Checked);
                    cmd.Parameters.AddWithValue("@cat", cboTestCategory.SelectedItem);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmAddNewTest), "Insert", $"TestName={txtTestName.Text}, Price={txtPrice.Text}");
                }
                if (txtTestName.Text != "" && txtID.Text != "")
                {
                    // read old
                    string oldName = null; string oldPrice = null; bool oldDeleted = false; string oldCat = null;
                    try
                    {
                        var rcmd = con.CreateCommand();
                        rcmd.CommandText = "select TestName,Price,isDeleted,Category from tbl_testmaster where id=@id";
                        rcmd.Parameters.AddWithValue("@id", txtID.Text);
                        using (var rdr = rcmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                oldName = rdr[0].ToString();
                                oldPrice = rdr[1].ToString();
                                oldDeleted = Convert.ToBoolean(rdr[2]);
                                oldCat = rdr[3].ToString();
                            }
                        }
                    }
                    catch { }

                    cmd = con.CreateCommand();
                    cmd.CommandText = "update tbl_testmaster set TestName=@name,Price=@price,isDeleted=@deleted,Category=@cat where id=@id";
                    cmd.Parameters.AddWithValue("@name", txtTestName.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@deleted", chkDelete.Checked);
                    cmd.Parameters.AddWithValue("@cat", cboTestCategory.SelectedItem);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmAddNewTest), "Update", $"ID={txtID.Text}, OldName={oldName}, NewName={txtTestName.Text}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            insertTest();
            txtTestName.Text = "";
            txtID.Text = "";
            txtPrice.Text = "";
            cboTestCategory.Text = "";
            getTestName();
            con.Close();
        }

        private void btn_opd_Click(object sender, EventArgs e)
        {
            con.Open();
            //insertTestOPD();
            txtTestName.Text = "";
            getTestName();
            con.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&& (e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void gvTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gvTest.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTestName.Text = gvTest.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = gvTest.Rows[e.RowIndex].Cells[2].Value.ToString();
            chkDelete.Checked = (Boolean)gvTest.Rows[e.RowIndex].Cells[3].Value;
            cboTestCategory.Text = gvTest.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
