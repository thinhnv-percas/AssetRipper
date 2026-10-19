using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.ViewDrivenCellSizes
{
	[Token(Token = "0x200005A")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x40")]
		public RectTransform textRectTransform;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x48")]
		public RectOffset textBuffer;

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x402BF5C", Offset = "0x402BF5C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv75 = UnityEngine.UI.Text::set_text(this.someTextText, data.someText);\n\tv76 = ~calculateLayout;\n\tif (v76) goto L_003D;\n\tUnityEngine.Canvas::ForceUpdateCanvases();\n\tv37 = UnityEngine.RectTransform::get_rect(this.textRectTransform);\n\tv117 = UnityEngine.RectOffset::get_top(this.textBuffer);\n\tv89 = UnityEngine.RectOffset::get_bottom(this.textBuffer);\n\tv119 = v37.height + v117;\n\tv84 = v119 + v89;\n\tdata.cellSize = v84;\nL_003D:\n\treturn;\n")]
		public void SetData(Data data, bool calculateLayout)
		{
			someTextText.text = data.someText;
			if (calculateLayout)
			{
				Canvas.ForceUpdateCanvases();
				Rect rect = textRectTransform.rect;
				int top = textBuffer.top;
				int bottom = textBuffer.bottom;
				float num = rect.height + (float)top;
				float cellSize = num + (float)bottom;
				data.cellSize = cellSize;
			}
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0x402C00C", Offset = "0x402C00C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
