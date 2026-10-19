using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.PullDownRefresh
{
	[Token(Token = "0x2000048")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x40298E0", Offset = "0x40298E0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x4029910", Offset = "0x4029910", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
