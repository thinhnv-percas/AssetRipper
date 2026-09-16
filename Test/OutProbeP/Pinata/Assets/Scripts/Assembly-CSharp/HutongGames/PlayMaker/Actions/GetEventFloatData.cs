using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D850", Offset = "0x75D850")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D850", Offset = "0x75D850")]
	[Token(Token = "0x200034F")]
	public class GetEventFloatData : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C9648", Offset = "0x7C9648")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C9648", Offset = "0x7C9648")]
		[Token(Token = "0x4001B0F")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat getFloatData;

		[Token(Token = "0x6001086")]
		[Address(RVA = "0xA2B00C", Offset = "0xA2B00C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getFloatData = 0;\n\treturn;\n")]
		public override void Reset()
		{
			getFloatData = null;
		}

		[Token(Token = "0x6001087")]
		[Address(RVA = "0xA2B014", Offset = "0xA2B014", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EEC6C8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB1]) = v40;\nL_0016:\n\tv43 = this.getFloatData;\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv43.value = v56.FloatData;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = getFloatData;
			FsmEventData eventData = Fsm.EventData;
			fsmFloat.Value = eventData.FloatData;
			Finish();
		}

		[Token(Token = "0x6001088")]
		[Address(RVA = "0xA2B0AC", Offset = "0xA2B0AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventFloatData()
		{
		}
	}
}
