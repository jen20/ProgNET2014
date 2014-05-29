using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace Ex7
{
    public class MainWindowModel : ReactiveObject
    {
        public MainWindowModel()
        {
            //TODO: Add code to declare a ReactiveList of TweetViewModel

            //TODO: Add code to create the LoadTweets command and register a task which waits
            //      for 2 seconds, before adding the data from the FakeData class to the list

            //TODO: Declare an observable which fires `true` if the count of Tweets is greater
            //      than 0 and false otherwise.

            //TODO: Declare a command which removes the tweet at index 0, with a CanExecute of
            //      whether the above observable is true.
        }

        //TODO: Add LoadTweetand RemoveTweet ReactiveCommands

        public ReactiveList<TweetViewModel> Tweets { get; private set; }
    }
}