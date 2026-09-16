using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Morpeh.Globals.ECS
{
	[Token(Token = "0x200002D")]
	internal struct GlobalEventComponent<TData> : IComponent
	{
		[Token(Token = "0x4000050")]
		internal static bool Initialized;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x0")]
		public Action<IEnumerable<TData>> Action;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x0")]
		public List<TData> Data;
	}
}
