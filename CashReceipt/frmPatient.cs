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

    public partial class frmPatient : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        string searchtype;
        public frmPatient()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {

            //dtpBillDate.Value = DateTime.Now.ToString("dd-MMM-yy");
            getDoctorName();
            getGender();
            gbSearch.Visible = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            insertReceipt();
            con.Close();
        }

        private void insertReceipt()
        {
            try
            {
                if (txtName.Text != "" && txtMobile.Text != "")
                {
                    string relationtype = "";
                    if (rbWife.Checked == true)
                    {
                        relationtype = "W/o";
                    }
                    if (rbDaughter.Checked == true)
                    {
                        relationtype = "D/o";
                    }
                    if (rbSon.Checked == true)
                    {
                        relationtype = "S/o";
                    }
                    if (txtPatientNo.Text != "")
                    {
                        if (Globals.username == "admin")
                        {
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update tbl_patient set PatientName=@pname, CreatedDate=@cdate, DoctorID=@docid, Relation=@relation, Mobile=@mobile, Age=@age, Address=@address, Gender=@gender, RelationType=@relationtype where PatientID=@id";
                            cmd.Parameters.AddWithValue("@pname", txtName.Text);
                            cmd.Parameters.AddWithValue("@cdate", dtpBillDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@docid", cboDoctorName.SelectedValue);
                            cmd.Parameters.AddWithValue("@relation", txtRelation.Text);
                            cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@age", txtAge.Text);
                            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem);
                            cmd.Parameters.AddWithValue("@relationtype", relationtype);
                            cmd.Parameters.AddWithValue("@id", txtPatientNo.Text);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("You are not Authorized to edit old records, contact admin", "Error");
                        }
                    }
                    else
                    {
                        int refno = 0;
                        Int32.TryParse(lblRefNo.Text, out refno);
                        cmd = con.CreateCommand();
                        cmd.CommandText = "Insert into tbl_patient(PatientName,CreatedDate,DoctorID,CreatedBy,Relation,Mobile,Age,Address,Gender,RelationType,RefNo) Values(@pname,@cdate,@docid,@createdby,@relation,@mobile,@age,@address,@gender,@relationtype,@refno)";
                        cmd.Parameters.AddWithValue("@pname", txtName.Text);
                        cmd.Parameters.AddWithValue("@cdate", dtpBillDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@docid", cboDoctorName.SelectedValue);
                        cmd.Parameters.AddWithValue("@createdby", Globals.username.ToString());
                        cmd.Parameters.AddWithValue("@relation", txtRelation.Text);
                        cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem);
                        cmd.Parameters.AddWithValue("@relationtype", relationtype);
                        cmd.Parameters.AddWithValue("@refno", refno);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        getBillNo();
                    }
                    ((frmMain)Application.OpenForms["frmMain"]).getRef();
                    MessageBox.Show("Record Submitted", "Congrats");
                    
                }
                else
                {
                    MessageBox.Show("Please enter patient name,mobile number and test name", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void getBillNo()
        {
            DataSet dt = new DataSet();
            cmd.CommandText = "select max(PatientID) as billno from tbl_patient";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            txtPatientNo.Text = dt.Tables[0].Rows[0][0].ToString();
            dt.Clear();
        }
        private void getDoctorName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select ID as DoctorID,DoctorName from tbl_doctormaster where isDeleted=0 order by DoctorName";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cboDoctorName.DataSource = dt.Tables[0];
            cboDoctorName.DisplayMember = "DoctorName";
            cboDoctorName.ValueMember = "DoctorID";

            cboDoctorName.BindingContext = this.BindingContext;


            //dt.Clear();
        }
        private void getGender()
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Transgender");
        }
        private void getSearch(string searchstring, string searchwith)
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            if (searchwith == "")
            { cmd.CommandText = "select PatientID,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient order by CreatedDate desc limit 50"; }
            else
            {
                cmd.CommandText = "select PatientID,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient where " + searchwith + " like @search order by CreatedDate desc limit 50";
                cmd.Parameters.AddWithValue("@search", "%" + searchstring + "%");
            }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvSearch.DataSource = dt.Tables[0];
            gvSearch.BindingContext = this.BindingContext;
        }
        private void getRefSearch(string searchstring, string searchwith)
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            if (searchwith == "")
            { cmd.CommandText = "select PatientID as RefNo,DoctorName,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient_ref where PatientID not in (select RefNo from tbl_patient where RefNo is not null)"; }
            else
            {
                cmd.CommandText = "select PatientID as RefNo,DoctorName,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient_ref where PatientID not in (select RefNo from tbl_patient where RefNo is not null) and " + searchwith + " like @search";
                cmd.Parameters.AddWithValue("@search", "%" + searchstring + "%");
            }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvSearch.DataSource = dt.Tables[0];
            gvSearch.BindingContext = this.BindingContext;
        }
        private void LoadSearch(string BillNo)
        {
            //btnSave.Enabled = false;
            //btn_SavePrint.Enabled = false;

            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_patient where PatientID = @id;";
            cmd.Parameters.AddWithValue("@id", BillNo);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            lblRefNo.Text = "";
            txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
            txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
            txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
            txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
            txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
            txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
            if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); };
            dtpBillDate.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["CreatedDate"]);
            cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }

            //frmMain mainForm = new frmMain();
        }

        private void LoadRefSearch(string RefNo)
        {
            //btnSave.Enabled = false;
            //btn_SavePrint.Enabled = false;

            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_patient_ref where PatientID = @id;";
            cmd.Parameters.AddWithValue("@id", RefNo);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            lblRefNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
            txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
            txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
            txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
            txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
            txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
            if (dt.Tables[0].Rows[0]["DoctorName"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedText = dt.Tables[0].Rows[0]["DoctorName"].ToString(); };
            dtpBillDate.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["CreatedDate"]);
            cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "Wife of") { rbWife.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "Son of") { rbSon.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "Daughter of") { rbDaughter.Checked = true; }

            //frmMain mainForm = new frmMain();
        }


        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gbSearch.Visible = true;
            searchtype = "search";
            getSearch("", "");
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchName.Text.Length > 3)
            {
                txtSearchMobile.Text = "";
                if (searchtype == "search")
                { getSearch(txtSearchName.Text, "PatientName"); }
                else
                { getRefSearch(txtSearchName.Text, "PatientName"); }

            }
        }

        private void txtSearchMobile_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchMobile.Text.Length > 5)
            {
                txtSearchName.Text = "";
                if (searchtype == "search")
                { getSearch(txtSearchMobile.Text, "Mobile"); }
                else
                { getRefSearch(txtSearchMobile.Text, "Mobile"); }

            }
        }

        private void gvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = gvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
            con.Open();
            if (searchtype == "search")
            { LoadSearch(cellValue); }
            else
            { LoadRefSearch(cellValue); }
            gbSearch.Visible = false;
            con.Close();
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            //getTestName();
            //getDoctorName();
            //getGender();
            gbSearch.Visible = false;
            txtPatientNo.Text = "";
            txtName.Text = "";
            txtRelation.Text = "";
            txtSearchMobile.Text = "";
            txtSearchName.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";

            txtMobile.Text = "";

            rbWife.Checked = true;
            rbSon.Checked = false;
            rbDaughter.Checked = false;
            dtpBillDate.Value = DateTime.Now;

        }

        private void frmPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gbSearch.Visible = false;
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            gbSearch.Visible = true;
            searchtype = "searchRef";
            getRefSearch("", "");
        }
    }
}
