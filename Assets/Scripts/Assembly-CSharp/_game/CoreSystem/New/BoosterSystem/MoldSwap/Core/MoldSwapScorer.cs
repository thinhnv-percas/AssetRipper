using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Configs;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Core.Data;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.ECS;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core
{
	[Token(Token = "0x200048A")]
	public class MoldSwapScorer
	{
		[Token(Token = "0x4000EC3")]
		private const int ColorCount = 13;

		[Token(Token = "0x4000EC4")]
		private const float WeightConveyorMin = 2.5f;

		[Token(Token = "0x4000EC5")]
		private const float WeightConveyorMax = 6f;

		[Token(Token = "0x4000EC6")]
		private const float WeightParticle = 2f;

		[Token(Token = "0x4000EC7")]
		private const float WeightCube = 1f;

		[Token(Token = "0x4000EC8")]
		private const float WeightNeighborCube = 0.1f;

		[Token(Token = "0x4000EC9")]
		private const float DiversityDecay = 0.5f;

		[Token(Token = "0x4000ECA")]
		private const int FallbackParticlesPerCube = 120;

		[Token(Token = "0x4000ECB")]
		private const float HammerScore = 1E+12f;

		[Inject(false)]
		[Token(Token = "0x4000ECC")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000ECD")]
		[FieldOffset(Offset = "0x18")]
		private MoldSwapConfigSO _config;

		[Inject(true)]
		[Token(Token = "0x4000ECE")]
		[FieldOffset(Offset = "0x20")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(true)]
		[Token(Token = "0x4000ECF")]
		[FieldOffset(Offset = "0x28")]
		private SandParticleQueries _particleQueries;

		[Inject(true)]
		[Token(Token = "0x4000ED0")]
		[FieldOffset(Offset = "0x30")]
		private TopGridHandler _topGridHandler;

		[Token(Token = "0x60012DF")]
		[Address(RVA = "0x3CDD990", Offset = "0x3CDD990", Length = "0x1C")]
		public SwapPlan Calculate()
		{
			MoldSwapConfigSO config = _config;
			return Calculate(config.alwaysSwap);
		}

		[Token(Token = "0x60012E0")]
		[Address(RVA = "0x3CD98E4", Offset = "0x3CD98E4", Length = "0x9C4")]
		public SwapPlan Calculate(bool alwaysSwap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::Calculate");
			return default;
		}

		[Token(Token = "0x60012E1")]
		[Address(RVA = "0x3CDE308", Offset = "0x3CDE308", Length = "0x9D0")]
		private unsafe List<Entity> BuildFrontList(IReadOnlyList<Entity> molds, float[] supply, float[] spp, StringBuilder diag)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::BuildFrontList");
			return default;
		}

		[Token(Token = "0x60012E2")]
		[Address(RVA = "0x3CDECD8", Offset = "0x3CDECD8", Length = "0xB00")]
		private unsafe List<Entity> BuildCandidateList(IReadOnlyList<Entity> molds, float[] supply, float[] spp, StringBuilder diag)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::BuildCandidateList");
			return default;
		}

		[Token(Token = "0x60012E3")]
		[Address(RVA = "0x3CDF7D8", Offset = "0x3CDF7D8", Length = "0x115C")]
		private unsafe void Match(List<Entity> front, List<Entity> candidates, float[] supply, float[] spp, SwapPlan plan, bool alwaysSwap, StringBuilder diag)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::Match");
		}

		[Token(Token = "0x60012E4")]
		[Address(RVA = "0x3CE0934", Offset = "0x3CE0934", Length = "0x170")]
		private float ScoreEntity(Entity entity, float[] supply, float[] spp)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::ScoreEntity");
			return default;
		}

		[Token(Token = "0x60012E5")]
		[Address(RVA = "0x3CDDA38", Offset = "0x3CDDA38", Length = "0x8D0")]
		private unsafe float[] BuildColorScores(StringBuilder diag, float[] supply)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::BuildColorScores");
			return default;
		}

		[Token(Token = "0x60012E6")]
		[Address(RVA = "0x3CE0AA4", Offset = "0x3CE0AA4", Length = "0x760")]
		private void AccumulateCubeSupply(float[] scores, float[] supply, float[] cubeContrib, float[] neighborContrib)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapScorer::AccumulateCubeSupply");
		}

		[Token(Token = "0x60012E7")]
		[Address(RVA = "0x3CD796C", Offset = "0x3CD796C", Length = "0x8")]
		public MoldSwapScorer()
		{
		}
	}
}
