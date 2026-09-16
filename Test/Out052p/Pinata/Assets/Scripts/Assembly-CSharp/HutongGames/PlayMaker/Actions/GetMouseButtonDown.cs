using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757DD8", Offset = "0x757DD8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757DD8", Offset = "0x757DD8")]
	[Token(Token = "0x200023F")]
	public class GetMouseButtonDown : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B38D8", Offset = "0x7B38D8")]
		[Token(Token = "0x4001573")]
		[FieldOffset(Offset = "0x4C")]
		public MouseButton button;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3924", Offset = "0x7B3924")]
		[Token(Token = "0x4001574")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B395C", Offset = "0x7B395C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B395C", Offset = "0x7B395C")]
		[Token(Token = "0x4001575")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B39AC", Offset = "0x7B39AC")]
		[Token(Token = "0x4001576")]
		[FieldOffset(Offset = "0x60")]
		public bool inUpdateOnly;

		[Token(Token = "0x6000B3E")]
		[Address(RVA = "0xA30054", Offset = "0xA30054", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetMouseButtonDown)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetMouseButtonDown)+54]) = 0;\n\tthis.button = 0;\n\tthis.inUpdateOnly = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			button = default(MouseButton);
			inUpdateOnly = true;
		}

		[Token(Token = "0x6000B3F")]
		[Address(RVA = "0xA3006C", Offset = "0xA3006C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.inUpdateOnly;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetMouseButtonDown::DoGetMouseButtonDown(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!inUpdateOnly)
			{
				DoGetMouseButtonDown();
			}
		}

		[Token(Token = "0x6000B40")]
		[Address(RVA = "0xA300DC", Offset = "0xA300DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseButtonDown::DoGetMouseButtonDown(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetMouseButtonDown();
		}

		[Token(Token = "0x6000B41")]
		[Address(RVA = "0xA3007C", Offset = "0xA3007C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetMouseButtonDown(this.button);\n\tv17 = v14 == 0;\n\tif (v17) goto L_0014;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0014:\n\tv27 = this.storeResult;\n\tv27.value = v14;\n\treturn;\n\tv35 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetMouseButtonDown()
		{
			bool mouseButtonDown = Input.GetMouseButtonDown((int)button);
			if (mouseButtonDown)
			{
				Fsm.Event(sendEvent);
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = mouseButtonDown;
		}

		[Token(Token = "0x6000B42")]
		[Address(RVA = "0xA300E0", Offset = "0xA300E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMouseButtonDown()
		{
		}
	}
}
