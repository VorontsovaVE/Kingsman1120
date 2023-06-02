using Kingsman20.DataBase;
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

namespace Kingsman20.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
            CmbPositEmp.ItemsSource = ClassHelper.EF.Context.Position.ToList();
            CmbPositEmp.DisplayMemberPath = "Title";
            CmbPositEmp.SelectedIndex = 0;
        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            //валидация 

            // добавление услуги
            DataBase.Employee employee = new DataBase.Employee();

            employee.LastName = TbLNameEmp.Text;
            employee.FirstName = TbLNameEmp.Text;
            employee.Patronymic = TbPathEmp.Text;
            employee.Phone = TbPhoneEmp.Text;
            employee.IdPosition = (CmbPositEmp.SelectedItem as DataBase.Position).IDPosition;
            employee.Login = TbLoginEmp.Text;
            employee.Password = TbPasswordEmp.Text;


            ClassHelper.EF.Context.Employee.Add(employee);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Сотрудник Добавлен", "Удачно!", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
       
    }
}
