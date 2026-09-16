using System;
using Cpp2ILInjected;

namespace Morpeh
{
	[Token(Token = "0x200000A")]
	public interface ISystem : IInitializer, IDisposable
	{
		[Token(Token = "0x6000015")]
		void OnUpdate(float deltaTime);
	}
}
