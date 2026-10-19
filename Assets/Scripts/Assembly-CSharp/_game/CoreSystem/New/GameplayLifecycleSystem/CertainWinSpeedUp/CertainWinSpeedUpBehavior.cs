using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.CertainWinSpeedUp
{
	[Serializable]
	[Token(Token = "0x200042C")]
	public class CertainWinSpeedUpBehavior : IStateBehavior, IDisposable
	{
		[Token(Token = "0x4000D23")]
		private const string SpeedRequestKey = "certain_win";

		[Inject(false)]
		[Token(Token = "0x4000D24")]
		[FieldOffset(Offset = "0x10")]
		private CertainWinDetector _detector;

		[Inject(false)]
		[Token(Token = "0x4000D25")]
		[FieldOffset(Offset = "0x18")]
		private GameplaySpeedController _gameplaySpeed;

		[Token(Token = "0x4000D26")]
		[FieldOffset(Offset = "0x20")]
		private IGameplaySpeedHandle _handle;

		[Token(Token = "0x17000164")]
		public bool IsSpedUp
		{
			[Token(Token = "0x600116C")]
			[Address(RVA = "0x3CC0B94", Offset = "0x3CC0B94", Length = "0x10")]
			get
			{
				bool flag = _handle == null;
				return !flag;
			}
		}

		[Token(Token = "0x600116D")]
		[Address(RVA = "0x3CC0BA4", Offset = "0x3CC0BA4", Length = "0xB0")]
		public void OnStateEnter()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x600116E")]
		[Address(RVA = "0x3CC0D04", Offset = "0x3CC0D04", Length = "0x194")]
		public void OnStateUpdate()
		{
			if (!_detector.HasAnyCube())
			{
				SandPhysicsContext _003CCurrent_003Ek__BackingField = SandPhysicsContext.Current;
				if (SandPhysicsContext.Current == null || _003CCurrent_003Ek__BackingField.Queries == null || !_003CCurrent_003Ek__BackingField.Queries.HasInFlightParticles())
				{
					if (_handle == null)
					{
						IGameplaySpeedHandle handle = _gameplaySpeed.RequestProfile("certain_win", SpeedProfileId.CertainWin);
						_handle = handle;
					}
					return;
				}
			}
			if (_handle == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D94D]");
			int num = (int)((nint)0 & (nint)1);
			bool flag = num == 0;
			bool flag2 = !flag;
			IDisposable handle2 = _handle;
			if (!flag2)
			{
				_ = 1;
				bool flag3 = _handle == null;
				handle2 = _handle;
				if (flag3)
				{
					goto IL_0166;
				}
			}
			handle2.Dispose();
			goto IL_0166;
			IL_0166:
			_handle = null;
		}

		[Token(Token = "0x600116F")]
		[Address(RVA = "0x3CC0E98", Offset = "0x3CC0E98", Length = "0xB0")]
		public void OnStateExit()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x6001170")]
		[Address(RVA = "0x3CC0F48", Offset = "0x3CC0F48", Length = "0xB0")]
		public void Dispose()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x6001171")]
		[Address(RVA = "0x3CC0C54", Offset = "0x3CC0C54", Length = "0xB0")]
		private void ReleaseHandle()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x6001172")]
		[Address(RVA = "0x3CC0FF8", Offset = "0x3CC0FF8", Length = "0x8")]
		public CertainWinSpeedUpBehavior()
		{
		}
	}
}
