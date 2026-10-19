using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.CollisionSystem.ECS.Tags;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems
{
	[Token(Token = "0x2000161")]
	public class SandReconcile_TunnelSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x400046A")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400046B")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x400046C")]
		[FieldOffset(Offset = "0x20")]
		private TunnelConfig _config;

		[Token(Token = "0x60006C1")]
		[Address(RVA = "0x3E54B18", Offset = "0x3E54B18", Length = "0x808")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005E;\nL_005E:\n\tv67 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv854 = 0xB285000 + 0x5F8;\n\tv362 = *([v67 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv491 = *([v362 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv364 = *([v362 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v364) goto L_0089;\n\tv490 = *([v362 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv490 = v490 + 0x10;\n\tv473 = v491 - 1;\n\tv453 = v491 != 1;\nL_FFFFFFFF:\n\tv491 = v473;\n\tif (v453) goto L_0070;\nL_0089:\n\tv504 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v67);\n\tv505 = v504 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_009E;\n\tgoto L_02FD;\nL_008F:\n\tv512 = *([v490 @ X10_v43]) << 4;\n\tv513 = v362 + v512;\n\tv514 = v513 + 0x138;\n\t*([v514 @ X0_v111])(v518, v67, *([v514 @ X0_v111+8]), v41, v626, v1007, v44, v45, v46, v833, v48, v49, v50, v51, v52, v53, v54);\n\tv519 = v518 == 0;\n\tif (v519) goto L_02FD;\nL_009E:\n\tgoto L_00A1;\nL_00A1:\n\tv581 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv589 = ~v581;\n\tv590 = ~v589;\nL_FFFFFFFF:\n\tv885 = 0;\n\tif (v590) goto L_00B1;\nL_FFFFFFFF:\n\tv142 = 0;\nL_FFFFFFFF:\n\tv885 = 0;\n\tgoto L_00B7;\nL_00B1:\n\tv329 = this._config;\nL_FFFFFFFF:\n\tv142 = v329.tunnelTweenSettings;\nL_00BA:\n\tv854 = 0xB285000 + 0x5F8;\nL_FFFFFFFF:\n\tv833 = v142;\nL_FFFFFFFF:\n\tv834 = v837;\n\tv568 = *([v667 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv568 = v568 + 0x10;\n\tv693 = v709 - 1;\n\tv675 = v709 != 1;\nL_FFFFFFFF:\n\tv709 = v693;\n\tif (v675) goto L_00CA;\nL_00DF:\n\tv695 = 0x220C5E0(v67, *([v854 @ X25_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v695 @ X0_v95])(v574, v67, *([v695 @ X0_v95+8]), 0, v626, v1007, v44, v45, v46, v833, v48, v49, v50, v51, v52, v53, v54);\n\tv549 = v139 < v574;\n\tif (v549) goto L_010A;\n\tgoto L_02FD;\nL_00F2:\n\tv546 = *([v568 @ X10_v38]) << 4;\n\tv726 = v667 + v546;\n\tv727 = v726 + 0x138;\n\t*([v727 @ X0_v98])(v575, v67, *([v727 @ X0_v98+8]), v885, v626, v1007, v44, v45, v46, v833, v48, v49, v50, v51, v52, v53, v54);\n\tv550 = v139 >= v575;\n\tif (v550) goto L_02FD;\nL_010A:\n\tgoto L_0131;\n\tv825 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v821);\n\tv829 = ~v825;\nL_FFFFFFFF:\n\tv885 = 0;\n\tif (v829) goto L_00BD;\n\tv885 = *([v631 @ X23_v7 (System.Int32)]);\n\tv858 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v821);\n\tv861 = ~v858;\n\tif (v861) goto L_00BD;\n\tv866 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v821);\n\tv870 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v821);\n\tv872 = v821 & 0xFFFFFFFF;\n\tv873 = v629 & 0xFFFFFFFF00000000;\n\tv629 = v873 | v872;\n\tv875 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem::GetTargetCoord(v866, v870);\n\tv878 = v629 & 0xFFFFFFFF;\n\tv879 = v627 & 0xFFFFFFFF00000000;\n\tv155 = v879 | v878;\n\tv880 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsValidCoord(this._gridHandler, v875);\n\tv881 = ~v880;\nL_FFFFFFFF:\n\tv837 = 0;\nL_FFFFFFFF:\n\tv885 = v155;\n\tif (v881) goto L_00BC;\n\tv910 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetCellAt(this._gridHandler, v875);\n\tv903 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v910);\n\tv906 = ~v903;\nL_FFFFFFFF:\n\tv837 = 0;\nL_FFFFFFFF:\n\tv885 = 0;\n\tif (v906) goto L_00BC;\n\tv335 = v834 & 0xFFFFFFFF00000000;\n\tv837 = v629 | v335;\n\tv904 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem::IsCellAvailable(this, v910, v875, v142);\n\tv907 = ~v904;\nL_FFFFFFFF:\n\tv833 = v142;\nL_FFFFFFFF:\n\tv834 = v837;\nL_FFFFFFFF:\n\tv885 = v875;\n\tif (v907) goto L_00BC;\n\tv283 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::FindNextSlot(this._em, v821);\n\tv917 = *([v283 @ X0_v36 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv960 = *([v917 @ X8_v33 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv919 = *([v917 @ X8_v33 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v919) goto L_01BB;\n\tv959 = *([v917 @ X8_v33 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv959 = v959 + 0x10;\n\tv945 = v960 - 1;\n\tv925 = v960 != 1;\nL_FFFFFFFF:\n\tv960 = v945;\n\tif (v925) goto L_01A2;\nL_01BB:\n\tv973 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v283);\n\tv974 = v973 == 0;\n\tv975 = ~v974;\nL_FFFFFFFF:\n\tv1012 = 0;\n\tif (v975) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv885 = 0;\n\tgoto L_00BA;\nL_01C1:\n\tv978 = *([v959 @ X10_v27]) << 4;\n\tv979 = v917 + v978;\n\tv980 = v979 + 0x138;\n\t*([v980 @ X0_v87])(v984, v283, *([v980 @ X0_v87+8]), v875, v837, v1007, v44, v45, v46, v142, v48, v49, v50, v51, v52, v53, v54);\n\tv985 = v984 == 0;\nL_FFFFFFFF:\n\tv885 = v875;\nL_FFFFFFFF:\n\tv1012 = v875;\n\tif (v985) goto L_00BA;\nL_FFFFFFFF:\n\tv1009 = v837;\nL_FFFFFFFF:\n\tv127 = 0;\n\tgoto L_01D7;\nL_01D2:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v1210, v821);\nL_FFFFFFFF:\n\tv1007 = 0;\nL_FFFFFFFF:\n\tv1009 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv1012 = v821;\nL_01D3:\n\tv127 = v127 + 1;\n\tv1079 = *([v1037 @ X8_v38 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv1079 = v1079 + 0x10;\n\tv1065 = v1080 - 1;\n\tv1045 = v1080 != 1;\nL_FFFFFFFF:\n\tv1080 = v1065;\n\tif (v1045) goto L_01E2;\nL_01FB:\n\tv1093 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v283);\n\tv1104 = v127 < v1093;\n\tif (v1104) goto L_0222;\n\tgoto L_02DD;\nL_020A:\n\tv1107 = *([v1079 @ X10_v22]) << 4;\n\tv1108 = v1037 + v1107;\n\tv1109 = v1108 + 0x138;\n\t*([v1109 @ X0_v80])(v1113, v283, *([v1109 @ X0_v80+8]), v1012, v1009, v1007, v44, v45, v46, v142, v48, v49, v50, v51, v52, v53, v54);\n\tv1123 = v127 >= v1113;\n\tif (v1123) goto L_02DD;\nL_0222:\n\tgoto L_0249;\n\tv1211 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v1210);\n\tv1213 = ~v1211;\nL_FFFFFFFF:\n\tv1012 = 0;\n\tif (v1213) goto L_01D3;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v1210);\n\tv338 = v1008 & 0xFFFFFFFF00000000;\n\tv1008 = v338 | v629;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v1210, v875);\n\tv1222 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1210);\n\tv1224 = v1222 == 0;\n\tv1225 = ~v1224;\nL_FFFFFFFF:\n\tv113 = v1008;\n\tif (v1225) goto L_0282;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v1210, 0);\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\nL_0282:\n\tv1234 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1210);\n\tv1236 = v1234 == 0;\n\tv1237 = ~v1236;\n\tif (v1237) goto L_0297;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v1210, 0);\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\nL_0297:\n\tv1246 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1210);\n\tv1248 = v1246 == 0;\n\tv1249 = ~v1248;\n\tif (v1249) goto L_02AC;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v1210, 0);\nL_FFFFFFFF:\n\tv113 = Il2CppMethodInfo;\nL_02AC:\n\tv1258 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1210);\n\tv1259 = ~v1258;\n\tif (v1259) goto L_02CB;\n\tv1264 = _game.B\n// ... truncated")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_TunnelSystem::Execute");
		}

		[Token(Token = "0x60006C2")]
		[Address(RVA = "0x3E553E4", Offset = "0x3E553E4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tv63 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::HasPrimaryAt(this._gridHandler, coord);\n\tv82 = v63 == 0;\n\tif (v82) goto L_0041;\n\treturn 0;\nL_0041:\n\tv161 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, cell);\n\tv162 = ~v161;\n\tif (v162) goto L_0075;\n\tv164 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, cell);\n\tv111 = spawnTweenDuration == spawnTweenDuration;\n\tv166 = spawnTweenDuration < spawnTweenDuration;\n\tv108 = ~v166;\n\tv168 = ~v108;\n\tv96 = v168 | v111;\n\treturn v96;\nL_0075:\n\treturnVal4 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, cell);\n\treturn returnVal4;\n")]
		private bool IsCellAvailable(Entity cell, GridCoord coord, float spawnTweenDuration)
		{
			if (_gridHandler.HasPrimaryAt(coord))
			{
				return false;
			}
			if (_em.HasComponent<CellTransitionLockComponent>(cell))
			{
				CellTransitionLockComponent component = _em.GetComponent<CellTransitionLockComponent>(cell);
				bool flag = spawnTweenDuration == spawnTweenDuration;
				bool flag2 = spawnTweenDuration < spawnTweenDuration;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				return flag4 || flag;
			}
			return _em.HasComponent<CellStateChangedThisTickTag>(cell);
		}

		[Token(Token = "0x60006C3")]
		[Address(RVA = "0x3E55320", Offset = "0x3E55320", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv118 = tunnelCoord.y;\n\tv23 = direction > 1;\n\tif (v23) goto L_002B;\n\tv24 = direction == 0;\n\tif (v24) goto L_004B;\n\tv43 = direction != 1;\n\tif (v43) goto L_0048;\n\tv118 = v118 + 1;\nL_FFFFFFFF:\n\tv105 = &v48 @ stack_-20_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\n\tgoto L_FFFFFFFF;\nL_002B:\n\tv29 = direction == 2;\n\tif (v29) goto L_0051;\n\tv58 = direction != 3;\n\tif (v58) goto L_0048;\n\tv119 = tunnelCoord + 1;\nL_FFFFFFFF:\n\tv105 = &v48 @ stack_-20_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\n\tgoto L_0054;\nL_0048:\n\treturn tunnelCoord;\nL_004B:\n\tv118 = v118 - 1;\nL_FFFFFFFF:\n\tv105 = &v48 @ stack_-20_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\nL_0051:\n\tv119 = tunnelCoord - 1;\nL_FFFFFFFF:\n\tv105 = &v48 @ stack_-20_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\nL_FFFFFFFF:\n\tv119 = tunnelCoord;\n\tgoto L_0054;\nL_0054:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(v105, v119, v118);\n\treturn v48;\n")]
		private unsafe static GridCoord GetTargetCoord(GridCoord tunnelCoord, TunnelDirection direction)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_TunnelSystem::GetTargetCoord");
			return default;
		}

		[Token(Token = "0x60006C4")]
		[Address(RVA = "0x3E53AFC", Offset = "0x3E53AFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_TunnelSystem()
		{
		}
	}
}
