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
    public partial class NewNews : Form
    {
        private String oldPath;
        private String id;
        private readonly string complexSeparator = "%%$$##";

        private static string mainDirectoryPath = Directory.GetCurrentDirectory();
        //removing (/bin/debug) to get to FileWorx as the main folder.
        private String requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();

       
        public NewNews(String id)
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
            if (Title.Text == "" || descriptionTB.Text == "" || comboBox1.Text == "" || body.Text == "")
            { MessageBox.Show("Please fill all the arguments to proceed"); }
            else
            {
                if (oldPath == null)
                {
                    String fileName = requiredDirectoryPath + @"\News\" + Guid.NewGuid().ToString() + ".txt";
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.WriteLine(titleTB.Text + complexSeparator + descriptionTB.Text + complexSeparator + comboBox1.Text + complexSeparator + id + complexSeparator + "non" + complexSeparator + body.Text);
                    sw.Flush();
                    sw.Close();

                    this.Hide();
                    
                }
                else
                {
                    StreamWriter sw = new StreamWriter(oldPath);
                    sw.WriteLine(titleTB.Text + complexSeparator + descriptionTB.Text + complexSeparator + comboBox1.Text + complexSeparator + id + complexSeparator + "non" + complexSeparator + body.Text);
                    sw.Flush();
                    sw.Close();

                    this.Hide();
                    oldPath = null;
                    
                }
            }
        }

        public void fill(String path)
        {
            
            oldPath = path;
            String[] files = File.ReadAllLines(path);
            String[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

            titleTB.Text = sep[0];
            descriptionTB.Text = sep[1];
            comboBox1.Text = sep[2];
            body.Text = sep[5];

            int i = 1;
            while (i < files.Length)
            { body.Text += "\n" + files[i]; i++; }
            this.ShowDialog();

        }



        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
