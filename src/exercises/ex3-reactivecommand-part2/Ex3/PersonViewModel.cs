using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace Ex3
{
    public class PersonViewModel : ReactiveObject
    {
        private async Task<string> PretendToCallTheServer()
        {
            return await Observable.Return("Hello World")
                .Delay(TimeSpan.FromSeconds(2), RxApp.TaskpoolScheduler)
                .FirstAsync();
        } 

        public PersonViewModel()
        {
            _fullName = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName, (f, l) => string.Format("{0} {1}", f, l))
                            .ToProperty(this, vm => vm.FullName);

            var firstAndLastFilled = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName,
                (f, l) => !string.IsNullOrWhiteSpace(f) && !string.IsNullOrWhiteSpace(l));

            //TODO: Initialize ChangeName command as Async Task and
            //      register the `PretendToCallTheServer` method as the async operation of the
            //      ChangeName command and store the returned value in `ServerResult`
        }

        //TODO: Add a read-write property named ServerResult

        public readonly ReactiveCommand<string> ChangeName;

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
