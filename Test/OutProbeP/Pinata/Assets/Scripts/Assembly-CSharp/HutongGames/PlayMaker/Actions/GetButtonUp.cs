using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757C48", Offset = "0x757C48")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757C48", Offset = "0x757C48")]
	[Token(Token = "0x200023A")]
	public class GetButtonUp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B362C", Offset = "0x7B362C")]
		[Token(Token = "0x4001565")]
		[FieldOffset(Offset = "0x50")]
		public FsmString buttonName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3678", Offset = "0x7B3678")]
		[Token(Token = "0x4001566")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B36B0", Offset = "0x7B36B0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B36B0", Offset = "0x7B36B0")]
		[Token(Token = "0x4001567")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x6000B2C")]
		[Address(RVA = "0xB839B8", Offset = "0xB839B8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0DE98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D6]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Fire1\");\n\tthis.sendEvent = 0;\n\tthis.storeResult = 0;\n\tthis.buttonName = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Fire1";
			sendEvent = null;
			storeResult = null;
			buttonName = fsmString;
		}

		[Token(Token = "0x6000B2D")]
		[Address(RVA = "0xB83A14", Offset = "0xB83A14", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmString::get_Value(this.buttonName);\n\tv40 = UnityEngine.Input::GetButtonUp(v15);\n\tv56 = v40 == 0;\n\tif (v56) goto L_0018;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0018:\n\tv43 = this.storeResult;\n\tv43.value = v40;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			string value = buttonName.Value;
			bool buttonUp = Input.GetButtonUp(value);
			if (buttonUp)
			{
				Fsm.Event(sendEvent);
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = buttonUp;
		}

		[Token(Token = "0x6000B2E")]
		[Address(RVA = "0xB83A80", Offset = "0xB83A80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetButtonUp()
		{
		}
	}
}
