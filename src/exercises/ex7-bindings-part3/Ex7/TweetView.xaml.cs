using System.Windows;
using ReactiveUI;

namespace Ex7
{
    public partial class TweetView : IViewFor<TweetViewModel>
    {
        public TweetView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                //TODO: Add code that binds the date to the TweetDate field with the format "dd-MMM HH:mm:ss"

                d(this.OneWayBind(ViewModel, vm => vm.UserHandle, v => v.UserHandle.Text));
                d(this.OneWayBind(ViewModel, vm => vm.Message, v => v.Message.Text));
            });
        }

        public static readonly DependencyProperty ViewModelProperty;

        static TweetView()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(TweetViewModel), typeof(TweetView));
        }

        public TweetViewModel ViewModel
        {
            get { return (TweetViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (TweetViewModel)value; }
        }
    }
}
