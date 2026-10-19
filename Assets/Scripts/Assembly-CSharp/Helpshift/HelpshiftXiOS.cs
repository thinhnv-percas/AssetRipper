using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using HSMiniJSON;

namespace Helpshift
{
	[Token(Token = "0x2000802")]
	public class HelpshiftXiOS
	{
		[DllImport("__Internal")]
		[Token(Token = "0x60021F3")]
		[Address(RVA = "0x3DCCF1C", Offset = "0x3DCCF1C", Length = "0x6C")]
		private static extern void HsInstallForPlatformIdWithConfig(string platformId, string domainName, string jsonOptionsDict);

		[DllImport("__Internal")]
		[Token(Token = "0x60021F4")]
		[Address(RVA = "0x3DCCF88", Offset = "0x3DCCF88", Length = "0x28")]
		private static extern void HsShowConversationWithConfig(string jsonConfigDictionary);

		[DllImport("__Internal")]
		[Token(Token = "0x60021F5")]
		[Address(RVA = "0x3DCCFB0", Offset = "0x3DCCFB0", Length = "0x28")]
		private static extern void HsSetLanguage(string languageCode);

		[DllImport("__Internal")]
		[Token(Token = "0x60021F6")]
		[Address(RVA = "0x3DCCFD8", Offset = "0x3DCCFD8", Length = "0x38")]
		private static extern bool HsLogin(string jsonUserDetailsDict);

		[DllImport("__Internal")]
		[Token(Token = "0x60021F7")]
		[Address(RVA = "0x3DCD010", Offset = "0x3DCD010", Length = "0x4")]
		private static extern void HsLogout();

		[DllImport("__Internal")]
		[Token(Token = "0x60021F8")]
		[Address(RVA = "0x3DCD014", Offset = "0x3DCD014", Length = "0x28")]
		private static extern void HsRegisterDeviceToken(string deviceToken);

		[DllImport("__Internal")]
		[Token(Token = "0x60021F9")]
		[Address(RVA = "0x3DCD03C", Offset = "0x3DCD03C", Length = "0x4")]
		private static extern void HsPauseDisplayOfInAppNotification(bool pauseInApp);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FA")]
		[Address(RVA = "0x3DCD040", Offset = "0x3DCD040", Length = "0x30")]
		private static extern void HsHandleNotificationWithUserInfoDictionary(string jsonNotificationDataDict, bool isAppLaunch);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FB")]
		[Address(RVA = "0x3DCD070", Offset = "0x3DCD070", Length = "0x28")]
		private static extern void HsShowFaqsWithConfig(string configDictionaryString);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FC")]
		[Address(RVA = "0x3DCD098", Offset = "0x3DCD098", Length = "0x48")]
		private static extern void HsShowFaqSectionWithConfig(string faqSectionPublishID, string configDictionaryString);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FD")]
		[Address(RVA = "0x3DCD0E0", Offset = "0x3DCD0E0", Length = "0x48")]
		private static extern void HsShowSingleFaqWithConfig(string faqPublishID, string configDictionaryString);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FE")]
		[Address(RVA = "0x3DCD128", Offset = "0x3DCD128", Length = "0x4")]
		private static extern void HsRequestUnreadMessageCount(bool shouldFetchFromServer);

		[DllImport("__Internal")]
		[Token(Token = "0x60021FF")]
		[Address(RVA = "0x3DCD12C", Offset = "0x3DCD12C", Length = "0x28")]
		private static extern void HsLeaveBreadcrumb(string breadcrumb);

		[DllImport("__Internal")]
		[Token(Token = "0x6002200")]
		[Address(RVA = "0x3DCD154", Offset = "0x3DCD154", Length = "0x4")]
		private static extern void HsClearBreadcrumbs();

		[DllImport("__Internal")]
		[Token(Token = "0x6002201")]
		[Address(RVA = "0x3DCD158", Offset = "0x3DCD158", Length = "0x28")]
		private static extern void HsHandleProactiveLink(string proactiveLink);

		[DllImport("__Internal")]
		[Token(Token = "0x6002202")]
		[Address(RVA = "0x3DCD180", Offset = "0x3DCD180", Length = "0x4")]
		private static extern void HsClearAnonymousUserOnLogin(bool clearAnonymousUser);

		[DllImport("__Internal")]
		[Token(Token = "0x6002203")]
		[Address(RVA = "0x3DCD184", Offset = "0x3DCD184", Length = "0x28")]
		private static extern void HsAddUserTrail(string userTrail);

		[DllImport("__Internal")]
		[Token(Token = "0x6002204")]
		[Address(RVA = "0x3DCD1AC", Offset = "0x3DCD1AC", Length = "0x4")]
		private static extern void HsCloseSession();

		[DllImport("__Internal")]
		[Token(Token = "0x6002205")]
		[Address(RVA = "0x3DCD1B0", Offset = "0x3DCD1B0", Length = "0x28")]
		private static extern void HsAddUserIdentities(string identitiesJWT);

		[DllImport("__Internal")]
		[Token(Token = "0x6002206")]
		[Address(RVA = "0x3DCD1D8", Offset = "0x3DCD1D8", Length = "0x28")]
		private static extern void HsUpdateMasterAttributes(string attributesJson);

		[DllImport("__Internal")]
		[Token(Token = "0x6002207")]
		[Address(RVA = "0x3DCD200", Offset = "0x3DCD200", Length = "0x28")]
		private static extern void HsUpdateAppAttributes(string attributesJson);

		[Token(Token = "0x6002208")]
		[Address(RVA = "0x3DC9E8C", Offset = "0x3DC9E8C", Length = "0x8")]
		public HelpshiftXiOS()
		{
		}

		[Token(Token = "0x6002209")]
		[Address(RVA = "0x3DCA044", Offset = "0x3DCA044", Length = "0x2D8")]
		public void Install(string appId, string domainName, Dictionary<string, object> installConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::Install");
		}

		[Token(Token = "0x600220A")]
		[Address(RVA = "0x3DCAC6C", Offset = "0x3DCAC6C", Length = "0x19C")]
		public void ShowConversation(Dictionary<string, object> config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::ShowConversation");
		}

		[Token(Token = "0x600220B")]
		[Address(RVA = "0x3DCAE6C", Offset = "0x3DCAE6C", Length = "0x19C")]
		public void ShowFAQs(Dictionary<string, object> configMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::ShowFAQs");
		}

		[Token(Token = "0x600220C")]
		[Address(RVA = "0x3DCB074", Offset = "0x3DCB074", Length = "0x1C0")]
		public void ShowSingleFAQ(string faqId, Dictionary<string, object> configMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::ShowSingleFAQ");
		}

		[Token(Token = "0x600220D")]
		[Address(RVA = "0x3DCB2A0", Offset = "0x3DCB2A0", Length = "0x1C0")]
		public void ShowFAQSection(string sectionId, Dictionary<string, object> configMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::ShowFAQSection");
		}

		[Token(Token = "0x600220E")]
		[Address(RVA = "0x3DCB4C4", Offset = "0x3DCB4C4", Length = "0xBC")]
		public void RequestUnreadMessageCount(bool shouldFetchFromServer)
		{
			bool flag = default(bool);
			string text = flag.ToString();
			string message = "request unread message count api called with remote fetch : " + text;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFDD4");
		}

		[Token(Token = "0x600220F")]
		[Address(RVA = "0x3DCBAE8", Offset = "0x3DCBAE8", Length = "0xA4")]
		public void SetSDKLanguage(string languageCode)
		{
			string message = "setLanguage api called for language " + languageCode;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFDE0");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x6002210")]
		[Address(RVA = "0x3DCA380", Offset = "0x3DCA380", Length = "0x160")]
		public bool Login(Dictionary<string, string> userDetails)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::Login");
			return default;
		}

		[Token(Token = "0x6002211")]
		[Address(RVA = "0x3DCAA6C", Offset = "0x3DCAA6C", Length = "0x94")]
		public void Logout()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::Logout");
		}

		[Obsolete("ClearAnonymousUserOnLogin is deprecated, please use ClearAnonymousUserOnLogin(Boolean clearAnonymousUser) instead.")]
		[Token(Token = "0x6002212")]
		[Address(RVA = "0x3DCD2B4", Offset = "0x3DCD2B4", Length = "0x9C")]
		public void ClearAnonymousUserOnLogin()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::ClearAnonymousUserOnLogin");
		}

		[Token(Token = "0x6002213")]
		[Address(RVA = "0x3DCAB64", Offset = "0x3DCAB64", Length = "0xA4")]
		public void RegisterPushToken(string deviceToken)
		{
			string message = "Register device token :" + deviceToken;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFDA4");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x6002214")]
		[Address(RVA = "0x3DCC4DC", Offset = "0x3DCC4DC", Length = "0xBC")]
		public void PauseDisplayOfInAppNotification(bool pauseInAppNotifications)
		{
			bool flag = default(bool);
			string text = flag.ToString();
			string message = "Pause in-app notification called with shouldPause :" + text;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD98");
		}

		[Token(Token = "0x6002215")]
		[Address(RVA = "0x3DCB8E4", Offset = "0x3DCB8E4", Length = "0x1A0")]
		public void HandlePushNotification(Dictionary<string, object> notificationDataDict)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::HandlePushNotification");
		}

		[Token(Token = "0x6002216")]
		[Address(RVA = "0x3DCC360", Offset = "0x3DCC360", Length = "0x7C")]
		public void SetHelpshiftEventsListener(IHelpshiftEventsListener listener)
		{
			HelpshiftInternalLogger.d("Event listener is set");
			HelpshiftXiOSDelegate.SetExternalDelegate(listener);
		}

		[Token(Token = "0x6002217")]
		[Address(RVA = "0x3DCA6A0", Offset = "0x3DCA6A0", Length = "0x7C")]
		public void SetHelpshiftProactiveConfigCollector(IHelpshiftProactiveAPIConfigCollector listener)
		{
			HelpshiftInternalLogger.d("Proactive Event listener is set");
			HelpshiftXiOSDelegate.SetExternalProactiveDelegate(listener);
		}

		[Token(Token = "0x6002218")]
		[Address(RVA = "0x3DCC224", Offset = "0x3DCC224", Length = "0x2C")]
		public void LeaveBreadcrumb(string breadcrumb)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD68");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x6002219")]
		[Address(RVA = "0x3DCC2A4", Offset = "0x3DCC2A4", Length = "0x4")]
		public void ClearBreadcrumbs()
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD2C");
		}

		[Token(Token = "0x600221A")]
		[Address(RVA = "0x3DCA544", Offset = "0x3DCA544", Length = "0xA4")]
		public void HandleProactiveLink(string proactiveLink)
		{
			string message = "handleProactiveLink Called from unity: " + proactiveLink;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD50");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x600221B")]
		[Address(RVA = "0x3DCA774", Offset = "0x3DCA774", Length = "0xBC")]
		public void ClearAnonymousUserOnLogin(bool shouldClear)
		{
			bool flag = default(bool);
			string text = flag.ToString();
			string message = "ClearAnonymouseUserOnLogin api called with param  " + text;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD20");
		}

		[Token(Token = "0x600221C")]
		[Address(RVA = "0x3DCA8F8", Offset = "0x3DCA8F8", Length = "0xA4")]
		public void AddUserTrail(string trail)
		{
			string message = "addUserTrail api called with param  " + trail;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD14");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x600221D")]
		[Address(RVA = "0x3DCC474", Offset = "0x3DCC474", Length = "0x4")]
		public void CloseSession()
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD38");
		}

		[Token(Token = "0x600221E")]
		[Address(RVA = "0x3DCC050", Offset = "0x3DCC050", Length = "0x160")]
		public void LoginWithIdentities(string identitiesJwt, Dictionary<string, object> loginConfig, IHelpshiftUserLoginEventListener helpshiftUserLoginEventListener)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::LoginWithIdentities");
		}

		[Token(Token = "0x600221F")]
		[Address(RVA = "0x3DCBBF0", Offset = "0x3DCBBF0", Length = "0x13C")]
		public void UpdateAppAttributes(Dictionary<string, object> appAttributes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::UpdateAppAttributes");
		}

		[Token(Token = "0x6002220")]
		[Address(RVA = "0x3DCBD90", Offset = "0x3DCBD90", Length = "0x13C")]
		public void UpdateMasterAttributes(Dictionary<string, object> masterAttributes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::UpdateMasterAttributes");
		}

		[Token(Token = "0x6002221")]
		[Address(RVA = "0x3DCBF30", Offset = "0x3DCBF30", Length = "0xA4")]
		public void AddUserIdentities(string identitiesJwt)
		{
			string message = "addUserIdentities api called " + identitiesJwt;
			HelpshiftInternalLogger.d(message);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFD08");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x6002222")]
		[Address(RVA = "0x3DCD228", Offset = "0x3DCD228", Length = "0x88")]
		private string SerializeDictionary(Dictionary<string, object> configMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOS::SerializeDictionary");
			return default;
		}
	}
}
