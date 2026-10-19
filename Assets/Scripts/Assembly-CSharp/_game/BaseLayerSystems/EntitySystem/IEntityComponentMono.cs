using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem
{
	[Token(Token = "0x2000061")]
	public interface IEntityComponentMono
	{
		[Token(Token = "0x6000160")]
		void Init(EntityMono mono);

		[Token(Token = "0x6000161")]
		void DeInit(EntityMono mono);
	}
}
