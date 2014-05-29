using System.Windows;
using ReactiveUI;

namespace Ex5
{
    public partial class TitleBarView : IViewFor<TitleBarViewModel>
    {
        public TitleBarView()
        {
            InitializeComponent();

            //TODO: Add code to bind the Title on the VM to the Title in the view when the
            //      view is activated
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
