
namespace Hospital_Management
{
    partial class frmWhatsApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgPatientList = new System.Windows.Forms.DataGridView();
            this.btnPaid = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.chk1000 = new System.Windows.Forms.CheckBox();
            this.progress_msg = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dgPatientList);
            this.groupBox1.Location = new System.Drawing.Point(16, 192);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Size = new System.Drawing.Size(1156, 576);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient List";
            // 
            // dgPatientList
            // 
            this.dgPatientList.AllowUserToAddRows = false;
            this.dgPatientList.AllowUserToDeleteRows = false;
            this.dgPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatientList.Location = new System.Drawing.Point(6, 27);
            this.dgPatientList.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dgPatientList.Name = "dgPatientList";
            this.dgPatientList.Size = new System.Drawing.Size(1144, 541);
            this.dgPatientList.TabIndex = 0;
            this.dgPatientList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatientList_CellContentClick);
            // 
            // btnPaid
            // 
            this.btnPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaid.Location = new System.Drawing.Point(1260, 1052);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(564, 54);
            this.btnPaid.TabIndex = 51;
            this.btnPaid.Text = "Mark Referral Amount as Paid for selected doctor";
            this.btnPaid.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1864, 1052);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(168, 54);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Select Template Name";
            // 
            // cboTemplate
            // 
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(215, 10);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(753, 28);
            this.cboTemplate.TabIndex = 55;
            this.cboTemplate.SelectedIndexChanged += new System.EventHandler(this.cboTemplate_SelectedIndexChanged);
            this.cboTemplate.SelectedValueChanged += new System.EventHandler(this.cboTemplate_SelectedValueChanged);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(887, 779);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(279, 30);
            this.btn_Send.TabIndex = 56;
            this.btn_Send.Text = "Send Message to selected patients";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(40, 44);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(928, 146);
            this.txtMsg.TabIndex = 57;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.Checked = true;
            this.chkTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTest.Location = new System.Drawing.Point(986, 11);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(128, 24);
            this.chkTest.TabIndex = 58;
            this.chkTest.Text = "Test Message";
            this.chkTest.UseVisualStyleBackColor = true;
            this.chkTest.CheckedChanged += new System.EventHandler(this.chkTest_CheckedChanged);
            // 
            // chk1000
            // 
            this.chk1000.AutoSize = true;
            this.chk1000.Location = new System.Drawing.Point(986, 164);
            this.chk1000.Name = "chk1000";
            this.chk1000.Size = new System.Drawing.Size(138, 24);
            this.chk1000.TabIndex = 59;
            this.chk1000.Text = "Select next 100";
            this.chk1000.UseVisualStyleBackColor = true;
            this.chk1000.CheckedChanged += new System.EventHandler(this.chk1000_CheckedChanged);
            // 
            // progress_msg
            // 
            this.progress_msg.Location = new System.Drawing.Point(22, 780);
            this.progress_msg.Name = "progress_msg";
            this.progress_msg.Size = new System.Drawing.Size(859, 23);
            this.progress_msg.TabIndex = 60;
            // 
            // frmWhatsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 821);
            this.Controls.Add(this.progress_msg);
            this.Controls.Add(this.chk1000);
            this.Controls.Add(this.chkTest);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.cboTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmWhatsApp";
            this.Text = "Send WhatsApp Message";
            this.Load += new System.EventHandler(this.frmWhatsApp_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgPatientList;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.CheckBox chkTest;
        private System.Windows.Forms.CheckBox chk1000;
        private System.Windows.Forms.ProgressBar progress_msg;
    }
}