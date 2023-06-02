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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedIndex = 0;

            CmbTopSize.ItemsSource = ClassHelper.EF.Context.Size.ToList();
            CmbTopSize.DisplayMemberPath = "Size1";
            CmbTopSize.SelectedIndex = 0;

            CmbBottomSize.ItemsSource = ClassHelper.EF.Context.Size.ToList();
            CmbBottomSize.DisplayMemberPath = "Size1";
            CmbBottomSize.SelectedIndex = 0;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLNameClient.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFNameClient.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbBirthday.Text))
            {
                MessageBox.Show("Поле Дата рождения не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhoneClient.Text))
            {
                MessageBox.Show("Поле телефон не заполнено");
                return;
            }
            // добавление 
            DataBase.Client addClient = new DataBase.Client();
            addClient.Login = TbLoginClient.Text;
            addClient.Password = TbPasswordClient.Text;
            addClient.FirstName = TbFNameClient.Text;
            addClient.LastName = TbLNameClient.Text;
            addClient.Bithday = TbBirthday.SelectedDate.Value;
            addClient.Phone = TbPhoneClient.Text;
            addClient.IdGender = (CmbGender.SelectedItem as DataBase.Gender).IDGender;

            if (TbPathClient.Text != string.Empty)
            {
                addClient.Patronymic = TbPathClient.Text;
            }
            if (TbEmailClient.Text != string.Empty)
            {
                addClient.Email = TbEmailClient.Text;
            }
            if (CmbTopSize.Text != string.Empty)
            {
                addClient.IdTopSIze = (CmbTopSize.SelectedItem as DataBase.Size).IDSize;
            }
            if (CmbBottomSize.Text != string.Empty)
            {
                addClient.IdBottomSize = (CmbBottomSize.SelectedItem as DataBase.Size).IDSize;
            }
            if (BootsSize.Text != string.Empty)
            {
                addClient.BootsSize = Convert.ToDecimal(BootsSize.Text);
            }


            MessageBox.Show("Сотрудник Добавлен", "Удачно!", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
