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
    public partial class Users : Form
    {
        private static string mainDirectoryPath = Directory.GetCurrentDirectory();

        //removing (/bin/debug) to get to FileWorx as the main folder.
        private String requiredDirectoryPath = Directory.GetParent(Directory.GetParent(mainDirectoryPath).ToString()).ToString();
        private readonly string complexSeparator = "%%$$##";
        public Users()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            String path = requiredDirectoryPath + @"\Users\";
            String[] items = Directory.GetFileSystemEntries(path);

            
            for (int i = 0; i < items.Length; i++)
            {

                String[] files = File.ReadAllLines(items[i]);
                String[] sep = files[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);
                FileInfo inf = new FileInfo(items[i]);
                DateTime dt = inf.CreationTime;

                String[] useId = File.ReadAllLines(requiredDirectoryPath + @"\Users\" + sep[3]);
                String[] sep2 = useId[0].Split(new string[] { complexSeparator }, StringSplitOptions.None);

                ListViewItem item1 = new ListViewItem(sep[0]);
                item1.Checked = true;
                item1.SubItems.Add(sep[1]);
                item1.SubItems.Add(sep2[0]);
                item1.SubItems.Add(dt.ToString());
                listView1.Items.Add(item1);

            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
