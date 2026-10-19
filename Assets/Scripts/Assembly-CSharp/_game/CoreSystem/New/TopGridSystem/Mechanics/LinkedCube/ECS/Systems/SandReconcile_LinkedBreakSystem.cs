using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.SandSystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems
{
	[Token(Token = "0x20001D8")]
	public class SandReconcile_LinkedBreakSystem : IEcsSystem
	{
		[Token(Token = "0x40005B3")]
		public const float LayerInterval = 0.2f;

		[Inject(false)]
		[Token(Token = "0x40005B4")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40005B5")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40005B6")]
		[FieldOffset(Offset = "0x20")]
		private GridData<SandCubeCellData> _gridData;

		[Token(Token = "0x6000875")]
		[Address(RVA = "0x3E7DB1C", Offset = "0x3E7DB1C", Length = "0xA2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_008A;\nL_008A:\n\tv70 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv395 = *([v70 @ X0_v21 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv558 = *([v395 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv397 = *([v395 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v397) goto L_00B1;\n\tv557 = *([v395 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv557 = v557 + 0x10;\n\tv426 = v558 - 1;\n\tv406 = v558 != 1;\n\tv558 = v426;\n\tif (v406) goto L_009C;\nL_00B1:\n\tv429 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v70, System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv429.m_value(v571, v70, *([v429 @ X0_v130 (System.Boolean)+8]), 0, v800, v1147, v40, v41, v42, 0, v44, v45, v46, v47, v48, v49, v50);\n\tv572 = v571 == 0;\n\tv573 = ~v572;\n\tv805 = 0;\n\tif (v573) goto L_00C5;\n\tgoto L_034B;\nL_00BB:\n\tv590 = *([v557 @ X10_v39]) << 4;\n\tv591 = v395 + v590;\n\tv592 = v591 + 0x138;\n\t*([v592 @ X0_v133])(v596, v70, *([v592 @ X0_v133+8]), v805, v800, v1147, v40, v41, v42, 0, v44, v45, v46, v47, v48, v49, v50);\n\tv597 = v596 == 0;\n\tif (v597) goto L_034B;\nL_00C5:\n\tv617 = this._gridData == 0;\n\tif (v617) goto L_034B;\n\tv710 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(v710);\n\tv778 = new System.Collections.Generic.Queue`1<System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>>();\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>>::.ctor(v778);\n\tv128 = 0;\n\tgoto L_00E5;\nL_00E1:\n\tv128 = v128 + 1;\n\tv886 = *([v838 @ X8_v28 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv886 = v886 + 0x10;\n\tv869 = v887 - 1;\n\tv849 = v887 != 1;\n\tv887 = v869;\n\tif (v849) goto L_00F0;\nL_0105:\n\tv872 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v70, System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv872.m_value(v900, v70, *([v872 @ X0_v123 (System.Boolean)+8]), 0, v800, v1147, v40, v41, v42, 0, v44, v45, v46, v47, v48, v49, v50);\n\tv911 = v128 < v900;\n\tif (v911) goto L_0130;\n\tgoto L_01AF;\nL_0118:\n\tv917 = *([v886 @ X10_v34]) << 4;\n\tv918 = v838 + v917;\n\tv919 = v918 + 0x138;\n\t*([v919 @ X0_v126])(v923, v70, *([v919 @ X0_v126+8]), v805, v800, v1147, v40, v41, v42, 0, v44, v45, v46, v47, v48, v49, v50);\n\tv933 = v128 >= v923;\n\tif (v933) goto L_01AF;\nL_0130:\n\tgoto L_0157;\n\tv1063 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v1036);\n\tv1086 = ~v1063;\n\tv805 = 0;\n\tif (v1086) goto L_00E1;\n\tv1109 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1036);\n\tv1113 = ~v1109;\n\tv805 = Il2CppMethodInfo;\n\tif (v1113) goto L_00E1;\n\tv1110 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v1036);\n\tv157 = v1110 < 1;\n\tv805 = Il2CppMethodInfo;\n\tif (v157) goto L_00E1;\n\tv260 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v1036);\n\tv1111 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::ContainsKey(v710, v260);\n\tv1395 = v1111 == 0;\n\tv1114 = ~v1395;\n\tv800 = Il2CppMethodInfo;\n\tv805 = v1036;\n\tif (v1114) goto L_00E1;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::set_Item(v710, v260, 0);\n\tSystem.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(&v95 @ stack_-D0_v17 (System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>), v260, 0);\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>>::Enqueue(v778, v95);\n\tv1147 = Il2CppMethodInfo;\n\tv800 = Il2CppMethodInfo;\n\tv805 = 0;\n\tgoto L_00E1;\nL_01AF:\n\tv688 = v778.Count == 0;\n\tif (v688) goto L_034B;\n\tv1026 = v778.Count < 1;\n\tif (v1026) goto L_0284;\n\tgoto L_01D5;\nL_01CF:\n\tv1047 = v778.Count <= 0;\n\tif (v1047) goto L_0284;\nL_01D5:\n\tv1079 = System.Collections.Generic.Queue`1<System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>>::Dequeue(v778);\n\tv1151 = v1079 >> 0x20;\n\tv263 = _game.CoreSystem.SandSystem.LinkedSandCubeUtility::GetPartners(this._gridData, v1079, v1151);\n\tv121 = Il2CppMethodInfo >> 0x20;\n\tv1044 = 0;\n\tv130 = 0;\n\tgoto L_01E6;\nL_01E4:\n\tv130 = v130 + 1;\n\tv1223 = *([v1173 @ X8_v74 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<System.ValueTuple`2<System.Int32, System.Int32>>>)+B0]) + 8;\n\tv1223 = v1223 + 0x10;\n\tv1205 = v1224 - 1;\n\tv1185 = v1224 != 1;\n\tv1224 = v1205;\n\tif (v1185) goto L_01F1;\nL_020A:\n\tv1237 = System.Collections.Generic.IReadOnlyCollection`1<System.ValueTuple`2<System.Int32, System.Int32>>::get_Count(v263);\n\tv1248 = v130 < v1237;\n\tif (v1248) goto L_022F;\n\tgoto L_01CF;\nL_0219:\n\tv1258 = *([v1223 @ X10_v21]) << 4;\n\tv1259 = v1173 + v1258;\n\tv1260 = v1259 + 0x138;\n\t*([v1260 @ X0_v97])(v1264, v263, *([v1260 @ X0_v97+8]), v1151, v1044, v1147, v40, v41, v42, 0, v44, v45, v46, v47, v48, v49, v50);\n\tv1274 = v130 >= v1264;\n\tif (v1274) goto L_01CF;\nL_022F:\n\tgoto L_0256;\n\tv1403 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::ContainsKey(v710, v80);\n\tv1414 = v1403 == 0;\n\tv1169 = ~v1414;\n\tv1044 = Il2CppMethodInfo;\n\tv1151 = 0;\n\tif (v1169) goto L_01E4;\n\tv1422 = v121 + 1;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::set_Item(v710, v80, v1422);\n\tv1435 = v121 + 1;\n\tSystem.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(&v1425 @ stack_-D0_v14 (System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>), v80, v1435);\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>>::Enqueue(v778, v1425);\n\tv1147 = Il2CppMethodInfo;\n\tv1044 = Il2CppMethodInfo;\n\tv1151 = 0;\n\tgoto L_01E4;\nL_0284:\n\tv1085 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::GetEnumerator(v710);\n\tv307 = v1085;\n\tv350 = v1175 >> 0x20;\n\tv1128 = v350 == 0;\n\tif (v1128) goto L_02A6;\n\tv381 = this._gridHandler == 0;\n\tif (v381) goto L_034D;\n\tv1250 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(this._gridHandler, *([v1085 @ X0_v31 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>)+10]));\n\tgoto L_02C1;\nL_02C1:\n\tv1123 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v433 @ stack_-A8_v7 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv1129 = v1123 == 0;\n\tif (v1129) goto L_02A6;\n\tv520 = this._em == 0;\n\tif (v520) goto L_034F;\n\tv1124 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v433);\n\tv1130 = v1124 == 0;\n\tif (v1130) goto L_02A6;\n\tv521 = this._em == 0;\n\tif (v521) goto L_0351;\n\tv1125 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v433);\n\tv1437 = v1125 == 0;\n\tv1131 = ~v1437;\n\tif (v1131) goto L_02A6;\n\tv522 = this._em == 0;\n\tif (v522) goto L_0353;\n\tv1441 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v433);\n\tv1443 = v1441 == 0;\n\tv499 = v433;\n\tif (v1443) goto L_02F1;\n\tv528 = this._em == 0;\n\tif (v528) goto L_035F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v433);\n\tv499 = v433;\nL_02F1:\n\tv523 = this._em == 0;\n\tif (v523) goto L_0355;\n\tv1455 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v433\n// ... truncated")]
		public unsafe void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_LinkedBreakSystem::Execute");
		}

		[Token(Token = "0x6000876")]
		[Address(RVA = "0x3E7A3F8", Offset = "0x3E7A3F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_LinkedBreakSystem()
		{
		}
	}
}
