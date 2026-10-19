using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems
{
	[Token(Token = "0x20001B3")]
	public class SandReconcile_PinTriggerSystem : ITopGridEcsSystem, IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x4000550")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000551")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Token(Token = "0x60007E6")]
		[Address(RVA = "0x3E7113C", Offset = "0x3E7113C", Length = "0x50C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\nL_0044:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv384 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv417 = *([v384 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv386 = *([v384 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v386) goto L_006F;\n\tv324 = *([v384 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv324 = v324 + 0x10;\n\tv402 = v417 - 1;\n\tv392 = v417 != 1;\nL_FFFFFFFF:\n\tv417 = v402;\n\tif (v392) goto L_0056;\nL_006F:\n\tv346 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv420 = v346 == 0;\n\tv354 = ~v420;\n\tif (v354) goto L_007F;\n\tgoto L_0214;\nL_0075:\n\tv248 = *([v324 @ X10_v33]) << 4;\n\tv425 = v384 + v248;\n\tv426 = v425 + 0x138;\n\t*([v426 @ X0_v72])(v347, v63, *([v426 @ X0_v72+8]), v256, v652, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv355 = v347 == 0;\n\tif (v355) goto L_0214;\nL_007F:\n\tv445 = *([v63 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv486 = *([v445 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv356 = *([v445 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v356) goto L_00A3;\n\tv326 = *([v445 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv326 = v326 + 0x10;\n\tv471 = v486 - 1;\n\tv453 = v486 != 1;\nL_FFFFFFFF:\n\tv486 = v471;\n\tif (v453) goto L_008A;\nL_00A3:\n\tv348 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv95 = v348 - 1;\n\tv262 = v348 >= 1;\n\tif (v262) goto L_FFFFFFFF;\n\tgoto L_0214;\nL_00B2:\n\tv250 = *([v326 @ X10_v28]) << 4;\n\tv502 = v445 + v250;\n\tv503 = v502 + 0x138;\n\t*([v503 @ X0_v65])(v349, v63, *([v503 @ X0_v65+8]), 0, v652, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv305 = v349 < 1;\n\tv95 = v349 - 1;\n\tif (v305) goto L_0214;\nL_FFFFFFFF:\n\tv636 = 0;\n\tgoto L_00E5;\nL_00D1:\n\tv625 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v636, v628);\nL_FFFFFFFF:\n\tv652 = 0;\nL_FFFFFFFF:\n\tv258 = Il2CppMethodInfo;\nL_00D2:\n\tv219 = v95 - 1;\n\tv118 = v95 <= 0;\nL_FFFFFFFF:\n\tv95 = v219;\n\tif (v118) goto L_0155;\nL_00E5:\n\tgoto L_010C;\n\tv620 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v619);\n\tv621 = ~v620;\nL_FFFFFFFF:\n\tv258 = 0;\n\tif (v621) goto L_00D2;\n\tv641 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v619);\n\tv645 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetPinAt(this._gridHandler, v641);\n\tv626 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v645);\n\tv630 = ~v626;\nL_FFFFFFFF:\n\tv652 = 0;\nL_FFFFFFFF:\n\tv258 = 0;\n\tif (v630) goto L_00D2;\n\tv627 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v645);\n\tv631 = ~v627;\nL_FFFFFFFF:\n\tv652 = 0;\nL_FFFFFFFF:\n\tv258 = Il2CppMethodInfo;\n\tif (v631) goto L_00D2;\n\tv628 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v645);\n\tv801 = v645 & 1;\n\tv632 = v801 == 0;\nL_FFFFFFFF:\n\tv652 = 0;\nL_FFFFFFFF:\n\tv258 = Il2CppMethodInfo;\n\tif (v632) goto L_00D2;\n\tv812 = v636 == 0;\n\tv813 = ~v812;\n\tif (v813) goto L_00D1;\n\tv193 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v193);\n\tv833 = v193 == 0;\n\tv208 = ~v833;\nL_FFFFFFFF:\n\tv636 = v193;\n\tif (v208) goto L_00D1;\n\tgoto L_0206;\nL_0155:\n\tv357 = v636 == 0;\n\tif (v357) goto L_0214;\n\tv195 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\nL_FFFFFFFF:\n\tv94 = 0;\n\tgoto L_016F;\nL_016C:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v811, v837);\nL_FFFFFFFF:\n\tv652 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv258 = v837;\nL_016D:\n\tv94 = v94 + 1;\n\tv328 = *([v675 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv328 = v328 + 0x10;\n\tv698 = v711 - 1;\n\tv680 = v711 != 1;\nL_FFFFFFFF:\n\tv711 = v698;\n\tif (v680) goto L_017A;\nL_0193:\n\tv351 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v195);\n\tv264 = v94 < v351;\n\tif (v264) goto L_01B8;\n\tgoto L_0214;\nL_01A2:\n\tv252 = *([v328 @ X10_v18]) << 4;\n\tv725 = v675 + v252;\n\tv726 = v725 + 0x138;\n\t*([v726 @ X0_v55])(v352, v195, *([v726 @ X0_v55+8]), v258, v652, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv265 = v94 >= v352;\n\tif (v265) goto L_0214;\nL_01B8:\n\tgoto L_01DF;\n\tv814 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v811);\n\tv823 = ~v814;\nL_FFFFFFFF:\n\tv258 = 0;\n\tif (v823) goto L_016D;\n\tv837 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v811);\n\tv828 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v636, v837);\n\tv830 = ~v828;\nL_FFFFFFFF:\n\tv258 = Il2CppMethodInfo;\n\tif (v830) goto L_016D;\n\tv829 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v811);\n\tv840 = v829 == 0;\n\tv831 = ~v840;\nL_FFFFFFFF:\n\tv258 = Il2CppMethodInfo;\n\tif (v831) goto L_016D;\n\tv841 = this._em == 0;\n\tv201 = ~v841;\n\tif (v201) goto L_016C;\nL_0206:\n\tthrow System.NullReferenceException;\nL_0214:\n\treturn;\nL_0056:\n\tv296 = *([v324 @ X10_v33-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v296) goto L_0075;\nL_008A:\n\tv491 = *([v326 @ X10_v28-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v491) goto L_00B2;\nL_010C:\n\tv619 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v95);\nL_016F:\n\tv675 = *([v195 @ X0_v32 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv711 = *([v675 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv358 = *([v675 @ X8_v29 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v358) goto L_0193;\nL_017A:\n\tv716 = *([v328 @ X10_v18-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v716) goto L_01A2;\nL_01DF:\n\tv811 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v195, v94);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_PinTriggerSystem::Execute");
		}

		[Token(Token = "0x60007E7")]
		[Address(RVA = "0x3E6C6DC", Offset = "0x3E6C6DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_PinTriggerSystem()
		{
		}
	}
}
