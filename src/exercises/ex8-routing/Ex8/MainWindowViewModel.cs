using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Ex8
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public IRoutingState Router { get; private set; }

        public ReactiveCommand NavigateToACommand { get; private set; }
        public ReactiveCommand NavigateToBCommand { get; private set; }
        public ReactiveCommand BackCommand { get; private set; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();

            var canGoBack = this.WhenAnyValue(vm => vm.Router.NavigationStack.Count)
                                .Select(count => count > 0);

            NavigateToACommand = new ReactiveCommand();
            NavigateToBCommand = new ReactiveCommand();
            BackCommand = new ReactiveCommand(canGoBack);

            NavigateToACommand.Subscribe(NavigateToA);
            NavigateToBCommand.Subscribe(NavigateToB);
            BackCommand.Subscribe(NavigateBack);
        }

        public void NavigateBack(object _)
        {
            Router.NavigateBack.Execute(null);
        }

        public void NavigateToA(object _)
        {
            Router.Navigate.Execute(new ViewModelA(this));
        }

        public void NavigateToB(object _)
        {
            Router.Navigate.Execute(new ViewModelB(this));
        }
    }
}