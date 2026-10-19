using System;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x200000E")]
	public struct InitializationTimeTrack
	{
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		public float processStartTime;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x4")]
		public float processEndTime;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x8")]
		public Type initializable;
	}
}
