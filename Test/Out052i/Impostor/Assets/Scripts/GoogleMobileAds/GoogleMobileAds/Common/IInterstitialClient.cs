using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000028")]
	public interface IInterstitialClient
	{
		[Token(Token = "0x14000053")]
		event EventHandler<EventArgs> OnAdLoaded;

		[Token(Token = "0x14000054")]
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x14000055")]
		event EventHandler<EventArgs> OnAdOpening;

		[Token(Token = "0x14000056")]
		event EventHandler<EventArgs> OnAdClosed;

		[Token(Token = "0x14000057")]
		event EventHandler<EventArgs> OnAdLeavingApplication;

		[Token(Token = "0x14000058")]
		event EventHandler<AdValueEventArgs> OnPaidEvent;

		[Token(Token = "0x60001DB")]
		void CreateInterstitialAd(string adUnitId);

		[Token(Token = "0x60001DC")]
		void LoadAd(AdRequest request);

		[Token(Token = "0x60001DD")]
		bool IsLoaded();

		[Token(Token = "0x60001DE")]
		void ShowInterstitial();

		[Token(Token = "0x60001DF")]
		void DestroyInterstitial();

		[Token(Token = "0x60001E0")]
		string MediationAdapterClassName();

		[Token(Token = "0x60001E1")]
		IResponseInfoClient GetResponseInfoClient();
	}
}
