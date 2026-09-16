using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757CE8", Offset = "0x757CE8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757CE8", Offset = "0x757CE8")]
	[Token(Token = "0x200023C")]
	public class GetKeyDown : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400156B")]
		[FieldOffset(Offset = "0x4C")]
		public KeyCode key;

		[Token(Token = "0x400156C")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B37F4", Offset = "0x7B37F4")]
		[Token(Token = "0x400156D")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeResult;

		[Token(Token = "0x6000B34")]
		[Address(RVA = "0xA2F058", Offset = "0xA2F058", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetKeyDown)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetKeyDown)+54]) = 0;\n\tthis.key = 0;\n\treturn;\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			key = default(KeyCode);
		}

		[Token(Token = "0x6000B35")]
		[Address(RVA = "0xA2F068", Offset = "0xA2F068", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetKeyDown(this.key);\n\tv17 = v14 == 0;\n\tif (v17) goto L_0014;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0014:\n\tv27 = this.storeResult;\n\tv27.value = v14;\n\treturn;\n\tv35 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			bool keyDown = Input.GetKeyDown(key);
			if (keyDown)
			{
				Fsm.Event(sendEvent);
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = keyDown;
		}

		[Token(Token = "0x6000B36")]
		[Address(RVA = "0xA2F0C8", Offset = "0xA2F0C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetKeyDown()
		{
		}
	}
}
