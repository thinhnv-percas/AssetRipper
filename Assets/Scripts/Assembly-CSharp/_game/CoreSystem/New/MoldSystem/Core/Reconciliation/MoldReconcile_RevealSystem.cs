using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Commands;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared.Components;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002EA")]
	public class MoldReconcile_RevealSystem
	{
		[Token(Token = "0x40008ED")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x6000CCA")]
		[Address(RVA = "0x3EDD67C", Offset = "0x3EDD67C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\treturn;\n")]
		public MoldReconcile_RevealSystem(EntityManager em)
		{
			_em = em;
		}

		[Token(Token = "0x6000CCB")]
		[Address(RVA = "0x3EDDC7C", Offset = "0x3EDDC7C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RevealSystem::ClearHiddenAtFront(this);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RevealSystem::IssueRevealCommands(this);\n\treturn;\n")]
		public void Execute()
		{
			ClearHiddenAtFront();
			IssueRevealCommands();
		}

		[Token(Token = "0x6000CCC")]
		[Address(RVA = "0x3EE0DE0", Offset = "0x3EE0DE0", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv277 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv318 = *([v277 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv252 = *([v277 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v252) goto L_0060;\n\tv238 = *([v277 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv238 = v238 + 0x10;\n\tv303 = v318 - 1;\n\tv285 = v318 != 1;\nL_FFFFFFFF:\n\tv318 = v303;\n\tif (v285) goto L_0047;\nL_0060:\n\tv248 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv94 = v248 - 1;\n\tv201 = v248 >= 1;\n\tif (v201) goto L_008B;\n\tgoto L_013A;\nL_006F:\n\tv192 = *([v238 @ X10_v14]) << 4;\n\tv334 = v277 + v192;\n\tv335 = v334 + 0x138;\n\t*([v335 @ X0_v32])(v249, v63, *([v335 @ X0_v32+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv226 = v249 < 1;\n\tv94 = v249 - 1;\n\tif (v226) goto L_013A;\nL_008B:\n\tgoto L_00A2;\nL_008E:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v445);\nL_008F:\n\tv257 = v94 - 1;\n\tv203 = v94 <= 0;\nL_FFFFFFFF:\n\tv94 = v257;\n\tif (v203) goto L_013A;\nL_00A2:\n\tgoto L_00C9;\n\tv446 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v445);\n\tv447 = ~v446;\n\tif (v447) goto L_008F;\n\tv484 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v445);\n\tv487 = ~v484;\n\tif (v487) goto L_008F;\n\tv496 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v445);\n\tv486 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v445);\n\tv497 = ~v486;\n\tif (v497) goto L_0115;\n\tv485 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v445);\n\tv507 = v445 < 0;\n\tv508 = v445 == 0;\n\tv510 = v445 ^ v445;\n\tv511 = v445 & v510;\n\tv512 = v511 < 0;\n\tv513 = v507 == v512;\n\tv450 = ~v508;\n\tv514 = v513 & v450;\n\tv480 = v496 >> 0x20;\n\tv469 = v480 == 0;\n\tv454 = ~v469;\n\tv448 = ~v454;\n\tif (v448) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv491 = v514;\n\tgoto L_0110;\nL_FFFFFFFF:\n\tv491 = 1;\n\tgoto L_008F;\nL_0115:\n\tv481 = v496 >> 0x20;\n\tv470 = v481 == 0;\n\tv455 = ~v470;\n\tv449 = ~v455;\n\tif (v449) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv492 = 0;\n\tgoto L_0126;\nL_FFFFFFFF:\n\tv492 = 1;\nL_0129:\n\tv521 = this._em == 0;\n\tv160 = ~v521;\n\tif (v160) goto L_008E;\n\tthrow System.NullReferenceException;\nL_013A:\n\treturn;\nL_0047:\n\tv323 = *([v238 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v323) goto L_006F;\nL_00C9:\n\tv445 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v94);\nL_0110:\n\tv522 = ~v491;\n\tv488 = ~v522;\n\tif (v488) goto L_0129;\nL_0126:\n\tv489 = v492 == 0;\n\tif (v489) goto L_008F;\n")]
		internal void ClearHiddenAtFront()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_RevealSystem::ClearHiddenAtFront");
		}

		[Token(Token = "0x6000CCD")]
		[Address(RVA = "0x3EE108C", Offset = "0x3EE108C", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\nL_003B:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv269 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv310 = *([v269 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv244 = *([v269 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v244) goto L_0066;\n\tv231 = *([v269 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv231 = v231 + 0x10;\n\tv295 = v310 - 1;\n\tv277 = v310 != 1;\n\tv310 = v295;\n\tif (v277) goto L_004D;\nL_0066:\n\tv240 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv89 = v240 - 1;\n\tv194 = v240 >= 1;\n\tif (v194) goto L_0091;\n\tgoto L_0122;\nL_0075:\n\tv185 = *([v231 @ X10_v14]) << 4;\n\tv326 = v269 + v185;\n\tv327 = v326 + 0x138;\n\t*([v327 @ X0_v33])(v241, v63, *([v327 @ X0_v33+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv219 = v241 < 1;\n\tv89 = v241 - 1;\n\tif (v219) goto L_0122;\nL_0091:\n\tgoto L_00A9;\nL_0095:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v443, v464);\nL_0096:\n\tv249 = v89 - 1;\n\tv196 = v89 <= 0;\n\tv89 = v249;\n\tif (v196) goto L_0122;\nL_00A9:\n\tgoto L_00D0;\n\tv444 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v443);\n\tv445 = ~v444;\n\tif (v445) goto L_0096;\n\tv449 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v443);\n\tv460 = v449 == 0;\n\tv452 = ~v460;\n\tif (v452) goto L_0096;\n\tv450 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v443);\n\tv462 = v450 == 0;\n\tv453 = ~v462;\n\tif (v453) goto L_0096;\n\tv451 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v443);\n\tv454 = ~v451;\n\tif (v454) goto L_0096;\n\tv464 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v443);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v443);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v443, 0);\n\tv467 = this._em == 0;\n\tv151 = ~v467;\n\tif (v151) goto L_0095;\n\tthrow System.NullReferenceException;\nL_0122:\n\treturn;\nL_004D:\n\tv315 = *([v231 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v315) goto L_0075;\nL_00D0:\n\tv443 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v89);\n")]
		internal void IssueRevealCommands()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_RevealSystem::IssueRevealCommands");
		}
	}
}
