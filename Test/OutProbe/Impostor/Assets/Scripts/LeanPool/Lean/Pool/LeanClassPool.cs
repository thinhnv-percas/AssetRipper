using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Lean.Pool
{
	[Token(Token = "0x2000005")]
	public static class LeanClassPool<T> where T : class
	{
		[Token(Token = "0x4000006")]
		private static List<T> cache;

		[Token(Token = "0x6000005")]
		[Address(RVA = "0xFF706C", Offset = "0xFF706C", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv17 = 0xB348B0(v12, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0014:\n\tgoto L_0019;\n\tv40 = 0xB348B0(v35, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0019:\n\tgoto L_0020;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0020:\n\tgoto L_0028;\n\tv52 = 0xB348B0(v47, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0028:\n\tgoto L_002B;\n\tv60 = 0xB348B0(v55, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002B:\n\tv63 = v62.cache;\n\tgoto L_003F;\n\tv121 = 0xB348B0(v65, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003F:\n\tv110 = v63._size - 1;\n\tv84 = v63._size < 1;\n\tif (v84) goto L_FFFFFFFF;\n\tgoto L_0050;\n\tv163 = 0xB348B0(v126, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0050:\n\tgoto L_0055;\n\tv179 = 0xB348B0(v166, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0055:\n\tgoto L_005C;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v180, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_005C:\n\tgoto L_0064;\n\tv191 = 0xB348B0(v186, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0064:\n\tgoto L_006F;\n\tv199 = 0xB348B0(v194, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_006F:\n\tgoto L_0075;\n\tv205 = 0xB348B0(v200, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0075:\n\tv209 = System.Collections.Generic.List`1<T>::get_Item(v115.cache, v110);\n\tgoto L_0086;\n\tv214 = v210;\n\tv215 = System.Collections.Generic.List`1<T>::get_Item(v214, v78, v76);\n\tv217 = v215;\nL_0086:\n\tgoto L_0091;\n\tv225 = System.Collections.Generic.List`1<T>::get_Item(v220, v78, v76);\nL_0091:\n\tgoto L_0097;\n\tv230 = System.Collections.Generic.List`1<T>::get_Item(v226, v78, v76);\nL_0097:\n\tSystem.Collections.Generic.List`1<T>::RemoveAt(v116.cache, v110);\n\tgoto L_00A1;\nL_00A1:\n\treturn v174;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn()
		{
			List<T> list = cache;
			int index = list.Count - 1;
			if (list.Count >= 1)
			{
				T result = cache[index];
				cache.RemoveAt(index);
				return result;
			}
			return null;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0xFF71FC", Offset = "0xFF71FC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = v7;\n\tv17 = 0xB348B0(v16, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv34 = v17;\nL_0016:\n\tgoto L_001B;\n\tv41 = 0xB348B0(v36, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001B:\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\tgoto L_0028;\n\tv53 = 0xB348B0(v48, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\tv60 = Lean.Pool.LeanClassPool`1<T>::TrySpawn(onSpawn, &v57 @ stack_-18_v2 (T));\n\treturn v57;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn(Action<T> onSpawn)
		{
			T instance = default(T);
			bool flag = TrySpawn(onSpawn, ref instance);
			return instance;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0xFF727C", Offset = "0xFF727C", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv25 = v14;\n\tv26 = 0xB348B0(v25, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = v26;\nL_001A:\n\tgoto L_001F;\n\tv49 = 0xB348B0(v44, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_001F:\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tgoto L_002E;\n\tv61 = 0xB348B0(v56, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002E:\n\tgoto L_0031;\n\tv69 = 0xB348B0(v64, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\tv72 = v71.cache;\n\tgoto L_0045;\n\tv132 = 0xB348B0(v74, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0045:\n\tv118 = v72._size - 1;\n\tv90 = v72._size < 1;\n\tif (v90) goto L_00AE;\n\tgoto L_0056;\n\tv197 = 0xB348B0(v136, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0056:\n\tgoto L_005B;\n\tv205 = 0xB348B0(v200, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tgoto L_0062;\n\tv210 = \"il2cpp_codegen_runtime_class_init\"(v206, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0062:\n\tgoto L_006A;\n\tv217 = 0xB348B0(v212, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006A:\n\tgoto L_0075;\n\tv225 = 0xB348B0(v220, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tgoto L_007B;\n\tv231 = 0xB348B0(v226, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007B:\n\tv235 = System.Collections.Generic.List`1<T>::get_Item(v128.cache, v118);\n\t*([instance @ X1 (T&)]) = v235;\n\tgoto L_008A;\n\tv241 = System.Collections.Generic.List`1<T>::get_Item(v236, v83, v80);\nL_008A:\n\tgoto L_0095;\n\tv249 = System.Collections.Generic.List`1<T>::get_Item(v244, v83, v80);\nL_0095:\n\tgoto L_009B;\n\tv255 = System.Collections.Generic.List`1<T>::get_Item(v250, v83, v80);\nL_009B:\n\tSystem.Collections.Generic.List`1<T>::RemoveAt(v129.cache, v118);\n\tgoto L_00AA;\n\tv261 = System.Collections.Generic.List`1<T>::RemoveAt(v257, v84, v81);\nL_00AA:\n\tSystem.Action`1<T>::Invoke(onSpawn, *([instance @ X1 (T&)]));\nL_00AE:\n\tv157 = v72._size < 0;\n\tv158 = v72._size == 0;\n\tv160 = v72._size ^ v72._size;\n\tv161 = v72._size & v160;\n\tv162 = v161 < 0;\n\tv169 = v157 == v162;\n\tv170 = ~v158;\n\tv171 = v169 & v170;\n\treturn v171;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool TrySpawn(Action<T> onSpawn, ref T instance)
		{
			List<T> list = cache;
			int index = list.Count - 1;
			if (list.Count >= 1)
			{
				T val = cache[index];
				ref T reference = ref *(T*)val;
				cache.RemoveAt(index);
				onSpawn(instance);
			}
			bool flag = list.Count < 0;
			bool flag2 = list.Count == 0;
			int num = list.Count ^ list.Count;
			int num2 = list.Count & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0xFF7444", Offset = "0xFF7444", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = v7;\n\tv17 = 0xB348B0(v16, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv34 = v17;\nL_0016:\n\tgoto L_001B;\n\tv41 = 0xB348B0(v36, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001B:\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\tgoto L_0028;\n\tv53 = 0xB348B0(v48, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\tv60 = Lean.Pool.LeanClassPool`1<T>::TrySpawn(match, &v57 @ stack_-18_v2 (T));\n\treturn v57;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn(Predicate<T> match)
		{
			T instance = default(T);
			bool flag = TrySpawn(match, ref instance);
			return instance;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0xFF74C4", Offset = "0xFF74C4", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv21 = v10;\n\tv22 = 0xB348B0(v21, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = v22;\nL_0018:\n\tgoto L_001D;\n\tv45 = 0xB348B0(v40, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tgoto L_0024;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v46, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tgoto L_002C;\n\tv57 = 0xB348B0(v52, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tgoto L_0037;\n\tv65 = 0xB348B0(v60, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tgoto L_003D;\n\tv97 = 0xB348B0(v70, instance, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tv101 = System.Collections.Generic.List`1<T>::FindIndex(v67.cache, match);\n\tv102 = v101 & 0x80000000;\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0096;\n\tgoto L_0050;\n\tv140 = System.Collections.Generic.List`1<T>::FindIndex(v125, v79, v76);\nL_0050:\n\tgoto L_0055;\n\tv148 = System.Collections.Generic.List`1<T>::FindIndex(v143, v79, v76);\nL_0055:\n\tgoto L_005C;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v149, v79, v76, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005C:\n\tgoto L_0064;\n\tv160 = System.Collections.Generic.List`1<T>::FindIndex(v155, v79, v76);\nL_0064:\n\tgoto L_006F;\n\tv168 = System.Collections.Generic.List`1<T>::FindIndex(v163, v79, v76);\nL_006F:\n\tgoto L_0075;\n\tv174 = System.Collections.Generic.List`1<T>::FindIndex(v169, v79, v76);\nL_0075:\n\tv178 = System.Collections.Generic.List`1<T>::get_Item(v94.cache, v101);\n\t*([instance @ X1 (T&)]) = v178;\n\tgoto L_0084;\n\tv184 = System.Collections.Generic.List`1<T>::get_Item(v179, v80, v77);\nL_0084:\n\tgoto L_008F;\n\tv192 = System.Collections.Generic.List`1<T>::get_Item(v187, v80, v77);\nL_008F:\n\tgoto L_0095;\n\tv197 = System.Collections.Generic.List`1<T>::get_Item(v193, v80, v77);\nL_0095:\n\tSystem.Collections.Generic.List`1<T>::RemoveAt(v95.cache, v101);\nL_0096:\n\tv116 = ~v101;\n\treturnVal2 = v116 >> 0x1F;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool TrySpawn(Predicate<T> match, ref T instance)
		{
			//IL_003d: Expected I4, but got I8
			int num = cache.FindIndex(match);
			if ((int)(num & 0x80000000L) == 0)
			{
				T val = cache[num];
				ref T reference = ref *(T*)val;
				cache.RemoveAt(num);
			}
			int num2 = ~num;
			return (byte)(num2 >> 31) != 0;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0xFF7668", Offset = "0xFF7668", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = v9;\n\tv21 = 0xB348B0(v20, onSpawn, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = v21;\nL_0018:\n\tgoto L_001D;\n\tv44 = 0xB348B0(v39, onSpawn, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tgoto L_0024;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, onSpawn, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_002B;\n\tv56 = 0xB348B0(v51, onSpawn, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002B:\n\tv64 = Lean.Pool.LeanClassPool`1<T>::TrySpawn(match, onSpawn, &v60 @ stack_-28_v2 (T));\n\treturn v60;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn(Predicate<T> match, Action<T> onSpawn)
		{
			T instance = default(T);
			bool flag = TrySpawn(match, onSpawn, ref instance);
			return instance;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0xFF76F8", Offset = "0xFF76F8", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv25 = v12;\n\tv26 = 0xB348B0(v25, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = v26;\nL_001A:\n\tgoto L_001F;\n\tv48 = 0xB348B0(v43, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v49, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tgoto L_002E;\n\tv60 = 0xB348B0(v55, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tgoto L_0039;\n\tv68 = 0xB348B0(v63, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tgoto L_003F;\n\tv104 = 0xB348B0(v73, onSpawn, instance, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tv108 = System.Collections.Generic.List`1<T>::FindIndex(v70.cache, match);\n\tv109 = v108 & 0x80000000;\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_00A7;\n\tgoto L_0052;\n\tv150 = 0xB348B0(v134, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tgoto L_0057;\n\tv158 = 0xB348B0(v153, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0057:\n\tgoto L_005E;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v159, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005E:\n\tgoto L_0066;\n\tv170 = 0xB348B0(v165, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0066:\n\tgoto L_0071;\n\tv178 = 0xB348B0(v173, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0071:\n\tgoto L_0077;\n\tv184 = 0xB348B0(v179, v83, v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0077:\n\tv188 = System.Collections.Generic.List`1<T>::get_Item(v100.cache, v108);\n\t*([instance @ X2 (T&)]) = v188;\n\tgoto L_0086;\n\tv194 = 0xB348B0(v189, v84, v80, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0086:\n\tgoto L_0091;\n\tv202 = 0xB348B0(v197, v84, v80, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0091:\n\tgoto L_0097;\n\tv208 = 0xB348B0(v203, v84, v80, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0097:\n\tSystem.Collections.Generic.List`1<T>::RemoveAt(v101.cache, v108);\n\tgoto L_00A6;\n\tv214 = 0xB348B0(v210, v85, v81, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A6:\n\tSystem.Action`1<T>::Invoke(onSpawn, *([instance @ X2 (T&)]));\nL_00A7:\n\tv123 = ~v108;\n\treturnVal2 = v123 >> 0x1F;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool TrySpawn(Predicate<T> match, Action<T> onSpawn, ref T instance)
		{
			//IL_003d: Expected I4, but got I8
			int num = cache.FindIndex(match);
			if ((int)(num & 0x80000000L) == 0)
			{
				T val = cache[num];
				ref T reference = ref *(T*)val;
				cache.RemoveAt(num);
				onSpawn(instance);
			}
			int num2 = ~num;
			return (byte)(num2 >> 31) != 0;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0xFF78CC", Offset = "0xFF78CC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = instance == 0;\n\tif (v8) goto L_0055;\n\tgoto L_0016;\n\tv69 = 0xB348B0(v11, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_0016:\n\tgoto L_001B;\n\tv126 = 0xB348B0(v86, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_001B:\n\tgoto L_0022;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v127, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_0022:\n\tgoto L_002A;\n\tv138 = 0xB348B0(v133, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_002A:\n\tgoto L_002D;\n\tv146 = 0xB348B0(v141, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_002D:\n\tv55 = v148.cache;\n\tgoto L_0039;\n\tv158 = 0xB348B0(v150, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_0039:\n\tv156 = v55._items;\n\tv155 = v55._version + 1;\n\tv55._version = v155;\n\tv49 = v55._size;\n\tv161 = v55._size < v156.Length;\n\tv43 = ~v161;\n\tif (v43) goto L_0060;\n\tv52 = v55._size + 1;\n\tv55._size = v52;\n\tv156[v49 @ X10_v5 (System.Int32)] = instance;\nL_0055:\n\treturn;\nL_0060:\n\tSystem.Collections.Generic.List`1<T>::AddWithResize(v55, instance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Despawn(T instance)
		{
			if (instance != null)
			{
				List<T> list = cache;
				T[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = instance;
				}
				else
				{
					list.Add(instance);
				}
			}
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0xFF79BC", Offset = "0xFF79BC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = instance == 0;\n\tif (v8) goto L_0064;\n\tgoto L_0017;\n\tv135 = 0xB348B0(v71, onDespawn, methodInfo, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_0017:\n\tSystem.Action`1<T>::Invoke(onDespawn, instance);\n\tgoto L_0025;\n\tv145 = 0xB348B0(v140, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_0025:\n\tgoto L_002A;\n\tv153 = 0xB348B0(v148, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_002A:\n\tgoto L_0031;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v154, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_0031:\n\tgoto L_0039;\n\tv165 = 0xB348B0(v160, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_0039:\n\tgoto L_003C;\n\tv173 = 0xB348B0(v168, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_003C:\n\tv64 = v83.cache;\n\tgoto L_0048;\n\tv179 = 0xB348B0(v174, v50, v52, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105);\nL_0048:\n\tv84 = v64._items;\n\tv77 = v64._version + 1;\n\tv64._version = v77;\n\tv44 = v64._size;\n\tv182 = v64._size < v84.Length;\n\tv38 = ~v182;\n\tif (v38) goto L_006F;\n\tv47 = v64._size + 1;\n\tv64._size = v47;\n\tv84[v44 @ X10_v5 (System.Int32)] = instance;\nL_0064:\n\treturn;\nL_006F:\n\tSystem.Collections.Generic.List`1<T>::AddWithResize(v64, instance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Despawn(T instance, Action<T> onDespawn)
		{
			if (instance != null)
			{
				onDespawn(instance);
				List<T> list = cache;
				T[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = instance;
				}
				else
				{
					list.Add(instance);
				}
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0xFF7AD8", Offset = "0xFF7AD8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv13 = 0xB348B0(v8, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0012:\n\tgoto L_0014;\n\tv36 = 0xB348B0(v31, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0014:\n\tv38 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tgoto L_0022;\n\tv45 = v39;\n\tv46 = 0xB348B0(v45, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv48 = v46;\nL_0022:\n\tSystem.Collections.Generic.List`1<T>::.ctor(v38);\n\tgoto L_0030;\n\tv58 = System.Collections.Generic.List`1<T>::.ctor(v53, v52);\nL_0030:\n\tgoto L_0033;\n\tv66 = System.Collections.Generic.List`1<T>::.ctor(v61, v52);\nL_0033:\n\tv68.cache = v38;\n\tgoto L_003C;\n\tv74 = System.Collections.Generic.List`1<T>::.ctor(v69, v52);\nL_003C:\n\tv77 = Il2CppClass<Lean.Pool.LeanClassPool`1<T>>;\n\tv79 = *([v77 @ X0_v14 (Il2CppClass<Lean.Pool.LeanClassPool`1<T>>)+135]) & 1;\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_004C;\n\tv85 = System.Collections.Generic.List`1<T>::.ctor(Il2CppClass<Lean.Pool.LeanClassPool`1<T>>);\n\treturn;\nL_004C:\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LeanClassPool()
		{
			List<T> list = new List<T>();
			cache = list;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X0_v14 (Il2CppClass<Lean.Pool.LeanClassPool`1<T>>)+135]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
			}
		}
	}
}
