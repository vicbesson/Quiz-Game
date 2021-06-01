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
    public partial class RegisterControl : UserControl
    {
        public RegisterControl(Form formpntr)
        {
            InitializeComponent();
            this.Left = formpntr.Width / 2 - this.Width / 2;
            this.Top = formpntr.Height / 2 - this.Height / 2;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text.Trim() == "")
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtPasswordc.Clear();
                    throw new Exception("Please enter username");
                }
                if(txtPassword.Text.Trim() == "")
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtPasswordc.Clear();
                    throw new Exception("Please enter a password");
                }
                if (txtPassword.Text != txtPasswordc.Text)
                {
                    txtPassword.Clear();
                    txtPasswordc.Clear();
                    throw new Exception("Passwords do not match");
                }
                using (SuperModel sm = new SuperModel())
                {
                    User tmpUser = sm.Users.Where(x => x.UserName == txtUsername.Text.ToLower().Trim()).FirstOrDefault();
                    if (tmpUser != null)
                    {
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtPasswordc.Clear();
                        throw new Exception("Username Taken");
                    }
                    else
                    {
                        User user = new User()
                        {
                            UserName = txtUsername.Text.ToLower().Trim(),
                            Password = md5hasher.GetMd5Hash(txtPassword.Text)
                        };
                        sm.Users.Add(user);
                        sm.SaveChanges();
                        UserControl uc = new LoginControl((Form)this.Parent);
                        this.Parent.Controls.Add(uc);
                        ((MainForm)this.Parent).currentControl = uc;
                        this.Parent.Controls.Remove(this);
                        this.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl uc = new LoginControl((Form)this.Parent);
            this.Parent.Controls.Add(uc);
            ((MainForm)this.Parent).currentControl = uc;
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
