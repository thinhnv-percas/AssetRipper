using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core
{
	[Token(Token = "0x2000439")]
	public class ConveyorOccupancySystem_Headless
	{
		[Inject(false)]
		[Token(Token = "0x4000D40")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x600119E")]
		[Address(RVA = "0x3CBA6AC", Offset = "0x3CBA6AC", Length = "0x2A0")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorOccupancySystem_Headless::Execute");
		}

		[Token(Token = "0x600119F")]
		[Address(RVA = "0x3CC2CC4", Offset = "0x3CC2CC4", Length = "0x8")]
		public ConveyorOccupancySystem_Headless()
		{
		}
	}
}
