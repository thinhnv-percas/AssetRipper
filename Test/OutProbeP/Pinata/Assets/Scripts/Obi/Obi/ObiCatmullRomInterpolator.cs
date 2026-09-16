using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000072")]
	public class ObiCatmullRomInterpolator : ObiInterpolator<float>
	{
		[Token(Token = "0x6000483")]
		[Address(RVA = "0xE3FB04", Offset = "0xE3FB04", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = 1f - mu;\n\tv4 = v2 * v2;\n\tv5 = v2 * 3f;\n\tv6 = v2 * v4;\n\tv7 = v2 * v5;\n\tv8 = v6 * y0;\n\tv10 = mu * mu;\n\tv11 = v5 * mu;\n\tv12 = v7 * mu;\n\tv13 = v10 * mu;\n\tv14 = v11 * mu;\n\tv15 = v12 * y1;\n\tv17 = v14 * y2;\n\tv19 = v8 + v15;\n\tv20 = v17 + v19;\n\tv21 = v13 * y3;\n\treturnVal1 = v21 + v20;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float Evaluate(float y0, float y1, float y2, float y3, float mu)
		{
			float num = 1f - mu;
			float num2 = num * num;
			float num3 = num * 3f;
			float num4 = num * num2;
			float num5 = num * num3;
			float num6 = num4 * y0;
			float num7 = mu * mu;
			float num8 = num3 * mu;
			float num9 = num5 * mu;
			float num10 = num7 * mu;
			float num11 = num8 * mu;
			float num12 = num9 * y1;
			float num13 = num11 * y2;
			float num14 = num6 + num12;
			float num15 = num13 + num14;
			float num16 = num10 * y3;
			return num16 + num15;
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0xE3FB54", Offset = "0xE3FB54", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = y1 - y0;\n\tv6 = y2 - y1;\n\tv8 = y3 - y2;\n\tv10 = 1f - mu;\n\tv12 = mu * 3f;\n\tv13 = v10 * 3f;\n\tv14 = v10 * 6f;\n\tv15 = v12 * mu;\n\tv16 = v10 * v13;\n\tv17 = v14 * mu;\n\tv18 = v2 * v16;\n\tv19 = v6 * v17;\n\tv20 = v18 + v19;\n\tv21 = v8 * v15;\n\treturnVal1 = v21 + v20;\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float EvaluateFirstDerivative(float y0, float y1, float y2, float y3, float mu)
		{
			float num = y1 - y0;
			float num2 = y2 - y1;
			float num3 = y3 - y2;
			float num4 = 1f - mu;
			float num5 = mu * 3f;
			float num6 = num4 * 3f;
			float num7 = num4 * 6f;
			float num8 = num5 * mu;
			float num9 = num4 * num6;
			float num10 = num7 * mu;
			float num11 = num * num9;
			float num12 = num2 * num10;
			float num13 = num11 + num12;
			float num14 = num3 * num8;
			return num14 + num13;
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0xE3FBA0", Offset = "0xE3FBA0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = y1 - y0;\n\tv6 = y2 - y1;\n\tv8 = y3 - y2;\n\tv10 = 1f - mu;\n\tv12 = mu * 3f;\n\tv13 = v10 * 3f;\n\tv14 = v10 * 6f;\n\tv15 = v12 * mu;\n\tv16 = v10 * v13;\n\tv17 = v14 * mu;\n\tv18 = v2 * v16;\n\tv19 = v6 * v17;\n\tv20 = v18 + v19;\n\tv21 = v8 * v15;\n\treturnVal1 = v21 + v20;\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float EvaluateSecondDerivative(float y0, float y1, float y2, float y3, float mu)
		{
			float num = y1 - y0;
			float num2 = y2 - y1;
			float num3 = y3 - y2;
			float num4 = 1f - mu;
			float num5 = mu * 3f;
			float num6 = num4 * 3f;
			float num7 = num4 * 6f;
			float num8 = num5 * mu;
			float num9 = num4 * num6;
			float num10 = num7 * mu;
			float num11 = num * num9;
			float num12 = num2 * num10;
			float num13 = num11 + num12;
			float num14 = num3 * num8;
			return num14 + num13;
		}

		[Token(Token = "0x6000486")]
		[Address(RVA = "0xE3FBEC", Offset = "0xE3FBEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCatmullRomInterpolator()
		{
		}
	}
}
