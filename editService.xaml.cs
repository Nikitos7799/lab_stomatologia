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
    /// Логика взаимодействия для editService.xaml
    /// </summary>
    public partial class editService : Window
    {
        // Подключаемся к БД
        stomatologiaDBEntities _db = new stomatologiaDBEntities();

        // Переменная ид услуги
        int Id = 0;

        public editService(int ServiceId)
        {
            InitializeComponent();

            // Получаем значение переменной из таблицы
            Id = ServiceId;
        }

        // Функция сохранения новых значений в БД с последующим обновлением таблицы
        private void editServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем значения в БД на значения из формы и сохраняем
            Service updateService = (from s in _db.Services where s.id == Id select s).Single();
            updateService.name = fieldName.Text.Trim();
            updateService.price = Convert.ToString(fieldPrice.Text.Trim());
            _db.SaveChanges();

            // Обновляем таблицу и закрываем форму
            MainWindow.listServices.ItemsSource = _db.Services.ToList();
            this.Close();
        }
    }
}
