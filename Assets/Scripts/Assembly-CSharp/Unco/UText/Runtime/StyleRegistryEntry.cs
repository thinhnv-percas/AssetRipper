using System;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;

namespace Unco.UText.Runtime
{
	[Serializable]
	[Token(Token = "0x20007A4")]
	public struct StyleRegistryEntry
	{
		[Token(Token = "0x4001940")]
		[FieldOffset(Offset = "0x0")]
		public string Name;

		[Token(Token = "0x4001941")]
		[FieldOffset(Offset = "0x8")]
		public UTextStyle Style;
	}
}
