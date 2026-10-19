using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.CellEvents
{
	[Token(Token = "0x2000057")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x38")]
		private Data _data;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x40")]
		public Text someTextText;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x48")]
		public CellButtonTextClickedDelegate cellButtonTextClicked;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x50")]
		public CellButtonIntegerClickedDelegate cellButtonFixedIntegerClicked;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x58")]
		public CellButtonIntegerClickedDelegate cellButtonDataIntegerClicked;

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0x402B6B8", Offset = "0x402B6B8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv55 = this._data + 0x10;\n\tv57 = v55.m_value == 0;\n\tif (v57) goto L_003F;\n\tv76 = System.Int32::ToString(v55);\n\tv64 = System.String::Format(\"{0} 'o clock\", v76);\n\tv82 = v64;\nL_003B:\n\tv90 = UnityEngine.UI.Text::set_text(v90, v82);\nL_003B:\n\treturn;\nL_003F:\n\tv78 = this.someTextText == 0;\n\tv66 = ~v78;\n\tv82 = \"Midnight\";\n\tif (v66) goto L_003B;\n\tthrow System.NullReferenceException;\nL_001A:\n\tthis._data = v40;\n")]
		public unsafe void SetData(Data data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellView::SetData");
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0x402B77C", Offset = "0x402B77C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.cellButtonTextClicked == 0;\n\tif (v2) goto L_0007;\n\tEnhancedScrollerDemos.CellEvents.CellButtonTextClickedDelegate::Invoke(this.cellButtonTextClicked, value);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CellButtonText_OnClick(string value)
		{
			if (cellButtonTextClicked != null)
			{
				cellButtonTextClicked(value);
			}
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0x402B798", Offset = "0x402B798", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.cellButtonFixedIntegerClicked == 0;\n\tif (v2) goto L_0007;\n\tEnhancedScrollerDemos.CellEvents.CellButtonIntegerClickedDelegate::Invoke(this.cellButtonFixedIntegerClicked, value);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CellButtonFixedInteger_OnClick(int value)
		{
			if (cellButtonFixedIntegerClicked != null)
			{
				cellButtonFixedIntegerClicked(value);
			}
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0x402B7B4", Offset = "0x402B7B4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.cellButtonDataIntegerClicked == 0;\n\tif (v2) goto L_000B;\n\tv3 = this._data;\n\tEnhancedScrollerDemos.CellEvents.CellButtonIntegerClickedDelegate::Invoke(this.cellButtonDataIntegerClicked, v3.hour);\n\treturn;\nL_000B:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CellButtonDataInteger_OnClick()
		{
			if (cellButtonDataIntegerClicked != null)
			{
				Data data = _data;
				cellButtonDataIntegerClicked(data.hour);
			}
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0x402B7E8", Offset = "0x402B7E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
