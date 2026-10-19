using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000258")]
	public class SandReconcile_NeighborDirtySystem
	{
		[Inject(false)]
		[Token(Token = "0x400072F")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000730")]
		[FieldOffset(Offset = "0x18")]
		private readonly TopGridHandler _gridHandler;

		[Token(Token = "0x6000A44")]
		[Address(RVA = "0x3EACB78", Offset = "0x3EACB78", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv291 = 0xB285000 + 0x5F8;\n\tv290 = 0xB285000 + 0x780;\n\tv154 = 0;\n\tgoto L_0039;\nL_0038:\n\tv154 = v154 + 1;\n\tv344 = *([v302 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv344 = v344 + 0x10;\n\tv311 = v335 - 1;\n\tv309 = v335 != 1;\n\tv335 = v311;\n\tif (v309) goto L_0040;\nL_005A:\n\tv332 = 0x220C5E0(v63, *([v291 @ X28_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v332 @ X0_v31])(v357, v63, *([v332 @ X0_v31+8]), 0, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv368 = v154 < v357;\n\tif (v368) goto L_007F;\n\tgoto L_0112;\nL_006C:\n\t;\n\tv371 = *([v344 @ X10_v14]) << 4;\n\tv372 = v302 + v371;\n\tv373 = v372 + 0x138;\n\t*([v373 @ X0_v34])(v377, v63, *([v373 @ X0_v34+8]), v276, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv387 = v154 >= v377;\n\tif (v387) goto L_0112;\nL_007F:\n\t;\n\tv406 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv440 = *([v406 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv408 = *([v406 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v408) goto L_00A0;\n\tv449 = *([v406 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv449 = v449 + 0x10;\n\tv416 = v440 - 1;\n\tv414 = v440 != 1;\n\tv440 = v416;\n\tif (v414) goto L_0086;\nL_00A0:\n\tv465 = 0x220C5E0(v63, *([v290 @ X27_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00A6;\nL_00A2:\n\t;\n\tv461 = *([v449 @ X10_v9]) << 4;\n\tv462 = v406 + v461;\n\tv465 = v462 + 0x138;\n\tv469 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v468);\n\tv470 = ~v469;\n\tv276 = 0;\n\tif (v470) goto L_0038;\n\tv491 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v468);\n\tv493 = ~v491;\n\tv276 = Il2CppMethodInfo;\n\tif (v493) goto L_0038;\n\tv500 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v468);\n\tv501 = v500 >> 0x20;\n\tv504 = v501 + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v482 @ stack_-70_v4 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v500, v504);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::MarkForReeval(this, v482);\n\tv514 = v501 - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v478 @ stack_-80_v4 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v500, v514);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::MarkForReeval(this, v478);\n\tv524 = v500 - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v475 @ stack_-90_v4 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v524, v501);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::MarkForReeval(this, v475);\n\tv535 = v500 + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v472 @ stack_-A0_v4 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v535, v501);\n\tv487 = v259 & 0xFFFFFFFF00000000;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::MarkForReeval(this, v472);\n\tv259 = v487;\n\tv276 = v487;\n\tgoto L_0038;\nL_0112:\n\treturn;\nL_0039:\n\t;\n\tv302 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv335 = *([v302 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv247 = *([v302 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v247) goto L_005A;\nL_0040:\n\t;\n\tv349 = *([v344 @ X10_v14-8]) == *([v291 @ X28_v8 (System.Int32)]);\n\tif (v349) goto L_006C;\nL_0086:\n\t;\n\tv454 = *([v449 @ X10_v9-8]) == *([v290 @ X27_v8 (System.Int32)]);\n\tif (v454) goto L_00A2;\nL_00A6:\n\t;\n\t*([v465 @ X0_v9])(v468, v63, v154, *([v465 @ X0_v9+8]), 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_NeighborDirtySystem::Execute");
		}

		[Token(Token = "0x6000A45")]
		[Address(RVA = "0x3EACE74", Offset = "0x3EACE74", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v51 @ stack_-40_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv123 = ~v52;\n\tif (v123) goto L_0099;\n\tv124 = coord & 0x80000000;\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0099;\n\tv197 = coord & 0x8000000000000000;\n\tv198 = v197 == 0;\n\tv156 = ~v198;\n\tif (v156) goto L_0099;\n\tv132 = v199 <= coord;\n\tif (v132) goto L_0099;\n\tv61 = v51 <= coord.y;\n\tif (v61) goto L_0099;\n\tv109 = this._gridHandler;\n\tgoto L_0059;\n\tv74 = coord << 0x20;\n\tv91 = coord.y | v74;\n\tv222 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v109._sandCubeByCoord, v91, &v95 @ stack_-40_v5 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv117 = &v95 @ stack_-40_v5 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_007A;\nL_007A:\n\tv153 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, *([v117 @ X20_v6]));\n\tv157 = ~v153;\n\tif (v157) goto L_0099;\n\tv154 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, *([v117 @ X20_v6]));\n\tv240 = v154 == 0;\n\tv158 = ~v240;\n\tif (v158) goto L_0099;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, *([v117 @ X20_v6]), 0);\nL_0099:\n\treturn;\nL_0059:\n\tv95 = 0;\n")]
		private void MarkForReeval(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_NeighborDirtySystem::MarkForReeval");
		}

		[Token(Token = "0x6000A46")]
		[Address(RVA = "0x3EAD100", Offset = "0x3EAD100", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_NeighborDirtySystem()
		{
		}
	}
}
