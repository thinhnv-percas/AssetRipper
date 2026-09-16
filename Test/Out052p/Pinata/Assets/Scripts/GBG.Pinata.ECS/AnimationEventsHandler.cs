using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using UnityEngine;

[Token(Token = "0x2000004")]
public class AnimationEventsHandler : MonoBehaviour
{
	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x18")]
	public GlobalEvent animationEventBegin;

	[Token(Token = "0x400000A")]
	[FieldOffset(Offset = "0x20")]
	public GlobalEvent animationEventEnd;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0xCBE704", Offset = "0xCBE704", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.animationEventBegin);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AnimationBegin()
	{
		animationEventBegin.Publish();
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0xCBE720", Offset = "0xCBE720", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.animationEventEnd);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AnimationEnd()
	{
		animationEventEnd.Publish();
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0xCBE73C", Offset = "0xCBE73C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public void Update()
	{
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0xCBE740", Offset = "0xCBE740", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AnimationEventsHandler()
	{
	}
}
