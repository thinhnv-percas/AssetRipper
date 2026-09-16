using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B1E0", Offset = "0x75B1E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B1E0", Offset = "0x75B1E0")]
	[Token(Token = "0x20002DF")]
	public class PlayerPrefsDeleteKey : FsmStateAction
	{
		[Token(Token = "0x40018CE")]
		[FieldOffset(Offset = "0x50")]
		public FsmString key;

		[Token(Token = "0x6000E65")]
		[Address(RVA = "0xB1A2C0", Offset = "0xB1A2C0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF1C78]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022567]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.key = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "";
			key = fsmString;
		}

		[Token(Token = "0x6000E66")]
		[Address(RVA = "0xB1A318", Offset = "0xB1A318", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED3818]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022568]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.key);\n\tv60 = v42 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_003A;\n\tv50 = HutongGames.PlayMaker.FsmString::get_Value(this.key);\n\tv67 = System.String::Equals(v50, \"\");\n\tv88 = v67 == 0;\n\tv69 = ~v88;\n\tif (v69) goto L_003A;\n\tv66 = HutongGames.PlayMaker.FsmString::get_Value(this.key);\n\tUnityEngine.PlayerPrefs::DeleteKey(v66);\nL_003A:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!key.IsNone)
			{
				string value = key.Value;
				if (!value.Equals(""))
				{
					string value2 = key.Value;
					PlayerPrefs.DeleteKey(value2);
				}
			}
			Finish();
		}

		[Token(Token = "0x6000E67")]
		[Address(RVA = "0xB1A3BC", Offset = "0xB1A3BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsDeleteKey()
		{
		}
	}
}
