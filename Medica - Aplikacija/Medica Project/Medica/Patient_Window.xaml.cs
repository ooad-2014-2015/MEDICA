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
using MySql.Data.MySqlClient;
using Medica.VM_klase;

namespace Medica
{
    
    public partial class Patient_Window : Window
    {
        //Pomocni atributi
        MainWindow _main;
        List<string> _names = new List<string>();
        List<string> _treatments = new List<string>();
        DateTime _treatmentDATE;
        string _username;
        int idDoctor = 0;


        public Patient_Window()
        {
            InitializeComponent();
        }

        public Patient_Window(MainWindow Main)
        {
            InitializeComponent();
            PatientWindow_VM.Pomocna(_main, Main);
        }

        public Patient_Window(MainWindow Main, string Username)
        {
            InitializeComponent();
            _main = Main;
            PatientWindow_VM.Konstruktor(ref _names, ref _treatments, this, ref _username, Username);                     
        }

        private void LogOff_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow_VM.PomocnaShow(_main, this);
        }

        public void Preview_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow_VM.Preview(ref _treatmentDATE, idDoctor, this);
        }

        private void Feedback_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow_VM.PomocnaFeedback(this, _username);
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow_VM.PomocnaInfo(this);
        }

        private void Schedule_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow_VM.Schedule(this, _username, ref idDoctor, _treatmentDATE);
        }


    }
}
