using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000A0")]
	public abstract class ABSSequentiable
	{
		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x10")]
		internal TweenType tweenType;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x14")]
		internal float sequencedPosition;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x18")]
		internal float sequencedEndPosition;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x20")]
		internal TweenCallback onStart;

		[Token(Token = "0x60003BE")]
		[Address(RVA = "0xC2B404", Offset = "0xC2B404", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ABSSequentiable()
		{
		}
	}
}
