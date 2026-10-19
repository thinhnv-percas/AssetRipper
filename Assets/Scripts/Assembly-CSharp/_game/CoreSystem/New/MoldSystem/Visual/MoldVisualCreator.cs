using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.MoldSystem.Visual
{
	[Token(Token = "0x20002AC")]
	public class MoldVisualCreator : MonoBehaviour, IDisposable, IMoldVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000844")]
		[FieldOffset(Offset = "0x20")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000845")]
		[FieldOffset(Offset = "0x28")]
		private MoldConceptConfig _moldConceptConfig;

		[Inject(false)]
		[Token(Token = "0x4000846")]
		[FieldOffset(Offset = "0x30")]
		private MoldConfig _moldConfig;

		[Inject(false)]
		[Token(Token = "0x4000847")]
		[FieldOffset(Offset = "0x38")]
		private MoldEntitySystemCreator _entityCreator;

		[Inject(false)]
		[Token(Token = "0x4000848")]
		[FieldOffset(Offset = "0x40")]
		private MoldVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000849")]
		[FieldOffset(Offset = "0x48")]
		private MoldLinkVisualController _linkVisualController;

		[Inject(true)]
		[Token(Token = "0x400084A")]
		[FieldOffset(Offset = "0x50")]
		private IVfxPool _vfxPool;

		[SerializeField]
		[Token(Token = "0x400084B")]
		[FieldOffset(Offset = "0x58")]
		private Transform m_visualParent;

		[Token(Token = "0x170000F8")]
		public Transform VisualParent
		{
			[Token(Token = "0x6000BE2")]
			[Address(RVA = "0x3ECCF4C", Offset = "0x3ECCF4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VisualParent;\n")]
			get
			{
				return m_visualParent;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000BE3")]
		[Address(RVA = "0x3ECCF54", Offset = "0x3ECCF54", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tgoto L_005B;\n\tgoto L_0090;\n\tgoto L_00C1;\nL_00C7:\n\tv384 = &v57 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv349 = *([v384 @ X8_v24]);\n\tv382 = *([v384 @ X8_v24]) == 0;\n\tv343 = &v57 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv68 = 0;\n\tv353 = 0;\n\tv385 = 0;\n\tv153 = &v57 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv68 = 0;\n\tv77 = v157;\n\tv160 = 0;\n\tv172 = 0;\n\tv147 = 0;\n\tif (v382) goto L_00F6;\nL_00CB:\n\t;\n\tv388 = *([v349 @ X21_v6]);\n\tv540 = *([v388 @ X8_v8+12E]);\n\tv390 = *([v388 @ X8_v8+12E]) == 0;\n\tif (v390) goto L_00EC;\n\tv539 = *([v388 @ X8_v8+B0]) + 8;\n\tv539 = v539 + 0x10;\n\tv464 = v540 - 1;\n\tv444 = v540 != 1;\n\tv540 = v464;\n\tif (v444) goto L_00D2;\nL_00EC:\n\tv565 = 0x220C5E0(v349, *([v157 @ X22_v4 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv160 = 0;\n\tgoto L_00F2;\nL_00EE:\n\t;\n\tv562 = *([v539 @ X10_v9]) << 4;\n\tv563 = v388 + v562;\n\tv565 = v563 + 0x138;\n\tv160 = v353;\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateLinkVisuals(this._linkVisualController);\n\treturn;\nL_0107:\n\tv341 = new System.NullReferenceException();\n\tv160 = 0;\n\tv172 = 0;\n\tgoto L_010A;\nL_010A:\n\t// 266 Interrupt\n\tv153 = &v57 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv68 = 0;\nL_010D:\n\tv180 = new System.OutOfMemoryException();\n\tgoto L_011B;\nL_011B:\n\tv230 = v172 != 1;\n\tif (v230) goto L_0129;\n\tv254 = 0x8BF5BC4(v180, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv385 = *([v254 @ X0_v15]);\n\tv289 = 0x8BF5BF4(v254, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv349 = *([v153 @ stack_-50_v3]);\n\tv334 = *([v153 @ stack_-50_v3]) == 0;\n\tv335 = ~v334;\n\tv343 = v153;\n\tv68 = *([v254 @ X0_v15]);\n\tv353 = v160;\n\tif (v335) goto L_00CB;\n\tv68 = *([v254 @ X0_v15]);\n\tv77 = v77;\n\tv147 = *([v254 @ X0_v15]);\n\tgoto L_00F6;\nL_0129:\n\tv257 = 0x3175484(&v68 @ stack_-58_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv291 = 0x8BF0368(v180, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv336 = 0xA1B8(v291, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n\tthrow System.NullReferenceException;\nL_005B:\n\tv157 = 0xB28F000 + 0x8D0;\n\tv285 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(0);\n\tv57 = v285;\nL_0090:\n\tv380 = System.Collections.IEnumerator::MoveNext(v285);\n\tv559 = v380 == 0;\n\tif (v559) goto L_00C7;\nL_00C1:\n\tv630 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v285);\n\tv323 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::Spawn(this, v630);\n\tgoto L_0064;\nL_0064:\n\tv331 = v285 == 0;\n\tif (v331) goto L_0107;\nL_00F6:\n\tv438 = v147 == 0;\n\tv176 = ~v438;\n\tv157 = v77;\n\tif (v176) goto L_010D;\nL_00D2:\n\t;\n\tv545 = *([v539 @ X10_v9-8]) == *([v157 @ X22_v4 (System.Int32)]);\n\tif (v545) goto L_00EE;\nL_00F2:\n\t;\n\tv172 = *([v565 @ X0_v18+8]);\n\t*([v565 @ X0_v18])(v435, v349, *([v565 @ X0_v18+8]), v160, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv153 = v343;\n\tv77 = v157;\n\tv147 = v385;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualCreator::Construct");
		}

		[Token(Token = "0x6000BE4")]
		[Address(RVA = "0x3ECD5A4", Offset = "0x3ECD5A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void InitVisuals(Transform visualParent)
		{
		}

		[Token(Token = "0x6000BE5")]
		[Address(RVA = "0x3ECD234", Offset = "0x3ECD234", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\nL_003B:\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv183 = ~v75;\n\tif (v183) goto L_FFFFFFFF;\n\tv190 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv192 = ~v190;\n\tif (v192) goto L_FFFFFFFF;\n\tv351 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv131 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v351);\n\tv173 = this._moldConceptConfig;\n\tv114 = v351 >> 0x20;\n\tgoto L_007B;\n\tv157 = System.String::Format(\"Mold_{0}_{1}\", v400, v403);\n\tUnityEngine.Object::set_name(v396, v157);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::ApplyEditorHideFlags(v396);\n\tv175 = this._moldConfig;\n\tv159 = UnityEngine.GameObject::get_transform(v396);\n\tv133 = v175.cellWidth * 0x3F59999A;\n\t// 189 MakeStruct v84 @ AGG3ECD4A4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v133 @ V0_v6 (System.Single), v133 @ V0_v6 (System.Single), v133 @ V0_v6 (System.Single)\n\tUnityEngine.Transform::set_localScale(v159, v84);\n\tv417 = UnityEngine.GameObject::GetComponent(v396);\n\tv420 = UnityEngine.Object::op_Inequality(v417, 0);\n\tv421 = ~v420;\n\tif (v421) goto L_00D2;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::BindMono(entity, v417);\nL_00D2:\n\tv160 = UnityEngine.GameObject::GetComponent(v396);\n\tv433 = _game.CoreSystem.MoldSystem.MoldMonoBase::Setup(v160, this._moldConceptConfig);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v461_asT @ TEMPCOND_v4 (_game.CoreSystem.MoldSystem.MoldMono), typeof(_game.CoreSystem.MoldSystem.MoldMono), v160 @ X0_v34 (_game.CoreSystem.MoldSystem.MoldMonoBase)\n\tv461 = v461_asT == 0;\n\tif (v461) goto L_0106;\n\t_game.CoreSystem.MoldSystem.MoldMono::Init(v160, this._vfxPool, this.VisualParent);\nL_0106:\n\tv339 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::OnMoldSpawned(this, v396, entity);\nL_FFFFFFFF:\n\tv341 = v396;\n\tgoto L_011D;\nL_FFFFFFFF:\n\tv341 = 0;\nL_007B:\n\tgoto L_008F;\nL_011D:\n\treturn v341;\nL_008F:\n\t// 143 MakeStruct v78 @ AGG3ECD3FC_2_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v366.identity (UnityEngine.Quaternion), v366.identity.y (System.Single), v366.identity.z (System.Single), v366.identity.w (System.Single)\n\tv396 = UnityEngine.Object::Instantiate(v173.MoldPrefab, v131, v78, this.VisualParent);\n\tv92 = v351;\n\tv110 = 0xB7D5000 + 0x538;\n\tv400 = \"il2cpp_vm_object_box\"(*([v110 @ X24_v8 (System.Int32)+48]), &v92 @ stack_-94_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = v114;\n\tv403 = \"il2cpp_vm_object_box\"(*([v110 @ X24_v8 (System.Int32)+48]), &v89 @ stack_-98_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public GameObject Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualCreator::Spawn");
			return default;
		}

		[Token(Token = "0x6000BE6")]
		[Address(RVA = "0x3ECD5A8", Offset = "0x3ECD5A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnMoldSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x6000BE7")]
		[Address(RVA = "0x3ECD5AC", Offset = "0x3ECD5AC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(go);\n\treturn;\n")]
		protected virtual void DestroyMoldGo(GameObject go)
		{
			VisualHandlerUtility.DestroyGo(go);
		}

		[Token(Token = "0x6000BE8")]
		[Address(RVA = "0x3ECD5B8", Offset = "0x3ECD5B8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0022:\n\tv55 = UnityEngine.Object::op_Equality(v47, 0);\n\tv58 = v55 == 0;\n\tif (v58) goto L_0039;\n\treturn;\nL_0039:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(entity);\n\tv109 = UnityEngine.Component::get_gameObject(v47);\n\tv91 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::DestroyMoldGo(v91, v109);\n\treturn;\nL_0019:\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_0022;\n")]
		public void DestroyVisualFor(Entity entity)
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			if (!(monoBinding == null))
			{
				entity.UnbindMono();
				GameObject go = monoBinding.gameObject;
				MoldVisualCreator moldVisualCreator = default(MoldVisualCreator);
				moldVisualCreator.DestroyMoldGo(go);
			}
		}

		[Token(Token = "0x6000BE9")]
		[Address(RVA = "0x3ECD690", Offset = "0x3ECD690", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv96 = ~v55;\n\tif (v96) goto L_0049;\n\tv107 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv111 = ~v107;\n\tif (v111) goto L_0049;\n\tv156 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_003C;\nL_003C:\n\tv106 = UnityEngine.Object::op_Equality(v156, 0);\n\tv110 = v106 == 0;\n\tif (v110) goto L_005A;\nL_0049:\n\treturn;\nL_005A:\n\tv78 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv171 = UnityEngine.Component::get_transform(v156);\n\tv61 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v78);\n\tUnityEngine.Transform::set_position(v171, v61);\n\treturn;\n")]
		public void SnapToGridPosition(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualCreator::SnapToGridPosition");
		}

		[Token(Token = "0x6000BEA")]
		[Address(RVA = "0x3ECD7F0", Offset = "0x3ECD7F0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Transform::get_childCount(this.VisualParent);\n\tv86 = v15 < 1;\n\tif (v86) goto L_003A;\n\tv33 = v15;\nL_001A:\n\tv33 = v33 - 1;\n\tv68 = UnityEngine.Transform::GetChild(this.VisualParent, v33);\n\tv152 = UnityEngine.Component::get_gameObject(v68);\n\tv124 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::DestroyMoldGo(this, v152);\n\tv96 = v33 > 0;\n\tif (v96) goto L_001A;\nL_003A:\n\treturn;\n")]
		public void Cleanup()
		{
			int childCount = VisualParent.childCount;
			if (childCount >= 1)
			{
				int num = childCount;
				do
				{
					num--;
					Transform child = VisualParent.GetChild(num);
					GameObject go = child.gameObject;
					DestroyMoldGo(go);
				}
				while (num > 0);
			}
		}

		[Token(Token = "0x6000BEB")]
		[Address(RVA = "0x3ECD86C", Offset = "0x3ECD86C", Length = "0x564")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv254 = *([v64 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv363 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv256 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v256) goto L_0063;\n\tv362 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv362 = v362 + 0x10;\n\tv345 = v363 - 1;\n\tv325 = v363 != 1;\nL_FFFFFFFF:\n\tv363 = v345;\n\tif (v325) goto L_0049;\nL_0063:\n\tv420 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v64);\n\tv383 = v420 == 0;\n\tv384 = ~v383;\nL_FFFFFFFF:\n\tv661 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv405 = 0;\n\tif (v384) goto L_FFFFFFFF;\n\tgoto L_0200;\nL_006D:\n\tv390 = *([v362 @ X10_v44]) << 4;\n\tv391 = v254 + v390;\n\tv392 = v391 + 0x138;\n\t*([v392 @ X8_v48])(v420, v64, *([v392 @ X8_v48+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv401 = v420 == 0;\nL_FFFFFFFF:\n\tv661 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv405 = 0;\n\tif (v401) goto L_0200;\nL_FFFFFFFF:\n\tv499 = v420;\n\tgoto L_008B;\nL_0083:\n\t_game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::UpdateVisualState(this, v828);\nL_0085:\n\tv474 = v380 == 0;\nL_FFFFFFFF:\n\tv499 = v380;\n\tif (v474) goto L_0200;\nL_008B:\n\tgoto L_00B1;\n\tv583 = v380 == 0;\n\tif (v583) goto L_0204;\n\tgoto L_00E2;\n\tv841 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v828);\n\tv843 = v841 == 0;\n\tif (v843) goto L_00FF;\n\tv850 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v828, &v55 @ stack_-68_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv882 = v850 == 0;\n\tv883 = ~v882;\n\tif (v883) goto L_0083;\n\tv912 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::Spawn(this, v828);\n\t_game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::UpdateVisualState(this, v828);\n\tgoto L_0085;\nL_00FF:\n\tv853 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v828, &v536 @ stack_-60_v10 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv885 = v853 == 0;\n\tif (v885) goto L_0085;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v828);\n\tv975 = UnityEngine.Component::get_gameObject(v536);\n\tv921 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::DestroyMoldGo(this, v975);\n\tgoto L_0085;\nL_0114:\n\tv645 = &v380 @ stack_-58_v11 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv658 = *([v645 @ X8_v37]);\n\tv647 = *([v645 @ X8_v37]) == 0;\nL_FFFFFFFF:\n\tv656 = 6;\nL_FFFFFFFF:\n\tv684 = 0;\nL_FFFFFFFF:\n\tv78 = 6;\nL_FFFFFFFF:\n\tv273 = v661;\nL_FFFFFFFF:\n\tv189 = 0;\nL_FFFFFFFF:\n\tv303 = 0;\nL_FFFFFFFF:\n\tv165 = 0;\n\tif (v647) goto L_0145;\nL_011E:\n\tgoto L_0144;\n\tv121 = v78 == 6;\n\tif (v121) goto L_0159;\n\tv817 = v78 == 0;\n\tv231 = ~v817;\n\tif (v231) goto L_01FF;\nL_0159:\n\tv152 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(oldData);\nL_FFFFFFFF:\n\tv164 = 0;\n\tgoto L_016D;\nL_0164:\n\tv1053 = UnityEngine.Component::get_gameObject(v70);\n\tv1050 = this->klass;\n\tv189 = this->klass->vtable[9];\n\tv1048 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::DestroyMoldGo(this, v1053);\n\tv219 = *([v879 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv219 = v219 + 0x10;\n\tv907 = v934 - 1;\n\tv889 = v934 != 1;\nL_FFFFFFFF:\n\tv934 = v907;\n\tif (v889) goto L_0178;\nL_0191:\n\tv228 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v152);\n\tv191 = v164 < v228;\n\tif (v191) goto L_01B6;\n\tgoto L_01FF;\nL_01A0:\n\tv183 = *([v219 @ X10_v16]) << 4;\n\tv949 = v879 + v183;\n\tv950 = v949 + 0x138;\n\t*([v950 @ X0_v41])(v229, v152, *([v950 @ X0_v41+8]), v189, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv192 = v164 >= v229;\n\tif (v192) goto L_01FF;\nL_01B6:\n\tgoto L_01DD;\n\tv1039 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v1036);\n\tv1041 = v1039 == 0;\n\tv1042 = ~v1041;\nL_FFFFFFFF:\n\tv189 = 0;\n\tif (v1042) goto L_016B;\n\tv1044 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v1036, &v70 @ stack_-70_v6 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv1049 = ~v1044;\nL_FFFFFFFF:\n\tv189 = 0;\n\tif (v1049) goto L_016B;\n\tv1051 = v70 == 0;\n\tv155 = ~v1051;\n\tif (v155) goto L_0164;\n\tthrow System.NullReferenceException;\nL_01FF:\n\treturn;\nL_0200:\n\tthrow System.NullReferenceException;\nL_0202:\n\tthrow System.NullReferenceException;\nL_0204:\n\tthrow System.NullReferenceException;\nL_0220:\n\tv281 = v303 != 1;\n\tif (v281) goto L_022F;\n\tv711 = 0x8BF5BC4(v631, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv684 = *([v711 @ X0_v15]);\n\tv679 = 0x8BF5BF4(v711, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv658 = *([v273 @ stack_-78_v3]);\n\tv819 = *([v273 @ stack_-78_v3]) == 0;\n\tv681 = ~v819;\nL_FFFFFFFF:\n\tv656 = 0;\nL_FFFFFFFF:\n\tv661 = v273;\nL_FFFFFFFF:\n\tv405 = *([v711 @ X0_v15]);\n\tif (v681) goto L_011E;\nL_FFFFFFFF:\n\tv78 = 0;\nL_FFFFFFFF:\n\tv405 = *([v711 @ X0_v15]);\nL_FFFFFFFF:\n\tv165 = *([v711 @ X0_v15]);\n\tgoto L_0145;\nL_022F:\n\tv713 = 0x3175484(&v405 @ stack_-80_v9 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv774 = 0x8BF0368(v631, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv306 = 0xA1B8(v774, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0031:\n\tv55 = 0;\nL_0049:\n\tv368 = *([v362 @ X10_v44-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v368) goto L_006D;\nL_00B1:\n\tv640 = System.Collections.IEnumerator::MoveNext(v499);\n\tv642 = v640 == 0;\n\tif (v642) goto L_0114;\nL_00E2:\n\tv828 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v380);\n\tv582 = this._em == 0;\n\tif (v582) goto L_0202;\nL_0145:\n\tv710 = v165 == 0;\n\tv629 = ~v710;\n\tif (v629) goto L_0209;\nL_0144:\n\tSystem.IDisposable::Dispose(v658);\nL_FFFFFFFF:\n\tv78 = v656;\nL_FFFFFFFF:\n\tv273 = v661;\nL_FFFFFFFF:\n\tv189 = 0;\nL_FFFFFFFF:\n\tv303 = 0;\nL_FFFFFFFF:\n\tv165 = v684;\nL_016D:\n\tv879 = *([v152 @ X0_v19 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv934 = *([v879 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv232 = *([v879 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v232) goto L_0191;\nL_0178:\n\tv939 = *([v219 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v939) goto L_01A0;\nL_01DD:\n\tv1036 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v152, v164);\nL_016B:\n\tv164 = v164\n// ... truncated")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualCreator::SyncWithData");
		}

		[Token(Token = "0x6000BEC")]
		[Address(RVA = "0x3ECDDD0", Offset = "0x3ECDDD0", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tgoto L_0045;\nL_0045:\n\tv149 = UnityEngine.Object::op_Equality(v54, 0);\n\tv156 = v149 == 0;\n\tif (v156) goto L_005A;\n\tgoto L_011C;\nL_005A:\n\tv256 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv325 = UnityEngine.Component::get_transform(v54);\n\tv126 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v256);\n\tUnityEngine.Transform::set_position(v325, v126);\n\tv131 = v256 >> 0x20;\n\tv330 = UnityEngine.Component::get_gameObject(v54);\n\tv114 = v256;\n\tv112 = 0xB7D5000 + 0x538;\n\tv334 = \"il2cpp_vm_object_box\"(*([v112 @ X25_v5 (System.Int32)+48]), &v114 @ stack_-5C_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv109 = v131;\n\tv337 = \"il2cpp_vm_object_box\"(*([v112 @ X25_v5 (System.Int32)+48]), &v109 @ stack_-60_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv286 = System.String::Format(\"Mold_{0}_{1}\", v334, v337);\n\tUnityEngine.Object::set_name(v330, v286);\n\tv344 = UnityEngine.Component::GetComponent(v54);\n\tgoto L_009F;\nL_009F:\n\tv151 = UnityEngine.Object::op_Equality(v344, 0);\n\tv158 = v151 == 0;\n\tif (v158) goto L_00B4;\n\tgoto L_011C;\nL_00B4:\n\tv356 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv357 = ~v356;\nL_FFFFFFFF:\n\tv106 = 0;\n\tif (v357) goto L_00D8;\n\tv367 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv291 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv365 = *([v344 @ X0_v25 (_game.CoreSystem.MoldSystem.MoldMonoBase)]);\n\tv106 = *([v365 @ X8_v30 (Il2CppClass<_game.CoreSystem.MoldSystem.MoldMonoBase>)+250]);\n\tv363 = _game.CoreSystem.MoldSystem.MoldMonoBase::ApplyMaterial(v344, v367, v291);\nL_00D8:\n\tv292 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv369 = ~v292;\n\tif (v369) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv376 = 0x1C8;\nL_FFFFFFFF:\n\tv316 = 0x1D0;\n\tgoto L_00E4;\nL_FFFFFFFF:\n\tv376 = 0x1D8;\nL_FFFFFFFF:\n\tv316 = 0x1E0;\n\tv153 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv160 = ~v153;\n\tif (v160) goto L_011C;\n\tv384 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv75 = v384 < 1;\n\tif (v75) goto L_FFFFFFFF;\n\tv125 = entity / v384;\n\tgoto L_0110;\nL_FFFFFFFF:\n\tv125 = 0;\nL_0038:\n\tv57 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(entity, &v54 @ stack_-58_v2 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv61 = ~v57;\n\tif (v61) goto L_011C;\nL_011C:\n\treturn;\nL_00E4:\n\tv72 = *([v344 @ X0_v25 (_game.CoreSystem.MoldSystem.MoldMonoBase)]);\n\t*([v72 @ X10_v3 (Il2CppClass<_game.CoreSystem.MoldSystem.MoldMonoBase>)+v376 @ X9_v4 (System.Int32)])(v379, v344, *([v72 @ X10_v3 (Il2CppClass<_game.CoreSystem.MoldSystem.MoldMonoBase>)+v316 @ X8_v18 (System.Int32)]), Il2CppMethodInfo, v106, v36, v37, v38, v39, v126, v126.y, v126.z, v43, v44, v45, v46, v47);\nL_0110:\n\tv148 = _game.CoreSystem.MoldSystem.MoldMonoBase::UpdateVisualFill(v344, v125);\n")]
		private void UpdateVisualState(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualCreator::UpdateVisualState");
		}

		[Token(Token = "0x6000BED")]
		[Address(RVA = "0x3ECE160", Offset = "0x3ECE160", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator::Cleanup(this);\n\treturn;\n")]
		public void Dispose()
		{
			Cleanup();
		}

		[Token(Token = "0x6000BEE")]
		[Address(RVA = "0x3ECE164", Offset = "0x3ECE164", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldVisualCreator()
		{
		}
	}
}
