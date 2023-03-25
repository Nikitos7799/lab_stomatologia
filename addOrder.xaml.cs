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

namespace lab_stomatologia
{
    /// <summary>
    /// Логика взаимодействия для addOrder.xaml
    /// </summary>
    public partial class addOrder : Window
    {
        // Подключаемся к БД
        stomatologiaDBEntities _db = new stomatologiaDBEntities();
        public addOrder()
        {
            InitializeComponent();

            // Добавляем в ComboBox список клиентов
            var clientsList = _db.Clients.ToList();

            // Добавляем элементы
            foreach (var client in clientsList)
            {
                comboboxClient.Items.Add(new ComboBoxItem
                {
                    Content = client.family + " " + client.name + " " + client.patronymic
                });
            }

            // Добавляем в ComboBox список услуг
            var servicesList = _db.Services.ToList();

            // Добавляем элементы
            foreach (var service in servicesList)
            {
                comboboxService.Items.Add(new ComboBoxItem
                {
                    Content = service.name + " " + service.price + " руб."
                });
            }

        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {

            // Получаем данные из формы
            Order newOrder = new Order()
            {
                client = comboboxClient.Text.Trim(),
                service = comboboxService.Text.Trim(),
                datetime = fieldDate.Text.Trim()
            };

            // Добавлям в БД и обновляем список услуг
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
            MainWindow.listOrders.ItemsSource = _db.Orders.ToList();
            this.Close();
        }
    }
}
