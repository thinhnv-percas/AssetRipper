using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7416E8", Offset = "0x7416E8")]
	[Token(Token = "0x2000004")]
	public class TableColumnWidthAttribute : Attribute
	{
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x10")]
		public int Width;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x14")]
		public bool Resizable;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x167F380", Offset = "0x167F380", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Resizable = 1;\n\tSystem.Attribute::.ctor(this);\n\tthis.Width = width;\n\tthis.Resizable = resizable;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TableColumnWidthAttribute(int width, bool resizable = true)
		{
			Resizable = true;
			Width = width;
			Resizable = resizable;
		}
	}
}
