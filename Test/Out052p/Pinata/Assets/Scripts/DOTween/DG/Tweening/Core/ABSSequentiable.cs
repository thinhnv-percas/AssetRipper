using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000048")]
	public abstract class ABSSequentiable
	{
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x10")]
		internal TweenType tweenType;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x14")]
		internal float sequencedPosition;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x18")]
		internal float sequencedEndPosition;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x20")]
		internal TweenCallback onStart;

		[Token(Token = "0x600026F")]
		[Address(RVA = "0x106F300", Offset = "0x106F300", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ABSSequentiable()
		{
		}
	}
}
