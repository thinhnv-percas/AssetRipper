using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.GridSelection
{
	[Token(Token = "0x2000050")]
	public class RowCellView : MonoBehaviour
	{
		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x20")]
		public GameObject container;

		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x28")]
		public Text text;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x30")]
		public Image selectionPanel;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x38")]
		public Color selectedColor;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x48")]
		public Color unSelectedColor;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x60")]
		public SelectedDelegate selected;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x68")]
		private Data _data;

		[Token(Token = "0x17000025")]
		[field: Token(Token = "0x4000160")]
		[field: FieldOffset(Offset = "0x58")]
		public int DataIndex
		{
			[Token(Token = "0x600019B")]
			[Address(RVA = "0x402ACE8", Offset = "0x402ACE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.DataIndex;\n")]
			get;
			[Token(Token = "0x600019C")]
			[Address(RVA = "0x402ACF0", Offset = "0x402ACF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.DataIndex = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x402ACF8", Offset = "0x402ACF8", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv58 = new EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate();\n\tv97 = Il2CppMethodInfo;\n\tv58.method_ptr = *([v97 @ X23_v5 (Il2CppMethodInfo)+8]);\n\tv58.method = Il2CppMethodInfo;\n\tv58.Target = this;\n\tv58.method_code = v58;\n\tv164 = 0x21C1144(Il2CppMethodInfo, this, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv165 = v164 == 0;\n\tif (v165) goto L_0043;\n\tv175 = *([v97 @ X23_v5 (Il2CppMethodInfo)+52]) != 1;\n\tif (v175) goto L_0043;\n\tv188 = 0x319A000 + 0xB88;\n\tv58.invoke_impl = v188;\n\tgoto L_0047;\nL_0043:\n\tv58.invoke_impl = v58.method_ptr;\n\tv58.method_code = v58.Target;\n\tv65 = *([v203 @ X0_v10 (System.Delegate)]) != EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate;\n\tif (v65) goto L_006A;\n\tv47.selectedChanged = v203;\n\tv219 = *([v203 @ X0_v10 (System.Delegate)]) == EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate;\n\tif (v219) goto L_0082;\nL_006A:\n\tthrow System.InvalidCastException;\nL_0074:\n\treturn;\nL_0075:\n\tv47.selectedChanged = 0;\nL_0019:\n\tv47 = this._data;\n\tv48 = this._data == 0;\n\tif (v48) goto L_0074;\nL_0047:\n\tv200 = 0x319A000 + 0xB34;\n\tv58.extra_arg = v200;\n\tv203 = System.Delegate::Remove(v47.selectedChanged, v58);\n\tv102 = v203 == 0;\n\tif (v102) goto L_0075;\nL_0082:\n\treturn;\n")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RowCellView::OnDestroy");
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x402A194", Offset = "0x402A194", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv71 = data == 0;\n\tv76 = ~v71;\n\tUnityEngine.GameObject::SetActive(this.container, v76);\n\tv206 = data == 0;\n\tif (v206) goto L_0041;\n\tv295 = UnityEngine.UI.Text::set_text(this.text, data.someText);\n\tv307 = new EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate();\n\tv413 = Il2CppMethodInfo;\n\tv307.method_ptr = *([v413 @ X26_v10 (Il2CppMethodInfo)+8]);\n\tv307.method = Il2CppMethodInfo;\n\tv307.Target = this;\n\tv307.method_code = v307;\n\tv420 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv421 = v420 == 0;\n\tif (v421) goto L_006F;\n\tv433 = *([v413 @ X26_v10 (Il2CppMethodInfo)+52]) != 1;\n\tif (v433) goto L_006F;\n\tv452 = 0x319A000 + 0xB88;\n\tv307.invoke_impl = v452;\n\tgoto L_0073;\nL_006F:\n\tv307.invoke_impl = v307.method_ptr;\n\tv307.method_code = v307.Target;\n\tv229 = *([v273 @ X0_v49 (System.Delegate)]) != EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate;\n\tif (v229) goto L_01AB;\n\tv302.selectedChanged = v273;\n\tv254 = *([v273 @ X0_v49 (System.Delegate)]) == EnhancedScrollerDemos.GridSelection.SelectedChangedDelegate;\n\tif (v254) goto L_009B;\n\tgoto L_01AB;\nL_0097:\n\tv302.selectedChanged = 0;\nL_009B:\n\tthis.DataIndex = dataIndex;\n\tthis._data = data;\n\tv389 = data == 0;\n\tif (v389) goto L_0106;\n\tv198 = this._data;\n\tv423 = new *([v83 @ X26_v5 (System.Int32)])();\n\tv87 = Il2CppMethodInfo;\n\tv423.method_ptr = *([v87 @ X25_v5 (Il2CppMethodInfo)+8]);\n\tv423.method = Il2CppMethodInfo;\n\tv423.Target = this;\n\tv423.method_code = v423;\n\tv468 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv469 = v468 == 0;\n\tif (v469) goto L_00CB;\n\tv480 = *([v87 @ X25_v5 (Il2CppMethodInfo)+52]) != 1;\n\tif (v480) goto L_00CB;\n\tv496 = 0x319A000 + 0xB88;\n\tv423.invoke_impl = v496;\n\tgoto L_00CF;\nL_00CB:\n\tv423.invoke_impl = v423.method_ptr;\n\tv423.method_code = v423.Target;\n\tv230 = *([v274 @ X0_v21 (System.Delegate)]) != *([v83 @ X26_v5 (System.Int32)]);\n\tif (v230) goto L_01AB;\n\tv198.selectedChanged = v274;\n\tv115 = *([v274 @ X0_v21 (System.Delegate)]) != *([v83 @ X26_v5 (System.Int32)]);\n\tif (v115) goto L_01AB;\n\tv516 = this._data;\n\tv519 = this._data == 0;\n\tv185 = ~v519;\n\tif (v185) goto L_0111;\n\tgoto L_01A9;\nL_0106:\n\treturn;\nL_0107:\n\tv198.selectedChanged = 0;\n\tv516 = this._data;\nL_0111:\n\tv518 = new *([v83 @ X26_v5 (System.Int32)])();\n\tv92 = Il2CppMethodInfo;\n\tv518.method_ptr = *([v92 @ X24_v6 (Il2CppMethodInfo)+8]);\n\tv518.method = Il2CppMethodInfo;\n\tv518.Target = this;\n\tv518.method_code = v518;\n\tv527 = 0x21C1144(Il2CppMethodInfo, this, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv528 = v527 == 0;\n\tif (v528) goto L_0133;\n\tv538 = *([v92 @ X24_v6 (Il2CppMethodInfo)+52]) != 1;\n\tif (v538) goto L_0133;\n\tv551 = 0x319A000 + 0xB88;\n\tv518.invoke_impl = v551;\n\tgoto L_0136;\nL_0133:\n\tv518.invoke_impl = v518.method_ptr;\n\tv518.method_code = v518.Target;\n\tv231 = *([v275 @ X0_v30 (System.Delegate)]) != *([v83 @ X26_v5 (System.Int32)]);\n\tif (v231) goto L_01AB;\n\tv516.selectedChanged = v275;\n\tv117 = *([v275 @ X0_v30 (System.Delegate)]) != *([v83 @ X26_v5 (System.Int32)]);\n\tif (v117) goto L_01AB;\nL_0163:\n\tv379 = data.Selected == 0;\n\tv577 = ~v379;\n\tv578 = ~v577;\n\tif (v578) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv581 = 0x44;\n\tgoto L_0173;\nL_FFFFFFFF:\n\tv581 = 0x54;\nL_FFFFFFFF:\n\tv363 = 0x40;\n\tgoto L_017C;\nL_FFFFFFFF:\n\tv363 = 0x50;\nL_FFFFFFFF:\n\tv340 = 0x3C;\n\tgoto L_0188;\nL_FFFFFFFF:\n\tv340 = 0x4C;\nL_FFFFFFFF:\n\tv596 = 0x38;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv596 = 0x48;\nL_01A1:\n\tv516.selectedChanged = 0;\n\tv559 = this.selectionPanel == 0;\n\tv182 = ~v559;\n\tif (v182) goto L_0163;\nL_01A9:\n\tthrow System.NullReferenceException;\nL_01AB:\n\tthrow System.InvalidCastException;\nL_0022:\n\tthis.selected = selected;\nL_0041:\n\tv83 = 0xB294000 + 0x120;\n\tv302 = this._data;\n\tv80 = 0x319A000 + 0xB34;\n\tv305 = this._data == 0;\n\tif (v305) goto L_009B;\nL_0073:\n\tv80 = 0x319A000 + 0xB34;\n\tv307.extra_arg = v80;\n\tv273 = System.Delegate::Remove(v302.selectedChanged, v307);\n\tv277 = v273 == 0;\n\tif (v277) goto L_0097;\nL_00CF:\n\tv423.extra_arg = v80;\n\tv274 = System.Delegate::Remove(v198.selectedChanged, v423);\n\tv278 = v274 == 0;\n\tif (v278) goto L_0107;\nL_0136:\n\tv518.extra_arg = v80;\n\tv275 = System.Delegate::Combine(v516.selectedChanged, v518);\n\tv279 = v275 == 0;\n\tif (v279) goto L_01A1;\nL_0173:\n\tv584 = ~v379;\n\tv585 = ~v584;\n\tif (v585) goto L_FFFFFFFF;\nL_017C:\n\tv590 = ~v379;\n\tv591 = ~v590;\n\tif (v591) goto L_FFFFFFFF;\nL_0188:\n\tv369 = ~v379;\n\tv343 = ~v369;\n\tif (v343) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v596 @ X8_v20 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v340 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v363 @ X9_v9 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v581 @ X8_v19 (System.Int32)]\n\tv387 = UnityEngine.UI.Graphic::set_color(v387, Color_arg);\n\treturn;\n")]
		public unsafe void SetData(int dataIndex, Data data, SelectedDelegate selected)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RowCellView::SetData");
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0x402AE3C", Offset = "0x402AE3C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = selected == 0;\n\tv16 = ~v9;\n\tv17 = ~v16;\n\tif (v17) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv40 = 0x44;\n\tgoto L_0018;\nL_FFFFFFFF:\n\tv40 = 0x54;\nL_FFFFFFFF:\n\tv78 = 0x40;\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv78 = 0x50;\nL_FFFFFFFF:\n\tv69 = 0x3C;\n\tgoto L_002D;\nL_FFFFFFFF:\n\tv69 = 0x4C;\nL_FFFFFFFF:\n\tv81 = 0x38;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv81 = 0x48;\nL_0018:\n\tv43 = ~v9;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\nL_0021:\n\tv106 = ~v9;\n\tv107 = ~v106;\n\tif (v107) goto L_FFFFFFFF;\nL_002D:\n\tv75 = ~v9;\n\tv72 = ~v75;\n\tif (v72) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v81 @ X9_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v69 @ X11_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v78 @ X10_v3 (System.Int32)], [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v40 @ X9_v2 (System.Int32)]\n\tv2 = UnityEngine.UI.Graphic::set_color(v2, Color_arg);\n\treturn;\n")]
		private void SelectedChanged(bool selected)
		{
			//IL_0124: Expected F4, but got I
			//IL_0139: Expected F4, but got I
			//IL_014e: Expected F4, but got I
			//IL_0163: Expected F4, but got I
			bool flag = !selected;
			if (!flag)
			{
				int num = 68;
			}
			else
			{
				int num = 84;
			}
			if (!flag)
			{
				int num2 = 64;
			}
			else
			{
				int num2 = 80;
			}
			if (!flag)
			{
				int num3 = 60;
			}
			else
			{
				int num3 = 76;
			}
			if (!flag)
			{
				int num4 = 56;
			}
			else
			{
				int num4 = 72;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v81 @ X9_v3 (System.Int32)]");
			Color color = default(Color);
			color.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v69 @ X11_v3 (System.Int32)]");
			color.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v78 @ X10_v3 (System.Int32)]");
			color.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.GridSelection.RowCellView)+v40 @ X9_v2 (System.Int32)]");
			color.a = 0f;
			Image image = default(Image);
			image.color = color;
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x402AEA8", Offset = "0x402AEA8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.selected == 0;\n\tif (v2) goto L_0008;\n\tEnhancedScrollerDemos.GridSelection.SelectedDelegate::Invoke(this.selected, this);\n\treturn;\nL_0008:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSelected()
		{
			if (selected != null)
			{
				selected(this);
			}
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x402AEC8", Offset = "0x402AEC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RowCellView()
		{
		}
	}
}
