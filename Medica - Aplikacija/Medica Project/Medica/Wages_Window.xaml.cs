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
    
    public partial class Wages_Window : Window
    {
        Admin_Window _admin;

        public Wages_Window()
        {
            InitializeComponent();
        }

        public Wages_Window(Admin_Window Admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WagesWindow_VM.Pomocna(ref _admin, Admin);
            WagesWindow_VM.Konstruktor(this);                   
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            WagesWindow_VM.PomocnaDruga(ref _admin, this);
        }

        private void Pay_Button_Click(object sender, RoutedEventArgs e)
        {
            WagesWindow_VM.Pay();
        }


    }
}
