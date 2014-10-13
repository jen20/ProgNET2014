using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace Ex4
{
    public class MainWindowModel : ReactiveObject
    {
        private async Task<string> PretendToCallTheServer()
        {
            await Task.Delay(2000);
            return "Hello World";
        } 

        public MainWindowModel()
        {
            ServerResult = "Haven't talked to the server yet...";

            var firstAndLastFilled = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName,
                (f, l) => !string.IsNullOrWhiteSpace(f) && !string.IsNullOrWhiteSpace(l));

            ChangeName = ReactiveCommand.CreateAsyncTask(firstAndLastFilled, _ => PretendToCallTheServer());
            ChangeName.Subscribe(r => ServerResult = r);
        }

        private string _serverResult;
        public string ServerResult
        {
            get { return _serverResult; }
            set { this.RaiseAndSetIfChanged(ref _serverResult, value); }
        }

        public readonly ReactiveCommand<string> ChangeName;

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