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
    
    public partial class Info_Window : Window
    {
        Patient_Window _patient;
        List<string> _doctors = new List<string>();

        public Info_Window()
        {
            InitializeComponent();
        }

        public Info_Window(Patient_Window Patient)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InfoWindow_VM.Konstruktor(ref _doctors, this, ref _patient, Patient);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow_VM.Cancel(_patient, this);
        }

        private void Preview_Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow_VM.Preview(this);
        }



    }

   



}
