using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.Shared.Components;

namespace _game.CoreSystem.New.BoosterSystem.ForcePour.Core
{
	[Token(Token = "0x2000494")]
	public class ForcePourTargeter
	{
		[Token(Token = "0x2000495")]
		public struct MoldTarget
		{
			[Token(Token = "0x4000F20")]
			[FieldOffset(Offset = "0x0")]
			public int entityId;

			[Token(Token = "0x4000F21")]
			[FieldOffset(Offset = "0x4")]
			public int remainingNeed;

			[Token(Token = "0x4000F22")]
			[FieldOffset(Offset = "0x8")]
			public int row;

			[Token(Token = "0x4000F23")]
			[FieldOffset(Offset = "0xC")]
			public int col;
		}

		[Token(Token = "0x2000496")]
		public struct EntityCount
		{
			[Token(Token = "0x4000F24")]
			[FieldOffset(Offset = "0x0")]
			public int entityId;

			[Token(Token = "0x4000F25")]
			[FieldOffset(Offset = "0x4")]
			public int count;
		}

		[Inject(false)]
		[Token(Token = "0x4000F1E")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000F1F")]
		[FieldOffset(Offset = "0x18")]
		private MoldAbsorptionBridge _absorptionBridge;

		[Token(Token = "0x600131C")]
		[Address(RVA = "0x3CE6110", Offset = "0x3CE6110", Length = "0x424")]
		public unsafe List<MoldTarget> FindTargets(GameColor color, int maxTargets = 2147483647, bool sortByLeastRemaining = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTargeter::FindTargets");
			return default;
		}

		[Token(Token = "0x600131D")]
		[Address(RVA = "0x3CE653C", Offset = "0x3CE653C", Length = "0x234")]
		public bool HasAnyTarget(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTargeter::HasAnyTarget");
			return default;
		}

		[Token(Token = "0x600131E")]
		[Address(RVA = "0x3CE6770", Offset = "0x3CE6770", Length = "0x25C")]
		public List<EntityCount> ClaimSlots(List<MoldTarget> targets, GameColor color, int totalParticles)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTargeter::ClaimSlots");
			return default;
		}

		[Token(Token = "0x600131F")]
		[Address(RVA = "0x3CE69CC", Offset = "0x3CE69CC", Length = "0x8")]
		public ForcePourTargeter()
		{
		}
	}
}
