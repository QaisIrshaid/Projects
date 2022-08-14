using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FileWorx
{
    public partial class AddNews : Form
    {
        private string oldPath;
        private string id;

        public AddNews(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void NewNews_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            if (titleLbl.Text == "" || descriptionTB.Text == "" || categoryComboBox.Text == "" || body.Text == "")
            { 
                MessageBox.Show("Please Fill all the arguments to proceed");
            }

            else
            {
                if (oldPath == null)
                {
                    //if oldPath is null then create a new file.

                    string fileName = Constants.GetDirectory + @"\News\" + Guid.NewGuid().ToString() + ".txt";
                    StreamWriter streamWriter = new StreamWriter(fileName);
                    streamWriter.WriteLine(titleTB.Text + Constants.ComplexSeparator + descriptionTB.Text + Constants.ComplexSeparator + categoryComboBox.Text + Constants.ComplexSeparator + id + Constants.ComplexSeparator + Constants.NewsFlag + Constants.ComplexSeparator + body.Text);
                    streamWriter.Flush();
                    streamWriter.Close();

                    this.Hide();
                }

                else
                {
                    //if oldPath has a value then write on the same file.

                    StreamWriter streamWriter = new StreamWriter(oldPath);
                    streamWriter.WriteLine(titleTB.Text + Constants.ComplexSeparator + descriptionTB.Text + Constants.ComplexSeparator + categoryComboBox.Text + Constants.ComplexSeparator + id + Constants.ComplexSeparator + Constants.NewsFlag + Constants.ComplexSeparator + body.Text);
                    streamWriter.Flush();
                    streamWriter.Close();

                    this.Hide();
                    oldPath = null;
                }
            }
        }

        public void Fill(string path)
        {
            oldPath = path;
            String[] file = File.ReadAllLines(path);
            String[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);

            titleTB.Text = objectAttributes[0];
            descriptionTB.Text = objectAttributes[1];
            categoryComboBox.Text = objectAttributes[2];
            body.Text = objectAttributes[5];

            int i = 1;
            while (i < file.Length)
            { 
                body.Text += "\n" + file[i];
                i++;
            }

            this.ShowDialog();
        }



        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
