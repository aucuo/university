using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для TextEditorWindow.xaml
    /// </summary>
    public partial class TextEditorWindow : Window
    {
        public TextEditorWindow(string content = "")
        {
            InitializeComponent();
            textBox.Text = content;
        }

        public string GetContent()
        {
            return textBox.Text;
        }
    }
}
