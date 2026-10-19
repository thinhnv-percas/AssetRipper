using Cpp2ILInjected;

namespace Unco.TimeTaskSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public interface ITimeTaskController
	{
		[Token(Token = "0x6000003")]
		protected internal void Update();

		[Token(Token = "0x6000004")]
		TimerHandle CreateTimer(float duration, TimerFlags flags, float elapsed = 0f, float updateInterval = 0f);

		[Token(Token = "0x6000005")]
		TimerHandle CreateTimer(float duration, bool countDown, bool hasInterval, bool loops, float elapsed = 0f, float updateInterval = 0f);
	}
}
