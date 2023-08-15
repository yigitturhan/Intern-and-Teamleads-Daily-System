using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class InternInterface : Form
    {
        NoteDal _notedal = new NoteDal();
        UserInfoDal _userinfo = new UserInfoDal();
        public Intern user;
        public InternInterface()
        {
            InitializeComponent();
        }
        private void LoadNotes()
        {
            dgwNotes.DataSource = _notedal.GetAll(user);
            LoadComboBox();
            dgwNotes.Columns[0].Visible = false;
            dgwNotes.Columns[1].Visible = false;
            dgwNotes.Columns[2].Visible = false;
            dgwNotes.Columns[10].Visible = false;
            dgwNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("====NO FILTER====");
            comboBox1.Items.Add("Done");
            comboBox1.Items.Add("In Progress");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Note note = GetNote(sender, e);
            Return ret = GetReturn(sender, e);
            ret.NoteId = note.Id;
            _notedal.Update(note,ret);
            LoadNotes();
            MessageBox.Show("UPDATED BY " + user.UserName.ToUpper());
            tbxExtraNotes.Clear();
            cbxDone.Checked = false;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadNotes();
            LoadUserData();
        }
        private string GeneratePath()
        {
            string basepath = "C:/Users/ahmet/source/repos/Solution2/DemoProject/pictures/";
            basepath += user.Email + ".png";
            Console.WriteLine(basepath);
            return basepath;
        }
        private void LoadUserData()
        {
            string p = GeneratePath();
            if (System.IO.File.Exists(p))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = System.Drawing.Image.FromFile(p);
            }
            lblName.Text = user.UserName;
            lblEmail.Text = user.Email;
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            dgwNotes.DataSource = _notedal.GetByTitle(tbxSearch.Text, user);
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is LogIn form2)
                {
                    form2.Visible = true;
                    break;
                }
            }
            this.Close();
        }
        private Note GetNote(object sender, EventArgs e)
        {
            Note note = new Note
            {
                Id = Convert.ToInt32(dgwNotes.CurrentRow.Cells[1].Value),
                Author = dgwNotes.CurrentRow.Cells[3].Value.ToString(),
                Title = dgwNotes.CurrentRow.Cells[4].Value.ToString(),
                Content = dgwNotes.CurrentRow.Cells[5].Value.ToString(),
                CreatedAt = Convert.ToDateTime(dgwNotes.CurrentRow.Cells[6].Value),
                LastUpdate = DateTime.Now,
                AuthorId = Convert.ToInt32(dgwNotes.CurrentRow.Cells[2].Value)
            };
            return note;
        }
        private Return GetReturn (object sender, EventArgs e)
        {
            Return ret = new Return{
                Id = Convert.ToInt32(dgwNotes.CurrentRow.Cells[0].Value),
                ExtraNotes = tbxExtraNotes.Text,
                InternName = user.UserName,
                InternId = user.Id,
                Status = cbxDone.Checked ? "Done" : "In Progress" };
            return ret;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwNotes.DataSource = _notedal.GetByStatus(user,comboBox1.SelectedItem.ToString());
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            ChangePassword form4 = new ChangePassword();
            form4.Show();
            this.Visible = false;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this account?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _userinfo.RemoveTeamleadOrIntern(user);
            }
            MessageBox.Show("Deleted");
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is LogIn form2)
                {
                    form2.Visible = true;
                    break;
                }
            }
            this.Close();
        }
    }
}
