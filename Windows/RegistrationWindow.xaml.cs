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

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Gender";
            CmbGender.SelectedIndex = 0;
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbBithday.Text))
            {
                MessageBox.Show("Поле Дата рождения не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                MessageBox.Show("Поле Дата рождения не заполнено");
                return;
            }
            // добавление 
            DataBase.Client addClient = new DataBase.Client();
            addClient.Login = TbLogin.Text;
            addClient.Password = PbPassword.Password;
            addClient.FirstName = TbFirstName.Text;
            addClient.LastName = TbLastName.Text;
            addClient.Bithday = TbBithday.SelectedDate.Value;
            addClient.Phone = TbPhone.Text;
            addClient.IdGender = (CmbGender.SelectedItem as DataBase.Gender).IDGender;

            if (TbMiddleName.Text != string.Empty)
            {
                addClient.Patronymic = TbMiddleName.Text;
            }
            if (TbEmail.Text != string.Empty)
            {
                addClient.Email = TbEmail.Text;
            }
            if (TbTopSize.Text != string.Empty)
            {
                addClient.IdTopSIze = (TbTopSize.SelectedItem as DataBase.Size).IDSize;
            }
            if (TbBottomSize.Text != string.Empty)
            {
                addClient.IdBottomSize = (TbBottomSize.SelectedItem as DataBase.Size).IDSize;
            }
            if (TbBootsSize.Text != string.Empty)
            {
                addClient.BootsSize =  Convert.ToDecimal(TbBootsSize.Text);
            }


            ClassHelper.EF.Context.Client.Add(addClient);

            // сохранение
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен");


        }
        private void BtnAuth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
