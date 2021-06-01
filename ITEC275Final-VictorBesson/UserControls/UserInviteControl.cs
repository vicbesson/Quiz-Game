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
    public partial class UserInviteControl : UserControl
    {
        private BackgroundWorker bgw = new BackgroundWorker();
        public UserInviteControl(Form formpntr, int liveid, string code)
        {
            InitializeComponent();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;
            this.LiveID = liveid;
            txtCode.Text = code;
        }
        public int LiveID { get; set; }
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            using (DAL.SuperModel s = new DAL.SuperModel())
            {
                while (true)
                {
                    int count = s.AnonUsers.Where(x => x.LiveGameID == LiveID).ToList().Count();
                    if (count != num)
                    {
                        num = count;
                        bgw.ReportProgress(0, num);
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtCode.Text = $"Connected Users: {(string)e.UserState}";
        }
    }
}
