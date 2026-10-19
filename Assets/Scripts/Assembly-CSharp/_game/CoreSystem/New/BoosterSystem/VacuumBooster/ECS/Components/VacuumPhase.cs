using Cpp2ILInjected;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components
{
	[Token(Token = "0x200047B")]
	public enum VacuumPhase : byte
	{
		[Token(Token = "0x4000E81")]
		Suctioning = 0,
		[Token(Token = "0x4000E82")]
		InTube = 1,
		[Token(Token = "0x4000E83")]
		Bulb = 2,
		[Token(Token = "0x4000E84")]
		Dispatching = 3
	}
}
