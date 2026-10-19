using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x200025C")]
	public class SandReconcile_TapEventSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x400073B")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x400073C")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x400073D")]
		[FieldOffset(Offset = "0x20")]
		private int _moveNumber;

		[Token(Token = "0x6000A4D")]
		[Address(RVA = "0x3EADC9C", Offset = "0x3EADC9C", Length = "0x4E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\nL_0043:\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv178 = &v162 @ stack_-74 (System.Int32);\n\tv188 = 0;\n\tgoto L_0063;\nL_0053:\n\tv774 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::GetHashCode(&v72 @ stack_-80_v4 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\t*([v178 @ X24_v2+F]) = 0;\n\t*([v178 @ X24_v2+D]) = 0;\n\tv162 = v774;\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(this._eventBus, &v162 @ stack_-74 (System.Int32));\n\tv162 = v774;\n\tv559 = Il2CppMethodInfo;\nL_0061:\n\tv188 = v188 + 1;\n\tv394 = *([v345 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv394 = v394 + 0x10;\n\tv358 = v385 - 1;\n\tv356 = v385 != 1;\n\tv385 = v358;\n\tif (v356) goto L_0069;\nL_0083:\n\tv379 = Unco.EventBusSystem.Runtime.EventBus::InvokeEvent(v65, System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\t*([v379 @ X0_v64])(v407, v65, *([v379 @ X0_v64+8]), 0, v539, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv418 = v188 < v407;\n\tif (v418) goto L_00AC;\n\tv559 = 0;\n\tgoto L_0100;\nL_0095:\n\t;\n\tv424 = *([v394 @ X10_v28]) << 4;\n\tv425 = v345 + v424;\n\tv426 = v425 + 0x138;\n\t*([v426 @ X0_v67])(v430, v65, *([v426 @ X0_v67+8]), v559, v539, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv440 = v188 >= v430;\n\tif (v440) goto L_0100;\nL_00AC:\n\tgoto L_00D3;\n\tv537 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v533);\n\tv575 = ~v537;\n\tv559 = 0;\n\tif (v575) goto L_0061;\n\tv618 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v533);\n\tv621 = ~v618;\n\tv559 = Il2CppMethodInfo;\n\tif (v621) goto L_0061;\n\tv619 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v533);\n\tv622 = this._eventBus == 0;\n\tv559 = Il2CppMethodInfo;\n\tif (v622) goto L_0061;\n\tgoto L_0053;\nL_0100:\n\tv202 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv182 = &v162 @ stack_-74 (System.Int32);\n\tv189 = 0;\n\tgoto L_0109;\nL_0107:\n\tv189 = v189 + 1;\n\tv636 = *([v573 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv636 = v636 + 0x10;\n\tv583 = v627 - 1;\n\tv581 = v627 != 1;\n\tv627 = v583;\n\tif (v581) goto L_010F;\nL_012B:\n\t;\n\tv649 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v202);\n\tv660 = v189 < v649;\n\tif (v660) goto L_0152;\n\tgoto L_01DC;\nL_013B:\n\t;\n\tv663 = *([v636 @ X10_v16]) << 4;\n\tv664 = v573 + v663;\n\tv665 = v664 + 0x138;\n\t*([v665 @ X0_v40])(v669, v202, *([v665 @ X0_v40+8]), v559, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv679 = v189 >= v669;\n\tif (v679) goto L_01DC;\nL_0152:\n\tgoto L_0179;\n\tv763 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v762);\n\tv769 = ~v763;\n\tv559 = 0;\n\tif (v769) goto L_0107;\n\tv805 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v762);\n\tv795 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v762);\n\tv807 = ~v795;\n\tif (v807) goto L_01A5;\n\tv794 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v762);\n\tv790 = this._eventBus;\n\tv820 = this._eventBus == 0;\n\tv797 = ~v820;\n\tv778 = v794;\n\tif (v797) goto L_01AE;\n\tv559 = Il2CppMethodInfo;\n\tgoto L_0107;\nL_01A5:\n\tv790 = this._eventBus;\n\tv798 = this._eventBus == 0;\n\tv559 = Il2CppMethodInfo;\n\tv778 = 0;\n\tif (v798) goto L_0107;\nL_01AE:\n\tgoto L_01B0;\nL_01B0:\n\tv787 = v805 >> 0x20;\n\tv825 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::GetHashCode(&v75 @ stack_-88_v4 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\t*([v182 @ X27_v4+F]) = 0;\n\t*([v182 @ X27_v4+D]) = 0;\n\tv162 = v825;\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(v790, &v162 @ stack_-74 (System.Int32));\n\tv799 = this._eventBus == 0;\n\tv559 = Il2CppMethodInfo;\n\tif (v799) goto L_0107;\n\tv830 = this._moveNumber + 1;\n\tthis._moveNumber = v830;\n\tv786 = v787 | v778;\n\tv793 = v830 | v805;\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(this._eventBus, v793);\n\tv559 = v786;\n\tgoto L_0107;\nL_01DC:\n\treturn;\nL_0063:\n\tv345 = *([v65 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv385 = *([v345 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv347 = *([v345 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v347) goto L_0083;\nL_0069:\n\t;\n\tv399 = *([v394 @ X10_v28-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v399) goto L_0095;\nL_00D3:\n\tv533 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v65, v188);\n\tv72 = v533;\nL_0109:\n\tv573 = *([v202 @ X0_v9 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv627 = *([v573 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv300 = *([v573 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v300) goto L_012B;\nL_010F:\n\t;\n\tv641 = *([v636 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v641) goto L_013B;\nL_0179:\n\tv762 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v202, v189);\n\tv75 = v762;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_TapEventSystem::Execute");
		}

		[Token(Token = "0x6000A4E")]
		[Address(RVA = "0x3EAE17C", Offset = "0x3EAE17C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_TapEventSystem()
		{
		}
	}
}
