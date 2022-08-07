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
        private String dir = Directory.GetCurrentDirectory().Split('b')[0];

        public Login()
        {
            InitializeComponent();
            UpdateTextPosition();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            String path = dir+@"Users\";
            String[] items = Directory.GetFileSystemEntries(path);
            foreach(String item in items)
            {
                
                String[] files = File.ReadAllLines(item);
                String[] sep = files[0].Split('$');
                if (sep[1]==loginName.Text && sep[2]==password.Text)
                    { FileWorx file = new FileWorx(Path.GetFileName(item)); file.Show();this.Hide();break; }    
                
            }
            warning.Text = "Wrong login name or password \n Please try again";

        }

        private void Login_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }
    }
}
