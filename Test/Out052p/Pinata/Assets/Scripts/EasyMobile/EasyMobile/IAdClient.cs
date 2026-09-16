using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200002B")]
	public interface IAdClient
	{
		[Token(Token = "0x1700007F")]
		AdNetwork Network
		{
			[Token(Token = "0x60001E0")]
			get;
		}

		[Token(Token = "0x17000080")]
		bool IsBannerAdSupported
		{
			[Token(Token = "0x60001E1")]
			get;
		}

		[Token(Token = "0x17000081")]
		bool IsInterstitialAdSupported
		{
			[Token(Token = "0x60001E2")]
			get;
		}

		[Token(Token = "0x17000082")]
		bool IsRewardedAdSupported
		{
			[Token(Token = "0x60001E3")]
			get;
		}

		[Token(Token = "0x17000083")]
		bool IsSdkAvail
		{
			[Token(Token = "0x60001E4")]
			get;
		}

		[Token(Token = "0x17000084")]
		bool IsInitialized
		{
			[Token(Token = "0x60001E5")]
			get;
		}

		[Token(Token = "0x17000085")]
		List<AdPlacement> DefinedCustomInterstitialAdPlacements
		{
			[Token(Token = "0x6000200")]
			get;
		}

		[Token(Token = "0x17000086")]
		List<AdPlacement> DefinedCustomRewardedAdPlacements
		{
			[Token(Token = "0x6000201")]
			get;
		}

		[Token(Token = "0x1400000A")]
		event Action<IAdClient, AdPlacement> InterstitialAdCompleted;

		[Token(Token = "0x1400000B")]
		event Action<IAdClient, AdPlacement> RewardedAdSkipped;

		[Token(Token = "0x1400000C")]
		event Action<IAdClient, AdPlacement> RewardedAdCompleted;

		[Token(Token = "0x60001E6")]
		void Init();

		[Token(Token = "0x60001E7")]
		bool IsValidPlacement(AdPlacement placement, AdType type);

		[Token(Token = "0x60001E8")]
		void ShowBannerAd(BannerAdPosition position, BannerAdSize size);

		[Token(Token = "0x60001E9")]
		void HideBannerAd();

		[Token(Token = "0x60001EA")]
		void DestroyBannerAd();

		[Token(Token = "0x60001EB")]
		void ShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size);

		[Token(Token = "0x60001EC")]
		void HideBannerAd(AdPlacement placement);

		[Token(Token = "0x60001ED")]
		void DestroyBannerAd(AdPlacement placement);

		[Token(Token = "0x60001F0")]
		void LoadInterstitialAd();

		[Token(Token = "0x60001F1")]
		bool IsInterstitialAdReady();

		[Token(Token = "0x60001F2")]
		void ShowInterstitialAd();

		[Token(Token = "0x60001F3")]
		void LoadInterstitialAd(AdPlacement placement);

		[Token(Token = "0x60001F4")]
		bool IsInterstitialAdReady(AdPlacement placement);

		[Token(Token = "0x60001F5")]
		void ShowInterstitialAd(AdPlacement placement);

		[Token(Token = "0x60001FA")]
		void LoadRewardedAd();

		[Token(Token = "0x60001FB")]
		bool IsRewardedAdReady();

		[Token(Token = "0x60001FC")]
		void ShowRewardedAd();

		[Token(Token = "0x60001FD")]
		void LoadRewardedAd(AdPlacement placement);

		[Token(Token = "0x60001FE")]
		bool IsRewardedAdReady(AdPlacement placement);

		[Token(Token = "0x60001FF")]
		void ShowRewardedAd(AdPlacement placement);
	}
}
