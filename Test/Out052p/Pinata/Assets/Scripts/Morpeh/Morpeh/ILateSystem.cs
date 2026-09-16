using System;
using Cpp2ILInjected;

namespace Morpeh
{
	[Token(Token = "0x200000C")]
	public interface ILateSystem : ISystem, IInitializer, IDisposable
	{
	}
}
