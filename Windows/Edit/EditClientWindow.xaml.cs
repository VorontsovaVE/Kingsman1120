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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        DataBase.Client editClient = null;

        private bool isEdit = false;

        public EditClientWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditClientWindow(DataBase.Client client)
        {
            InitializeComponent();
            isEdit = true;
            editClient = client;

            //заполнение размера
            CmbTopSize.ItemsSource = ClassHelper.EF.Context.Size.ToList();
            CmbTopSize.DisplayMemberPath = "Size";

            CmbBottomSize.ItemsSource = ClassHelper.EF.Context.Size.ToList();
            CmbBottomSize.DisplayMemberPath = "Size";

            //заполнение гендера
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Name";

            //заполнение полей
            TbLNameClient.Text = client.LastName;
            TbFNameClient.Text = client.FirstName;
            TbPathClient.Text = client.Patronymic;
            TbPhoneClient.Text = client.Phone;
            TbEmailClient.Text = client.Email;
            TbPasswordClient.Text = client.Password;
            TbLoginClient.Text = client.Login;
            //TbBirthday.SelectedDate.Value = client.Bithday;

            if(TbBootsSize.Text != string.Empty)
            {
                 client.BootsSize = Convert.ToDecimal(TbBootsSize.Text);
            }

            //заполнение размера
            CmbTopSize.SelectedItem = ClassHelper.EF.Context.Size.Where(i => i.IDSize == client.IdTopSIze).FirstOrDefault();
            CmbBottomSize.SelectedItem = ClassHelper.EF.Context.Size.Where(i => i.IDSize == client.IdTopSIze).FirstOrDefault();

            //заполнение гендера
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.IDGender == client.IdGender).FirstOrDefault();
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
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
            if (TbBootsSize.Text != string.Empty)
            {
                addClient.BootsSize = Convert.ToDecimal(TbBootsSize.Text);
            }

            // сохранение
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }
    }
}
