using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core
{
	[Token(Token = "0x200043B")]
	public class ConveyorTerminalSystem_Headless
	{
		[Inject(false)]
		[Token(Token = "0x4000D45")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x17000166")]
		[field: Token(Token = "0x4000D46")]
		[field: FieldOffset(Offset = "0x18")]
		public TerminalVerdict_Headless Verdict
		{
			[Token(Token = "0x60011A0")]
			[Address(RVA = "0x3CC2DEC", Offset = "0x3CC2DEC", Length = "0x8")]
			get;
			[Token(Token = "0x60011A1")]
			[Address(RVA = "0x3CC2DF4", Offset = "0x3CC2DF4", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x60011A2")]
		[Address(RVA = "0x3CBACC8", Offset = "0x3CBACC8", Length = "0x30C")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorTerminalSystem_Headless::Execute");
		}

		[Token(Token = "0x60011A3")]
		[Address(RVA = "0x3CC2DE4", Offset = "0x3CC2DE4", Length = "0x8")]
		public ConveyorTerminalSystem_Headless()
		{
		}
	}
}
