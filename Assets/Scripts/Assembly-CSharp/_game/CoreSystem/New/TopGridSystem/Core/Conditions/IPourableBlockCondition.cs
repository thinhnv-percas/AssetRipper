using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.New.TopGridSystem.Core.Conditions
{
	[Token(Token = "0x200027B")]
	public interface IPourableBlockCondition
	{
		[Token(Token = "0x170000CF")]
		BlockReason Reason
		{
			[Token(Token = "0x6000B20")]
			get;
		}

		[Token(Token = "0x170000D0")]
		bool AffectsCover
		{
			[Token(Token = "0x6000B21")]
			get;
		}

		[Token(Token = "0x6000B22")]
		bool HasBlockTag(EntityManager em, Entity entity);

		[Token(Token = "0x6000B23")]
		void AddBlockTagIfMissing(EntityManager em, Entity entity);

		[Token(Token = "0x6000B24")]
		void RemoveBlockTagIfPresent(EntityManager em, Entity entity);

		[Token(Token = "0x6000B25")]
		bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid);
	}
}
