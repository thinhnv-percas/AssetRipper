using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x200047C")]
	public struct VacuumParticlePhase : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x4000E85")]
		[FieldOffset(Offset = "0x0")]
		public VacuumPhase value;
	}
}
