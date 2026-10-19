using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003DD")]
	public sealed class ConveyorSettleProbe
	{
		[Token(Token = "0x20003DE")]
		internal struct MoldFront
		{
			[Token(Token = "0x4000C1E")]
			[FieldOffset(Offset = "0x0")]
			public bool Valid;

			[Token(Token = "0x4000C1F")]
			[FieldOffset(Offset = "0x1")]
			public bool Accepting;

			[Token(Token = "0x4000C20")]
			[FieldOffset(Offset = "0x4")]
			public GameColor Color;
		}

		[Token(Token = "0x4000C1A")]
		private const int MaxColumns = 16;

		[Inject(false)]
		[Token(Token = "0x4000C1B")]
		[FieldOffset(Offset = "0x10")]
		private _game.BaseLayerSystems.EntitySystem.Core.EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000C1C")]
		[FieldOffset(Offset = "0x18")]
		private MoldGridHandler _moldGrid;

		[Token(Token = "0x4000C1D")]
		[FieldOffset(Offset = "0x20")]
		internal readonly MoldFront[] _fronts;

		[Token(Token = "0x6001040")]
		[Address(RVA = "0x3CAEC24", Offset = "0x3CAEC24", Length = "0x4B8")]
		public unsafe bool AnyAbsorbableSandRemains()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSettleProbe::AnyAbsorbableSandRemains");
			return default;
		}

		[Token(Token = "0x6001041")]
		[Address(RVA = "0x3CAF0DC", Offset = "0x3CAF0DC", Length = "0x1F8")]
		private int BuildFrontRowCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSettleProbe::BuildFrontRowCache");
			return default;
		}

		[Token(Token = "0x6001042")]
		[Address(RVA = "0x3CAF2D4", Offset = "0x3CAF2D4", Length = "0x70")]
		public ConveyorSettleProbe()
		{
			MoldFront[] fronts = new MoldFront[16];
			_fronts = fronts;
		}
	}
}
