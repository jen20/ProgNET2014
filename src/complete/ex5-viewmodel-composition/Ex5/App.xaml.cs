namespace Ex5
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
