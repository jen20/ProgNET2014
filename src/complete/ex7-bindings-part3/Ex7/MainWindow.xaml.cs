using System.Windows;
using ReactiveUI;

namespace Ex7
{
    public partial class MainWindow : IViewFor<MainWindowModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Tweets, v => v.Tweets.ItemsSource));
                d(this.BindCommand(ViewModel, vm => vm.RemoveTweet, v => v.RemoveTweet));

                d(ViewModel.WhenAnyObservable(vm => vm.LoadTweets.IsExecuting)
                    .BindTo(this, v => v.LoadingIndicator.Visibility));

                ViewModel.LoadTweets.Execute(null);
            });
        }

        public static readonly DependencyProperty ViewModelProperty;

        static MainWindow()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowModel), typeof(MainWindow));
        }

        public MainWindowModel ViewModel
        {
            get { return (MainWindowModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowModel)value; }
        }
    }
}
