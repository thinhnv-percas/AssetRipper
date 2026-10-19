using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.Pagination
{
	[Token(Token = "0x2000030")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[CompilerGenerated]
		[Token(Token = "0x2000031")]
		private sealed class _003CFakeDelay_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000122")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000123")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000124")]
			[FieldOffset(Offset = "0x20")]
			public Controller _003C_003E4__this;

			[Token(Token = "0x17000022")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000134")]
				[Address(RVA = "0x4027464", Offset = "0x4027464", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000023")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000136")]
				[Address(RVA = "0x40274AC", Offset = "0x40274AC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000131")]
			[Address(RVA = "0x4027354", Offset = "0x4027354", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CFakeDelay_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000132")]
			[Address(RVA = "0x4027388", Offset = "0x4027388", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000133")]
			[Address(RVA = "0x402738C", Offset = "0x402738C", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv53 = this.<>1__state != 1;\n\tif (v53) goto L_0030;\n\tv59 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv68 = v59._data;\n\tEnhancedScrollerDemos.Pagination.Controller::LoadData(v59, v68.Count);\nL_0030:\n\tv73 = this.<>1__state == 0;\n\treturn v73;\nL_003F:\n\tthis.<>1__state = -1;\n\tv58 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v58, 1f);\n\tthis.<>2__current = v58;\n\tthis.<>1__state = 1;\n\tv111 = this.<>1__state == 0;\n\treturn v111;\nL_0015:\n\tv43 = this.<>1__state == 0;\n\tif (v43) goto L_003F;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						Controller controller = _003C_003E4__this;
						_003C_003E1__state = -1;
						SmallList<Data> data = controller._data;
						controller.LoadData(data.Count);
					}
					return _003C_003E1__state == 0;
				}
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000135")]
			[Address(RVA = "0x402746C", Offset = "0x402746C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x30")]
		public CellView cellViewPrefab;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x38")]
		public LoadingCellView loadingCellViewPrefab;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x40")]
		public int cellHeight;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x44")]
		public int pageCount;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x48")]
		private bool _loadingNew;

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x4026D34", Offset = "0x4026D34", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv75 = this.scroller;\n\tv63 = this.scroller == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0040;\n\tgoto L_006F;\nL_0040:\n\tv75.Delegate = this;\n\tv75._reloadData = 1;\n\tv102 = this.scroller;\n\tv94 = new EnhancedUI.EnhancedScroller.ScrollerScrolledDelegate();\n\tEnhancedUI.EnhancedScroller.ScrollerScrolledDelegate::.ctor(v94, this, Il2CppMethodInfo);\n\tv102.scrollerScrolled = v94;\n\tv142 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.Pagination.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.Pagination.Data>::.ctor(v142);\n\tthis._data = v142;\n\tEnhancedScrollerDemos.Pagination.Controller::LoadData(this, 0);\n\treturn;\nL_006F:\n\tthrow System.NullReferenceException;\n")]
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
				SmallList<Data> data = new SmallList<Data>();
				_data = data;
				LoadData(0);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x4026E98", Offset = "0x4026E98", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv63 = this.pageCount + v56.Count;\n\tv76 = v63 <= v87;\n\tif (v76) goto L_0064;\n\tv141 = System.String::Concat(\"Cell Data Index \", v235);\n\tv189.someText = v141;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.Pagination.Data>::Add(this._data, v189);\n\tv180 = v134 + 1;\n\tv167 = v180 < v63;\n\tif (v167) goto L_003D;\nL_0064:\n\tv143 = this.scroller;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this.scroller, v143._scrollPosition);\n\tthis._loadingNew = 0;\n\treturn;\nL_0021:\n\tv56 = this._data;\nL_003D:\n\tv189 = new EnhancedScrollerDemos.Pagination.Data();\n\tSystem.Object::.ctor(v189);\n\tv235 = System.Int32::ToString(&v134 @ stack_-64_v5 (System.Int32));\n")]
		private void LoadData(int pageStartIndex)
		{
			SmallList<Data> data = _data;
			int num = pageCount + data.Count;
			int num2 = default(int);
			if (num > num2)
			{
				int num3 = default(int);
				int num4;
				do
				{
					Data data2 = new Data();
					string text = num3.ToString();
					string someText = "Cell Data Index " + text;
					data2.someText = someText;
					_data.Add(data2);
					num4 = num3 + 1;
				}
				while (num4 < num);
			}
			EnhancedScroller enhancedScroller = scroller;
			scroller.ReloadData();
			scroller.ScrollPosition = enhancedScroller._scrollPosition;
			_loadingNew = false;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x4026FF4", Offset = "0x4026FF4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturnVal1 = v0.Count + 1;\n\treturn returnVal1;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count + 1;
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x4027014", Offset = "0x4027014", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.cellHeight;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			//IL_0007: Expected F4, but got I4
			return cellHeight;
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x4027020", Offset = "0x4027020", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv61 = v46.Count != dataIndex;\n\tif (v61) goto L_006D;\n\tv136 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.loadingCellViewPrefab);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v93_asT @ TEMPCOND_v4 (EnhancedScrollerDemos.Pagination.LoadingCellView), typeof(EnhancedScrollerDemos.Pagination.LoadingCellView), v136 @ X0_v17 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tUnityEngine.Object::set_name(v136, \"Loading...\");\n\treturn v136;\nL_006D:\n\tv169 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv219 = v169 == 0;\n\tif (v219) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv158 = 0;\n\tgoto L_0097;\nL_FFFFFFFF:\n\t// -1 IsInst v267_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.Pagination.CellView), typeof(EnhancedScrollerDemos.Pagination.CellView), v169 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv267 = v267_asT == 0;\n\tif (v267) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv158 = v169;\n\tgoto L_0097;\nL_FFFFFFFF:\n\tv158 = 0;\n\tUnityEngine.Object::set_name(v158, v137);\n\tv139 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.Pagination.Data>::get_Item(this._data, v155);\n\tv140 = *([v158 @ X20_v3 (UnityEngine.Object)+38]);\n\tv200 = *([v140 @ X0_v13]);\n\t*([v200 @ X8_v12+5E8])(v280, v140, v139.someText, *([v200 @ X8_v12+5F0]), cellIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn v158;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0023:\n\tv46 = this._data;\nL_0097:\n\tv273 = System.Int32::ToString(&v155 @ stack_-34_v3 (System.Int32));\n\tv137 = System.String::Concat(\"Cell \", v273);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_011d: Expected O, but got I
			SmallList<Data> data = _data;
			if (data.Count == dataIndex)
			{
				EnhancedScrollerCellView cellView = scroller.GetCellView(loadingCellViewPrefab);
				LoadingCellView loadingCellView = cellView as LoadingCellView;
				cellView.name = "Loading...";
				return cellView;
			}
			EnhancedScrollerCellView cellView2 = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView2 != null) ? ((!(cellView2 is CellView)) ? null : cellView2) : null);
			int i = default(int);
			string text = i.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data2 = _data[i];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X20_v3 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v200 @ X8_v12+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x4027208", Offset = "0x4027208", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = scroller._scrollPosition == 0;\n\tv25 = scroller._scrollPosition < 0;\n\tv26 = ~v25;\n\tv29 = ~v26;\n\tv30 = v29 | v24;\n\tif (v30) goto L_0034;\n\tv47 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(scroller);\n\tv55 = scroller._scrollPosition / v47;\n\tv69 = v55 < 1f;\n\tv83 = v55 == v55;\n\tv52 = 1f == 1f;\n\tv63 = v83 & v52;\n\tv61 = ~v63;\n\tv84 = v69 == v61;\n\tv59 = ~v84;\n\tif (v59) goto L_0034;\n\tv71 = this._loadingNew == 0;\n\tif (v71) goto L_0036;\nL_0034:\n\treturn;\nL_0036:\n\tthis._loadingNew = 1;\n\tgoto L_0044;\n\tv104 = UnityEngine.MonoBehaviour::StartCoroutine(this, v138);\n\treturn;\nL_0044:\n\tv138 = new EnhancedScrollerDemos.Pagination.Controller+<FakeDelay>d__13();\n\tSystem.Object::.ctor(v138);\n\tv138.<>1__state = 0;\n\tv138.<>4__this = this;\n")]
		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
			bool flag = scroller._scrollPosition == 0f;
			bool flag2 = scroller._scrollPosition < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (!(flag4 || flag))
			{
				float scrollSize = scroller.ScrollSize;
				float num = scroller._scrollPosition / scrollSize;
				bool flag5 = num < 1f;
				bool flag6 = num == num;
				bool flag7 = 1f == 1f;
				bool flag8 = flag6 && flag7;
				bool flag9 = !flag8;
				if (flag5 == flag9 && !_loadingNew)
				{
					_loadingNew = true;
					_003CFakeDelay_003Ed__13 _003CFakeDelay_003Ed__14 = (_003CFakeDelay_003Ed__13)FormatterServices.GetUninitializedObject(typeof(_003CFakeDelay_003Ed__13));
					_003CFakeDelay_003Ed__14._003C_003E1__state = 0;
					_003CFakeDelay_003Ed__14._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(_003CFakeDelay_003Ed__14);
				}
			}
		}

		[IteratorStateMachine(typeof(_003CFakeDelay_003Ed__13))]
		[Token(Token = "0x600012F")]
		[Address(RVA = "0x40272DC", Offset = "0x40272DC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new EnhancedScrollerDemos.Pagination.Controller+<FakeDelay>d__13();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator FakeDelay()
		{
			_003CFakeDelay_003Ed__13 _003CFakeDelay_003Ed__14 = (_003CFakeDelay_003Ed__13)FormatterServices.GetUninitializedObject(typeof(_003CFakeDelay_003Ed__13));
			_003CFakeDelay_003Ed__14._003C_003E1__state = 0;
			_003CFakeDelay_003Ed__14._003C_003E4__this = this;
			return _003CFakeDelay_003Ed__14;
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x4027380", Offset = "0x4027380", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
