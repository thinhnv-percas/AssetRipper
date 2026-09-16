using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using EasyMobile.Internal.GameServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x731044", Offset = "0x731044")]
	[Token(Token = "0x200003C")]
	public class GameServices : MonoBehaviour
	{
		[StructLayout((LayoutKind)0, Size = 48)]
		[Token(Token = "0x2000117")]
		private struct LoadScoreRequest
		{
			[Token(Token = "0x40004B9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public bool useLeaderboardDefault;

			[Token(Token = "0x40004BA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1")]
			public bool loadLocalUserScore;

			[Token(Token = "0x40004BB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string leaderboardName;

			[Token(Token = "0x40004BC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string leaderboardId;

			[Token(Token = "0x40004BD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public int fromRank;

			[Token(Token = "0x40004BE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
			public int scoreCount;

			[Token(Token = "0x40004BF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TimeScope timeScope;

			[Token(Token = "0x40004C0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public UserScope userScope;

			[Token(Token = "0x40004C1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public Action<string, IScore[]> callback;
		}

		[Token(Token = "0x2000118")]
		public delegate void InvitationReceivedDelegate(Invitation invitation, bool shouldAutoAccept);

		[CompilerGenerated]
		[Token(Token = "0x40001AE")]
		private static Action m_UserLoginSucceeded;

		[CompilerGenerated]
		[Token(Token = "0x40001AF")]
		private static Action m_UserLoginFailed;

		[Token(Token = "0x40001B0")]
		private static bool isLoadingScore = false;

		[Token(Token = "0x40001B1")]
		private static List<LoadScoreRequest> loadScoreRequests;

		[Token(Token = "0x40001B2")]
		private const string ANDROID_LOGIN_REQUEST_NUMBER_PPKEY = "SGLIB_ANDROID_LOGIN_REQUEST_NUMBER";

		[Token(Token = "0x40001B3")]
		private static ITurnBasedMultiplayerClient sTurnBasedClient;

		[Token(Token = "0x40001B4")]
		private static IRealTimeMultiplayerClient sRealTimeClient;

		[Token(Token = "0x40001B5")]
		private static InvitationReceivedDelegate sInvitationDelegate;

		[Token(Token = "0x40001B6")]
		private static ISavedGameClient sSavedGameClient;

		[Token(Token = "0x170000FF")]
		[field: Token(Token = "0x40001AD")]
		public static GameServices Instance
		{
			[Token(Token = "0x600035B")]
			[Address(RVA = "0xA56878", Offset = "0xA56878", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB28A0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FB1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.GameServices;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600035C")]
			[Address(RVA = "0xA568E0", Offset = "0xA568E0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA8390]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FB2]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.GameServices;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000100")]
		public static ILocalUser LocalUser
		{
			[Token(Token = "0x6000361")]
			[Address(RVA = "0xA56D0C", Offset = "0xA56D0C", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF5428]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FB7]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_002D;\n\treturnVal2 = UnityEngine.Social::get_localUser();\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (IsInitialized())
				{
					return Social.localUser;
				}
				return null;
			}
		}

		[Token(Token = "0x17000101")]
		public static ITurnBasedMultiplayerClient TurnBased
		{
			[Token(Token = "0x600037F")]
			[Address(RVA = "0xA5926C", Offset = "0xA5926C", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EED270]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD2]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.GameServices;\nL_0021:\n\tv53 = v51.sTurnBasedClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0035;\n\tgoto L_002E;\n\tv70 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv90 = v49;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v90, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002E:\n\tv62 = EasyMobile.GameServices::GetTurnBasedMultiplayerClient();\n\tv60.sTurnBasedClient = v62;\nL_0035:\n\tgoto L_0043;\n\tv76 = *([v65 @ X8_v5 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0043;\n\tv91 = v65;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v91, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv84 = EasyMobile.GameServices;\nL_0043:\n\treturn v85.sTurnBasedClient;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sTurnBasedClient == null)
				{
					ITurnBasedMultiplayerClient turnBasedMultiplayerClient = GetTurnBasedMultiplayerClient();
					sTurnBasedClient = turnBasedMultiplayerClient;
				}
				return sTurnBasedClient;
			}
		}

		[Token(Token = "0x17000102")]
		public static IRealTimeMultiplayerClient RealTime
		{
			[Token(Token = "0x6000380")]
			[Address(RVA = "0xA59384", Offset = "0xA59384", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE5378]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD3]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.GameServices;\nL_0021:\n\tv53 = v51.sRealTimeClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0035;\n\tgoto L_002E;\n\tv70 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv90 = v49;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v90, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002E:\n\tv62 = EasyMobile.GameServices::GetRealTimeMultiplayerClient();\n\tv60.sRealTimeClient = v62;\nL_0035:\n\tgoto L_0043;\n\tv76 = *([v65 @ X8_v5 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0043;\n\tv91 = v65;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v91, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv84 = EasyMobile.GameServices;\nL_0043:\n\treturn v85.sRealTimeClient;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sRealTimeClient == null)
				{
					IRealTimeMultiplayerClient realTimeMultiplayerClient = GetRealTimeMultiplayerClient();
					sRealTimeClient = realTimeMultiplayerClient;
				}
				return sRealTimeClient;
			}
		}

		[Token(Token = "0x17000103")]
		public static InvitationReceivedDelegate InvitationDelegate
		{
			[Token(Token = "0x6000381")]
			[Address(RVA = "0xA5949C", Offset = "0xA5949C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE0C28]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD4]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.GameServices;\nL_0024:\n\treturn v49.sInvitationDelegate;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sInvitationDelegate;
			}
		}

		[Token(Token = "0x17000104")]
		public static ISavedGameClient SavedGames
		{
			[Token(Token = "0x6000385")]
			[Address(RVA = "0xA59570", Offset = "0xA59570", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECCD20]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD8]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.GameServices;\nL_0021:\n\tv53 = v51.sSavedGameClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0035;\n\tgoto L_002E;\n\tv70 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv90 = v49;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v90, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002E:\n\tv62 = EasyMobile.GameServices::GetSavedGameClient();\n\tv60.sSavedGameClient = v62;\nL_0035:\n\tgoto L_0043;\n\tv76 = *([v65 @ X8_v5 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0043;\n\tv91 = v65;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v91, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv84 = EasyMobile.GameServices;\nL_0043:\n\treturn v85.sSavedGameClient;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sSavedGameClient == null)
				{
					ISavedGameClient savedGameClient = GetSavedGameClient();
					sSavedGameClient = savedGameClient;
				}
				return sSavedGameClient;
			}
		}

		[Token(Token = "0x14000022")]
		public static event Action UserLoginSucceeded
		{
			[CompilerGenerated]
			[Token(Token = "0x600035D")]
			[Address(RVA = "0xA5694C", Offset = "0xA5694C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0F358]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FB3]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.GameServices;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.GameServices;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = GameServices.m_UserLoginSucceeded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600035E")]
			[Address(RVA = "0xA56A3C", Offset = "0xA56A3C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF90A8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FB4]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.GameServices;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.GameServices;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = GameServices.m_UserLoginSucceeded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000023")]
		public static event Action UserLoginFailed
		{
			[CompilerGenerated]
			[Token(Token = "0x600035F")]
			[Address(RVA = "0xA56B2C", Offset = "0xA56B2C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0EDF8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FB5]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.GameServices;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.GameServices;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = GameServices.m_UserLoginFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000360")]
			[Address(RVA = "0xA56C1C", Offset = "0xA56C1C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0F718]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FB6]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.GameServices;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.GameServices;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = GameServices.m_UserLoginFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0xA56E3C", Offset = "0xA56E3C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0BB30]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021FB8]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EDB4E0]);\n\tv62 = *([v61 @ X8_v28]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2021FE1]) = v66;\nL_0030:\n\tgoto L_003F;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.GameServices;\nL_003F:\n\tgoto L_0049;\n\tv87 = *([v81 @ X8_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0049;\n\tv98 = v81;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv97 = UnityEngine.Object::op_Inequality(v80.<Instance>k__BackingField, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_0066;\n\tgoto L_0060;\n\tv109 = *([v101 @ X0_v20+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_0066:\n\tgoto L_0070;\n\tv124 = *([v105 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0070;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tgoto L_007B;\n\tv136 = *([1EABF40]);\n\tv137 = *([v136 @ X8_v19]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([2021FE2]) = v141;\nL_007B:\n\tgoto L_0083;\n\tv165 = *([v142 @ X0_v13 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tgoto L_0083;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v142, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = EasyMobile.GameServices;\nL_0083:\n\tv160.<Instance>k__BackingField = this;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0xA56FB4", Offset = "0xA56FB4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.EM_Settings::get_GameServices();\n\tv13 = ~v10.mAutoInit;\n\tif (v13) goto L_001E;\n\tv19 = EasyMobile.EM_Settings::get_GameServices();\n\tv55 = EasyMobile.GameServices::CRAutoInit(v19, v19.mAutoInitDelay);\n\tv50 = UnityEngine.MonoBehaviour::StartCoroutine(this, v55);\n\treturn;\nL_001E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameServicesSettings gameServices = EM_Settings.GameServices;
			if (gameServices.IsAutoInit)
			{
				GameServicesSettings gameServices2 = EM_Settings.GameServices;
				IEnumerator routine = ((GameServices)(object)gameServices2).CRAutoInit(gameServices2.AutoInitDelay);
				Coroutine coroutine = StartCoroutine(routine);
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x734650", Offset = "0x734650")]
		[Token(Token = "0x6000364")]
		[Address(RVA = "0xA5700C", Offset = "0xA5700C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC1530]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, delay, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021FB9]) = v38;\nL_0016:\n\tv42 = new EasyMobile.GameServices+<CRAutoInit>d__18();\n\tEasyMobile.GameServices+<CRAutoInit>d__18::.ctor(v42, 0);\n\tv42.delay = delay;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CRAutoInit(float delay)
		{
			yield return new WaitForSeconds(delay);
			ManagedInit();
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0xA57088", Offset = "0xA57088", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv18 = *([1EF1E38]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2021FBA]) = v39;\n\tgoto L_001F;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_001F;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv53 = EasyMobile.GameServices::IsInitialized();\n\tv55 = v53 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0070;\n\tv62 = EasyMobile.Internal.StorageUtil::GetInt(\"SGLIB_ANDROID_LOGIN_REQUEST_NUMBER\", 0);\n\tv115 = EasyMobile.EM_Settings::get_GameServices();\n\tv180 = v62 < v115.mAndroidMaxLoginRequests;\n\tif (v180) goto L_0072;\n\tv182 = EasyMobile.EM_Settings::get_GameServices();\n\tv70 = v182.mAndroidMaxLoginRequests <= 0;\n\tif (v70) goto L_0072;\n\t// 81 Box v201 @ X0_v19 (System.Object), typeof(System.Int32), &v62 @ X0_v7 (System.Int32)\n\tv211 = System.String::Concat(\"Failed to initialize Game Services module: AndroidMaxLoginRequests exceeded. Requests attempted: \", v201);\n\tgoto L_0069;\n\tv217 = *([v106 @ X8_v20+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_0069;\n\tv222 = v106;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v222, v208, v97, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0069:\n\tUnityEngine.Debug::Log(v211);\nL_0070:\n\treturn;\nL_0072:\n\tv152 = v62 + 1;\n\tEasyMobile.Internal.StorageUtil::SetInt(\"SGLIB_ANDROID_LOGIN_REQUEST_NUMBER\", v152);\n\tEasyMobile.Internal.StorageUtil::Save();\n\tgoto L_0087;\n\tv202 = *([v193 @ X0_v14 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0087;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v193, v152, v150, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0087:\n\tEasyMobile.GameServices::Init();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ManagedInit()
		{
			if (IsInitialized())
			{
				return;
			}
			int num = StorageUtil.GetInt("SGLIB_ANDROID_LOGIN_REQUEST_NUMBER", 0);
			GameServicesSettings gameServices = EM_Settings.GameServices;
			if (num >= gameServices.AndroidMaxLoginRequests)
			{
				GameServicesSettings gameServices2 = EM_Settings.GameServices;
				if (gameServices2.AndroidMaxLoginRequests > 0)
				{
					object obj = num;
					string message = "Failed to initialize Game Services module: AndroidMaxLoginRequests exceeded. Requests attempted: " + obj;
					Debug.Log(message);
					return;
				}
			}
			int value = num + 1;
			StorageUtil.SetInt("SGLIB_ANDROID_LOGIN_REQUEST_NUMBER", value);
			StorageUtil.Save();
			Init();
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0xA571E4", Offset = "0xA571E4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE9DC0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FBB]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0xA56D84", Offset = "0xA56D84", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EF8940]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FBC]) = v35;\nL_0012:\n\tv37 = UnityEngine.Social::get_localUser();\n\tv41 = *([v37 @ X0_v3 (UnityEngine.SocialPlatforms.ILocalUser)]);\n\tv45 = *([v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]) == 0;\n\tif (v45) goto L_003A;\n\tv98 = *([v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]) + 8;\nL_0025:\n\tv104 = *([v98 @ X11_v5-8]) == UnityEngine.SocialPlatforms.ILocalUser;\n\tif (v104) goto L_003D;\n\tv99 = v99 + 1;\n\tv155 = v99 < *([v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]);\n\tv78 = ~v155;\n\tv98 = v98 + 0x10;\n\tv54 = ~v78;\n\tif (v54) goto L_0025;\nL_003A:\n\tv162 = 0x8909C4(v37, UnityEngine.SocialPlatforms.ILocalUser, 2, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0041;\nL_003D:\n\tv157 = *([v98 @ X11_v5]) + 2;\n\tv158 = v157 << 4;\n\tv159 = v41 + v158;\n\tv162 = v159 + 0x130;\nL_0041:\n\tv117 = *([v162 @ X0_v5]);\n\tv139 = *([v162 @ X0_v5+8]);\n\t// 72 IndirectJump v117 @ X2_v2, v37 @ X0_v3 (UnityEngine.SocialPlatforms.ILocalUser), v37 @ X0_v3 (UnityEngine.SocialPlatforms.ILocalUser), v139 @ X1_v2, v117 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized()
		{
			//IL_000d: Expected I, but got O
			//IL_014b: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ILocalUser localUser = Social.localUser;
			IntPtr intPtr = (IntPtr)localUser;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalUser))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v3 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0133;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0133;
			IL_0133:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v5+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X2_v2 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000368")]
		[Address(RVA = "0xA57250", Offset = "0xA57250", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F00E60]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FBD]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_002E;\n\tUnityEngine.Social::ShowLeaderboardUI();\n\treturn;\nL_002E:\n\tgoto L_003C;\n\tv62 = *([v58 @ X0_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003C;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_003C:\n\tUnityEngine.Debug::Log(\"Couldn't show leaderboard UI: user is not logged in.\");\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowLeaderboardUI()
		{
			if (IsInitialized())
			{
				Social.ShowLeaderboardUI();
			}
			else
			{
				Debug.Log("Couldn't show leaderboard UI: user is not logged in.");
			}
		}

		[Token(Token = "0x6000369")]
		[Address(RVA = "0xA572F4", Offset = "0xA572F4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECAFC0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FBE]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tEasyMobile.GameServices::ShowLeaderboardUI(leaderboardName, methodInfo);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowLeaderboardUI(string leaderboardName)
		{
			IntPtr intPtr = default(IntPtr);
			ShowLeaderboardUI(leaderboardName, (TimeScope)(long)intPtr);
		}

		[Token(Token = "0x600036A")]
		[Address(RVA = "0xA57358", Offset = "0xA57358", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EED8A0]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, timeScope, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FBF]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, timeScope, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.GameServices::IsInitialized();\n\tv54 = v52 == 0;\n\tif (v54) goto L_003F;\n\tgoto L_002E;\n\tv65 = *([v55 @ X0_v10+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_002E;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v55, timeScope, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv73 = EasyMobile.GameServices::GetLeaderboardByName(leaderboardName);\n\tv83 = v73 == 0;\n\tif (v83) goto L_004E;\n\tUnityEngine.Social::ShowLeaderboardUI();\n\treturn;\nL_003F:\n\tgoto L_FFFFFFFF;\n\tv74 = *([v61 @ X0_v7+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v61, timeScope, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_005D;\nL_004E:\n\tgoto L_FFFFFFFF;\n\tv107 = *([v103 @ X0_v14+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_FFFFFFFF;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v103, timeScope, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005D:\n\tUnityEngine.Debug::Log(*([v88 @ X8_v5 (System.String)]));\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowLeaderboardUI(string leaderboardName, TimeScope timeScope)
		{
			string message;
			if (IsInitialized())
			{
				Leaderboard leaderboardByName = GetLeaderboardByName(leaderboardName);
				if (leaderboardByName != null)
				{
					Social.ShowLeaderboardUI();
					return;
				}
				message = "Couldn't show leaderboard UI: unknown leaderboard name.";
			}
			else
			{
				message = "Couldn't show leaderboard UI: user is not logged in.";
			}
			Debug.Log(message);
		}

		[Token(Token = "0x600036B")]
		[Address(RVA = "0xA574F4", Offset = "0xA574F4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA3270]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FC0]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_002E;\n\tUnityEngine.Social::ShowAchievementsUI();\n\treturn;\nL_002E:\n\tgoto L_003C;\n\tv62 = *([v58 @ X0_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003C;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_003C:\n\tUnityEngine.Debug::Log(\"Couldn't show achievements UI: user is not logged in.\");\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowAchievementsUI()
		{
			if (IsInitialized())
			{
				Social.ShowAchievementsUI();
			}
			else
			{
				Debug.Log("Couldn't show achievements UI: user is not logged in.");
			}
		}

		[Token(Token = "0x600036C")]
		[Address(RVA = "0xA57598", Offset = "0xA57598", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF9CA8]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, leaderboardName, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FC1]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, leaderboardName, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = EasyMobile.GameServices::GetLeaderboardByName(leaderboardName);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0045;\n\tgoto L_003D;\n\tv73 = *([v62 @ X0_v10+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v62, leaderboardName, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003D:\n\tEasyMobile.GameServices::DoReportScore(score, v59._androidId, callback);\n\treturn;\nL_0045:\n\tgoto L_0056;\n\tv89 = *([v69 @ X0_v6+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0056;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v69, leaderboardName, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0056:\n\tUnityEngine.Debug::Log(\"Failed to report score: unknown leaderboard name.\");\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ReportScore(long score, string leaderboardName, Action<bool> callback = null)
		{
			Leaderboard leaderboardByName = GetLeaderboardByName(leaderboardName);
			if (leaderboardByName != null)
			{
				DoReportScore(score, leaderboardByName.AndroidId, callback);
			}
			else
			{
				Debug.Log("Failed to report score: unknown leaderboard name.");
			}
		}

		[Token(Token = "0x600036D")]
		[Address(RVA = "0xA57830", Offset = "0xA57830", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBBF18]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021FC2]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.GameServices::GetAchievementByName(achievementName);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0042;\n\tgoto L_003A;\n\tv70 = *([v59 @ X0_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003A:\n\tEasyMobile.GameServices::DoReportAchievementProgress(v56._androidId, 0d, callback);\n\treturn;\nL_0042:\n\tgoto L_0052;\n\tv85 = *([v66 @ X0_v6+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0052;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v66, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tUnityEngine.Debug::Log(\"Failed to reveal achievement: unknown achievement name.\");\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RevealAchievement(string achievementName, Action<bool> callback = null)
		{
			Achievement achievementByName = GetAchievementByName(achievementName);
			if (achievementByName != null)
			{
				DoReportAchievementProgress(achievementByName.AndroidId, 0.0, callback);
			}
			else
			{
				Debug.Log("Failed to reveal achievement: unknown achievement name.");
			}
		}

		[Token(Token = "0x600036E")]
		[Address(RVA = "0xA57B78", Offset = "0xA57B78", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBCA70]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021FC3]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = EasyMobile.GameServices::GetAchievementByName(achievementName);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0043;\n\tgoto L_003B;\n\tv70 = *([v59 @ X0_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003B;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003B:\n\tEasyMobile.GameServices::DoReportAchievementProgress(v56._androidId, 100d, callback);\n\treturn;\nL_0043:\n\tgoto L_0053;\n\tv86 = *([v66 @ X0_v6+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0053;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v66, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\tUnityEngine.Debug::Log(\"Failed to unlocked achievement: unknown achievement name.\");\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UnlockAchievement(string achievementName, Action<bool> callback = null)
		{
			Achievement achievementByName = GetAchievementByName(achievementName);
			if (achievementByName != null)
			{
				DoReportAchievementProgress(achievementByName.AndroidId, 100.0, callback);
			}
			else
			{
				Debug.Log("Failed to unlocked achievement: unknown achievement name.");
			}
		}

		[Token(Token = "0x600036F")]
		[Address(RVA = "0xA57C60", Offset = "0xA57C60", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EFCBF0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FC4]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, callback, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv59 = EasyMobile.GameServices::GetAchievementByName(achievementName);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0045;\n\tgoto L_003D;\n\tv73 = *([v62 @ X0_v10+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v62, callback, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\nL_003D:\n\tEasyMobile.GameServices::DoReportAchievementProgress(v59._androidId, progress, callback);\n\treturn;\nL_0045:\n\tgoto L_0056;\n\tv89 = *([v69 @ X0_v6+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0056;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v69, callback, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\nL_0056:\n\tUnityEngine.Debug::Log(\"Failed to report incremental achievement progress: unknown achievement name.\");\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ReportAchievementProgress(string achievementName, double progress, Action<bool> callback = null)
		{
			Achievement achievementByName = GetAchievementByName(achievementName);
			if (achievementByName != null)
			{
				DoReportAchievementProgress(achievementByName.AndroidId, progress, callback);
			}
			else
			{
				Debug.Log("Failed to report incremental achievement progress: unknown achievement name.");
			}
		}

		[Token(Token = "0x6000370")]
		[Address(RVA = "0xA57D54", Offset = "0xA57D54", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED14A0]);\n\tv23 = *([v22 @ X8_v49]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021FC5]) = v42;\nL_0018:\n\tv46 = new EasyMobile.GameServices+<>c__DisplayClass30_0();\n\tEasyMobile.GameServices+<>c__DisplayClass30_0::.ctor(v46);\n\tv46.callback = callback;\n\tgoto L_002B;\n\tv117 = *([v52 @ X0_v8 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_002B;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v52, v47, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tv124 = EasyMobile.GameServices::IsInitialized();\n\tv198 = v124 == 0;\n\tif (v198) goto L_0060;\n\tv177 = UnityEngine.Social::get_localUser();\n\tv320 = *([v177 @ X0_v21 (UnityEngine.SocialPlatforms.ILocalUser)]);\n\tv323 = *([v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]) == 0;\n\tif (v323) goto L_0058;\n\tv376 = *([v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]) + 8;\nL_0043:\n\tv381 = *([v376 @ X11_v28-8]) == UnityEngine.SocialPlatforms.ILocalUser;\n\tif (v381) goto L_0075;\n\tv375 = v375 + 1;\n\tv386 = v375 < *([v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]);\n\tv348 = ~v386;\n\tv376 = v376 + 0x10;\n\tv332 = ~v348;\n\tif (v332) goto L_0043;\nL_0058:\n\tv392 = 0x8909C4(v177, UnityEngine.SocialPlatforms.ILocalUser, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_007C;\nL_0060:\n\tgoto L_006A;\n\tv308 = *([v202 @ X0_v14+E0]);\n\tv309 = v308 == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_006A;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v202, v47, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006A:\n\tUnityEngine.Debug::Log(\"Failed to load friends: user is not logged in.\");\n\tv422 = v46.callback;\n\tv325 = v46.callback == 0;\n\tif (v325) goto L_0120;\n\t// 114 NewArr v416 @ X0_v11 (UnityEngine.SocialPlatforms.IUserProfile[]), typeof(UnityEngine.SocialPlatforms.IUserProfile[]), 0\n\tgoto L_0146;\nL_0075:\n\tv388 = *([v376 @ X11_v28]) + 1;\n\tv389 = v388 << 4;\n\tv390 = v320 + v389;\n\tv392 = v390 + 0x130;\nL_007C:\n\t*([v392 @ X0_v22])(v395, v177, *([v392 @ X0_v22+8]), v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv396 = v395 == 0;\n\tif (v396) goto L_00E3;\n\tv178 = UnityEngine.Social::get_localUser();\n\tv439 = *([v178 @ X0_v36 (UnityEngine.SocialPlatforms.ILocalUser)]);\n\tv442 = *([v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]) == 0;\n\tif (v442) goto L_00A6;\n\tv486 = *([v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]) + 8;\nL_0091:\n\tv491 = *([v486 @ X11_v23-8]) == UnityEngine.SocialPlatforms.ILocalUser;\n\tif (v491) goto L_00A9;\n\tv485 = v485 + 1;\n\tv499 = v485 < *([v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]);\n\tv467 = ~v499;\n\tv486 = v486 + 0x10;\n\tv451 = ~v467;\n\tif (v451) goto L_0091;\nL_00A6:\n\tv505 = 0x8909C4(v178, UnityEngine.SocialPlatforms.ILocalUser, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00B0;\nL_00A9:\n\tv501 = *([v486 @ X11_v23]) + 1;\n\tv502 = v501 << 4;\n\tv503 = v439 + v502;\n\tv505 = v503 + 0x130;\nL_00B0:\n\t*([v505 @ X0_v37])(v180, v178, *([v505 @ X0_v37+8]), v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv430 = *([v180 @ X0_v39+18]) == 0;\n\tif (v430) goto L_00E3;\n\tv422 = v46.callback;\n\tv362 = v46.callback == 0;\n\tif (v362) goto L_0120;\n\tv179 = UnityEngine.Social::get_localUser();\n\tv567 = *([v179 @ X0_v41 (UnityEngine.SocialPlatforms.ILocalUser)]);\n\tv418 = *([v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]) == 0;\n\tif (v418) goto L_00E0;\n\tv611 = *([v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]) + 8;\nL_00CB:\n\tv616 = *([v611 @ X11_v18-8]) == UnityEngine.SocialPlatforms.ILocalUser;\n\tif (v616) goto L_0132;\n\tv610 = v610 + 1;\n\tv621 = v610 < *([v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]);\n\tv592 = ~v621;\n\tv611 = v611 + 0x10;\n\tv576 = ~v592;\n\tif (v576) goto L_00CB;\nL_00E0:\n\tv627 = 0x8909C4(v179, UnityEngine.SocialPlatforms.ILocalUser, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0139;\nL_00E3:\n\tv434 = UnityEngine.Social::get_localUser();\n\tv109 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v109, v46, Il2CppMethodInfo);\n\tgoto L_0130;\n\tv508 = *([v496 @ X8_v33+B0]);\n\tv509 = 0;\n\tv510 = v508 + 8;\n\tv512 = *([v549 @ X11_v11-8]);\n\tv554 = v512 == v497;\n\tif (v554) goto L_0121;\n\tv532 = v548 + 1;\n\tv559 = v532 < v498;\n\tv530 = ~v559;\n\tv534 = v549 + 0x10;\n\tv514 = ~v530;\n\tif (v514) goto L_FFFFFFFF;\n\tv535 = v113;\n\tv536 = 0;\n\tv537 = 0x8909C4(v535, v497, v536, v60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0130;\nL_0120:\n\treturn;\nL_0121:\n\tv560 = *([v549 @ X11_v11]);\n\tv561 = v560 << 4;\n\tv562 = v496 + v561;\n\tv563 = v562 + 0x130;\nL_0130:\n\tUnityEngine.SocialPlatforms.ILocalUser::LoadFriends(v434, v109);\nL_0132:\n\tv623 = *([v611 @ X11_v18]) + 1;\n\tv624 = v623 << 4;\n\tv625 = v567 + v624;\n\tv627 = v625 + 0x130;\nL_0139:\n\t*([v627 @ X0_v42])(v416, v179, *([v627 @ X0_v42+8]), v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0146:\n\tSystem.Action`1<UnityEngine.SocialPlatforms.IUserProfile[]>::Invoke(v422, v416);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadFriends(Action<IUserProfile[]> callback)
		{
			//IL_0053: Expected I, but got O
			//IL_008e: Expected O, but got I
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_0187: Expected O, but got I
			//IL_0196: Expected O, but got I
			//IL_01b1: Expected I, but got O
			//IL_00da: Expected O, but got I
			//IL_01ec: Expected O, but got I
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_0294: Expected O, but got I
			//IL_02a3: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_0312: Expected I, but got O
			//IL_034d: Expected O, but got I
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Expected O, but got Unknown
			//IL_0422: Expected O, but got I
			//IL_0431: Expected O, but got I
			//IL_0399: Expected O, but got I
			if (IsInitialized())
			{
				ILocalUser localUser = Social.localUser;
				IntPtr intPtr = (IntPtr)localUser;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00f3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ X11_v28-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILocalUser))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X8_v24 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00f3;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_046f;
			}
			Debug.Log("Failed to load friends: user is not logged in.");
			Action<IUserProfile[]> action = callback;
			IUserProfile[] obj5 = default(IUserProfile[]);
			if (callback != null)
			{
				obj5 = new IUserProfile[0];
				goto IL_0496;
			}
			return;
			IL_0507:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v627 @ X0_v42] (should have been resolved before IL gen)");
			goto IL_0496;
			IL_0496:
			action(obj5);
			return;
			IL_046f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v392 @ X0_v22] (should have been resolved before IL gen)");
			object obj6 = default(object);
			if (obj6 == null)
			{
				goto IL_03ca;
			}
			ILocalUser localUser2 = Social.localUser;
			IntPtr intPtr2 = (IntPtr)localUser2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0251;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]");
			object obj7 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X11_v23-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalUser))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v36 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj7 = (long)(IntPtr)obj7 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0251;
			}
			object obj8 = obj7 + 1;
			int num6 = (int)((long)(IntPtr)obj8 << 4);
			object obj9 = (long)intPtr2 + (long)num6;
			object obj10 = (long)(IntPtr)obj9 + 304L;
			goto IL_04ce;
			IL_0251:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num7 = 1;
			goto IL_04ce;
			IL_04ce:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v505 @ X0_v37] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v39+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03ca;
			}
			action = callback;
			if (callback == null)
			{
				return;
			}
			ILocalUser localUser3 = Social.localUser;
			IntPtr intPtr3 = (IntPtr)localUser3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]");
			object obj11 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v611 @ X11_v18-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalUser))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X8_v40 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
				bool flag5 = (long)num9 < 0L;
				bool flag6 = !flag5;
				obj11 = (long)(IntPtr)obj11 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_03b2;
			}
			object obj12 = obj11 + 1;
			int num10 = (int)((long)(IntPtr)obj12 << 4);
			object obj13 = (long)intPtr3 + (long)num10;
			object obj14 = (long)(IntPtr)obj13 + 304L;
			goto IL_0507;
			IL_03ca:
			ILocalUser localUser4 = Social.localUser;
			Action<bool> callback2 = delegate(bool success)
			{
				//IL_003a: Expected I, but got O
				//IL_0075: Expected O, but got I
				//IL_0125: Unknown result type (might be due to invalid IL or missing references)
				//IL_012a: Expected O, but got Unknown
				//IL_0147: Expected O, but got I
				//IL_0156: Expected O, but got I
				//IL_00c1: Expected O, but got I
				if (success)
				{
					if (callback == null)
					{
						return;
					}
					ILocalUser localUser5 = Social.localUser;
					IntPtr intPtr4 = (IntPtr)localUser5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v8 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00da;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v8 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+B0]");
					object obj15 = 0L + 8L;
					int num11 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X11_v6-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILocalUser))
						{
							break;
						}
						num11++;
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v8 (Il2CppClass<UnityEngine.SocialPlatforms.ILocalUser>)+126]");
						bool flag7 = (long)num12 < 0L;
						bool flag8 = !flag7;
						obj15 = (long)(IntPtr)obj15 + 16L;
						if (!flag8)
						{
							continue;
						}
						goto IL_00da;
					}
					object obj16 = obj15 + 1;
					int num13 = (int)((long)(IntPtr)obj16 << 4);
					object obj17 = (long)intPtr4 + (long)num13;
					object obj18 = (long)(IntPtr)obj17 + 304L;
					goto IL_01a2;
				}
				if (callback == null)
				{
					return;
				}
				IUserProfile[] obj19 = new IUserProfile[0];
				goto IL_01b1;
				IL_00da:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_01a2;
				IL_01a2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ X0_v9] (should have been resolved before IL gen)");
				goto IL_01b1;
				IL_01b1:
				callback(obj19);
			};
			localUser4.LoadFriends(callback2);
			return;
			IL_03b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num7 = 1;
			goto IL_0507;
			IL_00f3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num7 = 1;
			goto IL_046f;
		}

		[Token(Token = "0x6000371")]
		[Address(RVA = "0xA5809C", Offset = "0xA5809C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDACB8]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021FC6]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = EasyMobile.GameServices::IsInitialized();\n\tv57 = v55 == 0;\n\tif (v57) goto L_0036;\n\tUnityEngine.Social::LoadUsers(userIds, callback);\n\treturn;\nL_0036:\n\tgoto L_0040;\n\tv72 = *([v68 @ X0_v5+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0040;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tUnityEngine.Debug::Log(\"Failed to load users: user is not logged in.\");\n\tv93 = callback == 0;\n\tif (v93) goto L_005B;\n\t// 71 NewArr v112 @ X0_v9 (UnityEngine.SocialPlatforms.IUserProfile[]), typeof(UnityEngine.SocialPlatforms.IUserProfile[]), 0\n\tSystem.Action`1<UnityEngine.SocialPlatforms.IUserProfile[]>::Invoke(callback, v112);\n\treturn;\nL_005B:\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
		{
			if (IsInitialized())
			{
				Social.LoadUsers(userIds, callback);
				return;
			}
			Debug.Log("Failed to load users: user is not logged in.");
			if (callback != null)
			{
				IUserProfile[] obj = new IUserProfile[0];
				callback(obj);
			}
		}

		[Token(Token = "0x6000372")]
		[Address(RVA = "0xA5819C", Offset = "0xA5819C", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv24 = *([1ECF9E0]);\n\tv25 = *([v24 @ X8_v51]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021FC7]) = v43;\nL_0020:\n\tgoto L_0026;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0026;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = EasyMobile.GameServices::IsInitialized();\n\tv63 = v61 == 0;\n\tif (v63) goto L_006A;\n\tgoto L_0035;\n\tv73 = *([v64 @ X0_v27+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0035;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v64, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0035:\n\tv81 = EasyMobile.GameServices::GetLeaderboardByName(leaderboardName);\n\tv85 = v81 == 0;\n\tif (v85) goto L_008D;\n\tgoto L_005A;\n\tv169 = *([v130 @ X0_v39 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\t// 71 ConditionalJump @b52, v171 @ TEMP_v45\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v130, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv173 = EasyMobile.GameServices;\nL_005A:\n\tv189 = 1;\n\tSystem.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>::Add(v126.loadScoreRequests, &v189 @ X9_v7 (System.Int32));\n\tEasyMobile.GameServices::DoNextLoadScoreRequest();\n\tgoto L_00C4;\nL_006A:\n\t// 106 NewArr v72 @ X0_v20 (System.Object[]), typeof(System.Object[]), 1\n\tv86 = leaderboardName == 0;\n\tif (v86) goto L_0077;\n\t// 115 IsInst v139 @ X0_v26, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_0077:\n\tv146 = v72.Length == 0;\n\tif (v146) goto L_00C6;\n\tv72[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv209 = *([v178 @ X0_v22+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_FFFFFFFF;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v178, v140, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00AE;\nL_008D:\n\t// 141 NewArr v117 @ X0_v32 (System.Object[]), typeof(System.Object[]), 1\n\tv198 = leaderboardName == 0;\n\tif (v198) goto L_009A;\n\t// 150 IsInst v202 @ X0_v38, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_009A:\n\tv163 = v117.Length == 0;\n\tif (v163) goto L_00C6;\n\tv117[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv335 = *([v254 @ X0_v34+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_FFFFFFFF;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v254, v151, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00AE:\n\tUnityEngine.Debug::LogFormat(*([v246 @ X8_v5 (System.String)]), v248);\n\tv258 = callback == 0;\n\tif (v258) goto L_00C4;\n\t// 181 NewArr v345 @ X0_v8 (UnityEngine.SocialPlatforms.IScore[]), typeof(UnityEngine.SocialPlatforms.IScore[]), 0\n\tSystem.Action`2<System.String, UnityEngine.SocialPlatforms.IScore[]>::Invoke(callback, leaderboardName, v345);\nL_00C4:\n\treturn;\n\tv129 = new System.NullReferenceException();\nL_00C6:\n\tv168 = new System.IndexOutOfRangeException();\n\tgoto L_00CB;\n\tv208 = new System.ArrayTypeMismatchException();\nL_00CB:\n\tthrow v230;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void LoadScores(string leaderboardName, Action<string, IScore[]> callback)
		{
			//IL_0076: Expected O, but got Ref
			string format;
			object[] args;
			if (IsInitialized())
			{
				Leaderboard leaderboardByName = GetLeaderboardByName(leaderboardName);
				if (leaderboardByName != null)
				{
					int num = 1;
					loadScoreRequests.Add((LoadScoreRequest)(&num));
					DoNextLoadScoreRequest();
					return;
				}
				object[] array = new object[1];
				if (leaderboardName != null)
				{
					object obj = leaderboardName as object;
				}
				if (array.Length == 0)
				{
					goto IL_01c6;
				}
				array[0] = leaderboardName;
				format = "Failed to load scores: unknown leaderboard name {0}";
				args = array;
			}
			else
			{
				object[] array2 = new object[1];
				if (leaderboardName != null)
				{
					object obj2 = leaderboardName as object;
				}
				if (array2.Length == 0)
				{
					goto IL_01c6;
				}
				array2[0] = leaderboardName;
				format = "Failed to load scores from leaderboard {0}: user is not logged in.";
				args = array2;
			}
			Debug.LogFormat(format, args);
			if (callback != null)
			{
				IScore[] arg = new IScore[0];
				callback(leaderboardName, arg);
			}
			return;
			IL_01c6:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000373")]
		[Address(RVA = "0xA58900", Offset = "0xA58900", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv40 = *([1EEE928]);\n\tv41 = *([v40 @ X8_v52]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, fromRank, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2021FC8]) = v55;\nL_0026:\n\tgoto L_002C;\n\tv64 = *([v60 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, fromRank, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_002C:\n\tv71 = EasyMobile.GameServices::IsInitialized();\n\tv73 = v71 == 0;\n\tif (v73) goto L_006D;\n\tgoto L_003B;\n\tv83 = *([v74 @ X0_v27+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_003B;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v74, fromRank, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_003B:\n\tv91 = EasyMobile.GameServices::GetLeaderboardByName(leaderboardName);\n\tv95 = v91 == 0;\n\tif (v95) goto L_0090;\n\tgoto L_005C;\n\tv162 = *([v128 @ X0_v39 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\t// 75 ConditionalJump @b52, v164 @ TEMP_v45\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v128, fromRank, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv166 = EasyMobile.GameServices;\nL_005C:\n\tv182 = 0;\n\tSystem.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>::Add(v169.loadScoreRequests, &v182 @ stack_-80_v2);\n\tEasyMobile.GameServices::DoNextLoadScoreRequest();\n\tgoto L_00CB;\nL_006D:\n\t// 109 NewArr v82 @ X0_v20 (System.Object[]), typeof(System.Object[]), 1\n\tv96 = leaderboardName == 0;\n\tif (v96) goto L_007A;\n\t// 118 IsInst v137 @ X0_v26, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_007A:\n\tv144 = v82.Length == 0;\n\tif (v144) goto L_00CD;\n\tv82[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv204 = *([v172 @ X0_v22+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_FFFFFFFF;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v172, v138, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00B1;\nL_0090:\n\t// 144 NewArr v115 @ X0_v32 (System.Object[]), typeof(System.Object[]), 1\n\tv193 = leaderboardName == 0;\n\tif (v193) goto L_009D;\n\t// 153 IsInst v197 @ X0_v38, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_009D:\n\tv156 = v115.Length == 0;\n\tif (v156) goto L_00CD;\n\tv115[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv332 = *([v244 @ X0_v34+E0]);\n\tv333 = v332 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_FFFFFFFF;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v244, v148, scoreCount, timeScope, userScope, callback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00B1:\n\tUnityEngine.Debug::LogFormat(*([v237 @ X8_v5 (System.String)]), v236);\n\tv248 = callback == 0;\n\tif (v248) goto L_00CB;\n\t// 184 NewArr v342 @ X0_v8 (UnityEngine.SocialPlatforms.IScore[]), typeof(UnityEngine.SocialPlatforms.IScore[]), 0\n\tSystem.Action`2<System.String, UnityEngine.SocialPlatforms.IScore[]>::Invoke(callback, leaderboardName, v342);\nL_00CB:\n\treturn;\n\tv127 = new System.NullReferenceException();\nL_00CD:\n\tv161 = new System.IndexOutOfRangeException();\n\tgoto L_00D2;\n\tv203 = new System.ArrayTypeMismatchException();\nL_00D2:\n\tthrow v220;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void LoadScores(string leaderboardName, int fromRank, int scoreCount, TimeScope timeScope, UserScope userScope, Action<string, IScore[]> callback)
		{
			//IL_0068: Expected O, but got I4
			//IL_0076: Expected O, but got Ref
			object[] args;
			string format;
			if (IsInitialized())
			{
				Leaderboard leaderboardByName = GetLeaderboardByName(leaderboardName);
				if (leaderboardByName != null)
				{
					object obj = 0;
					loadScoreRequests.Add((LoadScoreRequest)(&obj));
					DoNextLoadScoreRequest();
					return;
				}
				object[] array = new object[1];
				if (leaderboardName != null)
				{
					object obj2 = leaderboardName as object;
				}
				if (array.Length == 0)
				{
					goto IL_01c6;
				}
				array[0] = leaderboardName;
				args = array;
				format = "Failed to load scores: unknown leaderboard name {0}.";
			}
			else
			{
				object[] array2 = new object[1];
				if (leaderboardName != null)
				{
					object obj3 = leaderboardName as object;
				}
				if (array2.Length == 0)
				{
					goto IL_01c6;
				}
				array2[0] = leaderboardName;
				args = array2;
				format = "Failed to load scores from leaderboard {0}: user is not logged in.";
			}
			Debug.LogFormat(format, args);
			if (callback != null)
			{
				IScore[] arg = new IScore[0];
				callback(leaderboardName, arg);
			}
			return;
			IL_01c6:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000374")]
		[Address(RVA = "0xA58B88", Offset = "0xA58B88", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0019;\n\tv26 = *([1EF5998]);\n\tv27 = *([v26 @ X8_v56]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021FC9]) = v45;\nL_0019:\n\t*([v14 @ X29_v1-24]) = 0;\n\t*([v14 @ X29_v1-28]) = 0;\n\tv49 = new EasyMobile.GameServices+<>c__DisplayClass34_0();\n\tEasyMobile.GameServices+<>c__DisplayClass34_0::.ctor(v49);\n\tv49.callback = callback;\n\tgoto L_002F;\n\tv60 = *([v55 @ X0_v11 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_002F;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v55, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002F:\n\tv67 = EasyMobile.GameServices::IsInitialized();\n\tv108 = v67 == 0;\n\tif (v108) goto L_007C;\n\tgoto L_003E;\n\tv137 = *([v131 @ X0_v28+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_003E;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v131, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_003E:\n\tv145 = EasyMobile.GameServices::GetLeaderboardByName(leaderboardName);\n\tv167 = v145 == 0;\n\tif (v167) goto L_009F;\n\t*([v14 @ X29_v1-24]) = 0;\n\t*([v14 @ X29_v1-28]) = 0;\n\tv172 = new System.Action`2<System.String, UnityEngine.SocialPlatforms.IScore[]>();\n\tSystem.Action`2<System.String, UnityEngine.SocialPlatforms.IScore[]>::.ctor(v172, v49, Il2CppMethodInfo);\n\tgoto L_006C;\n\tv275 = *([v256 @ X0_v42 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv276 = v275 == 0;\n\tv277 = ~v276;\n\t// 90 ConditionalJump @b56, v277 @ TEMP_v46\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v256, v88, v77, v75, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv279 = EasyMobile.GameServices;\nL_006C:\n\tv305 = 0x100;\n\tSystem.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>::Add(v282.loadScoreRequests, &v305 @ X9_v8 (System.Int32));\n\tEasyMobile.GameServices::DoNextLoadScoreRequest();\n\tgoto L_00D2;\nL_007C:\n\t// 124 NewArr v90 @ X0_v21 (System.Object[]), typeof(System.Object[]), 1\n\tv168 = leaderboardName == 0;\n\tif (v168) goto L_0089;\n\t// 133 IsInst v178 @ X0_v27, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_0089:\n\tv123 = v90.Length == 0;\n\tif (v123) goto L_00D5;\n\tv90[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv266 = *([v252 @ X0_v23+E0]);\n\tv267 = v266 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_FFFFFFFF;\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v252, v117, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00C0;\nL_009F:\n\t// 159 NewArr v91 @ X0_v33 (System.Object[]), typeof(System.Object[]), 1\n\tv260 = leaderboardName == 0;\n\tif (v260) goto L_00AC;\n\t// 168 IsInst v263 @ X0_v39, typeof(System.Object), leaderboardName @ X0 (System.String)\nL_00AC:\n\tv124 = v91.Length == 0;\n\tif (v124) goto L_00D5;\n\tv91[0] = leaderboardName;\n\tgoto L_FFFFFFFF;\n\tv322 = *([v316 @ X0_v35+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\tif (v324) goto L_FFFFFFFF;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v316, v118, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00C0:\n\tUnityEngine.Debug::LogFormat(*([v292 @ X8_v10 (System.String)]), v291);\n\tv321 = v49.callback == 0;\n\tif (v321) goto L_00D2;\n\tSystem.Action`2<System.String, UnityEngine.SocialPlatforms.IScore>::Invoke(v49.callback, leaderboardName, 0);\nL_00D2:\n\treturn;\n\tv106 = new System.NullReferenceException();\nL_00D5:\n\tv130 = new System.IndexOutOfRangeException();\n\tgoto L_00DA;\n\tv156 = new System.ArrayTypeMismatchException();\nL_00DA:\n\tthrow v155;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void LoadLocalUserScore(string leaderboardName, Action<string, IScore> callback)
		{
			//IL_00b5: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			object[] args;
			string format;
			if (IsInitialized())
			{
				Leaderboard leaderboardByName = GetLeaderboardByName(leaderboardName);
				if (leaderboardByName != null)
				{
					_ = 0;
					_ = 0;
					Action<string, IScore[]> action = delegate(string ldbName, IScore[] scores)
					{
						IScore arg;
						if (scores != null)
						{
							if (callback == null)
							{
								return;
							}
							if (scores.Length == 0)
							{
								IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
								throw ex3;
							}
							arg = scores[0];
						}
						else
						{
							if (callback == null)
							{
								return;
							}
							arg = null;
						}
						string arg2 = default(string);
						callback(arg2, arg);
					};
					int num = 256;
					loadScoreRequests.Add((LoadScoreRequest)(&num));
					DoNextLoadScoreRequest();
					return;
				}
				object[] array = new object[1];
				if (leaderboardName != null)
				{
					object obj3 = leaderboardName as object;
				}
				if (array.Length == 0)
				{
					goto IL_01f9;
				}
				array[0] = leaderboardName;
				args = array;
				format = "Failed to load local user's score: unknown leaderboard name {0}.";
			}
			else
			{
				object[] array2 = new object[1];
				if (leaderboardName != null)
				{
					object obj4 = leaderboardName as object;
				}
				if (array2.Length == 0)
				{
					goto IL_01f9;
				}
				array2[0] = leaderboardName;
				args = array2;
				format = "Failed to load local user's score from leaderboard {0}: user is not logged in.";
			}
			Debug.LogFormat(format, args);
			if (callback != null)
			{
				callback(leaderboardName, null);
			}
			return;
			IL_01f9:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000375")]
		[Address(RVA = "0xA57450", Offset = "0xA57450", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = EasyMobile.EM_Settings::get_GameServices();\n\tv18 = v16.mLeaderboards;\n\tv115 = v18.Length;\n\tv110 = v18.Length < 1;\n\tif (v110) goto L_FFFFFFFF;\nL_001D:\n\tv206 = v37 < v115;\n\tv73 = ~v206;\n\tif (v73) goto L_004E;\n\tv30 = v18[v37 @ X22_v7 (System.Int32)];\n\tv154 = System.String::Equals(v30._name, leaderboardName);\n\tv212 = v154 == 0;\n\tv152 = ~v212;\n\tif (v152) goto L_004D;\n\tv115 = v18.Length;\n\tv37 = v37 + 1;\n\tv132 = v37 < v18.Length;\n\tif (v132) goto L_001D;\nL_004D:\n\treturn v207;\nL_004E:\n\tv210 = new System.IndexOutOfRangeException();\n\tthrow v210;\n\tv83 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Leaderboard GetLeaderboardByName(string leaderboardName)
		{
			GameServicesSettings gameServices = EM_Settings.GameServices;
			Leaderboard[] leaderboards = gameServices.Leaderboards;
			int num = leaderboards.Length;
			if (leaderboards.Length < 1)
			{
				goto IL_00f2;
			}
			int num2 = 0;
			Leaderboard result;
			while (true)
			{
				if (num2 < num)
				{
					Leaderboard leaderboard = leaderboards[num2];
					bool flag = leaderboard.Name.Equals(leaderboardName);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = leaderboards[num2];
					if (flag3)
					{
						break;
					}
					num = leaderboards.Length;
					num2++;
					if (num2 < leaderboards.Length)
					{
						continue;
					}
					goto IL_00f2;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_010a;
			IL_00f2:
			result = null;
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x6000376")]
		[Address(RVA = "0xA57914", Offset = "0xA57914", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = EasyMobile.EM_Settings::get_GameServices();\n\tv18 = v16.mAchievements;\n\tv115 = v18.Length;\n\tv110 = v18.Length < 1;\n\tif (v110) goto L_FFFFFFFF;\nL_001D:\n\tv206 = v37 < v115;\n\tv73 = ~v206;\n\tif (v73) goto L_004E;\n\tv30 = v18[v37 @ X22_v7 (System.Int32)];\n\tv154 = System.String::Equals(v30._name, achievementName);\n\tv212 = v154 == 0;\n\tv152 = ~v212;\n\tif (v152) goto L_004D;\n\tv115 = v18.Length;\n\tv37 = v37 + 1;\n\tv132 = v37 < v18.Length;\n\tif (v132) goto L_001D;\nL_004D:\n\treturn v207;\nL_004E:\n\tv210 = new System.IndexOutOfRangeException();\n\tthrow v210;\n\tv83 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Achievement GetAchievementByName(string achievementName)
		{
			GameServicesSettings gameServices = EM_Settings.GameServices;
			Achievement[] achievements = gameServices.Achievements;
			int num = achievements.Length;
			if (achievements.Length < 1)
			{
				goto IL_00f2;
			}
			int num2 = 0;
			Achievement result;
			while (true)
			{
				if (num2 < num)
				{
					Achievement achievement = achievements[num2];
					bool flag = achievement.Name.Equals(achievementName);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = achievements[num2];
					if (flag3)
					{
						break;
					}
					num = achievements.Length;
					num2++;
					if (num2 < achievements.Length)
					{
						continue;
					}
					goto IL_00f2;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_010a;
			IL_00f2:
			result = null;
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x6000377")]
		[Address(RVA = "0xA58E44", Offset = "0xA58E44", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBA410]);\n\tv15 = *([v14 @ X8_v21]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FCA]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_003B;\n\tgoto L_0031;\n\tv74 = *([v54 @ X0_v7+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0031;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v54, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0031:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\nL_003B:\n\treturn v71.Empty;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetServerAuthCode()
		{
			if (IsInitialized())
			{
				Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
			}
			return string.Empty;
		}

		[Token(Token = "0x6000378")]
		[Address(RVA = "0xA58EF0", Offset = "0xA58EF0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED80A8]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FCB]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_003B;\n\tgoto L_0035;\n\tv61 = *([v54 @ X0_v5+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0035;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v54, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0035:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\nL_003B:\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback)
		{
			if (IsInitialized())
			{
				Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
			}
		}

		[Token(Token = "0x6000379")]
		[Address(RVA = "0xA58F90", Offset = "0xA58F90", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0AED0]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FCC]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.GameServices::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_003B;\n\tgoto L_0035;\n\tv61 = *([v54 @ X0_v5+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0035;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v54, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0035:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\nL_003B:\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SignOut()
		{
			if (IsInitialized())
			{
				Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
			}
		}

		[Token(Token = "0x600037A")]
		[Address(RVA = "0xA57680", Offset = "0xA57680", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB9160]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, leaderboardId, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FCD]) = v44;\nL_001A:\n\tv48 = new EasyMobile.GameServices+<>c__DisplayClass40_0();\n\tEasyMobile.GameServices+<>c__DisplayClass40_0::.ctor(v48);\n\tv48.callback = callback;\n\tgoto L_002D;\n\tv59 = *([v54 @ X0_v11 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002D;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v54, v49, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv66 = EasyMobile.GameServices::IsInitialized();\n\tv79 = v66 == 0;\n\tif (v79) goto L_004F;\n\tv93 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v93, v48, Il2CppMethodInfo);\n\tUnityEngine.Social::ReportScore(score, leaderboardId, v93);\n\treturn;\nL_004F:\n\t// 79 NewArr v70 @ X0_v15 (System.Object[]), typeof(System.Object[]), 1\n\tv126 = leaderboardId == 0;\n\tif (v126) goto L_005C;\n\t// 88 IsInst v128 @ X0_v23, typeof(System.Object), leaderboardId @ X1 (System.String)\nL_005C:\n\tv85 = v70.Length == 0;\n\tif (v85) goto L_008B;\n\tv70[0] = leaderboardId;\n\tgoto L_0070;\n\tv171 = *([v167 @ X0_v17+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0070;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v167, v81, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0070:\n\tUnityEngine.Debug::LogFormat(\"Failed to report score to leaderboard {0}: user is not logged in.\", v70);\n\tv146 = v48.callback == 0;\n\tif (v146) goto L_0088;\n\tSystem.Action`1<System.Boolean>::Invoke(v48.callback, 0);\n\treturn;\nL_0088:\n\treturn;\n\tv77 = new System.NullReferenceException();\nL_008B:\n\tv89 = new System.IndexOutOfRangeException();\n\tgoto L_0090;\n\tv107 = new System.ArrayTypeMismatchException();\nL_0090:\n\tthrow v106;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DoReportScore(long score, string leaderboardId, Action<bool> callback)
		{
			if (IsInitialized())
			{
				Action<bool> callback2 = delegate(bool success)
				{
					if (callback != null)
					{
						callback(success);
					}
				};
				Social.ReportScore(score, leaderboardId, callback2);
				return;
			}
			object[] array = new object[1];
			if (leaderboardId != null)
			{
				object obj = leaderboardId as object;
			}
			if (array.Length != 0)
			{
				array[0] = leaderboardId;
				Debug.LogFormat("Failed to report score to leaderboard {0}: user is not logged in.", array);
				if (callback != null)
				{
					callback(obj: false);
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600037B")]
		[Address(RVA = "0xA579B8", Offset = "0xA579B8", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EAE3D8]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021FCE]) = v44;\nL_001A:\n\tv48 = new EasyMobile.GameServices+<>c__DisplayClass41_0();\n\tEasyMobile.GameServices+<>c__DisplayClass41_0::.ctor(v48);\n\tv48.callback = callback;\n\tgoto L_002D;\n\tv59 = *([v54 @ X0_v11 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002D;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v54, v49, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv66 = EasyMobile.GameServices::IsInitialized();\n\tv79 = v66 == 0;\n\tif (v79) goto L_004F;\n\tv93 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v93, v48, Il2CppMethodInfo);\n\tUnityEngine.Social::ReportProgress(achievementId, progress, v93);\n\treturn;\nL_004F:\n\t// 79 NewArr v70 @ X0_v15 (System.Object[]), typeof(System.Object[]), 1\n\tv126 = achievementId == 0;\n\tif (v126) goto L_005C;\n\t// 88 IsInst v128 @ X0_v23, typeof(System.Object), achievementId @ X0 (System.String)\nL_005C:\n\tv85 = v70.Length == 0;\n\tif (v85) goto L_008B;\n\tv70[0] = achievementId;\n\tgoto L_0070;\n\tv172 = *([v168 @ X0_v17+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0070;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v168, v81, methodInfo, v30, v31, v32, v33, v34, progress, v35, v36, v37, v38, v39, v40, v41);\nL_0070:\n\tUnityEngine.Debug::LogFormat(\"Failed to report progress for achievement {0}: user is not logged in.\", v70);\n\tv147 = v48.callback == 0;\n\tif (v147) goto L_0088;\n\tSystem.Action`1<System.Boolean>::Invoke(v48.callback, 0);\n\treturn;\nL_0088:\n\treturn;\n\tv77 = new System.NullReferenceException();\nL_008B:\n\tv89 = new System.IndexOutOfRangeException();\n\tgoto L_0090;\n\tv107 = new System.ArrayTypeMismatchException();\nL_0090:\n\tthrow v106;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DoReportAchievementProgress(string achievementId, double progress, Action<bool> callback)
		{
			if (IsInitialized())
			{
				Action<bool> callback2 = delegate(bool success)
				{
					if (callback != null)
					{
						callback(success);
					}
				};
				Social.ReportProgress(achievementId, progress, callback2);
				return;
			}
			object[] array = new object[1];
			if (achievementId != null)
			{
				object obj = achievementId as object;
			}
			if (array.Length != 0)
			{
				array[0] = achievementId;
				Debug.LogFormat("Failed to report progress for achievement {0}: user is not logged in.", array);
				if (callback != null)
				{
					callback(obj: false);
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600037C")]
		[Address(RVA = "0xA58418", Offset = "0xA58418", Length = "0x4E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F0DE68]);\n\tv21 = *([v20 @ X8_v61]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2021FCF]) = v41;\nL_0017:\n\tv45 = new EasyMobile.GameServices+<>c__DisplayClass42_0();\n\tEasyMobile.GameServices+<>c__DisplayClass42_0::.ctor(v45);\n\tgoto L_002A;\n\tv54 = *([v50 @ X0_v4 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, v46, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = EasyMobile.GameServices;\nL_002A:\n\tv63 = ~v61.isLoadingScore;\n\tif (v63) goto L_0037;\nL_0033:\n\treturn;\nL_0037:\n\tgoto L_003F;\n\tv232 = *([v57 @ X0_v5 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_003F;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v57, v46, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv236 = EasyMobile.GameServices;\n\tv238 = *([v236 @ X0_v64+B8]);\nL_003F:\n\tv239 = v137.loadScoreRequests;\n\tv134 = v239._size == 0;\n\tif (v134) goto L_0033;\n\tgoto L_0051;\n\tv377 = *([v131 @ X0_v6 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv378 = v377 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_0051;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v131, v46, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv381 = EasyMobile.GameServices;\n\tv384 = *([v381 @ X0_v62+B8]);\nL_0051:\n\tv383.isLoadingScore = 1;\n\tv327 = v361.loadScoreRequests;\n\tv387 = v327._size == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_005C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005C:\n\tv357 = v327._items;\n\tv45.request.timeScope = *([v357 @ X8_v14 (LoadScoreRequest[])+40]);\n\tv45.request.leaderboardId = *([v357 @ X8_v14 (LoadScoreRequest[])+30]);\n\tv45.request = *([v357 @ X8_v14 (LoadScoreRequest[])+20]);\n\tSystem.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>::RemoveAt(v375.loadScoreRequests, 0);\n\tv372 = UnityEngine.Social::CreateLeaderboard();\n\tv45.ldb = v372;\n\tv398 = *([v372 @ X0_v15 (UnityEngine.SocialPlatforms.ILeaderboard)]);\n\tv401 = *([v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]) == 0;\n\tif (v401) goto L_00A0;\n\tv443 = *([v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]) + 8;\nL_008B:\n\tv448 = *([v443 @ X11_v38-8]) == UnityEngine.SocialPlatforms.ILeaderboard;\n\tif (v448) goto L_00A3;\n\tv442 = v442 + 1;\n\tv453 = v442 < *([v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]);\n\tv424 = ~v453;\n\tv443 = v443 + 0x10;\n\tv408 = ~v424;\n\tif (v408) goto L_008B;\nL_00A0:\n\tv460 = 0x8909C4(v372, UnityEngine.SocialPlatforms.ILeaderboard, 2, v25, v26, v27, v28, v29, &v357[0], v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00A8;\nL_00A3:\n\tv455 = *([v443 @ X11_v38]) + 2;\n\tv456 = v455 << 4;\n\tv457 = v398 + v456;\n\tv460 = v457 + 0x130;\nL_00A8:\n\tv580 = *([v460 @ X0_v16+8]);\n\t*([v460 @ X0_v16])(v343, v372, v45.request.leaderboardId, *([v460 @ X0_v16+8]), v25, v26, v27, v28, v29, *([v357 @ X8_v14 (LoadScoreRequest[])+20]), v31, v32, v33, v34, v35, v36, v37);\n\tv333 = v45.ldb;\n\tv464 = v45.request == 0;\n\tif (v464) goto L_00DD;\n\tv465 = *([v333 @ X20_v6 (UnityEngine.SocialPlatforms.ILeaderboard)]);\n\tv223 = *([v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]) == 0;\n\tif (v223) goto L_00D4;\n\tv543 = *([v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]) + 8;\nL_00BF:\n\tv548 = *([v543 @ X11_v33-8]) == UnityEngine.SocialPlatforms.ILeaderboard;\n\tif (v548) goto L_00FE;\n\tv542 = v542 + 1;\n\tv574 = v542 < *([v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]);\n\tv494 = ~v574;\n\tv543 = v543 + 0x10;\n\tv478 = ~v494;\n\tif (v478) goto L_00BF;\nL_00D4:\n\tv582 = 0x8909C4(v45.ldb, UnityEngine.SocialPlatforms.ILeaderboard, 1, v25, v26, v27, v28, v29, &v357[0], v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0105;\nL_00DD:\n\tgoto L_012A;\n\tv502 = *([v468 @ X8_v23+B0]);\n\tv503 = 0;\n\tv504 = v502 + 8;\n\tv506 = *([v564 @ X11_v27-8]);\n\tv569 = v506 == v469;\n\tif (v569) goto L_0121;\n\tv526 = v563 + 1;\n\tv594 = v526 < v470;\n\tv524 = ~v594;\n\tv528 = v564 + 0x10;\n\tv508 = ~v524;\n\tif (v508) goto L_FFFFFFFF;\n\tv529 = 5;\n\tv530 = v333;\n\tv531 = 0x8909C4(v530, v469, v529, v25, v26, v27, v28, v29, v118, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_012A;\nL_00FE:\n\tv576 = *([v543 @ X11_v33]) + 1;\n\tv577 = v576 << 4;\n\tv578 = v465 + v577;\n\tv582 = v578 + 0x130;\nL_0105:\n\t*([v582 @ X0_v48])(v587, v45.ldb, *([v582 @ X0_v48+8]), v580, v25, v26, v27, v28, v29, *([v357 @ X8_v14 (LoadScoreRequest[])+20]), v31, v32, v33, v34, v35, v36, v37);\n\tv593 = new System.Action`1<UnityEngine.SocialPlatforms.IScore[]>();\n\tSystem.Action`1<UnityEngine.SocialPlatforms.IScore[]>::.ctor(v593, v45, Il2CppMethodInfo);\n\tUnityEngine.Social::LoadScores(v587, v593);\n\treturn;\nL_0121:\n\tv595 = *([v564 @ X11_v27]);\n\tv596 = v595 + 5;\n\tv597 = v596 << 4;\n\tv598 = v468 + v597;\n\tv599 = v598 + 0x130;\nL_012A:\n\tUnityEngine.SocialPlatforms.ILeaderboard::set_timeScope(v45.ldb, v45.request.timeScope);\n\tv335 = v45.ldb;\n\tv609 = *([v335 @ X20_v7 (UnityEngine.SocialPlatforms.ILeaderboard)]);\n\tv612 = *([v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]) == 0;\n\tif (v612) goto L_0151;\n\tv654 = *([v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]) + 8;\nL_013C:\n\tv659 = *([v654 @ X11_v22-8]) == UnityEngine.SocialPlatforms.ILeaderboard;\n\tif (v659) goto L_0154;\n\tv653 = v653 + 1;\n\tv664 = v653 < *([v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]);\n\tv635 = ~v664;\n\tv654 = v654 + 0x10;\n\tv619 = ~v635;\n\tif (v619) goto L_013C;\nL_0151:\n\tv680 = 0x8909C4(v335, UnityEngine.SocialPlatforms.ILeaderboard, 3, v25, v26, v27, v28, v29, &v357[0], v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_015C;\nL_0154:\n\tv666 = *([v654 @ X11_v22]) + 3;\n\tv667 = v666 << 4;\n\tv668 = v609 + v667;\n\tv680 = v668 + 0x130;\nL_015C:\n\t*([v680 @ X0_v22])(v686, v335, v45.request.userScope, *([v680 @ X0_v22+8]), v25, v26, v27, v28, v29, *([v357 @ X8_v14 (LoadScoreRequest[])+20]), v31, v32, v33, v34, v35, v36, v37);\n\tv697 = v45.request.fromRank < 1;\n\tif (v697) goto L_01B2;\n\tv256 = v45.request.scoreCount < 1;\n\tif (v256) goto L_01B2;\n\tv334 = v45.ldb;\n\tv315 = 0;\n\tv344 = 0x16565D0(&v315 @ stack_-60_v5, v45.request.fromRank, v45.request.scoreCount, 0, v26, v27, v28, v29, &v357[0], v31, v32, v33, v34, v35, v36, v37);\n\tv735 = *([v334 @ X20_v10 (UnityEngine.SocialPlatforms.ILeaderboard)]);\n\tv726 = *([v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]) == 0;\n\tif (v726) goto L_01A2;\n\tv812 = *([v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]) + 8;\nL_018D:\n\tv817 = *([v812 @ X11_v17-8]) == UnityEngine.SocialPlatforms.ILeaderboard;\n\tif (v817) goto L_01A5;\n\tv811 = v811 + 1;\n\tv843 = v811 < *([v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]);\n\tv763 = ~v843;\n\tv812 = v812 + 0x10;\n\tv747 = ~v763;\n\tif (v747) goto L_018D;\nL_01A2:\n\tv850 = 0x8909C4(v334, UnityEngine.SocialPlatforms.ILeaderboard, 4, 0, v26, v27, v28, v29, &v357[0], v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_01AD;\nL_01A5:\n\tv845 = *([v812 @ X11_v17]) + 4;\n\tv846 = v845 << 4;\n\tv847 = v735 + v846;\n\tv850 = v847 + 0x130;\nL_01AD:\n\t*([v850 @ X0_v36])(v724, v334, 0, *([v850 @ X0_v36+8]), 0, v26, v27, v28, v29, *([v357 @ X8_v14 (LoadScoreRequest[])+20]), v31, v32, v33, v34, v35, v36, v37);\nL_01B2:\n\tv345 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v345, v45, Il2CppMethodInfo);\n\tgoto L_01EA;\n\tv771 = *([v738 @ X8_v34+B0]);\n\tv772 = 0;\n\tv773 = v771 + 8;\n\tv775 = *([v833 @ X11_v11-8]);\n\tv838 = v775 == v739;\n\tif (v838) goto L_01E2;\n\tv795 = v832 + 1;\n\tv853 = v795 < v740;\n\tv793 = ~v853;\n\tv797 = v833 + 0x10;\n\tv777 = ~v793;\n\tif (v777) goto L_FFFFFFFF;\n\tv798 = v127;\n\tv799 = 0;\n\tv800 = 0x8909C4(v798, v739, v799, v69, v26, v27, v28, v29, v118, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_01EA;\nL_01E2:\n\tv854 = *([v833 @ X11_v11]);\n\tv855 = v854 << 4;\n\tv856 = v738 + v855;\n\tv857 = v856 + 0x130;\nL_01EA:\n\tUnityEngine.SocialPlatforms.ILeaderboard::LoadScores(v45.ldb, v345\n// ... truncated")]
		private static void DoNextLoadScoreRequest()
		{
			//IL_00b0: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_0101: Expected I, but got O
			//IL_013c: Expected O, but got I
			//IL_01f7: Expected I, but got O
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01db: Expected O, but got I
			//IL_01ea: Expected O, but got I
			//IL_02fc: Expected I, but got O
			//IL_0188: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_0337: Expected O, but got I
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Expected O, but got Unknown
			//IL_02df: Expected O, but got I
			//IL_02ee: Expected O, but got I
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Expected O, but got Unknown
			//IL_03d6: Expected O, but got I
			//IL_03e5: Expected O, but got I
			//IL_027e: Expected O, but got I
			//IL_0383: Expected O, but got I
			//IL_0427: Expected O, but got I4
			//IL_043e: Expected I, but got O
			//IL_0479: Expected O, but got I
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fb: Expected O, but got Unknown
			//IL_0518: Expected O, but got I
			//IL_0527: Expected O, but got I
			//IL_04c5: Expected O, but got I
			if (isLoadingScore)
			{
				return;
			}
			List<LoadScoreRequest> list = loadScoreRequests;
			if (list.Count == 0)
			{
				return;
			}
			isLoadingScore = true;
			List<LoadScoreRequest> list2 = loadScoreRequests;
			if (list2.Count == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			LoadScoreRequest[] items = list2._items;
			LoadScoreRequest request = default(LoadScoreRequest);
			ref LoadScoreRequest reference = ref request;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X8_v14 (LoadScoreRequest[])+40]");
			reference.timeScope = TimeScope.Today;
			ref LoadScoreRequest reference2 = ref request;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X8_v14 (LoadScoreRequest[])+30]");
			reference2.leaderboardId = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X8_v14 (LoadScoreRequest[])+20]");
			request = (LoadScoreRequest)0;
			loadScoreRequests.RemoveAt(0);
			ILeaderboard ldb;
			IntPtr intPtr = (IntPtr)(ldb = Social.CreateLeaderboard());
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01a1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X11_v38-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X8_v19 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_01a1;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_05aa;
			IL_06d6:
			Action<bool> callback = delegate
			{
				//IL_002a: Expected I, but got O
				//IL_011d: Expected I, but got O
				//IL_0065: Expected O, but got I
				//IL_0158: Expected O, but got I
				//IL_01de: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e3: Expected O, but got Unknown
				//IL_0200: Expected O, but got I
				//IL_020f: Expected O, but got I
				//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_02dc: Expected O, but got Unknown
				//IL_02f9: Expected O, but got I
				//IL_0308: Expected O, but got I
				//IL_00b1: Expected O, but got I
				//IL_01a4: Expected O, but got I
				IScore[] array;
				if (request.loadLocalUserScore)
				{
					array = new IScore[1];
					ILeaderboard leaderboard4 = ldb;
					IntPtr intPtr5 = (IntPtr)leaderboard4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X8_v21 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00ca;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X8_v21 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
					object obj18 = 0L + 8L;
					int num14 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ X11_v16-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
						{
							break;
						}
						num14++;
						int num15 = num14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X8_v21 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
						bool flag9 = (long)num15 < 0L;
						bool flag10 = !flag9;
						obj18 = (long)(IntPtr)obj18 + 16L;
						if (!flag10)
						{
							continue;
						}
						goto IL_00ca;
					}
					object obj19 = obj18 + 6;
					int num16 = (int)((long)(IntPtr)obj19 << 4);
					object obj20 = (long)intPtr5 + (long)num16;
					object obj21 = (long)(IntPtr)obj20 + 304L;
					goto IL_036f;
				}
				if (request.callback != null)
				{
					ILeaderboard leaderboard5 = ldb;
					IntPtr intPtr6 = (IntPtr)leaderboard5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X8_v13 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01bd;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X8_v13 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
					object obj22 = 0L + 8L;
					int num17 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X11_v10-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
						{
							break;
						}
						num17++;
						int num18 = num17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X8_v13 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
						bool flag11 = (long)num18 < 0L;
						bool flag12 = !flag11;
						obj22 = (long)(IntPtr)obj22 + 16L;
						if (!flag12)
						{
							continue;
						}
						goto IL_01bd;
					}
					object obj23 = obj22 + 7;
					int num19 = (int)((long)(IntPtr)obj23 << 4);
					object obj24 = (long)intPtr6 + (long)num19;
					object obj25 = (long)(IntPtr)obj24 + 304L;
					goto IL_03a8;
				}
				goto IL_03f2;
				IL_03a8:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v405 @ X0_v16] (should have been resolved before IL gen)");
				object obj27 = default(object);
				object obj26 = obj27;
				string leaderboardName = request.leaderboardName;
				Action<string, IScore[]> callback3 = request.callback;
				IntPtr intPtr7 = (IntPtr)0;
				goto IL_03e3;
				IL_01bd:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				IntPtr intPtr8 = (IntPtr)7;
				goto IL_03a8;
				IL_036f:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v374 @ X0_v25] (should have been resolved before IL gen)");
				object obj28 = default(object);
				if (obj28 != null)
				{
					object obj29 = array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				array[0] = (IScore)obj28;
				callback3 = request.callback;
				if (request.callback != null)
				{
					leaderboardName = request.leaderboardName;
					obj26 = array;
					intPtr7 = (IntPtr)0;
					goto IL_03e3;
				}
				goto IL_03f2;
				IL_00ca:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				intPtr8 = (IntPtr)6;
				goto IL_036f;
				IL_03e3:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @11F85A8 (System.Action`2<EasyMobile.AnimatedClip, System.String>::Invoke, and 13 more at this address)");
				goto IL_03f2;
				IL_03f2:
				isLoadingScore = false;
				DoNextLoadScoreRequest();
			};
			ldb.LoadScores(callback);
			return;
			IL_04de:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0719;
			IL_0719:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v850 @ X0_v36] (should have been resolved before IL gen)");
			goto IL_06d6;
			IL_061d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v582 @ X0_v48] (should have been resolved before IL gen)");
			Action<IScore[]> callback2 = delegate(IScore[] scores)
			{
				if (request.callback != null)
				{
					request.callback(request.leaderboardName, scores);
				}
				isLoadingScore = false;
				DoNextLoadScoreRequest();
			};
			string leaderboardID = default(string);
			Social.LoadScores(leaderboardID, callback2);
			return;
			IL_039c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_06a5;
			IL_06a5:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v680 @ X0_v22] (should have been resolved before IL gen)");
			if (request.fromRank < 1 || request.scoreCount < 1)
			{
				goto IL_06d6;
			}
			ILeaderboard leaderboard = ldb;
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16565D0 (inside UnityEngine.SocialPlatforms.Impl.Leaderboard::.ctor +0xDC)");
			IntPtr intPtr2 = (IntPtr)leaderboard;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_04de;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
			object obj6 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ X11_v17-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ X8_v39 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_04de;
			}
			object obj7 = obj6 + 4;
			int num6 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr2 + (long)num6;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_0719;
			IL_0297:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num7 = 1;
			goto IL_061d;
			IL_01a1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_05aa;
			IL_05aa:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v16+8]");
			num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v460 @ X0_v16] (should have been resolved before IL gen)");
			ILeaderboard leaderboard2 = ldb;
			if ((object)request != null)
			{
				IntPtr intPtr3 = (IntPtr)leaderboard2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0297;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
				object obj10 = 0L + 8L;
				int num8 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X11_v33-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
					{
						break;
					}
					num8++;
					int num9 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X8_v45 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
					bool flag5 = (long)num9 < 0L;
					bool flag6 = !flag5;
					obj10 = (long)(IntPtr)obj10 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_0297;
				}
				object obj11 = obj10 + 1;
				int num10 = (int)((long)(IntPtr)obj11 << 4);
				object obj12 = (long)intPtr3 + (long)num10;
				object obj13 = (long)(IntPtr)obj12 + 304L;
				goto IL_061d;
			}
			ldb.timeScope = request.timeScope;
			ILeaderboard leaderboard3 = ldb;
			IntPtr intPtr4 = (IntPtr)leaderboard3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_039c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+B0]");
			object obj14 = 0L + 8L;
			int num11 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ X11_v22-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILeaderboard))
				{
					break;
				}
				num11++;
				int num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X8_v26 (Il2CppClass<UnityEngine.SocialPlatforms.ILeaderboard>)+126]");
				bool flag7 = (long)num12 < 0L;
				bool flag8 = !flag7;
				obj14 = (long)(IntPtr)obj14 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_039c;
			}
			object obj15 = obj14 + 3;
			int num13 = (int)((long)(IntPtr)obj15 << 4);
			object obj16 = (long)intPtr4 + (long)num13;
			object obj17 = (long)(IntPtr)obj16 + 304L;
			goto IL_06a5;
		}

		[Token(Token = "0x600037D")]
		[Address(RVA = "0xA59030", Offset = "0xA59030", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F09DC0]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FD0]) = v38;\nL_0018:\n\tv44 = success == 0;\n\tif (v44) goto L_0048;\n\tgoto L_0025;\n\tv49 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0025;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv53 = EasyMobile.GameServices;\nL_0025:\n\tv58 = v56.UserLoginSucceeded == 0;\n\tif (v58) goto L_003D;\n\tgoto L_0037;\n\tv97 = *([v52 @ X0_v12 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0037;\n\tv139 = EasyMobile.GameServices;\n\tv140 = *([v139 @ X8_v20 (Il2CppClass<EasyMobile.GameServices>)+B8]);\n\tv103 = v140.UserLoginSucceeded;\nL_0037:\n\tSystem.Action::Invoke(v56.UserLoginSucceeded);\nL_003D:\n\tEasyMobile.Internal.StorageUtil::SetInt(\"SGLIB_ANDROID_LOGIN_REQUEST_NUMBER\", 0);\n\tEasyMobile.Internal.StorageUtil::Save();\n\treturn;\nL_0048:\n\tgoto L_0051;\n\tv59 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0051;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = EasyMobile.GameServices;\nL_0051:\n\tv68 = v66.UserLoginFailed == 0;\n\tif (v68) goto L_006F;\n\tgoto L_0068;\n\tv109 = *([v62 @ X0_v6 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0068;\n\tv141 = EasyMobile.GameServices;\n\tv142 = *([v141 @ X8_v9 (Il2CppClass<EasyMobile.GameServices>)+B8]);\n\tv118 = v142.UserLoginFailed;\nL_0068:\n\tSystem.Action::Invoke(v66.UserLoginFailed);\n\treturn;\nL_006F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ProcessAuthentication(bool success)
		{
			if (success)
			{
				if (GameServices.UserLoginSucceeded != null)
				{
					GameServices.UserLoginSucceeded();
				}
				StorageUtil.SetInt("SGLIB_ANDROID_LOGIN_REQUEST_NUMBER", 0);
				StorageUtil.Save();
			}
			else if (GameServices.UserLoginFailed != null)
			{
				GameServices.UserLoginFailed();
			}
		}

		[Token(Token = "0x600037E")]
		[Address(RVA = "0xA5915C", Offset = "0xA5915C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBBE88]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FD1]) = v38;\nL_0015:\n\tv40 = achievements.Length;\n\tv41 = achievements.Length == 0;\n\tif (v41) goto L_0045;\n\t// 29 Box v49 @ X0_v9 (System.Object), typeof(System.Int32), &v40 @ X8_v3\n\tv65 = System.String::Concat(\"Got \", v49, \" achievements.\");\n\tgoto L_0038;\n\tv110 = *([v99 @ X8_v16+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0038;\n\tv115 = v99;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v115, v60, v63, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0038:\n\tUnityEngine.Debug::Log(v65);\n\treturn;\nL_0045:\n\tgoto L_0054;\n\tv66 = *([v52 @ X0_v4+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0054;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0054:\n\tUnityEngine.Debug::Log(\"No achievements found.\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ProcessLoadedAchievements(IAchievement[] achievements)
		{
			//IL_000f: Expected O, but got I4
			//IL_0037: Expected I4, but got O
			object obj = achievements.Length;
			if (achievements.Length != 0)
			{
				object obj2 = (int)obj;
				string message = string.Concat("Got ", obj2, " achievements.");
				Debug.Log(message);
			}
			else
			{
				Debug.Log("No achievements found.");
			}
		}

		[Token(Token = "0x6000382")]
		[Address(RVA = "0xA59504", Offset = "0xA59504", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB36F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FD5]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.GameServices>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.GameServices;\nL_0021:\n\tv52.sInvitationDelegate = invitationDelegate;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterInvitationDelegate(InvitationReceivedDelegate invitationDelegate)
		{
			sInvitationDelegate = invitationDelegate;
		}

		[Token(Token = "0x6000383")]
		[Address(RVA = "0xA59328", Offset = "0xA59328", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC2CE0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD6]) = v35;\nL_0014:\n\tv39 = new EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient();\n\tEasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ITurnBasedMultiplayerClient GetTurnBasedMultiplayerClient()
		{
			return new UnsupportedTurnBasedMultiplayerClient();
		}

		[Token(Token = "0x6000384")]
		[Address(RVA = "0xA59440", Offset = "0xA59440", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ED2070]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD7]) = v35;\nL_0014:\n\tv39 = new EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient();\n\tEasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IRealTimeMultiplayerClient GetRealTimeMultiplayerClient()
		{
			return new UnsupportedRealTimeMultiplayerClient();
		}

		[Token(Token = "0x6000386")]
		[Address(RVA = "0xA5962C", Offset = "0xA5962C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EF2C80]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FD9]) = v35;\nL_0011:\n\tv36 = EasyMobile.EM_Settings::get_GameServices();\n\tv39 = ~v36.mEnableSavedGames;\n\tif (v39) goto L_0022;\n\tv44 = new EasyMobile.Internal.GameServices.AndroidSavedGameClient();\n\tEasyMobile.Internal.GameServices.AndroidSavedGameClient::.ctor(v44);\n\tgoto L_002E;\nL_0022:\n\tv48 = new EasyMobile.Internal.GameServices.UnsupportedSavedGameClient();\n\tEasyMobile.Internal.GameServices.UnsupportedSavedGameClient::.ctor(v48, \"Please enable Saved Game feature in the Game Services module settings first.\");\nL_002E:\n\treturn v72;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ISavedGameClient GetSavedGameClient()
		{
			GameServicesSettings gameServices = EM_Settings.GameServices;
			if (gameServices.IsSavedGamesEnabled)
			{
				return new AndroidSavedGameClient();
			}
			return new UnsupportedSavedGameClient("Please enable Saved Game feature in the Game Services module settings first.");
		}

		[Token(Token = "0x6000387")]
		[Address(RVA = "0xA596C8", Offset = "0xA596C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameServices()
		{
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0xA596D0", Offset = "0xA596D0", Length = "0x1158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EB9608]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021FDA]) = v37;\nL_0016:\n\tv41.isLoadingScore = 0;\n\tv45 = new System.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>();\n\tSystem.Collections.Generic.List`1<EasyMobile.GameServices+LoadScoreRequest>::.ctor(v45);\n\tv51.loadScoreRequests = v45;\n\treturn;\n\tgoto L_042C;\n\tX0 = *([X8]);\n\tX0 = 0xA3F004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xA4D004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xA48008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\nL_042C:\n\tX0 = *([X0]);\n\tX1 = 0;\n\tX0 = System.IntPtr::op_Explicit(X0, X1);\n\treturn;\n\t// 1072 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = X1;\n\tX1 = 0;\n\tX0 = System.IntPtr::op_Explicit(X0, X1);\n\t*([X19]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 1085 ShiftStack 32\n\treturn;\n\t*([X0+8]) = X1;\n\treturn;\n\t// 1089 ShiftStack -64\n\tstack[0] = X23;\n\tstack[10] = X22;\n\tstack[18] = X21;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX8 = *([2021FE3]);\n\tX19 = X3;\n\tX20 = X2;\n\tX22 = X1;\n\tX21 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_045A;\n\tX8 = *([1EBE8E8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2021FE3]) = X8;\nL_045A:\n\tX8 = 0x1EA8000;\n\tX8 = *([1EA8C18]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0466;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0466;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0466:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.UIntPtr::op_Explicit(X0, X1);\n\tX1 = 0;\n\tX0 = System.UIntPtr::op_Explicit(X0, X1);\n\t*([X21]) = X0;\n\t*([X21+8]) = X20;\n\t*([X21+C]) = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX23 = stack[0];\n\t// 1141 ShiftStack 64\n\treturn;\n// 1052 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static GameServices()
		{
			List<LoadScoreRequest> list = new List<LoadScoreRequest>();
			loadScoreRequests = list;
		}
	}
}
