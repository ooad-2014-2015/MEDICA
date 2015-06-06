using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class NewDoctor_VM
    {
        public static void AddDoctor(NewDoctor_Windows doctor, Admin_Window _admin, ref List<string> _names)
        {
            string name = doctor.Name_TextBox.Text;
            string surname = doctor.Surname_TextBox.Text;
            string Username = doctor.Username_TextBox.Text;
            string Password = doctor.Password_PasswordBox.Password;
            string repeat_password = doctor.RepeatPassword_PasswordBox.Password;
            string Specijalnost = doctor.Specialized_TextBox.Text;
            bool state = true;

            try
            {
                if (name == "" || surname == "" || Username == "" || Password == "" || repeat_password == "" || Specijalnost == "") throw new Exception();
            }
            catch (Exception)
            {
                doctor.Name_TextBox.Text = "";
                doctor.Surname_TextBox.Text = "";
                doctor.Username_TextBox.Text = "";
                doctor.Password_PasswordBox.Password = "";
                doctor.RepeatPassword_PasswordBox.Password = "";
                doctor.Specialized_TextBox.Text = "";
                state = false;
                System.Windows.MessageBox.Show("Provided data is not valid");
            }

            try
            {
                if (Password != repeat_password) throw new Exception();
            }
            catch (Exception)
            {
                doctor.Password_PasswordBox.Password = "";
                doctor.RepeatPassword_PasswordBox.Password = "";
                System.Windows.MessageBox.Show("Please check if inputed passwords are the same");
                state = false;
            }

            if (state) using (var db = new medicadbEntities())
                {
                    //Fali provjera da li neko sa istim usernameom vec postoji u bazi
                    try
                    {
                        var Doktori = db.Set<doktori>();
                        Doktori.Add(new doktori { ime = name, prezime = surname, password = Password, username = Username, specijalnost = Specijalnost });
                        db.SaveChanges();

                        _names = (from d in db.doktori select d.ime + " " + d.prezime).ToList();
                        //_admin.Doctor_ComboBox.Items.Clear();
                        _admin.Doctor_ComboBox.ItemsSource = _names;

                        doctor.Hide();
                        _admin.Show();
                        System.Windows.MessageBox.Show("You succesfully registered!");
                        doctor.Close();

                    }
                    catch (Exception)
                    {
                        System.Windows.MessageBox.Show("Error occurred, please try again later");
                    }

                }
        }

    }
}
