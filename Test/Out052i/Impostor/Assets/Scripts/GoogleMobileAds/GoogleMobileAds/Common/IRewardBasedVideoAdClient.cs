using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x200002B")]
	public interface IRewardBasedVideoAdClient
	{
		[Token(Token = "0x14000059")]
		event EventHandler<EventArgs> OnAdLoaded;

		[Token(Token = "0x1400005A")]
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x1400005B")]
		event EventHandler<EventArgs> OnAdOpening;

		[Token(Token = "0x1400005C")]
		event EventHandler<EventArgs> OnAdStarted;

		[Token(Token = "0x1400005D")]
		event EventHandler<Reward> OnAdRewarded;

		[Token(Token = "0x1400005E")]
		event EventHandler<EventArgs> OnAdClosed;

		[Token(Token = "0x1400005F")]
		event EventHandler<EventArgs> OnAdLeavingApplication;

		[Token(Token = "0x14000060")]
		event EventHandler<EventArgs> OnAdCompleted;

		[Token(Token = "0x60001FE")]
		void CreateRewardBasedVideoAd();

		[Token(Token = "0x60001FF")]
		void LoadAd(AdRequest request, string adUnitId);

		[Token(Token = "0x6000200")]
		bool IsLoaded();

		[Token(Token = "0x6000201")]
		string MediationAdapterClassName();

		[Token(Token = "0x6000202")]
		void ShowRewardBasedVideoAd();

		[Token(Token = "0x6000203")]
		void SetUserId(string userId);
	}
}
