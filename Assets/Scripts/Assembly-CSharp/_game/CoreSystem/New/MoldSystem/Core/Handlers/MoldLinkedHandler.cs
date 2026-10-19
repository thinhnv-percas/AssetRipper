using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.MoldSystem.Components;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Responds;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;

namespace _game.CoreSystem.New.MoldSystem.Core.Handlers
{
	[Token(Token = "0x20002FF")]
	public class MoldLinkedHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000935")]
		[FieldOffset(Offset = "0x10")]
		private GridData<MoldCellData> _grid;

		[Inject(false)]
		[Token(Token = "0x4000936")]
		[FieldOffset(Offset = "0x18")]
		private EntityManager _em;

		[Token(Token = "0x6000D42")]
		[Address(RVA = "0x3EED054", Offset = "0x3EED054", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv132 = ~v53;\n\tif (v132) goto L_00CB;\n\tv172 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tgoto L_0048;\nL_0048:\n\tv187 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v185 @ stack_-38_v7 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv192 = ~v187;\n\tv193 = ~v192;\n\tif (v193) goto L_0058;\n\tgoto L_009F;\nL_0058:\n\tv206 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v185);\n\tv209 = ~v206;\n\tif (v209) goto L_009F;\n\tgoto L_006B;\nL_006B:\n\tv230 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v185);\n\tv231 = ~v230;\n\tif (v231) goto L_007B;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v185);\nL_007B:\n\tv239 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v185);\n\tv240 = ~v239;\n\tif (v240) goto L_008D;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v185);\nL_008D:\n\tv207 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v185);\n\tv210 = ~v207;\n\tif (v210) goto L_009F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v185);\nL_009F:\n\tv213 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv214 = ~v213;\n\tif (v214) goto L_00B1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\nL_00B1:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\n\tv142 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv144 = ~v142;\n\tif (v144) goto L_00CB;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\nL_00CB:\n\treturn;\n")]
		public void OnLinkedResolved(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkedHandler::OnLinkedResolved");
		}

		[Token(Token = "0x6000D43")]
		[Address(RVA = "0x3EEB160", Offset = "0x3EEB160", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv51.<>4__this = this;\n\tv113 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv78 = v113 >> 0x20;\n\tv88 = _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.MoldCellData>::GetCell(this._grid, v113, v78);\n\tv169 = _game.CoreSystem.LevelCreator.MoldCellData::TryGetComponent(v88, &v51.linked (_game.CoreSystem.MoldSystem.Components.LinkedMoldComponent));\n\tv170 = ~v169;\n\tif (v170) goto L_0089;\n\tv184 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv188 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v188, v51, Il2CppMethodInfo);\n\tv197 = System.Linq.Enumerable::FirstOrDefault(v184, v188);\n\tgoto L_007C;\nL_007C:\n\tv176 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v171 @ stack_-48_v6 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv205 = ~v176;\n\tv178 = ~v205;\n\tif (v178) goto L_0098;\nL_0089:\n\treturn;\nL_0098:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, v171);\n\treturn;\nL_0035:\n\tv51 = new _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldLinkedHandler+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v51);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkedHandler::InitEntity");
		}

		[Token(Token = "0x6000D44")]
		[Address(RVA = "0x3EED300", Offset = "0x3EED300", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldLinkedHandler()
		{
		}
	}
}
