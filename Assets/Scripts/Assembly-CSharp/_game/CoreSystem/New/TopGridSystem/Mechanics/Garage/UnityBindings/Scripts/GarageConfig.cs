using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Shared.Cover;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts
{
	[CreateAssetMenu(fileName = "BlockerCoverConfig", menuName = "SandOut/Blocker Cover Config")]
	[Token(Token = "0x200021D")]
	public class GarageConfig : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x200021E")]
		public class CoverEntry
		{
			[Tooltip("Always store the larger dimension as width (width >= height)")]
			[Token(Token = "0x4000697")]
			[FieldOffset(Offset = "0x10")]
			public int width;

			[Token(Token = "0x4000698")]
			[FieldOffset(Offset = "0x14")]
			public int height;

			[Token(Token = "0x4000699")]
			[FieldOffset(Offset = "0x18")]
			public GameObject prefab;

			[Token(Token = "0x6000964")]
			[Address(RVA = "0x3E92EB8", Offset = "0x3E92EB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public CoverEntry()
			{
			}
		}

		[Token(Token = "0x4000695")]
		[FieldOffset(Offset = "0x18")]
		public List<CoverEntry> entries;

		[Tooltip("Virtual parent uniform scale tween. Cubes are temporarily re-parented to a transform pivoted at their geometric center; this drives that pivot from startValue -> endValue, producing the center-to-corners spread feel.")]
		[Token(Token = "0x4000696")]
		[FieldOffset(Offset = "0x20")]
		public TweenSettings<float> parentScaleTween;

		[Token(Token = "0x6000962")]
		[Address(RVA = "0x3E92D60", Offset = "0x3E92D60", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Shared.Cover.CoverPrefabResolver::GetPrefab(this.entries, width, height, needsRotation);\n\treturn returnVal1;\n")]
		public GameObject GetPrefab(int width, int height, out bool needsRotation)
		{
			needsRotation = default(bool);
			return CoverPrefabResolver.GetPrefab(entries, width, height, out needsRotation);
		}

		[Token(Token = "0x6000963")]
		[Address(RVA = "0x3E92D6C", Offset = "0x3E92D6C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tPrimeTween.TweenSettings::.ctor(&v74 @ stack_-A0_v2 (PrimeTween.TweenSettings), 0.4f, 0x1B, 1, 0, 0f, 0f, 0, 0);\n\tv90 = v74;\n\tPrimeTween.TweenSettings`1<System.Single>::.ctor(&v99 @ stack_-E0_v2 (PrimeTween.TweenSettings`1<System.Single>), 0.6f, 1f, &v90 @ stack_-70_v1 (PrimeTween.TweenSettings));\n\tthis.parentScaleTween = v99;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+30]) = 0;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+40]) = 0;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+50]) = 0;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_0023:\n\tv54 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig+CoverEntry>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig+CoverEntry>::.ctor(v54);\n\tthis.entries = v54;\n")]
		public GarageConfig()
		{
			List<CoverEntry> list = new List<CoverEntry>();
			entries = list;
			TweenSettings tweenSettings = new TweenSettings(0.4f, Ease.OutBack);
			TweenSettings settings = tweenSettings;
			TweenSettings<float> tweenSettings2 = new TweenSettings<float>(0.6f, 1f, settings);
			parentScaleTween = tweenSettings2;
			_ = 0;
			_ = 0;
			_ = 0;
		}
	}
}
