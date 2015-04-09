using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NoCoUG.PostSharp.WPF.ViewModels;
using PostSharp.Aspects;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

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
                Name = "Eric",
                Age = 37
            };
            DataContext = _viewModel;
        }

        private async void Update(object sender, RoutedEventArgs e)
        {
            _viewModel.Name = await BuildName();
            _viewModel.Age = await CalculateAge();
        }

        [CacheMe]
        private async Task<string> BuildName()
        {
            await Task.Delay(5000);
            return "Mike";
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            _viewModel.Name = "Eric";
            _viewModel.Age = 37;
        }

        [CacheMe]
        private async Task<int> CalculateAge()
        {
            await Task.Delay(5000);
            return 2 + 3;
        }
    }

    [Serializable]
    internal class CacheMeAttribute : OnMethodBoundaryAspect
    {
        private object _cache = null;

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (_cache != null)
            {
                args.ReturnValue = _cache;
                args.FlowBehavior = FlowBehavior.Return;
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cache = args.ReturnValue;
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

}

