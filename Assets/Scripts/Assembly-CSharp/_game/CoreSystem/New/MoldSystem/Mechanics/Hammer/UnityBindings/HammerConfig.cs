using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings
{
	[CreateAssetMenu(fileName = "HammerConfig", menuName = "SandOut/Hammer Config")]
	[Token(Token = "0x20002B7")]
	public class HammerConfig : ScriptableObject
	{
		[Header("Hammer prefab (placeholder: assign the Key prefab / KeyMono)")]
		[Token(Token = "0x4000860")]
		[FieldOffset(Offset = "0x18")]
		public GameObject hammerMono;

		[Tooltip("Added to the hammer area's world position to get the flight target, so the copy lands slightly off the exact center (e.g. a bit above it).")]
		[Token(Token = "0x4000861")]
		[FieldOffset(Offset = "0x20")]
		public Vector3 targetOffset;

		[Tooltip("Added to the hammer area's center to position the impact VFX (independent of the flight target).")]
		[Token(Token = "0x4000862")]
		[FieldOffset(Offset = "0x2C")]
		public Vector3 vfxOffset;

		[Header("Normal hit — flight animation")]
		[Token(Token = "0x4000863")]
		[FieldOffset(Offset = "0x38")]
		public HammerFlightAnim normalHit;

		[Header("Last hit (opens the hammer area) — flight animation")]
		[Token(Token = "0x4000864")]
		[FieldOffset(Offset = "0x40")]
		public HammerFlightAnim lastHit;

		[Header("Area punch on landing (non-last hits only)")]
		[Tooltip("PunchScale applied to the hammer area when a flying copy finishes its flight, but only when this is NOT the hit that opens the area (last hit plays the open reveal instead).")]
		[Token(Token = "0x4000865")]
		[FieldOffset(Offset = "0x48")]
		public ShakeSettings areaPunchSettings;

		[Header("Camera shake on last hit")]
		[Tooltip("Applied to the main camera when the LAST hit's flying copy finishes its flight (the hit that opens the area). Leave strength at zero to disable.")]
		[Token(Token = "0x4000866")]
		[FieldOffset(Offset = "0x88")]
		public ShakeSettings cameraShakeSettings;

		[Token(Token = "0x6000C21")]
		[Address(RVA = "0x3ED0E48", Offset = "0x3ED0E48", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv49.zCurveMultiplier = 1f;\n\tv49.keyMaxScale = 1.5f;\n\tSystem.Object::.ctor(v49);\n\tthis.normalHit = v49;\n\tv70 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerFlightAnim();\n\tv77 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 0f);\n\tv70.zCurve = v77;\n\tv70.zCurveMultiplier = 1f;\n\tv70.keyMaxScale = 1.5f;\n\tSystem.Object::.ctor(v70);\n\tthis.lastHit = v70;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_0019:\n\tv49 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerFlightAnim();\n\tv56 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 0f);\n\tv49.zCurve = v56;\n")]
		public HammerConfig()
		{
			HammerFlightAnim hammerFlightAnim = new HammerFlightAnim();
			AnimationCurve zCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);
			hammerFlightAnim.zCurve = zCurve;
			hammerFlightAnim.zCurveMultiplier = 1f;
			hammerFlightAnim.keyMaxScale = 1.5f;
			normalHit = hammerFlightAnim;
			HammerFlightAnim hammerFlightAnim2 = new HammerFlightAnim();
			AnimationCurve zCurve2 = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);
			hammerFlightAnim2.zCurve = zCurve2;
			hammerFlightAnim2.zCurveMultiplier = 1f;
			hammerFlightAnim2.keyMaxScale = 1.5f;
			lastHit = hammerFlightAnim2;
		}
	}
}
