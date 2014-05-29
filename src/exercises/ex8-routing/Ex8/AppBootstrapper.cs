using ReactiveUI;

namespace Ex8
{
    public class AppBootstrapper
    {
        public void Run()
        {
            RegisterViews();
            var vm = MakeAndRegisterMainViewModel();
            var view = new MainWindowView {ViewModel = vm};
            view.Show();
        }

        private MainWindowViewModel MakeAndRegisterMainViewModel()
        {
            var vm = new MainWindowViewModel();
            RxApp.MutableResolver.RegisterConstant(vm, typeof(IScreen));
            return vm;
        }

        private void RegisterViews()
        {
            var ioc = RxApp.MutableResolver;

            ioc.Register(() => new ViewA(), typeof (IViewFor<ViewModelA>));
            ioc.Register(() => new ViewB(), typeof(IViewFor<ViewModelB>));
        }
    }
}