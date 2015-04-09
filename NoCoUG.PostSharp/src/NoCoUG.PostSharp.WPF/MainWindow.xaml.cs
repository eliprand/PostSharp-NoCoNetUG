using System.Windows;
using NoCoUG.PostSharp.WPF.ViewModels;
using PostSharp.Patterns.Model;

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

            _viewModel = new MainViewModel
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
}

namespace NoCoUG.PostSharp.WPF.ViewModels
{

    public class MainViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainViewModel2
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainViewModel3
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainViewModel4
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainViewModel5
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainViewModel6
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
