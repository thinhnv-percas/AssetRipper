using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.ForcePour.Configs
{
	[CreateAssetMenu(fileName = "ForcePourConfig", menuName = "Sand Out/ForcePour/Config")]
	[Token(Token = "0x2000499")]
	public class ForcePourConfigSO : ScriptableObject
	{
		[Header("Absorption Arc")]
		[Token(Token = "0x4000F2E")]
		[FieldOffset(Offset = "0x18")]
		public ForcePourAbsorptionProfile absorptionProfile;

		[Header("Timing")]
		[Tooltip("Duration over which particle spawns are staggered (negative progress at start of arc).")]
		[Token(Token = "0x4000F2F")]
		[FieldOffset(Offset = "0x34")]
		public float staggerDuration;

		[Tooltip("Random jitter added to per-particle stagger for organic variation.")]
		[Token(Token = "0x4000F30")]
		[FieldOffset(Offset = "0x38")]
		public float staggerJitter;

		[Tooltip("Delay between cube tap and the actual break — covers hammer swing animation.")]
		[Token(Token = "0x4000F31")]
		[FieldOffset(Offset = "0x3C")]
		public float hammerSwingDelay;

		[Tooltip("After execute, keep other booster buttons (swap/vacuum) blocked for this many seconds so the player can't fire a swap that would destroy our in-flight absorbing particles before they arrive.")]
		[Token(Token = "0x4000F32")]
		[FieldOffset(Offset = "0x40")]
		public float postExecuteOtherBoosterBlockDuration;

		[Header("Prefabs")]
		[Tooltip("Indicator overlay shown on each eligible cube during Selecting state.")]
		[Token(Token = "0x4000F33")]
		[FieldOffset(Offset = "0x48")]
		public GameObject overlayIndicatorPrefab;

		[Tooltip("Hammer prefab spawned over the targeted cube before break.")]
		[Token(Token = "0x4000F34")]
		[FieldOffset(Offset = "0x50")]
		public GameObject hammerPrefab;

		[Tooltip("Particle effect spawned on hammer impact.")]
		[Token(Token = "0x4000F35")]
		[FieldOffset(Offset = "0x58")]
		public GameObject hammerHitParticlePrefab;

		[Header("Hammer Spawn")]
		[Token(Token = "0x4000F36")]
		[FieldOffset(Offset = "0x60")]
		public Vector3 hammerOffset;

		[Header("Particle Layout")]
		[Tooltip("Z depth used when no SandRenderingAssets z value is available.")]
		[Token(Token = "0x4000F37")]
		[FieldOffset(Offset = "0x6C")]
		public float fallbackParticleDepthZ;

		[Token(Token = "0x6001323")]
		[Address(RVA = "0x3CE6A80", Offset = "0x3CE6A80", Length = "0x48")]
		public ForcePourConfigSO()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourConfigSO::.ctor");
		}
	}
}
