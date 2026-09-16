using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000009")]
	public class Adjust : MonoBehaviour
	{
		[Token(Token = "0x400000E")]
		private const string errorMsgEditor = "Adjust: SDK can not be used in Editor.";

		[Token(Token = "0x400000F")]
		private const string errorMsgStart = "Adjust: SDK not started. Start it manually using the 'start' method.";

		[Token(Token = "0x4000010")]
		private const string errorMsgPlatform = "Adjust: SDK can only be used in Android, iOS, Windows Phone 8.1, Windows Store or Universal Windows apps.";

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x18")]
		public bool startManually;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x19")]
		public bool eventBuffering;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x1A")]
		public bool sendInBackground;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x1B")]
		public bool launchDeferredDeeplink;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x20")]
		public string appToken;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x28")]
		public AdjustLogLevel logLevel;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x2C")]
		public AdjustEnvironment environment;

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x15659F4", Offset = "0x15659F4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED2C60]);\n\tv25 = *([v24 @ X8_v13]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202906A]) = v44;\nL_0018:\n\tv47 = UnityEngine.Component::get_transform(this);\n\tv50 = UnityEngine.Component::get_gameObject(v47);\n\tgoto L_002D;\n\tv108 = *([v55 @ X8_v6+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_002D;\n\tv116 = v55;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v116, v49, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tUnityEngine.Object::DontDestroyOnLoad(v50);\n\tv118 = ~this.startManually;\n\tif (v118) goto L_0040;\n\treturn;\nL_0040:\n\tv99 = new com.adjust.sdk.AdjustConfig();\n\tv83 = this.logLevel - 7;\n\tv77 = v83 == 0;\n\tcom.adjust.sdk.AdjustConfig::.ctor(v99, this.appToken, this.environment, v77);\n\tcom.adjust.sdk.AdjustConfig::setLogLevel(v99, this.logLevel);\n\tcom.adjust.sdk.AdjustConfig::setSendInBackground(v99, this.sendInBackground);\n\tcom.adjust.sdk.AdjustConfig::setEventBufferingEnabled(v99, this.eventBuffering);\n\tv99.launchDeferredDeeplink = this.launchDeferredDeeplink;\n\tcom.adjust.sdk.Adjust::start(v99);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Transform transform = base.transform;
			GameObject target = transform.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
			if (!startManually)
			{
				bool allowSuppressLogLevel = default(bool);
				AdjustConfig adjustConfig = new AdjustConfig(appToken, environment, allowSuppressLogLevel);
				int num = (int)(logLevel - 7);
				allowSuppressLogLevel = num == 0;
				adjustConfig.setLogLevel(logLevel);
				adjustConfig.setSendInBackground(sendInBackground);
				adjustConfig.setEventBufferingEnabled(eventBuffering);
				adjustConfig.launchDeferredDeeplink = launchDeferredDeeplink;
				start(adjustConfig);
			}
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x1565DBC", Offset = "0x1565DBC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0EF18]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, pauseStatus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202906B]) = v38;\nL_0018:\n\tv44 = pauseStatus == 0;\n\tif (v44) goto L_002B;\n\tgoto L_0027;\n\tv49 = *([v41 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0027;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v41, pauseStatus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tcom.adjust.sdk.AdjustAndroid::OnPause();\n\treturn;\nL_002B:\n\tgoto L_0036;\n\tv60 = *([v41 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0036;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v41, pauseStatus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0036:\n\tcom.adjust.sdk.AdjustAndroid::OnResume();\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				AdjustAndroid.OnPause();
			}
			else
			{
				AdjustAndroid.OnResume();
			}
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x1565D18", Offset = "0x1565D18", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE4680]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202906C]) = v38;\nL_0013:\n\tv39 = adjustConfig == 0;\n\tif (v39) goto L_002F;\n\tgoto L_0027;\n\tv52 = *([v42 @ X0_v6+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tcom.adjust.sdk.AdjustAndroid::Start(adjustConfig);\n\treturn;\nL_002F:\n\tgoto L_003E;\n\tv64 = *([v48 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_003E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tUnityEngine.Debug::Log(\"Adjust: Missing config to start.\");\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void start(AdjustConfig adjustConfig)
		{
			if (adjustConfig != null)
			{
				AdjustAndroid.Start(adjustConfig);
			}
			else
			{
				Debug.Log("Adjust: Missing config to start.");
			}
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x1566F88", Offset = "0x1566F88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEA048]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202906D]) = v38;\nL_0013:\n\tv39 = adjustEvent == 0;\n\tif (v39) goto L_002F;\n\tgoto L_0027;\n\tv52 = *([v42 @ X0_v6+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tcom.adjust.sdk.AdjustAndroid::TrackEvent(adjustEvent);\n\treturn;\nL_002F:\n\tgoto L_003E;\n\tv64 = *([v48 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_003E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tUnityEngine.Debug::Log(\"Adjust: Missing event to track.\");\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void trackEvent(AdjustEvent adjustEvent)
		{
			if (adjustEvent != null)
			{
				AdjustAndroid.TrackEvent(adjustEvent);
			}
			else
			{
				Debug.Log("Adjust: Missing event to track.");
			}
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x1567534", Offset = "0x1567534", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC50B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202906E]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::SetEnabled(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void setEnabled(bool enabled)
		{
			AdjustAndroid.SetEnabled(enabled);
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15676A8", Offset = "0x15676A8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0C178]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202906F]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = com.adjust.sdk.AdjustAndroid::IsEnabled();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool isEnabled()
		{
			return AdjustAndroid.IsEnabled();
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x1567828", Offset = "0x1567828", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAA858]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029070]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::SetOfflineMode(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void setOfflineMode(bool enabled)
		{
			AdjustAndroid.SetOfflineMode(enabled);
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x156799C", Offset = "0x156799C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDA118]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029071]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::SetDeviceToken(deviceToken);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void setDeviceToken(string deviceToken)
		{
			AdjustAndroid.SetDeviceToken(deviceToken);
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x1567B28", Offset = "0x1567B28", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEABA8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029072]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tcom.adjust.sdk.AdjustAndroid::GdprForgetMe();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void gdprForgetMe()
		{
			AdjustAndroid.GdprForgetMe();
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x1567C80", Offset = "0x1567C80", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F007C0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029073]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tcom.adjust.sdk.AdjustAndroid::DisableThirdPartySharing();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void disableThirdPartySharing()
		{
			AdjustAndroid.DisableThirdPartySharing();
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x1567DD8", Offset = "0x1567DD8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAD018]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029074]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::AppWillOpenUrl(url);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void appWillOpenUrl(string url)
		{
			AdjustAndroid.AppWillOpenUrl(url);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x1567FFC", Offset = "0x1567FFC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFF9D0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029075]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tcom.adjust.sdk.AdjustAndroid::SendFirstPackages();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void sendFirstPackages()
		{
			AdjustAndroid.SendFirstPackages();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x1568174", Offset = "0x1568174", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA9EA8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029076]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tcom.adjust.sdk.AdjustAndroid::AddSessionPartnerParameter(key, value);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void addSessionPartnerParameter(string key, string value)
		{
			AdjustAndroid.AddSessionPartnerParameter(key, value);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x1568378", Offset = "0x1568378", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC7A60]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029077]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tcom.adjust.sdk.AdjustAndroid::AddSessionCallbackParameter(key, value);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void addSessionCallbackParameter(string key, string value)
		{
			AdjustAndroid.AddSessionCallbackParameter(key, value);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x156857C", Offset = "0x156857C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBC140]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029078]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::RemoveSessionPartnerParameter(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void removeSessionPartnerParameter(string key)
		{
			AdjustAndroid.RemoveSessionPartnerParameter(key);
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x1568744", Offset = "0x1568744", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F06820]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029079]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::RemoveSessionCallbackParameter(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void removeSessionCallbackParameter(string key)
		{
			AdjustAndroid.RemoveSessionCallbackParameter(key);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x156890C", Offset = "0x156890C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F06F48]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202907A]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tcom.adjust.sdk.AdjustAndroid::ResetSessionPartnerParameters();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void resetSessionPartnerParameters()
		{
			AdjustAndroid.ResetSessionPartnerParameters();
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x1568AF4", Offset = "0x1568AF4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EABF18]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202907B]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tcom.adjust.sdk.AdjustAndroid::ResetSessionCallbackParameters();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void resetSessionCallbackParameters()
		{
			AdjustAndroid.ResetSessionCallbackParameters();
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x1568CDC", Offset = "0x1568CDC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFFE48]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, payload, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202907C]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, payload, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tcom.adjust.sdk.AdjustAndroid::TrackAdRevenue(source, payload);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void trackAdRevenue(string source, string payload)
		{
			AdjustAndroid.TrackAdRevenue(source, payload);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x1568F50", Offset = "0x1568F50", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC3EE0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202907D]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = com.adjust.sdk.AdjustAndroid::GetAdid();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getAdid()
		{
			return AdjustAndroid.GetAdid();
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15690D0", Offset = "0x15690D0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F04238]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202907E]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = com.adjust.sdk.AdjustAndroid::GetAttribution();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdjustAttribution getAttribution()
		{
			return AdjustAndroid.GetAttribution();
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x15697B0", Offset = "0x15697B0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF3730]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202907F]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::Log(\"Adjust: Error! Windows Advertising ID is not available on Android platform.\");\n\treturn v58.Empty;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getWinAdid()
		{
			Debug.Log("Adjust: Error! Windows Advertising ID is not available on Android platform.");
			return string.Empty;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1569834", Offset = "0x1569834", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F03B98]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029080]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::Log(\"Adjust: Error! IDFA is not available on Android platform.\");\n\treturn v58.Empty;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getIdfa()
		{
			Debug.Log("Adjust: Error! IDFA is not available on Android platform.");
			return string.Empty;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x15698B8", Offset = "0x15698B8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF2080]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029081]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = com.adjust.sdk.AdjustAndroid::GetSdkVersion();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getSdkVersion()
		{
			return AdjustAndroid.GetSdkVersion();
		}

		[Obsolete]
		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1569A54", Offset = "0x1569A54", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7408]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029082]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::SetReferrer(referrer);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void setReferrer(string referrer)
		{
			AdjustAndroid.SetReferrer(referrer);
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x1569BE0", Offset = "0x1569BE0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC6658]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029083]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::GetGoogleAdId(onDeviceIdsRead);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void getGoogleAdId(Action<string> onDeviceIdsRead)
		{
			AdjustAndroid.GetGoogleAdId(onDeviceIdsRead);
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x1569D88", Offset = "0x1569D88", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFFE28]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029084]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = com.adjust.sdk.AdjustAndroid::GetAmazonAdId();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getAmazonAdId()
		{
			return AdjustAndroid.GetAmazonAdId();
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x1565B1C", Offset = "0x1565B1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsEditor()
		{
			return false;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x1569EE8", Offset = "0x1569EE8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC49A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029085]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tcom.adjust.sdk.AdjustAndroid::SetTestOptions(testOptions);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTestOptions(Dictionary<string, string> testOptions)
		{
			AdjustAndroid.SetTestOptions(testOptions);
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x156A084", Offset = "0x156A084", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA7270]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029086]) = v38;\nL_0016:\n\tthis.startManually = 1;\n\tthis.launchDeferredDeeplink = 1;\n\tthis.logLevel = 3;\n\tthis.appToken = \"{Your App Token}\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Adjust()
		{
			startManually = true;
			launchDeferredDeeplink = true;
			logLevel = AdjustLogLevel.Info;
			appToken = "{Your App Token}";
		}
	}
}
