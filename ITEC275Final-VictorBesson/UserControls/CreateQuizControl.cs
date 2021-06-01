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
    public partial class CreateQuizControl : UserControl
    {
        private int UserID { get; set; }
        private List<Tuple<Models.Question, List<Models.QuestionAnswer>>> Questions = new List<Tuple<Models.Question, List<Models.QuestionAnswer>>>();
        public CreateQuizControl(int UserID,Form formpntr)
        {
            InitializeComponent();
            this.UserID = UserID;
            this.Left = formpntr.Width / 2 - this.Width / 2;
            this.Top = formpntr.Height / 2 - this.Height / 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl uc = new UserMainControl(this.UserID, (Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnAddQuestion.Text == "Add Question")
                {
                    if (pnAnswers.Controls.Count < 2)
                        throw new Exception("Must Have Atleast 2 Answers");
                    int IsThereAnAnswer = pnAnswers.Controls.Count;
                    if (IsThereAnAnswer == 0)
                        throw new Exception("Must Have An Answer");
                    foreach (MiniControls.CreateQuizAnswerControl answer in pnAnswers.Controls)
                        if (answer.IsAnswer == false)
                            IsThereAnAnswer--;
                    if (IsThereAnAnswer == 0)
                        throw new Exception("Must Have An Answer");
                    string q = txtQuestion.Text.Trim();
                    if (!q.EndsWith("?"))
                        q += "?";
                    Models.Question question = new Models.Question()
                    {
                        CreateDate = DateTime.Now,
                        QuestionText = q
                    };
                    List<Models.QuestionAnswer> questionAnswers = new List<Models.QuestionAnswer>();
                    foreach (MiniControls.CreateQuizAnswerControl ac in pnAnswers.Controls)
                    {
                        Models.QuestionAnswer answer = new Models.QuestionAnswer()
                        {
                            CreateDate = DateTime.Now,
                            AnswerText = ac.Answer,
                            Answer = ac.IsAnswer
                        };
                        questionAnswers.Add(answer);
                    }
                    Questions.Add(new Tuple<Models.Question, List<Models.QuestionAnswer>>(question, questionAnswers));
                    UserControl uc = new MiniControls.CreateQuizQuestionControl(txtQuestion.Text.Trim(), pnQuestions.Controls.Count + 1, pnQuestions);
                    ResizePanel(pnQuestions);
                    pnQuestions.ScrollControlIntoView(uc);
                    txtQuestion.Clear();
                    txtAnswer.Clear();
                    pnAnswers.Controls.Clear();
                }
                else
                {
                    if (pnAnswers.Controls.Count < 2)
                        throw new Exception("Must Have Atleast 2 Answers");
                    int IsThereAnAnswer = pnAnswers.Controls.Count;
                    if (IsThereAnAnswer == 0)
                        throw new Exception("Must Have An Answer");
                    foreach (MiniControls.CreateQuizAnswerControl answer in pnAnswers.Controls)
                        if (answer.IsAnswer == false)
                            IsThereAnAnswer--;
                    if (IsThereAnAnswer == 0)
                        throw new Exception("Must Have An Answer");
                    string q = txtQuestion.Text.Trim();
                    if (!q.EndsWith("?"))
                        q += "?";
                    MiniControls.CreateQuizQuestionControl p = null;
                    foreach (MiniControls.CreateQuizQuestionControl c in pnQuestions.Controls)
                    {
                        if (c.IsSelected)
                        {
                            p = c;
                            break;
                        }
                    }
                    if (p != null)
                    {
                        Questions.RemoveAt(p.Number - 1);
                        p.ChangeQuestion(txtQuestion.Text.Trim());
                        Models.Question question = new Models.Question()
                        {
                            CreateDate = DateTime.Now,
                            QuestionText = q
                        };
                        List<Models.QuestionAnswer> questionAnswers = new List<Models.QuestionAnswer>();
                        foreach (MiniControls.CreateQuizAnswerControl ac in pnAnswers.Controls)
                        {
                            Models.QuestionAnswer answer = new Models.QuestionAnswer()
                            {
                                CreateDate = DateTime.Now,
                                AnswerText = ac.Answer,
                                Answer = ac.IsAnswer
                            };
                            questionAnswers.Add(answer);
                        }
                        Questions.Insert(p.Number - 1,new Tuple<Models.Question, List<Models.QuestionAnswer>>(question, questionAnswers));
                        txtQuestion.Clear();
                        txtAnswer.Clear();
                        pnAnswers.Controls.Clear();
                        p.CreateQuizQuestionControl_Click(p, null);
                        btnAddQuestion.Text = "Add Question";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public void LoadQuestion(int index)
        {
            pnAnswers.Controls.Clear();
            txtQuestion.Clear();
            txtAnswer.Clear();
            Tuple<Models.Question, List<Models.QuestionAnswer>> tmp = Questions[index];
            txtQuestion.Text = ((MiniControls.CreateQuizQuestionControl)pnQuestions.Controls[index]).Question;
            foreach(Models.QuestionAnswer q in tmp.Item2)
            {
                pnAnswers.Controls.Add(new MiniControls.CreateQuizAnswerControl(q.AnswerText, pnAnswers.Controls.Count + 1, pnAnswers, q.Answer));
            }
            ResizePanel(pnAnswers);
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnswer.Text.Trim() == "")
                    throw new Exception("Answer Must Have Text");
                if (pnAnswers.Controls.Count == 6)
                    throw new Exception("Max Amount of Answers is 6");
                if (btnAddAnswer.Text == "Add")
                {
                    UserControl uc = new MiniControls.CreateQuizAnswerControl(txtAnswer.Text.Trim(), pnAnswers.Controls.Count + 1, pnAnswers, false);
                    ResizePanel(pnAnswers);
                    pnAnswers.ScrollControlIntoView(uc);
                }
                else
                    foreach (MiniControls.CreateQuizAnswerControl c in pnAnswers.Controls)
                        if (c.Selected)
                        {
                            c.ChangeAnswer((pnAnswers.Controls.Count).ToString() + ". " + txtAnswer.Text);
                            break;
                        }
                txtAnswer.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text.Trim() == "")
                    throw new Exception("Must Enter Title");
                if (Questions.Count < 5)
                    throw new Exception("Must Atleast Have 5 Questions");
                using (DAL.SuperModel sm = new DAL.SuperModel())
                {
                    Models.Quiz quiz = new Models.Quiz()
                    {
                        Title = txtTitle.Text.Trim(),
                        UserID = this.UserID,
                        CreateDate = DateTime.Now,
                        IsPrivate = cbPrivate.Checked
                    };
                    sm.Quizzes.Add(quiz);
                    sm.SaveChanges();
                    foreach(Tuple<Models.Question, List<Models.QuestionAnswer>> i in Questions)
                    {
                        i.Item1.QuizID = quiz.QuizID;
                        sm.Questions.Add(i.Item1);
                        sm.SaveChanges();
                        foreach(Models.QuestionAnswer j in i.Item2)
                        {
                            j.QuestionID = i.Item1.QuestionID;
                            sm.QuestionAnswers.Add(j);
                            sm.SaveChanges();
                        }
                    }
                    UserControl uc = new UserMainControl(this.UserID, (Form)this.Parent);
                    this.Parent.Controls.Add(uc);
                    ((MainForm)this.Parent).currentControl = uc;
                    this.Parent.Controls.Remove(this);
                    this.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            MiniControls.CreateQuizAnswerControl tmp = null;
            foreach(MiniControls.CreateQuizAnswerControl c in pnAnswers.Controls)
            {
                if(c.Selected)
                {
                    tmp = c;
                    break;
                }
            }
            if (tmp != null)
            {
                foreach (MiniControls.CreateQuizAnswerControl c in pnAnswers.Controls)
                {
                    if (c.Number > tmp.Number)
                    {
                        c.Number--;
                        c.ChangeAnswer(c.Answer);
                    }
                }
                pnAnswers.Controls.Remove(tmp);
                txtAnswer.Clear();
                btnAddAnswer.Text = "Add";
                ResizePanel(pnAnswers);
                if(pnAnswers.Controls.Count > 0)
                    pnAnswers.ScrollControlIntoView(pnAnswers.Controls[pnAnswers.Controls.Count - 1]);
            }
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            MiniControls.CreateQuizQuestionControl tmp = null;
            foreach (MiniControls.CreateQuizQuestionControl c in pnQuestions.Controls)
            {
                if (c.IsSelected)
                {
                    tmp = c;
                    break;
                }
            }
            if (tmp != null)
            {
                foreach (MiniControls.CreateQuizQuestionControl c in pnQuestions.Controls)
                {
                    if (c.Number > tmp.Number)
                    {
                        c.Number--;
                        c.ChangeQuestion(c.Question);
                    }
                }
                pnQuestions.Controls.Remove(tmp);
                ResizePanel(pnQuestions);
                txtQuestion.Clear();
                txtAnswer.Clear();
                pnAnswers.Controls.Clear();
                btnAddAnswer.Text = "Add";
                if(pnQuestions.Controls.Count > 0)
                    pnQuestions.ScrollControlIntoView(pnQuestions.Controls[pnQuestions.Controls.Count - 1]);
                btnAddQuestion.Text = "Add Question";
            }
        }
    }
}
