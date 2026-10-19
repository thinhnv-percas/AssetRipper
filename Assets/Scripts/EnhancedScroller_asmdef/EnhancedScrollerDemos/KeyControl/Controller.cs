using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.KeyControl
{
	[Token(Token = "0x200002D")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x28")]
		private int _selectedIndex;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x402676C", Offset = "0x402676C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.KeyControl.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0x4026998", Offset = "0x4026998", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv142 = this._data;\nL_FFFFFFFF:\n\tv174 = -1;\n\tgoto L_002C;\nL_0020:\n\tv50 = UnityEngine.Input::GetKeyDown(0x112);\n\tv170 = ~v50;\n\tif (v170) goto L_00C8;\n\tv142 = this._data;\nL_FFFFFFFF:\n\tv174 = 1;\nL_FFFFFFFF:\n\tv128 = v179;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv323 = 0;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv323 = v128;\n\tv140 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControl.Data>::get_Item(v142, v164);\n\tv112 = v164 - this._selectedIndex;\n\tv100 = v112 == 0;\n\tv140.isSelected = v100;\n\tv164 = v164 + 1;\n\tv142 = this._data;\n\tv342 = this._data == 0;\n\tv150 = ~v342;\n\tif (v150) goto L_005B;\n\tgoto L_00A2;\nL_0074:\n\tv69 = this.scroller;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv166 = 0;\n\tv143 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v196, v166);\n\tv361 = EnhancedUI.EnhancedScroller.EnhancedScrollerCellView::RefreshCellView(v143);\n\tv166 = v166 + 1;\n\tv196 = v69._activeCellViews;\n\tv362 = v69._activeCellViews == 0;\n\tv147 = ~v362;\n\tif (v147) goto L_0092;\nL_00A2:\n\tthrow System.NullReferenceException;\nL_00A3:\n\tv144 = this.scroller;\n\tv248 = this._selectedIndex >= v144.EndCellViewIndex;\n\tif (v248) goto L_FFFFFFFF;\n\tv202 = this._selectedIndex <= v144.StartCellViewIndex;\n\tif (v202) goto L_FFFFFFFF;\nL_00C8:\n\treturn;\nL_FFFFFFFF:\n\tv262 = 1f;\nL_FFFFFFFF:\n\tv264 = 1f;\n\tgoto L_00DB;\nL_FFFFFFFF:\n\tv262 = 0;\nL_FFFFFFFF:\n\tv264 = 0;\nL_0016:\n\tv44 = UnityEngine.Input::GetKeyDown(0x111);\n\tv45 = ~v44;\n\tif (v45) goto L_0020;\nL_002C:\n\tv179 = this._selectedIndex + v174;\n\tv128 = v142.Count - 1;\n\tv183 = v179 - v128;\n\tv184 = v183 < 0;\n\tv186 = v179 ^ v128;\n\tv187 = v179 ^ v183;\n\tv188 = v186 & v187;\n\tv189 = v188 < 0;\n\tv190 = v184 == v189;\n\tv191 = ~v190;\n\tv192 = ~v191;\n\tif (v192) goto L_0042;\nL_0042:\n\tv306 = v179 < 0;\n\tv309 = v179 ^ v179;\n\tv310 = v179 & v309;\n\tv311 = v310 < 0;\n\tv312 = v306 == v311;\n\tv313 = ~v312;\n\tv53 = ~v313;\n\tif (v53) goto L_FFFFFFFF;\nL_0050:\n\tthis._selectedIndex = v323;\nL_FFFFFFFF:\n\tv164 = 0;\nL_005B:\n\tv63 = v164 >= v142.Count;\n\tif (v63) goto L_0074;\nL_0082:\n\tv196 = v69._activeCellViews;\nL_0092:\n\tv61 = v166 >= v196.Count;\n\tif (v61) goto L_00A3;\nL_00DB:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(v144, this._selectedIndex, v264, v262, 1, 0, 0f, 0, 0, 0);\n\treturn;\n")]
		private void Update()
		{
			SmallList<Data> data;
			int num;
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				data = _data;
				num = -1;
			}
			else
			{
				if (!Input.GetKeyDown(KeyCode.DownArrow))
				{
					return;
				}
				data = _data;
				num = 1;
			}
			int num2 = _selectedIndex + num;
			int num3 = data.Count - 1;
			int num4 = num2 - num3;
			bool flag = num4 < 0;
			int num5 = num2 ^ num3;
			int num6 = num2 ^ num4;
			int num7 = num5 & num6;
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
				num3 = num2;
			}
			bool flag3 = num2 < 0;
			int num8 = num2 ^ num2;
			int num9 = num2 & num8;
			bool flag4 = num9 < 0;
			int selectedIndex = ((flag3 == flag4) ? num3 : 0);
			_selectedIndex = selectedIndex;
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
						float cellOffset;
						float scrollerOffset;
						if (_selectedIndex < enhancedScroller2.EndCellViewIndex)
						{
							if (_selectedIndex > enhancedScroller2.StartCellViewIndex)
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
						enhancedScroller2.JumpToDataIndex(_selectedIndex, scrollerOffset, cellOffset);
						return;
					}
					while (enhancedScroller._activeCellViews != null);
				}
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0x402681C", Offset = "0x402681C", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv140 = System.String::Concat(\"Cell Data Index \", v136);\n\tv131.someText = v140;\n\tv160 = v134 - this._selectedIndex;\n\tv156 = v160 == 0;\n\tv131.isSelected = v156;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControl.Data>::Add(this._data, v131);\n\tv127 = v134 + 1;\n\tv84 = v127 < 0x3E8;\n\tif (v84) goto L_003C;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControl.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControl.Data>::.ctor(v62);\n\tthis._data = v62;\nL_003C:\n\tv131 = new EnhancedScrollerDemos.KeyControl.Data();\n\tSystem.Object::.ctor(v131);\n\tv136 = System.Int32::ToString(&v134 @ stack_-54_v3 (System.Int32));\n")]
		private void LoadData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			int num = default(int);
			int num3;
			do
			{
				Data data2 = new Data();
				string text = num.ToString();
				string someText = "Cell Data Index " + text;
				data2.someText = someText;
				int num2 = num - _selectedIndex;
				bool isSelected = num2 == 0;
				data2.isSelected = isSelected;
				_data.Add(data2);
				num3 = num + 1;
			}
			while (num3 < 1000);
			scroller.ReloadData();
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0x4026B60", Offset = "0x4026B60", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x4026B7C", Offset = "0x4026B7C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = dataIndex & 1;\n\tv3 = v0 == 0;\n\tv9 = ~v3;\n\tif (v9) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 30f;\n\tgoto L_000E;\nL_FFFFFFFF:\n\treturnVal1 = 0x42C80000;\nL_000E:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			if ((dataIndex & 1) == 0)
			{
				return 30f;
			}
			return 100f;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x4026B94", Offset = "0x4026B94", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv124 = v53 == 0;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = 0;\n\tgoto L_004C;\nL_FFFFFFFF:\n\t// -1 IsInst v202_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.KeyControl.CellView), typeof(EnhancedScrollerDemos.KeyControl.CellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv202 = v202_asT == 0;\n\tif (v202) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = v53;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv120 = 0;\n\tUnityEngine.Object::set_name(v120, v102);\n\tv213 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.KeyControl.Data>::get_Item(this._data, v116);\n\t*([v120 @ X20_v3 (UnityEngine.Object)+38]) = v213;\n\tv113 = *([v120 @ X20_v3 (UnityEngine.Object)+38]);\n\tv105 = *([v120 @ X20_v3 (UnityEngine.Object)+48]);\n\tv217 = *([v105 @ X0_v15]);\n\t*([v217 @ X8_v8+5E8])(v219, v105, *([v113 @ X8_v7+18]), *([v217 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv179 = *([v120 @ X20_v3 (UnityEngine.Object)]);\n\t*([v179 @ X8_v9 (Il2CppClass<UnityEngine.Object>)+178])(v221, v120, *([v179 @ X8_v9 (Il2CppClass<UnityEngine.Object>)+180]), *([v217 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v120;\nL_004C:\n\tv207 = System.Int32::ToString(&v116 @ stack_-34_v3 (System.Int32));\n\tv102 = System.String::Concat(\"Cell \", v207);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::GetCellView");
			return default;
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x4026CF4", Offset = "0x4026CF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
