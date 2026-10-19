using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings
{
	[Serializable]
	[Token(Token = "0x20002B8")]
	public class HammerFlightAnim
	{
		[Header("Flight — position")]
		[Token(Token = "0x4000867")]
		[FieldOffset(Offset = "0x10")]
		public TweenSettings moveSettings;

		[Token(Token = "0x4000868")]
		[FieldOffset(Offset = "0x40")]
		public TweenSettings moveZSettings;

		[Token(Token = "0x4000869")]
		[FieldOffset(Offset = "0x70")]
		public AnimationCurve zCurve;

		[Token(Token = "0x400086A")]
		[FieldOffset(Offset = "0x78")]
		public float zCurveMultiplier;

		[Header("Flight — scale punch")]
		[Token(Token = "0x400086B")]
		[FieldOffset(Offset = "0x80")]
		public TweenSettings keyScaleUpSettings;

		[Token(Token = "0x400086C")]
		[FieldOffset(Offset = "0xB0")]
		public TweenSettings keyScaleBackSettings;

		[Token(Token = "0x400086D")]
		[FieldOffset(Offset = "0xE0")]
		public float keyMaxScale;

		[Header("Flight — rotation")]
		[Token(Token = "0x400086E")]
		[FieldOffset(Offset = "0xE8")]
		public TweenSettings rotateToMidSettings;

		[Token(Token = "0x400086F")]
		[FieldOffset(Offset = "0x118")]
		public TweenSettings rotateToTargetSettings;

		[Token(Token = "0x4000870")]
		[FieldOffset(Offset = "0x148")]
		public Vector3 midRotationEuler;

		[Tooltip("World-space euler the hammer copy lands at. Default (0,0,0) = upright. Use the button below to capture it from a hammer placed in the scene.")]
		[Token(Token = "0x4000871")]
		[FieldOffset(Offset = "0x154")]
		public Vector3 landRotationEuler;

		[Header("Arrival — copy scale down")]
		[Token(Token = "0x4000872")]
		[FieldOffset(Offset = "0x160")]
		public TweenSettings keyScaleDownSettings;

		[Header("Impact VFX")]
		[Tooltip("Spawned at the landing point the moment the hammer copy arrives. Per-variant: normalHit and lastHit can use different impact effects. Null = no VFX.")]
		[Token(Token = "0x4000873")]
		[FieldOffset(Offset = "0x190")]
		public GameObject hitVfx;

		[Token(Token = "0x6000C22")]
		[Address(RVA = "0x3ED0FB8", Offset = "0x3ED0FB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void CaptureLandRotation(Transform t)
		{
		}

		[Token(Token = "0x6000C23")]
		[Address(RVA = "0x3ED0F5C", Offset = "0x3ED0F5C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 0f);\n\tthis.zCurve = v17;\n\tthis.zCurveMultiplier = 1f;\n\tthis.keyMaxScale = 1.5f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerFlightAnim()
		{
			AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);
			zCurve = animationCurve;
			zCurveMultiplier = 1f;
			keyMaxScale = 1.5f;
		}
	}
}
