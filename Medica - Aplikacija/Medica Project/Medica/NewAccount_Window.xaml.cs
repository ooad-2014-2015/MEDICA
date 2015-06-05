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
using WebcamControl;
using Microsoft.Expression.Encoder.Devices;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using Medica.VM_klase;


namespace Medica
{
    
    public partial class NewAccount_Window : Window
    {
        MainWindow _main;

        public NewAccount_Window()
        {
            InitializeComponent();
        }

        public NewAccount_Window(MainWindow Main)
        {
            _main = Main; 
            InitializeComponent();                  
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            _main.Show();
            Close();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            NewAccount_VM.Register(this, _main);
        }

        private void Picture_Button_Click(object sender, RoutedEventArgs e)
        {
            Camera c = new Camera();
            Thread th = new Thread(new ThreadStart(c.startCamera));
            th.Start();
        }


    }

    public class Camera
    {
        public void startCamera()
        {
            Process pr = new Process();
            ProcessStartInfo prs = new ProcessStartInfo();
            //prs.FileName = @Environment.CurrentDirectory + @"\WebKamera\WebKamera\WebKamera\bin\Debug\WebKamera2";
            prs.FileName = @"C:\Users\Jarvis v2\Desktop\Medica - Aplikacija\Medica Project\WebKamera\WebKamera\WebKamera\bin\Debug\WebKamera";            
            pr.StartInfo = prs;
            pr.Start();
        }
    }


}
