namespace Hospital_Management
{
    partial class frmAddNewDoctor
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.gvTest = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDocid = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(195, 251);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(112, 35);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(164, 59);
            this.txtDoctorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(360, 26);
            this.txtDoctorName.TabIndex = 0;
            // 
            // gvTest
            // 
            this.gvTest.AllowUserToAddRows = false;
            this.gvTest.AllowUserToDeleteRows = false;
            this.gvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTest.Location = new System.Drawing.Point(548, 27);
            this.gvTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTest.Name = "gvTest";
            this.gvTest.Size = new System.Drawing.Size(588, 550);
            this.gvTest.TabIndex = 4;
            this.gvTest.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvTest_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter Doctor Name";
            // 
            // lblDocid
            // 
            this.lblDocid.AutoSize = true;
            this.lblDocid.Location = new System.Drawing.Point(10, 371);
            this.lblDocid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocid.Name = "lblDocid";
            this.lblDocid.Size = new System.Drawing.Size(18, 20);
            this.lblDocid.TabIndex = 8;
            this.lblDocid.Text = "0";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(14, 115);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(448, 24);
            this.chkDelete.TabIndex = 1;
            this.chkDelete.Text = "Delete (This test will not appear on entry form dropdown list)";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // frmAddNewDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 613);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.lblDocid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtDoctorName);
            this.Controls.Add(this.gvTest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewDoctor";
            this.Text = "Add New Doctor Name";
            this.Load += new System.EventHandler(this.FrmAddNewDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.DataGridView gvTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDocid;
        private System.Windows.Forms.CheckBox chkDelete;
    }
}