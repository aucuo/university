using lab4.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PassengerShip> Ships { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Ships = new ObservableCollection<PassengerShip>
            {
                new PassengerShip("Титаник", 52310, "Лайнер", new List<string> { "Стандарт", "Люкс" }),
                new PassengerShip("Лузитания", 31000, "Круизный Лайнер", new List<string> { "Эконом", "Бизнес", "Люкс" })
            };
        }

        private void ViewTableMenu_Click(object sender, RoutedEventArgs e)
        {
            ShipTableWindow tableWindow = new ShipTableWindow(Ships);
            tableWindow.Show();
        }
    }
}
