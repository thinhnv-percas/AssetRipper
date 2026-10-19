using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions
{
	[Token(Token = "0x2000247")]
	public class FrozenBlockCondition : PourableBlockCondition<BlockedByFrozenTag>
	{
		[Token(Token = "0x170000C3")]
		public override BlockReason Reason
		{
			[Token(Token = "0x60009DC")]
			[Address(RVA = "0x3E9C430", Offset = "0x3E9C430", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 8;\n")]
			get
			{
				return BlockReason.Frozen;
			}
		}

		[Token(Token = "0x60009DD")]
		[Address(RVA = "0x3E9C438", Offset = "0x3E9C438", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv58 = ~returnVal2;\n\tif (v58) goto L_004D;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv104 = ~returnVal2;\n\tif (v104) goto L_004D;\n\tv139 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv141 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::CountLiveFreezers(em, grid, v139);\n\tv87 = v141 < 0;\n\tv84 = v141 == 0;\n\tv78 = v141 ^ v141;\n\tv75 = v141 & v78;\n\tv72 = v75 < 0;\n\tv143 = v87 == v72;\n\tv66 = ~v84;\n\tv69 = v143 & v66;\n\treturnVal2 = v69;\nL_004D:\n\treturn returnVal2;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenBlockCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x60009DE")]
		[Address(RVA = "0x3E9BCAC", Offset = "0x3E9BCAC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags.BlockedByFrozenTag>::.ctor(this);\n\treturn;\n")]
		public FrozenBlockCondition()
		{
		}
	}
}
