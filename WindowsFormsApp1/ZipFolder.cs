using System;
using System.IO.Compression;
using Archive = System.IO.Compression.ZipFile;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class ZipFolder : Form
    {
        public ZipFolder()
        {
            InitializeComponent();
        }

        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog bd = new FolderBrowserDialog();
            if (bd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = bd.SelectedPath;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            
            if (ZipManager.IsFileExist(path))
            {
                ZipManager.Zip(path);
                Close();
            }
            else
            {
                MessageBox.Show("файла не существует или неверно указан путь");
            }
        }
    }
}