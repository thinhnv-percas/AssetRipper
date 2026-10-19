using System;
using System.Collections.Generic;
using AdjustSdk;
using Cpp2ILInjected;

namespace ElephantSDK
{
	[Token(Token = "0x2000944")]
	public class ElephantAdjustManager : IAdjustElephantAdapter, IElephantAdapter
	{
		[Token(Token = "0x1700045C")]
		public string IronSourceAdRevenueSource
		{
			[Token(Token = "0x6002791")]
			[Address(RVA = "0x3E42FD4", Offset = "0x3E42FD4", Length = "0x44")]
			get
			{
				return "ironsource_sdk";
			}
		}

		[Token(Token = "0x1700045D")]
		public string AppLovinMAXRevenueSource
		{
			[Token(Token = "0x6002792")]
			[Address(RVA = "0x3E43018", Offset = "0x3E43018", Length = "0x44")]
			get
			{
				return "applovin_max_sdk";
			}
		}

		[Token(Token = "0x600278A")]
		[Address(RVA = "0x3E42444", Offset = "0x3E42444", Length = "0x320")]
		public void InitAdjust(string adjustAppKey, bool isCvUpdateServiceEnabled, Action<string> deepLinkCallback, bool isLowerThanIos145 = false)
		{
			ElephantLog.Log("ADJUST-ELEPHANT", "InitAdjust is Called");
			if (string.IsNullOrEmpty(adjustAppKey))
			{
				ElephantLog.LogError("ElephantAdjustManager", "AdjustAppKey is not filled, check Elephant Dashboard");
				return;
			}
			AdjustConfig adjustConfig = new AdjustConfig(ElephantThirdPartyIds.AdjustAppKey, AdjustEnvironment.Production);
			Action<AdjustAttribution> _003CAttributionChangedDelegate_003Ek__BackingField = OnAttrChange;
			adjustConfig.AttributionChangedDelegate = _003CAttributionChangedDelegate_003Ek__BackingField;
			adjustConfig.FbAppId = ElephantThirdPartyIds.FacebookAppId;
			if (!isLowerThanIos145)
			{
				RemoteConfig instance = RemoteConfig.GetInstance();
				if (instance.GetBool("conversion_value_service_enabled"))
				{
					bool? isSkanAttributionEnabled = false;
					adjustConfig.IsSkanAttributionEnabled = isSkanAttributionEnabled;
				}
			}
			bool? isDeferredDeeplinkOpeningEnabled = true;
			adjustConfig.IsDeferredDeeplinkOpeningEnabled = isDeferredDeeplinkOpeningEnabled;
			adjustConfig.DeferredDeeplinkDelegate = deepLinkCallback;
			Adjust.InitSdk(adjustConfig);
			ElephantCore instance2 = ElephantCore.Instance;
			if (instance2.ZyngaPublishingElephantAdapter != null)
			{
				instance2.ZyngaPublishingElephantAdapter.LogAdjustInitializedEvent();
			}
		}

		[Token(Token = "0x600278B")]
		[Address(RVA = "0x3E42764", Offset = "0x3E42764", Length = "0x220")]
		private void OnAttrChange(AdjustAttribution adjustAttribution)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantAdjustManager::OnAttrChange");
		}

		[Token(Token = "0x600278C")]
		[Address(RVA = "0x3E42A50", Offset = "0x3E42A50", Length = "0xD8")]
		public void TrackPurchaseRevenue(string token, double revenue, string currency)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantAdjustManager::TrackPurchaseRevenue");
		}

		[Token(Token = "0x600278D")]
		[Address(RVA = "0x3E42B28", Offset = "0x3E42B28", Length = "0xAC")]
		public void TrackAdjustEvent(string token)
		{
			ElephantLog.Log("ADJUST-ELEPHANT", "TrackAdjustEvent is Called");
			AdjustEvent adjustEvent = new AdjustEvent(token);
			Adjust.TrackEvent(adjustEvent);
		}

		[Token(Token = "0x600278E")]
		[Address(RVA = "0x3E42BD4", Offset = "0x3E42BD4", Length = "0x1A4")]
		public void SetTrackThirdPartySharing(bool isEea, bool adPersonalizationStatus, bool adUserDataStatus)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantAdjustManager::SetTrackThirdPartySharing");
		}

		[Token(Token = "0x600278F")]
		[Address(RVA = "0x3E42D78", Offset = "0x3E42D78", Length = "0x17C")]
		public void SetTrackThirdPartySharing(bool isEea)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantAdjustManager::SetTrackThirdPartySharing");
		}

		[Token(Token = "0x6002790")]
		[Address(RVA = "0x3E42EF4", Offset = "0x3E42EF4", Length = "0xE0")]
		public void SetTrackThirdPartySharingForCcpa(bool enabled)
		{
			ElephantLog.Log("ADJUST-ELEPHANT", "SetAdjustConsentCcpa is Called");
			bool? isEnabled = enabled;
			AdjustThirdPartySharing thirdPartySharing = new AdjustThirdPartySharing(isEnabled);
			Adjust.TrackThirdPartySharing(thirdPartySharing);
		}

		[Token(Token = "0x6002793")]
		[Address(RVA = "0x3E4305C", Offset = "0x3E4305C", Length = "0x29C")]
		public unsafe void TrackAdRevenue(string source, double revenue, string currency, string network, string unit, string placement, string format = null, string adUnitId = null, Dictionary<string, string> extraParams = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantAdjustManager::TrackAdRevenue");
		}

		[Token(Token = "0x6002794")]
		[Address(RVA = "0x3E4298C", Offset = "0x3E4298C", Length = "0xC4")]
		public void GetAdid(Action<string> callback)
		{
			Action<string> callback2 = delegate(string adId)
			{
				if (callback != null)
				{
					callback(adId);
				}
			};
			Adjust.GetAdid(callback2);
		}

		[Token(Token = "0x6002795")]
		[Address(RVA = "0x3E43300", Offset = "0x3E43300", Length = "0x10")]
		public void AddSessionCallbackParameter(string key, string value)
		{
			Adjust.AddGlobalCallbackParameter(key, value);
		}

		[Token(Token = "0x6002796")]
		[Address(RVA = "0x3E42434", Offset = "0x3E42434", Length = "0x8")]
		public ElephantAdjustManager()
		{
		}
	}
}
