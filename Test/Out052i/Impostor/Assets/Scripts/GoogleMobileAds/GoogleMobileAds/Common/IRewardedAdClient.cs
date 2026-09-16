using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x200002C")]
	public interface IRewardedAdClient
	{
		[Token(Token = "0x14000061")]
		event EventHandler<EventArgs> OnAdLoaded;

		[Token(Token = "0x14000062")]
		event EventHandler<AdErrorEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x14000063")]
		event EventHandler<AdErrorEventArgs> OnAdFailedToShow;

		[Token(Token = "0x14000064")]
		event EventHandler<EventArgs> OnAdOpening;

		[Token(Token = "0x14000065")]
		event EventHandler<Reward> OnUserEarnedReward;

		[Token(Token = "0x14000066")]
		event EventHandler<EventArgs> OnAdClosed;

		[Token(Token = "0x14000067")]
		event EventHandler<AdValueEventArgs> OnPaidEvent;

		[Token(Token = "0x6000212")]
		void CreateRewardedAd(string adUnitId);

		[Token(Token = "0x6000213")]
		void LoadAd(AdRequest request);

		[Token(Token = "0x6000214")]
		bool IsLoaded();

		[Token(Token = "0x6000215")]
		string MediationAdapterClassName();

		[Token(Token = "0x6000216")]
		Reward GetRewardItem();

		[Token(Token = "0x6000217")]
		void Show();

		[Token(Token = "0x6000218")]
		void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions);

		[Token(Token = "0x6000219")]
		IResponseInfoClient GetResponseInfoClient();
	}
}
