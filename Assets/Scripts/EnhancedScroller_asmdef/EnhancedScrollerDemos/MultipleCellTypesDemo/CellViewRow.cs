using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x200007B")]
	public class CellViewRow : CellView
	{
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x40")]
		private RowData _rowData;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x48")]
		public Text userNameText;

		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x50")]
		public Image userAvatarImage;

		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x58")]
		public Text userHighScoreText;

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x40318B8", Offset = "0x40318B8", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv56 = EnhancedScrollerDemos.MultipleCellTypesDemo.RowData;\n\tgoto L_FFFFFFFF;\n\tthis._rowData = 0;\n\tv129 = data->klass;\n\tgoto L_0044;\nL_0044:\n\tv134 = *([v56 @ X8_v15 (Il2CppClass<EnhancedScrollerDemos.MultipleCellTypesDemo.RowData>)+130]) << 3;\n\tv135 = *([v129 @ X10_v12 (Il2CppClass<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>)+C8]) + v134;\n\tv146 = *([v135 @ X9_v8-8]) != EnhancedScrollerDemos.MultipleCellTypesDemo.RowData;\n\tif (v146) goto L_0057;\n\tgoto L_0057;\n\tgoto L_00C5;\nL_005F:\n\tthis._rowData = 0;\n\tv197 = this._rowData;\n\tv103 = this._rowData == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0094;\n\tgoto L_00C5;\nL_FFFFFFFF:\n\t// -1 IsInst v101_asT @ TEMPCSEL_v4 (EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), data @ X1 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv101 = v101_asT == 0;\n\tif (v101) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv204 = data;\n\tgoto L_007B;\nL_FFFFFFFF:\n\tv204 = 0;\n\tv197 = this._rowData;\nL_0094:\n\tv236 = UnityEngine.UI.Text::set_text(this.userNameText, v197.userName);\n\tv246 = this._rowData;\n\tv237 = UnityEngine.Resources::Load(v246.userAvatarSpritePath);\n\tUnityEngine.UI.Image::set_sprite(this.userAvatarImage, v237);\n\tv247 = this._rowData;\n\tv209 = v247.userHighScore;\n\tv248 = 0xB7D5000 + 0x538;\n\tv301 = \"il2cpp_vm_object_box\"(*([v248 @ X8_v10 (System.Int32)+70]), &v209 @ stack_-38_v2 (System.UInt64), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv239 = System.String::Format(\"{0:n0}\", v301);\n\tv284 = UnityEngine.UI.Text::set_text(this.userHighScoreText, v239);\n\treturn;\nL_00C5:\n\tthrow System.NullReferenceException;\nL_001D:\n\tthis._data = data;\n\tv51 = data == 0;\n\tif (v51) goto L_005F;\nL_0057:\n\tv197 = this._rowData;\n\tv258 = this._rowData == 0;\n\tv196 = ~v258;\n\tif (v196) goto L_0094;\nL_007B:\n\tthis._rowData = v204;\n\tv129 = data->klass;\n\tgoto L_0044;\n")]
		public override void SetData(Data data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellViewRow::SetData");
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x4031A9C", Offset = "0x4031A9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellViewRow()
		{
		}
	}
}
