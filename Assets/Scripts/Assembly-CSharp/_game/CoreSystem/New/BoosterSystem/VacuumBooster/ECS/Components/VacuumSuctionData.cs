using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x200047D")]
	public struct VacuumSuctionData : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x4000E86")]
		[FieldOffset(Offset = "0x0")]
		public float baseScale;

		[Token(Token = "0x4000E87")]
		[FieldOffset(Offset = "0x4")]
		public float targetScale;
	}
}
