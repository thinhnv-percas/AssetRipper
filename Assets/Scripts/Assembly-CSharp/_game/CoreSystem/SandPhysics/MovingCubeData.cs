using Cpp2ILInjected;
using Unity.Mathematics;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A2")]
	public struct MovingCubeData
	{
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x0")]
		public float2 center;

		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x8")]
		public float2 prevCenter;

		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0x10")]
		public float halfSize;

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x14")]
		public float cosAngle;

		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x18")]
		public float sinAngle;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x1C")]
		public EntityId entityId;
	}
}
