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
    public partial class frmCreateUser : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmCreateUser()
        {
            InitializeComponent();
        }
        private void getUser()
        {
            try
            {
                DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                cmd.CommandText = "select UserName,FirstName, LastName,UserPassword from tbl_usermaster";
                cmd.Connection = con;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                gvTest.DataSource = dt.Tables[0];
                gvTest.BindingContext = this.BindingContext;
                gvTest.Columns["UserPassword"].Visible = false;
                //dt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void insertUser()
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    cmd = con.CreateCommand();
                    string newUser = (txtFirstName.Text.Trim() + txtLastName.Text.Trim());
                    cmd.CommandText = "Insert into tbl_usermaster(UserName,FirstName, LastName,UserPassword) Values(@user,@first,@last,@pwd)";
                    cmd.Parameters.AddWithValue("@user", newUser);
                    cmd.Parameters.AddWithValue("@first", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmCreateUser), "Insert", $"UserName={newUser}");
                }
                if (txtUserName.Text != "")
                {
                    // read old
                    string oldFirst = null, oldLast = null, oldPwd = null;
                    try
                    {
                        var rcmd = con.CreateCommand();
                        rcmd.CommandText = "select FirstName,LastName,UserPassword from tbl_usermaster where UserName=@user";
                        rcmd.Parameters.AddWithValue("@user", txtUserName.Text);
                        using (var rdr = rcmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                oldFirst = rdr[0].ToString();
                                oldLast = rdr[1].ToString();
                                oldPwd = rdr[2].ToString();
                            }
                        }
                    }
                    catch { }

                    cmd = con.CreateCommand();
                    cmd.CommandText = "update tbl_usermaster set FirstName=@first,LastName=@last,UserPassword=@pwd where UserName=@user";
                    cmd.Parameters.AddWithValue("@first", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditTrail.Log(Globals.username, nameof(frmCreateUser), "Update", $"UserName={txtUserName.Text}, OldFirst={oldFirst}, NewFirst={txtFirstName.Text}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                if (duplicateUser() == false)
                {
                    con.Open();
                    insertUser();
                    txtUserName.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    getUser();
                    con.Close();
                }
                else
                { MessageBox.Show("UserName Already exists", "Error"); }
            }
            else
            { MessageBox.Show("Password and Confirm Password doesn't Match", "Error"); }
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            getUser();
        }

        private void gvTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = gvTest.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = gvTest.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = gvTest.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = gvTest.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtConfirmPassword.Text = gvTest.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private Boolean duplicateUser()
        {
            try
            {

                DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                cmd.CommandText = "select UserName from tbl_usermaster where UserName=@user";
                cmd.Parameters.AddWithValue("@user", txtFirstName.Text.Trim() + txtLastName.Text.Trim());
                cmd.Connection = con;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                { return true; }
                else
                { return false; }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserName.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure, you want to delete " + txtUserName.Text + " user permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "delete from tbl_usermaster where UserName=@user";
                        cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        getUser();
                        txtConfirmPassword.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPassword.Text = "";
                        txtUserName.Text = "";
                        MessageBox.Show("User delete successfuly", "Message");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    MessageBox.Show("Select a user to delete", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
