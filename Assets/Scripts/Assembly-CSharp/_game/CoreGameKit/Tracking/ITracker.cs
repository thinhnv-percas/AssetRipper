using Cpp2ILInjected;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x2000581")]
	public interface ITracker
	{
		[Token(Token = "0x600172E")]
		ITracker GetInstance();

		[Token(Token = "0x600172F")]
		void SetRouter(TrackingRouter router);

		[Token(Token = "0x6001730")]
		void BeginTracking();

		[Token(Token = "0x6001731")]
		void EndTracking();
	}
}
