using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class FeedbackWindow_VM
    {

        public static void Konstruktor(ref string _username, Feedback_Window feedback, string Username, ref Patient_Window _patient, Patient_Window Patient)
        {
            _patient = Patient;
            _username = Username;
            string _username2 = _username;

            int idPacijenta = 0;
            List<int> ideviTretmana = new List<int>();
            using (var db = new medicadbEntities())
            {
                
                    //Pretraga id-a pacijenta 
                    idPacijenta = (from p in db.pacijenti where _username2 == p.username select p.idPacijenti).Single();
                    ideviTretmana = (from t in db.termini where t.Pacijenti_idPacijenti == idPacijenta && t.ocjenaTermina == null select t.idTermini).ToList();

                    foreach (int k in ideviTretmana)
                    {
                        //Feedback_ComboBox.Items.Add(k);

                        //Trazenje imena doktora na osnovu ida
                        int IDdoctor = (from t in db.termini where t.idTermini == k select t.Doktori_idDoktor).Single();
                        string doctor = (from d in db.doktori where d.idDoktori == IDdoctor select d.ime + " " + d.prezime).Single();

                        //Trazenje naziva tretmana na osnovu ida
                        int IDtretman = (from t in db.termini where t.idTermini == k select t.Tretmani_idTretmani).Single();
                        string tretman = (from t in db.tretmani where t.idTretmani == IDtretman select t.naziv).Single();

                        feedback.Feedback_ComboBox.Items.Add(k + " - " + doctor + " - " + tretman);
                    }


            }
        }

        public static void Cancel(Patient_Window patient, Feedback_Window feedback)
        {
            feedback.Hide();
            patient.Show();
            feedback.Close();
        }

        public static void Rate(Feedback_Window feedback)
        {
            string izabrano = feedback.Feedback_ComboBox.Text;
            string[] split = izabrano.Split(' ');
            int IDtretmana = int.Parse(split[0]);
            int ocjena = 5;

            if ((bool)feedback.Four_RadioButton.IsChecked) ocjena = 4;
            else if ((bool)feedback.Three_RadioButton.IsChecked) ocjena = 3;
            else if ((bool)feedback.Two_RadioButton.IsChecked) ocjena = 2;
            else if ((bool)feedback.One_RadioButton.IsChecked) ocjena = 1;

            using (var db = new medicadbEntities())
            {
                try
                {
                    var result = db.termini.SingleOrDefault(t => t.idTermini == IDtretmana);
                    if (result.ocjenaTermina != null) throw new Exception();
                    result.ocjenaTermina = ocjena;
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("You have successfully reviewed treatment!");
                }
                catch (Exception )
                {
                    System.Windows.MessageBox.Show("This treatment was already reviewed!");
                }

            }
        }

    }

}
