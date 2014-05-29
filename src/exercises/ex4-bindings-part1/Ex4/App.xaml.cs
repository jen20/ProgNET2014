namespace Ex4
{
    public partial class App
    {
        public App()
        {
            var vm = new MainWindowModel();
            var view = new MainWindow {ViewModel = vm};

            view.ShowDialog();
        }
    }
}
