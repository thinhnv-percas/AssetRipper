using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Core
{
	[Token(Token = "0x200004E")]
	public static class Extensions
	{
		[Token(Token = "0x600029A")]
		[Address(RVA = "0xB86AD0", Offset = "0xB86AD0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([t @ X0 (T)+F4]) = mode;\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetSpecialStartupMode<T>(this T t, SpecialStartupMode mode) where T : Tween
		{
			return t;
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0x135AA3C", Offset = "0x135AA3C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.isBlendable = 1;\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<T1, T2, TPlugOptions> Blendable<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			t.isBlendable = true;
			return t;
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0x135AAAC", Offset = "0x135AAAC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.isFromAllowed = 0;\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<T1, T2, TPlugOptions> NoFrom<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			t.isFromAllowed = false;
			return t;
		}
	}
}
