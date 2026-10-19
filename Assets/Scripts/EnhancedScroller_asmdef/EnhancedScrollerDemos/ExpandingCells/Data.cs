using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.ExpandingCells
{
	[Token(Token = "0x2000027")]
	public class Data
	{
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x10")]
		public bool isExpanded;

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x18")]
		public string headerText;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x20")]
		public string descriptionText;

		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x28")]
		public float collapsedSize;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x2C")]
		public float expandedSize;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x30")]
		public Tween.TweenType tweenType;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x34")]
		public float tweenTimeExpand;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x38")]
		public float tweenTimeCollapse;

		[Token(Token = "0x17000020")]
		public float Size
		{
			[Token(Token = "0x600010B")]
			[Address(RVA = "0x4025AC0", Offset = "0x4025AC0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.isExpanded == 0;\n\tv13 = ~v6;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv17 = 0x2C;\n\tgoto L_0014;\nL_FFFFFFFF:\n\tv17 = 0x28;\nL_0014:\n\treturn *([this @ X0 (EnhancedScrollerDemos.ExpandingCells.Data)+v17 @ X8_v3 (System.Int32)]);\n")]
			get
			{
				//IL_005e: Expected F4, but got I
				if (isExpanded)
				{
					int num = 44;
				}
				else
				{
					int num = 40;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EnhancedScrollerDemos.ExpandingCells.Data)+v17 @ X8_v3 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x17000021")]
		public float SizeDifference
		{
			[Token(Token = "0x600010C")]
			[Address(RVA = "0x402594C", Offset = "0x402594C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.expandedSize - this.collapsedSize;\n\treturn returnVal1;\n")]
			get
			{
				return expandedSize - collapsedSize;
			}
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x4025594", Offset = "0x4025594", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
