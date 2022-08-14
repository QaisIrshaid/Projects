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

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string path = Constants.GetDirectory() + @"\Users\";
            string[] entries = Directory.GetFileSystemEntries(path);

            foreach (string item in entries)
            {
                string[] file = File.ReadAllLines(item);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);

                if (objectAttributes[1] == txtBox_Username.Text && objectAttributes[2] == txtBox_Password.Text)
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
