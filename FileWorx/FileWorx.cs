using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileWorx
{

    public partial class FileWorx : Form
    {

        private string id;

        public FileWorx(string id)
        {
            InitializeComponent();
            this.id = id;
            dataGridViewLoad();
        }

        private void dataGridViewLoad()
        {
            string path = Constants.GetDirectory() + @"\News\";
            string[] entries = Directory.GetFileSystemEntries(path);
            string[] row;

            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = File.ReadAllLines(entries[i]);
                string[] ObjectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);
                FileInfo fileInfo = new FileInfo(entries[i]);
                DateTime date = fileInfo.CreationTime;
                string[] lastModifierObject = File.ReadAllLines(Constants.GetDirectory() + @"\Users\" + ObjectAttributes[3]);
                string[] lastModifierAttributes = lastModifierObject[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);

                                  //       Title           Creation Date      Description              Last Modifier       Object Index
                row = new string[] { ObjectAttributes[0], date.ToString(), ObjectAttributes[1], lastModifierAttributes[0], i.ToString() };
                grid.Rows.Add(row);
            }
        }

        public void Refrech()
        {
            grid.Rows.Clear();
            titleTxtBox.Text = dateTxtBox.Text = category.Text = richBox2.Text = richBox.Text = picBox.ImageLocation = "";
            tabControl2.Show();
            dataGridViewLoad();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string path = Constants.GetDirectory() + @"\News\";
                string[] entries = Directory.GetFileSystemEntries(path);
                int objectIndex = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[4].Value.ToString());         
                string[] file = File.ReadAllLines(entries[objectIndex]);
                string[] ObjectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);

                if (ObjectAttributes[4] == Constants.NewsFlag())
                {
                    string title = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string creationDate = grid.Rows[e.RowIndex].Cells[1].Value.ToString();

                    category.Show();
                    lablCategory.Show();
                    tabControl1.Hide();
                    tabControl2.Show();

                    titleTxtBox.Text = title;
                    dateTxtBox.Text = creationDate;
                    category.Text = ObjectAttributes[2];
                    richBox2.Text = ObjectAttributes[5];

                    int i = 1;
                    while (i < file.Length)
                    { 
                        richBox2.Text += "\n" + file[i];
                        i++; 
                    }
                }

                else
                {
                    string title = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string creationDate = grid.Rows[e.RowIndex].Cells[1].Value.ToString();

                    titleTxtBox.Text = title; 
                    dateTxtBox.Text = creationDate;
                    category.Hide();
                    lablCategory.Hide();

                    tabControl1.Show();
                    tabControl2.Hide();
                    richBox.Text = ObjectAttributes[5];
                    picBox.ImageLocation = (ObjectAttributes[2]);

                    int i = 1;
                    while (i < file.Length)
                    {                   
                        richBox.Text += "\n" + file[i]; 
                        i++; 
                    }
                }
            }
            else return;
        }


        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string path = Constants.GetDirectory() + @"\News\";
                string[] entries = Directory.GetFileSystemEntries(path);
                int objectIndex = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[4].Value.ToString());
                string[] file = File.ReadAllLines(entries[objectIndex]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);

                if (objectAttributes[4] == Constants.NewsFlag())
                {
                    AddNews news = new AddNews(this.id);
                    news.fill(entries[objectIndex]);
                    Refrech();
                }

                else
                {
                    AddPhoto photo = new AddPhoto(this.id);
                    photo.fill(entries[objectIndex]);
                    Refrech();
                }
            }
            else return;
        }

        private void addNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNews news = new AddNews(this.id);
            news.ShowDialog();
            Refrech();
        }

        private void addPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPhoto photo = new AddPhoto(this.id);
            photo.ShowDialog();
            Refrech();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser(this.id);
            user.ShowDialog();
        }

        private int rowIndex = 0;

        private void grid_CellMouseUp_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                this.grid.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.grid.CurrentCell = this.grid.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.grid, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.grid.Rows[this.rowIndex].IsNewRow)
            {
                int objectIndex = Convert.ToInt32(grid.Rows[this.rowIndex].Cells[4].Value);
                string path = Constants.GetDirectory() + @"\News\";
                string[] entries = Directory.GetFileSystemEntries(path);
                string[] file = File.ReadAllLines(entries[objectIndex]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);
                file[0] = null;

                if (objectAttributes[4] == Constants.NewsFlag())
                {
                    File.Delete(entries[objectIndex]);
                }
                else
                {
                    File.Delete(objectAttributes[2]);
                    File.Delete(entries[objectIndex]);
                }
                Refrech();
            }
        }

        private void sittingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void accountSittingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser old = new AddUser(this.id);
            old.fill(this.id);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.ShowDialog();
        }

        private void FileWorx_Load(object sender, EventArgs e)
        {

        }
    }
}
