using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.SpawnHandlers
{
	[Token(Token = "0x20001F2")]
	public class LockTunnelSpawnHandler : TunnelSpawnHandlerBase
	{
		[Inject(true)]
		[Token(Token = "0x400063B")]
		[FieldOffset(Offset = "0x18")]
		private LockVisualHandler _lockHandler;

		[Token(Token = "0x60008E4")]
		[Address(RVA = "0x3E892F4", Offset = "0x3E892F4", Length = "0x3C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv358 = slotEntities;\n\tv137 = tunnel;\n\tv155 = 0;\n\tgoto L_005E;\nL_004F:\n\tv587 = new System.Action();\n\tSystem.Action::.ctor(v587, v275, Il2CppMethodInfo);\n\tv525 = PrimeTween.Sequence::OnComplete(&v182 @ stack_-80_v5 (PrimeTween.Sequence), v587, 1);\n\tv358 = 0;\n\tv137 = 1;\nL_005C:\n\tv155 = v155 + 1;\n\tv128 = *([v371 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv128 = v128 + 0x10;\n\tv380 = v405 - 1;\n\tv379 = v405 != 1;\n\tv405 = v380;\n\tif (v379) goto L_0064;\nL_0080:\n\t;\n\tv147 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(slotEntities);\n\tv87 = v155 < v147;\n\tif (v87) goto L_00A4;\n\tgoto L_015F;\nL_0090:\n\t;\n\tv84 = *([v128 @ X10_v14]) << 4;\n\tv430 = v371 + v84;\n\tv431 = v430 + 0x138;\n\t*([v431 @ X0_v54])(v148, slotEntities, *([v431 @ X0_v54+8]), v137, v358, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv88 = v155 >= v148;\n\tif (v88) goto L_015F;\nL_00A4:\n\tv451 = slotEntities->klass;\n\tv477 = slotEntities->klass->interface_offsets_count;\n\tv453 = *([v451 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v453) goto L_00C6;\n\tv246 = *([v451 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv246 = v246 + 0x10;\n\tv460 = v477 - 1;\n\tv459 = v477 != 1;\n\tv477 = v460;\n\tif (v459) goto L_00AA;\nL_00C6:\n\t;\n\tv499 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(slotEntities, v155);\n\tv488 = em == 0;\n\tv278 = ~v488;\n\tif (v278) goto L_00DD;\n\tgoto L_0160;\nL_00CE:\n\t;\n\tv193 = *([v246 @ X10_v9]) << 4;\n\tv493 = v451 + v193;\n\tv494 = v493 + 0x138;\n\t*([v494 @ X0_v47])(v499, slotEntities, v155, *([v494 @ X0_v47+8]), v358, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00DD:\n\tv505 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v499);\n\tv508 = ~v505;\n\tv137 = 0;\n\tif (v508) goto L_005C;\n\tv512 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v499);\n\tv530 = ~v512;\n\tv137 = Il2CppMethodInfo;\n\tif (v530) goto L_005C;\n\tv538 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v499);\n\tgoto L_00F1;\nL_00F1:\n\tv526 = UnityEngine.Object::op_Inequality(v538, 0);\n\tv545 = v526 == 0;\n\tv531 = ~v545;\n\tv137 = 0;\n\tif (v531) goto L_005C;\n\tgoto L_0106;\nL_0106:\n\tv552 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::TrySpawn(this._lockHandler, v499);\n\tv559 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, v499, &v184 @ stack_-6C_v5 (_game.CoreSystem.New.Shared.Components.ColorComponent));\n\tv560 = ~v559;\n\tv187 = 0;\n\tif (v560) goto L_0121;\n\tSystem.Nullable`1<System.Int32Enum>::.ctor(&v187 @ stack_-68_v6 (System.Int32), v184);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::SetGroupChainVisible(this._lockHandler, v184, 0);\nL_0121:\n\tv528 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnHandlerBase::AnimateSpawn(this, v499, tunnel);\n\tv182 = v528;\n\tv199 = 0 != 1;\n\tv358 = 0;\n\tv137 = tunnel;\n\tif (v199) goto L_005C;\n\tv275 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.SpawnHandlers.LockTunnelSpawnHandler+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v275);\n\tv275.<>4__this = this;\n\tv580 = System.Nullable`1<System.Int32Enum>::get_Value(&v187 @ stack_-68_v6 (System.Int32));\n\tv275.capturedColor = v580;\n\tv582 = PrimeTween.Sequence::get_isAlive(&v182 @ stack_-80_v5 (PrimeTween.Sequence));\n\tv583 = ~v582;\n\tv529 = ~v583;\n\tif (v529) goto L_004F;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::SetGroupChainVisible(this._lockHandler, v275.capturedColor, 1);\n\tv358 = 0;\n\tv137 = 1;\n\tgoto L_005C;\nL_015F:\n\treturn;\nL_0160:\n\tthrow System.NullReferenceException;\nL_0040:\n\tv63 = this._lockHandler == 0;\n\tif (v63) goto L_015F;\nL_005E:\n\tv371 = slotEntities->klass;\n\tv405 = slotEntities->klass->interface_offsets_count;\n\tv150 = *([v371 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v150) goto L_0080;\nL_0064:\n\t;\n\tv418 = *([v128 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v418) goto L_0090;\nL_00AA:\n\t;\n\tv226 = *([v246 @ X10_v9-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v226) goto L_00CE;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void Handle(EntityManager em, Entity tunnel, IReadOnlyList<Entity> slotEntities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockTunnelSpawnHandler::Handle");
		}

		[Token(Token = "0x60008E5")]
		[Address(RVA = "0x3E896C4", Offset = "0x3E896C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnHandlerBase::.ctor(this);\n\treturn;\n")]
		public LockTunnelSpawnHandler()
		{
		}
	}
}
