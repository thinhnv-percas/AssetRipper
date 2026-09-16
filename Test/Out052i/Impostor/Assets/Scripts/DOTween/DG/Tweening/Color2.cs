using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000004")]
	public struct Color2
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x0")]
		public Color ca;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x10")]
		public Color cb;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0xC05810", Offset = "0xC05810", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ca = ca;\n\t*([this @ X0 (DG.Tweening.Color2)+4]) = ca.g;\n\t*([this @ X0 (DG.Tweening.Color2)+8]) = ca.b;\n\t*([this @ X0 (DG.Tweening.Color2)+C]) = ca.a;\n\tthis.cb = cb;\n\t*([this @ X0 (DG.Tweening.Color2)+14]) = cb.g;\n\t*([this @ X0 (DG.Tweening.Color2)+18]) = cb.b;\n\t*([this @ X0 (DG.Tweening.Color2)+1C]) = cb.a;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color2(Color ca, Color cb)
		{
			this.ca = ca;
			_ = ca.g;
			_ = ca.b;
			_ = ca.a;
			this.cb = cb;
			_ = cb.g;
			_ = cb.b;
			_ = cb.a;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0xC05824", Offset = "0xC05824", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = c1.ca + c2.ca;\n\tv7 = c1.cb + c2.cb;\n\treturnBuffer.ca = v6;\n\treturnBuffer.cb = v7;\n\treturn c1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator +(Color2 c1, Color2 c2)
		{
			//IL_0053: Expected O, but got F4
			//IL_004e: Expected native int or pointer, but got O
			//IL_0060: Expected O, but got F4
			//IL_005b: Expected native int or pointer, but got O
			float num = c1.ca.r + c2.ca.r;
			float num2 = c1.cb.r + c2.cb.r;
			Color2 color = default(Color2);
			((Color2*)(nint)color)->ca = (Color)num;
			((Color2*)(nint)color)->cb = (Color)num2;
			return c1;
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0xC0583C", Offset = "0xC0583C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = c1.ca - c2.ca;\n\tv7 = c1.cb - c2.cb;\n\treturnBuffer.ca = v6;\n\treturnBuffer.cb = v7;\n\treturn c1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator -(Color2 c1, Color2 c2)
		{
			//IL_0053: Expected O, but got F4
			//IL_004e: Expected native int or pointer, but got O
			//IL_0060: Expected O, but got F4
			//IL_005b: Expected native int or pointer, but got O
			float num = c1.ca.r - c2.ca.r;
			float num2 = c1.cb.r - c2.cb.r;
			Color2 color = default(Color2);
			((Color2*)(nint)color)->ca = (Color)num;
			((Color2*)(nint)color)->cb = (Color)num2;
			return c1;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0xC05854", Offset = "0xC05854", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = c1.ca * v4;\n\tv5 = c1.cb * v4;\n\treturnBuffer.ca = v3;\n\treturnBuffer.cb = v5;\n\treturn c1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator *(Color2 c1, float f)
		{
			//IL_003f: Expected O, but got F4
			//IL_003a: Expected native int or pointer, but got O
			//IL_004c: Expected O, but got F4
			//IL_0047: Expected native int or pointer, but got O
			object obj = default(object);
			float num = c1.ca.r * (float)obj;
			float num2 = c1.cb.r * (float)obj;
			Color2 color = default(Color2);
			((Color2*)(nint)color)->ca = (Color)num;
			((Color2*)(nint)color)->cb = (Color)num2;
			return c1;
		}
	}
}
