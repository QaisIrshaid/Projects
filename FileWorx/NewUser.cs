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
        private String id;
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
        public NewUser(String id)
        {
            InitializeComponent();
            this.id = id;
            UpdateTextPosition();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || loginName.Text == "" || password.Text == "")
                MessageBox.Show("Please fill all the arguments to proceed");
            else
            {

                String fileName = @"\git\Projects\FileWorx\Users\" + Guid.NewGuid().ToString() + ".txt";

                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(name.Text + "$" + loginName.Text + "$" + password.Text + "$" + this.id);
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

        private void NewUser_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }
    }
}
