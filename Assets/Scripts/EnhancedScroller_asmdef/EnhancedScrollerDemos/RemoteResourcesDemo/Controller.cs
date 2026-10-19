using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Token(Token = "0x200006B")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x38")]
		public bool preloadCells;

		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x40")]
		public string[] imageURLList;

		[Token(Token = "0x6000218")]
		[Address(RVA = "0x402EFF0", Offset = "0x402EFF0", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\nL_0040:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv75 = this.scroller;\n\tv77 = new EnhancedUI.EnhancedScroller.CellViewVisibilityChangedDelegate();\n\tEnhancedUI.EnhancedScroller.CellViewVisibilityChangedDelegate::.ctor(v77, this, Il2CppMethodInfo);\n\tv75.cellViewVisibilityChanged = v77;\n\tv223 = this.scroller;\n\tv202 = new EnhancedUI.EnhancedScroller.CellViewWillRecycleDelegate();\n\tEnhancedUI.EnhancedScroller.CellViewWillRecycleDelegate::.ctor(v202, this, Il2CppMethodInfo);\n\tv223.cellViewWillRecycle = v202;\n\tv123 = this.preloadCells != 1;\n\tif (v123) goto L_0082;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_lookAheadBefore(this.scroller, 1000f);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_lookAheadAfter(this.scroller, 1000f);\nL_0082:\n\tv287 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.RemoteResourcesDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RemoteResourcesDemo.Data>::.ctor(v287);\n\tthis._data = v287;\n\tv335 = this.imageURLList;\n\t// 149 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv175 = 0;\n\tv206 = new EnhancedScrollerDemos.RemoteResourcesDemo.Data();\n\tSystem.Object::.ctor(v206);\n\tv232 = this.imageURLList;\n\tv338 = v175 < v232.Length;\n\tv168 = ~v338;\n\tif (v168) goto L_00E7;\n\tv206.imageUrl = v232[v175 @ X23_v7 (System.Int32)];\n\tv206.imageDimensions = v3;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RemoteResourcesDemo.Data>::Add(this._data, v206);\n\tv175 = v175 + 1;\n\tv335 = this.imageURLList;\n\tv341 = this.imageURLList == 0;\n\tv211 = ~v341;\n\tif (v211) goto L_00A0;\n\tthrow System.NullReferenceException;\nL_00D2:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.scroller, this);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_00E7:\n\tthrow v206;\nL_003C:\n\tgoto L_0040;\nL_00A0:\n\tv121 = v175 >= v335.Length;\n\tif (v121) goto L_00D2;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::Start");
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x402F29C", Offset = "0x402F29C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void HandleCellViewWillRecycleDelegate(EnhancedScrollerCellView cellView)
		{
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x402F2A0", Offset = "0x402F2A0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x402F2BC", Offset = "0x402F2BC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x43820000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 260f;
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x402F2C8", Offset = "0x402F2C8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = dataIndex;\n\tgoto L_0020;\nL_0020:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv107 = v53 == 0;\n\tif (v107) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv105 = 0;\n\tgoto L_004A;\nL_FFFFFFFF:\n\t// -1 IsInst v182_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.RemoteResourcesDemo.CellView), typeof(EnhancedScrollerDemos.RemoteResourcesDemo.CellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv182 = v182_asT == 0;\n\tif (v182) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv105 = v53;\n\tgoto L_004A;\nL_FFFFFFFF:\n\tv105 = 0;\n\tUnityEngine.Object::set_name(v105, v98);\n\treturn v105;\nL_004A:\n\tv187 = System.Int32::ToString(&v18 @ stack_-34_v1 (System.Int32));\n\tv98 = System.String::Concat(\"Cell \", v187);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			int num = dataIndex;
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			string text = num.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x402F3BC", Offset = "0x402F3BC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tgoto L_FFFFFFFF;\n\tv75 = cellView.active != 1;\n\tif (v75) goto L_0074;\nL_FFFFFFFF:\n\tv141 = 0;\n\tgoto L_0056;\nL_FFFFFFFF:\n\t// -1 IsInst v69_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.RemoteResourcesDemo.CellView), typeof(EnhancedScrollerDemos.RemoteResourcesDemo.CellView), cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv69 = v69_asT == 0;\n\tif (v69) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv142 = cellView;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv142 = 0;\nL_0056:\n\tv128 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RemoteResourcesDemo.Data>::get_Item(this._data, cellView.dataIndex);\n\tEnhancedScrollerDemos.RemoteResourcesDemo.CellView::SetData(v141, v128);\n\treturn;\nL_0072:\n\tUnityEngine.UI.Image::set_sprite(*([v142 @ X21_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+38]), *([v142 @ X21_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+40]));\n\treturn;\nL_0074:\n\tthrow System.NullReferenceException;\nL_004D:\n\tv193 = cellView.active == 0;\nL_FFFFFFFF:\n\tv141 = v142;\n\tif (v193) goto L_0072;\n")]
		private void CellViewVisibilityChanged(EnhancedScrollerCellView cellView)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::CellViewVisibilityChanged");
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0x402F4B4", Offset = "0x402F4B4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v59_asT @ TEMPCOND_v3 (EnhancedScrollerDemos.RemoteResourcesDemo.CellView), typeof(EnhancedScrollerDemos.RemoteResourcesDemo.CellView), cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv98 = *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+48]) == 0;\n\tif (v98) goto L_0045;\n\tUnityEngine.MonoBehaviour::StopCoroutine(cellView, *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+48]));\n\treturn;\nL_0045:\n\treturn;\n\tthrow System.NullReferenceException;\n")]
		private void CellViewWillRecycle(EnhancedScrollerCellView cellView)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::CellViewWillRecycle");
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x402F548", Offset = "0x402F548", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
