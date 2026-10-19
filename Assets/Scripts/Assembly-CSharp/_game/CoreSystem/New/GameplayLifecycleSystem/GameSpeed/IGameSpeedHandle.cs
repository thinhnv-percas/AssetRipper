using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Token(Token = "0x2000411")]
	public interface IGameSpeedHandle : IDisposable
	{
		[Token(Token = "0x6001113")]
		void SetMultiplier(float multiplier);
	}
}
