using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem
{
	[Token(Token = "0x2000062")]
	public interface IEntityData
	{
		[Token(Token = "0x6000162")]
		void Apply(ref EntityBuilder builder);
	}
}
