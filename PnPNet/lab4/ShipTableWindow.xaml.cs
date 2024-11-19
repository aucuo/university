using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using lab4.Models;
using Microsoft.Win32;

namespace lab4
{
    public partial class ShipTableWindow : Window
    {
        // Используем одну коллекцию Ships для привязки и оригинального списка
        public ObservableCollection<PassengerShip> Ships { get; set; }

        public ShipTableWindow(ObservableCollection<PassengerShip> ships)
        {
            InitializeComponent();
            Ships = ships;  // Сохраняем переданную коллекцию
            dataGrid.ItemsSource = Ships;  // Привязываем к DataGrid
        }

        private void AddShipButton_Click(object sender, RoutedEventArgs e)
        {
            ShipEntryWindow entryWindow = new ShipEntryWindow();
            if (entryWindow.ShowDialog() == true)
            {
                Ships.Add(entryWindow.Ship);  // Добавляем новый объект в коллекцию
            }
        }

        private void DeleteShipButton_Click(object sender, RoutedEventArgs e)
        {
            PassengerShip selectedShip = (PassengerShip)dataGrid.SelectedItem;
            if (selectedShip != null)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить корабль '{selectedShip.Name}'?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Ships.Remove(selectedShip);  // Удаляем объект из коллекции
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите корабль для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditShipButton_Click(object sender, RoutedEventArgs e)
        {
            PassengerShip selectedShip = (PassengerShip)dataGrid.SelectedItem;
            if (selectedShip != null)
            {
                ShipEntryWindow entryWindow = new ShipEntryWindow(selectedShip);
                if (entryWindow.ShowDialog() == true)
                {
                    // После редактирования данные автоматически обновляются благодаря ObservableCollection
                    dataGrid.ItemsSource = null;  // Обнуляем источник данных
                    dataGrid.ItemsSource = Ships;  // Устанавливаем обновленную коллекцию
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите корабль для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SearchShipButton_Click(object sender, RoutedEventArgs e)
        {
            ShipSearchWindow searchWindow = new ShipSearchWindow();
            if (searchWindow.ShowDialog() == true)
            {
                var filteredShips = Ships.Where(ship =>
                    (string.IsNullOrEmpty(searchWindow.NameFilter) || ship.Name.Contains(searchWindow.NameFilter, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(searchWindow.TypeFilter) || ship.Type.Contains(searchWindow.TypeFilter, StringComparison.OrdinalIgnoreCase)) &&
                    (!searchWindow.MinDisplacement.HasValue || ship.Displacement >= searchWindow.MinDisplacement.Value) &&
                    (!searchWindow.MaxDisplacement.HasValue || ship.Displacement <= searchWindow.MaxDisplacement.Value)
                );

                dataGrid.ItemsSource = new ObservableCollection<PassengerShip>(filteredShips);  // Обновляем источник данных для фильтрации
            }
        }

        private void LoadFromFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var loadedShips = JsonSerializer.Deserialize<ObservableCollection<PassengerShip>>(json);

                    if (loadedShips != null)
                    {
                        Ships.Clear();
                        foreach (var ship in loadedShips)
                        {
                            ship.CreationDate = DateTime.Now;  // Устанавливаем дату создания на текущую для всех загруженных объектов
                            Ships.Add(ship);
                        }

                        dataGrid.ItemsSource = null;  // Обнуляем источник данных
                        dataGrid.ItemsSource = Ships;  // Устанавливаем обновленную коллекцию
                    }

                    MessageBox.Show("Данные успешно загружены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string json = JsonSerializer.Serialize(Ships);
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PassengerShip selectedShip = (PassengerShip)dataGrid.SelectedItem;
            if (selectedShip != null && !string.IsNullOrEmpty(selectedShip.PhotoPath))
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(selectedShip.PhotoPath, UriKind.Absolute));
                    ShipImage.Source = image;
                }
                catch
                {
                    ShipImage.Source = null;
                }
            }
            else
            {
                ShipImage.Source = null;
            }
        }
    }
}
