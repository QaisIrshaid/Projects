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
        private Rectangle listV;
        private Rectangle original;
        private String id;
        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }
        public FileWorx(String id)
        {
            InitializeComponent();
            this.id = id;
            UpdateTextPosition();
        }

        

        private void FileWorx_Load(object sender, EventArgs e)
        {
            
            String path = @"\git\Projects\FileWorx\News\";
            String[] items = Directory.GetFileSystemEntries(path);

            String[] row;
            for (int i = 0; i < items.Length; i++)
            {
                String[] files = File.ReadAllLines(items[i]);
                String[] sep = files[0].Split('$');
                FileInfo inf = new FileInfo(items[i]);
                DateTime dt = inf.CreationTime;
                String[] useId = File.ReadAllLines(@"\git\Projects\FileWorx\Users\" + sep[3]);
                String[] sep2 = useId[0].Split('$');
                row = new String[] { sep[0], dt.ToString(), sep[1], sep2[0] };
                grid.Rows.Add(row);

            }
        }

       
       
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                String path = @"\git\Projects\FileWorx\News\";
                String[] items = Directory.GetFileSystemEntries(path);
                String[] files = File.ReadAllLines(items[e.RowIndex]);
                String[] sep = files[0].Split('$');
                

                if (sep[4] == "non")
                {

                    object s1 = grid.Rows[e.RowIndex].Cells[0].Value;
                    object s2 = grid.Rows[e.RowIndex].Cells[1].Value;

                    category.Show();
                    label3.Show();
                    tabControl1.Hide();
                    tabControl2.Show();

                    titleTB.Text = sep[0];
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
                    label3.Hide();


                    tabControl1.Show();
                    tabControl2.Hide();
                    richBox.Text = sep[5];
                    picBox.Image = Image.FromFile(sep[2]);
                    int i = 1;
                    while (i < files.Length)
                    { richBox.Text += "\n" + files[i]; i++; }


               
                }
            }
            else return;

        }


        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String path = @"\git\Projects\FileWorx\News\";
            String[] items = Directory.GetFileSystemEntries(path);
            String[] files = File.ReadAllLines(items[e.RowIndex]);
            String[] sep = files[0].Split('$');
            if (sep[4] == "non")
            {

                this.Hide();
                OldNews old = new OldNews(this.id);
                old.fill(items[e.RowIndex].ToString());
            }

            else
            {
                this.Hide();
                OldPhotos old = new OldPhotos(this.id);
                old.fill(items[e.RowIndex].ToString());

            }

        }

        private void addNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNews news = new NewNews(this.id);
            news.Show();
            this.Hide();
        }

        private void addPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPhoto photo = new NewPhoto(this.id);
            this.Hide();
            photo.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser user = new NewUser(this.id);
            user.Show();
            this.Hide();
        }
       
      

        private int rowIndex = 0;

        

        private void grid_CellMouseUp_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
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
                this.grid.Rows.RemoveAt(this.rowIndex);
                String path = @"\git\Projects\FileWorx\News\";
                String[] items = Directory.GetFileSystemEntries(path);
                File.Delete(items[rowIndex]);


            }
        }

        private void splitContainer2_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

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
            OldUser old = new OldUser(this.id);
            old.fill(this.id);
            this.Hide();
            
        }
    }
}
