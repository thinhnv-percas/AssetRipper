using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B600", Offset = "0x75B600")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B600", Offset = "0x75B600")]
	[Token(Token = "0x20002EA")]
	public class SetProceduralFloat : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0F88", Offset = "0x7C0F88")]
		[Token(Token = "0x40018EA")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0FD4", Offset = "0x7C0FD4")]
		[Token(Token = "0x40018EB")]
		[FieldOffset(Offset = "0x58")]
		public FsmString floatProperty;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1020", Offset = "0x7C1020")]
		[Token(Token = "0x40018EC")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat floatValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C106C", Offset = "0x7C106C")]
		[Token(Token = "0x40018ED")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E8C")]
		[Address(RVA = "0x99877C", Offset = "0x99877C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0A180]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021788]) = v38;\nL_0013:\n\tthis.substanceMaterial = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.floatProperty = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.floatValue = v46;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			substanceMaterial = null;
			FsmString fsmString = "";
			floatProperty = fsmString;
			FsmFloat fsmFloat = 0f;
			floatValue = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000E8D")]
		[Address(RVA = "0x9987EC", Offset = "0x9987EC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E8E")]
		[Address(RVA = "0x998804", Offset = "0x998804", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E8F")]
		[Address(RVA = "0x998800", Offset = "0x998800", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSetProceduralFloat()
		{
		}

		[Token(Token = "0x6000E90")]
		[Address(RVA = "0x998808", Offset = "0x998808", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetProceduralFloat()
		{
		}
	}
}
