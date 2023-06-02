using Kingsman20.Windows.Add;
using Kingsman20.Windows.Edit;
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

namespace Kingsman20.Windows.Main
{
    /// <summary>
    /// Логика взаимодействия для EmployeesInfWindow.xaml
    /// </summary>
    public partial class EmployeesInfWindow : Window
    {
        public EmployeesInfWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvEmployees.ItemsSource = ClassHelper.EF.Context.Employee.ToList();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
            this.Close();
        }
        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button.DataContext as DataBase.Employee;


            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow();
            editEmployeeWindow.Show();

            GetListService();
        }
    }
}
