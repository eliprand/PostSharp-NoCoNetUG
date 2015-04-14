using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using NoCoUG.PostSharp.WPF.ViewModels;
using PostSharp;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace NoCoUG.PostSharp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel()
            {
                Name = "Eric",
                Age = 37
            };
            DataContext = _viewModel;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            _viewModel.Name = "Eric";
            _viewModel.Age = 37;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            _viewModel.Name = "Mike";
            _viewModel.Age = CalculateAge();
        }

        //[Retry(MaxRetries = 4)]
        [CacheMe]
        private int CalculateAge()
        {
            Thread.Sleep(3000);
            var age = Add(2,3);
            var age2 = Add(5, 3);    // if CompileTimeValidate() did its job, Add(a,b) is not cached
            return age2;
        }

        [CacheMe]   // this [CacheMe] attribute will be excluded with CompileTimeValidate()
        private int Add(int a, int b)
        {
            return a + b;
        }
    }

    [Serializable]
    internal class CacheMeAttribute : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(MethodBase method)
        {
            // check documentation here: http://doc.postsharp.net/aspect-validation

            if (method.GetParameters().Length > 0)
            {
                Message.Write(MessageLocation.Of(method), SeverityType.Error, "SE1234", "CacheMe attribute only on paramterless methods");
                return false;
            }
            return true;
        }

        /*
         * At runtime, pattern is:
         * OnEntry();
         * try
         * {
         *      ActualMethodCall()
         *      OnSuccess();
         * }
         * catch (Exception)
         * {
         *      OnException();
         * }
         * finally
         * {
         *      OnExit();
         * }
         */

        private object _cache;
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


    [Serializable]
    public class RetryAttribute : MethodInterceptionAspect
    {
        
        // See official example here: http://doc.postsharp.net/method-interception

        public int MaxRetries { get; set; }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var currentCount = 0;
            while (true)
            {
                try
                {
                    base.OnInvoke(args);
                    return;
                }
                catch (Exception)
                {
                    if (currentCount > MaxRetries)
                    {
                        throw;
                    }
                    currentCount++;
                }
            }
        }
    }


}

namespace NoCoUG.PostSharp.WPF.ViewModels
{
    //[NotifyPropertyChanged] // applied in AssemblyInfo.cs instead
    public class MainViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    //public class MainViewModel2
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //public class MainViewModel3
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //public class MainViewModel4
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //public class MainViewModel5
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //public class MainViewModel6
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}


}