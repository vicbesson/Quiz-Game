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
    public partial class CreateQuizQuestionControl : UserControl
    {
        public CreateQuizQuestionControl(string question, int number,Panel panelpntr)
        {
            InitializeComponent();
            if (!question.EndsWith("?"))
                lblMessage.Text = number.ToString() + ". " + question + "?";
            else
                lblMessage.Text = number.ToString() + ". " + question;
            this.Question = question;
            this.Number = number;
            this.IsSelected = false;
            lblMessage.MaximumSize = new Size(panelpntr.Width, 0);
            this.Width = panelpntr.Width;
            if (lblMessage.Height > 65)
                this.Height = lblMessage.Height + 20;
            else
                this.Height = 65;
            lblMessage.Left = this.Width / 2 - lblMessage.Width / 2;
            lblMessage.Top = this.Height / 2 - lblMessage.Height / 2;
            panelpntr.Controls.Add(this);
        }
        public string Question { get; set; }
        public int Number { get; set; }
        public bool IsSelected { get; set; }

        public void ChangeQuestion(string question)
        {
            this.Question = question;
            if (!question.EndsWith("?"))
                lblMessage.Text = Number.ToString() + ". " + question + "?";
            else
                lblMessage.Text = Number.ToString() + ". " + question;
        }

        public void CreateQuizQuestionControl_Click(object sender, EventArgs e)
        {
            foreach (CreateQuizQuestionControl c in this.Parent.Controls)
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
                ((CreateQuizControl)this.Parent.Parent).btnAddQuestion.Text = "Add Question";
                ((CreateQuizControl)this.Parent.Parent).pnAnswers.Controls.Clear();
                ((CreateQuizControl)this.Parent.Parent).txtQuestion.Clear();
                ((CreateQuizControl)this.Parent.Parent).txtAnswer.Clear();
                ((CreateQuizControl)this.Parent.Parent).btnAddAnswer.Text = "Add";
                ((CreateQuizControl)this.Parent.Parent).btnAddQuestion.Text = "Add Question";
            }
            else
            {
                this.IsSelected = true;
                ((CreateQuizControl)this.Parent.Parent).LoadQuestion(Number - 1);
                this.BackColor = Color.FromArgb(255, 192, 128);
                ((CreateQuizControl)this.Parent.Parent).btnAddQuestion.Text = "Save Question";
            }
        }
    }
}
