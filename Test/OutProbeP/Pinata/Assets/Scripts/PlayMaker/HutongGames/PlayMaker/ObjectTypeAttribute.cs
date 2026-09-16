using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EBB4", Offset = "0x73EBB4")]
	[Token(Token = "0x200003E")]
	public sealed class ObjectTypeAttribute : Attribute
	{
		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x10")]
		private readonly Type objectType;

		[Token(Token = "0x1700004D")]
		public Type ObjectType
		{
			[Token(Token = "0x600012D")]
			[Address(RVA = "0xE52160", Offset = "0xE52160", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.objectType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectType;
			}
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xE52168", Offset = "0xE52168", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.objectType = objectType;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObjectTypeAttribute(Type objectType)
		{
			this.objectType = objectType;
		}
	}
}
