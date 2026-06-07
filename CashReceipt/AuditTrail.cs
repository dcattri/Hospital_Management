using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    public static class AuditTrail
    {
        private class AuditEntry
        {
            public string Username { get; set; }
            public string FormName { get; set; }
            public string Action { get; set; }
            public string Details { get; set; }
            public DateTime Created { get; set; }
        }

        private static readonly BlockingCollection<AuditEntry> _queue = new BlockingCollection<AuditEntry>(new ConcurrentQueue<AuditEntry>());
        private static readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private static readonly Task _worker;

        static AuditTrail()
        {
            _worker = Task.Factory.StartNew(ProcessQueue, TaskCreationOptions.LongRunning);
        }

        public static void Log(string username, string formName, string action, string details = null)
        {
            try
            {
                var e = new AuditEntry
                {
                    Username = string.IsNullOrEmpty(username) ? "-" : username,
                    FormName = string.IsNullOrEmpty(formName) ? "-" : formName,
                    Action = string.IsNullOrEmpty(action) ? "-" : action,
                    Details = details ?? string.Empty,
                    Created = DateTime.Now
                };
                // enqueue quickly
                _queue.Add(e);
            }
            catch
            {
                // swallow
            }
        }

        private static void ProcessQueue()
        {
            try
            {
                foreach (var item in _queue.GetConsumingEnumerable(_cts.Token))
                {
                    try
                    {
                        using (var con = new MySqlConnection(Global.con()))
                        using (var cmd = con.CreateCommand())
                        {
                            con.Open();
                            cmd.CommandText = "INSERT INTO audit_trail (username, form_name, action, details, created_at) VALUES (@username, @form, @action, @details, @created)";
                            cmd.Parameters.AddWithValue("@username", item.Username);
                            cmd.Parameters.AddWithValue("@form", item.FormName);
                            cmd.Parameters.AddWithValue("@action", item.Action);
                            cmd.Parameters.AddWithValue("@details", item.Details);
                            cmd.Parameters.AddWithValue("@created", item.Created);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        // If insert fails, drop the entry. Consider persisting to local file if necessary.
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch { }
        }

        public static void Shutdown()
        {
            try
            {
                _queue.CompleteAdding();
                _cts.Cancel();
                _worker.Wait(3000);
            }
            catch { }
        }
    }
}
