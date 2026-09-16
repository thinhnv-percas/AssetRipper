using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x2000097")]
	public abstract class ABSTweenPlugin<T1, T2, TPlugOptions> : ITweenPlugin where TPlugOptions : struct, IPlugOptions
	{
		[Token(Token = "0x600037D")]
		public abstract void Reset(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x600037E")]
		public abstract void SetFrom(TweenerCore<T1, T2, TPlugOptions> t, bool isRelative);

		[Token(Token = "0x600037F")]
		public abstract void SetFrom(TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately, bool isRelative);

		[Token(Token = "0x6000380")]
		public abstract T2 ConvertToStartValue(TweenerCore<T1, T2, TPlugOptions> t, T1 value);

		[Token(Token = "0x6000381")]
		public abstract void SetRelativeEndValue(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x6000382")]
		public abstract void SetChangeValue(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x6000383")]
		public abstract float GetSpeedBasedDuration(TPlugOptions options, float unitsXSecond, T2 changeValue);

		[Token(Token = "0x6000384")]
		public abstract void EvaluateAndApply(TPlugOptions options, Tween t, bool isRelative, DOGetter<T1> getter, DOSetter<T1> setter, float elapsed, T2 startValue, T2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice);

		[Token(Token = "0x6000385")]
		[Address(RVA = "0xDD0340", Offset = "0xDD0340", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ABSTweenPlugin()
		{
		}
	}
}
