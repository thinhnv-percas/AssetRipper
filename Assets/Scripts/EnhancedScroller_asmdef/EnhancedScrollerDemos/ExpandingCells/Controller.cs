using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.ExpandingCells
{
	[Token(Token = "0x2000026")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x28")]
		private bool _lastPadderActive;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x2C")]
		private float _lastPadderSize;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x4025204", Offset = "0x4025204", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv67 = this.scroller;\n\tv58 = this.scroller == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002E;\n\tgoto L_0044;\nL_002E:\n\tv67.Delegate = this;\n\tv67._reloadData = 1;\n\tv78 = this.scroller;\n\t// 56 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv78.lookAheadBefore = v35;\n\tEnhancedScrollerDemos.ExpandingCells.Controller::LoadData(this);\n\treturn;\nL_0044:\n\tthrow System.NullReferenceException;\n")]
		private void Start()
		{
			//IL_0087: Expected F4, but got O
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			if ((object)scroller != null)
			{
				enhancedScroller._delegate = this;
				enhancedScroller._reloadData = true;
				EnhancedScroller enhancedScroller2 = scroller;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				object obj = default(object);
				enhancedScroller2._lookAheadBefore = (float)obj;
				LoadData();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x40252CC", Offset = "0x40252CC", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv140 = 0;\n\tgoto L_0063;\nL_0058:\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::Add(this._data, v177);\n\tv122 = v140 == 0x32;\n\tif (v122) goto L_00F7;\nL_0063:\n\tv161 = v140 * 0xFFFFFFFFAAAAAAAB;\n\tv162 = v161 < 0x55555555;\n\tv163 = ~v162;\n\tv164 = v161 - 0x55555555;\n\tv166 = v164 == 0;\n\tv171 = ~v163;\n\tv172 = v171 | v166;\n\tif (v172) goto L_009D;\n\tv140 = v140 + 1;\n\tv177 = new EnhancedScrollerDemos.ExpandingCells.Data();\n\tSystem.Object::.ctor(v177);\n\tv188 = v140 * 0xFFFFFFFFAAAAAAAB;\n\tv189 = v188 < 0x55555555;\n\tv190 = ~v189;\n\tv191 = v188 - 0x55555555;\n\tv193 = v191 == 0;\n\tv198 = ~v190;\n\tv102 = v198 | v193;\n\tif (v102) goto L_00D0;\n\tv177.headerText = \"Single Expand\";\n\tv177.descriptionText = \"Expanding this cell will collapse other cells.\\n\\nClick the cell again to collapse.\";\n\tv177.isExpanded = 0;\n\tv177.collapsedSize = 3.963168385453261E+17d;\n\tv177.tweenTimeCollapse = 0f;\n\tv177.tweenType = 0;\n\tv300 = this._data == 0;\n\tv249 = ~v300;\n\tif (v249) goto L_0058;\n\tgoto L_00E2;\nL_009D:\n\tv179 = new EnhancedScrollerDemos.ExpandingCells.Data();\n\tSystem.Object::.ctor(v179);\n\tv179.headerText = \"Multiple Expand\";\n\tv179.descriptionText = \"Expanding this cell will not collapse other cells. This allows you to have multiple cells expanded at once.\\n\\nClick the cell again to collapse.\";\n\tv179.isExpanded = 0;\n\tv179.collapsedSize = 3.963168385453261E+17d;\n\tv179.tweenTimeCollapse = 0f;\n\tv179.tweenType = 0;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::Add(this._data, v179);\n\tv140 = v140 + 1;\n\tv104 = v140 != 0x32;\n\tif (v104) goto L_0063;\n\tgoto L_00F7;\nL_00D0:\n\tv177.headerText = \"Tween Expand\";\n\tv177.descriptionText = \"This cell will animate its size when clicked.\\n\\nClick the cell again to collapse.\";\n\tv177.isExpanded = 0;\n\tv177.collapsedSize = 3.963168385453261E+17d;\n\tv177.tweenType = 0x11;\n\tv177.tweenTimeExpand = 0x3F;\n\tv301 = this._data == 0;\n\tv248 = ~v301;\n\tif (v248) goto L_0058;\nL_00E2:\n\tthrow System.NullReferenceException;\nL_00F7:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_0042:\n\tv70 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::.ctor(v70);\n\tthis._data = v70;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			int num = 0;
			do
			{
				IL_0040:
				int num2 = num * -1431655765;
				bool flag = (uint)num2 < 1431655765u;
				bool flag2 = !flag;
				int num3 = num2 - 1431655765;
				bool flag3 = num3 == 0;
				bool flag4 = !flag2;
				Data data2;
				if (!(flag4 || flag3))
				{
					num++;
					data2 = new Data();
					int num4 = num * -1431655765;
					bool flag5 = (uint)num4 < 1431655765u;
					bool flag6 = !flag5;
					int num5 = num4 - 1431655765;
					bool flag7 = num5 == 0;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						data2.headerText = "Single Expand";
						data2.descriptionText = "Expanding this cell will collapse other cells.\n\nClick the cell again to collapse.";
						data2.isExpanded = false;
						data2.collapsedSize = 60f;
						data2.expandedSize = 300f;
						data2.tweenTimeCollapse = 0f;
						data2.tweenType = default(Tween.TweenType);
						if (_data != null)
						{
							goto IL_0013;
						}
					}
					else
					{
						data2.headerText = "Tween Expand";
						data2.descriptionText = "This cell will animate its size when clicked.\n\nClick the cell again to collapse.";
						data2.isExpanded = false;
						data2.collapsedSize = 60f;
						data2.expandedSize = 300f;
						data2.tweenType = Tween.TweenType.easeInOutSine;
						data2.tweenTimeExpand = 8.8E-44f;
						if (_data != null)
						{
							goto IL_0013;
						}
					}
					throw new NullReferenceException();
				}
				Data data3 = new Data();
				data3.headerText = "Multiple Expand";
				data3.descriptionText = "Expanding this cell will not collapse other cells. This allows you to have multiple cells expanded at once.\n\nClick the cell again to collapse.";
				data3.isExpanded = false;
				data3.collapsedSize = 60f;
				data3.expandedSize = 300f;
				data3.tweenTimeCollapse = 0f;
				data3.tweenType = default(Tween.TweenType);
				_data.Add(data3);
				num++;
				if (num == 50)
				{
					break;
				}
				goto IL_0040;
				IL_0013:
				_data.Add(data2);
			}
			while (num != 50);
			scroller.ReloadData();
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x402559C", Offset = "0x402559C", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\t;\n\tv65 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv241 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv303 = v241.isExpanded ^ 1;\n\tv65.isExpanded = v303;\n\tv245 = this._data;\n\tv360 = dataIndex + 2;\n\tv363 = v360 * 0xFFFFFFFFAAAAAAAB;\n\tv364 = 0x2AAAAAAA + v363;\n\tv365 = v364 < 0x55555555;\n\tv366 = ~v365;\n\tv374 = ~v366;\n\tif (v374) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv321 = 0;\n\tgoto L_005C;\nL_004F:\n\tv321 = v321 + 1;\nL_005C:\n\tv331 = v321 >= v245.Count;\nL_FFFFFFFF:\n\tv325 = cellViewIndex;\n\tif (v331) goto L_00A8;\n\tv405 = dataIndex == v321;\n\tif (v405) goto L_004F;\n\tv411 = v321 + 2;\n\tv412 = v411 * 0xFFFFFFFFAAAAAAAB;\n\tv305 = 0x2AAAAAAA + v412;\n\tv413 = v305 < 0x55555554;\n\tv177 = ~v413;\n\tv168 = v305 - 0x55555554;\n\tv150 = v168 == 0;\n\tv414 = ~v150;\n\tv105 = v177 & v414;\n\tif (v105) goto L_004F;\n\tv244 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(v245, v321);\n\tv244.isExpanded = 0;\n\tv245 = this._data;\n\tgoto L_004F;\nL_FFFFFFFF:\n\tv318 = 0;\n\tgoto L_0090;\nL_0081:\n\tv239.isExpanded = 0;\n\tv245 = this._data;\nL_0090:\n\tv102 = v318 >= v245.Count;\nL_FFFFFFFF:\n\tv325 = cellViewIndex;\n\tif (v102) goto L_00A8;\n\tv147 = dataIndex == v318;\n\tif (v147) goto L_0083;\n\tv239 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(v245, v318);\n\tv419 = v239 == 0;\n\tv267 = ~v419;\nL_FFFFFFFF:\n\tv325 = cellViewIndex;\n\tif (v267) goto L_0081;\n\tthrow System.NullReferenceException;\nL_00A8:\n\tv93 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this.scroller, v325, 0);\n\tv247 = this.scroller;\n\tv247._ignoreLoopJump = 1;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(v247, 0f);\n\tv95 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this.scroller, v325, 0);\n\tv80 = v93 - v247._scrollPosition;\n\tv96 = v95 - v80;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this.scroller, v96);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this.scroller);\n\tv308 = this.scroller;\n\tv308._ignoreLoopJump = 0;\n\tv251 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv421 = v251.tweenType == 0;\n\tif (v421) goto L_0120;\n\tv309 = this.scroller;\n\tv253 = UnityEngine.EventSystems.UIBehaviour::IsActive(v309.LastPadder);\n\tthis._lastPadderActive = v253;\n\tv310 = this.scroller;\n\tv479 = UnityEngine.UI.LayoutElement::get_minHeight(v310.LastPadder);\n\tthis._lastPadderSize = v96;\n\tv256 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv312 = this.scroller;\n\tv107 = v256.isExpanded != 1;\n\tif (v107) goto L_0123;\n\tv329 = v312.LastPadder;\n\tv482 = UnityEngine.UI.LayoutElement::get_minHeight(v312.LastPadder);\n\tv258 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv487 = v258.expandedSize - v258.collapsedSize;\n\tv97 = v96 + v487;\n\tgoto L_013C;\nL_0120:\n\treturn;\nL_0123:\n\tv329 = v312.LastPadder;\n\tv484 = UnityEngine.UI.LayoutElement::get_minHeight(v312.LastPadder);\n\tv260 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv491 = v260.expandedSize - v260.collapsedSize;\n\tv97 = v96 - v491;\n\tv262 = UnityEngine.Component::get_gameObject(v315.LastPadder);\n\tUnityEngine.GameObject::SetActive(v262, 1);\n\tv264 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellViewAtDataIndex(this.scroller, dataIndex);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v109_asT @ TEMPCOND_v4 (EnhancedScrollerDemos.ExpandingCells.CellView), typeof(EnhancedScrollerDemos.ExpandingCells.CellView), v264 @ X0_v23 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tEnhancedScrollerDemos.ExpandingCells.CellView::BeginTween(v264);\n\treturn;\nL_0083:\n\tv318 = v318 + 1;\nL_013C:\n\tv265 = UnityEngine.UI.LayoutElement::set_minHeight(v329, v97);\n\tv315 = this.scroller;\n")]
		private void InitializeTween(int dataIndex, int cellViewIndex)
		{
			Data data = _data[dataIndex];
			Data data2 = _data[dataIndex];
			int isExpanded = (data2.isExpanded ? 1 : 0) ^ 1;
			data.isExpanded = (byte)isExpanded != 0;
			SmallList<Data> data3 = _data;
			int num = dataIndex + 2;
			int num2 = num * -1431655765;
			int num3 = 715827882 + num2;
			int cellViewIndex2;
			if ((uint)num3 >= 1431655765u)
			{
				int num4 = 0;
				while (true)
				{
					bool flag = num4 >= data3.Count;
					cellViewIndex2 = cellViewIndex;
					if (flag)
					{
						break;
					}
					if (dataIndex != num4)
					{
						int num5 = num4 + 2;
						int num6 = num5 * -1431655765;
						int num7 = 715827882 + num6;
						bool flag2 = (uint)num7 < 1431655764u;
						bool flag3 = !flag2;
						int num8 = num7 - 1431655764;
						bool flag4 = num8 == 0;
						bool flag5 = !flag4;
						if (!(flag3 && flag5))
						{
							Data data4 = data3[num4];
							data4.isExpanded = false;
							data3 = _data;
						}
					}
					num4++;
				}
			}
			else
			{
				int num9 = 0;
				while (true)
				{
					bool flag6 = num9 >= data3.Count;
					cellViewIndex2 = cellViewIndex;
					if (flag6)
					{
						break;
					}
					if (dataIndex != num9)
					{
						Data data5 = data3[num9];
						bool flag7 = data5 == null;
						bool flag8 = !flag7;
						cellViewIndex2 = cellViewIndex;
						if (!flag8)
						{
							throw new NullReferenceException();
						}
						data5.isExpanded = false;
						data3 = _data;
					}
					num9++;
				}
			}
			float scrollPositionForCellViewIndex = scroller.GetScrollPositionForCellViewIndex(cellViewIndex2, default(EnhancedScroller.CellViewPositionEnum));
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._ignoreLoopJump = true;
			enhancedScroller.ReloadData();
			float scrollPositionForCellViewIndex2 = scroller.GetScrollPositionForCellViewIndex(cellViewIndex2, default(EnhancedScroller.CellViewPositionEnum));
			float num10 = scrollPositionForCellViewIndex - enhancedScroller._scrollPosition;
			float num11 = scrollPositionForCellViewIndex2 - num10;
			scroller.ScrollPosition = num11;
			scroller._RefreshActive();
			EnhancedScroller enhancedScroller2 = scroller;
			enhancedScroller2._ignoreLoopJump = false;
			Data data6 = _data[dataIndex];
			if (data6.tweenType != Tween.TweenType.immediate)
			{
				EnhancedScroller enhancedScroller3 = scroller;
				bool lastPadderActive = enhancedScroller3.LastPadder.IsActive();
				_lastPadderActive = lastPadderActive;
				EnhancedScroller enhancedScroller4 = scroller;
				float minHeight = enhancedScroller4.LastPadder.minHeight;
				_lastPadderSize = num11;
				Data data7 = _data[dataIndex];
				EnhancedScroller enhancedScroller5 = scroller;
				LayoutElement lastPadder;
				float minHeight3;
				if (data7.isExpanded)
				{
					lastPadder = enhancedScroller5.LastPadder;
					float minHeight2 = enhancedScroller5.LastPadder.minHeight;
					Data data8 = _data[dataIndex];
					float num12 = data8.expandedSize - data8.collapsedSize;
					minHeight3 = num11 + num12;
				}
				else
				{
					lastPadder = enhancedScroller5.LastPadder;
					float minHeight4 = enhancedScroller5.LastPadder.minHeight;
					Data data9 = _data[dataIndex];
					float num13 = data9.expandedSize - data9.collapsedSize;
					minHeight3 = num11 - num13;
				}
				lastPadder.minHeight = minHeight3;
				EnhancedScroller enhancedScroller6 = scroller;
				GameObject gameObject = enhancedScroller6.LastPadder.gameObject;
				gameObject.SetActive(value: true);
				EnhancedScrollerCellView cellViewAtDataIndex = scroller.GetCellViewAtDataIndex(dataIndex);
				CellView cellView = cellViewAtDataIndex as CellView;
				((CellView)cellViewAtDataIndex).BeginTween();
			}
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x4025958", Offset = "0x4025958", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.scroller;\n\tv42 = UnityEngine.UI.LayoutElement::get_minHeight(v14.LastPadder);\n\tv43 = newValue - delta;\n\tv47 = UnityEngine.UI.LayoutElement::set_minHeight(v47, v43);\n\treturn;\n")]
		private void TweenUpdated(int dataIndex, int cellViewIndex, float newValue, float delta)
		{
			EnhancedScroller enhancedScroller = scroller;
			float minHeight = enhancedScroller.LastPadder.minHeight;
			float minHeight2 = newValue - delta;
			LayoutElement layoutElement = default(LayoutElement);
			layoutElement.minHeight = minHeight2;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x40259B8", Offset = "0x40259B8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.scroller;\n\tv24 = UnityEngine.Component::get_gameObject(v10.LastPadder);\n\tUnityEngine.GameObject::SetActive(v24, this._lastPadderActive);\n\tv25 = UnityEngine.UI.LayoutElement::set_minHeight(v25, this._lastPadderSize);\n\treturn;\n")]
		private void TweenEnd(int dataIndex, int cellViewIndex)
		{
			EnhancedScroller enhancedScroller = scroller;
			GameObject gameObject = enhancedScroller.LastPadder.gameObject;
			gameObject.SetActive(_lastPadderActive);
			LayoutElement layoutElement = default(LayoutElement);
			layoutElement.minHeight = _lastPadderSize;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x4025A20", Offset = "0x4025A20", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x4025A3C", Offset = "0x4025A3C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, dataIndex);\n\tv62 = v49.isExpanded == 0;\n\tv69 = ~v62;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv104 = 0x2C;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv104 = 0x28;\nL_003A:\n\treturn *([v49 @ X0_v5 (EnhancedScrollerDemos.ExpandingCells.Data)+v104 @ X8_v8 (System.Int32)]);\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			//IL_007e: Expected F4, but got I
			Data data = _data[dataIndex];
			if (data.isExpanded)
			{
				int num = 44;
			}
			else
			{
				int num = 40;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v5 (EnhancedScrollerDemos.ExpandingCells.Data)+v104 @ X8_v8 (System.Int32)]");
			return 0f;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x4025ADC", Offset = "0x4025ADC", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\nL_0037:\n\tv65 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv147 = v65 == 0;\n\tif (v147) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv142 = 0;\n\tgoto L_0061;\nL_FFFFFFFF:\n\t// -1 IsInst v247_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.ExpandingCells.CellView), typeof(EnhancedScrollerDemos.ExpandingCells.CellView), v65 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv247 = v247_asT == 0;\n\tif (v247) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv142 = v65;\n\tgoto L_0061;\nL_FFFFFFFF:\n\tv142 = 0;\n\tUnityEngine.Object::set_name(v142, v122);\n\tv264 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, v140);\n\tv125 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, v140);\n\tv127 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.ExpandingCells.Data>::get_Item(this._data, v140);\n\tv276 = new System.Action`2<System.Int32, System.Int32>();\n\tSystem.Action`2<System.Int32, System.Int32>::.ctor(v276, this, Il2CppMethodInfo);\n\tv282 = new System.Action`4<System.Int32, System.Int32, System.Single, System.Single>();\n\tSystem.Action`4<System.Int32, System.Int32, System.Single, System.Single>::.ctor(v282, this, Il2CppMethodInfo);\n\tv288 = new System.Action`2<System.Int32, System.Int32>();\n\tSystem.Action`2<System.Int32, System.Int32>::.ctor(v288, this, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.ExpandingCells.CellView::SetData(v142, v264, v140, v45, v46, v276, v282, v288);\n\treturn v142;\nL_0061:\n\tv252 = System.Int32::ToString(&v140 @ stack_-64_v3 (System.Int32));\n\tv122 = System.String::Concat(\"Cell \", v252);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int num = default(int);
			string text = num.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data = _data[num];
			Data data2 = _data[num];
			Data data3 = _data[num];
			Action<int, int> initializeTween = InitializeTween;
			Action<int, int, float, float> updateTween = TweenUpdated;
			Action<int, int> endTween = TweenEnd;
			float collapsedSize = default(float);
			float expandedSize = default(float);
			((CellView)obj).SetData(data, num, collapsedSize, expandedSize, initializeTween, updateTween, endTween);
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x4025D18", Offset = "0x4025D18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
