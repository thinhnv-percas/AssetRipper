using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7593E8", Offset = "0x7593E8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7593E8", Offset = "0x7593E8")]
	[Token(Token = "0x2000280")]
	public class FloatAbs : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B7F14", Offset = "0x7B7F14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7F14", Offset = "0x7B7F14")]
		[Token(Token = "0x40016AB")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7F74", Offset = "0x7B7F74")]
		[Token(Token = "0x40016AC")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000C73")]
		[Address(RVA = "0xB75C00", Offset = "0xB75C00", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.floatVariable = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			floatVariable = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000C74")]
		[Address(RVA = "0xB75C0C", Offset = "0xB75C0C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAbs::DoFloatAbs(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatAbs();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C75")]
		[Address(RVA = "0xB75CD8", Offset = "0xB75CD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAbs::DoFloatAbs(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatAbs();
		}

		[Token(Token = "0x6000C76")]
		[Address(RVA = "0xB75C48", Offset = "0xB75C48", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC28A0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202292A]) = v40;\nL_0014:\n\tv41 = this.floatVariable;\n\tv45 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tgoto L_0027;\n\tv55 = *([v51 @ X0_v5+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, v44, v24, v25, v26, v27, v28, v29, v45, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv62 = UnityEngine.Mathf::Abs(v45);\n\tv41.value = v62;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatAbs()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = Mathf.Abs(value);
			fsmFloat.Value = value2;
		}

		[Token(Token = "0x6000C77")]
		[Address(RVA = "0xB75CDC", Offset = "0xB75CDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatAbs()
		{
		}
	}
}
