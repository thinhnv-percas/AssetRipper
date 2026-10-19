using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared
{
	[Token(Token = "0x200023C")]
	public static class FrozenNeighborQuery
	{
		[Token(Token = "0x60009C6")]
		[Address(RVA = "0x3E9AAE4", Offset = "0x3E9AAE4", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = coord.y - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v30 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v28);\n\tv37 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::IsFreezer(em, grid, v30);\n\tv44 = coord.y + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v30 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v44);\n\tv51 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::IsFreezer(em, grid, v30);\n\tv56 = v37 == 0;\n\tv62 = ~v56;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\n\tv66 = 1 + 1;\n\tgoto L_003D;\nL_FFFFFFFF:\n\tv66 = 1;\nL_FFFFFFFF:\n\tv80 = v66;\n\tgoto L_004B;\nL_FFFFFFFF:\n\tv80 = v37;\n\tv105 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::IsFreezer(em, grid, v30);\n\tv106 = v92 + v105;\n\treturnVal1 = v80 + v106;\n\treturn returnVal1;\nL_003D:\n\tv71 = v51 == 0;\n\tv76 = ~v71;\n\tv77 = ~v76;\n\tif (v77) goto L_FFFFFFFF;\nL_004B:\n\tv83 = coord - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v30 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v83, coord.y);\n\tv92 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::IsFreezer(em, grid, v30);\n\tv98 = coord + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v30 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v98, coord.y);\n")]
		public static int CountLiveFreezers(EntityManager em, TopGridHandler grid, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenNeighborQuery::CountLiveFreezers");
			return default;
		}

		[Token(Token = "0x60009C7")]
		[Address(RVA = "0x3E9B3A0", Offset = "0x3E9B3A0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv55 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsValidCoord(grid, c);\n\tv68 = ~v55;\n\tif (v68) goto L_004C;\n\tv61 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(grid, c);\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v61);\n\tv77 = ~v75;\n\tif (v77) goto L_004C;\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v61);\n\treturn returnVal3;\nL_004C:\n\treturn 0;\n")]
		private static bool IsFreezer(EntityManager em, TopGridHandler grid, GridCoord c)
		{
			if (grid.IsValidCoord(c))
			{
				Entity sandCubeAt = grid.GetSandCubeAt(c);
				if (em.IsValid(sandCubeAt))
				{
					return em.HasComponent<FreezerTag>(sandCubeAt);
				}
			}
			return false;
		}
	}
}
