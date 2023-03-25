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
    /// Логика взаимодействия для editOrder.xaml
    /// </summary>
    public partial class editOrder : Window
    {
        // Подключаемся к БД
        stomatologiaDBEntities _db = new stomatologiaDBEntities();

        // Переменная ид услуги
        int Id = 0;
        public editOrder(int OrderId)
        {
            InitializeComponent();

            // Получаем значение переменной из таблицы
            Id = OrderId;
        }

        // Функция сохранения новых значений в БД с последующим обновлением таблицы
        private void editOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем значения в БД на значения из формы и сохраняем
            Order updateOrder = (from s in _db.Orders where s.id == Id select s).Single();
            updateOrder.client = comboboxClient.Text.Trim();
            updateOrder.service = comboboxService.Text.Trim();
            updateOrder.datetime = fieldDate.Text.Trim();
            _db.SaveChanges();

            // Обновляем таблицу и закрываем форму
            MainWindow.listOrders.ItemsSource = _db.Orders.ToList();
            this.Close();
        }
    }
}
