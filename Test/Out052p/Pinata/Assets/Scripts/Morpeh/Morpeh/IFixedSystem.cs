using System;
using Cpp2ILInjected;

namespace Morpeh
{
	[Token(Token = "0x200000B")]
	public interface IFixedSystem : ISystem, IInitializer, IDisposable
	{
	}
}
