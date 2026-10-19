using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.RefreshDemo
{
	[Token(Token = "0x200005E")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0x402D02C", Offset = "0x402D02C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.scroller, this);\n\tEnhancedScrollerDemos.RefreshDemo.Controller::LoadLargeData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			scroller.Delegate = this;
			LoadLargeData();
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0x402D238", Offset = "0x402D238", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv67 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 0);\n\tv67.someText = \"This cell was updated\";\n\tv90 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 1);\n\tv90.someText = \"---\";\n\tv92 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 2);\n\tv92.someText = \"---\";\n\tv94 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 3);\n\tv94.someText = \"---\";\n\tv96 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 4);\n\tv96.someText = \"---\";\n\tv98 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, 5);\n\tv98.someText = \"This cell was also updated\";\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::RefreshActiveCellViews(this.scroller);\n\treturn;\nL_0086:\n\treturn;\nL_001F:\n\tv45 = UnityEngine.Input::GetKeyDown(0x72);\n\tv49 = ~v45;\n\tif (v49) goto L_0086;\n")]
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Data data = _data[0];
				data.someText = "This cell was updated";
				Data data2 = _data[1];
				data2.someText = "---";
				Data data3 = _data[2];
				data3.someText = "---";
				Data data4 = _data[3];
				data4.someText = "---";
				Data data5 = _data[4];
				data5.someText = "---";
				Data data6 = _data[5];
				data6.someText = "This cell was also updated";
				scroller.RefreshActiveCellViews();
			}
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0x402D0D0", Offset = "0x402D0D0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv135 = System.String::Concat(\"Cell Data Index \", v131);\n\tv126.someText = v135;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::Add(this._data, v126);\n\tv122 = v129 + 1;\n\tv84 = v122 < 0x3E8;\n\tif (v84) goto L_003C;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::.ctor(v62);\n\tthis._data = v62;\nL_003C:\n\tv126 = new EnhancedScrollerDemos.RefreshDemo.Data();\n\tSystem.Object::.ctor(v126);\n\tv131 = System.Int32::ToString(&v129 @ stack_-54_v3 (System.Int32));\n")]
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

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x402D3D0", Offset = "0x402D3D0", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv73 = new EnhancedScrollerDemos.RefreshDemo.Data();\n\tSystem.Object::.ctor(v73);\n\tv73.someText = \"A\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::Add(this._data, v73);\n\tv104 = new EnhancedScrollerDemos.RefreshDemo.Data();\n\tSystem.Object::.ctor(v104);\n\tv104.someText = \"B\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::Add(this._data, v104);\n\tv106 = new EnhancedScrollerDemos.RefreshDemo.Data();\n\tSystem.Object::.ctor(v106);\n\tv106.someText = \"C\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::Add(this._data, v106);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_002F:\n\tv54 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::.ctor(v54);\n\tthis._data = v54;\n")]
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

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0x402D598", Offset = "0x402D598", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedScrollerDemos.RefreshDemo.Controller::LoadLargeData(this);\n\treturn;\n")]
		public void LoadLargeDataButton_OnClick()
		{
			LoadLargeData();
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0x402D59C", Offset = "0x402D59C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedScrollerDemos.RefreshDemo.Controller::LoadSmallData(this);\n\treturn;\n")]
		public void LoadSmallDataButton_OnClick()
		{
			LoadSmallData();
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0x402D5A0", Offset = "0x402D5A0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0x402D5BC", Offset = "0x402D5BC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = dataIndex & 1;\n\tv3 = v0 == 0;\n\tv9 = ~v3;\n\tif (v9) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 30f;\n\tgoto L_000E;\nL_FFFFFFFF:\n\treturnVal1 = 0x42C80000;\nL_000E:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			if ((dataIndex & 1) == 0)
			{
				return 30f;
			}
			return 100f;
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x402D5D4", Offset = "0x402D5D4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv54 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv116 = v54 == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv112 = 0;\n\tgoto L_004D;\nL_FFFFFFFF:\n\t// -1 IsInst v194_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.RefreshDemo.CellView), typeof(EnhancedScrollerDemos.RefreshDemo.CellView), v54 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv194 = v194_asT == 0;\n\tif (v194) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv112 = v54;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv112 = 0;\n\tUnityEngine.Object::set_name(v112, v101);\n\tv205 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.RefreshDemo.Data>::get_Item(this._data, v110);\n\t*([v112 @ X20_v3 (UnityEngine.Object)+38]) = v205;\n\tv171 = *([v112 @ X20_v3 (UnityEngine.Object)]);\n\t*([v171 @ X8_v7 (Il2CppClass<UnityEngine.Object>)+178])(v211, v112, *([v171 @ X8_v7 (Il2CppClass<UnityEngine.Object>)+180]), Il2CppMethodInfo, cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v112;\nL_004D:\n\tv199 = System.Int32::ToString(&v110 @ stack_-34_v3 (System.Int32));\n\tv101 = System.String::Concat(\"Cell \", v199);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::GetCellView");
			return default;
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0x402D710", Offset = "0x402D710", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
