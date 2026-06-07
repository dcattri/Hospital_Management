
namespace Hospital_Management
{
    partial class frmIPD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkRefPaid = new System.Windows.Forms.CheckBox();
            this.txtRefAmount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.txtSearchMobile = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSearchNo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboDoctorName = new System.Windows.Forms.ComboBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.txtPatientNo = new System.Windows.Forms.TextBox();
            this.txtSearchBillNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewService = new System.Windows.Forms.Button();
            this.gvIPD = new System.Windows.Forms.DataGridView();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPDServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPDService = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRefPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPrintable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNetAmt = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSon = new System.Windows.Forms.RadioButton();
            this.rbDaughter = new System.Windows.Forms.RadioButton();
            this.rbWife = new System.Windows.Forms.RadioButton();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SavePrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.chkDischarged = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIPDNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIPD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRefPaid
            // 
            this.chkRefPaid.AutoSize = true;
            this.chkRefPaid.Location = new System.Drawing.Point(1144, 443);
            this.chkRefPaid.Name = "chkRefPaid";
            this.chkRefPaid.Size = new System.Drawing.Size(15, 14);
            this.chkRefPaid.TabIndex = 57;
            this.chkRefPaid.UseVisualStyleBackColor = true;
            this.chkRefPaid.CheckedChanged += new System.EventHandler(this.chkRefPaid_CheckedChanged);
            // 
            // txtRefAmount
            // 
            this.txtRefAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefAmount.Location = new System.Drawing.Point(804, 471);
            this.txtRefAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefAmount.Name = "txtRefAmount";
            this.txtRefAmount.Size = new System.Drawing.Size(163, 26);
            this.txtRefAmount.TabIndex = 53;
            this.txtRefAmount.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(117, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 20);
            this.label18.TabIndex = 86;
            this.label18.Text = "Patient No :";
            // 
            // gvSearch
            // 
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Location = new System.Drawing.Point(14, 99);
            this.gvSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.RowHeadersWidth = 62;
            this.gvSearch.Size = new System.Drawing.Size(1189, 665);
            this.gvSearch.TabIndex = 6;
            this.gvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSearch_CellDoubleClick);
            this.gvSearch.DoubleClick += new System.EventHandler(this.gvSearch_DoubleClick);
            // 
            // txtSearchMobile
            // 
            this.txtSearchMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchMobile.Location = new System.Drawing.Point(965, 46);
            this.txtSearchMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMobile.Name = "txtSearchMobile";
            this.txtSearchMobile.Size = new System.Drawing.Size(238, 26);
            this.txtSearchMobile.TabIndex = 5;
            this.txtSearchMobile.TextChanged += new System.EventHandler(this.txtSearchMobile_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(825, 49);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "Search By Mobile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1015, 441);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Is Referral Paid:";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.Location = new System.Drawing.Point(610, 46);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(182, 26);
            this.txtSearchName.TabIndex = 3;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(420, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Search By Patient Name";
            // 
            // lblSearchNo
            // 
            this.lblSearchNo.AutoSize = true;
            this.lblSearchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchNo.Location = new System.Drawing.Point(17, 49);
            this.lblSearchNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchNo.Name = "lblSearchNo";
            this.lblSearchNo.Size = new System.Drawing.Size(130, 20);
            this.lblSearchNo.TabIndex = 0;
            this.lblSearchNo.Text = "Search By Bill No";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(236, 100);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(358, 26);
            this.txtName.TabIndex = 58;
            // 
            // cboDoctorName
            // 
            this.cboDoctorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDoctorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDoctorName.FormattingEnabled = true;
            this.cboDoctorName.Location = new System.Drawing.Point(844, 232);
            this.cboDoctorName.Margin = new System.Windows.Forms.Padding(4);
            this.cboDoctorName.Name = "cboDoctorName";
            this.cboDoctorName.Size = new System.Drawing.Size(358, 28);
            this.cboDoctorName.TabIndex = 66;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.Location = new System.Drawing.Point(602, 47);
            this.btnSearchPatient.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(127, 35);
            this.btnSearchPatient.TabIndex = 84;
            this.btnSearchPatient.Text = "Search Patient";
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.Enabled = false;
            this.txtPatientNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNo.Location = new System.Drawing.Point(236, 54);
            this.txtPatientNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.Size = new System.Drawing.Size(358, 26);
            this.txtPatientNo.TabIndex = 85;
            // 
            // txtSearchBillNo
            // 
            this.txtSearchBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBillNo.Location = new System.Drawing.Point(184, 46);
            this.txtSearchBillNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchBillNo.Name = "txtSearchBillNo";
            this.txtSearchBillNo.Size = new System.Drawing.Size(173, 26);
            this.txtSearchBillNo.TabIndex = 2;
            this.txtSearchBillNo.TextChanged += new System.EventHandler(this.txtSearchBillNo_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(634, 474);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 20);
            this.label17.TabIndex = 54;
            this.label17.Text = "Referral Amount :";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.gvSearch);
            this.gbSearch.Controls.Add(this.txtSearchMobile);
            this.gbSearch.Controls.Add(this.label16);
            this.gbSearch.Controls.Add(this.txtSearchName);
            this.gbSearch.Controls.Add(this.txtSearchBillNo);
            this.gbSearch.Controls.Add(this.label15);
            this.gbSearch.Controls.Add(this.lblSearchNo);
            this.gbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(13, 38);
            this.gbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Padding = new System.Windows.Forms.Padding(4);
            this.gbSearch.Size = new System.Drawing.Size(1210, 791);
            this.gbSearch.TabIndex = 79;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDischarged);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnNewService);
            this.groupBox2.Controls.Add(this.gvIPD);
            this.groupBox2.Controls.Add(this.chkRefPaid);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRefAmount);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblNetAmt);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblTotalAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 276);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1197, 511);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IPD Services";
            // 
            // btnNewService
            // 
            this.btnNewService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewService.Location = new System.Drawing.Point(1019, 27);
            this.btnNewService.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewService.Name = "btnNewService";
            this.btnNewService.Size = new System.Drawing.Size(157, 35);
            this.btnNewService.TabIndex = 87;
            this.btnNewService.Text = "Add New Service";
            this.btnNewService.UseVisualStyleBackColor = true;
            this.btnNewService.Click += new System.EventHandler(this.btnNewService_Click);
            // 
            // gvIPD
            // 
            this.gvIPD.AllowUserToAddRows = false;
            this.gvIPD.AllowUserToDeleteRows = false;
            this.gvIPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIPD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNo,
            this.BillDate,
            this.IPDServiceID,
            this.IPDService,
            this.Price,
            this.Quantity,
            this.isRefPaid,
            this.isPrintable});
            this.gvIPD.Location = new System.Drawing.Point(19, 66);
            this.gvIPD.Name = "gvIPD";
            this.gvIPD.Size = new System.Drawing.Size(1158, 356);
            this.gvIPD.TabIndex = 58;
            this.gvIPD.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvIPD_EditingControlShowing);
            this.gvIPD.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvIPD_RowsAdded);
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "BillNo";
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            // 
            // BillDate
            // 
            this.BillDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BillDate.DataPropertyName = "BillDate";
            this.BillDate.HeaderText = "AdmissionDate";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 142;
            // 
            // IPDServiceID
            // 
            this.IPDServiceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IPDServiceID.DataPropertyName = "IPDServiceID";
            this.IPDServiceID.HeaderText = "IPDServiceID";
            this.IPDServiceID.Name = "IPDServiceID";
            this.IPDServiceID.ReadOnly = true;
            this.IPDServiceID.Width = 130;
            // 
            // IPDService
            // 
            this.IPDService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IPDService.DataPropertyName = "TestID";
            this.IPDService.HeaderText = "IPD Service Name";
            this.IPDService.Name = "IPDService";
            this.IPDService.Width = 130;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // isRefPaid
            // 
            this.isRefPaid.DataPropertyName = "isRefPaid";
            this.isRefPaid.HeaderText = "isRefPaid";
            this.isRefPaid.Name = "isRefPaid";
            this.isRefPaid.ReadOnly = true;
            // 
            // isPrintable
            // 
            this.isPrintable.DataPropertyName = "isPrintable";
            this.isPrintable.HeaderText = "Print";
            this.isPrintable.Name = "isPrintable";
            this.isPrintable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isPrintable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(175, 435);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(358, 26);
            this.txtDiscount.TabIndex = 12;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 441);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 20);
            this.label13.TabIndex = 50;
            this.label13.Text = "Total Discount :";
            // 
            // lblNetAmt
            // 
            this.lblNetAmt.AutoSize = true;
            this.lblNetAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmt.Location = new System.Drawing.Point(800, 441);
            this.lblNetAmt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetAmt.Name = "lblNetAmt";
            this.lblNetAmt.Size = new System.Drawing.Size(18, 20);
            this.lblNetAmt.TabIndex = 49;
            this.lblNetAmt.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(665, 441);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 20);
            this.label12.TabIndex = 48;
            this.label12.Text = "Net Amount :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(171, 477);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(18, 20);
            this.lblTotalAmount.TabIndex = 47;
            this.lblTotalAmount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 477);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Total Amount :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSon);
            this.groupBox1.Controls.Add(this.rbDaughter);
            this.groupBox1.Controls.Add(this.rbWife);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 130);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(192, 43);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // rbSon
            // 
            this.rbSon.AutoSize = true;
            this.rbSon.Enabled = false;
            this.rbSon.Location = new System.Drawing.Point(130, 16);
            this.rbSon.Margin = new System.Windows.Forms.Padding(4);
            this.rbSon.Name = "rbSon";
            this.rbSon.Size = new System.Drawing.Size(51, 24);
            this.rbSon.TabIndex = 28;
            this.rbSon.TabStop = true;
            this.rbSon.Text = "S/o";
            this.rbSon.UseVisualStyleBackColor = true;
            // 
            // rbDaughter
            // 
            this.rbDaughter.AutoSize = true;
            this.rbDaughter.Enabled = false;
            this.rbDaughter.Location = new System.Drawing.Point(73, 16);
            this.rbDaughter.Margin = new System.Windows.Forms.Padding(4);
            this.rbDaughter.Name = "rbDaughter";
            this.rbDaughter.Size = new System.Drawing.Size(52, 24);
            this.rbDaughter.TabIndex = 27;
            this.rbDaughter.TabStop = true;
            this.rbDaughter.Text = "D/o";
            this.rbDaughter.UseVisualStyleBackColor = true;
            // 
            // rbWife
            // 
            this.rbWife.AutoSize = true;
            this.rbWife.Enabled = false;
            this.rbWife.Location = new System.Drawing.Point(10, 16);
            this.rbWife.Margin = new System.Windows.Forms.Padding(4);
            this.rbWife.Name = "rbWife";
            this.rbWife.Size = new System.Drawing.Size(55, 24);
            this.rbWife.TabIndex = 26;
            this.rbWife.TabStop = true;
            this.rbWife.Text = "W/o";
            this.rbWife.UseVisualStyleBackColor = true;
            // 
            // txtMobile
            // 
            this.txtMobile.Enabled = false;
            this.txtMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(239, 232);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(358, 26);
            this.txtMobile.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 75;
            this.label3.Text = "Mobile No :";
            // 
            // txtRelation
            // 
            this.txtRelation.Enabled = false;
            this.txtRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelation.Location = new System.Drawing.Point(236, 146);
            this.txtRelation.Margin = new System.Windows.Forms.Padding(4);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.Size = new System.Drawing.Size(358, 26);
            this.txtRelation.TabIndex = 60;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(1079, 795);
            this.btn_Print.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(144, 37);
            this.btn_Print.TabIndex = 73;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SavePrint
            // 
            this.btn_SavePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SavePrint.Location = new System.Drawing.Point(909, 795);
            this.btn_SavePrint.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SavePrint.Name = "btn_SavePrint";
            this.btn_SavePrint.Size = new System.Drawing.Size(165, 37);
            this.btn_SavePrint.TabIndex = 71;
            this.btn_SavePrint.Text = "Save and Print";
            this.btn_SavePrint.UseVisualStyleBackColor = true;
            this.btn_SavePrint.Click += new System.EventHandler(this.btn_SavePrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(762, 795);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 37);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(95, 103);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 69;
            this.label11.Text = "Patient Name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(641, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Reference Doctor : ";
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(236, 185);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(89, 26);
            this.txtAge.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Age/Sex :";
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(845, 104);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(358, 103);
            this.txtAddress.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(724, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Address :";
            // 
            // cbGender
            // 
            this.cbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGender.Enabled = false;
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(365, 185);
            this.cbGender.Margin = new System.Windows.Forms.Padding(4);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(229, 28);
            this.cbGender.TabIndex = 62;
            // 
            // chkDischarged
            // 
            this.chkDischarged.AutoSize = true;
            this.chkDischarged.Location = new System.Drawing.Point(1144, 479);
            this.chkDischarged.Name = "chkDischarged";
            this.chkDischarged.Size = new System.Drawing.Size(15, 14);
            this.chkDischarged.TabIndex = 89;
            this.chkDischarged.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1024, 477);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "is Discharged: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(746, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 88;
            this.label7.Text = "IPD No :";
            // 
            // txtIPDNo
            // 
            this.txtIPDNo.Enabled = false;
            this.txtIPDNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPDNo.Location = new System.Drawing.Point(842, 56);
            this.txtIPDNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPDNo.Name = "txtIPDNo";
            this.txtIPDNo.Size = new System.Drawing.Size(360, 26);
            this.txtIPDNo.TabIndex = 87;
            // 
            // frmIPD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1252, 842);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboDoctorName);
            this.Controls.Add(this.btnSearchPatient);
            this.Controls.Add(this.txtPatientNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRelation);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_SavePrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIPDNo);
            this.MaximizeBox = false;
            this.Name = "frmIPD";
            this.Text = "IPD Patient Details";
            this.Load += new System.EventHandler(this.frmIPD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIPD_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIPD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRefPaid;
        private System.Windows.Forms.TextBox txtRefAmount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.TextBox txtSearchMobile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSearchNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboDoctorName;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.TextBox txtPatientNo;
        private System.Windows.Forms.TextBox txtSearchBillNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNetAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSon;
        private System.Windows.Forms.RadioButton rbDaughter;
        private System.Windows.Forms.RadioButton rbWife;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_SavePrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.DataGridView gvIPD;
        private System.Windows.Forms.Button btnNewService;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPDServiceID;
        private System.Windows.Forms.DataGridViewComboBoxColumn IPDService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRefPaid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPrintable;
        private System.Windows.Forms.CheckBox chkDischarged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIPDNo;
    }
}