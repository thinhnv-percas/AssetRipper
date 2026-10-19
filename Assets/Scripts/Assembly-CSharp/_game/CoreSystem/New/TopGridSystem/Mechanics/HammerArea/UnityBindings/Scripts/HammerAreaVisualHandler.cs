using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Shared.Cover;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts
{
	[Token(Token = "0x2000206")]
	public class HammerAreaVisualHandler : ITopGridVisualHandler
	{
		[Token(Token = "0x2000207")]
		private struct UnderRevealSnapshot
		{
			[Token(Token = "0x400066E")]
			[FieldOffset(Offset = "0x0")]
			public Transform transform;

			[Token(Token = "0x400066F")]
			[FieldOffset(Offset = "0x8")]
			public Transform originalParent;

			[Token(Token = "0x4000670")]
			[FieldOffset(Offset = "0x10")]
			public Vector3 originalWorldPos;

			[Token(Token = "0x4000671")]
			[FieldOffset(Offset = "0x1C")]
			public Vector3 originalLocalScale;
		}

		[CompilerGenerated]
		[Token(Token = "0x2000208")]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			[Token(Token = "0x4000672")]
			[FieldOffset(Offset = "0x10")]
			public List<UnderRevealSnapshot> snapshots;

			[Token(Token = "0x4000673")]
			[FieldOffset(Offset = "0x18")]
			public GameObject pivotGo;

			[Token(Token = "0x600092A")]
			[Address(RVA = "0x3E8F41C", Offset = "0x3E8F41C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass10_0()
			{
			}

			internal void _003CPlayUnderReveal_003Eb__0(GameObject _)
			{
				RestoreFromUnderReveal(snapshots, pivotGo);
			}
		}

		[Inject(false)]
		[Token(Token = "0x4000669")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400066A")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x400066B")]
		[FieldOffset(Offset = "0x20")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x400066C")]
		[FieldOffset(Offset = "0x28")]
		private HammerAreaConfig _config;

		[Token(Token = "0x400066D")]
		[FieldOffset(Offset = "0x30")]
		private Transform _parent;

		[Token(Token = "0x6000920")]
		[Address(RVA = "0x3E8D950", Offset = "0x3E8D950", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv70 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv171 = 0;\n\tgoto L_004C;\nL_0046:\n\tv598 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv492 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler::Spawn(this, v598);\n\tv285 = 0;\nL_004A:\n\tv171 = v171 + 1;\n\tv339 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv339 = v339 + 0x10;\n\tv306 = v330 - 1;\n\tv304 = v330 != 1;\n\tv330 = v306;\n\tif (v304) goto L_0057;\nL_0070:\n\tv352 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v70);\n\tv363 = v171 < v352;\n\tif (v363) goto L_0093;\n\tgoto L_013B;\nL_007F:\n\tv366 = *([v339 @ X10_v27]) << 4;\n\tv367 = v297 + v366;\n\tv368 = v367 + 0x138;\n\t*([v368 @ X0_v44])(v372, v70, *([v368 @ X0_v44+8]), v285, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv382 = v171 >= v372;\n\tif (v382) goto L_013B;\nL_0093:\n\tv400 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv420 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv402 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v402) goto L_00B8;\n\tv149 = *([v400 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv149 = v149 + 0x10;\n\tv406 = v420 - 1;\n\tv405 = v420 != 1;\n\tv420 = v406;\n\tif (v405) goto L_009E;\nL_00B8:\n\tv450 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv431 = this._em == 0;\n\tv179 = ~v431;\n\tif (v179) goto L_00CB;\n\tgoto L_013C;\nL_00BE:\n\tv83 = *([v149 @ X10_v22]) << 4;\n\tv433 = v400 + v83;\n\tv434 = v433 + 0x138;\n\t*([v434 @ X0_v37])(v450, v70, v171, *([v434 @ X0_v37+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CB:\n\tv456 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v450);\n\tv457 = ~v456;\n\tv285 = Il2CppMethodInfo;\n\tif (v457) goto L_004A;\n\tv459 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv515 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv461 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v461) goto L_00F5;\n\tv151 = *([v459 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv151 = v151 + 0x10;\n\tv501 = v515 - 1;\n\tv500 = v515 != 1;\n\tv515 = v501;\n\tif (v500) goto L_00DB;\nL_00F5:\n\tv533 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v70, v171);\n\tv526 = this._em == 0;\n\tv181 = ~v526;\n\tif (v181) goto L_0108;\n\tgoto L_013C;\nL_00FB:\n\tv85 = *([v151 @ X10_v16]) << 4;\n\tv528 = v459 + v85;\n\tv529 = v528 + 0x138;\n\t*([v529 @ X0_v29])(v533, v70, v171, *([v529 @ X0_v29+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0108:\n\tv493 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v533);\n\tv495 = ~v493;\n\tv285 = Il2CppMethodInfo;\n\tif (v495) goto L_004A;\n\tgoto L_0046;\nL_013B:\n\treturn;\nL_013C:\n\tthrow System.NullReferenceException;\nL_0028:\n\tthis._parent = v48;\nL_004C:\n\tv297 = *([v70 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv330 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv248 = *([v297 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v248) goto L_0070;\nL_0057:\n\tv344 = *([v339 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v344) goto L_007F;\nL_009E:\n\tv125 = *([v149 @ X10_v22-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v125) goto L_00BE;\nL_00DB:\n\tv127 = *([v151 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v127) goto L_00FB;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::InitVisuals");
		}

		[Token(Token = "0x6000921")]
		[Address(RVA = "0x3E8E370", Offset = "0x3E8E370", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv112 = 0;\n\tgoto L_0046;\nL_003A:\n\tv116 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v116);\n\tv432 = UnityEngine.Component::get_gameObject(v415);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v432);\n\tv219 = 0;\nL_0044:\n\tv112 = v112 + 1;\n\tv273 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv273 = v273 + 0x10;\n\tv240 = v264 - 1;\n\tv238 = v264 != 1;\n\tv264 = v240;\n\tif (v238) goto L_0051;\nL_006A:\n\tv286 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v59);\n\tv297 = v112 < v286;\n\tif (v297) goto L_008F;\n\tgoto L_0131;\nL_0079:\n\tv300 = *([v273 @ X10_v27]) << 4;\n\tv301 = v231 + v300;\n\tv302 = v301 + 0x138;\n\t*([v302 @ X0_v43])(v306, v59, *([v302 @ X0_v43+8]), v219, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv316 = v112 >= v306;\n\tif (v316) goto L_0131;\nL_008F:\n\tgoto L_00B6;\nL_00C1:\n\tv422 = UnityEngine.Object::op_Equality(v415, 0);\n\tv425 = v422 == 0;\n\tv426 = ~v425;\n\tv219 = 0;\n\tif (v426) goto L_0044;\n\tgoto L_00D5;\nL_00D5:\n\tgoto L_00FC;\nL_0131:\n\treturn;\nL_0046:\n\tv231 = *([v59 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv264 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv181 = *([v231 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v181) goto L_006A;\nL_0051:\n\tv278 = *([v273 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v278) goto L_0079;\nL_00B6:\n\tv413 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\tv415 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v413);\n\tgoto L_00C1;\nL_00FC:\n\tv519 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v112);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler::RestoreUnderVisualsFromData(this, this._em, v519);\n\tgoto L_003A;\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000922")]
		[Address(RVA = "0x3E8DC34", Offset = "0x3E8DC34", Length = "0x73C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\nL_0043:\n\tv72 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv317 = ~v72;\n\tif (v317) goto L_FFFFFFFF;\n\tv448 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv452 = ~v448;\n\tif (v452) goto L_FFFFFFFF;\n\tv449 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv453 = ~v449;\n\tif (v453) goto L_FFFFFFFF;\n\tv711 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv235 = v711.groupId;\n\tv271 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv302 = this._config;\n\tv717 = _game.CoreSystem.New.TopGridSystem.Shared.Cover.CoverPrefabResolver::GetPrefab(v302.entries, v711.sizeX, v711.sizeY, &v184 @ stack_-81_v7 (System.Boolean));\n\tgoto L_008C;\nL_008C:\n\tv725 = UnityEngine.Object::op_Equality(v717, 0);\n\tv727 = ~v725;\n\tif (v727) goto L_00CF;\n\tv235 = v711.sizeX;\n\tv458 = 0xB7D5000 + 0x538;\n\tv740 = \"il2cpp_vm_object_box\"(*([v458 @ X20_v6 (System.Int32)+48]), &v235 @ stack_-A0_v6 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv422 = v711.sizeY;\n\tv747 = \"il2cpp_vm_object_box\"(*([v458 @ X20_v6 (System.Int32)+48]), &v422 @ stack_-A4_v7 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv447 = System.String::Format(\"[HammerAreaVisualHandler] No prefab found for size {0}x{1}.\", v740, v747);\n\tgoto L_00AD;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_00CF:\n\tv199 = v271 >> 0x20;\n\tv157 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v271);\n\tv757 = v711.sizeX + v271;\n\tv257 = v757 - 1;\n\tv304 = v711.sizeY + v199;\n\tv244 = v304 - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v236 @ stack_-A0_v8 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v257, v244);\n\tv158 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v236);\n\tv305 = this._config;\n\tv765 = v157 + v158;\n\tv766 = v157.y + v158.y;\n\tv142 = v765 * 0.5f;\n\tv139 = v766 * 0.5f;\n\tgoto L_0110;\n\tv793 = v275 == 0;\n\tif (v793) goto L_0130;\n\tv520 = 0x21C11D0(v275, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv526 = v520 == 0;\n\tif (v526) goto L_024D;\nL_0130:\n\tv790[0] = v275;\n\tv131 = v199;\n\tv803 = \"il2cpp_vm_object_box\"(*([v191 @ X26_v11 (System.Int32)+48]), &v131 @ stack_-A8_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv804 = v803 == 0;\n\tif (v804) goto L_0149;\n\tv521 = 0x21C11D0(v803, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv527 = v521 == 0;\n\tif (v527) goto L_024D;\nL_0149:\n\tv790[1] = v803;\n\tv116 = v711.sizeX;\n\tv814 = \"il2cpp_vm_object_box\"(*([v191 @ X26_v11 (System.Int32)+48]), &v116 @ stack_-AC_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv815 = v814 == 0;\n\tif (v815) goto L_0168;\n\tv522 = 0x21C11D0(v814, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv528 = v522 == 0;\n\tif (v528) goto L_024D;\nL_0168:\n\tv790[2] = v814;\n\tv98 = v711.sizeY;\n\tv826 = \"il2cpp_vm_object_box\"(*([v191 @ X26_v11 (System.Int32)+48]), &v98 @ stack_-B0_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv827 = v826 == 0;\n\tif (v827) goto L_0181;\n\tv523 = 0x21C11D0(v826, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv529 = v523 == 0;\n\tif (v529) goto L_024D;\nL_0181:\n\tv790[3] = v826;\n\tv95 = v235;\n\tv838 = \"il2cpp_vm_object_box\"(*([v191 @ X26_v11 (System.Int32)+48]), &v95 @ stack_-B4_v5 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv839 = v838 == 0;\n\tif (v839) goto L_01A1;\n\tv524 = 0x21C11D0(v838, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv530 = v524 == 0;\n\tif (v530) goto L_024D;\nL_01A1:\n\tv790[4] = v838;\n\tv276 = System.String::Format(\"HammerArea_{0}_{1}_{2}x{3}_g{4}\", v790);\n\tUnityEngine.Object::set_name(returnVal1, v276);\n\tv281 = UnityEngine.GameObject::get_transform(returnVal1);\n\tgoto L_01BB;\nL_01BB:\n\tgoto L_01D4;\nL_01D4:\n\t// 468 MakeStruct v92 @ AGG3E8E1D0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 1119092736\n\tUnityEngine.Transform::set_localEulerAngles(v281, v92);\n\tv161 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv278 = UnityEngine.GameObject::get_transform(returnVal1);\n\t// 485 MakeStruct v89 @ AGG3E8E208_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v161 @ V0_v10 (System.Single), v161 @ V0_v10 (System.Single), v161 @ V0_v10 (System.Single)\n\tUnityEngine.Transform::set_localScale(v278, v89);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(returnVal1, entity);\n\tv894 = UnityEngine.GameObject::GetComponent(returnVal1);\n\tgoto L_01FC;\nL_01FC:\n\tv279 = UnityEngine.Object::op_Inequality(v894, 0);\n\tv902 = ~v279;\n\tif (v902) goto L_0241;\n\tv235 = v711.visualCounter;\n\tgoto L_020C;\nL_020C:\n\tgoto L_020F;\nL_020F:\n\tv944 = UnityEngine.Object::op_Equality(v894.m_counterText, 0);\n\tv956 = v944 == 0;\nL_FFFFFFFF:\n\tv905 = v711.maxCounter;\n\tif (v956) goto L_022F;\nL_FFFFFFFF:\n\tv905 = v711.maxCounter;\n\tgoto L_023B;\nL_022F:\n\tv280 = System.Int32::ToString(&v235 @ stack_-A0_v6 (System.Int32));\n\tv975 = TMPro.TMP_Text::set_text(v894.m_counterText, v280);\nL_0241:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler::HideUnderVisuals(this, v271, v711.sizeX, v711.sizeY);\n\tv926 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler::OnSpawned(this, returnVal1, entity);\n\tgoto L_00C0;\nL_024D:\n\tv538 = new System.ArrayTypeMismatchException();\n\tthrow v538;\nL_00AD:\n\tUnityEngine.Debug::LogWarning(v447);\nL_0110:\n\t// 272 MakeStruct v78 @ AGG3E8DF9C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v142 @ V8_v7 (System.Single), v139 @ V9_v7 (System.Single), v305.spawnDepthZ (System.Single)\n\t// 273 MakeStruct v75 @ AGG3E8DF9C_2_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v781.identity (UnityEngine.Quaternion), v781.identity.y (System.Single), v781.identity.z (System.Single), v781.identity.w (System.Single)\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v717, v78, v75, this._parent);\n\t// 280 NewArr v790 @ X0_v33 (System.Object[]), typeof(System.Object[]), 5\n\tv177 = v271;\n\tv191 = 0xB7D5000 + 0x538;\n\tv275 = \"il2cp\n// ... truncated")]
		public GameObject Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::Spawn");
			return default;
		}

		[Token(Token = "0x6000923")]
		[Address(RVA = "0x3E8E9F0", Offset = "0x3E8E9F0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x6000924")]
		[Address(RVA = "0x3E8E9F4", Offset = "0x3E8E9F4", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv118 = ~v55;\n\tif (v118) goto L_0064;\n\tv139 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv143 = ~v139;\n\tif (v143) goto L_0064;\n\tv202 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv205 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv206 = v205 == 0;\n\tif (v206) goto L_0067;\n\tv210 = UnityEngine.Component::GetComponent(v205);\n\tv62 = 0xB292000 + 0x5A0;\n\tv113 = v210;\n\tgoto L_0057;\nL_0057:\n\tv138 = UnityEngine.Object::op_Equality(v113, 0);\n\tv142 = v138 == 0;\n\tif (v142) goto L_0078;\nL_0064:\n\treturn;\nL_0067:\n\tv62 = 0xB292000 + 0x5A0;\n\tv113 = 0;\n\tgoto L_0057;\nL_0078:\n\tv85 = v202.visualCounter;\n\tv238 = *([B78E74E]) & 1;\n\tv239 = v238 == 0;\n\tif (v239) goto L_008E;\n\tv259 = v113.m_counterText;\n\tv241 = *([v62 @ X22_v4 (System.Int32)]);\n\tv243 = *([v241 @ X8_v19+E4]) == 0;\n\tv249 = v113.m_counterText;\n\tif (v243) goto L_009B;\nL_0085:\n\tv257 = UnityEngine.Object::op_Equality(v249, 0);\n\tv268 = v257 == 0;\n\tif (v268) goto L_00A3;\n\tgoto L_00AF;\nL_008E:\n\t*([B78E74E]) = 1;\n\tv259 = v113.m_counterText;\n\tv254 = *([v62 @ X22_v4 (System.Int32)]);\n\tv266 = *([v254 @ X8_v17+E4]) == 0;\n\tv252 = ~v266;\n\tv249 = v113.m_counterText;\n\tif (v252) goto L_0085;\nL_009B:\n\tv272 = UnityEngine.Object::op_Equality(v259, 0);\n\tv280 = v272 == 0;\n\tv277 = ~v280;\n\tif (v277) goto L_00AF;\nL_00A3:\n\tv98 = System.Int32::ToString(&v85 @ stack_-5C_v4 (System.Int32));\n\tv288 = TMPro.TMP_Text::set_text(v113.m_counterText, v98);\nL_00AF:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaMono::SetFill(v113, v202.visualCounter, v202.maxCounter);\n\treturn;\n")]
		public void RefreshCounter(Entity entity)
		{
			//IL_01db: Expected O, but got I4
			//IL_015e: Expected O, but got I4
			if (!_em.IsValid(entity) || !_em.HasComponent<HammerAreaComponent>(entity))
			{
				return;
			}
			HammerAreaComponent component = _em.GetComponent<HammerAreaComponent>(entity);
			EntityMono monoBinding = entity.GetMonoBinding();
			int num;
			HammerAreaMono hammerAreaMono;
			if ((object)monoBinding != null)
			{
				HammerAreaMono component2 = monoBinding.GetComponent<HammerAreaMono>();
				num = 187244544 + 1440;
				hammerAreaMono = component2;
			}
			else
			{
				num = 187244544 + 1440;
				hammerAreaMono = null;
			}
			if (hammerAreaMono == null)
			{
				return;
			}
			int visualCounter = component.visualCounter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E74E]");
			TextMeshPro counterText;
			UnityEngine.Object counterText2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				counterText = hammerAreaMono.m_counterText;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v19+E4]");
				bool flag = (nint)0 == 0;
				counterText2 = hammerAreaMono.m_counterText;
				if (!flag)
				{
					goto IL_0190;
				}
			}
			else
			{
				_ = 1;
				counterText = hammerAreaMono.m_counterText;
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v17+E4]");
				bool flag2 = (nint)0 == 0;
				bool flag3 = !flag2;
				counterText2 = hammerAreaMono.m_counterText;
				if (flag3)
				{
					goto IL_0190;
				}
			}
			if (!(counterText == null))
			{
				goto IL_0253;
			}
			goto IL_027c;
			IL_027c:
			hammerAreaMono.SetFill(component.visualCounter, component.maxCounter);
			return;
			IL_0190:
			if (!(counterText2 == null))
			{
				goto IL_0253;
			}
			goto IL_027c;
			IL_0253:
			string text = visualCounter.ToString();
			hammerAreaMono.m_counterText.text = text;
			goto IL_027c;
		}

		[Token(Token = "0x6000925")]
		[Address(RVA = "0x3E8EC20", Offset = "0x3E8EC20", Length = "0x7FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004D;\n\tv87 = coords->klass;\n\tv475 = coords->klass->interface_offsets_count;\n\tv89 = *([v87 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v89) goto L_007D;\n\tv302 = *([v87 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv302 = v302 + 0x10;\n\tv372 = v475 - 1;\n\tv362 = v475 != 1;\n\tv475 = v372;\n\tif (v362) goto L_0064;\nL_007D:\n\tv318 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(coords);\n\tv478 = v318 == 0;\n\tv323 = ~v478;\n\tif (v323) goto L_0090;\n\tgoto L_0303;\nL_0083:\n\tv238 = *([v302 @ X10_v30]) << 4;\n\tv483 = v87 + v238;\n\tv484 = v483 + 0x138;\n\t*([v484 @ X0_v107])(v319, coords, *([v484 @ X0_v107+8]), methodInfo, v191, v50, v51, v52, v53, 0, v948, v944, v57, v58, v59, v60, v61);\n\tv324 = v319 == 0;\n\tif (v324) goto L_0303;\nL_0090:\n\tgoto L_00B6;\n\tv71.snapshots = v596;\n\tgoto L_00DB;\nL_00EA:\n\tv706 = v68;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>::Add(v939, &v706 @ stack_-F0_v7 (UnityEngine.Transform));\n\tv952 = Il2CppMethodInfo;\n\tv949 = UnityEngine.Transform::get_position(v1296);\n\tv1229 = v943 + v949;\n\tv942 = v942 + v949.y;\n\tv941 = v941 + v949.z;\n\tv943 = v1229;\n\tv1030 = *([v984 @ X8_v40 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv1030 = v1030 + 0x10;\n\tv1016 = v1031 - 1;\n\tv996 = v1031 != 1;\n\tv1031 = v1016;\n\tif (v996) goto L_0106;\nL_011F:\n\tv1044 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(coords);\n\tv1055 = v234 < v1044;\n\tif (v1055) goto L_0142;\n\tgoto L_01F3;\nL_012E:\n\tv1061 = *([v1030 @ X10_v20]) << 4;\n\tv1062 = v984 + v1061;\n\tv1063 = v1062 + 0x138;\n\t*([v1063 @ X0_v94])(v1067, coords, *([v1063 @ X0_v94+8]), v952, 0, v50, v51, v52, v53, v949, v949.y, v949.z, v57, v58, v59, v60, v61);\n\tv1077 = v234 >= v1067;\n\tif (v1077) goto L_01F3;\nL_0142:\n\tv1095 = coords->klass;\n\tv1128 = coords->klass->interface_offsets_count;\n\tv1097 = *([v1095 @ X8_v56 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v1097) goto L_0167;\n\tv791 = *([v1095 @ X8_v56 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv791 = v791 + 0x10;\n\tv1114 = v1128 - 1;\n\tv1104 = v1128 != 1;\n\tv1128 = v1114;\n\tif (v1104) goto L_014D;\nL_0167:\n\tv1142 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(coords, v234);\n\tv1131 = this._gridHandler == 0;\n\tv833 = ~v1131;\n\tif (v833) goto L_017C;\n\tv461 = coords;\n\tgoto L_026F;\nL_016D:\n\tv731 = *([v791 @ X10_v15]) << 4;\n\tv1137 = v1095 + v731;\n\tv1138 = v1137 + 0x138;\n\t*([v1138 @ X0_v87])(v1142, coords, v234, *([v1138 @ X0_v87+8]), 0, v50, v51, v52, v53, v949, v949.y, v949.z, v57, v58, v59, v60, v61);\nL_017C:\n\tv1146 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v1142);\n\tv1167 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v1146);\n\tv1192 = ~v1167;\n\tv952 = 0;\n\tif (v1192) goto L_00F9;\n\tv1225 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v1146);\n\tgoto L_0191;\nL_0191:\n\tv1253 = UnityEngine.Object::op_Equality(v1225, 0);\n\tv1276 = v1253 == 0;\n\tv1256 = ~v1276;\n\tv952 = 0;\n\tif (v1256) goto L_00F9;\n\tv952 = 0;\n\tgoto L_01A4;\nL_01A4:\n\tv1296 = UnityEngine.Component::get_transform(v1225);\n\tv939 = v71.snapshots;\n\tv227.m_value = 0;\n\t*([v227 @ X24_v7 (System.Int32)+10]) = 0;\n\tv1314 = UnityEngine.Transform::get_parent(v1296);\n\tv1322 = UnityEngine.Transform::get_position(v1296);\n\tv717 = UnityEngine.Transform::get_localScale(v1296);\n\tgoto L_00EA;\nL_01F3:\n\tv333 = v71.snapshots;\n\tv187 = 0xB296000 + 0x490;\n\tv325 = v333.Count == 0;\n\tif (v325) goto L_0303;\n\tv1135 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v1135, \"HammerAreaUnderRevealPivot\");\n\tv71.pivotGo = v1135;\n\tv824 = UnityEngine.GameObject::get_transform(v71.pivotGo);\n\tv693 = v943 / v333.Count;\n\tv691 = v942 / v333.Count;\n\tv689 = v941 / v333.Count;\n\tUnityEngine.Transform::SetParent(v824, this._parent, 0);\n\t// 545 MakeStruct v644 @ AGG3E8F1F8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v693 @ V8_v13 (System.Single), v691 @ V9_v7 (System.Single), v689 @ V10_v7 (System.Single)\n\tUnityEngine.Transform::set_position(v824, v644);\n\tgoto L_0238;\n\tv728 = 0;\n\tv826 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>::get_Item(v894, v728);\n\tUnityEngine.Transform::SetParent(v826.transform, v824, 1);\n\tv827 = UnityEngine.Component::get_gameObject(v826.transform);\n\tUnityEngine.GameObject::SetActive(v827, 1);\n\tv728 = v728 + 1;\n\tv894 = v71.snapshots;\n\tv1331 = v71.snapshots == 0;\n\tv832 = ~v1331;\n\tv193 = v71;\n\tv461 = v824;\n\tif (v832) goto L_024A;\nL_026F:\n\tv869 = new System.NullReferenceException();\nL_0275:\n\tgoto L_027B;\n\tv987 = *([v187 @ X26_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>)]);\n\tv798 = *([v987 @ X9_v7 (Il2CppClass<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>>)+B8]);\n\tv719 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>>)+C]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+24]);\n\tv712 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>>)+10]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+24]);\n\tv697 = *([v798 @ X9_v8 (Il2CppStaticFields<System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>>)+14]) * *([v864 @ X8_v16 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+24]);\n\t// 649 MakeStruct v111 @ AGG3E8F308_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v719 @ V0_v5, v712 @ V1_v4, v697 @ V2_v4\n\tUnityEngine.Transform::set_localScale(v461, v111);\n\tv863 = this._config;\n\tv154 = v863.parentScaleTween;\n\tv1058 = PrimeTween.Tween::Scale(v461, &v154 @ stack_-130_v3 (PrimeTween.TweenSettings`1<System.Single>));\n\t// 674 NewArr v829 @ X0_v17 (System.Single[]), typeof(System.Single[]), 1\n\tv457 = this._config;\n\tv202 = *([v457 @ X8_v20 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+48]) + *([v457 @ X8_v20 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaConfig)+30]);\n\tv829[0] = v202;\n\tv1161 = v829.Length < 2;\n\tif (v1161) goto L_02E1;\n\tv1168 = v829.Length & 0x7FFFFFFF;\n\tv1207 = v1168 - 1;\n\tv1206 = v829 + 0x24;\n\tv1173 = v202;\n\tv1173 = *([v1206 @ X9_v12]);\n\tgoto L_02DA;\nL_02E1:\n\tv1191 = new System.Action`1<UnityEngine.GameObject>();\n\tSystem.Action`1<UnityEngine.GameObject>::.ctor(v1191, v193, Il2CppMethodInfo);\n\tv317 = PrimeTween.Tween::Delay(v193.pivotGo, v202, v1191, 0, 1);\nL_0303:\n\treturn;\nL_004D:\n\tv68 = 0;\n\tv71 = new _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v71);\n\tv80 = coords == 0;\n\tif (v80) goto L_0303;\nL_0064:\n\tv278 = *([v302 @ X10_v30-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v278) goto L_0083;\nL_00B6:\n\tv591 = System.Collections\n// ... truncated")]
		public unsafe void PlayUnderReveal(IReadOnlyList<GridCoord> coords)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::PlayUnderReveal");
		}

		[Token(Token = "0x6000926")]
		[Address(RVA = "0x3E8F424", Offset = "0x3E8F424", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv175 = 0xB292000 + 0x5A0;\n\tv81 = snapshots.Count < 1;\n\tif (v81) goto L_008B;\n\tv183 = 0;\n\tgoto L_005E;\nL_003E:\n\tUnityEngine.Transform::SetParent(v281.transform, v281.originalParent, 0);\n\t// 68 MakeStruct v342 @ AGG3E8F4DC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v281.originalWorldPos (UnityEngine.Vector3), v281.originalWorldPos.y (System.Single), v281.originalWorldPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v281.transform, v342);\n\t// 75 MakeStruct v341 @ AGG3E8F4F4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v281.originalLocalScale (UnityEngine.Vector3), v281.originalLocalScale.y (System.Single), v281.originalLocalScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v281.transform, v341);\nL_004D:\n\tv183 = v183 + 1;\n\tv225 = v183 >= snapshots.Count;\n\tif (v225) goto L_008B;\nL_005E:\n\tv281 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler+UnderRevealSnapshot>::get_Item(snapshots, v183);\n\tgoto L_0078;\nL_0078:\n\tv298 = UnityEngine.Object::op_Equality(v281.transform, 0);\n\tv310 = v298 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_004D;\n\tgoto L_0087;\nL_0087:\n\tv355 = v281.transform == 0;\n\tv179 = ~v355;\n\tif (v179) goto L_003E;\n\tthrow System.NullReferenceException;\nL_008B:\n\tv251 = *([v175 @ X24_v3 (System.Int32)]);\n\tv253 = *([v251 @ X0_v3+E4]) == 0;\n\tif (v253) goto L_009B;\n\tv285 = UnityEngine.Object::op_Inequality(pivotGo, 0);\n\tv289 = ~v285;\n\tv290 = ~v289;\n\tif (v290) goto L_00A2;\n\tgoto L_00B8;\nL_009B:\n\tv294 = UnityEngine.Object::op_Inequality(pivotGo, 0);\n\tv304 = ~v294;\n\tif (v304) goto L_00B8;\nL_00A2:\n\tgoto L_00A6;\nL_00A6:\n\tUnityEngine.Object::Destroy(pivotGo);\nL_00B8:\n\treturn;\n")]
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

		[Token(Token = "0x6000927")]
		[Address(RVA = "0x3E8E868", Offset = "0x3E8E868", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv81 = sizeY < 1;\n\tif (v81) goto L_00A3;\nL_FFFFFFFF:\n\tv108 = 0;\n\tgoto L_FFFFFFFF;\nL_003E:\n\tv108 = v108 + 1;\n\tv125 = v108 == sizeX;\n\tif (v125) goto L_00A3;\nL_FFFFFFFF:\n\tv101 = anchor.y;\nL_FFFFFFFF:\n\tv145 = sizeY;\n\tgoto L_005C;\nL_004E:\n\tUnityEngine.GameObject::SetActive(v219, 0);\nL_004F:\n\tv101 = v101 + 1;\n\tv196 = v145 == 1;\n\tv145 = v145 - 1;\n\tif (v196) goto L_003E;\nL_005C:\n\tv205 = v108 + anchor;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v96 @ stack_-70_v5 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v205, v101);\n\tv213 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v96);\n\tv229 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v213);\n\tv230 = ~v229;\n\tif (v230) goto L_004F;\n\tv233 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v213);\n\tgoto L_007E;\nL_007E:\n\tv237 = UnityEngine.Object::op_Equality(v233, 0);\n\tv251 = v237 == 0;\n\tv239 = ~v251;\n\tif (v239) goto L_004F;\n\tgoto L_0091;\nL_0091:\n\tv219 = UnityEngine.Component::get_gameObject(v233);\n\tv257 = v219 == 0;\n\tv222 = ~v257;\n\tif (v222) goto L_004E;\n\tthrow System.NullReferenceException;\nL_00A3:\n\treturn;\nL_002A:\n\tv69 = sizeX < 1;\n\tif (v69) goto L_00A3;\n")]
		private void HideUnderVisuals(GridCoord anchor, int sizeX, int sizeY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::HideUnderVisuals");
		}

		[Token(Token = "0x6000928")]
		[Address(RVA = "0x3E8E638", Offset = "0x3E8E638", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\nL_0031:\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(data, areaEntity);\n\tv177 = ~v68;\n\tif (v177) goto L_00D7;\n\tv241 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(data, areaEntity);\n\tv245 = ~v241;\n\tif (v245) goto L_00D7;\n\tv281 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(data, areaEntity);\n\tv242 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(data, areaEntity);\n\tv190 = v281.sizeX < 1;\n\tif (v190) goto L_00D7;\n\tv91 = v281.sizeY < 1;\n\tif (v91) goto L_00D7;\n\tv87 = v242 >> 0x20;\nL_FFFFFFFF:\n\tv89 = 0;\n\tgoto L_FFFFFFFF;\nL_0072:\n\tv89 = v89 + 1;\n\tv210 = v89 == v281.sizeX;\n\tif (v210) goto L_00D7;\nL_FFFFFFFF:\n\tv83 = v281.sizeY;\nL_FFFFFFFF:\n\tv167 = v87;\n\tgoto L_0090;\nL_0082:\n\tUnityEngine.GameObject::SetActive(v153, 1);\nL_0083:\n\tv167 = v167 + 1;\n\tv319 = v83 == 1;\n\tv83 = v83 - 1;\n\tif (v319) goto L_0072;\nL_0090:\n\tv145 = v89 + v242;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v81 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v145, v167);\n\tv328 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, v81);\n\tv331 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v328);\n\tv332 = ~v331;\n\tif (v332) goto L_0083;\n\tv335 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v328);\n\tgoto L_00B2;\nL_00B2:\n\tv342 = UnityEngine.Object::op_Equality(v335, 0);\n\tv353 = v342 == 0;\n\tv344 = ~v353;\n\tif (v344) goto L_0083;\n\tgoto L_00C5;\nL_00C5:\n\tv153 = UnityEngine.Component::get_gameObject(v335);\n\tv359 = v153 == 0;\n\tv158 = ~v359;\n\tif (v158) goto L_0082;\n\tthrow System.NullReferenceException;\nL_00D7:\n\treturn;\n")]
		private void RestoreUnderVisualsFromData(EntityManager data, Entity areaEntity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaVisualHandler::RestoreUnderVisualsFromData");
		}

		[Token(Token = "0x6000929")]
		[Address(RVA = "0x3E8F5F0", Offset = "0x3E8F5F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerAreaVisualHandler()
		{
		}
	}
}
