
namespace Hospital_Management
{
    partial class frmDailyCollection
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
            this.dgRefAmount = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbOPD = new System.Windows.Forms.RadioButton();
            this.rbIPD = new System.Windows.Forms.RadioButton();
            this.rbLab = new System.Windows.Forms.RadioButton();
            this.rbXRay = new System.Windows.Forms.RadioButton();
            this.rbUSG = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRefAmount)).BeginInit();
            this.gbCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dgRefAmount);
            this.groupBox1.Location = new System.Drawing.Point(30, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1424, 638);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daily Collection";
            // 
            // dgRefAmount
            // 
            this.dgRefAmount.AllowUserToAddRows = false;
            this.dgRefAmount.AllowUserToDeleteRows = false;
            this.dgRefAmount.AllowUserToOrderColumns = true;
            this.dgRefAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRefAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRefAmount.Location = new System.Drawing.Point(4, 24);
            this.dgRefAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgRefAmount.Name = "dgRefAmount";
            this.dgRefAmount.ReadOnly = true;
            this.dgRefAmount.RowHeadersWidth = 62;
            this.dgRefAmount.Size = new System.Drawing.Size(1416, 609);
            this.dgRefAmount.TabIndex = 0;
            this.dgRefAmount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRefAmount_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1338, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(150, 42);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(198, 26);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(492, 42);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "From Date :";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1338, 759);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.rbAll);
            this.gbCategory.Controls.Add(this.rbOPD);
            this.gbCategory.Controls.Add(this.rbIPD);
            this.gbCategory.Controls.Add(this.rbLab);
            this.gbCategory.Controls.Add(this.rbXRay);
            this.gbCategory.Controls.Add(this.rbUSG);
            this.gbCategory.Location = new System.Drawing.Point(711, 12);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(608, 67);
            this.gbCategory.TabIndex = 45;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Select Test Category";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(541, 28);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(44, 24);
            this.rbAll.TabIndex = 5;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbOPD
            // 
            this.rbOPD.AutoSize = true;
            this.rbOPD.Location = new System.Drawing.Point(444, 28);
            this.rbOPD.Name = "rbOPD";
            this.rbOPD.Size = new System.Drawing.Size(61, 24);
            this.rbOPD.TabIndex = 4;
            this.rbOPD.Text = "OPD";
            this.rbOPD.UseVisualStyleBackColor = true;
            // 
            // rbIPD
            // 
            this.rbIPD.AutoSize = true;
            this.rbIPD.Location = new System.Drawing.Point(347, 28);
            this.rbIPD.Name = "rbIPD";
            this.rbIPD.Size = new System.Drawing.Size(54, 24);
            this.rbIPD.TabIndex = 3;
            this.rbIPD.Text = "IPD";
            this.rbIPD.UseVisualStyleBackColor = true;
            // 
            // rbLab
            // 
            this.rbLab.AutoSize = true;
            this.rbLab.Location = new System.Drawing.Point(251, 28);
            this.rbLab.Name = "rbLab";
            this.rbLab.Size = new System.Drawing.Size(54, 24);
            this.rbLab.TabIndex = 2;
            this.rbLab.Text = "Lab";
            this.rbLab.UseVisualStyleBackColor = true;
            // 
            // rbXRay
            // 
            this.rbXRay.AutoSize = true;
            this.rbXRay.Location = new System.Drawing.Point(142, 28);
            this.rbXRay.Name = "rbXRay";
            this.rbXRay.Size = new System.Drawing.Size(70, 24);
            this.rbXRay.TabIndex = 1;
            this.rbXRay.Text = "X Ray";
            this.rbXRay.UseVisualStyleBackColor = true;
            // 
            // rbUSG
            // 
            this.rbUSG.AutoSize = true;
            this.rbUSG.Checked = true;
            this.rbUSG.Location = new System.Drawing.Point(39, 28);
            this.rbUSG.Name = "rbUSG";
            this.rbUSG.Size = new System.Drawing.Size(63, 24);
            this.rbUSG.TabIndex = 0;
            this.rbUSG.TabStop = true;
            this.rbUSG.Text = "USG";
            this.rbUSG.UseVisualStyleBackColor = true;
            // 
            // frmDailyCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 807);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyCollection";
            this.Text = "Daily Collection Report";
            this.Load += new System.EventHandler(this.frmDailyCollection_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRefAmount)).EndInit();
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgRefAmount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.RadioButton rbOPD;
        private System.Windows.Forms.RadioButton rbIPD;
        private System.Windows.Forms.RadioButton rbLab;
        private System.Windows.Forms.RadioButton rbXRay;
        private System.Windows.Forms.RadioButton rbUSG;
        private System.Windows.Forms.RadioButton rbAll;
    }
}