using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace WindowsFormsApp1
{
    public partial class ViewContent : Form
    {
        public ViewContent()
        {
            InitializeComponent();
            ZipManager.TreeView = treeView1;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZIP архив|*.zip";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = textBox3.Text;
            if (ZipManager.IsFileExist(path))
            {
                ZipManager.Open(path);
            }
            else
            {
                MessageBox.Show("файла не существует или неверно указан путь");
            }
        }
    }
}
