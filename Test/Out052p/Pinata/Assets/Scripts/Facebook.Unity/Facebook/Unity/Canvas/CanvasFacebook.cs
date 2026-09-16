using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x200006D")]
	internal sealed class CanvasFacebook : FacebookBase, ICanvasFacebookImplementation, IPayFacebook, IFacebook, ICanvasFacebookResultHandler, IFacebookResultHandler
	{
		[Token(Token = "0x200006E")]
		private class CanvasUIMethodCall<T> : MethodCall<T> where T : IResult
		{
			[Token(Token = "0x40000B2")]
			[FieldOffset(Offset = "0x0")]
			private CanvasFacebook canvasImpl;

			[Token(Token = "0x40000B3")]
			[FieldOffset(Offset = "0x0")]
			private string callbackMethod;

			[Token(Token = "0x60002C4")]
			[Address(RVA = "0xD92DFC", Offset = "0xD92DFC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = Facebook.Unity.MethodCall`1<T>::.ctor(this, canvasImpl, methodName);\n\tthis.canvasImpl = canvasImpl;\n\tthis.callbackMethod = callbackMethod;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public CanvasUIMethodCall(CanvasFacebook canvasImpl, string methodName, string callbackMethod)
				: base((FacebookBase)canvasImpl, methodName)
			{
				this.canvasImpl = canvasImpl;
				this.callbackMethod = callbackMethod;
			}

			[Token(Token = "0x60002C5")]
			[Address(RVA = "0xD92E50", Offset = "0xD92E50", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = Facebook.Unity.MethodCall`1<T>::get_MethodName(this);\n\tv46 = Facebook.Unity.MethodCall`1<T>::get_Callback(this);\n\tv57 = Il2CppMethodInfo;\n\tv58 = *([v57 @ X4_v1 (Il2CppMethodInfo)]);\n\t// 41 IndirectJump v58 @ X5_v1, this @ X0 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<T>), this @ X0 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<T>), v26 @ X0_v3 (System.String), args @ X1 (Facebook.Unity.MethodArguments), v46 @ X0_v5 (Facebook.Unity.FacebookDelegate`1<T>), methodof(Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<T>::UI), v58 @ X5_v1, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override void Call(MethodArguments args)
			{
				//IL_0022: Expected O, but got I
				string methodName = base.MethodName;
				FacebookDelegate<T> callback = base.Callback;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X5_v1 (should have been resolved before IL gen)");
			}

			[Token(Token = "0x60002C6")]
			[Address(RVA = "0xD92ED8", Offset = "0xD92ED8", Length = "0x20C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1ECB4E8]);\n\tv37 = *([v36 @ X8_v27]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, method, args, callback, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20240B9]) = v52;\nL_001C:\n\tv53 = this.canvasImpl;\n\tv55 = v53.canvasJSWrapper;\n\tv137 = *([v55 @ X24_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv140 = *([v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v140) goto L_0046;\n\tv210 = *([v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_0031:\n\tv215 = *([v210 @ X11_v13-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v215) goto L_0049;\n\tv209 = v209 + 1;\n\tv282 = v209 < *([v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv191 = ~v282;\n\tv210 = v210 + 0x10;\n\tv175 = ~v191;\n\tif (v175) goto L_0031;\nL_0046:\n\tv289 = 0x8909C4(v55, Facebook.Unity.Canvas.ICanvasJSWrapper, 1, callback, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0050;\nL_0049:\n\tv284 = *([v210 @ X11_v13]) + 1;\n\tv285 = v284 << 4;\n\tv286 = v137 + v285;\n\tv289 = v286 + 0x130;\nL_0050:\n\t*([v289 @ X0_v6])(v294, v55, *([v289 @ X0_v6+8]), v288, callback, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv113 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v113, args);\n\tv130 = this.canvasImpl;\n\tFacebook.Unity.MethodArguments::AddString(v113, \"app_id\", v130.appId);\n\tFacebook.Unity.MethodArguments::AddString(v113, \"method\", method);\n\tv131 = this.canvasImpl;\n\tv115 = Facebook.Unity.CallbackManager::AddFacebookDelegate(v131.<CallbackManager>k__BackingField, callback);\n\tv132 = this.canvasImpl;\n\tv128 = v132.canvasJSWrapper;\n\tv116 = Facebook.Unity.MethodArguments::ToJsonString(v113);\n\tv310 = *([v128 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv311 = this.callbackMethod;\n\tv265 = *([v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v265) goto L_00A6;\n\tv355 = *([v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_0091:\n\tv360 = *([v355 @ X11_v8-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v360) goto L_00A9;\n\tv354 = v354 + 1;\n\tv365 = v354 < *([v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv336 = ~v365;\n\tv355 = v355 + 0x10;\n\tv320 = ~v336;\n\tif (v320) goto L_0091;\nL_00A6:\n\tv372 = 0x8909C4(v128, Facebook.Unity.Canvas.ICanvasJSWrapper, 8, 0, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AD;\nL_00A9:\n\tv367 = *([v355 @ X11_v8]) + 8;\n\tv368 = v367 << 4;\n\tv369 = v310 + v368;\n\tv372 = v369 + 0x130;\nL_00AD:\n\tv225 = *([v372 @ X0_v17]);\n\tv223 = *([v372 @ X0_v17+8]);\n\t// 189 IndirectJump v225 @ X5_v1, v128 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), v128 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), v116 @ X0_v16 (System.String), v115 @ X0_v14 (System.String), v311 @ X19_v2 (System.String), v223 @ X4_v1, v225 @ X5_v1, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void UI(string method, MethodArguments args, FacebookDelegate<T> callback = null)
			{
				//IL_001f: Expected I, but got O
				//IL_00d2: Expected O, but got I4
				//IL_005a: Expected O, but got I
				//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e5: Expected O, but got Unknown
				//IL_0102: Expected O, but got I
				//IL_0111: Expected O, but got I
				//IL_00a6: Expected O, but got I
				//IL_01a7: Expected I, but got O
				//IL_0341: Expected O, but got I
				//IL_01ec: Expected O, but got I
				//IL_0269: Unknown result type (might be due to invalid IL or missing references)
				//IL_026e: Expected O, but got Unknown
				//IL_028b: Expected O, but got I
				//IL_029a: Expected O, but got I
				//IL_0238: Expected O, but got I
				CanvasFacebook canvasFacebook = canvasImpl;
				ICanvasJSWrapper canvasJSWrapper = canvasFacebook.canvasJSWrapper;
				IntPtr intPtr = (IntPtr)canvasJSWrapper;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bf;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X11_v13-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00bf;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				object obj5 = args;
				goto IL_02d8;
				IL_00bf:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				obj5 = 1;
				goto IL_02d8;
				IL_02d8:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v289 @ X0_v6] (should have been resolved before IL gen)");
				MethodArguments methodArguments = new MethodArguments(args);
				CanvasFacebook canvasFacebook2 = canvasImpl;
				methodArguments.AddString("app_id", canvasFacebook2.appId);
				methodArguments.AddString("method", method);
				CanvasFacebook canvasFacebook3 = canvasImpl;
				string text = canvasFacebook3.CallbackManager.AddFacebookDelegate(callback);
				CanvasFacebook canvasFacebook4 = canvasImpl;
				ICanvasJSWrapper canvasJSWrapper2 = canvasFacebook4.canvasJSWrapper;
				string text2 = methodArguments.ToJsonString();
				IntPtr intPtr2 = (IntPtr)canvasJSWrapper2;
				string text3 = callbackMethod;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0251;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
				object obj6 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ X11_v8-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v21 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0251;
				}
				object obj7 = obj6 + 8;
				int num6 = (int)((long)(IntPtr)obj7 << 4);
				object obj8 = (long)intPtr2 + (long)num6;
				object obj9 = (long)(IntPtr)obj8 + 304L;
				goto IL_0329;
				IL_0329:
				object obj10 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ X0_v17+8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v225 @ X5_v1 (should have been resolved before IL gen)");
				return;
				IL_0251:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0329;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200006F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000B4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000B5")]
			public static Utilities.Callback<ResultContainer> _003C_003E9__40_0;

			[Token(Token = "0x60002C7")]
			[Address(RVA = "0xD20F10", Offset = "0xD20F10", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE0908]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023B7B]) = v37;\nL_0015:\n\tv41 = new Facebook.Unity.Canvas.CanvasFacebook+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60002C8")]
			[Address(RVA = "0xD20F74", Offset = "0xD20F74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnFacebookAuthResponseChange_003Eb__40_0(ResultContainer formattedResponse)
			{
				LoginResult loginResult = new LoginResult(formattedResponse);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @D34E90 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x2C)");
			}
		}

		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x28")]
		private string appId;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x30")]
		private string appLinkUrl;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x38")]
		private ICanvasJSWrapper canvasJSWrapper;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x40")]
		private HideUnityDelegate onHideUnityDelegate;

		[CompilerGenerated]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x48")]
		private bool _003CLimitEventUsage_003Ek__BackingField;

		[Token(Token = "0x1700008B")]
		public override bool LimitEventUsage
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0xD1DDA8", Offset = "0xD1DDA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LimitEventUsage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LimitEventUsage;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0xD1DDB0", Offset = "0xD1DDB0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LimitEventUsage>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CLimitEventUsage_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700008C")]
		public override string SDKName
		{
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0xD1DDBC", Offset = "0xD1DDBC", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EC7698]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023B64]) = v35;\nL_0018:\n\treturn \"FBJSSDK\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "FBJSSDK";
			}
		}

		[Token(Token = "0x1700008D")]
		public override string SDKVersion
		{
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0xD1DE04", Offset = "0xD1DE04", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED1438]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B65]) = v38;\nL_001C:\n\tgoto L_0048;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v39;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v45, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0048;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 << 4;\n\tv162 = v42 + v161;\n\tv163 = v162 + 0x130;\nL_0048:\n\tinterfaceTailCallResult = Facebook.Unity.Canvas.ICanvasJSWrapper::GetSDKVersion(this.canvasJSWrapper);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return canvasJSWrapper.GetSDKVersion();
			}
		}

		[Token(Token = "0x1700008E")]
		public override string SDKUserAgent
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0xD1DEB8", Offset = "0xD1DEB8", Length = "0x2CC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF0BF0]);\n\tv25 = *([v24 @ X8_v63]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023B66]) = v44;\nL_0017:\n\tv46 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv56 = v46 != 3;\n\tif (v56) goto L_006B;\n\tgoto L_0030;\n\tv69 = *([v59 @ X0_v45+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0030;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0030:\n\tv77 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 55 NewArr v94 @ X0_v50 (System.Object[]), typeof(System.Object[]), 1\n\tv99 = Facebook.Unity.Constants::get_CurrentPlatform();\n\t// 64 Box this @ X0 (Facebook.Unity.Canvas.CanvasFacebook), typeof(Facebook.Unity.FacebookUnityPlatform), &v99 @ X0_v51 (Facebook.Unity.FacebookUnityPlatform)\n\tv154 = *([this @ X0 (Facebook.Unity.Canvas.CanvasFacebook)]);\n\t*([v154 @ X8_v53+160])(this, this, *([v154 @ X8_v53+168]), v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v154 @ X8_v53+168]), v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv224 = this == 0;\n\tif (v224) goto L_0059;\n\t// 85 IsInst this @ X0 (Facebook.Unity.Canvas.CanvasFacebook), typeof(System.Object), this @ X0 (Facebook.Unity.Canvas.CanvasFacebook)\nL_0059:\n\tv119 = v94.Length == 0;\n\tif (v119) goto L_00E3;\n\tv94[0] = this;\n\tv117 = System.String::Format(v77, \"FBUnity{0}\", v94);\n\tgoto L_007E;\nL_006B:\n\tgoto L_0074;\n\tv78 = *([v65 @ X0_v41+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0074;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0074:\n\tFacebook.Unity.FacebookLogger::Warn(\"Currently running on uknown web platform\");\nL_007E:\n\tgoto L_0085;\n\tv137 = *([v126 @ X0_v4+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tgoto L_0085;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v126, v114, v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0085:\n\tv145 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 140 NewArr v153 @ X0_v9 (System.Object[]), typeof(System.Object[]), 2\n\tv210 = Facebook.Unity.Canvas.CanvasFacebook::get_SDKName(this);\n\tv216 = Facebook.Unity.Canvas.CanvasFacebook::get_SDKVersion(this);\n\tv219 = Facebook.Unity.Utilities::GetUserAgent(v210, v216);\n\tv295 = v219 == 0;\n\tif (v295) goto L_00A8;\n\t// 164 IsInst this @ X0 (Facebook.Unity.Canvas.CanvasFacebook), typeof(System.Object), v219 @ X0_v15 (System.String)\nL_00A8:\n\tv316 = v153.Length == 0;\n\tif (v316) goto L_00E3;\n\tv153[0] = v219;\n\tgoto L_00BB;\n\tv370 = *([1EE6770]);\n\tv371 = *([v370 @ X8_v25]);\n\tv372 = \"il2cpp_codegen_initialize_method\"(v371, v310, v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv375 = 0 | 1;\n\t*([2023C31]) = v375;\nL_00BB:\n\tv380 = Facebook.Unity.Utilities::GetUserAgent(v122, \"7.18.0\");\n\tv384 = v380 == 0;\n\tif (v384) goto L_00C6;\n\t// 194 IsInst this @ X0 (Facebook.Unity.Canvas.CanvasFacebook), typeof(System.Object), v380 @ X0_v19 (System.String)\nL_00C6:\n\tv387 = v153.Length < 1;\n\tv282 = ~v387;\n\tv280 = v153.Length - 1;\n\tv276 = v280 == 0;\n\tv388 = ~v282;\n\tv266 = v388 | v276;\n\tif (v266) goto L_00E3;\n\tv153[1] = v380;\n\treturnVal2 = System.String::Format(v145, \"{0} {1}\", v153);\n\treturn returnVal2;\nL_00E3:\n\tv345 = new System.IndexOutOfRangeException();\n\tgoto L_00E8;\n\tv368 = new System.ArrayTypeMismatchException();\nL_00E8:\n\tthrow v383;\n\tv195 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_01df: Expected O, but got I4
				FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
				string productName;
				if (currentPlatform == FacebookUnityPlatform.WebGL)
				{
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					object[] array = new object[1];
					FacebookUnityPlatform currentPlatform2 = Constants.CurrentPlatform;
					CanvasFacebook canvasFacebook = (CanvasFacebook)(object)currentPlatform2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v154 @ X8_v53+160] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					if (this != null)
					{
						canvasFacebook = (CanvasFacebook)(this as object);
					}
					if (array.Length == 0)
					{
						goto IL_0241;
					}
					array[0] = this;
					string text = string.Format(invariantCulture, "FBUnity{0}", array);
					productName = text;
				}
				else
				{
					FacebookLogger.Warn("Currently running on uknown web platform");
					productName = "FBUnityWebUnknown";
				}
				CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
				object[] array2 = new object[2];
				string sDKName = SDKName;
				string sDKVersion = SDKVersion;
				string userAgent = Utilities.GetUserAgent(sDKName, sDKVersion);
				if (userAgent != null)
				{
					CanvasFacebook canvasFacebook = (CanvasFacebook)(userAgent as object);
				}
				if (array2.Length != 0)
				{
					array2[0] = userAgent;
					string userAgent2 = Utilities.GetUserAgent(productName, "7.18.0");
					if (userAgent2 != null)
					{
						CanvasFacebook canvasFacebook = (CanvasFacebook)(userAgent2 as object);
					}
					bool flag = array2.Length < 1;
					bool flag2 = !flag;
					object obj = array2.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = userAgent2;
						return string.Format(invariantCulture2, "{0} {1}", array2);
					}
				}
				goto IL_0241;
				IL_0241:
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xD1DC14", Offset = "0xD1DC14", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED7740]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023B62]) = v40;\nL_0014:\n\tv41 = Facebook.Unity.Canvas.CanvasFacebook::GetCanvasJSWrapper();\n\tv47 = new Facebook.Unity.CallbackManager();\n\tFacebook.Unity.CallbackManager::.ctor(v47);\n\tSystem.Object::.ctor(v38);\n\tv38.<CallbackManager>k__BackingField = v47;\n\tv38.canvasJSWrapper = v41;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CanvasFacebook()
		{
			ICanvasJSWrapper canvasJSWrapper = GetCanvasJSWrapper();
			CallbackManager callbackManager = new CallbackManager();
			CallbackManager = callbackManager;
			this.canvasJSWrapper = canvasJSWrapper;
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xD1DD40", Offset = "0xD1DD40", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\tthis.canvasJSWrapper = canvasJSWrapper;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CanvasFacebook(ICanvasJSWrapper canvasJSWrapper, CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
			this.canvasJSWrapper = canvasJSWrapper;
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xD1DC94", Offset = "0xD1DC94", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EAF178]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023B63]) = v37;\nL_0016:\n\tv42 = System.Reflection.Assembly::Load(\"Facebook.Unity.Canvas\");\n\tv50 = System.Reflection.Assembly::GetType(v42, \"Facebook.Unity.Canvas.CanvasJSWrapper\");\n\tv52 = System.Activator::CreateInstance(v50);\n\tv55 = v52 == 0;\n\tif (v55) goto L_0032;\n\t// 42 IsInst returnVal1 @ X0_v10 (Facebook.Unity.Canvas.ICanvasJSWrapper), typeof(Facebook.Unity.Canvas.ICanvasJSWrapper), v52 @ X0_v9 (System.Object)\n\tv66 = returnVal1 == 0;\n\tif (v66) goto L_0036;\nL_0032:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0036:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ICanvasJSWrapper GetCanvasJSWrapper()
		{
			Assembly assembly = Assembly.Load("Facebook.Unity.Canvas");
			Type type = assembly.GetType("Facebook.Unity.Canvas.CanvasJSWrapper");
			object obj = Activator.CreateInstance(type);
			bool flag = obj == null;
			ICanvasJSWrapper canvasJSWrapper = (ICanvasJSWrapper)obj;
			if (!flag)
			{
				canvasJSWrapper = obj as ICanvasJSWrapper;
				if (canvasJSWrapper == null)
				{
					return (ICanvasJSWrapper)new InvalidCastException();
				}
			}
			return canvasJSWrapper;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0xD1E458", Offset = "0xD1E458", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv35 = *([v24 @ X29_v1+18]);\n\tgoto L_002B;\n\tv56 = *([1EB5F48]);\n\tv57 = *([v56 @ X8_v48]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, appId, cookie, logging, status, xfbml, channelUrl, authResponse, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 0 | 1;\n\t*([2023B67]) = v69;\nL_002B:\n\tthis.onInitCompleteDelegate = *([v24 @ X29_v1+30]);\n\tgoto L_005C;\n\tv153 = *([v73 @ X8_v6+B0]);\n\tv154 = 0;\n\tv155 = v153 + 8;\n\tv157 = *([v193 @ X11_v12-8]);\n\tv199 = v157 == v76;\n\tif (v199) goto L_0054;\n\tv179 = v194 + 1;\n\tv276 = v179 < v75;\n\tv175 = ~v276;\n\tv177 = v193 + 0x10;\n\tv159 = ~v175;\n\tif (v159) goto L_FFFFFFFF;\n\tv180 = 9;\n\tv181 = v70;\n\tv182 = 0x8909C4(v181, v76, v180, logging, status, xfbml, channelUrl, authResponse, v59, v60, v61, v62, v63, v64, v65, v66);\n\tgoto L_005C;\nL_0054:\n\tv277 = *([v193 @ X11_v12]);\n\tv278 = v277 + 9;\n\tv279 = v278 << 4;\n\tv280 = v73 + v279;\n\tv281 = v280 + 0x130;\nL_005C:\n\tFacebook.Unity.Canvas.ICanvasJSWrapper::InitScreenPosition(this.canvasJSWrapper);\n\tthis.appId = appId;\n\tthis.onHideUnityDelegate = *([v24 @ X29_v1+28]);\n\tv126 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v126);\n\tFacebook.Unity.MethodArguments::AddString(v126, \"appId\", appId);\n\tFacebook.Unity.MethodArguments::AddPrimative(v126, \"cookie\", cookie);\n\tFacebook.Unity.MethodArguments::AddPrimative(v126, \"logging\", logging);\n\tFacebook.Unity.MethodArguments::AddPrimative(v126, \"status\", status);\n\tFacebook.Unity.MethodArguments::AddPrimative(v126, \"xfbml\", xfbml);\n\tFacebook.Unity.MethodArguments::AddString(v126, \"channelUrl\", channelUrl);\n\tFacebook.Unity.MethodArguments::AddString(v126, \"authResponse\", authResponse);\n\tv335 = *([v24 @ X29_v1+10]) & 1;\n\tFacebook.Unity.MethodArguments::AddPrimative(v126, \"frictionlessRequests\", v335);\n\tgoto L_00B0;\n\tv341 = *([v337 @ X0_v18+E0]);\n\tv342 = v341 == 0;\n\tv343 = ~v342;\n\tif (v343) goto L_00B0;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v337, v333, v335, v82, status, xfbml, channelUrl, authResponse, v59, v60, v61, v62, v63, v64, v65, v66);\nL_00B0:\n\tgoto L_00BB;\n\tv352 = *([1EDFFC0]);\n\tv353 = *([v352 @ X8_v42]);\n\tv354 = \"il2cpp_codegen_initialize_method\"(v353, v333, v335, v82, status, xfbml, channelUrl, authResponse, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv357 = 0 | 1;\n\t*([2023CAA]) = v357;\nL_00BB:\n\tgoto L_00C8;\n\tv362 = *([v358 @ X0_v21 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\tgoto L_00C8;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v358, v333, v335, v82, status, xfbml, channelUrl, authResponse, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv366 = Facebook.Unity.FB;\nL_00C8:\n\tFacebook.Unity.MethodArguments::AddString(v126, \"version\", v370.graphApiVersion);\n\tv132 = this.canvasJSWrapper;\n\tv127 = Facebook.Unity.MethodArguments::ToJsonString(v126);\n\tv375 = *([v132 @ X21_v3 (Facebook.Unity.MethodArguments)]);\n\tv382 = *([v24 @ X29_v1+20]) & 1;\n\tv249 = *([v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+126]) == 0;\n\tif (v249) goto L_00F9;\n\tv423 = *([v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+B0]) + 8;\nL_00E4:\n\tv429 = *([v423 @ X11_v7-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v429) goto L_00FC;\n\tv424 = v424 + 1;\n\tv434 = v424 < *([v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+126]);\n\tv405 = ~v434;\n\tv423 = v423 + 0x10;\n\tv389 = ~v405;\n\tif (v389) goto L_00E4;\nL_00F9:\n\tv441 = Facebook.Unity.MethodArguments::AddPrimative(v132, Facebook.Unity.Canvas.ICanvasJSWrapper, 2);\n\tgoto L_0100;\nL_00FC:\n\tv436 = *([v423 @ X11_v7]) + 2;\n\tv437 = v436 << 4;\n\tv438 = v375 + v437;\n\tv441 = v438 + 0x130;\nL_0100:\n\tv213 = *([v441 @ X0_v26]);\n\tv211 = *([v441 @ X0_v26+8]);\n\t// 277 IndirectJump v213 @ X7_v1, v132 @ X21_v3 (Facebook.Unity.MethodArguments), v132 @ X21_v3 (Facebook.Unity.MethodArguments), \"https://connect.facebook.net\", v35 @ X8_v2, v382 @ X24_v2 (System.Int32), v127 @ X0_v25 (System.String), status @ X4 (System.Boolean), v211 @ X6_v1, v213 @ X7_v1, v59 @ V0, v60 @ V1, v61 @ V2, v62 @ V3, v63 @ V4, v64 @ V5, v65 @ V6, v66 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 190 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(string appId, bool cookie, bool logging, bool status, bool xfbml, string channelUrl, string authResponse, bool frictionlessRequests, string javascriptSDKLocale, bool loadDebugJSSDK, HideUnityDelegate hideUnityDelegate, InitDelegate onInitComplete)
		{
			//IL_0018: Expected O, but got I
			//IL_0212: Expected O, but got I
			//IL_023e: Expected O, but got I
			//IL_00ee: Expected I, but got O
			//IL_02c3: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_01ec: Expected O, but got I
			//IL_01fb: Expected O, but got I
			//IL_018b: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+30]");
			onInitCompleteDelegate = (InitDelegate)0;
			canvasJSWrapper.InitScreenPosition();
			this.appId = appId;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
			onHideUnityDelegate = (HideUnityDelegate)0;
			MethodArguments methodArguments = new MethodArguments();
			methodArguments.AddString("appId", appId);
			methodArguments.AddPrimative("cookie", cookie);
			methodArguments.AddPrimative("logging", logging);
			methodArguments.AddPrimative("status", status);
			methodArguments.AddPrimative("xfbml", xfbml);
			methodArguments.AddString("channelUrl", channelUrl);
			methodArguments.AddString("authResponse", authResponse);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			bool value = false;
			methodArguments.AddPrimative("frictionlessRequests", value);
			methodArguments.AddString("version", FB.graphApiVersion);
			MethodArguments methodArguments2 = (MethodArguments)canvasJSWrapper;
			string text = methodArguments.ToJsonString();
			IntPtr intPtr = (IntPtr)methodArguments2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			int num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01a4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+B0]");
			object obj4 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ X8_v37 (Il2CppClass<Facebook.Unity.MethodArguments>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_01a4;
			}
			object obj5 = obj4 + 2;
			int num4 = (int)((long)(IntPtr)obj5 << 4);
			object obj6 = (long)intPtr + (long)num4;
			object obj7 = (long)(IntPtr)obj6 + 304L;
			goto IL_02ab;
			IL_01a4:
			methodArguments2.AddPrimative((string)(object)typeof(ICanvasJSWrapper), value: true);
			goto IL_02ab;
			IL_02ab:
			object obj8 = obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ X0_v26+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v213 @ X7_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0xD1E968", Offset = "0xD1E968", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EDC890]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, permissions, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023B68]) = v46;\nL_0018:\n\tv47 = this.canvasJSWrapper;\n\tv50 = *([v47 @ X22_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv54 = *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v54) goto L_003F;\n\tv182 = *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_002A:\n\tv187 = *([v182 @ X11_v13-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v187) goto L_0042;\n\tv181 = v181 + 1;\n\tv192 = v181 < *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv135 = ~v192;\n\tv182 = v182 + 0x10;\n\tv119 = ~v135;\n\tif (v119) goto L_002A;\nL_003F:\n\tv198 = 0x8909C4(v47, Facebook.Unity.Canvas.ICanvasJSWrapper, 1, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0049;\nL_0042:\n\tv194 = *([v182 @ X11_v13]) + 1;\n\tv195 = v194 << 4;\n\tv196 = v50 + v195;\n\tv198 = v196 + 0x130;\nL_0049:\n\t*([v198 @ X0_v6])(v201, v47, *([v198 @ X0_v6+8]), v146, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv107 = this.canvasJSWrapper;\n\tv103 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tv259 = *([v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv245 = *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v245) goto L_0078;\n\tv303 = *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_0063:\n\tv308 = *([v303 @ X11_v8-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v308) goto L_007B;\n\tv302 = v302 + 1;\n\tv313 = v302 < *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv284 = ~v313;\n\tv303 = v303 + 0x10;\n\tv268 = ~v284;\n\tif (v268) goto L_0063;\nL_0078:\n\tv320 = 0x8909C4(v107, Facebook.Unity.Canvas.ICanvasJSWrapper, 3, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_007F;\nL_007B:\n\tv315 = *([v303 @ X11_v8]) + 3;\n\tv316 = v315 << 4;\n\tv317 = v259 + v316;\n\tv320 = v317 + 0x130;\nL_007F:\n\tv207 = *([v320 @ X0_v11]);\n\tv205 = *([v320 @ X0_v11+8]);\n\t// 140 IndirectJump v207 @ X4_v1, v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), permissions @ X1 (System.Collections.Generic.IEnumerable`1<System.String>), v103 @ X0_v10 (System.String), v205 @ X3_v1, v207 @ X4_v1, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithPublishPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_00c0: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_0136: Expected I, but got O
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00f0: Expected O, but got I
			//IL_00ff: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_02ae: Expected O, but got I
			//IL_0171: Expected O, but got I
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_0210: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_01bd: Expected O, but got I
			ICanvasJSWrapper canvasJSWrapper = this.canvasJSWrapper;
			IntPtr intPtr = (IntPtr)canvasJSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			object obj5 = callback;
			goto IL_025d;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			obj5 = 1;
			goto IL_025d;
			IL_025d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ X0_v6] (should have been resolved before IL gen)");
			ICanvasJSWrapper canvasJSWrapper2 = this.canvasJSWrapper;
			string text = CallbackManager.AddFacebookDelegate(callback);
			IntPtr intPtr2 = (IntPtr)canvasJSWrapper2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01d6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj6 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01d6;
			}
			object obj7 = obj6 + 3;
			int num6 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr2 + (long)num6;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_0296;
			IL_0296:
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X0_v11+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v207 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_01d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0296;
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xD1EACC", Offset = "0xD1EACC", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EFD8A8]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, permissions, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023B69]) = v46;\nL_0018:\n\tv47 = this.canvasJSWrapper;\n\tv50 = *([v47 @ X22_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv54 = *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v54) goto L_003F;\n\tv182 = *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_002A:\n\tv187 = *([v182 @ X11_v13-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v187) goto L_0042;\n\tv181 = v181 + 1;\n\tv192 = v181 < *([v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv135 = ~v192;\n\tv182 = v182 + 0x10;\n\tv119 = ~v135;\n\tif (v119) goto L_002A;\nL_003F:\n\tv198 = 0x8909C4(v47, Facebook.Unity.Canvas.ICanvasJSWrapper, 1, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0049;\nL_0042:\n\tv194 = *([v182 @ X11_v13]) + 1;\n\tv195 = v194 << 4;\n\tv196 = v50 + v195;\n\tv198 = v196 + 0x130;\nL_0049:\n\t*([v198 @ X0_v6])(v201, v47, *([v198 @ X0_v6+8]), v146, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv107 = this.canvasJSWrapper;\n\tv103 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tv259 = *([v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv245 = *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v245) goto L_0078;\n\tv303 = *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_0063:\n\tv308 = *([v303 @ X11_v8-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v308) goto L_007B;\n\tv302 = v302 + 1;\n\tv313 = v302 < *([v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv284 = ~v313;\n\tv303 = v303 + 0x10;\n\tv268 = ~v284;\n\tif (v268) goto L_0063;\nL_0078:\n\tv320 = 0x8909C4(v107, Facebook.Unity.Canvas.ICanvasJSWrapper, 3, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_007F;\nL_007B:\n\tv315 = *([v303 @ X11_v8]) + 3;\n\tv316 = v315 << 4;\n\tv317 = v259 + v316;\n\tv320 = v317 + 0x130;\nL_007F:\n\tv207 = *([v320 @ X0_v11]);\n\tv205 = *([v320 @ X0_v11+8]);\n\t// 140 IndirectJump v207 @ X4_v1, v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), v107 @ X21_v4 (Facebook.Unity.Canvas.ICanvasJSWrapper), permissions @ X1 (System.Collections.Generic.IEnumerable`1<System.String>), v103 @ X0_v10 (System.String), v205 @ X3_v1, v207 @ X4_v1, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithReadPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_00c0: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_0136: Expected I, but got O
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00f0: Expected O, but got I
			//IL_00ff: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_02ae: Expected O, but got I
			//IL_0171: Expected O, but got I
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_0210: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_01bd: Expected O, but got I
			ICanvasJSWrapper canvasJSWrapper = this.canvasJSWrapper;
			IntPtr intPtr = (IntPtr)canvasJSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			object obj5 = callback;
			goto IL_025d;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			obj5 = 1;
			goto IL_025d;
			IL_025d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ X0_v6] (should have been resolved before IL gen)");
			ICanvasJSWrapper canvasJSWrapper2 = this.canvasJSWrapper;
			string text = CallbackManager.AddFacebookDelegate(callback);
			IntPtr intPtr2 = (IntPtr)canvasJSWrapper2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01d6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj6 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v10 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01d6;
			}
			object obj7 = obj6 + 3;
			int num6 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr2 + (long)num6;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_0296;
			IL_0296:
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X0_v11+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v207 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_01d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0296;
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xD1EC30", Offset = "0xD1EC30", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB6630]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B6A]) = v38;\nL_0017:\n\tgoto L_0022;\n\tv44 = *([1ED9370]);\n\tv45 = *([v44 @ X8_v14]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = 0 | 1;\n\t*([2023CAB]) = v49;\nL_0022:\n\tv53.<CurrentAccessToken>k__BackingField = 0;\n\tv54 = this.canvasJSWrapper;\n\tv57 = *([v54 @ X19_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv61 = *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v61) goto L_004A;\n\tv115 = *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_0035:\n\tv121 = *([v115 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v121) goto L_004D;\n\tv116 = v116 + 1;\n\tv174 = v116 < *([v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv95 = ~v174;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0035;\nL_004A:\n\tv181 = 0x8909C4(v54, Facebook.Unity.Canvas.ICanvasJSWrapper, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0051;\nL_004D:\n\tv176 = *([v115 @ X11_v5]) + 4;\n\tv177 = v176 << 4;\n\tv178 = v57 + v177;\n\tv181 = v178 + 0x130;\nL_0051:\n\tv134 = *([v181 @ X0_v5]);\n\tv156 = *([v181 @ X0_v5+8]);\n\t// 89 IndirectJump v134 @ X2_v2, v54 @ X19_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), v54 @ X19_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), v156 @ X1_v2, v134 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				ICanvasJSWrapper canvasJSWrapper = this.canvasJSWrapper;
				IntPtr intPtr = (IntPtr)canvasJSWrapper;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v9 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
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

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xD1ED70", Offset = "0xD1ED70", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0027;\n\tv49 = *([1EFA368]);\n\tv50 = *([v49 @ X8_v37]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2023B6B]) = v62;\nL_0027:\n\tFacebook.Unity.FacebookBase::ValidateAppRequestArgs(this, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v67, v68, v69);\n\tv74 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v74);\n\tFacebook.Unity.MethodArguments::AddString(v74, \"message\", message);\n\tFacebook.Unity.MethodArguments::AddCommaSeparatedList(v74, \"to\", to);\n\tv126 = actionType & 0xFF00000000;\n\tv127 = v126 == 0;\n\tif (v127) goto L_FFFFFFFF;\n\tv171 = System.Nullable`1<Facebook.Unity.OGActionType>::ToString(&actionType @ X2 (System.Nullable`1<Facebook.Unity.OGActionType>));\n\tgoto L_0052;\nL_0052:\n\tFacebook.Unity.MethodArguments::AddString(v74, \"action_type\", v175);\n\tFacebook.Unity.MethodArguments::AddString(v74, \"object_id\", objectId);\n\tFacebook.Unity.MethodArguments::AddList(v74, \"filters\", filters);\n\tFacebook.Unity.MethodArguments::AddList(v74, \"exclude_ids\", excludeIds);\n\tFacebook.Unity.MethodArguments::AddNullablePrimitive(v74, \"max_recipients\", maxRecipients);\n\tFacebook.Unity.MethodArguments::AddString(v74, \"data\", *([v24 @ X29_v1+10]));\n\tFacebook.Unity.MethodArguments::AddString(v74, \"title\", *([v24 @ X29_v1+18]));\n\tv103 = new Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IAppRequestResult>();\n\tFacebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IAppRequestResult>::.ctor(v103, this, \"apprequests\", \"OnAppRequestsComplete\");\n\tv103.<Callback>k__BackingField = *([v24 @ X29_v1+20]);\n\tv143 = Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1::Call(v103, v74);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			//IL_00cc: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_011a: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			string data2 = default(string);
			string title2 = default(string);
			FacebookDelegate<IAppRequestResult> callback2 = default(FacebookDelegate<IAppRequestResult>);
			ValidateAppRequestArgs(message, actionType, objectId, to, filters, excludeIds, maxRecipients, data2, title2, callback2);
			MethodArguments methodArguments = new MethodArguments();
			methodArguments.AddString("message", message);
			methodArguments.AddCommaSeparatedList("to", to);
			string value;
			if ((int)((_003F?)actionType & 0xFF00000000L) != 0)
			{
				OGActionType? oGActionType = default(OGActionType?);
				string text = oGActionType.ToString();
				value = text;
			}
			else
			{
				value = null;
			}
			methodArguments.AddString("action_type", value);
			methodArguments.AddString("object_id", objectId);
			methodArguments.AddList("filters", filters);
			methodArguments.AddList("exclude_ids", excludeIds);
			methodArguments.AddNullablePrimitive("max_recipients", maxRecipients);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			methodArguments.AddString("data", (string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			methodArguments.AddString("title", (string)0);
			CanvasUIMethodCall<IAppRequestResult> canvasUIMethodCall = new CanvasUIMethodCall<IAppRequestResult>(this, "apprequests", "OnAppRequestsComplete");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			canvasUIMethodCall.Callback = (FacebookDelegate<IAppRequestResult>)0;
			((CanvasUIMethodCall<>)(object)canvasUIMethodCall).Call(methodArguments);
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xD1F2C8", Offset = "0xD1F2C8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F01FA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, appId, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B6C]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 5;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 5;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tFacebook.Unity.Canvas.ICanvasJSWrapper::ActivateApp(this.canvasJSWrapper);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ActivateApp(string appId)
		{
			canvasJSWrapper.ActivateApp();
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xD1F380", Offset = "0xD1F380", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1EE2FF8]);\n\tv39 = *([v38 @ X8_v21]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, contentURL, contentTitle, contentDescription, photoURL, callback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023B6D]) = v53;\nL_0020:\n\tv57 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v57);\n\tFacebook.Unity.MethodArguments::AddUri(v57, \"link\", contentURL);\n\tFacebook.Unity.MethodArguments::AddString(v57, \"name\", contentTitle);\n\tFacebook.Unity.MethodArguments::AddString(v57, \"description\", contentDescription);\n\tFacebook.Unity.MethodArguments::AddUri(v57, \"picture\", photoURL);\n\tv80 = new Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>::.ctor(v80, this, \"feed\", \"OnShareLinkComplete\");\n\tv126 = *([v80 @ X0_v12 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>)]);\n\tv80.<Callback>k__BackingField = callback;\n\tv103 = *([v126 @ X8_v18 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+170]);\n\tv109 = *([v126 @ X8_v18 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+178]);\n\t// 95 IndirectJump v103 @ X3_v3, v80 @ X0_v12 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>), v80 @ X0_v12 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>), v57 @ X0_v3 (Facebook.Unity.MethodArguments), v109 @ X2_v7, v103 @ X3_v3, methodof(Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>::.ctor), callback @ X5 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>), methodInfo @ X6 (Il2CppMethodInfo), v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback)
		{
			//IL_0079: Expected I, but got O
			//IL_0096: Expected O, but got I
			//IL_00a6: Expected O, but got I
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddUri("link", contentURL);
				methodArguments.AddString("name", contentTitle);
				methodArguments.AddString("description", contentDescription);
				methodArguments.AddUri("picture", photoURL);
				CanvasUIMethodCall<IShareResult> canvasUIMethodCall = new CanvasUIMethodCall<IShareResult>(this, "feed", "OnShareLinkComplete");
				IntPtr intPtr = (IntPtr)canvasUIMethodCall;
				canvasUIMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v18 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v18 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v103 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xD1F60C", Offset = "0xD1F60C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0026;\n\tv49 = *([1F0FB08]);\n\tv50 = *([v49 @ X8_v27]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2023B6E]) = v62;\nL_0026:\n\tv66 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v66);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"to\", toId);\n\tFacebook.Unity.MethodArguments::AddUri(v66, \"link\", link);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"name\", linkName);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"caption\", linkCaption);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"description\", linkDescription);\n\tFacebook.Unity.MethodArguments::AddUri(v66, \"picture\", picture);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"source\", mediaSource);\n\tv89 = new Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>::.ctor(v89, this, \"feed\", \"OnShareLinkComplete\");\n\tv141 = *([v89 @ X0_v15 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>)]);\n\tv89.<Callback>k__BackingField = *([v24 @ X29_v1+10]);\n\tv112 = *([v141 @ X8_v24 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+170]);\n\tv118 = *([v141 @ X8_v24 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+178]);\n\t// 122 IndirectJump v112 @ X3_v3, v89 @ X0_v15 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>), v89 @ X0_v15 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>), v66 @ X0_v3 (Facebook.Unity.MethodArguments), v118 @ X2_v10, v112 @ X3_v3, methodof(Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>::.ctor), linkDescription @ X5 (System.String), picture @ X6 (System.Uri), mediaSource @ X7 (System.String), v52 @ V0, v53 @ V1, v54 @ V2, v55 @ V3, v56 @ V4, v57 @ V5, v58 @ V6, v59 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback)
		{
			//IL_00c1: Expected I, but got O
			//IL_00d6: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_00f6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddString("to", toId);
				methodArguments.AddUri("link", link);
				methodArguments.AddString("name", linkName);
				methodArguments.AddString("caption", linkCaption);
				methodArguments.AddString("description", linkDescription);
				methodArguments.AddUri("picture", picture);
				methodArguments.AddString("source", mediaSource);
				CanvasUIMethodCall<IShareResult> canvasUIMethodCall = new CanvasUIMethodCall<IShareResult>(this, "feed", "OnShareLinkComplete");
				IntPtr intPtr = (IntPtr)canvasUIMethodCall;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
				canvasUIMethodCall.Callback = (FacebookDelegate<IShareResult>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v24 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+170]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v24 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IShareResult>>)+178]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xD1F7B0", Offset = "0xD1F7B0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tFacebook.Unity.Canvas.CanvasFacebook::PayImpl(this, product, 0, action, quantity, quantityMin, quantityMax, requestId, pricepointId, *([v4 @ X29_v1+10]), 0, *([v4 @ X29_v1+18]));\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pay(string product, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, FacebookDelegate<IPayResult> callback)
		{
			//IL_0044: Expected O, but got I
			//IL_0044: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1+10]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1+18]");
			PayImpl(product, null, action, quantity, quantityMin, quantityMax, requestId, pricepointId, (string)(long)intPtr, null, (FacebookDelegate<IPayResult>)0);
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xD1FA28", Offset = "0xD1FA28", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EF28E8]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023B6F]) = v43;\nL_0019:\n\tv47 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v47);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v47, \"url\", this.appLinkUrl);\n\tv82 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v82, v47);\n\tv70 = new Facebook.Unity.AppLinkResult();\n\tFacebook.Unity.AppLinkResult::.ctor(v70, v82);\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>::Invoke(callback, v70);\n\tthis.appLinkUrl = v114.Empty;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", appLinkUrl);
			ResultContainer resultContainer = new ResultContainer(dictionary);
			AppLinkResult result = new AppLinkResult(resultContainer);
			callback(result);
			appLinkUrl = string.Empty;
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xD1FB80", Offset = "0xD1FB80", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EB2A50]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, logEvent, valueToSum, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B70]) = v47;\nL_001B:\n\tv50 = this.canvasJSWrapper;\n\tgoto L_0027;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, logEvent, valueToSum, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tv63 = Facebook.MiniJSON.Json+Serializer::Serialize(parameters);\n\tv67 = *([v50 @ X21_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv71 = *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v71) goto L_004F;\n\tv125 = *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_003A:\n\tv131 = *([v125 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v131) goto L_0052;\n\tv126 = v126 + 1;\n\tv196 = v126 < *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv105 = ~v196;\n\tv125 = v125 + 0x10;\n\tv81 = ~v105;\n\tif (v81) goto L_003A;\nL_004F:\n\tv203 = 0x8909C4(v50, Facebook.Unity.Canvas.ICanvasJSWrapper, 6, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0056;\nL_0052:\n\tv198 = *([v125 @ X11_v5]) + 6;\n\tv199 = v198 << 4;\n\tv200 = v67 + v199;\n\tv203 = v200 + 0x130;\nL_0056:\n\tv143 = *([v203 @ X0_v8]);\n\tv141 = *([v203 @ X0_v8+8]);\n\t// 100 IndirectJump v143 @ X5_v1, v50 @ X21_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), v50 @ X21_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), logEvent @ X1 (System.String), valueToSum @ X2 (System.Nullable`1<System.Single>), v63 @ X0_v5 (System.String), v141 @ X4_v1, v143 @ X5_v1, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters)
		{
			//IL_001f: Expected I, but got O
			//IL_015e: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00f9: Expected O, but got I
			//IL_0108: Expected O, but got I
			//IL_00a6: Expected O, but got I
			ICanvasJSWrapper canvasJSWrapper = this.canvasJSWrapper;
			string text = Json.Serializer.Serialize(parameters);
			IntPtr intPtr = (IntPtr)canvasJSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bf;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bf;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0146;
			IL_00bf:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0146;
			IL_0146:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v143 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0xD1FC8C", Offset = "0xD1FC8C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1ED8100]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, currency, parameters, methodInfo, v34, v35, v36, v37, purchaseAmount, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B71]) = v47;\nL_001B:\n\tv50 = this.canvasJSWrapper;\n\tgoto L_0027;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, currency, parameters, methodInfo, v34, v35, v36, v37, purchaseAmount, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tv63 = Facebook.MiniJSON.Json+Serializer::Serialize(parameters);\n\tv67 = *([v50 @ X20_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper)]);\n\tv71 = *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]) == 0;\n\tif (v71) goto L_004F;\n\tv125 = *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]) + 8;\nL_003A:\n\tv131 = *([v125 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasJSWrapper;\n\tif (v131) goto L_0052;\n\tv126 = v126 + 1;\n\tv196 = v126 < *([v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]);\n\tv105 = ~v196;\n\tv125 = v125 + 0x10;\n\tv81 = ~v105;\n\tif (v81) goto L_003A;\nL_004F:\n\tv203 = 0x8909C4(v50, Facebook.Unity.Canvas.ICanvasJSWrapper, 7, methodInfo, v34, v35, v36, v37, purchaseAmount, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0056;\nL_0052:\n\tv198 = *([v125 @ X11_v5]) + 7;\n\tv199 = v198 << 4;\n\tv200 = v67 + v199;\n\tv203 = v200 + 0x130;\nL_0056:\n\tv143 = *([v203 @ X0_v8]);\n\tv141 = *([v203 @ X0_v8+8]);\n\t// 100 IndirectJump v143 @ X4_v1, v50 @ X20_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), v50 @ X20_v2 (Facebook.Unity.Canvas.ICanvasJSWrapper), currency @ X1 (System.String), v63 @ X0_v5 (System.String), v141 @ X3_v1, v143 @ X4_v1, v35 @ X5, v36 @ X6, v37 @ X7, purchaseAmount @ V0 (System.Single), v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogPurchase(float purchaseAmount, string currency, Dictionary<string, object> parameters)
		{
			//IL_001f: Expected I, but got O
			//IL_015e: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00f9: Expected O, but got I
			//IL_0108: Expected O, but got I
			//IL_00a6: Expected O, but got I
			ICanvasJSWrapper canvasJSWrapper = this.canvasJSWrapper;
			string text = Json.Serializer.Serialize(parameters);
			IntPtr intPtr = (IntPtr)canvasJSWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bf;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasJSWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v7 (Il2CppClass<Facebook.Unity.Canvas.ICanvasJSWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bf;
			}
			object obj2 = obj + 7;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0146;
			IL_00bf:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0146;
			IL_0146:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v143 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0xD1FD98", Offset = "0xD1FD98", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED5160]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B72]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v45, this, Il2CppMethodInfo);\n\tFacebook.Unity.Canvas.CanvasFacebook::FormatAuthResponse(result, v45);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLoginComplete(ResultContainer result)
		{
			Utilities.Callback<ResultContainer> callback = delegate(ResultContainer formattedResponse)
			{
				//IL_0018: Expected I, but got O
				//IL_0028: Expected O, but got I
				//IL_0038: Expected O, but got I
				LoginResult loginResult = new LoginResult(formattedResponse);
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook>)+430]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook>)+438]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X3_v1 (should have been resolved before IL gen)");
			};
			FormatAuthResponse(result, callback);
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0xD2054C", Offset = "0xD2054C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EF51D0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, message, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023B73]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGetAppLinkComplete(ResultContainer message)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0xD205B0", Offset = "0xD205B0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF53B8]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2023B74]) = v42;\nL_001B:\n\tgoto L_0023;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+<>c>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0023;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = Facebook.Unity.Canvas.CanvasFacebook+<>c;\nL_0023:\n\tv81 = v56.<>9__40_0;\n\tv58 = v56.<>9__40_0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_004C;\n\tgoto L_0036;\n\tv91 = *([v52 @ X0_v3 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+<>c>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0036;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v52, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv105 = Facebook.Unity.Canvas.CanvasFacebook+<>c;\n\tv98 = *([v105 @ X8_v14+B8]);\nL_0036:\n\tv76 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v76, v97.<>9, Il2CppMethodInfo);\n\tv80.<>9__40_0 = v76;\nL_004C:\n\tFacebook.Unity.Canvas.CanvasFacebook::FormatAuthResponse(resultContainer, v81);\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookAuthResponseChange(ResultContainer resultContainer)
		{
			Utilities.Callback<ResultContainer> callback = _003C_003Ec._003C_003E9__40_0;
			if (_003C_003Ec._003C_003E9__40_0 == null)
			{
				callback = (_003C_003Ec._003C_003E9__40_0 = delegate(ResultContainer formattedResponse)
				{
					LoginResult loginResult = new LoginResult(formattedResponse);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @D34E90 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x2C)");
				});
			}
			FormatAuthResponse(resultContainer, callback);
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0xD20690", Offset = "0xD20690", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0FA88]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B75]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.PayResult();\n\tFacebook.Unity.PayResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPayComplete(ResultContainer resultContainer)
		{
			PayResult result = new PayResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0xD207B8", Offset = "0xD207B8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECA138]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B76]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppRequestResult();\n\tFacebook.Unity.AppRequestResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAppRequestsComplete(ResultContainer resultContainer)
		{
			AppRequestResult result = new AppRequestResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0xD20830", Offset = "0xD20830", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F09B90]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B77]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.ShareResult();\n\tFacebook.Unity.ShareResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnShareLinkComplete(ResultContainer resultContainer)
		{
			ShareResult result = new ShareResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0xD20984", Offset = "0xD20984", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.appLinkUrl = url;\n\treturn;\n")]
		public void OnUrlResponse(string url)
		{
			appLinkUrl = url;
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0xD2098C", Offset = "0xD2098C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.onHideUnityDelegate == 0;\n\tif (v2) goto L_0006;\n\tFacebook.Unity.HideUnityDelegate::Invoke(this.onHideUnityDelegate, isGameShown);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnHideUnity(bool isGameShown)
		{
			if (onHideUnityDelegate != null)
			{
				onHideUnityDelegate(isGameShown);
			}
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xD1FE20", Offset = "0xD1FE20", Length = "0x72C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EFCAE8]);\n\tv33 = *([v32 @ X8_v94]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, callback, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2023B78]) = v51;\nL_001E:\n\tv56 = new Facebook.Unity.Canvas.CanvasFacebook+<>c__DisplayClass47_0();\n\tSystem.Object::.ctor(v56);\n\tv56.result = result;\n\tv56.callback = callback;\n\tv232 = result.<ResultDictionary>k__BackingField == 0;\n\tif (v232) goto L_FFFFFFFF;\n\tv184 = Facebook.Unity.Utilities::TryGetValue(result.<ResultDictionary>k__BackingField, \"authResponse\", &v168 @ stack_-58_v9 (System.Collections.Generic.IDictionary`2<System.String, System.Object>));\n\tv345 = v184 == 0;\n\tif (v345) goto L_0199;\n\tv221 = v56.result;\n\tgoto L_0073;\n\tv587 = *([v547 @ X8_v62+B0]);\n\tv588 = 0;\n\tv589 = v587 + 8;\n\tv591 = *([v635 @ X11_v67-8]);\n\tv640 = v591 == v549;\n\tif (v640) goto L_006A;\n\tv611 = v634 + 1;\n\tv675 = v611 < v548;\n\tv609 = ~v675;\n\tv613 = v635 + 0x10;\n\tv593 = ~v609;\n\tif (v593) goto L_FFFFFFFF;\n\tv614 = 5;\n\tv615 = v214;\n\tv616 = 0x8909C4(v615, v549, v614, v164, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0073;\n\tgoto L_022C;\nL_006A:\n\tv676 = *([v635 @ X11_v67]);\n\tv677 = v676 + 5;\n\tv678 = v677 << 4;\n\tv679 = v547 + v678;\n\tv680 = v679 + 0x130;\nL_0073:\n\tv190 = System.Collections.Generic.IDictionary`2<System.String, System.Object>::Remove(v221.<ResultDictionary>k__BackingField, \"authResponse\");\n\tgoto L_00A4;\n\tv725 = *([v707 @ X8_v65+B0]);\n\tv726 = 0;\n\tv727 = v725 + 8;\n\tv729 = *([v772 @ X11_v62-8]);\n\tv777 = v729 == v710;\n\tif (v777) goto L_009D;\n\tv749 = v771 + 1;\n\tv786 = v749 < v709;\n\tv747 = ~v786;\n\tv751 = v772 + 0x10;\n\tv731 = ~v747;\n\tif (v731) goto L_FFFFFFFF;\n\tv752 = v218;\n\tv753 = 0;\n\tv754 = 0x8909C4(v752, v710, v753, v164, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00A4;\nL_009D:\n\tv787 = *([v772 @ X11_v62]);\n\tv788 = v787 << 4;\n\tv789 = v707 + v788;\n\tv790 = v789 + 0x130;\nL_00A4:\n\tv811 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::GetEnumerator(v168);\nL_00B0:\n\tgoto L_00D7;\n\tv907 = *([v871 @ X8_v77+B0]);\n\tv908 = 0;\n\tv909 = v907 + 8;\n\tv911 = *([v1011 @ X11_v57-8]);\n\tv1016 = v911 == v872;\n\tif (v1016) goto L_00D0;\n\tv931 = v1010 + 1;\n\tv1044 = v931 < v873;\n\tv929 = ~v1044;\n\tv933 = v1011 + 0x10;\n\tv913 = ~v929;\n\tif (v913) goto L_FFFFFFFF;\n\tv934 = v337;\n\tv935 = 0;\n\tv936 = 0x8909C4(v934, v872, v935, v324, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00D7;\nL_00D0:\n\tv1045 = *([v1011 @ X11_v57]);\n\tv1046 = v1045 << 4;\n\tv1047 = v871 + v1046;\n\tv1048 = v1047 + 0x130;\nL_00D7:\n\tv1069 = System.Collections.IEnumerator::MoveNext(v811);\n\tv1071 = v1069 == 0;\n\tif (v1071) goto L_0141;\n\tgoto L_0106;\n\tv1085 = *([v1075 @ X8_v80+B0]);\n\tv1086 = 0;\n\tv1087 = v1085 + 8;\n\tv1089 = *([v1159 @ X11_v52-8]);\n\tv1164 = v1089 == v1076;\n\tif (v1164) goto L_00FF;\n\tv1109 = v1158 + 1;\n\tv1227 = v1109 < v1077;\n\tv1107 = ~v1227;\n\tv1111 = v1159 + 0x10;\n\tv1091 = ~v1107;\n\tif (v1091) goto L_FFFFFFFF;\n\tv1112 = v337;\n\tv1113 = 0;\n\tv1114 = 0x8909C4(v1112, v1076, v1113, v324, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0106;\nL_00FF:\n\tv1228 = *([v1159 @ X11_v52]);\n\tv1229 = v1228 << 4;\n\tv1230 = v1075 + v1229;\n\tv1231 = v1230 + 0x130;\nL_0106:\n\tv971 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::get_Current(v811);\n\tv976 = v56.result;\n\tv824 = v976.<ResultDictionary>k__BackingField;\n\tv1031 = v976.<ResultDictionary>k__BackingField == 0;\n\tif (v1031) goto L_014A;\n\tv1269 = *([v824 @ X23_v16 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv859 = *([v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v859) goto L_0131;\n\tv1324 = *([v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_011C:\n\tv1329 = *([v1324 @ X11_v47-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v1329) goto L_0134;\n\tv1323 = v1323 + 1;\n\tv1364 = v1323 < *([v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv1299 = ~v1364;\n\tv1324 = v1324 + 0x10;\n\tv1283 = ~v1299;\n\tif (v1283) goto L_011C;\nL_0131:\n\tv1371 = Facebook.Unity.Utilities::TryGetValue(v976.<ResultDictionary>k__BackingField, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1);\n\tgoto L_0139;\nL_0134:\n\tv1366 = *([v1324 @ X11_v47]) + 1;\n\tv1367 = v1366 << 4;\n\tv1368 = v1269 + v1367;\n\tv1371 = v1368 + 0x130;\nL_0139:\n\tv385 = *([v1371 @ X0_v96 (System.Boolean)+8]);\n\tv1371.m_value(v857, v976.<ResultDictionary>k__BackingField, v971, 0, *([v1371 @ X0_v96 (System.Boolean)+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00B0;\nL_0141:\n\tv1081 = v811 == 0;\n\tv1082 = ~v1081;\n\tif (v1082) goto L_0167;\n\tgoto L_018F;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_014A:\n\tv392 = new System.NullReferenceException();\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\nL_0159:\n\tv361 = v389 != 1;\n\tif (v361) goto L_02D0;\n\tv1147 = Facebook.Unity.Utilities::TryGetValue(v392, v389, v387);\n\tv1138 = v1147.m_value;\n\tv1135 = Facebook.Unity.Utilities::TryGetValue(v1147, v389, v387);\n\tv1137 = v811 == 0;\n\tif (v1137) goto L_018F;\nL_0167:\n\tgoto L_018E;\n\tv1193 = *([v1142 @ X8_v71+B0]);\n\tv1194 = 0;\n\tv1195 = v1193 + 8;\n\tv1197 = *([v1248 @ X11_v37-8]);\n\tv1253 = v1197 == v1145;\n\tif (v1253) goto L_0187;\n\tv1217 = v1247 + 1;\n\tv1258 = v1217 < v1144;\n\tv1215 = ~v1258;\n\tv1219 = v1248 + 0x10;\n\tv1199 = ~v1215;\n\tif (v1199) goto L_FFFFFFFF;\n\tv1220 = v337;\n\tv1221 = 0;\n\tv1222 = 0x8909C4(v1220, v1145, v1221, v324, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_018E;\nL_0187:\n\tv1259 = *([v1248 @ X11_v37]);\n\tv1260 = v1259 << 4;\n\tv1261 = v1142 + v1260;\n\tv1262 = v1261 + 0x130;\nL_018E:\n\tSystem.IDisposable::Dispose(v811);\nL_018F:\n\tv402 = v293 + 1;\n\tv309 = v402 == 0;\n\tv299 = ~v309;\n\tif (v299) goto L_0199;\n\tv1236 = ~v335;\n\tv333 = ~v1236;\n\tif (v333) goto L_02CF;\nL_0199:\n\tv222 = v56.result;\n\tv216 = v222.<ResultDictionary>k__BackingField;\n\tgoto L_01AE;\n\tv551 = *([v487 @ X0_v23 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv552 = v551 == 0;\n\tv553 = ~v552;\n\t// 423 ConditionalJump @b137, v553 @ TEMP_v54\n\tv617 = \"il2cpp_codegen_runtime_class_init\"(v487, v178, v171, v165, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv554 = Facebook.Unity.LoginResult;\nL_01AE:\n\tv620 = *([v216 @ X20_v11 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv623 = *([v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v623) goto L_01D2;\n\tv696 = *([v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_01BD:\n\tv701 = *([v696 @ X11_v26-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v701) goto L_01D5;\n\tv695 = v695 + 1;\n\tv712 = v695 < *([v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv667 = ~v712;\n\tv696 = v696 + 0x10;\n\tv651 = ~v667;\n\tif (v651) goto L_01BD;\nL_01D2:\n\tv719 = Facebook.Unity.Utilities::TryGetValue(v216, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 3);\n\tgoto L_01DD;\nL_01D5:\n\tv714 = *([v696 @ X11_v26]) + 3;\n\tv715 = v714 << 4;\n\tv716 = v620 + v715;\n\tv719 = v716 + 0x130;\nL_01DD:\n\tv719.m_value(v187, v216, v619.AccessTokenKey, *([v719 @ X0_v25 (System.Boolean)+8]), v385, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv723 = v187 & 1;\n\tv724 = v723 == 0;\n\tif (v724) goto L_0225;\n\tv223 = v56.result;\n\tv219 = v223.<ResultDictionary>k__BackingField;\n\tgoto L_01F3;\n\tv814 = *([v782 @ X0_v30 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv815 = v814 == 0;\n\tv816 = ~v815;\n\t// 493 ConditionalJump @b140, v816 @ TEMP_v52\n\tv865 = \"il2cpp_codegen_runtime_class_init\"(v782, v179, v172, v165, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n// ... truncated")]
		private unsafe static void FormatAuthResponse(ResultContainer result, Utilities.Callback<ResultContainer> callback)
		{
			//IL_0350: Expected I, but got O
			//IL_038b: Expected O, but got I
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Expected O, but got Unknown
			//IL_043c: Expected O, but got I
			//IL_03d7: Expected O, but got I
			//IL_047c: Expected I, but got O
			//IL_04b7: Expected O, but got I
			//IL_0546: Unknown result type (might be due to invalid IL or missing references)
			//IL_054b: Expected O, but got Unknown
			//IL_0568: Expected O, but got I
			//IL_0503: Expected O, but got I
			//IL_00f7: Expected I, but got O
			//IL_02b6: Expected O, but got I4
			//IL_0132: Expected O, but got I
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01e8: Expected O, but got I
			//IL_017e: Expected O, but got I
			ResultContainer result2 = result;
			Utilities.Callback<ResultContainer> callback2 = callback;
			IEnumerator<KeyValuePair<string, object>> enumerator;
			int num4;
			bool flag9;
			int num5;
			bool flag10;
			IntPtr intPtr;
			if (result.ResultDictionary != null)
			{
				bool flag = result.ResultDictionary.TryGetValue<IDictionary<string, object>>("authResponse", out var value);
				bool flag2 = !flag;
				intPtr = (IntPtr)0;
				if (flag2)
				{
					goto IL_0324;
				}
				ResultContainer resultContainer = result2;
				bool flag3 = resultContainer.ResultDictionary.Remove("authResponse");
				enumerator = value.GetEnumerator();
				intPtr = (IntPtr)0;
				for (; enumerator.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ X0_v96 (System.Boolean)+8]"), intPtr = (IntPtr)0, Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1371.m_value (System.Boolean) (should have been resolved before IL gen)"))
				{
					KeyValuePair<string, object> current = enumerator.Current;
					ResultContainer resultContainer2 = result2;
					IDictionary<string, object> resultDictionary = resultContainer2.ResultDictionary;
					bool flag6;
					if (resultContainer2.ResultDictionary != null)
					{
						IntPtr intPtr2 = (IntPtr)resultDictionary;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
							object obj = 0L + 8L;
							int num = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1324 @ X11_v47-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
								{
									break;
								}
								num++;
								int num2 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ X8_v84 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
								bool flag4 = (long)num2 < 0L;
								bool flag5 = !flag4;
								obj = (long)(IntPtr)obj + 16L;
								if (!flag5)
								{
									continue;
								}
								goto IL_0197;
							}
							object obj2 = obj + 1;
							int num3 = (int)((long)(IntPtr)obj2 << 4);
							object obj3 = (long)intPtr2 + (long)num3;
							flag6 = (byte)((ulong)(long)(IntPtr)obj3 + 304uL) != 0;
							continue;
						}
						goto IL_0197;
					}
					goto IL_024d;
					IL_0197:
					flag6 = resultContainer2.ResultDictionary.TryGetValue<IDictionary<string, object>>((string)(object)typeof(IDictionary<string, object>), out *(IDictionary<string, object>*)1);
				}
				bool flag7 = enumerator == null;
				bool flag8 = !flag7;
				num4 = 0;
				flag9 = false;
				if (!flag8)
				{
					num5 = 0;
					flag10 = false;
					goto IL_077e;
				}
				goto IL_07b4;
			}
			ResultContainer obj4 = result;
			Utilities.Callback<ResultContainer> callback3 = callback;
			goto IL_06c2;
			IL_067d:
			IDictionary<string, object> dictionary;
			bool flag11 = dictionary.TryGetValue<IDictionary<string, object>>(null, out *(IDictionary<string, object>*)null);
			goto IL_0691;
			IL_07fc:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v719.m_value (System.Boolean) (should have been resolved before IL gen)");
			object obj5 = default(object);
			if ((int)((long)(IntPtr)obj5 & 1L) == 0)
			{
				goto IL_057c;
			}
			ResultContainer resultContainer3 = result2;
			IDictionary<string, object> resultDictionary2 = resultContainer3.ResultDictionary;
			IntPtr intPtr3 = (IntPtr)resultDictionary2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v27 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_051c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v27 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj6 = 0L + 8L;
			int num6 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v990 @ X11_v21-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num6++;
				int num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v27 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag12 = (long)num7 < 0L;
				bool flag13 = !flag12;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag13)
				{
					continue;
				}
				goto IL_051c;
			}
			object obj7 = obj6 + 3;
			int num8 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr3 + (long)num8;
			bool flag14 = (byte)((ulong)(long)(IntPtr)obj8 + 304uL) != 0;
			goto IL_085c;
			IL_0324:
			ResultContainer resultContainer4 = result2;
			IDictionary<string, object> resultDictionary3 = resultContainer4.ResultDictionary;
			IntPtr intPtr4 = (IntPtr)resultDictionary3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03f0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj9 = 0L + 8L;
			int num9 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ X11_v26-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num9++;
				int num10 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ X8_v19 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag15 = (long)num10 < 0L;
				bool flag16 = !flag15;
				obj9 = (long)(IntPtr)obj9 + 16L;
				if (!flag16)
				{
					continue;
				}
				goto IL_03f0;
			}
			object obj10 = obj9 + 3;
			int num11 = (int)((long)(IntPtr)obj10 << 4);
			object obj11 = (long)intPtr4 + (long)num11;
			bool flag17 = (byte)((ulong)(long)(IntPtr)obj11 + 304uL) != 0;
			goto IL_07fc;
			IL_085c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1040.m_value (System.Boolean) (should have been resolved before IL gen)");
			object obj12 = default(object);
			if ((int)((long)(IntPtr)obj12 & 1L) == 0)
			{
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				dictionary2.Add("fields", "permissions");
				ResultContainer resultContainer5 = result2;
				string text = (string)resultContainer5.ResultDictionary.get_Item(LoginResult.AccessTokenKey);
				if (text == null || (object)text.GetType() == typeof(string))
				{
					dictionary2.Add("access_token", text);
					FacebookDelegate<IGraphResult> callback4 = delegate(IGraphResult r)
					{
						//IL_000d: Expected I, but got O
						//IL_0048: Expected O, but got I
						//IL_0114: Expected I, but got O
						//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d3: Expected O, but got Unknown
						//IL_00f0: Expected O, but got I
						//IL_00ff: Expected O, but got I
						//IL_0094: Expected O, but got I
						//IL_014f: Expected O, but got I
						//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
						//IL_01da: Expected O, but got Unknown
						//IL_01f7: Expected O, but got I
						//IL_0206: Expected O, but got I
						//IL_019b: Expected O, but got I
						//IL_05d5: Expected I, but got O
						//IL_0610: Expected O, but got I
						//IL_069f: Unknown result type (might be due to invalid IL or missing references)
						//IL_06a4: Expected O, but got Unknown
						//IL_06c1: Expected O, but got I
						//IL_065c: Expected O, but got I
						//IL_0336: Expected I, but got O
						//IL_0527: Expected O, but got I4
						//IL_0371: Expected O, but got I
						//IL_043d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0442: Expected O, but got Unknown
						//IL_045f: Expected O, but got I
						//IL_03bd: Expected O, but got I
						IntPtr intPtr6 = (IntPtr)r;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_00ad;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
						object obj13 = 0L + 8L;
						int num12 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X11_v60-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IResult))
							{
								break;
							}
							num12++;
							int num13 = num12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
							bool flag22 = (long)num13 < 0L;
							bool flag23 = !flag22;
							obj13 = (long)(IntPtr)obj13 + 16L;
							if (!flag23)
							{
								continue;
							}
							goto IL_00ad;
						}
						object obj14 = obj13 + 1;
						int num14 = (int)((long)(IntPtr)obj14 << 4);
						object obj15 = (long)intPtr6 + (long)num14;
						object obj16 = (long)(IntPtr)obj15 + 304L;
						IntPtr intPtr7 = default(IntPtr);
						int num15 = (int)(long)intPtr7;
						goto IL_0731;
						IL_08a9:
						IEnumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
						bool flag25;
						bool flag24 = flag25;
						int num17;
						int num16 = num17;
						goto IL_0873;
						IL_0675:
						IDictionary<string, object> resultDictionary4;
						bool flag26 = resultDictionary4.TryGetValue<IList<object>>((string)(object)typeof(IDictionary<string, object>), out *(IList<object>*)1);
						goto IL_0905;
						IL_05ac:
						ResultContainer resultContainer6 = result2;
						resultDictionary4 = resultContainer6.ResultDictionary;
						List<string> list;
						string text3 = list.ToCommaSeparateList();
						IntPtr intPtr8 = (IntPtr)resultDictionary4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0675;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
						object obj17 = 0L + 8L;
						int num18 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1043 @ X11_v14-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
							{
								break;
							}
							num18++;
							int num19 = num18;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
							bool flag27 = (long)num19 < 0L;
							bool flag28 = !flag27;
							obj17 = (long)(IntPtr)obj17 + 16L;
							if (!flag28)
							{
								continue;
							}
							goto IL_0675;
						}
						object obj18 = obj17 + 1;
						int num20 = (int)((long)(IntPtr)obj18 << 4);
						object obj19 = (long)intPtr8 + (long)num20;
						flag26 = (byte)((ulong)(long)(IntPtr)obj19 + 304uL) != 0;
						goto IL_0905;
						IL_04c6:
						NullReferenceException dictionary3 = new NullReferenceException();
						string text4 = default(string);
						if ((IntPtr)text4 != (IntPtr)1)
						{
							NullReferenceException dictionary4 = default(NullReferenceException);
							string key = default(string);
							ref string value3 = default(ref string);
							bool flag29 = ((IDictionary<string, object>)dictionary4).TryGetValue<string>(key, out value3);
							goto IL_0701;
						}
						ref string value4 = default(ref string);
						bool flag30 = ((IDictionary<string, object>)dictionary3).TryGetValue<string>(text4, out value4);
						flag25 = ((bool*)(flag30 ? 1 : 0))->m_value;
						bool flag31 = ((IDictionary<string, object>)flag30).TryGetValue<string>(text4, out value4);
						bool flag32 = enumerator2 == null;
						num17 = -1;
						flag24 = ((bool*)(flag30 ? 1 : 0))->m_value;
						num16 = -1;
						if (flag32)
						{
							goto IL_0873;
						}
						goto IL_08a9;
						IL_00ad:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num15 = 1;
						goto IL_0731;
						IL_0731:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v380 @ X0_v12] (should have been resolved before IL gen)");
						object obj20 = default(object);
						if (obj20 == null)
						{
							goto IL_0259;
						}
						IntPtr intPtr9 = (IntPtr)r;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v21 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_01b4;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v21 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
						object obj21 = 0L + 8L;
						int num21 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X11_v55-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IResult))
							{
								break;
							}
							num21++;
							int num22 = num21;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v21 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
							bool flag33 = (long)num22 < 0L;
							bool flag34 = !flag33;
							obj21 = (long)(IntPtr)obj21 + 16L;
							if (!flag34)
							{
								continue;
							}
							goto IL_01b4;
						}
						object obj22 = obj21 + 1;
						int num23 = (int)((long)(IntPtr)obj22 << 4);
						object obj23 = (long)intPtr9 + (long)num23;
						object obj24 = (long)(IntPtr)obj23 + 304L;
						goto IL_0783;
						IL_0905:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1089.m_value (System.Boolean) (should have been resolved before IL gen)");
						goto IL_06d5;
						IL_06d5:
						callback2(result2);
						return;
						IL_0873:
						if (num16 + 1 != 0)
						{
							goto IL_05ac;
						}
						if (!flag24)
						{
							goto IL_059d;
						}
						goto IL_0701;
						IL_059d:
						FacebookLogger.Warn("Failed to extract data from permissions");
						goto IL_05ac;
						IL_0701:
						throw new TypeLoadException();
						IL_01b4:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num15 = 1;
						goto IL_0783;
						IL_0783:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v611 @ X0_v22] (should have been resolved before IL gen)");
						IDictionary<string, object> dictionary5 = default(IDictionary<string, object>);
						if (!dictionary5.TryGetValue<IDictionary<string, object>>("permissions", out var value5))
						{
							goto IL_0259;
						}
						list = new List<string>();
						if (!value5.TryGetValue<IList<object>>("data", out var value6))
						{
							goto IL_059d;
						}
						enumerator2 = value6.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							object current2 = ((IEnumerator<object>)enumerator2).Current;
							IDictionary<string, object> dictionary6 = current2 as IDictionary<string, object>;
							if (dictionary6 == null)
							{
								FacebookLogger.Warn("Failed to case permission dictionary");
								continue;
							}
							if (!dictionary6.TryGetValue<string>("status", out var value7) || !value7.Equals("granted", StringComparison.InvariantCultureIgnoreCase))
							{
								FacebookLogger.Warn("Didn't find status in permissions result");
								continue;
							}
							if (!dictionary6.TryGetValue<string>("permission", out var _))
							{
								FacebookLogger.Warn("Didn't find permission name");
								continue;
							}
							if (list == null)
							{
								goto IL_04c6;
							}
							IntPtr intPtr10 = (IntPtr)list;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1332 @ X8_v87 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_03d6;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1332 @ X8_v87 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+B0]");
							object obj25 = 0L + 8L;
							int num24 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ X11_v35-8]");
								if ((IntPtr)0 == (IntPtr)typeof(ICollection<string>))
								{
									break;
								}
								num24++;
								int num25 = num24;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1332 @ X8_v87 (Il2CppClass<System.Collections.Generic.List`1<System.String>>)+126]");
								bool flag35 = (long)num25 < 0L;
								bool flag36 = !flag35;
								obj25 = (long)(IntPtr)obj25 + 16L;
								if (!flag36)
								{
									continue;
								}
								goto IL_03d6;
							}
							object obj26 = obj25 + 2;
							int num26 = (int)((long)(IntPtr)obj26 << 4);
							object obj27 = (long)intPtr10 + (long)num26;
							bool flag37 = (byte)((ulong)(long)(IntPtr)obj27 + 304uL) != 0;
							goto IL_085e;
							IL_03d6:
							flag37 = ((IDictionary<string, object>)list).TryGetValue<string>((string)(object)typeof(ICollection<string>), out *(string*)2);
							goto IL_085e;
							IL_085e:
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1402.m_value (System.Boolean) (should have been resolved before IL gen)");
						}
						bool flag38 = enumerator2 == null;
						bool flag39 = !flag38;
						flag25 = false;
						num17 = 0;
						if (!flag39)
						{
							flag24 = false;
							num16 = 0;
							goto IL_0873;
						}
						goto IL_08a9;
						IL_0259:
						FacebookLogger.Warn("Failed to load permissions for access token");
						goto IL_06d5;
					};
					FB.API("me", default(HttpMethod), callback4, dictionary2);
					return;
				}
				goto IL_0691;
			}
			goto IL_057c;
			IL_0691:
			throw new InvalidCastException();
			IL_051c:
			flag14 = resultDictionary2.TryGetValue<IDictionary<string, object>>((string)(object)typeof(IDictionary<string, object>), out *(IDictionary<string, object>*)3);
			goto IL_085c;
			IL_06c2:
			callback3(obj4);
			return;
			IL_024d:
			NullReferenceException ex = new NullReferenceException();
			string text2 = default(string);
			bool flag18 = (IntPtr)text2 != (IntPtr)1;
			dictionary = (IDictionary<string, object>)ex;
			if (flag18)
			{
				goto IL_067d;
			}
			ref IDictionary<string, object> value2 = default(ref IDictionary<string, object>);
			bool flag19 = ((IDictionary<string, object>)ex).TryGetValue<IDictionary<string, object>>(text2, out value2);
			flag9 = ((bool*)(flag19 ? 1 : 0))->m_value;
			bool flag20 = ((IDictionary<string, object>)flag19).TryGetValue<IDictionary<string, object>>(text2, out value2);
			bool flag21 = enumerator == null;
			num4 = -1;
			num5 = -1;
			flag10 = ((bool*)(flag19 ? 1 : 0))->m_value;
			if (flag21)
			{
				goto IL_077e;
			}
			goto IL_07b4;
			IL_057c:
			callback3 = callback2;
			obj4 = result2;
			goto IL_06c2;
			IL_07b4:
			enumerator.Dispose();
			num5 = num4;
			flag10 = flag9;
			goto IL_077e;
			IL_077e:
			if (num5 + 1 != 0 || !flag10)
			{
				goto IL_0324;
			}
			TypeLoadException ex2 = new TypeLoadException();
			IntPtr intPtr5 = default(IntPtr);
			intPtr = intPtr5;
			dictionary = (IDictionary<string, object>)ex2;
			goto IL_067d;
			IL_03f0:
			flag17 = resultDictionary3.TryGetValue<IDictionary<string, object>>((string)(object)typeof(IDictionary<string, object>), out *(IDictionary<string, object>*)3);
			goto IL_07fc;
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xD1F804", Offset = "0xD1F804", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_002B;\n\tv54 = *([1EB1180]);\n\tv55 = *([v54 @ X8_v35]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, product, productId, action, quantity, quantityMin, quantityMax, requestId, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = 0 | 1;\n\t*([2023B79]) = v67;\nL_002B:\n\tv71 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v71);\n\tFacebook.Unity.MethodArguments::AddString(v71, \"product\", product);\n\tFacebook.Unity.MethodArguments::AddString(v71, \"product_id\", productId);\n\tFacebook.Unity.MethodArguments::AddString(v71, \"action\", action);\n\tFacebook.Unity.MethodArguments::AddPrimative(v71, \"quantity\", quantity);\n\tFacebook.Unity.MethodArguments::AddNullablePrimitive(v71, \"quantity_min\", quantityMin);\n\tFacebook.Unity.MethodArguments::AddNullablePrimitive(v71, \"quantity_max\", quantityMax);\n\tFacebook.Unity.MethodArguments::AddString(v71, \"request_id\", requestId);\n\tFacebook.Unity.MethodArguments::AddString(v71, \"pricepoint_id\", *([v24 @ X29_v1+10]));\n\tFacebook.Unity.MethodArguments::AddString(v71, \"test_currency\", *([v24 @ X29_v1+18]));\n\tFacebook.Unity.MethodArguments::AddString(v71, \"developer_payload\", *([v24 @ X29_v1+20]));\n\tv94 = new Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>();\n\tFacebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>::.ctor(v94, this, \"pay\", \"OnPayComplete\");\n\tv149 = *([v94 @ X0_v18 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>)]);\n\tv94.<Callback>k__BackingField = *([v24 @ X29_v1+28]);\n\tv118 = *([v149 @ X8_v32 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>>)+170]);\n\tv124 = *([v149 @ X8_v32 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>>)+178]);\n\t// 153 IndirectJump v118 @ X3_v6, v94 @ X0_v18 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>), v94 @ X0_v18 (Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>), v71 @ X0_v3 (Facebook.Unity.MethodArguments), v124 @ X2_v13, v118 @ X3_v6, methodof(Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>::.ctor), quantityMin @ X5 (System.Nullable`1<System.Int32>), quantityMax @ X6 (System.Nullable`1<System.Int32>), requestId @ X7 (System.String), v57 @ V0, v58 @ V1, v59 @ V2, v60 @ V3, v61 @ V4, v62 @ V5, v63 @ V6, v64 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PayImpl(string product, string productId, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, string developerPayload, FacebookDelegate<IPayResult> callback)
		{
			//IL_00b4: Expected O, but got I
			//IL_00d3: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_0114: Expected I, but got O
			//IL_0129: Expected O, but got I
			//IL_0139: Expected O, but got I
			//IL_0149: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddString("product", product);
				methodArguments.AddString("product_id", productId);
				methodArguments.AddString("action", action);
				methodArguments.AddPrimative("quantity", quantity);
				methodArguments.AddNullablePrimitive("quantity_min", quantityMin);
				methodArguments.AddNullablePrimitive("quantity_max", quantityMax);
				methodArguments.AddString("request_id", requestId);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
				methodArguments.AddString("pricepoint_id", (string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
				methodArguments.AddString("test_currency", (string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
				methodArguments.AddString("developer_payload", (string)0);
				CanvasUIMethodCall<IPayResult> canvasUIMethodCall = new CanvasUIMethodCall<IPayResult>(this, "pay", "OnPayComplete");
				IntPtr intPtr = (IntPtr)canvasUIMethodCall;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
				canvasUIMethodCall.Callback = (FacebookDelegate<IPayResult>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v32 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>>)+170]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v32 (Il2CppClass<Facebook.Unity.Canvas.CanvasFacebook+CanvasUIMethodCall`1<Facebook.Unity.IPayResult>>)+178]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v6 (should have been resolved before IL gen)");
			}
		}
	}
}
