using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000075")]
	public class ObiConstantInterpolator : ObiInterpolator<int>
	{
		[Token(Token = "0x600048F")]
		[Address(RVA = "0xE42B98", Offset = "0xE42B98", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = mu - 0.5f;\n\tv5 = v4 < 0;\n\tv11 = ~v5;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tgoto L_0011;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int Evaluate(int y0, int y1, int y2, int y3, float mu)
		{
			float num = mu - 0.5f;
			if (!(num < 0f))
			{
				return y2;
			}
			return y1;
		}

		[Token(Token = "0x6000490")]
		[Address(RVA = "0xE42BA8", Offset = "0xE42BA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int EvaluateFirstDerivative(int y0, int y1, int y2, int y3, float mu)
		{
			return 0;
		}

		[Token(Token = "0x6000491")]
		[Address(RVA = "0xE42BB0", Offset = "0xE42BB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int EvaluateSecondDerivative(int y0, int y1, int y2, int y3, float mu)
		{
			return 0;
		}

		[Token(Token = "0x6000492")]
		[Address(RVA = "0xE42BB8", Offset = "0xE42BB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiConstantInterpolator()
		{
		}
	}
}
