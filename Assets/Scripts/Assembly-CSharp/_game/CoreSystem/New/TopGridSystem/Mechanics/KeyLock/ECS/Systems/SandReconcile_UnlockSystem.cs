using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems
{
	[Token(Token = "0x20001FE")]
	public class SandReconcile_UnlockSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x400065E")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400065F")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000660")]
		[FieldOffset(Offset = "0x20")]
		private LockGroupHandler _lockGroups;

		[Token(Token = "0x6000911")]
		[Address(RVA = "0x3E8CC50", Offset = "0x3E8CC50", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\nL_0041:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv240 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv355 = *([v240 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv242 = *([v240 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v242) goto L_006C;\n\tv354 = *([v240 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv354 = v354 + 0x10;\n\tv337 = v355 - 1;\n\tv317 = v355 != 1;\n\tv355 = v337;\n\tif (v317) goto L_0053;\nL_006C:\n\tv368 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv111 = v368 - 1;\n\tv379 = v368 >= 1;\n\tif (v379) goto L_0090;\n\tgoto L_017B;\nL_007B:\n\tv385 = *([v354 @ X10_v14]) << 4;\n\tv386 = v240 + v385;\n\tv387 = v386 + 0x138;\n\t*([v387 @ X0_v48])(v391, v63, *([v387 @ X0_v48+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv395 = v391 < 1;\n\tv111 = v391 - 1;\n\tif (v395) goto L_017B;\nL_0090:\n\t;\n\tgoto L_00A7;\nL_0094:\n\tv460 = v111 - 1;\n\tv447 = v111 <= 0;\n\tv111 = v460;\n\tif (v447) goto L_017B;\nL_00A7:\n\tgoto L_00CE;\n\tv555 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v552);\n\tv556 = ~v555;\n\tif (v556) goto L_0094;\n\tv582 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v552);\n\tv114 = v582 >> 0x20;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v86 @ stack_-70_v5 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v582, v114);\n\tv585 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetKeyAt(this._gridHandler, v86);\n\tv569 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v585);\n\tv572 = ~v569;\n\tif (v572) goto L_0094;\n\tv570 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v585);\n\tv573 = ~v570;\n\tif (v573) goto L_0094;\n\tv587 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v585);\n\tv198 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.LockGroupHandler::GetGroup(this._lockGroups, v587);\n\tv599 = v198.Count < 1;\n\tif (v599) goto L_015B;\n\tv102 = 0;\n\tgoto L_0134;\nL_0122:\n\tv102 = v102 + 1;\n\tv604 = v102 >= v198.Count;\n\tif (v604) goto L_015B;\nL_0134:\n\tv627 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v198, v102);\n\tv633 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v627);\n\tv634 = ~v633;\n\tif (v634) goto L_0122;\n\tv639 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v627);\n\tv646 = v639 == 0;\n\tv640 = ~v646;\n\tif (v640) goto L_0122;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v627, v587);\n\tgoto L_0122;\nL_015B:\n\tv571 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v585);\n\tv632 = v571 == 0;\n\tv574 = ~v632;\n\tif (v574) goto L_0094;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v585, v587);\n\tgoto L_0094;\nL_017B:\n\treturn;\nL_0053:\n\tv360 = *([v354 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v360) goto L_007B;\nL_00CE:\n\tv552 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v111);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_UnlockSystem::Execute");
		}

		[Token(Token = "0x6000912")]
		[Address(RVA = "0x3E8D034", Offset = "0x3E8D034", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_UnlockSystem()
		{
		}
	}
}
