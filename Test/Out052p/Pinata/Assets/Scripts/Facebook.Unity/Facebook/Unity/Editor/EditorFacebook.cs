using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;
using Facebook.Unity.Canvas;
using Facebook.Unity.Mobile;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000054")]
	internal class EditorFacebook : FacebookBase, IMobileFacebookImplementation, IMobileFacebook, IFacebook, IMobileFacebookResultHandler, IFacebookResultHandler, ICanvasFacebookImplementation, IPayFacebook, ICanvasFacebookResultHandler
	{
		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x28")]
		private IEditorWrapper editorWrapper;

		[CompilerGenerated]
		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x30")]
		private bool _003CLimitEventUsage_003Ek__BackingField;

		[Token(Token = "0x1700006E")]
		public override bool LimitEventUsage
		{
			[CompilerGenerated]
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0xD26DE4", Offset = "0xD26DE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LimitEventUsage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LimitEventUsage;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0xD26DEC", Offset = "0xD26DEC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LimitEventUsage>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CLimitEventUsage_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700006F")]
		public ShareDialogMode ShareDialogMode
		{
			[CompilerGenerated]
			[Token(Token = "0x60001E6")]
			[Address(RVA = "0xD26DF8", Offset = "0xD26DF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ShareDialogMode>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ShareDialogMode = value;
			}
		}

		[Token(Token = "0x17000070")]
		public override string SDKName
		{
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0xD26E00", Offset = "0xD26E00", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EA4A68]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BB7]) = v35;\nL_0018:\n\treturn \"FBUnityEditorSDK\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "FBUnityEditorSDK";
			}
		}

		[Token(Token = "0x17000071")]
		public override string SDKVersion
		{
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0xD26E48", Offset = "0xD26E48", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE6770]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C31]) = v35;\nL_0018:\n\treturn \"7.18.0\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "7.18.0";
			}
		}

		[Token(Token = "0x17000072")]
		private static IFacebookCallbackHandler EditorGameObject
		{
			[Token(Token = "0x60001E9")]
			[Address(RVA = "0xD26D6C", Offset = "0xD26D6C", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1F02B30]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BB8]) = v35;\nL_0019:\n\treturnVal1 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ComponentFactory.GetComponent<EditorFacebookGameObject>();
			}
		}

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0xD26C98", Offset = "0xD26C98", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\tthis.editorWrapper = wrapper;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorFacebook(IEditorWrapper wrapper, CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
			editorWrapper = wrapper;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0xD26CD0", Offset = "0xD26CD0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFDFF8]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BB6]) = v40;\nL_0014:\n\tv41 = Facebook.Unity.Editor.EditorFacebook::get_EditorGameObject();\n\tv47 = new Facebook.Unity.Editor.EditorWrapper();\n\tSystem.Object::.ctor(v47);\n\t*([v47 @ X0_v4 (System.Object)+10]) = v41;\n\tv53 = new Facebook.Unity.CallbackManager();\n\tFacebook.Unity.CallbackManager::.ctor(v53);\n\tSystem.Object::.ctor(v38);\n\tv38.<CallbackManager>k__BackingField = v53;\n\tv38.editorWrapper = v47;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorFacebook()
		{
			IFacebookCallbackHandler editorGameObject = EditorGameObject;
			object obj = null;
			CallbackManager callbackManager = new CallbackManager();
			CallbackManager = callbackManager;
			editorWrapper = (IEditorWrapper)obj;
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0xD26E90", Offset = "0xD26E90", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE2C98]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, onInitComplete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BB9]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, onInitComplete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tFacebook.Unity.FacebookLogger::Warn(\"You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.\");\n\tthis.onInitCompleteDelegate = onInitComplete;\n\tgoto L_005C;\n\tv68 = *([v61 @ X8_v9+B0]);\n\tv69 = 0;\n\tv70 = v68 + 8;\n\tv72 = *([v119 @ X11_v5-8]);\n\tv125 = v72 == v64;\n\tif (v125) goto L_004F;\n\tv105 = v120 + 1;\n\tv180 = v105 < v63;\n\tv99 = ~v180;\n\tv102 = v119 + 0x10;\n\tv75 = ~v99;\n\tif (v75) goto L_FFFFFFFF;\n\tv106 = v58;\n\tv107 = 0;\n\tv108 = 0x8909C4(v106, v64, v107, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005C;\nL_004F:\n\tv181 = *([v119 @ X11_v5]);\n\tv182 = v181 << 4;\n\tv183 = v61 + v182;\n\tv184 = v183 + 0x130;\nL_005C:\n\tFacebook.Unity.Editor.IEditorWrapper::Init(this.editorWrapper);\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Init(InitDelegate onInitComplete)
		{
			FacebookLogger.Warn("You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.");
			onInitCompleteDelegate = onInitComplete;
			editorWrapper.Init();
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0xD26F84", Offset = "0xD26F84", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[33];\n\tv3 = this->klass->vtable[33];\n\t// 3 IndirectJump v2 @ X4_v1, this @ X0 (Facebook.Unity.Editor.EditorFacebook), this @ X0 (Facebook.Unity.Editor.EditorFacebook), permissions @ X1 (System.Collections.Generic.IEnumerable`1<System.String>), callback @ X2 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>), v3 @ X3_v1, v2 @ X4_v1, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		public override void LogInWithReadPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+340]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+348]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0xD26F94", Offset = "0xD26F94", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EC0150]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, permissions, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023BBA]) = v46;\nL_0019:\n\tv48 = this.editorWrapper;\n\tv51 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tv55 = this->klass;\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v51, this, *([v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+3F8]));\n\tv92 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tv69 = Facebook.Unity.Utilities::ToCommaSeparateList(permissions);\n\tv166 = *([v48 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv152 = *([v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]) == 0;\n\tif (v152) goto L_005A;\n\tv210 = *([v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]) + 8;\nL_0045:\n\tv216 = *([v210 @ X11_v5-8]) == Facebook.Unity.Editor.IEditorWrapper;\n\tif (v216) goto L_005D;\n\tv211 = v211 + 1;\n\tv221 = v211 < *([v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]);\n\tv192 = ~v221;\n\tv210 = v210 + 0x10;\n\tv176 = ~v192;\n\tif (v176) goto L_0045;\nL_005A:\n\tv228 = Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v48, Facebook.Unity.Editor.IEditorWrapper, 1);\n\tgoto L_0061;\nL_005D:\n\tv223 = *([v210 @ X11_v5]) + 1;\n\tv224 = v223 << 4;\n\tv225 = v166 + v224;\n\tv228 = v225 + 0x130;\nL_0061:\n\tv99 = *([v228 @ X0_v13 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv97 = *([v228 @ X0_v13 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]);\n\t// 111 IndirectJump v99 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), v48 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v48 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v51 @ X0_v3 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v92 @ X0_v10 (System.String), v69 @ X0_v12 (System.String), v97 @ X4_v1, v99 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithPublishPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_000a: Expected I, but got O
			//IL_003c: Expected I, but got O
			//IL_0177: Expected I, but got O
			//IL_0187: Expected O, but got I
			//IL_0077: Expected O, but got I
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_010c: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_00c3: Expected O, but got I
			Utilities.Callback<ResultContainer> callback2 = (Utilities.Callback<ResultContainer>)(object)editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+3F8]");
			Utilities.Callback<ResultContainer> callback3 = new Utilities.Callback<ResultContainer>(this, (IntPtr)0);
			IntPtr intPtr = (IntPtr)this;
			string text = CallbackManager.AddFacebookDelegate(callback);
			string text2 = permissions.ToCommaSeparateList();
			IntPtr intPtr2 = (IntPtr)callback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
			Utilities.Callback<ResultContainer> callback4 = default(Utilities.Callback<ResultContainer>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IEditorWrapper))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr2 + (long)num3;
					callback4 = (Utilities.Callback<ResultContainer>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr3 = (IntPtr)callback4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v13 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v99 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0xD270D4", Offset = "0xD270D4", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_0017;\n\tv23 = *([1F02B18]);\n\tv24 = *([v23 @ X8_v15]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BBB]) = v43;\nL_0017:\n\tv45 = this.editorWrapper;\n\tv48 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tv52 = this->klass;\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v48, this, *([v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+418]));\n\tv66 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v12 @ X29_v1+20]));\n\tv154 = *([v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv142 = *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]) == 0;\n\tif (v142) goto L_0055;\n\tv198 = *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]) + 8;\nL_0040:\n\tv204 = *([v198 @ X11_v5-8]) == Facebook.Unity.Editor.IEditorWrapper;\n\tif (v204) goto L_0058;\n\tv199 = v199 + 1;\n\tv209 = v199 < *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]);\n\tv180 = ~v209;\n\tv198 = v198 + 0x10;\n\tv164 = ~v180;\n\tif (v164) goto L_0040;\nL_0055:\n\tv216 = Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v45, Facebook.Unity.Editor.IEditorWrapper, 2);\n\tgoto L_005C;\nL_0058:\n\tv211 = *([v198 @ X11_v5]) + 2;\n\tv212 = v211 << 4;\n\tv213 = v154 + v212;\n\tv216 = v213 + 0x130;\nL_005C:\n\tv89 = *([v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv130 = *([v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]);\n\t// 104 IndirectJump v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v48 @ X0_v3 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v66 @ X0_v10 (System.String), v130 @ X3_v4, v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), filters @ X5 (System.Collections.Generic.IEnumerable`1<System.Object>), excludeIds @ X6 (System.Collections.Generic.IEnumerable`1<System.String>), maxRecipients @ X7 (System.Nullable`1<System.Int32>), v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback)
		{
			//IL_0012: Expected I, but got O
			//IL_002e: Expected O, but got I
			//IL_003f: Expected I, but got O
			//IL_017a: Expected I, but got O
			//IL_018a: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_010f: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00c6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Utilities.Callback<ResultContainer> callback2 = (Utilities.Callback<ResultContainer>)(object)editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+418]");
			Utilities.Callback<ResultContainer> callback3 = new Utilities.Callback<ResultContainer>(this, (IntPtr)0);
			IntPtr intPtr = (IntPtr)this;
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+20]");
			string text = callbackManager.AddFacebookDelegate((FacebookDelegate<IAppRequestResult>)0);
			IntPtr intPtr2 = (IntPtr)callback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
			Utilities.Callback<ResultContainer> callback4 = default(Utilities.Callback<ResultContainer>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]");
				object obj3 = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IEditorWrapper))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj3 = (long)(IntPtr)obj3 + 16L;
						continue;
					}
					object obj4 = obj3 + 2;
					int num3 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr2 + (long)num3;
					callback4 = (Utilities.Callback<ResultContainer>)((long)(IntPtr)obj5 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr3 = (IntPtr)callback4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xD271F8", Offset = "0xD271F8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA54F0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, contentURL, contentTitle, contentDescription, photoURL, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BBC]) = v43;\nL_0017:\n\tv45 = this.editorWrapper;\n\tv48 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tv52 = this->klass;\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v48, this, *([v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+428]));\n\tv66 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tv156 = *([v45 @ X19_v2 (Facebook.Unity.Editor.IEditorWrapper)]);\n\tv144 = *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+126]) == 0;\n\tif (v144) goto L_0058;\n\tv203 = *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+B0]) + 8;\nL_0043:\n\tv209 = *([v203 @ X11_v5-8]) == Facebook.Unity.Editor.IEditorWrapper;\n\tif (v209) goto L_005B;\n\tv204 = v204 + 1;\n\tv214 = v204 < *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+126]);\n\tv185 = ~v214;\n\tv203 = v203 + 0x10;\n\tv169 = ~v185;\n\tif (v169) goto L_0043;\nL_0058:\n\tv221 = 0x8909C4(v45, Facebook.Unity.Editor.IEditorWrapper, 4, Il2CppMethodInfo, photoURL, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_005F;\nL_005B:\n\tv216 = *([v203 @ X11_v5]) + 4;\n\tv217 = v216 << 4;\n\tv218 = v156 + v217;\n\tv221 = v218 + 0x130;\nL_005F:\n\tv91 = *([v221 @ X0_v11]);\n\tv89 = *([v221 @ X0_v11+8]);\n\t// 108 IndirectJump v91 @ X5_v1, v45 @ X19_v2 (Facebook.Unity.Editor.IEditorWrapper), v45 @ X19_v2 (Facebook.Unity.Editor.IEditorWrapper), v48 @ X0_v3 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), \"ShareLink\", v66 @ X0_v10 (System.String), v89 @ X4_v1, v91 @ X5_v1, methodInfo @ X6 (Il2CppMethodInfo), v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback)
		{
			//IL_000a: Expected I, but got O
			//IL_002f: Expected I, but got O
			//IL_0184: Expected O, but got I
			//IL_006a: Expected O, but got I
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			//IL_0109: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_00b6: Expected O, but got I
			IEditorWrapper editorWrapper = this.editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+428]");
			Utilities.Callback<ResultContainer> callback2 = new Utilities.Callback<ResultContainer>(this, (IntPtr)0);
			IntPtr intPtr = (IntPtr)this;
			string text = CallbackManager.AddFacebookDelegate(callback);
			IntPtr intPtr2 = (IntPtr)editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00cf;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IEditorWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Editor.IEditorWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00cf;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr2 + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016c;
			IL_00cf:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016c;
			IL_016c:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X0_v11+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xD2732C", Offset = "0xD2732C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_0017;\n\tv23 = *([1EAE050]);\n\tv24 = *([v23 @ X8_v15]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BBD]) = v43;\nL_0017:\n\tv45 = this.editorWrapper;\n\tv48 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tv52 = this->klass;\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v48, this, *([v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+428]));\n\tv66 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v12 @ X29_v1+10]));\n\tv156 = *([v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv144 = *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]) == 0;\n\tif (v144) goto L_0058;\n\tv203 = *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]) + 8;\nL_0043:\n\tv209 = *([v203 @ X11_v5-8]) == Facebook.Unity.Editor.IEditorWrapper;\n\tif (v209) goto L_005B;\n\tv204 = v204 + 1;\n\tv214 = v204 < *([v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]);\n\tv185 = ~v214;\n\tv203 = v203 + 0x10;\n\tv169 = ~v185;\n\tif (v169) goto L_0043;\nL_0058:\n\tv221 = Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v45, Facebook.Unity.Editor.IEditorWrapper, 4);\n\tgoto L_005F;\nL_005B:\n\tv216 = *([v203 @ X11_v5]) + 4;\n\tv217 = v216 << 4;\n\tv218 = v156 + v217;\n\tv221 = v218 + 0x130;\nL_005F:\n\tv91 = *([v221 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv89 = *([v221 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]);\n\t// 108 IndirectJump v91 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v48 @ X0_v3 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), \"FeedShare\", v66 @ X0_v10 (System.String), v89 @ X4_v1, v91 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), picture @ X6 (System.Uri), mediaSource @ X7 (System.String), v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback)
		{
			//IL_0012: Expected I, but got O
			//IL_002e: Expected O, but got I
			//IL_003f: Expected I, but got O
			//IL_017a: Expected I, but got O
			//IL_018a: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_010f: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00c6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Utilities.Callback<ResultContainer> callback2 = (Utilities.Callback<ResultContainer>)(object)editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+428]");
			Utilities.Callback<ResultContainer> callback3 = new Utilities.Callback<ResultContainer>(this, (IntPtr)0);
			IntPtr intPtr = (IntPtr)this;
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			string text = callbackManager.AddFacebookDelegate((FacebookDelegate<IShareResult>)0);
			IntPtr intPtr2 = (IntPtr)callback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
			Utilities.Callback<ResultContainer> callback4 = default(Utilities.Callback<ResultContainer>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]");
				object obj3 = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IEditorWrapper))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj3 = (long)(IntPtr)obj3 + 16L;
						continue;
					}
					object obj4 = obj3 + 4;
					int num3 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr2 + (long)num3;
					callback4 = (Utilities.Callback<ResultContainer>)((long)(IntPtr)obj5 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr3 = (IntPtr)callback4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X5_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xD27460", Offset = "0xD27460", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F05BB8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, appId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BBE]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, appId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0024:\n\tFacebook.Unity.FacebookLogger::Log(\"Pew! Pretending to send this off.  Doesn't actually work in the editor\");\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ActivateApp(string appId)
		{
			FacebookLogger.Log("Pew! Pretending to send this off.  Doesn't actually work in the editor");
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xD274C8", Offset = "0xD274C8", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EF6450]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BBF]) = v43;\nL_0019:\n\tv47 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v47);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v47, \"url\", \"mockurl://testing.url\");\n\tv80 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v47, \"callback_id\", v80);\n\tv114 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v114, v47);\n\tv106 = this->klass;\n\tv90 = this->klass->vtable[45];\n\tv92 = this->klass->vtable[45];\n\t// 78 IndirectJump v90 @ X3_v4, this @ X0 (Facebook.Unity.Editor.EditorFacebook), this @ X0 (Facebook.Unity.Editor.EditorFacebook), v114 @ X0_v12 (Facebook.Unity.ResultContainer), v92 @ X2_v5, v90 @ X3_v4, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_005f: Expected I, but got O
			//IL_006f: Expected O, but got I
			//IL_007f: Expected O, but got I
			while (true)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.set_Item("url", (object)"mockurl://testing.url");
				string value = CallbackManager.AddFacebookDelegate(callback);
				dictionary.set_Item("callback_id", (object)value);
				ResultContainer resultContainer = new ResultContainer(dictionary);
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v16 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+400]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v16 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+408]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v90 @ X3_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xD275D8", Offset = "0xD275D8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA7300]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, logEvent, valueToSum, parameters, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BC0]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, logEvent, valueToSum, parameters, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0024:\n\tFacebook.Unity.FacebookLogger::Log(\"Pew! Pretending to send this off.  Doesn't actually work in the editor\");\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters)
		{
			FacebookLogger.Log("Pew! Pretending to send this off.  Doesn't actually work in the editor");
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0xD27640", Offset = "0xD27640", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFE718]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, currency, parameters, methodInfo, v20, v21, v22, v23, logPurchase, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BC1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, currency, parameters, methodInfo, v20, v21, v22, v23, logPurchase, v25, v26, v27, v28, v29, v30, v31);\nL_0024:\n\tFacebook.Unity.FacebookLogger::Log(\"Pew! Pretending to send this off.  Doesn't actually work in the editor\");\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters)
		{
			FacebookLogger.Log("Pew! Pretending to send this off.  Doesn't actually work in the editor");
		}

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0xD276A8", Offset = "0xD276A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsImplicitPurchaseLoggingEnabled()
		{
			return true;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0xD276B0", Offset = "0xD276B0", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EE2E30]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023BC2]) = v47;\nL_001B:\n\tv51 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v51);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v51, \"url\", \"mockurl://testing.url\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v51, \"ref\", \"mock ref\");\n\tv80 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v80);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v80, \"mock extra key\", \"mock extra value\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v51, \"extras\", v80);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v51, \"target_url\", \"mocktargeturl://mocktarget.url\");\n\tv162 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v51, \"callback_id\", v162);\n\tv169 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v169, v51);\n\tFacebook.Unity.Editor.EditorFacebook::OnFetchDeferredAppLinkComplete(this, v169);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.set_Item("url", (object)"mockurl://testing.url");
			dictionary.set_Item("ref", (object)"mock ref");
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("mock extra key", "mock extra value");
			dictionary.set_Item("extras", (object)dictionary2);
			dictionary.set_Item("target_url", (object)"mocktargeturl://mocktarget.url");
			string value = CallbackManager.AddFacebookDelegate(callback);
			dictionary.set_Item("callback_id", (object)value);
			ResultContainer resultContainer = new ResultContainer(dictionary);
			OnFetchDeferredAppLinkComplete(resultContainer);
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0xD278DC", Offset = "0xD278DC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_0017;\n\tv23 = *([1EC0C38]);\n\tv24 = *([v23 @ X8_v15]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, product, action, quantity, quantityMin, quantityMax, requestId, pricepointId, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BC3]) = v43;\nL_0017:\n\tv45 = this.editorWrapper;\n\tv48 = new Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>();\n\tv52 = this->klass;\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v48, this, *([v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+4B8]));\n\tv66 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v12 @ X29_v1+18]));\n\tv154 = *([v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv142 = *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]) == 0;\n\tif (v142) goto L_0055;\n\tv198 = *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]) + 8;\nL_0040:\n\tv204 = *([v198 @ X11_v5-8]) == Facebook.Unity.Editor.IEditorWrapper;\n\tif (v204) goto L_0058;\n\tv199 = v199 + 1;\n\tv209 = v199 < *([v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]);\n\tv180 = ~v209;\n\tv198 = v198 + 0x10;\n\tv164 = ~v180;\n\tif (v164) goto L_0040;\nL_0055:\n\tv216 = Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::.ctor(v45, Facebook.Unity.Editor.IEditorWrapper, 3);\n\tgoto L_005C;\nL_0058:\n\tv211 = *([v198 @ X11_v5]) + 3;\n\tv212 = v211 << 4;\n\tv213 = v154 + v212;\n\tv216 = v213 + 0x130;\nL_005C:\n\tv89 = *([v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)]);\n\tv130 = *([v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]);\n\t// 104 IndirectJump v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v45 @ X19_v2 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v48 @ X0_v3 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>), v66 @ X0_v10 (System.String), v130 @ X3_v4, v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>), quantityMax @ X5 (System.Nullable`1<System.Int32>), requestId @ X6 (System.String), pricepointId @ X7 (System.String), v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pay(string product, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, FacebookDelegate<IPayResult> callback)
		{
			//IL_0012: Expected I, but got O
			//IL_002e: Expected O, but got I
			//IL_003f: Expected I, but got O
			//IL_017a: Expected I, but got O
			//IL_018a: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_010f: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00c6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Utilities.Callback<ResultContainer> callback2 = (Utilities.Callback<ResultContainer>)(object)editorWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v7 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+4B8]");
			Utilities.Callback<ResultContainer> callback3 = new Utilities.Callback<ResultContainer>(this, (IntPtr)0);
			IntPtr intPtr = (IntPtr)this;
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			string text = callbackManager.AddFacebookDelegate((FacebookDelegate<IPayResult>)0);
			IntPtr intPtr2 = (IntPtr)callback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
			Utilities.Callback<ResultContainer> callback4 = default(Utilities.Callback<ResultContainer>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+B0]");
				object obj3 = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IEditorWrapper))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X8_v10 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj3 = (long)(IntPtr)obj3 + 16L;
						continue;
					}
					object obj4 = obj3 + 3;
					int num3 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr2 + (long)num3;
					callback4 = (Utilities.Callback<ResultContainer>)((long)(IntPtr)obj5 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr3 = (IntPtr)callback4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v11 (Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ X4_v1 (Il2CppClass<Facebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0xD27A00", Offset = "0xD27A00", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EEBDE0]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BC4]) = v43;\nL_0016:\n\tv44 = callback == 0;\n\tif (v44) goto L_006D;\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v48);\n\tv119 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v48, \"callback_id\", v119);\n\tgoto L_0044;\n\tv135 = *([1F0D7D0]);\n\tv136 = *([v135 @ X8_v33]);\n\tv137 = \"il2cpp_codegen_initialize_method\"(v136, v129, v57, v52, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv140 = 0 | 1;\n\t*([2021D32]) = v140;\nL_0044:\n\tv146 = v144.<CurrentAccessToken>k__BackingField == 0;\n\tif (v146) goto L_0078;\n\tv147 = Facebook.Unity.AccessToken::ToJson(v144.<CurrentAccessToken>k__BackingField);\n\tv161 = Facebook.MiniJSON.Json;\n\tv163 = *([v161 @ X8_v26 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]) & 2;\n\tv164 = v163 == 0;\n\tif (v164) goto L_0052;\n\tv166 = *([v161 @ X8_v26 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]) == 0;\n\tif (v166) goto L_007C;\nL_0052:\n\tv169 = v147 == 0;\n\tif (v169) goto L_FFFFFFFF;\nL_0055:\n\tv192 = Facebook.MiniJSON.Json+Parser::Parse(v147);\n\tv196 = v192 == 0;\n\tif (v196) goto L_FFFFFFFF;\n\t// 94 IsInst v204 @ X0_v27 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), typeof(System.Collections.Generic.IDictionary`2<System.String, System.Object>), v192 @ X0_v25 (System.Object)\n\tv210 = v204 == 0;\n\tv63 = ~v210;\n\tif (v63) goto L_0084;\n\tthrow System.InvalidCastException;\nL_006D:\n\treturn;\nL_0078:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v48, \"error\", \"No current access token\");\n\tgoto L_0088;\nL_007C:\n\tv201 = v147 == 0;\n\tv190 = ~v201;\n\tif (v190) goto L_0055;\nL_0084:\n\tFacebook.Unity.Utilities::AddAllKVPFrom(v48, v175);\nL_0088:\n\tv185 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v185, v48);\n\tFacebook.Unity.Editor.EditorFacebook::OnRefreshCurrentAccessTokenComplete(this, v185);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback)
		{
			//IL_005f: Expected I, but got O
			if (callback == null)
			{
				return;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string value = CallbackManager.AddFacebookDelegate(callback);
			dictionary.Add("callback_id", value);
			string text;
			if (AccessToken.CurrentAccessToken != null)
			{
				text = AccessToken.CurrentAccessToken.ToJson();
				IntPtr intPtr = (IntPtr)typeof(Json);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v26 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v26 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if (text != null)
						{
							goto IL_00d4;
						}
						goto IL_0183;
					}
				}
				if (text != null)
				{
					goto IL_00d4;
				}
				goto IL_0183;
			}
			dictionary.set_Item("error", (object)"No current access token");
			goto IL_018d;
			IL_01e6:
			IDictionary<string, object> source;
			dictionary.AddAllKVPFrom(source);
			goto IL_018d;
			IL_00d4:
			object obj = Json.Parser.Parse(text);
			if (obj == null)
			{
				goto IL_0183;
			}
			IDictionary<string, object> dictionary2 = obj as IDictionary<string, object>;
			bool flag = dictionary2 == null;
			bool flag2 = !flag;
			source = dictionary2;
			if (!flag2)
			{
				throw new InvalidCastException();
			}
			goto IL_01e6;
			IL_0183:
			source = null;
			goto IL_01e6;
			IL_018d:
			ResultContainer resultContainer = new ResultContainer(dictionary);
			OnRefreshCurrentAccessTokenComplete(resultContainer);
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0xD27C64", Offset = "0xD27C64", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECB818]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BC5]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppRequestResult();\n\tFacebook.Unity.AppRequestResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAppRequestsComplete(ResultContainer resultContainer)
		{
			AppRequestResult result = new AppRequestResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0xD27CDC", Offset = "0xD27CDC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED5D20]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BC6]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppLinkResult();\n\tFacebook.Unity.AppLinkResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGetAppLinkComplete(ResultContainer resultContainer)
		{
			AppLinkResult result = new AppLinkResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0xD27D54", Offset = "0xD27D54", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBC3B8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BC7]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.LoginResult();\n\tFacebook.Unity.LoginResult::.ctor(v45, resultContainer);\n\tv48 = this->klass;\n\tv54 = this->klass->vtable[48];\n\tv55 = this->klass->vtable[48];\n\t// 39 IndirectJump v54 @ X3_v1, this @ X0 (Facebook.Unity.Editor.EditorFacebook), this @ X0 (Facebook.Unity.Editor.EditorFacebook), v45 @ X0_v3 (Facebook.Unity.LoginResult), v55 @ X2_v1, v54 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLoginComplete(ResultContainer resultContainer)
		{
			//IL_0018: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			LoginResult loginResult = new LoginResult(resultContainer);
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+430]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Editor.EditorFacebook>)+438]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0xD27DD0", Offset = "0xD27DD0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF0BC0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BC8]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.ShareResult();\n\tFacebook.Unity.ShareResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnShareLinkComplete(ResultContainer resultContainer)
		{
			ShareResult result = new ShareResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0xD27864", Offset = "0xD27864", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F084D0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BC9]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppLinkResult();\n\tFacebook.Unity.AppLinkResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFetchDeferredAppLinkComplete(ResultContainer resultContainer)
		{
			AppLinkResult result = new AppLinkResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0xD27E48", Offset = "0xD27E48", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB6DA0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BCA]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.PayResult();\n\tFacebook.Unity.PayResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPayComplete(ResultContainer resultContainer)
		{
			PayResult result = new PayResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0xD27BEC", Offset = "0xD27BEC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB4270]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BCB]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AccessTokenRefreshResult();\n\tFacebook.Unity.AccessTokenRefreshResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnRefreshCurrentAccessTokenComplete(ResultContainer resultContainer)
		{
			AccessTokenRefreshResult result = new AccessTokenRefreshResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0xD27EC0", Offset = "0xD27EC0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB6D20]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, resultContainer, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023BCC]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookAuthResponseChange(ResultContainer resultContainer)
		{
			NotSupportedException ex = new NotSupportedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000200")]
		[Address(RVA = "0xD27F24", Offset = "0xD27F24", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EE19D8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, message, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023BCD]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnUrlResponse(string message)
		{
			NotSupportedException ex = new NotSupportedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0xD27F88", Offset = "0xD27F88", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F040C8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, hidden, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023BCE]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnHideUnity(bool hidden)
		{
			NotSupportedException ex = new NotSupportedException();
			throw new TypeLoadException();
		}
	}
}
