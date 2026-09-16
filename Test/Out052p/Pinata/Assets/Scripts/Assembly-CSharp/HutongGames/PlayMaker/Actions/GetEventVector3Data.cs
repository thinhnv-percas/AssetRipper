using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DA30", Offset = "0x75DA30")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75DA30", Offset = "0x75DA30")]
	[Token(Token = "0x2000355")]
	public class GetEventVector3Data : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C99A4", Offset = "0x7C99A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C99A4", Offset = "0x7C99A4")]
		[Token(Token = "0x4001B25")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 getVector3Data;

		[Token(Token = "0x6001098")]
		[Address(RVA = "0xA2B8EC", Offset = "0xA2B8EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getVector3Data = 0;\n\treturn;\n")]
		public override void Reset()
		{
			getVector3Data = null;
		}

		[Token(Token = "0x6001099")]
		[Address(RVA = "0xA2B8F4", Offset = "0xA2B8F4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F006E0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB7]) = v40;\nL_0016:\n\tv43 = this.getVector3Data;\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv43.value = v56.Vector3Data;\n\tv43.value.z = v56.Vector3Data.z;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = getVector3Data;
			FsmEventData eventData = Fsm.EventData;
			fsmVector.value = eventData.Vector3Data;
			fsmVector.value.z = eventData.Vector3Data.z;
			Finish();
		}

		[Token(Token = "0x600109A")]
		[Address(RVA = "0xA2B994", Offset = "0xA2B994", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventVector3Data()
		{
		}
	}
}
