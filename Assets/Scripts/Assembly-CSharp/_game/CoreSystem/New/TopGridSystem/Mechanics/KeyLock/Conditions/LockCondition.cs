using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Conditions
{
	[Token(Token = "0x2000203")]
	public class LockCondition : PourableBlockCondition<BlockedByLockTag>
	{
		[Token(Token = "0x170000BB")]
		public override BlockReason Reason
		{
			[Token(Token = "0x6000917")]
			[Address(RVA = "0x3E8D1CC", Offset = "0x3E8D1CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n")]
			get
			{
				return BlockReason.Lock;
			}
		}

		[Token(Token = "0x6000918")]
		[Address(RVA = "0x3E8D1D4", Offset = "0x3E8D1D4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv65 = ~returnVal2;\n\tif (v65) goto L_0044;\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv100 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetLockAt(grid, v59);\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v100);\n\treturn returnVal3;\nL_0044:\n\treturn returnVal2;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x6000919")]
		[Address(RVA = "0x3E8D2A0", Offset = "0x3E8D2A0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags.BlockedByLockTag>::.ctor(this);\n\treturn;\n")]
		public LockCondition()
		{
		}
	}
}
