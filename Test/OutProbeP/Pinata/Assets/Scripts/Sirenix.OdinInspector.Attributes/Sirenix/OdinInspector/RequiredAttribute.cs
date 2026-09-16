using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7418A4", Offset = "0x7418A4")]
	[Token(Token = "0x2000012")]
	public sealed class RequiredAttribute : Attribute
	{
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x10")]
		public InfoMessageType MessageType;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x167F34C", Offset = "0x167F34C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.MessageType = 3;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RequiredAttribute()
		{
			MessageType = InfoMessageType.Error;
		}
	}
}
