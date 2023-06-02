using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            SetListServise();
        }

        private void SetListServise()
        {
            ObservableCollection<DataBase.Service> listCart = new ObservableCollection<DataBase.Service>(ClassHelper.CartServiceClass.ServiceCart);
            LvCartService.ItemsSource = listCart.Distinct();

        }

        private void BtnRomoveToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service; // получаем выбранную запись

            ClassHelper.CartServiceClass.ServiceCart.Remove(service);

            SetListServise();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            if (ClassHelper.CartServiceClass.ServiceCart.Count != 0)
            {
                DataBase.Order newOrder = new DataBase.Order();

                if (ClassHelper.UserDataClass.Employee != null)
                {
                    newOrder.IdClient = 1;
                    newOrder.IdEmployee = ClassHelper.UserDataClass.Employee.IDEmployee;
                }
                else
                {
                    newOrder.IdClient = 1;
                    newOrder.IdEmployee = 1;
                }
                newOrder.StartTime = DateTime.Now;

                ClassHelper.EF.Context.Order.Add(newOrder);
                ClassHelper.EF.Context.SaveChanges();

                foreach (DataBase.Service item in ClassHelper.CartServiceClass.ServiceCart.Distinct())
                {
                    DataBase.OrderService newOrderService = new DataBase.OrderService();
                    newOrderService.IdOrder = newOrder.IDOrder;
                    newOrderService.IdService = item.IDService;
                    newOrderService.Quantity = item.Quantity;

                    ClassHelper.EF.Context.OrderService.Add(newOrderService);
                    ClassHelper.EF.Context.SaveChanges();
                }

                MessageBox.Show("Заказ успешно оформлен!");
            }
            else
            {
                MessageBox.Show("Корзина пуста");
            }

            this.Close();

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service;

            if (service.Quantity > 1)
            {
                service.Quantity--;
            }

            SetListServise();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service;

            if (service.Quantity < 10)
            {
                service.Quantity++;
            }

            SetListServise();
        }
    }
}
