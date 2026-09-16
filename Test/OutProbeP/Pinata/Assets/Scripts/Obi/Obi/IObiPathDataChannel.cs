using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x200006B")]
	public interface IObiPathDataChannel
	{
		[Token(Token = "0x170000B4")]
		int Count
		{
			[Token(Token = "0x6000464")]
			get;
		}

		[Token(Token = "0x170000B5")]
		bool Dirty
		{
			[Token(Token = "0x6000465")]
			get;
		}

		[Token(Token = "0x6000466")]
		void Clean();

		[Token(Token = "0x6000467")]
		void RemoveAt(int index);
	}
}
