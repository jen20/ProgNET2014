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
            Tweets = new ReactiveList<TweetViewModel>();

            LoadTweets = ReactiveCommand.CreateAsyncTask(async _ =>
            {
                await Task.Delay(2000);
                foreach (var t in FakeData.GetFakeTweets())
                    Tweets.Add(t);
            });

            var canRemoveTweet = this.WhenAnyValue(vm => vm.Tweets.Count)
                .Select(c => c > 0);

            RemoveTweet = ReactiveCommand.Create(canRemoveTweet);
            RemoveTweet.Subscribe(_ => Tweets.RemoveAt(0));
        }

        public IReactiveCommand LoadTweets { get; private set; }
        public ReactiveCommand<object> RemoveTweet { get; private set; }

        public ReactiveList<TweetViewModel> Tweets { get; private set; }
    }
}