using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCalculator
{
    public class Form1 : Form
    {
        // Элементы интерфейса
        private Label numberLabel;
        private TextBox numberTextBox;
        private Label powerLabel;
        private TextBox powerTextBox;
        private Button calculateButton;
        private Label resultLabel;

        public Form1()
        {
            // Настройка формы
            this.Text = "Калькулятор Степеней";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeUI();
        }

        private void InitializeUI()
        {
            // Метка для ввода числа
            numberLabel = new Label
            {
                Text = "Введите число:",
                Location = new System.Drawing.Point(50, 30),
                AutoSize = true
            };
            this.Controls.Add(numberLabel);

            // Поле для ввода числа
            numberTextBox = new TextBox
            {
                Location = new System.Drawing.Point(180, 30),
                Width = 150
            };
            this.Controls.Add(numberTextBox);

            // Метка для ввода степени
            powerLabel = new Label
            {
                Text = "Введите степень:",
                Location = new System.Drawing.Point(50, 70),
                AutoSize = true
            };
            this.Controls.Add(powerLabel);

            // Поле для ввода степени
            powerTextBox = new TextBox
            {
                Location = new System.Drawing.Point(180, 70),
                Width = 150
            };
            this.Controls.Add(powerTextBox);

            // Кнопка для расчета
            calculateButton = new Button
            {
                Text = "Рассчитать",
                Location = new System.Drawing.Point(150, 120),
                Width = 100
            };
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);

            // Метка для вывода результата
            resultLabel = new Label
            {
                Text = "Результат: ",
                Location = new System.Drawing.Point(50, 170),
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };
            this.Controls.Add(resultLabel);
        }

        // Обработчик события нажатия кнопки
        private async void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                double number = double.Parse(numberTextBox.Text);
                int power = int.Parse(powerTextBox.Text);

                // Асинхронный расчет степени
                double result = await Task.Run(() => CalculatePower(number, power));

                // Выводим результат
                resultLabel.Text = $"Результат: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для расчета степени
        private double CalculatePower(double number, int power)
        {
            return Math.Pow(number, power);
        }
    }
}