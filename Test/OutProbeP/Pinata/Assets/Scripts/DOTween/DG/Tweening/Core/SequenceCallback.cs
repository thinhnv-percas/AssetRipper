using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000051")]
	internal class SequenceCallback : ABSSequentiable
	{
		[Token(Token = "0x60002AA")]
		[Address(RVA = "0x1075BD8", Offset = "0x1075BD8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.sequencedPosition = sequencedPosition;\n\tthis.tweenType = 2;\n\tthis.onStart = callback;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SequenceCallback(float sequencedPosition, TweenCallback callback)
		{
			base.sequencedPosition = sequencedPosition;
			tweenType = TweenType.Callback;
			onStart = callback;
		}
	}
}
