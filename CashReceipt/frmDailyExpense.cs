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
    public partial class frmDailyExpense : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmDailyExpense()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtID.Text != "")
            {
                //DialogResult dialogResult = MessageBox.Show("There is already an expense entry for the date: " + dtpDate.Value.ToString("dd-MMM-yyyy") + "."+ "\n" + "Do you want to update the expense?", "Warning", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    updateDoctor();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    //do something else
                //}
                updateDoctor();

            }
            else
            { insertExpense(); }

            getDailyExpense();
            con.Close();
        }

        private void txtExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void insertExpense()
        {
            try
            {
                if (txtExpense.Text != "")
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into tbl_dailyexpense(ExpenseDate,Amount,UserName,Remarks) Values(@date,@amount,@user,@remarks)";
                    cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@amount", txtExpense.Text);
                    cmd.Parameters.AddWithValue("@user", Globals.username.ToString());
                    cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Daily expense saved successfully", "Congratulations");
                    clearform();
                }
                else
                { MessageBox.Show("Please enter expense amount", "Error"); }
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
                if (txtExpense.Text != "")
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "update tbl_dailyexpense set Amount = @amount, ExpenseDate=@date, Remarks=@remarks where ID=@id";
                    cmd.Parameters.AddWithValue("@amount", txtExpense.Text);
                    cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Daily expense updated successfully", "Congratulations");
                    clearform();
                }
                else
                { MessageBox.Show("Please enter expense amount", "Error"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void gvExpense_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gvExpense.Rows[e.RowIndex].Cells[0].Value.ToString();
            dtpDate.Value = DateTime.Parse(gvExpense.Rows[e.RowIndex].Cells[1].Value.ToString());
            txtExpense.Text = gvExpense.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRemarks.Text = gvExpense.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void getDailyExpense()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from tbl_dailyexpense order by ExpenseDate";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvExpense.DataSource = dt.Tables[0];
            gvExpense.BindingContext = this.BindingContext;
        }

        private void frmDailyExpense_Load(object sender, EventArgs e)
        {
            getDailyExpense();
        }
        private Boolean checkExpense()
        {
            Boolean flag;
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from tbl_dailyexpense where ID=@id";
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Tables[0].Rows.Count > 0)
            { flag = true; }
            else
            { flag = false; }
            return flag;
        }
        private void clearform()
        {
            txtExpense.Text = "";
            txtRemarks.Text = "";
            txtID.Text = "";
        }
    }
}
