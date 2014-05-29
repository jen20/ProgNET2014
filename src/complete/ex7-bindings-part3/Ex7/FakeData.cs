using System;
using System.Collections.Generic;

namespace Ex7
{
    public static class FakeData
    {
        public static IEnumerable<TweetViewModel> GetFakeTweets()
        {
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(60)),
                UserHandle = "jen20",
                Message = "This is a test tweet"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(59)),
                UserHandle = "ashic",
                Message = "This is another test tweet"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(58)),
                UserHandle = "gregyoung",
                Message = "Tweeting is fun"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(56)),
                UserHandle = "robashton",
                Message = "I want coffee"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(55)),
                UserHandle = "stack72",
                Message = "I want a beer"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(50)),
                UserHandle = "jen20",
                Message = "Beer sounds like a good plan"
            };
            yield return new TweetViewModel
            {
                Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(40)),
                UserHandle = "macintyrecoffee",
                Message = "Coffee sounds better than beer"
            };
        }
    }
}