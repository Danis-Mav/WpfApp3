using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для security_page.xaml
    /// </summary>
    

    public partial class security_page : Page

     
    {
        public static ObservableCollection<employee> emp { get; set; }

        public static ObservableCollection<Fine> fin { get; set; }

        public static ObservableCollection<Arrival> arr { get; set; }

        int i { get; set; }

        public static ObservableCollection<employee> empl { get; set; }
        public static ObservableCollection<Arrival> arri { get; set; }
        public static IEnumerable<employee> empls { get; set; }

        public security_page()
        {
            InitializeComponent();
            emp = new ObservableCollection<employee>(bd_connection.connection.employee.ToList());
            this.DataContext = this;
            fin = new ObservableCollection<Fine>(bd_connection.connection.Fine.ToList());
            arr = new ObservableCollection<Arrival>(bd_connection.connection.Arrival.ToList());
            empl = new ObservableCollection<employee>(bd_connection.connection.employee.ToList());
            arri = new ObservableCollection<Arrival>(bd_connection.connection.Arrival.ToList());
            this.DataContext = this;
            empls = empl.Where(a => a.Works == false).ToList();
                    
        }

        private void ClickAdd(object sender, RoutedEventArgs e)
        {
            DateTime normal = new DateTime(2021, 11, 08, 8, 00, 00);
            DateTime enter = DateTime.Now;
            var em = listView_Employee.SelectedItem as employee;
            int late = (enter.Hour * 60 - normal.Hour * 60) + (enter.Minute - normal.Minute);
            var s = new Arrival();
            var emp = new employee();
            var ep = bd_connection.connection.employee.Where(a => a.id_emp == em.id_emp).FirstOrDefault();
            s.IdEmployee = em.id_emp;
            s.ArrivalTime = DateTime.Now;

            if (late >= 10 && late < 30)
            {
                s.idFine = 1;
                ep.Balance -= 500;
                //bd_connection.connection.SaveChanges();
            }

            else if (late == 30)
            {
                s.idFine = 2;
                ep.Balance -= 1000;
                //bd_connection.connection.SaveChanges();
            }

            else if (late > 30)
            {
                s.idFine = 3;
                ep.Balance -= 2000;
                //bd_connection.connection.SaveChanges();
            }

            else
            {
                s.idFine = null;
                //bd_connection.connection.SaveChanges();
            }
            bd_connection.connection.Arrival.Add(s);
            bd_connection.connection.SaveChanges();

            if (late > 0)
            {
                MessageBox.Show($"Сотрудник {em.Name }      Вошёл с опозданием {late} минут        БАЛАНС: {ep.Balance}");
            }

            else
            {
                MessageBox.Show($"Сотрудник {em.Name } вошёл без опоздания ");
            }
        }
    }
}
