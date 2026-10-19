using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Components;

namespace _game.CoreSystem.New.TopGridSystem.Utils
{
	[Token(Token = "0x2000135")]
	public static class SandCubeQueryHelper
	{
		[Token(Token = "0x6000629")]
		[Address(RVA = "0x3DB29E0", Offset = "0x3DB29E0", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv67 = *([v51 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv195 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv69 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v69) goto L_004E;\n\tv194 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv194 = v194 + 0x10;\n\tv180 = v195 - 1;\n\tv160 = v195 != 1;\n\tv195 = v180;\n\tif (v160) goto L_0035;\nL_004E:\n\treturnVal2 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v51);\n\tv209 = returnVal2 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_006C;\nL_0059:\n\treturn returnVal2;\nL_005B:\n\tv213 = *([v194 @ X10_v12]) << 4;\n\tv214 = v67 + v213;\n\tv215 = v214 + 0x138;\n\t*([v215 @ X0_v21])(returnVal2, v51, *([v215 @ X0_v21+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv220 = returnVal2 == 0;\n\tif (v220) goto L_0059;\nL_006C:\n\tgoto L_0093;\nL_0035:\n\tv200 = *([v194 @ X10_v12-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v200) goto L_005B;\nL_0093:\n\tv307 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v51, 0);\n\tv309 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v307);\n\treturn v309.columns;\n")]
		public static int GetColumns(EntityManager em)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeQueryHelper::GetColumns");
			return default;
		}

		[Token(Token = "0x600062A")]
		[Address(RVA = "0x3DB2B6C", Offset = "0x3DB2B6C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv67 = *([v51 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv195 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv69 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v69) goto L_004E;\n\tv194 = *([v67 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv194 = v194 + 0x10;\n\tv180 = v195 - 1;\n\tv160 = v195 != 1;\n\tv195 = v180;\n\tif (v160) goto L_0035;\nL_004E:\n\treturnVal2 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v51);\n\tv209 = returnVal2 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_006C;\nL_0059:\n\treturn returnVal2;\nL_005B:\n\tv213 = *([v194 @ X10_v12]) << 4;\n\tv214 = v67 + v213;\n\tv215 = v214 + 0x138;\n\t*([v215 @ X0_v20])(returnVal2, v51, *([v215 @ X0_v20+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv220 = returnVal2 == 0;\n\tif (v220) goto L_0059;\nL_006C:\n\tgoto L_0093;\nL_0035:\n\tv200 = *([v194 @ X10_v12-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v200) goto L_005B;\nL_0093:\n\tv307 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v51, 0);\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v307);\n\treturn returnVal3;\n")]
		public static int GetRows(EntityManager em)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeQueryHelper::GetRows");
			return default;
		}
	}
}
