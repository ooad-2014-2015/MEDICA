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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Medica.VM_klase;

namespace Medica
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_VM.Login(Username_TextBox.Text, Password_PasswordBox.Password, this);                                     
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewAccount_Button_Click(object sender, RoutedEventArgs e)
        {        
            MainWindow_VM.NewAcount(this);        
        }

        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_VM.Game();
        }









    }
}
