using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000154")]
	public class SandCubeTunnelSpawnHandler : TunnelSpawnHandlerBase
	{
		[CompilerGenerated]
		[Token(Token = "0x2000155")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x400044F")]
			[FieldOffset(Offset = "0x10")]
			public GridCoord? capturedCoord;

			[Token(Token = "0x4000450")]
			[FieldOffset(Offset = "0x20")]
			public MovingCubeTracker captured;

			[Token(Token = "0x4000451")]
			[FieldOffset(Offset = "0x28")]
			public SandCubeTunnelSpawnHandler _003C_003E4__this;

			[Token(Token = "0x600069A")]
			[Address(RVA = "0x3DB9464", Offset = "0x3DB9464", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal unsafe void _003CHandle_003Eb__0()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SandCubeTunnelSpawnHandler._003C_003Ec__DisplayClass4_0::_003CHandle_003Eb__0");
			}
		}

		[Inject(false)]
		[Token(Token = "0x400044B")]
		[FieldOffset(Offset = "0x18")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x400044C")]
		[FieldOffset(Offset = "0x20")]
		private TopGridVisualGridController _visualGrid;

		[Inject(true)]
		[Token(Token = "0x400044D")]
		[FieldOffset(Offset = "0x28")]
		private SandCubeVisualHandler _sandCubeHandler;

		[Inject(true)]
		[Token(Token = "0x400044E")]
		[FieldOffset(Offset = "0x30")]
		private SandCollisionService _collisionService;

		[Token(Token = "0x6000696")]
		[Address(RVA = "0x3DB8D8C", Offset = "0x3DB8D8C", Length = "0x6D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tv365 = 0xB285000 + 0x5F8;\n\tv498 = 0xB29B000 + 0xAD8;\nL_FFFFFFFF:\n\tv459 = slotEntities;\nL_FFFFFFFF:\n\tv113 = tunnel;\nL_FFFFFFFF:\n\tv161 = 0;\n\tgoto L_004E;\nL_004D:\n\tv161 = v161 + 1;\n\tv156 = *([v500 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv156 = v156 + 0x10;\n\tv509 = v534 - 1;\n\tv508 = v534 != 1;\nL_FFFFFFFF:\n\tv534 = v509;\n\tif (v508) goto L_0055;\nL_006F:\n\tv528 = 0x220C5E0(slotEntities, *([v365 @ X25_v7 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v528 @ X0_v112])(v163, slotEntities, *([v528 @ X0_v112+8]), 0, v459, v242, v43, v44, v45, v458, v47, v48, v49, v50, v51, v52, v53);\n\tv115 = v161 < v163;\n\tif (v115) goto L_0094;\n\tgoto L_0273;\nL_0081:\n\t;\n\tv106 = *([v156 @ X10_v21]) << 4;\n\tv559 = v500 + v106;\n\tv560 = v559 + 0x138;\n\t*([v560 @ X0_v115])(v164, slotEntities, *([v560 @ X0_v115+8]), v113, v459, v242, v43, v44, v45, v458, v47, v48, v49, v50, v51, v52, v53);\n\tv116 = v161 >= v164;\n\tif (v116) goto L_0273;\nL_0094:\n\t;\n\tv368 = new *([v498 @ X20_v21 (System.Int32)])();\n\tSystem.Object::.ctor(v368);\n\t*([v368 @ X0_v8 (System.Object)+28]) = this;\n\tv585 = slotEntities->klass;\n\tv607 = slotEntities->klass->interface_offsets_count;\n\tv587 = *([v585 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v587) goto L_00C5;\n\tv360 = *([v585 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv360 = v360 + 0x10;\n\tv593 = v607 - 1;\n\tv592 = v607 != 1;\nL_FFFFFFFF:\n\tv607 = v593;\n\tif (v592) goto L_00A9;\nL_00C5:\n\t;\n\tv626 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(slotEntities, v161);\n\tv618 = em == 0;\n\tv380 = ~v618;\n\tif (v380) goto L_00DC;\n\tgoto L_0274;\nL_00CD:\n\t;\n\tv251 = *([v360 @ X10_v16]) << 4;\n\tv620 = v585 + v251;\n\tv621 = v620 + 0x138;\n\t*([v621 @ X0_v108])(v626, slotEntities, v161, *([v621 @ X0_v108+8]), v459, v242, v43, v44, v45, v458, v47, v48, v49, v50, v51, v52, v53);\nL_00DC:\n\tv632 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v626);\n\tv633 = ~v632;\nL_FFFFFFFF:\n\tv113 = 0;\n\tif (v633) goto L_004D;\n\tv639 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v626);\n\tv694 = ~v639;\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\n\tif (v694) goto L_004D;\n\tv710 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v626);\n\tgoto L_00F2;\nL_00F2:\n\tv686 = UnityEngine.Object::op_Inequality(v710, 0);\n\tv718 = v686 == 0;\n\tv695 = ~v718;\nL_FFFFFFFF:\n\tv113 = 0;\n\tif (v695) goto L_004D;\n\tgoto L_010A;\nL_010A:\n\tv727 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler::TrySpawn(this._sandCubeHandler, v626);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler::PlayTunnelFireVfx(v727, tunnel);\n\tv734 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v626);\n\tv736 = v734 == 0;\n\tif (v736) goto L_FFFFFFFF;\n\tv742 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v626);\n\tSystem.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(&v766 @ stack_-A0_v7 (System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>), v742);\n\tv778 = v766 == 1;\nL_FFFFFFFF:\n\tv768 = v766;\nL_FFFFFFFF:\n\tv242 = v742;\n\tif (v778) goto L_0146;\nL_FFFFFFFF:\n\tv768 = v766;\nL_FFFFFFFF:\n\tv243 = v742;\n\tgoto L_0176;\nL_FFFFFFFF:\n\tv768 = 0;\nL_FFFFFFFF:\n\tv768 = 0;\nL_FFFFFFFF:\n\tv243 = v242;\n\tgoto L_0176;\nL_0146:\n\tv401 = this._collisionService;\n\tv785 = this._collisionService == 0;\nL_FFFFFFFF:\n\tv243 = v242;\n\tif (v785) goto L_0176;\n\tv809 = System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Value(&v768 @ stack_-70_v6 (System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tgoto L_0169;\nL_0169:\n\tv844 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v401._suppressedCoords, v809);\n\tv796 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v401._dirtyCoords, v809);\nL_FFFFFFFF:\n\tv243 = v242;\nL_0181:\n\tv825 = UnityEngine.Object::op_Inequality(v803, 0);\n\tv836 = ~v825;\n\tv837 = ~v836;\nL_FFFFFFFF:\n\tv642 = 0;\n\tif (v837) goto L_019E;\n\tv498 = 0xB29B000 + 0xAD8;\n\tv856 = *([B78E0D9]) & 1;\n\tv857 = v856 == 0;\nL_FFFFFFFF:\n\tv211 = v642;\nL_FFFFFFFF:\n\tv403 = v498;\n\tif (v857) goto L_01AD;\nL_018D:\n\tv641 = this._animator;\n\tv873 = this._animator == 0;\n\tv384 = ~v873;\n\tif (v384) goto L_01B7;\n\tgoto L_0274;\nL_019E:\n\tv867 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler::TryRegisterMovingCubeTracker(this, v803, v626, tunnel);\n\tv498 = 0xB29B000 + 0xAD8;\n\tv881 = *([B78E0D9]) & 1;\n\tv882 = v881 == 0;\n\tv870 = ~v882;\nL_FFFFFFFF:\n\tv642 = v867;\nL_FFFFFFFF:\n\tv211 = v867;\nL_FFFFFFFF:\n\tv403 = v498;\n\tif (v870) goto L_018D;\nL_01AD:\n\t*([B78E0D9]) = 1;\n\tv641 = this._animator;\nL_FFFFFFFF:\n\tv642 = v211;\nL_FFFFFFFF:\n\tv498 = v403;\nL_01B7:\n\tgoto L_01DF;\n\t*([v368 @ X0_v8 (System.Object)+20]) = v642;\n\tv975 = new System.Action();\n\tSystem.Action::.ctor(v975, v368, Il2CppMethodInfo);\n\tv688 = PrimeTween.Sequence::OnComplete(&v201 @ stack_-80_v5 (PrimeTween.Sequence), v975, 1);\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = 0;\nL_FFFFFFFF:\n\tv242 = v243;\nL_FFFFFFFF:\n\tv113 = 1;\n\tgoto L_004D;\nL_0204:\n\tgoto L_0208;\nL_0208:\n\tv979 = UnityEngine.Object::op_Inequality(v642, 0);\n\tv985 = ~v979;\n\tv986 = ~v985;\nL_FFFFFFFF:\n\tv113 = 0;\nL_FFFFFFFF:\n\tv275 = 0;\n\tif (v986) goto L_0226;\n\tv659 = *([v368 @ X0_v8 (System.Object)+10]) != 1;\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = 0;\nL_FFFFFFFF:\n\tv242 = v243;\n\tif (v659) goto L_004D;\nL_FFFFFFFF:\n\tv275 = v113;\n\tgoto L_0237;\nL_0226:\n\tgoto L_022A;\nL_022A:\n\tUnityEngine.Object::Destroy(v642);\n\tv660 = *([v368 @ X0_v8 (System.Object)+10]) != 1;\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = 0;\nL_FFFFFFFF:\n\tv242 = v243;\nL_FFFFFFFF:\n\tv113 = 0;\n\tif (v660) goto L_004D;\nL_0237:\n\tv246 = this._collisionService;\n\tv700 = this._collisionService == 0;\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = 0;\nL_FFFFFFFF:\n\tv242 = v243;\nL_FFFFFFFF:\n\tv113 = v275;\n\tif (v700) goto L_004D;\n\tv1008 = v368 + 0x10;\n\tv1009 = System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Value(v1008);\n\tgoto L_0259;\nL_0259:\n\tv692 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Remove(v246._suppressedCoords, v1009);\n\tv701 = ~v692;\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv242 = v243;\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\n\tif (v701) goto L_004D;\n\tv693 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v246._dirtyCoords, v1009);\nL_FFFFFFFF:\n\tv458 = v768;\nL_FFFFFFFF:\n\tv459 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv242 = v243;\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\n\tgoto L_004D;\nL_0273:\n\treturn;\nL_0274:\n\tthrow System.NullReferenceException;\nL_0043:\n\tv63 = this._sandCubeHandler == 0;\n\tif (v63) goto L_0273;\nL_004E:\n\t;\n\tv500 = slotEntities->klass;\n\tv534 = slotEntities->klass->interface_offsets_count;\n\tv166 = *([v500 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v166) goto L_006F;\nL_0055:\n\t;\n\tv547 = *([v156 @ X10_v21-8]) == *([v365 @ X25_v7 (System.Int32)]);\n\tif (v547) goto L_0081;\nL_00A9:\n\t;\n\tv328 = *([v360 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v328) goto L_00CD;\nL_0176:\n\tv803 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v626);\n\tgoto L_0181;\nL_01DF:\n\tv959 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnAnimator::Animate(v641, v626, tunnel);\n\tv201 = v959;\n\t*([v368 @ X0_v8 (System.Object)+10]) = v768;\n\tv962 = PrimeTween.Sequence::get_isAlive(&v201 @ stack_-80_v5 (PrimeTween.Sequence)\n// ... truncated")]
		public unsafe override void Handle(EntityManager em, Entity tunnel, IReadOnlyList<Entity> slotEntities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeTunnelSpawnHandler::Handle");
		}

		[Token(Token = "0x6000697")]
		[Address(RVA = "0x3DB946C", Offset = "0x3DB946C", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0024:\n\tv57 = UnityEngine.Object::op_Equality(v47, 0);\n\tv60 = v57 == 0;\n\tif (v60) goto L_0038;\n\tgoto L_004C;\nL_0038:\n\tv99 = UnityEngine.Component::GetComponent(v47);\n\tgoto L_0041;\nL_0041:\n\tv80 = UnityEngine.Object::op_Equality(v99, 0);\n\tv83 = v80 == 0;\n\tif (v83) goto L_0060;\nL_004C:\n\treturn;\nL_0060:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono::PlayFireVfx(v99);\n\treturn;\nL_001B:\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(tunnel);\n\tgoto L_0024;\n")]
		private void PlayTunnelFireVfx(Entity tunnel)
		{
			EntityMono monoBinding = tunnel.GetMonoBinding();
			if (!(monoBinding == null))
			{
				TunnelVisualMono component = monoBinding.GetComponent<TunnelVisualMono>();
				if (!(component == null))
				{
					component.PlayFireVfx();
				}
			}
		}

		[Token(Token = "0x6000698")]
		[Address(RVA = "0x3DB9580", Offset = "0x3DB9580", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = *([B78E0BE]) & 1;\n\tv37 = v36 == 0;\n\tif (v37) goto L_002F;\n\tv61 = 0xB293000 + 0xDC8;\n\tv42 = *([B193A9A]) & 1;\n\tv43 = v42 == 0;\nL_FFFFFFFF:\n\tv75 = v61;\n\tif (v43) goto L_003C;\nL_001E:\n\tv69 = *([v61 @ X24_v9 (System.Int32)]);\n\tv70 = *([v69 @ X8_v23+B8]);\n\tv86 = *([v70 @ X8_v24]);\n\tv72 = *([v70 @ X8_v24]) == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0049;\n\tgoto L_FFFFFFFF;\nL_002F:\n\t*([B1930BE]) = 1;\n\tv61 = 0xB293000 + 0xDC8;\n\tv215 = *([B193A9A]) & 1;\n\tv216 = v215 == 0;\n\tv64 = ~v216;\nL_FFFFFFFF:\n\tv75 = v61;\n\tif (v64) goto L_001E;\nL_003C:\n\t*([B193A9A]) = 1;\n\tv96 = *([v75 @ X24_v5 (System.Int32)]);\n\tv91 = *([v96 @ X8_v18+B8]);\n\tv86 = *([v91 @ X8_v19]);\n\tv89 = *([v91 @ X8_v19]) == 0;\n\tif (v89) goto L_FFFFFFFF;\nL_0049:\n\tv104 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, tunnel);\n\tv107 = ~v104;\n\tif (v107) goto L_FFFFFFFF;\n\tv186 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, tunnel);\n\tv165 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v186);\n\tv207 = this._visualGrid;\n\tv153 = 0;\n\tv289 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(v207._gridHandler, &v153 @ stack_-70_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv291 = ~v289;\nL_FFFFFFFF:\n\tv143 = 0.5f;\n\tif (v291) goto L_008A;\n\tv295 = v294 + v294;\n\tv296 = v294 < 0;\n\tv297 = v294 == 0;\n\tv300 = v294 == v294;\n\tv301 = ~v300;\n\tv305 = v296 == v301;\n\tv306 = ~v297;\n\tv307 = v305 & v306;\n\tv308 = ~v307;\n\tif (v308) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv314 = v295;\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv314 = 0x3DCCCCCD;\nL_008A:\n\tv189 = UnityEngine.Component::get_transform(this._visualGrid);\n\tv167 = UnityEngine.Transform::get_eulerAngles(v189);\n\t// 153 MakeStruct v115 @ AGG3DB9730_2_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v165 @ V0_v3 (UnityEngine.Vector3), v165.y (System.Single)\n\t_game.CoreSystem.SandPhysics.Services.MovingCubeRegistry::Register(*([v86 @ X24_v4+18]), entity, v115, v143, v167.z);\n\tv191 = UnityEngine.Component::get_gameObject(binding);\n\treturnVal1 = UnityEngine.GameObject::AddComponent(v191);\n\treturnVal1._entity = entity;\n\tgoto L_00B8;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0083:\n\tv311 = 0 - v314;\n\tv143 = v311 * 0.5f;\nL_00B8:\n\treturn returnVal1;\n")]
		private MovingCubeTracker TryRegisterMovingCubeTracker(Component binding, Entity entity, Entity tunnel)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeTunnelSpawnHandler::TryRegisterMovingCubeTracker");
			return default;
		}

		[Token(Token = "0x6000699")]
		[Address(RVA = "0x3DB9848", Offset = "0x3DB9848", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandCubeTunnelSpawnHandler()
		{
		}
	}
}
