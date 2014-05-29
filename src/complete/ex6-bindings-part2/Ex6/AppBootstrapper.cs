namespace Ex6
{
    public class AppBootstrapper
    {
        public void Bootstrap()
        {
            RunApp();
        }

        private void RunApp()
        {
            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};

            view.ShowDialog();
        }
    }
}