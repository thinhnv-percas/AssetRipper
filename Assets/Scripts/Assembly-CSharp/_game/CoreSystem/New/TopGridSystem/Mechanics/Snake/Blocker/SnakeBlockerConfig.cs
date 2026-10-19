using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker
{
	[CreateAssetMenu(fileName = "SnakeBlockerConfig", menuName = "SandOut/SnakeBlockerConfig")]
	[Token(Token = "0x2000180")]
	public class SnakeBlockerConfig : ScriptableObject
	{
		[Header("Path piece prefabs")]
		[Tooltip("Closed cap at the back-of-body cell (path[N-1]).")]
		[Token(Token = "0x40004AC")]
		[FieldOffset(Offset = "0x18")]
		public GameObject tailendPrefab;

		[Tooltip("Straight middle segment between head and tail.")]
		[Token(Token = "0x40004AD")]
		[FieldOffset(Offset = "0x20")]
		public GameObject middlePrefab;

		[Tooltip("Corner segment where the path bends 90 degrees.")]
		[Token(Token = "0x40004AE")]
		[FieldOffset(Offset = "0x28")]
		public GameObject cornerPrefab;

		[Tooltip("Direction arrow overlaid on each body segment, pointing toward the head.")]
		[Token(Token = "0x40004AF")]
		[FieldOffset(Offset = "0x30")]
		public GameObject arrowPrefab;

		[Tooltip("Ramp placed at the head cell (path[0]), oriented away from the body.")]
		[Token(Token = "0x40004B0")]
		[FieldOffset(Offset = "0x38")]
		public GameObject rampPrefab;

		[Header("Body cube transform")]
		[Tooltip("Scale multiplier applied to body cube visuals; head stays at full size. Body cubes spawn at this reduced scale and PlayFall scales them back up when a body cube becomes the new head.")]
		[Range(0.1f, 1f)]
		[Token(Token = "0x40004B1")]
		[FieldOffset(Offset = "0x40")]
		public float bodyScaleRatio;

		[Tooltip("Local Z offset applied to body cube visuals (negative = toward camera in this 2D layout). Preserved during body→body lateral shifts; PlayFall returns to Z = 0 when a body cube ascends to head.")]
		[Token(Token = "0x40004B2")]
		[FieldOffset(Offset = "0x44")]
		public float bodyZOffset;

		[Header("Chain root (highlight)")]
		[Tooltip("Root prefab the chain is built under. Must carry a HighlightEffect (effectGroup = Children, highlighted = true) so every spawned piece is highlighted. Required; if unassigned the chain falls back to a bare root (no highlight) and logs an error.")]
		[Token(Token = "0x40004B3")]
		[FieldOffset(Offset = "0x48")]
		public GameObject chainRootPrefab;

		[Header("Chain piece transform")]
		[Tooltip("Local Z offset applied to the chain root (negative = toward camera).")]
		[Token(Token = "0x40004B4")]
		[FieldOffset(Offset = "0x50")]
		public float pieceZOffset;

		[Tooltip("Uniform scale multiplier applied to the chain root on top of cellSize. Use this to close visible gaps when piece meshes are authored smaller than 1 unit per cell.")]
		[Range(0.5f, 2f)]
		[Token(Token = "0x40004B5")]
		[FieldOffset(Offset = "0x54")]
		public float pieceScaleMultiplier;

		[Header("Shift animation")]
		[Tooltip("Tween used by every body cube slide after a head pour. duration + ease drive each cube's motion; startDelay shifts the wave start. Distinct from moduleShiftTween so cube wave and chain recede can use different easings.")]
		[Token(Token = "0x40004B6")]
		[FieldOffset(Offset = "0x58")]
		public TweenSettings cubeShiftTween;

		[Tooltip("Tween used by the chain tailend recede slide. The slide is offset to land in sync with the last cube's slide.")]
		[Token(Token = "0x40004B7")]
		[FieldOffset(Offset = "0x88")]
		public TweenSettings moduleShiftTween;

		[Tooltip("Per-segment wave delay between cube body slides. Cube i shifts at cubeShiftTween.startDelay + i * shiftStepDelay.")]
		[Min(0f)]
		[Token(Token = "0x40004B8")]
		[FieldOffset(Offset = "0xB8")]
		public float shiftStepDelay;

		[Header("Rebuild reaction")]
		[Tooltip("Delay between a head pour and the chain rebuild. Old chain stays visible until this delay elapses, then diff/respawn (or tail-recede slide) runs. 0 = rebuild same frame as cube break.")]
		[Min(0f)]
		[Token(Token = "0x40004B9")]
		[FieldOffset(Offset = "0xBC")]
		public float rebuildDelay;

		[Header("Fall animation (body cube ascending to head slot)")]
		[Tooltip("Z arc curve evaluated over PlayFall's normalized time; multiplied by fallZMultiplier and added on top of the Z lerp.")]
		[Token(Token = "0x40004BA")]
		[FieldOffset(Offset = "0xC0")]
		public AnimationCurve fallZCurve;

		[Tooltip("Tween controlling the Z (arc) leg of PlayFall. Its duration defines the landing moment used to time tracker attach.")]
		[Token(Token = "0x40004BB")]
		[FieldOffset(Offset = "0xC8")]
		public TweenSettings fallMoveZSettings;

		[Tooltip("Multiplier applied to fallZCurve.Evaluate(t) before adding to the Z lerp.")]
		[Token(Token = "0x40004BC")]
		[FieldOffset(Offset = "0xF8")]
		public float fallZMultiplier;

		[Tooltip("Tween controlling the lateral X/Y motion during PlayFall.")]
		[Token(Token = "0x40004BD")]
		[FieldOffset(Offset = "0x100")]
		public TweenSettings fallMoveXYSettings;

		[Tooltip("Tween controlling the uniform scale-up during PlayFall (body cube returns to head-size).")]
		[Token(Token = "0x40004BE")]
		[FieldOffset(Offset = "0x130")]
		public TweenSettings fallScaleSettings;

		[Tooltip("Optional particle prefab spawned mid-flight at the landing position.")]
		[Token(Token = "0x40004BF")]
		[FieldOffset(Offset = "0x160")]
		public GameObject fallParticle;

		[Tooltip("Delay (seconds) from PlayFall start to particle spawn.")]
		[Min(0f)]
		[Token(Token = "0x40004C0")]
		[FieldOffset(Offset = "0x168")]
		public float fallParticleInsertTime;

		[Token(Token = "0x6000731")]
		[Address(RVA = "0x3E62218", Offset = "0x3E62218", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis.moduleShiftTween = v81;\n\tthis.moduleShiftTween.cycles = 0;\n\tthis.moduleShiftTween.useUnscaledTime = 0;\n\t// 83 NotImplemented \"Instruction DUP not yet implemented.\"\n\tthis.shiftStepDelay = 0f;\n\t// 87 NewArr v101 @ X0_v9 (UnityEngine.Keyframe[]), typeof(UnityEngine.Keyframe[]), 3\n\tv104 = 0;\n\tv105 = 0;\n\tv106 = 0;\n\tUnityEngine.Keyframe::.ctor(&v108 @ stack_-C0_v2 (UnityEngine.Keyframe), 0f, 0f);\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+20]) = v108;\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+2C]) = v184;\n\tUnityEngine.Keyframe::.ctor(&v190 @ stack_-E0_v4 (UnityEngine.Keyframe), 0.5f, -1f);\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+54]) = 0;\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+4C]) = 0;\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+3C]) = v190;\n\tUnityEngine.Keyframe::.ctor(&v202 @ stack_-100_v4 (UnityEngine.Keyframe), 1f, 0f);\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+70]) = 0;\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+68]) = 0;\n\t*([v101 @ X0_v9 (UnityEngine.Keyframe[])+58]) = v202;\n\tv317 = new UnityEngine.AnimationCurve();\n\tUnityEngine.AnimationCurve::.ctor(v317, v101);\n\tthis.fallZCurve = v317;\n\tPrimeTween.TweenSettings::.ctor(&v247 @ stack_-130_v2 (PrimeTween.TweenSettings), 0.4f, 6, 1, 0, 0f, 0f, 0, 0);\n\tthis.fallMoveZSettings = v247;\n\tthis.fallMoveZSettings.cycles = 0;\n\tthis.fallMoveZSettings.useUnscaledTime = 0;\n\tthis.fallZMultiplier = 1f;\n\tPrimeTween.TweenSettings::.ctor(&v236 @ stack_-160_v2 (PrimeTween.TweenSettings), 0.4f, 6, 1, 0, 0f, 0f, 0, 0);\n\tthis.fallMoveXYSettings = v236;\n\tthis.fallMoveXYSettings.cycles = 0;\n\tthis.fallMoveXYSettings.useUnscaledTime = 0;\n\tPrimeTween.TweenSettings::.ctor(&v227 @ stack_-190_v2 (PrimeTween.TweenSettings), 0.4f, 6, 1, 0, 0f, 0f, 0, 0);\n\tthis.fallScaleSettings = v227;\n\tthis.fallScaleSettings.cycles = 0;\n\tthis.fallScaleSettings.useUnscaledTime = 0;\n\tthis.fallParticleInsertTime = 0.4f;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001D:\n\tthis.bodyScaleRatio = -3.433228351568118E-06d;\n\tthis.pieceZOffset = 0.007812505558831617d;\n\tPrimeTween.TweenSettings::.ctor(&v58 @ stack_-70_v2 (PrimeTween.TweenSettings), 0.25f, 6, 1, 0, 0f, 0f, 0, 0);\n\tthis.cubeShiftTween = v58;\n\tthis.cubeShiftTween.cycles = 0;\n\tthis.cubeShiftTween.useUnscaledTime = 0;\n\tPrimeTween.TweenSettings::.ctor(&v81 @ stack_-A0_v2 (PrimeTween.TweenSettings), 0.25f, 6, 1, 0, 0f, 0f, 0, 0);\n")]
		public SnakeBlockerConfig()
		{
			bodyScaleRatio = 0.65f;
			bodyZOffset = -0.4f;
			pieceZOffset = -0.5f;
			pieceScaleMultiplier = 1f;
			TweenSettings tweenSettings = new TweenSettings(0.25f, Ease.OutQuad);
			cubeShiftTween = tweenSettings;
			cubeShiftTween.cycles = 0;
			cubeShiftTween.useUnscaledTime = false;
			TweenSettings tweenSettings2 = new TweenSettings(0.25f, Ease.OutQuad);
			moduleShiftTween = tweenSettings2;
			moduleShiftTween.cycles = 0;
			moduleShiftTween.useUnscaledTime = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			shiftStepDelay = 0f;
			Keyframe[] keys = new Keyframe[3];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			Keyframe keyframe = new Keyframe(0f, 0f);
			Keyframe keyframe2 = new Keyframe(0.5f, -1f);
			_ = 0;
			_ = 0;
			Keyframe keyframe3 = new Keyframe(1f, 0f);
			_ = 0;
			_ = 0;
			AnimationCurve animationCurve = new AnimationCurve(keys);
			fallZCurve = animationCurve;
			TweenSettings tweenSettings3 = new TweenSettings(0.4f, Ease.OutQuad);
			fallMoveZSettings = tweenSettings3;
			fallMoveZSettings.cycles = 0;
			fallMoveZSettings.useUnscaledTime = false;
			fallZMultiplier = 1f;
			TweenSettings tweenSettings4 = new TweenSettings(0.4f, Ease.OutQuad);
			fallMoveXYSettings = tweenSettings4;
			fallMoveXYSettings.cycles = 0;
			fallMoveXYSettings.useUnscaledTime = false;
			TweenSettings tweenSettings5 = new TweenSettings(0.4f, Ease.OutQuad);
			fallScaleSettings = tweenSettings5;
			fallScaleSettings.cycles = 0;
			fallScaleSettings.useUnscaledTime = false;
			fallParticleInsertTime = 0.4f;
		}
	}
}
