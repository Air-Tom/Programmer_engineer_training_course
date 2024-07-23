using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itmo.CSDesktopApp.WinFormsLab_1_5_2
{
    public partial class StartingForm : Form
    {
        MainForm myF;

        public StartingForm()
        {
            InitializeComponent();
            myF = new MainForm();
            // Разворот формы по максимуму

            this.WindowState = FormWindowState.Maximized; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myF.Show();
                myF.Activate();
            }
            catch (ObjectDisposedException ex)
            {
                myF = new MainForm();
                myF.Text = "MainForm";
                myF.Show();
                myF.Activate();
            }

            myF.StartPosition = FormStartPosition.Manual;         
            myF.Show();
        }
    }
}
