using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Settings
{
	[Token(Token = "0x2000002")]
	public class FacebookSettings : ScriptableObject
	{
		[Token(Token = "0x2000003")]
		public delegate void OnChangeCallback();

		[Serializable]
		[Token(Token = "0x2000004")]
		public class UrlSchemes
		{
			[SerializeField]
			[Token(Token = "0x4000014")]
			[FieldOffset(Offset = "0x10")]
			private List<string> list;

			[Token(Token = "0x17000015")]
			public List<string> Schemes
			{
				[Token(Token = "0x600002D")]
				[Address(RVA = "0x1678324", Offset = "0x1678324", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.list;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Schemes;
				}
				[Token(Token = "0x600002E")]
				[Address(RVA = "0x167832C", Offset = "0x167832C", Length = "0x1008")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.list = value;\n\treturn;\n\tX0 = MoreMountains.NiceVibrations.MMVibrationManager::Android(X0);\n\treturn;\n\tX1 = *([X8]);\n\tX0 = 0x167800C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1021 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					list = value;
				}
			}

			[Token(Token = "0x600002C")]
			[Address(RVA = "0x1677F2C", Offset = "0x1677F2C", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EA7A60]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, schemes, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B4FC]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv44 = schemes == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0026;\n\tv49 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v49);\nL_0026:\n\tthis.list = v53;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public UrlSchemes(List<string> schemes = null)
			{
				bool flag = schemes == null;
				bool flag2 = !flag;
				List<string> list = schemes;
				if (!flag2)
				{
					list = new List<string>();
				}
				this.list = list;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000005")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000015")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000016")]
			public static Action<OnChangeCallback> _003C_003E9__76_0;

			[Token(Token = "0x600002F")]
			[Address(RVA = "0x1678030", Offset = "0x1678030", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ECD758]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B4FB]) = v37;\nL_0015:\n\tv41 = new Facebook.Unity.Settings.FacebookSettings+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000030")]
			[Address(RVA = "0x1678094", Offset = "0x1678094", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CSettingsChanged_003Eb__76_0(OnChangeCallback callback)
			{
				callback();
			}
		}

		[Token(Token = "0x4000001")]
		public const string FacebookSettingsAssetName = "FacebookSettings";

		[Token(Token = "0x4000002")]
		public const string FacebookSettingsPath = "FacebookSDK/SDK/Resources";

		[Token(Token = "0x4000003")]
		public const string FacebookSettingsAssetExtension = ".asset";

		[Token(Token = "0x4000004")]
		private static List<OnChangeCallback> onChangeCallbacks;

		[Token(Token = "0x4000005")]
		private static FacebookSettings instance;

		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x18")]
		private int selectedAppIndex;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x20")]
		private List<string> clientTokens;

		[SerializeField]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x28")]
		private List<string> appIds;

		[SerializeField]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x30")]
		private List<string> appLabels;

		[SerializeField]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x38")]
		private bool cookie;

		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x39")]
		private bool logging;

		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x3A")]
		private bool status;

		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x3B")]
		private bool xfbml;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x3C")]
		private bool frictionlessRequests;

		[SerializeField]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x40")]
		private string iosURLSuffix;

		[SerializeField]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x48")]
		private List<UrlSchemes> appLinkSchemes;

		[SerializeField]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x50")]
		private string uploadAccessToken;

		[SerializeField]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x58")]
		private bool autoLogAppEventsEnabled;

		[SerializeField]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x59")]
		private bool advertiserIDCollectionEnabled;

		[Token(Token = "0x17000001")]
		public static int SelectedAppIndex
		{
			[Token(Token = "0x6000001")]
			[Address(RVA = "0x1676720", Offset = "0x1676720", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F04E00]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4D4]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.selectedAppIndex;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.selectedAppIndex;
			}
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x167689C", Offset = "0x167689C", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7BC8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4D5]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv64 = v52.selectedAppIndex != value;\n\tif (v64) goto L_0038;\n\treturn;\nL_0038:\n\tgoto L_003E;\n\tv118 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003E;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tv84 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv84.selectedAppIndex = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.selectedAppIndex != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.selectedAppIndex = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000002")]
		public static List<string> AppIds
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x1676A68", Offset = "0x1676A68", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA6308]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4D6]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.appIds;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.appIds;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x1676AD4", Offset = "0x1676AD4", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE1920]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4D7]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.appIds == value;\n\tif (v59) goto L_0047;\n\tgoto L_0037;\n\tv95 = *([v87 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0037;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tv81 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv81.appIds = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.appIds != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.appIds = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000003")]
		public static List<string> AppLabels
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x1676B7C", Offset = "0x1676B7C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE1678]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4D8]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.appLabels;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.appLabels;
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x1676BE8", Offset = "0x1676BE8", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F05660]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4D9]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.appLabels == value;\n\tif (v59) goto L_0047;\n\tgoto L_0037;\n\tv95 = *([v87 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0037;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tv81 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv81.appLabels = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.appLabels != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.appLabels = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000004")]
		public static List<string> ClientTokens
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x1676C90", Offset = "0x1676C90", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE83B0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4DA]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.clientTokens;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.clientTokens;
			}
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x1676CFC", Offset = "0x1676CFC", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA8CC8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4DB]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.clientTokens == value;\n\tif (v59) goto L_0047;\n\tgoto L_0037;\n\tv95 = *([v87 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0037;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tv81 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv81.clientTokens = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.clientTokens != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.clientTokens = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000005")]
		public static string AppId
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x1676DA4", Offset = "0x1676DA4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC6918]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B4DC]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = Facebook.Unity.Settings.FacebookSettings::get_AppIds();\n\tv53 = Facebook.Unity.Settings.FacebookSettings::get_SelectedAppIndex();\n\tv57 = v51._size < v53;\n\tv58 = ~v57;\n\tv59 = v51._size - v53;\n\tv61 = v59 == 0;\n\tv66 = ~v61;\n\tv67 = v58 & v66;\n\tif (v67) goto L_0033;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0033:\n\tv71 = v51._items;\n\treturnVal2 = System.String::Trim(v71[v53 @ X0_v5 (System.Int32)]);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<string> list = AppIds;
				int num = SelectedAppIndex;
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items = list._items;
				return items[num].Trim();
			}
		}

		[Token(Token = "0x17000006")]
		public static string ClientToken
		{
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x1676E44", Offset = "0x1676E44", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE17C8]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B4DD]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = Facebook.Unity.Settings.FacebookSettings::get_ClientTokens();\n\tv53 = Facebook.Unity.Settings.FacebookSettings::get_SelectedAppIndex();\n\tv57 = v51._size < v53;\n\tv58 = ~v57;\n\tv59 = v51._size - v53;\n\tv61 = v59 == 0;\n\tv66 = ~v61;\n\tv67 = v58 & v66;\n\tif (v67) goto L_0033;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0033:\n\tv71 = v51._items;\n\treturnVal2 = System.String::Trim(v71[v53 @ X0_v5 (System.Int32)]);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<string> list = ClientTokens;
				int num = SelectedAppIndex;
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items = list._items;
				return items[num].Trim();
			}
		}

		[Token(Token = "0x17000007")]
		public static bool IsValidAppId
		{
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x1676EE4", Offset = "0x1676EE4", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED61E8]);\n\tv15 = *([v14 @ X8_v22]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4DE]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_AppId();\n\tv50 = v49 == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tgoto L_002A;\n\tv89 = *([v51 @ X0_v8 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_002A;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv83 = Facebook.Unity.Settings.FacebookSettings::get_AppId();\n\tv57 = v83.m_stringLength < 1;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_0044;\n\tv157 = *([v153 @ X0_v13 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0044;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v153, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0044:\n\tv151 = Facebook.Unity.Settings.FacebookSettings::get_AppId();\n\tv110 = System.String::Equals(v151, \"0\");\n\tv113 = v110 ^ 1;\n\tgoto L_0051;\nL_0051:\n\treturnVal1 = v113 & 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string appId = AppId;
				int num;
				if (appId != null)
				{
					string appId2 = AppId;
					if (appId2.Length >= 1)
					{
						string appId3 = AppId;
						bool flag = appId3.Equals("0");
						num = (flag ? 1 : 0) ^ 1;
						goto IL_00ab;
					}
				}
				num = 0;
				goto IL_00ab;
				IL_00ab:
				return (byte)(num & 1) != 0;
			}
		}

		[Token(Token = "0x17000008")]
		public static bool Cookie
		{
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x1676FBC", Offset = "0x1676FBC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFCE70]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4DF]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.cookie;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.cookie;
			}
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x1677028", Offset = "0x1677028", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFF7E8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4E0]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.cookie == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.cookie = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.cookie;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.cookie = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000009")]
		public static bool Logging
		{
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x16770DC", Offset = "0x16770DC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC2F60]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4E1]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.logging;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.logging;
			}
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x1677148", Offset = "0x1677148", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC5D78]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4E2]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.logging == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.logging = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.logging;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.logging = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x1700000A")]
		public static bool Status
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x16771FC", Offset = "0x16771FC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC5130]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4E3]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.status;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.status;
			}
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x1677268", Offset = "0x1677268", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB9190]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4E4]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.status == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.status = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.status;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.status = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x1700000B")]
		public static bool Xfbml
		{
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x167731C", Offset = "0x167731C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB6F30]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4E5]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.xfbml;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.xfbml;
			}
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x1677388", Offset = "0x1677388", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC36D8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4E6]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.xfbml == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.xfbml = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.xfbml;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.xfbml = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x1700000C")]
		public static string IosURLSuffix
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x167743C", Offset = "0x167743C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F07E50]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4E7]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.iosURLSuffix;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.iosURLSuffix;
			}
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x16774A8", Offset = "0x16774A8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB9D68]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4E8]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv57 = System.String::op_Inequality(v52.iosURLSuffix, value);\n\tv68 = v57 == 0;\n\tif (v68) goto L_0043;\n\tgoto L_0033;\n\tv90 = *([v69 @ X0_v9 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0033;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v69, v55, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0033:\n\tv61 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv61.iosURLSuffix = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.iosURLSuffix != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.iosURLSuffix = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x1700000D")]
		public static string ChannelUrl
		{
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x1677558", Offset = "0x1677558", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ED16D0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4E9]) = v35;\nL_0018:\n\treturn \"/channel.html\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "/channel.html";
			}
		}

		[Token(Token = "0x1700000E")]
		public static bool FrictionlessRequests
		{
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x16775A0", Offset = "0x16775A0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECBCA8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4EA]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.frictionlessRequests;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.frictionlessRequests;
			}
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x167760C", Offset = "0x167760C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED84F0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4EB]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.frictionlessRequests == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.frictionlessRequests = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.frictionlessRequests;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.frictionlessRequests = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x1700000F")]
		public static List<UrlSchemes> AppLinkSchemes
		{
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x16776C0", Offset = "0x16776C0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE7A70]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4EC]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.appLinkSchemes;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.appLinkSchemes;
			}
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x167772C", Offset = "0x167772C", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6088]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4ED]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.appLinkSchemes == value;\n\tif (v59) goto L_0047;\n\tgoto L_0037;\n\tv95 = *([v87 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0037;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tv81 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv81.appLinkSchemes = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.appLinkSchemes != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.appLinkSchemes = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000010")]
		public static string UploadAccessToken
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x16777D4", Offset = "0x16777D4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFF430]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4EE]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.uploadAccessToken;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.uploadAccessToken;
			}
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x1677840", Offset = "0x1677840", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC9870]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4EF]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv57 = System.String::op_Inequality(v52.uploadAccessToken, value);\n\tv68 = v57 == 0;\n\tif (v68) goto L_0043;\n\tgoto L_0033;\n\tv90 = *([v69 @ X0_v9 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0033;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v69, v55, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0033:\n\tv61 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv61.uploadAccessToken = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				if (facebookSettings.uploadAccessToken != value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.uploadAccessToken = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000011")]
		public static bool AutoLogAppEventsEnabled
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x16778F0", Offset = "0x16778F0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB3518]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4F0]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.autoLogAppEventsEnabled;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.autoLogAppEventsEnabled;
			}
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x167795C", Offset = "0x167795C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECF488]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4F1]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.autoLogAppEventsEnabled == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.autoLogAppEventsEnabled = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.autoLogAppEventsEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.autoLogAppEventsEnabled = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000012")]
		public static bool AdvertiserIDCollectionEnabled
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x1677A10", Offset = "0x1677A10", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE3E90]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4F2]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\treturn v49.advertiserIDCollectionEnabled;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings facebookSettings = Instance;
				return facebookSettings.advertiserIDCollectionEnabled;
			}
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x1677A7C", Offset = "0x1677A7C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE98D0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4F3]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv59 = v52.advertiserIDCollectionEnabled == 0;\n\tv64 = ~v59;\n\tv66 = v64 ^ value;\n\tv68 = v66 == 0;\n\tif (v68) goto L_004D;\n\tgoto L_003C;\n\tv102 = *([v94 @ X0_v7 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv88 = Facebook.Unity.Settings.FacebookSettings::get_Instance();\n\tv88.advertiserIDCollectionEnabled = value;\n\tFacebook.Unity.Settings.FacebookSettings::SettingsChanged();\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				FacebookSettings facebookSettings = Instance;
				bool flag = !facebookSettings.advertiserIDCollectionEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					FacebookSettings facebookSettings2 = Instance;
					facebookSettings2.advertiserIDCollectionEnabled = value;
					SettingsChanged();
				}
			}
		}

		[Token(Token = "0x17000013")]
		public static FacebookSettings Instance
		{
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x167678C", Offset = "0x167678C", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC5018]);\n\tv17 = *([v16 @ X8_v21]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B4F4]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = Facebook.Unity.Settings.FacebookSettings::get_NullableInstance();\n\tv53.instance = v51;\n\tgoto L_0033;\n\tv62 = *([v57 @ X0_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0033;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0033:\n\tv72 = UnityEngine.Object::op_Equality(v56.instance, 0);\n\tv74 = v72 == 0;\n\tif (v74) goto L_004F;\n\tv78 = UnityEngine.ScriptableObject::CreateInstance();\n\tgoto L_0049;\n\tv97 = *([v80 @ X8_v15 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0049;\n\tv118 = v80;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v118, v70, v71, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv102 = Facebook.Unity.Settings.FacebookSettings;\nL_0049:\n\tv86.instance = v78;\n\tgoto L_004F;\nL_004F:\n\tgoto L_005E;\n\tv103 = *([v91 @ X8_v8 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tgoto L_005E;\n\tv119 = v91;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v119, v70, v71, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv111 = Facebook.Unity.Settings.FacebookSettings;\nL_005E:\n\treturn v112.instance;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookSettings nullableInstance = NullableInstance;
				instance = nullableInstance;
				if (instance == null)
				{
					FacebookSettings facebookSettings = ScriptableObject.CreateInstance<FacebookSettings>();
					instance = facebookSettings;
				}
				return instance;
			}
		}

		[Token(Token = "0x17000014")]
		public static FacebookSettings NullableInstance
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x1677B30", Offset = "0x1677B30", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F03D18]);\n\tv17 = *([v16 @ X8_v20]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B4F5]) = v37;\nL_0018:\n\tgoto L_0027;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Facebook.Unity.Settings.FacebookSettings;\nL_0027:\n\tgoto L_0031;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv71 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v71, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Equality(v53.instance, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_005A;\n\tv78 = UnityEngine.Resources::Load(\"FacebookSettings\");\n\tgoto L_0048;\n\tv136 = *([v80 @ X8_v15 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0048;\n\tv158 = v80;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v158, v76, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv142 = Facebook.Unity.Settings.FacebookSettings;\nL_0048:\n\tv129 = v78 == 0;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006E;\nL_005A:\n\tgoto L_0072;\n\tv197 = v197_asT == 0;\n\tif (v197) goto L_FFFFFFFF;\n\tgoto L_006E;\nL_006E:\n\tv125.instance = v122;\nL_0072:\n\tgoto L_0081;\n\tv143 = *([v130 @ X8_v8 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tgoto L_0081;\n\tv183 = v130;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v183, v123, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv151 = Facebook.Unity.Settings.FacebookSettings;\nL_0081:\n\treturn v152.instance;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (instance == null)
				{
					UnityEngine.Object obj = Resources.Load("FacebookSettings");
					UnityEngine.Object obj2;
					if ((object)obj == null)
					{
						obj2 = null;
					}
					else
					{
						FacebookSettings facebookSettings = obj as FacebookSettings;
						obj2 = (((object)facebookSettings == null) ? null : obj);
					}
					instance = (FacebookSettings)obj2;
				}
				return instance;
			}
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x1677C70", Offset = "0x1677C70", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA8830]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4F6]) = v38;\nL_0019:\n\tgoto L_002D;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b13\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.Settings.FacebookSettings;\nL_002D:\n\tSystem.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>::Add(v52.onChangeCallbacks, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterChangeEventCallback(OnChangeCallback callback)
		{
			onChangeCallbacks.Add(callback);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x1677CF4", Offset = "0x1677CF4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC8630]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4F7]) = v38;\nL_0019:\n\tgoto L_002D;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b13\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.Settings.FacebookSettings;\nL_002D:\n\tv64 = System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>::Remove(v52.onChangeCallbacks, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UnregisterChangeEventCallback(OnChangeCallback callback)
		{
			bool flag = onChangeCallbacks.Remove(callback);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x1676944", Offset = "0x1676944", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F06CD0]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202B4F8]) = v41;\nL_001A:\n\tgoto L_002A;\n\tv48 = *([v44 @ X8_v3 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv65 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = Facebook.Unity.Settings.FacebookSettings;\nL_002A:\n\tgoto L_0032;\n\tv66 = *([v60 @ X0_v3 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings+<>c>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v60, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv70 = Facebook.Unity.Settings.FacebookSettings+<>c;\nL_0032:\n\tv87 = v73.<>9__76_0;\n\tv75 = v73.<>9__76_0 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0060;\n\tgoto L_0045;\n\tv100 = *([v69 @ X0_v4 (Il2CppClass<Facebook.Unity.Settings.FacebookSettings+<>c>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0045;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v69, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv127 = Facebook.Unity.Settings.FacebookSettings+<>c;\n\tv107 = *([v127 @ X8_v19+B8]);\nL_0045:\n\tv94 = new System.Action`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>();\n\tSystem.Action`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>::.ctor(v94, v106.<>9, Il2CppMethodInfo);\n\tv98.<>9__76_0 = v94;\nL_0060:\n\tSystem.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>::ForEach(v59.onChangeCallbacks, v87);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SettingsChanged()
		{
			Action<OnChangeCallback> action = _003C_003Ec._003C_003E9__76_0;
			if (_003C_003Ec._003C_003E9__76_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__76_0 = delegate(OnChangeCallback callback)
				{
					callback();
				});
			}
			onChangeCallbacks.ForEach(action);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x1677D78", Offset = "0x1677D78", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE3090]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202B4F9]) = v46;\nL_001A:\n\tv50 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v50);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v50, v61.Empty);\n\tthis.clientTokens = v50;\n\tv79 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v79);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v79, \"0\");\n\tthis.appIds = v79;\n\tv80 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v80);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v80, \"App Name\");\n\tthis.appLabels = v80;\n\tthis.cookie = 0x101;\n\tthis.status = 1;\n\tthis.frictionlessRequests = 1;\n\tthis.iosURLSuffix = v131.Empty;\n\tv136 = new System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+UrlSchemes>();\n\tSystem.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+UrlSchemes>::.ctor(v136);\n\tv81 = new Facebook.Unity.Settings.FacebookSettings+UrlSchemes();\n\tFacebook.Unity.Settings.FacebookSettings+UrlSchemes::.ctor(v81, 0);\n\tSystem.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+UrlSchemes>::Add(v136, v81);\n\tthis.appLinkSchemes = v136;\n\tthis.autoLogAppEventsEnabled = 0x101;\n\tthis.uploadAccessToken = v147.Empty;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FacebookSettings()
		{
			clientTokens = new List<string> { string.Empty };
			appIds = new List<string> { "0" };
			appLabels = new List<string> { "App Name" };
			cookie = true;
			logging = true;
			status = true;
			frictionlessRequests = true;
			iosURLSuffix = string.Empty;
			List<UrlSchemes> list = new List<UrlSchemes>();
			UrlSchemes item = new UrlSchemes();
			list.Add(item);
			appLinkSchemes = list;
			autoLogAppEventsEnabled = true;
			advertiserIDCollectionEnabled = true;
			uploadAccessToken = string.Empty;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x1677FBC", Offset = "0x1677FBC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB9130]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B4FA]) = v34;\nL_0014:\n\tv38 = new System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings+OnChangeCallback>();\n\tv42 = 0x1678338(v38, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturn;\n\tSystem.Collections.Generic.List`1::.ctor /* +161 sharing this address */(X0, X1);\n\tX8 = *([1F03EC0]);\n\tX8 = *([X8]);\n\tX8 = *([X8+B8]);\n\t*([X8]) = X19;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 35 ShiftStack 32\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FacebookSettings()
		{
			List<OnChangeCallback> list = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1678338 (inside Facebook.Unity.Settings.FacebookSettings+UrlSchemes::set_Schemes +0xC)");
		}
	}
}
