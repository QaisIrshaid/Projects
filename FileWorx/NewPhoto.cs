using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorx
{
    public partial class NewPhoto : Form
    {
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
        public NewPhoto(string id)
        {
            InitializeComponent();
            this.id = id; UpdateTextPosition();
        }

        private void NewPhoto_Load(object sender, EventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                URL.Text = dialog.FileName.ToString();
                FileInfo inf = new FileInfo(URL.Text);
                if (inf.Extension.ToString() == ".jpg" || inf.Extension.ToString() == ".png" || inf.Extension.ToString() == ".apng")
                    pictureBox1.ImageLocation = dialog.FileName.ToString();
                else
                    MessageBox.Show("The file extension is not supported, please try another file.");


            }


        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" || descriptionTB.Text == "" || body.Text == "" || pictureBox1.ImageLocation == null)
            { MessageBox.Show("Please fill all the arguments to proceed"); }
            else
            {
                String destinationPath = Path.Combine(dir+@"\Photos\", Path.GetFileName(URL.Text));
                File.Copy(URL.Text, destinationPath, true);

                String fileName = dir+@"\News\" + Guid.NewGuid().ToString() + ".txt";

                StreamWriter sw = new StreamWriter(fileName);
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
    }
}
