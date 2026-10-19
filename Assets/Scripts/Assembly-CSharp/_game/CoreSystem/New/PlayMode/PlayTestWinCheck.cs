using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;
using _game.CoreSystem.New.LevelGeneratorSystem.PlayReport;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E6")]
	public sealed class PlayTestWinCheck : IRequireUpdateCall
	{
		[Token(Token = "0x4000C66")]
		private const float CheckIntervalSeconds = 1.25f;

		[Inject(false)]
		[Token(Token = "0x4000C67")]
		[FieldOffset(Offset = "0x10")]
		private WinDetector _detector;

		[Inject(true)]
		[Token(Token = "0x4000C68")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x4000C69")]
		[FieldOffset(Offset = "0x20")]
		internal readonly WinPollLatch _latch;

		[Token(Token = "0x6001072")]
		[Address(RVA = "0x3CB3EE0", Offset = "0x3CB3EE0", Length = "0xFC")]
		public void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestWinCheck::Update");
		}

		[Token(Token = "0x6001073")]
		[Address(RVA = "0x3CB3110", Offset = "0x3CB3110", Length = "0x7C")]
		public PlayTestWinCheck()
		{
			WinPollLatch latch = new WinPollLatch(1.25f);
			_latch = latch;
		}
	}
}
