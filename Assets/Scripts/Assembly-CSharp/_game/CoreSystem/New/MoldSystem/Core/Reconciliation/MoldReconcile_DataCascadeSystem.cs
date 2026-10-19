using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E5")]
	public class MoldReconcile_DataCascadeSystem
	{
		[Token(Token = "0x40008E5")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x40008E6")]
		[FieldOffset(Offset = "0x18")]
		private readonly MoldGridHandler _gridHandler;

		[Token(Token = "0x6000CB5")]
		[Address(RVA = "0x3EDD5DC", Offset = "0x3EDD5DC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\tthis._gridHandler = gridHandler;\n\treturn;\n")]
		public MoldReconcile_DataCascadeSystem(EntityManager em, MoldGridHandler gridHandler)
		{
			_em = em;
			_gridHandler = gridHandler;
		}

		[Token(Token = "0x6000CB6")]
		[Address(RVA = "0x3EDD9FC", Offset = "0x3EDD9FC", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv282 = *([v156 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv320 = *([v282 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv256 = *([v282 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v256) goto L_0062;\n\tv237 = *([v282 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv237 = v237 + 0x10;\n\tv307 = v320 - 1;\n\tv289 = v320 != 1;\n\tv320 = v307;\n\tif (v289) goto L_0049;\nL_0062:\n\tv252 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v156);\n\tv84 = v252 - 1;\n\tv200 = v252 >= 1;\n\tif (v200) goto L_0098;\n\tgoto L_00FF;\nL_0071:\n\tv191 = *([v237 @ X10_v14]) << 4;\n\tv333 = v282 + v191;\n\tv334 = v333 + 0x138;\n\t*([v334 @ X0_v32])(v253, v156, *([v334 @ X0_v32+8]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv84 = v253 - 1;\n\tv201 = v253 >= 1;\n\tif (v201) goto L_0098;\n\tgoto L_00FF;\nL_0085:\n\tv261 = v84 - 1;\n\tv202 = v84 <= 0;\n\tv84 = v261;\n\tif (v202) goto L_00FF;\nL_0098:\n\tgoto L_00BF;\n\tv420 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v419);\n\tv421 = ~v420;\n\tif (v421) goto L_0085;\n\tv422 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v419);\n\tv424 = ~v422;\n\tif (v424) goto L_0085;\n\tv423 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v419);\n\tv429 = v419 & 0x100000000;\n\tv425 = v429 == 0;\n\tif (v425) goto L_0085;\n\tv430 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v419);\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::RemoveEntity(this._gridHandler, v419);\n\tv431 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler::ShiftColumn(this._gridHandler, v430);\n\tv184 = this._em;\n\tv432 = this._em == 0;\n\tv164 = ~v432;\n\tif (v164) goto L_0039;\n\tthrow System.NullReferenceException;\nL_00FF:\n\treturn;\nL_0029:\n\tv184 = this._em;\nL_0049:\n\tv325 = *([v237 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v325) goto L_0071;\nL_00BF:\n\tv419 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v156, v84);\nL_0039:\n\tv156 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v184);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_DataCascadeSystem::Execute");
		}
	}
}
