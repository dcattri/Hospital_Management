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
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hospital_Management
{

    public partial class frmWhatsApp : BaseForm
    {
        MySqlConnection con = new MySqlConnection(Global.con());
        MySqlCommand cmd;
        public frmWhatsApp()
        {
            InitializeComponent();
        }


        private void frmWhatsApp_Load(object sender, EventArgs e)
        {
            get_templates();
            getPatientList();
            //txtMessage.Text = "We are pleased to inform you, that Dr.Virender Ultrasound Centre is completing two year of successful operations in December 2024, and we would like to take this opportunity to thank you for your continuous support and good wishes.\r\nIn the last Two years, we have endeavoured constantly to maintain high standards of ultrasound service, constantly updating clinical knowledge and adhering to ethical practices. The results have encouraged us, with “Dr.Virender Ultrasound” becoming one of the most liked and appreciated Ultrasound Centre in HODAL.\r\nWe thank you for your support and blessings. We are committed to deliver quality care in future and further expand the good work we have been doing so far.\r\nWe also look forward to your feedback and constructive criticism in future to enable us to learn and improve.\r\nThanking you,\r\nDr  Virender Kumar\r\n(Dr.Virender Ultrasound Centre Hodal)";
        }
        private void getPatientList()
        {
            DataSet dt = new DataSet();
            cmd = new MySqlCommand();
            if (chkTest.Checked == true)
            {
                cmd.CommandText = "select *,true as is_message_sent from (select 0 as PatientID,'Virender' as PatientName,'S/o' as RelationType,'Dharam Singh' as Relation,'9990989070' as Mobile,CURRENT_TIMESTAMP() as  CreatedDate,'Virender S/o Dharam Singh' as Greeting union select 1 as PatientID,'Son' as PatientName,'S/o' as RelationType,'Father' as Relation,'9896416790' as Mobile,CURRENT_TIMESTAMP() as  CreatedDate,'Son S/o Father' as Greeting union select 2 as PatientID,'Deven' as PatientName,'S/o' as RelationType,'Lab' as Relation,'9654289868' as Mobile,CURRENT_TIMESTAMP() as  CreatedDate,'Deven S/o Lab' as Greeting) a ;";
            }
            else
            {
                //cmd.CommandText = "select p.PatientID,PatientName,RelationType,Relation,Mobile,CreatedDate,CONCAT(PatientName,' ',RelationType,' ',Relation,'\r\n') as Greeting from tbl_patient p where length(mobile)=10 order by createddate desc";
                cmd.CommandText = "select p.PatientID,PatientName,RelationType,Relation,Mobile,CreatedDate,CONCAT(PatientName,' ',RelationType,' ',Relation,'\r\n') as Greeting, case when w.PatientID is not null then true else false end as is_message_sent from tbl_patient p left join tbl_whatsapp_messages w on p.PatientID=w.PatientID and w.Message=@msg where length(mobile)=10 order by createddate desc;";
                cmd.Parameters.AddWithValue("@msg", cboTemplate.Text);
            }
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            var column = new DataColumn("select_to_send_message", typeof(bool));
            column.DefaultValue = false;
            dt.Tables[0].Columns.Add(column);

            DataTable dtCloned = dt.Tables[0].Clone();
            dtCloned.Columns["is_message_sent"].DataType = typeof(bool);
            foreach (DataRow row in dt.Tables[0].Rows)
                dtCloned.ImportRow(row);

            dgPatientList.DataSource = dtCloned;//dt.Tables[0];
            dgPatientList.BindingContext = this.BindingContext;

            //DataGridViewButtonColumn sendMessage = new DataGridViewButtonColumn();
            //sendMessage.Name = "sendMessage";
            //sendMessage.Text = "Send Message";
            //int columnIndex = 5;
            //if (dgPatientList.Columns["sendMessage"] == null)
            //{
            //    dgPatientList.Columns.Insert(columnIndex, sendMessage);
            //}



            //var buttonColumn = new DataGridViewButtonColumn()
            //{
            //    Name = "statusButton",
            //    HeaderText = "Send Message",
            //    UseColumnTextForButtonValue = false,
            //    DefaultCellStyle = new DataGridViewCellStyle()
            //    {
            //        NullValue = "Click Send"
            //    }
            //};
            //this.dgPatientList.Columns.Add(buttonColumn);

            //string sentdate;
            //string buttontext = "";
            //foreach (DataGridViewRow row in dgPatientList.Rows)
            //{
            //    sentdate = row.Cells["SentDate"].Value.ToString();
            //    if (sentdate != "") { buttontext = "Sent"; } else { buttontext = "Click Send"; }
            //    row.Cells["statusButton"].Value = buttontext;
            //}

        }

        private void dgPatientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void insertReceipt(string pid, string msg, string result)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Insert into tbl_whatsapp_messages(PatientID,Message,SentDate,SentBy,msg_status) Values(@pid,@msg,CURRENT_TIMESTAMP(),@user,@status)";
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@msg", msg);
            cmd.Parameters.AddWithValue("@user", Globals.username.ToString());
            cmd.Parameters.AddWithValue("@status", result);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            progress_msg.Minimum = 0;
            progress_msg.Maximum = dgPatientList.Rows.Count;
            progress_msg.Step = 1;
            progress_msg.Style = ProgressBarStyle.Continuous;
            int progress = 1;
            string name;
            string mobile;
            string pid;
            bool select_to_send_message;

            foreach (DataGridViewRow row in dgPatientList.Rows)
            {
                progress_msg.Value = progress;
                var result = "";
                name = row.Cells["Greeting"].Value.ToString();
                mobile = row.Cells["Mobile"].Value.ToString();
                pid = row.Cells["PatientID"].Value.ToString();
                select_to_send_message = Convert.ToBoolean(row.Cells["select_to_send_message"].Value);
                if (select_to_send_message == true)
                {
                    result = await send_message(cboTemplate.Text, name, mobile, pid);
                    //if (result == "success")
                    //{
                        insertReceipt(pid, cboTemplate.Text, result);
                    //}
                }
                progress = progress + 1;
            }

            MessageBox.Show("Message sent to all displayed patients", "Congrats");
            getPatientList();
        }

        private static async Task<string> send_message(string template, string name, string mobile, string pid)
        {
            string result = "";
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://graph.facebook.com/v21.0/460132163860712/messages");
                request.Headers.Add("Authorization", "Bearer EACAMT4FrzKIBO7D35NHrb2uqMdJqptke1YLGpNpxOt4r9JZCaYoDQZCPXy6N6PVp30ZAWTtsrmQbzcQL1ee1ZBnrXUTPLx9x6NwS8gzDbYSwQboLgPOSCTBFOZBJWZCGynEGGyZC962lBug7O7SATO7gRfFkRTKTkRVGpRYfyT0jLjXa4MD4KePrZATeKm8rJGCWWgZDZD");
                var content = new StringContent("{\n    \"messaging_product\": \"whatsapp\",\n    \"to\": \"91" + mobile + "\",\n    \"type\": \"template\",\n    \"template\": {\n        \"name\": \"" + template + "\",\n        \"language\": {\n            \"code\": \"en\"\n        },\n    \"components\": [\n      {\n        \"type\": \"body\",\n        \"parameters\": [\n          {\n            \"type\": \"text\",\n            \"text\": \"" + name.Trim() + "\"\n          }\n        ]\n      }\n    ]\n    }\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string resp = await response.Content.ReadAsStringAsync();
                result = "success";
            }
            catch (Exception e)
            {
                result = "fail";
                HandleUnhandledException(e);
            }
            finally
            {
                //return "fail";
            }
            return result;
            //insertReceipt(pid, template);
        }
        private static void HandleUnhandledException(Object o)
        {
            // TODO: Log it!
            Exception e = o as Exception;

            if (e != null)
            {

            }
        }
        private async void get_templates()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://graph.facebook.com/v21.0/556155280905610/message_templates");
            request.Headers.Add("Authorization", "Bearer EACAMT4FrzKIBO7D35NHrb2uqMdJqptke1YLGpNpxOt4r9JZCaYoDQZCPXy6N6PVp30ZAWTtsrmQbzcQL1ee1ZBnrXUTPLx9x6NwS8gzDbYSwQboLgPOSCTBFOZBJWZCGynEGGyZC962lBug7O7SATO7gRfFkRTKTkRVGpRYfyT0jLjXa4MD4KePrZATeKm8rJGCWWgZDZD");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resp = await response.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(resp);

            //var abc = jObj.SelectToken("data[1].name").Value<string>();

            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("text", typeof(string));
            table.Columns.Add("status", typeof(string));
            table.Columns.Add("category", typeof(string));
            table.Columns.Add("language", typeof(string));



            var items = jObj["data"].Value<JArray>();
            foreach (JToken item in items)
            {
                if (item is JArray)
                {
                    item.ToString();
                    //do something with the array
                }
                else if (item is JObject)
                {
                    //item.ToString();
                    var name = item.SelectToken("name").Value<string>();
                    var text = item.SelectToken("components[0].text").Value<string>();
                    var status = item.SelectToken("status").Value<string>();
                    var category = item.SelectToken("category").Value<string>();
                    var language = item.SelectToken("language").Value<string>();
                    //do something with the object
                    table.Rows.Add(name, text, status, category, language);
                }
            }

            DataTable tblFiltered = table.AsEnumerable()
                             .Where(r => r.Field<string>("status") == "APPROVED" && r.Field<string>("name") != "hello_world")
                             .CopyToDataTable();
            cboTemplate.DataSource = tblFiltered;
            cboTemplate.DisplayMember = "name";
            cboTemplate.ValueMember = "text";

            cboTemplate.BindingContext = this.BindingContext;

        }

        private void cboTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            txtMsg.Text = cboTemplate.SelectedValue.ToString();
        }

        private void chkTest_CheckedChanged(object sender, EventArgs e)
        {
            getPatientList();
        }

        private void chk1000_CheckedChanged(object sender, EventArgs e)
        {
            //is_message_sent
            int max;
            int strt = 0;
            foreach (DataGridViewRow row in dgPatientList.Rows)
            {
                if (Convert.ToBoolean(row.Cells["is_message_sent"].Value) == true)
                { strt = strt + 1; }

            }
            max = dgPatientList.Rows.Count;
            if (max > 100) { max = strt + 100; }

            if (chk1000.Checked == true)
            {
                for (var i = strt; i < max; ++i)
                {
                    dgPatientList.Rows[i].Cells["select_to_send_message"].Value = true;
                }

            }
            else
            {
                for (var i = 0; i < max; ++i)
                {
                    dgPatientList.Rows[i].Cells["select_to_send_message"].Value = false;
                }
            }
        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPatientList();
        }
    }


}
