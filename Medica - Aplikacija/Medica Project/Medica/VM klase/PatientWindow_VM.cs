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

namespace Medica.VM_klase
{
    public static class PatientWindow_VM
    {
        public static void Konstruktor(ref List<string> _names, ref List<string> _treatments, Patient_Window patient, ref string _username, string Username)
        {
            _username = Username;
            using (var db = new medicadbEntities())
            {
     
                 _names = (from d in db.doktori select d.ime + " " + d.prezime).ToList();
                 _treatments = (from t in db.tretmani select t.naziv).ToList();

                patient.Doctor_ComboBox.ItemsSource = _names;
                patient.Treatment_ComboBox1.ItemsSource = _treatments;

            }
        }

        public static void Preview(ref  DateTime _treatmentDATE, int idDoctor, Patient_Window patient)
        {
            
            patient.Preview_ListBox.Items.Clear();

            string doctor = patient.Doctor_ComboBox.Text;
            string treatment = patient.Treatment_ComboBox1.Text;
            _treatmentDATE = patient.TreatmentDate_DateTimePicker.SelectedDate.Value;
            DateTime _treatmentDATE2 = _treatmentDATE;
            if (_treatmentDATE < DateTime.Now)
            {
                System.Windows.MessageBox.Show("Date is not valid");
                return;
            }

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
                    patient.Preview_ListBox.Items.Add("Free appointments for chosen physician");
                    patient.Preview_ListBox.Items.Add("--------------------------------------");


                    zauzeti = (from t in db.termini where t.Doktori_idDoktor == idDoctor && t.datumTermina == _treatmentDATE2 select t.idTermini).ToList();
                    foreach (int? i in zauzeti)
                    {
                        int? temp = (from t in db.termini where t.idTermini == i select t.satiTermina).Single();
                        sati_zauzeti.Add(temp);
                    }

                    for (int i = 9; i < 16; i++)
                    {
                        bool flag = false;

                        if (!flag)
                            foreach (int? k in sati_zauzeti)
                                if (k == i) flag = true;
                        if (!flag)
                            patient.Preview_ListBox.Items.Add(i + "-" + (i + 1));

                    }

                }
                catch (Exception )
                {
                    System.Windows.MessageBox.Show("Izuzetak");
                }

            }
        }

        public static void Pomocna(MainWindow _main, MainWindow Main)
        {
            _main = Main;
        }

        public static void PomocnaShow(MainWindow main, Patient_Window patient)
        {
            patient.Hide();
            main.Show();
            patient.Close();
        }

        public static void PomocnaFeedback(Patient_Window patient, string _username)
        {
            patient.Hide();
            Feedback_Window feedback = new Feedback_Window(patient, _username);
            feedback.Show();
        }

        public static void PomocnaInfo(Patient_Window patient)
        {
            patient.Hide();
            Info_Window info = new Info_Window(patient);
            info.Show();
        }

        public static void Schedule(Patient_Window patient, string _username, ref int idDoctor, DateTime _treatmentDATE)
        {
            string vrijeme = patient.Preview_ListBox.SelectedItem.ToString();
            string[] split = vrijeme.Split('-');
            string x = split[0];
            int idPacijent = 0;

            using (var db = new medicadbEntities())
            {
                try
                {
                    //trazenje ida pacijenta na osnovu username-a
                    idPacijent = (from p in db.pacijenti where p.username == _username select p.idPacijenti).Single();
                    
                    //trazenje ida tretmana
                    int Tretman = (from t in db.tretmani where t.naziv == patient.Treatment_ComboBox1.Text select t.idTretmani).Single();


                    string doctor = patient.Doctor_ComboBox.Text;                                   
                    string[] split2 = doctor.Split(' ');
                    string q = split2[0];
                    string w = split2[1];
                    idDoctor = (from d in db.doktori where (d.ime.ToString() == q && d.prezime.ToString() == w) select d.idDoktori).Single();
                    
                    termini temp = new termini
                    {
                        Pacijenti_idPacijenti = idPacijent,
                        Doktori_idDoktor = idDoctor,
                        datumTermina = _treatmentDATE,
                        satiTermina = int.Parse(x),
                        Tretmani_idTretmani = Tretman
                    };
                    
                    db.termini.Add(temp);                
                    db.SaveChanges();
                    patient.Preview_Button_Click(null, null);
                    System.Windows.MessageBox.Show("Appointment sheduled");
                    
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }


            }
        }

    }
}
