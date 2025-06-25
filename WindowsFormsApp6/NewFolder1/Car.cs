using System;

namespace CarListApp
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } // Марка автомобиля
        public string Manufacturer { get; set; } // Производитель
        public double PayloadCapacity { get; set; } // Грузоподъемность (в тоннах)
        public int YearOfManufacture { get; set; } // Год выпуска
        public DateTime RegistrationDate { get; set; } // Дата регистрации

        public override string ToString()
        {
            return Brand; // Для ListBox отображаем только марку
        }
    }
}