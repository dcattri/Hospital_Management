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
    public partial class frmIPD : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        string SearchPatientName;
        string searchtype;

        public frmIPD()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }
        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents    
                        endStr = "Paisa " + endStr;//Cents    
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
        private void getPatientSearch(string searchstring, string searchwith)
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            if (searchwith == "")
            { cmd.CommandText = "select p.PatientID,p.PatientName,p.RelationType,p.Relation,p.CreatedDate,p.Mobile, c.ID as IPDNo from tbl_patient p left join (select ID,PatientID,isIPD,isDischarged from tbl_cashreceipt) c on p.PatientID=c.PatientID where isIPD=True and isDischarged=False order by CreatedDate desc limit 50"; }
            else
            { cmd.CommandText = "select p.PatientID,p.PatientName,p.RelationType,p.Relation,p.CreatedDate,p.Mobile, c.ID as IPDNo from tbl_patient p left join (select ID,PatientID,isIPD,isDischarged from tbl_cashreceipt) c on p.PatientID=c.PatientID where  isIPD=True and isDischarged=False and " + searchwith + " like '%" + searchstring + "%' order by CreatedDate desc limit 50"; }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvSearch.DataSource = dt.Tables[0];
            gvSearch.BindingContext = this.BindingContext;
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
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSearchBillNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBillNo.Text.Length >= 3)
            {
                txtSearchMobile.Text = "";
                txtSearchName.Text = "";
                getPatientSearch(txtSearchBillNo.Text, "PatientID");

            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text.Length >= 3)
            {
                txtSearchMobile.Text = "";
                txtSearchBillNo.Text = "";
                getPatientSearch(txtSearchName.Text, "PatientName");

            }
        }

        private void txtSearchMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchMobile.Text.Length >= 3)
            {
                txtSearchName.Text = "";
                txtSearchBillNo.Text = "";
                getPatientSearch(txtSearchMobile.Text, "Mobile");

            }
        }

        private void gvSearch_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string PatientNo = gvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
            SearchPatientName = gvSearch.Rows[e.RowIndex].Cells[1].Value.ToString();
            string IPDNo = gvSearch.Rows[e.RowIndex].Cells[6].Value.ToString();
            con.Open();
            LoadSearch(PatientNo, IPDNo);
            gbSearch.Visible = false;
            con.Close();
        }

        private void chkRefPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.username != "admin" && chkRefPaid.Checked == false)
            {
                MessageBox.Show("You need admin rights to mark Unpaid");
                chkRefPaid.Checked = true;
            }
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            lblSearchNo.Text = "Search By Patient No";
            gbSearch.Visible = true;
            searchtype = "Patient Search";
            getPatientSearch("", "");
        }

        private void frmIPD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gbSearch.Visible = false;
            }
        }
        private void LoadSearch(string PatientNo, string IPDNo)
        {
            //btnSave.Enabled = false;
            //btn_SavePrint.Enabled = false;
            btn_Print.Enabled = true;

            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "select c.ID as IPDNo,c.isDischarged,c.isRefPaid,p.PatientID,p.PatientName,p.Relation,p.Mobile,p.Age,p.Address,p.DoctorID,p.Gender,p.RelationType,sum(Discount) as Discount,sum(RefAmount) as RefAmount, sum(TotalAmount) as TotalAmount,sum(NetAmount) as NetAmount from tbl_cashreceipt c inner join tbl_patient p on c.patientid=p.patientid where c.PatientID = @patientId and c.ID=@ipdId group by c.ID,p.PatientID,p.PatientName,p.Relation,p.Mobile,p.Age,p.Address,p.DoctorID,p.Gender,p.RelationType,c.isDischarged,c.isRefPaid order by c.ID desc;";
            cmd.Parameters.AddWithValue("@patientId", PatientNo);
            cmd.Parameters.AddWithValue("@ipdId", IPDNo);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Tables[0].Rows.Count > 0)
            {
                if ((bool)dt.Tables[0].Rows[0]["isDischarged"] == true)
                {
                    DialogResult dialogResult = MessageBox.Show(SearchPatientName + " patient has been discharged, do you want to create new IPD for " + SearchPatientName + "?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dt = new DataSet();
                        cmd = new MySqlCommand();
                        cmd.CommandText = "select * from tbl_patient where PatientID = " + PatientNo + ";";
                        cmd.Connection = con;
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                            txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
                            txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
                            txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                            txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                            if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); };
                            txtDiscount.Text = "0";
                            txtRefAmount.Text = "0";
                            if (txtRefAmount.Text == "") { txtRefAmount.Text = "0"; }
                            lblTotalAmount.Text = "0";
                            lblNetAmt.Text = "0";
                            cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
                            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
                            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
                            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }
                            chkRefPaid.Checked = false;
                            chkDischarged.Checked = false;
                            txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
                        }
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
                        cmd = con.CreateCommand();
                        cmd.CommandText = "Insert into tbl_cashreceipt(PatientName,BillDate,DoctorID,UserName,OrgID,Relation,Mobile,Age,Address,Gender,TotalAmount,Discount,RefAmount,NetAmount,NetAmountWords,TestID,Rate,RelationType, isRefPaid,PatientID,isIPD,isDischarged) " +
                            "Values('" + txtName.Text + "',CURRENT_TIMESTAMP(),'" + cboDoctorName.SelectedValue + "','" + Globals.username.ToString() + "',1,'" + txtRelation.Text + "','" + txtMobile.Text + "','" + txtAge.Text + "','" + txtAddress.Text + "','" + cbGender.SelectedItem + "','0','0','0','0','Zero',224,'0','" + relationtype + "'," + false + "," + txtPatientNo.Text + "," + true + "," + false + ")";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        dt = new DataSet();
                        cmd = new MySqlCommand();
                        cmd.CommandText = "select ID as IPDNo from tbl_cashreceipt where PatientID = " + PatientNo + ";";
                        cmd.Connection = con;
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            txtIPDNo.Text = dt.Tables[0].Rows[0]["IPDNo"].ToString();
                        }

                        cmd = con.CreateCommand();
                        cmd.CommandText = "insert into tbl_cashreceipt_details(cashreceipt_ID,test_ID) values(" + txtIPDNo.Text + ",224)";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        LoadSearch(txtPatientNo.Text, txtIPDNo.Text);
                    }
                    else
                    {
                        txtIPDNo.Text = dt.Tables[0].Rows[0]["IPDNo"].ToString();
                        txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                        txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
                        txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
                        txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                        txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                        if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); };
                        txtDiscount.Text = dt.Tables[0].Rows[0]["Discount"].ToString();
                        txtRefAmount.Text = dt.Tables[0].Rows[0]["RefAmount"].ToString();
                        if (txtRefAmount.Text == "") { txtRefAmount.Text = "0"; }
                        lblTotalAmount.Text = dt.Tables[0].Rows[0]["TotalAmount"].ToString();
                        lblNetAmt.Text = dt.Tables[0].Rows[0]["NetAmount"].ToString();
                        cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }
                        chkRefPaid.Checked = (bool)dt.Tables[0].Rows[0]["isRefPaid"];
                        chkDischarged.Checked = (bool)dt.Tables[0].Rows[0]["isDischarged"];
                        txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
                        LoadIPDServices();
                    }
                }
                else
                {
                    txtIPDNo.Text = dt.Tables[0].Rows[0]["IPDNo"].ToString();
                    txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                    txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
                    txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
                    txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                    txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                    if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); };
                    txtDiscount.Text = dt.Tables[0].Rows[0]["Discount"].ToString();
                    txtRefAmount.Text = dt.Tables[0].Rows[0]["RefAmount"].ToString();
                    if (txtRefAmount.Text == "") { txtRefAmount.Text = "0"; }
                    lblTotalAmount.Text = dt.Tables[0].Rows[0]["TotalAmount"].ToString();
                    lblNetAmt.Text = dt.Tables[0].Rows[0]["NetAmount"].ToString();
                    cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
                    if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
                    if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
                    if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }
                    chkRefPaid.Checked = (bool)dt.Tables[0].Rows[0]["isRefPaid"];
                    chkDischarged.Checked = (bool)dt.Tables[0].Rows[0]["isDischarged"];
                    txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
                    LoadIPDServices();
                }

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(SearchPatientName + " patient has no records, do you want to register " + SearchPatientName + " for IPD?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dt = new DataSet();
                    cmd = new MySqlCommand();
                    cmd.CommandText = "select * from tbl_patient where PatientID = " + PatientNo + ";";
                    cmd.Connection = con;
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
                        txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
                        txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
                        txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
                        txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
                        if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); };
                        txtDiscount.Text = "0";
                        txtRefAmount.Text = "0";
                        if (txtRefAmount.Text == "") { txtRefAmount.Text = "0"; }
                        lblTotalAmount.Text = "0";
                        lblNetAmt.Text = "0";
                        cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
                        if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }
                        chkRefPaid.Checked = false;
                        chkDischarged.Checked = false;
                        txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
                    }
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
                    cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into tbl_cashreceipt(PatientName,BillDate,DoctorID,UserName,OrgID,Relation,Mobile,Age,Address,Gender,TotalAmount,Discount,RefAmount,NetAmount,NetAmountWords,TestID,Rate,RelationType, isRefPaid,PatientID,isIPD,isDischarged) " +
                        "Values(@pname,CURRENT_TIMESTAMP(),@docid,@user,1,@relation,@mobile,@age,@address,@gender,0,0,0,0,'Zero',224,0,@relationtype,0,@patientid,1,0)";
                    cmd.Parameters.AddWithValue("@pname", txtName.Text);
                    cmd.Parameters.AddWithValue("@docid", cboDoctorName.SelectedValue);
                    cmd.Parameters.AddWithValue("@user", Globals.username.ToString());
                    cmd.Parameters.AddWithValue("@relation", txtRelation.Text);
                    cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@relationtype", relationtype);
                    cmd.Parameters.AddWithValue("@patientid", txtPatientNo.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();

                        dt = new DataSet();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "select ID as IPDNo from tbl_cashreceipt where PatientID = @id;";
                        cmd.Parameters.AddWithValue("@id", PatientNo);
                        cmd.Connection = con;
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        txtIPDNo.Text = dt.Tables[0].Rows[0]["IPDNo"].ToString();
                    }

                        cmd = con.CreateCommand();
                        cmd.CommandText = "insert into tbl_cashreceipt_details(cashreceipt_ID,test_ID) values(@id,224)";
                        cmd.Parameters.AddWithValue("@id", txtIPDNo.Text);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    LoadSearch(txtPatientNo.Text, txtIPDNo.Text);
                }
                else
                {

                }
            }


            if (Globals.username == "admin")
            {
                txtDiscount.Enabled = true;
                txtRefAmount.Enabled = true;
            }
            else
            {
                txtDiscount.Enabled = false;
                txtRefAmount.Enabled = false;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            { txtDiscount.Text = "0"; }
            lblNetAmt.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) - Convert.ToInt16(txtDiscount.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                insertReceipt();
                MessageBox.Show("Updated Successfully", "Congrats");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_SavePrint_Click(object sender, EventArgs e)
        {
            con.Open();
            insertReceipt();
            con.Close();
            frmReportViewer rpt = new frmReportViewer();
            rpt.rptName = "report/rptIPD.rdlc";
            rpt.dt = getReportDT();
            rpt.Show();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            frmReportViewer rpt = new frmReportViewer();
            rpt.rptName = "report/rptIPD.rdlc";
            rpt.dt = getReportDT();
            rpt.Show();
        }
        private DataTable getReportDT()
        {
            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT PatientName, BillDate, DoctorName_Old, UserName, OrgID, RelationType, Relation, Mobile, Age, Address, Gender, TotalAmount, Discount, NetAmount, NetAmountWords, TestID, tbl_testmaster.Price as Rate, RefAmount, DoctorID,tbl_cashreceipt.ID as BillNo, tbl_cashreceipt_details.Quantity as Qty, tbl_testmaster.Price*tbl_cashreceipt_details.Quantity as Amount,EmailAddress, tbl_testmaster.TestName, tblorg.OrgName, tblorg.OrgAddress, tblorg.OrgPhone, tblorg.OrgMobile1, tblorg.OrgMobile2, DATE_FORMAT(BillDate,'%d-%b-%Y') AS BillDateOnly FROM tbl_cashreceipt INNER JOIN tbl_cashreceipt_details ON tbl_cashreceipt.ID = tbl_cashreceipt_details.CashReceipt_ID INNER JOIN tbl_testmaster ON tbl_cashreceipt_details.test_ID = tbl_testmaster.ID INNER JOIN tblorg ON tbl_cashreceipt.OrgID = tblorg.ID where tbl_cashreceipt.PatientID = @patientId and tbl_cashreceipt_details.isPrintable=true and tbl_cashreceipt.ID=@ipdId;";
            cmd.Parameters.AddWithValue("@patientId", txtPatientNo.Text);
            cmd.Parameters.AddWithValue("@ipdId", txtIPDNo.Text);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void insertReceipt()
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "delete from tbl_cashreceipt_details where cashreceipt_ID = @id";
                cmd.Parameters.AddWithValue("@id", txtIPDNo.Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                DataTable bill_dt = new DataTable();
                bill_dt.Columns.Add("BillNo");
                DataRow drLocal = null;
                int discount;
                foreach (DataGridViewRow row in gvIPD.Rows)
                {
                    var IPDServiceID = row.Cells["IPDServiceID"].Value;
                    var BillNo = row.Cells["BillNo"].Value;
                    var Quantity = row.Cells["Quantity"].Value;
                    var isPrintable = row.Cells["isPrintable"].Value;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "insert into tbl_cashreceipt_details (cashreceipt_ID,test_ID,Quantity,isPrintable) values(@billNo,@testId,@qty,@isPrintable)";
                    cmd.Parameters.AddWithValue("@billNo", BillNo.ToString());
                    cmd.Parameters.AddWithValue("@testId", IPDServiceID.ToString());
                    cmd.Parameters.AddWithValue("@qty", Quantity.ToString());
                    cmd.Parameters.AddWithValue("@isPrintable", isPrintable);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    drLocal = bill_dt.NewRow();
                    drLocal["BillNo"] = BillNo;
                    bill_dt.Rows.Add(drLocal);
                }
                var list = from x in bill_dt.AsEnumerable()
                           group x by (string)x["BillNo"] into g
                           select g;

                var abc = list.ToArray().Length;
                discount = int.Parse(txtDiscount.Text) / list.ToList().Count();

                foreach (var x in list)
                {
                    var BillNo = x.Key;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE tbl_cashreceipt a INNER JOIN (select cashreceipt_ID,sum(Price*Quantity) as Amount from tbl_cashreceipt_details cd inner join tbl_testmaster tm on cd.test_ID=tm.ID group by cashreceipt_ID) b ON a.ID = b.cashreceipt_ID SET TotalAmount = b.Amount,Discount=@discount, NetAmount=b.Amount-@discount,isRefPaid=@isRefPaid,isIPD=true, isDischarged=@isDischarged where a.ID=@id";
                    cmd.Parameters.AddWithValue("@discount", discount);
                    cmd.Parameters.AddWithValue("@isRefPaid", chkRefPaid.Checked);
                    cmd.Parameters.AddWithValue("@isDischarged", chkDischarged.Checked);
                    cmd.Parameters.AddWithValue("@id", BillNo.ToString());
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }

                btn_Print.Enabled = true;
                //MessageBox.Show("Updated Successfully", "Congrats");
                LoadSearch(txtPatientNo.Text, txtIPDNo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void frmIPD_Load(object sender, EventArgs e)
        {
            getDoctorName();
            getGender();
            gbSearch.Visible = false;

        }
        private DataTable getTestName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select ID as TestID,concat(TestName,'-',Price) as TestName from tbl_testmaster where isDeleted=0 order by TestName";
            var abc = con;
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Tables[0];
        }
        private DataTable getIPDService()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = "select c.ID as BillNo,Quantity,BillDate,test_ID as IPDServiceID,Price,isRefPaid,CreatedDate,isPrintable from tbl_cashreceipt c inner join tbl_cashreceipt_details cd on c.ID=cd.cashreceipt_ID inner join tbl_testmaster tm on cd.test_ID=tm.ID where PatientID=@patientId and c.ID=@ipdId";
            cmd.Parameters.AddWithValue("@patientId", txtPatientNo.Text);
            cmd.Parameters.AddWithValue("@ipdId", txtIPDNo.Text);
            var abc = con;
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void LoadIPDServices()
        {
            try
            {
                var cmbTest = (DataGridViewComboBoxColumn)gvIPD.Columns["IPDService"];
                cmbTest.DisplayMember = "TestName";
                cmbTest.ValueMember = "TestID";
                cmbTest.DataSource = getTestName();
                cmbTest.DataPropertyName = "IPDServiceID";
                gvIPD.DataSource = getIPDService();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void gvIPD_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void btnNewService_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = getIPDService();
            var desRow = dt.NewRow();
            var sourceRow = dt.Rows[gvIPD.Rows.Count - 1];
            desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];
            dt.Rows.Add(desRow);

            gvIPD.DataSource = dt;
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = gvIPD.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            //DataGridViewTextBoxCell testID = (DataGridViewTextBoxCell)gvIPD.Rows[currentcell.Y].Cells[3];
            if (sendingCB.SelectedValue != null)
            {
                if (int.TryParse(sendingCB.SelectedValue.ToString(), out int value))
                {
                    gvIPD.CurrentRow.Cells["IPDServiceID"].Value = sendingCB.SelectedValue;
                    String price = ((DataRowView)sendingCB.SelectedItem).Row["TestName"].ToString();
                    gvIPD.CurrentRow.Cells["Price"].Value = price.Substring(price.LastIndexOf('-') + 1);
                }
            }

        }

        private void gvIPD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvIPD.CurrentCell.ColumnIndex == 7 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }
    }
}
