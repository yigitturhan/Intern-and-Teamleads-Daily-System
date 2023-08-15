using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    
    public partial class ChangePassword : Form
    {
        UserInfoDal _userInfoDal = new UserInfoDal();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            IUser user = _userInfoDal.LogIn(tbxEmail.Text, tbxPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Wrong email or password");
                return;
            }
            else if (user is TeamLead teamlead)
            {
                TeamLead newTeamlead = teamlead as TeamLead;
                newTeamlead.Password = tbxPasswordNew.Text;
                _userInfoDal.Update(newTeamlead);
            }
            else if (user is Intern intern)
            {
                Intern newIntern = intern as Intern;
                newIntern.Password = tbxPasswordNew.Text;
                _userInfoDal.Update(newIntern);
            }
            MessageBox.Show("Password has changed successfully");
            tbxEmail.Clear();
            tbxPassword.Clear();
            tbxPasswordNew.Clear();
            this.Close();
            LogIn form2 = new LogIn();
            form2.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is InternInterface form3)
                {
                    form3.Visible = true;
                    break;
                }
                if (openForm is TeamleadInterface form1)
                {
                    form1.Visible = true;
                    break;
                }
            }
            this.Close();
        }
    }
}
