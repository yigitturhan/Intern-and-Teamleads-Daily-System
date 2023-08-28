using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoProject
{
    public partial class TeamleadInterface : Form
    {
        public TeamLead user;
        NoteDal _notedal = new NoteDal();
        UserInfoDal _userInfoDal = new UserInfoDal();
        public TeamleadInterface()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNotes();
            LoadUserData();
        }
        private void LoadNotes()
        {
            dqwNotes.DataSource = _notedal.GetAll(user);
            dqwNotes.Columns[0].Visible = false;
            dqwNotes.Columns[1].Visible = false;
            dqwNotes.Columns[2].Visible = false;
            dqwNotes.Columns[10].Visible = false;
            dqwNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FillCombobox();

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
            label2.Text = user.UserName;
            label3.Text = user.Email;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _notedal.Add(new Note
            {
                Author = user.UserName,
                Title = tbxTitle.Text,
                Content = tbxContent.Text,
                CreatedAt = DateTime.Now,
                LastUpdate = DateTime.Now,
                AuthorId = user.Id},_userInfoDal.GetInterns(user));
            LoadNotes();
            tbxTitle.Clear();
            tbxContent.Clear();
            MessageBox.Show("ADDED BY " + user.UserName.ToUpper());
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Note note = GetNote(sender, e);
            Return ret = GetReturn(sender, e);
            ret.NoteId = note.Id;
            _notedal.Update(note,ret);
            LoadNotes();
            MessageBox.Show("UPDATED BY " + user.UserName.ToUpper());
        }
        private void dqwNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxTitleUpdate.Text = dqwNotes.CurrentRow.Cells[4].Value.ToString();
            tbxContentUpdate.Text = dqwNotes.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            tbxContentUpdate.Clear();
            tbxTitleUpdate.Clear();
            Note note = GetNote(sender,e);
            Return ret = GetReturn(sender, e);
            ret.NoteId = note.Id;
            _notedal.Delete(note, ret);
            LoadNotes();
            MessageBox.Show("DELETED");
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboboxIntern.SelectedItem == null) dqwNotes.DataSource = _notedal.GetByTitle(tbxSearch.Text, user);
            else
            {
                string selected = comboboxIntern.SelectedItem.ToString();
                dqwNotes.DataSource = _notedal.GetByTitle(tbxSearch.Text, user, selected, user);
            }
        }
        private void FillCombobox()
        {
            comboboxIntern.Items.Clear();
            Intern[] interns = _userInfoDal.GetInterns(user);
            comboboxIntern.Items.Add("====NO FILTER====");
            foreach (Intern intern in interns)
            {
                comboboxIntern.Items.Add(intern.UserName);
            }
        }
        private Note GetNote(object sender, EventArgs e)
        {
            Note note = new Note
            {
                Id = Convert.ToInt32(dqwNotes.CurrentRow.Cells[1].Value),
                Author = user.UserName,
                Title = tbxTitleUpdate.Text,
                Content = tbxContentUpdate.Text,
                CreatedAt = Convert.ToDateTime(dqwNotes.CurrentRow.Cells[6].Value),
                LastUpdate = DateTime.Now,
                AuthorId = user.Id
            };
            return note;
        }
        private Return GetReturn (object sender, EventArgs e)
        {
            Return ret = new Return
            {
                Id = Convert.ToInt32(dqwNotes.CurrentRow.Cells[0].Value),
                Status = dqwNotes.CurrentRow.Cells[8].Value.ToString(),
                ExtraNotes = dqwNotes.CurrentRow.Cells[9].Value.ToString(),
                InternId = Convert.ToInt32(dqwNotes.CurrentRow.Cells[10].Value),
                InternName = dqwNotes.CurrentRow.Cells[11].Value.ToString()
            };
            return ret;
        }

        private void comboboxIntern_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboboxIntern.SelectedItem.ToString();
            if (selectedItem != null) dqwNotes.DataSource = _notedal.GetByIntern(selectedItem, user, tbxSearch.Text, user);
        }
        private void btnLogout_Click(object sender, EventArgs e)
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ChangePassword form4 = new ChangePassword();
            form4.Show();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this account?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ChooseNewTeamlead form = new ChooseNewTeamlead();
                form.user = user;
                form.Show();
            }
        }
    }
}
