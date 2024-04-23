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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        Entities db;
        int mod = 0;
        Employee employee = null;
        public EmployeeWindow(Entities departmentsEntities)
        {
            InitializeComponent();
            db = departmentsEntities;
            ComboBoxDepartment.ItemsSource = db.Department.Local;
        }

        public EmployeeWindow(Entities departmentsEntities, Employee employee)
        {
            InitializeComponent();
            db = departmentsEntities;
            TextBoxFirstName.Text = employee.FirstName;
            TextBoxLastName.Text = employee.LastName;
            TextBoxSurName.Text = employee.SurName;
            ComboBoxDepartment.ItemsSource = db.Department.Local;
            ComboBoxDepartment.SelectedValue = employee.Department;
            Title = "Редактирование сотрудника";
            mod = 1;
            this.employee = employee;
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (mod == 0) addDataInDb();
            else editDataInDb();
            Close();
        }

        private void addDataInDb() 
        {
            try
            {
                db.Employee.Add(new Employee
                {
                    LastName = TextBoxLastName.Text,
                    FirstName = TextBoxFirstName.Text,
                    SurName = TextBoxSurName.Text,
                    Department = (Department)ComboBoxDepartment.SelectedItem
                });
                db.SaveChanges();
                MessageBox.Show($"Запись добавлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить сотрудника! - {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void editDataInDb() 
        {
            try
            {
                employee.LastName = TextBoxLastName.Text;
                employee.FirstName = TextBoxFirstName.Text;
                employee.SurName = TextBoxSurName.Text;
                employee.Department = (Department)ComboBoxDepartment.SelectedItem;
                db.SaveChanges();
                MessageBox.Show($"Запись изменена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить сотрудника! - {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
