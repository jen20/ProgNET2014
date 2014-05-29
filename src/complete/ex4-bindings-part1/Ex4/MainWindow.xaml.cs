using System.Windows;
using ReactiveUI;

namespace Ex4
{
    public partial class MainWindow : IViewFor<MainWindowModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.FirstName, v => v.FirstName.Text));
                d(this.Bind(ViewModel, vm => vm.LastName, v => v.LastName.Text));
                d(this.OneWayBind(ViewModel, vm => vm.ServerResult, v => v.ServerResult.Text));
                d(this.BindCommand(ViewModel, vm => vm.ChangeName, v => v.ChangeNameButton));
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
