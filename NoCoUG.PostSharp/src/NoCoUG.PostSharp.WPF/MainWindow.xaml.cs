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
    }

    public class MainViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
