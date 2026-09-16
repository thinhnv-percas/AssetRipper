using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753824", Offset = "0x753824")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753824", Offset = "0x753824")]
	[Token(Token = "0x200016C")]
	public class GetScreenHeight : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A8EF0", Offset = "0x7A8EF0")]
		[Token(Token = "0x4001231")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeScreenHeight;

		[Token(Token = "0x60007FB")]
		[Address(RVA = "0xA35958", Offset = "0xA35958", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeScreenHeight = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeScreenHeight = null;
		}

		[Token(Token = "0x60007FC")]
		[Address(RVA = "0xA35960", Offset = "0xA35960", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.storeScreenHeight;\n\tv14 = UnityEngine.Screen::get_height();\n\tv12.value = v14;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = storeScreenHeight;
			int height = Screen.height;
			fsmFloat.Value = height;
			Finish();
		}

		[Token(Token = "0x60007FD")]
		[Address(RVA = "0xA359A4", Offset = "0xA359A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetScreenHeight()
		{
		}
	}
}
