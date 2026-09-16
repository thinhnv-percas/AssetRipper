using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D8F0", Offset = "0x75D8F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D8F0", Offset = "0x75D8F0")]
	[Token(Token = "0x2000351")]
	public class GetEventIntData : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C97C4", Offset = "0x7C97C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C97C4", Offset = "0x7C97C4")]
		[Token(Token = "0x4001B1F")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt getIntData;

		[Token(Token = "0x600108C")]
		[Address(RVA = "0xA2B48C", Offset = "0xA2B48C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getIntData = 0;\n\treturn;\n")]
		public override void Reset()
		{
			getIntData = null;
		}

		[Token(Token = "0x600108D")]
		[Address(RVA = "0xA2B494", Offset = "0xA2B494", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ECAF68]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB3]) = v40;\nL_0016:\n\tv43 = this.getIntData;\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv43.value = v56.IntData;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmInt fsmInt = getIntData;
			FsmEventData eventData = Fsm.EventData;
			fsmInt.Value = eventData.IntData;
			Finish();
		}

		[Token(Token = "0x600108E")]
		[Address(RVA = "0xA2B52C", Offset = "0xA2B52C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventIntData()
		{
		}
	}
}
