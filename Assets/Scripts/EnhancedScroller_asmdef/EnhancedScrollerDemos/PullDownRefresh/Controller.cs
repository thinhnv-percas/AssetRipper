using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.PullDownRefresh
{
	[Token(Token = "0x2000049")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x28")]
		private bool _dragging;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x29")]
		private bool _pullToRefresh;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x40")]
		public float pullDownThreshold;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x48")]
		public Text pullDownToRefreshText;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x50")]
		public Text releaseToRefreshText;

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x4029918", Offset = "0x4029918", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv71 = this.scroller;\n\tv59 = this.scroller == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0038;\n\tgoto L_0056;\nL_0038:\n\tv71.Delegate = this;\n\tv71._reloadData = 1;\n\tv97 = this.scroller;\n\tv89 = new EnhancedUI.EnhancedScroller.ScrollerScrolledDelegate();\n\tEnhancedUI.EnhancedScroller.ScrollerScrolledDelegate::.ctor(v89, this, Il2CppMethodInfo);\n\tv97.scrollerScrolled = v89;\n\tEnhancedScrollerDemos.PullDownRefresh.Controller::LoadLargeData(this);\n\treturn;\nL_0056:\n\tthrow System.NullReferenceException;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			if ((object)scroller != null)
			{
				enhancedScroller._delegate = this;
				enhancedScroller._reloadData = true;
				EnhancedScroller enhancedScroller2 = scroller;
				ScrollerScrolledDelegate scrollerScrolled = ScrollerScrolled;
				enhancedScroller2.scrollerScrolled = scrollerScrolled;
				LoadLargeData();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x4029A24", Offset = "0x4029A24", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv135 = System.String::Concat(\"Cell Data Index \", v131);\n\tv126.someText = v135;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.PullDownRefresh.Data>::Add(this._data, v126);\n\tv122 = v129 + 1;\n\tv84 = v122 < 0x64;\n\tif (v84) goto L_003C;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.PullDownRefresh.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.PullDownRefresh.Data>::.ctor(v62);\n\tthis._data = v62;\nL_003C:\n\tv126 = new EnhancedScrollerDemos.PullDownRefresh.Data();\n\tSystem.Object::.ctor(v126);\n\tv131 = System.Int32::ToString(&v129 @ stack_-54_v3 (System.Int32));\n")]
		private void LoadLargeData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			int num = default(int);
			int num2;
			do
			{
				Data data2 = new Data();
				string text = num.ToString();
				string someText = "Cell Data Index " + text;
				data2.someText = someText;
				_data.Add(data2);
				num2 = num + 1;
			}
			while (num2 < 100);
			scroller.ReloadData();
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x4029B90", Offset = "0x4029B90", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x4029BAC", Offset = "0x4029BAC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = dataIndex & 1;\n\tv3 = v0 == 0;\n\tv9 = ~v3;\n\tif (v9) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 30f;\n\tgoto L_000E;\nL_FFFFFFFF:\n\treturnVal1 = 0x42C80000;\nL_000E:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			if ((dataIndex & 1) == 0)
			{
				return 30f;
			}
			return 100f;
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x4029BC4", Offset = "0x4029BC4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv123 = v53 == 0;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = 0;\n\tgoto L_004C;\nL_FFFFFFFF:\n\t// -1 IsInst v201_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.PullDownRefresh.CellView), typeof(EnhancedScrollerDemos.PullDownRefresh.CellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv201 = v201_asT == 0;\n\tif (v201) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = v53;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv119 = 0;\n\tUnityEngine.Object::set_name(v119, v102);\n\tv104 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.PullDownRefresh.Data>::get_Item(this._data, v117);\n\tv105 = *([v119 @ X20_v3 (UnityEngine.Object)+38]);\n\tv178 = *([v105 @ X0_v13]);\n\t*([v178 @ X8_v8+5E8])(v210, v105, v104.someText, *([v178 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v119;\nL_004C:\n\tv206 = System.Int32::ToString(&v117 @ stack_-34_v3 (System.Int32));\n\tv102 = System.String::Concat(\"Cell \", v206);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_00b7: Expected O, but got I
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int i = default(int);
			string text = i.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data = _data[i];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X20_v3 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v178 @ X8_v8+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x4029D00", Offset = "0x4029D00", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = scroller.ScrollRect;\n\tv95 = UnityEngine.RectTransform::get_anchoredPosition(v18.content);\n\tv54 = -this.pullDownThreshold;\n\tv136 = v95.y == v54;\n\tv137 = v95.y < v54;\n\tv138 = ~v137;\n\tv143 = ~v138;\n\tv34 = v143 | v136;\n\tv31 = ~v34;\n\tif (v31) goto L_FFFFFFFF;\n\tv49 = this._dragging == 0;\n\tgoto L_0034;\nL_FFFFFFFF:\n\tv49 = 1;\n\tthis._pullToRefresh = 1;\n\tv66 = UnityEngine.Component::get_gameObject(this.releaseToRefreshText);\n\tUnityEngine.GameObject::SetActive(v66, 1);\nL_0045:\n\tv68 = UnityEngine.Component::get_gameObject(this.pullDownToRefreshText);\n\tv117 = scrollPosition == 0;\n\tv161 = scrollPosition < 0;\n\tv115 = ~v161;\n\tv162 = ~v115;\n\tv108 = v162 | v117;\n\tUnityEngine.GameObject::SetActive(v68, v108);\n\treturn;\nL_0034:\n\tif (v49) goto L_0045;\n")]
		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
			//IL_002f: Expected O, but got F4
			ScrollRect scrollRect = scroller.ScrollRect;
			Vector2 anchoredPosition = scrollRect.content.anchoredPosition;
			object obj = 0f - pullDownThreshold;
			bool flag = anchoredPosition.y == (float)obj;
			bool flag2 = anchoredPosition.y < (float)obj;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if ((flag4 || flag) && _dragging)
			{
				_pullToRefresh = true;
				GameObject gameObject = releaseToRefreshText.gameObject;
				gameObject.SetActive(value: true);
			}
			GameObject gameObject2 = pullDownToRefreshText.gameObject;
			bool flag5 = scrollPosition == 0f;
			bool flag6 = scrollPosition < 0f;
			bool flag7 = !flag6;
			bool flag8 = !flag7;
			bool active = flag8 || flag5;
			gameObject2.SetActive(active);
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x4029DA8", Offset = "0x4029DA8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._dragging = 1;\n\treturn;\n")]
		public void OnBeginDrag(PointerEventData data)
		{
			_dragging = true;
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x4029DB4", Offset = "0x4029DB4", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv209 = System.String::Concat(\"Brand New Data \", v204, \"!!!\");\n\tv153.someText = v209;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.PullDownRefresh.Data>::Insert(this._data, v153, 0);\n\tv114 = v202 + 1;\n\tv77 = v114 < 3;\n\tif (v77) goto L_0039;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\tthis._pullToRefresh = 0;\n\tv110 = UnityEngine.Component::get_gameObject(this.releaseToRefreshText);\n\tUnityEngine.GameObject::SetActive(v110, 0);\nL_007D:\n\treturn;\nL_0021:\n\tthis._dragging = 0;\n\tv61 = this._pullToRefresh != 1;\n\tif (v61) goto L_007D;\nL_0039:\n\tv153 = new EnhancedScrollerDemos.PullDownRefresh.Data();\n\tSystem.Object::.ctor(v153);\n\tv204 = System.Int32::ToString(&v202 @ stack_-54_v4 (System.Int32));\n")]
		public void OnEndDrag(PointerEventData data)
		{
			_dragging = false;
			if (_pullToRefresh)
			{
				int num = default(int);
				int num2;
				do
				{
					Data data2 = new Data();
					string text = num.ToString();
					string someText = "Brand New Data " + text + "!!!";
					data2.someText = someText;
					_data.Insert(data2, 0);
					num2 = num + 1;
				}
				while (num2 < 3);
				scroller.ReloadData();
				_pullToRefresh = false;
				GameObject gameObject = releaseToRefreshText.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x4029F18", Offset = "0x4029F18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
