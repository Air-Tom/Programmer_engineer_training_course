using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;




namespace CSApp.WPF.Example1.WpfHello
{
    /// <summary>
    /// Логика взаимодействия для MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {

     

        MainWindow wnd1 = null;

        private bool _close;
        public MyWindow()
        {
            InitializeComponent();           
        }
        private void PrintLogFile()
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\Users\\User\\source\\repos\\WPF\\CSApp.WPF.Example1.WpfHello\\log.txt", true))
            {
                writer.WriteLine("Внесено {0}; {1} ", textBox.Text, DateTime.Now.ToShortDateString() + ", Время: " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
        }

        public new void Close() 
        { 
            _close = true; 
            base.Close(); 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close) return; 
            e.Cancel = true; 
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\Users\\User\\source\\repos\\WPF\\CSApp.WPF.Example1.WpfHello\\log.txt", true))
            {
                writer.WriteLine("Внесено {0}: {1} ", textBox.Text, DateTime.Now.ToShortDateString() + ", время: " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            wnd1 = Owner as MainWindow;
            if (wnd1 != null && listBox1.SelectedItem is Student Student)
            {
                wnd1.txtBlock.Text = textBox.Text;
                string Stud = Student.FullStudentData;
                wnd1.txtBlock.Text = $"Студент: {Stud}";
            }
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            wnd1.myWin = null;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
