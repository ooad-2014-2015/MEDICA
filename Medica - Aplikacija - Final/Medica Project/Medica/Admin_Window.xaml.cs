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
    

    public partial class Admin_Window : Window
    {
        MainWindow _main;
        List<string> _names = new List<string>();
        string _username;
        int idDoctor = 0;
        DateTime _treatmentDATE;

        public Admin_Window()
        {
            InitializeComponent();
        }

        public Admin_Window(MainWindow Main, string Username)
        {
            InitializeComponent();           
            AdminWindow_VM.Pomocna(ref _main, Main, ref _username, Username);
            AdminWindow_VM.Konstruktor(this, ref _names);    
        }

        private void LogOff_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow_VM.PomocnaDruga(_main, this);
        }   

        private void NewDoctor_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow_VM.NewDoctor(this, ref _names);
        }
   
        private void Preview_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow_VM.Preview(this, ref _treatmentDATE, ref idDoctor);
        }

        private void Wages_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Wages_Window wages = new Wages_Window(this);
            wages.Show();
        }

      


    }
}
