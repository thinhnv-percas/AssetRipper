using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SelectionDemo
{
	[Token(Token = "0x2000074")]
	public class InventoryCellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x38")]
		private InventoryData _data;

		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x40")]
		public Image selectionPanel;

		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x48")]
		public Text itemNameText;

		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x50")]
		public Text itemCostText;

		[Token(Token = "0x40001D7")]
		[FieldOffset(Offset = "0x58")]
		public Text itemDamageText;

		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x60")]
		public Text itemDefenseText;

		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x68")]
		public Text itemWeightText;

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x70")]
		public Text itemDescriptionText;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x78")]
		public Image image;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x80")]
		public Color selectedColor;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x90")]
		public Color unSelectedColor;

		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0xA8")]
		public SelectedDelegate selected;

		[Token(Token = "0x17000031")]
		[field: Token(Token = "0x40001DE")]
		[field: FieldOffset(Offset = "0xA0")]
		public int DataIndex
		{
			[Token(Token = "0x6000231")]
			[Address(RVA = "0x402FD84", Offset = "0x402FD84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.DataIndex;\n")]
			get;
			[Token(Token = "0x6000232")]
			[Address(RVA = "0x402FD8C", Offset = "0x402FD8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.DataIndex = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0x402FD94", Offset = "0x402FD94", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv58 = new EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate();\n\tv97 = Il2CppMethodInfo;\n\tv58.method_ptr = *([v97 @ X23_v5 (Il2CppMethodInfo)+8]);\n\tv58.method = Il2CppMethodInfo;\n\tv58.Target = this;\n\tv58.method_code = v58;\n\tv164 = 0x21C1144(Il2CppMethodInfo, this, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv165 = v164 == 0;\n\tif (v165) goto L_0043;\n\tv175 = *([v97 @ X23_v5 (Il2CppMethodInfo)+52]) != 1;\n\tif (v175) goto L_0043;\n\tv188 = 0x319A000 + 0xF7C;\n\tv58.invoke_impl = v188;\n\tgoto L_0047;\nL_0043:\n\tv58.invoke_impl = v58.method_ptr;\n\tv58.method_code = v58.Target;\n\tv65 = *([v203 @ X0_v10 (System.Delegate)]) != EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate;\n\tif (v65) goto L_006A;\n\tv47.selectedChanged = v203;\n\tv219 = *([v203 @ X0_v10 (System.Delegate)]) == EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate;\n\tif (v219) goto L_0082;\nL_006A:\n\tthrow System.InvalidCastException;\nL_0074:\n\treturn;\nL_0075:\n\tv47.selectedChanged = 0;\nL_0019:\n\tv47 = this._data;\n\tv48 = this._data == 0;\n\tif (v48) goto L_0074;\nL_0047:\n\tv200 = 0x319A000 + 0xF28;\n\tv58.extra_arg = v200;\n\tv203 = System.Delegate::Remove(v47.selectedChanged, v58);\n\tv102 = v203 == 0;\n\tif (v102) goto L_0075;\nL_0082:\n\treturn;\n")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InventoryCellView::OnDestroy");
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0x402FF7C", Offset = "0x402FF7C", Length = "0x6C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv72 = new EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate();\n\tv129 = Il2CppMethodInfo;\n\tv72.method_ptr = *([v129 @ X27_v6 (Il2CppMethodInfo)+8]);\n\tv72.method = Il2CppMethodInfo;\n\tv72.Target = this;\n\tv72.method_code = v72;\n\tv140 = 0x21C1144(Il2CppMethodInfo, this, data, isVertical, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv354 = v140 == 0;\n\tif (v354) goto L_005D;\n\tv448 = *([v129 @ X27_v6 (Il2CppMethodInfo)+52]) != 1;\n\tif (v448) goto L_005D;\n\tv469 = 0x319A000 + 0xF7C;\n\tv72.invoke_impl = v469;\n\tgoto L_0061;\nL_005D:\n\tv72.invoke_impl = v72.method_ptr;\n\tv72.method_code = v72.Target;\n\tv371 = *([v424 @ X0_v121 (System.Delegate)]) != EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate;\n\tif (v371) goto L_029F;\n\tv62.selectedChanged = v424;\n\tv396 = *([v424 @ X0_v121 (System.Delegate)]) == EnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate;\n\tif (v396) goto L_008A;\n\tgoto L_029F;\nL_0086:\n\tv62.selectedChanged = 0;\nL_008A:\n\tthis.DataIndex = dataIndex;\n\tthis._data = data;\n\tv360 = UnityEngine.UI.Text::set_text(this.itemNameText, data.itemName);\n\tgoto L_00A2;\nL_00A2:\n\tv462 = UnityEngine.Object::op_Inequality(this.itemCostText, 0);\n\tv484 = ~v462;\n\tv485 = ~v484;\n\tif (v485) goto L_00DF;\nL_FFFFFFFF:\n\tv598 = this.itemDamageText;\n\tgoto L_00AD;\nL_00AD:\n\tv607 = UnityEngine.Object::op_Inequality(v598, 0);\n\tv632 = ~v607;\n\tv633 = ~v632;\n\tif (v633) goto L_0110;\nL_FFFFFFFF:\n\tv701 = this.itemDefenseText;\n\tgoto L_00B8;\nL_00B8:\n\tv710 = UnityEngine.Object::op_Inequality(v701, 0);\n\tv732 = ~v710;\n\tv733 = ~v732;\n\tif (v733) goto L_0141;\nL_FFFFFFFF:\n\tv801 = this.itemWeightText;\n\tgoto L_00C3;\nL_00C3:\n\tv810 = UnityEngine.Object::op_Inequality(v801, 0);\n\tv832 = ~v810;\n\tv833 = ~v832;\n\tif (v833) goto L_0172;\n\tv864 = ~isVertical;\n\tif (v864) goto L_0196;\nL_00D0:\n\tv915 = UnityEngine.UI.Text::set_text(this.itemDescriptionText, data.itemDescription);\n\tv330 = 0xB307000 + 0x210;\n\tgoto L_019D;\nL_00DF:\n\tv291 = data + 0x18;\n\tv166 = v291.m_value <= 0;\n\tif (v166) goto L_FFFFFFFF;\n\tv290 = System.Int32::ToString(&data.itemCost (System.Int32));\n\tv638 = this.itemCostText == 0;\n\tv306 = ~v638;\nL_FFFFFFFF:\n\tv597 = v290;\n\tif (v306) goto L_00FE;\n\tgoto L_029D;\nL_FFFFFFFF:\n\tv597 = \"-\";\nL_00FE:\n\tv645 = UnityEngine.UI.Text::set_text(this.itemCostText, v597);\nL_FFFFFFFF:\n\tv598 = this.itemDamageText;\n\tgoto L_00AD;\nL_0110:\n\tv293 = data + 0x1C;\n\tv167 = v293.m_value <= 0;\n\tif (v167) goto L_FFFFFFFF;\n\tv292 = System.Int32::ToString(&data.itemDamage (System.Int32));\n\tv738 = this.itemDamageText == 0;\n\tv308 = ~v738;\nL_FFFFFFFF:\n\tv700 = v292;\n\tif (v308) goto L_012F;\n\tgoto L_029D;\nL_FFFFFFFF:\n\tv700 = \"-\";\nL_012F:\n\tv745 = UnityEngine.UI.Text::set_text(this.itemDamageText, v700);\nL_FFFFFFFF:\n\tv701 = this.itemDefenseText;\n\tgoto L_00B8;\nL_0141:\n\tv295 = data + 0x20;\n\tv168 = v295.m_value <= 0;\n\tif (v168) goto L_FFFFFFFF;\n\tv294 = System.Int32::ToString(&data.itemDefense (System.Int32));\n\tv838 = this.itemDefenseText == 0;\n\tv310 = ~v838;\nL_FFFFFFFF:\n\tv800 = v294;\n\tif (v310) goto L_0160;\n\tgoto L_029D;\nL_FFFFFFFF:\n\tv800 = \"-\";\nL_0160:\n\tv845 = UnityEngine.UI.Text::set_text(this.itemDefenseText, v800);\nL_FFFFFFFF:\n\tv801 = this.itemWeightText;\n\tgoto L_00C3;\nL_0172:\n\tv297 = data + 0x24;\n\tv169 = v297.m_value <= 0;\n\tif (v169) goto L_FFFFFFFF;\n\tv296 = System.Int32::ToString(&data.itemWeight (System.Int32));\n\tv927 = this.itemWeightText == 0;\n\tv312 = ~v927;\nL_FFFFFFFF:\n\tv885 = v296;\n\tif (v312) goto L_0191;\n\tgoto L_029D;\nL_FFFFFFFF:\n\tv885 = \"-\";\nL_0191:\n\tv887 = UnityEngine.UI.Text::set_text(this.itemWeightText, v885);\n\tv932 = ~isVertical;\n\tv889 = ~v932;\n\tif (v889) goto L_00D0;\nL_0196:\n\tv330 = 0xB307000 + 0x158;\n\tUnityEngine.UI.Image::set_sprite(this.image, v298);\n\tv348 = this._data;\n\tv934 = new *([v109 @ X27_v4 (System.Int32)])();\n\tv282 = Il2CppMethodInfo;\n\tv934.method_ptr = *([v282 @ X25_v4 (Il2CppMethodInfo)+8]);\n\tv934.method = Il2CppMethodInfo;\n\tv934.Target = this;\n\tv934.method_code = v934;\n\tv942 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv943 = v942 == 0;\n\tif (v943) goto L_01CE;\n\tv953 = *([v282 @ X25_v4 (Il2CppMethodInfo)+52]) != 1;\n\tif (v953) goto L_01CE;\n\tv966 = 0x319A000 + 0xF7C;\n\tv934.invoke_impl = v966;\n\tgoto L_01D1;\nL_01CE:\n\tv934.invoke_impl = v934.method_ptr;\n\tv934.method_code = v934.Target;\n\tv372 = *([v425 @ X0_v25 (System.Delegate)]) != *([v109 @ X27_v4 (System.Int32)]);\n\tif (v372) goto L_029F;\n\tv348.selectedChanged = v425;\n\tv171 = *([v425 @ X0_v25 (System.Delegate)]) != *([v109 @ X27_v4 (System.Int32)]);\n\tif (v171) goto L_029F;\n\tv986 = this._data;\n\tv989 = this._data == 0;\n\tv316 = ~v989;\n\tif (v316) goto L_0205;\n\tgoto L_029D;\nL_01FB:\n\tv348.selectedChanged = 0;\n\tv986 = this._data;\nL_0205:\n\tv988 = new *([v109 @ X27_v4 (System.Int32)])();\n\tv284 = Il2CppMethodInfo;\n\tv988.method_ptr = *([v284 @ X24_v8 (Il2CppMethodInfo)+8]);\n\tv988.method = Il2CppMethodInfo;\n\tv988.Target = this;\n\tv988.method_code = v988;\n\tv997 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv998 = v997 == 0;\n\tif (v998) goto L_0227;\n\tv1008 = *([v284 @ X24_v8 (Il2CppMethodInfo)+52]) != 1;\n\tif (v1008) goto L_0227;\n\tv1021 = 0x319A000 + 0xF7C;\n\tv988.invoke_impl = v1021;\n\tgoto L_022A;\nL_0227:\n\tv988.invoke_impl = v988.method_ptr;\n\tv988.method_code = v988.Target;\n\tv373 = *([v426 @ X0_v34 (System.Delegate)]) != *([v109 @ X27_v4 (System.Int32)]);\n\tif (v373) goto L_029F;\n\tv986.selectedChanged = v426;\n\tv173 = *([v426 @ X0_v34 (System.Delegate)]) != *([v109 @ X27_v4 (System.Int32)]);\n\tif (v173) goto L_029F;\nL_0257:\n\tv527 = data.Selected == 0;\n\tv1047 = ~v527;\n\tv1048 = ~v1047;\n\tif (v1048) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1051 = 0x8C;\n\tgoto L_0267;\nL_FFFFFFFF:\n\tv1051 = 0x9C;\nL_FFFFFFFF:\n\tv515 = 0x88;\n\tgoto L_0270;\nL_FFFFFFFF:\n\tv515 = 0x98;\nL_FFFFFFFF:\n\tv507 = 0x84;\n\tgoto L_027C;\nL_FFFFFFFF:\n\tv507 = 0x94;\nL_FFFFFFFF:\n\tv1066 = 0x80;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1066 = 0x90;\nL_0295:\n\tv986.selectedChanged = 0;\n\tv1029 = this.selectionPanel == 0;\n\tv304 = ~v1029;\n\tif (v304) goto L_0257;\nL_029D:\n\tthrow System.NullReferenceException;\nL_029F:\n\tthrow System.InvalidCastException;\nL_0030:\n\tv109 = 0xB294000 + 0x128;\n\tv62 = this._data;\n\tv105 = 0x319A000 + 0xF28;\n\tv65 = this._data == 0;\n\tif (v65) goto L_008A;\nL_0061:\n\tv109 = 0xB294000 + 0x128;\n\tv105 = 0x319A000 + 0xF28;\n\tv72.extra_arg = v105;\n\tv424 = System.Delegate::Remove(v62.selectedChanged, v72);\n\tv118 = v424 == 0;\n\tif (v118) goto L_0086;\nL_019D:\n\tv926 = System.String::Concat(data.spritePath, *([v330 @ X8_v8 (System.Int32)]));\n\tv298 = UnityEngine.Resources::Load(v926);\nL_01D1:\n\tv934.extra_arg = v105;\n\tv425 = System.Delegate::Remove(v348.selectedChanged, v934);\n\tv428 = v425 == 0;\n\tif (v428) goto L_01FB;\nL_022A:\n\tv988.extra_arg = v105;\n\tv426 = System.Delegate::Combine(v986.selectedChanged, v988);\n\tv429 = v426 == 0;\n\tif (v429) goto L_0295;\nL_0267:\n\tv1054 = ~v527;\n\tv1055 = ~v1054;\n\tif (v1055) goto L_FFFFFFFF;\nL_0270:\n\tv1060 = ~v527;\n\tv1061 = ~v1060;\n\tif (v1061) goto L_FFFFFFFF;\nL_027C:\n\tv517 = ~v527;\n\tv510 = ~v517;\n\tif (v510) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v1066 @ X8_v22 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v507 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v515 @ X9_v11 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v1051 @ X8_v21 (System.Int32)]\n\tv547 = UnityEngine.UI.Graphic::set_color(v547, Color_arg);\n\treturn;\n")]
		public unsafe void SetData(int dataIndex, InventoryData data, bool isVertical)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InventoryCellView::SetData");
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0x4030640", Offset = "0x4030640", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = selected == 0;\n\tv16 = ~v9;\n\tv17 = ~v16;\n\tif (v17) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv40 = 0x8C;\n\tgoto L_0018;\nL_FFFFFFFF:\n\tv40 = 0x9C;\nL_FFFFFFFF:\n\tv78 = 0x88;\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv78 = 0x98;\nL_FFFFFFFF:\n\tv69 = 0x84;\n\tgoto L_002D;\nL_FFFFFFFF:\n\tv69 = 0x94;\nL_FFFFFFFF:\n\tv81 = 0x80;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv81 = 0x90;\nL_0018:\n\tv43 = ~v9;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\nL_0021:\n\tv106 = ~v9;\n\tv107 = ~v106;\n\tif (v107) goto L_FFFFFFFF;\nL_002D:\n\tv75 = ~v9;\n\tv72 = ~v75;\n\tif (v72) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v81 @ X9_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v69 @ X11_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v78 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v40 @ X9_v2 (System.Int32)]\n\tv2 = UnityEngine.UI.Graphic::set_color(v2, Color_arg);\n\treturn;\n")]
		private void SelectedChanged(bool selected)
		{
			//IL_0124: Expected F4, but got I
			//IL_0139: Expected F4, but got I
			//IL_014e: Expected F4, but got I
			//IL_0163: Expected F4, but got I
			bool flag = !selected;
			if (!flag)
			{
				int num = 140;
			}
			else
			{
				int num = 156;
			}
			if (!flag)
			{
				int num2 = 136;
			}
			else
			{
				int num2 = 152;
			}
			if (!flag)
			{
				int num3 = 132;
			}
			else
			{
				int num3 = 148;
			}
			if (!flag)
			{
				int num4 = 128;
			}
			else
			{
				int num4 = 144;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v81 @ X9_v3 (System.Int32)]");
			Color color = default(Color);
			color.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v69 @ X11_v3 (System.Int32)]");
			color.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v78 @ X10_v3 (System.Int32)]");
			color.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView)+v40 @ X9_v2 (System.Int32)]");
			color.a = 0f;
			Image image = default(Image);
			image.color = color;
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0x40306AC", Offset = "0x40306AC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.selected == 0;\n\tif (v2) goto L_0008;\n\tEnhancedScrollerDemos.SelectionDemo.SelectedDelegate::Invoke(this.selected, this);\n\treturn;\nL_0008:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSelected()
		{
			if (selected != null)
			{
				selected(this);
			}
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0x40306CC", Offset = "0x40306CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public InventoryCellView()
		{
		}
	}
}
