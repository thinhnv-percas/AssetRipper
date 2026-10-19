using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.GridSelection
{
	[Token(Token = "0x200004F")]
	public class Data
	{
		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x18")]
		public SelectedChangedDelegate selectedChanged;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x20")]
		internal bool _selected;

		[Token(Token = "0x17000024")]
		public bool Selected
		{
			[Token(Token = "0x6000198")]
			[Address(RVA = "0x402ACE0", Offset = "0x402ACE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Selected;\n")]
			get
			{
				return _selected;
			}
			[Token(Token = "0x6000199")]
			[Address(RVA = "0x402A910", Offset = "0x402A910", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.Selected == value;\n\tif (v7) goto L_0013;\n\tthis.Selected = value;\n\tv13 = this.selectedChanged == 0;\n\tif (v13) goto L_0013;\n\tEnhancedScrollerDemos.GridSelection.SelectedChangedDelegate::Invoke(this.selectedChanged, value);\n\treturn;\nL_0013:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Selected != value)
				{
					_selected = value;
					if (selectedChanged != null)
					{
						selectedChanged(value);
					}
				}
			}
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0x402A7DC", Offset = "0x402A7DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
