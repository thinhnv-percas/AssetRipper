using System;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Enums;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000011")]
	internal interface IResolver : IDisposable
	{
		[Token(Token = "0x17000008")]
		Lifetime Lifetime
		{
			[Token(Token = "0x6000030")]
			get;
		}

		[Token(Token = "0x6000031")]
		object Resolve(Container container);
	}
}
