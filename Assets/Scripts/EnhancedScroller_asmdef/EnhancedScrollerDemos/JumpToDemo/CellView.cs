using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.JumpToDemo
{
	[Token(Token = "0x2000070")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x38")]
		public Text cellText;

		[Token(Token = "0x6000224")]
		[Address(RVA = "0x402F568", Offset = "0x402F568", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.cellText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.cellText;
		}

		[Token(Token = "0x6000225")]
		[Address(RVA = "0x402F598", Offset = "0x402F598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
