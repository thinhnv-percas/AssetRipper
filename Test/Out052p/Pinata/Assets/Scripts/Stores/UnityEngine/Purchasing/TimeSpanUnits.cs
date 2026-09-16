using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000074")]
	public class TimeSpanUnits
	{
		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x10")]
		public double days;

		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x18")]
		public int months;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x1C")]
		public int years;

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0x15AFDCC", Offset = "0x15AFDCC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.days = d;\n\tthis.months = m;\n\tthis.years = y;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TimeSpanUnits(double d, int m, int y)
		{
			days = d;
			months = m;
			years = y;
		}
	}
}
