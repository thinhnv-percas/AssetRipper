using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.SnappingDemo
{
	[Token(Token = "0x2000065")]
	public class SlotController : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<SlotData> _data;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView slotCellViewPrefab;

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x402E1D8", Offset = "0x402E1D8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn;\nL_001C:\n\tv48 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.SnappingDemo.SlotData>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SnappingDemo.SlotData>::.ctor(v48);\n\tthis._data = v48;\n")]
		private void Awake()
		{
			SmallList<SlotData> data = new SmallList<SlotData>();
			_data = data;
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x402E258", Offset = "0x402E258", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.scroller, this);\n\treturn;\n")]
		private void Start()
		{
			scroller.Delegate = this;
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x402E278", Offset = "0x402E278", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SnappingDemo.SlotData>::Clear(this._data);\n\tv154 = sprites.Length < 1;\n\tif (v154) goto L_0071;\n\tv83 = 0;\n\tv126.sprite = sprites[v83 @ X24_v5 (System.Int32)];\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SnappingDemo.SlotData>::Add(this._data, v126);\n\tv83 = v83 + 1;\n\tv201 = v83 < sprites.Length;\n\tif (v201) goto L_0040;\nL_0071:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_0040:\n\tv126 = new EnhancedScrollerDemos.SnappingDemo.SlotData();\n\tSystem.Object::.ctor(v126);\n")]
		public void Reload(Sprite[] sprites)
		{
			_data.Clear();
			if (sprites.Length >= 1)
			{
				int num = 0;
				do
				{
					SlotData slotData = new SlotData();
					slotData.sprite = sprites[num];
					_data.Add(slotData);
					num++;
				}
				while (num < sprites.Length);
			}
			scroller.ReloadData();
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x402E3A0", Offset = "0x402E3A0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_LinearVelocity(this.scroller, amount);\n\treturn;\n")]
		public void AddVelocity(float amount)
		{
			scroller.LinearVelocity = amount;
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x402E3BC", Offset = "0x402E3BC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<SlotData> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0x402E3D8", Offset = "0x402E3D8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x43160000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 150f;
		}

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0x402E3E4", Offset = "0x402E3E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv51 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.slotCellViewPrefab);\n\tv136 = v51 == 0;\n\tif (v136) goto L_0032;\n\tgoto L_FFFFFFFF;\nL_0032:\n\tv185 = this._data;\n\tv149 = this._data == 0;\n\tv124 = ~v149;\nL_FFFFFFFF:\n\tv133 = 0;\n\tif (v124) goto L_0051;\n\tgoto L_0060;\nL_FFFFFFFF:\n\t// -1 IsInst v55_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.SnappingDemo.SlotCellView), typeof(EnhancedScrollerDemos.SnappingDemo.SlotCellView), v51 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv55 = v55_asT == 0;\n\tif (v55) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv134 = v51;\n\tgoto L_004A;\nL_FFFFFFFF:\n\tv134 = 0;\nL_0051:\n\tv121 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SnappingDemo.SlotData>::get_Item(v185, dataIndex);\n\tEnhancedScrollerDemos.SnappingDemo.SlotCellView::SetData(v133, v121);\n\treturn v133;\nL_0060:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_004A:\n\tv185 = this._data;\nL_FFFFFFFF:\n\tv133 = v134;\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(slotCellViewPrefab);
			SmallList<SlotData> data;
			SlotCellView slotCellView;
			if ((object)cellView == null)
			{
				data = _data;
				bool flag = _data == null;
				bool flag2 = !flag;
				slotCellView = null;
				if (!flag2)
				{
					return (EnhancedScrollerCellView)(object)new NullReferenceException();
				}
			}
			else
			{
				EnhancedScrollerCellView enhancedScrollerCellView = ((!(cellView is SlotCellView)) ? null : cellView);
				data = _data;
				slotCellView = (SlotCellView)enhancedScrollerCellView;
			}
			SlotData data2 = data[dataIndex];
			slotCellView.SetData(data2);
			return slotCellView;
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0x402E4CC", Offset = "0x402E4CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SlotController()
		{
		}
	}
}
