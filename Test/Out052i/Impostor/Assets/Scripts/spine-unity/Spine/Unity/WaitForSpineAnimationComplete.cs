using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000C2")]
	public class WaitForSpineAnimationComplete : WaitForSpineAnimation, IEnumerator
	{
		[Token(Token = "0x60006E1")]
		[Address(RVA = "0x1571B80", Offset = "0x1571B80", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = includeEndEvent == 0;\n\tv21 = ~v13;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, v25);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimationComplete(TrackEntry trackEntry, bool includeEndEvent = false)
		{
			AnimationEventTypes eventsToWaitFor = ((!includeEndEvent) ? AnimationEventTypes.Complete : (AnimationEventTypes.End | AnimationEventTypes.Complete));
			SafeSubscribe(trackEntry, eventsToWaitFor);
		}

		[Token(Token = "0x60006E2")]
		[Address(RVA = "0x1571BC0", Offset = "0x1571BC0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = includeEndEvent == 0;\n\tv14 = ~v9;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_0014;\nL_0014:\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, v33);\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimationComplete NowWaitFor(TrackEntry trackEntry, bool includeEndEvent = false)
		{
			AnimationEventTypes eventsToWaitFor = ((!includeEndEvent) ? AnimationEventTypes.Complete : (AnimationEventTypes.End | AnimationEventTypes.Complete));
			SafeSubscribe(trackEntry, eventsToWaitFor);
			return this;
		}
	}
}
