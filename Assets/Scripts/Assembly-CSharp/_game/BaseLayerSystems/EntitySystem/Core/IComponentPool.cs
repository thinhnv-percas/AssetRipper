using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x200006F")]
	public interface IComponentPool
	{
		[Token(Token = "0x1700003D")]
		Type ComponentType
		{
			[Token(Token = "0x600019C")]
			get;
		}

		[Token(Token = "0x1700003E")]
		int TypeIndex
		{
			[Token(Token = "0x600019D")]
			get;
		}

		[Token(Token = "0x1700003F")]
		int Version
		{
			[Token(Token = "0x60001A0")]
			get;
		}

		[Token(Token = "0x17000040")]
		int Count
		{
			[Token(Token = "0x60001A1")]
			get;
		}

		[Token(Token = "0x6000198")]
		void RemoveByIndex(int index);

		[Token(Token = "0x6000199")]
		void Clear();

		[Token(Token = "0x600019A")]
		bool HasByIndex(int index);

		[Token(Token = "0x600019B")]
		object GetComponentByIndex(int index);

		[Token(Token = "0x600019E")]
		IEnumerable<int> GetEntityIndices();

		[Token(Token = "0x600019F")]
		IComponentPool Clone();
	}
}
