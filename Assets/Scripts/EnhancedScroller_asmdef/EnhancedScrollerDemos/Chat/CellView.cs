using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.Chat
{
	[Token(Token = "0x2000021")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x40")]
		public RectTransform textRectTransform;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x48")]
		public RectOffset textBuffer;

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x4024038", Offset = "0x4024038", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.UI.Text::set_text(v8, data.someText);\n\treturn;\n")]
		public void SetData(Data data)
		{
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x4024068", Offset = "0x4024068", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
