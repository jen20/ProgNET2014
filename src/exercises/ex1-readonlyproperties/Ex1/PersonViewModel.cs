using ReactiveUI;

namespace Ex1
{
    public class PersonViewModel : ReactiveObject
    {
        public PersonViewModel()
        {
            //TODO: Add code to update FullName when FirstName or LastName change
        }

        //TODO: Add a read-only property for FullName

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }

        //TODO: Add a second read-write property for LastName
    }
}
