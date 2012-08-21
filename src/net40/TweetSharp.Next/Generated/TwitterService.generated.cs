using System;
using System.Collections.Generic;
using Hammock;
using Hammock.Web;

namespace TweetSharp
{
#region Interface
	public partial interface ITwitterService
	{
		#region Asynchronous Methods (without IAsyncResult)

        void AuthenticateWith(string token, string tokenSecret);

        void AuthenticateWith(string consumerKey, string consumerSecret, string token, string tokenSecret);

		void VerifyCredentials(Action<TwitterUser, TwitterResponse> action);

		void GetRateLimitStatus(Action<TwitterRateLimitStatus, TwitterResponse> action);

		void EndSession(Action<TwitterError, TwitterResponse> action);

		void GetAccountSettings(Action<TwitterAccount, TwitterResponse> action);

		void UpdateAccountSettings(int trend_location_woeid, Action<TwitterAccount, TwitterResponse> action);

		void UpdateAccountSettings(bool sleepTimeEnabled, Action<TwitterAccount, TwitterResponse> action);

		void UpdateAccountSettings(bool sleepTimeEnabled, int startSleepTime, int endSleepTime, Action<TwitterAccount, TwitterResponse> action);

		void UpdateAccountSettings(string lang, Action<TwitterAccount, TwitterResponse> action);

		void UpdateAccountSettings(string timeZone, string lang, Action<TwitterAccount, TwitterResponse> action);

		void UpdateDeliveryDevice(TwitterDeliveryDevice device, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, string sidebarBorderColor, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileColors(string backgroundColor, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileColors(string backgroundColor, string textColor, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileImage(string path, System.IO.Stream file, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfileBackgroundImage(string path, Action<TwitterUser, TwitterResponse> action);

		void UpdateProfile(string name, string description, string email, string url, string location, Action<TwitterUser, TwitterResponse> action);

		void BlockUser(int userId, Action<TwitterUser, TwitterResponse> action);

		void BlockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action);

		void UnblockUser(int userId, Action<TwitterUser, TwitterResponse> action);

		void UnblockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action);

		void VerifyBlocking(int userId, Action<TwitterUser, TwitterResponse> action);

		void VerifyBlocking(string userScreenName, Action<TwitterUser, TwitterResponse> action);

		void ListBlockedUsers(Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListBlockedUsers(int page, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListBlockedUserIds(Action<IEnumerable<int>, TwitterResponse> action);

		void ListDirectMessagesReceived(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceived(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceived(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesReceivedBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSent(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSent(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSent(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void ListDirectMessagesSentBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action);

		void DeleteDirectMessage(long id, Action<TwitterDirectMessage, TwitterResponse> action);

		void DeleteDirectMessage(int id, Action<TwitterDirectMessage, TwitterResponse> action);

		void SendDirectMessage(int userId, string text, Action<TwitterDirectMessage, TwitterResponse> action);

		void SendDirectMessage(string screenName, string text, Action<TwitterDirectMessage, TwitterResponse> action);

		void ListFavoriteTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweets(int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(int userId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(string userScreenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(string userScreenName, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListFavoriteTweetsFor(string userScreenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void FavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action);

		void UnfavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action);

		void ListFriendIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void ListFriendIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void ListFollowerIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void ListFollowerIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void FollowUser(int userId, Action<TwitterUser, TwitterResponse> action);

		void FollowUser(string screenName, Action<TwitterUser, TwitterResponse> action);

		void UnfollowUser(string screenName, Action<TwitterUser, TwitterResponse> action);

		void UnfollowUser(int userId, Action<TwitterUser, TwitterResponse> action);

		void GetIncomingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action);

		void GetIncomingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void GetOutgoingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action);

		void GetOutgoingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action);

		void GetFriendshipInfo(string sourceScreenName, string targetScreenName, Action<TwitterFriendship, TwitterResponse> action);

		void GetFriendshipInfo(int sourceId, int targetId, Action<TwitterFriendship, TwitterResponse> action);

		void CreateList(string listOwner, string name, Action<TwitterList, TwitterResponse> action);

		void CreateList(string listOwner, string name, string description, Action<TwitterList, TwitterResponse> action);

		void CreateList(string listOwner, string name, string description, string mode, Action<TwitterList, TwitterResponse> action);

		void ListListsFor(string screenName, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action);

		void GetList(string ownerScreenName, string slug, Action<TwitterList, TwitterResponse> action);

		void DeleteList(long listId, Action<TwitterList, TwitterResponse> action);

		void ListTweetsOnList(string ownerScreenName, string slug, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnList(string ownerScreenName, string slug, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnList(string ownerScreenName, string slug, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListListMembershipsFor(string screenName, bool filterToOwnedLists, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action);

		void ListListMembers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void AddListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action);

		void RemoveListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action);

		void VerifyListMembership(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action);

		void ListListSubscriptionsFor(string screenName, Action<IEnumerable<TwitterList>, TwitterResponse> action);

		void ListListSubscribers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void FollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action);

		void UnfollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action);

		void VerifyListSubscription(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action);

		void FollowUserNotifications(string screenName, Action<TwitterUser, TwitterResponse> action);

		void FollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action);

		void UnfollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action);

		void UnfollowUserNotifications(string userScreenName, Action<TwitterUser, TwitterResponse> action);

		void ListSavedSearches(Action<IEnumerable<TwitterSavedSearch>, TwitterResponse> action);

		void GetSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action);

		void CreateSavedSearch(string query, Action<TwitterSavedSearch, TwitterResponse> action);

		void DeleteSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action);

		void Search(string q, Action<TwitterSearchResult, TwitterResponse> action);

		void Search(string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void Search(string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void Search(string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void Search(string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void Search(string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchSince(long since_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchBefore(long max_id, string q, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchBefore(long max_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

        RestRequest PrepareEchoRequest();

		void SearchBefore(long max_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchBefore(long max_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchBefore(long max_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action);

		void SearchBefore(long max_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action);

		void ListTweetsOnPublicTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnHomeTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnFriendsTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

        void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnUserTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

        void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

        

		void ListTweetsOnSpecifiedUserTimeline(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimeline(int userId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimeline(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimeline(string screenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimeline(string screenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListTweetsMentioningMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMe(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsByMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsToMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweets(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweets(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweetsSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweetsSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweetsSince(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweetsBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListRetweetsOfMyTweetsBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListCurrentTrends(Action<TwitterTrends, TwitterResponse> action);

		void ListCurrentTrends(string exclude, Action<TwitterTrends, TwitterResponse> action);

		void ListDailyTrends(Action<TwitterTrends, TwitterResponse> action);

		void ListDailyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action);

		void ListDailyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action);

		void ListDailyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action);

		void ListWeeklyTrends(Action<TwitterTrends, TwitterResponse> action);

		void ListWeeklyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action);

		void ListWeeklyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action);

		void ListWeeklyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action);

		void ListAvailableTrendsLocations(Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action);

		void ListAvailableTrendsLocations(double lat, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action);

		void ListAvailableTrendsLocations(double lat, double @long, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action);

		void ListLocalTrendsFor(long woeId, Action<TwitterLocalTrends, TwitterResponse> action);

		void GetTweet(long id, Action<TwitterStatus, TwitterResponse> action);

		void SendTweet(string status, Action<TwitterStatus, TwitterResponse> action);

		void SendTweet(string status, double lat, double @long, Action<TwitterStatus, TwitterResponse> action);

		void SendTweet(string status, long inReplyToStatusId, Action<TwitterStatus, TwitterResponse> action);

		void SendTweet(string status, long inReplyToStatusId, double lat, double @long, Action<TwitterStatus, TwitterResponse> action);

		void DeleteTweet(long id, Action<TwitterStatus, TwitterResponse> action);

		void Retweet(long id, Action<TwitterStatus, TwitterResponse> action);

		void Retweets(long id, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void Retweets(long id, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action);

		void ListUsersWhoRetweeted(long id, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListUsersWhoRetweeted(long id, int count, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListUserIdsWhoRetweeted(long id, Action<IEnumerable<int>, TwitterResponse> action);

		void ListUserIdsWhoRetweeted(long id, int count, Action<IEnumerable<int>, TwitterResponse> action);

		void ListFriends(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFriends(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFriendsOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFriendsOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFriendsOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFriendsOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowers(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowers(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowersOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowersOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowersOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void ListFollowersOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action);

		void GetUserProfile(Action<TwitterUser, TwitterResponse> action);

		void GetUserProfileFor(string screenName, Action<TwitterUser, TwitterResponse> action);

		void GetUserProfileFor(int id, Action<TwitterUser, TwitterResponse> action);

		void SearchForUser(string q, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void SearchForUser(string q, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void SearchForUser(string q, int page, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListUserProfilesFor(IEnumerable<string> screenName, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListUserProfilesFor(IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void ListUserProfilesFor(IEnumerable<string> screenName, IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action);

		void GetProfileImageFor(string screenName, Action<byte[], TwitterResponse> action);

		void GetProfileImageFor(string screenName, TwitterProfileImageSize size, Action<byte[], TwitterResponse> action);

		void ListSuggestedUserCategories(Action<IEnumerable<TwitterUserSuggestions>, TwitterResponse> action);

		void ListSuggestedUsers(string categorySlug, Action<TwitterUserSuggestions, TwitterResponse> action);

		void GetPlace(string id, Action<TwitterPlace, TwitterResponse> action);

		void ReverseGeocode(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action);

		void GeoSearchByCoordinates(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action);

		void GeoSearchByQuery(string query, Action<IEnumerable<TwitterPlace>, TwitterResponse> action);

		void GeoSearchByIp(string ip, Action<IEnumerable<TwitterPlace>, TwitterResponse> action);

        void ReportSpam(string username, Action<TwitterUser, TwitterResponse> action);
        
        void ReportSpam(long id, Action<TwitterUser, TwitterResponse> action);

		#endregion	
	}
#endregion
}

namespace TweetSharp
{
#region Implementation
	public partial class TwitterService : ITwitterService
	{
		#region Asynchronous Methods (without IAsyncResult)
		public virtual void VerifyCredentials(Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "account/verify_credentials", FormatAsString);
		}

		public virtual void GetRateLimitStatus(Action<TwitterRateLimitStatus, TwitterResponse> action)
		{
			WithHammock(action, "account/rate_limit_status", FormatAsString);
		}

		public virtual void EndSession(Action<TwitterError, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/end_session", FormatAsString);
		}

		public virtual void GetAccountSettings(Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(action, "account/settings", FormatAsString);
		}

		public virtual void UpdateAccountSettings(int trend_location_woeid, Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/settings", FormatAsString, "?trend_location_woeid=", trend_location_woeid);
		}

		public virtual void UpdateAccountSettings(bool sleepTimeEnabled, Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/settings", FormatAsString, "?sleep_time_enabled=", sleepTimeEnabled);
		}

		public virtual void UpdateAccountSettings(bool sleepTimeEnabled, int startSleepTime, int endSleepTime, Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/settings", FormatAsString, "?sleep_time_enabled=", sleepTimeEnabled, "&start_sleep_time=", startSleepTime, "&end_sleep_time=", endSleepTime);
		}

		public virtual void UpdateAccountSettings(string lang, Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/settings", FormatAsString, "?lang=", lang);
		}

		public virtual void UpdateAccountSettings(string timeZone, string lang, Action<TwitterAccount, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/settings", FormatAsString, "?time_zone=", timeZone, "&lang=", lang);
		}

		public virtual void UpdateDeliveryDevice(TwitterDeliveryDevice device, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "account/update_delivery_device", FormatAsString, "?device=", device);
		}

		public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, string sidebarBorderColor, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_colors", FormatAsString, "?background_color=", backgroundColor, "&text_color=", textColor, "&link_color=", linkColor, "&sidebar_fill_color=", sidebarFillColor, "&sidebar_border_color=", sidebarBorderColor);
		}

		public virtual void UpdateProfileColors(string backgroundColor, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_colors", FormatAsString, "?background_color=", backgroundColor);
		}

		public virtual void UpdateProfileColors(string backgroundColor, string textColor, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_colors", FormatAsString, "?background_color=", backgroundColor, "&text_color=", textColor);
		}

		public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_colors", FormatAsString, "?background_color=", backgroundColor, "&text_color=", textColor, "&link_color=", linkColor);
		}

		public virtual void UpdateProfileColors(string backgroundColor, string textColor, string linkColor, string sidebarFillColor, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_colors", FormatAsString, "?background_color=", backgroundColor, "&text_color=", textColor, "&link_color=", linkColor, "&sidebar_fill_color=", sidebarFillColor);
		}

		public virtual void UpdateProfileImage(string path, System.IO.Stream file, Action<TwitterUser, TwitterResponse> action)
		{
            WithHammockFile(WebMethod.Post, "image", path, file, "account/update_profile_image", action, FormatAsString);
		}

		public virtual void UpdateProfileBackgroundImage(string path, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile_background_image", FormatAsString, "?path=", path);
		}

		public virtual void UpdateProfile(string name, string description, string email, string url, string location, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "account/update_profile", FormatAsString, "?name=", name, "&description=", description, "&email=", email, "&url=", url, "&location=", location);
		}

		public virtual void BlockUser(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "blocks/create", FormatAsString, "?user_id=", userId);
		}

		public virtual void BlockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "blocks/create", FormatAsString, "?user_screen_name=", userScreenName);
		}

		public virtual void UnblockUser(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "blocks/destroy", FormatAsString, "?user_id=", userId);
		}

		public virtual void UnblockUser(string userScreenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "blocks/destroy", FormatAsString, "?user_screen_name=", userScreenName);
		}

		public virtual void VerifyBlocking(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "blocks/exists", FormatAsString, "?user_id=", userId);
		}

		public virtual void VerifyBlocking(string userScreenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "blocks/exists", FormatAsString, "?user_screen_name=", userScreenName);
		}

		public virtual void ListBlockedUsers(Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "blocks/blocking", FormatAsString);
		}

		public virtual void ListBlockedUsers(int page, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "blocks/blocking", FormatAsString, "?page=", page);
		}

		public virtual void ListBlockedUserIds(Action<IEnumerable<int>, TwitterResponse> action)
		{
			WithHammock(action, "blocks/blocking/ids", FormatAsString);
		}

		public virtual void ListDirectMessagesReceived(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString);
		}

		public virtual void ListDirectMessagesReceived(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?count=", count);
		}

		public virtual void ListDirectMessagesReceived(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListDirectMessagesReceivedSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListDirectMessagesReceivedSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListDirectMessagesReceivedSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListDirectMessagesReceivedBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListDirectMessagesReceivedBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListDirectMessagesReceivedBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListDirectMessagesSent(Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString);
		}

		public virtual void ListDirectMessagesSent(int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?count=", count);
		}

		public virtual void ListDirectMessagesSent(int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListDirectMessagesSentSince(long sinceId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListDirectMessagesSentSince(long sinceId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListDirectMessagesSentSince(long sinceId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListDirectMessagesSentBefore(long maxId, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListDirectMessagesSentBefore(long maxId, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListDirectMessagesSentBefore(long maxId, int page, int count, Action<IEnumerable<TwitterDirectMessage>, TwitterResponse> action)
		{
			WithHammock(action, "direct_messages/sent", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void DeleteDirectMessage(long id, Action<TwitterDirectMessage, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "direct_messages/destroy/{id}", FormatAsString, "?id=", id);
		}

		public virtual void DeleteDirectMessage(int id, Action<TwitterDirectMessage, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "direct_messages/destroy/{id}", FormatAsString, "?id=", id);
		}

		public virtual void SendDirectMessage(int userId, string text, Action<TwitterDirectMessage, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "direct_messages/new", FormatAsString, "?user_id=", userId, "&text=", text);
		}

		public virtual void SendDirectMessage(string screenName, string text, Action<TwitterDirectMessage, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "direct_messages/new", FormatAsString, "?screen_name=", screenName, "&text=", text);
		}

		public virtual void ListFavoriteTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites", FormatAsString);
		}

		public virtual void ListFavoriteTweets(int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites", FormatAsString, "?page=", page);
		}

		public virtual void ListFavoriteTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListFavoriteTweetsFor(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_id=", userId);
		}

		public virtual void ListFavoriteTweetsFor(int userId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_id=", userId, "&page=", page);
		}

		public virtual void ListFavoriteTweetsFor(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_id=", userId, "&page=", page, "&count=", count);
		}

		public virtual void ListFavoriteTweetsFor(string userScreenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_screen_name=", userScreenName);
		}

		public virtual void ListFavoriteTweetsFor(string userScreenName, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_screen_name=", userScreenName, "&page=", page);
		}

		public virtual void ListFavoriteTweetsFor(string userScreenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "favorites/{user_screen_name}", FormatAsString, "?user_screen_name=", userScreenName, "&page=", page, "&count=", count);
		}

		public virtual void FavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "favorites/create/{id}", FormatAsString, "?id=", id);
		}

		public virtual void UnfavoriteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "favorites/destroy/{id}", FormatAsString, "?id=", id);
		}

		public virtual void ListFriendIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friends/ids", FormatAsString, "?screen_name=", screenName, "&cursor=", cursor);
		}

		public virtual void ListFriendIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friends/ids", FormatAsString, "?user_id=", userId, "&cursor=", cursor);
		}

		public virtual void ListFollowerIdsOf(int userId, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "followers/ids", FormatAsString, "?user_id=", userId, "&cursor=", cursor);
		}

		public virtual void ListFollowerIdsOf(string screenName, long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "followers/ids", FormatAsString, "?screen_name=", screenName, "&cursor=", cursor);
		}

		public virtual void FollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "friendships/create", FormatAsString, "?user_id=", userId);
		}

		public virtual void FollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "friendships/create", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void UnfollowUser(string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "friendships/destroy", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void UnfollowUser(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "friendships/destroy", FormatAsString, "?user_id=", userId);
		}

		public virtual void GetIncomingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friendships/incoming", FormatAsString);
		}

		public virtual void GetIncomingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friendships/incoming", FormatAsString, "?cursor=", cursor);
		}

		public virtual void GetOutgoingFriendRequests(Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friendships/outgoing", FormatAsString);
		}

		public virtual void GetOutgoingFriendRequests(long cursor, Action<TwitterCursorList<int>, TwitterResponse> action)
		{
			WithHammock(action, "friendships/outgoing", FormatAsString, "?cursor=", cursor);
		}

		public virtual void GetFriendshipInfo(string sourceScreenName, string targetScreenName, Action<TwitterFriendship, TwitterResponse> action)
		{
			WithHammock(action, "friendships/show", FormatAsString, "?source_screen_name=", sourceScreenName, "&target_screen_name=", targetScreenName);
		}

		public virtual void GetFriendshipInfo(int sourceId, int targetId, Action<TwitterFriendship, TwitterResponse> action)
		{
			WithHammock(action, "friendships/show", FormatAsString, "?source_id=", sourceId, "&target_id=", targetId);
		}

		public virtual void CreateList(string listOwner, string name, Action<TwitterList, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/create", FormatAsString, "?list_owner=", listOwner, "&name=", name);
		}

		public virtual void CreateList(string listOwner, string name, string description, Action<TwitterList, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/create", FormatAsString, "?list_owner=", listOwner, "&name=", name, "&description=", description);
		}

		public virtual void CreateList(string listOwner, string name, string description, string mode, Action<TwitterList, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/create", FormatAsString, "?list_owner=", listOwner, "&name=", name, "&description=", description, "&mode=", mode);
		}

		public virtual void ListListsFor(string screenName, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action)
		{
			WithHammock(action, "lists", FormatAsString, "?screen_name=", screenName, "&cursor=", cursor);
		}

		public virtual void GetList(string ownerScreenName, string slug, Action<TwitterList, TwitterResponse> action)
		{
			WithHammock(action, "lists/show", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug);
		}

		public virtual void DeleteList(long listId, Action<TwitterList, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/destroy", FormatAsString, "?list_id=", listId);
		}

		public virtual void ListTweetsOnList(string ownerScreenName, string slug, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug);
		}

		public virtual void ListTweetsOnList(string ownerScreenName, string slug, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&per_page=", perPage);
		}

		public virtual void ListTweetsOnList(string ownerScreenName, string slug, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&page=", page, "&per_page=", perPage);
		}

		public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&since_id=", sinceId);
		}

		public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&since_id=", sinceId, "&per_page=", perPage);
		}

		public virtual void ListTweetsOnListSince(string ownerScreenName, string slug, long sinceId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&since_id=", sinceId, "&page=", page, "&per_page=", perPage);
		}

		public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&max_id=", maxId);
		}

		public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&max_id=", maxId, "&per_page=", perPage);
		}

		public virtual void ListTweetsOnListBefore(string ownerScreenName, string slug, long maxId, int page, int perPage, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "lists/statuses", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&max_id=", maxId, "&page=", page, "&per_page=", perPage);
		}

		public virtual void ListListMembershipsFor(string screenName, bool filterToOwnedLists, long cursor, Action<TwitterCursorList<TwitterList>, TwitterResponse> action)
		{
			WithHammock(action, "lists/memberships", FormatAsString, "?screen_name=", screenName, "&filter_to_owned_lists=", filterToOwnedLists, "&cursor=", cursor);
		}

		public virtual void ListListMembers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "lists/members", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&cursor=", cursor);
		}

		public virtual void AddListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/members/create", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&screen_name=", screenName);
		}

		public virtual void RemoveListMember(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/members/destroy", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&screen_name=", screenName);
		}

		public virtual void VerifyListMembership(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "lists/members/show", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&screen_name=", screenName);
		}

		public virtual void ListListSubscriptionsFor(string screenName, Action<IEnumerable<TwitterList>, TwitterResponse> action)
		{
			WithHammock(action, "lists/all", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void ListListSubscribers(string ownerScreenName, string slug, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "lists/subscribers", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&cursor=", cursor);
		}

		public virtual void FollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/subscribers/create", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug);
		}

		public virtual void UnfollowList(string ownerScreenName, string slug, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "lists/subscribers/destroy", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug);
		}

		public virtual void VerifyListSubscription(string ownerScreenName, string slug, string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "lists/subscribers/show", FormatAsString, "?owner_screen_name=", ownerScreenName, "&slug=", slug, "&screen_name=", screenName);
		}

		public virtual void FollowUserNotifications(string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "users/notifications/follow", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void FollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "users/notifications/follow", FormatAsString, "?user_id=", userId);
		}

		public virtual void UnfollowUserNotifications(int userId, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "users/notifications/leave", FormatAsString, "?user_id=", userId);
		}

		public virtual void UnfollowUserNotifications(string userScreenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "users/notifications/leave", FormatAsString, "?user_screen_name=", userScreenName);
		}

		public virtual void ListSavedSearches(Action<IEnumerable<TwitterSavedSearch>, TwitterResponse> action)
		{
			WithHammock(action, "saved_searches", FormatAsString);
		}

		public virtual void GetSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action)
		{
			WithHammock(action, "saved_searches/show", FormatAsString, "?id=", id);
		}

		public virtual void CreateSavedSearch(string query, Action<TwitterSavedSearch, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "saved_searches/create", FormatAsString, "?query=", query);
		}

		public virtual void DeleteSavedSearch(long id, Action<TwitterSavedSearch, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "saved_searches/destroy/{id}", FormatAsString, "?id=", id);
		}

		public virtual void Search(string q, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q);
		}

		public virtual void Search(string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q, "&result_type=", resultType);
		}

		public virtual void Search(string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q, "&rpp=", rpp);
		}

		public virtual void Search(string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void Search(string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q, "&page=", page, "&rpp=", rpp);
		}

		public virtual void Search(string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?q=", q, "&page=", page, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void SearchSince(long since_id, string q, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q);
		}

		public virtual void SearchSince(long since_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q, "&result_type=", resultType);
		}

		public virtual void SearchSince(long since_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q, "&rpp=", rpp);
		}

		public virtual void SearchSince(long since_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void SearchSince(long since_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q, "&page=", page, "&rpp=", rpp);
		}

		public virtual void SearchSince(long since_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?since_id=", since_id, "&q=", q, "&page=", page, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void SearchBefore(long max_id, string q, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q);
		}

		public virtual void SearchBefore(long max_id, string q, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q, "&result_type=", resultType);
		}

		public virtual void SearchBefore(long max_id, string q, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q, "&rpp=", rpp);
		}

		public virtual void SearchBefore(long max_id, string q, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void SearchBefore(long max_id, string q, int page, int rpp, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q, "&page=", page, "&rpp=", rpp);
		}

		public virtual void SearchBefore(long max_id, string q, int page, int rpp, TwitterSearchResultType resultType, Action<TwitterSearchResult, TwitterResponse> action)
		{
			WithHammock(action, "search", FormatAsString, "?max_id=", max_id, "&q=", q, "&page=", page, "&rpp=", rpp, "&result_type=", resultType);
		}

		public virtual void ListTweetsOnPublicTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/public_timeline", FormatAsString);
		}

		public virtual void ListTweetsOnHomeTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString);
		}

		public virtual void ListTweetsOnHomeTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?count=", count);
		}

		public virtual void ListTweetsOnHomeTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnHomeTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListTweetsOnHomeTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListTweetsOnHomeTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnHomeTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListTweetsOnHomeTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListTweetsOnHomeTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/home_timeline", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnFriendsTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString);
		}

		public virtual void ListTweetsOnFriendsTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?count=", count);
		}

		public virtual void ListTweetsOnFriendsTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListTweetsOnFriendsTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListTweetsOnFriendsTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends_timeline", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnUserTimeline(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString);
		}

		public virtual void ListTweetsOnUserTimeline(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?count=", count);
		}

		public virtual void ListTweetsOnUserTimeline(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnUserTimelineSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListTweetsOnUserTimelineSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListTweetsOnUserTimelineSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnUserTimelineBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListTweetsOnUserTimelineBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListTweetsOnUserTimelineBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId);
		}

		public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimeline(int userId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&since_id=", sinceId);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&since_id=", sinceId, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(int userId, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&max_id=", maxId);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&max_id=", maxId, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(int userId, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?user_id=", userId, "&max_id=", maxId, "&page=", page, "&count=", count);
		}

        public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&include_rts=", includeRT);
        }

		public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimeline(string screenName, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&since_id=", sinceId);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&since_id=", sinceId, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineSince(string screenName, long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&max_id=", maxId);
		}

        public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, bool includeRT, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&max_id=", maxId, "&include_rts=", includeRT);
        }

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&max_id=", maxId, "&page=", page);
		}

		public virtual void ListTweetsOnSpecifiedUserTimelineBefore(string screenName, long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/user_timeline", FormatAsString, "?screen_name=", screenName, "&max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsMentioningMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString);
		}

		public virtual void ListTweetsMentioningMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?count=", count);
		}

        public virtual void ListTweetsMentioningMe(int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            WithHammock(action, "statuses/mentions", FormatAsString, "?count=", count, "&include_rts=", includeRetweets.ToString().ToLowerInvariant());
        }

		public virtual void ListTweetsMentioningMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListTweetsMentioningMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListTweetsMentioningMeSince(long sinceId, int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
            WithHammock(action, "statuses/mentions", FormatAsString, "?since_id=", sinceId, "&count=", count, "&include_rts=", includeRetweets.ToString().ToLowerInvariant());
		}

        public virtual void ListTweetsMentioningMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            WithHammock(action, "statuses/mentions", FormatAsString, "?since_id=", sinceId, "&count=", count);
        }

		public virtual void ListTweetsMentioningMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListTweetsMentioningMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListTweetsMentioningMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

        public virtual void ListTweetsMentioningMeBefore(long maxId, int count, bool includeRetweets, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
        {
            WithHammock(action, "statuses/mentions", FormatAsString, "?max_id=", maxId, "&count=", count, "&include_rts=", includeRetweets.ToString().ToLowerInvariant());
        }

		public virtual void ListTweetsMentioningMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/mentions", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsByMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString);
		}

		public virtual void ListRetweetsByMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?count=", count);
		}

		public virtual void ListRetweetsByMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListRetweetsByMe(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListRetweetsByMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListRetweetsByMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsByMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListRetweetsByMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListRetweetsByMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_by_me", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsToMe(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString);
		}

		public virtual void ListRetweetsToMe(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?count=", count);
		}

		public virtual void ListRetweetsToMe(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListRetweetsToMeSince(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListRetweetsToMeSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListRetweetsToMeSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsToMeBefore(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListRetweetsToMeBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListRetweetsToMeBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweeted_to_me", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsOfMyTweets(Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString);
		}

		public virtual void ListRetweetsOfMyTweets(int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?count=", count);
		}

		public virtual void ListRetweetsOfMyTweets(int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?page=", page, "&count=", count);
		}

		public virtual void ListRetweetsOfMyTweets(long sinceId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?since_id=", sinceId);
		}

		public virtual void ListRetweetsOfMyTweetsSince(long sinceId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?since_id=", sinceId, "&count=", count);
		}

		public virtual void ListRetweetsOfMyTweetsSince(long sinceId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?since_id=", sinceId, "&page=", page, "&count=", count);
		}

		public virtual void ListRetweetsOfMyTweetsSince(long maxId, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?max_id=", maxId);
		}

		public virtual void ListRetweetsOfMyTweetsBefore(long maxId, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?max_id=", maxId, "&count=", count);
		}

		public virtual void ListRetweetsOfMyTweetsBefore(long maxId, int page, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets_of_me", FormatAsString, "?max_id=", maxId, "&page=", page, "&count=", count);
		}

		public virtual void ListCurrentTrends(Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/current", FormatAsString);
		}

		public virtual void ListCurrentTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/current", FormatAsString, "?exclude=", exclude);
		}

		public virtual void ListDailyTrends(Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/daily", FormatAsString);
		}

		public virtual void ListDailyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/daily", FormatAsString, "?date=", date);
		}

		public virtual void ListDailyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/daily", FormatAsString, "?exclude=", exclude);
		}

		public virtual void ListDailyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/daily", FormatAsString, "?date=", date, "&exclude=", exclude);
		}

		public virtual void ListWeeklyTrends(Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/weekly", FormatAsString);
		}

		public virtual void ListWeeklyTrends(DateTime date, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/weekly", FormatAsString, "?date=", date);
		}

		public virtual void ListWeeklyTrends(string exclude, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/weekly", FormatAsString, "?exclude=", exclude);
		}

		public virtual void ListWeeklyTrends(DateTime date, string exclude, Action<TwitterTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/weekly", FormatAsString, "?date=", date, "&exclude=", exclude);
		}

		public virtual void ListAvailableTrendsLocations(Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
		{
			WithHammock(action, "trends/available", FormatAsString);
		}

		public virtual void ListAvailableTrendsLocations(double lat, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
		{
			WithHammock(action, "trends/available", FormatAsString, "?lat=", lat);
		}

		public virtual void ListAvailableTrendsLocations(double lat, double @long, Action<IEnumerable<WhereOnEarthLocation>, TwitterResponse> action)
		{
			WithHammock(action, "trends/available", FormatAsString, "?lat=", lat, "&long=", @long);
		}

		public virtual void ListLocalTrendsFor(long woeId, Action<TwitterLocalTrends, TwitterResponse> action)
		{
			WithHammock(action, "trends/{woe_id}", FormatAsString, "?woe_id=", woeId);
		}

		public virtual void GetTweet(long id, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(action, "statuses/show/{id}", FormatAsString, "?id=", id);
		}

		public virtual void SendTweet(string status, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "statuses/update", FormatAsString, "?status=", status);
		}

		public virtual void SendTweet(string status, double lat, double @long, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "statuses/update", FormatAsString, "?status=", status, "&lat=", lat, "&long=", @long);
		}

		public virtual void SendTweet(string status, long inReplyToStatusId, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "statuses/update", FormatAsString, "?status=", status, "&in_reply_to_status_id=", inReplyToStatusId);
		}

		public virtual void SendTweet(string status, long inReplyToStatusId, double lat, double @long, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "statuses/update", FormatAsString, "?status=", status, "&in_reply_to_status_id=", inReplyToStatusId, "&lat=", lat, "&long=", @long);
		}

		public virtual void DeleteTweet(long id, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Delete, action, "statuses/destroy/{id}", FormatAsString, "?id=", id);
		}

		public virtual void Retweet(long id, Action<TwitterStatus, TwitterResponse> action)
		{
			WithHammock(WebMethod.Post, action, "statuses/retweet/{id}", FormatAsString, "?id=", id);
		}

		public virtual void Retweets(long id, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets/{id}", FormatAsString, "?id=", id);
		}

		public virtual void Retweets(long id, int count, Action<IEnumerable<TwitterStatus>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/retweets/{id}", FormatAsString, "?id=", id, "&count=", count);
		}

		public virtual void ListUsersWhoRetweeted(long id, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/{id}/retweeted_by", FormatAsString, "?id=", id);
		}

		public virtual void ListUsersWhoRetweeted(long id, int count, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/{id}/retweeted_by", FormatAsString, "?id=", id, "&count=", count);
		}

		public virtual void ListUserIdsWhoRetweeted(long id, Action<IEnumerable<int>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/{id}/retweeted_by/ids", FormatAsString, "?id=", id);
		}

		public virtual void ListUserIdsWhoRetweeted(long id, int count, Action<IEnumerable<int>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/{id}/retweeted_by/ids", FormatAsString, "?id=", id, "&count=", count);
		}

		public virtual void ListFriends(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString);
		}

		public virtual void ListFriends(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString, "?cursor=", cursor);
		}

		public virtual void ListFriendsOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString, "?user_id=", userId);
		}

		public virtual void ListFriendsOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString, "?user_id=", userId, "&cursor=", cursor);
		}

		public virtual void ListFriendsOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void ListFriendsOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/friends", FormatAsString, "?screen_name=", screenName, "&cursor=", cursor);
		}

		public virtual void ListFollowers(Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString);
		}

		public virtual void ListFollowers(long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString, "?cursor=", cursor);
		}

		public virtual void ListFollowersOf(int userId, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString, "?user_id=", userId);
		}

		public virtual void ListFollowersOf(int userId, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString, "?user_id=", userId, "&cursor=", cursor);
		}

		public virtual void ListFollowersOf(string screenName, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void ListFollowersOf(string screenName, long cursor, Action<TwitterCursorList<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "statuses/followers", FormatAsString, "?screen_name=", screenName, "&cursor=", cursor);
		}

		public virtual void GetUserProfile(Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "account/verify_credentials", FormatAsString);
		}

		public virtual void GetUserProfileFor(string screenName, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "users/show", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void GetUserProfileFor(int id, Action<TwitterUser, TwitterResponse> action)
		{
			WithHammock(action, "users/show", FormatAsString, "?id=", id);
		}

		public virtual void SearchForUser(string q, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/search", FormatAsString, "?q=", q);
		}

		public virtual void SearchForUser(string q, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/search", FormatAsString, "?q=", q, "&per_page=", perPage);
		}

		public virtual void SearchForUser(string q, int page, int perPage, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/search", FormatAsString, "?q=", q, "&page=", page, "&per_page=", perPage);
		}

		public virtual void ListUserProfilesFor(IEnumerable<string> screenName, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/lookup", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void ListUserProfilesFor(IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/lookup", FormatAsString, "?user_id=", userId);
		}

		public virtual void ListUserProfilesFor(IEnumerable<string> screenName, IEnumerable<int> userId, Action<IEnumerable<TwitterUser>, TwitterResponse> action)
		{
			WithHammock(action, "users/lookup", FormatAsString, "?screen_name=", screenName, "&user_id=", userId);
		}

		public virtual void GetProfileImageFor(string screenName, Action<byte[], TwitterResponse> action)
		{
			WithHammock(action, "users/profile_image/{screen_name}", FormatAsString, "?screen_name=", screenName);
		}

		public virtual void GetProfileImageFor(string screenName, TwitterProfileImageSize size, Action<byte[], TwitterResponse> action)
		{
			WithHammock(action, "users/profile_image/{screen_name}", FormatAsString, "?screen_name=", screenName, "&size=", size);
		}

		public virtual void ListSuggestedUserCategories(Action<IEnumerable<TwitterUserSuggestions>, TwitterResponse> action)
		{
			WithHammock(action, "users/suggestions", FormatAsString);
		}

		public virtual void ListSuggestedUsers(string categorySlug, Action<TwitterUserSuggestions, TwitterResponse> action)
		{
			WithHammock(action, "/users/suggestions/{category_slug}", FormatAsString, "?category_slug=", categorySlug);
		}

		public virtual void GetPlace(string id, Action<TwitterPlace, TwitterResponse> action)
		{
			WithHammock(action, "geo/id/{id}", FormatAsString, "?id=", id);
		}

		public virtual void ReverseGeocode(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
		{
			WithHammock(action, "geo/reverse_geocode", FormatAsString, "?lat=", lat, "&long=", @long);
		}

		public virtual void GeoSearchByCoordinates(double lat, double @long, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
		{
			WithHammock(action, "geo/search", FormatAsString, "?lat=", lat, "&long=", @long);
		}

		public virtual void GeoSearchByQuery(string query, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
		{
			WithHammock(action, "geo/search", FormatAsString, "?query=", query);
		}

		public virtual void GeoSearchByIp(string ip, Action<IEnumerable<TwitterPlace>, TwitterResponse> action)
		{
			WithHammock(action, "geo/search", FormatAsString, "?ip=", ip);
		}

        public virtual void ReportSpam(string username, Action<TwitterUser, TwitterResponse> action)
        {
            WithHammock(WebMethod.Post, action, "report_spam", FormatAsString, "?screen_name=", username);
        }

        public virtual void ReportSpam(long id, Action<TwitterUser, TwitterResponse> action)
        {
            WithHammock(WebMethod.Post, action, "report_spam", FormatAsString, "?user_id=", id.ToString());
        }

		#endregion	
	}

	#endregion
}
