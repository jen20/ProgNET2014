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

            //TODO: Register the `PretendToCallTheServer` method as the async operation of the
            //      ChangeName command and store the returned value in `ServerResult`
        }

        //TODO: Add a read-write property named ServerResult

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
