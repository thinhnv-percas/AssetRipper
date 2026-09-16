using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EC04", Offset = "0x73EC04")]
	[Token(Token = "0x2000042")]
	public sealed class RequiredFieldAttribute : Attribute
	{
		[Token(Token = "0x6000133")]
		[Address(RVA = "0xE53AB8", Offset = "0xE53AB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RequiredFieldAttribute()
		{
		}
	}
}
