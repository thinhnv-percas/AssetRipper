using System;
using Cpp2ILInjected;

namespace Spine
{
	[Flags]
	[Token(Token = "0x2000040")]
	public enum TransformMode
	{
		[Token(Token = "0x400019F")]
		Normal = 0,
		[Token(Token = "0x40001A0")]
		OnlyTranslation = 7,
		[Token(Token = "0x40001A1")]
		NoRotationOrReflection = 1,
		[Token(Token = "0x40001A2")]
		NoScale = 2,
		[Token(Token = "0x40001A3")]
		NoScaleOrReflection = 6
	}
}
