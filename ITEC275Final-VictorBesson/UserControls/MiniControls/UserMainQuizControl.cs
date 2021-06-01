using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC275Final_VictorBesson.UserControls.MiniControls
{
    public partial class UserMainQuizControl : UserControl
    {
        public UserMainQuizControl(string title, int key, string username, string date, Panel panelpntr)
        {
            InitializeComponent();
            lblTitle.Text = $"{title}{Environment.NewLine}By {username}";
            lblTitle.MaximumSize = new Size(panelpntr.Width - 20, 0);
            if (lblTitle.Height > 100)
                this.Height = lblTitle.Height + 20;
            else
                this.Height = 100;
            lblTitle.Left = this.Width / 2 - lblTitle.Width / 2;
            lblTitle.Top = this.Height / 2 - lblTitle.Height / 2;
            panelpntr.Controls.Add(this);
            this.Width = panelpntr.Width;
            this.Title = title;
            this.Key = key;
            this.Username = username;
        }
        public int Key { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public bool IsSelected { get; set; }
        private void UserMainQuizControl_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (UserMainQuizControl c in this.Parent.Controls)
                {
                    if (c.IsSelected && c != this)
                    {
                        c.IsSelected = false;
                        c.BackColor = Color.FromArgb(255, 224, 192);
                    }
                }
                if (this.IsSelected)
                {
                    this.IsSelected = false;
                    this.BackColor = Color.FromArgb(255, 224, 192);
                    ((UserMainControl)this.Parent.Parent).btnRun.Enabled = false;
                    ((UserMainControl)this.Parent.Parent).Quiz = null;
                }
                else
                {
                    this.IsSelected = true;
                    this.BackColor = Color.FromArgb(255, 192, 128);
                    ((UserMainControl)this.Parent.Parent).btnRun.Enabled = true;
                    using (DAL.SuperModel s = new DAL.SuperModel())
                    {
                        Models.Quiz q = s.Quizzes.Where(x => x.QuizID == Key).FirstOrDefault();
                        if (q != null)
                            ((UserMainControl)this.Parent.Parent).Quiz = q;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
