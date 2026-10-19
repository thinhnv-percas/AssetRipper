using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.CellEvents
{
	[Token(Token = "0x2000058")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x20")]
		private List<Data> _data;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x38")]
		public float cellSize;

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0x402B7F0", Offset = "0x402B7F0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.CellEvents.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0x402B8A0", Offset = "0x402B8A0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv121 = 0;\n\tgoto L_0044;\nL_0038:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.CellEvents.Data>::AddWithResize(this._data, v140);\n\tv121 = v121 + 1;\n\tv104 = v121 == 0x18;\n\tif (v104) goto L_007F;\nL_0044:\n\tv133 = this._data;\n\tv140 = new EnhancedScrollerDemos.CellEvents.Data();\n\tSystem.Object::.ctor(v140);\n\tv142 = v140 == 0;\n\tif (v142) goto L_0080;\n\tv140.hour = v121;\n\tv143 = this._data == 0;\n\tif (v143) goto L_0080;\n\tv150 = v133._version + 1;\n\tv133._version = v150;\n\tv85 = v133._items;\n\tv131 = v133._items == 0;\n\tif (v131) goto L_0080;\n\tv82 = v133.Count;\n\tv151 = v133.Count < v85.Length;\n\tv152 = ~v151;\n\tif (v152) goto L_0038;\n\tv138 = v133.Count + 1;\n\tv133.Count = v138;\n\tv85[v82 @ X10_v2 (System.Int32)] = v140;\n\tv121 = v121 + 1;\n\tv74 = v121 != 0x18;\n\tif (v74) goto L_0044;\nL_007F:\n\treturn;\nL_0080:\n\tthrow v140;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.CellEvents.Data>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.CellEvents.Data>::.ctor(v56);\n\tthis._data = v56;\n")]
		private void LoadData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::LoadData");
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x402B9FC", Offset = "0x402B9FC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x402BA48", Offset = "0x402BA48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.cellSize;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return cellSize;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x402BA50", Offset = "0x402BA50", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv63 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv169 = v63 == 0;\n\tif (v169) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv164 = 0;\n\tgoto L_005D;\nL_FFFFFFFF:\n\t// -1 IsInst v260_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.CellEvents.CellView), typeof(EnhancedScrollerDemos.CellEvents.CellView), v63 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv260 = v260_asT == 0;\n\tif (v260) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv164 = v63;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv164 = 0;\n\tv275 = v148 == 0;\n\tif (v275) goto L_0082;\n\tv69 = *([v145 @ X23_v4 (Il2CppMethodInfo)+52]) != 1;\n\tif (v69) goto L_0085;\n\tv279 = 0x319A000 + 0xC18;\n\tv265.invoke_impl = v279;\n\tv156 = 0x319A000 + 0xBA4;\n\tv265.extra_arg = v156;\n\tv281 = v164 == 0;\n\tv151 = ~v281;\n\tif (v151) goto L_009F;\n\tgoto L_0110;\nL_0082:\n\tv277 = *([v145 @ X23_v4 (Il2CppMethodInfo)+52]) == 0;\n\tif (v277) goto L_0090;\nL_0085:\n\tv265.invoke_impl = v265.method_ptr;\n\tv157 = 0x319A000 + 0xBA4;\n\tv265.extra_arg = v157;\n\tv265.method_code = v265.Target;\n\tv285 = v164 == 0;\n\tv152 = ~v285;\n\tif (v152) goto L_009F;\n\tgoto L_0110;\nL_0090:\n\tv287 = 0x319A000 + 0xBF8;\n\tv265.invoke_impl = v287;\n\tv158 = 0x319A000 + 0xBA4;\n\tv265.extra_arg = v158;\nL_009F:\n\tv164.cellButtonTextClicked = v265;\n\tv310 = new EnhancedScrollerDemos.CellEvents.CellButtonIntegerClickedDelegate();\n\tv312 = Il2CppMethodInfo;\n\tv310.method_ptr = *([v312 @ X23_v7 (Il2CppMethodInfo)+8]);\n\tv310.method = Il2CppMethodInfo;\n\tv310.Target = this;\n\tv310.method_code = v310;\n\tv319 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = v319 == 0;\n\tif (v320) goto L_00C3;\n\tv330 = *([v312 @ X23_v7 (Il2CppMethodInfo)+52]) != 1;\n\tif (v330) goto L_00C3;\n\tv343 = 0x319A000 + 0xCAC;\n\tv310.invoke_impl = v343;\n\tgoto L_00C7;\nL_00C3:\n\tv310.invoke_impl = v310.method_ptr;\n\tv310.method_code = v310.Target;\n\tv360.method_code = v360;\n\tv366 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv367 = v366 == 0;\n\tif (v367) goto L_00EF;\n\tv377 = *([v146 @ X23_v8 (Il2CppMethodInfo)+52]) != 1;\n\tif (v377) goto L_00EF;\n\tv390 = 0x319A000 + 0xCAC;\n\tv360.invoke_impl = v390;\n\tgoto L_00F2;\nL_00EF:\n\tv360.invoke_impl = v360.method_ptr;\n\tv360.method_code = v360.Target;\n\tv396 = System.Collections.Generic.List`1<EnhancedScrollerDemos.CellEvents.Data>::get_Item(this._data, dataIndex);\n\tEnhancedScrollerDemos.CellEvents.CellView::SetData(v164, v396);\n\treturn v164;\nL_0110:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_005D:\n\tv265 = new EnhancedScrollerDemos.CellEvents.CellButtonTextClickedDelegate();\n\tv145 = Il2CppMethodInfo;\n\tv265.method_ptr = *([v145 @ X23_v4 (Il2CppMethodInfo)+8]);\n\tv265.method = Il2CppMethodInfo;\n\tv265.Target = this;\n\tv265.method_code = v265;\n\tv148 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00C7:\n\tv65 = 0x319A000 + 0xC58;\n\tv310.extra_arg = v65;\n\tv164.cellButtonFixedIntegerClicked = v310;\n\tv360 = new EnhancedScrollerDemos.CellEvents.CellButtonIntegerClickedDelegate();\n\tv146 = Il2CppMethodInfo;\n\tv360.method_ptr = *([v146 @ X23_v8 (Il2CppMethodInfo)+8]);\n\tv360.method = Il2CppMethodInfo;\n\tv360.Target = this;\nL_00F2:\n\tv360.extra_arg = v65;\n\tv164.cellButtonDataIntegerClicked = v360;\n")]
		public unsafe EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::GetCellView");
			return default;
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x402BD48", Offset = "0x402BD48", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78F000;\n\tv20 = *([B78F506]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002B;\n\tv57 = System.String::Concat(\"Cell Text Button Clicked! Value = \", value);\n\tgoto L_0020;\nL_0020:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\nL_002B:\n\t*([v14 @ X20_v1+506]) = 1;\n\tv57 = System.String::Concat(\"Cell Text Button Clicked! Value = \", value);\n\tgoto L_0020;\n")]
		private void CellButtonTextClicked(string value)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192475136;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78F506]");
			string message;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				message = "Cell Text Button Clicked! Value = " + value;
			}
			else
			{
				_ = 1;
				message = "Cell Text Button Clicked! Value = " + value;
			}
			Debug.Log(message);
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0x402BE04", Offset = "0x402BE04", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = value;\n\tgoto L_001D;\nL_001D:\n\tv49 = System.Int32::ToString(&v14 @ stack_-34_v1 (System.Int32));\n\tv63 = System.String::Concat(\"Cell Fixed Integer Button Clicked! Value = \", v49);\n\tgoto L_002C;\nL_002C:\n\tUnityEngine.Debug::Log(v63);\n\treturn;\n")]
		private void CellButtonFixedIntegerClicked(int value)
		{
			int num = value;
			string text = num.ToString();
			string message = "Cell Fixed Integer Button Clicked! Value = " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0x402BEAC", Offset = "0x402BEAC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = value;\n\tgoto L_001D;\nL_001D:\n\tv49 = System.Int32::ToString(&v14 @ stack_-34_v1 (System.Int32));\n\tv63 = System.String::Concat(\"Cell Data Integer Button Clicked! Value = \", v49);\n\tgoto L_002C;\nL_002C:\n\tUnityEngine.Debug::Log(v63);\n\treturn;\n")]
		private void CellButtonDataIntegerClicked(int value)
		{
			int num = value;
			string text = num.ToString();
			string message = "Cell Data Integer Button Clicked! Value = " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0x402BF54", Offset = "0x402BF54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
