using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D990", Offset = "0x75D990")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D990", Offset = "0x75D990")]
	[Token(Token = "0x2000353")]
	public class GetEventStringData : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C9904", Offset = "0x7C9904")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C9904", Offset = "0x7C9904")]
		[Token(Token = "0x4001B23")]
		[FieldOffset(Offset = "0x50")]
		public FsmString getStringData;

		[Token(Token = "0x6001092")]
		[Address(RVA = "0xA2B79C", Offset = "0xA2B79C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getStringData = 0;\n\treturn;\n")]
		public override void Reset()
		{
			getStringData = null;
		}

		[Token(Token = "0x6001093")]
		[Address(RVA = "0xA2B7A4", Offset = "0xA2B7A4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EBE248]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB5]) = v40;\nL_0016:\n\tv43 = this.getStringData;\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv43.value = v56.StringData;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmString fsmString = getStringData;
			FsmEventData eventData = Fsm.EventData;
			fsmString.Value = eventData.StringData;
			Finish();
		}

		[Token(Token = "0x6001094")]
		[Address(RVA = "0xA2B83C", Offset = "0xA2B83C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventStringData()
		{
		}
	}
}
