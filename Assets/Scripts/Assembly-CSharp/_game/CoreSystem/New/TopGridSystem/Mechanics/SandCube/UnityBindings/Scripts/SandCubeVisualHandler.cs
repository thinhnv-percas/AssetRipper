using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts
{
	[Token(Token = "0x2000191")]
	public class SandCubeVisualHandler : ITopGridVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000516")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000517")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000518")]
		[FieldOffset(Offset = "0x20")]
		private SandCubeConfig _config;

		[Inject(false)]
		[Token(Token = "0x4000519")]
		[FieldOffset(Offset = "0x28")]
		private SnakeBlockerConfig _snakeConfig;

		[Inject(false)]
		[Token(Token = "0x400051A")]
		[FieldOffset(Offset = "0x30")]
		private TopGridVisualHandler _visualCoordinator;

		[Inject(true)]
		[Token(Token = "0x400051B")]
		[FieldOffset(Offset = "0x38")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x400051C")]
		[FieldOffset(Offset = "0x40")]
		private Transform _parent;

		[Token(Token = "0x600077E")]
		[Address(RVA = "0x3E69E1C", Offset = "0x3E69E1C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv173 = 0;\n\tgoto L_0040;\nL_003A:\n\tv347 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v65, v173);\n\tv176 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::Spawn(this, v347);\n\tv173 = v173 + 1;\n\tv224 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv224 = v224 + 0x10;\n\tv191 = v215 - 1;\n\tv189 = v215 != 1;\n\tv215 = v191;\n\tif (v189) goto L_004B;\nL_0064:\n\tv237 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v65);\n\tv248 = v173 < v237;\n\tif (v248) goto L_0089;\n\tgoto L_00B3;\nL_0073:\n\tv251 = *([v224 @ X10_v13]) << 4;\n\tv252 = v182 + v251;\n\tv253 = v252 + 0x138;\n\t*([v253 @ X0_v23])(v257, v65, *([v253 @ X0_v23+8]), 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv267 = v173 >= v257;\n\tif (v267) goto L_00B3;\nL_0089:\n\tgoto L_003A;\nL_00B3:\n\treturn;\nL_0020:\n\tthis._parent = v44;\nL_0040:\n\tv182 = *([v65 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv215 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv134 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v134) goto L_0064;\nL_004B:\n\tv229 = *([v224 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v229) goto L_0073;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::InitVisuals");
		}

		[Token(Token = "0x600077F")]
		[Address(RVA = "0x3E69FB8", Offset = "0x3E69FB8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv61 = ~v52;\n\tif (v61) goto L_003F;\n\tv67 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv69 = ~v67;\n\tif (v69) goto L_003F;\n\treturnVal3 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::Spawn(this, entity);\n\treturn returnVal3;\nL_003F:\n\treturn 0;\n")]
		public GameObject TrySpawn(Entity entity)
		{
			if (_em.HasComponent<SandCubeTag>(entity) && _em.HasComponent<GridPositionComponent>(entity))
			{
				return Spawn(entity);
			}
			return null;
		}

		[Token(Token = "0x6000780")]
		[Address(RVA = "0x3E6A06C", Offset = "0x3E6A06C", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv140 = 0;\n\tgoto L_0035;\nL_0033:\n\tv140 = v140 + 1;\n\tv309 = *([v267 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv309 = v309 + 0x10;\n\tv276 = v300 - 1;\n\tv274 = v300 != 1;\n\tv300 = v276;\n\tif (v274) goto L_0040;\nL_0059:\n\tv322 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v59);\n\tv333 = v140 < v322;\n\tif (v333) goto L_007E;\n\tgoto L_013B;\nL_0068:\n\tv336 = *([v309 @ X10_v27]) << 4;\n\tv337 = v267 + v336;\n\tv338 = v337 + 0x138;\n\t*([v338 @ X0_v45])(v342, v59, *([v338 @ X0_v45+8]), v233, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv352 = v140 >= v342;\n\tif (v352) goto L_013B;\nL_007E:\n\tgoto L_00A5;\nL_00B0:\n\tv457 = UnityEngine.Object::op_Equality(v450, 0);\n\tv460 = v457 == 0;\n\tv461 = ~v460;\n\tv233 = 0;\n\tif (v461) goto L_0033;\n\tgoto L_00C1;\nL_00C1:\n\tv476 = *([v59 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv496 = *([v476 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv478 = *([v476 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v478) goto L_00E6;\n\tv131 = *([v476 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv131 = v131 + 0x10;\n\tv482 = v496 - 1;\n\tv481 = v496 != 1;\n\tv496 = v482;\n\tif (v481) goto L_00CC;\nL_00E6:\n\tv527 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v140);\n\tv507 = this._visualCoordinator == 0;\n\tv151 = ~v507;\n\tif (v151) goto L_00F9;\n\tgoto L_013C;\nL_00EC:\n\tv72 = *([v131 @ X10_v16]) << 4;\n\tv509 = v476 + v72;\n\tv510 = v509 + 0x138;\n\t*([v510 @ X0_v29])(v527, v59, v140, *([v510 @ X0_v29+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00F9:\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::NotifyEntityRemoving(this._visualCoordinator, v527);\n\tgoto L_0125;\n\tv467 = UnityEngine.Component::get_gameObject(v450);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v467);\n\tv233 = 0;\n\tgoto L_0033;\nL_013B:\n\treturn;\nL_013C:\n\tthrow System.NullReferenceException;\nL_0035:\n\tv267 = *([v59 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv300 = *([v267 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv217 = *([v267 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v217) goto L_0059;\nL_0040:\n\tv314 = *([v309 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v314) goto L_0068;\nL_00A5:\n\tv448 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v140);\n\tv450 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v448);\n\tgoto L_00B0;\nL_00CC:\n\tv111 = *([v131 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v111) goto L_00EC;\nL_0125:\n\tv148 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v140);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v148);\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000781")]
		[Address(RVA = "0x3E6A34C", Offset = "0x3E6A34C", Length = "0x564")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv282 = *([v64 @ X0_v52 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv374 = *([v282 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv284 = *([v282 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v284) goto L_0063;\n\tv248 = *([v282 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv248 = v248 + 0x10;\n\tv301 = v374 - 1;\n\tv290 = v374 != 1;\nL_FFFFFFFF:\n\tv374 = v301;\n\tif (v290) goto L_0049;\nL_0063:\n\tv443 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v64);\n\tv379 = v443 == 0;\n\tv264 = ~v379;\nL_FFFFFFFF:\n\tv574 = &v204 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv202 = 0;\n\tif (v264) goto L_FFFFFFFF;\n\tgoto L_01FE;\nL_006D:\n\tv193 = *([v248 @ X10_v44]) << 4;\n\tv425 = v282 + v193;\n\tv426 = v425 + 0x138;\n\t*([v426 @ X8_v44])(v443, v64, *([v426 @ X8_v44+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv265 = v443 == 0;\nL_FFFFFFFF:\n\tv574 = &v204 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv202 = 0;\n\tif (v265) goto L_01FE;\nL_FFFFFFFF:\n\tv471 = v443;\n\tgoto L_008B;\nL_0083:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::SetVisual(this, v807);\nL_0085:\n\tv266 = v204 == 0;\nL_FFFFFFFF:\n\tv471 = v204;\n\tif (v266) goto L_01FE;\nL_008B:\n\tgoto L_00B1;\n\tv355 = v204 == 0;\n\tif (v355) goto L_0202;\n\tgoto L_00E2;\n\tv853 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v807);\n\tv855 = v853 == 0;\n\tif (v855) goto L_00FF;\n\tv862 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v807, &v55 @ stack_-68_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv892 = v862 == 0;\n\tv893 = ~v892;\n\tif (v893) goto L_0083;\n\tv922 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::Spawn(this, v807);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::SetVisual(this, v807);\n\tgoto L_0085;\nL_00FF:\n\tv865 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v807, &v307 @ stack_-60_v9 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv895 = v865 == 0;\n\tif (v895) goto L_0085;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v807);\n\tv929 = UnityEngine.Component::get_gameObject(v307);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v929);\n\tgoto L_0085;\nL_0110:\n\tv564 = &v204 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv572 = *([v564 @ X8_v35]);\n\tv566 = *([v564 @ X8_v35]) == 0;\nL_FFFFFFFF:\n\tv571 = 6;\nL_FFFFFFFF:\n\tv594 = 0;\nL_FFFFFFFF:\n\tv595 = oldData;\nL_FFFFFFFF:\n\tv78 = 6;\nL_FFFFFFFF:\n\tv387 = v574;\nL_FFFFFFFF:\n\tv817 = 0;\nL_FFFFFFFF:\n\tv410 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv170 = 0;\nL_FFFFFFFF:\n\tv417 = oldData;\n\tif (v566) goto L_0141;\nL_011A:\n\tgoto L_0140;\n\tv122 = v78 == 6;\n\tif (v122) goto L_0155;\n\tv788 = v78 == 0;\n\tv789 = ~v788;\n\tif (v789) goto L_01FC;\nL_0155:\n\tv155 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v417);\nL_FFFFFFFF:\n\tv171 = 0;\n\tgoto L_0161;\nL_015F:\n\tv171 = v171 + 1;\n\tv837 = *([v889 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv837 = v837 + 0x10;\n\tv917 = v941 - 1;\n\tv899 = v941 != 1;\nL_FFFFFFFF:\n\tv941 = v917;\n\tif (v899) goto L_016C;\nL_0185:\n\tv843 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v155);\n\tv818 = v171 < v843;\n\tif (v818) goto L_01AA;\n\tgoto L_01FC;\nL_0194:\n\tv815 = *([v837 @ X10_v15]) << 4;\n\tv956 = v889 + v815;\n\tv957 = v956 + 0x138;\n\t*([v957 @ X0_v37])(v844, v155, *([v957 @ X0_v37+8]), v817, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv819 = v171 >= v844;\n\tif (v819) goto L_01FC;\nL_01AA:\n\tgoto L_01D1;\n\tv1044 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v1041);\n\tv1046 = v1044 == 0;\n\tv1047 = ~v1046;\nL_FFFFFFFF:\n\tv817 = 0;\n\tif (v1047) goto L_015F;\n\tv1049 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v1041, &v71 @ stack_-70_v6 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv1052 = ~v1049;\nL_FFFFFFFF:\n\tv817 = 0;\n\tif (v1052) goto L_015F;\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::NotifyEntityRemoving(this._visualCoordinator, v1041);\n\tv1051 = UnityEngine.Component::get_gameObject(v71);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v1051);\nL_FFFFFFFF:\n\tv817 = 0;\n\tgoto L_015F;\nL_01FC:\n\treturn;\nL_01FE:\n\tthrow System.NullReferenceException;\nL_0200:\n\tthrow System.NullReferenceException;\nL_0202:\n\tthrow System.NullReferenceException;\nL_021E:\n\tv485 = v410 != 1;\n\tif (v485) goto L_022D;\n\tv515 = 0x8BF5BC4(v419, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv594 = *([v515 @ X0_v11]);\n\tv542 = 0x8BF5BF4(v515, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv572 = *([v387 @ stack_-78_v1]);\n\tv559 = *([v387 @ stack_-78_v1]) == 0;\n\tv560 = ~v559;\nL_FFFFFFFF:\n\tv571 = 0;\nL_FFFFFFFF:\n\tv574 = v387;\nL_FFFFFFFF:\n\tv202 = *([v515 @ X0_v11]);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv595 = v417;\n\tif (v560) goto L_011A;\nL_FFFFFFFF:\n\tv78 = 0;\nL_FFFFFFFF:\n\tv202 = *([v515 @ X0_v11]);\nL_FFFFFFFF:\n\tv170 = *([v515 @ X0_v11]);\n\tgoto L_0141;\nL_022D:\n\tv518 = 0x3175484(&v202 @ stack_-80_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv544 = 0x8BF0368(v419, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv561 = 0xA1B8(v544, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0031:\n\tv55 = 0;\nL_0049:\n\tv232 = *([v248 @ X10_v44-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v232) goto L_006D;\nL_00B1:\n\tv553 = System.Collections.IEnumerator::MoveNext(v471);\n\tv555 = v553 == 0;\n\tif (v555) goto L_0110;\nL_00E2:\n\tv807 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v204);\n\tv354 = this._em == 0;\n\tif (v354) goto L_0200;\nL_0141:\n\tv624 = v170 == 0;\n\tv414 = ~v624;\n\tif (v414) goto L_0207;\nL_0140:\n\tSystem.IDisposable::Dispose(v572);\nL_FFFFFFFF:\n\tv78 = v571;\nL_FFFFFFFF:\n\tv387 = v574;\nL_FFFFFFFF:\n\tv817 = 0;\nL_FFFFFFFF:\n\tv410 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv170 = v594;\nL_FFFFFFFF:\n\tv417 = v595;\nL_0161:\n\tv889 = *([v155 @ X0_v16 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv941 = *([v889 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv845 = *([v889 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\n// ... truncated")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::SyncWithData");
		}

		[Token(Token = "0x6000782")]
		[Address(RVA = "0x3E6A8B0", Offset = "0x3E6A8B0", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv70 = UnityEngine.Component::GetComponent(v59);\n\tv207 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv263 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v207);\n\tv176 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::TryGetSnakeBodyZOffset(this, entity, &v131 @ stack_-64_v3 (System.Single));\n\tv145 = v263.z + v131;\n\tv116 = v176 == 0;\n\tv96 = ~v116;\n\tv92 = ~v96;\n\tif (v92) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = v145;\n\tgoto L_0064;\nL_FFFFFFFF:\n\tv133 = v263.z;\nL_0064:\n\tv170 = UnityEngine.Component::get_transform(v70);\n\t// 107 MakeStruct v89 @ AGG3E6A9E4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v263 @ V0_v2 (UnityEngine.Vector3), v263.y (System.Single), v133 @ V10_v3 (System.Single)\n\tUnityEngine.Transform::set_position(v170, v89);\n\tv272 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv274 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv279 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv280 = *([v70 @ X0_v6 (_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase)]);\n\tv117 = v274 == 0;\n\tv284 = ~v117;\n\tv285 = ~v284;\n\tif (v285) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv288 = 0x188;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv288 = 0x198;\nL_FFFFFFFF:\n\tv76 = 0x190;\n\tgoto L_00A7;\nL_FFFFFFFF:\n\tv76 = 0x1A0;\n\tv306 = System.Text.StringBuilder::Insert(v174, 0, \"SandCube_\");\n\tv309 = UnityEngine.Component::get_gameObject(v70);\n\tv175 = System.Text.StringBuilder::ToString(v174);\n\tUnityEngine.Object::set_name(v309, v175);\n\treturn;\nL_002D:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\nL_009D:\n\tv97 = ~v117;\n\tv93 = ~v97;\n\tif (v93) goto L_FFFFFFFF;\nL_00A7:\n\t*([v280 @ X8_v14 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase>)+v288 @ X9_v3 (System.Int32)])(v295, v70, *([v280 @ X8_v14 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase>)+v76 @ X10_v4 (System.Int32)]), Il2CppMethodInfo, 0, v40, v41, v42, v43, v263, v263.y, v133, v47, v48, v49, v50, v51);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetHidden(v70, v279);\n\tv301 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::ApplyMaterial(v70, v272);\n\tv174 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\n")]
		private void SetVisual(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::SetVisual");
		}

		[Token(Token = "0x6000783")]
		[Address(RVA = "0x3E5EB04", Offset = "0x3E5EB04", Length = "0x3C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv66 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv240 = ~v66;\n\tif (v240) goto L_FFFFFFFF;\n\tv203 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv228 = this._config;\n\tv172 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v203);\n\tgoto L_006C;\n\tv391 = System.Text.StringBuilder::Insert(v205, 0, \"SandCube_\");\n\tv206 = System.Text.StringBuilder::ToString(v205);\n\tUnityEngine.Object::set_name(v386, v206);\n\tv173 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv397 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::TryGetSnakeBodyVisualParams(this, entity, &v131 @ stack_-64_v3 (System.Single), &v128 @ stack_-68_v4 (System.Single));\n\tv208 = UnityEngine.GameObject::get_transform(v386);\n\tv177 = v173 * v131;\n\tv114 = v397 == 0;\n\tv97 = ~v114;\n\tv94 = ~v97;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_00AE;\nL_FFFFFFFF:\n\tv177 = v173;\nL_00CB:\n\t// 203 MakeStruct v91 @ AGG3E5ED70_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v231.zero (UnityEngine.Vector3), v231.zero.y (System.Single), v231.zero.z (System.Single)\n\tUnityEngine.Transform::set_localEulerAngles(v213, v91);\n\tv113 = v128 == 0;\n\tif (v113) goto L_00EF;\n\tv209 = UnityEngine.GameObject::get_transform(v386);\n\tv175 = UnityEngine.Transform::get_localPosition(v209);\n\tv210 = UnityEngine.GameObject::get_transform(v386);\n\tv424 = v128 + v175.z;\n\t// 234 MakeStruct v423 @ AGG3E5EDC4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v175 @ V0_v10 (UnityEngine.Vector3), v175.y (System.Single), v424 @ V2_v9 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v210, v423);\nL_00EF:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(v386, entity);\n\tv438 = UnityEngine.GameObject::GetComponent(v386);\n\tgoto L_00FF;\nL_00FF:\n\tv448 = UnityEngine.Object::op_Inequality(v438, 0);\n\tv450 = ~v448;\n\tv451 = ~v450;\n\tif (v451) goto L_0113;\n\tgoto L_012B;\nL_FFFFFFFF:\n\tv351 = 0;\n\tgoto L_013A;\nL_0113:\n\tv438._config = this._config;\n\tv438._vfxPool = this._vfxPool;\n\tv476 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetHidden(v438, v476);\nL_012B:\n\tv348 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::OnSpawned(this, v386, entity);\nL_FFFFFFFF:\n\tv351 = v386;\nL_006C:\n\t// 108 MakeStruct v75 @ AGG3E5EC60_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v172 @ V0_v4 (UnityEngine.Vector3), v172.y (System.Single), v172.z (System.Single)\n\t// 109 MakeStruct v72 @ AGG3E5EC60_2_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v381.identity (UnityEngine.Quaternion), v381.identity.y (System.Single), v381.identity.z (System.Single), v381.identity.w (System.Single)\n\tv386 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v228.sandCubePrefab, v75, v72, this._parent);\n\tv205 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\nL_00AE:\n\t// 174 MakeStruct v69 @ AGG3E5ED14_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v177 @ V0_v7 (System.Single), v177 @ V0_v7 (System.Single), v177 @ V0_v7 (System.Single)\n\tUnityEngine.Transform::set_localScale(v208, v69);\n\tv213 = UnityEngine.GameObject::get_transform(v386);\n\tgoto L_00CB;\nL_013A:\n\treturn v351;\n")]
		public GameObject Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::Spawn");
			return default;
		}

		[Token(Token = "0x6000784")]
		[Address(RVA = "0x3E6ADA4", Offset = "0x3E6ADA4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x6000785")]
		[Address(RVA = "0x3E6AC60", Offset = "0x3E6AC60", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_002C:\n\tv63 = UnityEngine.Object::op_Equality(this._snakeConfig, 0);\n\tv68 = v63 == 0;\n\tif (v68) goto L_004B;\n\treturnVal1 = 0;\nL_004B:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv97 = ~returnVal1;\n\tif (v97) goto L_003A;\n\tv148 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv149 = v148 & 0x8000000000000000;\n\tv150 = v149 == 0;\n\tv98 = ~v150;\n\treturnVal1 = 0;\n\tif (v98) goto L_003A;\n\tv151 = entity & 0x80000000;\n\tv152 = v151 == 0;\n\tv99 = ~v152;\n\treturnVal1 = 0;\n\tif (v99) goto L_003A;\n\tv120 = this._snakeConfig;\n\t*([bodyScaleRatio @ X2 (System.Single&)]) = v120.bodyScaleRatio;\n\t*([bodyZOffset @ X3 (System.Single&)]) = v120.bodyZOffset;\n\treturn 1;\nL_0022:\n\t*([bodyScaleRatio @ X2 (System.Single&)]) = 0x3F800000;\n\t*([bodyZOffset @ X3 (System.Single&)]) = 0;\n\tgoto L_002C;\nL_003A:\n\treturn returnVal1;\n")]
		private bool TryGetSnakeBodyVisualParams(Entity entity, out float bodyScaleRatio, out float bodyZOffset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::TryGetSnakeBodyVisualParams");
			bodyScaleRatio = default;
			bodyZOffset = default;
			return default;
		}

		[Token(Token = "0x6000786")]
		[Address(RVA = "0x3E6AB1C", Offset = "0x3E6AB1C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB78E000;\n\tv28 = *([B78E57C]) & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_0036;\n\t*([bodyZOffset @ X2 (System.Single&)]) = 0;\n\tv56 = this._snakeConfig;\n\tgoto L_001D;\nL_001D:\n\tv61 = UnityEngine.Object::op_Equality(v56, 0);\n\tv71 = v61 == 0;\n\tif (v71) goto L_004E;\n\treturnVal1 = 0;\nL_0036:\n\t*([v24 @ X22_v1+57C]) = 1;\n\t*([bodyZOffset @ X2 (System.Single&)]) = 0;\n\tv56 = this._snakeConfig;\n\tgoto L_001D;\nL_004E:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv109 = ~returnVal1;\n\tif (v109) goto L_002B;\n\tv161 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv162 = v161 & 0x8000000000000000;\n\tv163 = v162 == 0;\n\tv110 = ~v163;\n\treturnVal1 = 0;\n\tif (v110) goto L_002B;\n\tv164 = entity & 0x80000000;\n\tv165 = v164 == 0;\n\tv111 = ~v165;\n\treturnVal1 = 0;\n\tif (v111) goto L_002B;\n\tv133 = this._snakeConfig;\n\t*([bodyZOffset @ X2 (System.Single&)]) = v133.bodyZOffset;\n\treturn 1;\nL_002B:\n\treturn returnVal1;\n")]
		private bool TryGetSnakeBodyZOffset(Entity entity, out float bodyZOffset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeVisualHandler::TryGetSnakeBodyZOffset");
			bodyZOffset = default;
			return default;
		}

		[Token(Token = "0x6000787")]
		[Address(RVA = "0x3E6ADA8", Offset = "0x3E6ADA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandCubeVisualHandler()
		{
		}
	}
}
