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
using Microsoft.Expression.Encoder.Devices;
using WebcamControl;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Medica
{
    
    public partial class WebKamera : Window
    {
        public WebKamera()
        {
            InitializeComponent();

            Binding binding_1 = new Binding("SelectedValue");
            binding_1.Source = VideoDevicesComboBox;
            WebcamCtrl.SetBinding(Webcam.VideoDeviceProperty, binding_1);

            Binding binding_2 = new Binding("SelectedValue");
            binding_2.Source = AudioDevicesComboBox;
            WebcamCtrl.SetBinding(Webcam.AudioDeviceProperty, binding_2);

            
            

            // Kreiranje direktorija za spašavanje slika
            string slikaPut = @"C:\MedicaSlike";

            if (!Directory.Exists(slikaPut))
            {
                Directory.CreateDirectory(slikaPut);
            }


            WebcamCtrl.ImageDirectory = slikaPut;
            WebcamCtrl.FrameRate = 30;
            WebcamCtrl.FrameSize = new System.Drawing.Size(640, 480);

            // Ponalazak dostupnih audio i video uređaja
            var vidDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            var audDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
            VideoDevicesComboBox.ItemsSource = vidDevices;
            AudioDevicesComboBox.ItemsSource = audDevices;
            VideoDevicesComboBox.SelectedIndex = 0;
            AudioDevicesComboBox.SelectedIndex = 0;
        }

        private void ZapocniPrikaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Display webcam video
                WebcamCtrl.StartCapture();
            }
            catch (Microsoft.Expression.Encoder.SystemErrorException)
            {
                MessageBox.Show("Device is in use by another application");
            }

        }

        private void ZaustaviPrikaz_Click(object sender, RoutedEventArgs e)
        {
            // Stop the display of webcam video.
            WebcamCtrl.StopCapture();
        }

      
        private void Uslikaj_Click(object sender, RoutedEventArgs e)
        {
            WebcamCtrl.TakeSnapshot();
            System.Windows.MessageBox.Show("You took a picture");
        }
    }
}
