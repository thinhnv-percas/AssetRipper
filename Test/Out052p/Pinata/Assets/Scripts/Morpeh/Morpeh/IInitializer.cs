using System;
using Cpp2ILInjected;

namespace Morpeh
{
	[Token(Token = "0x2000009")]
	public interface IInitializer : IDisposable
	{
		[Token(Token = "0x17000004")]
		World World
		{
			[Token(Token = "0x600000F")]
			get;
			[Token(Token = "0x6000010")]
			set;
		}

		[Token(Token = "0x17000005")]
		FilterProvider Filter
		{
			[Token(Token = "0x6000011")]
			get;
			[Token(Token = "0x6000012")]
			set;
		}

		[Token(Token = "0x6000013")]
		void OnAwake();

		[Token(Token = "0x6000014")]
		void OnStart();
	}
}
