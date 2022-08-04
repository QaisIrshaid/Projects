﻿using System;
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
    public partial class OldNews : Form
    {
        private String oldPath;
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


        public OldNews(String id)
        {
            InitializeComponent();
            this.id = id;
            UpdateTextPosition();
        }



        private void Save_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" || descriptionTB.Text == "" || comboBox1.Text == "" || body.Text == "")
            { MessageBox.Show("Please fill all the arguments to proceed"); }
            else
            {
                StreamWriter sw = new StreamWriter(oldPath);
                sw.WriteLine(titleTB.Text + "$" + descriptionTB.Text + "$" + comboBox1.Text + "$" + id + "$" + "non" + "$" + body.Text);
                sw.Flush();
                sw.Close();

                this.Hide();
                FileWorx worx = new FileWorx(this.id);
                worx.Show();
            }
        }


        public void fill(String path)
        {
            this.Show();
            oldPath = path;
            String[] files = File.ReadAllLines(path);
            String[] sep = files[0].Split('$');

            titleTB.Text = sep[0];
            descriptionTB.Text = sep[1];
            comboBox1.Text = sep[2];
            body.Text = sep[5];

            int i = 1;
            while (i < files.Length)
            { body.Text += "\n" + files[i]; i++; }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileWorx worx = new FileWorx(this.id);
            worx.Show();
        }

        private void OldNews_Load(object sender, EventArgs e)
        {

        }
    }
}
