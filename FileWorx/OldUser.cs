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
    public partial class OldUser : Form
    {
        private String id;
        private String oldPath;
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
        public OldUser(String id)
        {
            InitializeComponent();
            this.id= id;
            UpdateTextPosition();
        }

        private void OldUser_Load(object sender, EventArgs e)
        {

        }

        public void fill(String path)
        {
            this.Show();
            path = @"\git\Projects\FileWorx\Users\" + path; 
            oldPath = path;

            String[] files = File.ReadAllLines(path);
            String[] sep = files[0].Split('$');

            name.Text = sep[0];
            loginName.Text = sep[1];
            password.Text = sep[2];
            

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || loginName.Text == "" || password.Text == "" )
            { MessageBox.Show("Please fill all the arguments to proceed"); }

            else
            {
                StreamWriter sw = new StreamWriter(oldPath);
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
    }
}
