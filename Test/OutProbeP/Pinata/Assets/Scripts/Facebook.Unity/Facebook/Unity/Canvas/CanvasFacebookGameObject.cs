using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000071")]
	internal class CanvasFacebookGameObject : FacebookGameObject, ICanvasFacebookCallbackHandler, IFacebookCallbackHandler
	{
		[Token(Token = "0x1700008F")]
		protected ICanvasFacebookImplementation CanvasFacebookImpl
		{
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0xD216F0", Offset = "0xD216F0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F04698]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B7E]) = v38;\nL_0014:\n\tv40 = this.<Facebook>k__BackingField == 0;\n\tif (v40) goto L_FFFFFFFF;\n\t// 27 IsInst returnVal1 @ X0_v2 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), typeof(Facebook.Unity.Canvas.ICanvasFacebookImplementation), this.<Facebook>k__BackingField (Facebook.Unity.IFacebookImplementation)\n\tv56 = returnVal1 == 0;\n\tv52 = ~v56;\n\tif (v52) goto L_0028;\n\tthrow System.InvalidCastException;\nL_0028:\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ICanvasFacebookImplementation canvasFacebookImplementation;
				if (Facebook != null)
				{
					canvasFacebookImplementation = Facebook as ICanvasFacebookImplementation;
					if (canvasFacebookImplementation == null)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					canvasFacebookImplementation = null;
				}
				return canvasFacebookImplementation;
			}
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xD21764", Offset = "0xD21764", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB38F8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B7F]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Canvas.CanvasFacebookGameObject::get_CanvasFacebookImpl(this);\n\tv49 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v49, result);\n\tgoto L_0056;\n\tv61 = *([v54 @ X8_v6+B0]);\n\tv62 = 0;\n\tv63 = v61 + 8;\n\tv65 = *([v112 @ X11_v5-8]);\n\tv118 = v65 == v57;\n\tif (v118) goto L_0048;\n\tv98 = v113 + 1;\n\tv175 = v98 < v56;\n\tv92 = ~v175;\n\tv95 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_FFFFFFFF;\n\tv99 = v46;\n\tv100 = 0;\n\tv101 = 0x8909C4(v99, v57, v100, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0056;\nL_0048:\n\tv176 = *([v112 @ X11_v5]);\n\tv177 = v176 << 4;\n\tv178 = v54 + v177;\n\tv179 = v178 + 0x130;\nL_0056:\n\tFacebook.Unity.Canvas.ICanvasFacebookResultHandler::OnPayComplete(v43, v49);\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPayComplete(string result)
		{
			ICanvasFacebookImplementation canvasFacebookImpl = CanvasFacebookImpl;
			ResultContainer resultContainer = new ResultContainer(result);
			canvasFacebookImpl.OnPayComplete(resultContainer);
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xD21978", Offset = "0xD21978", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA50A0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B80]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Canvas.CanvasFacebookGameObject::get_CanvasFacebookImpl(this);\n\tv49 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v49, message);\n\tv54 = *([v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation)]);\n\tv58 = *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]) == 0;\n\tif (v58) goto L_0046;\n\tv112 = *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]) + 8;\nL_0031:\n\tv118 = *([v112 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookResultHandler;\n\tif (v118) goto L_0049;\n\tv113 = v113 + 1;\n\tv175 = v113 < *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]);\n\tv92 = ~v175;\n\tv112 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_0031;\nL_0046:\n\tv182 = 0x8909C4(v43, Facebook.Unity.Canvas.ICanvasFacebookResultHandler, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_0049:\n\tv177 = *([v112 @ X11_v5]) + 1;\n\tv178 = v177 << 4;\n\tv179 = v54 + v178;\n\tv182 = v179 + 0x130;\nL_004D:\n\tv126 = *([v182 @ X0_v8]);\n\tv133 = *([v182 @ X0_v8+8]);\n\t// 87 IndirectJump v126 @ X3_v1, v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), v49 @ X0_v5 (Facebook.Unity.ResultContainer), v133 @ X2_v2, v126 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookAuthResponseChange(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookImplementation canvasFacebookImpl = CanvasFacebookImpl;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)canvasFacebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
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
			goto IL_0147;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v126 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xD21A68", Offset = "0xD21A68", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA96E8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B81]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Canvas.CanvasFacebookGameObject::get_CanvasFacebookImpl(this);\n\tv47 = *([v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation)]);\n\tv51 = *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]) == 0;\n\tif (v51) goto L_003E;\n\tv104 = *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]) + 8;\nL_0029:\n\tv110 = *([v104 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookResultHandler;\n\tif (v110) goto L_0041;\n\tv105 = v105 + 1;\n\tv167 = v105 < *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]);\n\tv84 = ~v167;\n\tv104 = v104 + 0x10;\n\tv60 = ~v84;\n\tif (v60) goto L_0029;\nL_003E:\n\tv174 = 0x8909C4(v43, Facebook.Unity.Canvas.ICanvasFacebookResultHandler, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0045;\nL_0041:\n\tv169 = *([v104 @ X11_v5]) + 2;\n\tv170 = v169 << 4;\n\tv171 = v47 + v170;\n\tv174 = v171 + 0x130;\nL_0045:\n\tv118 = *([v174 @ X0_v5]);\n\tv125 = *([v174 @ X0_v5+8]);\n\t// 79 IndirectJump v118 @ X3_v1, v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), message @ X1 (System.String), v125 @ X2_v2, v118 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnUrlResponse(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookImplementation canvasFacebookImpl = CanvasFacebookImpl;
			IntPtr intPtr = (IntPtr)canvasFacebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
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
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v5+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xD21B34", Offset = "0xD21B34", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED4470]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, hide, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B82]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Canvas.CanvasFacebookGameObject::get_CanvasFacebookImpl(this);\n\tv47 = *([v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation)]);\n\tv51 = *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]) == 0;\n\tif (v51) goto L_003E;\n\tv104 = *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]) + 8;\nL_0029:\n\tv110 = *([v104 @ X11_v5-8]) == Facebook.Unity.Canvas.ICanvasFacebookResultHandler;\n\tif (v110) goto L_0041;\n\tv105 = v105 + 1;\n\tv167 = v105 < *([v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]);\n\tv84 = ~v167;\n\tv104 = v104 + 0x10;\n\tv60 = ~v84;\n\tif (v60) goto L_0029;\nL_003E:\n\tv174 = 0x8909C4(v43, Facebook.Unity.Canvas.ICanvasFacebookResultHandler, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0045;\nL_0041:\n\tv169 = *([v104 @ X11_v5]) + 3;\n\tv170 = v169 << 4;\n\tv171 = v47 + v170;\n\tv174 = v171 + 0x130;\nL_0045:\n\tv118 = *([v174 @ X0_v5]);\n\tv125 = *([v174 @ X0_v5+8]);\n\t// 79 IndirectJump v118 @ X3_v1, v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), v43 @ X0_v3 (Facebook.Unity.Canvas.ICanvasFacebookImplementation), hide @ X1 (System.Boolean), v125 @ X2_v2, v118 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnHideUnity(bool hide)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			ICanvasFacebookImplementation canvasFacebookImpl = CanvasFacebookImpl;
			IntPtr intPtr = (IntPtr)canvasFacebookImpl;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICanvasFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Facebook.Unity.Canvas.ICanvasFacebookImplementation>)+126]");
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
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v5+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xD21C00", Offset = "0xD21C00", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECEAB0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B83]) = v38;\nL_0016:\n\tv42 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v42, \"FacebookJsBridge\");\n\tv53 = UnityEngine.GameObject::AddComponent(v42);\n\tv66 = UnityEngine.GameObject::get_transform(v42);\n\tv70 = UnityEngine.Component::get_gameObject(this);\n\tv57 = UnityEngine.GameObject::get_transform(v70);\n\tUnityEngine.Transform::set_parent(v66, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAwake()
		{
			GameObject gameObject = new GameObject("FacebookJsBridge");
			JsBridge jsBridge = gameObject.AddComponent<JsBridge>();
			Transform transform = gameObject.transform;
			GameObject gameObject2 = base.gameObject;
			Transform parent = gameObject2.transform;
			transform.parent = parent;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xD21CC0", Offset = "0xD21CC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CanvasFacebookGameObject()
		{
		}
	}
}
