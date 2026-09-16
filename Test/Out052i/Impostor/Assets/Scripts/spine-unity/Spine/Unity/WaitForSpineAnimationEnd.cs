using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000C3")]
	public class WaitForSpineAnimationEnd : WaitForSpineAnimation, IEnumerator
	{
		[Token(Token = "0x60006E3")]
		[Address(RVA = "0x1571BF0", Offset = "0x1571BF0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, 4);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimationEnd(TrackEntry trackEntry)
		{
			SafeSubscribe(trackEntry, AnimationEventTypes.End);
		}

		[Token(Token = "0x60006E4")]
		[Address(RVA = "0x1571C20", Offset = "0x1571C20", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, 4);\n\treturn this;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimationEnd NowWaitFor(TrackEntry trackEntry)
		{
			SafeSubscribe(trackEntry, AnimationEventTypes.End);
			return this;
		}
	}
}
