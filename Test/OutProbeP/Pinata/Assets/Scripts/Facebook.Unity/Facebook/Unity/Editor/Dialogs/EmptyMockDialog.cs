using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Editor.Dialogs
{
	[Token(Token = "0x200005A")]
	internal class EmptyMockDialog : EditorFacebookMockDialog
	{
		[Token(Token = "0x17000077")]
		public string EmptyDialogTitle
		{
			[CompilerGenerated]
			[Token(Token = "0x6000223")]
			[Address(RVA = "0xD25778", Offset = "0xD25778", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EmptyDialogTitle>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EmptyDialogTitle;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000224")]
			[Address(RVA = "0xD25780", Offset = "0xD25780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EmptyDialogTitle>k__BackingField = value;\n\treturn;\n")]
			set
			{
				EmptyDialogTitle = value;
			}
		}

		[Token(Token = "0x17000078")]
		protected override string DialogTitle
		{
			[Token(Token = "0x6000225")]
			[Address(RVA = "0xD25788", Offset = "0xD25788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EmptyDialogTitle>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EmptyDialogTitle;
			}
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0xD25790", Offset = "0xD25790", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void DoGui()
		{
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0xD25794", Offset = "0xD25794", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFA4A8]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BAB]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tv54 = 1;\n\t// 35 Box v55 @ X0_v5 (System.Object), typeof(System.Boolean), &v54 @ X8_v9 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"did_complete\", v55);\n\tv69 = System.String::IsNullOrEmpty(this.<CallbackID>k__BackingField);\n\tv71 = v69 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003E;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"callback_id\", this.<CallbackID>k__BackingField);\nL_003E:\n\tv86 = this.<Callback>k__BackingField == 0;\n\tif (v86) goto L_0053;\n\tv109 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v109, v44);\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::Invoke(this.<Callback>k__BackingField, v109);\nL_0053:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SendSuccessResult()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			object value = (byte)num != 0;
			dictionary.set_Item("did_complete", value);
			if (!string.IsNullOrEmpty(CallbackID))
			{
				dictionary.set_Item("callback_id", (object)CallbackID);
			}
			if (Callback != null)
			{
				ResultContainer obj = new ResultContainer(dictionary);
				Callback(obj);
			}
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0xD258B4", Offset = "0xD258B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EmptyMockDialog()
		{
		}
	}
}
