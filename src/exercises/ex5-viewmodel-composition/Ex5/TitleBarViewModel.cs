using ReactiveUI;

namespace Ex5
{
    public class TitleBarViewModel : ReactiveObject
    {
        public TitleBarViewModel()
        {
            Title = "This is being composed from TitleBarViewModel";
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }
    }
}
