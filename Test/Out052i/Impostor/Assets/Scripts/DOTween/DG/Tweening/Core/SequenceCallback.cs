using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B4")]
	internal class SequenceCallback : ABSSequentiable
	{
		[Token(Token = "0x600042A")]
		[Address(RVA = "0xC2E16C", Offset = "0xC2E16C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Core.ABSSequentiable::.ctor(this);\n\tthis.sequencedPosition = sequencedPosition;\n\tthis.tweenType = 2;\n\tthis.onStart = callback;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SequenceCallback(float sequencedPosition, TweenCallback callback)
		{
			base.sequencedPosition = sequencedPosition;
			tweenType = TweenType.Callback;
			onStart = callback;
		}
	}
}
