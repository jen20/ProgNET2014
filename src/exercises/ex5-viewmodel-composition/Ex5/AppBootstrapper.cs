using ReactiveUI;
using Splat;

namespace Ex5
{
    public class AppBootstrapper
    {
        public void Bootstrap()
        {
            ConfigureServiceLocator();
            RunApp();
        }

        private void ConfigureServiceLocator()
        {
            var sl = Locator.CurrentMutable;

            //TODO: Register a func for creating new TitleBarViews for the IViewFor<TitleBarViewModel> type
            sl.Register(() => new TitleBarView(), typeof(IViewFor<TitleBarViewModel>));
        }

        private void RunApp()
        {
            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};

            view.ShowDialog();
        }
    }
}