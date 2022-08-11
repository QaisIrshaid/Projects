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
    public partial class Login : Form
    {
        private static string mainDirectoryPath = Directory.GetCurrentDirectory();

        //removing (/bin/debug) to get to FileWorx as the main folder.
        private static string requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();

        private readonly string complexSeparator = "%%$$##";
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string path = requiredDirectoryPath + @"\Users\";
            string[] entries = Directory.GetFileSystemEntries(path);

            foreach (string item in entries)
            {
                string[] file = File.ReadAllLines(item);
                string[] attributes = file[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

                if (attributes[1] == txtBox_Username.Text && attributes[2] == txtBox_Password.Text)
                {

                    FileWorx fileWorx = new FileWorx(Path.GetFileName(item));
                    fileWorx.Show();
                    this.Hide();
                    break;

                }

            }

            warning.Text = "Wrong login name or password \n Please try again";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
