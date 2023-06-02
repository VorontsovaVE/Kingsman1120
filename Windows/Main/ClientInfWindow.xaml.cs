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
    /// Логика взаимодействия для ClientInfWindow.xaml
    /// </summary>
    public partial class ClientInfWindow : Window
    {
        public ClientInfWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvClient.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            this.Close();
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button.DataContext as DataBase.Client;


            EditClientWindow editClientWindow = new EditClientWindow();
            editClientWindow.Show();

            GetListService();
        }
    }
}
