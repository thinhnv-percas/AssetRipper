using System;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;

namespace Unco.UText.Runtime
{
	[Serializable]
	[Token(Token = "0x20007A5")]
	public struct SpriteRegistryEntry
	{
		[Token(Token = "0x4001942")]
		[FieldOffset(Offset = "0x0")]
		public string Name;

		[Token(Token = "0x4001943")]
		[FieldOffset(Offset = "0x8")]
		public UTextSpriteAsset Atlas;
	}
}
