using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757AA8", Offset = "0x757AA8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757AA8", Offset = "0x757AA8")]
	[Token(Token = "0x2000235")]
	public class AnyKey : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3130", Offset = "0x7B3130")]
		[Token(Token = "0x4001553")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Token(Token = "0x6000B19")]
		[Address(RVA = "0xA88608", Offset = "0xA88608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sendEvent = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sendEvent = null;
		}

		[Token(Token = "0x6000B1A")]
		[Address(RVA = "0xA88610", Offset = "0xA88610", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_anyKeyDown();\n\tv13 = v11 == 0;\n\tif (v13) goto L_001A;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_001A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (Input.anyKeyDown)
			{
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000B1B")]
		[Address(RVA = "0xA88658", Offset = "0xA88658", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnyKey()
		{
		}
	}
}
