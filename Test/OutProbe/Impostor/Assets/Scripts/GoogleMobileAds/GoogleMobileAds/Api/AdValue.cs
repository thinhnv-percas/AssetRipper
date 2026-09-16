using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000040")]
	public class AdValue
	{
		[Token(Token = "0x2000041")]
		public enum PrecisionType
		{
			[Token(Token = "0x40000F6")]
			Unknown = 0,
			[Token(Token = "0x40000F7")]
			Estimated = 1,
			[Token(Token = "0x40000F8")]
			PublisherProvided = 2,
			[Token(Token = "0x40000F9")]
			Precise = 3
		}

		[Token(Token = "0x1700002A")]
		public PrecisionType Precision
		{
			[CompilerGenerated]
			[Token(Token = "0x60002E6")]
			[Address(RVA = "0x13580F4", Offset = "0x13580F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Precision>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Precision;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002E7")]
			[Address(RVA = "0x13580FC", Offset = "0x13580FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Precision>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Precision = value;
			}
		}

		[Token(Token = "0x1700002B")]
		public long Value
		{
			[CompilerGenerated]
			[Token(Token = "0x60002E8")]
			[Address(RVA = "0x1358104", Offset = "0x1358104", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Value>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002E9")]
			[Address(RVA = "0x135810C", Offset = "0x135810C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Value>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x1700002C")]
		public string CurrencyCode
		{
			[CompilerGenerated]
			[Token(Token = "0x60002EA")]
			[Address(RVA = "0x1358114", Offset = "0x1358114", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CurrencyCode>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrencyCode;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002EB")]
			[Address(RVA = "0x135811C", Offset = "0x135811C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CurrencyCode>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CurrencyCode = value;
			}
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x1346DB8", Offset = "0x1346DB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdValue()
		{
		}
	}
}
