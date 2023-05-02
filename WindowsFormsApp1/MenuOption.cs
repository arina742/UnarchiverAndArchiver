using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuOption : Form
    {
        public MenuOption()
        {
            InitializeComponent();
        }
        
        //view content
        private void button3_Click(object sender, EventArgs e)
        {
            Form dlg1 = new ViewContent();
            dlg1.ShowDialog(this);
        }

        //unzip folder
        private void button1_Click(object sender, EventArgs e)
        {
            Form dlg2 = new UnzipFolder();
            dlg2.ShowDialog(this);
        }


        //zip folder
        private void button2_Click(object sender, EventArgs e)
        {
            Form dlg3 = new ZipFolder();
            dlg3.ShowDialog(this);
        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}

