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
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace Client_desk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

        private async void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = new { Text = "Hello, World!" };
            var json = JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("api/Messages", content);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                txtResponse.Text = $"Server response: {responseBody}";
            }
            catch (HttpRequestException ex)
            {
                txtResponse.Text = $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                txtResponse.Text = $"Unexpected error: {ex.Message}";
            }
        }


        private async void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };

            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var fileName = openFileDialog.FileName;
                using var content = new MultipartFormDataContent();
                var fileStream = System.IO.File.OpenRead(fileName);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent, "file", System.IO.Path.GetFileName(fileName));

                try
                {
                    var response = await _httpClient.PostAsync("api/Images", content);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    txtResponse.Text = $"Response: {responseBody}";
                }
                catch (HttpRequestException ex)
                {
                    txtResponse.Text = $"Error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    txtResponse.Text = $"Unexpected error: {ex.Message}";
                }
            }
        }

        public class DataItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private async void BtnSendJson_Click(object sender, RoutedEventArgs e)
        {
                var dataItems = new List<DataItem>
                {
                    new DataItem { Id = 1, Name = "Sample Item" }
                };

                var json = JsonConvert.SerializeObject(dataItems);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await _httpClient.PostAsync("api/Data", content);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    txtResponse.Text = $"Response: {responseBody}";
                }
                catch (HttpRequestException ex)
                {
                    txtResponse.Text = $"Error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    txtResponse.Text = $"Unexpected error: {ex.Message}";
                }
            }
    }
}
