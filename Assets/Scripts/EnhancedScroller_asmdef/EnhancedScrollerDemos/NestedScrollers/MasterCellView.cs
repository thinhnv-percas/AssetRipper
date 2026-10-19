using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x2000041")]
	public class MasterCellView : EnhancedScrollerCellView, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x31")]
		private bool reloadDataNextFrame;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScroller detailScroller;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x40")]
		private MasterData _data;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x48")]
		public EnhancedScrollerCellView detailCellViewPrefab;

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x4028DB8", Offset = "0x4028DB8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv48.Delegate = this;\n\tv48._reloadData = 1;\n\tv74 = this.detailScroller;\n\tv70 = new EnhancedUI.EnhancedScroller.ScrollerScrolledDelegate();\n\tEnhancedUI.EnhancedScroller.ScrollerScrolledDelegate::.ctor(v70, this, Il2CppMethodInfo);\n\tv74.scrollerScrolled = v70;\n\tthis._data = data;\n\tthis.reloadDataNextFrame = 1;\n\treturn;\nL_001A:\n\tv48 = this.detailScroller;\n")]
		public void SetData(MasterData data)
		{
			EnhancedScroller enhancedScroller = detailScroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			EnhancedScroller enhancedScroller2 = detailScroller;
			ScrollerScrolledDelegate scrollerScrolled = ScrollerScrolled;
			enhancedScroller2.scrollerScrolled = scrollerScrolled;
			_data = data;
			reloadDataNextFrame = true;
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x4028ECC", Offset = "0x4028ECC", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.reloadDataNextFrame != 1;\n\tif (v17) goto L_0020;\n\tthis.reloadDataNextFrame = 0;\n\tv18 = this._data;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.detailScroller, v18.normalizedScrollPosition);\n\treturn;\nL_0020:\n\treturn;\n")]
		private void Update()
		{
			if (reloadDataNextFrame)
			{
				reloadDataNextFrame = false;
				MasterData data = _data;
				detailScroller.ReloadData(data.normalizedScrollPosition);
			}
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x4028F0C", Offset = "0x4028F0C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv40 = v38.childData;\n\treturn v40.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			MasterData data = _data;
			List<DetailData> childData = data.childData;
			return childData.Count;
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x4028F60", Offset = "0x4028F60", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x4028F6C", Offset = "0x4028F6C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.detailCellViewPrefab);\n\tv126 = v53 == 0;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv122 = 0;\n\tgoto L_004C;\nL_FFFFFFFF:\n\t// -1 IsInst v204_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.NestedScrollers.DetailCellView), typeof(EnhancedScrollerDemos.NestedScrollers.DetailCellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv204 = v204_asT == 0;\n\tif (v204) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv122 = v53;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv122 = 0;\n\tUnityEngine.Object::set_name(v122, v102);\n\tv115 = this._data;\n\tv105 = System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.DetailData>::get_Item(v115.childData, v120);\n\tv106 = *([v122 @ X20_v3 (UnityEngine.Object)+38]);\n\tv181 = *([v106 @ X0_v13]);\n\t*([v181 @ X8_v9+5E8])(v212, v106, v105.someText, *([v181 @ X8_v9+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v122;\nL_004C:\n\tv209 = System.Int32::ToString(&v120 @ stack_-34_v3 (System.Int32));\n\tv102 = System.String::Concat(\"Detail Cell \", v209);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_00c4: Expected O, but got I
			EnhancedScrollerCellView cellView = scroller.GetCellView(detailCellViewPrefab);
			Object obj = (((object)cellView != null) ? ((!(cellView is DetailCellView)) ? null : cellView) : null);
			int index = default(int);
			string text = index.ToString();
			string text2 = "Detail Cell " + text;
			obj.name = text2;
			MasterData data = _data;
			DetailData detailData = data.childData[index];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X20_v3 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v181 @ X8_v9+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x40290B0", Offset = "0x40290B0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this._data;\n\tv23 = scroller._scrollPosition == 0;\n\tv24 = scroller._scrollPosition < 0;\n\tv25 = ~v24;\n\tv28 = ~v25;\n\tv29 = v28 | v23;\n\tv45 = 0;\n\tif (v29) goto L_001C;\n\tv64 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(scroller);\n\tv45 = scroller._scrollPosition / v64;\nL_001C:\n\tv18.normalizedScrollPosition = v45;\n\treturn;\n")]
		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
			MasterData data = _data;
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
			data.normalizedScrollPosition = normalizedScrollPosition;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x4029100", Offset = "0x4029100", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MasterCellView()
		{
		}
	}
}
