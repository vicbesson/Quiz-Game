using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITEC275Final_VictorBesson.UserControls;
namespace ITEC275Final_VictorBesson
{
    public partial class MainForm : Form
    {
        public UserControl currentControl;
        public MainForm()
        {
            InitializeComponent();
            UserControl uc = new StartControl(this);
            this.Controls.Add(uc);
            currentControl = uc;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.currentControl.Left = this.Width / 2 - currentControl.Width / 2;
            this.currentControl.Top = this.Height / 2 - currentControl.Height / 2;
        }
    }
}
