namespace Hospital_Management
{
    partial class frmAuditTrail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvAudit = new System.Windows.Forms.DataGridView();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDates = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(192, 14);
            this.cboUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(387, 23);
            this.cboUser.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(192, 57);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(184, 24);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(399, 57);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(180, 24);
            this.dtpTo.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(615, 94);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvAudit
            // 
            this.dgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudit.Location = new System.Drawing.Point(15, 133);
            this.dgvAudit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAudit.Name = "dgvAudit";
            this.dgvAudit.Size = new System.Drawing.Size(1254, 526);
            this.dgvAudit.TabIndex = 5;
            // 
            // cboAction
            // 
            this.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(192, 100);
            this.cboAction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(387, 26);
            this.cboAction.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUser.Location = new System.Drawing.Point(15, 24);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(73, 15);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "Select User:";
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDates.Location = new System.Drawing.Point(12, 64);
            this.lblDates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(115, 15);
            this.lblDates.TabIndex = 11;
            this.lblDates.Text = "From and To Dates:";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAction.Location = new System.Drawing.Point(12, 100);
            this.lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(46, 15);
            this.lblAction.TabIndex = 12;
            this.lblAction.Text = "Action: ";
            // 
            // frmAuditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 709);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblDates);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAudit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAuditTrail";
            this.Text = "Audit Trail";
            this.Load += new System.EventHandler(this.frmAuditTrail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvAudit;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.Label lblAction;
    }
}
