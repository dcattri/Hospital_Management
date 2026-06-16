using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Management
{
    static class Global
    {
        // Modern connection resolution: prefer environment variable or structured configuration.
        // Avoid reading legacy txt files. Use JSON parsing for appsettings or environment components.
        private static string ReadAppSettingsMySql()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var candidates = new[] {
                    Path.Combine(baseDir, "appsettings.json"),
                    Path.Combine(baseDir, "..", "CashReceipt.WPF", "appsettings.json"),
                    Path.Combine(baseDir, "CashReceipt.WPF", "appsettings.json")
                };

                foreach (var p in candidates)
                {
                    if (!File.Exists(p)) continue;
                    var txt = File.ReadAllText(p);
                    // naive JSON extraction for "MySql": "..."
                    var key = "\"MySql\"";
                    var idx = txt.IndexOf(key, StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        var colon = txt.IndexOf(':', idx);
                        if (colon > idx)
                        {
                            var firstQuote = txt.IndexOf('"', colon + 1);
                            if (firstQuote >= 0)
                            {
                                var secondQuote = txt.IndexOf('"', firstQuote + 1);
                                if (secondQuote > firstQuote)
                                {
                                    var val = txt.Substring(firstQuote + 1, secondQuote - firstQuote - 1);
                                    if (!string.IsNullOrWhiteSpace(val)) return val.Trim();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return string.Empty;
        }

        private static string ReplaceDatabase(string conn, string database)
        {
            if (string.IsNullOrWhiteSpace(conn)) return string.Empty;
            try
            {
                var lower = conn.ToLowerInvariant();
                var key = "database=";
                var idx = lower.IndexOf(key, StringComparison.Ordinal);
                if (idx >= 0)
                {
                    var after = idx + key.Length;
                    var semicolon = conn.IndexOf(';', after);
                    if (semicolon >= 0)
                    {
                        return conn.Substring(0, idx) + "Database=" + database + conn.Substring(semicolon);
                    }
                    else
                    {
                        return conn.Substring(0, idx) + "Database=" + database;
                    }
                }
                else
                {
                    // append
                    if (conn.EndsWith(";")) return conn + "Database=" + database;
                    return conn + ";Database=" + database;
                }
            }
            catch
            {
                return conn ?? string.Empty;
            }
        }
        private static string BuildFromEnvComponents(string desiredDb)
        {
            try
            {
                var host = Environment.GetEnvironmentVariable("CASHRECEIPT_HOST");
                var user = Environment.GetEnvironmentVariable("CASHRECEIPT_USER");
                var pwd = Environment.GetEnvironmentVariable("CASHRECEIPT_PWD");
                if (!string.IsNullOrWhiteSpace(host) && !string.IsNullOrWhiteSpace(user))
                {
                    var sb = new System.Text.StringBuilder();
                    sb.Append("Server="); sb.Append(host); sb.Append(';');
                    sb.Append("Uid="); sb.Append(user); sb.Append(';');
                    if (!string.IsNullOrWhiteSpace(pwd)) { sb.Append("Pwd="); sb.Append(pwd); sb.Append(';'); }
                    sb.Append("Database="); sb.Append(desiredDb); sb.Append(';');
                    return sb.ToString();
                }
            }
            catch { }
            return string.Empty;
        }

        public static string con()
        {
            // determine desired DB by branch
            // Prefer explicit DB names from environment variables; fall back to hard-coded defaults
            var palwalDb = Environment.GetEnvironmentVariable("CASHRECEIPT_DB_PALWAL");
            if (string.IsNullOrWhiteSpace(palwalDb)) palwalDb = "cashreceipt_test";
            var hodalDb = Environment.GetEnvironmentVariable("CASHRECEIPT_DB_HODAL");
            if (string.IsNullOrWhiteSpace(hodalDb)) hodalDb = "cashreceipt_hodal_test";

            var desiredDb = (Globals.branch ?? string.Empty).ToLowerInvariant() == "palwal"
                ? palwalDb
                : hodalDb;

            // 1) environment override: full connection string
            try
            {
                var env = Environment.GetEnvironmentVariable("CASHRECEIPT_CONNECTION");
                if (!string.IsNullOrWhiteSpace(env)) return ReplaceDatabase(env.Trim(), desiredDb);
            }
            catch { }

            // 2) structured environment components
            var fromEnvComponents = BuildFromEnvComponents(desiredDb);
            if (!string.IsNullOrWhiteSpace(fromEnvComponents)) return fromEnvComponents;

            // 3) appsettings.json (MySql)
            var app = ReadAppSettingsMySql();
            if (!string.IsNullOrWhiteSpace(app)) return ReplaceDatabase(app, desiredDb);

            // final fallback: no connection available
            return string.Empty;
        }
        //public static string con
        //{
        //    get { return _con; }
        //    set { _con = value; }
        //}
        //public static string con_palwal
        //{
        //    get { return _con_palwal; }
        //    set { _con_palwal = value; }
        //}

    }
}
