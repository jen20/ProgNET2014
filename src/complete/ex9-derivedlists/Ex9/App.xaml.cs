using ReactiveUI;

namespace Ex9
{
    public partial class App
    {
        public App()
        {
            RxApp.MutableResolver.Register(() => new TestView(), typeof(IViewFor<TestViewModel>));

            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};
            view.Show();
        }
    }
}
