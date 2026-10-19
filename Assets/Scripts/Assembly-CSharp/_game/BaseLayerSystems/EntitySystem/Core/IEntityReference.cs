using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x200007B")]
	public interface IEntityReference
	{
		[Token(Token = "0x6000214")]
		void ResolveReferences(EntityManager manager);
	}
}
