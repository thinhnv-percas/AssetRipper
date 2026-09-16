using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759708", Offset = "0x759708")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759708", Offset = "0x759708")]
	[Token(Token = "0x200028A")]
	public class IntClamp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8964", Offset = "0x7B8964")]
		[Token(Token = "0x40016D3")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[RequiredField]
		[Token(Token = "0x40016D4")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt minValue;

		[RequiredField]
		[Token(Token = "0x40016D5")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt maxValue;

		[Token(Token = "0x40016D6")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000CA1")]
		[Address(RVA = "0xA38278", Offset = "0xA38278", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.minValue = 0;\n\tthis.maxValue = 0;\n\tthis.intVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			minValue = null;
			maxValue = null;
			intVariable = null;
		}

		[Token(Token = "0x6000CA2")]
		[Address(RVA = "0xA38288", Offset = "0xA38288", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntClamp::DoClamp(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoClamp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CA3")]
		[Address(RVA = "0xA38398", Offset = "0xA38398", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntClamp::DoClamp(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoClamp();
		}

		[Token(Token = "0x6000CA4")]
		[Address(RVA = "0xA382C4", Offset = "0xA382C4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE0DA0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E28]) = v42;\nL_0015:\n\tv43 = this.intVariable;\n\tv47 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv53 = HutongGames.PlayMaker.FsmInt::get_Value(this.minValue);\n\tv94 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxValue);\n\tgoto L_003B;\n\tv101 = *([v87 @ X8_v8+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_003B;\n\tv107 = v87;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v107, v93, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003B:\n\tv81 = UnityEngine.Mathf::Clamp(v47, v53, v94);\n\tv43.value = v81;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoClamp()
		{
			FsmInt fsmInt = intVariable;
			int value = intVariable.Value;
			int value2 = minValue.Value;
			int value3 = maxValue.Value;
			int value4 = Mathf.Clamp(value, value2, value3);
			fsmInt.Value = value4;
		}

		[Token(Token = "0x6000CA5")]
		[Address(RVA = "0xA3839C", Offset = "0xA3839C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntClamp()
		{
		}
	}
}
