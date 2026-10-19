using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.SpawnHandlers
{
	[Token(Token = "0x20001F1")]
	public class KeyTunnelSpawnHandler : TunnelSpawnHandlerBase
	{
		[Inject(true)]
		[Token(Token = "0x400063A")]
		[FieldOffset(Offset = "0x18")]
		private KeyVisualHandler _keyHandler;

		[Token(Token = "0x60008E2")]
		[Address(RVA = "0x3E8906C", Offset = "0x3E8906C", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv453 = 0xB285000 + 0x5F8;\n\tv452 = 0xB285000 + 0x780;\n\tv451 = 0xB2C6000 + 0x7C8;\n\tv450 = 0xB292000 + 0x5A0;\n\tv307 = slotEntities;\n\tv143 = 0;\n\tv457 = this;\n\tv458 = v122;\n\tgoto L_003C;\nL_0039:\n\tv454 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnHandlerBase::AnimateSpawn(v457, v435, v458);\n\tv307 = 0;\n\tv122 = v458;\nL_003A:\n\tv143 = v143 + 1;\n\tv116 = *([v325 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv116 = v116 + 0x10;\n\tv331 = v353 - 1;\n\tv330 = v353 != 1;\n\tv353 = v331;\n\tif (v330) goto L_0047;\nL_005C:\n\tv350 = 0x220C5E0(slotEntities, *([v453 @ X25_v11 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v350 @ X0_v34])(v135, slotEntities, *([v350 @ X0_v34+8]), 0, v307, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv75 = v143 < v135;\n\tif (v75) goto L_0082;\n\tgoto L_00F9;\nL_006F:\n\tv72 = *([v116 @ X10_v14]) << 4;\n\tv375 = v325 + v72;\n\tv376 = v375 + 0x138;\n\t*([v376 @ X0_v37])(v136, slotEntities, *([v376 @ X0_v37+8]), v122, v307, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv76 = v143 >= v136;\n\tif (v76) goto L_00F9;\nL_0082:\n\tv396 = slotEntities->klass;\n\tv416 = slotEntities->klass->interface_offsets_count;\n\tv398 = *([v396 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v398) goto L_00A2;\n\tv224 = *([v396 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv224 = v224 + 0x10;\n\tv402 = v416 - 1;\n\tv401 = v416 != 1;\n\tv416 = v402;\n\tif (v401) goto L_008D;\nL_00A2:\n\tv414 = 0x220C5E0(slotEntities, *([v452 @ X26_v10 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v414 @ X0_v27])(v435, slotEntities, v143, *([v414 @ X0_v27+8]), v307, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv427 = em == 0;\n\tv248 = ~v427;\n\tif (v248) goto L_00BB;\n\tgoto L_00FA;\nL_00AD:\n\tv180 = *([v224 @ X10_v9]) << 4;\n\tv429 = v396 + v180;\n\tv430 = v429 + 0x138;\n\t*([v430 @ X0_v30])(v435, slotEntities, v143, *([v430 @ X0_v30+8]), v307, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00BB:\n\tv441 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v435);\n\tv442 = ~v441;\n\tv122 = 0;\n\tif (v442) goto L_003A;\n\tv122 = *([v451 @ X27_v10 (System.Int32)]);\n\tv446 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v435);\n\tv456 = ~v446;\n\tif (v456) goto L_003A;\n\tv461 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v435);\n\tv254 = *([v450 @ X28_v10 (System.Int32)]);\n\tv462 = *([v254 @ X8_v11+E4]) == 0;\n\tif (v462) goto L_00E0;\n\tv465 = UnityEngine.Object::op_Equality(v461, 0);\n\tv474 = ~v465;\n\tif (v474) goto L_0039;\n\tv236 = v450;\n\tv238 = v451;\n\tv240 = v452;\n\tv242 = v453;\n\tv257 = v457;\n\tv259 = v458;\n\tgoto L_00EA;\nL_00E0:\n\tv453 = 0xB285000 + 0x5F8;\n\tv485 = UnityEngine.Object::op_Equality(v461, 0);\n\tv491 = ~v485;\n\tv236 = v450;\n\tv238 = v451;\n\tv240 = v452;\n\tv242 = v453;\n\tv257 = v457;\n\tv259 = v458;\n\tif (v491) goto L_0039;\nL_00EA:\n\tv490 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::TrySpawn(v257._keyHandler, v435);\n\tv450 = v236;\n\tv451 = v238;\n\tv452 = v240;\n\tv453 = v242;\n\tv457 = v257;\n\tv458 = v259;\n\tgoto L_0039;\nL_00F9:\n\treturn;\nL_00FA:\n\tthrow System.NullReferenceException;\nL_0027:\n\tv59 = this._keyHandler == 0;\n\tif (v59) goto L_00F9;\nL_003C:\n\tv325 = slotEntities->klass;\n\tv353 = slotEntities->klass->interface_offsets_count;\n\tv138 = *([v325 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v138) goto L_005C;\nL_0047:\n\tv366 = *([v116 @ X10_v14-8]) == *([v453 @ X25_v11 (System.Int32)]);\n\tif (v366) goto L_006F;\nL_008D:\n\tv208 = *([v224 @ X10_v9-8]) == *([v452 @ X26_v10 (System.Int32)]);\n\tif (v208) goto L_00AD;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Handle(EntityManager em, Entity tunnel, IReadOnlyList<Entity> slotEntities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyTunnelSpawnHandler::Handle");
		}

		[Token(Token = "0x60008E3")]
		[Address(RVA = "0x3E892EC", Offset = "0x3E892EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnHandlerBase::.ctor(this);\n\treturn;\n")]
		public KeyTunnelSpawnHandler()
		{
		}
	}
}
