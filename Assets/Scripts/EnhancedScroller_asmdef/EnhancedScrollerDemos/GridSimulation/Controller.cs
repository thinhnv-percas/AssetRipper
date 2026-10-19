using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.GridSimulation
{
	[Token(Token = "0x2000052")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x38")]
		public int numberOfCellsPerRow;

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x402B040", Offset = "0x402B040", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.GridSimulation.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x402B0F0", Offset = "0x402B0F0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv117.someText = v122;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSimulation.Data>::Add(this._data, v117);\n\tv113 = v120 + 1;\n\tv75 = v113 < 0x3E8;\n\tif (v75) goto L_0035;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_0028:\n\tv56 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSimulation.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSimulation.Data>::.ctor(v56);\n\tthis._data = v56;\nL_0035:\n\tv117 = new EnhancedScrollerDemos.GridSimulation.Data();\n\tSystem.Object::.ctor(v117);\n\tv122 = System.Int32::ToString(&v120 @ stack_-44_v3 (System.Int32));\n")]
		private void LoadData()
		{
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			int num = default(int);
			int num2;
			do
			{
				Data data2 = new Data();
				string someText = num.ToString();
				data2.someText = someText;
				_data.Add(data2);
				num2 = num + 1;
			}
			while (num2 < 1000);
			scroller.ReloadData();
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x402B230", Offset = "0x402B230", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._data;\n\tgoto L_001E;\nL_0022:\n\tv56 = v14.Count / this.numberOfCellsPerRow;\n\tv57 = UnityEngine.Mathf::Ceil(v56);\n\tv76 = v57 == 0x7F800000;\n\tv61 = ~v76;\n\tif (v61) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0xFFFFFFFF80000000;\n\tgoto L_003D;\nL_FFFFFFFF:\n\treturnVal2 = v56;\nL_001E:\n\tgoto L_0022;\nL_003D:\n\treturn returnVal2;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			//IL_0077: Expected I4, but got F4
			SmallList<Data> data = _data;
			float num = (float)data.Count / (float)numberOfCellsPerRow;
			float num2 = Mathf.Ceil(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x402B2C4", Offset = "0x402B2C4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x402B2D0", Offset = "0x402B2D0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\tv59 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv125 = v59 == 0;\n\tif (v125) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv121 = 0;\n\tgoto L_004F;\nL_FFFFFFFF:\n\t// -1 IsInst v208_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.GridSimulation.CellView), typeof(EnhancedScrollerDemos.GridSimulation.CellView), v59 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv208 = v208_asT == 0;\n\tif (v208) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv121 = v59;\n\tgoto L_004F;\nL_FFFFFFFF:\n\tv121 = 0;\n\tUnityEngine.Object::set_name(v121, v113);\n\tv158 = this.numberOfCellsPerRow * dataIndex;\n\tEnhancedScrollerDemos.GridSimulation.CellView::SetData(v121, &this._data (EnhancedUI.SmallList`1<EnhancedScrollerDemos.GridSimulation.Data>), v158);\n\treturn v121;\nL_004F:\n\tv213 = this.numberOfCellsPerRow * dataIndex;\n\tv214 = v213;\n\tv217 = System.Int32::ToString(&v214 @ stack_-44_v2 (System.Int32));\n\tv219 = this.numberOfCellsPerRow * dataIndex;\n\tv220 = this.numberOfCellsPerRow + v219;\n\tv117 = v220 - 1;\n\tv214 = v117;\n\tv223 = System.Int32::ToString(&v214 @ stack_-44_v2 (System.Int32));\n\tv113 = System.String::Concat(\"Cell \", v217, \" to \", v223);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int num = numberOfCellsPerRow * dataIndex;
			int num2 = num;
			string text = num2.ToString();
			int num3 = numberOfCellsPerRow * dataIndex;
			int num4 = numberOfCellsPerRow + num3;
			int num5 = num4 - 1;
			num2 = num5;
			string text2 = num2.ToString();
			string text3 = "Cell " + text + " to " + text2;
			obj.name = text3;
			int startingIndex = numberOfCellsPerRow * dataIndex;
			((CellView)obj).SetData(ref _data, startingIndex);
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x402B424", Offset = "0x402B424", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.numberOfCellsPerRow = 3;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
			numberOfCellsPerRow = 3;
		}
	}
}
