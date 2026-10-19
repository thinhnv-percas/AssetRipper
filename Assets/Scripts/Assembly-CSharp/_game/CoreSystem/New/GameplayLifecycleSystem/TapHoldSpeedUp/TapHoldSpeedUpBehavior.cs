using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp
{
	[Serializable]
	[Token(Token = "0x20003F8")]
	public class TapHoldSpeedUpBehavior : IStateBehavior, IDisposable
	{
		[Token(Token = "0x4000C96")]
		private const string SpeedRequestKey = "tap_hold";

		[Token(Token = "0x4000C97")]
		private const float RaycastDistance = 1000f;

		[Inject(false)]
		[Token(Token = "0x4000C98")]
		[FieldOffset(Offset = "0x10")]
		private RemoteConfigManager _remoteConfigManager;

		[Inject(false)]
		[Token(Token = "0x4000C99")]
		[FieldOffset(Offset = "0x18")]
		private IInputProvider _inputProvider;

		[Inject(false)]
		[Token(Token = "0x4000C9A")]
		[FieldOffset(Offset = "0x20")]
		private GameplaySpeedController _gameplaySpeed;

		[Inject(false)]
		[Token(Token = "0x4000C9B")]
		[FieldOffset(Offset = "0x28")]
		private ILevelProgressService _levelProgressService;

		[Token(Token = "0x4000C9C")]
		[FieldOffset(Offset = "0x30")]
		private bool _isEnabled;

		[Token(Token = "0x4000C9D")]
		[FieldOffset(Offset = "0x31")]
		private bool? _isPressEligible;

		[Token(Token = "0x4000C9E")]
		[FieldOffset(Offset = "0x38")]
		private IGameplaySpeedHandle _handle;

		[Token(Token = "0x60010B3")]
		[Address(RVA = "0x3CB7338", Offset = "0x3CB7338", Length = "0x324")]
		public void OnStateEnter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapHoldSpeedUpBehavior::OnStateEnter");
		}

		[Token(Token = "0x60010B4")]
		[Address(RVA = "0x3CB7978", Offset = "0x3CB7978", Length = "0x260")]
		public void OnStateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapHoldSpeedUpBehavior::OnStateUpdate");
		}

		[Token(Token = "0x60010B5")]
		[Address(RVA = "0x3CB7EE4", Offset = "0x3CB7EE4", Length = "0xC4")]
		public void OnStateExit()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
			_isPressEligible = null;
		}

		[Token(Token = "0x60010B6")]
		[Address(RVA = "0x3CB7FA8", Offset = "0x3CB7FA8", Length = "0xB0")]
		public void Dispose()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x60010B7")]
		[Address(RVA = "0x3CB78C8", Offset = "0x3CB78C8", Length = "0xB0")]
		private void ReleaseHandle()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x60010B8")]
		[Address(RVA = "0x3CB7BD8", Offset = "0x3CB7BD8", Length = "0x188")]
		private unsafe static bool IsPointerOverSandCube(Vector2 screenPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapHoldSpeedUpBehavior::IsPointerOverSandCube");
			return default;
		}

		[Token(Token = "0x60010B9")]
		[Address(RVA = "0x3CB8058", Offset = "0x3CB8058", Length = "0x8")]
		public TapHoldSpeedUpBehavior()
		{
		}
	}
}
