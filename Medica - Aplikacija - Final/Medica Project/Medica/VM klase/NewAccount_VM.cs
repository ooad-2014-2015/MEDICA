using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica.VM_klase
{
    public static class NewAccount_VM
    {
        public static void Register(NewAccount_Window acc, MainWindow main)
        {
            string name = acc.Name_TextBox.Text;
            string surname = acc.Surname_TextBox.Text;
            string Username = acc.Username_TextBox.Text;
            string Password = acc.Password_PasswordBox.Password;
            string repeat_password = acc.RepeatPassword_PasswordBox.Password;
            bool state = true;

            try
            {
                if (name == "" || surname == "" || Username == "" || Password == "" || repeat_password == "") throw new Exception();
            }
            catch (Exception)
            {
                acc.Name_TextBox.Text = "";
                acc.Surname_TextBox.Text = "";
                acc.Username_TextBox.Text = "";
                acc.Password_PasswordBox.Password = "";
                acc.RepeatPassword_PasswordBox.Password = "";
                state = false;
                System.Windows.MessageBox.Show("Provided data is not valid");
            }

            try
            {
                if (Password != repeat_password) throw new Exception();
            }
            catch (Exception)
            {
                acc.Password_PasswordBox.Password = "";
                acc.RepeatPassword_PasswordBox.Password = "";
                System.Windows.MessageBox.Show("Please check if inputed passwords are the same");
                state = false;
            }

            if (state) using (var db = new medicadbEntities())
                {
                    //Fali provjera da li neko sa istim usernameom vec postoji u bazi
                    try
                    {
                        var Pacijenti = db.Set<pacijenti>();
                        Pacijenti.Add(new pacijenti { ime = name, prezime = surname, password = Password, username = Username });
                        db.SaveChanges();

                        acc.Hide();
                        main.Show();
                        System.Windows.MessageBox.Show("You succesfully registered!");
                        acc.Close();

                    }
                    catch (Exception)
                    {
                        System.Windows.MessageBox.Show("Error occurred, please try again later");
                    }

                }
        }

    }
}
