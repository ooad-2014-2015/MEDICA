using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class DoctorWindow_VM
    {

        public static void Preview(Doctor_Window doctor, string username)
        {
            doctor.Treatments_ListBox.Items.Clear();
            DateTime datum = doctor.Date_DatePicker.SelectedDate.Value;
            using (var db = new medicadbEntities())
            {
                int idDoctor = (from d in db.doktori where d.username == username select d.idDoktori).Single();

                List<int> termini = (from t in db.termini where t.Doktori_idDoktor == idDoctor && t.datumTermina == datum select t.idTermini).ToList();

                foreach (int ter in termini)
                {
                    int idPacijent = (from t in db.termini where t.idTermini == ter select t.Pacijenti_idPacijenti).Single();
                    string imePacijent = (from p in db.pacijenti where p.idPacijenti == idPacijent select p.ime + " " + p.prezime).Single();
                    int? sati = (from t in db.termini where t.idTermini == ter select t.satiTermina).Single();

                    doctor.Treatments_ListBox.Items.Add(sati.ToString() + " - " + (sati+1).ToString() + "  " + imePacijent);
                }

            }

        }



    }


}
