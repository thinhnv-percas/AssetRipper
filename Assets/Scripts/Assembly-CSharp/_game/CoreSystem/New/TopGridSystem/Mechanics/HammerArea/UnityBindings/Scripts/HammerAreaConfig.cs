using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Shared.Cover;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts
{
	[CreateAssetMenu(fileName = "HammerAreaConfig", menuName = "SandOut/Hammer Area Config")]
	[Token(Token = "0x2000204")]
	public class HammerAreaConfig : ScriptableObject
	{
		[Tooltip("Hammer area prefabs by footprint. Each prefab root must carry a HammerAreaMono (counter text + fill indicators).")]
		[Token(Token = "0x4000663")]
		[FieldOffset(Offset = "0x18")]
		public List<GarageConfig.CoverEntry> entries;

		[Tooltip("Virtual parent uniform scale tween used by PlayUnderReveal. Mirrors GarageConfig.parentScaleTween.")]
		[Token(Token = "0x4000664")]
		[FieldOffset(Offset = "0x20")]
		public TweenSettings<float> parentScaleTween;

		[Tooltip("World-space Z the spawned hammer area is pinned to (overrides the grid-plane Z), so areas can sit in front of / behind the rest of the top-grid visuals.")]
		[Token(Token = "0x4000665")]
		[FieldOffset(Offset = "0x60")]
		public float spawnDepthZ;

		[Token(Token = "0x600091A")]
		[Address(RVA = "0x3E8D2F8", Offset = "0x3E8D2F8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Shared.Cover.CoverPrefabResolver::GetPrefab(this.entries, width, height, needsRotation);\n\treturn returnVal1;\n")]
		public GameObject GetPrefab(int width, int height, out bool needsRotation)
		{
			needsRotation = default(bool);
			return CoverPrefabResolver.GetPrefab(entries, width, height, out needsRotation);
		}

		[Token(Token = "0x600091B")]
		[Address(RVA = "0x3E8D304", Offset = "0x3E8D304", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tPrimeTween.TweenSettings::.ctor(&v74 @ stack_-A0_v2 (PrimeTween.TweenSettings), 0.4f, 0x1B, 1, 0, 0f, 0f, 0, 0);\n\tv90 = v74;\n\tPrimeTween.TweenSettings`1<System.Single>::.ctor(&v99 @ stack_-E0_v2 (PrimeTween.TweenSettings`1<System.Single>), 0.6f, 1f, &v90 @ stack_-70_v1 (PrimeTween.TweenSettings));\n\tthis.parentScaleTween = v99;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+30]) = 0;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+40]) = 0;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+50]) = 0;\n\tthis.spawnDepthZ = -0.3f;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_0023:\n\tv54 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig+CoverEntry>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig+CoverEntry>::.ctor(v54);\n\tthis.entries = v54;\n")]
		public HammerAreaConfig()
		{
			List<GarageConfig.CoverEntry> list = new List<GarageConfig.CoverEntry>();
			entries = list;
			TweenSettings tweenSettings = new TweenSettings(0.4f, Ease.OutBack);
			TweenSettings settings = tweenSettings;
			TweenSettings<float> tweenSettings2 = new TweenSettings<float>(0.6f, 1f, settings);
			parentScaleTween = tweenSettings2;
			_ = 0;
			_ = 0;
			_ = 0;
			spawnDepthZ = -0.3f;
		}
	}
}
