using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.GridSelection
{
	[Token(Token = "0x200004D")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x38")]
		public int numberOfCellsPerRow;

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x402A5A0", Offset = "0x402A5A0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.GridSelection.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x402A650", Offset = "0x402A650", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv110 = 0;\n\tv155 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>::get_Item(v113, v110);\n\tv155.selectedChanged = 0;\n\tv110 = v110 + 1;\n\tv113 = this._data;\n\tv210 = this._data == 0;\n\tv146 = ~v210;\n\tif (v146) goto L_0034;\n\tthrow System.NullReferenceException;\nL_004E:\n\tv129 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>::.ctor(v129);\n\tthis._data = v129;\n\tv209.someText = v193;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>::Add(this._data, v209);\n\tv200 = v183 + 1;\n\tv166 = v200 < 0x3E8;\n\tif (v166) goto L_0059;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_0024:\n\tv113 = this._data;\n\tv50 = this._data == 0;\n\tif (v50) goto L_004E;\nL_0034:\n\tv59 = v110 >= v113.Count;\n\tif (v59) goto L_004E;\nL_0059:\n\tv209 = new EnhancedScrollerDemos.GridSelection.Data();\n\tSystem.Object::.ctor(v209);\n\tv193 = System.Int32::ToString(&v183 @ stack_-44_v4 (System.Int32));\n")]
		private void LoadData()
		{
			SmallList<Data> data = _data;
			if (_data != null)
			{
				int num = 0;
				while (num < data.Count)
				{
					Data data2 = data[num];
					data2.selectedChanged = null;
					num++;
					data = _data;
					if (_data == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			SmallList<Data> data3 = new SmallList<Data>();
			_data = data3;
			int num2 = default(int);
			int num3;
			do
			{
				Data data4 = new Data();
				string someText = num2.ToString();
				data4.someText = someText;
				_data.Add(data4);
				num3 = num2 + 1;
			}
			while (num3 < 1000);
			scroller.ReloadData();
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x402A7E4", Offset = "0x402A7E4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(cellView, 0);\n\tv62 = v53 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_003A;\n\tgoto L_003D;\nL_003A:\n\treturn;\nL_003D:\n\tv105 = this._data;\n\tv114 = 0;\n\tgoto L_0053;\nL_0045:\n\tv114 = v114 + 1;\n\tv105 = this._data;\nL_0053:\n\tv75 = v114 >= v105.Count;\n\tif (v75) goto L_003A;\n\tv186 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>::get_Item(v105, v114);\n\tv206 = cellView.DataIndex - v114;\n\tv208 = v206 == 0;\n\tv219 = v186.Selected == v208;\n\tif (v219) goto L_0045;\n\tv186.Selected = v208;\n\tv225 = v186.selectedChanged == 0;\n\tif (v225) goto L_0045;\n\tv233 = cellView.DataIndex - v114;\n\tv231 = v233 == 0;\n\tEnhancedScrollerDemos.GridSelection.SelectedChangedDelegate::Invoke(v186.selectedChanged, v231);\n\tgoto L_0045;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CellViewSelected(RowCellView cellView)
		{
			if (cellView == null)
			{
				return;
			}
			SmallList<Data> data = _data;
			int num = 0;
			while (num < data.Count)
			{
				Data data2 = data[num];
				int num2 = cellView.DataIndex - num;
				bool flag = num2 == 0;
				if (data2.Selected != flag)
				{
					data2._selected = flag;
					if (data2.selectedChanged != null)
					{
						int num3 = cellView.DataIndex - num;
						bool val = num3 == 0;
						data2.selectedChanged(val);
					}
				}
				num++;
				data = _data;
			}
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x402A93C", Offset = "0x402A93C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._data;\n\tgoto L_001E;\nL_0022:\n\tv56 = v14.Count / this.numberOfCellsPerRow;\n\tv57 = UnityEngine.Mathf::Ceil(v56);\n\tv76 = v57 == 0x7F800000;\n\tv61 = ~v76;\n\tif (v61) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0xFFFFFFFF80000000;\n\tgoto L_003D;\nL_FFFFFFFF:\n\treturnVal2 = v56;\nL_001E:\n\tgoto L_0022;\nL_003D:\n\treturn returnVal2;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			//IL_0077: Expected I4, but got F4
			SmallList<Data> data = _data;
			float num = (float)data.Count / (float)numberOfCellsPerRow;
			float num2 = Mathf.Ceil(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x402A9D0", Offset = "0x402A9D0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x402A9DC", Offset = "0x402A9DC", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv59 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv132 = v59 == 0;\n\tif (v132) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = 0;\n\tgoto L_0059;\nL_FFFFFFFF:\n\t// -1 IsInst v221_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.GridSelection.CellView), typeof(EnhancedScrollerDemos.GridSelection.CellView), v59 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv221 = v221_asT == 0;\n\tif (v221) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = v59;\n\tgoto L_0059;\nL_FFFFFFFF:\n\tv124 = 0;\n\tUnityEngine.Object::set_name(v124, v115);\n\tv244 = new EnhancedScrollerDemos.GridSelection.SelectedDelegate();\n\tEnhancedScrollerDemos.GridSelection.SelectedDelegate::.ctor(v244, this, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.GridSelection.CellView::SetData(v124, &this._data (EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSelection.Data>), v109, v244);\n\treturn v124;\nL_0059:\n\tv228 = System.Int32::ToString(&v109 @ stack_-44_v3 (System.Int32));\n\tv230 = v109 + this.numberOfCellsPerRow;\n\tv119 = v230 - 1;\n\tv67 = v119;\n\tv233 = System.Int32::ToString(&v67 @ stack_-48_v2 (System.Int32));\n\tv115 = System.String::Concat(\"Cell \", v228, \" to \", v233);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int num = default(int);
			string text = num.ToString();
			int num2 = num + numberOfCellsPerRow;
			int num3 = num2 - 1;
			int num4 = num3;
			string text2 = num4.ToString();
			string text3 = "Cell " + text + " to " + text2;
			obj.name = text3;
			SelectedDelegate selected = CellViewSelected;
			((CellView)obj).SetData(ref _data, num, selected);
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x402AB78", Offset = "0x402AB78", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.numberOfCellsPerRow = 3;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
			numberOfCellsPerRow = 3;
		}
	}
}
