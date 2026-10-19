using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Commands;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E7")]
	public class MoldReconcile_LinkedResolveSystem
	{
		[Token(Token = "0x40008E8")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x40008E9")]
		[FieldOffset(Offset = "0x18")]
		private readonly MoldLinkedHandler _linkedHandler;

		[Token(Token = "0x6000CB9")]
		[Address(RVA = "0x3EDD62C", Offset = "0x3EDD62C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._em = em;\n\tthis._linkedHandler = linkedHandler;\n\treturn;\n")]
		public MoldReconcile_LinkedResolveSystem(EntityManager em, MoldLinkedHandler linkedHandler)
		{
			_em = em;
			_linkedHandler = linkedHandler;
		}

		[Token(Token = "0x6000CBA")]
		[Address(RVA = "0x3EDDC58", Offset = "0x3EDDC58", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::BreakLinksOnFill(this);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::ResolveLinksAtFront(this);\n\treturn;\n")]
		public void Execute()
		{
			BreakLinksOnFill();
			ResolveLinksAtFront();
		}

		[Token(Token = "0x6000CBB")]
		[Address(RVA = "0x3EDF00C", Offset = "0x3EDF00C", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\nL_0032:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv259 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv300 = *([v259 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv234 = *([v259 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v234) goto L_005D;\n\tv221 = *([v259 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv221 = v221 + 0x10;\n\tv285 = v300 - 1;\n\tv267 = v300 != 1;\n\tv300 = v285;\n\tif (v267) goto L_0044;\nL_005D:\n\tv230 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv86 = v230 - 1;\n\tv184 = v230 >= 1;\n\tif (v184) goto L_0088;\n\tgoto L_0110;\nL_006C:\n\tv175 = *([v221 @ X10_v14]) << 4;\n\tv315 = v259 + v175;\n\tv316 = v315 + 0x138;\n\t*([v316 @ X0_v33])(v231, v63, *([v316 @ X0_v33+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv209 = v231 < 1;\n\tv86 = v231 - 1;\n\tif (v209) goto L_0110;\nL_0088:\n\tgoto L_00A8;\nL_008C:\n\tv455 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v424);\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntity(this._em, v455);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::ProcessResolve(this, v424, v459);\nL_0095:\n\tv239 = v86 - 1;\n\tv186 = v86 <= 0;\n\tv86 = v239;\n\tif (v186) goto L_0110;\nL_00A8:\n\tgoto L_00CF;\n\tv425 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v424);\n\tv426 = ~v425;\n\tif (v426) goto L_0095;\n\tv439 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v424);\n\tv448 = v439 == 0;\n\tv441 = ~v448;\n\tif (v441) goto L_0095;\n\tv440 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v424);\n\tv442 = ~v440;\n\tif (v442) goto L_0095;\n\tv142 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v424);\n\tv94 = v142.dataFill < 1;\n\tif (v94) goto L_0095;\n\tv451 = this._em == 0;\n\tv148 = ~v451;\n\tif (v148) goto L_008C;\n\tthrow System.NullReferenceException;\nL_0110:\n\treturn;\nL_0044:\n\tv305 = *([v221 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v305) goto L_006C;\nL_00CF:\n\tv424 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v86);\n")]
		internal void BreakLinksOnFill()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_LinkedResolveSystem::BreakLinksOnFill");
		}

		[Token(Token = "0x6000CBC")]
		[Address(RVA = "0x3EDF28C", Offset = "0x3EDF28C", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\nL_0039:\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv186 = *([v64 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv299 = *([v186 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv188 = *([v186 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v188) goto L_0064;\n\tv298 = *([v186 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv298 = v298 + 0x10;\n\tv281 = v299 - 1;\n\tv261 = v299 != 1;\n\tv299 = v281;\n\tif (v261) goto L_004B;\nL_0064:\n\tv312 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v64);\n\tv98 = v312 - 1;\n\tv323 = v312 >= 1;\n\tif (v323) goto L_0088;\n\tgoto L_014C;\nL_0073:\n\tv329 = *([v298 @ X10_v14]) << 4;\n\tv330 = v186 + v329;\n\tv331 = v330 + 0x138;\n\t*([v331 @ X0_v47])(v335, v64, *([v331 @ X0_v47+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv339 = v335 < 1;\n\tv98 = v335 - 1;\n\tif (v339) goto L_014C;\nL_0088:\n\t;\n\tv384 = 0xB28D000 + 0xE20;\n\tgoto L_00A5;\nL_0092:\n\tv407 = v98 - 1;\n\tv395 = v98 <= 0;\n\tv98 = v407;\n\tif (v395) goto L_014C;\nL_00A5:\n\tgoto L_00CC;\n\tv493 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v492);\n\tv494 = ~v493;\n\tif (v494) goto L_0092;\n\tv508 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v492);\n\tv531 = v508 == 0;\n\tv516 = ~v531;\n\tif (v516) goto L_0092;\n\tv509 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v492);\n\tv517 = ~v509;\n\tif (v517) goto L_0092;\n\tv533 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v492);\n\tv535 = *([v384 @ X28_v9 (System.Int32)]);\n\tv536 = *([v535 @ X0_v20+E4]) == 0;\n\tif (v536) goto L_00FC;\n\tv510 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v495 @ stack_-68_v8 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv518 = ~v510;\n\tif (v518) goto L_0092;\n\tgoto L_0104;\nL_00FC:\n\tv511 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v495 @ stack_-68_v8 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv519 = ~v511;\n\tif (v519) goto L_0092;\nL_0104:\n\tv512 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v495);\n\tv520 = ~v512;\n\tif (v520) goto L_0092;\n\tgoto L_0114;\nL_0114:\n\tv513 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v495);\n\tv521 = ~v513;\n\tif (v521) goto L_0092;\n\tv549 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v492);\n\tv514 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v495);\n\tv525 = v549 >> 0x20;\n\tv553 = v525 == 0;\n\tv522 = ~v553;\n\tif (v522) goto L_0092;\n\tv526 = v514 >> 0x20;\n\tv554 = v526 == 0;\n\tv523 = ~v554;\n\tif (v523) goto L_0092;\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::ProcessResolve(this, v492, v495);\n\tgoto L_0092;\nL_014C:\n\treturn;\nL_004B:\n\tv304 = *([v298 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v304) goto L_0073;\nL_00CC:\n\tv492 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v64, v98);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void ResolveLinksAtFront()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcile_LinkedResolveSystem::ResolveLinksAtFront");
		}

		[Token(Token = "0x6000CBD")]
		[Address(RVA = "0x3EDF5FC", Offset = "0x3EDF5FC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv90 = v54 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0036;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, 0);\nL_0036:\n\tv120 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, partner);\n\tv122 = v120 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004C;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, partner, 0);\nL_004C:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, 0);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, partner, 0);\n\treturn;\n")]
		private void ProcessResolve(Entity entity, Entity partner)
		{
			if (!_em.HasComponent<Cmd_LinkedResolve>(entity))
			{
				_em.AddComponent(entity, default(Cmd_LinkedResolve));
			}
			if (!_em.HasComponent<Cmd_LinkedResolve>(partner))
			{
				_em.AddComponent(partner, default(Cmd_LinkedResolve));
			}
			_em.AddComponent(entity, default(VisualLinkResolvingTag));
			_em.AddComponent(partner, default(VisualLinkResolvingTag));
		}
	}
}
