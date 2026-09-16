using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EAB4", Offset = "0x73EAB4")]
	[Token(Token = "0x2000033")]
	public sealed class ArrayEditorAttribute : Attribute
	{
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x10")]
		private readonly VariableType variableType;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x18")]
		private readonly Type objectType;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x20")]
		private readonly string elementName;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x28")]
		private readonly int fixedSize;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x2C")]
		private readonly int maxSize;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x30")]
		private readonly int minSize;

		[Token(Token = "0x17000038")]
		public VariableType VariableType
		{
			[Token(Token = "0x600010A")]
			[Address(RVA = "0x9D76C8", Offset = "0x9D76C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.variableType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType;
			}
		}

		[Token(Token = "0x17000039")]
		public Type ObjectType
		{
			[Token(Token = "0x600010B")]
			[Address(RVA = "0x9D76D0", Offset = "0x9D76D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.objectType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectType;
			}
		}

		[Token(Token = "0x1700003A")]
		public string ElementName
		{
			[Token(Token = "0x600010C")]
			[Address(RVA = "0x9D76D8", Offset = "0x9D76D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.elementName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ElementName;
			}
		}

		[Token(Token = "0x1700003B")]
		public int FixedSize
		{
			[Token(Token = "0x600010D")]
			[Address(RVA = "0x9D76E0", Offset = "0x9D76E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fixedSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FixedSize;
			}
		}

		[Token(Token = "0x1700003C")]
		public bool Resizable
		{
			[Token(Token = "0x600010E")]
			[Address(RVA = "0x9D76E8", Offset = "0x9D76E8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.fixedSize == 0;\n\treturn v6;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FixedSize == 0;
			}
		}

		[Token(Token = "0x1700003D")]
		public int MinSize
		{
			[Token(Token = "0x600010F")]
			[Address(RVA = "0x9D76F8", Offset = "0x9D76F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.minSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinSize;
			}
		}

		[Token(Token = "0x1700003E")]
		public int MaxSize
		{
			[Token(Token = "0x6000110")]
			[Address(RVA = "0x9D7700", Offset = "0x9D7700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxSize;
			}
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x9D7708", Offset = "0x9D7708", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.variableType = variableType;\n\tthis.elementName = elementName;\n\tthis.maxSize = maxSize;\n\tthis.minSize = minSize;\n\tthis.fixedSize = fixedSize;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayEditorAttribute(VariableType variableType, string elementName = "", int fixedSize = 0, int minSize = 0, int maxSize = 65536)
		{
			this.variableType = variableType;
			this.elementName = elementName;
			this.maxSize = maxSize;
			this.minSize = minSize;
			this.fixedSize = fixedSize;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x9D7760", Offset = "0x9D7760", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tv36 = System.Type::get_IsEnum(objectType);\n\tv59 = v36 == 0;\n\tv64 = ~v59;\n\tv65 = ~v64;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\tthis.objectType = objectType;\n\tthis.elementName = elementName;\n\tthis.maxSize = maxSize;\n\tthis.minSize = minSize;\n\tthis.variableType = v85;\n\tthis.fixedSize = fixedSize;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayEditorAttribute(Type objectType, string elementName = "", int fixedSize = 0, int minSize = 0, int maxSize = 65536)
		{
			int num = ((!objectType.IsEnum) ? 12 : 14);
			this.objectType = objectType;
			this.elementName = elementName;
			this.maxSize = maxSize;
			this.minSize = minSize;
			variableType = (VariableType)num;
			this.fixedSize = fixedSize;
		}
	}
}
