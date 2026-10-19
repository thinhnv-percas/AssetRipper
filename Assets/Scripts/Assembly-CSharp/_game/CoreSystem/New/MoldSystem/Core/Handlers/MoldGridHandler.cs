using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Extensions;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;

namespace _game.CoreSystem.New.MoldSystem.Core.Handlers
{
	[Token(Token = "0x20002FC")]
	public class MoldGridHandler
	{
		[Token(Token = "0x400092E")]
		public const uint GRID_ID = 10u;

		[Inject(false)]
		[Token(Token = "0x400092F")]
		[FieldOffset(Offset = "0x10")]
		internal EntityManager _em;

		[Token(Token = "0x6000D34")]
		[Address(RVA = "0x3EEB008", Offset = "0x3EEB008", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, 0xA);\n\treturn;\n")]
		public void InitEntity(Entity entity, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::InitEntity");
		}

		[Token(Token = "0x6000D35")]
		[Address(RVA = "0x3EEC35C", Offset = "0x3EEC35C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv74 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::IsValidCoord(this, v53);\n\tv75 = ~v74;\n\tif (v75) goto L_0049;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\n\treturn;\nL_0049:\n\treturn;\n")]
		public void RemoveEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::RemoveEntity");
		}

		[Token(Token = "0x6000D36")]
		[Address(RVA = "0x3EEC508", Offset = "0x3EEC508", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv52.<>4__this = this;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v76 @ stack_-50_v3 (_game.CoreSystem.New.GridEcsBinding.GridCoord), col, row);\n\tv52.coord = v76;\n\tv52.coord.IsValid = 0;\n\tv98 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::IsValidCoord(this, v76);\n\tv140 = v98 == 0;\n\tif (v140) goto L_006F;\n\tv149 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv157 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v157, v52, Il2CppMethodInfo);\n\treturnVal3 = Unco.Extensions.CollectionExtensions::Find(v149, v157);\n\treturn returnVal3;\nL_006F:\n\tgoto L_007D;\nL_002A:\n\tv52 = new _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v52);\nL_007D:\n\treturn v123.Invalid;\n")]
		public Entity GetEntityAt(int col, int row)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::GetEntityAt");
			return default;
		}

		[Token(Token = "0x6000D37")]
		[Address(RVA = "0x3EEC6B4", Offset = "0x3EEC6B4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v40);\n\tv53 = v51 >> 0x20;\n\tv58 = v53 == 0;\n\treturn v58;\n")]
		public bool IsFront(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::IsFront");
			return default;
		}

		[Token(Token = "0x6000D38")]
		[Address(RVA = "0x3EEC728", Offset = "0x3EEC728", Length = "0x42C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\nL_004C:\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv251 = System.Linq.Enumerable::First(v68);\n\tv312 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v251);\n\tv317 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v317);\n\tv396 = new System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>>::.ctor(v396);\n\tv130 = v312 < 1;\n\tif (v130) goto L_00BA;\n\tv418 = v396 == 0;\nL_FFFFFFFF:\n\tv204 = 0;\n\tif (v418) goto L_0082;\nL_FFFFFFFF:\n\tv207 = 0;\n\tgoto L_0132;\nL_0082:\n\tv466 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::GetEntityAt(this, column, v204);\n\tv282 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v466);\n\tv558 = ~v282;\n\tv284 = ~v558;\n\tif (v284) goto L_0170;\n\tv204 = v204 + 1;\n\tv450 = v312 != v204;\nL_FFFFFFFF:\n\t;\n\tif (v450) goto L_0082;\nL_FFFFFFFF:\n\tv619 = 0;\nL_00BA:\n\tv478 = v396.Count < 1;\n\tif (v478) goto L_016D;\nL_FFFFFFFF:\n\tv189 = 0;\n\tgoto L_00DA;\nL_00C9:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Add(v317, v554);\nL_00CA:\n\tv189 = v189 + 1;\n\tv520 = v189 >= v396.Count;\n\tif (v520) goto L_016D;\nL_00DA:\n\tv554 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>>::get_Item(v396, v189);\n\tv104 = 0;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v104 @ stack_-80_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), column, v189);\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v93 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), column, v189);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v554, v93);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v554, 0xA);\n\tv164 = v189 == v189;\n\tif (v164) goto L_00CA;\n\tgoto L_00C9;\nL_0123:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>>::Add(v396, v106);\nL_FFFFFFFF:\n\t;\nL_0124:\n\tv207 = v207 + 1;\n\tv492 = v312 == v207;\nL_FFFFFFFF:\n\t;\n\tif (v492) goto L_FFFFFFFF;\nL_0132:\n\tv508 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::GetEntityAt(this, column, v207);\n\tv557 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v508);\n\tv563 = ~v557;\n\tif (v563) goto L_0124;\n\tSystem.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>::.ctor(&v106 @ stack_-80_v11 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>), v508, v207);\n\tgoto L_0123;\nL_016D:\n\treturn v317;\nL_0170:\n\tv288 = 0;\n\tSystem.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>::.ctor(&v288 @ stack_-80_v2 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Int32>), v276, v277);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_009D:\n\tv624 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::GetEntityAt(this, column, v619);\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::RemoveEntity(this, v624);\n\tv619 = v619 + 1;\n\tv428 = v312 != v619;\n\tif (v428) goto L_009D;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<Entity> ShiftColumn(int column)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::ShiftColumn");
			return default;
		}

		[Token(Token = "0x6000D39")]
		[Address(RVA = "0x3EECB54", Offset = "0x3EECB54", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv57 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entityA);\n\tv83 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entityB);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entityA, v83);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entityB, v57);\n\treturn;\n")]
		public void SwapEntities(Entity entityA, Entity entityB)
		{
			GridPositionComponent component = _em.GetComponent<GridPositionComponent>(entityA);
			GridPositionComponent component2 = _em.GetComponent<GridPositionComponent>(entityB);
			_em.SetComponent(entityA, component2);
			_em.SetComponent(entityB, component);
		}

		[Token(Token = "0x6000D3A")]
		[Address(RVA = "0x3EECC2C", Offset = "0x3EECC2C", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv60.<>4__this = this;\n\tv145 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entityA);\n\tv60.coordA = v145;\n\tv60.coordA.IsValid = entityA;\n\tv185 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entityB);\n\tv60.coordB = v185;\n\tv60.coordB.IsValid = entityB;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entityA, v185);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entityB, v60.coordA);\n\tv194 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv196 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v196, v60, Il2CppMethodInfo);\n\tv201 = System.Linq.Enumerable::FirstOrDefault(v194, v196);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v201, entityA);\n\tv205 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv207 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v207, v60, Il2CppMethodInfo);\n\tv212 = System.Linq.Enumerable::FirstOrDefault(v205, v207);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v212, entityB);\n\treturn;\nL_0037:\n\tv60 = new _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v60);\n")]
		public void SwapEntitiesVisual(Entity entityA, Entity entityB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::SwapEntitiesVisual");
		}

		[Token(Token = "0x6000D3B")]
		[Address(RVA = "0x3EEC438", Offset = "0x3EEC438", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv67 = System.Linq.Enumerable::First(v54);\n\tv124 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v67);\n\tv126 = coord & 0x80000000;\n\tv127 = v126 == 0;\n\tv109 = ~v127;\nL_FFFFFFFF:\n\tv111 = 0;\n\tif (v109) goto L_0067;\n\tv138 = coord >= v124.columns;\nL_FFFFFFFF:\n\tv111 = 0;\n\tif (v138) goto L_0067;\n\tv139 = coord < 0;\n\tif (v139) goto L_FFFFFFFF;\n\tv163 = coord.y - v124;\n\tv146 = v163 < 0;\n\tv166 = coord.y ^ v124;\n\tv167 = coord.y ^ v163;\n\tv168 = v166 & v167;\n\tv141 = v168 < 0;\n\tgoto L_005C;\nL_FFFFFFFF:\n\tv141 = 0;\nL_FFFFFFFF:\n\tv146 = 0;\nL_0067:\n\treturn v111;\nL_005C:\n\tv174 = v146 == v141;\n\tv140 = ~v174;\nL_FFFFFFFF:\n\tv111 = v140;\n")]
		private bool IsValidCoord(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldGridHandler::IsValidCoord");
			return default;
		}

		[Token(Token = "0x6000D3C")]
		[Address(RVA = "0x3EECE88", Offset = "0x3EECE88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldGridHandler()
		{
		}
	}
}
