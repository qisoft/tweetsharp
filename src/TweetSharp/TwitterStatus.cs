using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Hammock.Model;
using Newtonsoft.Json;
using System.Net;

namespace TweetSharp
{
#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterStatus : PropertyChangedBase,
                                 IComparable<TwitterStatus>,
                                 IEquatable<TwitterStatus>,
                                 ITwitterModel, 
                                 ITweetable
    {
        private DateTime _createdDate;
        private long _id;
        private string _inReplyToScreenName;
        private long? _inReplyToStatusId;
        private int? _inReplyToUserId;
        private bool _isFavorited;
        private bool _isTruncated;
        private string _source;
        private string _text;
        private TwitterUser _user;
        private TwitterStatus _retweetedStatus;
        private TwitterGeoLocation _location;
        private TwitterEntities _entities;
        private bool? _isPossiblySensitive;
        private TwitterPlace _place;

        public virtual string AuthorName
        {
            get
            {
                if (RetweetedStatus != null)
                    return RetweetedStatus.Author.ScreenName;
                else
                    return Author.ScreenName;
            }
        }

        public bool IsRetweeted
        {
            get
            {
                return RetweetedStatus != null;
            }
        }

        private static string TrimUrl(string url)
        {
            if (url == null)
                return "";
            url = url.Replace("http://", "");
            url = url.Replace("https://", "");
            if (url.Length > 25)
            {
                int SlashIndex = url.IndexOf('/');
                url = url.Substring(0, SlashIndex + 1);
                url += "...";
            }

            return url;
        }

        private string _cleanText;
        public string CleanText
        {
            get
            {
                if (RetweetedStatus != null)
                    return RetweetedStatus.CleanText;

                if (_cleanText != null)
                    return _cleanText;

                string TweetText = Text;
                string ReturnText = "";
                string PreviousText;
                int i = 0;

                foreach (var Entity in Entities)
                {
                    if (Entity.StartIndex > i)
                    {
                        PreviousText = TweetText.Substring(i, Entity.StartIndex - i);
                        ReturnText += HttpUtility.HtmlDecode(PreviousText);
                    }

                    i = Entity.EndIndex;

                    switch (Entity.EntityType)
                    {
                        case TwitterEntityType.HashTag:
                            ReturnText += "#" + ((TwitterHashTag)Entity).Text;
                            break;

                        case TwitterEntityType.Mention:
                            ReturnText += "@" + ((TwitterMention)Entity).ScreenName;
                            break;

                        case TwitterEntityType.Url:
                            ReturnText += TrimUrl(((TwitterUrl)Entity).ExpandedValue);
                            break;
                        case TwitterEntityType.Media:
                            ReturnText += ((TwitterMedia)Entity).DisplayUrl;
                            break;
                    }
                }

                if (i < TweetText.Length)
                    ReturnText += HttpUtility.HtmlDecode(TweetText.Substring(i));

                _cleanText = ReturnText;
                return ReturnText;
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("Id");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int? InReplyToUserId
        {
            get { return _inReplyToUserId; }
            set
            {
                if (_inReplyToUserId == value)
                {
                    return;
                }

                _inReplyToUserId = value;
                OnPropertyChanged("InReplyToUserId");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long? InReplyToStatusId
        {
            get { return _inReplyToStatusId; }
            set
            {
                if (_inReplyToStatusId == value)
                {
                    return;
                }

                _inReplyToStatusId = value;
                OnPropertyChanged("InReplyToStatusId");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string InReplyToScreenName
        {
            get { return _inReplyToScreenName; }
            set
            {
                if (_inReplyToScreenName == value)
                {
                    return;
                }

                _inReplyToScreenName = value;
                OnPropertyChanged("InReplyToScreenName");
            }
        }

        [JsonProperty("truncated")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual bool IsTruncated
        {
            get { return _isTruncated; }
            set
            {
                if (_isTruncated == value)
                {
                    return;
                }

                _isTruncated = value;
                OnPropertyChanged("IsTruncated");
            }
        }

        [JsonProperty("favorited")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual bool IsFavorited
        {
            get { return _isFavorited; }
            set
            {
                if (_isFavorited == value)
                {
                    return;
                }

                _isFavorited = value;
                OnPropertyChanged("IsFavorited");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                {
                    return;
                }

                _text = value;
                _textAsHtml = null;
                _textDecoded = null;
                OnPropertyChanged("Text");
            }
        }

        private string _textDecoded;
        public virtual string TextDecoded
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return Text;
                }
#if !SILVERLIGHT && !WINDOWS_PHONE
                return _textDecoded ?? (_textDecoded = System.Compat.Web.HttpUtility.HtmlDecode(Text));
#elif WINDOWS_PHONE
                return _textDecoded ?? (_textDecoded = System.Net.HttpUtility.HtmlDecode(Text));
#else
                return _textDecoded ?? (_textDecoded = System.Windows.Browser.HttpUtility.HtmlDecode(Text));
#endif
            }
            set
            {
                _textDecoded = value;
                OnPropertyChanged("TextDecoded");
            }
        }

        private string _textAsHtml;
        [Obsolete("For most cases you want to use Entitites to find elements you can turn into HTML. This method does not know about entities.")]
        public virtual string TextAsHtml
        {
            get
            {
                if(string.IsNullOrEmpty(Text))
                {
                    return Text;
                }
                return _textAsHtml ?? (_textAsHtml = Text.ParseTwitterageToHtml());
            }
            set
            {
                _textAsHtml = value;
                OnPropertyChanged("TextAsHtml");
            }
        }

        public ITweeter Author
        {
            get { return User; }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Source
        {
            get { return _source; }
            set
            {
                if (_source == value)
                {
                    return;
                }

                _source = value;
                OnPropertyChanged("Source");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterUser User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                OnPropertyChanged("TwitterUser");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterStatus RetweetedStatus
        {
            get { return _retweetedStatus; }
            set
            {
                if (_retweetedStatus == value)
                {
                    return;
                }

                _retweetedStatus = value;
                OnPropertyChanged("RetweetedStatus");
            }
        }

        [JsonProperty("created_at")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if (_createdDate == value)
                {
                    return;
                }

                _createdDate = value;

                if (_createdDate.Kind == DateTimeKind.Unspecified)
                    _createdDate = new DateTime(_createdDate.Ticks, DateTimeKind.Utc);

                OnPropertyChanged("CreatedDate");
            }
        }

        [JsonProperty("geo")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterGeoLocation Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                {
                    return;
                }

                _location = value;
                OnPropertyChanged("Location");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterEntities Entities
        {
            get { return _entities; }
            set
            {
                if (_entities == value)
                {
                    return;
                }

                _entities = value;
                OnPropertyChanged("Entities");
            }
        }

        [JsonProperty("possibly_sensitive")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual bool? IsPossiblySensitive
        {
            get { return _isPossiblySensitive; }
            set
            {
                if (_isPossiblySensitive == value)
                {
                    return;
                }

                _isPossiblySensitive = value;
                OnPropertyChanged("IsPossiblySensitive");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterPlace Place
        {
            get { return _place; }
            set
            {
                if (_place == value)
                {
                    return;
                }

                _place = value;
                OnPropertyChanged("Place");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string RawSource { get; set; }

        #region IComparable<TwitterStatus> Members

        public int CompareTo(TwitterStatus other)
        {
            return other.Id == Id ? 0 : other.Id > Id ? -1 : 1;
        }

        #endregion

        #region IEquatable<TwitterStatus> Members

        public bool Equals(TwitterStatus status)
        {
            if (ReferenceEquals(null, status))
            {
                return false;
            }
            if (ReferenceEquals(this, status))
            {
                return true;
            }
            return status.Id == Id;
        }

        #endregion

        public override bool Equals(object status)
        {
            if (ReferenceEquals(null, status))
            {
                return false;
            }
            if (ReferenceEquals(this, status))
            {
                return true;
            }
            return status.GetType() == typeof (TwitterStatus) && Equals((TwitterStatus) status);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(TwitterStatus left, TwitterStatus right)
        {
            return Equals(left, right);
        }
        
        public static bool operator !=(TwitterStatus left, TwitterStatus right)
        {
            return !Equals(left, right);
        }
    }
}