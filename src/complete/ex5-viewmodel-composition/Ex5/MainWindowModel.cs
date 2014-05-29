using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Ex5
{
    public class MainWindowModel : ReactiveObject
    {
        private IObservable<string> PretendToCallTheServer()
        {
            return Observable.Return("Hello World")
                .Delay(TimeSpan.FromMilliseconds(2000), RxApp.TaskpoolScheduler);
        }

        public MainWindowModel()
        {
            TitleBar = new TitleBarViewModel();

            ServerResult = "Haven't talked to the server yet...";

            var firstAndLastFilled = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName,
                (f, l) => !string.IsNullOrWhiteSpace(f) && !string.IsNullOrWhiteSpace(l));

            ChangeName = new ReactiveCommand(firstAndLastFilled);
            ChangeName.RegisterAsync(_ => PretendToCallTheServer())
                .Subscribe(r => ServerResult = r);
        }

        private TitleBarViewModel _titleBar;
        public TitleBarViewModel TitleBar
        {
            get { return _titleBar; }
            private set { this.RaiseAndSetIfChanged(ref _titleBar, value); }
        }

        private string _serverResult;
        public string ServerResult
        {
            get { return _serverResult; }
            set { this.RaiseAndSetIfChanged(ref _serverResult, value); }
        }

        public readonly ReactiveCommand ChangeName;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { this.RaiseAndSetIfChanged(ref _lastName, value); }
        }
    }
}