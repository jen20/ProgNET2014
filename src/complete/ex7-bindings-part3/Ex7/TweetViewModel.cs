using System;
using ReactiveUI;

namespace Ex7
{
    public class TweetViewModel : ReactiveObject
    {
        private string _userHandle;
        public string UserHandle
        {
            get { return _userHandle; }
            set { this.RaiseAndSetIfChanged(ref _userHandle, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { this.RaiseAndSetIfChanged(ref _message, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { this.RaiseAndSetIfChanged(ref _date, value); }
        }
    }
}