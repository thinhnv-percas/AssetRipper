using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757D38", Offset = "0x757D38")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757D38", Offset = "0x757D38")]
	[Token(Token = "0x200023D")]
	public class GetKeyUp : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400156E")]
		[FieldOffset(Offset = "0x4C")]
		public KeyCode key;

		[Token(Token = "0x400156F")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3818", Offset = "0x7B3818")]
		[Token(Token = "0x4001570")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeResult;

		[Token(Token = "0x6000B37")]
		[Address(RVA = "0xA2F0D0", Offset = "0xA2F0D0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetKeyUp)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetKeyUp)+54]) = 0;\n\tthis.key = 0;\n\treturn;\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			key = default(KeyCode);
		}

		[Token(Token = "0x6000B38")]
		[Address(RVA = "0xA2F0E0", Offset = "0xA2F0E0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetKeyUp(this.key);\n\tv17 = v14 == 0;\n\tif (v17) goto L_0014;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0014:\n\tv27 = this.storeResult;\n\tv27.value = v14;\n\treturn;\n\tv35 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			bool keyUp = Input.GetKeyUp(key);
			if (keyUp)
			{
				Fsm.Event(sendEvent);
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = keyUp;
		}

		[Token(Token = "0x6000B39")]
		[Address(RVA = "0xA2F140", Offset = "0xA2F140", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetKeyUp()
		{
		}
	}
}
