using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x200003F")]
	public abstract class ABSTweenPlugin<T1, T2, TPlugOptions> : ITweenPlugin where TPlugOptions : struct, IPlugOptions
	{
		[Token(Token = "0x6000234")]
		public abstract void Reset(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x6000235")]
		public abstract void SetFrom(TweenerCore<T1, T2, TPlugOptions> t, bool isRelative);

		[Token(Token = "0x6000236")]
		public abstract void SetFrom(TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately);

		[Token(Token = "0x6000237")]
		public abstract T2 ConvertToStartValue(TweenerCore<T1, T2, TPlugOptions> t, T1 value);

		[Token(Token = "0x6000238")]
		public abstract void SetRelativeEndValue(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x6000239")]
		public abstract void SetChangeValue(TweenerCore<T1, T2, TPlugOptions> t);

		[Token(Token = "0x600023A")]
		public abstract float GetSpeedBasedDuration(TPlugOptions options, float unitsXSecond, T2 changeValue);

		[Token(Token = "0x600023B")]
		public abstract void EvaluateAndApply(TPlugOptions options, Tween t, bool isRelative, DOGetter<T1> getter, DOSetter<T1> setter, float elapsed, T2 startValue, T2 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice);

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xD8BD4C", Offset = "0xD8BD4C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ABSTweenPlugin()
		{
		}
	}
}
