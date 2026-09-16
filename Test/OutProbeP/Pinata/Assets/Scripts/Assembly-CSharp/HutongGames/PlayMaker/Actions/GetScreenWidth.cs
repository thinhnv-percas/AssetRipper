using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753874", Offset = "0x753874")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753874", Offset = "0x753874")]
	[Token(Token = "0x200016D")]
	public class GetScreenWidth : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A8F2C", Offset = "0x7A8F2C")]
		[Token(Token = "0x4001232")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeScreenWidth;

		[Token(Token = "0x60007FE")]
		[Address(RVA = "0xA359AC", Offset = "0xA359AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeScreenWidth = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeScreenWidth = null;
		}

		[Token(Token = "0x60007FF")]
		[Address(RVA = "0xA359B4", Offset = "0xA359B4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.storeScreenWidth;\n\tv14 = UnityEngine.Screen::get_width();\n\tv12.value = v14;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = storeScreenWidth;
			int width = Screen.width;
			fsmFloat.Value = width;
			Finish();
		}

		[Token(Token = "0x6000800")]
		[Address(RVA = "0xA359F8", Offset = "0xA359F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetScreenWidth()
		{
		}
	}
}
