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
    
    public partial class LogIn : Form
    {
        UserInfoDal _userInfoDal = new UserInfoDal();
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTeamlead();   
        }
        private void LoadTeamlead()
        {
            dgwChoose.DataSource = _userInfoDal.Get();
            dgwChoose.Columns[0].Visible = false;
            dgwChoose.Columns[2].Visible = false;
            dgwChoose.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (!cbxIntern.Checked && !cbxTeamLead.Checked)
            {
                MessageBox.Show("You should check one of the checkboxes");
                return;
            }
            if (cbxTeamLead.Checked)
            {
                message = _userInfoDal.Add(new TeamLead
                {
                    Email = tbxEmailSU.Text,
                    Password = tbxPasswordSU.Text,
                    UserName = tbxUserNameSU.Text
                });
                LoadTeamlead();
            }
            else
            {
                message = _userInfoDal.Add(new Intern
                {
                    Email = tbxEmailSU.Text,
                    Password = tbxPasswordSU.Text,
                    UserName = tbxUserNameSU.Text,
                    TeamleadId = Convert.ToInt32(dgwChoose.CurrentRow.Cells[0].Value)
                });
            }
            switch (message)
            {
                case "AIS":
                    MessageBox.Show("Email is already in use");
                    break;
                case "PP":
                    MessageBox.Show("Password cannot be less than 4 characters");
                    break;
                case "EP":
                    MessageBox.Show("Email should contain the character @");
                    break;
                default:
                    MessageBox.Show("Successfully Signed Up");
                    tbxEmailSI.Text = tbxEmailSU.Text;
                    tbxPasswordSI.Text = tbxPasswordSU.Text;
                    tbxEmailSU.Clear();
                    tbxPasswordSU.Clear();
                    tbxUserNameSU.Clear();
                    cbxIntern.Checked = false;
                    cbxTeamLead.Checked = false;
                    break;
            }
        }
        private void cbxIntern_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIntern.Checked) cbxTeamLead.Checked = false;
        }

        private void cbxTeamLead_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTeamLead.Checked) cbxIntern.Checked = false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            IUser user = _userInfoDal.LogIn(tbxEmailSI.Text, tbxPasswordSI.Text);
            if(user == null)
            {
                MessageBox.Show("Wrong email or password");
                return;
            }
            else if (user is TeamLead teamlead)
            {
                TeamleadInterface f1 = new TeamleadInterface();
                f1.user = teamlead;
                f1.Show();
            }
            else if(user is Intern intern)
            {
                InternInterface f3 = new InternInterface();
                f3.user = intern;
                f3.Show();
            }
            this.Visible = false;
        }
    }
}
