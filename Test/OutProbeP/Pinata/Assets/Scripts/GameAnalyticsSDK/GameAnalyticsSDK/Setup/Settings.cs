using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GameAnalyticsSDK.Setup
{
	[Token(Token = "0x200000D")]
	public class Settings : ScriptableObject
	{
		[Token(Token = "0x200001D")]
		public enum HelpTypes
		{
			[Token(Token = "0x400009F")]
			None = 0,
			[Token(Token = "0x40000A0")]
			IncludeSystemSpecsHelp = 1,
			[Token(Token = "0x40000A1")]
			ProvideCustomUserID = 2
		}

		[Token(Token = "0x200001E")]
		public enum MessageTypes
		{
			[Token(Token = "0x40000A3")]
			None = 0,
			[Token(Token = "0x40000A4")]
			Error = 1,
			[Token(Token = "0x40000A5")]
			Info = 2,
			[Token(Token = "0x40000A6")]
			Warning = 3
		}

		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x200001F")]
		public struct HelpInfo
		{
			[Token(Token = "0x40000A7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string Message;

			[Token(Token = "0x40000A8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public MessageTypes MsgType;

			[Token(Token = "0x40000A9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public HelpTypes HelpType;
		}

		[Token(Token = "0x2000020")]
		public enum InspectorStates
		{
			[Token(Token = "0x40000AB")]
			Account = 0,
			[Token(Token = "0x40000AC")]
			Basic = 1,
			[Token(Token = "0x40000AD")]
			Debugging = 2,
			[Token(Token = "0x40000AE")]
			Pref = 3
		}

		[HideInInspector]
		[Token(Token = "0x4000035")]
		public static string VERSION = "6.0.10";

		[HideInInspector]
		[Token(Token = "0x4000036")]
		public static bool CheckingForUpdates = false;

		[Token(Token = "0x4000037")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public int TotalMessagesSubmitted;

		[Token(Token = "0x4000038")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public int TotalMessagesFailed;

		[Token(Token = "0x4000039")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public int DesignMessagesSubmitted;

		[Token(Token = "0x400003A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public int DesignMessagesFailed;

		[Token(Token = "0x400003B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public int QualityMessagesSubmitted;

		[Token(Token = "0x400003C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
		public int QualityMessagesFailed;

		[Token(Token = "0x400003D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public int ErrorMessagesSubmitted;

		[Token(Token = "0x400003E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public int ErrorMessagesFailed;

		[Token(Token = "0x400003F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public int BusinessMessagesSubmitted;

		[Token(Token = "0x4000040")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
		public int BusinessMessagesFailed;

		[Token(Token = "0x4000041")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public int UserMessagesSubmitted;

		[Token(Token = "0x4000042")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
		public int UserMessagesFailed;

		[Token(Token = "0x4000043")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public string CustomArea;

		[SerializeField]
		[Token(Token = "0x4000044")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private List<string> gameKey;

		[SerializeField]
		[Token(Token = "0x4000045")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		private List<string> secretKey;

		[SerializeField]
		[Token(Token = "0x4000046")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public List<string> Build;

		[SerializeField]
		[Token(Token = "0x4000047")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		public List<string> SelectedPlatformStudio;

		[SerializeField]
		[Token(Token = "0x4000048")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		public List<string> SelectedPlatformGame;

		[SerializeField]
		[Token(Token = "0x4000049")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
		public List<int> SelectedPlatformGameID;

		[SerializeField]
		[Token(Token = "0x400004A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		public List<int> SelectedStudio;

		[SerializeField]
		[Token(Token = "0x400004B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
		public List<int> SelectedGame;

		[Token(Token = "0x400004C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
		public string NewVersion;

		[Token(Token = "0x400004D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
		public string Changes;

		[Token(Token = "0x400004E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
		public bool SignUpOpen;

		[Token(Token = "0x400004F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA8")]
		public string StudioName;

		[Token(Token = "0x4000050")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
		public string GameName;

		[Token(Token = "0x4000051")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB8")]
		public string EmailGA;

		[NonSerialized]
		[Token(Token = "0x4000052")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC0")]
		public string PasswordGA;

		[NonSerialized]
		[Token(Token = "0x4000053")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
		public string TokenGA;

		[NonSerialized]
		[Token(Token = "0x4000054")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD0")]
		public string ExpireTime;

		[NonSerialized]
		[Token(Token = "0x4000055")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD8")]
		public string LoginStatus;

		[NonSerialized]
		[Token(Token = "0x4000056")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE0")]
		public bool JustSignedUp;

		[NonSerialized]
		[Token(Token = "0x4000057")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE1")]
		public bool HideSignupWarning;

		[Token(Token = "0x4000058")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE2")]
		public bool IntroScreen;

		[NonSerialized]
		[Token(Token = "0x4000059")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE8")]
		public List<Studio> Studios;

		[Token(Token = "0x400005A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF0")]
		public bool InfoLogEditor;

		[Token(Token = "0x400005B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF1")]
		public bool InfoLogBuild;

		[Token(Token = "0x400005C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF2")]
		public bool VerboseLogBuild;

		[Token(Token = "0x400005D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF3")]
		public bool UseManualSessionHandling;

		[Token(Token = "0x400005E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF4")]
		public bool SendExampleGameDataToMyGame;

		[Token(Token = "0x400005F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF5")]
		public bool UseIMEI;

		[Token(Token = "0x4000060")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF6")]
		public bool InternetConnectivity;

		[Token(Token = "0x4000061")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
		public List<string> CustomDimensions01;

		[Token(Token = "0x4000062")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x100")]
		public List<string> CustomDimensions02;

		[Token(Token = "0x4000063")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x108")]
		public List<string> CustomDimensions03;

		[Token(Token = "0x4000064")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x110")]
		public List<string> ResourceItemTypes;

		[Token(Token = "0x4000065")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x118")]
		public List<string> ResourceCurrencies;

		[Token(Token = "0x4000066")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x120")]
		public RuntimePlatform LastCreatedGamePlatform;

		[Token(Token = "0x4000067")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x128")]
		public List<RuntimePlatform> Platforms;

		[Token(Token = "0x4000068")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x130")]
		public InspectorStates CurrentInspectorState;

		[Token(Token = "0x4000069")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x138")]
		public List<HelpTypes> ClosedHints;

		[Token(Token = "0x400006A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x140")]
		public bool DisplayHints;

		[Token(Token = "0x400006B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x144")]
		public Vector2 DisplayHintsScrollState;

		[Token(Token = "0x400006C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x150")]
		public Texture2D Logo;

		[Token(Token = "0x400006D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x158")]
		public Texture2D UpdateIcon;

		[Token(Token = "0x400006E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x160")]
		public Texture2D InfoIcon;

		[Token(Token = "0x400006F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x168")]
		public Texture2D DeleteIcon;

		[Token(Token = "0x4000070")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x170")]
		public Texture2D GameIcon;

		[Token(Token = "0x4000071")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x178")]
		public Texture2D HomeIcon;

		[Token(Token = "0x4000072")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x180")]
		public Texture2D InstrumentIcon;

		[Token(Token = "0x4000073")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x188")]
		public Texture2D QuestionIcon;

		[Token(Token = "0x4000074")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x190")]
		public Texture2D UserIcon;

		[Token(Token = "0x4000075")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x198")]
		public Texture2D AmazonIcon;

		[Token(Token = "0x4000076")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1A0")]
		public Texture2D GooglePlayIcon;

		[Token(Token = "0x4000077")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1A8")]
		public Texture2D iosIcon;

		[Token(Token = "0x4000078")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1B0")]
		public Texture2D macIcon;

		[Token(Token = "0x4000079")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1B8")]
		public Texture2D windowsPhoneIcon;

		[NonSerialized]
		[Token(Token = "0x400007A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C0")]
		public GUIStyle SignupButton;

		[Token(Token = "0x400007B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C8")]
		public bool UsePlayerSettingsBuildNumber;

		[Token(Token = "0x400007C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C9")]
		public bool SubmitErrors;

		[Token(Token = "0x400007D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1CC")]
		public int MaxErrorCount;

		[Token(Token = "0x400007E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1D0")]
		public bool SubmitFpsAverage;

		[Token(Token = "0x400007F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1D1")]
		public bool SubmitFpsCritical;

		[Token(Token = "0x4000080")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1D2")]
		public bool IncludeGooglePlay;

		[Token(Token = "0x4000081")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1D4")]
		public int FpsCriticalThreshold;

		[Token(Token = "0x4000082")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1D8")]
		public int FpsCirticalSubmitInterval;

		[Token(Token = "0x4000083")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1E0")]
		public List<bool> PlatformFoldOut;

		[Token(Token = "0x4000084")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1E8")]
		public bool CustomDimensions01FoldOut;

		[Token(Token = "0x4000085")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1E9")]
		public bool CustomDimensions02FoldOut;

		[Token(Token = "0x4000086")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1EA")]
		public bool CustomDimensions03FoldOut;

		[Token(Token = "0x4000087")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1EB")]
		public bool ResourceItemTypesFoldOut;

		[Token(Token = "0x4000088")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1EC")]
		public bool ResourceCurrenciesFoldOut;

		[Token(Token = "0x4000089")]
		public static readonly RuntimePlatform[] AvailablePlatforms = new RuntimePlatform[8]
		{
			RuntimePlatform.Android,
			RuntimePlatform.IPhonePlayer,
			RuntimePlatform.LinuxPlayer,
			RuntimePlatform.OSXPlayer,
			RuntimePlatform.tvOS,
			RuntimePlatform.WebGLPlayer,
			RuntimePlatform.WindowsPlayer,
			RuntimePlatform.MetroPlayerARM
		};

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x15A5188", Offset = "0x15A5188", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EBF368]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, customID, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029814]) = v38;\nL_001F:\n\tv50 = System.String::op_Inequality(customID, v46.Empty);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetCustomUserID(string customID)
		{
			bool flag = customID != string.Empty;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x15A51E4", Offset = "0x15A51E4", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF8D00]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029815]) = v41;\nL_0015:\n\tv42 = index & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_007B;\n\tv45 = this.Platforms;\n\tv48 = v45._size <= index;\n\tif (v48) goto L_007B;\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.gameKey, index);\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.secretKey, index);\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.Build, index);\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.SelectedPlatformStudio, index);\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.SelectedPlatformGame, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.SelectedPlatformGameID, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.SelectedStudio, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.SelectedGame, index);\n\tSystem.Collections.Generic.List`1<System.Boolean>::RemoveAt(this.PlatformFoldOut, index);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::RemoveAt(this.Platforms, index);\n\treturn;\nL_007B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemovePlatformAtIndex(int index)
		{
			//IL_010f: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0)
			{
				List<RuntimePlatform> platforms = Platforms;
				if (platforms.Count > index)
				{
					gameKey.RemoveAt(index);
					secretKey.RemoveAt(index);
					Build.RemoveAt(index);
					SelectedPlatformStudio.RemoveAt(index);
					SelectedPlatformGame.RemoveAt(index);
					SelectedPlatformGameID.RemoveAt(index);
					SelectedStudio.RemoveAt(index);
					SelectedGame.RemoveAt(index);
					PlatformFoldOut.RemoveAt(index);
					Platforms.RemoveAt(index);
				}
			}
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x15A5344", Offset = "0x15A5344", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EC2B60]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, platform, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029816]) = v43;\nL_001F:\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.gameKey, \"\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.secretKey, \"\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.Build, \"0.1\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.SelectedPlatformStudio, \"\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.SelectedPlatformGame, \"\");\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.SelectedPlatformGameID, 0xFFFFFFFF);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.SelectedStudio, 0);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.SelectedGame, 0);\n\tSystem.Collections.Generic.List`1<System.Boolean>::Add(this.PlatformFoldOut, 1);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(this.Platforms, platform);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddPlatform(RuntimePlatform platform)
		{
			gameKey.Add("");
			secretKey.Add("");
			Build.Add("0.1");
			SelectedPlatformStudio.Add("");
			SelectedPlatformGame.Add("");
			SelectedPlatformGameID.Add(-1);
			SelectedStudio.Add(0);
			SelectedGame.Add(0);
			PlatformFoldOut.Add(item: true);
			Platforms.Add(platform);
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x15A5488", Offset = "0x15A5488", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EA9478]);\n\tv35 = *([v34 @ X8_v28]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029817]) = v54;\nL_001F:\n\tv417 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v417);\n\tgoto L_00BD;\nL_0034:\n\tgoto L_0040;\n\tv205 = *([v133 @ X0_v6 (Il2CppClass<GameAnalyticsSDK.Setup.Settings>)+E0]);\n\tv267 = v205 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_0040;\n\tv324 = GameAnalyticsSDK.Setup.Settings;\n\tv325 = *([v324 @ X8_v22 (Il2CppClass<GameAnalyticsSDK.Setup.Settings>)+B8]);\n\tv224 = v325.AvailablePlatforms;\nL_0040:\n\tv270 = v116 < v260.Length;\n\tv252 = ~v270;\n\tif (v252) goto L_00ED;\n\tv87 = v116 << 2;\n\tv223 = v260 + v87;\n\tv168 = *([v223 @ X8_v17+20]);\n\tv290 = *([v223 @ X8_v17+20]) == 0x1F;\n\tif (v290) goto L_0069;\n\tv335 = *([v223 @ X8_v17+20]) != 8;\n\tif (v335) goto L_0088;\n\tv367 = this.Platforms;\n\tgoto L_006E;\nL_0069:\n\tv367 = this.Platforms;\nL_006E:\n\tv369 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(v367, v355);\n\tv372 = v369 == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_0081;\n\tv399 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(this.Platforms, *([v223 @ X8_v17+20]));\n\tv401 = v399 == 0;\n\tif (v401) goto L_00A4;\nL_0081:\n\tv390 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(this.Platforms, *([v223 @ X8_v17+20]));\n\tgoto L_009F;\nL_0088:\n\tv390 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(this.Platforms, *([v223 @ X8_v17+20]));\n\tv161 = *([v223 @ X8_v17+20]) != 0x14;\n\tif (v161) goto L_009F;\n\tv375 = v390 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_00B8;\n\tgoto L_00B7;\nL_009F:\n\tv394 = v390 == 0;\n\tv395 = ~v394;\n\tif (v395) goto L_00B8;\nL_00A4:\n\t// 164 Box v361 @ X0_v29, typeof(UnityEngine.RuntimePlatform), &v168 @ X21_v5 (UnityEngine.RuntimePlatform)\n\tv431 = *([v361 @ X0_v29]);\n\t*([v431 @ X8_v20+160])(v433, v361, *([v431 @ X8_v20+168]), v158, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv215 = \"il2cpp_vm_object_unbox\"(v361, *([v431 @ X8_v20+168]), v158, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00B7:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v417, v416);\nL_00B8:\n\tv116 = v116 + 1;\nL_00BD:\n\tgoto L_00C5;\n\tv130 = *([v126 @ X0_v5 (Il2CppClass<GameAnalyticsSDK.Setup.Settings>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tgoto L_00C5;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v126, v118, v77, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv134 = GameAnalyticsSDK.Setup.Settings;\nL_00C5:\n\tv260 = v137.AvailablePlatforms;\n\tv152 = v116 < v260.Length;\n\tif (v152) goto L_0034;\n\treturnVal1 = System.Collections.Generic.List`1<System.String>::ToArray(v417);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\tv227 = new System.NullReferenceException();\nL_00ED:\n\tv261 = new System.IndexOutOfRangeException();\n\tthrow v261;\n\treturn returnVal2;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetAvailablePlatforms()
		{
			//IL_004f: Expected O, but got I
			List<string> list = new List<string>();
			int num = 0;
			string text = default(string);
			while (true)
			{
				RuntimePlatform[] availablePlatforms = AvailablePlatforms;
				RuntimePlatform runtimePlatform;
				bool flag;
				string item;
				if (num < availablePlatforms.Length)
				{
					if (num >= availablePlatforms.Length)
					{
						break;
					}
					int num2 = num << 2;
					object obj = (long)(IntPtr)availablePlatforms + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
					runtimePlatform = RuntimePlatform.OSXEditor;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
					List<RuntimePlatform> platforms2;
					int item2;
					IntPtr intPtr;
					if ((IntPtr)0 != (IntPtr)31)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
						if ((IntPtr)0 != (IntPtr)8)
						{
							List<RuntimePlatform> platforms = Platforms;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
							flag = platforms.Contains(RuntimePlatform.OSXEditor);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
							bool flag2 = (IntPtr)0 != (IntPtr)20;
							intPtr = (IntPtr)0;
							if (flag2)
							{
								goto IL_01cc;
							}
							if (flag)
							{
								goto IL_023a;
							}
							item = "WSA";
							goto IL_02e1;
						}
						platforms2 = Platforms;
						item2 = 31;
					}
					else
					{
						platforms2 = Platforms;
						item2 = 8;
					}
					if (!platforms2.Contains((RuntimePlatform)item2))
					{
						List<RuntimePlatform> platforms3 = Platforms;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
						bool flag3 = platforms3.Contains(RuntimePlatform.OSXEditor);
						bool flag4 = !flag3;
						intPtr = (IntPtr)0;
						if (flag4)
						{
							goto IL_01f4;
						}
					}
					List<RuntimePlatform> platforms4 = Platforms;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X8_v17+20]");
					flag = platforms4.Contains(RuntimePlatform.OSXEditor);
					intPtr = (IntPtr)0;
					goto IL_01cc;
				}
				return list.ToArray();
				IL_023a:
				num++;
				continue;
				IL_02e1:
				list.Add(item);
				goto IL_023a;
				IL_01cc:
				if (flag)
				{
					goto IL_023a;
				}
				goto IL_01f4;
				IL_01f4:
				object obj2 = runtimePlatform;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v431 @ X8_v20+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				item = text;
				goto IL_02e1;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x15A56E0", Offset = "0x15A56E0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EC8B78]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, index, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029818]) = v46;\nL_0018:\n\tv131 = this.Platforms;\nL_0027:\n\tv142 = v101 >= v131._size;\n\tif (v142) goto L_FFFFFFFF;\nL_0033:\n\tv65 = index != v117;\n\tif (v65) goto L_0043;\n\tv117 = v117 + 1;\n\tv148 = v117 < v131._size;\n\tif (v148) goto L_0033;\n\tgoto L_FFFFFFFF;\nL_0043:\n\tv62 = this.gameKey;\n\tv215 = v62._size < v117;\n\tv96 = ~v215;\n\tv92 = v62._size - v117;\n\tv84 = v92 == 0;\n\tv216 = ~v84;\n\tv64 = v96 & v216;\n\tif (v64) goto L_0057;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0057:\n\tv218 = v62._items;\n\tv104 = System.String::Equals(value, v218[v117 @ X22_v8 (System.Int32)]);\n\tv221 = v104 == 0;\n\tv191 = ~v221;\n\tif (v191) goto L_FFFFFFFF;\n\tv131 = this.Platforms;\n\tv101 = v117 + 1;\n\tv222 = this.Platforms == 0;\n\tv108 = ~v222;\n\tif (v108) goto L_0027;\n\tthrow System.NullReferenceException;\nL_0072:\n\treturn returnVal1;\n\tgoto L_0072;\n\treturn X0;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsGameKeyValid(int index, string value)
		{
			List<RuntimePlatform> platforms = Platforms;
			int num = 0;
			while (true)
			{
				if (num < platforms.Count)
				{
					int num2 = num;
					while (index == num2)
					{
						num2++;
						if (num2 < platforms.Count)
						{
							continue;
						}
						goto IL_016a;
					}
					List<string> list = gameKey;
					bool flag = list.Count < num2;
					bool flag2 = !flag;
					int num3 = list.Count - num2;
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list._items;
					if (value.Equals(items[num2]))
					{
						break;
					}
					platforms = Platforms;
					num = num2 + 1;
					if (Platforms == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				goto IL_016a;
				IL_016a:
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x15A57CC", Offset = "0x15A57CC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ECD030]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, index, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029819]) = v46;\nL_0018:\n\tv131 = this.Platforms;\nL_0027:\n\tv142 = v101 >= v131._size;\n\tif (v142) goto L_FFFFFFFF;\nL_0033:\n\tv65 = index != v117;\n\tif (v65) goto L_0043;\n\tv117 = v117 + 1;\n\tv148 = v117 < v131._size;\n\tif (v148) goto L_0033;\n\tgoto L_FFFFFFFF;\nL_0043:\n\tv62 = this.secretKey;\n\tv215 = v62._size < v117;\n\tv96 = ~v215;\n\tv92 = v62._size - v117;\n\tv84 = v92 == 0;\n\tv216 = ~v84;\n\tv64 = v96 & v216;\n\tif (v64) goto L_0057;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0057:\n\tv218 = v62._items;\n\tv104 = System.String::Equals(value, v218[v117 @ X22_v8 (System.Int32)]);\n\tv221 = v104 == 0;\n\tv191 = ~v221;\n\tif (v191) goto L_FFFFFFFF;\n\tv131 = this.Platforms;\n\tv101 = v117 + 1;\n\tv222 = this.Platforms == 0;\n\tv108 = ~v222;\n\tif (v108) goto L_0027;\n\tthrow System.NullReferenceException;\nL_0072:\n\treturn returnVal1;\n\tgoto L_0072;\n\treturn X0;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsSecretKeyValid(int index, string value)
		{
			List<RuntimePlatform> platforms = Platforms;
			int num = 0;
			while (true)
			{
				if (num < platforms.Count)
				{
					int num2 = num;
					while (index == num2)
					{
						num2++;
						if (num2 < platforms.Count)
						{
							continue;
						}
						goto IL_016a;
					}
					List<string> list = secretKey;
					bool flag = list.Count < num2;
					bool flag2 = !flag;
					int num3 = list.Count - num2;
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list._items;
					if (value.Equals(items[num2]))
					{
						break;
					}
					platforms = Platforms;
					num = num2 + 1;
					if (Platforms == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				goto IL_016a;
				IL_016a:
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x15A58B8", Offset = "0x15A58B8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F02CD8]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202981A]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(v133);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0026;\n\tv137 = this.gameKey;\n\tgoto L_0030;\nL_0026:\n\tv55 = GameAnalyticsSDK.Setup.Settings::IsGameKeyValid(this, v135, v133);\n\tv103 = this.gameKey;\n\tv110 = v55 == 0;\n\tif (v110) goto L_003D;\nL_0030:\n\t;\nL_003A:\n\tSystem.Collections.Generic.List`1<System.String>::set_Item(v137, v135, \"\");\n\treturn;\nL_003D:\n\tv181 = v103._size < v135;\n\tv87 = ~v181;\n\tv84 = v103._size - v135;\n\tv78 = v84 == 0;\n\tv182 = ~v78;\n\tv63 = v87 & v182;\n\tif (v63) goto L_004B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004B:\n\tv185 = v103._items;\n\tv165 = System.String::Equals(v185[v135 @ X1_v2 (System.Int32)], v133);\n\tv167 = v165 == 0;\n\tif (v167) goto L_0069;\n\tv137 = this.gameKey;\n\tgoto L_003A;\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateGameKey(int index, string value)
		{
			string value2 = default(string);
			List<string> list;
			int num = default(int);
			if (string.IsNullOrEmpty(value2))
			{
				list = gameKey;
			}
			else
			{
				bool flag = IsGameKeyValid(num, value2);
				List<string> list2 = gameKey;
				if (flag)
				{
					list = list2;
				}
				else
				{
					bool flag2 = list2.Count < num;
					bool flag3 = !flag2;
					int num2 = list2.Count - num;
					bool flag4 = num2 == 0;
					bool flag5 = !flag4;
					if (!(flag3 && flag5))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list2._items;
					if (!items[num].Equals(value2))
					{
						return;
					}
					list = gameKey;
				}
			}
			list.set_Item(num, "");
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x15A59D4", Offset = "0x15A59D4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EDFE20]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202981B]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(v133);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0026;\n\tv137 = this.secretKey;\n\tgoto L_0030;\nL_0026:\n\tv55 = GameAnalyticsSDK.Setup.Settings::IsSecretKeyValid(this, v135, v133);\n\tv103 = this.secretKey;\n\tv110 = v55 == 0;\n\tif (v110) goto L_003D;\nL_0030:\n\t;\nL_003A:\n\tSystem.Collections.Generic.List`1<System.String>::set_Item(v137, v135, \"\");\n\treturn;\nL_003D:\n\tv181 = v103._size < v135;\n\tv87 = ~v181;\n\tv84 = v103._size - v135;\n\tv78 = v84 == 0;\n\tv182 = ~v78;\n\tv63 = v87 & v182;\n\tif (v63) goto L_004B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004B:\n\tv185 = v103._items;\n\tv165 = System.String::Equals(v185[v135 @ X1_v2 (System.Int32)], v133);\n\tv167 = v165 == 0;\n\tif (v167) goto L_0069;\n\tv137 = this.secretKey;\n\tgoto L_003A;\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateSecretKey(int index, string value)
		{
			string value2 = default(string);
			List<string> list;
			int num = default(int);
			if (string.IsNullOrEmpty(value2))
			{
				list = secretKey;
			}
			else
			{
				bool flag = IsSecretKeyValid(num, value2);
				List<string> list2 = secretKey;
				if (flag)
				{
					list = list2;
				}
				else
				{
					bool flag2 = list2.Count < num;
					bool flag3 = !flag2;
					int num2 = list2.Count - num;
					bool flag4 = num2 == 0;
					bool flag5 = !flag4;
					if (!(flag3 && flag5))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list2._items;
					if (!items[num].Equals(value2))
					{
						return;
					}
					list = secretKey;
				}
			}
			list.set_Item(num, "");
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x15A37C4", Offset = "0x15A37C4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE9468]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202981C]) = v41;\nL_0015:\n\tv42 = this.gameKey;\n\tv45 = v42._size < index;\n\tv46 = ~v45;\n\tv47 = v42._size - index;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_0027;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0027:\n\tv60 = v42._items;\n\treturn v60[index @ X1 (System.Int32)];\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetGameKey(int index)
		{
			List<string> list = gameKey;
			bool flag = list.Count < index;
			bool flag2 = !flag;
			int num = list.Count - index;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			string[] items = list._items;
			return items[index];
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x15A3840", Offset = "0x15A3840", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE8E18]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202981D]) = v41;\nL_0015:\n\tv42 = this.secretKey;\n\tv45 = v42._size < index;\n\tv46 = ~v45;\n\tv47 = v42._size - index;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_0027;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0027:\n\tv60 = v42._items;\n\treturn v60[index @ X1 (System.Int32)];\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetSecretKey(int index)
		{
			List<string> list = secretKey;
			bool flag = list.Count < index;
			bool flag2 = !flag;
			int num = list.Count - index;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			string[] items = list._items;
			return items[index];
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x15A5AF0", Offset = "0x15A5AF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetCustomArea(string customArea)
		{
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x15A5AF4", Offset = "0x15A5AF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetKeys(string gamekey, string secretkey)
		{
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x15A5AF8", Offset = "0x15A5AF8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ECDFF0]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202981E]) = v46;\nL_001D:\n\tthis.CustomArea = v51.Empty;\n\tv55 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v55);\n\tthis.gameKey = v55;\n\tv61 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v61);\n\tthis.secretKey = v61;\n\tv65 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v65);\n\tthis.Build = v65;\n\tv69 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v69);\n\tthis.SelectedPlatformStudio = v69;\n\tv73 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v73);\n\tthis.SelectedPlatformGame = v73;\n\tv79 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v79);\n\tthis.SelectedPlatformGameID = v79;\n\tv85 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v85);\n\tthis.SelectedStudio = v85;\n\tv89 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v89);\n\tthis.SelectedGame = v89;\n\tthis.NewVersion = \"\";\n\tthis.Changes = \"\";\n\tthis.StudioName = \"\";\n\tthis.GameName = \"\";\n\tthis.EmailGA = \"\";\n\tthis.PasswordGA = \"\";\n\tthis.TokenGA = \"\";\n\tthis.ExpireTime = \"\";\n\tthis.SignUpOpen = 1;\n\tthis.IntroScreen = 1;\n\tthis.InfoLogEditor = 1;\n\tthis.InfoLogBuild = 1;\n\tthis.LoginStatus = \"Not logged in.\";\n\tv100 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v100);\n\tthis.CustomDimensions01 = v100;\n\tv104 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v104);\n\tthis.CustomDimensions02 = v104;\n\tv108 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v108);\n\tthis.CustomDimensions03 = v108;\n\tv112 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v112);\n\tthis.ResourceItemTypes = v112;\n\tv116 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v116);\n\tthis.ResourceCurrencies = v116;\n\tv122 = new System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::.ctor(v122);\n\tthis.Platforms = v122;\n\tv130 = new System.Collections.Generic.List`1<GameAnalyticsSDK.Setup.Settings+HelpTypes>();\n\tSystem.Collections.Generic.List`1<GameAnalyticsSDK.Setup.Settings+HelpTypes>::.ctor(v130);\n\tthis.ClosedHints = v130;\n\tthis.SubmitErrors = 1;\n\tthis.SubmitFpsAverage = 1;\n\tthis.SubmitFpsCritical = 1;\n\tthis.IncludeGooglePlay = 1;\n\tthis.FpsCirticalSubmitInterval = 1;\n\tthis.MaxErrorCount = 0xA;\n\tthis.FpsCriticalThreshold = 0x14;\n\tv140 = new System.Collections.Generic.List`1<System.Boolean>();\n\tSystem.Collections.Generic.List`1<System.Boolean>::.ctor(v140);\n\tthis.PlatformFoldOut = v140;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Settings()
		{
			CustomArea = string.Empty;
			List<string> list = new List<string>();
			gameKey = list;
			List<string> list2 = new List<string>();
			secretKey = list2;
			List<string> build = new List<string>();
			Build = build;
			List<string> selectedPlatformStudio = new List<string>();
			SelectedPlatformStudio = selectedPlatformStudio;
			List<string> selectedPlatformGame = new List<string>();
			SelectedPlatformGame = selectedPlatformGame;
			List<int> selectedPlatformGameID = new List<int>();
			SelectedPlatformGameID = selectedPlatformGameID;
			List<int> selectedStudio = new List<int>();
			SelectedStudio = selectedStudio;
			List<int> selectedGame = new List<int>();
			SelectedGame = selectedGame;
			NewVersion = "";
			Changes = "";
			StudioName = "";
			GameName = "";
			EmailGA = "";
			PasswordGA = "";
			TokenGA = "";
			ExpireTime = "";
			SignUpOpen = true;
			IntroScreen = true;
			InfoLogEditor = true;
			InfoLogBuild = true;
			LoginStatus = "Not logged in.";
			List<string> customDimensions = new List<string>();
			CustomDimensions01 = customDimensions;
			List<string> customDimensions2 = new List<string>();
			CustomDimensions02 = customDimensions2;
			List<string> customDimensions3 = new List<string>();
			CustomDimensions03 = customDimensions3;
			List<string> resourceItemTypes = new List<string>();
			ResourceItemTypes = resourceItemTypes;
			List<string> resourceCurrencies = new List<string>();
			ResourceCurrencies = resourceCurrencies;
			List<RuntimePlatform> platforms = new List<RuntimePlatform>();
			Platforms = platforms;
			List<HelpTypes> closedHints = new List<HelpTypes>();
			ClosedHints = closedHints;
			SubmitErrors = true;
			SubmitFpsAverage = true;
			SubmitFpsCritical = true;
			IncludeGooglePlay = true;
			FpsCirticalSubmitInterval = 1;
			MaxErrorCount = 10;
			FpsCriticalThreshold = 20;
			List<bool> platformFoldOut = new List<bool>();
			PlatformFoldOut = platformFoldOut;
		}
	}
}
