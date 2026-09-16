using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.Unity.Canvas;
using Facebook.Unity.Editor;
using Facebook.Unity.Gameroom;
using Facebook.Unity.Mobile;
using Facebook.Unity.Mobile.Android;
using Facebook.Unity.Mobile.IOS;
using Facebook.Unity.Settings;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x200000B")]
	public sealed class FB : ScriptableObject
	{
		[Token(Token = "0x200000C")]
		private delegate void OnDLLLoaded();

		[Token(Token = "0x200000D")]
		public sealed class Canvas
		{
			[Token(Token = "0x1700001F")]
			private static IPayFacebook FacebookPayImpl
			{
				[Token(Token = "0x6000064")]
				[Address(RVA = "0xD2B6CC", Offset = "0xD2B6CC", Length = "0xB4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7020]);\n\tv15 = *([v14 @ X8_v18]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C05]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.FB::get_FacebookImpl();\n\t// 33 IsInst returnVal1 @ X0_v5 (Facebook.Unity.IPayFacebook), typeof(Facebook.Unity.IPayFacebook), v49 @ X0_v4 (Facebook.Unity.IFacebook)\n\tv54 = returnVal1 == 0;\n\tif (v54) goto L_002C;\n\treturn returnVal1;\nL_002C:\n\tv61 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v61, \"Attempt to call Facebook pay interface on unsupported platform\");\n\tthrow v61;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					IFacebook facebookImpl = FacebookImpl;
					IPayFacebook payFacebook = facebookImpl as IPayFacebook;
					if (payFacebook != null)
					{
						return payFacebook;
					}
					InvalidOperationException ex = new InvalidOperationException("Attempt to call Facebook pay interface on unsupported platform");
					throw ex;
				}
			}

			[Token(Token = "0x6000065")]
			[Address(RVA = "0xD2B780", Offset = "0xD2B780", Length = "0x124")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv48 = *([1EC7F18]);\n\tv49 = *([v48 @ X8_v9]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, action, quantity, quantityMin, quantityMax, requestId, pricepointId, testCurrency, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023C06]) = v61;\nL_0022:\n\tv62 = Facebook.Unity.FB+Canvas::get_FacebookPayImpl();\n\tgoto L_005E;\n\tv73 = *([v66 @ X8_v3+B0]);\n\tv74 = 0;\n\tv75 = v73 + 8;\n\tv77 = *([v124 @ X11_v5-8]);\n\tv130 = v77 == v70;\n\tif (v130) goto L_004D;\n\tv110 = v125 + 1;\n\tv218 = v110 < v69;\n\tv104 = ~v218;\n\tv107 = v124 + 0x10;\n\tv80 = ~v104;\n\tif (v80) goto L_FFFFFFFF;\n\tv111 = v63;\n\tv112 = 0;\n\tv113 = 0x8909C4(v111, v70, v112, quantityMin, quantityMax, requestId, pricepointId, testCurrency, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_005E;\nL_004D:\n\tv219 = *([v124 @ X11_v5]);\n\tv220 = v219 << 4;\n\tv221 = v66 + v220;\n\tv222 = v221 + 0x130;\nL_005E:\n\tFacebook.Unity.IPayFacebook::Pay(v62, v59, action, quantity, quantityMin, quantityMax, requestId, pricepointId);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void Pay(string product, string action = "purchaseitem", int quantity = 1, int? quantityMin = null, int? quantityMax = null, string requestId = null, string pricepointId = null, string testCurrency = null, FacebookDelegate<IPayResult> callback = null)
			{
				IPayFacebook facebookPayImpl = FacebookPayImpl;
				string product2 = default(string);
				facebookPayImpl.Pay(product2, action, quantity, quantityMin, quantityMax, requestId, pricepointId, null, null);
			}
		}

		[Token(Token = "0x200000E")]
		public sealed class Mobile
		{
			[Token(Token = "0x17000020")]
			public static ShareDialogMode ShareDialogMode
			{
				[Token(Token = "0x6000066")]
				[Address(RVA = "0xD2BBD0", Offset = "0xD2BBD0", Length = "0xB8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBE3F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C08]) = v38;\nL_0013:\n\tv39 = Facebook.Unity.FB+Mobile::get_MobileFacebookImpl();\n\tgoto L_004A;\n\tv49 = *([v43 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v46;\n\tif (v106) goto L_003D;\n\tv86 = v101 + 1;\n\tv161 = v86 < v45;\n\tv80 = ~v161;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v40;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v46, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004A;\nL_003D:\n\tv162 = *([v100 @ X11_v5]);\n\tv163 = v162 << 4;\n\tv164 = v43 + v163;\n\tv165 = v164 + 0x130;\nL_004A:\n\tFacebook.Unity.Mobile.IMobileFacebook::set_ShareDialogMode(v39, v36);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					IMobileFacebook mobileFacebookImpl = MobileFacebookImpl;
					ShareDialogMode shareDialogMode = default(ShareDialogMode);
					mobileFacebookImpl.ShareDialogMode = shareDialogMode;
				}
			}

			[Token(Token = "0x17000021")]
			private static IMobileFacebook MobileFacebookImpl
			{
				[Token(Token = "0x6000067")]
				[Address(RVA = "0xD2BC88", Offset = "0xD2BC88", Length = "0xB4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB9CB8]);\n\tv15 = *([v14 @ X8_v18]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C09]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.FB::get_FacebookImpl();\n\t// 33 IsInst returnVal1 @ X0_v5 (Facebook.Unity.Mobile.IMobileFacebook), typeof(Facebook.Unity.Mobile.IMobileFacebook), v49 @ X0_v4 (Facebook.Unity.IFacebook)\n\tv54 = returnVal1 == 0;\n\tif (v54) goto L_002C;\n\treturn returnVal1;\nL_002C:\n\tv61 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v61, \"Attempt to call Mobile interface on non mobile platform\");\n\tthrow v61;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					IFacebook facebookImpl = FacebookImpl;
					IMobileFacebook mobileFacebook = facebookImpl as IMobileFacebook;
					if (mobileFacebook != null)
					{
						return mobileFacebook;
					}
					InvalidOperationException ex = new InvalidOperationException("Attempt to call Mobile interface on non mobile platform");
					throw ex;
				}
			}

			[Token(Token = "0x6000068")]
			[Address(RVA = "0xD2BD3C", Offset = "0xD2BD3C", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC8650]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C0A]) = v38;\nL_0013:\n\tv39 = v36 == 0;\n\tif (v39) goto L_0044;\n\tv40 = Facebook.Unity.FB+Mobile::get_MobileFacebookImpl();\n\tv111 = *([v40 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook)]);\n\tv101 = *([v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]) == 0;\n\tif (v101) goto L_003D;\n\tv155 = *([v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]) + 8;\nL_0028:\n\tv161 = *([v155 @ X11_v5-8]) == Facebook.Unity.Mobile.IMobileFacebook;\n\tif (v161) goto L_0046;\n\tv156 = v156 + 1;\n\tv166 = v156 < *([v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]);\n\tv137 = ~v166;\n\tv155 = v155 + 0x10;\n\tv121 = ~v137;\n\tif (v121) goto L_0028;\nL_003D:\n\tv173 = 0x8909C4(v40, Facebook.Unity.Mobile.IMobileFacebook, 1, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004A;\nL_0044:\n\treturn;\nL_0046:\n\tv168 = *([v155 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v111 + v169;\n\tv173 = v170 + 0x130;\nL_004A:\n\tv48 = *([v173 @ X0_v4]);\n\tv58 = *([v173 @ X0_v4+8]);\n\t// 83 IndirectJump v48 @ X3_v1, v40 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v40 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v36 @ X0_v1 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>), v58 @ X2_v2, v48 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void FetchDeferredAppLinkData(FacebookDelegate<IAppLinkResult> callback = null)
			{
				//IL_001b: Expected I, but got O
				//IL_0169: Expected O, but got I
				//IL_0056: Expected O, but got I
				//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d9: Expected O, but got Unknown
				//IL_00f6: Expected O, but got I
				//IL_0105: Expected O, but got I
				//IL_00a2: Expected O, but got I
				FacebookDelegate<IAppLinkResult> facebookDelegate = default(FacebookDelegate<IAppLinkResult>);
				if (facebookDelegate == null)
				{
					return;
				}
				IMobileFacebook mobileFacebookImpl = MobileFacebookImpl;
				IntPtr intPtr = (IntPtr)mobileFacebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bb;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IMobileFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00bb;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0151;
				IL_0151:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ X3_v1 (should have been resolved before IL gen)");
				return;
				IL_00bb:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0151;
			}

			[Token(Token = "0x6000069")]
			[Address(RVA = "0xD2BE08", Offset = "0xD2BE08", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFF5F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C0B]) = v38;\nL_0013:\n\tv39 = Facebook.Unity.FB+Mobile::get_MobileFacebookImpl();\n\tv43 = *([v39 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook)]);\n\tv47 = *([v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]) == 0;\n\tif (v47) goto L_003B;\n\tv100 = *([v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]) + 8;\nL_0026:\n\tv106 = *([v100 @ X11_v5-8]) == Facebook.Unity.Mobile.IMobileFacebook;\n\tif (v106) goto L_003E;\n\tv101 = v101 + 1;\n\tv161 = v101 < *([v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]);\n\tv80 = ~v161;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0026;\nL_003B:\n\tv168 = 0x8909C4(v39, Facebook.Unity.Mobile.IMobileFacebook, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0042;\nL_003E:\n\tv163 = *([v100 @ X11_v5]) + 2;\n\tv164 = v163 << 4;\n\tv165 = v43 + v164;\n\tv168 = v165 + 0x130;\nL_0042:\n\tv114 = *([v168 @ X0_v4]);\n\tv121 = *([v168 @ X0_v4+8]);\n\t// 75 IndirectJump v114 @ X3_v1, v39 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v39 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v36 @ X0_v1 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAccessTokenRefreshResult>), v121 @ X2_v2, v114 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback = null)
			{
				//IL_000d: Expected I, but got O
				//IL_014b: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				IMobileFacebook mobileFacebookImpl = MobileFacebookImpl;
				IntPtr intPtr = (IntPtr)mobileFacebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IMobileFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v114 @ X3_v1 (should have been resolved before IL gen)");
			}

			[Token(Token = "0x600006A")]
			[Address(RVA = "0xD23E28", Offset = "0xD23E28", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EBE1D0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C0C]) = v35;\nL_0011:\n\tv36 = Facebook.Unity.FB+Mobile::get_MobileFacebookImpl();\n\tv40 = *([v36 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook)]);\n\tv44 = *([v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]) == 0;\n\tif (v44) goto L_0039;\n\tv97 = *([v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]) + 8;\nL_0024:\n\tv103 = *([v97 @ X11_v5-8]) == Facebook.Unity.Mobile.IMobileFacebook;\n\tif (v103) goto L_003C;\n\tv98 = v98 + 1;\n\tv154 = v98 < *([v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]);\n\tv77 = ~v154;\n\tv97 = v97 + 0x10;\n\tv53 = ~v77;\n\tif (v53) goto L_0024;\nL_0039:\n\tv161 = 0x8909C4(v36, Facebook.Unity.Mobile.IMobileFacebook, 3, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0040;\nL_003C:\n\tv156 = *([v97 @ X11_v5]) + 3;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv161 = v158 + 0x130;\nL_0040:\n\tv116 = *([v161 @ X0_v4]);\n\tv138 = *([v161 @ X0_v4+8]);\n\t// 71 IndirectJump v116 @ X2_v2, v36 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v36 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebook), v138 @ X1_v2, v116 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static bool IsImplicitPurchaseLoggingEnabled()
			{
				//IL_000d: Expected I, but got O
				//IL_014b: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				IMobileFacebook mobileFacebookImpl = MobileFacebookImpl;
				IntPtr intPtr = (IntPtr)mobileFacebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IMobileFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebook>)+126]");
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
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0133;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0133;
				IL_0133:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ X2_v2 (should have been resolved before IL gen)");
				return false;
			}
		}

		[Token(Token = "0x200000F")]
		internal abstract class CompiledFacebookLoader : MonoBehaviour
		{
			[Token(Token = "0x17000022")]
			protected abstract FacebookGameObject FBGameObject
			{
				[Token(Token = "0x600006B")]
				get;
			}

			[Token(Token = "0x600006C")]
			[Address(RVA = "0xD2B8A4", Offset = "0xD2B8A4", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDF8A0]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C07]) = v40;\nL_0014:\n\t;\n\tv45 = Facebook.Unity.FB+CompiledFacebookLoader::get_FBGameObject(this);\n\tgoto L_002B;\n\tv66 = *([v51 @ X0_v6 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v51, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv70 = Facebook.Unity.FB;\nL_002B:\n\tv73.facebook = v45.<Facebook>k__BackingField;\n\tgoto L_003B;\n\tv79 = *([1EB2630]);\n\tv80 = *([v79 @ X8_v20]);\n\tv81 = \"il2cpp_codegen_initialize_method\"(v80, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv84 = 0 | 1;\n\t*([2023CB0]) = v84;\nL_003B:\n\tgoto L_0046;\n\tv108 = *([v85 @ X0_v9 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\t// 63 Jump @b25\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v85, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv112 = Facebook.Unity.FB;\nL_0046:\n\tFacebook.Unity.FB+OnDLLLoaded::Invoke(v63.<OnDLLLoadedDelegate>k__BackingField);\n\tFacebook.Unity.FB::LogVersion();\n\tgoto L_005C;\n\tv122 = *([v118 @ X0_v12+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_005C;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005C:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Start()
			{
				FacebookGameObject fBGameObject = FBGameObject;
				facebook = fBGameObject.Facebook;
				OnDLLLoadedDelegate();
				LogVersion();
				UnityEngine.Object.Destroy(this);
			}

			[Token(Token = "0x600006D")]
			[Address(RVA = "0xD21D5C", Offset = "0xD21D5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected internal CompiledFacebookLoader()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000010")]
		private sealed class _003C_003Ec__DisplayClass35_0
		{
			[Token(Token = "0x4000026")]
			[FieldOffset(Offset = "0x10")]
			public InitDelegate onInitComplete;

			[Token(Token = "0x4000027")]
			[FieldOffset(Offset = "0x18")]
			public string appId;

			[Token(Token = "0x4000028")]
			[FieldOffset(Offset = "0x20")]
			public bool cookie;

			[Token(Token = "0x4000029")]
			[FieldOffset(Offset = "0x21")]
			public bool logging;

			[Token(Token = "0x400002A")]
			[FieldOffset(Offset = "0x22")]
			public bool status;

			[Token(Token = "0x400002B")]
			[FieldOffset(Offset = "0x23")]
			public bool xfbml;

			[Token(Token = "0x400002C")]
			[FieldOffset(Offset = "0x28")]
			public string authResponse;

			[Token(Token = "0x400002D")]
			[FieldOffset(Offset = "0x30")]
			public bool frictionlessRequests;

			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x38")]
			public string javascriptSDKLocale;

			[Token(Token = "0x400002F")]
			[FieldOffset(Offset = "0x40")]
			public HideUnityDelegate onHideUnity;

			[Token(Token = "0x600006E")]
			[Address(RVA = "0xD29C30", Offset = "0xD29C30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass35_0()
			{
			}

			internal void _003CInit_003Eb__0()
			{
				//IL_003d: Expected I, but got O
				IFacebook facebook = FB.facebook;
				EditorFacebook editorFacebook = FB.facebook as EditorFacebook;
				if (editorFacebook != null)
				{
					IntPtr intPtr = (IntPtr)facebook;
					EditorFacebook editorFacebook2 = FB.facebook as EditorFacebook;
					if (editorFacebook2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v151 @ X8_v12 (Il2CppClass<Facebook.Unity.IFacebook>)+330] (should have been resolved before IL gen)");
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new NullReferenceException();
			}

			internal void _003CInit_003Eb__1()
			{
				CanvasFacebook facebook = (CanvasFacebook)FB.facebook;
				string channelUrl = FacebookSettings.ChannelUrl;
				bool debugMode = Constants.DebugMode;
				if ((object)facebook.GetType() == typeof(CanvasFacebook) && (object)facebook.GetType() == typeof(CanvasFacebook))
				{
					bool flag = !frictionlessRequests;
					bool flag2 = !flag;
					bool flag3 = !xfbml;
					bool flag4 = !flag3;
					bool flag5 = !status;
					bool flag6 = !flag5;
					bool flag7 = !logging;
					bool flag8 = !flag7;
					bool flag9 = !cookie;
					bool flag10 = !flag9;
					facebook.Init(appId, flag10, flag8, flag6, flag4, channelUrl, authResponse, flag2, javascriptSDKLocale, debugMode, onHideUnity, onInitComplete);
					return;
				}
				throw new InvalidCastException();
			}

			internal void _003CInit_003Eb__2()
			{
				string iosURLSuffix = FacebookSettings.IosURLSuffix;
				IOSFacebook iOSFacebook = facebook as IOSFacebook;
				if (iOSFacebook != null)
				{
					IOSFacebook iOSFacebook2 = facebook as IOSFacebook;
					if (iOSFacebook2 != null)
					{
						bool flag = !frictionlessRequests;
						bool flag2 = !flag;
						HideUnityDelegate hideUnityDelegate = default(HideUnityDelegate);
						((IOSFacebook)facebook).Init(appId, flag2, iosURLSuffix, hideUnityDelegate, onInitComplete);
						return;
					}
				}
				throw new InvalidCastException();
			}

			internal void _003CInit_003Eb__3()
			{
				AndroidFacebook facebook = (AndroidFacebook)FB.facebook;
				if ((object)facebook.GetType() == typeof(AndroidFacebook) && (object)facebook.GetType() == typeof(AndroidFacebook))
				{
					HideUnityDelegate hideUnityDelegate = default(HideUnityDelegate);
					facebook.Init(appId, hideUnityDelegate, onInitComplete);
					return;
				}
				InvalidCastException ex = new InvalidCastException();
				throw new NullReferenceException();
			}

			internal void _003CInit_003Eb__4()
			{
				GameroomFacebook facebook = (GameroomFacebook)FB.facebook;
				if ((object)facebook.GetType() == typeof(GameroomFacebook) && (object)facebook.GetType() == typeof(GameroomFacebook))
				{
					HideUnityDelegate hideUnityDelegate = default(HideUnityDelegate);
					facebook.Init(appId, hideUnityDelegate, onInitComplete);
					return;
				}
				InvalidCastException ex = new InvalidCastException();
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x400001E")]
		private const string DefaultJSSDKLocale = "en_US";

		[Token(Token = "0x400001F")]
		private static IFacebook facebook;

		[Token(Token = "0x4000020")]
		private static bool isInitCalled = false;

		[Token(Token = "0x4000021")]
		internal static string facebookDomain = "facebook.com";

		[Token(Token = "0x4000022")]
		internal static string graphApiVersion = "v3.0";

		[Token(Token = "0x17000016")]
		[field: Token(Token = "0x4000023")]
		public static string AppId
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0xD28D30", Offset = "0xD28D30", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAF7B0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BDD]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0024:\n\treturn v49.<AppId>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600003C")]
			[Address(RVA = "0xD28D98", Offset = "0xD28D98", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC2B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BDE]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.<AppId>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000017")]
		[field: Token(Token = "0x4000024")]
		public static string ClientToken
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0xD28E04", Offset = "0xD28E04", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB4688]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BDF]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0024:\n\treturn v49.<ClientToken>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600003E")]
			[Address(RVA = "0xD28E6C", Offset = "0xD28E6C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEB9F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BE0]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.<ClientToken>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000018")]
		public static string GraphApiVersion
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0xD28ED8", Offset = "0xD28ED8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F048F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BE1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0024:\n\treturn v49.graphApiVersion;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return graphApiVersion;
			}
			[Token(Token = "0x6000040")]
			[Address(RVA = "0xD28F40", Offset = "0xD28F40", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC73E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BE2]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.graphApiVersion = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				graphApiVersion = value;
			}
		}

		[Token(Token = "0x17000019")]
		public static bool IsLoggedIn
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0xD2698C", Offset = "0xD2698C", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC9748]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BE3]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0020:\n\tv51 = v49.facebook == 0;\n\tif (v51) goto L_005A;\n\tgoto L_002B;\n\tv60 = *([v45 @ X0_v3 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_002B;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002B:\n\tv67 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_0066;\n\tv134 = *([v130 @ X8_v9+B0]);\n\tv135 = 0;\n\tv136 = v134 + 8;\n\tv138 = *([v174 @ X11_v5-8]);\n\tv180 = v138 == v133;\n\tif (v180) goto L_005B;\n\tv160 = v175 + 1;\n\tv185 = v160 < v132;\n\tv156 = ~v185;\n\tv158 = v174 + 0x10;\n\tv140 = ~v156;\n\tif (v140) goto L_FFFFFFFF;\n\tv161 = v126;\n\tv162 = 0;\n\tv163 = 0x8909C4(v161, v133, v162, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0066;\nL_005A:\n\treturn 0;\nL_005B:\n\tv186 = *([v174 @ X11_v5]);\n\tv187 = v186 << 4;\n\tv188 = v130 + v187;\n\tv189 = v188 + 0x130;\nL_0066:\n\tinterfaceTailCallResult = Facebook.Unity.IFacebook::get_LoggedIn(v67);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (facebook != null)
				{
					IFacebook facebookImpl = FacebookImpl;
					return facebookImpl.LoggedIn;
				}
				return false;
			}
		}

		[Token(Token = "0x1700001A")]
		public static bool IsInitialized
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0xD28FAC", Offset = "0xD28FAC", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF7918]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BE4]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Facebook.Unity.FB;\nL_0020:\n\tv72 = v51.facebook;\n\tv53 = v51.facebook == 0;\n\tif (v53) goto L_005D;\n\tgoto L_0032;\n\tv63 = *([v47 @ X0_v3 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv170 = Facebook.Unity.FB;\n\tv71 = *([v170 @ X8_v12 (Il2CppClass<Facebook.Unity.FB>)+B8]);\n\tv73 = v71.facebook;\nL_0032:\n\tv75 = *([v72 @ X19_v4 (Facebook.Unity.IFacebook)]);\n\tv79 = *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v79) goto L_0055;\n\tv181 = *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0040:\n\tv187 = *([v181 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v187) goto L_005F;\n\tv182 = v182 + 1;\n\tv193 = v182 < *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv162 = ~v193;\n\tv181 = v181 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_0040;\nL_0055:\n\tv200 = 0x8909C4(v51.facebook, Facebook.Unity.IFacebook, 4, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_006B;\nL_005D:\n\treturn 0;\nL_005F:\n\tv195 = *([v181 @ X11_v5]) + 4;\n\tv196 = v195 << 4;\n\tv197 = v75 + v196;\n\tv200 = v197 + 0x130;\nL_006B:\n\t// 107 IndirectJump [v200 @ X0_v6], v51.facebook (Facebook.Unity.IFacebook), v51.facebook (Facebook.Unity.IFacebook), [v200 @ X0_v6+8], [v200 @ X0_v6], v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0012: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Expected O, but got Unknown
				//IL_00f2: Expected O, but got I
				//IL_0101: Expected O, but got I
				//IL_0099: Expected O, but got I
				IFacebook facebook = FB.facebook;
				if (FB.facebook != null)
				{
					IntPtr intPtr = (IntPtr)facebook;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00b2;
					}
					object obj2 = obj + 4;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_015c;
				}
				return false;
				IL_015c:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v200 @ X0_v6] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
				return false;
				IL_00b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_015c;
			}
		}

		[Token(Token = "0x1700001B")]
		public static bool LimitAppEventUsage
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0xD290BC", Offset = "0xD290BC", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F03C48]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BE5]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Facebook.Unity.FB;\nL_0020:\n\tv72 = v51.facebook;\n\tv53 = v51.facebook == 0;\n\tif (v53) goto L_005D;\n\tgoto L_0032;\n\tv63 = *([v47 @ X0_v3 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv170 = Facebook.Unity.FB;\n\tv71 = *([v170 @ X8_v12 (Il2CppClass<Facebook.Unity.FB>)+B8]);\n\tv73 = v71.facebook;\nL_0032:\n\tv75 = *([v72 @ X19_v4 (Facebook.Unity.IFacebook)]);\n\tv79 = *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v79) goto L_0055;\n\tv181 = *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0040:\n\tv187 = *([v181 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v187) goto L_005F;\n\tv182 = v182 + 1;\n\tv193 = v182 < *([v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv162 = ~v193;\n\tv181 = v181 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_0040;\nL_0055:\n\tv200 = 0x8909C4(v51.facebook, Facebook.Unity.IFacebook, 1, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_006B;\nL_005D:\n\treturn 0;\nL_005F:\n\tv195 = *([v181 @ X11_v5]) + 1;\n\tv196 = v195 << 4;\n\tv197 = v75 + v196;\n\tv200 = v197 + 0x130;\nL_006B:\n\t// 107 IndirectJump [v200 @ X0_v6], v51.facebook (Facebook.Unity.IFacebook), v51.facebook (Facebook.Unity.IFacebook), [v200 @ X0_v6+8], [v200 @ X0_v6], v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0012: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Expected O, but got Unknown
				//IL_00f2: Expected O, but got I
				//IL_0101: Expected O, but got I
				//IL_0099: Expected O, but got I
				IFacebook facebook = FB.facebook;
				if (FB.facebook != null)
				{
					IntPtr intPtr = (IntPtr)facebook;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00b2;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_015c;
				}
				return false;
				IL_015c:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v200 @ X0_v6] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
				return false;
				IL_00b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_015c;
			}
			[Token(Token = "0x6000044")]
			[Address(RVA = "0xD291CC", Offset = "0xD291CC", Length = "0x120")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC8A50]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BE6]) = v40;\nL_001A:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Facebook.Unity.FB;\nL_0022:\n\tv75 = v54.facebook;\n\tv56 = v54.facebook == 0;\n\tif (v56) goto L_005F;\n\tgoto L_0034;\n\tv66 = *([v50 @ X0_v3 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0034;\n\tv177 = Facebook.Unity.FB;\n\tv74 = *([v177 @ X8_v12 (Il2CppClass<Facebook.Unity.FB>)+B8]);\n\tv76 = v74.facebook;\nL_0034:\n\tv78 = *([v75 @ X20_v4 (Facebook.Unity.IFacebook)]);\n\tv82 = *([v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v82) goto L_0057;\n\tv188 = *([v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0042:\n\tv194 = *([v188 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v194) goto L_0061;\n\tv189 = v189 + 1;\n\tv200 = v189 < *([v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv169 = ~v200;\n\tv188 = v188 + 0x10;\n\tv153 = ~v169;\n\tif (v153) goto L_0042;\nL_0057:\n\tv207 = 0x8909C4(v54.facebook, Facebook.Unity.IFacebook, 2, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006F;\nL_005F:\n\treturn;\nL_0061:\n\tv202 = *([v188 @ X11_v5]) + 2;\n\tv203 = v202 << 4;\n\tv204 = v78 + v203;\n\tv207 = v204 + 0x130;\nL_006F:\n\t// 111 IndirectJump [v207 @ X0_v5], v54.facebook (Facebook.Unity.IFacebook), v54.facebook (Facebook.Unity.IFacebook), value @ X0 (System.Boolean), [v207 @ X0_v5+8], [v207 @ X0_v5], v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Expected O, but got Unknown
				//IL_00ed: Expected O, but got I
				//IL_00fc: Expected O, but got I
				//IL_0099: Expected O, but got I
				IFacebook facebook = FB.facebook;
				if (FB.facebook == null)
				{
					return;
				}
				IntPtr intPtr = (IntPtr)facebook;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00b2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00b2;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0157;
				IL_0157:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v207 @ X0_v5] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				return;
				IL_00b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0157;
			}
		}

		[Token(Token = "0x1700001C")]
		internal static IFacebook FacebookImpl
		{
			[Token(Token = "0x6000045")]
			[Address(RVA = "0xD253FC", Offset = "0xD253FC", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0FA68]);\n\tv15 = *([v14 @ X8_v20]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BE7]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0020:\n\tv51 = v49.facebook == 0;\n\tif (v51) goto L_0037;\n\tgoto L_0033;\n\tv60 = *([v45 @ X0_v3 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0033;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv94 = Facebook.Unity.FB;\n\tv95 = *([v94 @ X8_v14+B8]);\n\tv68 = *([v95 @ X8_v15]);\nL_0033:\n\treturn v49.facebook;\nL_0037:\n\tv59 = new System.NullReferenceException();\n\tSystem.NullReferenceException::.ctor(v59, \"Facebook object is not yet loaded.  Did you call FB.Init()?\");\n\tthrow v59;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (facebook == null)
				{
					NullReferenceException ex = new NullReferenceException("Facebook object is not yet loaded.  Did you call FB.Init()?");
					throw ex;
				}
				return facebook;
			}
			[Token(Token = "0x6000046")]
			[Address(RVA = "0xD292EC", Offset = "0xD292EC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF3208]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BE8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.facebook = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				facebook = value;
			}
		}

		[Token(Token = "0x1700001D")]
		internal static string FacebookDomain
		{
			[Token(Token = "0x6000047")]
			[Address(RVA = "0xD29358", Offset = "0xD29358", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F063B0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BE9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0024:\n\treturn v49.facebookDomain;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return facebookDomain;
			}
			[Token(Token = "0x6000048")]
			[Address(RVA = "0xD293C0", Offset = "0xD293C0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBB048]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BEA]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.facebookDomain = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				facebookDomain = value;
			}
		}

		[Token(Token = "0x1700001E")]
		[field: Token(Token = "0x4000025")]
		private static OnDLLLoaded OnDLLLoadedDelegate
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0xD2942C", Offset = "0xD2942C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC3288]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BEB]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FB;\nL_0024:\n\treturn v49.<OnDLLLoadedDelegate>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600004A")]
			[Address(RVA = "0xD29494", Offset = "0xD29494", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC2A60]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BEC]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FB;\nL_0021:\n\tv52.<OnDLLLoadedDelegate>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0xD29500", Offset = "0xD29500", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EF94A8]);\n\tv39 = *([v38 @ X8_v15]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, onHideUnity, authResponse, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2023BED]) = v56;\nL_0023:\n\tgoto L_002A;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002A;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, onHideUnity, authResponse, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_002A:\n\tv71 = Facebook.Unity.Settings.FacebookSettings::get_AppId();\n\tv74 = Facebook.Unity.Settings.FacebookSettings::get_ClientToken();\n\tv77 = Facebook.Unity.Settings.FacebookSettings::get_Cookie();\n\tv80 = Facebook.Unity.Settings.FacebookSettings::get_Logging();\n\tv83 = Facebook.Unity.Settings.FacebookSettings::get_Status();\n\tv86 = Facebook.Unity.Settings.FacebookSettings::get_Xfbml();\n\tv89 = Facebook.Unity.Settings.FacebookSettings::get_FrictionlessRequests();\n\tgoto L_0059;\n\tv97 = *([v93 @ X8_v9+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0059;\n\tv119 = v93;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v119, onHideUnity, authResponse, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0059:\n\tFacebook.Unity.FB::Init(v71, v74, v77, v80, v83, v86, v89, authResponse, \"en_US\", onHideUnity, onInitComplete);\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init(InitDelegate onInitComplete = null, HideUnityDelegate onHideUnity = null, string authResponse = null)
		{
			string appId = FacebookSettings.AppId;
			string clientToken = FacebookSettings.ClientToken;
			bool cookie = FacebookSettings.Cookie;
			bool logging = FacebookSettings.Logging;
			bool status = FacebookSettings.Status;
			bool xfbml = FacebookSettings.Xfbml;
			bool frictionlessRequests = FacebookSettings.FrictionlessRequests;
			Init(appId, clientToken, cookie, logging, status, xfbml, frictionlessRequests, authResponse, "en_US", onHideUnity, onInitComplete);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xD29640", Offset = "0xD29640", Length = "0x5F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0028;\n\tv51 = *([1EF5B98]);\n\tv52 = *([v51 @ X8_v79]);\n\tv53 = \"il2cpp_codegen_initialize_method\"(v52, clientToken, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2023BEE]) = v64;\nL_0028:\n\tv68 = new Facebook.Unity.FB+<>c__DisplayClass35_0();\n\tSystem.Object::.ctor(v68);\n\tv68.onInitComplete = *([v24 @ X29_v1+20]);\n\tv68.appId = appId;\n\tv68.authResponse = authResponse;\n\tv68.cookie = cookie;\n\tv68.logging = logging;\n\tv68.status = status;\n\tv68.xfbml = xfbml;\n\tv68.frictionlessRequests = frictionlessRequests;\n\tv68.javascriptSDKLocale = *([v24 @ X29_v1+10]);\n\tv68.onHideUnity = *([v24 @ X29_v1+18]);\n\tv80 = System.String::IsNullOrEmpty(appId);\n\tv84 = v80 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_01DE;\n\tgoto L_0056;\n\tv114 = *([v105 @ X0_v17+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0056;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v105, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\nL_0056:\n\tgoto L_0061;\n\tv185 = *([1EF21A0]);\n\tv186 = *([v185 @ X8_v75]);\n\tv187 = \"il2cpp_codegen_initialize_method\"(v186, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv190 = 0 | 1;\n\t*([2023CAD]) = v190;\nL_0061:\n\tgoto L_006A;\n\tv217 = *([v191 @ X0_v20 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tgoto L_006A;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v191, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv221 = Facebook.Unity.FB;\nL_006A:\n\tv224.<AppId>k__BackingField = v68.appId;\n\tgoto L_0079;\n\tv231 = *([1EE9628]);\n\tv232 = *([v231 @ X8_v71]);\n\tv233 = \"il2cpp_codegen_initialize_method\"(v232, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv235 = Facebook.Unity.FB;\n\tv237 = 0 | 1;\n\t*([2023CAE]) = v237;\nL_0079:\n\tgoto L_0082;\n\tv241 = *([v234 @ X0_v22 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tgoto L_0082;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v234, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv245 = Facebook.Unity.FB;\nL_0082:\n\tv248.<ClientToken>k__BackingField = clientToken;\n\tv252 = ~v250.isInitCalled;\n\tif (v252) goto L_00A8;\n\tgoto L_00A3;\n\tv263 = *([v256 @ X0_v47+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_00A3;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v256, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\nL_00A3:\n\tFacebook.Unity.FacebookLogger::Warn(\"FB.Init() has already been called.  You only need to call this once and only once.\");\n\treturn;\nL_00A8:\n\tgoto L_00B2;\n\tv285 = *([v244 @ X0_v23 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_00B2;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v244, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv342 = Facebook.Unity.FB;\n\tv293 = *([v342 @ X8_v59+B8]);\nL_00B2:\n\tv292.isInitCalled = 1;\n\tv295 = UnityEngine.Application::get_isEditor();\n\tv209 = v295 == 0;\n\tif (v209) goto L_0102;\n\tv346 = new Facebook.Unity.FB+OnDLLLoaded();\n\tv350 = Il2CppMethodInfo;\n\tv346.m_target = v68;\n\tv346.method = Il2CppMethodInfo;\n\tv346.method_ptr = *([v350 @ X8_v40 (Il2CppMethodInfo)]);\n\tgoto L_00D1;\n\tv357 = *([v351 @ X0_v30+E0]);\n\tv358 = v357 == 0;\n\tv359 = ~v358;\n\tif (v359) goto L_00D1;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v351, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\nL_00D1:\n\tgoto L_00DC;\n\tv371 = *([1EFA250]);\n\tv372 = *([v371 @ X8_v56]);\n\tv373 = \"il2cpp_codegen_initialize_method\"(v372, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv376 = 0 | 1;\n\t*([2023CAF]) = v376;\nL_00DC:\n\tgoto L_00E4;\n\tv381 = *([v377 @ X0_v33 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tgoto L_00E4;\n\tv390 = \"il2cpp_codegen_runtime_class_init\"(v377, v79, cookie, logging, status, xfbml, frictionlessRequests, authResponse, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv385 = Facebook.Unity.FB;\nL_00E4:\n\tv387.<OnDLLLoadedDelegate>k__BackingField = v346;\nL_00E9:\n\tv393 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv398 = Facebook.Unity.ComponentFactory::GetComponent(0);\nL_0100:\n\tv314 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\treturn;\nL_0102:\n\tv208 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv212 = v208 - 1;\n\tv355 = v212 < 3;\n\tv204 = ~v355;\n\tv203 = v212 - 3;\n\tv201 = v203 == 0;\n\tv356 = ~v201;\n\tv196 = v204 & v356;\n\tif (v196) goto L_01EE;\n\tv310 = 0x181C000 + 0x298;\n\tv333 = *([v310 @ X9_v11 (System.Int32)+v212 @ X8_v33 (System.Int32)*4]) + v310;\n\t// 276 IndirectJump v333 @ X8_v35, v208 @ X0_v27 (Facebook.Unity.FacebookUnityPlatform), v208 @ X0_v27 (Facebook.Unity.FacebookUnityPlatform), 0, cookie @ X2 (System.Boolean), logging @ X3 (System.Boolean), status @ X4 (System.Boolean), xfbml @ X5 (System.Boolean), frictionlessRequests @ X6 (System.Boolean), authResponse @ X7 (System.String), v54 @ V0, v55 @ V1, v56 @ V2, v57 @ V3, v58 @ V4, v59 @ V5, v60 @ V6, v61 @ V7\n\tX8 = *([1EEDC30]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFDC78]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X20+20]) = X19;\n\t*([X20+28]) = X8;\n\t*([X20+10]) = X9;\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_012B;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_012B;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_012B:\n\tX19 = 0x2023000;\n\tX8 = *([2023CAF]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0136;\n\tX8 = *([1EFA250]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023CAF]) = X8;\nL_0136:\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0141;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0141;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_0141:\n\tX8 = *([X0+B8]);\n\t*([X8+30]) = X20;\n\tX8 = *([1EE9CE0]);\n\tgoto L_00E9;\n\tX8 = *([1EEDC30]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EC3510]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X20+20]) = X19;\n\t*([X20+28]) = X8;\n\t*([X20+10]) = X9;\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_015C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_015C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_015C:\n\tX19 = 0x2023000;\n\tX8 = *([2023CAF]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0167;\n\tX8 = *([1EFA250]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023CAF]) = X8;\nL_0167:\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0172;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0172;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_0172:\n\tX8 = *([X0+B8]);\n\t*([X8+30]) = X20;\n\tX8 = *([1EAEF10]);\n\tgoto L_0100;\n\tX8 = *([1EEDC30]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB81D8]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X20+20]) = X19;\n\t*([X20+28]) = X8;\n\t*([X20+10]) = X9;\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_018D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_018D:\n\tX19 = 0x2023000;\n\tX8 = *([2023CAF]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0198;\n\tX8 = *([1EFA250]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023CAF]) = X8;\nL_0198:\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP =\n// ... truncated")]
		public unsafe static void Init(string appId, string clientToken = null, bool cookie = true, bool logging = true, bool status = true, bool xfbml = false, bool frictionlessRequests = true, string authResponse = null, string javascriptSDKLocale = "en_US", HideUnityDelegate onHideUnity = null, InitDelegate onInitComplete = null)
		{
			//IL_0022: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_00a7: Expected O, but got I
			//IL_01d1: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_003C_003Ec__DisplayClass35_0 _003C_003Ec__DisplayClass35_1 = new _003C_003Ec__DisplayClass35_0();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			_003C_003Ec__DisplayClass35_1.onInitComplete = (InitDelegate)0;
			_003C_003Ec__DisplayClass35_1.appId = appId;
			_003C_003Ec__DisplayClass35_1.authResponse = authResponse;
			_003C_003Ec__DisplayClass35_1.cookie = cookie;
			_003C_003Ec__DisplayClass35_1.logging = logging;
			_003C_003Ec__DisplayClass35_1.status = status;
			_003C_003Ec__DisplayClass35_1.xfbml = xfbml;
			_003C_003Ec__DisplayClass35_1.frictionlessRequests = frictionlessRequests;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			_003C_003Ec__DisplayClass35_1.javascriptSDKLocale = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			_003C_003Ec__DisplayClass35_1.onHideUnity = (HideUnityDelegate)0;
			if (!string.IsNullOrEmpty(appId))
			{
				AppId = _003C_003Ec__DisplayClass35_1.appId;
				ClientToken = clientToken;
				if (isInitCalled)
				{
					FacebookLogger.Warn("FB.Init() has already been called.  You only need to call this once and only once.");
					return;
				}
				isInitCalled = true;
				if (Application.isEditor)
				{
					OnDLLLoaded onDLLLoaded = null;
					IntPtr method_ptr = (IntPtr)0;
					((Delegate)onDLLLoaded).m_target = _003C_003Ec__DisplayClass35_1;
					((Delegate)onDLLLoaded).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass35_0._003CInit_003Eb__0);
					((Delegate)onDLLLoaded).method_ptr = method_ptr;
					OnDLLLoadedDelegate = onDLLLoaded;
					EditorFacebookLoader component = ComponentFactory.GetComponent<EditorFacebookLoader>();
					CodelessCrawler component2 = ComponentFactory.GetComponent<CodelessCrawler>();
					CodelessUIInteractEvent component3 = ComponentFactory.GetComponent<CodelessUIInteractEvent>();
					return;
				}
				FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
				int num = (int)(currentPlatform - 1);
				bool flag = num < 3;
				bool flag2 = !flag;
				int num2 = num - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					NotSupportedException ex = new NotSupportedException("The facebook sdk does not support this platform");
					goto IL_01ef;
				}
				int num3 = 25280512 + 664;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X9_v11 (System.Int32)+v212 @ X8_v33 (System.Int32)*4]");
				object obj3 = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v333 @ X8_v35 (should have been resolved before IL gen)");
			}
			ArgumentException ex2 = new ArgumentException("appId cannot be null or empty!");
			goto IL_01ef;
			IL_01ef:
			throw new TypeLoadException();
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xD29C48", Offset = "0xD29C48", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC8BC8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BEF]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_005B;\n\tv65 = *([v59 @ X8_v7+B0]);\n\tv66 = 0;\n\tv67 = v65 + 8;\n\tv69 = *([v116 @ X11_v5-8]);\n\tv122 = v69 == v62;\n\tif (v122) goto L_004B;\n\tv102 = v117 + 1;\n\tv181 = v102 < v61;\n\tv96 = ~v181;\n\tv99 = v116 + 0x10;\n\tv72 = ~v96;\n\tif (v72) goto L_FFFFFFFF;\n\tv103 = 5;\n\tv104 = v56;\n\tv105 = 0x8909C4(v104, v62, v103, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005B;\nL_004B:\n\tv182 = *([v116 @ X11_v5]);\n\tv183 = v182 + 5;\n\tv184 = v183 << 4;\n\tv185 = v59 + v184;\n\tv186 = v185 + 0x130;\nL_005B:\n\tFacebook.Unity.IFacebook::LogInWithPublishPermissions(v55, permissions, callback);\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogInWithPublishPermissions(IEnumerable<string> permissions = null, FacebookDelegate<ILoginResult> callback = null)
		{
			IFacebook facebookImpl = FacebookImpl;
			facebookImpl.LogInWithPublishPermissions(permissions, callback);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xD29D34", Offset = "0xD29D34", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBA468]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BF0]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv55 = Facebook.Unity.FB::get_FacebookImpl();\n\tv59 = *([v55 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv63 = *([v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v63) goto L_0049;\n\tv116 = *([v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0034:\n\tv122 = *([v116 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v122) goto L_004C;\n\tv117 = v117 + 1;\n\tv181 = v117 < *([v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv96 = ~v181;\n\tv116 = v116 + 0x10;\n\tv72 = ~v96;\n\tif (v72) goto L_0034;\nL_0049:\n\tv188 = 0x8909C4(v55, Facebook.Unity.IFacebook, 6, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0050;\nL_004C:\n\tv183 = *([v116 @ X11_v5]) + 6;\n\tv184 = v183 << 4;\n\tv185 = v59 + v184;\n\tv188 = v185 + 0x130;\nL_0050:\n\tv132 = *([v188 @ X0_v6]);\n\tv130 = *([v188 @ X0_v6+8]);\n\t// 91 IndirectJump v132 @ X4_v1, v55 @ X0_v4 (Facebook.Unity.IFacebook), v55 @ X0_v4 (Facebook.Unity.IFacebook), permissions @ X0 (System.Collections.Generic.IEnumerable`1<System.String>), callback @ X1 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>), v130 @ X3_v1, v132 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogInWithReadPermissions(IEnumerable<string> permissions = null, FacebookDelegate<ILoginResult> callback = null)
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v132 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xD29E20", Offset = "0xD29E20", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EECAC8]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BF1]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Facebook.Unity.FB::get_FacebookImpl();\n\tv53 = *([v49 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv57 = *([v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v57) goto L_0045;\n\tv110 = *([v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0030:\n\tv116 = *([v110 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v116) goto L_0048;\n\tv111 = v111 + 1;\n\tv167 = v111 < *([v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv90 = ~v167;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_0030;\nL_0045:\n\tv174 = 0x8909C4(v49, Facebook.Unity.IFacebook, 7, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004C;\nL_0048:\n\tv169 = *([v110 @ X11_v5]) + 7;\n\tv170 = v169 << 4;\n\tv171 = v53 + v170;\n\tv174 = v171 + 0x130;\nL_004C:\n\tv129 = *([v174 @ X0_v6]);\n\tv151 = *([v174 @ X0_v6+8]);\n\t// 83 IndirectJump v129 @ X2_v2, v49 @ X0_v4 (Facebook.Unity.IFacebook), v49 @ X0_v4 (Facebook.Unity.IFacebook), v151 @ X1_v2, v129 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogOut()
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 7;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xD29EF4", Offset = "0xD29EF4", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1F038B8]);\n\tv43 = *([v42 @ X8_v16]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, actionType, objectId, to, data, title, callback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2023BF2]) = v56;\nL_0025:\n\tgoto L_002B;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, actionType, objectId, to, data, title, callback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\nL_002B:\n\tv70 = Facebook.Unity.FB::get_FacebookImpl();\n\tv75 = 0;\n\tv78 = 0x115C1AC(&v75 @ stack_-58_v1, actionType, Il2CppMethodInfo, to, data, title, callback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv81 = *([v70 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv86 = *([v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v86) goto L_005B;\n\tv142 = *([v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0046:\n\tv147 = *([v142 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v147) goto L_005E;\n\tv141 = v141 + 1;\n\tv233 = v141 < *([v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv120 = ~v233;\n\tv142 = v142 + 0x10;\n\tv96 = ~v120;\n\tif (v96) goto L_0046;\nL_005B:\n\tv241 = 0x8909C4(v70, Facebook.Unity.IFacebook, 8, to, data, title, callback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0070;\nL_005E:\n\tv235 = *([v142 @ X11_v5]) + 8;\n\tv236 = v235 << 4;\n\tv237 = v81 + v236;\n\tv241 = v237 + 0x130;\nL_0070:\n\t*([v241 @ X0_v9])(v211, v70, message, 0, objectId, to, 0, 0, 0, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AppRequest(string message, OGActionType actionType, string objectId, IEnumerable<string> to, string data = "", string title = "", FacebookDelegate<IAppRequestResult> callback = null)
		{
			//IL_0017: Expected O, but got I4
			//IL_002e: Expected I, but got O
			//IL_0069: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_0108: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_00b5: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C1AC (inside System.Nullable`1<System.Int32>::Unbox +0xA8)");
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ce;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj2 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ce;
			}
			object obj3 = obj2 + 8;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num3;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_014b;
			IL_00ce:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014b;
			IL_014b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v241 @ X0_v9] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xD2A050", Offset = "0xD2A050", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv48 = *([1EAFA00]);\n\tv49 = *([v48 @ X8_v16]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, actionType, objectId, filters, excludeIds, maxRecipients, data, title, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023BF3]) = v61;\nL_0028:\n\tgoto L_002E;\n\tv68 = *([v64 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_002E;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v64, actionType, objectId, filters, excludeIds, maxRecipients, data, title, v51, v52, v53, v54, v55, v56, v57, v58);\nL_002E:\n\tv75 = Facebook.Unity.FB::get_FacebookImpl();\n\tv80 = 0;\n\tv83 = System.Nullable`1<Facebook.Unity.OGActionType>::.ctor(&v80 @ stack_-68_v1 (System.Nullable`1<Facebook.Unity.OGActionType>), actionType);\n\tv86 = *([v75 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv92 = *([v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v92) goto L_005F;\n\tv148 = *([v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_004A:\n\tv153 = *([v148 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v153) goto L_0062;\n\tv147 = v147 + 1;\n\tv243 = v147 < *([v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv126 = ~v243;\n\tv148 = v148 + 0x10;\n\tv102 = ~v126;\n\tif (v102) goto L_004A;\nL_005F:\n\tv251 = 0x8909C4(v75, Facebook.Unity.IFacebook, 8, filters, excludeIds, maxRecipients, data, title, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_0074;\nL_0062:\n\tv245 = *([v148 @ X11_v5]) + 8;\n\tv246 = v245 << 4;\n\tv247 = v86 + v246;\n\tv251 = v247 + 0x130;\nL_0074:\n\t*([v251 @ X0_v9])(v219, v75, message, 0, objectId, 0, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AppRequest(string message, OGActionType actionType, string objectId, IEnumerable<object> filters = null, IEnumerable<string> excludeIds = null, int? maxRecipients = null, string data = "", string title = "", FacebookDelegate<IAppRequestResult> callback = null)
		{
			//IL_0032: Expected I, but got O
			//IL_006d: Expected O, but got I
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_010c: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_00b9: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			OGActionType? oGActionType = null;
			oGActionType = actionType;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00d2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v9 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00d2;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_00d2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
			IL_014f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v251 @ X0_v9] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0xD2A1BC", Offset = "0xD2A1BC", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1EB2940]);\n\tv47 = *([v46 @ X8_v14]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, to, filters, excludeIds, maxRecipients, data, title, callback, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2023BF4]) = v59;\nL_0027:\n\tgoto L_002D;\n\tv66 = *([v62 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, to, filters, excludeIds, maxRecipients, data, title, callback, v49, v50, v51, v52, v53, v54, v55, v56);\nL_002D:\n\tv73 = Facebook.Unity.FB::get_FacebookImpl();\n\tv77 = *([v73 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv81 = *([v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v81) goto L_0055;\n\tv134 = *([v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0040:\n\tv140 = *([v134 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v140) goto L_0058;\n\tv135 = v135 + 1;\n\tv229 = v135 < *([v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv114 = ~v229;\n\tv134 = v134 + 0x10;\n\tv90 = ~v114;\n\tif (v90) goto L_0040;\nL_0055:\n\tv237 = 0x8909C4(v73, Facebook.Unity.IFacebook, 8, excludeIds, maxRecipients, data, title, callback, v49, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_006A;\nL_0058:\n\tv231 = *([v134 @ X11_v5]) + 8;\n\tv232 = v231 << 4;\n\tv233 = v77 + v232;\n\tv237 = v233 + 0x130;\nL_006A:\n\t*([v237 @ X0_v6])(v205, v73, message, 0, 0, to, filters, excludeIds, maxRecipients, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AppRequest(string message, IEnumerable<string> to = null, IEnumerable<object> filters = null, IEnumerable<string> excludeIds = null, int? maxRecipients = null, string data = "", string title = "", FacebookDelegate<IAppRequestResult> callback = null)
		{
			//IL_001b: Expected I, but got O
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v237 @ X0_v6] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xD2A300", Offset = "0xD2A300", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EE6388]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, contentTitle, contentDescription, photoURL, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023BF5]) = v50;\nL_0021:\n\tgoto L_0027;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, contentTitle, contentDescription, photoURL, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0027:\n\tv64 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_0067;\n\tv74 = *([v68 @ X8_v7+B0]);\n\tv75 = 0;\n\tv76 = v74 + 8;\n\tv78 = *([v125 @ X11_v5-8]);\n\tv131 = v78 == v71;\n\tif (v131) goto L_0051;\n\tv111 = v126 + 1;\n\tv202 = v111 < v70;\n\tv105 = ~v202;\n\tv108 = v125 + 0x10;\n\tv81 = ~v105;\n\tif (v81) goto L_FFFFFFFF;\n\tv112 = 9;\n\tv113 = v65;\n\tv114 = 0x8909C4(v113, v71, v112, photoURL, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0067;\nL_0051:\n\tv203 = *([v125 @ X11_v5]);\n\tv204 = v203 + 9;\n\tv205 = v204 << 4;\n\tv206 = v68 + v205;\n\tv207 = v206 + 0x130;\nL_0067:\n\tFacebook.Unity.IFacebook::ShareLink(v64, contentURL, contentTitle, contentDescription, photoURL, callback);\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShareLink(Uri contentURL = null, string contentTitle = "", string contentDescription = "", Uri photoURL = null, FacebookDelegate<IShareResult> callback = null)
		{
			IFacebook facebookImpl = FacebookImpl;
			facebookImpl.ShareLink(contentURL, contentTitle, contentDescription, photoURL, callback);
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0xD2A40C", Offset = "0xD2A40C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1EDFD10]);\n\tv47 = *([v46 @ X8_v14]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, link, linkName, linkCaption, linkDescription, picture, mediaSource, callback, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2023BF6]) = v59;\nL_0027:\n\tgoto L_002D;\n\tv66 = *([v62 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, link, linkName, linkCaption, linkDescription, picture, mediaSource, callback, v49, v50, v51, v52, v53, v54, v55, v56);\nL_002D:\n\tv73 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_0068;\n\tv83 = *([v77 @ X8_v7+B0]);\n\tv84 = 0;\n\tv85 = v83 + 8;\n\tv87 = *([v134 @ X11_v5-8]);\n\tv140 = v87 == v80;\n\tif (v140) goto L_0057;\n\tv120 = v135 + 1;\n\tv223 = v120 < v79;\n\tv114 = ~v223;\n\tv117 = v134 + 0x10;\n\tv90 = ~v114;\n\tif (v90) goto L_FFFFFFFF;\n\tv121 = 0xA;\n\tv122 = v74;\n\tv123 = 0x8909C4(v122, v80, v121, linkCaption, linkDescription, picture, mediaSource, callback, v49, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_0068;\nL_0057:\n\tv224 = *([v134 @ X11_v5]);\n\tv225 = v224 + 0xA;\n\tv226 = v225 << 4;\n\tv227 = v77 + v226;\n\tv228 = v227 + 0x130;\nL_0068:\n\tFacebook.Unity.IFacebook::FeedShare(v73, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void FeedShare(string toId = "", Uri link = null, string linkName = "", string linkCaption = "", string linkDescription = "", Uri picture = null, string mediaSource = "", FacebookDelegate<IShareResult> callback = null)
		{
			IFacebook facebookImpl = FacebookImpl;
			facebookImpl.FeedShare(toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, null);
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0xD20BEC", Offset = "0xD20BEC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1F0DFF8]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, method, callback, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023BF7]) = v47;\nL_001B:\n\tv50 = System.String::IsNullOrEmpty(query);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_006E;\n\tgoto L_002C;\n\tv64 = *([v56 @ X0_v10 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v56, v49, callback, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002C:\n\tv71 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_006A;\n\tv105 = *([v89 @ X8_v14+B0]);\n\tv106 = 0;\n\tv107 = v105 + 8;\n\tv109 = *([v156 @ X11_v5-8]);\n\tv162 = v109 == v92;\n\tif (v162) goto L_0056;\n\tv142 = v157 + 1;\n\tv228 = v142 < v91;\n\tv136 = ~v228;\n\tv139 = v156 + 0x10;\n\tv112 = ~v136;\n\tif (v112) goto L_FFFFFFFF;\n\tv143 = 0xB;\n\tv144 = v80;\n\tv145 = 0x8909C4(v144, v92, v143, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006A;\nL_0056:\n\tv229 = *([v156 @ X11_v5]);\n\tv230 = v229 + 0xB;\n\tv231 = v230 << 4;\n\tv232 = v89 + v231;\n\tv233 = v232 + 0x130;\nL_006A:\n\tFacebook.Unity.IFacebook::API(v71, query, method, formData, callback);\nL_006E:\n\tv63 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v63, \"query\", \"The query param cannot be null or empty\");\n\tthrow v63;\n\tthrow System.NullReferenceException;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void API(string query, HttpMethod method, FacebookDelegate<IGraphResult> callback = null, IDictionary<string, string> formData = null)
		{
			if (!string.IsNullOrEmpty(query))
			{
				IFacebook facebookImpl = FacebookImpl;
				facebookImpl.API(query, method, formData, callback);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("query", "The query param cannot be null or empty");
			throw ex;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0xD2A54C", Offset = "0xD2A54C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1F0B9E0]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, method, callback, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023BF8]) = v47;\nL_001B:\n\tv50 = System.String::IsNullOrEmpty(query);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_006E;\n\tgoto L_002C;\n\tv64 = *([v56 @ X0_v10 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v56, v49, callback, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002C:\n\tv71 = Facebook.Unity.FB::get_FacebookImpl();\n\tv89 = *([v71 @ X0_v12 (Facebook.Unity.IFacebook)]);\n\tv93 = *([v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v93) goto L_0054;\n\tv156 = *([v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_003F:\n\tv162 = *([v156 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v162) goto L_0057;\n\tv157 = v157 + 1;\n\tv228 = v157 < *([v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv136 = ~v228;\n\tv156 = v156 + 0x10;\n\tv112 = ~v136;\n\tif (v112) goto L_003F;\nL_0054:\n\tv235 = 0x8909C4(v71, Facebook.Unity.IFacebook, 0xC, formData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005B;\nL_0057:\n\tv230 = *([v156 @ X11_v5]) + 0xC;\n\tv231 = v230 << 4;\n\tv232 = v89 + v231;\n\tv235 = v232 + 0x130;\nL_005B:\n\tv174 = *([v235 @ X0_v13]);\n\tv172 = *([v235 @ X0_v13+8]);\n\t// 106 IndirectJump v174 @ X6_v1, v71 @ X0_v12 (Facebook.Unity.IFacebook), v71 @ X0_v12 (Facebook.Unity.IFacebook), query @ X0 (System.String), method @ X1 (Facebook.Unity.HttpMethod), formData @ X3 (UnityEngine.WWWForm), callback @ X2 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>), v172 @ X5_v1, v174 @ X6_v1, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\nL_006E:\n\tv63 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v63, \"query\", \"The query param cannot be null or empty\");\n\tthrow v63;\n\tthrow System.NullReferenceException;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void API(string query, HttpMethod method, FacebookDelegate<IGraphResult> callback, WWWForm formData)
		{
			//IL_0020: Expected I, but got O
			//IL_01a3: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00fa: Expected O, but got I
			//IL_0109: Expected O, but got I
			//IL_00a7: Expected O, but got I
			object obj4 = default(object);
			if (!string.IsNullOrEmpty(query))
			{
				IFacebook facebookImpl = FacebookImpl;
				IntPtr intPtr = (IntPtr)facebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v14 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c0;
				}
				object obj2 = obj + 12;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_018b;
			}
			ArgumentNullException ex = new ArgumentNullException("query", "The query param cannot be null or empty");
			throw ex;
			IL_018b:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X0_v13+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v174 @ X6_v1 (should have been resolved before IL gen)");
			return;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_018b;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0xD2A6AC", Offset = "0xD2A6AC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB2DD8]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023BF9]) = v39;\nL_0019:\n\tgoto L_001F;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_001F;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv53 = Facebook.Unity.FB::get_FacebookImpl();\n\tgoto L_0030;\n\tv60 = *([1EDE4B8]);\n\tv61 = *([v60 @ X8_v15]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = 0 | 1;\n\t*([2021D31]) = v65;\nL_0030:\n\tgoto L_0041;\n\tv70 = *([v66 @ X0_v6 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 52 Jump @b24\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v66, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv74 = Facebook.Unity.FB;\nL_0041:\n\tgoto L_0070;\n\tv89 = *([v81 @ X8_v9+B0]);\n\tv90 = 0;\n\tv91 = v89 + 8;\n\tv93 = *([v140 @ X11_v5-8]);\n\tv146 = v93 == v85;\n\tif (v146) goto L_0061;\n\tv126 = v141 + 1;\n\tv203 = v126 < v84;\n\tv120 = ~v203;\n\tv123 = v140 + 0x10;\n\tv96 = ~v120;\n\tif (v96) goto L_FFFFFFFF;\n\tv127 = 0xD;\n\tv128 = v56;\n\tv129 = 0x8909C4(v128, v85, v127, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0070;\nL_0061:\n\tv204 = *([v140 @ X11_v5]);\n\tv205 = v204 + 0xD;\n\tv206 = v205 << 4;\n\tv207 = v81 + v206;\n\tv208 = v207 + 0x130;\nL_0070:\n\tFacebook.Unity.IFacebook::ActivateApp(v53, v80.<AppId>k__BackingField);\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ActivateApp()
		{
			IFacebook facebookImpl = FacebookImpl;
			facebookImpl.ActivateApp(AppId);
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0xD2A7D8", Offset = "0xD2A7D8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFE6C8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BFA]) = v38;\nL_0013:\n\tv39 = callback == 0;\n\tif (v39) goto L_0050;\n\tgoto L_0021;\n\tv50 = *([v42 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv57 = Facebook.Unity.FB::get_FacebookImpl();\n\tv124 = *([v57 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv112 = *([v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v112) goto L_0049;\n\tv168 = *([v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0034:\n\tv174 = *([v168 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v174) goto L_0052;\n\tv169 = v169 + 1;\n\tv179 = v169 < *([v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv150 = ~v179;\n\tv168 = v168 + 0x10;\n\tv134 = ~v150;\n\tif (v134) goto L_0034;\nL_0049:\n\tv186 = 0x8909C4(v57, Facebook.Unity.IFacebook, 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0056;\nL_0050:\n\treturn;\nL_0052:\n\tv181 = *([v168 @ X11_v5]) + 0xE;\n\tv182 = v181 << 4;\n\tv183 = v124 + v182;\n\tv186 = v183 + 0x130;\nL_0056:\n\tv59 = *([v186 @ X0_v6]);\n\tv69 = *([v186 @ X0_v6+8]);\n\t// 95 IndirectJump v59 @ X3_v1, v57 @ X0_v4 (Facebook.Unity.IFacebook), v57 @ X0_v4 (Facebook.Unity.IFacebook), callback @ X0 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>), v69 @ X2_v2, v59 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_0020: Expected I, but got O
			//IL_016e: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00fb: Expected O, but got I
			//IL_010a: Expected O, but got I
			//IL_00a7: Expected O, but got I
			if (callback == null)
			{
				return;
			}
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c0;
			}
			object obj2 = obj + 14;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0156;
			IL_0156:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v59 @ X3_v1 (should have been resolved before IL gen)");
			return;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0156;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xD2A8C4", Offset = "0xD2A8C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void ClearAppLink()
		{
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0xD23F44", Offset = "0xD23F44", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EFCB10]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, valueToSum, parameters, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023BFB]) = v44;\nL_001D:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, valueToSum, parameters, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tv58 = Facebook.Unity.FB::get_FacebookImpl();\n\tv62 = *([v58 @ X0_v4 (Facebook.Unity.IFacebook)]);\n\tv66 = *([v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v66) goto L_004B;\n\tv119 = *([v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0036:\n\tv125 = *([v119 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v125) goto L_004E;\n\tv120 = v120 + 1;\n\tv188 = v120 < *([v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv99 = ~v188;\n\tv119 = v119 + 0x10;\n\tv75 = ~v99;\n\tif (v75) goto L_0036;\nL_004B:\n\tv195 = 0x8909C4(v58, Facebook.Unity.IFacebook, 0xF, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0052;\nL_004E:\n\tv190 = *([v119 @ X11_v5]) + 0xF;\n\tv191 = v190 << 4;\n\tv192 = v62 + v191;\n\tv195 = v192 + 0x130;\nL_0052:\n\tv137 = *([v195 @ X0_v6]);\n\tv135 = *([v195 @ X0_v6+8]);\n\t// 95 IndirectJump v137 @ X5_v1, v58 @ X0_v4 (Facebook.Unity.IFacebook), v58 @ X0_v4 (Facebook.Unity.IFacebook), logEvent @ X0 (System.String), valueToSum @ X1 (System.Nullable`1<System.Single>), parameters @ X2 (System.Collections.Generic.Dictionary`2<System.String, System.Object>), v135 @ X4_v1, v137 @ X5_v1, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogAppEvent(string logEvent, float? valueToSum = null, Dictionary<string, object> parameters = null)
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v137 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xD2A8C8", Offset = "0xD2A8C8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EC4230]);\n\tv29 = *([v28 @ X8_v9]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, currency, parameters, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023BFC]) = v45;\nL_001A:\n\tv48 = 0xEA4608(&logPurchase @ X0 (System.Decimal), 0, parameters, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = System.Single::Parse(v48);\n\tgoto L_002D;\n\tv58 = *([v54 @ X0_v4+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002D;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, v49, parameters, methodInfo, v31, v32, v33, v34, v50, v36, v37, v38, v39, v40, v41, v42);\nL_002D:\n\tFacebook.Unity.FB::LogPurchase(v50, parameters, methodInfo);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogPurchase(decimal logPurchase, string currency = null, Dictionary<string, object> parameters = null)
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA4608 (inside System.Decimal::FCallDivide +0x140)");
			string s = default(string);
			float logPurchase2 = float.Parse(s);
			IntPtr intPtr = default(IntPtr);
			LogPurchase(logPurchase2, (string)(object)parameters, (Dictionary<string, object>)(long)intPtr);
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xD2A970", Offset = "0xD2A970", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED6F10]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, parameters, methodInfo, v30, v31, v32, v33, v34, logPurchase, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023BFD]) = v44;\nL_0019:\n\tv71 = System.String::IsNullOrEmpty(currency);\n\tv53 = v71 == 0;\n\tv60 = ~v53;\n\tv61 = ~v60;\n\tif (v61) goto L_002F;\n\tgoto L_002F;\nL_002F:\n\tgoto L_0036;\n\tv67 = *([v56 @ X8_v5+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0036;\n\tv75 = v56;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v75, v46, methodInfo, v30, v31, v32, v33, v34, logPurchase, v35, v36, v37, v38, v39, v40, v41);\nL_0036:\n\tv74 = Facebook.Unity.FB::get_FacebookImpl();\n\tv79 = *([v74 @ X0_v5 (Facebook.Unity.IFacebook)]);\n\tv83 = *([v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v83) goto L_005E;\n\tv126 = *([v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0049:\n\tv137 = *([v126 @ X11_v5-8]) == Facebook.Unity.IFacebook;\n\tif (v137) goto L_0061;\n\tv128 = v128 + 1;\n\tv198 = v128 < *([v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv113 = ~v198;\n\tv126 = v126 + 0x10;\n\tv107 = ~v113;\n\tif (v107) goto L_0049;\nL_005E:\n\tv205 = 0x8909C4(v74, Facebook.Unity.IFacebook, 0x10, v30, v31, v32, v33, v34, logPurchase, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0065;\nL_0061:\n\tv200 = *([v126 @ X11_v5]) + 0x10;\n\tv201 = v200 << 4;\n\tv202 = v79 + v201;\n\tv205 = v202 + 0x130;\nL_0065:\n\tv149 = *([v205 @ X0_v7]);\n\tv147 = *([v205 @ X0_v7+8]);\n\t// 114 IndirectJump v149 @ X4_v1, v74 @ X0_v5 (Facebook.Unity.IFacebook), v74 @ X0_v5 (Facebook.Unity.IFacebook), v64 @ X20_v2 (System.String), parameters @ X1 (System.Collections.Generic.Dictionary`2<System.String, System.Object>), v147 @ X3_v1, v149 @ X4_v1, v32 @ X5, v33 @ X6, v34 @ X7, logPurchase @ V0 (System.Single), v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogPurchase(float logPurchase, string currency = null, Dictionary<string, object> parameters = null)
		{
			//IL_0029: Expected I, but got O
			//IL_019e: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_0103: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_00b0: Expected O, but got I
			if (string.IsNullOrEmpty(currency))
			{
				string text = "USD";
			}
			IFacebook facebookImpl = FacebookImpl;
			IntPtr intPtr = (IntPtr)facebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v6 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c9;
			}
			object obj2 = obj + 16;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0186;
			IL_0186:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X0_v7+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v149 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0186;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xD2AA90", Offset = "0xD2AA90", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC5DA8]);\n\tv19 = *([v18 @ X8_v31]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023BFE]) = v39;\nL_0019:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = Facebook.Unity.FB;\nL_0027:\n\tgoto L_0031;\n\tv62 = *([1EE6770]);\n\tv63 = *([v62 @ X8_v27]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv67 = 0 | 1;\n\t*([2023C31]) = v67;\nL_0031:\n\tv71 = v53.facebook == 0;\n\tif (v71) goto L_006C;\n\tgoto L_003D;\n\tv82 = *([v72 @ X0_v12 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_003D;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v72, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tv89 = Facebook.Unity.FB::get_FacebookImpl();\n\tv154 = *([v89 @ X0_v14 (Facebook.Unity.IFacebook)]);\n\tv143 = *([v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v143) goto L_0065;\n\tv213 = *([v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0050:\n\tv219 = *([v213 @ X11_v6-8]) == Facebook.Unity.IFacebook;\n\tif (v219) goto L_006F;\n\tv214 = v214 + 1;\n\tv249 = v214 < *([v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv194 = ~v249;\n\tv213 = v213 + 0x10;\n\tv178 = ~v194;\n\tif (v178) goto L_0050;\nL_0065:\n\tv256 = 0x8909C4(v89, Facebook.Unity.IFacebook, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0076;\nL_006C:\n\tv140 = System.String::Format(\"Using Facebook Unity SDK v{0}\", \"7.18.0\");\n\tgoto L_0086;\nL_006F:\n\tv251 = *([v213 @ X11_v6]) + 3;\n\tv252 = v251 << 4;\n\tv253 = v154 + v252;\n\tv256 = v253 + 0x130;\nL_0076:\n\t*([v256 @ X0_v16])(v261, v89, *([v256 @ X0_v16+8]), 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv140 = System.String::Format(\"Using Facebook Unity SDK v{0} with {1}\", \"7.18.0\", v261);\nL_0086:\n\tgoto L_0094;\n\tv159 = *([v149 @ X8_v12+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0094;\n\tv202 = v149;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v202, v132, v100, v92, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0094:\n\tFacebook.Unity.FacebookLogger::Info(v140);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void LogVersion()
		{
			//IL_0020: Expected I, but got O
			//IL_005b: Expected O, but got I
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_0113: Expected O, but got I
			//IL_0122: Expected O, but got I
			//IL_00a7: Expected O, but got I
			if (facebook != null)
			{
				IFacebook facebookImpl = FacebookImpl;
				IntPtr intPtr = (IntPtr)facebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v17 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c0;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_016a;
			}
			string msg = string.Format("Using Facebook Unity SDK v{0}", "7.18.0");
			goto IL_012c;
			IL_016a:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v256 @ X0_v16] (should have been resolved before IL gen)");
			object arg = default(object);
			msg = string.Format("Using Facebook Unity SDK v{0} with {1}", "7.18.0", arg);
			goto IL_012c;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016a;
			IL_012c:
			FacebookLogger.Info(msg);
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xD2AD58", Offset = "0xD2AD58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FB()
		{
		}
	}
}
