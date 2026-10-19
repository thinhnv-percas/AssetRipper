using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003EF")]
	public class WinDetector
	{
		[Inject(false)]
		[Token(Token = "0x4000C7C")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x4000C7D")]
		[FieldOffset(Offset = "0x18")]
		private bool _hasSeenMolds;

		[Token(Token = "0x600108F")]
		[Address(RVA = "0x3CB4804", Offset = "0x3CB4804", Length = "0x2D0")]
		public bool IsWon()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinDetector::IsWon");
			return default;
		}

		[Token(Token = "0x6001090")]
		[Address(RVA = "0x3CB302C", Offset = "0x3CB302C", Length = "0x8")]
		public WinDetector()
		{
		}
	}
}
