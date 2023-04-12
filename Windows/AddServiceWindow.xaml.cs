using Microsoft.Win32;
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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private string pathImage = null;
        public AddServiceWindow()
        {
            InitializeComponent();

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.TypeOfService.ToList();
            CmbTypeService.DisplayMemberPath = "Title";
            CmbTypeService.SelectedIndex = 0;
        }
        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

            //валидация 

            // добавление услуги
            DataBase.Service newService = new DataBase.Service();

            newService.Price = Convert.ToDecimal(TbPriceService.Text);
            newService.Title = TbNameService.Text;
            newService.Discription = TbDiscService.Text;
            newService.IdTypeIfService = (CmbTypeService.SelectedItem as DataBase.TypeOfService).IDTypeOfService;
            if (pathImage != null)
            {
                newService.Photo = pathImage;
            }

            ClassHelper.EF.Context.Service.Add(newService);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Услуга добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

    }
}
