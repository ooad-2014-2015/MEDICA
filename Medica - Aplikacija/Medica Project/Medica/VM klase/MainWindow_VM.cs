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

    public static class MainWindow_VM
    {
        public static void Login(string username, string password, MainWindow main)
        {
            using (var db = new medicadbEntities())
            {
                string upit;
                //Upit iz baze pacijenata
                try
                {
                    upit = (from p in db.pacijenti where p.username == username select p.password).Single();

                    if (password == upit)
                    {
                        Patient_Window patient = new Patient_Window(main, username);
                        main.Hide();
                        patient.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        patient.Show();
                        main.Username_TextBox.Text = "";
                        main.Password_PasswordBox.Password = "";

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Invalid login information!");
                        main.Username_TextBox.Text = "";
                        main.Password_PasswordBox.Password = "";
                    }
                    
                }

                catch (Exception )
                {

                    //Upit iz baze doktora
                    try
                    {
                        upit = (from d in db.doktori where d.username == username select d.password).Single();

                        if (password == upit)
                        {
                            Doctor_Window doctor = new Doctor_Window(main, username);
                            main.Hide();
                            doctor.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            doctor.Show();
                            main.Username_TextBox.Text = "";
                            main.Password_PasswordBox.Password = "";
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Invalid login information!");
                            main.Username_TextBox.Text = "";
                            main.Password_PasswordBox.Password = "";
                        }

                    }

                    catch (Exception)
                    {

                        try
                        {
                            upit = (from a in db.administracija where a.username == username select a.password).Single();

                            if (password == upit)
                            {
                                Admin_Window admin = new Admin_Window(main, username);
                                main.Hide();
                                admin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                admin.Show();
                                main.Username_TextBox.Text = "";
                                main.Password_PasswordBox.Password = "";
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Invalid login information!");
                                main.Username_TextBox.Text = "";
                                main.Password_PasswordBox.Password = "";
                            }

                        }

                        catch (Exception)
                        {
                            System.Windows.MessageBox.Show("Invalid login information!");
                            main.Username_TextBox.Text = "";
                            main.Password_PasswordBox.Password = "";
                        }

                    }
                   
                }                     
                
            }
        }

        public static void NewAcount(MainWindow main)
        {
            main.Hide();
            main.Username_TextBox.Text = "";
            main.Password_PasswordBox.Password = "";
            NewAccount_Window account = new NewAccount_Window(main);
            account.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            account.Show();
        }

        public static void Game()
        {
            Game g = new Game();
            Thread th = new Thread(new ThreadStart(g.startGame));
            th.Start();
        }
    }

    public class Game
    {
        public void startGame()
        {

            Process pr = new Process();
            ProcessStartInfo prs = new ProcessStartInfo();
            prs.FileName = @"C:\Users\Jarvis v2\Desktop\Medica - Aplikacija\Medica Project\Game\MEDICA-labirinth";
            pr.StartInfo = prs;
            pr.Start();

        }
    }

}
