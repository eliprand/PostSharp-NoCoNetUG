using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NoCoUG.PostSharp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel()
            {
                Name = "Bob",
                Age = 37
            };
            DataContext = _viewModel;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            _viewModel.Name = "Mike";
            _viewModel.Age = 5;
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        public int Age
        {
            get { return _age; }
            set { SetValue(ref _age, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            field = value;
            OnPropertyChanged(name);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
    }

}
