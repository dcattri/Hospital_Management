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

    public partial class frmEntryForm : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        string searchtype;
        public frmEntryForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void frmEntryForm_Load(object sender, EventArgs e)
        {

            //dtpBillDate.Value = DateTime.Now.ToString("dd-MMM-yy");
            getTestName();
            getDoctorName();
            getGender();
            gbSearch.Visible = false;
            btn_Print.Enabled = false;
            AuditTrail.Log(Globals.username, nameof(frmEntryForm), "Open", "Entry form opened");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            insertReceipt();
            con.Close();
            AuditTrail.Log(Globals.username, nameof(frmEntryForm), "Save", "Saved a cash receipt");
        }
        private void btn_SavePrint_Click(object sender, EventArgs e)
        {
            con.Open();
            insertReceipt();
            con.Close();
            frmReportViewer rpt = new frmReportViewer();
            if (Globals.branch == "palwal")
            {
                rpt.rptName = "report/rptInvoice_palwal.rdlc";
            }
            else
            {
                rpt.rptName = "report/rptInvoice.rdlc";
            }

            rpt.dt = getReportDT();
            rpt.Show();
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            frmReportViewer rpt = new frmReportViewer();
            //rpt.rptName = "rptInvoice.rdlc";
            if (Globals.branch == "palwal")
            {
                rpt.rptName = "report/rptInvoice_palwal.rdlc";
            }
            else
            {
                rpt.rptName = "report/rptInvoice.rdlc";
            }
            rpt.dt = getReportDT();
            rpt.Show();

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
        private void insertReceipt()
        {
            try
            {
                if (txtName.Text != "" && txtMobile.Text != "" && TestID() > 0)
                {
                    lblNetAmt.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) - Convert.ToInt16(txtDiscount.Text));
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
                    if (txtBillNo.Text != "")
                    {
                        if (Globals.username == "admin" || (Globals.username != "admin" && chkIPD.Checked == true))
                        {
                            // Update main receipt
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update tbl_cashreceipt set PatientName=@pname, BillDate=@bdate, DoctorID=@docid, Relation=@relation, Mobile=@mobile, Age=@age, Address=@address, Gender=@gender, TotalAmount=@total, Discount=@discount, RefAmount=@refamt, NetAmount=@netamt, NetAmountWords=@networds, TestID=@testid, Rate=@rate, RelationType=@relationtype, isRefPaid=@isrefpaid, PatientID=@patientid, isIPD=@isipd where ID=@id";
                            cmd.Parameters.AddWithValue("@pname", txtName.Text);
                            cmd.Parameters.AddWithValue("@bdate", dtpBillDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@docid", cboDoctorName.SelectedValue);
                            cmd.Parameters.AddWithValue("@relation", txtRelation.Text);
                            cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@age", txtAge.Text);
                            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem);
                            cmd.Parameters.AddWithValue("@total", lblTotalAmount.Text);
                            cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);
                            cmd.Parameters.AddWithValue("@refamt", txtRefAmount.Text);
                            cmd.Parameters.AddWithValue("@netamt", lblNetAmt.Text);
                            cmd.Parameters.AddWithValue("@networds", ConvertToWords(lblNetAmt.Text));
                            cmd.Parameters.AddWithValue("@testid", TestID());
                            cmd.Parameters.AddWithValue("@rate", lblTotalAmount.Text);
                            cmd.Parameters.AddWithValue("@relationtype", relationtype);
                            cmd.Parameters.AddWithValue("@isrefpaid", chkRefPaid.Checked);
                            cmd.Parameters.AddWithValue("@patientid", string.IsNullOrWhiteSpace(txtPatientNo.Text) ? (object)DBNull.Value : txtPatientNo.Text);
                            cmd.Parameters.AddWithValue("@isipd", chkIPD.Checked);
                            cmd.Parameters.AddWithValue("@id", txtBillNo.Text);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();

                            // Delete existing details
                            cmd = con.CreateCommand();
                            cmd.CommandText = "delete from tbl_cashreceipt_details where cashreceipt_ID=@id";
                            cmd.Parameters.AddWithValue("@id", txtBillNo.Text);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();

                            // Insert details
                            foreach (object itemChecked in clbTestName.CheckedItems)
                            {
                                DataRowView castedItem = itemChecked as DataRowView;
                                int testid = (int)castedItem["TestID"];
                                cmd = con.CreateCommand();
                                cmd.CommandText = "insert into tbl_cashreceipt_details(cashreceipt_ID,test_ID) values(@id,@testid)";
                                cmd.Parameters.AddWithValue("@id", txtBillNo.Text);
                                cmd.Parameters.AddWithValue("@testid", testid);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                            }

                        }
                        else
                        {
                            MessageBox.Show("You are not Authorized to edit old records, contact admin", "Error");
                        }
                    }
                    else
                    {

                        cmd = con.CreateCommand();
                        cmd.CommandText = "Insert into tbl_cashreceipt(PatientName,BillDate,DoctorID,UserName,OrgID,Relation,Mobile,Age,Address,Gender,TotalAmount,Discount,RefAmount,NetAmount,NetAmountWords,TestID,Rate,RelationType, isRefPaid,PatientID,isIPD,isDischarged) Values(@pname,@bdate,@docid,@user,@orgid,@relation,@mobile,@age,@address,@gender,@total,@discount,@refamt,@netamt,@networds,@testid,@rate,@relationtype,@isrefpaid,@patientid,@isipd,@isdischarged); SELECT LAST_INSERT_ID();";
                        cmd.Parameters.AddWithValue("@pname", txtName.Text);
                        cmd.Parameters.AddWithValue("@bdate", dtpBillDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@docid", cboDoctorName.SelectedValue);
                        cmd.Parameters.AddWithValue("@user", Globals.username.ToString());
                        cmd.Parameters.AddWithValue("@orgid", 1);
                        cmd.Parameters.AddWithValue("@relation", txtRelation.Text);
                        cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem);
                        cmd.Parameters.AddWithValue("@total", lblTotalAmount.Text);
                        cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);
                        cmd.Parameters.AddWithValue("@refamt", txtRefAmount.Text);
                        cmd.Parameters.AddWithValue("@netamt", lblNetAmt.Text);
                        cmd.Parameters.AddWithValue("@networds", ConvertToWords(lblNetAmt.Text));
                        cmd.Parameters.AddWithValue("@testid", TestID());
                        cmd.Parameters.AddWithValue("@rate", lblTotalAmount.Text);
                        cmd.Parameters.AddWithValue("@relationtype", relationtype);
                        cmd.Parameters.AddWithValue("@isrefpaid", chkRefPaid.Checked);
                        cmd.Parameters.AddWithValue("@patientid", string.IsNullOrWhiteSpace(txtPatientNo.Text) ? (object)DBNull.Value : txtPatientNo.Text);
                        cmd.Parameters.AddWithValue("@isipd", chkIPD.Checked);
                        cmd.Parameters.AddWithValue("@isdischarged", false);
                        cmd.Connection = con;
                        var newId = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (object itemChecked in clbTestName.CheckedItems)
                        {
                            DataRowView castedItem = itemChecked as DataRowView;
                            int testid = (int)castedItem["TestID"];
                            cmd = con.CreateCommand();
                            cmd.CommandText = "insert into tbl_cashreceipt_details(cashreceipt_ID,test_ID) values(@id,@testid)";
                            cmd.Parameters.AddWithValue("@id", newId);
                            cmd.Parameters.AddWithValue("@testid", testid);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                        getBillNo();
                    }
                    btn_Print.Enabled = true;
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
            cmd.CommandText = "select max(id) as billno from tbl_cashreceipt";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            txtBillNo.Text = dt.Tables[0].Rows[0][0].ToString();
            dt.Clear();
        }
        private DataTable getReportDT()
        {
            DataSet dt = new DataSet();
            cmd.CommandText = "SELECT PatientName, BillDate, DoctorName_Old, UserName, OrgID, RelationType, Relation, Mobile, Age, Address, Gender, TotalAmount, Discount, NetAmount, NetAmountWords, TestID, tbl_testmaster.Price as Rate, RefAmount, DoctorID,tbl_cashreceipt.ID as BillNo, 1 as Qty, tbl_testmaster.Price as Amount,EmailAddress, tbl_testmaster.TestName, tblorg.OrgName, tblorg.OrgAddress, tblorg.OrgPhone, tblorg.OrgMobile1, tblorg.OrgMobile2, DATE_FORMAT(BillDate,'%d-%b-%Y') AS BillDateOnly FROM tbl_cashreceipt INNER JOIN tbl_cashreceipt_details ON tbl_cashreceipt.ID = tbl_cashreceipt_details.CashReceipt_ID INNER JOIN tbl_testmaster ON tbl_cashreceipt_details.test_ID = tbl_testmaster.ID INNER JOIN tblorg ON tbl_cashreceipt.OrgID = tblorg.ID where tbl_cashreceipt.ID = " + txtBillNo.Text + ";";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void getTestName()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select ID as TestID,concat(TestName,'-',Price) as TestName from tbl_testmaster where isDeleted=0 order by TestName";
            var abc = con;
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cbTestName.DataSource = dt.Tables[0];
            cbTestName.DisplayMember = "TestName";
            cbTestName.ValueMember = "TestID";

            cbTestName.BindingContext = this.BindingContext;

            ((ListBox)clbTestName).DataSource = dt.Tables[0];
            ((ListBox)clbTestName).DisplayMember = "TestName";
            ((ListBox)clbTestName).ValueMember = "TestID";

            //dt.Clear();
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
            if (searchtype == "Patient Search")
            { getPatientSearch(searchstring, searchwith); }
            else
            {
                DataSet dt = new DataSet();
                cmd = con.CreateCommand();
                if (searchwith == "BillNo")
                {
                    cmd.CommandText = "select ID,PatientName,BillDate,Mobile,DoctorName from vw_report where ID = @id order by BillDate desc";
                    cmd.Parameters.AddWithValue("@id", searchstring);
                }
                else
                {
                    cmd.CommandText = "select ID,PatientName,BillDate,Mobile,DoctorName from vw_report where " + searchwith + " like @search order by BillDate desc";
                    cmd.Parameters.AddWithValue("@search", "%" + searchstring + "%");
                }
                cmd.Connection = con;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                gvSearch.DataSource = dt.Tables[0];
                gvSearch.BindingContext = this.BindingContext;
            }
        }
        private void LoadSearch(string BillNo)
        {
            //btnSave.Enabled = false;
            //btn_SavePrint.Enabled = false;
            btn_Print.Enabled = true;

            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_cashreceipt where ID = @id;";
            cmd.Parameters.AddWithValue("@id", BillNo);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            txtBillNo.Text = dt.Tables[0].Rows[0]["ID"].ToString();
            txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
            txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
            txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
            txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
            txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
            if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); }
            ;
            txtRate.Text = dt.Tables[0].Rows[0]["Rate"].ToString();
            txtDiscount.Text = dt.Tables[0].Rows[0]["Discount"].ToString();
            txtRefAmount.Text = dt.Tables[0].Rows[0]["RefAmount"].ToString();
            if (txtRefAmount.Text == "") { txtRefAmount.Text = "0"; }
            lblTotalAmount.Text = dt.Tables[0].Rows[0]["TotalAmount"].ToString();
            lblNetAmt.Text = dt.Tables[0].Rows[0]["NetAmount"].ToString();
            dtpBillDate.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["BillDate"]);
            cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
            cbTestName.SelectedValue = dt.Tables[0].Rows[0]["TestID"].ToString();
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }
            chkRefPaid.Checked = (bool)dt.Tables[0].Rows[0]["isRefPaid"];
            txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
            chkIPD.Checked = (bool)dt.Tables[0].Rows[0]["isIPD"];

            dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_cashreceipt_details where cashreceipt_ID = @id;";
            cmd.Parameters.AddWithValue("@id", BillNo);
            cmd.Connection = con;
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            //DataRowView castedItem = itemChecked as DataRowView;
            //int testid = (int)castedItem["TestID"];
            for (int i = 0; i <= clbTestName.Items.Count - 1; i++)
            {
                clbTestName.SetItemChecked(i, false);
            }
            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= clbTestName.Items.Count - 1; i++)
                {
                    foreach (DataRow dr in dt.Tables[0].Rows)
                    {
                        if (dr["test_ID"].ToString() == ((DataRowView)clbTestName.Items[i])["TestID"].ToString())
                        {
                            clbTestName.SetItemChecked(i, true);
                        }

                    }
                }
            }

            frmMain mainForm = new frmMain();
            if (Globals.username == "admin")
            {
                txtRate.Enabled = true;
                txtDiscount.Enabled = true;
                txtRefAmount.Enabled = true;
            }
            else
            {
                txtRate.Enabled = false;
                txtDiscount.Enabled = false;
                txtRefAmount.Enabled = false;
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            //lblTotalAmount.Text = txtRate.Text;
            //if (txtDiscount.Text == "")
            //{ txtDiscount.Text = "0"; }
            //if (txtRate.Text == "")
            //{ txtRate.Text = "0"; }
            //lblNetAmt.Text = Convert.ToString(Convert.ToInt16(txtRate.Text) - Convert.ToInt16(txtDiscount.Text));
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //lblTotalAmount.Text = txtRate.Text;
            if (txtDiscount.Text == "")
            { txtDiscount.Text = "0"; }
            if (txtRate.Text == "")
            { txtRate.Text = "0"; }
            lblNetAmt.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) - Convert.ToInt16(txtDiscount.Text));
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //(e.KeyChar != '.'))
            //      {
            //          e.Handled = true;
            //      }

            //      // only allow one decimal point
            //      if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //      {
            //          e.Handled = true;
            //      }
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
            lblSearchNo.Text = "Search By Bill No";
            gbSearch.Visible = true;
            searchtype = "search";
        }

        private void txtSearchBillNo_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchBillNo.Text.Length >= 4)
            {
                txtSearchMobile.Text = "";
                txtSearchName.Text = "";
                if (searchtype == "search")
                { getSearch(txtSearchBillNo.Text, "BillNo"); }
                else if (searchtype == "Patient Search")
                { getPatientSearch(txtSearchBillNo.Text, "PatientID"); }
                else
                { }

            }

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchName.Text.Length >= 3)
            {
                txtSearchMobile.Text = "";
                txtSearchBillNo.Text = "";
                if (searchtype == "search")
                { getSearch(txtSearchName.Text, "PatientName"); }
                else if (searchtype == "Patient Search")
                { getPatientSearch(txtSearchName.Text, "PatientName"); }
                else
                { }

            }
        }

        private void txtSearchMobile_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchMobile.Text.Length >= 3)
            {
                txtSearchName.Text = "";
                txtSearchBillNo.Text = "";
                if (searchtype == "search")
                { getSearch(txtSearchMobile.Text, "Mobile"); }
                else if (searchtype == "Patient Search")
                { getPatientSearch(txtSearchMobile.Text, "Mobile"); }
                else { }

            }
        }

        private void gvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = gvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
            con.Open();
            if (searchtype == "Patient Search")
            {
                LoadPatientSearch(cellValue);
            }
            else if (searchtype == "search")
            { LoadSearch(cellValue); }
            else
            { }
            gbSearch.Visible = false;
            con.Close();
        }

        public void btnFormF_Click(object sender, EventArgs e)
        {
            if (txtBillNo.Text.ToString().Length > 2)
            {
                if (clbTestName.CheckedItems.Count > 1)
                {
                    MessageBox.Show("Unable to print FormF with more than one test selected. FromF is only applicable for single Test selected at a time.", "Error");
                }
                else
                {
                    frmFormF formF = new frmFormF();
                    formF.txtBillNo.Text = txtBillNo.Text;
                    //((frmFormF)Owner).txtBillNo.Text = txtBillNo.Text;
                    formF.Show();
                    formF.LoadSearch(txtBillNo.Text);
                }
            }
            else
            {
                MessageBox.Show("Unable to print FormF without valid Bill No. First select a Bill No then try printing FormF", "Error");
            }

        }

        private void cbTestName_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*String price = ((DataRowView)cbTestName.SelectedItem).Row["TestName"].ToString();

            if (!String.IsNullOrEmpty(price))
            {
                var result = price.Substring(price.LastIndexOf('-') + 1);
                txtRate.Text = result;
            }
            else
            {
                txtRate.Text = "";
            }
            */
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //getTestName();
            //getDoctorName();
            //getGender();
            gbSearch.Visible = false;
            btn_Print.Enabled = false;
            txtBillNo.Text = "";
            txtName.Text = "";
            txtRefAmount.Text = "0";
            txtRelation.Text = "";
            txtSearchMobile.Text = "";
            txtSearchName.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtDiscount.Text = "0";
            txtMobile.Text = "";
            lblNetAmt.Text = "0";
            lblTotalAmount.Text = "0";
            rbWife.Checked = true;
            rbSon.Checked = false;
            rbDaughter.Checked = false;
            dtpBillDate.Value = DateTime.Now;
            txtRate.Enabled = true;
            txtDiscount.Enabled = true;
            txtRefAmount.Enabled = true;
            chkIPD.Checked = false;
            chkRefPaid.Checked = false;
            txtPatientNo.Text = "";
            for (int i = 0; i <= clbTestName.Items.Count - 1; i++)
            {
                clbTestName.SetItemChecked(i, false);
            }
        }

        private void clbTestName_ItemCheck(object sender, ItemCheckEventArgs e)
        {


            lblTotalAmount.Text = "0";
            String price = ((DataRowView)clbTestName.SelectedItem).Row["TestName"].ToString();
            var result = price.Substring(price.LastIndexOf('-') + 1);
            if (e.NewValue == CheckState.Checked)
            {
                lblTotalAmount.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) + Convert.ToInt16(result));
            }
            else
            {
                lblTotalAmount.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) - Convert.ToInt16(result));
            }
            string checkedItems = string.Empty;

            foreach (object Item in clbTestName.CheckedItems)
            {
                checkedItems += Item.ToString();
                result = clbTestName.GetItemText(Item).Substring(clbTestName.GetItemText(Item).LastIndexOf('-') + 1);
                lblTotalAmount.Text = Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) + Convert.ToInt16(result));
                //MessageBox.Show(clbTestName.GetItemText(Item));
            }

            lblNetAmt.Text = (Convert.ToInt16(lblTotalAmount.Text) - Convert.ToInt16(txtDiscount.Text)).ToString();


            //String price = ((DataRowView)clbTestName.SelectedItem).Row["TestName"].ToString();

            //if (!String.IsNullOrEmpty(price))
            //{
            //    var result = price.Substring(price.LastIndexOf('-') + 1);
            //    lblTotalAmount.Text= Convert.ToString(Convert.ToInt16(lblTotalAmount.Text) + Convert.ToInt16(result));
            //}
            //else
            //{
            //    lblTotalAmount.Text = "0";
            //}


        }
        private int TestID()
        {
            int testid = 0;
            foreach (object itemChecked in clbTestName.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                testid = (int)castedItem["TestID"];
            }
            return testid;
        }

        private void chkRefPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.username != "admin" && chkRefPaid.Checked == false)
            {
                MessageBox.Show("You need admin rights to mark Unpaid");
                chkRefPaid.Checked = true;
            }
            if (txtBillNo.Text != "")
            {
                if (chkRefPaid.Checked == false)
                { AuditTrail.Log(Globals.username, nameof(frmEntryForm), "Open", "Ref unpaid marked for billno: " + txtBillNo.Text); }
                else
                { AuditTrail.Log(Globals.username, nameof(frmEntryForm), "Open", "Ref paid marked for billno: " + txtBillNo.Text); }
            }
            //if (Globals.username != "admin" && chkRefPaid.Checked == true)
            //{
            //    MessageBox.Show("You need admin rights to mark paid");
            //    chkRefPaid.Checked = false;
            //}
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            lblSearchNo.Text = "Search By Patient No";
            gbSearch.Visible = true;
            searchtype = "Patient Search";
            getSearch("", "");
        }

        private void frmEntryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gbSearch.Visible = false;
            }
        }
        private void getPatientSearch(string searchstring, string searchwith)
        {
            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            if (searchwith == "")
            { cmd.CommandText = "select PatientID,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient order by CreatedDate desc limit 50"; }
            else
            { cmd.CommandText = "select PatientID,PatientName,RelationType,Relation,CreatedDate,Mobile from tbl_patient where " + searchwith + " like @search order by CreatedDate desc limit 50"; cmd.Parameters.AddWithValue("@search", "%" + searchstring + "%"); }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            gvSearch.DataSource = dt.Tables[0];
            gvSearch.BindingContext = this.BindingContext;
        }
        private void LoadPatientSearch(string PatientNo)
        {
            //btnSave.Enabled = false;
            //btn_SavePrint.Enabled = false;

            DataSet dt = new DataSet();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_patient where PatientID = @id;";
            cmd.Parameters.AddWithValue("@id", PatientNo);
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            txtPatientNo.Text = dt.Tables[0].Rows[0]["PatientID"].ToString();
            txtName.Text = dt.Tables[0].Rows[0]["PatientName"].ToString();
            txtRelation.Text = dt.Tables[0].Rows[0]["Relation"].ToString();
            txtMobile.Text = dt.Tables[0].Rows[0]["Mobile"].ToString();
            txtAge.Text = dt.Tables[0].Rows[0]["Age"].ToString();
            txtAddress.Text = dt.Tables[0].Rows[0]["Address"].ToString();
            if (dt.Tables[0].Rows[0]["DoctorID"].ToString() == "") { cboDoctorName.SelectedValue = 2; } else { cboDoctorName.SelectedValue = dt.Tables[0].Rows[0]["DoctorID"].ToString(); }
            ;
            //dtpBillDate.Value = Convert.ToDateTime(dt.Tables[0].Rows[0]["CreatedDate"]);
            cbGender.SelectedItem = dt.Tables[0].Rows[0]["Gender"].ToString();
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "W/o") { rbWife.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "S/o") { rbSon.Checked = true; }
            if (dt.Tables[0].Rows[0]["RelationType"].ToString() == "D/o") { rbDaughter.Checked = true; }

            //frmMain mainForm = new frmMain();
        }
    }
}
