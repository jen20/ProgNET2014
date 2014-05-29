using System.Windows;
using ReactiveUI;

namespace Ex5
{
    public partial class TitleBarView : IViewFor<TitleBarViewModel>
    {
        public TitleBarView()
        {
            InitializeComponent();

            this.WhenActivated(d => d(this.OneWayBind(ViewModel, vm => vm.Title, v => v.Title.Text)));
        }

        public static readonly DependencyProperty ViewModelProperty;

        static TitleBarView()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(TitleBarViewModel), typeof(TitleBarView));
        }

        public TitleBarViewModel ViewModel
        {
            get { return (TitleBarViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (TitleBarViewModel)value; }
        }
    }
}
