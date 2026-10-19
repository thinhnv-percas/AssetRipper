using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.KeyControlGrid
{
	[Token(Token = "0x200002B")]
	public class RowCellView : MonoBehaviour
	{
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x20")]
		internal Data _data;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x28")]
		public GameObject container;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x30")]
		public Image backgroundImage;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x38")]
		public Text someTextText;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x40")]
		public Color selectedColor;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x50")]
		public Color unselectedColor;

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x4025DE8", Offset = "0x4025DE8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._data = data;\n\tv42 = data == 0;\n\tv47 = ~v42;\n\tUnityEngine.GameObject::SetActive(this.container, v47);\n\tv55 = this._data;\n\tv86 = this._data == 0;\n\tif (v86) goto L_0074;\n\tv94 = UnityEngine.UI.Text::set_text(this.someTextText, v55.someText);\n\tv56 = this._data;\n\tv92 = this._data == 0;\n\tif (v92) goto L_0074;\n\tv144 = v56.isSelected == 0;\n\tv166 = ~v144;\n\tv167 = ~v166;\n\tif (v167) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv170 = 0x4C;\n\tgoto L_0045;\nL_FFFFFFFF:\n\tv170 = 0x5C;\nL_FFFFFFFF:\n\tv126 = 0x48;\n\tgoto L_004E;\nL_FFFFFFFF:\n\tv126 = 0x58;\nL_FFFFFFFF:\n\tv120 = 0x44;\n\tgoto L_005A;\nL_FFFFFFFF:\n\tv120 = 0x54;\nL_FFFFFFFF:\n\tv185 = 0x40;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv185 = 0x50;\nL_0074:\n\treturn;\nL_0045:\n\tv173 = ~v144;\n\tv174 = ~v173;\n\tif (v174) goto L_FFFFFFFF;\nL_004E:\n\tv179 = ~v144;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\nL_005A:\n\tv134 = ~v144;\n\tv123 = ~v134;\n\tif (v123) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v185 @ X8_v9 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v120 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v126 @ X9_v6 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v170 @ X8_v8 (System.Int32)]\n\tv84 = UnityEngine.UI.Graphic::set_color(v84, Color_arg);\n\treturn;\n")]
		public void SetData(Data data)
		{
			//IL_01bc: Expected F4, but got I
			//IL_01d1: Expected F4, but got I
			//IL_01e6: Expected F4, but got I
			//IL_01fb: Expected F4, but got I
			_data = data;
			bool flag = data == null;
			bool active = !flag;
			container.SetActive(active);
			Data data2 = _data;
			if (_data == null)
			{
				return;
			}
			someTextText.text = data2.someText;
			Data data3 = _data;
			if (_data != null)
			{
				bool flag2 = !data3.isSelected;
				if (!flag2)
				{
					int num = 76;
				}
				else
				{
					int num = 92;
				}
				if (!flag2)
				{
					int num2 = 72;
				}
				else
				{
					int num2 = 88;
				}
				if (!flag2)
				{
					int num3 = 68;
				}
				else
				{
					int num3 = 84;
				}
				if (!flag2)
				{
					int num4 = 64;
				}
				else
				{
					int num4 = 80;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v185 @ X8_v9 (System.Int32)]");
				Color color = default(Color);
				color.r = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v120 @ X10_v3 (System.Int32)]");
				color.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v126 @ X9_v6 (System.Int32)]");
				color.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v170 @ X8_v8 (System.Int32)]");
				color.a = 0f;
				Image image = default(Image);
				image.color = color;
			}
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x4025FB4", Offset = "0x4025FB4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\tv2 = this._data == 0;\n\tif (v2) goto L_003D;\n\tv10 = v0.isSelected == 0;\n\tv17 = ~v10;\n\tv18 = ~v17;\n\tif (v18) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv100 = 0x4C;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv100 = 0x5C;\nL_FFFFFFFF:\n\tv75 = 0x48;\n\tgoto L_0024;\nL_FFFFFFFF:\n\tv75 = 0x58;\nL_FFFFFFFF:\n\tv66 = 0x44;\n\tgoto L_0030;\nL_FFFFFFFF:\n\tv66 = 0x54;\nL_FFFFFFFF:\n\tv115 = 0x40;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv115 = 0x50;\nL_003D:\n\treturn;\nL_001B:\n\tv103 = ~v10;\n\tv104 = ~v103;\n\tif (v104) goto L_FFFFFFFF;\nL_0024:\n\tv109 = ~v10;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\nL_0030:\n\tv72 = ~v10;\n\tv69 = ~v72;\n\tif (v69) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v115 @ X9_v5 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v66 @ X11_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v75 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v100 @ X9_v4 (System.Int32)]\n\tv59 = UnityEngine.UI.Graphic::set_color(v59, Color_arg);\n\treturn;\n")]
		public void RefreshCellView()
		{
			//IL_014f: Expected F4, but got I
			//IL_0164: Expected F4, but got I
			//IL_0179: Expected F4, but got I
			//IL_018e: Expected F4, but got I
			Data data = _data;
			if (_data != null)
			{
				bool flag = !data.isSelected;
				if (!flag)
				{
					int num = 76;
				}
				else
				{
					int num = 92;
				}
				if (!flag)
				{
					int num2 = 72;
				}
				else
				{
					int num2 = 88;
				}
				if (!flag)
				{
					int num3 = 68;
				}
				else
				{
					int num3 = 84;
				}
				if (!flag)
				{
					int num4 = 64;
				}
				else
				{
					int num4 = 80;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v115 @ X9_v5 (System.Int32)]");
				Color color = default(Color);
				color.r = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v66 @ X11_v3 (System.Int32)]");
				color.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v75 @ X10_v3 (System.Int32)]");
				color.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v100 @ X9_v4 (System.Int32)]");
				color.a = 0f;
				Image image = default(Image);
				image.color = color;
			}
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x4026680", Offset = "0x4026680", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RowCellView()
		{
		}
	}
}
