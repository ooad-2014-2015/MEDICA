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
    
    public partial class Feedback_Window : Window
    {
        Patient_Window _patient;
        string _username;

        public Feedback_Window()
        {
            InitializeComponent();
        }

        public Feedback_Window(Patient_Window Patient, string Username)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            FeedbackWindow_VM.Konstruktor(ref _username, this, Username, ref _patient, Patient);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow_VM.Cancel(_patient, this);
        }

        private void Rate_Button_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow_VM.Rate(this);
        }



    }
}
