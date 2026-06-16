using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;



namespace Hospital_Management
{
    public partial class frmLogin : BaseForm
    {
        public async Task CheckForUpdatesAsync()
        {
            // 1. Define your Azure Blob Storage configuration endpoint
            string jsonUrl = "https://hmsblobstorageaccount.blob.core.windows.net/hms-deploy/Hospital_Management_Lite/Release/versioncheck.json";

            // 2. Get the current running version of this application
            Version currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 3. Fetch the update metadata string from Azure
                    string jsonString = await client.GetStringAsync(jsonUrl);

                    // 4. Parse the JSON structure safely
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = doc.RootElement;
                        string latestVersionStr = root.GetProperty("LatestVersion").GetString();
                        string downloadUrl = root.GetProperty("DownloadUrl").GetString();

                        Version latestVersion = new Version(latestVersionStr);

                        // 5. Evaluate versions to see if an update is required
                        if (latestVersion > currentVersion)
                        {
                            DialogResult result = MessageBox.Show(
                                $"A new version ({latestVersionStr}) is available! Would you like to download it now?",
                                "Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            //if (result == DialogResult.Yes)
                            //{
                            //    // 6. Launch the default web browser to pull the remote MSI payload
                            //    Process.Start(new ProcessStartInfo
                            //    {
                            //        FileName = downloadUrl,
                            //        UseShellExecute = true
                            //    });
                            //    Application.Exit();
                            //}
                            if (result == DialogResult.Yes)
                            {
                                // 1. Determine a local temp file path for the MSI
                                string tempMsiPath = Path.Combine(Path.GetTempPath(), "Hospital_Management_Update.msi");

                                // 2. Download the actual MSI file bytes directly in the background
                                byte[] msiBytes = await client.GetByteArrayAsync(downloadUrl);

                                // FIX: Changed from WriteAllBytesAsync to synchronous WriteAllBytes
                                File.WriteAllBytes(tempMsiPath, msiBytes);

                                // 3. Execute the local MSI using Windows Installer engine
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = "msiexec.exe",
                                    Arguments = $"/i \"{tempMsiPath}\"",
                                    UseShellExecute = true
                                });


                                // 4. Safely kill the app so files aren't locked during install
                                Application.Exit();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Fail silently or log error so an internet outage doesn't crash your core app
                    Debug.WriteLine($"Update check failed: {ex.Message}");
                }
            }
        }


        public frmLogin()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cboBranch.Text=="")
            {
                MessageBox.Show("Please select branch name", "Error");
            }
            else
            {
                Globals.branch = cboBranch.Text;
                login();
            }
            
        }
        private void login()
        {
            frmMain mainForm = new frmMain();

            if (verifyUser() == true)
            {
                Globals.username = txtName.Text;
                AuditTrail.Log(Globals.username, nameof(frmLogin), "Login", "User logged in");
                mainForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
                mainForm.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Incorrect username or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        private Boolean verifyUser()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Global.con());
                MySqlCommand cmd;

                DataSet dt = new DataSet();
                cmd = new MySqlCommand();
                cmd.CommandText = "select UserName,UserPassword from tbl_usermaster where UserName=@user and UserPassword=@pwd";
                cmd.Parameters.AddWithValue("@user", txtName.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                cmd.Connection = con;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                { return true; }
                else
                { return false; }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }


        }

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.branch = cboBranch.Text;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                await CheckForUpdatesAsync();
            });
        }
    }
}
