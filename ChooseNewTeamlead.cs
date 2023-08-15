using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class ChooseNewTeamlead : Form
    {
        UserInfoDal _userInfoDal = new UserInfoDal();
        NoteDal _noteDal = new NoteDal();
        public TeamLead user;
        public ChooseNewTeamlead()
        {
            InitializeComponent();
        }

        private void ChooseNewTeamlead_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            Intern[] interns = _userInfoDal.GetInterns(user);
            TeamLead[] teamLeads = _userInfoDal.GetTeamleadForInterns(user);

            DataGridViewTextBoxColumn internColumn = new DataGridViewTextBoxColumn();
            internColumn.HeaderText = "Intern Name";
            internColumn.DataPropertyName = "UserName";

            DataGridViewComboBoxColumn teamLeadColumn = new DataGridViewComboBoxColumn();
            teamLeadColumn.DataSource = teamLeads;
            teamLeadColumn.HeaderText = "Team Lead";
            teamLeadColumn.DisplayMember = "UserName";
            teamLeadColumn.ValueMember = "Id";
            teamLeadColumn.Name = "teamLeadColumn";

            dgwInternTeamlead.Columns.Add(internColumn);
            dgwInternTeamlead.Columns.Add(teamLeadColumn);

            dgwInternTeamlead.DataSource = interns;

            dgwInternTeamlead.Columns[3].Visible = false;
            dgwInternTeamlead.Columns[1].Visible = false; 
            dgwInternTeamlead.Columns[5].Visible = false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this account?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            if (!check(sender, e))
            {
                MessageBox.Show("You should choose a teamlead for all of the interns");
                return;
            }
            _noteDal.DeleteNotesAndReturnsOfADeletedTeamlead(user);
            foreach (DataGridViewRow row in dgwInternTeamlead.Rows)
            {
                if (row.DataBoundItem is Intern intern)
                {
                    _userInfoDal.AdjustNewTeamlead(intern, Convert.ToInt32(row.Cells["teamLeadColumn"].Value));
                    
                }
                _userInfoDal.RemoveTeamleadOrIntern(user);
            }
            MessageBox.Show("Successfully Deleted");
            LogIn form2 = new LogIn();
            form2.Show();
        }
        private bool check(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgwInternTeamlead.Rows)
            {
                if (row.Cells["teamLeadColumn"].Value == null) return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
