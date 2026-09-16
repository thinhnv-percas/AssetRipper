using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.IOS
{
	[Token(Token = "0x2000064")]
	internal class IOSFacebook : MobileFacebook
	{
		[Token(Token = "0x2000065")]
		private class NativeDict
		{
			[Token(Token = "0x17000082")]
			public int NumEntries
			{
				[CompilerGenerated]
				[Token(Token = "0x6000278")]
				[Address(RVA = "0xD33864", Offset = "0xD33864", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<NumEntries>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return NumEntries;
				}
				[CompilerGenerated]
				[Token(Token = "0x6000279")]
				[Address(RVA = "0xD3386C", Offset = "0xD3386C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<NumEntries>k__BackingField = value;\n\treturn;\n")]
				set
				{
					NumEntries = value;
				}
			}

			[Token(Token = "0x17000083")]
			public string[] Keys
			{
				[CompilerGenerated]
				[Token(Token = "0x600027A")]
				[Address(RVA = "0xD33874", Offset = "0xD33874", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Keys>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Keys;
				}
				[CompilerGenerated]
				[Token(Token = "0x600027B")]
				[Address(RVA = "0xD3387C", Offset = "0xD3387C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Keys>k__BackingField = value;\n\treturn;\n")]
				set
				{
					Keys = value;
				}
			}

			[Token(Token = "0x17000084")]
			public string[] Values
			{
				[CompilerGenerated]
				[Token(Token = "0x600027C")]
				[Address(RVA = "0xD33884", Offset = "0xD33884", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Values>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Values;
				}
				[CompilerGenerated]
				[Token(Token = "0x600027D")]
				[Address(RVA = "0xD3388C", Offset = "0xD3388C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Values>k__BackingField = value;\n\treturn;\n")]
				set
				{
					Values = value;
				}
			}

			[Token(Token = "0x6000277")]
			[Address(RVA = "0xD33838", Offset = "0xD33838", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<NumEntries>k__BackingField = 0;\n\tthis.<Keys>k__BackingField = 0;\n\tthis.<Values>k__BackingField = 0;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public NativeDict()
			{
				NumEntries = 0;
				Keys = null;
				Values = null;
			}
		}

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x2C")]
		private bool limitEventUsage;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x30")]
		private IIOSWrapper iosWrapper;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x38")]
		private string userID;

		[Token(Token = "0x1700007F")]
		public override bool LimitEventUsage
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0xD32294", Offset = "0xD32294", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.limitEventUsage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LimitEventUsage;
			}
			[Token(Token = "0x6000262")]
			[Address(RVA = "0xD3229C", Offset = "0xD3229C", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EDF130]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C74]) = v41;\nL_0017:\n\tthis.limitEventUsage = value;\n\tgoto L_004F;\n\tv53 = *([v46 @ X8_v4+B0]);\n\tv54 = 0;\n\tv55 = v53 + 8;\n\tv57 = *([v104 @ X11_v5-8]);\n\tv110 = v57 == v49;\n\tif (v110) goto L_0040;\n\tv90 = v105 + 1;\n\tv167 = v90 < v48;\n\tv84 = ~v167;\n\tv87 = v104 + 0x10;\n\tv60 = ~v84;\n\tif (v60) goto L_FFFFFFFF;\n\tv91 = 0xB;\n\tv92 = v42;\n\tv93 = 0x8909C4(v92, v49, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004F;\nL_0040:\n\tv168 = *([v104 @ X11_v5]);\n\tv169 = v168 + 0xB;\n\tv170 = v169 << 4;\n\tv171 = v46 + v170;\n\tv172 = v171 + 0x130;\nL_004F:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::FBAppEventsSetLimitEventUsage(this.iosWrapper, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				limitEventUsage = value;
				iosWrapper.FBAppEventsSetLimitEventUsage(value);
			}
		}

		[Token(Token = "0x17000080")]
		public override string SDKName
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0xD3236C", Offset = "0xD3236C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB8A30]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C75]) = v35;\nL_0018:\n\treturn \"FBiOSSDK\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "FBiOSSDK";
			}
		}

		[Token(Token = "0x17000081")]
		public override string SDKVersion
		{
			[Token(Token = "0x6000264")]
			[Address(RVA = "0xD323B4", Offset = "0xD323B4", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE35D0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C76]) = v38;\nL_0013:\n\tv39 = this.iosWrapper;\n\tv42 = *([v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Facebook.Unity.Mobile.IOS.IIOSWrapper, 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0xE;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_014c: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				IIOSWrapper iIOSWrapper = iosWrapper;
				IntPtr intPtr = (IntPtr)iIOSWrapper;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 14;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0134;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0134;
				IL_0134:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0xD3212C", Offset = "0xD3212C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0FA10]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C73]) = v40;\nL_0014:\n\tv41 = Facebook.Unity.Mobile.IOS.IOSFacebook::GetIOSWrapper();\n\tv47 = new Facebook.Unity.CallbackManager();\n\tFacebook.Unity.CallbackManager::.ctor(v47);\n\tSystem.Object::.ctor(v38);\n\tv38.<CallbackManager>k__BackingField = v47;\n\tv38.iosWrapper = v41;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IOSFacebook()
		{
			IIOSWrapper iOSWrapper = GetIOSWrapper();
			CallbackManager callbackManager = new CallbackManager();
			CallbackManager = callbackManager;
			iosWrapper = iOSWrapper;
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0xD32258", Offset = "0xD32258", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\tthis.iosWrapper = iosWrapper;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IOSFacebook(IIOSWrapper iosWrapper, CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
			this.iosWrapper = iosWrapper;
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0xD2B15C", Offset = "0xD2B15C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1EF2418]);\n\tv37 = *([v36 @ X8_v14]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, appId, frictionlessRequests, iosURLSuffix, hideUnityDelegate, onInitComplete, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023C77]) = v52;\nL_001D:\n\tv50.onInitCompleteDelegate = onInitComplete;\n\tv54 = Facebook.Unity.Constants::get_UnitySDKUserAgentSuffixLegacy();\n\tgoto L_0053;\n\tv126 = *([v58 @ X8_v4+B0]);\n\tv127 = 0;\n\tv128 = v126 + 8;\n\tv130 = *([v167 @ X11_v12-8]);\n\tv172 = v130 == v61;\n\tif (v172) goto L_0048;\n\tv150 = v166 + 1;\n\tv236 = v150 < v60;\n\tv148 = ~v236;\n\tv152 = v167 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_FFFFFFFF;\n\tv153 = v53;\n\tv154 = 0;\n\tv155 = 0x8909C4(v153, v61, v154, iosURLSuffix, hideUnityDelegate, onInitComplete, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0053;\nL_0048:\n\tv237 = *([v167 @ X11_v12]);\n\tv238 = v237 << 4;\n\tv239 = v58 + v238;\n\tv240 = v239 + 0x130;\nL_0053:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::Init(v50.iosWrapper, appId, frictionlessRequests, iosURLSuffix, v54);\n\tv121 = v50.iosWrapper;\n\tv245 = *([v121 @ X20_v3 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv219 = *([v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v219) goto L_0079;\n\tv289 = *([v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0064:\n\tv294 = *([v289 @ X11_v7-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v294) goto L_007C;\n\tv288 = v288 + 1;\n\tv299 = v288 < *([v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv270 = ~v299;\n\tv289 = v289 + 0x10;\n\tv254 = ~v270;\n\tif (v254) goto L_0064;\nL_0079:\n\tv305 = 0x8909C4(v121, Facebook.Unity.Mobile.IOS.IIOSWrapper, 0xF, iosURLSuffix, v54, 0, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0083;\nL_007C:\n\tv301 = *([v289 @ X11_v7]) + 0xF;\n\tv302 = v301 << 4;\n\tv303 = v245 + v302;\n\tv305 = v303 + 0x130;\nL_0083:\n\t*([v305 @ X0_v9])(v217, v121, *([v305 @ X0_v9+8]), 0xF, iosURLSuffix, v54, 0, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv50.userID = v217;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(string appId, bool frictionlessRequests, string iosURLSuffix, HideUnityDelegate hideUnityDelegate, InitDelegate onInitComplete)
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0099: Expected O, but got I
			onInitCompleteDelegate = onInitComplete;
			string unitySDKUserAgentSuffixLegacy = Constants.UnitySDKUserAgentSuffixLegacy;
			iosWrapper.Init(appId, frictionlessRequests, iosURLSuffix, unitySDKUserAgentSuffixLegacy);
			IIOSWrapper iIOSWrapper = iosWrapper;
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016c;
			IL_00b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016c;
			IL_016c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v305 @ X0_v9] (should have been resolved before IL gen)");
			string text = default(string);
			userID = text;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0xD3246C", Offset = "0xD3246C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EA3328]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, permissions, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C78]) = v44;\nL_0018:\n\tv46 = this.iosWrapper;\n\tv51 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, callback);\n\tv54 = Facebook.Unity.Utilities::ToCommaSeparateList(permissions);\n\tv58 = *([v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv62 = *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v62) goto L_0048;\n\tv116 = *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0033:\n\tv122 = *([v116 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v122) goto L_004B;\n\tv117 = v117 + 1;\n\tv183 = v117 < *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv96 = ~v183;\n\tv116 = v116 + 0x10;\n\tv72 = ~v96;\n\tif (v72) goto L_0033;\nL_0048:\n\tv190 = 0x8909C4(v46, Facebook.Unity.Mobile.IOS.IIOSWrapper, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004F;\nL_004B:\n\tv185 = *([v116 @ X11_v5]) + 1;\n\tv186 = v185 << 4;\n\tv187 = v58 + v186;\n\tv190 = v187 + 0x130;\nL_004F:\n\tv132 = *([v190 @ X0_v8]);\n\tv130 = *([v190 @ X0_v8+8]);\n\t// 91 IndirectJump v132 @ X4_v1, v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v51 @ X0_v3 (System.Int32), v54 @ X0_v5 (System.String), v130 @ X3_v1, v132 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithReadPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_0167: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			int num = AddCallback(callback);
			string text = permissions.ToCommaSeparateList();
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
			IL_014f:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v132 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0xD32564", Offset = "0xD32564", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EF4C48]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, permissions, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C79]) = v44;\nL_0018:\n\tv46 = this.iosWrapper;\n\tv51 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, callback);\n\tv54 = Facebook.Unity.Utilities::ToCommaSeparateList(permissions);\n\tv58 = *([v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv62 = *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v62) goto L_0048;\n\tv116 = *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0033:\n\tv122 = *([v116 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v122) goto L_004B;\n\tv117 = v117 + 1;\n\tv183 = v117 < *([v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv96 = ~v183;\n\tv116 = v116 + 0x10;\n\tv72 = ~v96;\n\tif (v72) goto L_0033;\nL_0048:\n\tv190 = 0x8909C4(v46, Facebook.Unity.Mobile.IOS.IIOSWrapper, 2, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004F;\nL_004B:\n\tv185 = *([v116 @ X11_v5]) + 2;\n\tv186 = v185 << 4;\n\tv187 = v58 + v186;\n\tv190 = v187 + 0x130;\nL_004F:\n\tv132 = *([v190 @ X0_v8]);\n\tv130 = *([v190 @ X0_v8+8]);\n\t// 91 IndirectJump v132 @ X4_v1, v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v46 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v51 @ X0_v3 (System.Int32), v54 @ X0_v5 (System.String), v130 @ X3_v1, v132 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithPublishPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_0167: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			int num = AddCallback(callback);
			string text = permissions.ToCommaSeparateList();
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
			IL_014f:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v132 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0xD3265C", Offset = "0xD3265C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB16F8]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C7A]) = v38;\nL_0017:\n\tgoto L_0022;\n\tv44 = *([1ED9370]);\n\tv45 = *([v44 @ X8_v14]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = 0 | 1;\n\t*([2023CAB]) = v49;\nL_0022:\n\tv53.<CurrentAccessToken>k__BackingField = 0;\n\tv54 = this.iosWrapper;\n\tv57 = *([v54 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv61 = *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v61) goto L_004A;\n\tv115 = *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0035:\n\tv121 = *([v115 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v121) goto L_004D;\n\tv116 = v116 + 1;\n\tv174 = v116 < *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv95 = ~v174;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0035;\nL_004A:\n\tv181 = 0x8909C4(v54, Facebook.Unity.Mobile.IOS.IIOSWrapper, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0051;\nL_004D:\n\tv176 = *([v115 @ X11_v5]) + 3;\n\tv177 = v176 << 4;\n\tv178 = v57 + v177;\n\tv181 = v178 + 0x130;\nL_0051:\n\tv134 = *([v181 @ X0_v5]);\n\tv156 = *([v181 @ X0_v5+8]);\n\t// 89 IndirectJump v134 @ X2_v2, v54 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v54 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v156 @ X1_v2, v134 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogOut()
		{
			//IL_000d: Expected I, but got O
			//IL_0142: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			object obj4 = default(object);
			while (true)
			{
				AccessToken.CurrentAccessToken = null;
				IIOSWrapper iIOSWrapper = iosWrapper;
				IntPtr intPtr = (IntPtr)iIOSWrapper;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00ad;
					}
					object obj2 = obj + 3;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_012a;
				}
				goto IL_00ad;
				IL_012a:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X0_v5+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v134 @ X2_v2 (should have been resolved before IL gen)");
				continue;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_012a;
			}
		}

		[Token(Token = "0x6000269")]
		[Address(RVA = "0xD3274C", Offset = "0xD3274C", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\t*([v24 @ X29_v1-58]) = actionType;\n\tgoto L_0028;\n\tv49 = *([1EBD8D0]);\n\tv50 = *([v49 @ X8_v58]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2023C7B]) = v62;\nL_0028:\n\tFacebook.Unity.FacebookBase::ValidateAppRequestArgs(this, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v67, v68, v69);\n\tv72 = filters == 0;\n\tif (v72) goto L_0051;\n\tv77 = System.Linq.Enumerable::Any(filters);\n\tv131 = v77 == 0;\n\tif (v131) goto L_FFFFFFFF;\n\tv113 = System.Linq.Enumerable::First(filters);\n\tv116 = v113 == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tv80 = *([v113 @ X0_v41 (System.Object)]) != System.String;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0051;\nL_0051:\n\tv124 = this.iosWrapper;\n\tv129 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, *([v24 @ X29_v1+20]));\n\tv132 = actionType & 0xFF00000000;\n\tv134 = v132 == 0;\n\tif (v134) goto L_0088;\n\tv140 = &v25 @ stack_-10_v2 - 0x58;\n\tv142 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(v140, Il2CppMethodInfo);\n\tv152 = objectId == 0;\n\tif (v152) goto L_008F;\nL_0063:\n\tv170 = to == 0;\n\tif (v170) goto L_0094;\nL_0069:\n\tv193 = System.Linq.Enumerable::ToArray(to);\n\tv202 = System.Linq.Enumerable::Count(to);\n\tv204 = v245 == 0;\n\tif (v204) goto L_009C;\nL_0073:\n\tv225 = excludeIds == 0;\n\tif (v225) goto L_00A1;\nL_0079:\n\tv251 = System.Linq.Enumerable::ToArray(excludeIds);\n\tv259 = System.Linq.Enumerable::Count(excludeIds);\n\tgoto L_00A1;\nL_0088:\n\tv149 = objectId == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0063;\nL_008F:\n\tv243 = v161.Empty;\n\tv163 = to == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_0069;\nL_0094:\n\tv181 = v245 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0073;\nL_009C:\n\tv215 = excludeIds == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0079;\nL_00A1:\n\tv270 = v269 == 0;\n\tif (v270) goto L_00D6;\n\tv277 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(&maxRecipients @ X7 (System.Nullable`1<System.Int32>), Il2CppMethodInfo);\nL_00AD:\n\tv300 = *([v124 @ X22_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv306 = *([v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v306) goto L_00D2;\n\tv313 = *([v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_00B8:\n\t;\n\tv328 = *([v313 @ X11_v2-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v328) goto L_00DC;\n\tv318 = v318 + 1;\n\tv442 = v318 < *([v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv374 = ~v442;\n\tv313 = v313 + 0x10;\n\tv354 = ~v374;\n\tif (v354) goto L_00B8;\nL_00D2:\n\tv395 = 0x8909C4(this.iosWrapper, Facebook.Unity.Mobile.IOS.IIOSWrapper, 7, objectId, to, filters, excludeIds, maxRecipients, v52, v53, v54, v55, v56, v57, v58, v59);\n\tgoto L_00F1;\nL_00D6:\n\tv280 = this.iosWrapper == 0;\n\tv281 = ~v280;\n\tif (v281) goto L_00AD;\n\tthrow System.NullReferenceException;\nL_00DC:\n\tv345 = *([v313 @ X11_v2]) + 7;\n\tv346 = v345 << 4;\n\tv347 = v300 + v346;\n\tv395 = v347 + 0x130;\nL_00F1:\n\t*([v395 @ X0_v6])(v419, this.iosWrapper, v129, message, v255, v261, v254, v262, v263, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\n// 174 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback)
		{
			//IL_04ff: Expected O, but got I
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Expected I4, but got Unknown
			//IL_0251: Expected I4, but got O
			//IL_025a: Expected I4, but got O
			//IL_00c0: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_017f: Expected O, but got I4
			//IL_018f: Expected O, but got I4
			//IL_0372: Expected I, but got O
			//IL_0361: Expected O, but got I
			//IL_03ad: Expected O, but got I
			//IL_045a: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Expected O, but got Unknown
			//IL_047c: Expected O, but got I
			//IL_048b: Expected O, but got I
			//IL_03f9: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			string data2 = default(string);
			string title2 = default(string);
			FacebookDelegate<IAppRequestResult> callback2 = default(FacebookDelegate<IAppRequestResult>);
			ValidateAppRequestArgs(message, actionType, objectId, to, filters, excludeIds, maxRecipients, data2, title2, callback2);
			bool flag = filters == null;
			IEnumerable<object> enumerable = filters;
			if (!flag)
			{
				if (filters.Any())
				{
					object obj3 = filters.First();
					if (obj3 != null)
					{
						object obj4 = (((object)obj3.GetType() != typeof(string)) ? null : obj3);
						enumerable = (IEnumerable<object>)obj4;
						goto IL_04e3;
					}
				}
				enumerable = null;
			}
			goto IL_04e3;
			IL_053f:
			IntPtr intPtr = default(IntPtr);
			if (intPtr != (IntPtr)0)
			{
				int num = ((IOSFacebook)maxRecipients).AddCallback((FacebookDelegate<IAppRequestResult>)0);
			}
			else if (iosWrapper == null)
			{
				throw new NullReferenceException();
			}
			IIOSWrapper iIOSWrapper;
			IntPtr intPtr2 = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0412;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj5 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X11_v2-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ X8_v15 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag2 = (long)num3 < 0L;
				bool flag3 = !flag2;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_0412;
			}
			object obj6 = obj5 + 7;
			int num4 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num4;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0587;
			IL_02aa:
			bool flag4 = enumerable == null;
			bool flag5 = !flag4;
			string[] array = null;
			object obj9 = to;
			string[] array2 = null;
			int num6;
			int num5 = num6;
			string text2;
			string text = text2;
			object obj10 = to;
			if (flag5)
			{
				goto IL_019d;
			}
			goto IL_02fc;
			IL_00fc:
			bool flag6 = to == null;
			text = objectId;
			num6 = num5;
			text2 = objectId;
			if (!flag6)
			{
				goto IL_0131;
			}
			goto IL_02aa;
			IL_0131:
			string[] array3 = to.ToArray();
			int num7 = to.Count();
			bool flag7 = enumerable == null;
			array = array3;
			num6 = num5;
			text2 = text;
			obj9 = num7;
			array2 = array3;
			obj10 = num7;
			if (!flag7)
			{
				goto IL_019d;
			}
			goto IL_02fc;
			IL_01e2:
			string[] array4 = excludeIds.ToArray();
			int num8 = excludeIds.Count();
			array = array2;
			num6 = num5;
			text2 = text;
			obj9 = obj10;
			IEnumerable<object> enumerable2 = enumerable;
			goto IL_053f;
			IL_019d:
			bool flag8 = excludeIds == null;
			array2 = array;
			num5 = num6;
			text = text2;
			obj10 = obj9;
			enumerable2 = enumerable;
			if (!flag8)
			{
				goto IL_01e2;
			}
			goto IL_053f;
			IL_02fc:
			bool flag9 = excludeIds == null;
			bool flag10 = !flag9;
			enumerable = (IEnumerable<object>)(object)string.Empty;
			array = array2;
			num6 = num5;
			text2 = text;
			obj9 = obj10;
			enumerable2 = (IEnumerable<object>)(object)string.Empty;
			if (flag10)
			{
				goto IL_01e2;
			}
			goto IL_053f;
			IL_04e3:
			iIOSWrapper = iosWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			int num9 = AddCallback((FacebookDelegate<IAppRequestResult>)0);
			if ((int)((_003F?)actionType & 0xFF00000000L) != 0)
			{
				IOSFacebook iOSFacebook = (IOSFacebook)((long)(IntPtr)obj2 - 88L);
				int num10 = iOSFacebook.AddCallback((FacebookDelegate<IAppRequestResult>)0);
				bool flag11 = objectId == null;
				num5 = num10;
				num6 = num10;
				if (!flag11)
				{
					goto IL_00fc;
				}
			}
			else
			{
				bool flag12 = objectId == null;
				bool flag13 = !flag12;
				num5 = (int)string.Empty;
				num6 = (int)string.Empty;
				if (flag13)
				{
					goto IL_00fc;
				}
			}
			text = string.Empty;
			bool flag14 = to == null;
			bool flag15 = !flag14;
			num5 = num6;
			text2 = string.Empty;
			if (flag15)
			{
				goto IL_0131;
			}
			goto IL_02aa;
			IL_0587:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v395 @ X0_v6] (should have been resolved before IL gen)");
			return;
			IL_0412:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0587;
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0xD32A2C", Offset = "0xD32A2C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F001D8]);\n\tv39 = *([v38 @ X8_v10]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, contentURL, contentTitle, contentDescription, photoURL, callback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023C7C]) = v53;\nL_0023:\n\tv60 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, callback);\n\tv63 = Facebook.Unity.Utilities::AbsoluteUrlOrEmptyString(contentURL);\n\tv66 = Facebook.Unity.Utilities::AbsoluteUrlOrEmptyString(photoURL);\n\tgoto L_006A;\n\tv77 = *([v70 @ X8_v5+B0]);\n\tv78 = 0;\n\tv79 = v77 + 8;\n\tv81 = *([v128 @ X11_v5-8]);\n\tv134 = v81 == v73;\n\tif (v134) goto L_0053;\n\tv114 = v129 + 1;\n\tv207 = v114 < v72;\n\tv108 = ~v207;\n\tv111 = v128 + 0x10;\n\tv84 = ~v108;\n\tif (v84) goto L_FFFFFFFF;\n\tv115 = 5;\n\tv116 = v55;\n\tv117 = 0x8909C4(v116, v73, v115, contentDescription, photoURL, callback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_006A;\nL_0053:\n\tv208 = *([v128 @ X11_v5]);\n\tv209 = v208 + 5;\n\tv210 = v209 << 4;\n\tv211 = v70 + v210;\n\tv212 = v211 + 0x130;\nL_006A:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::ShareLink(this.iosWrapper, v60, v63, contentTitle, contentDescription, v66);\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback)
		{
			int requestId = AddCallback(callback);
			string contentURL2 = contentURL.AbsoluteUrlOrEmptyString();
			string photoURL2 = photoURL.AbsoluteUrlOrEmptyString();
			iosWrapper.ShareLink(requestId, contentURL2, contentTitle, contentDescription, photoURL2);
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xD32C00", Offset = "0xD32C00", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0029;\n\tv49 = *([1EDF250]);\n\tv50 = *([v49 @ X8_v30]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2023C7D]) = v62;\nL_0029:\n\tgoto L_0032;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0032;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0032:\n\tv79 = System.Uri::op_Inequality(link, 0);\n\tv81 = v79 == 0;\n\tif (v81) goto L_0043;\n\tv92 = System.Uri::ToString(link);\n\tgoto L_0048;\nL_0043:\n\tv111 = v86.Empty;\nL_0048:\n\tgoto L_0051;\n\tv131 = *([v127 @ X0_v7+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0051;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v123, v78, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0051:\n\tv105 = System.Uri::op_Inequality(picture, 0);\n\tv224 = v105 == 0;\n\tif (v224) goto L_0062;\n\tv234 = System.Uri::ToString(picture);\n\tgoto L_0064;\nL_0062:\n\tv113 = v228.Empty;\nL_0064:\n\tv120 = this.iosWrapper;\n\tv106 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, *([v24 @ X29_v1+10]));\n\tv243 = *([v120 @ X28_v4 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv198 = *([v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v198) goto L_0091;\n\tv287 = *([v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_007C:\n\tv293 = *([v287 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v293) goto L_0094;\n\tv288 = v288 + 1;\n\tv298 = v288 < *([v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv269 = ~v298;\n\tv287 = v287 + 0x10;\n\tv253 = ~v269;\n\tif (v253) goto L_007C;\nL_0091:\n\tv306 = 0x8909C4(v120, Facebook.Unity.Mobile.IOS.IIOSWrapper, 6, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\n\tgoto L_0098;\nL_0094:\n\tv300 = *([v287 @ X11_v5]) + 6;\n\tv301 = v300 << 4;\n\tv302 = v243 + v301;\n\tv306 = v302 + 0x130;\nL_0098:\n\tv190 = *([v306 @ X0_v14]);\n\t*([v24 @ X29_v1+10]) = mediaSource;\n\t*([v24 @ X29_v1+18]) = *([v306 @ X0_v14+8]);\n\t// 177 IndirectJump v190 @ X9_v5, v120 @ X28_v4 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v120 @ X28_v4 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v106 @ X0_v13 (System.Int32), toId @ X1 (System.String), v111 @ X24_v2 (System.String), linkName @ X3 (System.String), linkCaption @ X4 (System.String), linkDescription @ X5 (System.String), v113 @ X27_v2 (System.String), v52 @ V0, v53 @ V1, v54 @ V2, v55 @ V3, v56 @ V4, v57 @ V5, v58 @ V6, v59 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback)
		{
			//IL_01bf: Expected O, but got I
			//IL_00ab: Expected I, but got O
			//IL_00e6: Expected O, but got I
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Expected O, but got Unknown
			//IL_0185: Expected O, but got I
			//IL_0194: Expected O, but got I
			//IL_0132: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			if (link != null)
			{
				string text = link.ToString();
			}
			else
			{
				string empty = string.Empty;
			}
			if (picture != null)
			{
				string text2 = picture.ToString();
			}
			else
			{
				string empty2 = string.Empty;
			}
			IIOSWrapper iIOSWrapper = iosWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			int num = AddCallback((FacebookDelegate<IShareResult>)0);
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_014b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj3 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X8_v11 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_014b;
			}
			object obj4 = obj3 + 6;
			int num4 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr + (long)num4;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_01f2;
			IL_014b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01f2;
			IL_01f2:
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X0_v14+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v190 @ X9_v5 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xD32DF4", Offset = "0xD32DF4", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv33 = *([1EC0918]);\n\tv34 = *([v33 @ X8_v16]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, logEvent, valueToSum, parameters, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023C7E]) = v50;\nL_001C:\n\tv52 = Facebook.Unity.Mobile.IOS.IOSFacebook::MarshallDict(parameters);\n\tv54 = valueToSum & 0xFF00000000;\n\tv56 = v54 == 0;\n\tif (v56) goto L_0062;\n\tv61 = 0x115CAB0(&valueToSum @ X2 (System.Nullable`1<System.Single>), Il2CppMethodInfo, valueToSum, parameters, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_008F;\n\tv228 = *([v83 @ X8_v10+B0]);\n\tv229 = 0;\n\tv230 = v228 + 8;\n\tv232 = *([v289 @ X11_v11-8]);\n\tv295 = v232 == v89;\n\tif (v295) goto L_0082;\n\tv254 = v290 + 1;\n\tv308 = v254 < v88;\n\tv250 = ~v308;\n\tv252 = v289 + 0x10;\n\tv234 = ~v250;\n\tif (v234) goto L_FFFFFFFF;\n\tv255 = 9;\n\tv256 = v53;\n\tv257 = 0x8909C4(v256, v89, v255, parameters, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_008F;\nL_0062:\n\tgoto L_00B0;\n\tv91 = *([v74 @ X8_v5+B0]);\n\tv92 = 0;\n\tv93 = v91 + 8;\n\tv95 = *([v268 @ X11_v5-8]);\n\tv274 = v95 == v79;\n\tif (v274) goto L_009A;\n\tv128 = v269 + 1;\n\tv300 = v128 < v78;\n\tv122 = ~v300;\n\tv125 = v268 + 0x10;\n\tv98 = ~v122;\n\tif (v98) goto L_FFFFFFFF;\n\tv129 = 9;\n\tv130 = v53;\n\tv131 = 0x8909C4(v130, v79, v129, parameters, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00B0;\nL_0082:\n\tv309 = *([v289 @ X11_v11]);\n\tv310 = v309 + 9;\n\tv311 = v310 << 4;\n\tv312 = v83 + v311;\n\tv313 = v312 + 0x130;\nL_008F:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::LogAppEvent(this.iosWrapper, logEvent, v40, v52.<NumEntries>k__BackingField, v52.<Keys>k__BackingField, v52.<Values>k__BackingField);\n\treturn;\nL_009A:\n\tv301 = *([v268 @ X11_v5]);\n\tv302 = v301 + 9;\n\tv303 = v302 << 4;\n\tv304 = v74 + v303;\n\tv305 = v304 + 0x130;\nL_00B0:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::LogAppEvent(this.iosWrapper, logEvent, 0d, v52.<NumEntries>k__BackingField, v52.<Keys>k__BackingField, v52.<Values>k__BackingField);\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected I4, but got Unknown
			NativeDict nativeDict = MarshallDict(parameters);
			if ((int)((_003F?)valueToSum & 0xFF00000000L) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115CAB0 (inside System.Nullable`1<System.Int64>::Unbox +0xC0)");
				double valueToSum2 = default(double);
				iosWrapper.LogAppEvent(logEvent, valueToSum2, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
			}
			else
			{
				iosWrapper.LogAppEvent(logEvent, 0.0, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
			}
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xD33280", Offset = "0xD33280", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EDCD08]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, currency, parameters, methodInfo, v36, v37, v38, v39, logPurchase, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023C7F]) = v49;\nL_001B:\n\tv51 = Facebook.Unity.Mobile.IOS.IOSFacebook::MarshallDict(parameters);\n\tgoto L_0061;\n\tv71 = *([v58 @ X8_v3+B0]);\n\tv72 = 0;\n\tv73 = v71 + 8;\n\tv75 = *([v122 @ X11_v5-8]);\n\tv128 = v75 == v64;\n\tif (v128) goto L_004B;\n\tv108 = v123 + 1;\n\tv199 = v108 < v63;\n\tv102 = ~v199;\n\tv105 = v122 + 0x10;\n\tv78 = ~v102;\n\tif (v78) goto L_FFFFFFFF;\n\tv109 = 0xA;\n\tv110 = v53;\n\tv111 = 0x8909C4(v110, v64, v109, methodInfo, v36, v37, v38, v39, logPurchase, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0061;\nL_004B:\n\tv200 = *([v122 @ X11_v5]);\n\tv201 = v200 + 0xA;\n\tv202 = v201 << 4;\n\tv203 = v58 + v202;\n\tv204 = v203 + 0x130;\nL_0061:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::LogPurchaseAppEvent(this.iosWrapper, logPurchase, currency, v51.<NumEntries>k__BackingField, v51.<Keys>k__BackingField, v51.<Values>k__BackingField);\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters)
		{
			NativeDict nativeDict = MarshallDict(parameters);
			iosWrapper.LogPurchaseAppEvent(logPurchase, currency, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xD3338C", Offset = "0xD3338C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsImplicitPurchaseLoggingEnabled()
		{
			return false;
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xD33394", Offset = "0xD33394", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECC798]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, appId, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C80]) = v38;\nL_0013:\n\tv39 = this.iosWrapper;\n\tv42 = *([v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Facebook.Unity.Mobile.IOS.IIOSWrapper, 8, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 8;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v39 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ActivateApp(string appId)
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0134;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0134;
			IL_0134:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xD3344C", Offset = "0xD3344C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EED170]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C81]) = v41;\nL_0016:\n\tv43 = this.iosWrapper;\n\tv48 = Facebook.Unity.Mobile.IOS.IOSFacebook::AddCallback(this, callback);\n\tv52 = *([v43 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv56 = *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v56) goto L_0043;\n\tv110 = *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_002E:\n\tv116 = *([v110 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v116) goto L_0046;\n\tv111 = v111 + 1;\n\tv173 = v111 < *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv90 = ~v173;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_002E;\nL_0043:\n\tv180 = 0x8909C4(v43, Facebook.Unity.Mobile.IOS.IIOSWrapper, 0x10, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv175 = *([v110 @ X11_v5]) + 0x10;\n\tv176 = v175 << 4;\n\tv177 = v52 + v176;\n\tv180 = v177 + 0x130;\nL_004A:\n\tv124 = *([v180 @ X0_v6]);\n\tv131 = *([v180 @ X0_v6+8]);\n\t// 84 IndirectJump v124 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v43 @ X19_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v48 @ X0_v3 (System.Int32), v131 @ X2_v3, v124 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_015a: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			int num = AddCallback(callback);
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 16;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0142;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0142;
			IL_0142:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xD33530", Offset = "0xD33530", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EDA0A8]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C82]) = v41;\nL_0019:\n\tv45 = this.iosWrapper;\n\tv49 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tgoto L_002E;\n\tv74 = *([v54 @ X8_v8+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_002E;\n\tv81 = v54;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v81, v47, v48, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tv65 = System.Convert::ToInt32(v49);\n\tv146 = *([v45 @ X19_v3 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv134 = *([v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v134) goto L_0056;\n\tv190 = *([v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0041:\n\tv196 = *([v190 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v196) goto L_0059;\n\tv191 = v191 + 1;\n\tv201 = v191 < *([v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv172 = ~v201;\n\tv190 = v190 + 0x10;\n\tv156 = ~v172;\n\tif (v156) goto L_0041;\nL_0056:\n\tv208 = 0x8909C4(v45, Facebook.Unity.Mobile.IOS.IIOSWrapper, 0xC, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005D;\nL_0059:\n\tv203 = *([v190 @ X11_v5]) + 0xC;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv208 = v205 + 0x130;\nL_005D:\n\tv85 = *([v208 @ X0_v11]);\n\tv128 = *([v208 @ X0_v11+8]);\n\t// 103 IndirectJump v85 @ X3_v1, v45 @ X19_v3 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v45 @ X19_v3 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v65 @ X0_v10 (System.Int32), v128 @ X2_v4, v85 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_0041: Expected I, but got O
			//IL_0171: Expected O, but got I
			//IL_007c: Expected O, but got I
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_011b: Expected O, but got I
			//IL_012a: Expected O, but got I
			//IL_00c8: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			string value = CallbackManager.AddFacebookDelegate(callback);
			int num = Convert.ToInt32(value);
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e1;
			}
			object obj2 = obj + 12;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0159;
			IL_00e1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0159;
			IL_0159:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X0_v11+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v85 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xD33650", Offset = "0xD33650", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EC2600]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C83]) = v41;\nL_001D:\n\tv49 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tgoto L_002E;\n\tv74 = *([v54 @ X8_v8+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_002E;\n\tv81 = v54;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v81, v47, v48, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tv65 = System.Convert::ToInt32(v49);\n\tgoto L_0067;\n\tv150 = *([v146 @ X8_v9+B0]);\n\tv151 = 0;\n\tv152 = v150 + 8;\n\tv154 = *([v190 @ X11_v5-8]);\n\tv196 = v154 == v149;\n\tif (v196) goto L_0058;\n\tv176 = v191 + 1;\n\tv201 = v176 < v148;\n\tv172 = ~v201;\n\tv174 = v190 + 0x10;\n\tv156 = ~v172;\n\tif (v156) goto L_FFFFFFFF;\n\tv177 = 0xD;\n\tv178 = v45;\n\tv179 = 0x8909C4(v178, v149, v177, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0058:\n\tv202 = *([v190 @ X11_v5]);\n\tv203 = v202 + 0xD;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv206 = v205 + 0x130;\nL_0067:\n\tFacebook.Unity.Mobile.IOS.IIOSWrapper::RefreshCurrentAccessToken(this.iosWrapper, v65);\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback)
		{
			string value = CallbackManager.AddFacebookDelegate(callback);
			int requestId = Convert.ToInt32(value);
			iosWrapper.RefreshCurrentAccessToken(requestId);
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xD33770", Offset = "0xD33770", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F01BE0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, mode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C84]) = v41;\nL_0015:\n\tv42 = this.iosWrapper;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.Mobile.IOS.IIOSWrapper;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.Mobile.IOS.IIOSWrapper, 4, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 4;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), v42 @ X20_v2 (Facebook.Unity.Mobile.IOS.IIOSWrapper), mode @ X1 (Facebook.Unity.ShareDialogMode), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SetShareDialogMode(ShareDialogMode mode)
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IIOSWrapper iIOSWrapper = iosWrapper;
			IntPtr intPtr = (IntPtr)iIOSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IIOSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IOS.IIOSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0134;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0134;
			IL_0134:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0xD321AC", Offset = "0xD321AC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EBD4F0]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C85]) = v37;\nL_0016:\n\tv42 = System.Reflection.Assembly::Load(\"Facebook.Unity.IOS\");\n\tv50 = System.Reflection.Assembly::GetType(v42, \"Facebook.Unity.IOS.IOSWrapper\");\n\tv52 = System.Activator::CreateInstance(v50);\n\tv55 = v52 == 0;\n\tif (v55) goto L_0032;\n\t// 42 IsInst returnVal1 @ X0_v10 (Facebook.Unity.Mobile.IOS.IIOSWrapper), typeof(Facebook.Unity.Mobile.IOS.IIOSWrapper), v52 @ X0_v9 (System.Object)\n\tv66 = returnVal1 == 0;\n\tif (v66) goto L_0036;\nL_0032:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0036:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IIOSWrapper GetIOSWrapper()
		{
			Assembly assembly = Assembly.Load("Facebook.Unity.IOS");
			Type type = assembly.GetType("Facebook.Unity.IOS.IOSWrapper");
			object obj = Activator.CreateInstance(type);
			bool flag = obj == null;
			IIOSWrapper iIOSWrapper = (IIOSWrapper)obj;
			if (!flag)
			{
				iIOSWrapper = obj as IIOSWrapper;
				if (iIOSWrapper == null)
				{
					return (IIOSWrapper)new InvalidCastException();
				}
			}
			return iIOSWrapper;
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xD32FD4", Offset = "0xD32FD4", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2023C86]) & 1;\n\tv23 = v22 == 0;\n\tv24 = ~v23;\n\tif (v24) goto L_001F;\n\treturnVal1 = 0xD34EA8(dict, methodInfo, v161, v30, v31, v32, v33, v34, v35, v86, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023C86]) = X8;\nL_001F:\n\tv50 = new Facebook.Unity.Mobile.IOS.IOSFacebook+NativeDict();\n\tSystem.Object::.ctor(v50);\n\tv50.<NumEntries>k__BackingField = 0;\n\tv50.<Keys>k__BackingField = 0;\n\tv50.<Values>k__BackingField = 0;\n\tv155 = dict == 0;\n\tif (v155) goto L_00E9;\n\tv160 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(dict);\n\tv176 = v160 < 1;\n\tif (v176) goto L_00E9;\n\tv211 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(dict);\n\t// 65 NewArr v217 @ X0_v10 (System.String[]), typeof(System.String[]), v211 @ X0_v8 (System.Int32)\n\tv218 = v50 == 0;\n\tif (v218) goto L_00C2;\n\tv50.<Keys>k__BackingField = v217;\n\tv221 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(dict);\n\t// 75 NewArr v259 @ X0_v25 (System.String[]), typeof(System.String[]), v221 @ X0_v23 (System.Int32)\n\tv50.<Values>k__BackingField = v259;\n\tv50.<NumEntries>k__BackingField = 0;\n\tv265 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(dict);\n\tgoto L_00A0;\nL_005D:\n\tv308 = v50.<Keys>k__BackingField;\n\tv275 = v50.<NumEntries>k__BackingField;\n\tv314 = v269 == 0;\n\tif (v314) goto L_006C;\n\t// 104 IsInst v320 @ X0_v60, typeof(System.String), v269 @ stack_-88 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>)\n\tv324 = v320 == 0;\n\tif (v324) goto L_00B9;\nL_006C:\n\tv327 = v50.<NumEntries>k__BackingField < v308.Length;\n\tv328 = ~v327;\n\tif (v328) goto L_00AF;\n\tv308[v275 @ X24_v11 (System.Int32)] = v269;\n\tv413 = *([v313 @ stack_-58]);\n\tv285 = v50.<Values>k__BackingField;\n\tv276 = v50.<NumEntries>k__BackingField;\n\t*([v413 @ X8_v27+160])(v416, v313, *([v413 @ X8_v27+168]), v161, v30, v31, v32, v33, v34, v269, v173, v37, v38, v39, v40, v41, v42);\n\tv424 = v416 == 0;\n\tif (v424) goto L_008E;\n\t// 138 IsInst v450 @ X0_v58, typeof(System.String), v416 @ X0_v55\n\tv451 = v450 == 0;\n\tif (v451) goto L_00BD;\nL_008E:\n\tv457 = v50.<NumEntries>k__BackingField < v285.Length;\n\tv284 = ~v457;\n\tif (v284) goto L_00B5;\n\tv285[v276 @ X23_v10 (System.Int32)] = v416;\n\tv294 = v50.<NumEntries>k__BackingField + 1;\n\tv50.<NumEntries>k__BackingField = v294;\nL_00A0:\n\tv297 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::MoveNext(&v173 @ stack_-98_v3 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv303 = v297 == 0;\n\tv201 = ~v303;\n\tif (v201) goto L_005D;\n\tv199 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v173 @ stack_-98_v3 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tgoto L_00E9;\n\tthrow System.NullReferenceException;\n\tv356 = new System.NullReferenceException();\nL_00AF:\n\tv373 = new System.IndexOutOfRangeException();\n\tthrow v373;\n\tv445 = new System.NullReferenceException();\nL_00B5:\n\tv461 = new System.IndexOutOfRangeException();\n\tthrow v461;\nL_00B9:\n\tv412 = new System.ArrayTypeMismatchException();\n\tthrow v412;\nL_00BD:\n\tv453 = new System.ArrayTypeMismatchException();\n\tthrow v453;\nL_00C2:\n\tv255 = new System.NullReferenceException();\n\tgoto L_00D2;\n\tgoto L_00D2;\n\tgoto L_00D2;\n\tgoto L_00D2;\n\tgoto L_00D2;\n\tgoto L_00D2;\nL_00D2:\n\tv100 = v211 != 1;\n\tif (v100) goto L_00EA;\n\tv271 = 0x6D2BC0(v255, v211, v161, v30, v31, v32, v33, v34, 0, v86, v37, v38, v39, v40, v41, v42);\n\tv298 = 0x6D2490(v271, v211, v161, v30, v31, v32, v33, v34, 0, v86, v37, v38, v39, v40, v41, v42);\n\tv198 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v79 @ stack_-70_v3 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv310 = *([v271 @ X0_v18]) == 0;\n\tv200 = ~v310;\n\tif (v200) goto L_00EE;\nL_00E9:\n\treturn v50;\nL_00EA:\n\tv272 = 0x6D2380(v255, v211, v161, v30, v31, v32, v33, v34, 0, v86, v37, v38, v39, v40, v41, v42);\nL_00EE:\n\treturnVal3 = new System.TypeLoadException();\n\treturn returnVal3;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static NativeDict MarshallDict(Dictionary<string, object> dict)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2023C86]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @D34EA8 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x44)");
				NativeDict result = default(NativeDict);
				return result;
			}
			NativeDict nativeDict = new NativeDict();
			nativeDict.NumEntries = 0;
			nativeDict.Keys = null;
			nativeDict.Values = null;
			if (dict != null)
			{
				int count = dict.Count;
				if (count >= 1)
				{
					int count2 = dict.Count;
					string[] keys = new string[count2];
					bool flag = nativeDict == null;
					Dictionary<string, object>.Enumerator enumerator = default(Dictionary<string, object>.Enumerator);
					if (flag)
					{
						NullReferenceException ex = new NullReferenceException();
						if (count2 == 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							enumerator.Dispose();
							object obj = default(object);
							if (obj == null)
							{
								goto IL_0364;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						}
						return (NativeDict)(object)new TypeLoadException();
					}
					nativeDict.Keys = keys;
					int count3 = dict.Count;
					string[] values = new string[count3];
					nativeDict.Values = values;
					nativeDict.NumEntries = 0;
					object enumerator2 = dict.GetEnumerator();
					Dictionary<string, object>.Enumerator enumerator3 = default(Dictionary<string, object>.Enumerator);
					Dictionary<string, object>.Enumerator enumerator4 = default(Dictionary<string, object>.Enumerator);
					object obj4 = default(object);
					object obj5 = default(object);
					while (enumerator3.MoveNext())
					{
						string[] keys2 = nativeDict.Keys;
						int numEntries = nativeDict.NumEntries;
						if ((object)enumerator4 != null)
						{
							object obj2 = enumerator4 as string;
							if (obj2 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						if (nativeDict.NumEntries < keys2.Length)
						{
							keys2[numEntries] = (string)enumerator4;
							object obj3 = obj4;
							string[] values2 = nativeDict.Values;
							int numEntries2 = nativeDict.NumEntries;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v413 @ X8_v27+160] (should have been resolved before IL gen)");
							if (obj5 != null)
							{
								object obj6 = obj5 as string;
								if (obj6 == null)
								{
									ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
									int num = 0;
									throw ex3;
								}
							}
							if (nativeDict.NumEntries < values2.Length)
							{
								values2[numEntries2] = (string)obj5;
								int numEntries3 = nativeDict.NumEntries + 1;
								nativeDict.NumEntries = numEntries3;
								continue;
							}
							IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
							throw ex4;
						}
						IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
						throw ex5;
					}
					enumerator3.Dispose();
				}
			}
			goto IL_0364;
			IL_0364:
			return nativeDict;
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0xF14964", Offset = "0xF14964", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1EFFBB0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024E53]) = v44;\nL_0020:\n\tv53 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tgoto L_0038;\n\tv64 = *([v57 @ X8_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0038;\n\tv80 = v57;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v80, v50, v51, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0038:\n\treturnVal2 = System.Convert::ToInt32(v53);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int AddCallback<T>(FacebookDelegate<T> callback) where T : IResult
		{
			string value = CallbackManager.AddFacebookDelegate(callback);
			return Convert.ToInt32(value);
		}
	}
}
