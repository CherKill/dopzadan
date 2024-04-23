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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities db;
        public MainWindow()
        {
            InitializeComponent();
  
            db = new Entities();
            dataGridEmployees.ItemsSource = db.Employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(db);
            employeeWindow.ShowDialog();
            dataGridEmployees.ItemsSource = db.Employee.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Employee employee = (sender as Button).Tag as Employee;

            if (employee != null)
            {
                db.Employee.Remove(employee);
                db.SaveChanges();
                dataGridEmployees.ItemsSource = db.Employee.ToList();
            }
        }

        private void DataGridEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid != null)
            {
                Employee employee = grid.SelectedItem as Employee;
                if (employee != null)
                {
                    EmployeeWindow window = new EmployeeWindow(db, employee);
                    window.ShowDialog();
                    dataGridEmployees.ItemsSource = db.Employee.ToList();
                }
            }
        }

        private void ButtonAddDepartament_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow(db);
            departmentWindow.ShowDialog();
        }
    }
}
