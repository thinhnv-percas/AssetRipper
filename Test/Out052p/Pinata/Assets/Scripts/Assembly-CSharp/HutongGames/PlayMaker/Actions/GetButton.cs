using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757BA8", Offset = "0x757BA8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757BA8", Offset = "0x757BA8")]
	[Token(Token = "0x2000238")]
	public class GetButton : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3474", Offset = "0x7B3474")]
		[Token(Token = "0x400155F")]
		[FieldOffset(Offset = "0x50")]
		public FsmString buttonName;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B34C0", Offset = "0x7B34C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B34C0", Offset = "0x7B34C0")]
		[Token(Token = "0x4001560")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3520", Offset = "0x7B3520")]
		[Token(Token = "0x4001561")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000B24")]
		[Address(RVA = "0xB837F0", Offset = "0xB837F0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0CAF8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D4]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Fire1\");\n\tthis.buttonName = v43;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Fire1";
			buttonName = fsmString;
			storeResult = null;
			everyFrame = true;
		}

		[Token(Token = "0x6000B25")]
		[Address(RVA = "0xB83850", Offset = "0xB83850", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetButton::DoGetButton(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetButton();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B26")]
		[Address(RVA = "0xB838DC", Offset = "0xB838DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetButton::DoGetButton(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetButton();
		}

		[Token(Token = "0x6000B27")]
		[Address(RVA = "0xB8388C", Offset = "0xB8388C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.storeResult;\n\tv14 = HutongGames.PlayMaker.FsmString::get_Value(this.buttonName);\n\tv32 = UnityEngine.Input::GetButton(v14);\n\tv12.value = v32;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetButton()
		{
			FsmBool fsmBool = storeResult;
			string value = buttonName.Value;
			bool button = Input.GetButton(value);
			fsmBool.value = button;
		}

		[Token(Token = "0x6000B28")]
		[Address(RVA = "0xB838E0", Offset = "0xB838E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetButton()
		{
		}
	}
}
