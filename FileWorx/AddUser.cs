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
    public partial class AddUser : Form
    {
        private string oldPath;
        private string id;

        public AddUser(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || loginName.Text == "" || password.Text == "")
            {            
                MessageBox.Show("Please fill all the arguments to proceed");            
            }
            else
            {
                if (oldPath == null)
                {
                    string fileName = Constants.GetDirectory() + @"\Users\" + Guid.NewGuid().ToString() + ".txt";

                    StreamWriter streamWriter = new StreamWriter(fileName);
                    streamWriter.WriteLine(name.Text + Constants.ComplexSeparator() + loginName.Text + Constants.ComplexSeparator() + password.Text + Constants.ComplexSeparator() + this.id);
                    streamWriter.Flush();
                    streamWriter.Close();

                    this.Hide();
                }

                else
                {
                    StreamWriter streamWriter = new StreamWriter(oldPath);
                    streamWriter.WriteLine(name.Text + Constants.ComplexSeparator() + loginName.Text + Constants.ComplexSeparator() + password.Text + Constants.ComplexSeparator() + this.id);
                    streamWriter.Flush();
                    streamWriter.Close();

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
            
        }

        public void fill(string path)
        {
            path = Constants.GetDirectory() + @"\Users\" + path;
            oldPath = path;

            string[] file = File.ReadAllLines(path);
            string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator() }, StringSplitOptions.None);

            name.Text = objectAttributes[0];
            loginName.Text = objectAttributes[1];
            password.Text = objectAttributes[2];
            this.ShowDialog();
        }
    }
}
