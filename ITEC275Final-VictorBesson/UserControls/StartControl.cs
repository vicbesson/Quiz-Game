using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC275Final_VictorBesson.UserControls
{
    public partial class StartControl : UserControl
    {
        public StartControl(Form formpntr)
        {
            InitializeComponent();
            this.Left = formpntr.Width / 2 - this.Width / 2;
            this.Top = formpntr.Height / 2 - this.Height / 2;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserControl uc = new LoginControl((Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
