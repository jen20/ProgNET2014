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
                //TODO: Bind the Tweets collection to the ItemsSource of the Tweets ItemsControl on the view

                //TODO: Bind the RemoveTweet command to the RemoveTweet button

                //TODO: Show the LoadingIndicator only whilst the LoadTweets command is executing

                //TODO: Execute the LoadTweets command when we activate
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
