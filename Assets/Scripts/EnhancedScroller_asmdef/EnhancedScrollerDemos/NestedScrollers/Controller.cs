using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x200003E")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x20")]
		private List<MasterData> _data;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller masterScroller;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView masterCellViewPrefab;

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x402887C", Offset = "0x402887C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.masterScroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.NestedScrollers.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = masterScroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x402892C", Offset = "0x402892C", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tgoto L_0060;\nL_0050:\n\tv153 = v212 + 1;\n\tv116 = v153 >= 0x3E8;\n\tif (v116) goto L_00F9;\nL_0060:\n\tv159 = new EnhancedScrollerDemos.NestedScrollers.MasterData();\n\tSystem.Object::.ctor(v159);\n\tv159.normalizedScrollPosition = 0f;\n\tv175 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.DetailData>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.DetailData>::.ctor(v175);\n\tv159.childData = v175;\n\tv218 = this._data;\n\tgoto L_0097;\nL_0097:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.MasterData>::Add(v218, v159);\n\tgoto L_00AE;\nL_009F:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.DetailData>::Add(v114, v357);\n\tv353 = v179 + 1;\n\tv327 = v353 >= 0x14;\n\tif (v327) goto L_0050;\nL_00AE:\n\tv114 = v159.childData;\n\tv357 = new EnhancedScrollerDemos.NestedScrollers.DetailData();\n\tSystem.Object::.ctor(v357);\n\tv361 = System.Int32::ToString(&v212 @ stack_-64_v5 (System.Int32));\n\tv364 = System.Int32::ToString(&v179 @ stack_-68_v6 (System.Int32));\n\tv219 = System.String::Concat(v361, \",\", v364);\n\tv357.someText = v219;\n\tgoto L_009F;\nL_00F9:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.masterScroller, 0f);\n\treturn;\nL_0042:\n\tv71 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.MasterData>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.MasterData>::.ctor(v71);\n\tthis._data = v71;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadData()
		{
			List<MasterData> data = new List<MasterData>();
			_data = data;
			int num = default(int);
			int num2 = default(int);
			int num4;
			do
			{
				MasterData masterData = new MasterData();
				masterData.normalizedScrollPosition = 0f;
				List<DetailData> childData = new List<DetailData>();
				masterData.childData = childData;
				List<MasterData> data2 = _data;
				data2.Add(masterData);
				int num3;
				do
				{
					List<DetailData> childData2 = masterData.childData;
					DetailData detailData = new DetailData();
					string text = num.ToString();
					string text2 = num2.ToString();
					string someText = text + "," + text2;
					detailData.someText = someText;
					childData2.Add(detailData);
					num3 = num2 + 1;
				}
				while (num3 < 20);
				num4 = num + 1;
			}
			while (num4 < 1000);
			masterScroller.ReloadData();
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x4028C3C", Offset = "0x4028C3C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<MasterData> data = _data;
			return data.Count;
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x4028C88", Offset = "0x4028C88", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x42C80000;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 100f;
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x4028C94", Offset = "0x4028C94", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.masterCellViewPrefab);\n\tv115 = v53 == 0;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = 0;\n\tgoto L_004C;\nL_FFFFFFFF:\n\t// -1 IsInst v192_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.NestedScrollers.MasterCellView), typeof(EnhancedScrollerDemos.NestedScrollers.MasterCellView), v53 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv192 = v192_asT == 0;\n\tif (v192) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = v53;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv111 = 0;\n\tUnityEngine.Object::set_name(v111, v100);\n\tv202 = System.Collections.Generic.List`1<EnhancedScrollerDemos.NestedScrollers.MasterData>::get_Item(this._data, v109);\n\tEnhancedScrollerDemos.NestedScrollers.MasterCellView::SetData(v111, v202);\n\treturn v111;\nL_004C:\n\tv197 = System.Int32::ToString(&v109 @ stack_-34_v3 (System.Int32));\n\tv100 = System.String::Concat(\"Master Cell \", v197);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(masterCellViewPrefab);
			Object obj = (((object)cellView != null) ? ((!(cellView is MasterCellView)) ? null : cellView) : null);
			int index = default(int);
			string text = index.ToString();
			string text2 = "Master Cell " + text;
			obj.name = text2;
			MasterData data = _data[index];
			((MasterCellView)obj).SetData(data);
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x4028E8C", Offset = "0x4028E8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
