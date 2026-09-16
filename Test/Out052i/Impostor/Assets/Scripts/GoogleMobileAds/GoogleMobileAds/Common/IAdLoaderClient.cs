using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000024")]
	public interface IAdLoaderClient
	{
		[Token(Token = "0x1400004A")]
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x1400004B")]
		event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdLoaded;

		[Token(Token = "0x1400004C")]
		event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdClicked;

		[Token(Token = "0x60001AE")]
		void LoadAd(AdRequest request);
	}
}
