using System.Windows;
using ReactiveUI;

namespace Ex9
{
    public partial class TestView : IViewFor<TestViewModel>
    {
        public TestView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Id, v => v.Id.Text));
                d(this.OneWayBind(ViewModel, vm => vm.Name, v => v.NameTextView.Text));
                d(this.Bind(ViewModel, vm => vm.OtherValue, v => v.OtherValue.Text));
                d(this.BindCommand(ViewModel, vm => vm.DoStuffWithThisCommand, v => v.DoStuffButton, () => ViewModel));
            });
        }

        public static readonly DependencyProperty ViewModelProperty;

        static TestView()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(TestViewModel), typeof(TestView));
        }

        public TestViewModel ViewModel
        {
            get { return (TestViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (TestViewModel)value; }
        }
    }
}
