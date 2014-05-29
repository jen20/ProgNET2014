namespace Ex5
{
    public partial class App
    {
        public App()
        {
            //TODO: Observe what happens to the styles when you remove InitializeComponent.
            //      Don't forget to put it back!
            InitializeComponent();
            (new AppBootstrapper()).Bootstrap();
        }
    }
}
