using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA64", Offset = "0x73EA64")]
	[Token(Token = "0x200002F")]
	public sealed class PreviewFieldAttribute : Attribute
	{
		[CompilerGenerated]
		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x10")]
		private string _003CMethodName_003Ek__BackingField;

		[Token(Token = "0x17000034")]
		public string MethodName
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0xE52194", Offset = "0xE52194", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MethodName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MethodName;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000100")]
			[Address(RVA = "0xE5219C", Offset = "0xE5219C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MethodName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMethodName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xE521A4", Offset = "0xE521A4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.<MethodName>k__BackingField = methodName;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PreviewFieldAttribute(string methodName)
		{
			MethodName = methodName;
		}
	}
}
