using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Extensions;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.BaseLayerSystems.EntitySystem.Serialization;
using _game.CoreSystem.CollisionSystem.ECS.Tags;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.TopGridSystem.Core.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Wall.ECS.Tags;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.Core.Handlers
{
	[Token(Token = "0x2000274")]
	public class TopGridEntitySystemCreator
	{
		[Token(Token = "0x2000275")]
		private class LegacyCoverGroup
		{
			[Token(Token = "0x40007C4")]
			[FieldOffset(Offset = "0x10")]
			public int groupId;

			[Token(Token = "0x40007C5")]
			[FieldOffset(Offset = "0x14")]
			public int counter;

			[Token(Token = "0x40007C6")]
			[FieldOffset(Offset = "0x18")]
			public int minX;

			[Token(Token = "0x40007C7")]
			[FieldOffset(Offset = "0x1C")]
			public int maxX;

			[Token(Token = "0x40007C8")]
			[FieldOffset(Offset = "0x20")]
			public int minY;

			[Token(Token = "0x40007C9")]
			[FieldOffset(Offset = "0x24")]
			public int maxY;

			[Token(Token = "0x6000AEC")]
			[Address(RVA = "0x3EC1110", Offset = "0x3EC1110", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public LegacyCoverGroup()
			{
			}
		}

		[Inject(false)]
		[Token(Token = "0x40007C0")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40007C1")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40007C2")]
		[FieldOffset(Offset = "0x20")]
		private GridData<SandCubeCellData> _gridData;

		[Token(Token = "0x40007C3")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<GridCoord, int> _resolvedLinkedGroupIds;

		[Inject(false)]
		[Token(Token = "0x6000AD6")]
		[Address(RVA = "0x3EBF60C", Offset = "0x3EBF60C", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\t_game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::EnsureCellsArray(this._gridData);\n\tv160 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v160, this._em);\n\tv299 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v160, 0);\n\tv350 = this._gridData;\n\tv326 = v350.rows | v350.columns;\n\tv333 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v299, v326);\n\tv334 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v333, 0xB);\n\tv335 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v334.Entity);\n\tv354 = this._gridData;\n\tv377 = v354.cells;\n\tv378 = v354.cells == 0;\n\tif (v378) goto L_0179;\n\tv379 = v335.columns * v335;\n\tv391 = v379 > v377.Length;\n\tif (v391) goto L_0179;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::ConvertLegacyCoverBlockersToGarages(this, v335);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::ResolveLinkedCubeGroups(this, v335);\n\tv222 = v335.columns < 1;\n\tif (v222) goto L_FFFFFFFF;\n\tv453 = v335 - 1;\n\tv418 = v453 < 0;\n\tv456 = v335 ^ 1;\n\tv457 = v335 ^ v453;\n\tv458 = v456 & v457;\n\tv408 = v458 < 0;\n\tgoto L_00B0;\nL_FFFFFFFF:\n\tv408 = 0;\nL_FFFFFFFF:\n\tv418 = 1;\n\tv216 = v335 & 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv219 = 0;\n\tgoto L_FFFFFFFF;\nL_00B6:\n\tv219 = v219 + 1;\n\tv484 = v219 == v335.columns;\n\tif (v484) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv274 = v219;\n\tgoto L_00D8;\nL_00CB:\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v582, v619);\nL_00CC:\n\tv213 = v213 + 1;\n\tv274 = v274 + v335.columns;\n\tv512 = v216 == v213;\n\tif (v512) goto L_00B6;\nL_00D8:\n\tv355 = this._gridData;\n\tv283 = v355.cells;\n\tv520 = v283[v274 @ X21_v12 (System.Int32)];\n\tv521 = v283[v274 @ X21_v12 (System.Int32)] == 0;\n\tif (v521) goto L_00CC;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v302 @ stack_-70_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v219, v213);\n\tv541 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(v520.components);\n\tv544 = v541 == 0;\n\tv545 = ~v544;\n\tif (v545) goto L_010D;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreatePrimaryForCell(this, v302, v283[v274 @ X21_v12 (System.Int32)]);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateOverlaysForCell(this, v302, v283[v274 @ X21_v12 (System.Int32)]);\nL_010D:\n\tv534 = v520.entity == 0;\n\tif (v534) goto L_00CC;\n\tv582 = _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity::ToEntity(v520.entity, this._em);\n\tv532 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v582);\n\tv535 = ~v532;\n\tif (v535) goto L_00CC;\n\tv619 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v582);\n\tv620 = this._gridHandler == 0;\n\tv339 = ~v620;\n\tif (v339) goto L_00CB;\n\tthrow System.NullReferenceException;\nL_0131:\n\tgoto L_0144;\nL_0144:\n\tUnityEngine.Debug::LogError(\"[SandCubeEntitySystemCreator] GridData<SandCubeCellData> is null — nothing to spawn.\");\n\treturn;\nL_FFFFFFFF:\n\tv578 = 0;\n\tv578 = v578 + 1;\n\tv406 = v578 != v335.columns;\n\tif (v406) goto L_FFFFFFFF;\nL_0179:\n\treturn;\nL_003D:\n\tv60 = this._gridData == 0;\n\tif (v60) goto L_0131;\nL_00B0:\n\tv464 = v418 == v408;\n\tv228 = ~v464;\n\tif (v228) goto L_0179;\nL_014C:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v392 @ stack_-80_v5 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v578, v585);\n\tv433 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateCellEntity(this, v392);\n\tv585 = v585 + 1;\n\tv587 = v335 != v585;\n\tif (v587) goto L_014C;\nL_FFFFFFFF:\n\tv585 = 0;\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::Construct");
		}

		[Token(Token = "0x6000AD7")]
		[Address(RVA = "0x3EC1000", Offset = "0x3EC1000", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv68 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v53, 0);\n\tv74 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::HasPrimaryAt(this._gridHandler, coord);\n\tv75 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v68, v74);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v75.Entity, coord);\n\treturn v75.Entity;\nL_0023:\n\tv53 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v53, this._em);\n")]
		private Entity CreateCellEntity(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateCellEntity");
			return default;
		}

		[Token(Token = "0x6000AD8")]
		[Address(RVA = "0x3EBF9F0", Offset = "0x3EBF9F0", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv88 = v521 < 1;\n\tif (v88) goto L_01AE;\n\tv265 = v521 & 0x7FFFFFFF;\n\tv187 = 0xB2C1000 + 0x4D8;\n\tv184 = 0xB2D6000 + 0xC18;\nL_FFFFFFFF:\n\tv190 = v265;\nL_FFFFFFFF:\n\tv342 = 0;\nL_FFFFFFFF:\n\tv501 = 0;\n\tgoto L_FFFFFFFF;\nL_0065:\n\tv342 = v342 + 1;\n\tv211 = v342 == v164.columns;\nL_FFFFFFFF:\n\tv521 = v164;\n\tif (v211) goto L_0163;\nL_FFFFFFFF:\n\tv375 = v342;\nL_FFFFFFFF:\n\tv376 = 0;\n\tgoto L_0091;\nL_0073:\n\t;\n\tv482.groupId = *([v418 @ stack_-68_v9+10]);\n\tv482.minX = v342;\n\tv482.maxX = v342;\n\tv482.minY = v376;\n\tv482.maxY = v376;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>::set_Item(v501, *([v418 @ stack_-68_v9+10]), v482);\nL_FFFFFFFF:\n\tv164 = *([v418 @ stack_-68_v9+10]);\nL_FFFFFFFF:\n\tv190 = v265;\nL_0091:\n\tv404 = this._gridData;\n\tv409 = v404.cells;\n\tv507 = v409[v375 @ X24_v5 (System.Int32)];\n\tv551 = v409[v375 @ X24_v5 (System.Int32)] == 0;\nL_FFFFFFFF:\n\tv164 = v521;\n\tif (v551) goto L_0085;\n\tv164 = *([v187 @ X26_v10 (System.Int32)]);\n\tv578 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty /* +1 sharing this address */(v507.components, *([v187 @ X26_v10 (System.Int32)]));\n\tv619 = v578 & 1;\n\tv620 = v619 == 0;\n\tv609 = ~v620;\n\tif (v609) goto L_0085;\n\tv608 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp /* +1 sharing this address */(v409[v375 @ X24_v5 (System.Int32)], &v418 @ stack_-68_v9, *([v184 @ X22_v10 (System.Int32)]));\n\tv610 = v608 == 0;\nL_FFFFFFFF:\n\tv164 = &v418 @ stack_-68_v9;\n\tif (v610) goto L_0085;\n\tv642 = v501 == 0;\n\tv643 = ~v642;\nL_FFFFFFFF:\n\t;\n\tif (v643) goto L_00C5;\n\tv648 = new System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>::.ctor(v648);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv501 = v648;\nL_00C5:\n\t;\n\tv481 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>::TryGetValue(v501, *([v418 @ stack_-68_v9+10]), &v416 @ stack_-70_v9 (_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup));\n\tv683 = v481 == 0;\n\tif (v683) goto L_0114;\n\tv697 = v342 < v416.minX;\n\tif (v697) goto L_0123;\n\tv717 = v342 > v416.maxX;\n\tif (v717) goto L_0132;\nL_00F8:\n\tv758 = v376 < v416.minY;\n\tif (v758) goto L_013F;\nL_0106:\n\tv804 = v376 > v416.maxY;\n\tif (v804) goto L_014E;\nL_0109:\n\tv831 = v418 == 0;\n\tv488 = ~v831;\nL_FFFFFFFF:\n\tv834 = v418;\n\tif (v488) goto L_0152;\n\tgoto L_01AF;\nL_0114:\n\t;\n\tv482 = new _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup();\n\tSystem.Object::.ctor(v482);\n\tv829 = v482 == 0;\n\tv491 = ~v829;\n\tif (v491) goto L_0073;\n\tgoto L_01AF;\nL_0123:\n\tv416.minX = v342;\n\tv730 = v342 <= v416.maxX;\n\tif (v730) goto L_00F8;\nL_0132:\n\tv416.maxX = v342;\n\tv780 = v376 >= v416.minY;\n\tif (v780) goto L_0106;\nL_013F:\n\tv416.minY = v376;\n\tv828 = v376 <= v416.maxY;\n\tif (v828) goto L_0109;\nL_014E:\n\tv416.maxY = v376;\nL_FFFFFFFF:\n\tv834 = v418;\nL_0152:\n\t;\n\tv590 = *([v834 @ X9_v14+14]) <= v416.counter;\nL_FFFFFFFF:\n\tv164 = *([v418 @ stack_-68_v9+10]);\n\tif (v590) goto L_0085;\n\tv416.counter = *([v834 @ X9_v14+14]);\nL_FFFFFFFF:\n\tv164 = *([v418 @ stack_-68_v9+10]);\n\tgoto L_0085;\nL_0163:\n\tv228 = v501 == 0;\n\tif (v228) goto L_01AE;\n\tv483 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>::get_Values(v501);\n\tv658 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>+ValueCollection<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>::GetEnumerator(v483);\n\tv132 = v658._dictionary;\n\tv118 = v658.Current;\n\tv568 = v658.Current == 0;\nL_FFFFFFFF:\n\tv552 = 0;\nL_FFFFFFFF:\n\tv553 = Il2CppMethodInfo;\n\tif (v568) goto L_01B1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v669 @ stack_-98_v5 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v118.minX, v118.minY);\n\tv679 = v118.maxX - v118.minX;\n\tv671 = v118.maxY - v118.minY;\n\tv675 = v679 + 1;\n\tv665 = v671 + 1;\n\tv677 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateGarage(this, v669, v675, v665, v118.groupId, v118.counter);\n\tgoto L_017E;\nL_01A0:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v132 @ stack_-88_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>));\nL_01AE:\n\treturn;\nL_01AF:\n\tv509 = new System.NullReferenceException();\n\tv546 = new System.IndexOutOfRangeException();\nL_FFFFFFFF:\n\tv553 = v521;\nL_01B1:\n\tv572 = new System.NullReferenceException();\n\tgoto L_01C0;\nL_01C0:\n\tv197 = v553 != 1;\nL_FFFFFFFF:\n\tv321 = v572;\n\tif (v197) goto L_01D2;\n\tv629 = 0x8BF5BC4(v572, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv639 = 0x8BF5BF4(v629, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v132 @ stack_-88_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>));\n\tv229 = *([v629 @ X0_v14]) == 0;\n\tif (v229) goto L_01AE;\n\tv631 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv552 = *([v629 @ X0_v14]);\nL_FFFFFFFF:\n\tv321 = v631;\n\treturn;\nL_003F:\n\tv132 = 0;\n\tv74 = v164.columns < 1;\n\tif (v74) goto L_01AE;\nL_0085:\n\tv376 = v376 + 1;\n\tv375 = v375 + v164.columns;\n\tv390 = v190 == v376;\nL_FFFFFFFF:\n\tv521 = v164;\n\tif (v390) goto L_0065;\nL_017E:\n\tv566 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v132 @ stack_-88_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+LegacyCoverGroup>));\n\tv227 = v566 == 0;\n\tif (v227) goto L_01A0;\nL_01D2:\n\tv634 = 0x318F6C4(&v552 @ stack_-A8_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv641 = 0x8BF0368(v321, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv313 = 0xA1B8(v641, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ConvertLegacyCoverBlockersToGarages(GridComponent grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::ConvertLegacyCoverBlockersToGarages");
		}

		[Token(Token = "0x6000AD9")]
		[Address(RVA = "0x3EBFE40", Offset = "0x3EBFE40", Length = "0xC40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-A0;\n\tgoto L_008B;\n\tv100 = grid.columns < 1;\n\tif (v100) goto L_018D;\n\tv114 = grid < 1;\n\tif (v114) goto L_018D;\n\tv197 = grid & 0x7FFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv526 = 0;\nL_FFFFFFFF:\n\tv182 = v197;\n\tgoto L_FFFFFFFF;\nL_00C3:\n\tv526 = v606 + 1;\n\tv162 = v526 == grid.columns;\nL_FFFFFFFF:\n\t;\n\tif (v162) goto L_018D;\nL_FFFFFFFF:\n\tv606 = v526;\nL_FFFFFFFF:\n\tv496 = 0;\n\tgoto L_00DC;\nL_00D1:\n\tv496 = v496 + 1;\n\tv601 = v496 == v182;\n\tif (v601) goto L_00C3;\nL_00DC:\n\tv464 = this._gridData;\n\tv465 = v464.cells;\n\tv584 = v496 * grid.columns;\n\tv334 = v606 + v584;\n\tv186 = v465[v334 @ X9_v17 (System.Int32)];\n\tv1125 = v465[v334 @ X9_v17 (System.Int32)] == 0;\n\tif (v1125) goto L_00D1;\n\tv1139 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(v186.components);\n\tv1167 = v1139 == 0;\n\tv1155 = ~v1167;\n\tif (v1155) goto L_00D1;\n\tv1154 = v186.components;\nL_FFFFFFFF:\n\tv314 = 0;\nL_FFFFFFFF:\n\tv491 = 0;\n\tgoto L_011C;\nL_010E:\n\tv491 = v491 + 1;\n\tv1154 = v186.components;\nL_011C:\n\tv359 = v491 >= v1154.Count;\n\tif (v359) goto L_0173;\n\tv1321 = System.Collections.Generic.List`1<_game.CoreSystem.LevelCreator.ICellComponent>::get_Item(v1154, v491);\n\tv1335 = v1321 == 0;\n\tif (v1335) goto L_010E;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v358_asT @ TEMPCOND_v28 (_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent), typeof(_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent), v1321 @ X0_v136 (_game.CoreSystem.LevelCreator.ICellComponent)\n\tv358 = v358_asT == 0;\n\tif (v358) goto L_010E;\n\tv1453 = v314 == 0;\n\tv1454 = ~v1453;\nL_FFFFFFFF:\n\tv439 = v1321;\n\tif (v1454) goto L_0154;\n\tv1476 = new System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>::.ctor(v1476);\nL_FFFFFFFF:\n\tv314 = v1476;\nL_FFFFFFFF:\n\tv439 = v1321;\nL_0154:\n\t;\n\tgoto L_0168;\nL_0168:\n\t;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>::Add(v314, v439);\n\tgoto L_010E;\nL_0173:\n\tv1156 = v314 == 0;\nL_FFFFFFFF:\n\tv606 = v526;\nL_FFFFFFFF:\n\tv182 = v197;\n\tif (v1156) goto L_00D1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v120 @ stack_-128 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v526, v496);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::set_Item(v81, v120, v314);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv606 = v526;\nL_FFFFFFFF:\n\tv182 = v197;\n\tgoto L_00D1;\nL_018D:\n\tv205 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::get_Count(v81);\n\tv534 = v205 == 0;\n\tif (v534) goto L_037E;\n\tv623 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::get_Count(v81);\n\tv844 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v844, v623);\n\tv1127 = &v120 @ stack_-128 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\n\tv1129 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::GetEnumerator(v81);\n\tv120 = v120.x;\n\tv1109 = &v31 @ stack_-A0;\n\t*([v1109 @ X8_v54]) = v120.x;\n\t*([v1109 @ X8_v54+10]) = *([v1127 @ X8_v53+10]);\n\t*([v1109 @ X8_v54+20]) = *([v1127 @ X8_v53+20]);\n\tv1021 = 0;\n\tv1162 = v844 == 0;\n\tif (v1162) goto L_01D4;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(v844, v1303, v1303);\nL_FFFFFFFF:\n\t;\n\tgoto L_01C6;\nL_01D4:\n\tv1172 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Object>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Object>::MoveNext(&v31 @ stack_-A0);\n\tv1204 = v1172 == 0;\n\tv1093 = ~v1204;\n\tif (v1093) goto L_03A7;\nL_01DB:\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Object>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Object>::Dispose(&v31 @ stack_-A0);\n\tv1309 = &v1021 @ stack_-128_v15 (System.Int32);\n\tv1311 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::GetEnumerator(v81);\n\tv290 = v1021.m_value;\n\tv1329 = &v31 @ stack_-A0;\n\t*([v1329 @ X8_v56]) = v1021.m_value;\n\t*([v1329 @ X8_v56+10]) = *([v1309 @ X8_v55+10]);\n\t*([v1329 @ X8_v56+20]) = *([v1309 @ X8_v55+20]);\n\tv821 = v1446 == 0;\n\tif (v821) goto L_03A3;\n\tv1459 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v1446);\n\tv1003 = *([v1459 @ X0_v109+10]);\n\tv978 = *([v1459 @ X0_v109]);\n\tv1090 = *([v1459 @ X0_v109+10]) == 0;\n\tif (v1090) goto L_0257;\n\tv1549 = *([v1003 @ stack_-118_v15+10]) & 0x80000000;\n\tv1550 = v1549 == 0;\n\tv1507 = ~v1550;\n\tif (v1507) goto L_021A;\n\tv1597 = *([v1003 @ stack_-118_v15+14]) & 0x80000000;\n\tv1598 = v1597 == 0;\n\tv1508 = ~v1598;\n\tif (v1508) goto L_021A;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v1490 @ stack_-D0_v13 (_game.CoreSystem.New.GridEcsBinding.GridCoord), *([v1003 @ stack_-118_v15+10]), *([v1003 @ stack_-118_v15+14]));\n\tv1504 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::ContainsKey(v81, v1490);\n\tv1509 = v1504 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v1509) goto L_021A;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::UnionCoords(v844, v1303, v1490);\nL_FFFFFFFF:\n\t;\n\tgoto L_021A;\nL_FFFFFFFF:\n\tv290 = 0;\n\tgoto L_01FE;\nL_FFFFFFFF:\n\tv290 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\tv461 = 0xF;\n\tgoto L_0274;\nL_0257:\n\tv1082 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv230 = &v31 @ stack_-A0;\nL_FFFFFFFF:\n\tv232 = 0;\nL_FFFFFFFF:\n\tv1019 = 0;\nL_FFFFFFFF:\n\tv1072 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv1080 = v1082;\nL_FFFFFFFF:\n\tv487 = v844;\n\tgoto L_03B6;\nL_FFFFFFFF:\n\tv461 = 0x13;\nL_027C:\n\tv399 = v461 == 0x13;\n\tif (v399) goto L_0288;\n\tv1434 = v461 == 0;\n\tv706 = ~v1434;\n\tif (v706) goto L_037E;\nL_0288:\n\tv1438 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(v1438);\n\tv441 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::get_Keys(v81);\n\tv1517 = &v290 @ stack_-128_v8 (System.Int32);\n\tv1518 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>+KeyCollection<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent>>::GetEnumerator(v441);\n\tv221 = v290.m_value;\n\tv1531 = v1438 == 0;\n\tif (v1531) goto L_02DE;\n\tv1626 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::FindCoord(v487, *([v1517 @ X8_v17+10]));\n\tv1639 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::TryGetValue(v1438, v1626, &v1555 @ stack_-F4_v11 (System.Int32));\n\tif (v1639) goto L_02D2;\nL_FFFFFFFF:\n\tv1559 = 1;\n\tgoto L_02D8;\nL_02D2:\n\tv1559 = v1555 + 1;\nL_02DE:\n\tv1545 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Object>+Key\n// ... truncated")]
		private unsafe void ResolveLinkedCubeGroups(GridComponent grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::ResolveLinkedCubeGroups");
		}

		[Token(Token = "0x6000ADA")]
		[Address(RVA = "0x3EC1548", Offset = "0x3EC1548", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv59 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, c);\n\tv61 = v59;\n\tv67 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v61 @ stack_-50_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), c);\n\tv69 = v67 == 0;\n\tv70 = ~v69;\n\tv120 = c;\n\tif (v70) goto L_0066;\n\tv133 = c;\n\tv155 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v133);\n\tv160 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v155);\n\tv61 = v160;\n\tv118 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v61 @ stack_-50_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v155);\n\tv119 = v118 == 0;\n\tv120 = v155;\n\tv133 = v155;\n\tif (v119) goto L_0037;\nL_0066:\n\treturn v120;\nL_0037:\n\tv140 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v133);\n\tv146 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v140);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(parent, v133, v146);\n")]
		private static GridCoord FindCoord(Dictionary<GridCoord, GridCoord> parent, GridCoord c)
		{
			GridCoord gridCoord = parent[c];
			GridCoord gridCoord2 = gridCoord;
			bool flag = gridCoord2.Equals(c);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			GridCoord result = c;
			if (!flag3)
			{
				GridCoord key = c;
				bool flag5;
				do
				{
					GridCoord key2 = parent[key];
					GridCoord value = parent[key2];
					parent[key] = value;
					GridCoord gridCoord3 = parent[key];
					GridCoord gridCoord4 = parent[gridCoord3];
					gridCoord2 = gridCoord4;
					bool flag4 = gridCoord2.Equals(gridCoord3);
					flag5 = !flag4;
					result = gridCoord3;
					key = gridCoord3;
				}
				while (flag5);
			}
			return result;
		}

		[Token(Token = "0x6000ADB")]
		[Address(RVA = "0x3EC1470", Offset = "0x3EC1470", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv71 = v69 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0045;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(parent, v65, v61);\nL_0045:\n\treturn;\nL_001F:\n\tv55 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::FindCoord(parent, v47);\n\tv61 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::FindCoord(parent, b);\n\tv69 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v65 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v61);\n")]
		private static void UnionCoords(Dictionary<GridCoord, GridCoord> parent, GridCoord a, GridCoord b)
		{
			GridCoord c = default(GridCoord);
			GridCoord gridCoord = FindCoord(parent, c);
			GridCoord gridCoord2 = FindCoord(parent, b);
			GridCoord key = default(GridCoord);
			if (!key.Equals(gridCoord2))
			{
				parent[key] = gridCoord2;
			}
		}

		[Token(Token = "0x6000ADC")]
		[Address(RVA = "0x3EC0A88", Offset = "0x3EC0A88", Length = "0x37C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv85 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateGarage(this, coord, v62.sizeX, v62.sizeY, v62.groupId, v62.counter);\nL_005C:\n\tv96 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v94 @ stack_-60_v5 (_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.LevelData.HammerAreaAnchorCellData));\n\tv276 = ~v96;\n\tif (v276) goto L_006E;\n\tv323 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateHammerArea(this, coord, v94.sizeX, v94.sizeY, v94.groupId, v94.counter);\nL_006E:\n\tv332 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::HasComp(cell);\n\tv338 = ~v332;\n\tif (v338) goto L_0086;\n\tv378 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateWall(this, coord);\nL_0080:\n\treturn;\nL_0086:\n\tv210 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v171 @ stack_-68_v5 (_game.CoreSystem.SandSystem.Components.TunnelEntryComponent));\n\tv409 = ~v210;\n\tif (v409) goto L_00E7;\n\tv211 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateTunnel(this, coord, v171.direction);\n\tv380 = v171.slots == 0;\n\tif (v380) goto L_0080;\n\tv243 = v171;\n\tv256 = 0;\n\tgoto L_00A4;\nL_00A0:\n\tv256 = v256 + 1;\n\tv243 = v171;\nL_00A4:\n\tv213 = v243.slots;\n\tv349 = v256 >= v213.Count;\n\tif (v349) goto L_0080;\n\tv439 = System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.TunnelSlotData>::get_Item(v213, v256);\n\tv442 = v439 == 0;\n\tif (v442) goto L_00A0;\n\tv447 = v439.entities;\n\tv445 = v439.entities == 0;\n\tif (v445) goto L_00A0;\n\tv449 = v447.Count == 0;\n\tif (v449) goto L_00A0;\n\tv236 = 0;\n\tgoto L_00CF;\nL_00C1:\n\tv236 = v236 + 1;\n\tv447 = v439.entities;\nL_00CF:\n\tv108 = v236 >= v447.Count;\n\tif (v108) goto L_00A0;\n\tv473 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity>::get_Item(v447, v236);\n\tv474 = v473 == 0;\n\tif (v474) goto L_00C1;\n\tv476 = _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity::ToEntity(v473, this._em);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v476, v211);\n\tgoto L_00C1;\nL_00E7:\n\tv216 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v102 @ stack_-70_v5 (_game.CoreSystem.SandSystem.Components.TunnelCubeComponent));\n\tv302 = ~v216;\n\tif (v302) goto L_011E;\n\tv217 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateTunnel(this, coord, v102.direction);\n\tv381 = v102.queue == 0;\n\tif (v381) goto L_0080;\n\tv247 = v102;\n\tv257 = 0;\n\tv104 = v257 >= v218.Count;\n\tif (v104) goto L_0080;\n\tv456 = System.Collections.Generic.List`1<_game.CoreSystem.GameColor>::get_Item(v218, v257);\n\tv209 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::EnqueueSandCube(this._em, v217, v456);\n\tv257 = v257 + 1;\n\tv459 = v102 == 0;\n\tv220 = ~v459;\n\tv247 = v102;\n\tif (v220) goto L_00FC;\n\tthrow System.NullReferenceException;\nL_011E:\n\tv315 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::HasComp(cell);\n\tv336 = ~v315;\n\tif (v336) goto L_0080;\n\tv346 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateSandCubeFromCell(this, coord, cell);\n\tgoto L_0080;\nL_0049:\n\tv64 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v62 @ stack_-58_v2 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData.GarageAnchorCellData));\n\tv68 = ~v64;\n\tif (v68) goto L_005C;\nL_00FC:\n\tv218 = v247.queue;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreatePrimaryForCell(GridCoord coord, SandCubeCellData cell)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreatePrimaryForCell");
		}

		[Token(Token = "0x6000ADD")]
		[Address(RVA = "0x3EC0E04", Offset = "0x3EC0E04", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv69 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateKey(this, coord, v56.lockColor);\nL_0034:\n\tv80 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v78 @ stack_-50_v3 (_game.CoreSystem.SandSystem.Components.LockComponent));\n\tv92 = ~v80;\n\tif (v92) goto L_0048;\n\tv98 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::CreateLock(this, coord, v78.lockColor);\nL_0048:\n\treturn;\nL_0024:\n\tv58 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v56 @ stack_-48_v2 (_game.CoreSystem.SandSystem.Components.KeyComponent));\n\tv61 = ~v58;\n\tif (v61) goto L_0034;\n")]
		private void CreateOverlaysForCell(GridCoord coord, SandCubeCellData cell)
		{
			if (TryGetComp<KeyComponent>(cell, out var value))
			{
				Entity entity = CreateKey(coord, value.lockColor);
			}
			if (TryGetComp<LockComponent>(cell, out var value2))
			{
				Entity entity2 = CreateLock(coord, value2.lockColor);
			}
		}

		[Token(Token = "0x6000ADE")]
		[Address(RVA = "0x3EC212C", Offset = "0x3EC212C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv73 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v54, 0);\n\tv80 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v73, 0);\n\tv81 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v80, color);\n\tv82 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v81, 0);\n\tv83 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v82, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v83.Entity, coord);\n\treturn v83.Entity;\nL_002D:\n\tv54 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v54, this._em);\n")]
		public Entity CreateSandCube(GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateSandCube");
			return default;
		}

		[Token(Token = "0x6000ADF")]
		[Address(RVA = "0x3EC19F4", Offset = "0x3EC19F4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv68 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v53, 0);\n\tv72 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v68, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v72.Entity, coord);\n\treturn v72.Entity;\nL_0023:\n\tv53 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v53, this._em);\n")]
		public Entity CreateWall(GridCoord coord)
		{
			EntityBuilder entityBuilder = new EntityBuilder(_em);
			EntityBuilder entityBuilder2 = entityBuilder.With(default(WallTag));
			EntityBuilder entityBuilder3 = entityBuilder2.With(default(InitPendingTag));
			_gridHandler.InitEntity(entityBuilder3.Entity, coord);
			return entityBuilder3.Entity;
		}

		[Token(Token = "0x6000AE0")]
		[Address(RVA = "0x3EC1AE4", Offset = "0x3EC1AE4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv73 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v54, 0);\n\tv79 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v73, 0);\n\tv80 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v79, direction);\n\tv81 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v80, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v81.Entity, coord);\n\treturn v81.Entity;\nL_002A:\n\tv54 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v54, this._em);\n")]
		public Entity CreateTunnel(GridCoord coord, TunnelDirection direction)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateTunnel");
			return default;
		}

		[Token(Token = "0x6000AE1")]
		[Address(RVA = "0x3EC1EFC", Offset = "0x3EC1EFC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv72 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v54, 0);\n\tv77 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v72, color);\n\tv78 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v77, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v78.Entity, coord);\n\treturn v78.Entity;\nL_0027:\n\tv54 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v54, this._em);\n")]
		public Entity CreateKey(GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateKey");
			return default;
		}

		[Token(Token = "0x6000AE2")]
		[Address(RVA = "0x3EC2014", Offset = "0x3EC2014", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv72 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v54, 0);\n\tv77 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v72, color);\n\tv78 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v77, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v78.Entity, coord);\n\treturn v78.Entity;\nL_0027:\n\tv54 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v54, this._em);\n")]
		public Entity CreateLock(GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateLock");
			return default;
		}

		[Token(Token = "0x6000AE3")]
		[Address(RVA = "0x3EC228C", Offset = "0x3EC228C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v53, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v65.Entity, coord);\n\treturn v65.Entity;\nL_0020:\n\tv53 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v53, this._em);\n")]
		public Entity CreateNoPlace(GridCoord coord)
		{
			EntityBuilder entityBuilder = new EntityBuilder(_em);
			EntityBuilder entityBuilder2 = entityBuilder.With(default(NoPlaceTag));
			_gridHandler.InitEntity(entityBuilder2.Entity, coord);
			return entityBuilder2.Entity;
		}

		[Token(Token = "0x6000AE4")]
		[Address(RVA = "0x3EC2358", Offset = "0x3EC2358", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v53, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v65.Entity, coord);\n\treturn v65.Entity;\nL_0020:\n\tv53 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v53, this._em);\n")]
		public Entity CreateNoPlaceWall(GridCoord coord)
		{
			EntityBuilder entityBuilder = new EntityBuilder(_em);
			EntityBuilder entityBuilder2 = entityBuilder.With(default(NoPlaceWallTag));
			_gridHandler.InitEntity(entityBuilder2.Entity, coord);
			return entityBuilder2.Entity;
		}

		[Token(Token = "0x6000AE5")]
		[Address(RVA = "0x3EC1118", Offset = "0x3EC1118", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv86 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v67, 0);\n\tv160 = groupId | counter;\n\tv173 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v86, v160);\n\tv174 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v173, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v174.Entity, anchor);\n\tv326 = sizeX < 1;\n\tif (v326) goto L_011F;\n\tv338 = sizeY < 1;\n\tif (v338) goto L_011F;\nL_FFFFFFFF:\n\tv213 = 0;\n\tv177 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v176, 0);\n\tv178 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v177, 0);\n\tv179 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v178, groupId);\n\tv180 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v179, 0);\n\tv219 = this._gridHandler;\n\tgoto L_00D9;\nL_00D9:\n\tv448 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(v219._gridPosPool, v180.Entity, &v103 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv450 = ~v448;\n\tif (v450) goto L_00EA;\n\tv452 = v103 >> 0x20;\n\tv453 = v103 << 0x20;\n\tv454 = v452 | v453;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(v219, v180.Entity, v454);\nL_00EA:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v219._em, v180.Entity, v92);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v219._em, v180.Entity, 0xB);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InsertIntoSpatialIndices(v219, v180.Entity, v92);\n\tv96 = v96 + 1;\n\tv340 = v94 - 1;\n\tv402 = v94 != 1;\nL_FFFFFFFF:\n\tv94 = v340;\n\tif (v402) goto L_008D;\n\tv213 = v213 + 1;\n\tv345 = v213 != sizeX;\n\tif (v345) goto L_FFFFFFFF;\nL_011F:\n\treturn v174.Entity;\nL_0039:\n\tv67 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v67, this._em);\nL_008D:\n\tv421 = v213 + anchor;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v92 @ stack_-80_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v421, v96);\n\tv176 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v176, this._em);\nL_FFFFFFFF:\n\tv94 = sizeY;\nL_FFFFFFFF:\n\tv96 = anchor.y;\n")]
		public Entity CreateGarage(GridCoord anchor, int sizeX, int sizeY, int groupId, int counter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateGarage");
			return default;
		}

		[Token(Token = "0x6000AE6")]
		[Address(RVA = "0x3EC16A0", Offset = "0x3EC16A0", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv86 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v67, 0);\n\tv166 = groupId;\n\tv184 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v86, &v166 @ stack_-80_v2 (System.Int32));\n\tv185 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v184, 0);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v185.Entity, anchor);\n\tv339 = sizeX < 1;\n\tif (v339) goto L_0123;\n\tv351 = sizeY < 1;\n\tif (v351) goto L_0123;\nL_FFFFFFFF:\n\tv225 = 0;\n\tv188 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v187, 0);\n\tv189 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v188, 0);\n\tv190 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v189, groupId);\n\tv191 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v190, 0);\n\tv230 = this._gridHandler;\n\tgoto L_00DB;\nL_00DB:\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(v230._gridPosPool, v191.Entity, &v168 @ stack_-80_v7 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv462 = ~v459;\n\tif (v462) goto L_00EE;\n\tv464 = v168 >> 0x20;\n\tv465 = v168 << 0x20;\n\tv466 = v464 | v465;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(v230, v191.Entity, v466);\nL_00EE:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v230._em, v191.Entity, v88);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v230._em, v191.Entity, 0xB);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InsertIntoSpatialIndices(v230, v191.Entity, v88);\n\tv92 = v92 + 1;\n\tv353 = v90 - 1;\n\tv413 = v90 != 1;\nL_FFFFFFFF:\n\tv90 = v353;\n\tif (v413) goto L_008E;\n\tv225 = v225 + 1;\n\tv358 = v225 != sizeX;\n\tif (v358) goto L_FFFFFFFF;\nL_0123:\n\treturn v185.Entity;\nL_0039:\n\tv67 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v67, this._em);\nL_008E:\n\tv432 = v225 + anchor;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v88 @ stack_-90_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v432, v92);\n\tv187 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v187, this._em);\nL_FFFFFFFF:\n\tv90 = sizeY;\nL_FFFFFFFF:\n\tv92 = anchor.y;\n")]
		public unsafe Entity CreateHammerArea(GridCoord anchor, int sizeX, int sizeY, int groupId, int counter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateHammerArea");
			return default;
		}

		[Token(Token = "0x6000AE7")]
		[Address(RVA = "0x3EC1C20", Offset = "0x3EC1C20", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv75 = v61.gameColor;\n\tv121 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v82, 0);\n\tv122 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v121, 0);\n\tv123 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v122, v75);\n\tv124 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v123, 0);\n\tv240 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v124, 0);\n\tv125 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::HasComp(cell);\n\tv242 = ~v125;\n\tif (v242) goto L_008E;\n\tv246 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v240, 0);\nL_008E:\n\tv253 = this._resolvedLinkedGroupIds == 0;\n\tif (v253) goto L_00A6;\n\tv126 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::TryGetValue(this._resolvedLinkedGroupIds, coord, &v97 @ stack_-5C_v3 (System.Int32));\n\tv262 = ~v126;\n\tif (v262) goto L_00A6;\n\tv260 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v240, v97);\nL_00A6:\n\tv127 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v95 @ stack_-68_v2 (_game.CoreSystem.SandSystem.Components.SnakeSegmentComponent));\n\tv269 = ~v127;\n\tif (v269) goto L_00C8;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v88 @ stack_-78_v3 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v95.nextCol, v95.nextRow);\n\tv274 = v95.snakeId | v88;\n\tv276 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v240, v274);\n\tgoto L_00C8;\nL_00C8:\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InitEntity(this._gridHandler, v240.Entity, coord);\n\treturn v240.Entity;\nL_0048:\n\tv63 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator::TryGetComp(cell, &v61 @ stack_-58_v2 (_game.CoreSystem.SandSystem.Components.GameColorComponent));\n\tv68 = ~v63;\n\tv75 = 0;\n\tif (v68) goto L_0054;\nL_0054:\n\tv82 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v82, this._em);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Entity CreateSandCubeFromCell(GridCoord coord, SandCubeCellData cell)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::CreateSandCubeFromCell");
			return default;
		}

		[Token(Token = "0x6000AE8")]
		[Address(RVA = "0x3EC0A80", Offset = "0x3EC0A80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = columns * row;\n\treturnVal1 = col + v0;\n\treturn returnVal1;\n")]
		private static int GetIndex(int col, int row, int columns)
		{
			int num = columns * row;
			return col + num;
		}

		[Token(Token = "0x6000AE9")]
		[Address(RVA = "0x4D14A38", Offset = "0x4D14A38", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\nL_0017:\n\tv44 = cell == 0;\n\tif (v44) goto L_0099;\nL_001A:\n\tv53 = cell.components == 0;\n\tif (v53) goto L_0099;\n\tv66 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tv69 = *([v66 @ X0_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+135]) & 1;\n\tv70 = v69 == 0;\n\tif (v70) goto L_0033;\n\tgoto L_0027;\nL_0027:\n\tv106 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tv109 = *([v106 @ X0_v37 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+135]) & 1;\n\tv110 = v109 == 0;\nL_FFFFFFFF:\n\tv116 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\nL_FFFFFFFF:\n\tv126 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tif (v110) goto L_0041;\nL_002D:\n\tv122 = *([v116 @ X0_v35 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+B8]);\n\tv141 = *([v122 @ X8_v46 (Il2CppStaticFields<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+8]);\n\tv124 = *([v122 @ X8_v46 (Il2CppStaticFields<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+8]) == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_008A;\n\tgoto L_0048;\nL_0033:\n\tv98 = 0x220C238(Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = *([v98 @ X0_v34+E4]) == 0;\n\tv102 = ~v115;\n\tif (v102) goto L_0027;\n\tv117 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tv132 = *([v117 @ X0_v33 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+135]) & 1;\n\tv133 = v132 == 0;\n\tv119 = ~v133;\nL_FFFFFFFF:\n\tv116 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\nL_FFFFFFFF:\n\tv126 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tif (v119) goto L_002D;\nL_0041:\n\tv129 = 0x220C238(v126, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = *([v129 @ X0_v30+B8]);\n\tv141 = *([v150 @ X8_v39+8]);\n\tv153 = *([v150 @ X8_v39+8]) == 0;\n\tv147 = ~v153;\n\tif (v147) goto L_008A;\nL_0048:\n\tv159 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tv162 = *([v159 @ X0_v9 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+135]) & 1;\n\tv163 = v162 == 0;\n\tif (v163) goto L_009A;\n\tgoto L_0058;\nL_0058:\n\tgoto L_005F;\nL_005F:\n\tv198 = new System.Predicate`1<_game.CoreSystem.LevelCreator.ICellComponent>();\n\tSystem.Predicate`1<_game.CoreSystem.LevelCreator.ICellComponent>::.ctor(v198, v194.<>9, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv212 = Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>;\n\tgoto L_006F;\nL_006F:\n\tv213 = *([v212 @ X0_v18 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+B8]);\n\t*([v213 @ X8_v27 (Il2CppStaticFields<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>)+8]) = v198;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv141 = v198;\nL_008A:\n\treturnVal2 = System.Collections.Generic.List`1<_game.CoreSystem.LevelCreator.ICellComponent>::Exists(cell.components, v141);\n\treturn returnVal2;\n\tv48 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = cell == 0;\n\tv50 = ~v99;\n\tif (v50) goto L_001A;\nL_0099:\n\treturn 0;\nL_009A:\n\tv166 = 0x220C238(Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridEntitySystemCreator+<>c__24`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv183 = *([v166 @ X0_v13+E4]) == 0;\n\tv169 = ~v183;\n\tif (v169) goto L_0058;\n\tgoto L_00A7;\nL_00A7:\n\tgoto L_005F;\n")]
		private static bool HasComp<T>(SandCubeCellData cell) where T : ICellComponent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::HasComp");
			return default;
		}

		[Token(Token = "0x6000AEA")]
		[Address(RVA = "0x4D14DE8", Offset = "0x4D14DE8", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_001A;\nL_001A:\n\t*([value @ X1 (T&)]) = 0;\n\tv49 = cell == 0;\n\tif (v49) goto L_0068;\nL_001D:\n\tv97 = cell.components;\n\tv58 = cell.components == 0;\n\treturnVal2 = cell.components;\n\tif (v58) goto L_0057;\n\tv95 = 0;\n\tv196 = System.Collections.Generic.List`1<_game.CoreSystem.LevelCreator.ICellComponent>::get_Item(v97, v95);\n\tgoto L_003F;\n\tv95 = v95 + 1;\n\tv97 = cell.components;\n\tv201 = cell.components == 0;\n\tv180 = ~v201;\n\tif (v180) goto L_002D;\n\tv202 = new System.NullReferenceException();\nL_004A:\n\t*([value @ X1 (T&)]) = v202;\n\treturnVal2 = 1;\n\tv53 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([value @ X1 (T&)]) = 0;\n\tv183 = cell == 0;\n\tv55 = ~v183;\n\tif (v55) goto L_001D;\nL_0068:\n\treturn 0;\nL_0057:\n\treturn returnVal2;\nL_003F:\n\tv202 = 0x21C11D0(v196, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = v202 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_004A;\nL_002D:\n\tv61 = v95 >= v97.Count;\n\tif (v61) goto L_0068;\n")]
		private static bool TryGetComp<T>(SandCubeCellData cell, out T value) where T : class, ICellComponent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridEntitySystemCreator::TryGetComp");
			value = default;
			return default;
		}

		[Token(Token = "0x6000AEB")]
		[Address(RVA = "0x3EC2424", Offset = "0x3EC2424", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridEntitySystemCreator()
		{
		}
	}
}
