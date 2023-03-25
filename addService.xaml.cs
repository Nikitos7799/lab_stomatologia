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
    /// Логика взаимодействия для addService.xaml
    /// </summary>
    public partial class addService : Window
    {
        // Подключаемся к БД
        stomatologiaDBEntities _db = new stomatologiaDBEntities();

        public addService()
        {
            InitializeComponent();
        }

        // Обработка сохранения новой услуги
        private void addServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из формы
            Service newService = new Service()
            {
                name = fieldName.Text.Trim(),
                price = Convert.ToString(fieldPrice.Text.Trim())
            };

            // Добавлям в БД и обновляем список услуг
            _db.Services.Add(newService);
            _db.SaveChanges();
            MainWindow.listServices.ItemsSource = _db.Services.ToList();
            this.Close();
        }
    }
}
