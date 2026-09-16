using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000062")]
	public class StoreID
	{
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x10")]
		public string store;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x18")]
		public string id;
	}
}
