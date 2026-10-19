using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode
{
	[Token(Token = "0x20001B0")]
	public class PinRemoveHook : IEntityRemoveHook
	{
		[Inject(false)]
		[Token(Token = "0x4000549")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400054A")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(true)]
		[Token(Token = "0x400054B")]
		[FieldOffset(Offset = "0x20")]
		private PinEditorMutations _mutations;

		[Inject(true)]
		[Token(Token = "0x400054C")]
		[FieldOffset(Offset = "0x28")]
		private PinBlockerVisualHandler _visualHandler;

		[Token(Token = "0x400054D")]
		[FieldOffset(Offset = "0x30")]
		internal readonly HashSet<int> _touchedPinIds;

		[Token(Token = "0x60007DF")]
		[Address(RVA = "0x3E70850", Offset = "0x3E70850", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._touchedPinIds);\n\tv140 = entities == 0;\n\tif (v140) goto L_00E1;\n\tv147 = 0;\n\tgoto L_0044;\nL_0042:\n\tv147 = v147 + 1;\n\tv121 = *([v290 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv121 = v121 + 0x10;\n\tv296 = v318 - 1;\n\tv295 = v318 != 1;\n\tv318 = v296;\n\tif (v295) goto L_004F;\nL_0068:\n\tv137 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(entities);\n\tv80 = v147 < v137;\n\tif (v80) goto L_008D;\n\tgoto L_00E1;\nL_0077:\n\tv74 = *([v121 @ X10_v14]) << 4;\n\tv340 = v290 + v74;\n\tv341 = v340 + 0x138;\n\t*([v341 @ X0_v27])(v138, entities, *([v341 @ X0_v27+8]), v77, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv81 = v147 >= v138;\n\tif (v81) goto L_00E1;\nL_008D:\n\tgoto L_00B4;\n\tv425 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v424);\n\tv426 = ~v425;\n\tv77 = 0;\n\tif (v426) goto L_0042;\n\tv429 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v424);\n\tv431 = ~v429;\n\tv77 = Il2CppMethodInfo;\n\tif (v431) goto L_0042;\n\tv212 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v424);\n\tv430 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._touchedPinIds, v212);\n\tv77 = Il2CppMethodInfo;\n\tgoto L_0042;\nL_00E1:\n\treturn;\nL_002B:\n\tv57 = this._visualHandler == 0;\n\tif (v57) goto L_00E1;\nL_0044:\n\tv290 = entities->klass;\n\tv318 = entities->klass->interface_offsets_count;\n\tv141 = *([v290 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v141) goto L_0068;\nL_004F:\n\tv331 = *([v121 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v331) goto L_0077;\nL_00B4:\n\tv424 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(entities, v147);\n")]
		public void OnBeforeRemove(IReadOnlyList<Entity> entities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinRemoveHook::OnBeforeRemove");
		}

		[Token(Token = "0x60007E0")]
		[Address(RVA = "0x3E70A7C", Offset = "0x3E70A7C", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv96 = ~v51;\n\tif (v96) goto L_0077;\n\tv104 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv109 = ~v104;\n\tif (v109) goto L_0077;\n\tv105 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv110 = ~v105;\n\tif (v110) goto L_0077;\n\tv147 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv148 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v147);\n\tv106 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v148);\n\tv111 = ~v106;\n\tif (v111) goto L_0077;\n\tv107 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v148);\n\tv112 = ~v107;\n\tif (v112) goto L_0077;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v148);\n\treturn;\nL_0077:\n\treturn;\n")]
		public void OnBeforeDestroyEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinRemoveHook::OnBeforeDestroyEntity");
		}

		[Token(Token = "0x60007E1")]
		[Address(RVA = "0x3E70BEC", Offset = "0x3E70BEC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv56 = v50.Count == 0;\n\tif (v56) goto L_0064;\n\tv110 = 0xB2A6000 + 0x940;\n\tv136 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(this._touchedPinIds);\n\tv177 = v136;\n\tv239 = this._mutations == 0;\n\tif (v239) goto L_0044;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinEditorMutations::RemovePin(this._mutations, v136._current);\n\tgoto L_0044;\nL_0050:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v177 @ stack_-58_v5 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv89 = 0;\n\tv107 = Il2CppMethodInfo;\nL_0052:\n\tv116 = this._touchedPinIds == 0;\n\tif (v116) goto L_0065;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._touchedPinIds);\n\tv163 = this._visualHandler == 0;\n\tif (v163) goto L_0064;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ResyncAll(this._visualHandler);\nL_0064:\n\treturn;\nL_0065:\n\tv121 = new System.NullReferenceException();\n\tgoto L_0071;\nL_0071:\n\tv186 = v107 != 1;\n\tv225 = v121;\n\tif (v186) goto L_0081;\n\tv243 = 0x8BF5BC4(v121, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv257 = 0x8BF5BF4(v243, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv107 = *([v110 @ X22_v4 (System.Int32)]);\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v177 @ stack_-58_v5 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv248 = *([v243 @ X0_v12]) == 0;\n\tv89 = *([v243 @ X0_v12]);\n\tif (v248) goto L_0052;\n\tv247 = new System.OutOfMemoryException();\n\tv89 = *([v243 @ X0_v12]);\n\tv225 = v247;\n\treturn;\nL_0025:\n\tv177 = 0;\n\tv50 = this._touchedPinIds;\n\tv51 = this._touchedPinIds == 0;\n\tif (v51) goto L_0065;\nL_0044:\n\tv241 = System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v177 @ stack_-58_v5 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv255 = v241 == 0;\n\tif (v255) goto L_0050;\nL_0081:\n\tv251 = 0x3179F58(&v89 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv259 = 0x8BF0368(v225, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = 0xA1B8(v259, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterRemove()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinRemoveHook::OnAfterRemove");
		}

		[Token(Token = "0x60007E2")]
		[Address(RVA = "0x3E6D38C", Offset = "0x3E6D38C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v48);\n\tthis._touchedPinIds = v48;\n")]
		public PinRemoveHook()
		{
			HashSet<int> touchedPinIds = new HashSet<int>();
			_touchedPinIds = touchedPinIds;
		}
	}
}
