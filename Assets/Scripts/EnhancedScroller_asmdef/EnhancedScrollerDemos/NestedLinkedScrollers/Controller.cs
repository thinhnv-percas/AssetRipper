using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	[Token(Token = "0x2000034")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x20")]
		private List<MasterData> _data;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller masterScroller;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView masterCellViewPrefab;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x38")]
		public Scrollbar HScrollbar;

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x40274BC", Offset = "0x40274BC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.masterScroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.NestedLinkedScrollers.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = masterScroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x402756C", Offset = "0x402756C", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tgoto L_0060;\nL_0050:\n\tv153 = v212 + 1;\n\tv116 = v153 >= 0x3E8;\n\tif (v116) goto L_00F9;\nL_0060:\n\tv159 = new EnhancedScrollerDemos.NestedLinkedScrollers.MasterData();\n\tSystem.Object::.ctor(v159);\n\tv159.normalizedScrollPosition = 0f;\n\tv175 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.DetailData>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.DetailData>::.ctor(v175);\n\tv159.childData = v175;\n\tv218 = this._data;\n\tgoto L_0097;\nL_0097:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>::Add(v218, v159);\n\tgoto L_00AE;\nL_009F:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.DetailData>::Add(v114, v357);\n\tv353 = v179 + 1;\n\tv327 = v353 >= 0x14;\n\tif (v327) goto L_0050;\nL_00AE:\n\tv114 = v159.childData;\n\tv357 = new EnhancedScrollerDemos.NestedLinkedScrollers.DetailData();\n\tSystem.Object::.ctor(v357);\n\tv361 = System.Int32::ToString(&v212 @ stack_-64_v5 (System.Int32));\n\tv364 = System.Int32::ToString(&v179 @ stack_-68_v6 (System.Int32));\n\tv219 = System.String::Concat(v361, \",\", v364);\n\tv357.someText = v219;\n\tgoto L_009F;\nL_00F9:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.masterScroller, 0f);\n\treturn;\nL_0042:\n\tv71 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>::.ctor(v71);\n\tthis._data = v71;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadData()
		{
			List<MasterData> data = new List<MasterData>();
			_data = data;
			int num = default(int);
			int num2 = default(int);
			int num4;
			do
			{
				MasterData masterData = new MasterData();
				masterData.normalizedScrollPosition = 0f;
				List<DetailData> childData = new List<DetailData>();
				masterData.childData = childData;
				List<MasterData> data2 = _data;
				data2.Add(masterData);
				int num3;
				do
				{
					List<DetailData> childData2 = masterData.childData;
					DetailData detailData = new DetailData();
					string text = num.ToString();
					string text2 = num2.ToString();
					string someText = text + "," + text2;
					detailData.someText = someText;
					childData2.Add(detailData);
					num3 = num2 + 1;
				}
				while (num3 < 20);
				num4 = num + 1;
			}
			while (num4 < 1000);
			masterScroller.ReloadData();
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x402787C", Offset = "0x402787C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<MasterData> data = _data;
			return data.Count;
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x40278C8", Offset = "0x40278C8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x40278D4", Offset = "0x40278D4", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.masterCellViewPrefab);\n\tv116 = v53 == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = 0;\n\tgoto L_0052;\nL_FFFFFFFF:\n\t// -1 IsInst v198_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.NestedLinkedScrollers.MasterCellView), typeof(EnhancedScrollerDemos.NestedLinkedScrollers.MasterCellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv198 = v198_asT == 0;\n\tif (v198) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = v53;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv111 = 0;\n\tUnityEngine.Object::set_name(v111, v100);\n\tv213 = System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>::get_Item(this._data, v109);\n\tEnhancedScrollerDemos.NestedLinkedScrollers.MasterCellView::SetData(v111, v213);\n\tv217 = new EnhancedUI.EnhancedScroller.ScrollerScrolledDelegate();\n\tEnhancedUI.EnhancedScroller.ScrollerScrolledDelegate::.ctor(v217, this, Il2CppMethodInfo);\n\t*([v111 @ X20_v3 (UnityEngine.Object)+50]) = v217;\n\treturn v111;\nL_0052:\n\tv203 = System.Int32::ToString(&v109 @ stack_-34_v3 (System.Int32));\n\tv100 = System.String::Concat(\"Master Cell \", v203);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(masterCellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is MasterCellView)) ? null : cellView) : null);
			int index = default(int);
			string text = index.ToString();
			string text2 = "Master Cell " + text;
			obj.name = text2;
			MasterData data = _data[index];
			((MasterCellView)obj).SetData(data);
			ScrollerScrolledDelegate scrollerScrolledDelegate = DetailScrollerScrolled;
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x4027B1C", Offset = "0x4027B1C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = scroller._scrollPosition == 0;\n\tv22 = scroller._scrollPosition < 0;\n\tv23 = ~v22;\n\tv26 = ~v23;\n\tv27 = v26 | v21;\n\tv48 = 0;\n\tif (v27) goto L_0022;\n\tv44 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(scroller);\n\tv48 = scroller._scrollPosition / v44;\nL_0022:\n\tEnhancedScrollerDemos.NestedLinkedScrollers.Controller::UpdateDetailScrollers(v45, v48);\n\treturn;\n")]
		private void DetailScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
			bool flag = scroller._scrollPosition == 0f;
			bool flag2 = scroller._scrollPosition < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			bool flag5 = flag4 || flag;
			float normalizedScrollPosition = 0f;
			if (!flag5)
			{
				float scrollSize = scroller.ScrollSize;
				normalizedScrollPosition = scroller._scrollPosition / scrollSize;
			}
			UpdateDetailScrollers(normalizedScrollPosition);
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x4027D48", Offset = "0x4027D48", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Scrollbar::get_value(this.HScrollbar);\n\tEnhancedScrollerDemos.NestedLinkedScrollers.Controller::UpdateDetailScrollers(this, v15);\n\treturn;\n")]
		public void HScrollbarOnValueChanged(float value)
		{
			float value2 = HScrollbar.value;
			UpdateDetailScrollers(value2);
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x4027B68", Offset = "0x4027B68", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv57 = UnityEngine.UI.Scrollbar::get_value(this.HScrollbar);\n\tv124 = v57 == normalizedScrollPosition;\n\tif (v124) goto L_0043;\n\tUnityEngine.UI.Scrollbar::set_value(this.HScrollbar, normalizedScrollPosition);\nL_0043:\n\tv270 = System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>::GetEnumerator(this._data);\n\tv96 = v270._list;\n\tv86 = v270.Current;\n\tv277 = v270.Current == 0;\n\tif (v277) goto L_0093;\n\tv86.normalizedScrollPosition = normalizedScrollPosition;\n\tgoto L_004E;\nL_0059:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v96 @ stack_-58_v4 (System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>));\nL_005A:\n\tv159 = this.masterScroller;\n\tgoto L_0068;\n\tv162 = 0;\n\tv144 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v196, v162);\n\tv327 = EnhancedUI.EnhancedScroller.EnhancedScrollerCellView::RefreshCellView(v144);\n\tv162 = v162 + 1;\n\tv196 = v159._activeCellViews;\n\tv328 = v159._activeCellViews == 0;\n\tv147 = ~v328;\n\tif (v147) goto L_0078;\n\tthrow System.NullReferenceException;\nL_0092:\n\treturn;\nL_0093:\n\tv284 = new System.NullReferenceException();\n\tgoto L_00A0;\nL_00A0:\n\tv217 = Il2CppMethodInfo != 1;\n\tv228 = 0;\n\tv259 = v284;\n\tif (v217) goto L_00B0;\n\tv304 = 0x8BF5BC4(v284, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv312 = 0x8BF5BF4(v304, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v96 @ stack_-58_v4 (System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>));\n\tv289 = *([v304 @ X0_v31]) == 0;\n\tif (v289) goto L_005A;\n\tv306 = new System.OutOfMemoryException();\n\tv228 = *([v304 @ X0_v31]);\n\tv259 = v306;\n\treturn;\nL_0020:\n\tv96 = 0;\nL_004E:\n\tv275 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v96 @ stack_-58_v4 (System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedLinkedScrollers.MasterData>));\n\tv281 = v275 == 0;\n\tif (v281) goto L_0059;\nL_0068:\n\tv196 = v159._activeCellViews;\nL_0078:\n\tv59 = v162 >= v196.Count;\n\tif (v59) goto L_0092;\nL_00B0:\n\tv309 = 0x319A8D4(&v228 @ stack_-68_v5 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv314 = 0x8BF0368(v259, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv253 = 0xA1B8(v314, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void UpdateDetailScrollers(float normalizedScrollPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::UpdateDetailScrollers");
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x4027D7C", Offset = "0x4027D7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
