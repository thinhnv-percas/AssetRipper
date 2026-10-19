using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
	[Token(Token = "0x2000081")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x4032A2C", Offset = "0x4032A2C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0x4032A5C", Offset = "0x4032A5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
