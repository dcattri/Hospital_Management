using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    public partial class frmAuditTrail : Form
    {
        public frmAuditTrail()
        {
            InitializeComponent();
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var from = dtpFrom.Value.Date;
                var to = dtpTo.Value.Date.AddDays(1).AddTicks(-1);
                var username = cboUser.SelectedItem?.ToString();

                using (var con = new MySqlConnection(Global.con()))
                using (var cmd = con.CreateCommand())
                {
                    var sql = "SELECT id, created_at AS event_time, username, form_name, action, details FROM audit_trail WHERE created_at BETWEEN @from AND @to";
                    if (!string.IsNullOrEmpty(username))
                    {
                        sql += " AND username = @user";
                        cmd.Parameters.AddWithValue("@user", username);
                    }
                    var selectedAction = (cboAction.SelectedItem as string)?.Trim();
                    if (!string.IsNullOrEmpty(selectedAction) && !string.Equals(selectedAction, "All", StringComparison.OrdinalIgnoreCase))
                    {
                        // case-insensitive and trimmed comparison to handle DB value variations
                        sql += " AND TRIM(LOWER(action)) = TRIM(LOWER(@action))";
                        cmd.Parameters.AddWithValue("@action", selectedAction);
                    }
                    sql += " ORDER BY created_at DESC LIMIT 1000";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);

                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd)) da.Fill(dt);
                    dgvAudit.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            try
            {
                // populate users dropdown
                using (var con = new MySqlConnection(Global.con()))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT username FROM audit_trail ORDER BY username";
                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd)) da.Fill(dt);
                    cboUser.Items.Clear();
                    foreach (DataRow r in dt.Rows) cboUser.Items.Add(r[0].ToString());
                }

                // populate actions dropdown
                using (var con2 = new MySqlConnection(Global.con()))
                using (var cmd2 = con2.CreateCommand())
                {
                    cmd2.CommandText = "SELECT DISTINCT action FROM audit_trail ORDER BY action";
                    var dtA = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd2)) da.Fill(dtA);
                    cboAction.Items.Clear();
                    cboAction.Items.Add("All");
                    foreach (DataRow r in dtA.Rows) cboAction.Items.Add(r[0].ToString());
                    cboAction.SelectedIndex = 0;
                }
            }
            catch
            {
                // ignore
            }
        }
    }
}
