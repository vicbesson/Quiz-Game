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
    public partial class CreateQuizAnswerControl : UserControl
    {
        public CreateQuizAnswerControl(string answer, int number, Panel panelpntr, bool checkAnswer)
        {
            InitializeComponent();
            lblMessage.Text = number.ToString() + ". " + answer;
            this.Answer = answer;
            this.Number = number;
            this.IsAnswer = checkAnswer;
            if (checkAnswer)
                cbAnswer.Checked = true;
            this.Selected = false;
            lblMessage.MaximumSize = new Size(panelpntr.Width - 52, 0);
            this.Width = panelpntr.Width;
            if (lblMessage.Height > 65)
                this.Height = lblMessage.Height + 20;
            else
                this.Height = 65;
            lblMessage.Left = 0;
            lblMessage.Top = this.Height / 2 - lblMessage.Height / 2;
            panelpntr.Controls.Add(this);
        }
        public string Answer { get; set; }
        public int Number { get; set; }
        public bool IsAnswer { get; set; }
        public bool Selected { get; set; }
        private void cbAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnswer.Checked)
                this.IsAnswer = true;
            else
                this.IsAnswer = false;
        }
        public void ChangeAnswer(string answer)
        {
            this.Answer = answer;
            lblMessage.Text = Number.ToString() + ". " + answer;
        }
        private void CreateQuizAnswerControl_Click(object sender, EventArgs e)
        {
            foreach(CreateQuizAnswerControl c in this.Parent.Controls)
            {
                if (c.Selected && c != this)
                {
                    c.Selected = false;
                    c.BackColor = Color.FromArgb(255, 224, 192);
                }
            }
            if (this.Selected)
            {
                this.Selected = false;
                this.BackColor = Color.FromArgb(255, 224, 192);
                ((CreateQuizControl)this.Parent.Parent).btnAddAnswer.Text = "Add";
                ((CreateQuizControl)this.Parent.Parent).txtAnswer.Clear();
            }
            else
            {
                this.Selected = true;
                this.BackColor = Color.FromArgb(255, 192, 128);
                ((CreateQuizControl)this.Parent.Parent).txtAnswer.Text = Answer;
                ((CreateQuizControl)this.Parent.Parent).btnAddAnswer.Text = "Edit";
            }
        }
    }
}
