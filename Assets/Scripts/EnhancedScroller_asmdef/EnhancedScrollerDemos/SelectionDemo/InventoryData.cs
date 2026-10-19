using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.SelectionDemo
{
	[Token(Token = "0x2000076")]
	public class InventoryData
	{
		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x10")]
		public string itemName;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x18")]
		public int itemCost;

		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x1C")]
		public int itemDamage;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x20")]
		public int itemDefense;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x24")]
		public int itemWeight;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x28")]
		public string itemDescription;

		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x30")]
		public string spritePath;

		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x38")]
		public SelectedChangedDelegate selectedChanged;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x40")]
		internal bool _selected;

		[Token(Token = "0x17000032")]
		public bool Selected
		{
			[Token(Token = "0x600023C")]
			[Address(RVA = "0x4030788", Offset = "0x4030788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Selected;\n")]
			get
			{
				return _selected;
			}
			[Token(Token = "0x600023D")]
			[Address(RVA = "0x4030790", Offset = "0x4030790", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.Selected == value;\n\tif (v7) goto L_0013;\n\tthis.Selected = value;\n\tv13 = this.selectedChanged == 0;\n\tif (v13) goto L_0013;\n\tEnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate::Invoke(this.selectedChanged, value);\n\treturn;\nL_0013:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600023E")]
		[Address(RVA = "0x40307BC", Offset = "0x40307BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public InventoryData()
		{
		}
	}
}
