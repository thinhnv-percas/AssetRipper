using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Responds;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems
{
	[Token(Token = "0x20001B2")]
	public class SandReconcile_PinResolveSystem : ITopGridEcsSystem, IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x400054E")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400054F")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Token(Token = "0x60007E4")]
		[Address(RVA = "0x3E70DD4", Offset = "0x3E70DD4", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\nL_0038:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv189 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv300 = *([v189 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv191 = *([v189 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v191) goto L_0063;\n\tv299 = *([v189 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv282 = v300 - 1;\n\tv262 = v300 != 1;\n\tv300 = v282;\n\tif (v262) goto L_004A;\nL_0063:\n\tv313 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_0073;\n\tgoto L_0161;\nL_0069:\n\tv321 = *([v299 @ X10_v20]) << 4;\n\tv322 = v189 + v321;\n\tv323 = v322 + 0x138;\n\t*([v323 @ X0_v47])(v327, v63, *([v323 @ X0_v47+8]), v331, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv328 = v327 == 0;\n\tif (v328) goto L_0161;\nL_0073:\n\tv348 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv449 = *([v348 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv350 = *([v348 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v350) goto L_0097;\n\tv397 = *([v348 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv397 = v397 + 0x10;\n\tv435 = v449 - 1;\n\tv417 = v449 != 1;\n\tv449 = v435;\n\tif (v417) goto L_007E;\nL_0097:\n\tv407 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv137 = v407 - 1;\n\tv369 = v407 >= 1;\n\tif (v369) goto L_00C0;\n\tgoto L_0161;\nL_00A6:\n\tv366 = *([v397 @ X10_v15]) << 4;\n\tv462 = v348 + v366;\n\tv463 = v462 + 0x138;\n\t*([v463 @ X0_v40])(v408, v63, *([v463 @ X0_v40+8]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv388 = v408 < 1;\n\tv137 = v408 - 1;\n\tif (v388) goto L_0161;\nL_00C0:\n\tgoto L_00DA;\nL_00C6:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(this._em, v570);\nL_00C7:\n\tv413 = v137 - 1;\n\tv371 = v137 <= 0;\n\tv137 = v413;\n\tif (v371) goto L_0161;\nL_00DA:\n\tgoto L_0101;\n\tv571 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v570);\n\tv572 = ~v571;\n\tif (v572) goto L_00C7;\n\tv579 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v570);\n\tv580 = ~v579;\n\tif (v580) goto L_00C6;\n\tv592 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v570);\n\tv596 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v592);\n\tv585 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v596);\n\tv588 = ~v585;\n\tif (v588) goto L_00C6;\n\tv598 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v596);\n\tv599 = ~v598;\n\tif (v599) goto L_0145;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v596);\nL_0145:\n\tv586 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v596);\n\tv607 = v586 == 0;\n\tv589 = ~v607;\n\tif (v589) goto L_00C6;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v596, 0);\n\tgoto L_00C6;\nL_0161:\n\treturn;\nL_004A:\n\tv305 = *([v299 @ X10_v20-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v305) goto L_0069;\nL_007E:\n\tv454 = *([v397 @ X10_v15-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v454) goto L_00A6;\nL_0101:\n\tv570 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v137);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_PinResolveSystem::Execute");
		}

		[Token(Token = "0x60007E5")]
		[Address(RVA = "0x3E6C76C", Offset = "0x3E6C76C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_PinResolveSystem()
		{
		}
	}
}
