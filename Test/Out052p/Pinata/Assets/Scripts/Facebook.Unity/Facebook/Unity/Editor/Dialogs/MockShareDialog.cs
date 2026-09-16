using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Editor.Dialogs
{
	[Token(Token = "0x200005D")]
	internal class MockShareDialog : EditorFacebookMockDialog
	{
		[CompilerGenerated]
		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x40")]
		private string _003CSubTitle_003Ek__BackingField;

		[Token(Token = "0x1700007A")]
		public string SubTitle
		{
			[CompilerGenerated]
			[Token(Token = "0x6000230")]
			[Address(RVA = "0xD267B0", Offset = "0xD267B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SubTitle>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private get
			{
				return _003CSubTitle_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000231")]
			[Address(RVA = "0xD267B8", Offset = "0xD267B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SubTitle>k__BackingField = value;\n\treturn;\n")]
			set
			{
				SubTitle = value;
			}
		}

		[Token(Token = "0x1700007B")]
		protected override string DialogTitle
		{
			[Token(Token = "0x6000232")]
			[Address(RVA = "0xD267C0", Offset = "0xD267C0", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv18 = *([1EB9AD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BB2]) = v38;\nL_0020:\n\treturnVal1 = System.String::Concat(\"Mock \", this.<SubTitle>k__BackingField, \" Dialog\");\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "Mock " + SubTitle + " Dialog";
			}
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xD26820", Offset = "0xD26820", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void DoGui()
		{
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0xD26824", Offset = "0xD26824", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EB2770]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BB3]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tgoto L_0029;\n\tv55 = *([v51 @ X0_v4 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0029;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, v48, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\tv62 = Facebook.Unity.FB::get_IsLoggedIn();\n\tv64 = v62 == 0;\n\tif (v64) goto L_0038;\n\tv65 = Facebook.Unity.Editor.Dialogs.MockShareDialog::GenerateFakePostID(v62);\n\tgoto L_0045;\nL_0038:\n\tv71 = 1;\n\t// 58 Box v72 @ X0_v21 (System.String), typeof(System.Boolean), &v71 @ X8_v23 (System.Int32)\nL_0045:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, *([v95 @ X8_v11 (System.String)]), v141);\n\tv103 = System.String::IsNullOrEmpty(this.<CallbackID>k__BackingField);\n\tv131 = v103 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0057;\n\tv141 = this.<CallbackID>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"callback_id\", this.<CallbackID>k__BackingField);\nL_0057:\n\tv121 = this.<Callback>k__BackingField == 0;\n\tif (v121) goto L_006C;\n\tv149 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v149, v44);\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::Invoke(this.<Callback>k__BackingField, v149);\nL_006C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SendSuccessResult()
		{
			//IL_0034: Expected O, but got I4
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			bool isLoggedIn = FB.IsLoggedIn;
			string key;
			string value;
			if (isLoggedIn)
			{
				string text = ((MockShareDialog)isLoggedIn).GenerateFakePostID();
				value = text;
				key = "postId";
			}
			else
			{
				int num = 1;
				string text2 = (string)(object)((byte)num != 0);
				value = text2;
				key = "did_complete";
			}
			dictionary.set_Item(key, (object)value);
			if (!string.IsNullOrEmpty(CallbackID))
			{
				value = CallbackID;
				dictionary.set_Item("callback_id", (object)CallbackID);
			}
			if (Callback != null)
			{
				ResultContainer obj = new ResultContainer(dictionary);
				Callback(obj);
			}
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xD26B88", Offset = "0xD26B88", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F07770]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BB4]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"cancelled\", \"true\");\n\tv82 = System.String::IsNullOrEmpty(this.<CallbackID>k__BackingField);\n\tv84 = v82 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_003C;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"callback_id\", this.<CallbackID>k__BackingField);\nL_003C:\n\tv71 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v71, v44);\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::Invoke(this.<Callback>k__BackingField, v71);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SendCancelResult()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.set_Item("cancelled", (object)"true");
			if (!string.IsNullOrEmpty(CallbackID))
			{
				dictionary.set_Item("callback_id", (object)CallbackID);
			}
			ResultContainer obj = new ResultContainer(dictionary);
			Callback(obj);
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xD26A90", Offset = "0xD26A90", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED3370]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BB5]) = v37;\nL_0015:\n\tv41 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v41);\n\tgoto L_0028;\n\tv49 = *([1F0D7D0]);\n\tv50 = *([v49 @ X8_v15]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, v42, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv54 = 0 | 1;\n\t*([2021D32]) = v54;\nL_0028:\n\tv59 = v58.<CurrentAccessToken>k__BackingField;\n\tv68 = System.Text.StringBuilder::Append(v41, v59.<UserId>k__BackingField);\n\tv72 = System.Text.StringBuilder::Append(v41, 0x5F);\nL_0039:\n\tv104 = UnityEngine.Random::Range(0, 0xA);\n\tv99 = System.Text.StringBuilder::Append(v41, v104);\n\tv95 = v94 - 1;\n\tv84 = v94 != 1;\n\tif (v84) goto L_0039;\n\tv86 = *([v41 @ X0_v3 (System.Text.StringBuilder)]);\n\tv76 = *([v86 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv80 = *([v86 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 75 IndirectJump v76 @ X2_v6, v41 @ X0_v3 (System.Text.StringBuilder), v41 @ X0_v3 (System.Text.StringBuilder), v80 @ X1_v7, v76 @ X2_v6, v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GenerateFakePostID()
		{
			//IL_0048: Expected I, but got O
			//IL_0058: Expected O, but got I
			//IL_0068: Expected O, but got I
			while (true)
			{
				StringBuilder stringBuilder = new StringBuilder();
				AccessToken _003CCurrentAccessToken_003Ek__BackingField = AccessToken.CurrentAccessToken;
				StringBuilder stringBuilder2 = stringBuilder.Append(_003CCurrentAccessToken_003Ek__BackingField.UserId);
				StringBuilder stringBuilder3 = stringBuilder.Append('_');
				int num = 17;
				bool flag;
				do
				{
					int value = UnityEngine.Random.Range(0, 10);
					StringBuilder stringBuilder4 = stringBuilder.Append(value);
					int num2 = num - 1;
					flag = num != 1;
					num = num2;
				}
				while (flag);
				IntPtr intPtr = (IntPtr)stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+160]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v12 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X2_v6 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xD26C90", Offset = "0xD26C90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MockShareDialog()
		{
		}
	}
}
