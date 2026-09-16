using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace DG.Tweening.Core
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x742B60", Offset = "0x742B60")]
	[Token(Token = "0x200000A")]
	public abstract class ABSAnimationComponent : MonoBehaviour
	{
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x18")]
		public UpdateType updateType;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x1C")]
		public bool isSpeedBased;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x1D")]
		public bool hasOnStart;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x1E")]
		public bool hasOnPlay;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x1F")]
		public bool hasOnUpdate;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x20")]
		public bool hasOnStepComplete;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x21")]
		public bool hasOnComplete;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x22")]
		public bool hasOnTweenCreated;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x23")]
		public bool hasOnRewind;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x28")]
		public UnityEvent onStart;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x30")]
		public UnityEvent onPlay;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x38")]
		public UnityEvent onUpdate;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x40")]
		public UnityEvent onStepComplete;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x48")]
		public UnityEvent onComplete;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x50")]
		public UnityEvent onTweenCreated;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x58")]
		public UnityEvent onRewind;

		[NonSerialized]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x60")]
		public Tween tween;

		[Token(Token = "0x6000028")]
		public abstract void DOPlay();

		[Token(Token = "0x6000029")]
		public abstract void DOPlayBackwards();

		[Token(Token = "0x600002A")]
		public abstract void DOPlayForward();

		[Token(Token = "0x600002B")]
		public abstract void DOPause();

		[Token(Token = "0x600002C")]
		public abstract void DOTogglePause();

		[Token(Token = "0x600002D")]
		public abstract void DORewind();

		[Token(Token = "0x600002E")]
		public abstract void DORestart();

		[Token(Token = "0x600002F")]
		public abstract void DORestart(bool fromHere);

		[Token(Token = "0x6000030")]
		public abstract void DOComplete();

		[Token(Token = "0x6000031")]
		public abstract void DOKill();

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x163B440", Offset = "0x163B440", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ABSAnimationComponent()
		{
		}
	}
}
