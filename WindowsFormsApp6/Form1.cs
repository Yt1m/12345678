using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarListApp
{
    public partial class Form1 : Form
    {
        private List<Car> cars = new List<Car>
        {
            // Ford
            new Car { Id = 1, Brand = "Ford", Manufacturer = "Ford Motor Company", PayloadCapacity = 4.5, YearOfManufacture = 2018, RegistrationDate = new DateTime(2021, 1, 15) },
            new Car { Id = 2, Brand = "Ford", Manufacturer = "Ford Motor Company", PayloadCapacity = 3.0, YearOfManufacture = 2019, RegistrationDate = new DateTime(2020, 5, 20) },

            // Volvo
            new Car { Id = 3, Brand = "Volvo", Manufacturer = "Volvo Group", PayloadCapacity = 5.0, YearOfManufacture = 2017, RegistrationDate = new DateTime(2019, 3, 10) },
            new Car { Id = 4, Brand = "Volvo", Manufacturer = "Volvo Group", PayloadCapacity = 2.5, YearOfManufacture = 2020, RegistrationDate = new DateTime(2022, 7, 5) },

            // Mercedes-Benz
            new Car { Id = 5, Brand = "Mercedes-Benz", Manufacturer = "Daimler AG", PayloadCapacity = 6.0, YearOfManufacture = 2016, RegistrationDate = new DateTime(2018, 11, 25) },
            new Car { Id = 6, Brand = "Mercedes-Benz", Manufacturer = "Daimler AG", PayloadCapacity = 3.5, YearOfManufacture = 2017, RegistrationDate = new DateTime(2019, 4, 15) },

            // Toyota
            new Car { Id = 7, Brand = "Toyota", Manufacturer = "Toyota Motor Corporation", PayloadCapacity = 3.5, YearOfManufacture = 2020, RegistrationDate = new DateTime(2022, 7, 5) },
            new Car { Id = 8, Brand = "Toyota", Manufacturer = "Toyota Motor Corporation", PayloadCapacity = 4.0, YearOfManufacture = 2019, RegistrationDate = new DateTime(2020, 10, 10) },

            // BMW
            new Car { Id = 9, Brand = "BMW", Manufacturer = "Bayerische Motoren Werke AG", PayloadCapacity = 6.0, YearOfManufacture = 2016, RegistrationDate = new DateTime(2018, 11, 25) },
            new Car { Id = 10, Brand = "BMW", Manufacturer = "Bayerische Motoren Werke AG", PayloadCapacity = 5.5, YearOfManufacture = 2018, RegistrationDate = new DateTime(2021, 3, 15) }
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Загрузка данных в ListBox при запуске формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Отображаем только уникальные марки автомобилей
            foreach (var brand in cars.Select(car => car.Brand).Distinct())
            {
                listBoxCars.Items.Add(brand);
            }
        }

        // Обработка изменения выбора в ListBox
        private void listBoxCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очищаем детальную информацию при выборе нового автомобиля
            richTextBoxDetails.Clear();
        }

        // Обработка кнопки "Показать"
        private void buttonShowDetails_Click(object sender, EventArgs e)
        {
            if (listBoxCars.SelectedItem == null)
            {
                MessageBox.Show("Выберите марку автомобиля из списка.");
                return;
            }

            string selectedBrand = listBoxCars.SelectedItem.ToString();

            // Фильтруем автомобили по выбранной марке и фильтру
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            var filteredCars = cars.Where(car =>
                car.Brand == selectedBrand &&
                car.RegistrationDate < oneYearAgo &&
                car.PayloadCapacity > 3
            ).ToList();

            if (filteredCars.Count > 0)
            {
                // Отображаем информацию о подходящих автомобилях
                StringBuilder details = new StringBuilder();
                foreach (var car in filteredCars)
                {
                    details.AppendLine($"Марка: {car.Brand}");
                    details.AppendLine($"Производитель: {car.Manufacturer}");
                    details.AppendLine($"Грузоподъемность: {car.PayloadCapacity} тонн");
                    details.AppendLine($"Год выпуска: {car.YearOfManufacture}");
                    details.AppendLine($"Дата регистрации: {car.RegistrationDate.ToShortDateString()}");
                    details.AppendLine(new string('-', 30)); // Разделитель между машинами
                }

                richTextBoxDetails.Text = details.ToString().TrimEnd(); // Удаляем лишний разделитель в конце
            }
            else
            {
                richTextBoxDetails.Text = "Нет подходящих машин.";
            }
        }
    }
}