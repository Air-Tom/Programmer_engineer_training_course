using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itmo.CSDesktopApp.WinFormsLab_1
{
    public partial class nForm : Form
    {
        private bool nclose = false;

        public new void Close() 

        {
            nclose = true; 
            base.Close(); 
        }

        private void nForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nclose) return;

            e.Cancel = true;
            Hide();
        }

        public nForm()
        {
            InitializeComponent();
        }


        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}