using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B540", Offset = "0x75B540")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B540", Offset = "0x75B540")]
	[Token(Token = "0x20002E8")]
	public class SetProceduralBoolean : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0D50", Offset = "0x7C0D50")]
		[Token(Token = "0x40018E2")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0D9C", Offset = "0x7C0D9C")]
		[Token(Token = "0x40018E3")]
		[FieldOffset(Offset = "0x58")]
		public FsmString boolProperty;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0DE8", Offset = "0x7C0DE8")]
		[Token(Token = "0x40018E4")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool boolValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0E34", Offset = "0x7C0E34")]
		[Token(Token = "0x40018E5")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E82")]
		[Address(RVA = "0x998650", Offset = "0x998650", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFE540]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021786]) = v38;\nL_0013:\n\tthis.substanceMaterial = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.boolProperty = v43;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.boolValue = v46;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			substanceMaterial = null;
			FsmString fsmString = "";
			boolProperty = fsmString;
			FsmBool fsmBool = false;
			boolValue = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000E83")]
		[Address(RVA = "0x9986C0", Offset = "0x9986C0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E84")]
		[Address(RVA = "0x9986D8", Offset = "0x9986D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E85")]
		[Address(RVA = "0x9986D4", Offset = "0x9986D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSetProceduralFloat()
		{
		}

		[Token(Token = "0x6000E86")]
		[Address(RVA = "0x9986DC", Offset = "0x9986DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetProceduralBoolean()
		{
		}
	}
}
