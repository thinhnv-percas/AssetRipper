using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000048")]
	public interface IUpdatable
	{
		[Token(Token = "0x170000E9")]
		bool Active
		{
			[Token(Token = "0x60002E6")]
			get;
		}

		[Token(Token = "0x60002E5")]
		void Update();
	}
}
