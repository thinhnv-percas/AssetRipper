using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x200047A")]
	public struct VacuumDispatchTarget : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x4000E7C")]
		[FieldOffset(Offset = "0x0")]
		public int moldEntityIndex;

		[Token(Token = "0x4000E7D")]
		[FieldOffset(Offset = "0x4")]
		public int moldEntityGeneration;

		[Token(Token = "0x4000E7E")]
		[FieldOffset(Offset = "0x8")]
		public int gameColor;

		[Token(Token = "0x4000E7F")]
		[FieldOffset(Offset = "0xC")]
		public float staggerDelay;
	}
}
