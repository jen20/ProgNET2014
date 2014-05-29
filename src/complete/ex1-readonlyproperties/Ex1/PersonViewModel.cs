using ReactiveUI;

namespace Ex1
{
    public class PersonViewModel : ReactiveObject
    {
        public PersonViewModel()
        {
            _fullName = this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName, (f, l) => string.Format("{0} {1}", f, l))
                            .ToProperty(this, vm => vm.FullName);
        }

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
