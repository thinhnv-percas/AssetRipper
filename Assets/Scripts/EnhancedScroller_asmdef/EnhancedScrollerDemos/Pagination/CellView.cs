using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.Pagination
{
	[Token(Token = "0x200002F")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x4026CFC", Offset = "0x4026CFC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x4026D2C", Offset = "0x4026D2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
