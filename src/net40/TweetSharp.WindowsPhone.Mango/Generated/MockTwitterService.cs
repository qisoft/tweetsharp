using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace TweetSharp
{
    public class MockTwitterService : BaseMockTwitterService
    {
        private static List<int> blockedIds = new List<int>();
        private static List<TwitterStatus> favoritedStatus = new List<TwitterStatus>();
        private Random rand = new Random((int)DateTime.Now.Ticks);

        private static string _nextname;
        private static bool shouldGoNextName = false;
        public static string NextScreenName
        {
            protected get { shouldGoNextName = false; return _nextname; }
            set { _nextname = value; shouldGoNextName = true; }
        }

        private static int _nextId;
        private static bool shouldGoNextId = false;
        public static int NextId
        {
            protected get { shouldGoNextId = false; return _nextId; }
            set { _nextId = value; shouldGoNextId = true; }
        }

        private bool GetRandBool()
        {
            if((rand.Next() % 2) == 0)
                return true;
            else
                return false;
        }
        private TwitterUser CreateSampleUser()
        {
            string name;
            if (shouldGoNextName)
                name = NextScreenName;
            else
                name = rand.Next().ToString();

            int id;

            if (shouldGoNextId)
                id = NextId;
            else
                id = rand.Next();
            return new TwitterUser
            {
                ContributorsEnabled = true,
                CreatedDate = DateTime.Now.AddDays(-1),
                Description = "A nice description for this user",
                FavouritesCount = 5,
                FollowersCount = 10,
                FollowRequestSent = false,
                FriendsCount = 150,
                Id = id,
                IsDefaultProfile = false,
                IsGeoEnabled = false,
                IsProfileBackgroundTiled = false,
                IsProtected = false,
                IsTranslator = false,
                IsVerified = false,
                Language = "es-ES", 
                ListedCount = 2,
                Location = "Madrid",
                Name = "Pepito grillo",
                StatusesCount = 1205,
                Url = "about:blank",
                ScreenName = name,               
            };
        }

        private TwitterResponse GetGoodResponse()
        {
            return new TwitterResponse(new Hammock.RestResponseBase
            {
                InnerException = null,
                IsMock = true,
                StatusCode = HttpStatusCode.OK
            });
        }

        private TwitterResponse GetFailResponse()
        {
            return new TwitterResponse(new Hammock.RestResponseBase
            {
                InnerException = new Exception(),
                IsMock = true,
                StatusCode = HttpStatusCode.Forbidden
            });
        }

        private TwitterResponse GetResponse()
        {
            if(ReturnsFail)
                return GetFailResponse();
            else
                return GetGoodResponse();
        }

        private TwitterDirectMessage CreateSampleDM()
        {
            var user1 = CreateSampleUser();
                var user2 = CreateSampleUser();
            return new TwitterDirectMessage {
                CreatedDate = DateTime.Now.AddSeconds(rand.Next(1230)),
                Entities = new TwitterEntities(),
                Id = rand.Next(123180989),
                Recipient = user1,
                RecipientId = user1.Id,
                RecipientScreenName = user1.ScreenName,
                Sender = user2,
                SenderId = user2.Id,
                SenderScreenName = user2.ScreenName,
                Text = "Random direct message with no more than 140 chars."                
            };
        }

        public static bool SetReplyToTweets { get; set; }
        public static bool SetTweetFavorite { get; set; }
        public static bool SetRetweetedTweet { get; set; }
        private TwitterStatus CreateSampleStatus()
        {
            TwitterStatus rt = null;
            if(SetRetweetedTweet)
            {
                SetRetweetedTweet = false;
                rt = CreateSampleStatus();
                SetRetweetedTweet = true;
            }
            return new TwitterStatus {
                User = CreateSampleUser(),
                CreatedDate = DateTime.Now.AddSeconds(rand.Next(-123, 0)),
                Id = rand.Next(1239018),
                InReplyToScreenName = SetReplyToTweets ? rand.Next().ToString() :null ,
                InReplyToStatusId = SetReplyToTweets ? (int?)rand.Next() : null ,
                InReplyToUserId = SetReplyToTweets ? (int?)rand.Next() : null ,
                IsFavorited = SetTweetFavorite,
                IsPossiblySensitive = false,
                IsTruncated = false,
                RetweetedStatus = rt,
                Entities = new TwitterEntities(),
                Text = "Random text for this tweet."
            };
        }

        public static bool ReturnsFail { get; set;}
        
        public override void VerifyCredentials(Action<TwitterUser, TwitterResponse> action)
        {
            if(action != null)
                action(CreateSampleUser(), GetResponse());
        }

        public override void GetRateLimitStatus(Action<TwitterRateLimitStatus, TwitterResponse> action)
        {
            TwitterRateLimitStatus rate = new TwitterRateLimitStatus
            {
                HourlyLimit = 150,
                RemainingHits = 10,
                ResetTimeInSeconds = 500,
                ResetTime = DateTime.Now.AddSeconds(500)
            };
            if(action != null)
                action(rate, GetResponse());
        }

        public override void UpdateProfileImage(string path, System.IO.Stream file, Action<TwitterUser, TwitterResponse> action)
        {
            TwitterResponse resp;
            if (file.CanRead)
                resp = GetResponse();
            else
                resp = GetFailResponse();

            if (action != null)
                action(CreateSampleUser(), resp);
        }

        public override void BlockUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;

            if(!ReturnsFail)
                blockedIds.Add(user.Id);
            
            if(action != null)
                action(user, GetResponse());
        }

        public override void BlockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action)
        {
           var user = CreateSampleUser();
            user.ScreenName = userScreenName;
            if(!ReturnsFail)
                blockedIds.Add(user.Id);
            
            if(action != null)
                action(user, GetResponse());
        }

        public override void UnblockUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;
            if(!ReturnsFail)
                if(blockedIds.Contains(userId))
                    blockedIds.Remove(userId);
            
            if(action != null)
                action(user, GetResponse());
        }

        public override void ListBlockedUsers(Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            var list = new List<TwitterUser>();

            foreach(var id in blockedIds)
            {
                var user = CreateSampleUser();
                user.Id = id;
                list.Add(user);
            }

            if(action != null)
                action(list, GetResponse());
        }

        public override void ListBlockedUsers(int page, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            var list = new List<TwitterUser>();

            foreach(var id in blockedIds)
            {
                var user = CreateSampleUser();
                user.Id = id;
                list.Add(user);
            }

            if(action != null)
                action(list, GetResponse());
        }

        public override void ListBlockedUserIds(Action<IEnumerable<int>, TwitterResponse> action)
        {
            if(action != null)
                action(blockedIds, GetResponse());
        }

        public override void ListDirectMessagesReceived(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
                
        }

        public override void ListDirectMessagesReceived(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            var list = new List<TwitterDirectMessage>();

            for(int i = 0; i < count; i++)
                list.Add(CreateSampleDM());

            if(action != null)
                action(list, GetResponse());
        }

        public override void ListDirectMessagesReceived(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesReceivedSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public override void ListDirectMessagesReceivedSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesReceivedSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesReceivedBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public override void ListDirectMessagesReceivedBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesReceivedBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSent(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(14, action);
        }

        public override void ListDirectMessagesSent(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSent(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSentSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public override void ListDirectMessagesSentSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSentSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
           ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSentBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public override void ListDirectMessagesSentBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
           ListDirectMessagesReceived(count, action);
        }

        public override void ListDirectMessagesSentBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
             ListDirectMessagesReceived(count, action);
        }

        public override void DeleteDirectMessage(long id, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Id = id;
            if(action != null)
                action(dm, GetResponse());
        }

        public override void DeleteDirectMessage(int id, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Id = id;
            if(action != null)
                action(dm, GetResponse());
        }

        public override void SendDirectMessage(int userId, string text, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Text = text;

            if(action != null)
                action(dm, GetResponse());
        }

        public override void SendDirectMessage(string screenName, string text, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Text = text;

            if(action != null)
                action(dm, GetResponse());
        }

        public override void ListFavoriteTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweets(int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            var aux = SetTweetFavorite;
            SetTweetFavorite = true;
            List<TwitterStatus> list = new List<TwitterStatus>();
            for(int i = 0; i <count; i++)
                list.Add(CreateSampleStatus());

            if(action != null)
                action(list, GetResponse());
        }

        public override void ListFavoriteTweetsFor(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweetsFor(int userId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweetsFor(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, count, action);
        }

        public override void ListFavoriteTweetsFor(string userScreenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweetsFor(string userScreenName, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public override void ListFavoriteTweetsFor(string userScreenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, count, action);
        }

        public override void FavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            var status = CreateSampleStatus();
            status.IsFavorited = true;
            status.Id = id;
            favoritedStatus.Add(status);

            if(action != null)
                action(status, GetResponse());
        }

        public override void UnfavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            var status = favoritedStatus.FirstOrDefault(item => item.Id == id);
            
            if(action != null)
            action(status, GetResponse());
        }

        public override void FollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
           var user = CreateSampleUser();
            user.Id = userId;

            if(action != null)
                action(user, GetResponse());
        }

        public override void FollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.ScreenName = screenName;

            if(action != null)
                action(user, GetResponse());
        }

        public override void UnfollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.ScreenName = screenName;

            if(action != null)
                action(user, GetResponse());
        }

        public override void UnfollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;

            if(action != null)
                action(user, GetResponse());
        }

        public override void GetFriendshipInfo(string sourceScreenName, string targetScreenName, Action<TwitterFriendship, TwitterResponse> action)
        {
            var friendship = new TwitterFriendship
            {
                Relationship = new TwitterRelationship
                {
                    Source = new TwitterFriend
                    {
                        FollowedBy = GetRandBool(),
                        Following = GetRandBool(),
                        CanDirectMessage = GetRandBool(),
                        Id = rand.Next(),
                        IsBlocking = GetRandBool(),
                        ScreenName = sourceScreenName
                    },

                    Target = new TwitterFriend
                    {
                        FollowedBy = GetRandBool(),
                        Following = GetRandBool(),
                        CanDirectMessage = GetRandBool(),
                        Id = rand.Next(),
                        IsBlocking = GetRandBool(),
                        ScreenName = targetScreenName
                    },
                }
            };

            if (action != null)
                action(friendship, GetResponse());

        }

        public override void GetFriendshipInfo(int sourceId, int targetId, Action<TwitterFriendship, TwitterResponse> action)
        {
            var friendship = new TwitterFriendship
            {
                Relationship = new TwitterRelationship
                {
                    Source = new TwitterFriend
                    {
                        FollowedBy = GetRandBool(),
                        Following = GetRandBool(),
                        CanDirectMessage = GetRandBool(),
                        Id = sourceId,
                        IsBlocking = GetRandBool(),
                        ScreenName = rand.Next().ToString()
                    },

                    Target = new TwitterFriend
                    {
                        FollowedBy = GetRandBool(),
                        Following = GetRandBool(),
                        CanDirectMessage = GetRandBool(),
                        Id = targetId,
                        IsBlocking = GetRandBool(),
                        ScreenName = rand.Next().ToString()
                    },
                }
            };

            if (action != null)
                action(friendship, GetResponse());
        }

        public override void CreateList(string listOwner, string name, Action<TwitterList, TwitterResponse> action)
        {
            CreateList(listOwner, name, "", "public", action);
        }

        public override void CreateList(string listOwner, string name, string description, Action<TwitterList, TwitterResponse> action)
        {
            CreateList(listOwner, name, description, "public", action);
        }

        public override void CreateList(string listOwner, string name, string description, string mode, Action<TwitterList, TwitterResponse> action)
        {
            var list = new TwitterList
            {
                Description = description,
                FullName = listOwner + "/" + name,
                Id = rand.Next(),
                MemberCount = rand.Next(),
                Mode = mode,
                Name = name,
                Slug = name,
                SubscriberCount = rand.Next(),
                Uri = null,
                User = CreateSampleUser()
            };

            if (action != null)
                action(list, GetResponse());
        }

        public override void ListUserProfilesFor(IEnumerable<string> screenName, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.ScreenName = screenName.FirstOrDefault();
            var list = new List<TwitterUser>();
            list.Add(user);
            if (action != null)
                action(list, GetResponse());
        }

        public override void ReportSpam(int id, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = (int)id;
            if (action != null)
                action(user, GetResponse());
        }
    }
}
