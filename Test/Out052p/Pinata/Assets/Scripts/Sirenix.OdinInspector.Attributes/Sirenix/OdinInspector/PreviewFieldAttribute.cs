using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7416B0", Offset = "0x7416B0")]
	[Token(Token = "0x2000003")]
	public class PreviewFieldAttribute : Attribute
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		public float Height;

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x14")]
		public ObjectFieldAlignment Alignment;

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x167F278", Offset = "0x167F278", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.Height = 0f;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PreviewFieldAttribute()
		{
			Height = 0f;
		}
	}
}
