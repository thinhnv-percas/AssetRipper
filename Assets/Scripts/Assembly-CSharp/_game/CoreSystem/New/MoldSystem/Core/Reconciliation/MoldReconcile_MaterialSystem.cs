using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Commands;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E8")]
	public class MoldReconcile_MaterialSystem
	{
		[Token(Token = "0x40008EA")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000CBE")]
		[Address(RVA = "0x3EDD6B0", Offset = "0x3EDD6B0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\treturn;\n")]
		public MoldReconcile_MaterialSystem(EntityManager em)
		{
			_em = em;
		}

		[Token(Token = "0x6000CBF")]
		[Address(RVA = "0x3EDDCA0", Offset = "0x3EDDCA0", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\nL_FFFFFFFF:\n\tv132 = 0;\n\tgoto L_0045;\nL_0043:\n\tv132 = v132 + 1;\n\tv327 = *([v279 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv327 = v327 + 0x10;\n\tv291 = v318 - 1;\n\tv289 = v318 != 1;\nL_FFFFFFFF:\n\tv318 = v291;\n\tif (v289) goto L_0050;\nL_0069:\n\tv340 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv351 = v132 < v340;\n\tif (v351) goto L_008E;\n\tgoto L_010A;\nL_0078:\n\tv356 = *([v327 @ X10_v14]) << 4;\n\tv357 = v279 + v356;\n\tv358 = v357 + 0x138;\n\t*([v358 @ X0_v30])(v362, v63, *([v358 @ X0_v30+8]), v458, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv372 = v132 >= v362;\n\tif (v372) goto L_010A;\nL_008E:\n\tgoto L_00B5;\n\tv454 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v453);\n\tv455 = ~v454;\nL_FFFFFFFF:\n\tv458 = 0;\n\tif (v455) goto L_0043;\n\tv470 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v453);\n\tv474 = v470 == 0;\n\tv471 = ~v474;\nL_FFFFFFFF:\n\tv458 = Il2CppMethodInfo;\n\tif (v471) goto L_0043;\n\tv476 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v453);\n\tv478 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v453);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v453);\n\tv465 = v478 == 0;\n\tv459 = ~v465;\n\tv457 = ~v459;\n\tif (v457) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv472 = 0x100000000;\n\tgoto L_00F9;\nL_FFFFFFFF:\n\tv472 = 0;\nL_010A:\n\treturn;\nL_0045:\n\tv279 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv318 = *([v279 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv227 = *([v279 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v227) goto L_0069;\nL_0050:\n\tv332 = *([v327 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v332) goto L_0078;\nL_00B5:\n\tv453 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v132);\nL_00F9:\n\tv458 = v472 | v476;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v453, v458);\n\tgoto L_0043;\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_MaterialSystem::Execute");
		}
	}
}
