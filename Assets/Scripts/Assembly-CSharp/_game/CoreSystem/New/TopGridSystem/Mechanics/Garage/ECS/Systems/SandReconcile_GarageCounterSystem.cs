using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems
{
	[Token(Token = "0x2000232")]
	public class SandReconcile_GarageCounterSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x40006CE")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x40006CF")]
		[FieldOffset(Offset = "0x18")]
		private GarageVisualHandler _visualHandler;

		[Token(Token = "0x60009B1")]
		[Address(RVA = "0x3E99958", Offset = "0x3E99958", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\nL_003B:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv193 = 0;\n\tv579 = 0;\n\tgoto L_004E;\nL_004C:\n\tv193 = v193 + 1;\n\tv413 = *([v364 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv413 = v413 + 0x10;\n\tv377 = v404 - 1;\n\tv375 = v404 != 1;\n\tv404 = v377;\n\tif (v375) goto L_0059;\nL_006E:\n\tv398 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v63, System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv398.m_value(v426, v63, *([v398 @ X0_v53 (System.Boolean)+8]), 0, v553, v551, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv437 = v193 < v426;\n\tif (v437) goto L_0097;\n\tv259 = 0;\n\tgoto L_00D0;\nL_0081:\n\tv443 = *([v413 @ X10_v28]) << 4;\n\tv444 = v364 + v443;\n\tv445 = v444 + 0x138;\n\t*([v445 @ X0_v56])(v449, v63, *([v445 @ X0_v56+8]), v259, v553, v551, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv459 = v193 >= v449;\n\tif (v459) goto L_00D0;\nL_0097:\n\tgoto L_00BE;\n\tv546 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v545);\n\tv548 = ~v546;\n\tv259 = 0;\n\tif (v548) goto L_004C;\n\tv594 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v545);\n\tv579 = v579 + v594;\n\tv259 = Il2CppMethodInfo;\n\tgoto L_004C;\nL_00D0:\n\tv308 = v579 == 0;\n\tif (v308) goto L_01C3;\n\tv213 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv192 = 0;\n\tgoto L_00E4;\nL_00E1:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v727, v216);\n\tv551 = Il2CppMethodInfo;\n\tv553 = Il2CppMethodInfo;\n\tv259 = v216;\nL_00E2:\n\tv192 = v192 + 1;\n\tv292 = *([v589 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv292 = v292 + 0x10;\n\tv599 = v621 - 1;\n\tv598 = v621 != 1;\n\tv621 = v599;\n\tif (v598) goto L_00EF;\nL_0108:\n\tv305 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v213);\n\tv261 = v192 < v305;\n\tif (v261) goto L_012D;\n\tgoto L_01C3;\nL_0117:\n\tv256 = *([v292 @ X10_v16]) << 4;\n\tv643 = v589 + v256;\n\tv644 = v643 + 0x138;\n\t*([v644 @ X0_v37])(v306, v213, *([v644 @ X0_v37+8]), v259, v553, v551, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv262 = v192 >= v306;\n\tif (v262) goto L_01C3;\nL_012D:\n\tgoto L_0154;\n\tv728 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v727);\n\tv729 = ~v728;\n\tv259 = 0;\n\tif (v729) goto L_00E2;\n\tv733 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v727);\n\tv736 = ~v733;\n\tv259 = Il2CppMethodInfo;\n\tif (v736) goto L_00E2;\n\tv216 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v727);\n\tv108 = v216.counter < 1;\n\tv259 = Il2CppMethodInfo;\n\tif (v108) goto L_00E2;\n\tv744 = v216.counter - v579;\n\tv745 = ~v744;\n\tv184 = v744 & v745;\n\tv747 = v216 | v184;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v727, v747);\n\tv752 = this._visualHandler == 0;\n\tv259 = v747;\n\tif (v752) goto L_01A3;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::RefreshCounter(this._visualHandler, v727);\n\tv757 = this._visualHandler == 0;\n\tv259 = v747;\n\tif (v757) goto L_01A3;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::PlayHitVfx(this._visualHandler, v727, v184);\n\tv259 = v184;\nL_01A3:\n\tv103 = v744 > 0;\n\tv551 = Il2CppMethodInfo;\n\tv553 = v727;\n\tif (v103) goto L_00E2;\n\tv735 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v727);\n\tv762 = v735 == 0;\n\tv738 = ~v762;\n\tv551 = Il2CppMethodInfo;\n\tv553 = v727;\n\tv259 = Il2CppMethodInfo;\n\tif (v738) goto L_00E2;\n\tv763 = this._em == 0;\n\tv221 = ~v763;\n\tif (v221) goto L_00E1;\n\tthrow System.NullReferenceException;\nL_01C3:\n\treturn;\nL_004E:\n\tv364 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv404 = *([v364 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv366 = *([v364 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v366) goto L_006E;\nL_0059:\n\tv418 = *([v413 @ X10_v28-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v418) goto L_0081;\nL_00BE:\n\tv545 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v193);\nL_00E4:\n\tv589 = *([v213 @ X0_v10 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv621 = *([v589 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv309 = *([v589 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v309) goto L_0108;\nL_00EF:\n\tv634 = *([v292 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v634) goto L_0117;\nL_0154:\n\tv727 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v213, v192);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_GarageCounterSystem::Execute");
		}

		[Token(Token = "0x60009B2")]
		[Address(RVA = "0x3E97FE4", Offset = "0x3E97FE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_GarageCounterSystem()
		{
		}
	}
}
