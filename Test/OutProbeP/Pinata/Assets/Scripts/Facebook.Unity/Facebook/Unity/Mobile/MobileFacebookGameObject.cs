using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile
{
	[Token(Token = "0x2000062")]
	internal abstract class MobileFacebookGameObject : FacebookGameObject, IFacebookCallbackHandler
	{
		[Token(Token = "0x1700007E")]
		private IMobileFacebookImplementation MobileFacebook
		{
			[Token(Token = "0x600024A")]
			[Address(RVA = "0xD33C58", Offset = "0xD33C58", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC9718]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C8E]) = v38;\nL_0014:\n\tv40 = this.<Facebook>k__BackingField == 0;\n\tif (v40) goto L_FFFFFFFF;\n\t// 27 IsInst returnVal1 @ X0_v2 (Facebook.Unity.Mobile.IMobileFacebookImplementation), typeof(Facebook.Unity.Mobile.IMobileFacebookImplementation), this.<Facebook>k__BackingField (Facebook.Unity.IFacebookImplementation)\n\tv56 = returnVal1 == 0;\n\tv52 = ~v56;\n\tif (v52) goto L_0028;\n\tthrow System.InvalidCastException;\nL_0028:\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IMobileFacebookImplementation mobileFacebookImplementation;
				if (Facebook != null)
				{
					mobileFacebookImplementation = Facebook as IMobileFacebookImplementation;
					if (mobileFacebookImplementation == null)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					mobileFacebookImplementation = null;
				}
				return mobileFacebookImplementation;
			}
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xD33CCC", Offset = "0xD33CCC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE32C0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C8F]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Mobile.MobileFacebookGameObject::get_MobileFacebook(this);\n\tv49 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v49, message);\n\tgoto L_0056;\n\tv61 = *([v54 @ X8_v6+B0]);\n\tv62 = 0;\n\tv63 = v61 + 8;\n\tv65 = *([v112 @ X11_v5-8]);\n\tv118 = v65 == v57;\n\tif (v118) goto L_0048;\n\tv98 = v113 + 1;\n\tv175 = v98 < v56;\n\tv92 = ~v175;\n\tv95 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_FFFFFFFF;\n\tv99 = v46;\n\tv100 = 0;\n\tv101 = 0x8909C4(v99, v57, v100, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0056;\nL_0048:\n\tv176 = *([v112 @ X11_v5]);\n\tv177 = v176 << 4;\n\tv178 = v54 + v177;\n\tv179 = v178 + 0x130;\nL_0056:\n\tFacebook.Unity.Mobile.IMobileFacebookResultHandler::OnFetchDeferredAppLinkComplete(v43, v49);\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFetchDeferredAppLinkComplete(string message)
		{
			IMobileFacebookImplementation mobileFacebook = MobileFacebook;
			ResultContainer resultContainer = new ResultContainer(message);
			mobileFacebook.OnFetchDeferredAppLinkComplete(resultContainer);
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xD33DB8", Offset = "0xD33DB8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE3D58]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C90]) = v41;\nL_0016:\n\tv43 = Facebook.Unity.Mobile.MobileFacebookGameObject::get_MobileFacebook(this);\n\tv49 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v49, message);\n\tv54 = *([v43 @ X0_v3 (Facebook.Unity.Mobile.IMobileFacebookImplementation)]);\n\tv58 = *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+126]) == 0;\n\tif (v58) goto L_0046;\n\tv112 = *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+B0]) + 8;\nL_0031:\n\tv118 = *([v112 @ X11_v5-8]) == Facebook.Unity.Mobile.IMobileFacebookResultHandler;\n\tif (v118) goto L_0049;\n\tv113 = v113 + 1;\n\tv175 = v113 < *([v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+126]);\n\tv92 = ~v175;\n\tv112 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_0031;\nL_0046:\n\tv182 = 0x8909C4(v43, Facebook.Unity.Mobile.IMobileFacebookResultHandler, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_0049:\n\tv177 = *([v112 @ X11_v5]) + 1;\n\tv178 = v177 << 4;\n\tv179 = v54 + v178;\n\tv182 = v179 + 0x130;\nL_004D:\n\tv126 = *([v182 @ X0_v8]);\n\tv133 = *([v182 @ X0_v8+8]);\n\t// 87 IndirectJump v126 @ X3_v1, v43 @ X0_v3 (Facebook.Unity.Mobile.IMobileFacebookImplementation), v43 @ X0_v3 (Facebook.Unity.Mobile.IMobileFacebookImplementation), v49 @ X0_v5 (Facebook.Unity.ResultContainer), v133 @ X2_v2, v126 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnRefreshCurrentAccessTokenComplete(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IMobileFacebookImplementation mobileFacebook = MobileFacebook;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)mobileFacebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IMobileFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Facebook.Unity.Mobile.IMobileFacebookImplementation>)+126]");
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

		[Token(Token = "0x600024D")]
		[Address(RVA = "0xD32098", Offset = "0xD32098", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal MobileFacebookGameObject()
		{
		}
	}
}
