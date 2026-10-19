using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	[Token(Token = "0x2000035")]
	public class DetailCellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x4027D84", Offset = "0x4027D84", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(DetailData data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0x4027DB4", Offset = "0x4027DB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DetailCellView()
		{
		}
	}
}
