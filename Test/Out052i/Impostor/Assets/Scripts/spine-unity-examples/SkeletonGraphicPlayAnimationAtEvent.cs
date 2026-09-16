using AssetRipperInjected;
using Cpp2ILInjected;
using Spine;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x2000005")]
public class SkeletonGraphicPlayAnimationAtEvent : MonoBehaviour
{
	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x20")]
	public SkeletonGraphic skeletonGraphic;

	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x28")]
	public int trackIndex;

	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x2C")]
	public float playbackSpeed;

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x1508734", Offset = "0x1508734", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.skeletonGraphic;\n\tv23 = Spine.AnimationState::SetAnimation(v4.state, this.trackIndex, animation, 1);\n\tv23.timeScale = this.playbackSpeed;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayAnimationLooping(string animation)
	{
		SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
		TrackEntry trackEntry = skeletonGraphic.AnimationState.SetAnimation(trackIndex, animation, loop: true);
		trackEntry.TimeScale = playbackSpeed;
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x1508778", Offset = "0x1508778", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.skeletonGraphic;\n\tv23 = Spine.AnimationState::SetAnimation(v4.state, this.trackIndex, animation, 0);\n\tv23.timeScale = this.playbackSpeed;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayAnimationOnce(string animation)
	{
		SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
		TrackEntry trackEntry = skeletonGraphic.AnimationState.SetAnimation(trackIndex, animation, loop: false);
		trackEntry.TimeScale = playbackSpeed;
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x15087BC", Offset = "0x15087BC", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.skeletonGraphic;\n\tSpine.AnimationState::ClearTrack(v2.state, this.trackIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ClearTrack()
	{
		SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
		skeletonGraphic.AnimationState.ClearTrack(trackIndex);
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x15087E8", Offset = "0x15087E8", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.playbackSpeed = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SkeletonGraphicPlayAnimationAtEvent()
	{
		playbackSpeed = 1f;
	}
}
