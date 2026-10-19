using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Commands;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000257")]
	public class SandReconcile_MaterialSystem
	{
		[Inject(false)]
		[Token(Token = "0x400072E")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000A42")]
		[Address(RVA = "0x3EAC7D4", Offset = "0x3EAC7D4", Length = "0x39C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\nL_0044:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv298 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv339 = *([v298 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv273 = *([v298 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v273) goto L_006F;\n\tv258 = *([v298 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv258 = v258 + 0x10;\n\tv324 = v339 - 1;\n\tv306 = v339 != 1;\nL_FFFFFFFF:\n\tv339 = v324;\n\tif (v306) goto L_0056;\nL_006F:\n\tv269 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv96 = v269 - 1;\n\tv221 = v269 >= 1;\n\tif (v221) goto L_0091;\n\tgoto L_016B;\nL_007E:\n\tv212 = *([v258 @ X10_v17]) << 4;\n\tv355 = v298 + v212;\n\tv356 = v355 + 0x138;\n\t*([v356 @ X0_v41])(v270, v63, *([v356 @ X0_v41+8]), v37, v192, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv246 = v270 < 1;\n\tv96 = v270 - 1;\n\tif (v246) goto L_016B;\nL_0091:\n\tv210 = 0xB285000 + 0x780;\n\tgoto L_00CD;\nL_00A1:\n\tv512 = v555 == 0;\n\tv502 = ~v512;\n\tv492 = ~v502;\n\tif (v492) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv532 = 0x100000000;\n\tgoto L_00B2;\nL_FFFFFFFF:\n\tv532 = 0;\nL_00CD:\n\tv412 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv461 = *([v412 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv414 = *([v412 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v414) goto L_00ED;\n\tv460 = *([v412 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv460 = v460 + 0x10;\n\tv443 = v461 - 1;\n\tv423 = v461 != 1;\nL_FFFFFFFF:\n\tv461 = v443;\n\tif (v423) goto L_00D8;\nL_00ED:\n\tv480 = 0x220C5E0(v63, *([v210 @ X25_v7 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00F7;\nL_00F0:\n\tv476 = *([v460 @ X10_v12]) << 4;\n\tv477 = v412 + v476;\n\tv480 = v477 + 0x138;\n\tv487 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v483);\n\tv490 = ~v487;\n\tif (v490) goto L_00BD;\n\tv537 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv539 = v537 == 0;\n\tv540 = ~v539;\n\tif (v540) goto L_0124;\n\tv542 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv546 = v542 == 0;\n\tv544 = ~v546;\n\tif (v544) goto L_0124;\n\tv523 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv527 = ~v523;\n\tif (v527) goto L_00BD;\nL_0124:\n\tv524 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv548 = v524 == 0;\n\tv528 = ~v548;\n\tif (v528) goto L_00BD;\n\tv525 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv551 = v525 == 0;\n\tv529 = ~v551;\n\tif (v529) goto L_00BD;\n\tv526 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\tv530 = ~v526;\n\tif (v530) goto L_00BD;\n\tv553 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v483);\n\tv555 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v483);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v483);\n\tv557 = this._em == 0;\n\tv167 = ~v557;\n\tif (v167) goto L_00A1;\n\tthrow System.NullReferenceException;\nL_016B:\n\treturn;\nL_0056:\n\tv344 = *([v258 @ X10_v17-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v344) goto L_007E;\nL_00B2:\n\tv499 = v532 | v553;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v483, v499);\n\tv210 = 0xB285000 + 0x780;\nL_00D8:\n\tv466 = *([v460 @ X10_v12-8]) == *([v210 @ X25_v7 (System.Int32)]);\n\tif (v466) goto L_00F0;\nL_00F7:\n\t*([v480 @ X0_v9])(v483, v63, v96, *([v480 @ X0_v9+8]), Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00BD:\n\tv278 = v96 - 1;\n\tv223 = v96 <= 0;\nL_FFFFFFFF:\n\tv96 = v278;\n\tif (v223) goto L_016B;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_MaterialSystem::Execute");
		}

		[Token(Token = "0x6000A43")]
		[Address(RVA = "0x3EACB70", Offset = "0x3EACB70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_MaterialSystem()
		{
		}
	}
}
