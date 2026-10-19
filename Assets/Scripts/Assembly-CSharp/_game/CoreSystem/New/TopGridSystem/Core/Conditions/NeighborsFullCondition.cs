using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Conditions
{
	[Token(Token = "0x200027C")]
	public class NeighborsFullCondition : PourableBlockCondition<BlockedByNeighborsTag>
	{
		[Token(Token = "0x170000D1")]
		public override BlockReason Reason
		{
			[Token(Token = "0x6000B26")]
			[Address(RVA = "0x3EC4AAC", Offset = "0x3EC4AAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
			get
			{
				return BlockReason.Neighbors;
			}
		}

		[Token(Token = "0x6000B27")]
		[Address(RVA = "0x3EC4AB4", Offset = "0x3EC4AB4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv96 = ~returnVal2;\n\tif (v96) goto L_0052;\n\tv104 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv170 = ~v104;\n\tif (v170) goto L_0058;\n\tv175 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv106 = v175 < 1;\n\tif (v106) goto L_0058;\n\tv179 = _game.CoreSystem.New.TopGridSystem.Core.Conditions.NeighborsFullCondition::IsAnyGroupMemberPourable(em, grid, v175);\n\tv130 = v179 == 0;\n\tif (v130) goto L_0058;\n\treturnVal2 = 0;\nL_0058:\n\tv87 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv188 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCubePourableByNeighbours(grid, v87);\n\treturnVal3 = v188 ^ 1;\n\treturn returnVal3;\nL_0052:\n\treturn returnVal2;\n")]
		public override bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NeighborsFullCondition::IsBlocking");
			return default;
		}

		[Token(Token = "0x6000B28")]
		[Address(RVA = "0x3EC4BE0", Offset = "0x3EC4BE0", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv214 = gid;\n\tv120 = 0;\n\tgoto L_0044;\nL_0042:\n\tv120 = v120 + 1;\n\tv214 = v215;\n\tv294 = *([v246 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv294 = v294 + 0x10;\n\tv259 = v285 - 1;\n\tv257 = v285 != 1;\n\tv285 = v259;\n\tif (v257) goto L_004F;\nL_0068:\n\tv307 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v65);\n\tv319 = v120 < v307;\n\tv77 = v307;\n\tif (v319) goto L_008F;\n\tv364 = v307;\n\tgoto L_00EC;\nL_0078:\n\tv322 = *([v294 @ X10_v14]) << 4;\n\tv323 = v246 + v322;\n\tv324 = v323 + 0x138;\n\t*([v324 @ X0_v31])(v328, v65, *([v324 @ X0_v31+8]), v214, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv339 = v120 >= v328;\n\tv77 = v328;\n\tv364 = v328;\n\tif (v339) goto L_00EC;\nL_008F:\n\tgoto L_00B6;\n\tv461 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v452);\n\tv465 = ~v461;\n\tv215 = Il2CppMethodInfo;\n\tif (v465) goto L_0042;\n\tv464 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v452);\n\tv82 = v464 != gid;\n\tv215 = Il2CppMethodInfo;\n\tif (v82) goto L_0042;\n\tv474 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v452);\n\tv476 = v452 & 0xFFFFFFFF;\n\tv477 = v211 & 0xFFFFFFFF00000000;\n\tv211 = v477 | v476;\n\tv377 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCubePourableByNeighbours(grid, v474);\n\tv378 = v377 == 0;\n\tv215 = v211;\n\tv364 = v77;\n\tif (v378) goto L_0042;\nL_00EC:\n\tv177 = v120 - v364;\n\tv175 = v177 < 0;\n\tv171 = v120 ^ v364;\n\tv169 = v120 ^ v177;\n\tv167 = v171 & v169;\n\tv165 = v167 < 0;\n\tv380 = v175 == v165;\n\tv161 = ~v380;\n\treturn v161;\nL_0044:\n\tv246 = *([v65 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv285 = *([v246 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv248 = *([v246 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v248) goto L_0068;\nL_004F:\n\tv299 = *([v294 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v299) goto L_0078;\nL_00B6:\n\tv452 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v65, v120);\n\tv456 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v452);\n\tv457 = ~v456;\n\tv215 = Il2CppMethodInfo;\n\tif (v457) goto L_0042;\n")]
		private static bool IsAnyGroupMemberPourable(EntityManager em, TopGridHandler grid, int gid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NeighborsFullCondition::IsAnyGroupMemberPourable");
			return default;
		}

		[Token(Token = "0x6000B29")]
		[Address(RVA = "0x3EC4E4C", Offset = "0x3EC4E4C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.CoreSystem.New.TopGridSystem.Core.Conditions.PourableBlockCondition`1<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags.BlockedByNeighborsTag>::.ctor(this);\n\treturn;\n")]
		public NeighborsFullCondition()
		{
		}
	}
}
