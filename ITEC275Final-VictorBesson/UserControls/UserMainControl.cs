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
    public partial class UserMainControl : UserControl
    {
        private static Random rng = new Random();
        public int UserID { get; set; }
        public Models.Quiz Quiz { get; set; }
        public UserMainControl(int UserID, Form formpntr)
        {
            InitializeComponent();
            this.UserID = UserID;
            this.Left = formpntr.Width / 2 - this.Width / 2;
            this.Top = formpntr.Height / 2 - this.Height / 2;
           
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserControl uc = new LoginControl((Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            UserControl uc = new CreateQuizControl(this.UserID,(Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        public void ResizePanel(Panel pn)
        {
            foreach (Control c in pn.Controls)
            {
                c.Width = pn.Width;
            }
            pn.AutoScroll = false;
            pn.HorizontalScroll.Enabled = false;
            pn.AutoScroll = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pnInvitedQuizzes.Controls.Clear();
            pnMyQuizzes.Controls.Clear();
            pnPublicQuizzes.Controls.Clear();
            try
            {
                using (DAL.SuperModel s = new DAL.SuperModel())
                {
                    if(txtSearch.Text.Trim() == "")
                    {
                        foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID != this.UserID && x.IsPrivate == false).ToList())
                        {
                            pnPublicQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnPublicQuizzes));
                        }
                        foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID == UserID).ToList())
                        {
                            pnMyQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnMyQuizzes));
                        }
                        foreach (Models.SharedQuiz q in s.SharedQuizzes.Where(x => x.UserID == UserID).ToList())
                        {
                            pnInvitedQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Quiz.Title, q.Quiz.QuizID, q.Quiz.User.UserName, q.Quiz.CreateDate.ToLocalTime().ToString(), pnInvitedQuizzes));
                        }
                    }
                    else if(s.Quizzes.Where(x => x.Title.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim())).FirstOrDefault() != null)
                    {
                        foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID != this.UserID && x.IsPrivate == false && x.Title.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim())).ToList())
                        {
                            pnPublicQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnPublicQuizzes));
                        }
                        foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID == UserID && x.Title.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim())).ToList())
                        {
                            pnMyQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnMyQuizzes));
                        }
                        foreach (Models.SharedQuiz q in s.SharedQuizzes.Where(x => x.UserID == UserID && x.Quiz.Title.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim())).ToList())
                        {
                            pnInvitedQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Quiz.Title, q.Quiz.QuizID, q.Quiz.User.UserName, q.Quiz.CreateDate.ToLocalTime().ToString(), pnInvitedQuizzes));
                        }
                    }
                    ResizePanel(pnInvitedQuizzes);
                    ResizePanel(pnMyQuizzes);
                    ResizePanel(pnPublicQuizzes);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserMainControl_Load(object sender, EventArgs e)
        {
            try
            { 
                using (DAL.SuperModel s = new DAL.SuperModel())
                {
                    foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID != this.UserID && x.IsPrivate == false).ToList())
                    {
                        pnPublicQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnPublicQuizzes));
                    }
                    foreach (Models.Quiz q in s.Quizzes.Where(x => x.UserID == UserID).ToList())
                    {
                        pnMyQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Title, q.QuizID, q.User.UserName, q.CreateDate.ToLocalTime().ToString(), pnMyQuizzes));
                    }
                    foreach (Models.SharedQuiz q in s.SharedQuizzes.Where(x => x.UserID == UserID).ToList())
                    {
                        pnInvitedQuizzes.Controls.Add(new MiniControls.UserMainQuizControl(q.Quiz.Title, q.Quiz.QuizID, q.Quiz.User.UserName, q.Quiz.CreateDate.ToLocalTime().ToString(), pnInvitedQuizzes));
                    }
                }
                ResizePanel(pnInvitedQuizzes);
                ResizePanel(pnMyQuizzes);
                ResizePanel(pnPublicQuizzes);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string[] arr = { "a","b","c","d","e","f","g","h","i", "j" , "k" , "l" , "m" , "n" , "o" , "p" , "q" , "r" , "s" , "t" , "u" , "v" , "w" , "x" , "y" , "z" , "1" , "2", "3"
            , "4", "5", "6", "7", "8", "9", "0"};
            string code = "";
            for (int i = 0; i < 12; i++)
            {
                code += arr[rng.Next(0, arr.Length)];
            }
            using (DAL.SuperModel s = new DAL.SuperModel())
            {
                while(s.LiveGames.Where(x => x.RandomCode == code).FirstOrDefault() != null)
                {
                    code = "";
                    for (int i = 0; i < 12; i++)
                    {
                        code += arr[rng.Next(0, arr.Length)];
                    }
                }
                Models.LiveGame liveGame = new Models.LiveGame
                {
                    QuizID = Quiz.QuizID,
                    RandomCode = code,
                    CreatedDate = DateTime.Now
                };
                s.LiveGames.Add(liveGame);
                s.SaveChanges();
                UserControl uc = new UserInviteControl((Form)this.Parent, liveGame.LiveGameID, liveGame.RandomCode);
                this.Parent.Controls.Add(uc);
                ((MainForm)this.Parent).currentControl = uc;
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }
    }
}
