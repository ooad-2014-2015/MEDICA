using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class WagesWindow_VM
    {
        public static void Konstruktor(Wages_Window wages)
        {
            using (var db = new medicadbEntities())
            {
                List<int> doc = (from d in db.doktori select d.idDoktori).ToList();

                foreach (int dok in doc)
                {
                    float? prosjek = 0;
                    int i = 0;
                    List<int?> ocjene = (from t in db.termini where t.Doktori_idDoktor == dok select t.ocjenaTermina).ToList();
                    foreach (int? o in ocjene)
                    {
                        if (o != null && o != 0)
                        {
                            prosjek = prosjek + o;
                            i++;
                        }
                    }

                    prosjek = prosjek / i;

                    string popunjavanje = (from d in db.doktori where d.idDoktori == dok select d.ime + " " + d.prezime).Single();
                    if (i != 0)
                        popunjavanje = popunjavanje + " - 2000 + " + (prosjek * 300).ToString();
                    else
                        popunjavanje = popunjavanje + " - 2000 - No bonus";

                    wages.Wages_ListBox.Items.Add(popunjavanje);
                }
            }

        }

        public static void Pomocna(ref Admin_Window admin, Admin_Window Admin)
        {
            admin = Admin;
        }

        public static void PomocnaDruga(ref Admin_Window admin, Wages_Window wages)
        {
            wages.Hide();
            admin.Show();
            wages.Close();
        }

        public static void Pay()
        {
            System.Windows.MessageBox.Show("Pay module is not implemented");
        }

    }
}
