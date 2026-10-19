using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000256")]
	public class SandReconcile_GridReleaseSystem
	{
		[Inject(false)]
		[Token(Token = "0x400072C")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400072D")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Token(Token = "0x6000A40")]
		[Address(RVA = "0x3EAC398", Offset = "0x3EAC398", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\nL_0041:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv197 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv310 = *([v197 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv199 = *([v197 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v199) goto L_006C;\n\tv309 = *([v197 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv309 = v309 + 0x10;\n\tv292 = v310 - 1;\n\tv272 = v310 != 1;\n\tv310 = v292;\n\tif (v272) goto L_0053;\nL_006C:\n\tv323 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv94 = v323 - 1;\n\tv334 = v323 >= 1;\n\tif (v334) goto L_0095;\n\tgoto L_0144;\nL_007B:\n\tv340 = *([v309 @ X10_v14]) << 4;\n\tv341 = v197 + v340;\n\tv342 = v341 + 0x138;\n\t*([v342 @ X0_v40])(v346, v63, *([v342 @ X0_v40+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv350 = v346 < 1;\n\tv94 = v346 - 1;\n\tif (v350) goto L_0144;\nL_0095:\n\tgoto L_00A9;\nL_0096:\n\tv408 = v94 - 1;\n\tv396 = v94 <= 0;\n\tv94 = v408;\n\tif (v396) goto L_0144;\nL_00A9:\n\tgoto L_00D0;\n\tv503 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v500);\n\tv504 = ~v503;\n\tif (v504) goto L_0096;\n\tv506 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v500);\n\tv517 = v506 == 0;\n\tv509 = ~v517;\n\tif (v509) goto L_0096;\n\tv507 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v500);\n\tv510 = ~v507;\n\tif (v510) goto L_0096;\n\tv508 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v500);\n\tv511 = ~v508;\n\tif (v511) goto L_0096;\n\tv519 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v500);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v500);\n\tv522 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v500);\n\tv524 = v522 == 0;\n\tv525 = ~v524;\n\tif (v525) goto L_0123;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v500, v519);\nL_0123:\n\tv535 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v500);\n\tv537 = v535 == 0;\n\tv538 = ~v537;\n\tif (v538) goto L_0135;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v500, 0);\nL_0135:\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::ReleaseSlot(this._gridHandler, v500);\n\tgoto L_0096;\nL_0144:\n\treturn;\nL_0053:\n\tv315 = *([v309 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v315) goto L_007B;\nL_00D0:\n\tv500 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v94);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_GridReleaseSystem::Execute");
		}

		[Token(Token = "0x6000A41")]
		[Address(RVA = "0x3EAC7CC", Offset = "0x3EAC7CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_GridReleaseSystem()
		{
		}
	}
}
