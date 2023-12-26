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
        string? words;
        public MainWindow()
        {
            InitializeComponent();

        }
        private async Task Translate()
        {
            var translator = new YandexTranslator();
            words =  TranslateBox.Text;
            if (words=="")
            {
                ResultBox.Text = "";
                return;
            }
            var result = await translator.TranslateAsync( words, "En");
            ResultBox.Text = result.Translation;
        }
     
        private async void TranslateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Translate();
        }
    }
}
