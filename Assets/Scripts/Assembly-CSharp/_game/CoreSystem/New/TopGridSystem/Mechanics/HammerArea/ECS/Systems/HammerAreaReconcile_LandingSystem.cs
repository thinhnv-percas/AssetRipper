using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Responds;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems
{
	[Token(Token = "0x2000216")]
	public class HammerAreaReconcile_LandingSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x4000689")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x400068A")]
		[FieldOffset(Offset = "0x18")]
		private HammerAreaVisualHandler _visualHandler;

		[Token(Token = "0x6000958")]
		[Address(RVA = "0x3E9273C", Offset = "0x3E9273C", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\nL_003B:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv256 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv391 = *([v256 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv258 = *([v256 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v258) goto L_0066;\n\tv390 = *([v256 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv390 = v390 + 0x10;\n\tv373 = v391 - 1;\n\tv353 = v391 != 1;\n\tv391 = v373;\n\tif (v353) goto L_004D;\nL_0066:\n\tv404 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv140 = v404 - 1;\n\tv415 = v404 >= 1;\n\tif (v415) goto L_008F;\n\tgoto L_015D;\nL_0075:\n\tv421 = *([v390 @ X10_v14]) << 4;\n\tv422 = v256 + v421;\n\tv423 = v422 + 0x138;\n\t*([v423 @ X0_v34])(v427, v63, *([v423 @ X0_v34+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv431 = v427 < 1;\n\tv140 = v427 - 1;\n\tif (v431) goto L_015D;\nL_008F:\n\tv127 = &v120 @ stack_-80_v4 (System.Int32);\n\tgoto L_00A4;\nL_0091:\n\tv500 = v140 - 1;\n\tv487 = v140 <= 0;\n\tv140 = v500;\n\tif (v487) goto L_015D;\nL_00A4:\n\tgoto L_00CB;\n\tv589 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v588);\n\tv590 = ~v589;\n\tif (v590) goto L_0091;\n\tv615 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v588);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v588);\n\tv153 = v615 < 1;\n\tif (v153) goto L_0091;\n\tv603 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v588);\n\tv607 = ~v603;\n\tif (v607) goto L_0091;\n\tv604 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v588);\n\tv120 = v604.groupId;\n\tv154 = v604.visualCounter < 1;\n\tif (v154) goto L_0091;\n\tv125 = v604.visualCounter - v615;\n\t*([v127 @ X28_v4+C]) = *([v127 @ X28_v4+C]);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v588, &v120 @ stack_-80_v4 (System.Int32));\n\tv608 = this._visualHandler == 0;\n\tif (v608) goto L_0137;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler::RefreshCounter(this._visualHandler, v588);\nL_0137:\n\tv155 = v125 > 0;\n\tif (v155) goto L_0091;\n\tv606 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v588);\n\tv631 = v606 == 0;\n\tv609 = ~v631;\n\tif (v609) goto L_0091;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v588, v120);\n\tgoto L_0091;\nL_015D:\n\treturn;\nL_004D:\n\tv396 = *([v390 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v396) goto L_0075;\nL_00CB:\n\tv588 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v140);\n")]
		public unsafe void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaReconcile_LandingSystem::Execute");
		}

		[Token(Token = "0x6000959")]
		[Address(RVA = "0x3E90D24", Offset = "0x3E90D24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerAreaReconcile_LandingSystem()
		{
		}
	}
}
