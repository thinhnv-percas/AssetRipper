using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions
{
	[Token(Token = "0x2000237")]
	public class GarageBlockCondition : PourableBlockCondition<BlockedByGarageTag>
	{
		[Token(Token = "0x170000C2")]
		public override BlockReason Reason
		{
			[Token(Token = "0x60009B7")]
			[Address(RVA = "0x3E99F1C", Offset = "0x3E99F1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 3;\n")]
			get
			{
				return BlockReason.Garage;
			}
		}

		[Token(Token = "0x60009B8")]
		[Address(RVA = "0x3E99F24", Offset = "0x3E99F24", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv65 = ~returnVal2;\n\tif (v65) goto L_0044;\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv100 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetGarageCoverAt(grid, v59);\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v100);\n\treturn returnVal3;\nL_0044:\n\treturn returnVal2;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageBlockCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x60009B9")]
		[Address(RVA = "0x3E980A0", Offset = "0x3E980A0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags.BlockedByGarageTag>::.ctor(this);\n\treturn;\n")]
		public GarageBlockCondition()
		{
		}
	}
}
