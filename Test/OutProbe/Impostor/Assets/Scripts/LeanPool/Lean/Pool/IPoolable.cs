using Cpp2ILInjected;

namespace Lean.Pool
{
	[Token(Token = "0x2000004")]
	public interface IPoolable
	{
		[Token(Token = "0x6000003")]
		void OnSpawn();

		[Token(Token = "0x6000004")]
		void OnDespawn();
	}
}
