using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000016")]
	internal abstract class FacebookGameObject : MonoBehaviour, IFacebookCallbackHandler
	{
		[Token(Token = "0x1700002A")]
		public IFacebookImplementation Facebook
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0xD2DA68", Offset = "0xD2DA68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Facebook>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Facebook;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0xD2DA70", Offset = "0xD2DA70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Facebook>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Facebook = value;
			}
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0xD2DA78", Offset = "0xD2DA78", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7878]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C1D]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tUnityEngine.Object::DontDestroyOnLoad(this);\n\tgoto L_0032;\n\tv59 = *([1ED9370]);\n\tv60 = *([v59 @ X8_v15]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, v53, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv64 = 0 | 1;\n\t*([2023CAB]) = v64;\nL_0032:\n\tv69.<CurrentAccessToken>k__BackingField = 0;\n\tv70 = this->klass;\n\tv73 = this->klass->vtable[10];\n\tv74 = this->klass->vtable[10];\n\t// 59 IndirectJump v73 @ X2_v1, this @ X0 (Facebook.Unity.FacebookGameObject), this @ X0 (Facebook.Unity.FacebookGameObject), v74 @ X1_v2, v73 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			//IL_0020: Expected I, but got O
			//IL_0030: Expected O, but got I
			//IL_0040: Expected O, but got I
			UnityEngine.Object.DontDestroyOnLoad(this);
			AccessToken.CurrentAccessToken = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v13 (Il2CppClass<Facebook.Unity.FacebookGameObject>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v13 (Il2CppClass<Facebook.Unity.FacebookGameObject>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v73 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0xD2DB28", Offset = "0xD2DB28", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EFAF20]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C1E]) = v41;\nL_0019:\n\tv46 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v46, message);\n\tgoto L_0053;\n\tv58 = *([v51 @ X8_v5+B0]);\n\tv59 = 0;\n\tv60 = v58 + 8;\n\tv62 = *([v109 @ X11_v5-8]);\n\tv115 = v62 == v54;\n\tif (v115) goto L_0045;\n\tv95 = v110 + 1;\n\tv172 = v95 < v53;\n\tv89 = ~v172;\n\tv92 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_FFFFFFFF;\n\tv96 = v43;\n\tv97 = 0;\n\tv98 = 0x8909C4(v96, v54, v97, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0053;\nL_0045:\n\tv173 = *([v109 @ X11_v5]);\n\tv174 = v173 << 4;\n\tv175 = v51 + v174;\n\tv176 = v175 + 0x130;\nL_0053:\n\tFacebook.Unity.IFacebookResultHandler::OnInitComplete(this.<Facebook>k__BackingField, v46);\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitComplete(string message)
		{
			ResultContainer resultContainer = new ResultContainer(message);
			Facebook.OnInitComplete(resultContainer);
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0xD2DC08", Offset = "0xD2DC08", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED51A0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C1F]) = v41;\nL_0016:\n\tv43 = this.<Facebook>k__BackingField;\n\tv46 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v46, message);\n\tv51 = *([v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation)]);\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]) == 0;\n\tif (v55) goto L_0043;\n\tv109 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]) + 8;\nL_002E:\n\tv115 = *([v109 @ X11_v5-8]) == Facebook.Unity.IFacebookResultHandler;\n\tif (v115) goto L_0046;\n\tv110 = v110 + 1;\n\tv172 = v110 < *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]);\n\tv89 = ~v172;\n\tv109 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002E;\nL_0043:\n\tv179 = 0x8909C4(v43, Facebook.Unity.IFacebookResultHandler, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv174 = *([v109 @ X11_v5]) + 1;\n\tv175 = v174 << 4;\n\tv176 = v51 + v175;\n\tv179 = v176 + 0x130;\nL_004A:\n\tv123 = *([v179 @ X0_v6]);\n\tv130 = *([v179 @ X0_v6+8]);\n\t// 84 IndirectJump v123 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v46 @ X0_v3 (Facebook.Unity.ResultContainer), v130 @ X2_v2, v123 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnLoginComplete(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IFacebookImplementation facebook = Facebook;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0xD2DCEC", Offset = "0xD2DCEC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDAE08]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C20]) = v41;\nL_0016:\n\tv43 = this.<Facebook>k__BackingField;\n\tv46 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v46, message);\n\tv51 = *([v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation)]);\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]) == 0;\n\tif (v55) goto L_0043;\n\tv109 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]) + 8;\nL_002E:\n\tv115 = *([v109 @ X11_v5-8]) == Facebook.Unity.IFacebookResultHandler;\n\tif (v115) goto L_0046;\n\tv110 = v110 + 1;\n\tv172 = v110 < *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]);\n\tv89 = ~v172;\n\tv109 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002E;\nL_0043:\n\tv179 = 0x8909C4(v43, Facebook.Unity.IFacebookResultHandler, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv174 = *([v109 @ X11_v5]) + 2;\n\tv175 = v174 << 4;\n\tv176 = v51 + v175;\n\tv179 = v176 + 0x130;\nL_004A:\n\tv123 = *([v179 @ X0_v6]);\n\tv130 = *([v179 @ X0_v6+8]);\n\t// 84 IndirectJump v123 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v46 @ X0_v3 (Facebook.Unity.ResultContainer), v130 @ X2_v2, v123 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnLogoutComplete(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IFacebookImplementation facebook = Facebook;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
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
			goto IL_0147;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xD2DDD0", Offset = "0xD2DDD0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC6DD8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C21]) = v41;\nL_0016:\n\tv43 = this.<Facebook>k__BackingField;\n\tv46 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v46, message);\n\tv51 = *([v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation)]);\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]) == 0;\n\tif (v55) goto L_0043;\n\tv109 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]) + 8;\nL_002E:\n\tv115 = *([v109 @ X11_v5-8]) == Facebook.Unity.IFacebookResultHandler;\n\tif (v115) goto L_0046;\n\tv110 = v110 + 1;\n\tv172 = v110 < *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]);\n\tv89 = ~v172;\n\tv109 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002E;\nL_0043:\n\tv179 = 0x8909C4(v43, Facebook.Unity.IFacebookResultHandler, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv174 = *([v109 @ X11_v5]) + 3;\n\tv175 = v174 << 4;\n\tv176 = v51 + v175;\n\tv179 = v176 + 0x130;\nL_004A:\n\tv123 = *([v179 @ X0_v6]);\n\tv130 = *([v179 @ X0_v6+8]);\n\t// 84 IndirectJump v123 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v46 @ X0_v3 (Facebook.Unity.ResultContainer), v130 @ X2_v2, v123 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnGetAppLinkComplete(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IFacebookImplementation facebook = Facebook;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
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
			goto IL_0147;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xD2DEB4", Offset = "0xD2DEB4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBEE30]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C22]) = v41;\nL_0016:\n\tv43 = this.<Facebook>k__BackingField;\n\tv46 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v46, message);\n\tv51 = *([v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation)]);\n\tv55 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]) == 0;\n\tif (v55) goto L_0043;\n\tv109 = *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]) + 8;\nL_002E:\n\tv115 = *([v109 @ X11_v5-8]) == Facebook.Unity.IFacebookResultHandler;\n\tif (v115) goto L_0046;\n\tv110 = v110 + 1;\n\tv172 = v110 < *([v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]);\n\tv89 = ~v172;\n\tv109 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002E;\nL_0043:\n\tv179 = 0x8909C4(v43, Facebook.Unity.IFacebookResultHandler, 4, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0046:\n\tv174 = *([v109 @ X11_v5]) + 4;\n\tv175 = v174 << 4;\n\tv176 = v51 + v175;\n\tv179 = v176 + 0x130;\nL_004A:\n\tv123 = *([v179 @ X0_v6]);\n\tv130 = *([v179 @ X0_v6+8]);\n\t// 84 IndirectJump v123 @ X3_v1, v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v43 @ X19_v2 (Facebook.Unity.IFacebookImplementation), v46 @ X0_v3 (Facebook.Unity.ResultContainer), v130 @ X2_v2, v123 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAppRequestsComplete(string message)
		{
			//IL_000d: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IFacebookImplementation facebook = Facebook;
			ResultContainer resultContainer = new ResultContainer(message);
			IntPtr intPtr = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookResultHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v5 (Il2CppClass<Facebook.Unity.IFacebookImplementation>)+126]");
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
			goto IL_0147;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xD2DF98", Offset = "0xD2DF98", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv21 = *([1EA91C0]);\n\tv22 = *([v21 @ X8_v8]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C23]) = v40;\nL_0019:\n\tv45 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v45, message);\n\tv51 = 0xD34E98(v45, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n\tX9 = *([X8+126]);\n\tX1 = *([1EE6000]);\n\tif (TEMP) goto L_0042;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_002A:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0046;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_002A;\nL_0042:\n\tX2 = 5;\n\tX0 = X19;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_004B;\nL_0046:\n\tX9 = *([X11]);\n\tX9 = X9 + 5;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_004B:\n\tX3 = *([X0]);\n\tX2 = *([X0+8]);\n\tX0 = X19;\n\tX1 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 84 ShiftStack 48\n\t// 85 IndirectJump X3, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnShareLinkComplete(string message)
		{
			ResultContainer resultContainer = new ResultContainer(message);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @D34E98 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x34)");
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xD2E07C", Offset = "0xD2E07C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnAwake()
		{
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xD21CC8", Offset = "0xD21CC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal FacebookGameObject()
		{
		}
	}
}
