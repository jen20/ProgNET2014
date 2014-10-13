using ReactiveUI;

namespace Ex6
{
    public class MainWindowModel : ReactiveObject
    {
        public MainWindowModel()
        {
            //NOTE: We deliberately don't register an action here
            var canGreet = this.WhenAnyValue(vm => vm.FirstName, n => !string.IsNullOrWhiteSpace(n));
            GreetUser = ReactiveCommand.Create(canGreet);
        }

        public readonly ReactiveCommand<object> GreetUser;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }
    }
}