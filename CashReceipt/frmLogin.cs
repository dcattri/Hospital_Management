using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    public partial class frmLogin : BaseForm
    {
        
        public frmLogin()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cboBranch.Text=="")
            {
                MessageBox.Show("Please select branch name", "Error");
            }
            else
            {
                Globals.branch = cboBranch.Text;
                login();
            }
            
        }
        private void login()
        {
            frmMain mainForm = new frmMain();

            if (verifyUser() == true)
            {
                Globals.username = txtName.Text;
                AuditTrail.Log(Globals.username, nameof(frmLogin), "Login", "User logged in");
                mainForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
                mainForm.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Incorrect username or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        private Boolean verifyUser()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Global.con());
                MySqlCommand cmd;

                DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                cmd.CommandText = "select UserName,UserPassword from tbl_usermaster where UserName=@user and UserPassword=@pwd";
                cmd.Parameters.AddWithValue("@user", txtName.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
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

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.branch = cboBranch.Text;
        }
    }
}
