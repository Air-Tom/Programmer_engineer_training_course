using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itmo.CSDesktopApp.WinFormsLab_1_5
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Добавление эллипса, вписанного в прямоугольную форму
            // заданной ширины и высоты
            System.Drawing.Drawing2D.GraphicsPath myPath =
                new System.Drawing.Drawing2D.GraphicsPath();          
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
