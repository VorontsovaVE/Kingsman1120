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

namespace Kingsman20.Windows.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        DataBase.Employee editEmployee = null;

        private bool isEdit = false;

        public EditEmployeeWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditEmployeeWindow(DataBase.Employee employee )
        {
            InitializeComponent();

            isEdit =true;
            editEmployee = employee;

            //Заполнение должности 
            CmbPositEmp.ItemsSource = ClassHelper.EF.Context.Position.ToList();
            CmbPositEmp.DisplayMemberPath = "Title";

            //заполнение полей
            TbLNameEmp.Text = employee.LastName;
            TbFNameEmp.Text = employee.FirstName;
            TbPathEmp.Text = employee.Patronymic;
            TbPhoneEmp.Text = employee.Phone;
            TbLoginEmp.Text = employee.Login;
            TbPasswordEmp.Text = employee.Password;

            //заполнение должности
            CmbPositEmp.SelectedItem = ClassHelper.EF.Context.Position.Where(i => i.IDPosition == employee.IdPosition).FirstOrDefault();

        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            editEmployee.LastName = TbLNameEmp.Text;
            editEmployee.FirstName = TbFNameEmp.Text;
            editEmployee.Patronymic = TbPathEmp.Text;
            editEmployee.Phone = TbPhoneEmp.Text;
            editEmployee.Login = TbLoginEmp.Text;
            editEmployee.Password = TbPasswordEmp.Text;

            editEmployee.IdPosition = (CmbPositEmp.SelectedItem as DataBase.Position).IDPosition;

            ClassHelper.EF.Context.SaveChanges();
            
            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }
    }
}
