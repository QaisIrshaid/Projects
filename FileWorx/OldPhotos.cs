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

    public partial class OldPhotos : Form
    {
        private String oldPath;
        private String id;
        private String dir = Directory.GetCurrentDirectory().Split('b')[0];

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
        public OldPhotos(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void OldPhotos_Load(object sender, EventArgs e)
        {
            UpdateTextPosition();

        }
        public void fill(String path)
        {
            this.Show();
            oldPath = path;
            String[] files = File.ReadAllLines(path);
            String[] sep = files[0].Split('$');
            titleTB.Text = sep[0];
            descriptionTB.Text = sep[1];
            picBox.Image = Image.FromFile(sep[2]);
            

            URL.Text = sep[2];
            body.Text = sep[5];
            int i = 1;
            while (i < files.Length)
            { body.Text += "\n" + files[i]; i++; }

        }
        private String ss;
        private void browse_Click(object sender, EventArgs e)
        {
            //ss = URL.Text;
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                URL.Text = dialog.FileName.ToString();
                FileInfo inf = new FileInfo(URL.Text);
                
                if (inf.Extension.ToString() == ".jpg" || inf.Extension.ToString() == ".png" || inf.Extension.ToString() == ".apng")
                    picBox.ImageLocation = dialog.FileName.ToString();
                else
                    MessageBox.Show("The file extension is not supported, please try another file.");
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" || descriptionTB.Text == "" || body.Text == ""|| picBox.ImageLocation == null)
            { MessageBox.Show("Please fill all the arguments to proceed"); }
            else
            {
                String destinationPath = Path.Combine(dir+@"Photos\", Path.GetFileName(URL.Text));
                File.Copy(URL.Text, destinationPath, true);

                StreamWriter sw = new StreamWriter(oldPath);
                sw.WriteLine(titleTB.Text + "$" + descriptionTB.Text + "$" + destinationPath + "$" + id + "$" + "p" + "$" + body.Text);
                sw.Flush();
                sw.Close();


                this.Hide();
                FileWorx worx = new FileWorx(this.id);
                worx.Show();

            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileWorx worx = new FileWorx(this.id);
            worx.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
