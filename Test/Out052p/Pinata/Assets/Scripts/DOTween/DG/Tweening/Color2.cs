using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening
{
	[StructLayout((LayoutKind)0, Size = 32)]
	[Token(Token = "0x2000004")]
	public struct Color2
	{
		[Token(Token = "0x400000C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Color ca;

		[Token(Token = "0x400000D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Color cb;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x8566FC", Offset = "0x8566FC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cb = ca;\n\t*([this @ X0 (DG.Tweening.Color2)+14]) = ca.g;\n\t*([this @ X0 (DG.Tweening.Color2)+18]) = ca.b;\n\t*([this @ X0 (DG.Tweening.Color2)+1C]) = ca.a;\n\t*([this @ X0 (DG.Tweening.Color2)+20]) = cb;\n\t*([this @ X0 (DG.Tweening.Color2)+24]) = cb.g;\n\t*([this @ X0 (DG.Tweening.Color2)+28]) = cb.b;\n\t*([this @ X0 (DG.Tweening.Color2)+2C]) = cb.a;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color2(Color ca, Color cb)
		{
			this.cb = ca;
			_ = ca.g;
			_ = ca.b;
			_ = ca.a;
			_ = cb.g;
			_ = cb.b;
			_ = cb.a;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x106F158", Offset = "0x106F158", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = UnityEngine.Color::op_Addition(c1.ca, c2.ca);\n\tv57 = UnityEngine.Color::op_Addition(c1.cb, c2.cb);\n\treturnBuffer.ca = v37;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+4]) = v37.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+8]) = v37.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+C]) = v37.a;\n\treturnBuffer.cb = v57;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+14]) = v57.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+18]) = v57.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+1C]) = v57.a;\n\treturn 0;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator +(Color2 c1, Color2 c2)
		{
			//IL_0043: Expected native int or pointer, but got O
			//IL_006e: Expected native int or pointer, but got O
			Color color = c1.ca + c2.ca;
			Color color2 = c1.cb + c2.cb;
			Color2 color3 = default(Color2);
			((Color2*)(IntPtr)color3)->ca = color;
			_ = color.g;
			_ = color.b;
			_ = color.a;
			((Color2*)(IntPtr)color3)->cb = color2;
			_ = color2.g;
			_ = color2.b;
			_ = color2.a;
			return default(Color2);
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x106F1E8", Offset = "0x106F1E8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = UnityEngine.Color::op_Subtraction(c1.ca, c2.ca);\n\tv57 = UnityEngine.Color::op_Subtraction(c1.cb, c2.cb);\n\treturnBuffer.ca = v37;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+4]) = v37.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+8]) = v37.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+C]) = v37.a;\n\treturnBuffer.cb = v57;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+14]) = v57.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+18]) = v57.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+1C]) = v57.a;\n\treturn 0;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator -(Color2 c1, Color2 c2)
		{
			//IL_0043: Expected native int or pointer, but got O
			//IL_006e: Expected native int or pointer, but got O
			Color color = c1.ca - c2.ca;
			Color color2 = c1.cb - c2.cb;
			Color2 color3 = default(Color2);
			((Color2*)(IntPtr)color3)->ca = color;
			_ = color.g;
			_ = color.b;
			_ = color.a;
			((Color2*)(IntPtr)color3)->cb = color2;
			_ = color2.g;
			_ = color2.b;
			_ = color2.a;
			return default(Color2);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x106F278", Offset = "0x106F278", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = UnityEngine.Color::op_Multiply(c1.ca, f);\n\tv49 = UnityEngine.Color::op_Multiply(c1.cb, f);\n\treturnBuffer.ca = v33;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+4]) = v33.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+8]) = v33.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+C]) = v33.a;\n\treturnBuffer.cb = v49;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+14]) = v49.g;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+18]) = v49.b;\n\t*([returnBuffer @ X8 (DG.Tweening.Color2)+1C]) = v49.a;\n\treturn 0;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Color2 operator *(Color2 c1, float f)
		{
			//IL_0039: Expected native int or pointer, but got O
			//IL_0064: Expected native int or pointer, but got O
			Color color = c1.ca * f;
			Color color2 = c1.cb * f;
			Color2 color3 = default(Color2);
			((Color2*)(IntPtr)color3)->ca = color;
			_ = color.g;
			_ = color.b;
			_ = color.a;
			((Color2*)(IntPtr)color3)->cb = color2;
			_ = color2.g;
			_ = color2.b;
			_ = color2.a;
			return default(Color2);
		}
	}
}
