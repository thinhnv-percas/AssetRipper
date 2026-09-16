using System;
using Cpp2ILInjected;
using Morpeh.Utils;

namespace Morpeh
{
	[Token(Token = "0x2000007")]
	public interface IEntity : IDisposable
	{
		[Token(Token = "0x17000003")]
		int ID
		{
			[Token(Token = "0x6000006")]
			get;
		}

		[Token(Token = "0x6000007")]
		ref T AddComponent<T>() where T : struct, IComponent;

		[Token(Token = "0x6000008")]
		ref T AddComponent<T>(out bool exist) where T : struct, IComponent;

		[Token(Token = "0x6000009")]
		ref T GetComponent<T>() where T : struct, IComponent;

		[Token(Token = "0x600000A")]
		ref T GetComponent<T>(out bool exist) where T : struct, IComponent;

		[Token(Token = "0x600000B")]
		void SetComponent<T>(in T value) where T : struct, IComponent;

		[Token(Token = "0x600000C")]
		bool RemoveComponent<T>() where T : struct, IComponent;

		[Token(Token = "0x600000D")]
		bool Has<T>() where T : struct, IComponent;

		[Token(Token = "0x600000E")]
		bool Has(in FastBitMask mask);
	}
}
