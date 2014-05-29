using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Ex3
{
    public class PersonViewModel : ReactiveObject
    {
        private IObservable<string> PretendToCallTheServer()
        {
            return Observable.Return("Hello World")
                .Delay(TimeSpan.FromMilliseconds(2000), RxApp.TaskpoolScheduler);
        } 

        public PersonViewModel()
        {
            _fullName = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName, (f, l) => string.Format("{0} {1}", f, l))
                            .ToProperty(this, vm => vm.FullName);

            var firstAndLastFilled = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName,
                (f, l) => !string.IsNullOrWhiteSpace(f) && !string.IsNullOrWhiteSpace(l));

            ChangeName = new ReactiveCommand(firstAndLastFilled);
            ChangeName.RegisterAsync(_ => PretendToCallTheServer())
                .Subscribe(r => ServerResult = r);
        }

        private string _serverResult;
        public string ServerResult
        {
            get { return _serverResult; }
            set { this.RaiseAndSetIfChanged(ref _serverResult, value); }
        }

        public readonly ReactiveCommand ChangeName;

        private readonly ObservableAsPropertyHelper<string> _fullName;
        public string FullName
        {
            get { return _fullName.Value; }
        }

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
