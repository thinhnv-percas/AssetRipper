using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SoundSystem.Scripts.Runtime
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public struct FadeData
	{
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x0")]
		public float Start;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x4")]
		public float End;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x8")]
		public float Duration;

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x7B9C448", Offset = "0x7B9C448", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Start = start;\n\tthis.End = end;\n\tthis.Duration = duration;\n\treturn;\n")]
		public FadeData(float start, float end, float duration)
		{
			Start = start;
			End = end;
			Duration = duration;
		}
	}
}
