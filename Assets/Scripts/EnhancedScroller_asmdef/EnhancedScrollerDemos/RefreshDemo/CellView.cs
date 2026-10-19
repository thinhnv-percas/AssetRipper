using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.RefreshDemo
{
	[Token(Token = "0x200005D")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x38")]
		private Data _data;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x40")]
		public Text someTextText;

		[Token(Token = "0x17000026")]
		public RectTransform RectTransform
		{
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x402CF60", Offset = "0x402CF60", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v42);\n\treturn returnVal1;\nL_0015:\n\tv42 = UnityEngine.Component::get_gameObject(this);\n")]
			get
			{
				GameObject gameObject = base.gameObject;
				return gameObject.GetComponent<RectTransform>();
			}
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0x402CFC0", Offset = "0x402CFC0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._data = data;\n\tv32 = EnhancedScrollerDemos.RefreshDemo.CellView::RefreshCellView(v32);\n\treturn;\n")]
		public void SetData(Data data)
		{
			_data = data;
			CellView cellView = default(CellView);
			cellView.RefreshCellView();
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0x402CFF0", Offset = "0x402CFF0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._data;\n\tv9 = UnityEngine.UI.Text::set_text(v9, v6.someText);\n\treturn;\n")]
		public override void RefreshCellView()
		{
			Data data = _data;
			Text text = default(Text);
			text.text = data.someText;
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0x402D024", Offset = "0x402D024", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
