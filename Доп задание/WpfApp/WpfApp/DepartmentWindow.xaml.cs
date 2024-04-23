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
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        Entities db;
        public DepartmentWindow(Entities db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Department.Add(new Department
                {
                    Name = TextBoxDepartment.Text
                });
                db.SaveChanges();
                Close();
                MessageBox.Show($"Запись добавлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить отдел! - {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
