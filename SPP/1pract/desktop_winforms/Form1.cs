using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.IO;

namespace desktop_winforms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient; 
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7180/");
        }

        public async Task getImage()
        {
            var imageBytes = await _httpClient.GetByteArrayAsync("https://localhost:7256/Image");

            using (var ms = new MemoryStream(imageBytes))
            {
                var image = Image.FromStream(ms);

                pictureBox.Invoke(new Action(() => pictureBox.Image = image));
            }
        }

        private void getImageButton_Click(object sender, EventArgs e)
        {
            getImage();
        }
    }
}
