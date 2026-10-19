using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Commands;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E3")]
	public class MoldReconcile_CompleteSystem
	{
		[Token(Token = "0x40008E3")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000CB1")]
		[Address(RVA = "0x3EDD780", Offset = "0x3EDD780", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\treturn;\n")]
		public MoldReconcile_CompleteSystem(EntityManager em)
		{
			_em = em;
		}

		[Token(Token = "0x6000CB2")]
		[Address(RVA = "0x3EDEC78", Offset = "0x3EDEC78", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv133 = 0;\n\tgoto L_004E;\nL_004B:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v424, 0);\n\tv208 = 0;\nL_004C:\n\tv133 = v133 + 1;\n\tv205 = *([v282 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv205 = v205 + 0x10;\n\tv291 = v316 - 1;\n\tv290 = v316 != 1;\n\tv316 = v291;\n\tif (v290) goto L_0059;\nL_0072:\n\tv221 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv174 = v133 < v221;\n\tif (v174) goto L_0097;\n\tgoto L_0103;\nL_0081:\n\tv172 = *([v205 @ X10_v14]) << 4;\n\tv340 = v282 + v172;\n\tv341 = v340 + 0x138;\n\t*([v341 @ X0_v30])(v222, v63, *([v341 @ X0_v30+8]), v208, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv175 = v133 >= v222;\n\tif (v175) goto L_0103;\nL_0097:\n\tgoto L_00BE;\n\tv425 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v424);\n\tv426 = ~v425;\n\tv208 = 0;\n\tif (v426) goto L_004C;\n\tv430 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v424);\n\tv438 = v430 == 0;\n\tv433 = ~v438;\n\tv208 = Il2CppMethodInfo;\n\tif (v433) goto L_004C;\n\tv431 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v424);\n\tv434 = ~v431;\n\tv208 = Il2CppMethodInfo;\n\tif (v434) goto L_004C;\n\tv432 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v424);\n\tv439 = ~v424;\n\tv435 = 0x10100000000 & v439;\n\tv93 = v435 == 0;\n\tv73 = ~v93;\n\tv208 = Il2CppMethodInfo;\n\tif (v73) goto L_004C;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v424, 0);\n\tv441 = this._em == 0;\n\tv149 = ~v441;\n\tif (v149) goto L_004B;\n\tthrow System.NullReferenceException;\nL_0103:\n\treturn;\nL_004E:\n\tv282 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv316 = *([v282 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv224 = *([v282 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v224) goto L_0072;\nL_0059:\n\tv329 = *([v205 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v329) goto L_0081;\nL_00BE:\n\tv424 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v133);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_CompleteSystem::Execute");
		}
	}
}
