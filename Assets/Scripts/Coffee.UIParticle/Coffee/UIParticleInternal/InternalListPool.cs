using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Pool;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000017")]
	internal static class InternalListPool<T>
	{
		[Token(Token = "0x600005C")]
		[Address(RVA = "0x5588258", Offset = "0x5588258", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tv15 = *([v12 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>)+135]) & 1;\n\tv16 = v15 == 0;\n\tif (v16) goto L_0026;\n\tv18 = Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>;\n\tv21 = *([v18 @ X0_v19 (Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>)+135]) & 1;\n\tv22 = v21 == 0;\n\tv49 = Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>;\n\tif (v22) goto L_002F;\nL_0016:\n\tgoto L_0017;\nL_0017:\n\tv60 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tv63 = *([v60 @ X0_v17 (Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>)+135]) & 1;\n\tv64 = v63 == 0;\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tif (v64) goto L_003C;\nL_0024:\n\treturnVal1 = UnityEngine.Pool.CollectionPool`2<System.Object, System.Object>::Get();\n\treturn returnVal1;\nL_0026:\n\tv23 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = *([v23 @ X0_v11+C0]);\n\tv49 = *([v51 @ X8_v10+8]);\n\tv53 = *([v49 @ X0_v9 (Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>)+135]) & 1;\n\tv54 = v53 == 0;\n\tv40 = ~v54;\n\tif (v40) goto L_0016;\nL_002F:\n\tv50 = 0x220C238(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv69 = *([v50 @ X0_v10+E4]) == 0;\n\tv56 = ~v69;\n\tif (v56) goto L_0017;\n\tv75 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tv88 = *([v75 @ X0_v8 (Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>)+135]) & 1;\n\tv89 = v88 == 0;\n\tv71 = ~v89;\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tif (v71) goto L_0024;\nL_003C:\n\tv86 = 0x220C238(v85, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = UnityEngine.Pool.CollectionPool`2<System.Object, System.Object>::Get();\n\treturn returnVal2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<T> Rent()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InternalListPool::Rent");
			return default;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x5588308", Offset = "0x5588308", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = *([v30 @ X0_v1 (System.Collections.Generic.List`1<T>&)]) == 0;\n\tif (v16) goto L_002A;\n\tv20 = Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>;\n\tv23 = *([v20 @ X0_v3 (Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>)+135]) & 1;\n\tv24 = v23 == 0;\n\tif (v24) goto L_0035;\n\tv59 = Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>;\n\tv62 = *([v59 @ X0_v19 (Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv74 = Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>;\n\tif (v63) goto L_003E;\nL_001C:\n\tgoto L_0023;\nL_0023:\n\tgoto L_0028;\nL_0028:\n\tUnityEngine.Pool.CollectionPool`2<System.Object, System.Object>::Release(*([v30 @ X0_v1 (System.Collections.Generic.List`1<T>&)]));\nL_0035:\n\tv64 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.InternalListPool`1>, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv77 = *([v64 @ X0_v9+C0]);\n\tv74 = *([v77 @ X8_v9+8]);\n\tv79 = *([v74 @ X0_v7 (Il2CppClass<UnityEngine.Pool.CollectionPool`2<System.Collections.Generic.List`1<T>, T>>)+135]) & 1;\n\tv80 = v79 == 0;\n\tv70 = ~v80;\n\tif (v70) goto L_001C;\nL_003E:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = *([v76 @ X0_v8+E4]) == 0;\n\tv85 = ~v96;\n\tif (v85) goto L_0023;\n\tgoto L_004A;\nL_004A:\n\tgoto L_0028;\nL_002A:\n\t*([v30 @ X0_v1 (System.Collections.Generic.List`1<T>&)]) = 0;\n\treturn;\n")]
		public static void Return(ref List<T> toRelease)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InternalListPool::Return");
		}
	}
}
