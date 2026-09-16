using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D800", Offset = "0x75D800")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D800", Offset = "0x75D800")]
	[Token(Token = "0x200034E")]
	public class GetEventBoolData : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C95F8", Offset = "0x7C95F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C95F8", Offset = "0x7C95F8")]
		[Token(Token = "0x4001B0E")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool getBoolData;

		[Token(Token = "0x6001083")]
		[Address(RVA = "0xA2AF64", Offset = "0xA2AF64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getBoolData = 0;\n\treturn;\n")]
		public override void Reset()
		{
			getBoolData = null;
		}

		[Token(Token = "0x6001084")]
		[Address(RVA = "0xA2AF6C", Offset = "0xA2AF6C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EBC090]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB0]) = v40;\nL_0016:\n\tv43 = this.getBoolData;\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv43.value = v56.BoolData;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = getBoolData;
			FsmEventData eventData = Fsm.EventData;
			fsmBool.value = eventData.BoolData;
			Finish();
		}

		[Token(Token = "0x6001085")]
		[Address(RVA = "0xA2B004", Offset = "0xA2B004", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventBoolData()
		{
		}
	}
}
