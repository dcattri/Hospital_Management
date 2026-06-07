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
    public partial class frmMyProfile : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmMyProfile()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                con.Open();
                insertUser();
                con.Close();
            }
            else
            { MessageBox.Show("Password and Confirm Password doesn't Match", "Error"); }
        }
        private void getUser()
        {
            try
            {
                
                DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                cmd.CommandText = "select UserName,FirstName, LastName,UserPassword from tbl_usermaster where UserName=@user";
                cmd.Parameters.AddWithValue("@user", Globals.username);
                cmd.Connection = con;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                txtUserName.Text = dt.Tables[0].Rows[0]["UserName"].ToString();
                txtFirstName.Text = dt.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Tables[0].Rows[0]["LastName"].ToString();
                txtPassword.Text = dt.Tables[0].Rows[0]["UserPassword"].ToString();
                txtConfirmPassword.Text = dt.Tables[0].Rows[0]["UserPassword"].ToString();

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
                if (txtUserName.Text != "")
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "update tbl_usermaster set UserPassword=@pwd where UserName=@user";
                    cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@user", Globals.username);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password changed succesfully", "Congratulations");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            getUser();
        }
    }
}
