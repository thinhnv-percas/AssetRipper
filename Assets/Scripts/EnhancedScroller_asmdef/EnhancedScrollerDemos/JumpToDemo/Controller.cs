using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.JumpToDemo
{
	[Token(Token = "0x2000071")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x20")]
		private List<Data> _data;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller vScroller;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller hScroller;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x38")]
		public InputField jumpIndexInput;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x40")]
		public Toggle useSpacingToggle;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x48")]
		public Slider scrollerOffsetSlider;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x50")]
		public Slider cellOffsetSlider;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x58")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x60")]
		public EnhancedScroller.TweenType vScrollerTweenType;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x64")]
		public float vScrollerTweenTime;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x68")]
		public EnhancedScroller.TweenType hScrollerTweenType;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x6C")]
		public float hScrollerTweenTime;

		[Token(Token = "0x6000226")]
		[Address(RVA = "0x402F5A0", Offset = "0x402F5A0", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv67 = this.vScroller == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0042;\n\tgoto L_00CC;\nL_0042:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.vScroller, this);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.hScroller, this);\n\tv239 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.JumpToDemo.Data>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.JumpToDemo.Data>::.ctor(v239);\n\tthis._data = v239;\n\tgoto L_0074;\nL_0065:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.JumpToDemo.Data>::Add(v150, v285);\n\tv282 = v141 + 1;\n\tv250 = v282 >= 0x64;\n\tif (v250) goto L_00B9;\nL_0074:\n\tv150 = this._data;\n\tv285 = new EnhancedScrollerDemos.JumpToDemo.Data();\n\tSystem.Object::.ctor(v285);\n\tv289 = System.Int32::ToString(&v141 @ stack_-54_v4 (System.Int32));\n\tv161 = System.String::Concat(\"Cell Data Index \", v289);\n\tv285.cellText = v161;\n\tgoto L_0065;\nL_00B9:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.vScroller, 0f);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.hScroller, 0f);\n\treturn;\nL_00CC:\n\tthrow System.NullReferenceException;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			if ((object)vScroller != null)
			{
				vScroller.Delegate = this;
				hScroller.Delegate = this;
				List<Data> data = new List<Data>();
				_data = data;
				int num = default(int);
				int num2;
				do
				{
					List<Data> data2 = _data;
					Data data3 = new Data();
					string text = num.ToString();
					string cellText = "Cell Data Index " + text;
					data3.cellText = cellText;
					data2.Add(data3);
					num2 = num + 1;
				}
				while (num2 < 100);
				vScroller.ReloadData();
				hScroller.ReloadData();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x402F800", Offset = "0x402F800", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv56 = System.Int32::TryParse(v48.text, &v54 @ stack_-44_v3 (System.Int32));\n\tv119 = ~v56;\n\tif (v119) goto L_0077;\n\tv179 = UnityEngine.UI.Slider::get_value(this.scrollerOffsetSlider);\n\tv97 = UnityEngine.UI.Slider::get_value(this.cellOffsetSlider);\n\tv112 = this.useSpacingToggle;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this.vScroller, v54, v35, v35, v112.isOn, this.vScrollerTweenType, this.vScrollerTweenTime, 0, 0, 0);\n\tv185 = UnityEngine.UI.Slider::get_value(this.scrollerOffsetSlider);\n\tv100 = UnityEngine.UI.Slider::get_value(this.cellOffsetSlider);\n\tv114 = this.useSpacingToggle;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this.hScroller, v54, v35, v35, v114.isOn, this.hScrollerTweenType, this.hScrollerTweenTime, 0, 0, 0);\n\treturn;\nL_0077:\n\tgoto L_007D;\nL_007D:\n\tUnityEngine.Debug::LogWarning(\"The jump value you entered is not a number.\");\n\treturn;\nL_001A:\n\tv48 = this.jumpIndexInput;\n")]
		public void JumpButton_OnClick()
		{
			InputField inputField = jumpIndexInput;
			if (int.TryParse(inputField.text, out var result))
			{
				float value = scrollerOffsetSlider.value;
				float value2 = cellOffsetSlider.value;
				Toggle toggle = useSpacingToggle;
				float num = default(float);
				vScroller.JumpToDataIndex(result, num, num, toggle.isOn, vScrollerTweenType, vScrollerTweenTime);
				float value3 = scrollerOffsetSlider.value;
				float value4 = cellOffsetSlider.value;
				Toggle toggle2 = useSpacingToggle;
				hScroller.JumpToDataIndex(result, num, num, toggle2.isOn, hScrollerTweenType, hScrollerTweenTime);
			}
			else
			{
				Debug.LogWarning("The jump value you entered is not a number.");
			}
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0x402F9B8", Offset = "0x402F9B8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0x402FA04", Offset = "0x402FA04", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0024:\n\tv60 = UnityEngine.Object::op_Equality(scroller, this.vScroller);\n\tv61 = dataIndex & 1;\n\tv63 = v61 == 0;\n\tv69 = ~v63;\n\tif (v69) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 30f;\n\tgoto L_0037;\nL_FFFFFFFF:\n\treturnVal1 = 0x42C80000;\n\tgoto L_004E;\nL_FFFFFFFF:\n\treturnVal1 = 0x43480000;\nL_001F:\n\tgoto L_0024;\nL_0037:\n\tv77 = v60 == 0;\n\tv84 = ~v77;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\nL_004E:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			bool flag = scroller == vScroller;
			float result = (((dataIndex & 1) != 0) ? 100f : 30f);
			if (!flag)
			{
				result = 200f;
			}
			return result;
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0x402FAA8", Offset = "0x402FAA8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv54 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv124 = v54 == 0;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = 0;\n\tgoto L_004D;\nL_FFFFFFFF:\n\t// -1 IsInst v202_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.JumpToDemo.CellView), typeof(EnhancedScrollerDemos.JumpToDemo.CellView), v54 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv202 = v202_asT == 0;\n\tif (v202) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = v54;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv120 = 0;\n\tUnityEngine.Object::set_name(v120, v103);\n\tv105 = System.Collections.Generic.List`1<EnhancedScrollerDemos.JumpToDemo.Data>::get_Item(this._data, v118);\n\tv106 = *([v120 @ X20_v3 (UnityEngine.Object)+38]);\n\tv179 = *([v106 @ X0_v13]);\n\t*([v179 @ X8_v8+5E8])(v211, v106, v105.cellText, *([v179 @ X8_v8+5F0]), cellIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v120;\nL_004D:\n\tv207 = System.Int32::ToString(&v118 @ stack_-34_v3 (System.Int32));\n\tv103 = System.String::Concat(\"Cell \", v207);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_00b7: Expected O, but got I
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			UnityEngine.Object obj = (((object)cellView != null) ? ((!(cellView is CellView)) ? null : cellView) : null);
			int index = default(int);
			string text = index.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data = _data[index];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X20_v3 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ X8_v8+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x402FBE8", Offset = "0x402FBE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
