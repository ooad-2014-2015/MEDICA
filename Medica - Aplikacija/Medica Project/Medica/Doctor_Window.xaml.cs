using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Medica.VM_klase;

namespace Medica
{
   
    public partial class Doctor_Window : Window
    {
        MainWindow _main;
        string _username;

        public Doctor_Window(MainWindow main, string username)
        {
            _main = main;
            _username = username;
            InitializeComponent();
        }

        private void Preview_Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow_VM.Preview(this, _username);
        }

        private void LogOff_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _main.Show();
            this.Close();
        }




    }
}
