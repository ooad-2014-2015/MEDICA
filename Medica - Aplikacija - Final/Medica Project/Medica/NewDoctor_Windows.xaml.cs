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
using System.Diagnostics;
using System.Threading;
using Medica.VM_klase;

namespace Medica
{
    
    public partial class NewDoctor_Windows : Window
    {
        Admin_Window _admin;
        List<string> _names = new List<string>(); 

        public NewDoctor_Windows()
        {
            InitializeComponent();
        }

        public NewDoctor_Windows(Admin_Window Admin, ref List<string> Names)
        {
            _admin = Admin;
            _names = Names;
            InitializeComponent();
        }

        private void Picture_Button_Click(object sender, RoutedEventArgs e)
        {
            Camera c = new Camera();
            Thread th = new Thread(new ThreadStart(c.startCamera));
            th.Start();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _admin.Show();
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            NewDoctor_VM.AddDoctor(this, _admin, ref _names);
        }

        

    }

    

}
