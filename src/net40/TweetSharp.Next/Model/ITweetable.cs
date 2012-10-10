using System;

namespace TweetSharp
{
    public interface ITweetable
    {
        long Id { get; }
        string Text { get; }
        string TextAsHtml { get; }
        ITweeter Author { get; }
        DateTime CreatedDate { get; }
        TwitterEntities Entities { get; }
        bool IsRetweeted { get; }
        string RawSource { get; set; }
        string AuthorName { get; }
        string CleanText { get; }
    }

    public interface ITweeter 
    {
        string ScreenName { get; }
        string ProfileImageUrl { get; }
    }
}