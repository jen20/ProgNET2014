namespace Ex7
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            (new AppBootstrapper()).Bootstrap();
        }
    }
}
