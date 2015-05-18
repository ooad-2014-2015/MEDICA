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

namespace MEDICA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // za dodavanje
            mydbEntities db = new mydbEntities();
            db.uposlenici.Add(new uposlenici() {});
            db.SaveChanges();

            // za pretragu
            var uposlenici = (from d in db.uposlenici where (TextBox == d.idUposlenici) select d).ToArray(); //.Single();
          
        }
    }
}
