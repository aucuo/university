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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient; 
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7180/");
        }

        public async Task getImage()
        {
            var imageBytes = await _httpClient.GetByteArrayAsync("https://localhost:7256/Image");
            var message = $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = new MemoryStream(Convert.FromBase64String(message.Substring(message.IndexOf(',') + 1)));
            imageSource.EndInit();

            img.Source = imageSource;
        }


        private void btnGetImage_Click(object sender, RoutedEventArgs e)
        {
            getImage();
            
        }
    }
}
