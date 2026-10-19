using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x2000479")]
	public struct VacuumBulbSlot : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x4000E78")]
		[FieldOffset(Offset = "0x0")]
		public float heightSeed;

		[Token(Token = "0x4000E79")]
		[FieldOffset(Offset = "0x4")]
		public float2 diskOffset;

		[Token(Token = "0x4000E7A")]
		[FieldOffset(Offset = "0xC")]
		public float3 localOffset;

		[Token(Token = "0x4000E7B")]
		[FieldOffset(Offset = "0x18")]
		public float localScale;
	}
}
