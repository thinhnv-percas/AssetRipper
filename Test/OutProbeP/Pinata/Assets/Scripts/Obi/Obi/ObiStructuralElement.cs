using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000067")]
	public class ObiStructuralElement
	{
		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x10")]
		public int particle1;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x14")]
		public int particle2;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x18")]
		public float restLength;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x1C")]
		public float constraintForce;

		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x20")]
		public float tearResistance;

		[Token(Token = "0x6000460")]
		[Address(RVA = "0x1030278", Offset = "0x1030278", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiStructuralElement()
		{
		}
	}
}
