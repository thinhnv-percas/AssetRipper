using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x200007A")]
	public class CellViewHeader : CellView
	{
		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x40")]
		private HeaderData _headerData;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x48")]
		public Text categoryText;

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x4031780", Offset = "0x4031780", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv50 = EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData;\n\tgoto L_FFFFFFFF;\n\tthis._headerData = 0;\n\tv123 = data->klass;\n\tgoto L_003E;\nL_003E:\n\tv128 = *([v50 @ X8_v9 (Il2CppClass<EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData>)+130]) << 3;\n\tv129 = *([v123 @ X10_v12 (Il2CppClass<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>)+C8]) + v128;\n\tv140 = *([v129 @ X9_v4-8]) != EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData;\n\tif (v140) goto L_0051;\n\tgoto L_0051;\n\tgoto L_0096;\nL_0059:\n\tthis._headerData = 0;\n\tv191 = this._headerData;\n\tv97 = this._headerData == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0095;\n\tgoto L_0096;\nL_FFFFFFFF:\n\t// -1 IsInst v95_asT @ TEMPCSEL_v4 (EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), data @ X1 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv198 = data;\n\tgoto L_0075;\nL_FFFFFFFF:\n\tv198 = 0;\n\tv191 = this._headerData;\nL_0095:\n\tv194 = UnityEngine.UI.Text::set_text(v194, v191.category);\nL_0095:\n\treturn;\nL_0096:\n\tthrow System.NullReferenceException;\nL_0017:\n\tthis._data = data;\n\tv47 = data == 0;\n\tif (v47) goto L_0059;\nL_0051:\n\tv191 = this._headerData;\n\tv256 = this._headerData == 0;\n\tv190 = ~v256;\n\tif (v190) goto L_0095;\nL_0075:\n\tthis._headerData = v198;\n\tv123 = data->klass;\n\tgoto L_003E;\n")]
		public override void SetData(Data data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellViewHeader::SetData");
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x40318B0", Offset = "0x40318B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellViewHeader()
		{
		}
	}
}
