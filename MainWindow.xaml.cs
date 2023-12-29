
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GTranslate.Translators;

namespace TranslatorForComputer
{
    public class TranslateViewModel : INotifyPropertyChanged
    {
        private string? _words;
        public string Words
        {
            get { return _words; }
            set
            {
                if (_words != value)
                {
                    _words = value;
                    OnPropertyChanged(nameof(Words));
                    Translate();
                }
            }
        }

        private string? _translation;
        public string Translation
        {
            get { return _translation; }
            set
            {
                if (_translation != value)
                {
                    _translation = value;
                    OnPropertyChanged(nameof(Translation));
                }
            }
        }

        public async Task Translate()
        {
            var translator = new YandexTranslator();
            if (string.IsNullOrEmpty(Words))
            {
                Translation = null;
                return;
            }
            var result = await translator.TranslateAsync(Words, "En");
            Translation = result.Translation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


    public partial class MainWindow : Window
    {
        private readonly TranslateViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TranslateViewModel();
            DataContext = _viewModel;
        }
        private void TranslateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Translate();
        }

    }

}
