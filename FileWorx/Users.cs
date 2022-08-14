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

        public Users()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            string path = Constants.GetDirectory + @"\Users\";
            string[] entries = Directory.GetFileSystemEntries(path);


            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                FileInfo inf = new FileInfo(entries[i]);
                DateTime date = inf.CreationTime;

                string[] lastModifierObject = File.ReadAllLines(Constants.GetDirectory + @"\Users\" + objectAttributes[3]);
                string[] lastModifierAttributes = lastModifierObject[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);

                ListViewItem item1 = new ListViewItem(objectAttributes[0]);
                item1.Checked = true;
                item1.SubItems.Add(objectAttributes[1]);
                item1.SubItems.Add(lastModifierAttributes[0]);
                item1.SubItems.Add(date.ToString());
                listView1.Items.Add(item1);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
