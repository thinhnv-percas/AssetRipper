using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x200003F")]
	public class DetailCellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x4028E94", Offset = "0x4028E94", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(DetailData data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x4028EC4", Offset = "0x4028EC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DetailCellView()
		{
		}
	}
}
