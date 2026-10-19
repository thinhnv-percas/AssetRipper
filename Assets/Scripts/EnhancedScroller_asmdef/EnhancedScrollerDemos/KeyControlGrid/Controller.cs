using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.KeyControlGrid
{
	[Token(Token = "0x2000029")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x28")]
		private int _selectedIndex;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x38")]
		public int numberOfCellsPerRow;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x40")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x4026038", Offset = "0x4026038", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.KeyControlGrid.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x4026240", Offset = "0x4026240", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv177 = this._selectedIndex - this.numberOfCellsPerRow;\n\tv58 = this._selectedIndex >= this.numberOfCellsPerRow;\n\tif (v58) goto L_0058;\nL_0029:\n\tv82 = UnityEngine.Input::GetKeyDown(0x112);\n\tv85 = ~v82;\n\tif (v85) goto L_0042;\n\tv187 = this._data;\n\tv250 = v187.Count;\n\tv218 = v187.Count - this.numberOfCellsPerRow;\n\tv220 = this._selectedIndex >= v218;\n\tif (v220) goto L_0042;\n\tv177 = this.numberOfCellsPerRow + this._selectedIndex;\n\tgoto L_005F;\nL_0042:\n\tv234 = UnityEngine.Input::GetKeyDown(0x114);\n\tv275 = ~v234;\n\tif (v275) goto L_004E;\n\tv187 = this._data;\n\tv250 = v187.Count;\n\tv177 = this._selectedIndex - 1;\n\tgoto L_005F;\nL_004E:\n\tv293 = UnityEngine.Input::GetKeyDown(0x113);\n\tv322 = ~v293;\n\tif (v322) goto L_00FC;\n\tv187 = this._data;\n\tv250 = v187.Count;\n\tv177 = this._selectedIndex + 1;\n\tgoto L_005F;\nL_0058:\n\tv187 = this._data;\n\tv250 = v187.Count;\nL_FFFFFFFF:\n\tv378 = v177;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv378 = 0;\n\tgoto L_0082;\n\tv185 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>::get_Item(v187, v212);\n\tv166 = v212 - this._selectedIndex;\n\tv154 = v166 == 0;\n\tv185.isSelected = v154;\n\tv212 = v212 + 1;\n\tv187 = this._data;\n\tv429 = this._data == 0;\n\tv197 = ~v429;\n\tif (v197) goto L_008D;\n\tgoto L_00D4;\nL_00A6:\n\tv95 = this.scroller;\n\tgoto L_00B4;\nL_FFFFFFFF:\n\tv214 = 0;\n\tv188 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v271, v214);\n\tv448 = EnhancedUI.EnhancedScroller.EnhancedScrollerCellView::RefreshCellView(v188);\n\tv214 = v214 + 1;\n\tv271 = v95._activeCellViews;\n\tv449 = v95._activeCellViews == 0;\n\tv192 = ~v449;\n\tif (v192) goto L_00C4;\nL_00D4:\n\tthrow System.NullReferenceException;\nL_00D5:\n\tv189 = this.scroller;\n\tv280 = this._selectedIndex / this.numberOfCellsPerRow;\n\tv291 = v280 >= v189.EndCellViewIndex;\n\tif (v291) goto L_FFFFFFFF;\n\tv318 = v280 <= v189.StartCellViewIndex;\n\tif (v318) goto L_FFFFFFFF;\nL_00FC:\n\treturn;\nL_FFFFFFFF:\n\tv354 = 1f;\nL_FFFFFFFF:\n\tv355 = 1f;\n\tgoto L_010F;\nL_FFFFFFFF:\n\tv354 = 0;\nL_FFFFFFFF:\n\tv355 = 0;\nL_0016:\n\tv44 = UnityEngine.Input::GetKeyDown(0x111);\n\tv45 = ~v44;\n\tif (v45) goto L_0029;\nL_005F:\n\tv378 = v250 - 1;\n\tv258 = v177 - v378;\n\tv259 = v258 < 0;\n\tv261 = v177 ^ v378;\n\tv262 = v177 ^ v258;\n\tv263 = v261 & v262;\n\tv264 = v263 < 0;\n\tv265 = v259 == v264;\n\tv266 = ~v265;\n\tv267 = ~v266;\n\tif (v267) goto L_0074;\nL_0074:\n\tv298 = v177 < 0;\n\tv301 = v177 ^ v177;\n\tv302 = v177 & v301;\n\tv303 = v302 < 0;\n\tv304 = v298 == v303;\n\tv305 = ~v304;\n\tv88 = ~v305;\n\tif (v88) goto L_0082;\nL_0082:\n\tthis._selectedIndex = v378;\nL_FFFFFFFF:\n\tv212 = 0;\nL_008D:\n\tv124 = v212 >= v187.Count;\n\tif (v124) goto L_00A6;\nL_00B4:\n\tv271 = v95._activeCellViews;\nL_00C4:\n\tv122 = v214 >= v271.Count;\n\tif (v122) goto L_00D5;\nL_010F:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(v189, v280, v355, v354, 1, 0, 0f, 0, 0, 0);\n\treturn;\n")]
		private void Update()
		{
			int num;
			SmallList<Data> data;
			int count;
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				num = _selectedIndex - numberOfCellsPerRow;
				if (_selectedIndex >= numberOfCellsPerRow)
				{
					data = _data;
					count = data.Count;
					goto IL_0380;
				}
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				data = _data;
				count = data.Count;
				int num2 = data.Count - numberOfCellsPerRow;
				if (_selectedIndex < num2)
				{
					num = numberOfCellsPerRow + _selectedIndex;
					goto IL_0380;
				}
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				data = _data;
				count = data.Count;
				num = _selectedIndex - 1;
			}
			else
			{
				if (!Input.GetKeyDown(KeyCode.RightArrow))
				{
					return;
				}
				data = _data;
				count = data.Count;
				num = _selectedIndex + 1;
			}
			goto IL_0380;
			IL_0380:
			int num3 = count - 1;
			int num4 = num - num3;
			bool flag = num4 < 0;
			int num5 = num ^ num3;
			int num6 = num ^ num4;
			int num7 = num5 & num6;
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
				num3 = num;
			}
			bool flag3 = num < 0;
			int num8 = num ^ num;
			int num9 = num & num8;
			bool flag4 = num9 < 0;
			if (flag3 != flag4)
			{
				num3 = 0;
			}
			_selectedIndex = num3;
			int num10 = 0;
			while (true)
			{
				if (num10 < data.Count)
				{
					Data data2 = data[num10];
					int num11 = num10 - _selectedIndex;
					bool isSelected = num11 == 0;
					data2.isSelected = isSelected;
					num10++;
					data = _data;
					if (_data != null)
					{
						continue;
					}
				}
				else
				{
					EnhancedScroller enhancedScroller = scroller;
					SmallList<EnhancedScrollerCellView> activeCellViews = enhancedScroller._activeCellViews;
					int num12 = 0;
					do
					{
						if (num12 < activeCellViews.Count)
						{
							EnhancedScrollerCellView enhancedScrollerCellView = activeCellViews[num12];
							enhancedScrollerCellView.RefreshCellView();
							num12++;
							activeCellViews = enhancedScroller._activeCellViews;
							continue;
						}
						EnhancedScroller enhancedScroller2 = scroller;
						int num13 = _selectedIndex / numberOfCellsPerRow;
						float cellOffset;
						float scrollerOffset;
						if (num13 < enhancedScroller2.EndCellViewIndex)
						{
							if (num13 > enhancedScroller2.StartCellViewIndex)
							{
								return;
							}
							cellOffset = 0f;
							scrollerOffset = 0f;
						}
						else
						{
							cellOffset = 1f;
							scrollerOffset = 1f;
						}
						enhancedScroller2.JumpToDataIndex(num13, scrollerOffset, cellOffset);
						return;
					}
					while (enhancedScroller._activeCellViews != null);
				}
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x40260E8", Offset = "0x40260E8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv126.someText = v131;\n\tv152 = v129 - this._selectedIndex;\n\tv148 = v152 == 0;\n\tv126.isSelected = v148;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>::Add(this._data, v126);\n\tv122 = v129 + 1;\n\tv79 = v122 < 0x1F;\n\tif (v79) goto L_0037;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002A:\n\tv60 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>::.ctor(v60);\n\tthis._data = v60;\nL_0037:\n\tv126 = new EnhancedScrollerDemos.KeyControlGrid.Data();\n\tSystem.Object::.ctor(v126);\n\tv131 = System.Int32::ToString(&v129 @ stack_-54_v3 (System.Int32));\n")]
		private void LoadData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			int num = default(int);
			int num3;
			do
			{
				Data data2 = new Data();
				string someText = num.ToString();
				data2.someText = someText;
				int num2 = num - _selectedIndex;
				bool isSelected = num2 == 0;
				data2.isSelected = isSelected;
				_data.Add(data2);
				num3 = num + 1;
			}
			while (num3 < 31);
			scroller.ReloadData();
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x402647C", Offset = "0x402647C", Length = "0x94")]
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

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x4026510", Offset = "0x4026510", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x402651C", Offset = "0x402651C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\tv59 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv131 = v59 == 0;\n\tif (v131) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = 0;\n\tgoto L_0053;\nL_FFFFFFFF:\n\t// -1 IsInst v214_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.KeyControlGrid.CellView), typeof(EnhancedScrollerDemos.KeyControlGrid.CellView), v59 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv214 = v214_asT == 0;\n\tif (v214) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = v59;\n\tgoto L_0053;\nL_FFFFFFFF:\n\tv124 = 0;\n\tUnityEngine.Object::set_name(v124, v115);\n\tEnhancedScrollerDemos.KeyControlGrid.CellView::SetData(v124, &this._data (EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControlGrid.Data>), v109);\n\treturn v124;\nL_0053:\n\tv221 = System.Int32::ToString(&v109 @ stack_-44_v3 (System.Int32));\n\tv223 = v109 + this.numberOfCellsPerRow;\n\tv119 = v223 - 1;\n\tv67 = v119;\n\tv226 = System.Int32::ToString(&v67 @ stack_-48_v2 (System.Int32));\n\tv115 = System.String::Concat(\"Cell \", v221, \" to \", v226);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			((CellView)obj).SetData(ref _data, num);
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x4026670", Offset = "0x4026670", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.numberOfCellsPerRow = 3;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
			numberOfCellsPerRow = 3;
		}
	}
}
