using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000077")]
	internal class JsBridge : MonoBehaviour
	{
		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x18")]
		private ICanvasFacebookCallbackHandler facebook;

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0xD21D64", Offset = "0xD21D64", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE6C30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B85]) = v38;\nL_0017:\n\tv43 = Facebook.Unity.ComponentFactory::GetComponent(1);\n\tthis.facebook = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			CanvasFacebookGameObject component = ComponentFactory.GetComponent<CanvasFacebookGameObject>(ComponentFactory.IfNotExist.ReturnNull);
			facebook = component;
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0xD21DBC", Offset = "0xD21DBC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F066F0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B86]) = v41;\nL_0015:\n\tv42 = this.facebook;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.IFacebookCallbackHandler;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.IFacebookCallbackHandler, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), responseJsonData @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnLoginComplete(string responseJsonData = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
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

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0xD21E84", Offset = "0xD21E84", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFDEC8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B87]) = v41;\nL_0015:\n\tv42 = this.facebook;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), responseJsonData @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookAuthResponseChange(string responseJsonData = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
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

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0xD21F4C", Offset = "0xD21F4C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F05C90]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B88]) = v41;\nL_001E:\n\tgoto L_004C;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v42;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v48, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tFacebook.Unity.Canvas.ICanvasFacebookCallbackHandler::OnPayComplete(this.facebook, responseJsonData);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPayComplete(string responseJsonData = "")
		{
			facebook.OnPayComplete(responseJsonData);
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0xD22010", Offset = "0xD22010", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA76F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B89]) = v41;\nL_0015:\n\tv42 = this.facebook;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.IFacebookCallbackHandler;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.IFacebookCallbackHandler, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 2;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), responseJsonData @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAppRequestsComplete(string responseJsonData = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
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

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0xD220D8", Offset = "0xD220D8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED16C8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B8A]) = v41;\nL_0015:\n\tv42 = this.facebook;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.IFacebookCallbackHandler;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.IFacebookCallbackHandler, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 3;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), responseJsonData @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnShareLinkComplete(string responseJsonData = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
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

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0xD221A0", Offset = "0xD221A0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC6DD0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, state, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B8B]) = v41;\nL_0016:\n\tv43 = this.facebook;\n\tv48 = System.String::op_Inequality(state, \"hide\");\n\tv52 = *([v43 @ X19_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv56 = *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v56) goto L_0043;\n\tv110 = *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_002E:\n\tv116 = *([v110 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler;\n\tif (v116) goto L_0046;\n\tv111 = v111 + 1;\n\tv173 = v111 < *([v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv90 = ~v173;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_002E;\nL_0043:\n\tv180 = 0x8909C4(v43, Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv175 = *([v110 @ X11_v5]) + 3;\n\tv176 = v175 << 4;\n\tv177 = v52 + v176;\n\tv180 = v177 + 0x130;\nL_004A:\n\tv124 = *([v180 @ X0_v6]);\n\tv131 = *([v180 @ X0_v6+8]);\n\t// 84 IndirectJump v124 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v43 @ X19_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v48 @ X0_v3 (System.Boolean), v131 @ X2_v3, v124 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookFocus(string state)
		{
			//IL_000d: Expected I, but got O
			//IL_015e: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			bool flag = state != "hide";
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v5 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
				bool flag2 = (long)num2 < 0L;
				bool flag3 = !flag2;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0146;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0146;
			IL_0146:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0xD22284", Offset = "0xD22284", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF6418]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, responseJsonData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B8C]) = v41;\nL_001E:\n\tgoto L_004C;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v42;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v48, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tFacebook.Unity.IFacebookCallbackHandler::OnInitComplete(this.facebook, responseJsonData);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitComplete(string responseJsonData = "")
		{
			facebook.OnInitComplete(responseJsonData);
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0xD22348", Offset = "0xD22348", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB1CF0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, url, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B8D]) = v41;\nL_0015:\n\tv42 = this.facebook;\n\tv45 = *([v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 2;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), v42 @ X20_v2 (Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler), url @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnUrlResponse(string url = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookCallbackHandler canvasFacebookCallbackHandler = facebook;
			IntPtr intPtr = (IntPtr)canvasFacebookCallbackHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookCallbackHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler>)+126]");
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

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xD22410", Offset = "0xD22410", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JsBridge()
		{
		}
	}
}
