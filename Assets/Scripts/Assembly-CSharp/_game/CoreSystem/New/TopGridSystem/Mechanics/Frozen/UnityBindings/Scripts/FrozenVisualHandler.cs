using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts
{
	[Token(Token = "0x200023A")]
	public class FrozenVisualHandler : ITopGridVisualHandler
	{
		[Token(Token = "0x200023B")]
		internal class State
		{
			[Token(Token = "0x40006E3")]
			[FieldOffset(Offset = "0x10")]
			public int total;

			[Token(Token = "0x40006E4")]
			[FieldOffset(Offset = "0x14")]
			public int lastRemaining;

			[Token(Token = "0x40006E5")]
			[FieldOffset(Offset = "0x18")]
			public GameObject iceGo;

			[Token(Token = "0x40006E6")]
			[FieldOffset(Offset = "0x20")]
			public FrozenIceMono mono;

			[Token(Token = "0x60009C5")]
			[Address(RVA = "0x3E9AC08", Offset = "0x3E9AC08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public State()
			{
			}
		}

		[Inject(false)]
		[Token(Token = "0x40006DC")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40006DD")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40006DE")]
		[FieldOffset(Offset = "0x20")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x40006DF")]
		[FieldOffset(Offset = "0x28")]
		private FrozenConfig _config;

		[Inject(true)]
		[Token(Token = "0x40006E0")]
		[FieldOffset(Offset = "0x30")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x40006E1")]
		[FieldOffset(Offset = "0x38")]
		private Transform _parent;

		[Token(Token = "0x40006E2")]
		[FieldOffset(Offset = "0x40")]
		internal readonly Dictionary<EntityId, State> _states;

		[Token(Token = "0x60009BE")]
		[Address(RVA = "0x3E9A16C", Offset = "0x3E9A16C", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv173 = 0;\n\tgoto L_0041;\nL_003B:\n\tv347 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v65, v173);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::Spawn(this, v347);\n\tv173 = v173 + 1;\n\tv224 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv224 = v224 + 0x10;\n\tv191 = v215 - 1;\n\tv189 = v215 != 1;\n\tv215 = v191;\n\tif (v189) goto L_004C;\nL_0065:\n\tv237 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v65);\n\tv248 = v173 < v237;\n\tif (v248) goto L_008A;\n\tgoto L_00B4;\nL_0074:\n\tv251 = *([v224 @ X10_v13]) << 4;\n\tv252 = v182 + v251;\n\tv253 = v252 + 0x138;\n\t*([v253 @ X0_v24])(v257, v65, *([v253 @ X0_v24+8]), 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv267 = v173 >= v257;\n\tif (v267) goto L_00B4;\nL_008A:\n\tgoto L_003B;\nL_00B4:\n\treturn;\nL_0020:\n\tthis._parent = v44;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::Cleanup(this);\nL_0041:\n\tv182 = *([v65 @ X0_v9 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv215 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv134 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v134) goto L_0065;\nL_004C:\n\tv229 = *([v224 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v229) goto L_0074;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenVisualHandler::InitVisuals");
		}

		[Token(Token = "0x60009BF")]
		[Address(RVA = "0x3E9A8E8", Offset = "0x3E9A8E8", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = *([B78E6FE]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_002E;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::Cleanup(this);\n\tv54 = this._parent;\n\tgoto L_001B;\nL_001B:\n\tv62 = UnityEngine.Object::op_Equality(v54, 0);\n\tv74 = v62 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_004A;\n\tv137 = 0;\n\tgoto L_0051;\nL_002E:\n\t*([B78E6FE]) = 1;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::Cleanup(this);\n\tv54 = this._parent;\n\tgoto L_001B;\nL_004A:\n\treturn;\nL_0051:\n\tv211 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv156 = 0;\n\tgoto L_0068;\nL_0062:\n\tv386 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v211, v156);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::Spawn(this, v386);\n\tv156 = v156 + 1;\n\tv137 = 0;\n\tv130 = *([v253 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv130 = v130 + 0x10;\n\tv276 = v289 - 1;\n\tv258 = v289 != 1;\n\tv289 = v276;\n\tif (v258) goto L_0073;\nL_008C:\n\tv145 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v211);\n\tv93 = v156 < v145;\n\tif (v93) goto L_00B1;\n\tgoto L_004A;\nL_009B:\n\tv90 = *([v130 @ X10_v12]) << 4;\n\tv303 = v253 + v90;\n\tv304 = v303 + 0x138;\n\t*([v304 @ X0_v19])(v146, v211, *([v304 @ X0_v19+8]), v137, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv94 = v156 >= v146;\n\tif (v94) goto L_004A;\nL_00B1:\n\tgoto L_0062;\nL_0068:\n\tv253 = *([v211 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv289 = *([v253 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv149 = *([v253 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v149) goto L_008C;\nL_0073:\n\tv294 = *([v130 @ X10_v12-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v294) goto L_009B;\n")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenVisualHandler::SyncWithData");
		}

		[Token(Token = "0x60009C0")]
		[Address(RVA = "0x3E9A30C", Offset = "0x3E9A30C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv62 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::get_Values(this._states);\n\tv145 = v62 == 0;\n\tv96 = &v123 @ stack_-68_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>);\n\tv103 = 0;\n\tv125 = v126;\n\tv137 = Il2CppMethodInfo;\n\tif (v145) goto L_007D;\n\tv126 = 0xB2A8000 + 0x3C0;\n\tv169 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>+ValueCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::GetEnumerator(v62);\n\tv123 = v169._dictionary;\n\tv109 = v169.Current;\n\tgoto L_005F;\nL_005F:\n\tv207 = UnityEngine.Object::op_Inequality(v109.iceGo, 0);\n\tv210 = v207 == 0;\n\tif (v210) goto L_004E;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v109.iceGo);\n\tgoto L_004E;\nL_0069:\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+ValueCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(&v123 @ stack_-68_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>));\n\tv96 = &v123 @ stack_-68_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>);\n\tv103 = 0;\n\tv125 = v126;\n\tv137 = Il2CppMethodInfo;\nL_006B:\n\tv146 = this._states == 0;\n\tv96 = v98;\n\tv125 = v9;\n\tv137 = Il2CppMethodInfo;\n\tif (v146) goto L_007D;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::Clear(this._states);\n\treturn;\nL_008C:\n\tv180 = v137 != 1;\n\tv194 = v153;\n\tif (v180) goto L_009C;\n\tv185 = 0x8BF5BC4(v153, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = 0x8BF5BF4(v185, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = *([v125 @ X22_v1 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+ValueCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(v96);\n\tv193 = *([v185 @ X0_v12]) == 0;\n\tv103 = *([v185 @ X0_v12]);\n\tif (v193) goto L_006B;\n\tv191 = new System.OutOfMemoryException();\n\tv103 = *([v185 @ X0_v12]);\n\tv194 = v191;\n\treturn;\nL_002A:\n\tv123 = 0;\n\tv55 = this._states == 0;\n\tif (v55) goto L_007D;\nL_007D:\n\tv153 = new System.NullReferenceException();\n\tgoto L_008C;\nL_004E:\n\tv214 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+ValueCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::MoveNext(&v123 @ stack_-68_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>));\n\tv222 = v214 == 0;\n\tif (v222) goto L_0069;\nL_009C:\n\tv197 = 0x318F4B8(&v103 @ stack_-78_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv218 = 0x8BF0368(v194, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv224 = 0xA1B8(v218, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenVisualHandler::Cleanup");
		}

		[Token(Token = "0x60009C1")]
		[Address(RVA = "0x3E9A4E8", Offset = "0x3E9A4E8", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\nL_003A:\n\tv67 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv223 = ~v67;\n\tif (v223) goto L_0136;\n\tv257 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv260 = ~v257;\n\tif (v260) goto L_0136;\n\tv258 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv261 = ~v258;\n\tif (v261) goto L_0136;\n\tv334 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv338 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::CountLiveFreezers(this._em, this._gridHandler, v334);\n\tgoto L_006A;\nL_006A:\n\tv345 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv349 = ~v345;\n\tv350 = ~v349;\n\tif (v350) goto L_0078;\n\tgoto L_FFFFFFFF;\nL_0078:\n\tv209 = this._config;\n\tgoto L_0087;\n\tgoto L_0096;\n\tv127 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v334);\n\tv211 = this._config;\n\tv135 = v334 >> 0x20;\n\tv410 = 0x3E74E78(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v127, v127.y, v127.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 189 MakeStruct v85 @ AGG3E9A754_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v127 @ V0_v4 (UnityEngine.Vector3), v127.y (System.Single), v127.z (System.Single), v51 @ V3\n\tv419 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v211.iceMeshPrefab, v127, v85, this._parent);\n\tv81 = v334;\n\tv77 = 0xB7D5000 + 0x538;\n\tv423 = \"il2cpp_vm_object_box\"(*([v77 @ X26_v6 (System.Int32)+48]), &v81 @ stack_-74_v4 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv74 = v135;\n\tv426 = \"il2cpp_vm_object_box\"(*([v77 @ X26_v6 (System.Int32)+48]), &v74 @ stack_-78_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv187 = System.String::Format(\"FrozenIce_{0}_{1}\", v423, v426);\n\tUnityEngine.Object::set_name(v419, v187);\n\tv129 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv189 = UnityEngine.GameObject::get_transform(v419);\n\t// 231 MakeStruct v70 @ AGG3E9A7EC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v129 @ V0_v6 (System.Single), v129 @ V0_v6 (System.Single), v129 @ V0_v6 (System.Single)\n\tUnityEngine.Transform::set_localScale(v189, v70);\n\tv437 = UnityEngine.GameObject::GetComponent(v419);\n\tgoto L_00F8;\nL_00F8:\n\tv190 = UnityEngine.Object::op_Inequality(v437, 0);\n\tv383 = ~v190;\nL_FFFFFFFF:\n\tv153 = v419;\nL_FFFFFFFF:\n\tv158 = v437;\n\tif (v383) goto L_010C;\n\tv384 = ~v338;\n\tv444 = v338 & v384;\n\tv437._total = v444;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenIceMono::SetRemaining(v437, v444);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenIceMono::SetRemaining(v437, v338);\nL_FFFFFFFF:\n\tv153 = v419;\nL_FFFFFFFF:\n\tv158 = v437;\n\tgoto L_010C;\nL_FFFFFFFF:\n\tv153 = 0;\nL_FFFFFFFF:\n\tv158 = 0;\n\tv191.total = v338;\n\tv191.lastRemaining = v338;\n\tv191.iceGo = v153;\n\tv191.mono = v158;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::set_Item(this._states, entity, v191);\nL_0136:\n\treturn;\nL_0087:\n\tv366 = UnityEngine.Object::op_Inequality(v209.iceMeshPrefab, 0);\n\tv369 = ~v366;\n\tif (v369) goto L_FFFFFFFF;\nL_0096:\n\tv367 = UnityEngine.Object::op_Inequality(this._parent, 0);\n\tv370 = ~v367;\n\tif (v370) goto L_FFFFFFFF;\nL_010C:\n\tv191 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State();\n\tSystem.Object::.ctor(v191);\n")]
		private void Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenVisualHandler::Spawn");
		}

		[Token(Token = "0x60009C2")]
		[Address(RVA = "0x3E9AC10", Offset = "0x3E9AC10", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\nL_0036:\n\tv64 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::get_Count(this._states);\n\tv244 = v64 == 0;\n\tif (v244) goto L_019D;\n\tv201 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv418 = 0xB285000 + 0x5F8;\n\tv417 = 0xB285000 + 0x780;\n\tv416 = 0xB2C6000 + 0x780;\n\tv415 = 0xB2A1000 + 0xAA8;\nL_FFFFFFFF:\n\tv184 = 0;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv391 = v414;\nL_FFFFFFFF:\n\tv264 = v592;\n\tv297 = *([v429 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv297 = v297 + 0x10;\n\tv435 = v457 - 1;\n\tv434 = v457 != 1;\nL_FFFFFFFF:\n\tv457 = v435;\n\tif (v434) goto L_005B;\nL_0070:\n\tv454 = 0x220C5E0(v201, *([v418 @ X22_v7 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v454 @ X0_v59])(v308, v201, *([v454 @ X0_v59+8]), 0, v391, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv266 = v184 < v308;\n\tif (v266) goto L_0096;\n\tgoto L_019D;\nL_0083:\n\tv261 = *([v297 @ X10_v14]) << 4;\n\tv479 = v429 + v261;\n\tv480 = v479 + 0x138;\n\t*([v480 @ X0_v62])(v309, v201, *([v480 @ X0_v62+8]), v264, v391, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv267 = v184 >= v309;\n\tif (v267) goto L_019D;\nL_0096:\n\tv501 = *([v201 @ X0_v8 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv535 = *([v501 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv503 = *([v501 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v503) goto L_00B6;\n\tv544 = *([v501 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv544 = v544 + 0x10;\n\tv511 = v535 - 1;\n\tv509 = v535 != 1;\nL_FFFFFFFF:\n\tv535 = v511;\n\tif (v509) goto L_00A1;\nL_00B6:\n\tv560 = 0x220C5E0(v201, *([v417 @ X28_v7 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00C0;\nL_00B9:\n\tv556 = *([v544 @ X10_v9]) << 4;\n\tv557 = v501 + v556;\n\tv560 = v557 + 0x138;\n\tv564 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v563);\n\tv565 = ~v564;\nL_FFFFFFFF:\n\tv264 = 0;\n\tif (v565) goto L_004E;\n\tv264 = *([v416 @ X24_v7 (System.Int32)]);\n\tv576 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v563);\n\tv582 = ~v576;\n\tif (v582) goto L_004E;\n\tv391 = *([v415 @ X23_v7 (System.Int32)]);\n\tv577 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::TryGetValue(this._states, v563, &v90 @ stack_-68_v6 (_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State));\n\tv583 = ~v577;\nL_FFFFFFFF:\n\tv264 = &v90 @ stack_-68_v6 (_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State);\n\tif (v583) goto L_004E;\n\tv592 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v563);\n\tv595 = v563 & 0xFFFFFFFF;\n\tv596 = v414 & 0xFFFFFFFF00000000;\n\tv414 = v596 | v595;\n\tv205 = _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Shared.FrozenNeighborQuery::CountLiveFreezers(this._em, this._gridHandler, v592);\n\tv114 = v205 >= v90.lastRemaining;\n\tif (v114) goto L_FFFFFFFF;\n\tv90.lastRemaining = v205;\n\tgoto L_010D;\nL_010D:\n\tv206 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv418 = 0xB285000 + 0x5F8;\n\tv415 = 0xB2A1000 + 0xAA8;\n\tv612 = ~v206;\nL_FFFFFFFF:\n\tv192 = 0;\n\tif (v612) goto L_011C;\n\tv233 = this._config;\n\tv192 = v233.breakVfxPrefab;\n\tv584 = v90.mono == 0;\n\tif (v584) goto L_0135;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenIceMono::SetRemaining(v90.mono, v205);\nL_0135:\n\tv115 = v205 <= 0;\n\tif (v115) goto L_0141;\n\tv416 = 0xB2C6000 + 0x780;\nL_FFFFFFFF:\n\tv385 = v95;\nL_FFFFFFFF:\n\tv391 = v95;\nL_FFFFFFFF:\n\tv264 = v592;\n\tgoto L_004E;\nL_0141:\n\tgoto L_0144;\nL_0144:\n\tv630 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv636 = ~v630;\n\tv637 = ~v636;\nL_FFFFFFFF:\n\tv121 = v384;\n\tif (v637) goto L_0156;\nL_FFFFFFFF:\n\tv121 = v384;\nL_FFFFFFFF:\n\tv194 = 0;\n\tgoto L_015A;\nL_0156:\n\tv235 = this._config;\n\tv194 = v235.revealPrefab;\n\tv416 = 0xB2C6000 + 0x780;\n\tgoto L_0170;\nL_0170:\n\tv579 = UnityEngine.Object::op_Inequality(v90.iceGo, 0);\n\tv585 = ~v579;\nL_FFFFFFFF:\n\tv384 = v391;\nL_FFFFFFFF:\n\tv385 = v95;\nL_FFFFFFFF:\n\tv264 = 0;\n\tif (v585) goto L_004E;\nL_FFFFFFFF:\n\tv264 = 0;\n\tgoto L_0180;\nL_0180:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v90.iceGo);\n\tv90.iceGo = 0;\n\tv90.mono = 0;\nL_FFFFFFFF:\n\tv384 = v391;\nL_FFFFFFFF:\n\tv385 = v95;\n\tgoto L_004E;\nL_019D:\n\treturn;\nL_0050:\n\tv429 = *([v201 @ X0_v8 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv457 = *([v429 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv311 = *([v429 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v311) goto L_0070;\nL_005B:\n\tv470 = *([v297 @ X10_v14-8]) == *([v418 @ X22_v7 (System.Int32)]);\n\tif (v470) goto L_0083;\nL_00A1:\n\tv549 = *([v544 @ X10_v9-8]) == *([v417 @ X28_v7 (System.Int32)]);\n\tif (v549) goto L_00B9;\nL_00C0:\n\t*([v560 @ X0_v11])(v563, v201, v184, *([v560 @ X0_v11+8]), v391, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_004E:\n\tv184 = v184 + 1;\nL_011C:\n\tv616 = v385 & 0xFFFFFFFF00000000;\n\tv95 = v563 | v616;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::PlayVfx(this, v192, v592);\nL_015A:\n\tv652 = v121 & 0xFFFFFFFF00000000;\n\tv391 = v563 | v652;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::PlayVfx(this, v194, v592);\n")]
		public unsafe void RefreshDynamic()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenVisualHandler::RefreshDynamic");
		}

		[Token(Token = "0x60009C3")]
		[Address(RVA = "0x3E9B074", Offset = "0x3E9B074", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv75 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv84 = v75 == 0;\n\tif (v84) goto L_0047;\n\tgoto L_0060;\nL_0047:\n\tgoto L_004B;\nL_004B:\n\tv113 = UnityEngine.Object::op_Equality(this._parent, 0);\n\tv116 = v113 == 0;\n\tif (v116) goto L_0070;\nL_0060:\n\treturn;\nL_0070:\n\tVector3_arg = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, coord);\n\tv294 = this._vfxPool == 0;\n\tif (v294) goto L_00B5;\n\tgoto L_0093;\nL_00B5:\n\tgoto L_00DD;\nL_0093:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Quaternion_arg @ V3_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v309.identity (UnityEngine.Quaternion), v309.identity.y (System.Single), v309.identity.z (System.Single), v309.identity.w (System.Single)\n\tinterfaceTailCallResult = _game.CoreSystem.Pooling.IVfxPool::Rent(this._vfxPool, prefab, Vector3_arg, Quaternion_arg, this._parent);\nL_FFFFFFFF:\n\treturn;\nL_00DD:\n\t// 221 MakeStruct v140 @ AGG3E9B2B0_2_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v329.identity (UnityEngine.Quaternion), v329.identity.y (System.Single), v329.identity.z (System.Single), v329.identity.w (System.Single)\n\tv242 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(prefab, Vector3_arg, v140, this._parent);\n\treturn;\n")]
		private void PlayVfx(GameObject prefab, GridCoord coord)
		{
			if (!(prefab == null) && !(_parent == null))
			{
				Vector3 vector = _visualGrid.GridToWorld(coord);
				if (_vfxPool != null)
				{
					Quaternion worldRot = default(Quaternion);
					worldRot.x = Quaternion.identity.x;
					worldRot.y = Quaternion.identity.y;
					worldRot.z = Quaternion.identity.z;
					worldRot.w = Quaternion.identity.w;
					GameObject gameObject = _vfxPool.Rent(prefab, vector, worldRot, _parent);
				}
				else
				{
					Quaternion rotation = default(Quaternion);
					rotation.x = Quaternion.identity.x;
					rotation.y = Quaternion.identity.y;
					rotation.z = Quaternion.identity.z;
					rotation.w = Quaternion.identity.w;
					GameObject gameObject2 = VisualHandlerUtility.Instantiate(prefab, vector, rotation, _parent);
				}
			}
		}

		[Token(Token = "0x60009C4")]
		[Address(RVA = "0x3E9B314", Offset = "0x3E9B314", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>();\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler+State>::.ctor(v48);\n\tthis._states = v48;\n")]
		public FrozenVisualHandler()
		{
			Dictionary<EntityId, State> states = new Dictionary<EntityId, State>();
			_states = states;
		}
	}
}
