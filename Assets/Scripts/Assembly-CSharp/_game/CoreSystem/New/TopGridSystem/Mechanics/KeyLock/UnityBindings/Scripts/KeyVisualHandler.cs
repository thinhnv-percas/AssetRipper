using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001E7")]
	public class KeyVisualHandler : ITopGridVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000611")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000612")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000613")]
		[FieldOffset(Offset = "0x20")]
		private KeyAndLockConfig _config;

		[Inject(false)]
		[Token(Token = "0x4000614")]
		[FieldOffset(Offset = "0x28")]
		private LockVisualHandler _lockHandler;

		[Inject(false)]
		[Token(Token = "0x4000615")]
		[FieldOffset(Offset = "0x30")]
		private TopGridHandler _gridHandler;

		[Token(Token = "0x4000616")]
		[FieldOffset(Offset = "0x38")]
		private Transform _parent;

		[Token(Token = "0x60008A6")]
		[Address(RVA = "0x3E82AE8", Offset = "0x3E82AE8", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv70 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv123 = 0;\n\tgoto L_003C;\nL_003A:\n\tv123 = v123 + 1;\n\tv263 = *([v221 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv263 = v263 + 0x10;\n\tv230 = v254 - 1;\n\tv228 = v254 != 1;\n\tv254 = v230;\n\tif (v228) goto L_0047;\nL_0060:\n\tv276 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v70);\n\tv287 = v123 < v276;\n\tif (v287) goto L_0085;\n\tgoto L_00C5;\nL_006F:\n\tv290 = *([v263 @ X10_v14]) << 4;\n\tv291 = v221 + v290;\n\tv292 = v291 + 0x138;\n\t*([v292 @ X0_v26])(v296, v70, *([v292 @ X0_v26+8]), Il2CppMethodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv306 = v123 >= v296;\n\tif (v306) goto L_00C5;\nL_0085:\n\tgoto L_00AC;\n\tv389 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v387);\n\tv218 = ~v389;\n\tif (v218) goto L_003A;\n\tv392 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::Spawn(this, v387);\n\tgoto L_003A;\nL_00C5:\n\treturn;\nL_0025:\n\tthis._parent = v48;\nL_003C:\n\tv221 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv254 = *([v221 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv187 = *([v221 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v187) goto L_0060;\nL_0047:\n\tv268 = *([v263 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v268) goto L_006F;\nL_00AC:\n\tv387 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v123);\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::InitVisuals");
		}

		[Token(Token = "0x60008A7")]
		[Address(RVA = "0x3E82DE8", Offset = "0x3E82DE8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv69 = ~v53;\n\tif (v69) goto L_004C;\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv78 = ~v75;\n\tif (v78) goto L_004C;\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv79 = ~v76;\n\tif (v79) goto L_004C;\n\treturnVal3 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::Spawn(this, entity);\n\treturn returnVal3;\nL_004C:\n\treturn 0;\n")]
		public GameObject TrySpawn(Entity entity)
		{
			if (_em.HasComponent<KeyTag>(entity) && _em.HasComponent<GridPositionComponent>(entity) && _em.HasComponent<ColorComponent>(entity))
			{
				return Spawn(entity);
			}
			return null;
		}

		[Token(Token = "0x60008A8")]
		[Address(RVA = "0x3E82EC8", Offset = "0x3E82EC8", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv115 = 0;\n\tgoto L_0043;\nL_0038:\n\tv108 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v55, v115);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v108);\n\tv420 = UnityEngine.Component::get_gameObject(v403);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v420);\n\tv207 = 0;\nL_0041:\n\tv115 = v115 + 1;\n\tv261 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv261 = v261 + 0x10;\n\tv228 = v252 - 1;\n\tv226 = v252 != 1;\n\tv252 = v228;\n\tif (v226) goto L_004E;\nL_0067:\n\tv274 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v55);\n\tv285 = v115 < v274;\n\tif (v285) goto L_008C;\n\tgoto L_00FB;\nL_0076:\n\tv288 = *([v261 @ X10_v21]) << 4;\n\tv289 = v219 + v288;\n\tv290 = v289 + 0x138;\n\t*([v290 @ X0_v36])(v294, v55, *([v290 @ X0_v36+8]), v207, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv304 = v115 >= v294;\n\tif (v304) goto L_00FB;\nL_008C:\n\tgoto L_00B3;\nL_00BE:\n\tv410 = UnityEngine.Object::op_Equality(v403, 0);\n\tv413 = v410 == 0;\n\tv414 = ~v413;\n\tv207 = 0;\n\tif (v414) goto L_0041;\n\tgoto L_00D1;\nL_00D1:\n\tgoto L_0038;\nL_00FB:\n\treturn;\nL_0043:\n\tv219 = *([v55 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv252 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv171 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v171) goto L_0067;\nL_004E:\n\tv266 = *([v261 @ X10_v21-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v266) goto L_0076;\nL_00B3:\n\tv401 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v55, v115);\n\tv403 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v401);\n\tgoto L_00BE;\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::Cleanup");
		}

		[Token(Token = "0x60008A9")]
		[Address(RVA = "0x3E83228", Offset = "0x3E83228", Length = "0x4B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv234 = *([v59 @ X0_v48 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv293 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv236 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v236) goto L_005D;\n\tv292 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv292 = v292 + 0x10;\n\tv265 = v293 - 1;\n\tv245 = v293 != 1;\nL_FFFFFFFF:\n\tv293 = v265;\n\tif (v245) goto L_0043;\nL_005D:\n\tv353 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v59);\n\tv313 = v353 == 0;\n\tv314 = ~v313;\nL_FFFFFFFF:\n\tv478 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv338 = 0;\n\tif (v314) goto L_FFFFFFFF;\n\tgoto L_01D0;\nL_0067:\n\tv323 = *([v292 @ X10_v44]) << 4;\n\tv324 = v234 + v323;\n\tv325 = v324 + 0x138;\n\t*([v325 @ X8_v44])(v353, v59, *([v325 @ X8_v44+8]), methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv334 = v353 == 0;\nL_FFFFFFFF:\n\tv478 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv338 = 0;\n\tif (v334) goto L_01D0;\nL_FFFFFFFF:\n\tv429 = v353;\n\tgoto L_0083;\nL_007B:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::SetVisual(this, v805);\nL_007D:\n\tv405 = v310 == 0;\nL_FFFFFFFF:\n\tv429 = v310;\n\tif (v405) goto L_01D0;\nL_0083:\n\tgoto L_00A9;\n\tgoto L_00DA;\n\tv863 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::Spawn(this, v805);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::SetVisual(this, v805);\n\tgoto L_007D;\nL_00EC:\n\tv513 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv474 = *([v513 @ X8_v35]);\n\tv511 = *([v513 @ X8_v35]) == 0;\nL_FFFFFFFF:\n\tv472 = 5;\nL_FFFFFFFF:\n\tv514 = 0;\nL_FFFFFFFF:\n\tv516 = oldData;\nL_FFFFFFFF:\n\tv71 = 5;\nL_FFFFFFFF:\n\tv85 = v478;\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = 0;\nL_FFFFFFFF:\n\tv225 = oldData;\n\tif (v511) goto L_011D;\nL_00F6:\n\tgoto L_011C;\n\tv126 = v71 == 5;\n\tif (v126) goto L_0131;\n\tv685 = v71 == 0;\n\tv686 = ~v685;\n\tif (v686) goto L_01CF;\nL_0131:\n\tv165 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v225);\nL_FFFFFFFF:\n\tv182 = 0;\n\tgoto L_013D;\nL_013B:\n\tv182 = v182 + 1;\n\tv728 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv728 = v728 + 0x10;\n\tv858 = v876 - 1;\n\tv840 = v876 != 1;\nL_FFFFFFFF:\n\tv876 = v858;\n\tif (v840) goto L_0148;\nL_0161:\n\tv734 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v165);\n\tv709 = v182 < v734;\n\tif (v709) goto L_0186;\n\tgoto L_01CF;\nL_0170:\n\tv706 = *([v728 @ X10_v14]) << 4;\n\tv892 = v832 + v706;\n\tv893 = v892 + 0x138;\n\t*([v893 @ X0_v26])(v735, v165, *([v893 @ X0_v26+8]), v708, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv710 = v182 >= v735;\n\tif (v710) goto L_01CF;\nL_0186:\n\tgoto L_01AD;\n\tv979 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v976);\n\tv981 = v979 == 0;\n\tv982 = ~v981;\nL_FFFFFFFF:\n\tv708 = 0;\n\tif (v982) goto L_013B;\n\tv984 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v976, &v67 @ stack_-58_v5 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv987 = ~v984;\nL_FFFFFFFF:\n\tv708 = 0;\n\tif (v987) goto L_013B;\n\tv986 = UnityEngine.Component::get_gameObject(v67);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v986);\nL_FFFFFFFF:\n\tv708 = 0;\n\tgoto L_013B;\nL_01CF:\n\treturn;\nL_01D0:\n\tv410 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\n\tgoto L_01D3;\nL_01D3:\n\t// 467 Interrupt\nL_01D6:\n\tv227 = new System.OutOfMemoryException();\n\tgoto L_01E7;\nL_01E7:\n\tv278 = v218 != 1;\n\tif (v278) goto L_01F6;\n\tv315 = 0x8BF5BC4(v227, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv514 = *([v315 @ X0_v39]);\n\tv364 = 0x8BF5BF4(v315, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv474 = *([v85 @ stack_-60_v1]);\n\tv437 = *([v85 @ stack_-60_v1]) == 0;\n\tv438 = ~v437;\nL_FFFFFFFF:\n\tv472 = 0;\nL_FFFFFFFF:\n\tv338 = *([v315 @ X0_v39]);\nL_FFFFFFFF:\n\tv516 = v225;\n\tif (v438) goto L_00F6;\nL_FFFFFFFF:\n\tv71 = 0;\nL_FFFFFFFF:\n\tv85 = v85;\nL_FFFFFFFF:\n\tv338 = *([v315 @ X0_v39]);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = *([v315 @ X0_v39]);\n\tgoto L_011D;\nL_01F6:\n\tv318 = 0x3175484(&v338 @ stack_-68_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = 0x8BF0368(v227, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv439 = 0xA1B8(v366, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0029:\n\tv48 = 0;\n\tthrow System.NullReferenceException;\nL_0043:\n\tv298 = *([v292 @ X10_v44-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v298) goto L_0067;\nL_00A9:\n\tv509 = System.Collections.IEnumerator::MoveNext(v429);\n\tv662 = v509 == 0;\n\tif (v662) goto L_00EC;\nL_00DA:\n\tv805 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v310);\n\tv808 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v805, &v48 @ stack_-50_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv835 = v808 == 0;\n\tv836 = ~v835;\n\tif (v836) goto L_007B;\nL_011D:\n\tv566 = v181 == 0;\n\tv222 = ~v566;\nL_FFFFFFFF:\n\tv478 = v85;\nL_FFFFFFFF:\n\t;\n\tif (v222) goto L_01D6;\nL_011C:\n\tSystem.IDisposable::Dispose(v474);\nL_FFFFFFFF:\n\tv71 = v472;\nL_FFFFFFFF:\n\tv85 = v478;\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = v514;\nL_FFFFFFFF:\n\tv225 = v516;\nL_013D:\n\tv832 = *([v165 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv876 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv736 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v736) goto L_0161;\nL_0148:\n\tv881 = *([v728 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v881) goto L_0170;\nL_01AD:\n\tv976 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v165, v182);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::SyncWithData");
		}

		[Token(Token = "0x60008AA")]
		[Address(RVA = "0x3E837F8", Offset = "0x3E837F8", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, keyEntity);\n\tv95 = v54 == 0;\n\tif (v95) goto L_00AA;\n\tv167 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, keyEntity);\n\tv168 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v167);\n\tv117 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v168);\n\tv123 = v117 == 0;\n\tif (v123) goto L_00AA;\n\tv172 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v168);\n\tgoto L_0052;\nL_0052:\n\tv118 = UnityEngine.Object::op_Equality(v172, 0);\n\tv124 = ~v118;\n\tif (v124) goto L_0064;\n\tgoto L_00AA;\nL_0064:\n\tv185 = UnityEngine.Component::GetComponent(v172);\n\tgoto L_006D;\nL_006D:\n\tv192 = UnityEngine.Object::op_Inequality(v185, 0);\n\tv195 = ~v192;\n\tv128 = 0;\n\tif (v195) goto L_009A;\n\tv128 = v185.OverlayContent;\n\tgoto L_009F;\nL_0084:\n\t*([isOnCubeContent @ X2 (System.Boolean&)]) = 1;\n\treturn v128;\nL_009A:\n\tgoto L_009F;\nL_009F:\n\tv116 = UnityEngine.Object::op_Equality(v128, 0);\n\tv122 = ~v116;\n\tif (v122) goto L_0084;\nL_00AA:\n\treturn this._parent;\nL_001F:\n\t*([isOnCubeContent @ X2 (System.Boolean&)]) = 0;\n")]
		private Transform ResolveSpawnParent(Entity keyEntity, out bool isOnCubeContent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::ResolveSpawnParent");
			isOnCubeContent = default;
			return default;
		}

		[Token(Token = "0x60008AB")]
		[Address(RVA = "0x3E83A0C", Offset = "0x3E83A0C", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv60 = UnityEngine.GameObject::get_transform(go);\n\tv178 = UnityEngine.Transform::get_parent(v60);\n\tgoto L_0030;\nL_0030:\n\tv236 = UnityEngine.Object::op_Inequality(v178, parent);\n\tv240 = ~v236;\n\tv241 = ~v240;\n\tif (v241) goto L_0088;\n\tv252 = ~isOnCubeContent;\n\tif (v252) goto L_0099;\nL_0038:\n\tv124 = UnityEngine.GameObject::get_transform(go);\n\tv148 = this._config;\n\t// 66 MakeStruct v83 @ AGG3E83ACC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v148.keyOverlayOffset (UnityEngine.Vector3), v148.keyOverlayOffset.y (System.Single), v148.keyOverlayOffset.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v124, v83);\n\tv130 = UnityEngine.GameObject::get_transform(go);\n\tgoto L_0060;\nL_0060:\n\t// 96 MakeStruct v77 @ AGG3E83B28_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v290.identity (UnityEngine.Quaternion), v290.identity.y (System.Single), v290.identity.z (System.Single), v290.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v130, v77);\n\tv214 = UnityEngine.GameObject::get_transform(go);\n\tgoto L_0079;\nL_0079:\n\tv207 = v324.one.y;\n\tv205 = v324.one.z;\n\tv327 = v324.one;\n\tgoto L_00EF;\nL_0088:\n\tv125 = UnityEngine.GameObject::get_transform(go);\n\tUnityEngine.Transform::SetParent(v125, parent, 0);\n\tv272 = ~isOnCubeContent;\n\tv263 = ~v272;\n\tif (v263) goto L_0038;\nL_0099:\n\tv269 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv271 = UnityEngine.GameObject::get_transform(go);\n\tv85 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v269);\n\tv151 = this._config;\n\tv96 = v85.z + v151.keyOverlayOffset.z;\n\tv102 = v85.y + v151.keyOverlayOffset.y;\n\tv90 = v85 + v151.keyOverlayOffset;\n\t// 182 MakeStruct v68 @ AGG3E83C3C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v90 @ V0_v4 (System.Single), v102 @ V1_v4 (System.Single), v96 @ V2_v4 (System.Single)\n\tUnityEngine.Transform::set_position(v271, v68);\n\tv132 = UnityEngine.GameObject::get_transform(go);\n\tgoto L_00D3;\nL_00D3:\n\t// 211 MakeStruct v65 @ AGG3E83C98_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v152.zero (UnityEngine.Vector3), v152.zero.y (System.Single), v152.zero.z (System.Single)\n\tUnityEngine.Transform::set_localEulerAngles(v132, v65);\n\tv87 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv214 = UnityEngine.GameObject::get_transform(go);\n\tv327 = v87;\n\tv205 = v87;\n\tv207 = v87;\nL_00EF:\n\t// 239 MakeStruct v180 @ AGG3E83CE4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v327 @ V0_v10 (UnityEngine.Vector3), v207 @ V1_v2 (System.Single), v205 @ V2_v2 (System.Single)\n\tUnityEngine.Transform::set_localScale(v214, v180);\n\treturn;\n")]
		private void ApplyTransform(GameObject go, Entity entity, Transform parent, bool isOnCubeContent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::ApplyTransform");
		}

		[Token(Token = "0x60008AC")]
		[Address(RVA = "0x3E836D8", Offset = "0x3E836D8", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv52 = UnityEngine.Component::get_gameObject(v47);\n\tv90 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::ResolveSpawnParent(this, entity, &v62 @ stack_-31_v3 (System.Boolean));\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::ApplyTransform(this, v52, entity, v90, v62);\n\tv119 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::ApplyMaterial(this, entity, v119);\n\tv73 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\n\tv126 = System.Text.StringBuilder::Insert(v73, 0, \"Key_\");\n\tv74 = System.Text.StringBuilder::ToString(v73);\n\tUnityEngine.Object::set_name(v52, v74);\n\treturn;\nL_001B:\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n")]
		private void SetVisual(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyVisualHandler::SetVisual");
		}

		[Token(Token = "0x60008AD")]
		[Address(RVA = "0x3E82CBC", Offset = "0x3E82CBC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv60 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v52.keyMono, v49);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::ApplyTransform(this, v60, entity, v49, v46);\n\tv78 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\n\tv120 = System.Text.StringBuilder::Insert(v78, 0, \"Key_\");\n\tv79 = System.Text.StringBuilder::ToString(v78);\n\tUnityEngine.Object::set_name(v60, v79);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(v60, entity);\n\tv128 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::OnSpawned(this, v60, entity);\n\treturn v60;\nL_001C:\n\tv49 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler::ResolveSpawnParent(this, entity, &v46 @ stack_-31_v2 (System.Boolean));\n\tv52 = this._config;\n")]
		public GameObject Spawn(Entity entity)
		{
			Transform parent = ResolveSpawnParent(entity, out var isOnCubeContent);
			KeyAndLockConfig config = _config;
			GameObject gameObject = VisualHandlerUtility.Instantiate(config.keyMono, parent);
			ApplyTransform(gameObject, entity, parent, isOnCubeContent);
			StringBuilder stringBuilder = VisualHandlerUtility.GenerateName(_em, entity);
			StringBuilder stringBuilder2 = stringBuilder.Insert(0, "Key_");
			string name = stringBuilder.ToString();
			gameObject.name = name;
			VisualHandlerUtility.BindEntityMono(gameObject, entity);
			OnSpawned(gameObject, entity);
			return gameObject;
		}

		[Token(Token = "0x60008AE")]
		[Address(RVA = "0x3E8408C", Offset = "0x3E8408C", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_002C:\n\tv69 = UnityEngine.Object::op_Equality(v56, 0);\n\tv72 = v69 == 0;\n\tif (v72) goto L_0040;\n\tgoto L_00D8;\nL_0040:\n\tv182 = UnityEngine.Component::GetComponent(v56);\n\tgoto L_0049;\nL_0049:\n\tv146 = UnityEngine.Object::op_Equality(v182, 0);\n\tv153 = v146 == 0;\n\tif (v153) goto L_005D;\n\tgoto L_00D8;\nL_005D:\n\tgoto L_0061;\nL_0061:\n\tv148 = UnityEngine.Object::op_Equality(v182.OverlayContent, 0);\n\tv155 = v148 == 0;\n\tif (v155) goto L_0073;\n\tgoto L_00D8;\nL_0073:\n\tv150 = UnityEngine.Transform::get_childCount(v182.OverlayContent);\n\tv121 = v150 < 1;\n\tif (v121) goto L_00D8;\n\tv282 = v150;\n\tgoto L_008F;\nL_008D:\n\tv96 = v282 <= 0;\n\tif (v96) goto L_00D8;\nL_008F:\n\tv282 = v282 - 1;\n\tv286 = UnityEngine.Transform::GetChild(v182.OverlayContent, v282);\n\tgoto L_009C;\nL_009C:\n\tv292 = UnityEngine.Object::op_Equality(v286, 0);\n\tv295 = v292 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_008D;\n\tgoto L_00AF;\nL_00AF:\n\tv327 = UnityEngine.Component::GetComponent(v286);\n\tgoto L_00B6;\nL_00B6:\n\tv311 = UnityEngine.Object::op_Equality(v327, 0);\n\tv332 = v311 == 0;\n\tv315 = ~v332;\n\tif (v315) goto L_008D;\n\tgoto L_00CB;\nL_00CB:\n\tUnityEngine.Transform::SetParent(v286, this._parent, 1);\n\tgoto L_008D;\nL_00D8:\n\treturn;\nL_0023:\n\tv56 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_002C;\n")]
		public void OnEntityRemoving(Entity entity)
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			if (monoBinding == null)
			{
				return;
			}
			SandCubeMonoBase component = monoBinding.GetComponent<SandCubeMonoBase>();
			if (component == null || component.OverlayContent == null)
			{
				return;
			}
			int childCount = component.OverlayContent.childCount;
			if (childCount < 1)
			{
				return;
			}
			int num = childCount;
			do
			{
				num--;
				Transform child = component.OverlayContent.GetChild(num);
				if (!(child == null))
				{
					KeyMono component2 = child.GetComponent<KeyMono>();
					if (!(component2 == null))
					{
						child.SetParent(_parent, worldPositionStays: true);
					}
				}
			}
			while (num > 0);
		}

		[Token(Token = "0x60008AF")]
		[Address(RVA = "0x3E83CEC", Offset = "0x3E83CEC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0028:\n\tv63 = UnityEngine.Object::op_Equality(v53, 0);\n\tv66 = v63 == 0;\n\tif (v66) goto L_0043;\n\treturn;\nL_0043:\n\tv124 = UnityEngine.Component::get_gameObject(v53);\n\tv135 = UnityEngine.GameObject::GetComponent(v124);\n\tv129 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig::GetKeyMaterial(this._config, color);\n\tUnityEngine.Renderer::set_sharedMaterial(v135.m_renderer, v129);\n\treturn;\nL_001F:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_0028;\n")]
		public void ApplyMaterial(Entity entity, GameColor color)
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			if (!(monoBinding == null))
			{
				GameObject gameObject = monoBinding.gameObject;
				SimpleMaterialSetter component = gameObject.GetComponent<SimpleMaterialSetter>();
				Material keyMaterial = _config.GetKeyMaterial(color);
				component.m_renderer.sharedMaterial = keyMaterial;
			}
		}

		[Token(Token = "0x60008B0")]
		[Address(RVA = "0x3E842F8", Offset = "0x3E842F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x60008B1")]
		[Address(RVA = "0x3E842FC", Offset = "0x3E842FC", Length = "0x91C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv77.<>4__this = this;\n\tv77.onComplete = onComplete;\n\tgoto L_0064;\nL_0064:\n\tv506 = UnityEngine.Object::op_Equality(keyTransform, 0);\n\tv511 = ~v506;\n\tif (v511) goto L_0074;\n\tgoto L_0097;\nL_0074:\n\tv551 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::GetLockMono(this._lockHandler, lockColor);\n\tgoto L_007D;\nL_007D:\n\tv539 = UnityEngine.Object::op_Equality(v551, 0);\n\tv544 = v539 == 0;\n\tif (v544) goto L_0091;\n\tgoto L_0097;\nL_0091:\n\tgoto L_0094;\nL_0094:\n\tv538 = UnityEngine.Object::op_Equality(v551.KeyTargetTransform, 0);\n\tv543 = ~v538;\n\tif (v543) goto L_00BF;\nL_0097:\n\t;\n\tv474 = v77.onComplete == 0;\n\tif (v474) goto L_02D4;\n\tSystem.Action::Invoke(v77.onComplete);\n\treturn;\nL_00BF:\n\tv601 = UnityEngine.Component::GetComponent(keyTransform);\n\tv77.keyMono = v601;\n\tgoto L_00CD;\nL_00CD:\n\tv611 = UnityEngine.Object::op_Inequality(v77.keyMono, 0);\n\tv616 = ~v611;\n\tv617 = ~v616;\n\tif (v617) goto L_00DD;\n\tv362 = keyTransform;\n\tgoto L_00F6;\nL_00DD:\n\tv341 = v77.keyMono;\n\tgoto L_00EC;\n\tv342 = v77.keyMono;\n\tv362 = v342.KeyModel;\n\tv217 = UnityEngine.Transform::get_position(v551.KeyTargetTransform);\n\tv643 = UnityEngine.Transform::get_rotation(v551.KeyTargetTransform);\n\tv77.targetRot.x = v643;\n\tv77.targetRot.y = v643.y;\n\tv77.targetRot.z = v643.z;\n\tv77.targetRot.w = v643.w;\n\tv648 = UnityEngine.Transform::get_position(keyTransform);\n\tv77.startZ = v648.z;\n\tv77.endZ = v217.z;\n\tv218 = UnityEngine.Transform::get_localScale(keyTransform);\n\tv344 = this._config;\n\tv77.zCurve = v344.zCurve;\n\tv345 = this._config;\n\tv77.zMul = v345.zCurveMultiplier;\n\tv303 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv169 = v303;\n\tv346 = this._config;\n\tv158 = v346.moveSettings;\n\tv659 = PrimeTween.Tween::PositionX(keyTransform, v217, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv304 = PrimeTween.Sequence::Group(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v659);\n\tv347 = this._config;\n\tv158 = v347.moveSettings;\n\tv668 = PrimeTween.Tween::PositionY(keyTransform, v217.y, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv675 = PrimeTween.Sequence::Group(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v668);\n\tv305 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv134 = v305;\n\tv348 = this._config;\n\tv158 = v348.keyScaleUpSettings;\n\tv222 = v218 * v348.keyMaxScale;\n\tv682 = PrimeTween.Tween::Scale(keyTransform, v222, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv306 = PrimeTween.Sequence::Group(&v134 @ stack_-F0_v4 (PrimeTween.Sequence), v682);\n\tv134 = v306;\n\tv349 = this._config;\n\tv158 = v349.keyScaleBackSettings;\n\tv691 = PrimeTween.Tween::Scale(keyTransform, v218, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv698 = PrimeTween.Sequence::Chain(&v134 @ stack_-F0_v4 (PrimeTween.Sequence), v691);\n\tv307 = PrimeTween.Sequence::Group(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v698);\n\tv350 = this._config;\n\tv707 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v707, v77, Il2CppMethodInfo);\n\tv158 = v350.moveZSettings;\n\tv720 = PrimeTween.Tween::Custom(keyTransform, 0f, 1f, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings), v707);\n\tv308 = PrimeTween.Sequence::Group(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v720);\n\tv225 = UnityEngine.Transform::get_rotation(v362);\n\tv77.startRot.x = v225;\n\tv77.startRot.y = v225.y;\n\tv77.startRot.z = v225.z;\n\tv77.startRot.w = v225.w;\n\tv352 = this._config;\n\t// 469 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv728 = v352.midRotationEuler * v225.z;\n\tv730 = v352.midRotationEuler.z * 0x3C8EFA35;\n\t// 475 MakeStruct v114 @ AGG3E848E0_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v728 @ V0_v26 (System.Single), v732 @ V0.S1, v730 @ V2_v10 (System.Single)\n\tv226 = UnityEngine.Quaternion::Internal_FromEulerRad(v114);\n\tv77.midRot.x = v226;\n\tv77.midRot.y = v226.y;\n\tv77.midRot.z = v226.z;\n\tv77.midRot.w = v226.w;\n\tv353 = this._config;\n\tv77.spinTurns = v353.flightSpinTurns;\n\tv77.spinAxis.z = v353.flightSpinAxis.z;\n\tv77.spinAxis = v353.flightSpinAxis;\n\tv311 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv354 = this._config;\n\tv741 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v741, v77, Il2CppMethodInfo);\n\tv158 = v354.rotateToMidSettings;\n\tv754 = PrimeTween.Tween::Custom(v362, 0f, 1f, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings), v741);\n\tv312 = PrimeTween.Sequence::Chain(&v110 @ stack_-D0_v5 (PrimeTween.Sequence), v754);\n\tv355 = this._config;\n\tv763 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v763, v77, Il2CppMethodInfo);\n\tv158 = v355.rotateToTargetSettings;\n\tv777 = PrimeTween.Tween::Custom(v362, 0f, 1f, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings), v763);\n\tv784 = PrimeTween.Sequence::Chain(&v110 @ stack_-D0_v5 (PrimeTween.Sequence), v777);\n\tv789 = PrimeTween.Sequence::Group(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v110);\n\tv794 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv77.capturedColor = lockColor;\n\tv798 = new System.Action();\n\tSystem.Action::.ctor(v798, v77, Il2CppMethodInfo);\n\tv806 = PrimeTween.Sequence::ChainCallback(&v104 @ stack_-E0_v5 (PrimeTween.Sequence), v798, 1);\n\tgoto L_026E;\n\tv158 = v356.lockScaleDownSettings;\n\t// 642 MakeStruct v98 @ AGG3E84B10_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v246.zero (UnityEngine.Vector3), v246.zero.y (System.Single), v246.zero.z (System.Single)\n\tv821 = PrimeTween.Tween::Scale(v632, v98, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv825 = PrimeTween.Sequence::Group(&v104 @ stack_-E0_v5 (PrimeTween.Sequence), v821);\n\tgoto L_0295;\n\tv158 = v357.keyScaleDownSettings;\n\t// 679 MakeStruct v554 @ AGG3E84B84_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v569.zero (UnityEngine.Vector3), v569.zero.y (System.Single), v569.zero.z (System.Single)\n\tv841 = PrimeTween.Tween::Scale(keyTransform, v554, &v158 @ stack_-B0_v3 (PrimeTween.TweenSettings));\n\tv848 = PrimeTween.Sequence::Group(&v104 @ stack_-E0_v5 (PrimeTween.Sequence), v841);\n\tv853 = PrimeTween.Sequence::Chain(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v104);\n\tv855 = new System.Action();\n\tSystem.Action::.ctor(v855, v77, Il2CppMethodInfo);\n\tv574 = PrimeTween.Sequence::ChainCallback(&v169 @ stack_-C0_v4 (PrimeTween.Sequence), v855, 1);\nL_02D4:\n\treturn;\nL_004A:\n\tv77 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v77);\nL_00F6:\n\tv632 = UnityEngine.Component::get_transform(v551);\nL_00EC:\n\tv298 = UnityEngine.Object::op_Inequality(v341.KeyModel, 0);\n\tv628 = ~v298;\n\tv362 = keyTransform;\n\tif (v628) goto L_00F6;\nL_026E:\n\tv356 = this._config;\nL_0295:\n\tv357 = this._config;\n")]
		public void PlayKeyFly(Transform keyTransform, GameColor lockColor, Action onComplete)
		{
			//IL_05b9: Expected F4, but got O
			if (!(keyTransform == null))
			{
				LockMono lockMono = _lockHandler.GetLockMono(lockColor);
				if (!(lockMono == null) && !(lockMono.KeyTargetTransform == null))
				{
					KeyMono component = keyTransform.GetComponent<KeyMono>();
					KeyMono keyMono = component;
					Transform transform;
					if (!(keyMono != null))
					{
						transform = keyTransform;
					}
					else
					{
						KeyMono keyMono2 = keyMono;
						bool flag = keyMono2.KeyModel != null;
						bool flag2 = !flag;
						transform = keyTransform;
						if (!flag2)
						{
							KeyMono keyMono3 = keyMono;
							transform = keyMono3.KeyModel;
						}
					}
					Transform transform2 = lockMono.transform;
					Vector3 position = lockMono.KeyTargetTransform.position;
					Quaternion rotation = lockMono.KeyTargetTransform.rotation;
					Quaternion targetRot = default(Quaternion);
					targetRot.x = rotation.x;
					targetRot.y = rotation.y;
					targetRot.z = rotation.z;
					targetRot.w = rotation.w;
					float startZ = keyTransform.position.z;
					float endZ = position.z;
					Vector3 localScale = keyTransform.localScale;
					KeyAndLockConfig config = _config;
					AnimationCurve zCurve = config.zCurve;
					KeyAndLockConfig config2 = _config;
					float zMul = config2.zCurveMultiplier;
					Sequence sequence = Sequence.Create();
					Sequence sequence2 = sequence;
					KeyAndLockConfig config3 = _config;
					TweenSettings moveSettings = config3.moveSettings;
					Tween tween = Tween.PositionX(keyTransform, position.x, moveSettings);
					Sequence sequence3 = sequence2.Group(tween);
					KeyAndLockConfig config4 = _config;
					moveSettings = config4.moveSettings;
					Tween tween2 = Tween.PositionY(keyTransform, position.y, moveSettings);
					Sequence sequence4 = sequence2.Group(tween2);
					Sequence sequence5 = Sequence.Create();
					Sequence sequence6 = sequence5;
					KeyAndLockConfig config5 = _config;
					moveSettings = config5.keyScaleUpSettings;
					float endValue = localScale.x * config5.keyMaxScale;
					Tween tween3 = Tween.Scale(keyTransform, endValue, moveSettings);
					Sequence sequence7 = sequence6.Group(tween3);
					sequence6 = sequence7;
					KeyAndLockConfig config6 = _config;
					moveSettings = config6.keyScaleBackSettings;
					Tween tween4 = Tween.Scale(keyTransform, localScale.x, moveSettings);
					Sequence sequence8 = sequence6.Chain(tween4);
					Sequence sequence9 = sequence2.Group(sequence8);
					KeyAndLockConfig config7 = _config;
					Action<Transform, float> onValueChange = delegate(Transform t, float v)
					{
						if (!(t == null))
						{
							Vector3 position2 = t.position;
							float num = endZ - startZ;
							bool flag3 = v < 1f;
							bool flag4 = v == 1f;
							bool flag5 = v == v;
							bool flag6 = 1f == 1f;
							bool flag7 = flag5 && flag6;
							bool flag8 = !flag7;
							bool flag9 = flag3 == flag8;
							bool flag10 = !flag4;
							float num2 = ((!(flag9 && flag10)) ? v : 1f);
							if (v < 0f)
							{
								num2 = 0f;
							}
							float num3 = num2 * num;
							float num4 = startZ + num3;
							float num5 = zCurve.Evaluate(v);
							float f = num5 * zMul;
							float num6 = Mathf.Abs(f);
							float z2 = num4 - num6;
							Vector3 position3 = default(Vector3);
							position3.x = position2.x;
							position3.y = position2.y;
							position3.z = z2;
							t.position = position3;
						}
					};
					moveSettings = config7.moveZSettings;
					Tween tween5 = Tween.Custom(keyTransform, 0f, 1f, moveSettings, onValueChange);
					Sequence sequence10 = sequence2.Group(tween5);
					Quaternion rotation2 = transform.rotation;
					Quaternion startRot = default(Quaternion);
					startRot.x = rotation2.x;
					startRot.y = rotation2.y;
					startRot.z = rotation2.z;
					startRot.w = rotation2.w;
					KeyAndLockConfig config8 = _config;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
					float x = config8.midRotationEuler.x * rotation2.z;
					float z = config8.midRotationEuler.z * ((float)Math.PI / 180f);
					Vector3 vector = default(Vector3);
					vector.x = x;
					object obj = default(object);
					vector.y = (float)obj;
					vector.z = z;
					Quaternion quaternion = Quaternion.Euler(vector * 57.29578f);
					Quaternion midRot = default(Quaternion);
					midRot.x = quaternion.x;
					midRot.y = quaternion.y;
					midRot.z = quaternion.z;
					midRot.w = quaternion.w;
					KeyAndLockConfig config9 = _config;
					int spinTurns = config9.flightSpinTurns;
					Vector3 spinAxis = default(Vector3);
					spinAxis.z = config9.flightSpinAxis.z;
					spinAxis = config9.flightSpinAxis;
					Sequence sequence11 = Sequence.Create();
					KeyAndLockConfig config10 = _config;
					Action<Transform, float> onValueChange2 = delegate(Transform t, float v)
					{
						if (!(t == null))
						{
							Quaternion a = default(Quaternion);
							a.x = startRot.x;
							a.y = startRot.y;
							a.z = startRot.z;
							a.w = startRot.w;
							Quaternion b = default(Quaternion);
							b.x = midRot.x;
							b.y = midRot.y;
							b.z = midRot.z;
							b.w = midRot.w;
							Quaternion quaternion2 = Quaternion.Slerp(a, b, v);
							float num = v * 360f;
							float angle = num * (float)spinTurns;
							Vector3 axis = default(Vector3);
							axis.x = spinAxis.x;
							axis.y = spinAxis.y;
							axis.z = spinAxis.z;
							Quaternion quaternion3 = Quaternion.AngleAxis(angle, axis);
							float num2 = quaternion2.w * quaternion3.w;
							float num3 = quaternion2.x * quaternion3.x;
							float num4 = num2 - num3;
							float num5 = quaternion2.y * quaternion3.y;
							float num6 = num4 - num5;
							float num7 = quaternion2.z * quaternion3.z;
							float w = num6 - num7;
							float num8 = quaternion2.x * quaternion3.y;
							float num9 = quaternion2.w * quaternion3.z;
							float num10 = quaternion2.z * quaternion3.w;
							float num11 = num9 + num10;
							float num12 = num8 + num11;
							float num13 = quaternion2.y * quaternion3.x;
							float z2 = num12 - num13;
							float num14 = quaternion2.z * quaternion3.x;
							float num15 = quaternion2.w * quaternion3.y;
							float num16 = quaternion2.y * quaternion3.w;
							float num17 = num15 + num16;
							float num18 = num14 + num17;
							float num19 = quaternion2.x * quaternion3.z;
							float y = num18 - num19;
							float num20 = quaternion2.y * quaternion3.z;
							float num21 = quaternion2.w * quaternion3.x;
							float num22 = quaternion2.x * quaternion3.w;
							float num23 = num21 + num22;
							float num24 = num20 + num23;
							float num25 = quaternion2.z * quaternion3.y;
							float x2 = num24 - num25;
							Quaternion rotation3 = default(Quaternion);
							rotation3.x = x2;
							rotation3.y = y;
							rotation3.z = z2;
							rotation3.w = w;
							t.rotation = rotation3;
						}
					};
					moveSettings = config10.rotateToMidSettings;
					Tween tween6 = Tween.Custom(transform, 0f, 1f, moveSettings, onValueChange2);
					Sequence sequence13 = default(Sequence);
					Sequence sequence12 = sequence13.Chain(tween6);
					KeyAndLockConfig config11 = _config;
					Action<Transform, float> onValueChange3 = delegate(Transform t, float v)
					{
						if (!(t == null))
						{
							Quaternion a = default(Quaternion);
							a.x = midRot.x;
							a.y = midRot.y;
							a.z = midRot.z;
							a.w = midRot.w;
							Quaternion b = default(Quaternion);
							b.x = targetRot.x;
							b.y = targetRot.y;
							b.z = targetRot.z;
							b.w = targetRot.w;
							Quaternion rotation3 = Quaternion.Slerp(a, b, v);
							t.rotation = rotation3;
						}
					};
					moveSettings = config11.rotateToTargetSettings;
					Tween tween7 = Tween.Custom(transform, 0f, 1f, moveSettings, onValueChange3);
					Sequence sequence14 = sequence13.Chain(tween7);
					Sequence sequence15 = sequence2.Group(sequence13);
					Sequence sequence16 = Sequence.Create();
					GameColor capturedColor = lockColor;
					Action callback = delegate
					{
						KeyVisualHandler keyVisualHandler = this;
						keyVisualHandler._lockHandler.PlayBreakAnimation(capturedColor);
					};
					Sequence sequence18 = default(Sequence);
					Sequence sequence17 = sequence18.ChainCallback(callback);
					KeyAndLockConfig config12 = _config;
					moveSettings = config12.lockScaleDownSettings;
					Vector3 endValue2 = default(Vector3);
					endValue2.x = Vector3.zero.x;
					endValue2.y = Vector3.zero.y;
					endValue2.z = Vector3.zero.z;
					Tween tween8 = Tween.Scale(transform2, endValue2, moveSettings);
					Sequence sequence19 = sequence18.Group(tween8);
					KeyAndLockConfig config13 = _config;
					moveSettings = config13.keyScaleDownSettings;
					Vector3 endValue3 = default(Vector3);
					endValue3.x = Vector3.zero.x;
					endValue3.y = Vector3.zero.y;
					endValue3.z = Vector3.zero.z;
					Tween tween9 = Tween.Scale(keyTransform, endValue3, moveSettings);
					Sequence sequence20 = sequence18.Group(tween9);
					Sequence sequence21 = sequence2.Chain(sequence18);
					Action callback2 = delegate
					{
						if (onComplete != null)
						{
							onComplete();
						}
					};
					Sequence sequence22 = sequence2.ChainCallback(callback2);
					return;
				}
			}
			if (onComplete != null)
			{
				onComplete();
			}
		}

		[Token(Token = "0x60008B2")]
		[Address(RVA = "0x3E84D28", Offset = "0x3E84D28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public KeyVisualHandler()
		{
		}
	}
}
