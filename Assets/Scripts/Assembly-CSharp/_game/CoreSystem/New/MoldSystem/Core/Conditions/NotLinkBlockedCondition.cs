using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;

namespace _game.CoreSystem.New.MoldSystem.Core.Conditions
{
	[Token(Token = "0x2000305")]
	public class NotLinkBlockedCondition : IClaimCondition
	{
		[Token(Token = "0x400093A")]
		[FieldOffset(Offset = "0x10")]
		private MoldLinkedHandler _linkedHandler;

		[Token(Token = "0x400093B")]
		[FieldOffset(Offset = "0x18")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000D4E")]
		[Address(RVA = "0x3EED628", Offset = "0x3EED628", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\treturn;\n")]
		public NotLinkBlockedCondition(EntityManager em)
		{
			_em = em;
		}

		[Token(Token = "0x6000D4F")]
		[Address(RVA = "0x3EED65C", Offset = "0x3EED65C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\treturnVal1 = v49 ^ 1;\n\treturn returnVal1;\n")]
		public bool CanClaim(EntityManager em, Entity entity, GameColor color)
		{
			bool flag = _em.HasComponent<MoldLinkedComponent>(entity);
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}
	}
}
