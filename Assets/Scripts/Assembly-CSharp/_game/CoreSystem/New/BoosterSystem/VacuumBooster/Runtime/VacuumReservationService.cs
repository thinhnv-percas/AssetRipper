using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x200044E")]
	public class VacuumReservationService
	{
		[Inject(false)]
		[Token(Token = "0x4000DB5")]
		[FieldOffset(Offset = "0x10")]
		private MoldAbsorptionBridge _bridge;

		[Inject(false)]
		[Token(Token = "0x4000DB6")]
		[FieldOffset(Offset = "0x18")]
		private _game.BaseLayerSystems.EntitySystem.Core.EntityManager _moldEm;

		[Inject(false)]
		[Token(Token = "0x4000DB7")]
		[FieldOffset(Offset = "0x20")]
		private VacuumTargetPlanner _planner;

		[Token(Token = "0x600121C")]
		[Address(RVA = "0x3CCA294", Offset = "0x3CCA294", Length = "0x67C")]
		public unsafe bool Reserve(VacuumSession session, float2 mouthPos, int maxParticles, float2 mouthScaleRange, float mouth3DAxisMultiplier)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumReservationService::Reserve");
			return default;
		}

		[Token(Token = "0x600121D")]
		[Address(RVA = "0x3CCBF08", Offset = "0x3CCBF08", Length = "0x280")]
		private unsafe bool MarkGrainForSuction(Unity.Entities.EntityManager em, EntityCommandBuffer ecb, Unity.Entities.Entity grain, float2 mouthScaleRange)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumReservationService::MarkGrainForSuction");
			return default;
		}

		[Token(Token = "0x600121E")]
		[Address(RVA = "0x3CCC188", Offset = "0x3CCC188", Length = "0x8")]
		public VacuumReservationService()
		{
		}
	}
}
