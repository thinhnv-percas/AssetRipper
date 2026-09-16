using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B360", Offset = "0x75B360")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B360", Offset = "0x75B360")]
	[Token(Token = "0x20002E3")]
	public class PlayerPrefsHasKey : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40018D5")]
		[FieldOffset(Offset = "0x50")]
		public FsmString key;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C0AC0", Offset = "0x7C0AC0")]
		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x7C0AC0", Offset = "0x7C0AC0")]
		[Token(Token = "0x40018D6")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool variable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0B10", Offset = "0x7C0B10")]
		[Token(Token = "0x40018D7")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0B48", Offset = "0x7C0B48")]
		[Token(Token = "0x40018D8")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent falseEvent;

		[Token(Token = "0x6000E71")]
		[Address(RVA = "0xB1AA50", Offset = "0xB1AA50", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF65C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202256F]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.key = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "";
			key = fsmString;
		}

		[Token(Token = "0x6000E72")]
		[Address(RVA = "0xB1AAA8", Offset = "0xB1AAA8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA6090]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022570]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv44 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.key);\n\tv69 = v44 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0040;\n\tv54 = HutongGames.PlayMaker.FsmString::get_Value(this.key);\n\tv88 = System.String::Equals(v54, \"\");\n\tv134 = v88 == 0;\n\tv90 = ~v134;\n\tif (v90) goto L_0040;\n\tv83 = this.variable;\n\tv138 = HutongGames.PlayMaker.FsmString::get_Value(this.key);\n\tv76 = UnityEngine.PlayerPrefs::HasKey(v138);\n\tv83.value = v76;\nL_0040:\n\tv77 = HutongGames.PlayMaker.FsmBool::get_Value(this.variable);\n\tv126 = this + 0x60;\n\tv113 = this + 0x68;\n\tv107 = v77 == 0;\n\tv98 = ~v107;\n\tv95 = ~v98;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v126 @ X8_v7]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_00e7: Expected O, but got I
			//IL_00f3: Expected O, but got I
			Finish();
			if (!key.IsNone)
			{
				string value = key.Value;
				if (!value.Equals(""))
				{
					FsmBool fsmBool = variable;
					string value2 = key.Value;
					bool value3 = PlayerPrefs.HasKey(value2);
					fsmBool.value = value3;
				}
			}
			bool value4 = variable.Value;
			object fsmEvent = (long)(IntPtr)this + 96L;
			object obj = (long)(IntPtr)this + 104L;
			if (!value4)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x6000E73")]
		[Address(RVA = "0xB1AB9C", Offset = "0xB1AB9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsHasKey()
		{
		}
	}
}
