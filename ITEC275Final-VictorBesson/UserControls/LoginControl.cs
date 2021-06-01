using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITEC275Final_VictorBesson.Models;
using ITEC275Final_VictorBesson.DAL;
namespace ITEC275Final_VictorBesson.UserControls
{
    public partial class LoginControl : UserControl
    {
        public LoginControl(Form formpntr)
        {
            InitializeComponent();
            this.Left = formpntr.Width / 2 - this.Width / 2;
            this.Top = formpntr.Height / 2 - this.Height / 2;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl uc = new StartControl((Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            UserControl uc = new RegisterControl((Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim() == "")
                    throw new Exception("Must enter a username");
                if (txtPassword.Text.Trim() == "")
                    throw new Exception("Must enter a password");
                using (SuperModel sm = new SuperModel())
                {
                    string pass = md5hasher.GetMd5Hash(txtPassword.Text);
                    User u = sm.Users.Where(x => x.UserName == txtUsername.Text.ToLower().Trim() && x.Password == pass).FirstOrDefault();
                    if (u != null)
                    {
                        UserControl uc = new UserMainControl(u.UserID, (Form)this.Parent);
                        this.Parent.Controls.Add(uc);
                        ((MainForm)this.Parent).currentControl = uc;
                        this.Parent.Controls.Remove(this);
                        this.Dispose();
                    }
                    else
                    {
                        throw new Exception("Username or password is incorrect");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
