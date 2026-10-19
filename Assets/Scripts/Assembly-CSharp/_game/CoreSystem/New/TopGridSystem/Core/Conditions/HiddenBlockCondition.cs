using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Conditions
{
	[Token(Token = "0x200027A")]
	public class HiddenBlockCondition : PourableBlockCondition<BlockedByHiddenTag>
	{
		[Token(Token = "0x170000CD")]
		public override BlockReason Reason
		{
			[Token(Token = "0x6000B1C")]
			[Address(RVA = "0x3EC49E0", Offset = "0x3EC49E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 5;\n")]
			get
			{
				return BlockReason.Hidden;
			}
		}

		[Token(Token = "0x170000CE")]
		public override bool AffectsCover
		{
			[Token(Token = "0x6000B1D")]
			[Address(RVA = "0x3EC49E8", Offset = "0x3EC49E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000B1E")]
		[Address(RVA = "0x3EC49F0", Offset = "0x3EC49F0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v39);\n\treturn returnVal1;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			Entity entity2 = default(Entity);
			return em.HasComponent<ColorHiddenComponent>(entity2);
		}

		[Token(Token = "0x6000B1F")]
		[Address(RVA = "0x3EC4A54", Offset = "0x3EC4A54", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags.BlockedByHiddenTag>::.ctor(this);\n\treturn;\n")]
		public HiddenBlockCondition()
		{
		}
	}
}
