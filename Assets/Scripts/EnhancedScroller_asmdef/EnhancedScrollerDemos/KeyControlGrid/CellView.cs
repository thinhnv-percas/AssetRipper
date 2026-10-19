using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.KeyControlGrid
{
	[Token(Token = "0x2000028")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x38")]
		public RowCellView[] rowCellViews;

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x4025D20", Offset = "0x4025D20", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv119 = 0;\n\tv107 = data->klass;\n\tv165 = startingIndex + v119;\n\tv61 = v165 >= v107.Count;\n\tif (v61) goto L_FFFFFFFF;\n\tv169 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>::get_Item(v107, v165);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv101 = v169;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv101 = 0;\nL_0046:\n\tEnhancedScrollerDemos.KeyControlGrid.RowCellView::SetData(v115[v119 @ X22_v6 (System.Int32)], v101);\n\tv115 = this.rowCellViews;\n\tv119 = v119 + 1;\n\tv172 = this.rowCellViews == 0;\n\tv110 = ~v172;\n\tif (v110) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0056:\n\treturn;\nL_0018:\n\tv115 = this.rowCellViews;\nL_0029:\n\tv62 = v119 >= v115.Length;\n\tif (v62) goto L_0056;\n")]
		public void SetData(ref SmallList<Data> data, int startingIndex)
		{
			RowCellView[] array = rowCellViews;
			int num = 0;
			while (num < array.Length)
			{
				SmallList<Data> smallList = data;
				int num2 = startingIndex + num;
				Data data3;
				if (num2 < smallList.Count)
				{
					Data data2 = smallList[num2];
					data3 = data2;
				}
				else
				{
					data3 = null;
				}
				array[num].SetData(data3);
				array = rowCellViews;
				num++;
				if (rowCellViews == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x4025ED4", Offset = "0x4025ED4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv136 = this.rowCellViews;\nL_FFFFFFFF:\n\tv129 = 0;\n\tgoto L_0029;\nL_001C:\n\tv129 = v129 + 1;\nL_0029:\n\tv82 = v129 >= v136.Length;\n\tif (v82) goto L_0073;\n\tv118 = v136[v129 @ X20_v3 (System.Int32)];\n\tv75 = v118._data;\n\tv210 = v118._data == 0;\n\tif (v210) goto L_001C;\n\tv225 = v75.isSelected == 0;\n\tv234 = ~v225;\n\tv235 = ~v234;\n\tif (v235) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv238 = 0x4C;\n\tgoto L_0047;\nL_FFFFFFFF:\n\tv238 = 0x5C;\nL_FFFFFFFF:\n\tv219 = 0x48;\n\tgoto L_004E;\nL_FFFFFFFF:\n\tv219 = 0x58;\nL_FFFFFFFF:\n\tv216 = 0x44;\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv216 = 0x54;\nL_FFFFFFFF:\n\tv249 = 0x40;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv249 = 0x50;\nL_0073:\n\treturn;\nL_0047:\n\tv239 = ~v225;\n\tv240 = ~v239;\n\tif (v240) goto L_FFFFFFFF;\nL_004E:\n\tv243 = ~v225;\n\tv244 = ~v243;\n\tif (v244) goto L_FFFFFFFF;\nL_0058:\n\tv220 = ~v225;\n\tv217 = ~v220;\n\tif (v217) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v249 @ X8_v6 (System.Int32)], [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v216 @ X11_v3 (System.Int32)], [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v219 @ X10_v4 (System.Int32)], [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v238 @ X8_v5 (System.Int32)]\n\tv218 = UnityEngine.UI.Graphic::set_color(v118.backgroundImage, Color_arg);\n\tv136 = this.rowCellViews;\n\tgoto L_001C;\n")]
		public override void RefreshCellView()
		{
			//IL_01bc: Expected F4, but got I
			//IL_01d1: Expected F4, but got I
			//IL_01e6: Expected F4, but got I
			//IL_01fb: Expected F4, but got I
			RowCellView[] array = rowCellViews;
			Color color = default(Color);
			foreach (RowCellView rowCellView in array)
			{
				Data data = rowCellView._data;
				if (rowCellView._data != null)
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v249 @ X8_v6 (System.Int32)]");
					color.r = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v216 @ X11_v3 (System.Int32)]");
					color.g = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v219 @ X10_v4 (System.Int32)]");
					color.b = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X9_v5 (EnhancedScrollerDemos.KeyControlGrid.RowCellView)+v238 @ X8_v5 (System.Int32)]");
					color.a = 0f;
					rowCellView.backgroundImage.color = color;
					array = rowCellViews;
				}
			}
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x4026030", Offset = "0x4026030", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
