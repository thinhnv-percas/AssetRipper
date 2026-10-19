using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000409")]
	public class HeadlessReconcileDriver
	{
		[Inject(false)]
		[Token(Token = "0x4000CBD")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000CBE")]
		[FieldOffset(Offset = "0x18")]
		private MoldLinkedHandler _moldLinkedHandler;

		[Inject(false)]
		[Token(Token = "0x4000CBF")]
		[FieldOffset(Offset = "0x20")]
		private MoldGridHandler _moldGridHandler;

		[Inject(false)]
		[Token(Token = "0x4000CC0")]
		[FieldOffset(Offset = "0x28")]
		private IMoldCmdProcessor _moldCmdProcessor;

		[Inject(false)]
		[Token(Token = "0x4000CC1")]
		[FieldOffset(Offset = "0x30")]
		private TopGridReconcileTick_Headless _topGridTick;

		[Inject(false)]
		[Token(Token = "0x4000CC2")]
		[FieldOffset(Offset = "0x38")]
		private ConveyorUnitSpawnSystem_Headless _conveyorSpawn;

		[Inject(false)]
		[Token(Token = "0x4000CC3")]
		[FieldOffset(Offset = "0x40")]
		private ConveyorOccupancySystem_Headless _conveyorOccupancy;

		[Inject(false)]
		[Token(Token = "0x4000CC4")]
		[FieldOffset(Offset = "0x48")]
		private MoldFillFromUnitsSystem_Headless _moldFillFromUnits;

		[Inject(false)]
		[Token(Token = "0x4000CC5")]
		[FieldOffset(Offset = "0x50")]
		private ConveyorTerminalSystem_Headless _terminal;

		[Token(Token = "0x4000CC6")]
		[FieldOffset(Offset = "0x58")]
		private MoldReconcileCore _moldCore;

		[Inject(false)]
		[Token(Token = "0x60010E6")]
		[Address(RVA = "0x3CBA188", Offset = "0x3CBA188", Length = "0x8C")]
		private void Construct()
		{
			MoldReconcileCore moldCore = new MoldReconcileCore(_em, _moldLinkedHandler, _moldGridHandler, _moldCmdProcessor);
			_moldCore = moldCore;
		}

		[Token(Token = "0x60010E7")]
		[Address(RVA = "0x3CBA214", Offset = "0x3CBA214", Length = "0x7C")]
		public void Tick(float dt)
		{
			_topGridTick.Tick(dt);
			_conveyorSpawn.Execute();
			_conveyorOccupancy.Execute();
			_moldFillFromUnits.Execute();
			_moldCore.Tick(dt);
			_terminal.Execute();
		}

		[Token(Token = "0x60010E8")]
		[Address(RVA = "0x3CBAFD4", Offset = "0x3CBAFD4", Length = "0x48")]
		public void RunUntilStable(int maxTicks = 1024, float dtPerTick = 1f / 60f)
		{
			if (maxTicks >= 1)
			{
				int num = maxTicks;
				bool flag;
				do
				{
					Tick(dtPerTick);
					int num2 = num - 1;
					flag = num != 1;
					num = num2;
				}
				while (flag);
			}
		}

		[Token(Token = "0x60010E9")]
		[Address(RVA = "0x3CB9A40", Offset = "0x3CB9A40", Length = "0x8")]
		public HeadlessReconcileDriver()
		{
		}
	}
}
