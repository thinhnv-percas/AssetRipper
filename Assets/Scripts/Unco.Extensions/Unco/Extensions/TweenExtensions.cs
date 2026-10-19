using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;

namespace Unco.Extensions
{
	[Token(Token = "0x200001C")]
	public static class TweenExtensions
	{
		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x81AB4F0", Offset = "0x81AB4F0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = PrimeTween.Tween::Delay(duration, callback, ignoreTimeScale, 1);\n\treturn returnVal1;\n")]
		public static Tween DelayedCall_scaled(float duration, Action callback, bool ignoreTimeScale = false)
		{
			return Tween.Delay(duration, callback, ignoreTimeScale);
		}
	}
}
