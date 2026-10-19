using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
	[Token(Token = "0x2000083")]
	public class SimpleDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x600025D")]
		[Address(RVA = "0x4032A6C", Offset = "0x4032A6C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.scroller, this);\n\tEnhancedScrollerDemos.SuperSimpleDemo.SimpleDemo::LoadLargeData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			scroller.Delegate = this;
			LoadLargeData();
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0x4032B10", Offset = "0x4032B10", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv135 = System.String::Concat(\"Cell Data Index \", v131);\n\tv126.someText = v135;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::Add(this._data, v126);\n\tv122 = v129 + 1;\n\tv84 = v122 < 0x3E8;\n\tif (v84) goto L_003C;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::.ctor(v62);\n\tthis._data = v62;\nL_003C:\n\tv126 = new EnhancedScrollerDemos.SuperSimpleDemo.Data();\n\tSystem.Object::.ctor(v126);\n\tv131 = System.Int32::ToString(&v129 @ stack_-54_v3 (System.Int32));\n")]
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
			while (num2 < 1000);
			scroller.ReloadData();
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x4032C78", Offset = "0x4032C78", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv73 = new EnhancedScrollerDemos.SuperSimpleDemo.Data();\n\tSystem.Object::.ctor(v73);\n\tv73.someText = \"A\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::Add(this._data, v73);\n\tv104 = new EnhancedScrollerDemos.SuperSimpleDemo.Data();\n\tSystem.Object::.ctor(v104);\n\tv104.someText = \"B\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::Add(this._data, v104);\n\tv106 = new EnhancedScrollerDemos.SuperSimpleDemo.Data();\n\tSystem.Object::.ctor(v106);\n\tv106.someText = \"C\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::Add(this._data, v106);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv54 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::.ctor(v54);\n\tthis._data = v54;\n")]
		private void LoadSmallData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			Data data2 = new Data();
			data2.someText = "A";
			_data.Add(data2);
			Data data3 = new Data();
			data3.someText = "B";
			_data.Add(data3);
			Data data4 = new Data();
			data4.someText = "C";
			_data.Add(data4);
			scroller.ReloadData();
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x4032E40", Offset = "0x4032E40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedScrollerDemos.SuperSimpleDemo.SimpleDemo::LoadLargeData(this);\n\treturn;\n")]
		public void LoadLargeDataButton_OnClick()
		{
			LoadLargeData();
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x4032E44", Offset = "0x4032E44", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedScrollerDemos.SuperSimpleDemo.SimpleDemo::LoadSmallData(this);\n\treturn;\n")]
		public void LoadSmallDataButton_OnClick()
		{
			LoadSmallData();
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x4032E48", Offset = "0x4032E48", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x4032E64", Offset = "0x4032E64", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = dataIndex & 1;\n\tv3 = v0 == 0;\n\tv9 = ~v3;\n\tif (v9) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 30f;\n\tgoto L_000E;\nL_FFFFFFFF:\n\treturnVal1 = 0x42C80000;\nL_000E:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			if ((dataIndex & 1) == 0)
			{
				return 30f;
			}
			return 100f;
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x4032E7C", Offset = "0x4032E7C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv54 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv124 = v54 == 0;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = 0;\n\tgoto L_004D;\nL_FFFFFFFF:\n\t// -1 IsInst v202_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.SuperSimpleDemo.CellView), typeof(EnhancedScrollerDemos.SuperSimpleDemo.CellView), v54 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv202 = v202_asT == 0;\n\tif (v202) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = v54;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv120 = 0;\n\tUnityEngine.Object::set_name(v120, v103);\n\tv105 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SuperSimpleDemo.Data>::get_Item(this._data, v118);\n\tv106 = *([v120 @ X20_v3 (UnityEngine.Object)+38]);\n\tv179 = *([v106 @ X0_v13]);\n\t*([v179 @ X8_v8+5E8])(v211, v106, v105.someText, *([v179 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v120;\nL_004D:\n\tv207 = System.Int32::ToString(&v118 @ stack_-34_v3 (System.Int32));\n\tv103 = System.String::Concat(\"Cell \", v207);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_00b7: Expected O, but got I
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int i = default(int);
			string text = i.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data = _data[i];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X20_v3 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ X8_v8+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x4032FBC", Offset = "0x4032FBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SimpleDemo()
		{
		}
	}
}
