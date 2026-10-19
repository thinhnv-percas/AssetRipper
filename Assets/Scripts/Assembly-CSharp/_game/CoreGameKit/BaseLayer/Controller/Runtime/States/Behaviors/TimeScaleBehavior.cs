using System;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006E4")]
	public class TimeScaleBehavior : IStateBehavior, IDisposable
	{
		[Token(Token = "0x400170E")]
		private const string SpeedRequestKey = "base_layer_state";

		[SerializeField]
		[Token(Token = "0x400170F")]
		[FieldOffset(Offset = "0x10")]
		private float _enterTimeScale;

		[SerializeField]
		[Token(Token = "0x4001710")]
		[FieldOffset(Offset = "0x14")]
		private float _exitTimeScale;

		[Token(Token = "0x4001711")]
		[FieldOffset(Offset = "0x18")]
		private readonly GameSpeedController _gameSpeed;

		[Token(Token = "0x6001D0C")]
		[Address(RVA = "0x3D732B4", Offset = "0x3D732B4", Length = "0x64")]
		public TimeScaleBehavior(GameSpeedController gameSpeed, float enterTimeScale, float exitTimeScale)
		{
			_enterTimeScale = 0f;
			_gameSpeed = gameSpeed;
			_enterTimeScale = enterTimeScale;
			_exitTimeScale = exitTimeScale;
		}

		[Token(Token = "0x6001D0D")]
		[Address(RVA = "0x3D73318", Offset = "0x3D73318", Length = "0x64")]
		public void OnStateEnter()
		{
			if (_gameSpeed != null)
			{
				_gameSpeed.SetRequest("base_layer_state", _enterTimeScale);
			}
		}

		[Token(Token = "0x6001D0E")]
		[Address(RVA = "0x3D7337C", Offset = "0x3D7337C", Length = "0x64")]
		public void OnStateExit()
		{
			if (_gameSpeed != null)
			{
				_gameSpeed.SetRequest("base_layer_state", _exitTimeScale);
			}
		}

		[Token(Token = "0x6001D0F")]
		[Address(RVA = "0x3D733E0", Offset = "0x3D733E0", Length = "0x60")]
		public void Dispose()
		{
			if (_gameSpeed != null)
			{
				_gameSpeed.ClearRequest("base_layer_state");
			}
		}
	}
}
