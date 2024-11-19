using System;
using System.Windows;

namespace lab4
{
    public partial class ShipSearchWindow : Window
    {
        public string NameFilter { get; set; }
        public string TypeFilter { get; set; }
        public double? MinDisplacement { get; set; }
        public double? MaxDisplacement { get; set; }

        public ShipSearchWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем критерии поиска из текстовых полей
            NameFilter = NameTextBox.Text;
            TypeFilter = TypeTextBox.Text;

            // Попробуем получить минимальное водоизмещение
            if (double.TryParse(MinDisplacementTextBox.Text, out double minDisplacement))
            {
                MinDisplacement = minDisplacement;
            }
            else
            {
                MinDisplacement = null;
            }

            // Попробуем получить максимальное водоизмещение
            if (double.TryParse(MaxDisplacementTextBox.Text, out double maxDisplacement))
            {
                MaxDisplacement = maxDisplacement;
            }
            else
            {
                MaxDisplacement = null;
            }

            DialogResult = true; // Закрываем окно с положительным результатом
            Close();
        }
    }
}
