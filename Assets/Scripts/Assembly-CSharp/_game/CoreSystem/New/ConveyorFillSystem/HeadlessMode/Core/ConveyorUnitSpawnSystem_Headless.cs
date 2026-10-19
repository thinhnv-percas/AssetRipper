using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core
{
	[Token(Token = "0x200043C")]
	public class ConveyorUnitSpawnSystem_Headless
	{
		[Inject(false)]
		[Token(Token = "0x4000D47")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x60011A4")]
		[Address(RVA = "0x3CBA290", Offset = "0x3CBA290", Length = "0x41C")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorUnitSpawnSystem_Headless::Execute");
		}

		[Token(Token = "0x60011A5")]
		[Address(RVA = "0x3CC2C34", Offset = "0x3CC2C34", Length = "0x8")]
		public ConveyorUnitSpawnSystem_Headless()
		{
		}
	}
}
