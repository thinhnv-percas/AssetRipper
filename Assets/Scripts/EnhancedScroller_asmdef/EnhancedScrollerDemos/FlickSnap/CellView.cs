using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.FlickSnap
{
	[Token(Token = "0x200001D")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x4023A24", Offset = "0x4023A24", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x4023A54", Offset = "0x4023A54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
