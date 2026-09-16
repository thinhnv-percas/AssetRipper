using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757E28", Offset = "0x757E28")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757E28", Offset = "0x757E28")]
	[Token(Token = "0x2000240")]
	public class GetMouseButtonUp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B39E4", Offset = "0x7B39E4")]
		[Token(Token = "0x4001577")]
		[FieldOffset(Offset = "0x4C")]
		public MouseButton button;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3A30", Offset = "0x7B3A30")]
		[Token(Token = "0x4001578")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3A68", Offset = "0x7B3A68")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3A68", Offset = "0x7B3A68")]
		[Token(Token = "0x4001579")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3AB8", Offset = "0x7B3AB8")]
		[Token(Token = "0x400157A")]
		[FieldOffset(Offset = "0x60")]
		public bool inUpdateOnly;

		[Token(Token = "0x6000B43")]
		[Address(RVA = "0xA300E8", Offset = "0xA300E8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetMouseButtonUp)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetMouseButtonUp)+54]) = 0;\n\tthis.button = 0;\n\tthis.inUpdateOnly = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			button = default(MouseButton);
			inUpdateOnly = true;
		}

		[Token(Token = "0x6000B44")]
		[Address(RVA = "0xA30100", Offset = "0xA30100", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.inUpdateOnly;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetMouseButtonUp::DoGetMouseButtonUp(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!inUpdateOnly)
			{
				DoGetMouseButtonUp();
			}
		}

		[Token(Token = "0x6000B45")]
		[Address(RVA = "0xA30170", Offset = "0xA30170", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseButtonUp::DoGetMouseButtonUp(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetMouseButtonUp();
		}

		[Token(Token = "0x6000B46")]
		[Address(RVA = "0xA30110", Offset = "0xA30110", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetMouseButtonUp(this.button);\n\tv17 = v14 == 0;\n\tif (v17) goto L_0014;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0014:\n\tv27 = this.storeResult;\n\tv27.value = v14;\n\treturn;\n\tv35 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DoGetMouseButtonUp()
		{
			bool mouseButtonUp = Input.GetMouseButtonUp((int)button);
			if (mouseButtonUp)
			{
				Fsm.Event(sendEvent);
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = mouseButtonUp;
		}

		[Token(Token = "0x6000B47")]
		[Address(RVA = "0xA30174", Offset = "0xA30174", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMouseButtonUp()
		{
		}
	}
}
