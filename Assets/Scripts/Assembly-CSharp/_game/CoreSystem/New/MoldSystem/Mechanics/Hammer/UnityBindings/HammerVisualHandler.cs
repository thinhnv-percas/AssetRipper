using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.ECS;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Responds;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings
{
	[Token(Token = "0x20002B9")]
	public class HammerVisualHandler : IMoldVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000874")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000875")]
		[FieldOffset(Offset = "0x18")]
		private MoldVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000876")]
		[FieldOffset(Offset = "0x20")]
		private HammerConfig _config;

		[Inject(false)]
		[Token(Token = "0x4000877")]
		[FieldOffset(Offset = "0x28")]
		private MoldVisualStateInitSystem _initSystem;

		[Inject(false)]
		[Token(Token = "0x4000878")]
		[FieldOffset(Offset = "0x30")]
		private MoldVisualCreator _visualCreator;

		[Inject(true)]
		[Token(Token = "0x4000879")]
		[FieldOffset(Offset = "0x38")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x400087A")]
		[FieldOffset(Offset = "0x40")]
		private Transform _parent;

		[Inject(false)]
		[Token(Token = "0x6000C24")]
		[Address(RVA = "0x3ED0FBC", Offset = "0x3ED0FBC", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_0019;\nL_0019:\n\tv58 = UnityEngine.Object::op_Inequality(this._visualCreator, 0);\n\tv70 = ~v58;\n\tv71 = ~v70;\n\tv216 = 0;\n\tif (v71) goto L_003D;\n\tv216 = 0;\n\tv94 = 0;\n\tgoto L_0043;\nL_003D:\n\tv88 = this._visualCreator;\n\tv94 = v88.VisualParent;\n\tv111 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv228 = 0;\n\tgoto L_0063;\nL_005D:\n\tv396 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v111, v228);\n\tv223 = _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::Spawn(this, v396);\n\tv228 = v228 + 1;\n\tv216 = 0;\n\tv272 = *([v231 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv272 = v272 + 0x10;\n\tv258 = v273 - 1;\n\tv238 = v273 != 1;\n\tv273 = v258;\n\tif (v238) goto L_0069;\nL_0085:\n\t;\n\tv286 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v111);\n\tv297 = v228 < v286;\n\tif (v297) goto L_00AC;\n\tgoto L_00D6;\nL_0095:\n\t;\n\tv300 = *([v272 @ X10_v13]) << 4;\n\tv301 = v231 + v300;\n\tv302 = v301 + 0x138;\n\t*([v302 @ X0_v21])(v306, v111, *([v302 @ X0_v21+8]), v216, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv316 = v228 >= v306;\n\tif (v316) goto L_00D6;\nL_00AC:\n\tgoto L_005D;\nL_00D6:\n\treturn;\nL_0043:\n\tthis._parent = v94;\nL_0063:\n\tv231 = *([v111 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv273 = *([v231 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv175 = *([v231 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v175) goto L_0085;\nL_0069:\n\t;\n\tv278 = *([v272 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v278) goto L_0095;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::Construct");
		}

		[Token(Token = "0x6000C25")]
		[Address(RVA = "0x3ED1314", Offset = "0x3ED1314", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv80 = this + 0x40;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this._parent, 0);\n\tv68 = ~v59;\n\tif (v68) goto L_0044;\n\t*([v80 @ X20_v6]) = visualParent;\n\treturn;\nL_0044:\n\treturn;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::InitVisuals");
		}

		[Token(Token = "0x6000C26")]
		[Address(RVA = "0x3ED13CC", Offset = "0x3ED13CC", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv121 = 0;\n\tgoto L_003A;\nL_0035:\n\tv383 = UnityEngine.Component::get_gameObject(v367);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v383);\nL_0038:\n\tv121 = v121 + 1;\n\tv173 = *([v228 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv173 = v173 + 0x10;\n\tv234 = v256 - 1;\n\tv233 = v256 != 1;\n\tv256 = v234;\n\tif (v233) goto L_0045;\nL_005E:\n\tv181 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v59);\n\tv142 = v121 < v181;\n\tif (v142) goto L_0083;\n\tgoto L_00D7;\nL_006D:\n\tv137 = *([v173 @ X10_v14]) << 4;\n\tv278 = v228 + v137;\n\tv279 = v278 + 0x138;\n\t*([v279 @ X0_v31])(v182, v59, *([v279 @ X0_v31+8]), v140, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv143 = v121 >= v182;\n\tif (v143) goto L_00D7;\nL_0083:\n\tgoto L_00AA;\nL_00B6:\n\tv373 = UnityEngine.Object::op_Equality(v367, 0);\n\tv376 = v373 == 0;\n\tv377 = ~v376;\n\tv140 = 0;\n\tif (v377) goto L_0038;\n\tv140 = 0;\n\tgoto L_00C7;\nL_00C7:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v365);\n\tv390 = v367 == 0;\n\tv116 = ~v390;\n\tif (v116) goto L_0035;\n\tthrow System.NullReferenceException;\nL_00D7:\n\treturn;\nL_003A:\n\tv228 = *([v59 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv256 = *([v228 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv184 = *([v228 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v184) goto L_005E;\nL_0045:\n\tv269 = *([v173 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v269) goto L_006D;\nL_00AA:\n\tv365 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v121);\n\tv367 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v365);\n\tgoto L_00B6;\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000C27")]
		[Address(RVA = "0x3ED15CC", Offset = "0x3ED15CC", Length = "0x54C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv254 = *([v64 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv363 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv256 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v256) goto L_0063;\n\tv362 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv362 = v362 + 0x10;\n\tv345 = v363 - 1;\n\tv325 = v363 != 1;\nL_FFFFFFFF:\n\tv363 = v345;\n\tif (v325) goto L_0049;\nL_0063:\n\tv420 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v64);\n\tv383 = v420 == 0;\n\tv384 = ~v383;\nL_FFFFFFFF:\n\tv659 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv405 = 0;\n\tif (v384) goto L_FFFFFFFF;\n\tgoto L_01F8;\nL_006D:\n\tv390 = *([v362 @ X10_v44]) << 4;\n\tv391 = v254 + v390;\n\tv392 = v391 + 0x138;\n\t*([v392 @ X8_v44])(v420, v64, *([v392 @ X8_v44+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv401 = v420 == 0;\nL_FFFFFFFF:\n\tv659 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv405 = 0;\n\tif (v401) goto L_01F8;\nL_FFFFFFFF:\n\tv499 = v420;\n\tgoto L_008B;\nL_0083:\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::Reposition(this, v826);\nL_0085:\n\tv474 = v380 == 0;\nL_FFFFFFFF:\n\tv499 = v380;\n\tif (v474) goto L_01F8;\nL_008B:\n\tgoto L_00B1;\n\tv582 = v380 == 0;\n\tif (v582) goto L_01FC;\n\tgoto L_00E2;\n\tv839 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v826);\n\tv841 = v839 == 0;\n\tif (v841) goto L_00FF;\n\tv848 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v826, &v55 @ stack_-68_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv878 = v848 == 0;\n\tv879 = ~v878;\n\tif (v879) goto L_0083;\n\tv908 = _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::Spawn(this, v826);\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::Reposition(this, v826);\n\tgoto L_0085;\nL_00FF:\n\tv851 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v826, &v536 @ stack_-60_v10 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv881 = v851 == 0;\n\tif (v881) goto L_0085;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v826);\n\tv915 = UnityEngine.Component::get_gameObject(v536);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v915);\n\tgoto L_0085;\nL_0110:\n\tv643 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv656 = *([v643 @ X8_v35]);\n\tv645 = *([v643 @ X8_v35]) == 0;\nL_FFFFFFFF:\n\tv654 = 6;\nL_FFFFFFFF:\n\tv682 = 0;\nL_FFFFFFFF:\n\tv78 = 6;\nL_FFFFFFFF:\n\tv273 = v659;\nL_FFFFFFFF:\n\tv189 = 0;\nL_FFFFFFFF:\n\tv303 = 0;\nL_FFFFFFFF:\n\tv165 = 0;\n\tif (v645) goto L_0141;\nL_011A:\n\tgoto L_0140;\n\tv121 = v78 == 6;\n\tif (v121) goto L_0155;\n\tv815 = v78 == 0;\n\tv231 = ~v815;\n\tif (v231) goto L_01F7;\nL_0155:\n\tv152 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(oldData);\nL_FFFFFFFF:\n\tv164 = 0;\n\tgoto L_0165;\nL_0160:\n\tv1037 = UnityEngine.Component::get_gameObject(v70);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v1037);\nL_FFFFFFFF:\n\tv189 = 0;\nL_0163:\n\tv164 = v164 + 1;\n\tv219 = *([v875 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv219 = v219 + 0x10;\n\tv903 = v927 - 1;\n\tv885 = v927 != 1;\nL_FFFFFFFF:\n\tv927 = v903;\n\tif (v885) goto L_0170;\nL_0189:\n\tv228 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v152);\n\tv191 = v164 < v228;\n\tif (v191) goto L_01AE;\n\tgoto L_01F7;\nL_0198:\n\tv183 = *([v219 @ X10_v16]) << 4;\n\tv942 = v875 + v183;\n\tv943 = v942 + 0x138;\n\t*([v943 @ X0_v39])(v229, v152, *([v943 @ X0_v39+8]), v189, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv192 = v164 >= v229;\n\tif (v192) goto L_01F7;\nL_01AE:\n\tgoto L_01D5;\n\tv1030 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v1027);\n\tv1032 = v1030 == 0;\n\tv1033 = ~v1032;\nL_FFFFFFFF:\n\tv189 = 0;\n\tif (v1033) goto L_0163;\n\tv1035 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v1027, &v70 @ stack_-70_v5 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv1038 = ~v1035;\nL_FFFFFFFF:\n\tv189 = 0;\n\tif (v1038) goto L_0163;\n\tv1039 = v70 == 0;\n\tv155 = ~v1039;\n\tif (v155) goto L_0160;\n\tthrow System.NullReferenceException;\nL_01F7:\n\treturn;\nL_01F8:\n\tthrow System.NullReferenceException;\nL_01FA:\n\tthrow System.NullReferenceException;\nL_01FC:\n\tthrow System.NullReferenceException;\nL_0218:\n\tv281 = v303 != 1;\n\tif (v281) goto L_0227;\n\tv709 = 0x8BF5BC4(v629, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv682 = *([v709 @ X0_v15]);\n\tv677 = 0x8BF5BF4(v709, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv656 = *([v273 @ stack_-78_v3]);\n\tv817 = *([v273 @ stack_-78_v3]) == 0;\n\tv679 = ~v817;\nL_FFFFFFFF:\n\tv654 = 0;\nL_FFFFFFFF:\n\tv659 = v273;\nL_FFFFFFFF:\n\tv405 = *([v709 @ X0_v15]);\n\tif (v679) goto L_011A;\nL_FFFFFFFF:\n\tv78 = 0;\nL_FFFFFFFF:\n\tv405 = *([v709 @ X0_v15]);\nL_FFFFFFFF:\n\tv165 = *([v709 @ X0_v15]);\n\tgoto L_0141;\nL_0227:\n\tv711 = 0x3175484(&v405 @ stack_-80_v9 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv772 = 0x8BF0368(v629, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv306 = 0xA1B8(v772, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0031:\n\tv55 = 0;\nL_0049:\n\tv368 = *([v362 @ X10_v44-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v368) goto L_006D;\nL_00B1:\n\tv638 = System.Collections.IEnumerator::MoveNext(v499);\n\tv640 = v638 == 0;\n\tif (v640) goto L_0110;\nL_00E2:\n\tv826 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v380);\n\tv581 = this._em == 0;\n\tif (v581) goto L_01FA;\nL_0141:\n\tv708 = v165 == 0;\n\tv627 = ~v708;\n\tif (v627) goto L_0201;\nL_0140:\n\tSystem.IDisposable::Dispose(v656);\nL_FFFFFFFF:\n\tv78 = v654;\nL_FFFFFFFF:\n\tv273 = v659;\nL_FFFFFFFF:\n\tv189 = 0;\nL_FFFFFFFF:\n\tv303 = 0;\nL_FFFFFFFF:\n\tv165 = v682;\nL_0165:\n\tv875 = *([v152 @ X0_v19 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv927 = *([v875 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv232 = *([v875 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v232) goto L_0189;\nL_0170:\n\tv932 = *([v219 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v932) goto L_0198;\nL_01D5:\n\tv1027 = System.Collections.Generic.IReadO\n// ... truncated")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::SyncWithData");
		}

		[Token(Token = "0x6000C28")]
		[Address(RVA = "0x3ED11CC", Offset = "0x3ED11CC", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv77 = ~v51;\n\tif (v77) goto L_0062;\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv82 = ~v63;\n\tif (v82) goto L_0062;\n\tv70 = this._config;\n\tv120 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v70.hammerMono, this._parent);\n\tv54 = entity;\n\tv122 = 0xB7D5000 + 0x538;\n\tv125 = \"il2cpp_vm_object_box\"(*([v122 @ X8_v11 (System.Int32)+48]), &v54 @ stack_-34_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv64 = System.String::Format(\"Hammer_{0}\", v125);\n\tUnityEngine.Object::set_name(v120, v64);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(v120, entity);\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::Reposition(this, entity);\n\treturn v120;\nL_0062:\n\treturn 0;\n")]
		public GameObject Spawn(Entity entity)
		{
			if (_em.IsValid(entity) && _em.HasComponent<VisualPositionComponent>(entity))
			{
				HammerConfig config = _config;
				GameObject gameObject = VisualHandlerUtility.Instantiate(config.hammerMono, _parent);
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string name = $"Hammer_{arg}";
				gameObject.name = name;
				VisualHandlerUtility.BindEntityMono(gameObject, entity);
				Reposition(entity);
				return gameObject;
			}
			return null;
		}

		[Token(Token = "0x6000C29")]
		[Address(RVA = "0x3ED1B18", Offset = "0x3ED1B18", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv99 = ~v55;\n\tif (v99) goto L_007B;\n\tv102 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_0032;\nL_0032:\n\tv110 = UnityEngine.Object::op_Equality(v102, 0);\n\tv114 = v110 == 0;\n\tif (v114) goto L_0047;\n\tgoto L_007B;\nL_0047:\n\tv112 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv116 = ~v112;\n\tif (v116) goto L_007B;\n\tv80 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv171 = UnityEngine.Component::get_transform(v102);\n\tv61 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v80);\n\tUnityEngine.Transform::set_position(v171, v61);\n\treturn;\nL_007B:\n\treturn;\n")]
		public void Reposition(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::Reposition");
		}

		[Token(Token = "0x6000C2A")]
		[Address(RVA = "0x3ED1C7C", Offset = "0x3ED1C7C", Length = "0x674")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv793 = 0xB292000 + 0x5A0;\n\tgoto L_0049;\nL_0052:\n\tv94 = UnityEngine.Object::op_Inequality(v80, 0);\n\tv100 = ~v94;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv134 = 0;\n\tif (v101) goto L_0072;\nL_FFFFFFFF:\n\tv437 = hammer;\nL_FFFFFFFF:\n\tv441 = v80;\n\tgoto L_0061;\nL_0061:\n\tv149 = UnityEngine.Object::op_Inequality(v134, 0);\n\tv536 = ~v149;\n\tv537 = ~v536;\nL_FFFFFFFF:\n\tv675 = 0;\n\tif (v537) goto L_0088;\n\tgoto L_020F;\nL_0072:\n\tv160 = UnityEngine.Component::get_transform(v80);\nL_FFFFFFFF:\n\tv437 = hammer;\nL_FFFFFFFF:\n\tv441 = v80;\nL_FFFFFFFF:\n\tv134 = v160;\n\tgoto L_0061;\nL_0088:\n\tv694 = UnityEngine.Transform::get_position(v134);\n\tv425 = UnityEngine.Transform::get_localScale(v134);\n\tv476 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\nL_FFFFFFFF:\n\tv386 = 0;\nL_FFFFFFFF:\n\tv783 = v425.z;\nL_FFFFFFFF:\n\tv784 = v425.y;\nL_FFFFFFFF:\n\tv785 = v425;\nL_FFFFFFFF:\n\tv797 = &v297 @ stack_-C8_v4 (System.Int32);\n\tgoto L_00A7;\nL_00A5:\n\tv386 = v386 + 1;\n\tv672 = *([v799 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv672 = v672 + 0x10;\n\tv809 = v831 - 1;\n\tv808 = v831 != 1;\nL_FFFFFFFF:\n\tv831 = v809;\n\tif (v808) goto L_00AD;\nL_00C9:\n\t;\n\tv680 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v476);\n\tv651 = v386 < v680;\n\tif (v651) goto L_00EF;\n\tgoto L_020F;\nL_00D9:\n\t;\n\tv650 = *([v672 @ X10_v16]) << 4;\n\tv853 = v799 + v650;\n\tv854 = v853 + 0x138;\n\t*([v854 @ X0_v83])(v681, v476, *([v854 @ X0_v83+8]), v675, v1026, v1033, v59, v60, v61, v785, v784, v783, v425, v425.y, v425.z, v68, v69);\n\tv652 = v386 >= v681;\n\tif (v652) goto L_020F;\nL_00EF:\n\tv477 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v477);\n\tv477.<>4__this = this;\n\tgoto L_0127;\n\tv932 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v931);\n\tv933 = ~v932;\nL_FFFFFFFF:\n\tv675 = 0;\n\tif (v933) goto L_00A5;\n\tv953 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v931);\n\tv958 = ~v953;\nL_FFFFFFFF:\n\tv675 = Il2CppMethodInfo;\n\tif (v958) goto L_00A5;\n\tv954 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v931);\n\tv297 = v954.groupId;\n\tv523 = v954.launchCounter - 1;\n\tv312 = v954.launchCounter < 1;\nL_FFFFFFFF:\n\tv675 = Il2CppMethodInfo;\n\tif (v312) goto L_00A5;\n\tv977 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v931);\n\tv978 = *([v793 @ X28_v9 (System.Int32)]);\n\tv979 = *([v978 @ X0_v48+E4]) == 0;\n\tif (v979) goto L_0176;\n\tv955 = UnityEngine.Object::op_Equality(v977, 0);\n\tv983 = v955 == 0;\n\tv959 = ~v983;\nL_FFFFFFFF:\n\tv675 = 0;\n\tif (v959) goto L_00A5;\n\tgoto L_0187;\nL_0176:\n\tv956 = UnityEngine.Object::op_Equality(v977, 0);\n\tv986 = v956 == 0;\n\tv960 = ~v986;\nL_FFFFFFFF:\n\tv675 = 0;\n\tif (v960) goto L_00A5;\nL_0187:\n\t*([v797 @ X21_v10+10]) = *([v797 @ X21_v10+10]);\n\t*([v797 @ X21_v10+18]) = *([v797 @ X21_v10+18]);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v931, &v297 @ stack_-C8_v4 (System.Int32));\n\tv481 = UnityEngine.Component::get_transform(v977);\n\tv427 = UnityEngine.Transform::get_position(v481);\n\tv517 = this._config;\n\tv995 = v427.z + v517.vfxOffset.z;\n\tv999 = v427 + v517.vfxOffset;\n\tv477.vfxPos = v999;\n\tv477.vfxPos.z = v995;\n\tv356 = v523 == 0;\n\tv477.isLastHit = v356;\n\tv197 = v523 != 0;\n\tif (v197) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv320 = 0x40;\n\tgoto L_01BD;\nL_FFFFFFFF:\n\tv320 = 0x38;\n\tv477.hitVfx = v507.hitVfx;\n\tv1015 = UnityEngine.Component::get_transform(v977);\n\tv477.areaTransform = v1015;\n\tv937 = v427 + v517.targetOffset;\n\tv938 = v427.y + v517.targetOffset.y;\n\tv939 = v427.z + v517.targetOffset.z;\n\tv1022 = UnityEngine.GameObject::get_transform(v477.copy);\n\tv1026 = new System.Action();\n\tSystem.Action::.ctor(v1026, v477, Il2CppMethodInfo);\n\tv1033 = new System.Action();\n\tSystem.Action::.ctor(v1033, v477, Il2CppMethodInfo);\n\t// 518 MakeStruct v934 @ AGG3ED2214_2_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v937 @ V15_v5 (System.Single), v938 @ V8_v6 (System.Single), v939 @ V14_v6 (System.Single)\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::PlayFlight(this, v1022, v934, v507, v1026, v1033);\nL_FFFFFFFF:\n\tv783 = v939;\nL_FFFFFFFF:\n\tv784 = v938;\nL_FFFFFFFF:\n\tv785 = v937;\nL_FFFFFFFF:\n\tv675 = v507;\nL_FFFFFFFF:\n\tv797 = &v297 @ stack_-C8_v4 (System.Int32);\n\tgoto L_00A5;\nL_020F:\n\tgoto L_0215;\nL_0215:\n\tv702 = UnityEngine.Object::op_Inequality(v441, 0);\n\tv708 = ~v702;\n\tif (v708) goto L_0231;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v437);\n\tv721 = UnityEngine.Component::get_gameObject(v441);\n\tgoto L_022B;\nL_0231:\n\tv718 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v437);\n\tv722 = ~v718;\n\tif (v722) goto L_024F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(this._em, v437);\nL_024F:\n\treturn;\nL_0049:\n\tv80 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(hammer);\n\tgoto L_0052;\nL_00A7:\n\tv799 = *([v476 @ X0_v29 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv831 = *([v799 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv683 = *([v799 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v683) goto L_00C9;\nL_00AD:\n\t;\n\tv844 = *([v672 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v844) goto L_00D9;\nL_0127:\n\tv931 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v476, v386);\nL_01BD:\n\tv507 = *([v517 @ X8_v36 (_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerConfig)+v320 @ X9_v15 (System.Int32)]);\n\tv1006 = _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::SpawnFlyingCopy(v481, v134, v694, v425);\n\tv477.copy = v1006;\n\tv477.capturedArea = v931;\nL_022B:\n\tUnityEngine.Object::Destroy(v721);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void PlayFire(Entity hammer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::PlayFire");
		}

		[Token(Token = "0x6000C2B")]
		[Address(RVA = "0x3ED22F8", Offset = "0x3ED22F8", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv75 = UnityEngine.Component::get_gameObject(source);\n\tv132 = UnityEngine.Transform::get_rotation(source);\n\tv138 = UnityEngine.Transform::get_parent(source);\n\tgoto L_0056;\nL_0056:\n\tv105 = UnityEngine.Object::Instantiate(v75, pos, v132, v138);\n\tv198 = UnityEngine.GameObject::GetComponent(v105);\n\tv200 = UnityEngine.Object::op_Inequality(v198, 0);\n\tv201 = ~v200;\n\tif (v201) goto L_006F;\n\tgoto L_006C;\nL_006C:\n\tUnityEngine.Object::Destroy(v198);\nL_006F:\n\tv106 = UnityEngine.GameObject::get_transform(v105);\n\tUnityEngine.Transform::set_localScale(v106, scale);\n\treturn v105;\n")]
		private GameObject SpawnFlyingCopy(Transform source, Vector3 pos, Vector3 scale)
		{
			GameObject gameObject = source.gameObject;
			Quaternion rotation = source.rotation;
			Transform parent = source.parent;
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, pos, rotation, parent);
			EntityMono component = gameObject2.GetComponent<EntityMono>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			Transform transform = gameObject2.transform;
			transform.localScale = scale;
			return gameObject2;
		}

		[Token(Token = "0x6000C2C")]
		[Address(RVA = "0x3ED2ABC", Offset = "0x3ED2ABC", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv59 = UnityEngine.Object::op_Equality(root, 0);\n\tv67 = v59 == 0;\n\tif (v67) goto L_0037;\n\tgoto L_00A2;\nL_0037:\n\tv85 = UnityEngine.Transform::get_childCount(root);\n\tv87 = v85 == 0;\n\tif (v87) goto L_00A2;\n\tv105 = UnityEngine.Transform::GetChild(root, 0);\n\tv169 = UnityEngine.Transform::get_position(v105);\n\tv177 = UnityEngine.Transform::get_rotation(v105);\n\tUnityEngine.Transform::SetPositionAndRotation(root, v169, v177);\n\tgoto L_0072;\nL_00A2:\n\treturn;\nL_0072:\n\t// 114 MakeStruct v113 @ AGG3ED2C0C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v204.zero (UnityEngine.Vector3), v204.zero.y (System.Single), v204.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v105, v113);\n\tgoto L_0094;\nL_0094:\n\t// 148 MakeStruct v110 @ AGG3ED2C64_1_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v159.identity (UnityEngine.Quaternion), v159.identity.y (System.Single), v159.identity.z (System.Single), v159.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v105, v110);\n\treturn;\n")]
		private void CollapseChildPivot(Transform root)
		{
			if (!(root == null) && root.childCount != 0)
			{
				Transform child = root.GetChild(0);
				Vector3 position = child.position;
				Quaternion rotation = child.rotation;
				root.SetPositionAndRotation(position, rotation);
				Vector3 localPosition = default(Vector3);
				localPosition.x = Vector3.zero.x;
				localPosition.y = Vector3.zero.y;
				localPosition.z = Vector3.zero.z;
				child.localPosition = localPosition;
				Quaternion localRotation = default(Quaternion);
				localRotation.x = Quaternion.identity.x;
				localRotation.y = Quaternion.identity.y;
				localRotation.z = Quaternion.identity.z;
				localRotation.w = Quaternion.identity.w;
				child.localRotation = localRotation;
			}
		}

		[Token(Token = "0x6000C2D")]
		[Address(RVA = "0x3ED2C84", Offset = "0x3ED2C84", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tgoto L_0027;\nL_0027:\n\tv76 = UnityEngine.Object::op_Equality(vfxPrefab, 0);\n\tv85 = v76 == 0;\n\tif (v85) goto L_0059;\n\treturn;\nL_0059:\n\tv123 = this._vfxPool == 0;\n\tif (v123) goto L_0095;\n\tgoto L_0073;\nL_0095:\n\tgoto L_00A8;\nL_00D3:\n\tv215 = UnityEngine.GameObject::get_transform(v410);\n\t// 237 MakeStruct v141 @ AGG3ED2F04_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 1131085824, 0, 1119092736\n\tUnityEngine.Transform::set_eulerAngles(v215, v141);\n\treturn;\nL_0073:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Quaternion_arg @ V3_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v262.identity (UnityEngine.Quaternion), v262.identity.y (System.Single), v262.identity.z (System.Single), v262.identity.w (System.Single)\n\tv410 = _game.CoreSystem.Pooling.IVfxPool::Rent(this._vfxPool, vfxPrefab, Vector3_arg, Quaternion_arg, this._parent);\nL_00A8:\n\tgoto L_00BC;\nL_00BC:\n\t// 188 MakeStruct v352 @ AGG3ED2E78_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v283.identity (UnityEngine.Quaternion), v283.identity.y (System.Single), v283.identity.z (System.Single), v283.identity.w (System.Single)\n\tv410 = UnityEngine.Object::Instantiate(vfxPrefab, Vector3_arg, v352, this._parent);\n\tgoto L_00D3;\n")]
		private void SpawnHitVfx(GameObject vfxPrefab, Vector3 worldPos)
		{
			if (!(vfxPrefab == null))
			{
				GameObject gameObject;
				Vector3 vector = default(Vector3);
				if (_vfxPool != null)
				{
					Quaternion worldRot = default(Quaternion);
					worldRot.x = Quaternion.identity.x;
					worldRot.y = Quaternion.identity.y;
					worldRot.z = Quaternion.identity.z;
					worldRot.w = Quaternion.identity.w;
					gameObject = _vfxPool.Rent(vfxPrefab, vector, worldRot, _parent);
				}
				else
				{
					Quaternion rotation = default(Quaternion);
					rotation.x = Quaternion.identity.x;
					rotation.y = Quaternion.identity.y;
					rotation.z = Quaternion.identity.z;
					rotation.w = Quaternion.identity.w;
					gameObject = UnityEngine.Object.Instantiate(vfxPrefab, vector, rotation, _parent);
				}
				Transform transform = gameObject.transform;
				Vector3 eulerAngles = default(Vector3);
				eulerAngles.x = 235f;
				eulerAngles.y = 0f;
				eulerAngles.z = 90f;
				transform.eulerAngles = eulerAngles;
			}
		}

		[Token(Token = "0x6000C2E")]
		[Address(RVA = "0x3ED2F0C", Offset = "0x3ED2F0C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_002B;\n\tv118 = UnityEngine.Camera::get_main();\n\tgoto L_004A;\nL_004A:\n\tv126 = UnityEngine.Object::op_Equality(v118, 0);\n\tv129 = v126 == 0;\n\tif (v129) goto L_0065;\nL_0057:\n\treturn;\nL_0065:\n\tv89 = UnityEngine.Component::get_transform(v118);\n\tv95 = this._config;\n\tv158 = v95.cameraShakeSettings;\n\tv178 = PrimeTween.Tween::ShakeLocalPosition(v89, &v158 @ stack_-80_v1 (PrimeTween.ShakeSettings));\n\treturn;\nL_0016:\n\tv46 = this._config;\nL_002B:\n\tv108 = v46.cameraShakeSettings.strength.z - v106.zero.z;\n\tv110 = v46.cameraShakeSettings - v106.zero;\n\tv111 = v110 * v110;\n\t// 47 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv112 = v108 * v108;\n\tv78 = v112 + v111;\n\tv73 = v78 < 0x2EDBE6FE;\n\tif (v73) goto L_0057;\n")]
		private void ShakeCameraOnLastHit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::ShakeCameraOnLastHit");
		}

		[Token(Token = "0x6000C2F")]
		[Address(RVA = "0x3ED3078", Offset = "0x3ED3078", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, area);\n\tv74 = ~v51;\n\tif (v74) goto L_0052;\n\tv119 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, area);\n\tv120 = ~v119;\n\tif (v120) goto L_0061;\n\tv123 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, area);\n\tv96 = v123 + 1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, area, v96);\n\treturn;\nL_0052:\n\treturn;\nL_0061:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, area, 1);\n\treturn;\n")]
		private void NotifyLanded(Entity area)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerVisualHandler::NotifyLanded");
		}

		[Token(Token = "0x6000C30")]
		[Address(RVA = "0x3ED248C", Offset = "0x3ED248C", Length = "0x630")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tv78.onHit = onHit;\n\tv78.onComplete = onComplete;\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler::CollapseChildPivot(v101, flyer);\n\tv231 = UnityEngine.Transform::get_position(flyer);\n\tv78.startZ = v231.z;\n\tv78.endZ = targetWorldPos.z;\n\tv96 = UnityEngine.Transform::get_localScale(flyer);\n\tv78.zCurve = anim.zCurve;\n\tv78.zMul = anim.zCurveMultiplier;\n\tv260 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv172 = v260;\n\tv263 = anim.moveSettings;\n\tv271 = PrimeTween.Tween::PositionX(flyer, targetWorldPos, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings));\n\tv278 = PrimeTween.Sequence::Group(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v271);\n\tv263 = anim.moveSettings;\n\tv289 = PrimeTween.Tween::PositionY(flyer, targetWorldPos.y, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings));\n\tv296 = PrimeTween.Sequence::Group(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v289);\n\tv303 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv304 = v303;\n\tv263 = anim.keyScaleUpSettings;\n\tv313 = v96 * anim.keyMaxScale;\n\tv317 = PrimeTween.Tween::Scale(flyer, v313, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings));\n\tv324 = PrimeTween.Sequence::Group(&v304 @ stack_-100_v1 (PrimeTween.Sequence), v317);\n\tv304 = v324;\n\tv263 = anim.keyScaleBackSettings;\n\tv335 = PrimeTween.Tween::Scale(flyer, v96, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings));\n\tv342 = PrimeTween.Sequence::Chain(&v304 @ stack_-100_v1 (PrimeTween.Sequence), v335);\n\tv349 = PrimeTween.Sequence::Group(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v342);\n\tv357 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v357, v78, Il2CppMethodInfo);\n\tv263 = anim.moveZSettings;\n\tv374 = PrimeTween.Tween::Custom(flyer, 0f, 1f, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings), v357);\n\tv381 = PrimeTween.Sequence::Group(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v374);\n\tv384 = UnityEngine.Transform::get_rotation(flyer);\n\tv78.startRot.x = v384;\n\tv78.startRot.y = v384.y;\n\tv78.startRot.z = v384.z;\n\tv78.startRot.w = v384.w;\n\t// 272 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv392 = anim.midRotationEuler * targetWorldPos.y;\n\tv394 = anim.midRotationEuler.z * 0x3C8EFA35;\n\t// 278 MakeStruct v141 @ AGG3ED2828_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v392 @ V0_v23 (System.Single), v396 @ V0.S1, v394 @ V2_v7 (System.Single)\n\tv398 = UnityEngine.Quaternion::Internal_FromEulerRad(v141);\n\tv78.midRot.x = v398;\n\tv78.midRot.y = v398.y;\n\tv78.midRot.z = v398.z;\n\tv78.midRot.w = v398.w;\n\tv403 = anim.landRotationEuler * 0x3C8EFA35;\n\tv405 = anim.landRotationEuler.y * targetWorldPos.y;\n\t// 293 MakeStruct v138 @ AGG3ED284C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v403 @ V0_v26 (System.Single), v405 @ V1_v18 (System.Single), v407 @ V1.S1\n\tv409 = UnityEngine.Quaternion::Internal_FromEulerRad(v138);\n\tv78.landRot.x = v409;\n\tv78.landRot.y = v409.y;\n\tv78.landRot.z = v409.z;\n\tv78.landRot.w = v409.w;\n\tv419 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv429 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v429, v78, Il2CppMethodInfo);\n\tv263 = anim.rotateToMidSettings;\n\tv446 = PrimeTween.Tween::Custom(flyer, 0f, 1f, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings), v429);\n\tv454 = PrimeTween.Sequence::Chain(&v450 @ stack_-E0_v3 (PrimeTween.Sequence), v446);\n\tv460 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v460, v78, Il2CppMethodInfo);\n\tv263 = anim.rotateToTargetSettings;\n\tv477 = PrimeTween.Tween::Custom(flyer, 0f, 1f, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings), v460);\n\tv484 = PrimeTween.Sequence::Chain(&v450 @ stack_-E0_v3 (PrimeTween.Sequence), v477);\n\tv489 = PrimeTween.Sequence::Group(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v450);\n\tv491 = new System.Action();\n\tSystem.Action::.ctor(v491, v78, Il2CppMethodInfo);\n\tv502 = PrimeTween.Sequence::ChainCallback(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v491, 1);\n\tv507 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tgoto L_01AB;\n\tv541 = new System.Action();\n\tSystem.Action::.ctor(v541, v78, Il2CppMethodInfo);\n\tv194 = PrimeTween.Sequence::ChainCallback(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v541, 1);\n\treturn;\nL_0047:\n\tv78 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v78);\nL_01AB:\n\tv263 = anim.keyScaleDownSettings;\n\t// 434 MakeStruct v121 @ AGG3ED2A28_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v522.zero (UnityEngine.Vector3), v522.zero.y (System.Single), v522.zero.z (System.Single)\n\tv527 = PrimeTween.Tween::Scale(flyer, v121, &v263 @ stack_-C0_v1 (PrimeTween.TweenSettings));\n\tv534 = PrimeTween.Sequence::Group(&v132 @ stack_-F0_v3 (PrimeTween.Sequence), v527);\n\tv539 = PrimeTween.Sequence::Chain(&v172 @ stack_-D0_v2 (PrimeTween.Sequence), v132);\n")]
		private void PlayFlight(Transform flyer, Vector3 targetWorldPos, HammerFlightAnim anim, Action onHit, Action onComplete)
		{
			//IL_0360: Expected F4, but got O
			//IL_0444: Expected F4, but got O
			HammerVisualHandler hammerVisualHandler = default(HammerVisualHandler);
			hammerVisualHandler.CollapseChildPivot(flyer);
			float startZ = flyer.position.z;
			float endZ = targetWorldPos.z;
			Vector3 localScale = flyer.localScale;
			AnimationCurve zCurve = anim.zCurve;
			float zMul = anim.zCurveMultiplier;
			Sequence sequence = Sequence.Create();
			Sequence sequence2 = sequence;
			TweenSettings moveSettings = anim.moveSettings;
			Tween tween = Tween.PositionX(flyer, targetWorldPos.x, moveSettings);
			Sequence sequence3 = sequence2.Group(tween);
			moveSettings = anim.moveSettings;
			Tween tween2 = Tween.PositionY(flyer, targetWorldPos.y, moveSettings);
			Sequence sequence4 = sequence2.Group(tween2);
			Sequence sequence5 = Sequence.Create();
			Sequence sequence6 = sequence5;
			moveSettings = anim.keyScaleUpSettings;
			float endValue = localScale.x * anim.keyMaxScale;
			Tween tween3 = Tween.Scale(flyer, endValue, moveSettings);
			Sequence sequence7 = sequence6.Group(tween3);
			sequence6 = sequence7;
			moveSettings = anim.keyScaleBackSettings;
			Tween tween4 = Tween.Scale(flyer, localScale.x, moveSettings);
			Sequence sequence8 = sequence6.Chain(tween4);
			Sequence sequence9 = sequence2.Group(sequence8);
			Action<Transform, float> onValueChange = delegate(Transform t, float v)
			{
				if (!(t == null))
				{
					Vector3 position = t.position;
					float num = endZ - startZ;
					bool flag = v < 1f;
					bool flag2 = v == 1f;
					bool flag3 = v == v;
					bool flag4 = 1f == 1f;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					bool flag7 = flag == flag6;
					bool flag8 = !flag2;
					float num2 = ((!(flag7 && flag8)) ? v : 1f);
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
					Vector3 position2 = default(Vector3);
					position2.x = position.x;
					position2.y = position.y;
					position2.z = z2;
					t.position = position2;
				}
			};
			moveSettings = anim.moveZSettings;
			Tween tween5 = Tween.Custom(flyer, 0f, 1f, moveSettings, onValueChange);
			Sequence sequence10 = sequence2.Group(tween5);
			Quaternion rotation = flyer.rotation;
			Quaternion startRot = default(Quaternion);
			startRot.x = rotation.x;
			startRot.y = rotation.y;
			startRot.z = rotation.z;
			startRot.w = rotation.w;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			float x = anim.midRotationEuler.x * targetWorldPos.y;
			float z = anim.midRotationEuler.z * ((float)Math.PI / 180f);
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
			float x2 = anim.landRotationEuler.x * ((float)Math.PI / 180f);
			float y = anim.landRotationEuler.y * targetWorldPos.y;
			Vector3 vector2 = default(Vector3);
			vector2.x = x2;
			vector2.y = y;
			object obj2 = default(object);
			vector2.z = (float)obj2;
			Quaternion quaternion2 = Quaternion.Euler(vector2 * 57.29578f);
			Quaternion landRot = default(Quaternion);
			landRot.x = quaternion2.x;
			landRot.y = quaternion2.y;
			landRot.z = quaternion2.z;
			landRot.w = quaternion2.w;
			Sequence sequence11 = Sequence.Create();
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
					Quaternion rotation2 = Quaternion.Slerp(a, b, v);
					t.rotation = rotation2;
				}
			};
			moveSettings = anim.rotateToMidSettings;
			Tween tween6 = Tween.Custom(flyer, 0f, 1f, moveSettings, onValueChange2);
			Sequence sequence13 = default(Sequence);
			Sequence sequence12 = sequence13.Chain(tween6);
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
					b.x = landRot.x;
					b.y = landRot.y;
					b.z = landRot.z;
					b.w = landRot.w;
					Quaternion rotation2 = Quaternion.Slerp(a, b, v);
					t.rotation = rotation2;
				}
			};
			moveSettings = anim.rotateToTargetSettings;
			Tween tween7 = Tween.Custom(flyer, 0f, 1f, moveSettings, onValueChange3);
			Sequence sequence14 = sequence13.Chain(tween7);
			Sequence sequence15 = sequence2.Group(sequence13);
			Action callback = delegate
			{
				if (onHit != null)
				{
					onHit();
				}
			};
			Sequence sequence16 = sequence2.ChainCallback(callback);
			Sequence sequence17 = Sequence.Create();
			moveSettings = anim.keyScaleDownSettings;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = Vector3.zero.x;
			endValue2.y = Vector3.zero.y;
			endValue2.z = Vector3.zero.z;
			Tween tween8 = Tween.Scale(flyer, endValue2, moveSettings);
			Sequence sequence19 = default(Sequence);
			Sequence sequence18 = sequence19.Group(tween8);
			Sequence sequence20 = sequence2.Chain(sequence19);
			Action callback2 = delegate
			{
				if (onComplete != null)
				{
					onComplete();
				}
			};
			Sequence sequence21 = sequence2.ChainCallback(callback2);
		}

		[Token(Token = "0x6000C31")]
		[Address(RVA = "0x3ED31A0", Offset = "0x3ED31A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerVisualHandler()
		{
		}
	}
}
