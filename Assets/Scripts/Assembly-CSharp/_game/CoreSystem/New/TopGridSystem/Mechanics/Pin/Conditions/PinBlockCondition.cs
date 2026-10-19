using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions
{
	[Token(Token = "0x20001B8")]
	public class PinBlockCondition : PourableBlockCondition<BlockedByPinTag>
	{
		[Token(Token = "0x170000B0")]
		public override BlockReason Reason
		{
			[Token(Token = "0x60007EC")]
			[Address(RVA = "0x3E717DC", Offset = "0x3E717DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 6;\n")]
			get
			{
				return BlockReason.Pin;
			}
		}

		[Token(Token = "0x60007ED")]
		[Address(RVA = "0x3E717E4", Offset = "0x3E717E4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, sandCube);\n\tv69 = ~returnVal2;\n\tif (v69) goto L_0059;\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, sandCube);\n\tv135 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetPinAt(grid, v60);\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v135);\n\tv102 = ~returnVal2;\n\tif (v102) goto L_0059;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v135);\n\tv103 = ~returnVal2;\n\tif (v103) goto L_0059;\n\tv141 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v135);\n\tv101 = v135 & 1;\n\tv81 = v101 == 0;\n\treturnVal2 = v81;\nL_0059:\n\treturn returnVal2;\n")]
		public override bool IsBlocking(Entity sandCube, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x60007EE")]
		[Address(RVA = "0x3E6C5FC", Offset = "0x3E6C5FC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags.BlockedByPinTag>::.ctor(this);\n\treturn;\n")]
		public PinBlockCondition()
		{
		}
	}
}
