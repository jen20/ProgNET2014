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
                //TODO: Add further code to bind LastName on the VM to the LastName field in the view
                //TODO: Add further code to one-way bind ServerResult on the VM to the ServerResult field in the view
                //TODO: Add further code to bind the ChangeName command on the VM to the ChangeNameButton on the view
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
