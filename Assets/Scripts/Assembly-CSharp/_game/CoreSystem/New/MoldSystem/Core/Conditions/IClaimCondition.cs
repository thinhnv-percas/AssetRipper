using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.Core.Conditions
{
	[Token(Token = "0x2000302")]
	public interface IClaimCondition
	{
		[Token(Token = "0x6000D49")]
		bool CanClaim(EntityManager em, Entity entity, GameColor color);
	}
}
