using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.CoreSystem.ConveyorSystem
{
	[Token(Token = "0x2000510")]
	public class ConveyorUpgradeIntroWiring : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x400111D")]
		[FieldOffset(Offset = "0x10")]
		private ConveyorController _conveyor;

		[Inject(false)]
		[Token(Token = "0x400111E")]
		[FieldOffset(Offset = "0x18")]
		private IEnumerable<IBaseLayerIntroElement> _introElements;

		[Token(Token = "0x400111F")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<BaseLayerConveyorUpgradeElement> _targets;

		[Inject(false)]
		[Token(Token = "0x6001535")]
		[Address(RVA = "0x3D0D240", Offset = "0x3D0D240", Length = "0x38C")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorUpgradeIntroWiring::Construct");
		}

		[Token(Token = "0x6001536")]
		[Address(RVA = "0x3D0D5CC", Offset = "0x3D0D5CC", Length = "0x17C")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorUpgradeIntroWiring::Dispose");
		}

		[Token(Token = "0x6001537")]
		[Address(RVA = "0x3D0D748", Offset = "0x3D0D748", Length = "0x8C")]
		public ConveyorUpgradeIntroWiring()
		{
			List<BaseLayerConveyorUpgradeElement> targets = new List<BaseLayerConveyorUpgradeElement>();
			_targets = targets;
		}
	}
}
