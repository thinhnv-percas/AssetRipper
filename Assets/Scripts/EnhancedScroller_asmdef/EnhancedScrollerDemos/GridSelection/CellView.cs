using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.GridSelection
{
	[Token(Token = "0x200004C")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x38")]
		public RowCellView[] rowCellViews;

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x402A0B4", Offset = "0x402A0B4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv116 = 0;\n\tv119 = data->klass;\n\tv133 = startingIndex + v116;\n\tv73 = v133 >= v119.Count;\n\tif (v73) goto L_FFFFFFFF;\n\tv185 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>::get_Item(v119, v133);\nL_FFFFFFFF:\n\tv70 = v185;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv70 = 0;\nL_004C:\n\tEnhancedScrollerDemos.GridSelection.RowCellView::SetData(v127[v116 @ X24_v5 (System.Int32)], v133, v70, selected);\n\tv127 = this.rowCellViews;\n\tv116 = v116 + 1;\n\tv188 = this.rowCellViews == 0;\n\tv122 = ~v188;\n\tif (v122) goto L_002C;\n\tthrow System.NullReferenceException;\nL_005E:\n\treturn;\nL_001B:\n\tv127 = this.rowCellViews;\nL_002C:\n\tv74 = v116 >= v127.Length;\n\tif (v74) goto L_005E;\n")]
		public void SetData(ref SmallList<Data> data, int startingIndex, SelectedDelegate selected)
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
				array[num].SetData(num2, data3, selected);
				array = rowCellViews;
				num++;
				if (rowCellViews == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x402A598", Offset = "0x402A598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
