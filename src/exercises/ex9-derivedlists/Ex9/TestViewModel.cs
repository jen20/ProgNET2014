using ReactiveUI;

namespace Ex9
{
    public class TestViewModel : ReactiveObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { this.RaiseAndSetIfChanged(ref _id, value); }
        }

        private string _otherValue;
        public string OtherValue
        {
            get { return _otherValue; }
            set { this.RaiseAndSetIfChanged(ref _otherValue, value); }
        }

        public TestModel OriginalModel { get; set; }

        public IReactiveCommand DoStuffWithThisCommand { get; private set; }

        public TestViewModel()
        {
            var canDoStuffWithThisCommand = this.WhenAnyValue(vm => vm.OtherValue, s => !string.IsNullOrWhiteSpace(s));
            DoStuffWithThisCommand = new ReactiveCommand(canDoStuffWithThisCommand);
        }
    }
}