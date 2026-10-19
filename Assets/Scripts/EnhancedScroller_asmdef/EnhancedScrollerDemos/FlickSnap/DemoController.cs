using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.FlickSnap
{
	[Token(Token = "0x200001F")]
	public class DemoController : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x38")]
		public FlickSnap flickSnap;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x40")]
		public float cellViewSize;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x44")]
		public float CalculateStartCellBias;

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x4023A64", Offset = "0x4023A64", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv67 = this.scroller;\n\tv58 = this.scroller == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002E;\n\tgoto L_0043;\nL_002E:\n\tv67.Delegate = this;\n\tv67._reloadData = 1;\n\tv78 = this.scroller;\n\tv78.CalculateStartCellBias = this.CalculateStartCellBias;\n\tEnhancedScrollerDemos.FlickSnap.DemoController::LoadData(this);\n\treturn;\nL_0043:\n\tthrow System.NullReferenceException;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			if ((object)scroller != null)
			{
				enhancedScroller._delegate = this;
				enhancedScroller._reloadData = true;
				EnhancedScroller enhancedScroller2 = scroller;
				enhancedScroller2.CalculateStartCellBias = CalculateStartCellBias;
				LoadData();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x4023B28", Offset = "0x4023B28", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv135 = System.String::Concat(\"Cell Data Index \", v131);\n\tv126.someText = v135;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.FlickSnap.Data>::Add(this._data, v126);\n\tv122 = v129 + 1;\n\tv84 = v122 < 0x1E;\n\tif (v84) goto L_003C;\n\tv163 = this._data;\n\tv143 = this.flickSnap;\n\tv143.MaxDataElements = v163.Count;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.FlickSnap.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.FlickSnap.Data>::.ctor(v62);\n\tthis._data = v62;\nL_003C:\n\tv126 = new EnhancedScrollerDemos.FlickSnap.Data();\n\tSystem.Object::.ctor(v126);\n\tv131 = System.Int32::ToString(&v129 @ stack_-54_v3 (System.Int32));\n")]
		private void LoadData()
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
			while (num2 < 30);
			SmallList<Data> data3 = _data;
			FlickSnap flickSnap = this.flickSnap;
			flickSnap.MaxDataElements = data3.Count;
			scroller.ReloadData();
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x4023CA4", Offset = "0x4023CA4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x4023CC0", Offset = "0x4023CC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.cellViewSize;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return cellViewSize;
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x4023CC8", Offset = "0x4023CC8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv123 = v53 == 0;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = 0;\n\tgoto L_004C;\nL_FFFFFFFF:\n\t// -1 IsInst v201_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.FlickSnap.CellView), typeof(EnhancedScrollerDemos.FlickSnap.CellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv201 = v201_asT == 0;\n\tif (v201) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = v53;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv119 = 0;\n\tUnityEngine.Object::set_name(v119, v102);\n\tv104 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.FlickSnap.Data>::get_Item(this._data, v117);\n\tv105 = *([v119 @ X20_v3 (UnityEngine.Object)+38]);\n\tv178 = *([v105 @ X0_v13]);\n\t*([v178 @ X8_v8+5E8])(v210, v105, v104.someText, *([v178 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v119;\nL_004C:\n\tv206 = System.Int32::ToString(&v117 @ stack_-34_v3 (System.Int32));\n\tv102 = System.String::Concat(\"Cell \", v206);\n")]
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

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x4023E04", Offset = "0x4023E04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoController()
		{
		}
	}
}
