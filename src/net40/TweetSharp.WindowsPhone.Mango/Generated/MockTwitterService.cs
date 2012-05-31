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
    public class MockTwitterService : ITwitterService
    {
        private static List<int> blockedIds = new List<int>();
        private static List<TwitterStatus> favoritedStatus = new List<TwitterStatus>();
        private Random rand = new Random((int)DateTime.Now.Ticks);

        public virtual void AuthenticateWith(string token, string tokenSecret)
        {
        }

        public virtual void AuthenticateWith(string consumerKey, string consumerSecret, string token, string tokenSecret)
        {
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
            return new TwitterUser
            {
                ContributorsEnabled = true,
                CreatedDate = DateTime.Now.AddDays(-1),
                Description = "A nice description for this user",
                FavouritesCount = 5,
                FollowersCount = 10,
                FollowRequestSent = false,
                FriendsCount = 150,
                Id = rand.Next(0, 99999999),
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
                ScreenName = rand.Next(0, 1231315).ToString(),               
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
        
        public virtual void VerifyCredentials(Action<TwitterUser, TwitterResponse> action)
        {
            if(action != null)
                action(CreateSampleUser(), GetResponse());
        }

        public virtual void GetRateLimitStatus(Action<TwitterRateLimitStatus, TwitterResponse> action)
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

        public virtual void EndSession(Action<TwitterError, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetAccountSettings(Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccountSettings(int trend_location_woeid, Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccountSettings(bool sleepTimeEnabled, Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccountSettings(bool sleepTimeEnabled, int startSleepTime, int endSleepTime, Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccountSettings(string lang, Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccountSettings(string timeZone, string lang, Action<TwitterAccount, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateDeliveryDevice(TwitterDeliveryDevice device, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, string sidebarBorderColor, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateProfileColors(string backgroundColor, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateProfileColors(string backgroundColor, string textColor, Action<TwitterUser, TwitterResponse> action)
        {
           throw new NotImplementedException();
        }

        public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, Action<TwitterUser, TwitterResponse> action)
        {
           throw new NotImplementedException();
        }

        public virtual void UpdateProfileImage(string path, System.IO.Stream file, Action<TwitterUser, TwitterResponse> action)
        {
            TwitterResponse resp;
            if(file.CanRead)
                resp = GetResponse();
            else
                resp = GetFailResponse();

            if(action!= null)
                action(CreateSampleUser(), resp);
        }

        public virtual void UpdateProfileBackgroundImage(string path, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateProfile(string name, string description, string email, string url, string location, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void BlockUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;

            if(!ReturnsFail)
                blockedIds.Add(user.Id);
            
            if(action != null)
                action(user, GetResponse());
        }

        public virtual void BlockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action)
        {
           var user = CreateSampleUser();
            user.ScreenName = userScreenName;
            if(!ReturnsFail)
                blockedIds.Add(user.Id);
            
            if(action != null)
                action(user, GetResponse());
        }

        public virtual void UnblockUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;
            if(!ReturnsFail)
                if(blockedIds.Contains(userId))
                    blockedIds.Remove(userId);
            
            if(action != null)
                action(user, GetResponse());
        }

        public virtual void UnblockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyBlocking(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyBlocking(string userScreenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListBlockedUsers(Action<IEnumerable<TwitterUser>, TwitterResponse> action)
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

        public virtual void ListBlockedUsers(int page, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
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

        public virtual void ListBlockedUserIds(Action<IEnumerable<int>, TwitterResponse> action)
        {
            if(action != null)
                action(blockedIds, GetResponse());
        }

        public virtual void ListDirectMessagesReceived(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
                
        }

        public virtual void ListDirectMessagesReceived(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            var list = new List<TwitterDirectMessage>();

            for(int i = 0; i < count; i++)
                list.Add(CreateSampleDM());

            if(action != null)
                action(list, GetResponse());
        }

        public virtual void ListDirectMessagesReceived(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesReceivedSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public virtual void ListDirectMessagesReceivedSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesReceivedSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesReceivedBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public virtual void ListDirectMessagesReceivedBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesReceivedBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSent(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(14, action);
        }

        public virtual void ListDirectMessagesSent(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSent(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSentSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public virtual void ListDirectMessagesSentSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSentSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
           ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSentBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
            ListDirectMessagesReceived(15, action);
        }

        public virtual void ListDirectMessagesSentBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
           ListDirectMessagesReceived(count, action);
        }

        public virtual void ListDirectMessagesSentBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
        {
             ListDirectMessagesReceived(count, action);
        }

        public virtual void DeleteDirectMessage(long id, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Id = id;
            if(action != null)
                action(dm, GetResponse());
        }

        public virtual void DeleteDirectMessage(int id, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Id = id;
            if(action != null)
                action(dm, GetResponse());
        }

        public virtual void SendDirectMessage(int userId, string text, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Text = text;

            if(action != null)
                action(dm, GetResponse());
        }

        public virtual void SendDirectMessage(string screenName, string text, Action<TwitterDirectMessage, TwitterResponse> action)
        {
            var dm = CreateSampleDM();
            dm.Text = text;

            if(action != null)
                action(dm, GetResponse());
        }

        public virtual void ListFavoriteTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweets(int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            var aux = SetTweetFavorite;
            SetTweetFavorite = true;
            List<TwitterStatus> list = new List<TwitterStatus>();
            for(int i = 0; i <count; i++)
                list.Add(CreateSampleStatus());

            if(action != null)
                action(list, GetResponse());
        }

        public virtual void ListFavoriteTweetsFor(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweetsFor(int userId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweetsFor(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, count, action);
        }

        public virtual void ListFavoriteTweetsFor(string userScreenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweetsFor(string userScreenName, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, 15, action);
        }

        public virtual void ListFavoriteTweetsFor(string userScreenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            ListFavoriteTweets(0, count, action);
        }

        public virtual void FavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            var status = CreateSampleStatus();
            status.IsFavorited = true;
            status.Id = id;
            favoritedStatus.Add(status);

            if(action != null)
                action(status, GetResponse());
        }

        public virtual void UnfavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            var status = favoritedStatus.FirstOrDefault(item => item.Id == id);
            
            if(action != null)
            action(status, GetResponse());
        }

        public virtual void ListFriendIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriendIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowerIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowerIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void FollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
           var user = CreateSampleUser();
            user.Id = userId;

            if(action != null)
                action(user, GetResponse());
        }

        public virtual void FollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.ScreenName = screenName;

            if(action != null)
                action(user, GetResponse());
        }

        public virtual void UnfollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.ScreenName = screenName;

            if(action != null)
                action(user, GetResponse());
        }

        public virtual void UnfollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            var user = CreateSampleUser();
            user.Id = userId;

            if(action != null)
                action(user, GetResponse());
        }

        public virtual void GetIncomingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetIncomingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetOutgoingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetOutgoingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetFriendshipInfo(string sourceScreenName, string targetScreenName, Action<TwitterFriendship, TwitterResponse> action)
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

        public virtual void GetFriendshipInfo(int sourceId, int targetId, Action<TwitterFriendship, TwitterResponse> action)
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

        public virtual void CreateList(string listOwner, string name, Action<TwitterList, TwitterResponse> action)
        {
            CreateList(listOwner, name, "", "public", action);
        }

        public virtual void CreateList(string listOwner, string name, string description, Action<TwitterList, TwitterResponse> action)
        {
            CreateList(listOwner, name, description, "public", action);
        }

        public virtual void CreateList(string listOwner, string name, string description, string mode, Action<TwitterList, TwitterResponse> action)
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

        public virtual void ListListsFor(string screenName, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetList(string ownerScreenName, string slug, Action<TwitterList, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteList(long listId, Action<TwitterList, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnList(string ownerScreenName, string slug, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnList(string ownerScreenName, string slug, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnList(string ownerScreenName, string slug, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }
        public virtual void ListListMembershipsFor(string screenName, bool filterToOwnedLists, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListListMembers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void AddListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyListMembership(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListListSubscriptionsFor(string screenName, Action<IEnumerable<TwitterList>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListListSubscribers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void FollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UnfollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyListSubscription(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void FollowUserNotifications(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void FollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UnfollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void UnfollowUserNotifications(string userScreenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListSavedSearches(Action<IEnumerable<TwitterSavedSearch>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void CreateSavedSearch(string query, Action<TwitterSavedSearch, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Search(string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchSince(long since_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchBefore(long max_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnPublicTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnHomeTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnUserTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMe(int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeSince(long sinceId, int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeBefore(long maxId, int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListTweetsMentioningMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMe(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsByMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsToMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweets(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweets(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweetsSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweetsSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweetsSince(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweetsBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListRetweetsOfMyTweetsBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListCurrentTrends(Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListCurrentTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListDailyTrends(Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListDailyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListDailyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListDailyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListWeeklyTrends(Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListWeeklyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListWeeklyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListWeeklyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListAvailableTrendsLocations(Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListAvailableTrendsLocations(double lat, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListAvailableTrendsLocations(double lat, double @long, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListLocalTrendsFor(long woeId, Action<TwitterLocalTrends, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SendTweet(string status, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SendTweet(string status, double lat, double @long, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SendTweet(string status, long inReplyToStatusId, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SendTweet(string status, long inReplyToStatusId, double lat, double @long, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Retweet(long id, Action<TwitterStatus, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Retweets(long id, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void Retweets(long id, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUsersWhoRetweeted(long id, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUsersWhoRetweeted(long id, int count, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUserIdsWhoRetweeted(long id, Action<IEnumerable<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUserIdsWhoRetweeted(long id, int count, Action<IEnumerable<int>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriends(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriends(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriendsOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriendsOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriendsOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFriendsOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowers(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowers(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowersOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowersOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowersOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListFollowersOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetUserProfile(Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetUserProfileFor(string screenName, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetUserProfileFor(int id, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchForUser(string q, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchForUser(string q, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void SearchForUser(string q, int page, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUserProfilesFor(IEnumerable<string> screenName, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUserProfilesFor(IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListUserProfilesFor(IEnumerable<string> screenName, IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetProfileImageFor(string screenName, Action<byte[], TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetProfileImageFor(string screenName, TwitterProfileImageSize size, Action<byte[], TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListSuggestedUserCategories(Action<IEnumerable<TwitterUserSuggestions>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ListSuggestedUsers(string categorySlug, Action<TwitterUserSuggestions, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GetPlace(string id, Action<TwitterPlace, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ReverseGeocode(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GeoSearchByCoordinates(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GeoSearchByQuery(string query, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void GeoSearchByIp(string ip, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ReportSpam(string username, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }

        public virtual void ReportSpam(long id, Action<TwitterUser, TwitterResponse> action)
        {
            throw new NotImplementedException();
        }
    }
}
