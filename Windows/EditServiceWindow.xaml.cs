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
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        DataBase.Service editService = null;

        private bool isEdit = false;

        public EditServiceWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditServiceWindow(DataBase.Service service)
        {
            InitializeComponent();

            isEdit = true;

            editService = service;

            // Заполнение типа услуги

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.TypeOfService.ToList();
            CmbTypeService.DisplayMemberPath = "Title";

            // выгрузка изображения 
            ImgImageService.Source = new BitmapImage(new Uri(service.Photo));

            // заполнение полей
            TbNameService.Text = service.Title;
            TbDiscService.Text = service.Discription;
            TbPriceService.Text = Convert.ToString(service.Price);

            // заполнение типа услуги
            CmbTypeService.SelectedItem = ClassHelper.EF.Context.TypeOfService.Where(i => i.IDTypeOfService == service.IdTypeIfService).FirstOrDefault();

        }


        private void BtnEditService_Click(object sender, RoutedEventArgs e)
        {
            editService.Title = TbNameService.Text;
            editService.Discription = TbDiscService.Text;
            editService.Price = Convert.ToDecimal(TbPriceService.Text);
            editService.IdTypeIfService = (CmbTypeService.SelectedItem as DataBase.TypeOfService).IDTypeOfService;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }
    }
}
