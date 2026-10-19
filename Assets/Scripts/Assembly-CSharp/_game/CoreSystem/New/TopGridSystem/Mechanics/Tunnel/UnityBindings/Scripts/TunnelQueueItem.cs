using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Serializable]
	[Token(Token = "0x200014E")]
	public class TunnelQueueItem
	{
		[Token(Token = "0x4000437")]
		[FieldOffset(Offset = "0x10")]
		public TunnelQueueItemKind kind;

		[Token(Token = "0x4000438")]
		[FieldOffset(Offset = "0x14")]
		public GameColor cubeColor;

		[Token(Token = "0x4000439")]
		[FieldOffset(Offset = "0x18")]
		public GameColor lockColor;

		[Token(Token = "0x400043A")]
		[FieldOffset(Offset = "0x1C")]
		public GameColor keyColor;

		[Token(Token = "0x400043B")]
		[FieldOffset(Offset = "0x20")]
		public bool isHidden;

		[Token(Token = "0x6000680")]
		[Address(RVA = "0x3DB707C", Offset = "0x3DB707C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelQueueItem()
		{
		}
	}
}
