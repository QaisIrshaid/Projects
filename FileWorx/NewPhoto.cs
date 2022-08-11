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
        private string oldPath;
        private string id;
        private static string mainDirectoryPath = Directory.GetCurrentDirectory();

        //removing (/bin/debug) to get to FileWorx as the main folder.
        private String requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();
        private readonly string complexSeparator = "%%$$##";


       
        public NewPhoto(string id)
        {
            InitializeComponent();
            this.id = id; 
        }

        private void NewPhoto_Load(object sender, EventArgs e)
        {

        }

        public void fill(string path)
        {
            
            oldPath = path;
            string[] files = File.ReadAllLines(path);
            string[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
            files[0] = null;
            titleTB.Text = sep[0];
            descriptionTB.Text = sep[1];
            pictureBox1.ImageLocation = sep[2];
            URL.Text = sep[2];
            body.Text = sep[5];

            int i = 1;
            while (i < files.Length)
            { body.Text += "\n" + files[i]; i++; }
            this.ShowDialog();

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

            dialog.Dispose();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" || descriptionTB.Text == "" || body.Text == "" || pictureBox1.ImageLocation == null)
            { MessageBox.Show("Please fill all the arguments to proceed"); }
            else
            {
                if (oldPath == null)
                {
                    //MessageBox.Show(Path.GetFileName(URL.Text));
                    string destinationPath = Path.Combine(requiredDirectoryPath + @"\Photos\", Path.GetFileName(URL.Text));
                    try { File.Copy(URL.Text, destinationPath); }
                    catch
                    {

                        string fileNames = Path.GetFileNameWithoutExtension(URL.Text) + "2" + Path.GetExtension(URL.Text);
                        destinationPath = Path.Combine(requiredDirectoryPath + @"\Photos\", fileNames);
                        File.Copy(URL.Text, destinationPath);

                    }

                    string fileName = requiredDirectoryPath + @"\News\" + Guid.NewGuid().ToString() + ".txt";

                    StreamWriter sw = new StreamWriter(fileName);
                    sw.WriteLine(titleTB.Text + complexSeparator + descriptionTB.Text + complexSeparator + destinationPath + complexSeparator + id + complexSeparator + "p" + complexSeparator + body.Text);
                    sw.Flush();
                    sw.Close();
                    

                    this.Hide();
                    
                }
                else
                {

                    string[] files = File.ReadAllLines(oldPath);
                    string[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
                    files[0] = null;
                    //File.Delete(sep[2]);
                    string destinationPath = Path.Combine(requiredDirectoryPath + @"\Photos\", Path.GetFileName(URL.Text));
                    try { File.Copy(URL.Text, destinationPath); File.Delete(sep[2]); }
                    catch { }

                    StreamWriter sw = new StreamWriter(oldPath);
                    sw.WriteLine(titleTB.Text + complexSeparator + descriptionTB.Text + complexSeparator + destinationPath + complexSeparator + id + complexSeparator + "p" + complexSeparator + body.Text);
                    sw.Flush();
                    sw.Close();

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
