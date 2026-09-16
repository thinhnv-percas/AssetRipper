using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7594D8", Offset = "0x7594D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7594D8", Offset = "0x7594D8")]
	[Token(Token = "0x2000283")]
	public class FloatClamp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B81B0", Offset = "0x7B81B0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B81B0", Offset = "0x7B81B0")]
		[Token(Token = "0x40016B4")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8210", Offset = "0x7B8210")]
		[Token(Token = "0x40016B5")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat minValue;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B825C", Offset = "0x7B825C")]
		[Token(Token = "0x40016B6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat maxValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B82A8", Offset = "0x7B82A8")]
		[Token(Token = "0x40016B7")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000C82")]
		[Address(RVA = "0xB75FB8", Offset = "0xB75FB8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.minValue = 0;\n\tthis.maxValue = 0;\n\tthis.floatVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			minValue = null;
			maxValue = null;
			floatVariable = null;
		}

		[Token(Token = "0x6000C83")]
		[Address(RVA = "0xB75FC8", Offset = "0xB75FC8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatClamp::DoClamp(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoClamp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C84")]
		[Address(RVA = "0xB760D4", Offset = "0xB760D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatClamp::DoClamp(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoClamp();
		}

		[Token(Token = "0x6000C85")]
		[Address(RVA = "0xB76004", Offset = "0xB76004", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F05588]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202292B]) = v44;\nL_0016:\n\tv45 = this.floatVariable;\n\tv49 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv58 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minValue);\n\tv94 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxValue);\n\tgoto L_0039;\n\tv102 = *([v98 @ X0_v8+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0039;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v98, v81, v28, v29, v30, v31, v32, v33, v94, v35, v36, v37, v38, v39, v40, v41);\nL_0039:\n\tv79 = UnityEngine.Mathf::Clamp(v49, v58, v94);\n\tv45.value = v79;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoClamp()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = minValue.Value;
			float value3 = maxValue.Value;
			float value4 = Mathf.Clamp(value, value2, value3);
			fsmFloat.Value = value4;
		}

		[Token(Token = "0x6000C86")]
		[Address(RVA = "0xB760D8", Offset = "0xB760D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatClamp()
		{
		}
	}
}
