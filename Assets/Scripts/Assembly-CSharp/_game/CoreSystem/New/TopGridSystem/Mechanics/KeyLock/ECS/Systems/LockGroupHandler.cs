using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems
{
	[Token(Token = "0x20001FD")]
	public class LockGroupHandler
	{
		[Inject(false)]
		[Token(Token = "0x400065D")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x600090F")]
		[Address(RVA = "0x3E8C970", Offset = "0x3E8C970", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv78 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv167 = 0;\n\tgoto L_0058;\nL_0055:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Add(v61, v458);\n\tv274 = Il2CppMethodInfo;\nL_0056:\n\tv167 = v167 + 1;\n\tv333 = *([v286 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv333 = v333 + 0x10;\n\tv298 = v324 - 1;\n\tv296 = v324 != 1;\n\tv324 = v298;\n\tif (v296) goto L_0063;\nL_007C:\n\tv346 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v78);\n\tv357 = v167 < v346;\n\tif (v357) goto L_00A1;\n\tgoto L_0122;\nL_008B:\n\tv360 = *([v333 @ X10_v16]) << 4;\n\tv361 = v286 + v360;\n\tv362 = v361 + 0x138;\n\t*([v362 @ X0_v32])(v366, v78, *([v362 @ X0_v32+8]), v274, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv376 = v167 >= v366;\n\tif (v376) goto L_0122;\nL_00A1:\n\tgoto L_00C8;\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v458);\n\tv460 = ~v459;\n\tv274 = 0;\n\tif (v460) goto L_0056;\n\tv475 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v458);\n\tv477 = ~v475;\n\tv274 = Il2CppMethodInfo;\n\tif (v477) goto L_0056;\n\tv476 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v458);\n\tv482 = v476 == 0;\n\tv478 = ~v482;\n\tv274 = Il2CppMethodInfo;\n\tif (v478) goto L_0056;\n\tv154 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v458);\n\tv90 = v154 != color;\n\tv274 = Il2CppMethodInfo;\n\tif (v90) goto L_0056;\n\tgoto L_0055;\nL_0122:\n\treturn v61;\nL_0038:\n\tv61 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v61);\nL_0058:\n\tv286 = *([v78 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv324 = *([v286 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv229 = *([v286 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v229) goto L_007C;\nL_0063:\n\tv338 = *([v333 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v338) goto L_008B;\nL_00C8:\n\tv458 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v78, v167);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<Entity> GetGroup(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockGroupHandler::GetGroup");
			return default;
		}

		[Token(Token = "0x6000910")]
		[Address(RVA = "0x3E8CC48", Offset = "0x3E8CC48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LockGroupHandler()
		{
		}
	}
}
