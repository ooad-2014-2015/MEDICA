using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class InfoWindow_VM
    {
        public static void Konstruktor(ref List<string> _doctors, Info_Window info, ref Patient_Window _patient, Patient_Window Patient)
        {
            _patient = Patient;
            using (var db = new medicadbEntities())
            {
               
                 _doctors = (from d in db.doktori select d.ime + " " + d.prezime).ToList();
                 info.Physician_ComboBox.ItemsSource = _doctors;               
                
            }
        }

        public static void Cancel(Patient_Window patient, Info_Window info)
        {
            info.Hide();
            patient.Show();
            info.Close();
        }

        public static void Preview(Info_Window info)
        {
            info.Specialized_ListBox.Items.Clear();
            info.Average_ListBox.Items.Clear();

            string doctor = info.Physician_ComboBox.Text;
            string specijalnost = "";
            List<int?> ocjene;
            double? prosjek = 0;
            int i = 0;


            //Trazenje id-a doktora na osnovu imena i prezimena
            int idDoctor = 0;
            string[] split = doctor.Split(' ');

            using (var db = new medicadbEntities())
            {
                try
                {
                    string x = split[0];
                    string y = split[1];
                    idDoctor = (from d in db.doktori where (x == d.ime.ToString() && y == d.prezime.ToString()) select d.idDoktori).Single();

                }
                catch (Exception )
                {
                    System.Windows.MessageBox.Show("Izuzetak");
                }

            }

            //Popunjavanje ListBoxa
            using (var db = new medicadbEntities())
            {
                try
                {
                    string x = split[0];
                    string y = split[1];
                    specijalnost = (from d in db.doktori where x == d.ime && y == d.prezime select d.specijalnost).Single();
                    info.Specialized_ListBox.Items.Add(specijalnost);
                }
                catch (Exception )
                {
                    System.Windows.MessageBox.Show("Izuzetak");
                }

                try
                {
                    ocjene = (from t in db.termini where t.Doktori_idDoktor == idDoctor select t.ocjenaTermina).ToList();
                    foreach (int? o in ocjene)
                    {
                        if (o != null && o != 0)
                        {
                            prosjek = prosjek + o;
                            i++;
                        }
                    }

                    prosjek = prosjek / i;

                    info.Average_ListBox.Items.Add(prosjek);

                }
                catch (Exception )
                {
                    System.Windows.MessageBox.Show("Izuzetak");
                }


            }
        }

    }

}
