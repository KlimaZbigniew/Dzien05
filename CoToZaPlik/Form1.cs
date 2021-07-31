using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoToZaPlik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                label1.Text = ofd.FileName;
                lbInfo.Items.Clear();
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                lbInfo.Items.Add($"Nazwa: {fileInfo.Name}");
                lbInfo.Items.Add($"Czas kreacji: {fileInfo.CreationTime}");
                lbInfo.Items.Add($"Czas ostatniego dostępu: {fileInfo.LastAccessTime}");
                lbInfo.Items.Add($"Czas oststniej zmiany: {fileInfo.LastWriteTime}");




            
            

            }
        }
    }
}
