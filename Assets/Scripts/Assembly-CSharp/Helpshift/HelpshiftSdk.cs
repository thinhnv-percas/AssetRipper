using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Helpshift
{
	[Token(Token = "0x20007FA")]
	public class HelpshiftSdk
	{
		[Token(Token = "0x4001A8E")]
		private const string PLUGIN_VERSION = "10.4.0";

		[Token(Token = "0x4001A8F")]
		public const string ENABLE_LOGGING = "enableLogging";

		[Token(Token = "0x4001A90")]
		public const string ENABLE_INAPP_NOTIFICATION = "enableInAppNotification";

		[Token(Token = "0x4001A91")]
		public const string INAPP_NOTIFICATION_APPEARANCE = "inAppNotificationAppearance";

		[Token(Token = "0x4001A92")]
		public const string INAPP_NOTIFICATION_BANNER_BACKGROUND_COLOR = "bannerBackgroundColor";

		[Token(Token = "0x4001A93")]
		public const string INAPP_NOTIFICATION_BANNER_TEXT_COLOR = "textColor";

		[Token(Token = "0x4001A94")]
		private static HelpshiftSdk instance;

		[Token(Token = "0x4001A95")]
		private static HelpshiftXiOS nativeSdk;

		[Token(Token = "0x60021C6")]
		[Address(RVA = "0x3DC9DA4", Offset = "0x3DC9DA4", Length = "0x8")]
		private HelpshiftSdk()
		{
		}

		[Token(Token = "0x60021C7")]
		[Address(RVA = "0x3DC9DAC", Offset = "0x3DC9DAC", Length = "0xE0")]
		public static HelpshiftSdk GetInstance()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::GetInstance");
			return default;
		}

		[Token(Token = "0x60021C8")]
		[Address(RVA = "0x3DC9E94", Offset = "0x3DC9E94", Length = "0x1B0")]
		public void Install(string appId, string domainName, Dictionary<string, object> config = null)
		{
			bool flag = config == null;
			bool flag2 = !flag;
			Dictionary<string, object> dictionary = config;
			if (!flag2)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary = dictionary2;
			}
			dictionary.Add("sdkType", "unityx");
			dictionary.Add("pluginVersion", "10.4.0");
			string unityVersion = Application.unityVersion;
			dictionary.Add("runtimeVersion", unityVersion);
			((HelpshiftXiOS)(object)dictionary).Install(appId, domainName, dictionary);
		}

		[Token(Token = "0x60021C9")]
		[Address(RVA = "0x3DCA31C", Offset = "0x3DCA31C", Length = "0x64")]
		public bool Login(Dictionary<string, string> userData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::Login");
			return default;
		}

		[Token(Token = "0x60021CA")]
		[Address(RVA = "0x3DCA4E0", Offset = "0x3DCA4E0", Length = "0x64")]
		public void HandleProactiveLink(string proactiveLink)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::HandleProactiveLink");
		}

		[Token(Token = "0x60021CB")]
		[Address(RVA = "0x3DCA5E8", Offset = "0x3DCA5E8", Length = "0xB8")]
		public void SetHelpshiftProactiveConfigCollector(IHelpshiftProactiveAPIConfigCollector eventsListener)
		{
			HelpshiftInternalLogger.d("Proactive Event listener is set");
			HelpshiftXiOSDelegate.SetExternalProactiveDelegate(eventsListener);
		}

		[Obsolete("ClearAnonymousUserOnLogin is deprecated, please use ClearAnonymousUserOnLogin(Boolean clearAnonymousUser) instead.")]
		[Token(Token = "0x60021CC")]
		[Address(RVA = "0x3DCA71C", Offset = "0x3DCA71C", Length = "0x58")]
		public void ClearAnonymousUserOnLogin()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ClearAnonymousUserOnLogin");
		}

		[Token(Token = "0x60021CD")]
		[Address(RVA = "0x3DCA830", Offset = "0x3DCA830", Length = "0x64")]
		public void ClearAnonymousUserOnLogin(bool shouldClear)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ClearAnonymousUserOnLogin");
		}

		[Token(Token = "0x60021CE")]
		[Address(RVA = "0x3DCA894", Offset = "0x3DCA894", Length = "0x64")]
		public void AddUserTrail(string trail)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::AddUserTrail");
		}

		[Token(Token = "0x60021CF")]
		[Address(RVA = "0x3DCA99C", Offset = "0x3DCA99C", Length = "0xD0")]
		public void Logout()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::Logout");
		}

		[Token(Token = "0x60021D0")]
		[Address(RVA = "0x3DCAB00", Offset = "0x3DCAB00", Length = "0x64")]
		public void RegisterPushToken(string token)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::RegisterPushToken");
		}

		[Token(Token = "0x60021D1")]
		[Address(RVA = "0x3DCAC08", Offset = "0x3DCAC08", Length = "0x64")]
		public void ShowConversation(Dictionary<string, object> configMap = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ShowConversation");
		}

		[Token(Token = "0x60021D2")]
		[Address(RVA = "0x3DCAE08", Offset = "0x3DCAE08", Length = "0x64")]
		public void ShowFAQs(Dictionary<string, object> configMap = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ShowFAQs");
		}

		[Token(Token = "0x60021D3")]
		[Address(RVA = "0x3DCB008", Offset = "0x3DCB008", Length = "0x6C")]
		public void ShowSingleFAQ(string faqId, Dictionary<string, object> configMap = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ShowSingleFAQ");
		}

		[Token(Token = "0x60021D4")]
		[Address(RVA = "0x3DCB234", Offset = "0x3DCB234", Length = "0x6C")]
		public void ShowFAQSection(string sectionId, Dictionary<string, object> configMap = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::ShowFAQSection");
		}

		[Token(Token = "0x60021D5")]
		[Address(RVA = "0x3DCB460", Offset = "0x3DCB460", Length = "0x64")]
		public void RequestUnreadMessageCount(bool shouldFetchFromServer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::RequestUnreadMessageCount");
		}

		[Token(Token = "0x60021D6")]
		[Address(RVA = "0x3DCB580", Offset = "0x3DCB580", Length = "0x364")]
		public unsafe void HandlePushNotification(Dictionary<string, object> pushNotificationData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::HandlePushNotification");
		}

		[Token(Token = "0x60021D7")]
		[Address(RVA = "0x3DCBA84", Offset = "0x3DCBA84", Length = "0x64")]
		public void SetSDKLanguage(string locale)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::SetSDKLanguage");
		}

		[Token(Token = "0x60021D8")]
		[Address(RVA = "0x3DCBB8C", Offset = "0x3DCBB8C", Length = "0x64")]
		public void UpdateAppAttributes(Dictionary<string, object> attritbutes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::UpdateAppAttributes");
		}

		[Token(Token = "0x60021D9")]
		[Address(RVA = "0x3DCBD2C", Offset = "0x3DCBD2C", Length = "0x64")]
		public void UpdateMasterAttributes(Dictionary<string, object> attritbutes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::UpdateMasterAttributes");
		}

		[Token(Token = "0x60021DA")]
		[Address(RVA = "0x3DCBECC", Offset = "0x3DCBECC", Length = "0x64")]
		public void AddUserIdentities(string identitiesJwt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::AddUserIdentities");
		}

		[Token(Token = "0x60021DB")]
		[Address(RVA = "0x3DCBFD4", Offset = "0x3DCBFD4", Length = "0x7C")]
		public void LoginWithIdentity(string identitiesJwt, Dictionary<string, object> loginConfig, IHelpshiftUserLoginEventListener helpshiftUserLoginEventListener)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::LoginWithIdentity");
		}

		[Token(Token = "0x60021DC")]
		[Address(RVA = "0x3DCC1B0", Offset = "0x3DCC1B0", Length = "0x74")]
		public void LeaveBreadcrumb(string breadcrumb)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD68");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x60021DD")]
		[Address(RVA = "0x3DCC250", Offset = "0x3DCC250", Length = "0x54")]
		public void ClearBreadcrumbs()
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD2C");
		}

		[Token(Token = "0x60021DE")]
		[Address(RVA = "0x3DCC2A8", Offset = "0x3DCC2A8", Length = "0xB8")]
		public void SetHelpshiftEventsListener(IHelpshiftEventsListener eventsListener)
		{
			HelpshiftInternalLogger.d("Event listener is set");
			HelpshiftXiOSDelegate.SetExternalDelegate(eventsListener);
		}

		[Token(Token = "0x60021DF")]
		[Address(RVA = "0x3DCC3DC", Offset = "0x3DCC3DC", Length = "0x44")]
		public string SdkVersion()
		{
			return "10.4.0";
		}

		[Token(Token = "0x60021E0")]
		[Address(RVA = "0x3DCC420", Offset = "0x3DCC420", Length = "0x54")]
		public void CloseSession()
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD38");
		}

		[Token(Token = "0x60021E1")]
		[Address(RVA = "0x3DCC478", Offset = "0x3DCC478", Length = "0x64")]
		public void PauseDisplayOfInAppNotification(bool pauseInAppNotifications)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftSdk::PauseDisplayOfInAppNotification");
		}
	}
}
