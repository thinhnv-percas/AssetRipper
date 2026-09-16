using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74171C", Offset = "0x74171C")]
	[Token(Token = "0x2000005")]
	public class TableListAttribute : Attribute
	{
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x10")]
		public int DefaultMinColumnWidth;

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x14")]
		public bool DrawScrollView;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		public int MinScrollViewHeight;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x1C")]
		public int CellPadding;

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x167F3C8", Offset = "0x167F3C8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.DefaultMinColumnWidth = 0x28;\n\tthis.DrawScrollView = 1;\n\tthis.MinScrollViewHeight = 0x15E;\n\tthis.CellPadding = 2;\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TableListAttribute()
		{
			DefaultMinColumnWidth = 40;
			DrawScrollView = true;
			MinScrollViewHeight = 350;
			CellPadding = 2;
		}
	}
}
