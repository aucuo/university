using lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для ShipEntryWindow.xaml
    /// </summary>
    public partial class ShipEntryWindow : Window
    {
        public PassengerShip Ship { get; set; }

        public ShipEntryWindow(PassengerShip existingShip = null)
        {
            InitializeComponent();

            if (existingShip != null)
            {
                Ship = existingShip;
                NameTextBox.Text = Ship.Name;
                DisplacementTextBox.Text = Ship.Displacement.ToString();
                TypeTextBox.Text = Ship.Type;
                // Конвертируем список в строку, разделяя элементы запятыми
                CabinCategoriesTextBox.Text = string.Join(", ", Ship.CabinCategories);
                PhotoPathTextBox.Text = Ship.PhotoPath;
            }
            else
            {
                Ship = new PassengerShip();
            }
        }

        private void SelectPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                PhotoPathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void AddOrEditShipButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ship.Name = NameTextBox.Text;
                if (string.IsNullOrEmpty(Ship.Name))
                    throw new ArgumentException("Название не может быть пустым.");

                Ship.Displacement = double.Parse(DisplacementTextBox.Text);
                Ship.Type = TypeTextBox.Text;
                // Конвертируем строку в список, разделяя элементы запятой и удаляя пробелы
                Ship.CabinCategories = CabinCategoriesTextBox.Text.Split(',').Select(c => c.Trim()).ToList();
                Ship.PhotoPath = PhotoPathTextBox.Text;

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
