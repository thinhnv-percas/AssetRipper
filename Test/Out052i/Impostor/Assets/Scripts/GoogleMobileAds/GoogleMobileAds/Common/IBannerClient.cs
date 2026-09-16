using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000025")]
	public interface IBannerClient
	{
		[Token(Token = "0x1400004D")]
		event EventHandler<EventArgs> OnAdLoaded;

		[Token(Token = "0x1400004E")]
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x1400004F")]
		event EventHandler<EventArgs> OnAdOpening;

		[Token(Token = "0x14000050")]
		event EventHandler<EventArgs> OnAdClosed;

		[Token(Token = "0x14000051")]
		event EventHandler<EventArgs> OnAdLeavingApplication;

		[Token(Token = "0x14000052")]
		event EventHandler<AdValueEventArgs> OnPaidEvent;

		[Token(Token = "0x60001BB")]
		void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position);

		[Token(Token = "0x60001BC")]
		void CreateBannerView(string adUnitId, AdSize adSize, int x, int y);

		[Token(Token = "0x60001BD")]
		void LoadAd(AdRequest request);

		[Token(Token = "0x60001BE")]
		void ShowBannerView();

		[Token(Token = "0x60001BF")]
		void HideBannerView();

		[Token(Token = "0x60001C0")]
		void DestroyBannerView();

		[Token(Token = "0x60001C1")]
		float GetHeightInPixels();

		[Token(Token = "0x60001C2")]
		float GetWidthInPixels();

		[Token(Token = "0x60001C3")]
		void SetPosition(AdPosition adPosition);

		[Token(Token = "0x60001C4")]
		void SetPosition(int x, int y);

		[Token(Token = "0x60001C5")]
		string MediationAdapterClassName();

		[Token(Token = "0x60001C6")]
		IResponseInfoClient GetResponseInfoClient();
	}
}
