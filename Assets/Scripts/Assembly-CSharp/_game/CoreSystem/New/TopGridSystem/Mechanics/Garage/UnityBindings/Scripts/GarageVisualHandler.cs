using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Shared.Cover;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts
{
	[Token(Token = "0x2000221")]
	public class GarageVisualHandler : ITopGridVisualHandler
	{
		[Token(Token = "0x2000222")]
		private struct UnderRevealSnapshot
		{
			[Token(Token = "0x40006B1")]
			[FieldOffset(Offset = "0x0")]
			public Transform transform;

			[Token(Token = "0x40006B2")]
			[FieldOffset(Offset = "0x8")]
			public Transform originalParent;

			[Token(Token = "0x40006B3")]
			[FieldOffset(Offset = "0x10")]
			public Vector3 originalWorldPos;

			[Token(Token = "0x40006B4")]
			[FieldOffset(Offset = "0x1C")]
			public Vector3 originalLocalScale;
		}

		[CompilerGenerated]
		[Token(Token = "0x2000223")]
		private sealed class _003C_003Ec__DisplayClass16_0
		{
			[Token(Token = "0x40006B5")]
			[FieldOffset(Offset = "0x10")]
			public List<UnderRevealSnapshot> snapshots;

			[Token(Token = "0x40006B6")]
			[FieldOffset(Offset = "0x18")]
			public GameObject pivotGo;

			[Token(Token = "0x6000982")]
			[Address(RVA = "0x3E96384", Offset = "0x3E96384", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass16_0()
			{
			}

			internal void _003CPlayUnderReveal_003Eb__0(GameObject _)
			{
				RestoreFromUnderReveal(snapshots, pivotGo);
			}
		}

		[Inject(false)]
		[Token(Token = "0x40006AB")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40006AC")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40006AD")]
		[FieldOffset(Offset = "0x20")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x40006AE")]
		[FieldOffset(Offset = "0x28")]
		private GarageConfig _config;

		[Inject(true)]
		[Token(Token = "0x40006AF")]
		[FieldOffset(Offset = "0x30")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x40006B0")]
		[FieldOffset(Offset = "0x38")]
		private Transform _parent;

		[Token(Token = "0x6000973")]
		[Address(RVA = "0x3E93CB8", Offset = "0x3E93CB8", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv70 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv171 = 0;\n\tgoto L_004C;\nL_0046:\n\tv598 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv492 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::Spawn(this, v598);\n\tv285 = 0;\nL_004A:\n\tv171 = v171 + 1;\n\tv339 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv339 = v339 + 0x10;\n\tv306 = v330 - 1;\n\tv304 = v330 != 1;\n\tv330 = v306;\n\tif (v304) goto L_0057;\nL_0070:\n\tv352 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v70);\n\tv363 = v171 < v352;\n\tif (v363) goto L_0093;\n\tgoto L_013B;\nL_007F:\n\tv366 = *([v339 @ X10_v27]) << 4;\n\tv367 = v297 + v366;\n\tv368 = v367 + 0x138;\n\t*([v368 @ X0_v44])(v372, v70, *([v368 @ X0_v44+8]), v285, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv382 = v171 >= v372;\n\tif (v382) goto L_013B;\nL_0093:\n\tv400 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv420 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv402 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v402) goto L_00B8;\n\tv149 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv149 = v149 + 0x10;\n\tv406 = v420 - 1;\n\tv405 = v420 != 1;\n\tv420 = v406;\n\tif (v405) goto L_009E;\nL_00B8:\n\tv450 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv431 = this._em == 0;\n\tv179 = ~v431;\n\tif (v179) goto L_00CB;\n\tgoto L_013C;\nL_00BE:\n\tv83 = *([v149 @ X10_v22]) << 4;\n\tv433 = v400 + v83;\n\tv434 = v433 + 0x138;\n\t*([v434 @ X0_v37])(v450, v70, v171, *([v434 @ X0_v37+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CB:\n\tv456 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v450);\n\tv457 = ~v456;\n\tv285 = Il2CppMethodInfo;\n\tif (v457) goto L_004A;\n\tv459 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv515 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv461 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v461) goto L_00F5;\n\tv151 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv151 = v151 + 0x10;\n\tv501 = v515 - 1;\n\tv500 = v515 != 1;\n\tv515 = v501;\n\tif (v500) goto L_00DB;\nL_00F5:\n\tv533 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv526 = this._em == 0;\n\tv181 = ~v526;\n\tif (v181) goto L_0108;\n\tgoto L_013C;\nL_00FB:\n\tv85 = *([v151 @ X10_v16]) << 4;\n\tv528 = v459 + v85;\n\tv529 = v528 + 0x138;\n\t*([v529 @ X0_v29])(v533, v70, v171, *([v529 @ X0_v29+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0108:\n\tv493 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v533);\n\tv495 = ~v493;\n\tv285 = Il2CppMethodInfo;\n\tif (v495) goto L_004A;\n\tgoto L_0046;\nL_013B:\n\treturn;\nL_013C:\n\tthrow System.NullReferenceException;\nL_0028:\n\tthis._parent = v48;\nL_004C:\n\tv297 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv330 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv248 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v248) goto L_0070;\nL_0057:\n\tv344 = *([v339 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v344) goto L_007F;\nL_009E:\n\tv125 = *([v149 @ X10_v22-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v125) goto L_00BE;\nL_00DB:\n\tv127 = *([v151 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v127) goto L_00FB;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::InitVisuals");
		}

		[Token(Token = "0x6000974")]
		[Address(RVA = "0x3E946B4", Offset = "0x3E946B4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv69 = ~v53;\n\tif (v69) goto L_004C;\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv78 = ~v75;\n\tif (v78) goto L_004C;\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv79 = ~v76;\n\tif (v79) goto L_004C;\n\treturnVal3 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::Spawn(this, entity);\n\treturn returnVal3;\nL_004C:\n\treturn 0;\n")]
		public GameObject TrySpawn(Entity entity)
		{
			if (_em.HasComponent<GarageTag>(entity) && _em.HasComponent<GarageComponent>(entity) && _em.HasComponent<GridPositionComponent>(entity))
			{
				return Spawn(entity);
			}
			return null;
		}

		[Token(Token = "0x6000975")]
		[Address(RVA = "0x3E94794", Offset = "0x3E94794", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv112 = 0;\n\tgoto L_0046;\nL_003A:\n\tv116 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v116);\n\tv432 = UnityEngine.Component::get_gameObject(v415);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v432);\n\tv219 = 0;\nL_0044:\n\tv112 = v112 + 1;\n\tv273 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv273 = v273 + 0x10;\n\tv240 = v264 - 1;\n\tv238 = v264 != 1;\n\tv264 = v240;\n\tif (v238) goto L_0051;\nL_006A:\n\tv286 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v59);\n\tv297 = v112 < v286;\n\tif (v297) goto L_008F;\n\tgoto L_0131;\nL_0079:\n\tv300 = *([v273 @ X10_v27]) << 4;\n\tv301 = v231 + v300;\n\tv302 = v301 + 0x138;\n\t*([v302 @ X0_v43])(v306, v59, *([v302 @ X0_v43+8]), v219, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv316 = v112 >= v306;\n\tif (v316) goto L_0131;\nL_008F:\n\tgoto L_00B6;\nL_00C1:\n\tv422 = UnityEngine.Object::op_Equality(v415, 0);\n\tv425 = v422 == 0;\n\tv426 = ~v425;\n\tv219 = 0;\n\tif (v426) goto L_0044;\n\tgoto L_00D5;\nL_00D5:\n\tgoto L_00FC;\nL_0131:\n\treturn;\nL_0046:\n\tv231 = *([v59 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv264 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv181 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v181) goto L_006A;\nL_0051:\n\tv278 = *([v273 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v278) goto L_0079;\nL_00B6:\n\tv413 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\tv415 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v413);\n\tgoto L_00C1;\nL_00FC:\n\tv519 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::RestoreUnderVisualsFromData(this, this._em, v519);\n\tgoto L_003A;\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000976")]
		[Address(RVA = "0x3E94C88", Offset = "0x3E94C88", Length = "0x628")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv67 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(oldData);\n\tv755 = 0xB28F000 + 0x8D0;\nL_FFFFFFFF:\n\tv129 = methodInfo;\nL_FFFFFFFF:\n\tv265 = 0;\n\tgoto L_0058;\nL_0051:\n\tv659 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v67, v265);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::RestoreUnderVisualsFromData(this, oldData, v659);\n\tv265 = v265 + 1;\nL_FFFFFFFF:\n\tv129 = v659;\n\tv471 = *([v276 @ X8_v15 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv471 = v471 + 0x10;\n\tv369 = v462 - 1;\n\tv367 = v462 != 1;\nL_FFFFFFFF:\n\tv462 = v369;\n\tif (v367) goto L_0063;\nL_007C:\n\tv484 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v67);\n\tv495 = v265 < v484;\n\tif (v495) goto L_00A1;\nL_FFFFFFFF:\n\tv129 = 0;\n\tgoto L_FFFFFFFF;\nL_008B:\n\tv501 = *([v471 @ X10_v59]) << 4;\n\tv502 = v276 + v501;\n\tv503 = v502 + 0x138;\n\t*([v503 @ X0_v102])(v507, v67, *([v503 @ X0_v102+8]), v129, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv517 = v265 >= v507;\n\tif (v517) goto L_FFFFFFFF;\nL_00A1:\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv139 = 0;\n\tgoto L_00C6;\nL_00C4:\n\tv139 = v139 + 1;\n\tv711 = *([v625 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv711 = v711 + 0x10;\n\tv672 = v702 - 1;\n\tv670 = v702 != 1;\nL_FFFFFFFF:\n\tv702 = v672;\n\tif (v670) goto L_00D1;\nL_00EA:\n\tv724 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v67);\n\tv735 = v139 < v724;\n\tif (v735) goto L_010F;\nL_FFFFFFFF:\n\tv129 = 0;\n\tgoto L_015A;\nL_00F9:\n\tv779 = *([v711 @ X10_v47]) << 4;\n\tv780 = v625 + v779;\n\tv781 = v780 + 0x138;\n\t*([v781 @ X0_v87])(v785, v67, *([v781 @ X0_v87+8]), v129, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv795 = v139 >= v785;\n\tif (v795) goto L_015A;\nL_010F:\n\tgoto L_0136;\n\tv1079 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v1002);\n\tv1118 = ~v1079;\nL_FFFFFFFF:\n\tv128 = 0;\n\tif (v1118) goto L_014D;\n\tv1041 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::FootprintChanged(oldData, this._em, v1002);\n\tv1043 = ~v1041;\nL_FFFFFFFF:\n\tv129 = v1002;\nL_FFFFFFFF:\n\tv128 = v1002;\n\tif (v1043) goto L_00C4;\nL_014D:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v1002);\n\tv1042 = UnityEngine.Component::get_gameObject(v73);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v1042);\nL_FFFFFFFF:\n\tv129 = v128;\n\tgoto L_00C4;\nL_015A:\n\tv150 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv1005 = *([v150 @ X0_v32 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv1046 = *([v1005 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv1007 = *([v1005 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v1007) goto L_017E;\n\tv1055 = *([v1005 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv1055 = v1055 + 0x10;\n\tv1016 = v1046 - 1;\n\tv1014 = v1046 != 1;\nL_FFFFFFFF:\n\tv1046 = v1016;\n\tif (v1014) goto L_0169;\nL_017E:\n\tv1037 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v150, System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv1037.m_value(v1109, v150, *([v1037 @ X0_v62 (System.Boolean)+8]), 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1075 = v1109 == 0;\n\tv1076 = ~v1075;\nL_FFFFFFFF:\n\tv739 = &v1072 @ stack_-70_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv176 = 0;\n\tif (v1076) goto L_FFFFFFFF;\n\tgoto L_0265;\nL_018D:\n\tv1082 = *([v1055 @ X10_v35]) << 4;\n\tv1083 = v1005 + v1082;\n\tv1084 = v1083 + 0x138;\n\t*([v1084 @ X8_v36])(v1109, v150, *([v1084 @ X8_v36+8]), v129, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1093 = v1109 == 0;\nL_FFFFFFFF:\n\tv739 = &v1072 @ stack_-70_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv176 = 0;\n\tif (v1093) goto L_0265;\nL_FFFFFFFF:\n\tv1143 = v1109;\n\tgoto L_01AD;\nL_01A5:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::SetVisual(this, v1276);\nL_01A7:\n\tv1123 = v1072 == 0;\nL_FFFFFFFF:\n\tv1143 = v1072;\n\tif (v1123) goto L_0265;\nL_01AD:\n\tgoto L_01D3;\n\tv350 = v1072 == 0;\n\tif (v350) goto L_026A;\n\tgoto L_0204;\n\tv1277 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1276);\n\tv1279 = v1277 == 0;\n\tif (v1279) goto L_01A7;\n\tv1286 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1276);\n\tv1289 = v1286 == 0;\n\tif (v1289) goto L_01A7;\n\tv1293 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v1276, &v58 @ stack_-78_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv1295 = v1293 == 0;\n\tv1288 = ~v1295;\n\tif (v1288) goto L_01A5;\n\tv1298 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::Spawn(this, v1276);\n\tgoto L_01A5;\nL_0225:\n\tv767 = &v1072 @ stack_-70_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv771 = *([v767 @ X8_v27]);\n\tv765 = *([v767 @ X8_v27]) == 0;\nL_FFFFFFFF:\n\tv754 = 0;\nL_FFFFFFFF:\n\tv769 = 0;\nL_FFFFFFFF:\n\tv397 = v739;\nL_FFFFFFFF:\n\tv427 = 0;\nL_FFFFFFFF:\n\tv429 = v755;\nL_FFFFFFFF:\n\tv439 = 0;\nL_FFFFFFFF:\n\tv452 = 0;\n\tif (v765) goto L_0254;\nL_022A:\n\tv774 = *([v771 @ X20_v8 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager)]);\n\tv943 = *([v774 @ X8_v10 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>)+12E]);\n\tv776 = *([v774 @ X8_v10 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>)+12E]) == 0;\n\tif (v776) goto L_024A;\n\tv952 = *([v774 @ X8_v10 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>)+B0]) + 8;\n\tv952 = v952 + 0x10;\n\tv843 = v943 - 1;\n\tv841 = v943 != 1;\nL_FFFFFFFF:\n\tv943 = v843;\n\tif (v841) goto L_0235;\nL_024A:\n\tv988 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v771, *([v755 @ X24_v7 (System.Int32)]));\nL_FFFFFFFF:\n\tv427 = 0;\n\tgoto L_0251;\nL_024D:\n\tv985 = *([v952 @ X10_v11]) << 4;\n\tv986 = v774 + v985;\n\tv988 = v986 + 0x138;\nL_FFFFFFFF:\n\tv427 = v754;\n\treturn;\nL_0265:\n\tthrow System.NullReferenceException;\nL_0268:\n\tthrow System.NullReferenceException;\nL_026A:\n\tthrow System.NullReferenceException;\nL_0283:\n\tv547 = v439 != 1;\n\tif (v547) goto L_0291;\n\tv597 = 0x8BF5BC4(v456, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv769 = *([v597 @ X0_v10]);\n\tv662 = 0x8BF5BF4(v597, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv771 = *([v397 @ stack_-80_v1]);\n\tv697 = *([v397 @ stack_-80_v1]) == 0;\n\tv698 = ~v697;\nL_FFFFFFFF:\n\tv739 = v397;\nL_FFFFFFFF:\n\tv176 = *([v597 @ X0_v10]);\nL_FFFFFFFF:\n\tv754 = v427;\nL_FFFFFFFF:\n\tv755 = v429;\n\tif (v698) goto L_022A;\nL_FFFFFFFF:\n\tv176 = *([v597 @ X0_v10]);\nL_FFFFFFFF:\n\tv452 = *([v597 @ X0_v10]);\n\tgoto L_0254;\nL_0291:\n\tv600 = 0x3175484(&v176 @ stack_-88_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv664 = 0x8BF0368(v456, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered\n// ... truncated")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::SyncWithData");
		}

		[Token(Token = "0x6000977")]
		[Address(RVA = "0x3E95438", Offset = "0x3E95438", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv67 = UnityEngine.Component::get_gameObject(v58);\n\tv237 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv295 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\t// 74 NewArr v298 @ X0_v17 (System.Object[]), typeof(System.Object[]), 5\n\tv117 = v295;\n\tv113 = 0xB7D5000 + 0x538;\n\tv141 = \"il2cpp_vm_object_box\"(*([v113 @ X28_v5 (System.Int32)+48]), &v117 @ stack_-64_v4 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv352 = v141 == 0;\n\tif (v352) goto L_0060;\n\tv267 = 0x21C11D0(v141, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv273 = v267 == 0;\n\tif (v273) goto L_0119;\nL_0060:\n\tv194 = v295 >> 0x20;\n\tv298[0] = v141;\n\tv106 = v194;\n\tv362 = \"il2cpp_vm_object_box\"(*([v113 @ X28_v5 (System.Int32)+48]), &v106 @ stack_-68_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv363 = v362 == 0;\n\tif (v363) goto L_007C;\n\tv268 = 0x21C11D0(v362, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv274 = v268 == 0;\n\tif (v274) goto L_0119;\nL_007C:\n\tv298[1] = v362;\n\tv91 = entity;\n\tv373 = \"il2cpp_vm_object_box\"(*([v113 @ X28_v5 (System.Int32)+48]), &v91 @ stack_-6C_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v373 == 0;\n\tif (v374) goto L_0099;\n\tv269 = 0x21C11D0(v373, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv275 = v269 == 0;\n\tif (v275) goto L_0119;\nL_0099:\n\tv111 = entity >> 0x20;\n\tv298[2] = v373;\n\tv73 = v111;\n\tv385 = \"il2cpp_vm_object_box\"(*([v113 @ X28_v5 (System.Int32)+48]), &v73 @ stack_-70_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv386 = v385 == 0;\n\tif (v386) goto L_00B5;\n\tv270 = 0x21C11D0(v385, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv276 = v270 == 0;\n\tif (v276) goto L_0119;\nL_00B5:\n\tv298[3] = v385;\n\tv70 = v237;\n\tv396 = \"il2cpp_vm_object_box\"(*([v113 @ X28_v5 (System.Int32)+48]), &v70 @ stack_-74_v4 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data.GarageComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv397 = v396 == 0;\n\tif (v397) goto L_00D6;\n\tv271 = 0x21C11D0(v396, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv277 = v271 == 0;\n\tif (v277) goto L_0119;\nL_00D6:\n\tv298[4] = v396;\n\tv142 = System.String::Format(\"Garage_{0}_{1}_{2}x{3}_g{4}\", v298);\n\tUnityEngine.Object::set_name(v67, v142);\n\tv415 = UnityEngine.GameObject::GetComponent(v67);\n\tgoto L_00F2;\nL_00F2:\n\tv421 = UnityEngine.Object::op_Inequality(v415, 0);\n\tv423 = ~v421;\n\tv424 = ~v423;\n\tif (v424) goto L_0102;\n\tgoto L_0108;\nL_0102:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::SetCounter(v415, v237.counter);\nL_0108:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::HideUnderVisuals(this, v295, entity, v111);\n\treturn;\nL_0119:\n\tv286 = new System.ArrayTypeMismatchException();\n\tthrow v286;\nL_002C:\n\tv58 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n")]
		private void SetVisual(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::SetVisual");
		}

		[Token(Token = "0x6000978")]
		[Address(RVA = "0x3E93F9C", Offset = "0x3E93F9C", Length = "0x718")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\nL_0043:\n\tv72 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv284 = ~v72;\n\tif (v284) goto L_FFFFFFFF;\n\tv400 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv404 = ~v400;\n\tif (v404) goto L_FFFFFFFF;\n\tv401 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv405 = ~v401;\n\tif (v405) goto L_FFFFFFFF;\n\tv640 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv241 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv270 = this._config;\n\tv196 = entity >> 0x20;\n\tv646 = _game.CoreSystem.New.TopGridSystem.Shared.Cover.CoverPrefabResolver::GetPrefab(v270.entries, entity, v196, &v190 @ stack_-81_v7 (System.Boolean));\n\tgoto L_0082;\nL_0082:\n\tv654 = UnityEngine.Object::op_Equality(v646, 0);\n\tv656 = ~v654;\n\tif (v656) goto L_00C4;\n\tv384 = entity;\n\tv410 = 0xB7D5000 + 0x538;\n\tv669 = \"il2cpp_vm_object_box\"(*([v410 @ X20_v6 (System.Int32)+48]), &v384 @ stack_-98_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv382 = v196;\n\tv676 = \"il2cpp_vm_object_box\"(*([v410 @ X20_v6 (System.Int32)+48]), &v382 @ stack_-88_v7 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv399 = System.String::Format(\"[GarageVisualHandler] No prefab found for size {0}x{1}.\", v669, v676);\n\tgoto L_00A3;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_00C4:\n\tv206 = v241 >> 0x20;\n\tv164 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v241);\n\tv686 = entity + v241;\n\tv228 = v686 - 1;\n\tv272 = v196 + v206;\n\tv216 = v272 - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v183 @ stack_-98_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v228, v216);\n\tv697 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v183);\n\tv700 = v164 + v697;\n\tv701 = v164.y + v697.y;\n\tv702 = v164.z + v697.z;\n\tv151 = v700 * 0.5f;\n\tv148 = v701 * 0.5f;\n\tv145 = v702 * 0.5f;\n\tgoto L_0103;\n\tv730 = v244 == 0;\n\tif (v730) goto L_0123;\n\tv465 = 0x21C11D0(v244, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv471 = v465 == 0;\n\tif (v471) goto L_023C;\nL_0123:\n\tv727[0] = v244;\n\tv129 = v206;\n\tv740 = \"il2cpp_vm_object_box\"(*([v199 @ X24_v10 (System.Int32)+48]), &v129 @ stack_-9C_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv741 = v740 == 0;\n\tif (v741) goto L_013D;\n\tv466 = 0x21C11D0(v740, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv472 = v466 == 0;\n\tif (v472) goto L_023C;\nL_013D:\n\tv727[1] = v740;\n\tv114 = entity;\n\tv751 = \"il2cpp_vm_object_box\"(*([v199 @ X24_v10 (System.Int32)+48]), &v114 @ stack_-A0_v5 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv752 = v751 == 0;\n\tif (v752) goto L_015C;\n\tv467 = 0x21C11D0(v751, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv473 = v467 == 0;\n\tif (v473) goto L_023C;\nL_015C:\n\tv727[2] = v751;\n\tv96 = v196;\n\tv763 = \"il2cpp_vm_object_box\"(*([v199 @ X24_v10 (System.Int32)+48]), &v96 @ stack_-A4_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv764 = v763 == 0;\n\tif (v764) goto L_0175;\n\tv468 = 0x21C11D0(v763, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv474 = v468 == 0;\n\tif (v474) goto L_023C;\nL_0175:\n\tv727[3] = v763;\n\tv93 = v640;\n\tv774 = \"il2cpp_vm_object_box\"(*([v199 @ X24_v10 (System.Int32)+48]), &v93 @ stack_-A8_v5 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data.GarageComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv775 = v774 == 0;\n\tif (v775) goto L_0194;\n\tv469 = 0x21C11D0(v774, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv475 = v469 == 0;\n\tif (v475) goto L_023C;\nL_0194:\n\tv727[4] = v774;\n\tv245 = System.String::Format(\"Garage_{0}_{1}_{2}x{3}_g{4}\", v727);\n\tUnityEngine.Object::set_name(returnVal1, v245);\n\tv250 = UnityEngine.GameObject::get_transform(returnVal1);\n\tgoto L_01B0;\nL_01B0:\n\tgoto L_01CA;\nL_01CA:\n\t// 458 MakeStruct v90 @ AGG3E94534_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 1119092736\n\tUnityEngine.Transform::set_localEulerAngles(v250, v90);\n\tv167 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv247 = UnityEngine.GameObject::get_transform(returnVal1);\n\t// 475 MakeStruct v87 @ AGG3E9456C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v167 @ V0_v10 (System.Single), v167 @ V0_v10 (System.Single), v167 @ V0_v10 (System.Single)\n\tUnityEngine.Transform::set_localScale(v247, v87);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(returnVal1, entity);\n\tv832 = UnityEngine.GameObject::GetComponent(returnVal1);\n\tgoto L_01F0;\nL_01F0:\n\tv248 = UnityEngine.Object::op_Inequality(v832, 0);\n\tv839 = ~v248;\n\tif (v839) goto L_0230;\n\tv832._vfxPool = this._vfxPool;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::SetCounter(v832, v640.counter);\n\tgoto L_0207;\nL_0207:\n\tgoto L_020A;\nL_020A:\n\tv854 = UnityEngine.Object::op_Equality(v832.m_animator, 0);\n\tv856 = v854 == 0;\n\tif (v856) goto L_022A;\n\tgoto L_0230;\nL_022A:\n\tUnityEngine.Animator::Play(v832.m_animator, v832.m_closedIdleAnim);\nL_0230:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::HideUnderVisuals(this, v241, entity, v196);\n\tv870 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler::OnSpawned(this, returnVal1, entity);\n\tgoto L_00B6;\nL_023C:\n\tv483 = new System.ArrayTypeMismatchException();\n\tthrow v483;\nL_00A3:\n\tUnityEngine.Debug::LogWarning(v399);\nL_0103:\n\t// 259 MakeStruct v78 @ AGG3E942F4_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v151 @ V8_v7 (System.Single), v148 @ V9_v7 (System.Single), v145 @ V10_v7 (System.Single)\n\t// 260 MakeStruct v75 @ AGG3E942F4_2_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v718.identity (UnityEngine.Quaternion), v718.identity.y (System.Single), v718.identity.z (System.Single), v718.identity.w (System.Single)\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v646, v78, v75, this._parent);\n\t// 267 NewArr v727 @ X0_v33 (System.Object[]), typeof(System\n// ... truncated")]
		public GameObject Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::Spawn");
			return default;
		}

		[Token(Token = "0x6000979")]
		[Address(RVA = "0x3E9591C", Offset = "0x3E9591C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv75 = ~v51;\n\tif (v75) goto L_004E;\n\tv88 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv92 = ~v88;\n\tif (v92) goto L_004E;\n\tv129 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv130 = v129 == 0;\n\tif (v130) goto L_FFFFFFFF;\n\tv134 = UnityEngine.Component::GetComponent(v129);\nL_FFFFFFFF:\n\tv70 = v134;\n\tgoto L_0043;\nL_0043:\n\tv87 = UnityEngine.Object::op_Equality(v70, 0);\n\tv91 = v87 == 0;\n\tif (v91) goto L_0067;\nL_004E:\n\treturn;\nL_FFFFFFFF:\n\tv70 = 0;\n\tgoto L_0043;\nL_0067:\n\tv61 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::SetCounter(v70, v61.counter);\n\treturn;\n")]
		public void RefreshCounter(Entity entity)
		{
			if (_em.IsValid(entity) && _em.HasComponent<GarageComponent>(entity))
			{
				EntityMono monoBinding = entity.GetMonoBinding();
				GarageMono garageMono;
				if ((object)monoBinding != null)
				{
					GarageMono component = monoBinding.GetComponent<GarageMono>();
					garageMono = component;
				}
				else
				{
					garageMono = null;
				}
				if (!(garageMono == null))
				{
					garageMono.SetCounter(_em.GetComponent<GarageComponent>(entity).counter);
				}
			}
		}

		[Token(Token = "0x600097A")]
		[Address(RVA = "0x3E95A78", Offset = "0x3E95A78", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv65 = ~v51;\n\tif (v65) goto L_003F;\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv112 = v68 == 0;\n\tif (v112) goto L_FFFFFFFF;\n\tv116 = UnityEngine.Component::GetComponent(v68);\nL_FFFFFFFF:\n\tv63 = v116;\n\tgoto L_0034;\nL_0034:\n\tv76 = UnityEngine.Object::op_Equality(v63, 0);\n\tv79 = v76 == 0;\n\tif (v79) goto L_005C;\nL_003F:\n\treturn;\nL_FFFFFFFF:\n\tv63 = 0;\n\tgoto L_0034;\nL_005C:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::PlayHitVfx(v63, newHp);\n\treturn;\n")]
		public void PlayHitVfx(Entity entity, int newHp)
		{
			if (_em.IsValid(entity))
			{
				EntityMono monoBinding = entity.GetMonoBinding();
				GarageMono garageMono;
				if ((object)monoBinding != null)
				{
					GarageMono component = monoBinding.GetComponent<GarageMono>();
					garageMono = component;
				}
				else
				{
					garageMono = null;
				}
				if (!(garageMono == null))
				{
					garageMono.PlayHitVfx(newHp);
				}
			}
		}

		[Token(Token = "0x600097B")]
		[Address(RVA = "0x3E95B84", Offset = "0x3E95B84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x600097C")]
		[Address(RVA = "0x3E952B0", Offset = "0x3E952B0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\tv56 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(newData, entity);\n\tv66 = ~v56;\n\tif (v66) goto L_0094;\n\tv122 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(oldData, entity);\n\tv129 = ~v122;\n\tif (v129) goto L_0094;\n\tv123 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(newData, entity);\n\tv130 = ~v123;\n\tif (v130) goto L_0094;\n\tv124 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(oldData, entity);\n\tv131 = ~v124;\n\tif (v131) goto L_0094;\n\tv125 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(newData, entity);\n\tv132 = ~v125;\n\tif (v132) goto L_0094;\n\tv200 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(oldData, entity);\n\tv126 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(newData, entity);\n\tv71 = entity != entity;\n\tif (v71) goto L_0094;\n\tv207 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(oldData, entity);\n\tv127 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(newData, entity);\n\tv72 = v207 != v127;\n\tif (v72) goto L_0094;\n\tv210 = v127 ^ v207;\n\tv179 = v210 >> 0x20;\n\tv164 = v179 == 0;\n\tv154 = ~v164;\n\treturn v154;\nL_0094:\n\treturn 1;\n")]
		private static bool FootprintChanged(EntityManager oldData, EntityManager newData, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::FootprintChanged");
			return default;
		}

		[Token(Token = "0x600097D")]
		[Address(RVA = "0x3E95B88", Offset = "0x3E95B88", Length = "0x7FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004D;\n\tv87 = coords->klass;\n\tv475 = coords->klass->interface_offsets_count;\n\tv89 = *([v87 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v89) goto L_007D;\n\tv302 = *([v87 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv302 = v302 + 0x10;\n\tv372 = v475 - 1;\n\tv362 = v475 != 1;\n\tv475 = v372;\n\tif (v362) goto L_0064;\nL_007D:\n\tv318 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(coords);\n\tv478 = v318 == 0;\n\tv323 = ~v478;\n\tif (v323) goto L_0090;\n\tgoto L_0303;\nL_0083:\n\tv238 = *([v302 @ X10_v30]) << 4;\n\tv483 = v87 + v238;\n\tv484 = v483 + 0x138;\n\t*([v484 @ X0_v107])(v319, coords, *([v484 @ X0_v107+8]), methodInfo, v191, v50, v51, v52, v53, 0, v948, v944, v57, v58, v59, v60, v61);\n\tv324 = v319 == 0;\n\tif (v324) goto L_0303;\nL_0090:\n\tgoto L_00B6;\n\tv71.snapshots = v596;\n\tgoto L_00DB;\nL_00EA:\n\tv706 = v68;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>::Add(v939, &v706 @ stack_-F0_v7 (UnityEngine.Transform));\n\tv952 = Il2CppMethodInfo;\n\tv949 = UnityEngine.Transform::get_position(v1296);\n\tv1229 = v943 + v949;\n\tv942 = v942 + v949.y;\n\tv941 = v941 + v949.z;\n\tv943 = v1229;\n\tv1030 = *([v984 @ X8_v40 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv1030 = v1030 + 0x10;\n\tv1016 = v1031 - 1;\n\tv996 = v1031 != 1;\n\tv1031 = v1016;\n\tif (v996) goto L_0106;\nL_011F:\n\tv1044 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(coords);\n\tv1055 = v234 < v1044;\n\tif (v1055) goto L_0142;\n\tgoto L_01F3;\nL_012E:\n\tv1061 = *([v1030 @ X10_v20]) << 4;\n\tv1062 = v984 + v1061;\n\tv1063 = v1062 + 0x138;\n\t*([v1063 @ X0_v94])(v1067, coords, *([v1063 @ X0_v94+8]), v952, 0, v50, v51, v52, v53, v949, v949.y, v949.z, v57, v58, v59, v60, v61);\n\tv1077 = v234 >= v1067;\n\tif (v1077) goto L_01F3;\nL_0142:\n\tv1095 = coords->klass;\n\tv1128 = coords->klass->interface_offsets_count;\n\tv1097 = *([v1095 @ X8_v56 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v1097) goto L_0167;\n\tv791 = *([v1095 @ X8_v56 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv791 = v791 + 0x10;\n\tv1114 = v1128 - 1;\n\tv1104 = v1128 != 1;\n\tv1128 = v1114;\n\tif (v1104) goto L_014D;\nL_0167:\n\tv1142 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(coords, v234);\n\tv1131 = this._gridHandler == 0;\n\tv833 = ~v1131;\n\tif (v833) goto L_017C;\n\tv461 = coords;\n\tgoto L_026F;\nL_016D:\n\tv731 = *([v791 @ X10_v15]) << 4;\n\tv1137 = v1095 + v731;\n\tv1138 = v1137 + 0x138;\n\t*([v1138 @ X0_v87])(v1142, coords, v234, *([v1138 @ X0_v87+8]), 0, v50, v51, v52, v53, v949, v949.y, v949.z, v57, v58, v59, v60, v61);\nL_017C:\n\tv1146 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v1142);\n\tv1167 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v1146);\n\tv1192 = ~v1167;\n\tv952 = 0;\n\tif (v1192) goto L_00F9;\n\tv1225 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v1146);\n\tgoto L_0191;\nL_0191:\n\tv1253 = UnityEngine.Object::op_Equality(v1225, 0);\n\tv1276 = v1253 == 0;\n\tv1256 = ~v1276;\n\tv952 = 0;\n\tif (v1256) goto L_00F9;\n\tv952 = 0;\n\tgoto L_01A4;\nL_01A4:\n\tv1296 = UnityEngine.Component::get_transform(v1225);\n\tv939 = v71.snapshots;\n\tv227.m_value = 0;\n\t*([v227 @ X24_v7 (System.Int32)+10]) = 0;\n\tv1314 = UnityEngine.Transform::get_parent(v1296);\n\tv1322 = UnityEngine.Transform::get_position(v1296);\n\tv717 = UnityEngine.Transform::get_localScale(v1296);\n\tgoto L_00EA;\nL_01F3:\n\tv333 = v71.snapshots;\n\tv187 = 0xB296000 + 0x490;\n\tv325 = v333.Count == 0;\n\tif (v325) goto L_0303;\n\tv1135 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v1135, \"GarageUnderRevealPivot\");\n\tv71.pivotGo = v1135;\n\tv824 = UnityEngine.GameObject::get_transform(v71.pivotGo);\n\tv693 = v943 / v333.Count;\n\tv691 = v942 / v333.Count;\n\tv689 = v941 / v333.Count;\n\tUnityEngine.Transform::SetParent(v824, this._parent, 0);\n\t// 545 MakeStruct v644 @ AGG3E96160_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v693 @ V8_v13 (System.Single), v691 @ V9_v7 (System.Single), v689 @ V10_v7 (System.Single)\n\tUnityEngine.Transform::set_position(v824, v644);\n\tgoto L_0238;\n\tv728 = 0;\n\tv826 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>::get_Item(v894, v728);\n\tUnityEngine.Transform::SetParent(v826.transform, v824, 1);\n\tv827 = UnityEngine.Component::get_gameObject(v826.transform);\n\tUnityEngine.GameObject::SetActive(v827, 1);\n\tv728 = v728 + 1;\n\tv894 = v71.snapshots;\n\tv1331 = v71.snapshots == 0;\n\tv832 = ~v1331;\n\tv193 = v71;\n\tv461 = v824;\n\tif (v832) goto L_024A;\nL_026F:\n\tv869 = new System.NullReferenceException();\nL_0275:\n\tgoto L_027B;\n\tv987 = *([v187 @ X26_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>)]);\n\tv798 = *([v987 @ X9_v7 (Il2CppClass<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>>)+B8]);\n\tv719 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>>)+C]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+24]);\n\tv712 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>>)+10]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+24]);\n\tv697 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>>)+14]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+24]);\n\t// 649 MakeStruct v111 @ AGG3E96270_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v719 @ V0_v5, v712 @ V1_v4, v697 @ V2_v4\n\tUnityEngine.Transform::set_localScale(v461, v111);\n\tv863 = this._config;\n\tv154 = v863.parentScaleTween;\n\tv1058 = PrimeTween.Tween::Scale(v461, &v154 @ stack_-130_v3 (PrimeTween.TweenSettings`1<System.Single>));\n\t// 674 NewArr v829 @ X0_v17 (System.Single[]), typeof(System.Single[]), 1\n\tv457 = this._config;\n\tv202 = *([v457 @ X8_v20 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+48]) + *([v457 @ X8_v20 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageConfig)+30]);\n\tv829[0] = v202;\n\tv1161 = v829.Length < 2;\n\tif (v1161) goto L_02E1;\n\tv1168 = v829.Length & 0x7FFFFFFF;\n\tv1207 = v1168 - 1;\n\tv1206 = v829 + 0x24;\n\tv1173 = v202;\n\tv1173 = *([v1206 @ X9_v12]);\n\tgoto L_02DA;\nL_02E1:\n\tv1191 = new System.Action`1<UnityEngine.GameObject>();\n\tSystem.Action`1<UnityEngine.GameObject>::.ctor(v1191, v193, Il2CppMethodInfo);\n\tv317 = PrimeTween.Tween::Delay(v193.pivotGo, v202, v1191, 0, 1);\nL_0303:\n\treturn;\nL_004D:\n\tv68 = 0;\n\tv71 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v71);\n\tv80 = coords == 0;\n\tif (v80) goto L_0303;\nL_0064:\n\tv278 = *([v302 @ X10_v30-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v278) goto L_0083;\nL_00B6:\n\tv591 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(coords);\n\tv596 = ne\n// ... truncated")]
		public unsafe void PlayUnderReveal(IReadOnlyList<GridCoord> coords)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::PlayUnderReveal");
		}

		[Token(Token = "0x600097E")]
		[Address(RVA = "0x3E9638C", Offset = "0x3E9638C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv175 = 0xB292000 + 0x5A0;\n\tv81 = snapshots.Count < 1;\n\tif (v81) goto L_008B;\n\tv183 = 0;\n\tgoto L_005E;\nL_003E:\n\tUnityEngine.Transform::SetParent(v281.transform, v281.originalParent, 0);\n\t// 68 MakeStruct v342 @ AGG3E96444_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v281.originalWorldPos (UnityEngine.Vector3), v281.originalWorldPos.y (System.Single), v281.originalWorldPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v281.transform, v342);\n\t// 75 MakeStruct v341 @ AGG3E9645C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v281.originalLocalScale (UnityEngine.Vector3), v281.originalLocalScale.y (System.Single), v281.originalLocalScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v281.transform, v341);\nL_004D:\n\tv183 = v183 + 1;\n\tv225 = v183 >= snapshots.Count;\n\tif (v225) goto L_008B;\nL_005E:\n\tv281 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler+UnderRevealSnapshot>::get_Item(snapshots, v183);\n\tgoto L_0078;\nL_0078:\n\tv298 = UnityEngine.Object::op_Equality(v281.transform, 0);\n\tv310 = v298 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_004D;\n\tgoto L_0087;\nL_0087:\n\tv355 = v281.transform == 0;\n\tv179 = ~v355;\n\tif (v179) goto L_003E;\n\tthrow System.NullReferenceException;\nL_008B:\n\tv251 = *([v175 @ X24_v3 (System.Int32)]);\n\tv253 = *([v251 @ X0_v3+E4]) == 0;\n\tif (v253) goto L_009B;\n\tv285 = UnityEngine.Object::op_Inequality(pivotGo, 0);\n\tv289 = ~v285;\n\tv290 = ~v289;\n\tif (v290) goto L_00A2;\n\tgoto L_00B8;\nL_009B:\n\tv294 = UnityEngine.Object::op_Inequality(pivotGo, 0);\n\tv304 = ~v294;\n\tif (v304) goto L_00B8;\nL_00A2:\n\tgoto L_00A6;\nL_00A6:\n\tUnityEngine.Object::Destroy(pivotGo);\nL_00B8:\n\treturn;\n")]
		private static void RestoreFromUnderReveal(List<UnderRevealSnapshot> snapshots, GameObject pivotGo)
		{
			//IL_01d7: Expected O, but got I4
			int num = 187244544 + 1440;
			if (snapshots.Count >= 1)
			{
				int num2 = 0;
				Vector3 position = default(Vector3);
				Vector3 localScale = default(Vector3);
				do
				{
					UnderRevealSnapshot underRevealSnapshot = snapshots[num2];
					if (!(underRevealSnapshot.transform == null))
					{
						if ((object)underRevealSnapshot.transform == null)
						{
							throw new NullReferenceException();
						}
						underRevealSnapshot.transform.SetParent(underRevealSnapshot.originalParent, worldPositionStays: false);
						position.x = underRevealSnapshot.originalWorldPos.x;
						position.y = underRevealSnapshot.originalWorldPos.y;
						position.z = underRevealSnapshot.originalWorldPos.z;
						underRevealSnapshot.transform.position = position;
						localScale.x = underRevealSnapshot.originalLocalScale.x;
						localScale.y = underRevealSnapshot.originalLocalScale.y;
						localScale.z = underRevealSnapshot.originalLocalScale.z;
						underRevealSnapshot.transform.localScale = localScale;
					}
					num2++;
				}
				while (num2 < snapshots.Count);
			}
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X0_v3+E4]");
			if ((nint)0 != 0)
			{
				if (!(pivotGo != null))
				{
					return;
				}
			}
			else if (!(pivotGo != null))
			{
				return;
			}
			UnityEngine.Object.Destroy(pivotGo);
		}

		[Token(Token = "0x600097F")]
		[Address(RVA = "0x3E95794", Offset = "0x3E95794", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv81 = sizeY < 1;\n\tif (v81) goto L_00A3;\nL_FFFFFFFF:\n\tv108 = 0;\n\tgoto L_FFFFFFFF;\nL_003E:\n\tv108 = v108 + 1;\n\tv125 = v108 == sizeX;\n\tif (v125) goto L_00A3;\nL_FFFFFFFF:\n\tv101 = anchor.y;\nL_FFFFFFFF:\n\tv145 = sizeY;\n\tgoto L_005C;\nL_004E:\n\tUnityEngine.GameObject::SetActive(v219, 0);\nL_004F:\n\tv101 = v101 + 1;\n\tv196 = v145 == 1;\n\tv145 = v145 - 1;\n\tif (v196) goto L_003E;\nL_005C:\n\tv205 = v108 + anchor;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v96 @ stack_-70_v5 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v205, v101);\n\tv213 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v96);\n\tv229 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v213);\n\tv230 = ~v229;\n\tif (v230) goto L_004F;\n\tv233 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v213);\n\tgoto L_007E;\nL_007E:\n\tv237 = UnityEngine.Object::op_Equality(v233, 0);\n\tv251 = v237 == 0;\n\tv239 = ~v251;\n\tif (v239) goto L_004F;\n\tgoto L_0091;\nL_0091:\n\tv219 = UnityEngine.Component::get_gameObject(v233);\n\tv257 = v219 == 0;\n\tv222 = ~v257;\n\tif (v222) goto L_004E;\n\tthrow System.NullReferenceException;\nL_00A3:\n\treturn;\nL_002A:\n\tv69 = sizeX < 1;\n\tif (v69) goto L_00A3;\n")]
		private void HideUnderVisuals(GridCoord anchor, int sizeX, int sizeY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::HideUnderVisuals");
		}

		[Token(Token = "0x6000980")]
		[Address(RVA = "0x3E94A5C", Offset = "0x3E94A5C", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\nL_0031:\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(data, garageEntity);\n\tv159 = ~v68;\n\tif (v159) goto L_0074;\n\tv168 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(data, garageEntity);\n\tv219 = ~v168;\n\tif (v219) goto L_0074;\n\tv277 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(data, garageEntity);\n\tv216 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(data, garageEntity);\n\tv100 = garageEntity >> 0x20;\n\tv94 = garageEntity < 1;\n\tif (v94) goto L_FFFFFFFF;\n\tv292 = v100 - 1;\n\tv201 = v292 < 0;\n\tv295 = v100 ^ 1;\n\tv296 = v100 ^ v292;\n\tv297 = v295 & v296;\n\tv186 = v297 < 0;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv186 = 0;\nL_FFFFFFFF:\n\tv201 = 1;\nL_0074:\n\treturn;\nL_0077:\n\tv304 = v216 >> 0x20;\nL_FFFFFFFF:\n\tv86 = 0;\n\tgoto L_FFFFFFFF;\nL_007C:\n\tv86 = v86 + 1;\n\tv199 = v86 == garageEntity;\n\tif (v199) goto L_0074;\nL_FFFFFFFF:\n\tv82 = v100;\nL_FFFFFFFF:\n\tv88 = v304;\n\tgoto L_009B;\nL_008D:\n\tUnityEngine.GameObject::SetActive(v135, 1);\nL_008E:\n\tv88 = v88 + 1;\n\tv335 = v82 == 1;\n\tv82 = v82 - 1;\n\tif (v335) goto L_007C;\nL_009B:\n\tv127 = v86 + v216;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v77 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v127, v88);\n\tv344 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v77);\n\tv347 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v344);\n\tv348 = ~v347;\n\tif (v348) goto L_008E;\n\tv351 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v344);\n\tgoto L_00BD;\nL_00BD:\n\tv358 = UnityEngine.Object::op_Equality(v351, 0);\n\tv369 = v358 == 0;\n\tv360 = ~v369;\n\tif (v360) goto L_008E;\n\tgoto L_00D0;\nL_00D0:\n\tv135 = UnityEngine.Component::get_gameObject(v351);\n\tv375 = v135 == 0;\n\tv140 = ~v375;\n\tif (v140) goto L_008D;\n\tthrow System.NullReferenceException;\nL_0065:\n\tv97 = v201 == v186;\n\tif (v97) goto L_0077;\n")]
		private void RestoreUnderVisualsFromData(EntityManager data, Entity garageEntity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageVisualHandler::RestoreUnderVisualsFromData");
		}

		[Token(Token = "0x6000981")]
		[Address(RVA = "0x3E96558", Offset = "0x3E96558", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GarageVisualHandler()
		{
		}
	}
}
