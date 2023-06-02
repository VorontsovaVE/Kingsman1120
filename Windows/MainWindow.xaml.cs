using Kingsman20.Windows.Main;
using Kingsman20.Windows;
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

namespace Kingsman20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientInfWindow clientInfWindow = new ClientInfWindow();
            clientInfWindow.Show();
            this.Close();
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesInfWindow employeesInfWindow = new EmployeesInfWindow();
            employeesInfWindow.Show();
            this.Close();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            this.Close();
        }
    }
}
