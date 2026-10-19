using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E5")]
	public sealed class PlayTestSpeedHandler : IDisposable
	{
		[Token(Token = "0x4000C62")]
		public const float PlayTestSpeed = 20f;

		[Token(Token = "0x4000C63")]
		private const string SpeedRequestKey = "play_test";

		[Inject(false)]
		[Token(Token = "0x4000C64")]
		[FieldOffset(Offset = "0x10")]
		private GameSpeedController _speedController;

		[Token(Token = "0x4000C65")]
		[FieldOffset(Offset = "0x18")]
		private IGameSpeedHandle _handle;

		[Inject(false)]
		[Token(Token = "0x600106F")]
		[Address(RVA = "0x3CB3C00", Offset = "0x3CB3C00", Length = "0x7C")]
		public void Construct()
		{
			if (_speedController != null)
			{
				IGameSpeedHandle handle = _speedController.RequestSpeed("play_test", 20f);
				_handle = handle;
			}
			else
			{
				_handle = null;
			}
		}

		[Token(Token = "0x6001070")]
		[Address(RVA = "0x3CB3E30", Offset = "0x3CB3E30", Length = "0xB0")]
		public void Dispose()
		{
			if (_handle != null)
			{
				_handle.Dispose();
			}
			_handle = null;
		}

		[Token(Token = "0x6001071")]
		[Address(RVA = "0x3CB2E44", Offset = "0x3CB2E44", Length = "0x8")]
		public PlayTestSpeedHandler()
		{
		}
	}
}
