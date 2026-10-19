using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.KeyControl
{
	[Token(Token = "0x200002C")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x38")]
		private Data _data;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x40")]
		public Image backgroundImage;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x48")]
		public Text someTextText;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x50")]
		public Color selectedColor;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x60")]
		public Color unselectedColor;

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x4026688", Offset = "0x4026688", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._data = data;\n\tv31 = this._data;\n\tv42 = UnityEngine.UI.Text::set_text(this.someTextText, v31.someText);\n\tv46 = EnhancedScrollerDemos.KeyControl.CellView::RefreshCellView(v46);\n\treturn;\n")]
		public void SetData(Data data)
		{
			_data = data;
			Data data2 = _data;
			someTextText.text = data2.someText;
			CellView cellView = default(CellView);
			cellView.RefreshCellView();
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x40266E8", Offset = "0x40266E8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._data;\n\tv35 = v6.isSelected == 0;\n\tv42 = ~v35;\n\tv43 = ~v42;\n\tif (v43) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv102 = 0x5C;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv102 = 0x6C;\nL_FFFFFFFF:\n\tv78 = 0x58;\n\tgoto L_0028;\nL_FFFFFFFF:\n\tv78 = 0x68;\nL_FFFFFFFF:\n\tv69 = 0x54;\n\tgoto L_0034;\nL_FFFFFFFF:\n\tv69 = 0x64;\nL_FFFFFFFF:\n\tv117 = 0x50;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv117 = 0x60;\nL_001F:\n\tv105 = ~v35;\n\tv106 = ~v105;\n\tif (v106) goto L_FFFFFFFF;\nL_0028:\n\tv111 = ~v35;\n\tv112 = ~v111;\n\tif (v112) goto L_FFFFFFFF;\nL_0034:\n\tv75 = ~v35;\n\tv72 = ~v75;\n\tif (v72) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v117 @ X9_v5 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v69 @ X11_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v78 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v102 @ X9_v4 (System.Int32)]\n\tv67 = UnityEngine.UI.Graphic::set_color(v67, Color_arg);\n\treturn;\n")]
		public override void RefreshCellView()
		{
			//IL_0138: Expected F4, but got I
			//IL_014d: Expected F4, but got I
			//IL_0162: Expected F4, but got I
			//IL_0177: Expected F4, but got I
			Data data = _data;
			bool flag = !data.isSelected;
			if (!flag)
			{
				int num = 92;
			}
			else
			{
				int num = 108;
			}
			if (!flag)
			{
				int num2 = 88;
			}
			else
			{
				int num2 = 104;
			}
			if (!flag)
			{
				int num3 = 84;
			}
			else
			{
				int num3 = 100;
			}
			if (!flag)
			{
				int num4 = 80;
			}
			else
			{
				int num4 = 96;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v117 @ X9_v5 (System.Int32)]");
			Color color = default(Color);
			color.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v69 @ X11_v3 (System.Int32)]");
			color.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v78 @ X10_v3 (System.Int32)]");
			color.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControl.CellView)+v102 @ X9_v4 (System.Int32)]");
			color.a = 0f;
			Image image = default(Image);
			image.color = color;
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x4026764", Offset = "0x4026764", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
