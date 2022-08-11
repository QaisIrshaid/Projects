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

        private static string mainDirectoryPath = Directory.GetCurrentDirectory();
        //removing (/bin/debug) to get to FileWorx as the main folder.
        private string requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();

        private readonly string complexSeparator = "%%$$##";

        public FileWorx(String id)
        {
            InitializeComponent();
            this.id = id;
            load();

        }

        private void load()
        {

            string path = requiredDirectoryPath + @"\News\";
            string[] items = Directory.GetFileSystemEntries(path);
            string[] row;

            for (int i = 0; i < items.Length; i++)
            {

                string[] files = File.ReadAllLines(items[i]);
                string[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
                FileInfo inf = new FileInfo(items[i]);
                DateTime dt = inf.CreationTime;
                string[] useId = File.ReadAllLines(requiredDirectoryPath + @"\Users\" + sep[3]);
                string[] sep2 = useId[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
                row = new string[] { sep[0], dt.ToString(), sep[1], sep2[0], i.ToString() };
                grid.Rows.Add(row);

            }
        }
        public void Refrech()
        {
            grid.Rows.Clear();
            titleTB.Text = dateBox.Text = category.Text = richBox2.Text = richBox.Text = picBox.ImageLocation = "";
            dateBox.Text = "";
            category.Text = "";
            richBox2.Text = "";
            richBox.Text = "";
            picBox.ImageLocation = "";
            load();
        }


        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                string path = requiredDirectoryPath + @"\News\";
                string[] items = Directory.GetFileSystemEntries(path);
                object s3 = grid.Rows[e.RowIndex].Cells[4].Value;
                //MessageBox.Show(Convert.ToInt32(s3.ToString()).ToString());
                string[] files = File.ReadAllLines(items[Convert.ToInt32(s3.ToString())]);
                //MessageBox.Show(e.RowIndex.ToString()+"   "+s3.ToString());
                string[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

                if (sep[4] == "non")
                {

                    object s1 = grid.Rows[e.RowIndex].Cells[0].Value;
                    object s2 = grid.Rows[e.RowIndex].Cells[1].Value;

                    category.Show();
                    lablCategory.Show();
                    tabControl1.Hide();
                    tabControl2.Show();

                    titleTB.Text = s1.ToString();
                    dateBox.Text = s2.ToString();
                    category.Text = sep[2];
                    richBox2.Text = sep[5];

                    int i = 1;
                    while (i < files.Length)
                    { richBox2.Text += "\n" + files[i]; i++; }

                }

                else
                {

                    object s1 = grid.Rows[e.RowIndex].Cells[0].Value;
                    object s2 = grid.Rows[e.RowIndex].Cells[1].Value;

                    titleTB.Text = s1.ToString();
                    dateBox.Text = s2.ToString();
                    category.Hide();
                    lablCategory.Hide();

                    tabControl1.Show();
                    tabControl2.Hide();
                    richBox.Text = sep[5];
                    picBox.ImageLocation = (sep[2]);
                    int i = 1;
                    while (i < files.Length)
                    { richBox.Text += "\n" + files[i]; i++; }

                }

            }

            else return;

        }


        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                String path = requiredDirectoryPath + @"\News\";
                String[] items = Directory.GetFileSystemEntries(path);
                object s3 = grid.Rows[e.RowIndex].Cells[4].Value;
                String[] files = File.ReadAllLines(items[Convert.ToInt32(s3.ToString())]);
                String[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

                if (sep[4] == "non")
                {

                    //this.Hide();
                    NewNews old = new NewNews(this.id);
                    old.fill(items[Convert.ToInt32(s3.ToString())].ToString());
                    Refrech();

                }

                else
                {

                    //this.Hide();
                    NewPhoto old = new NewPhoto(this.id);
                    old.fill(items[Convert.ToInt32(s3.ToString())].ToString());
                    Refrech();

                }
            }
            else return;
        }

        private void addNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNews news = new NewNews(this.id);
            news.ShowDialog();
            Refrech();

        }

        private void addPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPhoto photo = new NewPhoto(this.id);
            photo.ShowDialog();
            Refrech();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser user = new NewUser(this.id);
            user.ShowDialog();
            Refrech();
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
                object s3 = grid.Rows[this.rowIndex].Cells[4].Value;
                this.grid.Rows.RemoveAt(this.rowIndex);
                String path = requiredDirectoryPath + @"\News\";
                String[] items = Directory.GetFileSystemEntries(path);
                String[] files = File.ReadAllLines(items[Convert.ToInt32(s3.ToString())]);
                String[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
                files[0] = null;
                if (sep[4] == "non")
                {

                    File.Delete(items[Convert.ToInt32(s3.ToString())]);

                }
                else
                {

                    File.Delete(sep[2]);
                    File.Delete(items[Convert.ToInt32(s3.ToString())]);

                }

                Refresh();
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

            NewUser old = new NewUser(this.id);
            old.fill(this.id);
            Refrech();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Users user = new Users();
            user.ShowDialog();

        }


    }
}
