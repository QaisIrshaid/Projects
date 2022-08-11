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
    public partial class NewUser : Form
    {
        private String oldPath;
        private String id;
        private static string mainDirectoryPath = Directory.GetCurrentDirectory();

        //removing (/bin/debug) to get to FileWorx as the main folder.
        private String requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();

        private readonly string complexSeparator = "%%$$##";

        
        public NewUser(String id)
        {
            InitializeComponent();
            this.id = id;
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || loginName.Text == "" || password.Text == "")
                MessageBox.Show("Please fill all the arguments to proceed");
            else
            {
                if (oldPath == null)
                {
                    String fileName = requiredDirectoryPath + @"\Users\" + Guid.NewGuid().ToString() + ".txt";

                    StreamWriter sw = new StreamWriter(fileName);
                    sw.WriteLine(name.Text + complexSeparator + loginName.Text + complexSeparator + password.Text + complexSeparator + this.id);
                    sw.Flush();
                    sw.Close();

                    this.Hide();
                    
                }

                else
                {
                    StreamWriter sw = new StreamWriter(oldPath);
                    sw.WriteLine(name.Text + complexSeparator + loginName.Text + complexSeparator + password.Text + complexSeparator + this.id);
                    sw.Flush();
                    sw.Close();

                    this.Hide();
                    oldPath = null;
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        public void fill(String path)
        {
            
            path = requiredDirectoryPath + @"\Users\" + path;
            oldPath = path;

            String[] files = File.ReadAllLines(path);
            String[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

            name.Text = sep[0];
            loginName.Text = sep[1];
            password.Text = sep[2];
            this.ShowDialog();


        }
    }
}
