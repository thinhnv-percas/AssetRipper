using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E6")]
	public class MoldReconcile_FillTextSystem
	{
		[Token(Token = "0x40008E7")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000CB7")]
		[Address(RVA = "0x3EDD74C", Offset = "0x3EDD74C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\treturn;\n")]
		public MoldReconcile_FillTextSystem(EntityManager em)
		{
			_em = em;
		}

		[Token(Token = "0x6000CB8")]
		[Address(RVA = "0x3EDE8B4", Offset = "0x3EDE8B4", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\nL_0044:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv345 = 0xB285000 + 0x5F8;\n\tv344 = 0xB285000 + 0x780;\n\tv343 = 0xB2C6000 + 0x920;\n\tv342 = 0xB2C6000 + 0x7F8;\nL_FFFFFFFF:\n\tv172 = 0;\n\tgoto L_005B;\nL_0058:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v508);\nL_FFFFFFFF:\n\tv269 = Il2CppMethodInfo;\nL_0059:\n\tv172 = v172 + 1;\n\tv266 = *([v356 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv266 = v266 + 0x10;\n\tv365 = v390 - 1;\n\tv364 = v390 != 1;\nL_FFFFFFFF:\n\tv390 = v365;\n\tif (v364) goto L_0066;\nL_007B:\n\tv384 = 0x220C5E0(v63, *([v345 @ X25_v12 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v384 @ X0_v38])(v280, v63, *([v384 @ X0_v38+8]), 0, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv235 = v172 < v280;\n\tif (v235) goto L_00A1;\n\tgoto L_0181;\nL_008E:\n\tv233 = *([v266 @ X10_v14]) << 4;\n\tv415 = v356 + v233;\n\tv416 = v415 + 0x138;\n\t*([v416 @ X0_v41])(v281, v63, *([v416 @ X0_v41+8]), v269, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv236 = v172 >= v281;\n\tif (v236) goto L_0181;\nL_00A1:\n\tv437 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv477 = *([v437 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv439 = *([v437 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v439) goto L_00C1;\n\tv486 = *([v437 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv486 = v486 + 0x10;\n\tv450 = v477 - 1;\n\tv448 = v477 != 1;\nL_FFFFFFFF:\n\tv477 = v450;\n\tif (v448) goto L_00AC;\nL_00C1:\n\tv505 = 0x220C5E0(v63, *([v344 @ X26_v10 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00CB;\nL_00C4:\n\tv501 = *([v486 @ X10_v9]) << 4;\n\tv502 = v437 + v501;\n\tv505 = v502 + 0x138;\n\tv512 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v508);\n\tv515 = ~v512;\nL_FFFFFFFF:\n\tv269 = 0;\n\tif (v515) goto L_0059;\n\tv269 = *([v343 @ X27_v10 (System.Int32)]);\n\tv525 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv529 = ~v525;\n\tif (v529) goto L_0059;\n\tv269 = *([v342 @ X24_v10 (System.Int32)]);\n\tv526 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv530 = ~v526;\n\tif (v530) goto L_0059;\n\tv527 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv536 = v527 == 0;\n\tv531 = ~v536;\nL_FFFFFFFF:\n\tv269 = Il2CppMethodInfo;\n\tif (v531) goto L_0059;\n\tv538 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v508);\n\tv540 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv542 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv543 = ~v542;\n\tif (v543) goto L_FFFFFFFF;\n\tv549 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v508);\n\tv561 = v549 >> 0x20;\n\tv554 = v561 == 0;\nL_FFFFFFFF:\n\tv216 = v554;\n\tgoto L_0126;\nL_FFFFFFFF:\n\tv216 = 0;\nL_0126:\n\tv563 = v538 >> 0x20;\n\tv568 = v563 == 0;\n\tv573 = v216 | v568;\n\tv119 = v573 == 0;\n\tv86 = ~v119;\n\tv72 = ~v86;\n\tif (v72) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv76 = v540;\n\tgoto L_0146;\nL_FFFFFFFF:\n\tv76 = 1;\n\tv582 = v528 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_015E;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v508, 0);\n\tv345 = 0xB285000 + 0x5F8;\nL_FFFFFFFF:\n\tv269 = 0;\n\tgoto L_0059;\nL_015E:\n\tv210 = v76 & v528;\n\tv345 = 0xB285000 + 0x5F8;\n\tv83 = v210 != 1;\nL_FFFFFFFF:\n\tv269 = Il2CppMethodInfo;\n\tif (v83) goto L_0059;\n\tv586 = this._em == 0;\n\tv197 = ~v586;\n\tif (v197) goto L_0058;\n\tthrow System.NullReferenceException;\nL_0181:\n\treturn;\nL_005B:\n\tv356 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv390 = *([v356 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv283 = *([v356 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v283) goto L_007B;\nL_0066:\n\tv403 = *([v266 @ X10_v14-8]) == *([v345 @ X25_v12 (System.Int32)]);\n\tif (v403) goto L_008E;\nL_00AC:\n\tv491 = *([v486 @ X10_v9-8]) == *([v344 @ X26_v10 (System.Int32)]);\n\tif (v491) goto L_00C4;\nL_00CB:\n\t*([v505 @ X0_v9])(v508, v63, v172, *([v505 @ X0_v9+8]), Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0146:\n\tv528 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v508);\n\tv579 = v76 == 0;\n\tv580 = ~v579;\n\tif (v580) goto L_015E;\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_FillTextSystem::Execute");
		}
	}
}
