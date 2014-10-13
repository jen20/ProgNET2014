using ReactiveUI;
using Splat;

namespace Ex9
{
    public partial class App
    {
        public App()
        {
            Locator.CurrentMutable.Register(() => new TestView(), typeof(IViewFor<TestViewModel>));

            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};
            view.Show();
        }
    }
}
