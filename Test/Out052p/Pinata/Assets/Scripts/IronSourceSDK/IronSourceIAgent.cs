using System.Collections.Generic;
using Cpp2ILInjected;

[Token(Token = "0x2000008")]
public interface IronSourceIAgent
{
	[Token(Token = "0x6000142")]
	void onApplicationPause(bool pause);

	[Token(Token = "0x6000143")]
	void setAge(int age);

	[Token(Token = "0x6000144")]
	void setGender(string gender);

	[Token(Token = "0x6000145")]
	void setMediationSegment(string segment);

	[Token(Token = "0x6000146")]
	string getAdvertiserId();

	[Token(Token = "0x6000147")]
	void validateIntegration();

	[Token(Token = "0x6000148")]
	void shouldTrackNetworkState(bool track);

	[Token(Token = "0x6000149")]
	bool setDynamicUserId(string dynamicUserId);

	[Token(Token = "0x600014A")]
	void setAdaptersDebug(bool enabled);

	[Token(Token = "0x600014B")]
	void setMetaData(string key, string value);

	[Token(Token = "0x600014C")]
	void setUserId(string userId);

	[Token(Token = "0x600014D")]
	void init(string appKey);

	[Token(Token = "0x600014E")]
	void init(string appKey, params string[] adUnits);

	[Token(Token = "0x600014F")]
	void initISDemandOnly(string appKey, params string[] adUnits);

	[Token(Token = "0x6000150")]
	void showRewardedVideo();

	[Token(Token = "0x6000151")]
	void showRewardedVideo(string placementName);

	[Token(Token = "0x6000152")]
	bool isRewardedVideoAvailable();

	[Token(Token = "0x6000153")]
	bool isRewardedVideoPlacementCapped(string placementName);

	[Token(Token = "0x6000154")]
	IronSourcePlacement getPlacementInfo(string name);

	[Token(Token = "0x6000155")]
	void setRewardedVideoServerParams(Dictionary<string, string> parameters);

	[Token(Token = "0x6000156")]
	void clearRewardedVideoServerParams();

	[Token(Token = "0x6000157")]
	void showISDemandOnlyRewardedVideo(string instanceId);

	[Token(Token = "0x6000158")]
	void loadISDemandOnlyRewardedVideo(string instanceId);

	[Token(Token = "0x6000159")]
	bool isISDemandOnlyRewardedVideoAvailable(string instanceId);

	[Token(Token = "0x600015A")]
	void loadInterstitial();

	[Token(Token = "0x600015B")]
	void showInterstitial();

	[Token(Token = "0x600015C")]
	void showInterstitial(string placementName);

	[Token(Token = "0x600015D")]
	bool isInterstitialReady();

	[Token(Token = "0x600015E")]
	bool isInterstitialPlacementCapped(string placementName);

	[Token(Token = "0x600015F")]
	void loadISDemandOnlyInterstitial(string instanceId);

	[Token(Token = "0x6000160")]
	void showISDemandOnlyInterstitial(string instanceId);

	[Token(Token = "0x6000161")]
	bool isISDemandOnlyInterstitialReady(string instanceId);

	[Token(Token = "0x6000162")]
	void showOfferwall();

	[Token(Token = "0x6000163")]
	void showOfferwall(string placementName);

	[Token(Token = "0x6000164")]
	bool isOfferwallAvailable();

	[Token(Token = "0x6000165")]
	void getOfferwallCredits();

	[Token(Token = "0x6000166")]
	void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position);

	[Token(Token = "0x6000167")]
	void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName);

	[Token(Token = "0x6000168")]
	void destroyBanner();

	[Token(Token = "0x6000169")]
	void displayBanner();

	[Token(Token = "0x600016A")]
	void hideBanner();

	[Token(Token = "0x600016B")]
	bool isBannerPlacementCapped(string placementName);

	[Token(Token = "0x600016C")]
	void setSegment(IronSourceSegment segment);

	[Token(Token = "0x600016D")]
	void setConsent(bool consent);
}
