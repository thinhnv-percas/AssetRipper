using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.GridSimulation
{
	[Token(Token = "0x2000051")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x38")]
		public RowCellView[] rowCellViews;

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0x402AED0", Offset = "0x402AED0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv143 = 0;\n\tgoto L_0035;\nL_0026:\n\tv205 = UnityEngine.UI.Text::set_text(v59.text, v146.someText);\nL_0035:\n\tv67 = v143 >= v141.Length;\n\tif (v67) goto L_0073;\n\tv129 = data->klass;\n\tv59 = v141[v143 @ X22_v6 (System.Int32)];\n\tv123 = startingIndex + v143;\n\tv68 = v123 >= v129.Count;\n\tif (v68) goto L_FFFFFFFF;\n\tv196 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSimulation.Data>::get_Item(v129, v123);\nL_FFFFFFFF:\n\tv146 = v196;\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv146 = 0;\nL_0058:\n\tv91 = v146 == 0;\n\tv66 = ~v91;\n\tUnityEngine.GameObject::SetActive(v59.container, v66);\n\tv200 = v146 == 0;\n\tif (v200) goto L_0027;\n\tv201 = v59.text == 0;\n\tv133 = ~v201;\n\tif (v133) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0073:\n\treturn;\nL_001A:\n\tv141 = this.rowCellViews;\nL_0027:\n\tv141 = this.rowCellViews;\n\tv143 = v143 + 1;\n")]
		public void SetData(ref SmallList<Data> data, int startingIndex)
		{
			RowCellView[] array = rowCellViews;
			for (int i = 0; i < array.Length; i++)
			{
				SmallList<Data> smallList = data;
				RowCellView rowCellView = array[i];
				int num = startingIndex + i;
				Data data3;
				if (num < smallList.Count)
				{
					Data data2 = smallList[num];
					data3 = data2;
				}
				else
				{
					data3 = null;
				}
				bool flag = data3 == null;
				bool flag2 = !flag;
				rowCellView.container.SetActive(flag2);
				if (data3 != null)
				{
					if ((object)rowCellView.text == null)
					{
						throw new NullReferenceException();
					}
					rowCellView.text.text = data3.someText;
				}
				array = rowCellViews;
			}
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x402B038", Offset = "0x402B038", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
