using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x200047E")]
	public struct VacuumTubeProgress : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x4000E88")]
		[FieldOffset(Offset = "0x0")]
		public float progress;

		[Token(Token = "0x4000E89")]
		[FieldOffset(Offset = "0x4")]
		public float perParticleSpeed;

		[Token(Token = "0x4000E8A")]
		[FieldOffset(Offset = "0x8")]
		public float orbitRadius;

		[Token(Token = "0x4000E8B")]
		[FieldOffset(Offset = "0xC")]
		public float orbitSpeed;

		[Token(Token = "0x4000E8C")]
		[FieldOffset(Offset = "0x10")]
		public float phaseOffset;
	}
}
