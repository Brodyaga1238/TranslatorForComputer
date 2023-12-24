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
using GTranslate.Translators;

namespace TranslatorForComputer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? words = null;
        public MainWindow()
        {
            InitializeComponent();

        }
        private async Task Translate()
        {
            var translator = new YandexTranslator();
            words =  TranslateBox.Text;
            var result = await translator.TranslateAsync( words, "En");
            ResultBox.Text = result.Translation;
        }

        private async void ResultBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            await Translate();
        }
    }
}
