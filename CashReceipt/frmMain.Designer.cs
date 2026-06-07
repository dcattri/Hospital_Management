namespace Hospital_Management
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referalAmountListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCollectionReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.formFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatsAppMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRef = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer_scroll = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPatientToolStripMenuItem,
            this.cashReceiptToolStripMenuItem,
            this.addTestToolStripMenuItem,
            this.addDoctorToolStripMenuItem,
            this.dailyExpensesToolStripMenuItem,
            this.referalAmountListToolStripMenuItem,
            this.dailyCollectionReportToolStripMenuItem1,
            this.formFToolStripMenuItem1,
            this.adminToolStripMenuItem,
            this.iPDToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1618, 60);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addPatientToolStripMenuItem
            // 
            this.addPatientToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.addPatientToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.patient;
            this.addPatientToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addPatientToolStripMenuItem.Name = "addPatientToolStripMenuItem";
            this.addPatientToolStripMenuItem.Size = new System.Drawing.Size(151, 54);
            this.addPatientToolStripMenuItem.Text = "Add Patient";
            this.addPatientToolStripMenuItem.Click += new System.EventHandler(this.addPatientToolStripMenuItem_Click);
            // 
            // cashReceiptToolStripMenuItem
            // 
            this.cashReceiptToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cashReceiptToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.receiptlogo;
            this.cashReceiptToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cashReceiptToolStripMenuItem.Name = "cashReceiptToolStripMenuItem";
            this.cashReceiptToolStripMenuItem.Size = new System.Drawing.Size(161, 54);
            this.cashReceiptToolStripMenuItem.Text = "Cash Receipt";
            this.cashReceiptToolStripMenuItem.Click += new System.EventHandler(this.cashReceiptToolStripMenuItem_Click);
            // 
            // addTestToolStripMenuItem
            // 
            this.addTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.addTestToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.medicaltest;
            this.addTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addTestToolStripMenuItem.Name = "addTestToolStripMenuItem";
            this.addTestToolStripMenuItem.Size = new System.Drawing.Size(130, 54);
            this.addTestToolStripMenuItem.Text = "Add Test";
            this.addTestToolStripMenuItem.Click += new System.EventHandler(this.addTestToolStripMenuItem_Click);
            // 
            // addDoctorToolStripMenuItem
            // 
            this.addDoctorToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.addDoctorToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.doctor;
            this.addDoctorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addDoctorToolStripMenuItem.Name = "addDoctorToolStripMenuItem";
            this.addDoctorToolStripMenuItem.Size = new System.Drawing.Size(151, 54);
            this.addDoctorToolStripMenuItem.Text = "Add Doctor";
            this.addDoctorToolStripMenuItem.Click += new System.EventHandler(this.addDoctorToolStripMenuItem_Click);
            // 
            // dailyExpensesToolStripMenuItem
            // 
            this.dailyExpensesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dailyExpensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dailyExpensesToolStripMenuItem.Image")));
            this.dailyExpensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dailyExpensesToolStripMenuItem.Name = "dailyExpensesToolStripMenuItem";
            this.dailyExpensesToolStripMenuItem.Size = new System.Drawing.Size(174, 54);
            this.dailyExpensesToolStripMenuItem.Text = "Daily Expenses";
            this.dailyExpensesToolStripMenuItem.Click += new System.EventHandler(this.dailyExpensesToolStripMenuItem_Click);
            // 
            // referalAmountListToolStripMenuItem
            // 
            this.referalAmountListToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.referalAmountListToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.rupee;
            this.referalAmountListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.referalAmountListToolStripMenuItem.Name = "referalAmountListToolStripMenuItem";
            this.referalAmountListToolStripMenuItem.Size = new System.Drawing.Size(214, 54);
            this.referalAmountListToolStripMenuItem.Text = "Referal Amount List";
            this.referalAmountListToolStripMenuItem.Click += new System.EventHandler(this.referalAmountListToolStripMenuItem_Click);
            // 
            // dailyCollectionReportToolStripMenuItem1
            // 
            this.dailyCollectionReportToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dailyCollectionReportToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("dailyCollectionReportToolStripMenuItem1.Image")));
            this.dailyCollectionReportToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dailyCollectionReportToolStripMenuItem1.Name = "dailyCollectionReportToolStripMenuItem1";
            this.dailyCollectionReportToolStripMenuItem1.Size = new System.Drawing.Size(231, 54);
            this.dailyCollectionReportToolStripMenuItem1.Text = "Daily Collection Report";
            this.dailyCollectionReportToolStripMenuItem1.Click += new System.EventHandler(this.dailyCollectionReportToolStripMenuItem1_Click);
            // 
            // formFToolStripMenuItem1
            // 
            this.formFToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formFToolStripMenuItem1.Image = global::Hospital_Management.Properties.Resources.formF;
            this.formFToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.formFToolStripMenuItem1.Name = "formFToolStripMenuItem1";
            this.formFToolStripMenuItem1.Size = new System.Drawing.Size(121, 54);
            this.formFToolStripMenuItem1.Text = "Form F";
            this.formFToolStripMenuItem1.Click += new System.EventHandler(this.formFToolStripMenuItem1_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserToolStripMenuItem,
            this.myProfileToolStripMenuItem,
            this.RunScriptToolStripMenuItem,
            this.whatsAppMessageToolStripMenuItem,
            this.auditTrailToolStripMenuItem});
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.Admin;
            this.adminToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(118, 54);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.myProfileToolStripMenuItem.Text = "My Profile";
            this.myProfileToolStripMenuItem.Click += new System.EventHandler(this.myProfileToolStripMenuItem_Click);
            // 
            // RunScriptToolStripMenuItem
            // 
            this.RunScriptToolStripMenuItem.Name = "RunScriptToolStripMenuItem";
            this.RunScriptToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.RunScriptToolStripMenuItem.Text = "Run Script";
            this.RunScriptToolStripMenuItem.Click += new System.EventHandler(this.RunScriptToolStripMenuItem_Click);
            // 
            // whatsAppMessageToolStripMenuItem
            // 
            this.whatsAppMessageToolStripMenuItem.Name = "whatsAppMessageToolStripMenuItem";
            this.whatsAppMessageToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.whatsAppMessageToolStripMenuItem.Text = "WhatsApp Message";
            this.whatsAppMessageToolStripMenuItem.Click += new System.EventHandler(this.whatsAppMessageToolStripMenuItem_Click);
            // 
            // auditTrailToolStripMenuItem
            // 
            this.auditTrailToolStripMenuItem.Name = "auditTrailToolStripMenuItem";
            this.auditTrailToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.auditTrailToolStripMenuItem.Text = "Audit Trail";
            this.auditTrailToolStripMenuItem.Click += new System.EventHandler(this.auditTrailToolStripMenuItem_Click);
            // 
            // iPDToolStripMenuItem
            // 
            this.iPDToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iPDToolStripMenuItem.Image = global::Hospital_Management.Properties.Resources.ipd;
            this.iPDToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iPDToolStripMenuItem.Name = "iPDToolStripMenuItem";
            this.iPDToolStripMenuItem.Size = new System.Drawing.Size(96, 54);
            this.iPDToolStripMenuItem.Text = "IPD";
            this.iPDToolStripMenuItem.Click += new System.EventHandler(this.iPDToolStripMenuItem_Click);
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.BackColor = System.Drawing.SystemColors.Info;
            this.lblRef.Location = new System.Drawing.Point(738, 9);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(13, 20);
            this.lblRef.TabIndex = 3;
            this.lblRef.Text = ".";
            this.lblRef.MouseLeave += new System.EventHandler(this.lblRef_MouseLeave);
            this.lblRef.MouseHover += new System.EventHandler(this.lblRef_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRef);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1618, 37);
            this.panel1.TabIndex = 4;
            // 
            // timer_scroll
            // 
            this.timer_scroll.Enabled = true;
            this.timer_scroll.Interval = 10;
            this.timer_scroll.Tick += new System.EventHandler(this.timer_scroll_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1618, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Hospital Management for Dr. Virender Ultrasound and Hospital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cashReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referalAmountListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCollectionReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem formFToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatsAppMessageToolStripMenuItem;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer_scroll;
        private System.Windows.Forms.ToolStripMenuItem auditTrailToolStripMenuItem;
    }
}