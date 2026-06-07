using System;
using System.Windows.Forms;

namespace Hospital_Management
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.Load += BaseForm_Load;
            this.FormClosed += BaseForm_FormClosed;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                AuditTrail.Log(Globals.username, this.GetType().Name, "Open", null);
            }
            catch { }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                AuditTrail.Log(Globals.username, this.GetType().Name, "Close", null);
            }
            catch { }
        }
    }
}
