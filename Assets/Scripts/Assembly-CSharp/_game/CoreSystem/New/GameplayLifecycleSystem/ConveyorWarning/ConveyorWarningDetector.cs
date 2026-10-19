using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unity.Collections;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.ConveyorWarning
{
	[Token(Token = "0x2000428")]
	public class ConveyorWarningDetector : IRequireUpdateCall, IDisposable
	{
		[Token(Token = "0x4000D16")]
		private const float ShowThreshold = 0.85f;

		[Token(Token = "0x4000D17")]
		private const float HideThreshold = 0.8f;

		[Token(Token = "0x4000D18")]
		private const float CheckInterval = 0.5f;

		[Token(Token = "0x4000D19")]
		private static readonly int ColorCount;

		[Inject(false)]
		[Token(Token = "0x4000D1A")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000D1B")]
		[FieldOffset(Offset = "0x18")]
		private ConveyorController _conveyor;

		[Inject(true)]
		[Token(Token = "0x4000D1C")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _bus;

		[Token(Token = "0x4000D1D")]
		[FieldOffset(Offset = "0x28")]
		internal readonly bool[] _neededColors;

		[Token(Token = "0x4000D1E")]
		[FieldOffset(Offset = "0x30")]
		private float _checkTimer;

		[Token(Token = "0x4000D1F")]
		[FieldOffset(Offset = "0x34")]
		private bool _warningActive;

		[Token(Token = "0x17000163")]
		public bool IsWarningActive
		{
			[Token(Token = "0x600115C")]
			[Address(RVA = "0x3CBFEF4", Offset = "0x3CBFEF4", Length = "0x8")]
			get
			{
				return _warningActive;
			}
		}

		[Token(Token = "0x600115D")]
		[Address(RVA = "0x3CBFEFC", Offset = "0x3CBFEFC", Length = "0x1E0")]
		public void Update()
		{
			if (_conveyor == null || _em == null)
			{
				return;
			}
			ConveyorController conveyor = _conveyor;
			if (conveyor.MaxParticleCapacity < 1)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			if ((_checkTimer += deltaTime) < 0.5f)
			{
				return;
			}
			_checkTimer = 0f;
			ConveyorController conveyor2 = _conveyor;
			int num = conveyor2.CurrentParticleCount / conveyor2.MaxParticleCapacity;
			bool flag = num == 1061997773;
			bool flag2 = num < 1061997773;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (!(flag4 || flag))
			{
				bool flag5 = HasMatchingConveyorParticles();
				if (!flag5)
				{
					bool flag6 = num < 1062836634;
					bool flag7 = num == num;
					bool flag8 = !flag7;
					if (flag6 == flag8 && !IsWarningActive)
					{
						SetWarning(active: true);
						return;
					}
				}
				bool flag9 = !IsWarningActive;
				int num2 = (flag5 ? 1 : 0) ^ 1;
				if (flag9)
				{
					num2 = 1;
				}
				if ((num2 & 1) == 0)
				{
					SetWarning(active: false);
				}
			}
			else if (IsWarningActive)
			{
				_warningActive = false;
				if (_bus != null)
				{
					_bus.InvokeEvent(default(UventConveyorWarningChanged));
				}
			}
		}

		[Token(Token = "0x600115E")]
		[Address(RVA = "0x3CC00DC", Offset = "0x3CC00DC", Length = "0x80")]
		private void SetWarning(bool active)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorWarningDetector::SetWarning");
		}

		[Token(Token = "0x600115F")]
		[Address(RVA = "0x3CC015C", Offset = "0x3CC015C", Length = "0x33C")]
		private bool HasMatchingConveyorParticles()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorWarningDetector::HasMatchingConveyorParticles");
			return default;
		}

		[Token(Token = "0x6001160")]
		[Address(RVA = "0x3CC0498", Offset = "0x3CC0498", Length = "0x70")]
		public void Dispose()
		{
			if (IsWarningActive)
			{
				_warningActive = false;
				if (_bus != null)
				{
					_bus.InvokeEvent(default(UventConveyorWarningChanged));
				}
			}
		}

		[Token(Token = "0x6001161")]
		[Address(RVA = "0x3CC0508", Offset = "0x3CC0508", Length = "0x70")]
		public ConveyorWarningDetector()
		{
			bool[] neededColors = new bool[13];
			_neededColors = neededColors;
		}

		[Token(Token = "0x6001162")]
		[Address(RVA = "0x3CC0578", Offset = "0x3CC0578", Length = "0xF4")]
		static ConveyorWarningDetector()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorWarningDetector::.cctor");
		}
	}
}
