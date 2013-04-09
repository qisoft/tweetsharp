using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Hammock.Model;
using Newtonsoft.Json;

namespace TweetSharp
{


#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSearchUser  
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string IdStr { get; set; }

        [JsonProperty("screen_name")]
        [DataMember]
        public virtual string ScreenName { get; set; }
        
        /*
        "created_at": "Mon Apr 26 06:01:55 +0000 2010",
        "location": "LA, CA",
        "follow_request_sent": null,
        "profile_link_color": "0084B4",
        "is_translator": false,
        "entities": {
          "url": {
            "urls": [
              {
                "expanded_url": null,
                "url": "",
                "indices": [
                  0,
                  0
                ]
              }
            ]
          },
          "description": {
            "urls": [
            ]
          }
        },
        "default_profile": true,
        "contributors_enabled": false,
        "favourites_count": 0,
        "url": null,
        "profile_image_url_https": "https://si0.twimg.com/profile_images/2359746665/1v6zfgqo8g0d3mk7ii5s_normal.jpeg",
        "utc_offset": -28800,
        "id": 137238150,
        "profile_use_background_image": true,
        "listed_count": 2,
        "profile_text_color": "333333",
        "lang": "en",
        "followers_count": 70,
        "protected": false,
        "notifications": null,
        "profile_background_image_url_https": "https://si0.twimg.com/images/themes/theme1/bg.png",
        "profile_background_color": "C0DEED",
        "verified": false,
        "geo_enabled": true,
        "time_zone": "Pacific Time (US & Canada)",
        "description": "Born 330 Live 310",
        "default_profile_image": false,
        "profile_background_image_url": "http://a0.twimg.com/images/themes/theme1/bg.png",
        "statuses_count": 579,
        "friends_count": 110,
        "following": null,
        "show_all_inline_media": false,
        "screen_name": "sean_cummings"
      */


    }


#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("{FromUserScreenName}: {Text}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSearchStatus : PropertyChangedBase,
                                       IComparable<TwitterSearchStatus>,
                                       IEquatable<TwitterSearchStatus>
    {
        private DateTime _createdDate;
        private int _fromUserId;
        private string _fromUserName;
        private string _fromUserScreenName;
        private long _id;
        private string _isoLanguageCode;
        private string _profileImageUrl;
        private long _sinceId;
        private string _source;
        private string _text;
        private int? _toUserId;
        private string _toUserScreenName;
        private string _location;
        private TwitterGeoLocation _geoLocation;
        private TwitterEntities _entities;


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
                OnPropertyChanged("Text");
            }
        }

        private string _textAsHtml;
        public virtual string TextAsHtml
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return Text;
                }
                return _textAsHtml ?? (_textAsHtml = Text.ParseTwitterageToHtml());
            }
            set
            {
                _textAsHtml = value;
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
                OnPropertyChanged("CreatedDate");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
            public string IsoLanguageCode
        {
            get { return _isoLanguageCode; }
            set
            {
                if (_isoLanguageCode == value)
                {
                    return;
                }

                _isoLanguageCode = value;
                OnPropertyChanged("IsoLanguageCode");
            }
        }

        [JsonProperty("geo")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public TwitterGeoLocation GeoLocation
        {
            get { return _geoLocation; }
            set
            {
                if (_geoLocation == value)
                {
                    return;
                }

                _geoLocation = value;
                OnPropertyChanged("TwitterGeoLocation");
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

        [JsonProperty("user")]
        public virtual TwitterSearchUser User  { get; set; }

        #region IComparable<TwitterSearchStatus> Members

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TwitterSearchStatus other)
        {
            return other.Id == Id ? 0 : other.Id > Id ? -1 : 1;
        }

        #endregion

        #region IEquatable<TwitterSearchStatus> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="status"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(TwitterSearchStatus status)
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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="status">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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
            return status.GetType() == typeof (TwitterSearchStatus) && Equals((TwitterSearchStatus) status);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(TwitterSearchStatus left, TwitterSearchStatus right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(TwitterSearchStatus left, TwitterSearchStatus right)
        {
            return !Equals(left, right);
        }

        ///<summary>
        /// This implicit conversion supports treating a search status as if it were a 
        /// regular <see cref="TwitterStatus" />. This is useful if you need to combine search
        /// results and regular results in the same UI context.
        ///</summary>
        ///<param name="searchStatus"></param>
        ///<returns></returns>
        public static implicit operator TwitterStatus(TwitterSearchStatus searchStatus)
        {
            var user = new TwitterUser
                           {
                           };

            var status = new TwitterStatus
                             {
                                 CreatedDate = searchStatus.CreatedDate,
                                 Id = searchStatus.Id,
                                 RawSource = searchStatus.RawSource,
                                 Text = searchStatus.Text,
                                 User = user
                             };

            return status;
        }

#if !Smartphone && !NET20
        /// <summary>
        /// The source content used to deserialize the model entity instance.
        /// Can be XML or JSON, depending on the endpoint used.
        /// </summary>
        [DataMember]
#endif
        public virtual string RawSource { get; set; }
    }

}
