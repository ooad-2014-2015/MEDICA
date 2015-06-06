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
using System.Diagnostics;
using System.Threading;

namespace Medica.VM_klase
{
    public static class AdminWindow_VM
    {
        public static void Konstruktor(Admin_Window admin, ref List<string> _names)
        {
            using (var db = new medicadbEntities())
            {

                _names = (from d in db.doktori select d.ime + " " + d.prezime).ToList();
                admin.Doctor_ComboBox.ItemsSource = _names;
            }
        }

        public static void Preview(Admin_Window admin, ref DateTime _treatmentDATE, ref int idDoctor)
        {
            admin.Treatments_ListBox.Items.Clear();           
            string doctor = admin.Doctor_ComboBox.Text;
            _treatmentDATE = admin.TreatmentDate_DateTimePicker.SelectedDate.Value;
            DateTime _treatmentDATE2 = _treatmentDATE;
            int idDoctor2 = idDoctor;
        

            //Trazenje id-a doktora na osnovu imena i prezimena

            string[] split = doctor.Split(' ');
            List<int> zauzeti = new List<int>();
            List<int?> sati_zauzeti = new List<int?>();

            using (var db = new medicadbEntities())
            {
                try
                {
                    string x = split[0];
                    string y = split[1];
                    idDoctor = (from d in db.doktori where (d.ime.ToString() == x && d.prezime.ToString() == y) select d.idDoktori).Single();
                    admin.Treatments_ListBox.Items.Add("Scheduled treatments for chosen physician");
                    admin.Treatments_ListBox.Items.Add("-----------------------------------------------");

                    int idPacijent = 0;
                    string imePacijent="";

                    zauzeti = (from t in db.termini where t.Doktori_idDoktor == idDoctor2 && t.datumTermina == _treatmentDATE2 select t.idTermini).ToList();     
              
                    foreach (int? i in zauzeti)
                    {
                        idPacijent = (from t in db.termini where t.idTermini == i select t.Pacijenti_idPacijenti).Single();
                        imePacijent = (from p in db.pacijenti where p.idPacijenti == idPacijent select p.ime + " " + p.prezime).Single();

                        int? temp = (from t in db.termini where t.idTermini == i select t.satiTermina).Single();

                        admin.Treatments_ListBox.Items.Add(temp + " - " + (temp + 1) + " - " + imePacijent);
                        //sati_zauzeti.Add(temp);
                    }

                   /* foreach (int? sat in sati_zauzeti)
                    {
                        //admin.Treatments_ListBox.Items.Add(sat + " - " + (sat + 1) + " - " + imePacijent);
                    }*/
                   // sati_zauzeti.Clear();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Izuzetak");
                }

            }
        }

        public static void Pomocna(ref MainWindow main, MainWindow Main, ref string _username, string Username)
        {
            _username = Username;
            main = Main;
        }

        public static void PomocnaDruga(MainWindow main, Admin_Window admin)
        {
            admin.Hide();
            main.Show();
            admin.Close();
        }

        public static void NewDoctor(Admin_Window admin, ref List<string> _names)
        {
            admin.Hide();
            NewDoctor_Windows doctor = new NewDoctor_Windows(admin, ref _names);
            doctor.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            doctor.Show();
        }

    }
}
