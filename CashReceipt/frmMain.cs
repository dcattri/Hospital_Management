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
    public partial class frmMain : BaseForm
    {
        int XCounta = 0;
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmMain()
        {
            InitializeComponent();
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Run heavy startup work on background thread to keep UI responsive.
            this.UseWaitCursor = true;
            try
            {
                var result = await Task.Run(() =>
                {
                    try
                    {
                        // If the form defines a LoadInitialData method, invoke it here and return its result.
                        var mi = this.GetType().GetMethod("LoadInitialData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                        return mi?.Invoke(this, null);
                    }
                    catch { return null; }
                });

                // If LoadInitialData returned a referral string, update UI on UI thread
                if (result is string refText)
                {
                    if (!string.IsNullOrEmpty(refText))
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            try
                            {
                                lblRef.Text = refText;
                                lblRef.Location = new Point(panel1.Width, lblRef.Location.Y);
                                XCounta = 0;
                                timer_scroll.Start();
                            }
                            catch { }
                        }));
                    }
                }
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void newCashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmEntryForm entryForm = new frmEntryForm();
            //entryForm.MdiParent = this;
            //entryForm.Show();
            if (Globals.username != "admin")
            {
                RunScriptToolStripMenuItem.Visible = false;
                createUserToolStripMenuItem.Visible = false;
            }
            // Heavy startup work (DB loads) moved to LoadInitialData to run off UI thread.
            AuditTrail.Log(Globals.username, nameof(frmMain), "Open", "Main form opened");
        }

        // Runs on background thread; return referral marquee text to be applied on UI thread
        private string LoadInitialData()
        {
            try
            {
                using (var conLocal = new MySqlConnection(Global.con()))
                using (var cmdLocal = new MySqlCommand())
                {
                    cmdLocal.CommandText = "select GROUP_CONCAT(concat(' Attention: New referral : ',PatientName,' ',RelationType,' ',Relation,' mobile ',mobile,' referred by ', DoctorName,' on ',CreatedDate)) as Patient from tbl_patient_ref where PatientID not in (select RefNo from tbl_patient where RefNo is not null);";
                    cmdLocal.Connection = conLocal;
                    var dt = new DataSet();
                    using (var da = new MySqlDataAdapter(cmdLocal))
                    {
                        da.Fill(dt);
                    }

                    if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                        return dt.Tables[0].Rows[0]["Patient"].ToString();
                }
            }
            catch
            {
                // swallow DB errors at startup; return empty
            }

            return string.Empty;
        }
        public void getRef()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            cmd.CommandText = "select GROUP_CONCAT(concat(' Attention: New referral : ',PatientName,' ',RelationType,' ',Relation,' mobile ',mobile,' referred by ', DoctorName,' on ',CreatedDate)) as Patient from tbl_patient_ref where PatientID not in (select RefNo from tbl_patient where RefNo is not null);";
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            lblRef.Text = dt.Tables[0].Rows[0]["Patient"].ToString();

            //dt.Clear();
        }

        private void addNewTestNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReferralAmountListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddDoctorNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void cashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntryForm entryForm = new frmEntryForm();
            entryForm.MdiParent = this;
            entryForm.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Entry Form");
        }

        private void addTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewTest testForm = new frmAddNewTest();
            testForm.MdiParent = this;
            testForm.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Add New Test");
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewDoctor newDoc = new frmAddNewDoctor();
            newDoc.MdiParent = this;
            newDoc.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Add Doctor");
        }

        private void referalAmountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRefAmount RefAmount = new frmRefAmount();
            RefAmount.MdiParent = this;
            RefAmount.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Referral Amount List");
        }

        private void dailyCollectionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDailyCollection dailyCollection = new frmDailyCollection();
            dailyCollection.MdiParent = this;
            dailyCollection.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Daily Collection");
        }

        private void formFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFormF formF = new frmFormF();
            formF.MdiParent = this;
            formF.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Form F");
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateUser user = new frmCreateUser();
            user.MdiParent = this;
            user.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Create User");
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfile profile = new frmMyProfile();
            profile.MdiParent = this;
            profile.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened My Profile");
        }

        private void RunScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScript script = new frmScript();
            script.MdiParent = this;
            script.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Script");
        }
        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var user = (Globals.username ?? string.Empty).Trim();
                if (!string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Only Admin users can access Audit Trail.", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var frm = new frmAuditTrail();
                // If this form is an MDI parent, attempt to set as child; ignore if not applicable
                try { frm.MdiParent = this; } catch { }
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Show();
                AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Audit Trail");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Audit Trail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dailyExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyExpense exp = new frmDailyExpense();
            exp.MdiParent = this;
            exp.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Daily Expense");
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient exp = new frmPatient();
            exp.MdiParent = this;
            exp.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened Patient Form");
        }
        private void iPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPD exp = new frmIPD();
            exp.MdiParent = this;
            exp.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened IPD Form");
        }

        private void whatsAppMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWhatsApp exp = new frmWhatsApp();
            exp.MdiParent = this;
            exp.Show();
            AuditTrail.Log(Globals.username, nameof(frmMain), "OpenChild", "Opened WhatsApp Form");
        }

        private void timer_scroll_Tick(object sender, EventArgs e)
        {
            if (lblRef.Location.X == 0)
            {
                XCounta = 0;
                lblRef.Location = new Point(panel1.Width - XCounta, lblRef.Location.Y);
                XCounta++;
            }
            else
            {
                lblRef.Location = new Point(panel1.Width - XCounta, lblRef.Location.Y);
                XCounta++;
            }
        }

        private void lblRef_MouseHover(object sender, EventArgs e)
        {
            timer_scroll.Stop();
        }

        private void lblRef_MouseLeave(object sender, EventArgs e)
        {
            timer_scroll.Start();
        }

        
    }
}
