using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x744A0C", Offset = "0x744A0C")]
	[Token(Token = "0x200004F")]
	public class VisibleIf : MultiPropertyAttribute
	{
		[CompilerGenerated]
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x10")]
		private string _003CMethodName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x18")]
		private bool _003CNegate_003Ek__BackingField;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x20")]
		private MethodInfo eventMethodInfo;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x28")]
		private FieldInfo fieldInfo;

		[Token(Token = "0x17000085")]
		public string MethodName
		{
			[CompilerGenerated]
			[Token(Token = "0x6000373")]
			[Address(RVA = "0x1036240", Offset = "0x1036240", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MethodName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MethodName;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000374")]
			[Address(RVA = "0x1036248", Offset = "0x1036248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MethodName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMethodName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000086")]
		public bool Negate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000375")]
			[Address(RVA = "0x1036250", Offset = "0x1036250", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Negate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Negate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000376")]
			[Address(RVA = "0x1036258", Offset = "0x1036258", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Negate>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CNegate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000377")]
		[Address(RVA = "0x1036264", Offset = "0x1036264", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.MultiPropertyAttribute::.ctor(this);\n\tthis.<MethodName>k__BackingField = methodName;\n\tthis.<Negate>k__BackingField = negate;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VisibleIf(string methodName, bool negate = false)
		{
			MethodName = methodName;
			Negate = negate;
		}
	}
}
