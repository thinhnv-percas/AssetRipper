using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000423")]
	public class FailSnapshotBuilder
	{
		[Token(Token = "0x2000424")]
		internal struct MoldFront
		{
			[Token(Token = "0x4000D0C")]
			[FieldOffset(Offset = "0x0")]
			public bool Valid;

			[Token(Token = "0x4000D0D")]
			[FieldOffset(Offset = "0x1")]
			public bool Accepting;

			[Token(Token = "0x4000D0E")]
			[FieldOffset(Offset = "0x4")]
			public GameColor Color;
		}

		[Token(Token = "0x4000D06")]
		private const int MaxColumns = 16;

		[Inject(false)]
		[Token(Token = "0x4000D07")]
		[FieldOffset(Offset = "0x10")]
		private _game.BaseLayerSystems.EntitySystem.Core.EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000D08")]
		[FieldOffset(Offset = "0x18")]
		private MoldGridHandler _moldGrid;

		[Inject(false)]
		[Token(Token = "0x4000D09")]
		[FieldOffset(Offset = "0x20")]
		private ConveyorController _conveyor;

		[Token(Token = "0x4000D0A")]
		[FieldOffset(Offset = "0x28")]
		private IReadOnlyList<IPourableBlockCondition> _blockConditions;

		[Token(Token = "0x4000D0B")]
		[FieldOffset(Offset = "0x30")]
		internal readonly MoldFront[] _fronts;

		[Inject(false)]
		[Token(Token = "0x6001150")]
		[Address(RVA = "0x3CBEE78", Offset = "0x3CBEE78", Length = "0x90")]
		public void Construct(IEnumerable<IPourableBlockCondition> blockConditions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSnapshotBuilder::Construct");
		}

		[Token(Token = "0x6001151")]
		[Address(RVA = "0x3CBEBA8", Offset = "0x3CBEBA8", Length = "0xF4")]
		public GameStateSnapshot Build()
		{
			bool conveyorAtCapacity;
			if (_conveyor != null)
			{
				ConveyorController conveyor = _conveyor;
				conveyorAtCapacity = conveyor.IsGateClosed;
			}
			else
			{
				conveyorAtCapacity = false;
			}
			GameStateSnapshot s = default(GameStateSnapshot);
			s.ConveyorAtCapacity = conveyorAtCapacity;
			int columns = BuildFrontRowCache();
			bool flag = AnyBreakableCube();
			ScanParticles(columns, ref s);
			return s;
		}

		[Token(Token = "0x6001152")]
		[Address(RVA = "0x3CBEF08", Offset = "0x3CBEF08", Length = "0x1F8")]
		private int BuildFrontRowCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSnapshotBuilder::BuildFrontRowCache");
			return default;
		}

		[Token(Token = "0x6001153")]
		[Address(RVA = "0x3CBF100", Offset = "0x3CBF100", Length = "0x400")]
		private bool AnyBreakableCube()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSnapshotBuilder::AnyBreakableCube");
			return default;
		}

		[Token(Token = "0x6001154")]
		[Address(RVA = "0x3CBF500", Offset = "0x3CBF500", Length = "0x4C4")]
		private unsafe void ScanParticles(int columns, ref GameStateSnapshot s)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSnapshotBuilder::ScanParticles");
		}

		[Token(Token = "0x6001155")]
		[Address(RVA = "0x3CBD934", Offset = "0x3CBD934", Length = "0x70")]
		public FailSnapshotBuilder()
		{
			MoldFront[] fronts = new MoldFront[16];
			_fronts = fronts;
		}
	}
}
