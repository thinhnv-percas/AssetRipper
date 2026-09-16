using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unity.IL2CPP.CompilerServices
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73CFF4", Offset = "0x73CFF4")]
	[Token(Token = "0x2000005")]
	public class Il2CppSetOptionAttribute : Attribute
	{
		[CompilerGenerated]
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x10")]
		private readonly Option _003COption_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x18")]
		private readonly object _003CValue_003Ek__BackingField;

		[Token(Token = "0x17000001")]
		public Option Option
		{
			[CompilerGenerated]
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x15FA568", Offset = "0x15FA568", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Option>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Option;
			}
		}

		[Token(Token = "0x17000002")]
		public object Value
		{
			[CompilerGenerated]
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x15FA570", Offset = "0x15FA570", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Value>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15FA578", Offset = "0x15FA578", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.<Option>k__BackingField = option;\n\tthis.<Value>k__BackingField = value;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Il2CppSetOptionAttribute(Option option, object value)
		{
			Option = option;
			Value = value;
		}
	}
}
