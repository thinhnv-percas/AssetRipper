using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems
{
	[Token(Token = "0x2000231")]
	public class GarageGroupHandler
	{
		[Inject(false)]
		[Token(Token = "0x40006CD")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x60009AD")]
		[Address(RVA = "0x3E9926C", Offset = "0x3E9926C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv121 = 0;\n\tgoto L_0042;\nL_0040:\n\tv121 = v121 + 1;\n\tv294 = *([v249 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv294 = v294 + 0x10;\n\tv261 = v285 - 1;\n\tv259 = v285 != 1;\n\tv285 = v261;\n\tif (v259) goto L_004D;\nL_0066:\n\tv307 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v64);\n\tv318 = v121 < v307;\n\tif (v318) goto L_008B;\n\tgoto L_00DA;\nL_0075:\n\tv321 = *([v294 @ X10_v15]) << 4;\n\tv322 = v249 + v321;\n\tv323 = v322 + 0x138;\n\t*([v323 @ X0_v32])(v327, v64, *([v323 @ X0_v32+8]), v218, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv337 = v121 >= v327;\n\tif (v337) goto L_00DA;\nL_008B:\n\tgoto L_00B2;\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v458);\n\tv460 = ~v459;\n\tv218 = 0;\n\tif (v460) goto L_0040;\n\tv461 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v458);\n\tv462 = ~v461;\n\tv218 = Il2CppMethodInfo;\n\tif (v462) goto L_0040;\n\tv448 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v458);\n\tv437 = v448 != groupId;\n\tv218 = Il2CppMethodInfo;\n\tif (v437) goto L_0040;\n\tv435 = v458;\n\tgoto L_00ED;\nL_00DA:\n\tgoto L_00DE;\nL_0042:\n\tv249 = *([v64 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv285 = *([v249 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv251 = *([v249 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v251) goto L_0066;\nL_004D:\n\tv299 = *([v294 @ X10_v15-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v299) goto L_0075;\nL_00B2:\n\tv458 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v64, v121);\nL_00ED:\n\treturn v435;\nL_00DE:\n\tv435 = v412.Invalid;\n")]
		public Entity GetParentByGroupId(int groupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageGroupHandler::GetParentByGroupId");
			return default;
		}

		[Token(Token = "0x60009AE")]
		[Address(RVA = "0x3E994A4", Offset = "0x3E994A4", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv78 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv163 = 0;\n\tgoto L_0055;\nL_0052:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Add(v61, v450);\n\tv269 = Il2CppMethodInfo;\nL_0053:\n\tv163 = v163 + 1;\n\tv325 = *([v281 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv325 = v325 + 0x10;\n\tv292 = v316 - 1;\n\tv290 = v316 != 1;\n\tv316 = v292;\n\tif (v290) goto L_0060;\nL_0079:\n\tv338 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v78);\n\tv349 = v163 < v338;\n\tif (v349) goto L_009E;\n\tgoto L_0113;\nL_0088:\n\tv352 = *([v325 @ X10_v16]) << 4;\n\tv353 = v281 + v352;\n\tv354 = v353 + 0x138;\n\t*([v354 @ X0_v30])(v358, v78, *([v354 @ X0_v30+8]), v269, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv368 = v163 >= v358;\n\tif (v368) goto L_0113;\nL_009E:\n\tgoto L_00C5;\n\tv451 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v450);\n\tv452 = ~v451;\n\tv269 = 0;\n\tif (v452) goto L_0053;\n\tv467 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v450);\n\tv468 = ~v467;\n\tv269 = Il2CppMethodInfo;\n\tif (v468) goto L_0053;\n\tv151 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v450);\n\tv90 = v151 != groupId;\n\tv269 = Il2CppMethodInfo;\n\tif (v90) goto L_0053;\n\tgoto L_0052;\nL_0113:\n\treturn v61;\nL_0035:\n\tv61 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v61);\nL_0055:\n\tv281 = *([v78 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv316 = *([v281 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv224 = *([v281 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v224) goto L_0079;\nL_0060:\n\tv330 = *([v325 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v330) goto L_0088;\nL_00C5:\n\tv450 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v78, v163);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<Entity> GetCoversByGroupId(int groupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageGroupHandler::GetCoversByGroupId");
			return default;
		}

		[Token(Token = "0x60009AF")]
		[Address(RVA = "0x3E99750", Offset = "0x3E99750", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\nL_FFFFFFFF:\n\tv124 = 0;\nL_FFFFFFFF:\n\tv440 = 0;\n\tgoto L_003D;\nL_003B:\n\tv124 = v124 + 1;\n\tv300 = *([v258 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv300 = v300 + 0x10;\n\tv267 = v291 - 1;\n\tv265 = v291 != 1;\nL_FFFFFFFF:\n\tv291 = v267;\n\tif (v265) goto L_0048;\nL_0061:\n\tv313 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv324 = v124 < v313;\n\tif (v324) goto L_0086;\n\tgoto L_00D8;\nL_0070:\n\tv327 = *([v300 @ X10_v14]) << 4;\n\tv328 = v258 + v327;\n\tv329 = v328 + 0x138;\n\t*([v329 @ X0_v27])(v333, v63, *([v329 @ X0_v27+8]), v226, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv343 = v124 >= v333;\n\tif (v343) goto L_00D8;\nL_0086:\n\tgoto L_00AD;\n\tv426 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v425);\n\tv427 = ~v426;\nL_FFFFFFFF:\n\tv226 = 0;\n\tif (v427) goto L_003B;\n\tv442 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v425);\n\tv444 = ~v442;\nL_FFFFFFFF:\n\tv226 = Il2CppMethodInfo;\n\tif (v444) goto L_003B;\n\tv443 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v425);\n\tv438 = v440 - v443;\n\tv437 = v438 < 0;\n\tv436 = v438 == 0;\n\tv435 = v440 ^ v443;\n\tv434 = v440 ^ v438;\n\tv433 = v435 & v434;\n\tv432 = v433 < 0;\n\tv446 = v437 == v432;\n\tv429 = ~v436;\n\tv431 = v446 & v429;\n\tv428 = ~v431;\n\tif (v428) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv440 = v443;\nL_00D8:\n\treturnVal2 = v440 + 1;\n\treturn returnVal2;\nL_003D:\n\tv258 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv291 = *([v258 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv210 = *([v258 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v210) goto L_0061;\nL_0048:\n\tv305 = *([v300 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v305) goto L_0070;\nL_00AD:\n\tv425 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v124);\nL_FFFFFFFF:\n\tv226 = Il2CppMethodInfo;\n\tgoto L_003B;\n")]
		public int GetNextGroupId()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageGroupHandler::GetNextGroupId");
			return default;
		}

		[Token(Token = "0x60009B0")]
		[Address(RVA = "0x3E97F54", Offset = "0x3E97F54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GarageGroupHandler()
		{
		}
	}
}
