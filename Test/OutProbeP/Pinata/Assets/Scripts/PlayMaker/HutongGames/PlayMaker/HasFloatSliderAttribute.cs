using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB3C", Offset = "0x73EB3C")]
	[Token(Token = "0x2000038")]
	public sealed class HasFloatSliderAttribute : Attribute
	{
		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x10")]
		private readonly float minValue;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x14")]
		private readonly float maxValue;

		[Token(Token = "0x17000047")]
		public float MinValue
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0xE51894", Offset = "0xE51894", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.minValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinValue;
			}
		}

		[Token(Token = "0x17000048")]
		public float MaxValue
		{
			[Token(Token = "0x6000122")]
			[Address(RVA = "0xE5189C", Offset = "0xE5189C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxValue;
			}
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xE518A4", Offset = "0xE518A4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.minValue = minValue;\n\tthis.maxValue = maxValue;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HasFloatSliderAttribute(float minValue, float maxValue)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
		}
	}
}
