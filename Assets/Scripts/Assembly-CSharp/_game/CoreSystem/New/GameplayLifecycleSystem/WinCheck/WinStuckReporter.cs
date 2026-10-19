using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.Tracking;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003F1")]
	public class WinStuckReporter : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000C80")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000C81")]
		[FieldOffset(Offset = "0x18")]
		private WinDetector _detector;

		[Inject(false)]
		[Token(Token = "0x4000C82")]
		[FieldOffset(Offset = "0x20")]
		private IWinCheckSuppressor _suppressor;

		[Inject(false)]
		[Token(Token = "0x4000C83")]
		[FieldOffset(Offset = "0x28")]
		private WinCheckBehavior _winCheck;

		[Inject(false)]
		[Token(Token = "0x4000C84")]
		[FieldOffset(Offset = "0x30")]
		private WinStuckBoosterUsageTracker _boosterUsage;

		[Inject(false)]
		[Token(Token = "0x4000C85")]
		[FieldOffset(Offset = "0x38")]
		private TrackingManager _tracking;

		[Inject(false)]
		[Token(Token = "0x4000C86")]
		[FieldOffset(Offset = "0x40")]
		private EventBus _eventBus;

		[Token(Token = "0x4000C87")]
		[FieldOffset(Offset = "0x48")]
		private bool _fired;

		[Inject(false)]
		[Token(Token = "0x6001096")]
		[Address(RVA = "0x3CB52D8", Offset = "0x3CB52D8", Length = "0x120")]
		private void Initialize()
		{
			Action<UventLevelRefreshed> observer = OnLevelRefreshed;
			_eventBus.ListenEvent(observer);
			Action<UventLevelLeave> observer2 = OnLevelLeave;
			_eventBus.ListenEvent(observer2);
		}

		[Token(Token = "0x6001097")]
		[Address(RVA = "0x3CB53F8", Offset = "0x3CB53F8", Length = "0x4")]
		private void OnLevelRefreshed(UventLevelRefreshed _)
		{
			Evaluate();
		}

		[Token(Token = "0x6001098")]
		[Address(RVA = "0x3CB54D4", Offset = "0x3CB54D4", Length = "0x4")]
		private void OnLevelLeave(UventLevelLeave _)
		{
			Evaluate();
		}

		[Token(Token = "0x6001099")]
		[Address(RVA = "0x3CB53FC", Offset = "0x3CB53FC", Length = "0xD8")]
		private void Evaluate()
		{
			EvaluateInternal();
		}

		[Token(Token = "0x600109A")]
		[Address(RVA = "0x3CB54D8", Offset = "0x3CB54D8", Length = "0x2FC")]
		private void EvaluateInternal()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStuckReporter::EvaluateInternal");
		}

		[Token(Token = "0x600109B")]
		[Address(RVA = "0x3CB57D4", Offset = "0x3CB57D4", Length = "0x578")]
		private void Report(int moldCount, int blocking)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStuckReporter::Report");
		}

		[Token(Token = "0x600109C")]
		[Address(RVA = "0x3CB639C", Offset = "0x3CB639C", Length = "0x130")]
		public void Dispose()
		{
			if (_eventBus != null)
			{
				Action<UventLevelRefreshed> observer = OnLevelRefreshed;
				_eventBus.RemoveListener(observer);
				if (_eventBus != null)
				{
					Action<UventLevelLeave> observer2 = OnLevelLeave;
					_eventBus.RemoveListener(observer2);
				}
			}
		}

		[Token(Token = "0x600109D")]
		[Address(RVA = "0x3CB64CC", Offset = "0x3CB64CC", Length = "0x8")]
		public WinStuckReporter()
		{
		}
	}
}
