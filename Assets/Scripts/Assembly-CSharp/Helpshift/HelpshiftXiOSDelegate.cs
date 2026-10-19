using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using HSMiniJSON;

namespace Helpshift
{
	[Token(Token = "0x2000805")]
	public class HelpshiftXiOSDelegate
	{
		[Token(Token = "0x2000806")]
		private delegate void UnitySupportMessageCallback(string methodName, string parametersJson);

		[Token(Token = "0x2000807")]
		private delegate string unityGetApiConfig();

		[Token(Token = "0x4001AE7")]
		private static HelpshiftXiOSDelegate sharedDelegate;

		[Token(Token = "0x4001AE8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal IHelpshiftEventsListener externalDelegate;

		[Token(Token = "0x4001AE9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		internal IHelpshiftProactiveAPIConfigCollector externalProactiveDelegate;

		[Token(Token = "0x4001AEA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		internal IHelpshiftUserLoginEventListener externalLoginWithIdentityDelegate;

		[DllImport("__Internal")]
		[Token(Token = "0x600222B")]
		[Address(RVA = "0x3DCE690", Offset = "0x3DCE690", Length = "0x14")]
		private static extern void HsRegisterHelpshiftDelegateCallback(UnitySupportMessageCallback callback);

		[DllImport("__Internal")]
		[Token(Token = "0x600222C")]
		[Address(RVA = "0x3DCE6A4", Offset = "0x3DCE6A4", Length = "0x14")]
		private static extern void HsRegisterHelpshiftProactiveDelegateCallback(unityGetApiConfig callback);

		[DllImport("__Internal")]
		[Token(Token = "0x600222D")]
		[Address(RVA = "0x3DCE6B8", Offset = "0x3DCE6B8", Length = "0x60")]
		private static extern void HsLoginWithIdentity(string identityJWT, string loginConfigJson, UnitySupportMessageCallback callback);

		[Token(Token = "0x600222E")]
		[Address(RVA = "0x3DCE718", Offset = "0x3DCE718", Length = "0x8")]
		private HelpshiftXiOSDelegate()
		{
		}

		[Token(Token = "0x600222F")]
		[Address(RVA = "0x3DCE720", Offset = "0x3DCE720", Length = "0xA4")]
		public static HelpshiftXiOSDelegate GetInstance()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::GetInstance");
			return default;
		}

		[Token(Token = "0x6002230")]
		[Address(RVA = "0x3DCD350", Offset = "0x3DCD350", Length = "0xA4")]
		public static void SetExternalDelegate(IHelpshiftEventsListener helpshiftEventListener)
		{
			HelpshiftXiOSDelegate helpshiftXiOSDelegate = sharedDelegate;
			if (sharedDelegate == null)
			{
				object obj = new HelpshiftXiOSDelegate();
				sharedDelegate = (HelpshiftXiOSDelegate)obj;
				helpshiftXiOSDelegate = sharedDelegate;
			}
			helpshiftXiOSDelegate.externalDelegate = helpshiftEventListener;
			RegisterHelpshiftDelegateCallback();
		}

		[Token(Token = "0x6002231")]
		[Address(RVA = "0x3DCD3F4", Offset = "0x3DCD3F4", Length = "0xA4")]
		public static void SetExternalProactiveDelegate(IHelpshiftProactiveAPIConfigCollector proactiveDelegate)
		{
			HelpshiftXiOSDelegate helpshiftXiOSDelegate = sharedDelegate;
			if (sharedDelegate == null)
			{
				object obj = new HelpshiftXiOSDelegate();
				sharedDelegate = (HelpshiftXiOSDelegate)obj;
				helpshiftXiOSDelegate = sharedDelegate;
			}
			helpshiftXiOSDelegate.externalProactiveDelegate = proactiveDelegate;
			RegisterHelpshifProactiveDelegateCallback();
		}

		[Token(Token = "0x6002232")]
		[Address(RVA = "0x3DCD498", Offset = "0x3DCD498", Length = "0x1F4")]
		public unsafe static void LoginWithIdentities(string identitiesJwt, string loginConfig, IHelpshiftUserLoginEventListener helpshiftUserLoginEventListener)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::LoginWithIdentities");
		}

		[Token(Token = "0x6002233")]
		[Address(RVA = "0x3DCE7C4", Offset = "0x3DCE7C4", Length = "0x104")]
		private unsafe static void RegisterHelpshiftDelegateCallback()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::RegisterHelpshiftDelegateCallback");
		}

		[Token(Token = "0x6002234")]
		[Address(RVA = "0x3DCE8C8", Offset = "0x3DCE8C8", Length = "0xE4")]
		private unsafe static void RegisterHelpshifProactiveDelegateCallback()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::RegisterHelpshifProactiveDelegateCallback");
		}

		[MonoPInvokeCallback(typeof(UnitySupportMessageCallback))]
		[Token(Token = "0x6002235")]
		[Address(RVA = "0x3DCD6EC", Offset = "0x3DCD6EC", Length = "0x478")]
		private static void UnityHelpshiftDelegateCallbackImpl(string methodName, string parametersJson)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::UnityHelpshiftDelegateCallbackImpl");
		}

		[MonoPInvokeCallback(typeof(unityGetApiConfig))]
		[Token(Token = "0x6002236")]
		[Address(RVA = "0x3DCDB64", Offset = "0x3DCDB64", Length = "0x1C0")]
		private static string UnityGetApiConfigProactiveDelegateCallbackImpl()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::UnityGetApiConfigProactiveDelegateCallbackImpl");
			return default;
		}

		[MonoPInvokeCallback(typeof(UnitySupportMessageCallback))]
		[Token(Token = "0x6002237")]
		[Address(RVA = "0x3DCDD24", Offset = "0x3DCDD24", Length = "0x96C")]
		private unsafe static void UnityLoginWithIdentityCallbackImpl(string methodName, string parametersJson)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::UnityLoginWithIdentityCallbackImpl");
		}

		[Token(Token = "0x6002238")]
		[Address(RVA = "0x3DCEB14", Offset = "0x3DCEB14", Length = "0x8C")]
		private static string SerializeDictionary(Dictionary<string, object> configMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HelpshiftXiOSDelegate::SerializeDictionary");
			return default;
		}
	}
}
