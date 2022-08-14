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
    public partial class AddPhoto : Form
    {
        private string oldPath;
        private string id;

        public AddPhoto(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void NewPhoto_Load(object sender, EventArgs e)
        {

        }

        public void Fill(string path)
        {
            oldPath = path;
            string[] file = File.ReadAllLines(path);
            string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
            file[0] = null;

            titleTB.Text = objectAttributes[0];
            descriptionTB.Text = objectAttributes[1];
            pictureBox1.ImageLocation = objectAttributes[2];
            photoPath.Text = objectAttributes[2];
            body.Text = objectAttributes[5];

            int i = 1;
            while (i < file.Length)
            {
                body.Text += "\n" + file[i];
                i++;
            }
            this.ShowDialog();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                photoPath.Text = dialog.FileName.ToString();
                FileInfo fileInfo = new FileInfo(photoPath.Text);
                if (fileInfo.Extension.ToString() == ".jpg" || fileInfo.Extension.ToString() == ".png" || fileInfo.Extension.ToString() == ".apng")
                {
                    pictureBox1.ImageLocation = dialog.FileName.ToString();
                }
                else
                {
                    MessageBox.Show("The file extension is not supported, please try another file.");
                }
            }
            dialog.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (titleLbl.Text == "" || descriptionTB.Text == "" || body.Text == "" || pictureBox1.ImageLocation == null)
            {
                MessageBox.Show("Please Fill all the arguments to proceed");
            }

            else
            {
                if (oldPath == null)
                {
                    //if oldPath is null then create a new file.

                    string destinationPath = Path.Combine(Constants.GetDirectory + @"\Photos\", Path.GetFileName(photoPath.Text));
                    try
                    {
                        File.Copy(photoPath.Text, destinationPath);
                    }

                    catch
                    {
                        //if Photos folder already contains a photo with the same name, then rename the cuurent photo.

                        string pictureName = Path.GetFileNameWithoutExtension(photoPath.Text) + "2" + Path.GetExtension(photoPath.Text);
                        destinationPath = Path.Combine(Constants.GetDirectory + @"\Photos\", pictureName);
                        File.Copy(photoPath.Text, destinationPath);
                    }

                    string fileName = Constants.GetDirectory + @"\News\" + Guid.NewGuid().ToString() + ".txt";
                    StreamWriter streamWriter = new StreamWriter(fileName);
                    streamWriter.WriteLine(titleTB.Text + Constants.ComplexSeparator + descriptionTB.Text + Constants.ComplexSeparator + destinationPath + Constants.ComplexSeparator + id + Constants.ComplexSeparator + Constants.PhotoFlag + Constants.ComplexSeparator + body.Text);
                    streamWriter.Flush();
                    streamWriter.Close();

                    this.Hide();
                }

                else
                {
                    //if oldPath has a value then write on the same file.

                    string[] file = File.ReadAllLines(oldPath);
                    string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                    file[0] = null;

                    string destinationPath = Path.Combine(Constants.GetDirectory + @"\Photos\", Path.GetFileName(photoPath.Text));
                    try
                    {
                        File.Copy(photoPath.Text, destinationPath);
                        File.Delete(objectAttributes[2]);
                    }

                    catch { }

                    StreamWriter streamWriter = new StreamWriter(oldPath);
                    streamWriter.WriteLine(titleTB.Text + Constants.ComplexSeparator + descriptionTB.Text + Constants.ComplexSeparator + destinationPath + Constants.ComplexSeparator + id + Constants.ComplexSeparator + Constants.PhotoFlag + Constants.ComplexSeparator + body.Text);
                    streamWriter.Flush();
                    streamWriter.Close();

                    oldPath = null;
                    this.Hide();
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
