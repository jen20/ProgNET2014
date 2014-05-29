using ReactiveUI;

namespace Ex7
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
            var sl = RxApp.MutableResolver;

            sl.Register(() => new TweetView(), typeof (IViewFor<TweetViewModel>));
        }

        private void RunApp()
        {
            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};

            view.ShowDialog();
        }
    }
}