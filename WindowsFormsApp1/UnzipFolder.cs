using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UnzipFolder : Form
    {
        public UnzipFolder()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string file = textBox1.Text;
            string zipFile = textBox2.Text;
            int c = 0;
            if (ZipManager.IsFileExist(file))
            {
                c++;
                if (Directory.Exists(zipFile))
                {
                    c++;
                }
                else
                {
                    MessageBox.Show("каталога не существует или неверно указан путь");
                }
            }
            else
            {
                MessageBox.Show("файла не существует или неверно указан путь");
            }

            if (c == 2)
            {
                
                ZipManager.Unzip(file, zipFile);
                MessageBox.Show("Распаковка завершена");
            }

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bd = new FolderBrowserDialog();
            if (bd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = bd.SelectedPath;
            }
        }
        
    }
}