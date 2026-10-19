using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions
{
	[Token(Token = "0x200017F")]
	public class SnakeBodyCondition : PourableBlockCondition<BlockedBySnakeBodyTag>
	{
		[Token(Token = "0x170000A3")]
		public override BlockReason Reason
		{
			[Token(Token = "0x600072E")]
			[Address(RVA = "0x3E62174", Offset = "0x3E62174", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 4;\n")]
			get
			{
				return BlockReason.SnakeBody;
			}
		}

		[Token(Token = "0x600072F")]
		[Address(RVA = "0x3E6217C", Offset = "0x3E6217C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv54 = ~returnVal2;\n\tif (v54) goto L_004C;\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv62 = v60 < 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv83 = entity < 0;\n\tv139 = entity ^ entity;\n\tv140 = entity & v139;\n\tv68 = v140 < 0;\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv68 = 0;\nL_FFFFFFFF:\n\tv83 = 1;\nL_004C:\n\treturn returnVal2;\nL_0043:\n\tv65 = v83 == v68;\nL_FFFFFFFF:\n\treturnVal2 = v65;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBodyCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x6000730")]
		[Address(RVA = "0x3E5905C", Offset = "0x3E5905C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Tags.BlockedBySnakeBodyTag>::.ctor(this);\n\treturn;\n")]
		public SnakeBodyCondition()
		{
		}
	}
}
