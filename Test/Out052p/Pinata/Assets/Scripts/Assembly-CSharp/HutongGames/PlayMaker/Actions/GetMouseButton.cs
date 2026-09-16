using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757D88", Offset = "0x757D88")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757D88", Offset = "0x757D88")]
	[Token(Token = "0x200023E")]
	public class GetMouseButton : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B382C", Offset = "0x7B382C")]
		[Token(Token = "0x4001571")]
		[FieldOffset(Offset = "0x4C")]
		public MouseButton button;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3878", Offset = "0x7B3878")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3878", Offset = "0x7B3878")]
		[Token(Token = "0x4001572")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool storeResult;

		[Token(Token = "0x6000B3A")]
		[Address(RVA = "0xA2FFC8", Offset = "0xA2FFC8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.button = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			button = default(MouseButton);
			storeResult = null;
		}

		[Token(Token = "0x6000B3B")]
		[Address(RVA = "0xA2FFD4", Offset = "0xA2FFD4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.storeResult;\n\tv12 = UnityEngine.Input::GetMouseButton(this.button);\n\tv8.value = v12;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = storeResult;
			bool mouseButton = Input.GetMouseButton((int)button);
			fsmBool.value = mouseButton;
		}

		[Token(Token = "0x6000B3C")]
		[Address(RVA = "0xA30010", Offset = "0xA30010", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.storeResult;\n\tv12 = UnityEngine.Input::GetMouseButton(this.button);\n\tv8.value = v12;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = storeResult;
			bool mouseButton = Input.GetMouseButton((int)button);
			fsmBool.value = mouseButton;
		}

		[Token(Token = "0x6000B3D")]
		[Address(RVA = "0xA3004C", Offset = "0xA3004C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMouseButton()
		{
		}
	}
}
