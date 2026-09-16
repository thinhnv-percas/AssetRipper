using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C2")]
	public sealed class StrongToWeakDictionary<TKey, TValue> where TValue : class
	{
		[Token(Token = "0x20001A3")]
		internal class WeakReference<T> : WeakReference where T : class
		{
			[Token(Token = "0x17000325")]
			public new T Target
			{
				[Token(Token = "0x6000CBD")]
				[Address(RVA = "0xD902D8", Offset = "0xD902D8", Length = "0x70")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = System.WeakReference::get_Target(this);\n\tgoto L_0016;\n\tv39 = v34;\n\tv40 = 0x8907BC(v39, v14, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0016:\n\tv42 = v15 == 0;\n\tif (v42) goto L_FFFFFFFF;\n\t// 26 IsInst returnVal2 @ X0_v4 (T), typeof(T), v15 @ X0_v2 (System.Object)\n\tv69 = returnVal2 == 0;\n\tv67 = ~v69;\n\tif (v67) goto L_0027;\n\tthrow System.InvalidCastException;\nL_0027:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					object target = base.Target;
					T val;
					if (target != null)
					{
						val = target as T;
						if (val == null)
						{
							throw new InvalidCastException();
						}
					}
					else
					{
						val = null;
					}
					return val;
				}
			}

			[Token(Token = "0x6000CBB")]
			[Address(RVA = "0xD90144", Offset = "0xD90144", Length = "0x178")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv25 = v18;\n\tv26 = 0x8907BC(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0014:\n\tv43 = target == 0;\n\tif (v43) goto L_003B;\n\tgoto L_001F;\n\tv54 = v44;\n\tv55 = 0x8907BC(v54, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001F:\n\tv58 = new Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, T>>();\n\tv66 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>;\n\tgoto L_002F;\n\tv95 = v66;\n\tv96 = 0x8907BC(v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv98 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>;\n\tv101 = *([v98 @ X22_v5 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>)+12E]);\nL_002F:\n\tv105 = *([v66 @ X23_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>)+12E]) & 1;\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0039;\n\tv126 = 0x8907BC(Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0039:\n\tv132 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, T>::.ctor(v58, target);\n\tgoto L_008B;\nL_003B:\n\tv49 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>;\n\tgoto L_0044;\n\tv59 = v49;\n\tv60 = 0x8907BC(v59, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv63 = *([v49 @ X20_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>)+12E]);\nL_0044:\n\tv64 = *([v49 @ X20_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>)+12E]) & 0x200;\n\tv65 = v64 == 0;\n\tif (v65) goto L_0074;\n\tgoto L_0050;\n\tv108 = v73;\n\tv109 = 0x8907BC(v108, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0050:\n\tv89 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>;\n\tgoto L_0059;\n\tv133 = v89;\n\tv134 = 0x8907BC(v133, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0059:\n\tv135 = *([v89 @ X20_v7 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>)+E0]) == 0;\n\tv83 = ~v135;\n\tif (v83) goto L_0074;\n\tgoto L_006A;\n\tv166 = v161;\n\tv167 = 0x8907BC(v166, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006A:\n\tgoto L_0074;\n\tv172 = v88;\n\tv173 = 0x8907BC(v172, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0074:\n\tgoto L_007D;\n\tv116 = v90;\n\tv117 = 0x8907BC(v116, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_007D:\n\tgoto L_FFFFFFFF;\n\tv136 = v120;\n\tv137 = 0x8907BC(v136, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008B:\n\treturn v151;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static WeakReference<T> Create(T target)
			{
				if (target != null)
				{
					WeakReference<T> result = new WeakReference<T>(target);
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X23_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakReference`1>)+12E]");
					if (0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
					}
					return result;
				}
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X20_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X20_v7 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				return WeakNullReference<T>.Singleton;
			}

			[Token(Token = "0x6000CBC")]
			[Address(RVA = "0xD902BC", Offset = "0xD902BC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.WeakReference::.ctor(this, target, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected WeakReference(T target)
				: base(target, trackResurrection: false)
			{
			}
		}

		[Token(Token = "0x20001A4")]
		internal class WeakNullReference<T> : WeakReference<T> where T : class
		{
			[Token(Token = "0x4000673")]
			public static readonly WeakNullReference<T> Singleton;

			[Token(Token = "0x17000326")]
			public override bool IsAlive
			{
				[Token(Token = "0x6000CBF")]
				[Address(RVA = "0xD8FF5C", Offset = "0xD8FF5C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return true;
				}
			}

			[Token(Token = "0x6000CBE")]
			[Address(RVA = "0xD8FF34", Offset = "0xD8FF34", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>), this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>), 0, methodof(EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, T>::.ctor), v7 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private WeakNullReference()
			{
				//IL_000e: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
			}

			[Token(Token = "0x6000CC0")]
			[Address(RVA = "0xD8FF64", Offset = "0xD8FF64", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv21 = v16;\n\tv22 = 0x8907BC(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tgoto L_001B;\n\tv45 = v40;\n\tv46 = 0x8907BC(v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv49 = new Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>>();\n\tv50 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>;\n\tgoto L_002B;\n\tv57 = v50;\n\tv58 = 0x8907BC(v57, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv60 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>;\n\tv63 = *([v60 @ X21_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>)+12E]);\nL_002B:\n\tv67 = *([v50 @ X22_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>)+12E]) & 1;\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0034;\n\tv71 = 0x8907BC(Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv76 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>::.ctor(v49);\n\tgoto L_0043;\n\tv82 = v77;\n\tv83 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>::.ctor(v82, v75);\nL_0043:\n\tgoto L_0047;\n\tv91 = v86;\n\tv92 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakNullReference`1<TKey, TValue, T>::.ctor(v91, v75);\nL_0047:\n\tv94.Singleton = v49;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static WeakNullReference()
			{
				WeakNullReference<T> singleton = new WeakNullReference<T>();
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X22_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2+WeakNullReference`1>)+12E]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				}
				Singleton = singleton;
			}
		}

		[Token(Token = "0x40003A8")]
		private static bool VerboseDebug;

		[Token(Token = "0x40003A9")]
		[FieldOffset(Offset = "0x0")]
		private readonly Dictionary<TKey, WeakReference<TValue>> mMap;

		[Token(Token = "0x40003AA")]
		[FieldOffset(Offset = "0x0")]
		private WeakReference mGcWatch;

		[Token(Token = "0x17000224")]
		public List<KeyValuePair<TKey, TValue>> Pairs
		{
			[Token(Token = "0x600070B")]
			[Address(RVA = "0xD9054C", Offset = "0xD9054C", Length = "0x540")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0016;\n\tv27 = v22;\n\tv28 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v27, methodInfo, v29, v30);\n\tv45 = *([v22 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]);\nL_0016:\n\tv46 = *([v22 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]) & 0x200;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0035;\n\tv50 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0024;\n\tv73 = v50;\n\tv74 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v73, methodInfo, v29, v30);\nL_0024:\n\tv75 = *([v50 @ X21_v39 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]) == 0;\n\tv60 = ~v75;\n\tif (v60) goto L_0035;\n\tgoto L_0035;\n\tv130 = v62;\n\tv131 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v130, methodInfo, v29, v30);\nL_0035:\n\tv68 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_003D;\n\tv76 = v68;\n\tv77 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v76, methodInfo, v29, v30);\nL_003D:\n\tv79 = *([v68 @ X21_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]);\n\tv111 = *([v79 @ X8_v9 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+8]);\n\tv81 = *([v79 @ X8_v9 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+8]) == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_009C;\n\tv89 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_004D;\n\tv134 = v89;\n\tv135 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v134, methodInfo, v29, v30);\n\tv138 = *([v89 @ X21_v33 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]);\nL_004D:\n\tv139 = *([v89 @ X21_v33 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]) & 0x200;\n\tv140 = v139 == 0;\n\tif (v140) goto L_0071;\n\tv150 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_005B;\n\tv198 = v150;\n\tv199 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v198, methodInfo, v29, v30);\nL_005B:\n\tv200 = *([v150 @ X21_v37 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]) == 0;\n\tv160 = ~v200;\n\tif (v160) goto L_0071;\n\tgoto L_0071;\n\tv278 = v162;\n\tv279 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v278, methodInfo, v29, v30);\nL_0071:\n\tgoto L_007D;\n\tv201 = v168;\n\tv202 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v201, methodInfo, v29, v30);\n\tv226 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2>;\n\tv205 = Il2CppRgctx<EasyMobile.Internal.StrongToWeakDictionary`2>;\nL_007D:\n\tgoto L_0081;\n\tv227 = v95;\n\tv228 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v227, methodInfo, v29, v30);\nL_0081:\n\tv231 = new Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>>();\n\tv284 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v231, v206.<>9, Il2CppMethodInfo);\n\tv97 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0094;\n\tv308 = v97;\n\tv309 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v308, v103, v99, v101);\nL_0094:\n\tv114 = *([v97 @ X22_v10 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]);\n\t*([v114 @ X8_v122 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+8]) = v231;\nL_009C:\n\tv121 = System.Linq.Enumerable::Select(this.mMap, v111);\n\tv125 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_00A9;\n\tv141 = v125;\n\tv142 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>::.ctor(v141, v117, v119, v100);\n\tv145 = *([v125 @ X21_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]);\nL_00A9:\n\tv146 = *([v125 @ X21_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]) & 0x200;\n\tv147 = v146 == 0;\n\tif (v147) goto L_00C8;\n\tv175 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_00B7;\n\tv212 = v175;\n\tv213 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>, System.Collections.Generic.KeyValuePair`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValu\n// ... truncated")]
			get
			{
				//IL_0076: Expected O, but got I
				//IL_01a9: Expected O, but got I
				//IL_02dc: Expected O, but got I
				//IL_04a0: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X21_v39 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X21_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v9 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+8]");
				Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, WeakReference<TValue>>> selector = (Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, WeakReference<TValue>>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v9 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+8]");
				IntPtr intPtr9;
				if ((IntPtr)0 == (IntPtr)0)
				{
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v33 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X21_v37 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, WeakReference<TValue>>> func = delegate
					{
						//IL_0010: Expected O, but got I
						//IL_0020: Expected O, but got I
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X3+18]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ X8_v1+C0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1189348 (inside System.Collections.Generic.HashSet`1<System.Object>::InternalGetHashCode +0xB88)");
						KeyValuePair<TKey, WeakReference<TValue>> result = default(KeyValuePair<TKey, WeakReference<TValue>>);
						return result;
					};
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X22_v10 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
					IntPtr intPtr8 = (IntPtr)0;
					intPtr9 = (IntPtr)0;
					selector = func;
				}
				IEnumerable<KeyValuePair<TKey, WeakReference<TValue>>> source = mMap.Select(selector);
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X21_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr11 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X21_v31 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr12 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X21_v8 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr13 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X8_v22 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+10]");
				Func<KeyValuePair<TKey, WeakReference<TValue>>, bool> predicate = (Func<KeyValuePair<TKey, WeakReference<TValue>>, bool>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X8_v22 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+10]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					IntPtr intPtr14 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X21_v25 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr15 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ X21_v29 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					Func<KeyValuePair<TKey, WeakReference<TValue>>, bool> func2 = delegate
					{
						//IL_0008: Expected O, but got I
						//IL_0018: Expected O, but got I
						//IL_0028: Expected O, but got I
						IntPtr intPtr27 = default(IntPtr);
						object obj2 = (long)intPtr27;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1+180]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1+188]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: X0)");
						return false;
					};
					IntPtr intPtr16 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X22_v8 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
					IntPtr intPtr17 = (IntPtr)0;
					intPtr9 = (IntPtr)0;
					predicate = func2;
				}
				IEnumerable<KeyValuePair<TKey, WeakReference<TValue>>> source2 = source.Where(predicate);
				IntPtr intPtr18 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ X21_v11 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr19 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X21_v23 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr20 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ X21_v13 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr21 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X8_v35 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+18]");
				Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, TValue>> selector2 = (Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, TValue>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X8_v35 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_0481;
				}
				IntPtr intPtr22 = (IntPtr)0;
				goto IL_04aa;
				IL_04aa:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X21_v17 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr23 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ X21_v21 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				Func<KeyValuePair<TKey, WeakReference<TValue>>, KeyValuePair<TKey, TValue>> func3 = delegate
				{
					//IL_0010: Expected O, but got I
					//IL_0020: Expected O, but got I
					//IL_0030: Expected O, but got I
					//IL_004a: Expected O, but got I
					//IL_005a: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X3+18]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X8_v1+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v2+38]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v1] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X3+18]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X8_v4+C0]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1189348 (inside System.Collections.Generic.HashSet`1<System.Object>::InternalGetHashCode +0xB88)");
					KeyValuePair<TKey, TValue> result = default(KeyValuePair<TKey, TValue>);
					return result;
				};
				IntPtr intPtr24 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ X22_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr25 = (IntPtr)0;
				intPtr9 = (IntPtr)0;
				selector2 = func3;
				goto IL_0481;
				IL_0481:
				IEnumerable<KeyValuePair<TKey, TValue>> enumerable = source2.Select(selector2);
				IntPtr intPtr26 = (IntPtr)0;
				object obj = (long)intPtr26;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v441 @ X2_v7 (should have been resolved before IL gen)");
				goto IL_04aa;
			}
		}

		[Token(Token = "0x17000225")]
		public List<TValue> Values
		{
			[Token(Token = "0x600070C")]
			[Address(RVA = "0xD90A8C", Offset = "0xD90A8C", Length = "0x204")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(this);\n\tv42 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_001D;\n\tv48 = v42;\n\tv49 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v48, v22);\n\tv52 = *([v42 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]);\nL_001D:\n\tv53 = *([v42 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]) & 0x200;\n\tv54 = v53 == 0;\n\tif (v54) goto L_003C;\n\tv57 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_002B;\n\tv110 = v57;\n\tv111 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v110, v22);\nL_002B:\n\tv112 = *([v57 @ X21_v13 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]) == 0;\n\tv72 = ~v112;\n\tif (v72) goto L_003C;\n\tgoto L_003C;\n\tv155 = v63;\n\tv156 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v155, v22);\nL_003C:\n\tv75 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0044;\n\tv113 = v75;\n\tv114 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v113, v22);\nL_0044:\n\tv116 = *([v75 @ X21_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]);\n\tv139 = *([v116 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+20]);\n\tv118 = *([v116 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+20]) == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_00A3;\n\tv126 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0054;\n\tv159 = v126;\n\tv160 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v159, v22);\n\tv163 = *([v126 @ X21_v7 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]);\nL_0054:\n\tv164 = *([v126 @ X21_v7 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]) & 0x200;\n\tv165 = v164 == 0;\n\tif (v165) goto L_0078;\n\tv168 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_0062;\n\tv191 = v168;\n\tv192 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v191, v22);\nL_0062:\n\tv193 = *([v168 @ X21_v11 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]) == 0;\n\tv183 = ~v193;\n\tif (v183) goto L_0078;\n\tgoto L_0078;\n\tv215 = v174;\n\tv216 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v215, v22);\nL_0078:\n\tgoto L_0084;\n\tv194 = v186;\n\tv195 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v194, v22);\n\tv209 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2>;\n\tv198 = Il2CppRgctx<EasyMobile.Internal.StrongToWeakDictionary`2>;\nL_0084:\n\tgoto L_0088;\n\tv210 = v132;\n\tv211 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::get_Pairs(v210, v22);\nL_0088:\n\tv214 = new Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, TValue>, TValue>>();\n\tv221 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, TValue>, TValue>::.ctor(v214, v199.<>9, Il2CppMethodInfo);\n\tv134 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>;\n\tgoto L_009B;\n\tv227 = v134;\n\tv228 = System.Func`2<System.Collections.Generic.KeyValuePair`2<TKey, TValue>, TValue>::.ctor(v227, v144, v136, v137);\nL_009B:\n\tv146 = *([v134 @ X22_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]);\n\t*([v146 @ X8_v33 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+20]) = v214;\nL_00A3:\n\tv98 = System.Linq.Enumerable::Select(v24, v139);\n\tv100 = Il2CppMethodInfo;\n\tv87 = *([v100 @ X1_v4 (Il2CppMethodInfo)]);\n\t// 176 IndirectJump v87 @ X2_v3, v98 @ X0_v8 (System.Collections.Generic.IEnumerable`1<TValue>), v98 @ X0_v8 (System.Collections.Generic.IEnumerable`1<TValue>), methodof(System.Linq.Enumerable::ToList), v87 @ X2_v3, v89 @ X3_v1 (Il2CppMethodInfo), v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0080: Expected O, but got I
				//IL_019a: Expected O, but got I
				List<KeyValuePair<TKey, TValue>> pairs = Pairs;
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X21_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X21_v13 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X21_v3 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+20]");
				Func<KeyValuePair<TKey, TValue>, TValue> selector = (Func<KeyValuePair<TKey, TValue>, TValue>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+20]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_017b;
				}
				IntPtr intPtr5 = (IntPtr)0;
				goto IL_01a4;
				IL_01a4:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X21_v7 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X21_v11 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				Func<KeyValuePair<TKey, TValue>, TValue> func = delegate
				{
					//IL_0005: Expected O, but got I
					IntPtr intPtr11 = default(IntPtr);
					return (TValue)(long)intPtr11;
				};
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X22_v4 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+<>c<TKey, TValue>>)+B8]");
				IntPtr intPtr8 = (IntPtr)0;
				IntPtr intPtr9 = (IntPtr)0;
				selector = func;
				goto IL_017b;
				IL_017b:
				IEnumerable<TValue> enumerable = pairs.Select(selector);
				IntPtr intPtr10 = (IntPtr)0;
				object obj = (long)intPtr10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v87 @ X2_v3 (should have been resolved before IL gen)");
				goto IL_01a4;
			}
		}

		[Token(Token = "0x600070D")]
		[Address(RVA = "0xD90C90", Offset = "0xD90C90", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = System.Collections.Generic.EqualityComparer`1<TKey>::get_Default();\n\tv41 = Il2CppMethodInfo;\n\tv42 = *([v41 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 27 IndirectJump v42 @ X3_v1, this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), v19 @ X0_v2 (System.Collections.Generic.EqualityComparer`1<TKey>), methodof(EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::.ctor), v42 @ X3_v1, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StrongToWeakDictionary()
		{
			//IL_001c: Expected O, but got I
			EqualityComparer<TKey> equalityComparer = EqualityComparer<TKey>.Default;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v42 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600070E")]
		[Address(RVA = "0xD90CEC", Offset = "0xD90CEC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_0016;\n\tv27 = v22;\n\tv28 = 0x8907BC(v27, comparer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = *([v22 @ X22_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]);\nL_0016:\n\tv45 = *([v22 @ X22_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]) & 0x200;\n\tv46 = v45 == 0;\n\tif (v46) goto L_0037;\n\tv49 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_0024;\n\tv71 = v49;\n\tv72 = 0x8907BC(v71, comparer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tv73 = *([v49 @ X22_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]) == 0;\n\tv59 = ~v73;\n\tif (v59) goto L_0037;\n\tgoto L_0037;\n\tv89 = v61;\n\tv90 = 0x8907BC(v89, comparer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0037:\n\tv69 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::AllocWeakRef();\n\tthis.mGcWatch = v69;\n\tSystem.Object::.ctor(this);\n\tgoto L_0049;\n\tv93 = v84;\n\tv94 = 0x8907BC(v93, v75, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0049:\n\tv97 = new Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>();\n\tv105 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::.ctor(v97, comparer);\n\tthis.mMap = v97;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StrongToWeakDictionary(IEqualityComparer<TKey> comparer)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X22_v1 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X22_v6 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			mGcWatch = AllocWeakRef();
			base._002Ector();
			Dictionary<TKey, WeakReference<TValue>> dictionary = new Dictionary<TKey, WeakReference<TValue>>(comparer);
			mMap = dictionary;
		}

		[Token(Token = "0x600070F")]
		[Address(RVA = "0xD90DF8", Offset = "0xD90DF8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>::Create(value);\n\tv49 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::Add(this.mMap, key, v28);\n\tv57 = Il2CppMethodInfo;\n\tv58 = *([v57 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 41 IndirectJump v58 @ X2_v2, this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), methodof(EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullIfNeeded), v58 @ X2_v2, methodof(System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::Add), v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(TKey key, TValue value)
		{
			//IL_0033: Expected O, but got I
			WeakReference<TValue> value2 = WeakReference<TValue>.Create(value);
			mMap.Add(key, value2);
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000710")]
		[Address(RVA = "0xD90E84", Offset = "0xD90E84", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>::Create(value);\n\tv49 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::set_Item(this.mMap, key, v28);\n\tv57 = Il2CppMethodInfo;\n\tv58 = *([v57 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 41 IndirectJump v58 @ X2_v2, this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), this @ X0 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>), methodof(EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullIfNeeded), v58 @ X2_v2, methodof(System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::set_Item), v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Put(TKey key, TValue value)
		{
			//IL_0033: Expected O, but got I
			WeakReference<TValue> value2 = WeakReference<TValue>.Create(value);
			mMap.set_Item(key, value2);
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000711")]
		[Address(RVA = "0xD90F10", Offset = "0xD90F10", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullIfNeeded(this);\n\tv38 = this.mMap;\n\tv53 = Il2CppMethodInfo;\n\tv54 = *([v53 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 32 IndirectJump v54 @ X3_v1, v38 @ X0_v5 (System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>), v38 @ X0_v5 (System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>), key @ X1 (TKey), methodof(System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::Remove), v54 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(TKey key)
		{
			//IL_0023: Expected O, but got I
			CullIfNeeded();
			Dictionary<TKey, WeakReference<TValue>> dictionary = mMap;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000712")]
		[Address(RVA = "0xD90F78", Offset = "0xD90F78", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::TryGetValue(this.mMap, key, &v20 @ stack_-28_v3 (EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>));\n\tv39 = v24 == 0;\n\tif (v39) goto L_0027;\n\tv58 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>::get_Target(v20);\n\t*([value @ X2 (TValue&)]) = v58;\n\tv67 = System.WeakReference::get_IsAlive(v20);\n\tgoto L_002E;\nL_0027:\n\t*([value @ X2 (TValue&)]) = 0;\nL_002E:\n\treturn v67;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool TryGetValue(TKey key, out TValue value)
		{
			value = null;
			ref TValue reference;
			if (mMap.TryGetValue(key, out var value2))
			{
				TValue target = value2.Target;
				reference = ref *(TValue*)target;
				return value2.IsAlive;
			}
			reference = ref *(TValue*)null;
			return false;
		}

		[Token(Token = "0x6000713")]
		[Address(RVA = "0xD91010", Offset = "0xD91010", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF2090]);\n\tv23 = *([v22 @ X8_v56]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20240B3]) = v41;\nL_001B:\n\tv47 = System.WeakReference::get_IsAlive(this.mGcWatch);\n\tv49 = v47 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_00BE;\n\tv67 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_002B;\n\tv91 = v67;\n\tv92 = 0x8907BC(v91, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv95 = *([v67 @ X21_v5 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]);\nL_002B:\n\tv96 = *([v67 @ X21_v5 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]) & 0x200;\n\tv97 = v96 == 0;\n\tif (v97) goto L_004F;\n\tv111 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_0039;\n\tv134 = v111;\n\tv135 = 0x8907BC(v134, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tv136 = *([v111 @ X21_v15 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]) == 0;\n\tv121 = ~v136;\n\tif (v121) goto L_004F;\n\tgoto L_004F;\n\tv178 = v126;\n\tv179 = 0x8907BC(v178, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004F:\n\tgoto L_0054;\n\tv137 = v129;\n\tv138 = 0x8907BC(v137, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0054:\n\tv142 = ~v140.VerboseDebug;\n\tif (v142) goto L_0089;\n\tgoto L_0067;\n\tv182 = *([v151 @ X0_v27+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0067;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v151, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0067:\n\tv57 = System.Type::GetTypeFromHandle(Il2CppClass<TValue>);\n\tv218 = System.Type::ToString(v57);\n\tv222 = System.String::Concat(v218, \" StrongToWeakDict: GC has occurred. Start culling dict...\");\n\tgoto L_0083;\n\tv235 = *([v163 @ X8_v44+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0083;\n\tv244 = v163;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v244, v221, v154, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0083:\n\tUnityEngine.Debug::Log(v222);\nL_0089:\n\tv170 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullDeadEntries(this);\n\tv173 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_0095;\n\tv189 = v173;\n\tv190 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullDeadEntries(v189, v75);\n\tv193 = *([v173 @ X21_v9 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]);\nL_0095:\n\tv194 = *([v173 @ X21_v9 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]) & 0x200;\n\tv195 = v194 == 0;\n\tif (v195) goto L_00B6;\n\tv198 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_00A3;\n\tv223 = v198;\n\tv224 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullDeadEntries(v223, v75);\nL_00A3:\n\tv225 = *([v198 @ X21_v11 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]) == 0;\n\tv207 = ~v225;\n\tif (v207) goto L_00B6;\n\tgoto L_00B6;\n\tv240 = v211;\n\tv241 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::CullDeadEntries(v240, v75);\nL_00B6:\n\tv79 = EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>::AllocWeakRef();\n\tthis.mGcWatch = v79;\nL_00BE:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CullIfNeeded()
		{
			if (mGcWatch.IsAlive)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X21_v5 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X21_v15 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			if (VerboseDebug)
			{
				Type typeFromHandle = typeof(TValue);
				string text = typeFromHandle.ToString();
				string message = text + " StrongToWeakDict: GC has occurred. Start culling dict...";
				Debug.Log(message);
			}
			CullDeadEntries();
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X21_v9 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X21_v11 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			WeakReference weakReference = AllocWeakRef();
			mGcWatch = weakReference;
		}

		[Token(Token = "0x6000714")]
		[Address(RVA = "0xD91238", Offset = "0xD91238", Length = "0x6EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = &v19 @ X29;\n\tgoto L_001D;\n\tv33 = *([1EF3948]);\n\tv34 = *([v33 @ X8_v135]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20240B4]) = v52;\nL_001D:\n\tv54 = &v55 @ stack_-100;\n\t*([v19 @ X29-60]) = 0;\n\t*([v19 @ X29-98]) = 0;\n\t*([v19 @ X29-90]) = 0;\n\t*([v19 @ X29-80]) = 0;\n\t*([v19 @ X29-70]) = 0;\n\t*([v19 @ X29-A0]) = 0;\n\tv59 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_0030;\n\tv64 = v59;\n\tv65 = 0x8907BC(v64, methodInfo, v36, v37, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\n\tv68 = *([v59 @ X21_v2 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]);\nL_0030:\n\tv69 = *([v59 @ X21_v2 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]) & 0x200;\n\tv70 = v69 == 0;\n\tif (v70) goto L_0054;\n\tv73 = Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>;\n\tgoto L_003E;\n\tv96 = v73;\n\tv97 = 0x8907BC(v96, methodInfo, v36, v37, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\nL_003E:\n\tv98 = *([v73 @ X21_v32 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]) == 0;\n\tv83 = ~v98;\n\tif (v83) goto L_0054;\n\tgoto L_0054;\n\tv119 = v88;\n\tv120 = 0x8907BC(v119, methodInfo, v36, v37, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\nL_0054:\n\tgoto L_0059;\n\tv99 = v91;\n\tv100 = 0x8907BC(v99, methodInfo, v36, v37, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\nL_0059:\n\tv104 = ~v102.VerboseDebug;\n\tif (v104) goto L_009E;\n\tgoto L_006C;\n\tv123 = *([v113 @ X0_v103+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_006C;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v113, methodInfo, v36, v37, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\nL_006C:\n\tv132 = System.Type::GetTypeFromHandle(Il2CppClass<TValue>);\n\tv235 = System.Type::ToString(v132);\n\tv146 = this + 0x10;\n\tv305 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::get_Count(this.mMap);\n\t*([v19 @ X29-D8]) = v305;\n\tv308 = &v19 @ X29 - 0xD8;\n\t// 132 Box v311 @ X0_v111 (System.Object), typeof(System.Int32), v308 @ X1_v36\n\tv386 = System.String::Concat(v235, \" StrongToWeakDict: count BEFORE culling: \", v311);\n\tgoto L_009C;\n\tv474 = *([v149 @ X8_v123+E0]);\n\tv475 = v474 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_009C;\n\tv501 = v149;\n\tv478 = \"il2cpp_codegen_runtime_class_init\"(v501, v385, v136, v134, v38, v39, v40, v41, v53, v43, v44, v45, v46, v47, v48, v49);\nL_009C:\n\tUnityEngine.Debug::Log(v386);\n\tgoto L_00A7;\nL_009E:\n\tv146 = this + 0x10;\nL_00A7:\n\tv160 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>::GetEnumerator(*([v146 @ X20_v2]));\n\t*([v19 @ X29-60]) = *([v19 @ X29-B8]);\n\t*([v19 @ X29-80]) = *([v19 @ X29-D8]);\n\t*([v19 @ X29-70]) = *([v19 @ X29-C8]);\nL_00B2:\n\tv262 = &v19 @ X29 - 0x80;\n\tv263 = System.Collections.Generic.List`1<TKey>::Add(v262, Il2CppMethodInfo);\n\tv312 = v263 & 1;\n\tv313 = v312 == 0;\n\tif (v313) goto L_00E6;\n\tv387 = *([v19 @ X29-68]);\n\tv255 = *([v387 @ X0_v78]);\n\t*([v255 @ X8_v97+180])(v249, v387, *([v255 @ X8_v97+188]), v241, 0, v38, v39, v40, v41, *([v19 @ X29-C8]), *([v19 @ X29-D8]), v44, v45, v46, v47, v48, v49);\n\tv397 = v249 & 1;\n\tv398 = v397 == 0;\n\tv252 = ~v398;\n\tif (v252) goto L_00B2;\n\tv479 = v240 == 0;\n\tv480 = ~v479;\n\tif (v480) goto L_00E1;\n\tgoto L_00D1;\n\tv545 = v504;\n\tv546 = System.Collections.Generic.List`1<TKey>::Add(v545, v244, v241);\nL_00D1:\n\tv549 = new Il2CppClass<System.Collections.Generic.List`1<TKey>>();\n\tv485 = System.Collections.Generic.List`1<TKey>::.ctor(v549);\n\tv486 = v549 == 0;\n\tif (v486) goto L_00EA;\nL_00E1:\n\tv250 = System.Collections.Generic.List`1<TKey>::Add(v240, *([v19 @ X29-70]));\n\tgoto L_00B2;\nL_00E6:\n\t*([v54 @ X24_v1]) = 0x8C;\n\tgoto L_0103;\n\tthrow System.NullReferenceException;\nL_00EA:\n\tv369 = new System.NullReferenceException();\n\tgoto L_00EF;\n\tgoto L_00FB;\n\tgoto L_00EF;\nL_00EF:\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\nL_00FB:\n\tv325 = Il2CppMethodInfo != 1;\n\tif (v325) goto L_027C;\n\tv604 = System.Collections.Generic.List`1<TKey>::Add(v369, Il2CppMethodInfo);\n\tv699 = *([v604 @ X0_v82 (System.Collections.Generic.List`1<TKey>)]);\n\tv414 = System.Collections.Generic.List`1<TKey>::Add(v604, Il2CppMethodInfo);\nL_0103:\n\tv317 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>;\n\tgoto L_010F;\n\tv489 = v317;\n\tv490 = System.Collections.Generic.List`1<TKey>::Add(v489, v411, v241);\nL_010F:\n\t*([v19 @ X29-D8]) = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>;\n\t*([v19 @ X29-D0]) = -1;\n\t*([v19 @ X29-A8]) = *([v19 @ X29-60]);\n\t*([v19 @ X29-B8]) = *([v19 @ X29-70]);\n\t*([v19 @ X29-C8]) = *([v19 @ X29-80]);\n\tv498 = &v19 @ X29 - 0xD8;\n\tv177 = v498 + 0x10;\n\tv500 = *([v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>)+126]) == 0;\n\tif (v500) goto L_0137;\n\tv551 = *([v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>)+B0]) + 8;\nL_011F:\n\t;\n\tv566 = *([v551 @ X10_v14-8]) == System.IDisposable;\n\tif (v566) goto L_013C;\n\tv561 = v561 + 1;\n\tv575 = v561 < *([v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>>)+126]);\n\tv539 = ~v575;\n\tv551 = v551 + 0x10;\n\tv523 = ~v539;\n\tif (v523) goto L_011F;\nL_0137:\n\tv542 = &v19 @ X29 - 0xD8;\n\tv591 = System.Collections.Generic.List`1<TKey>::Add(v542, System.IDisposable);\n\tgoto L_0141;\nL_013C:\n\tv577 = *([v551 @ X10_v14]) << 4;\n\tv578 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>> + v577;\n\tv591 = v578 + 0x130;\nL_0141:\n\tv595 = &v19 @ X29 - 0xD8;\n\t*([v591 @ X0_v13])(v596, v595, *([v591 @ X0_v13+8]), v681, 0, v38, v39, v40, v41, *([v19 @ X29-70]), *([v19 @ X29-80]), v44, v45, v46, v47, v48, v49);\n\tv599 = v672 + 1;\n\tv601 = v599 == 0;\n\t*([v19 @ X29-60]) = *([v177 @ X27_v1+20]);\n\t*([v19 @ X29-80]) = *([v177 @ X27_v1]);\n\t*([v19 @ X29-70]) = *([v177 @ X27_v1+10]);\n\tif (v601) goto L_0160;\n\tv615 = *([v54 @ X24_v1+v672 @ X25_v7 (System.Int32)*4]) != 0x8C;\n\tif (v615) goto L_0160;\n\tv629 = v240 == 0;\n\tv630 = ~v629;\n\tif (v630) goto L_016B;\n\tgoto L_01F6;\nL_0160:\n\tv626 = v699 == 0;\n\tv627 = ~v626;\n\tif (v627) goto L_01F0;\n\tv631 = v240 == 0;\n\tif (v631) goto L_01F6;\nL_016B:\n\tv721 = System.Collections.Generic.List`1<TKey>::GetEnumerator(v240);\n\t*([v19 @ X29-90]) = *([v19 @ X29-C8]);\n\t*([v19 @ X29-A0]) = *([v19 @ X29-D8]);\nL_0173:\n\tv757 = &v19 @ X29 - 0xA0;\n\tv758 = System.Collections.Generic.List`1<TKey>::Add(v757, Il2CppMethodInfo);\n\tv766 = v758 & 1;\n\tv767 = v766 == 0;\n\tif (v767) goto L_0183;\n\tv373 = *([v146 @ X20_v2]) == 0;\n\tif (v373) goto L_0187;\n\tv752 = System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>\n// ... truncated")]
		public void CullDeadEntries()
		{
			//IL_010c: Expected O, but got I
			//IL_0152: Expected I, but got O
			//IL_0878: Expected O, but got I
			//IL_0883: Expected O, but got I
			//IL_023d: Expected O, but got I4
			//IL_024b: Expected I, but got O
			//IL_009d: Expected O, but got I
			//IL_0167: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00ce: Expected I4, but got O
			//IL_02f6: Expected O, but got I
			//IL_0305: Expected O, but got I
			//IL_03b4: Expected O, but got I
			//IL_03cc: Expected I, but got O
			//IL_08f4: Expected O, but got I
			//IL_0340: Expected O, but got I
			//IL_0229: Expected O, but got I
			//IL_03df: Expected I4, but got O
			//IL_03ea: Expected O, but got I
			//IL_03f9: Expected O, but got I
			//IL_038c: Expected O, but got I
			//IL_0957: Expected O, but got I
			//IL_0962: Expected O, but got I
			//IL_0831: Expected O, but got I
			//IL_028c: Expected O, but got I
			//IL_0294: Expected I, but got O
			//IL_029f: Expected O, but got I
			//IL_05bd: Expected O, but got I
			//IL_05cc: Expected O, but got I
			//IL_067b: Expected O, but got I
			//IL_0693: Expected I, but got O
			//IL_0509: Expected O, but got I
			//IL_09c8: Expected O, but got I
			//IL_0607: Expected O, but got I
			//IL_07ea: Expected O, but got I
			//IL_07f3: Expected I4, but got O
			//IL_0568: Expected O, but got I
			//IL_0570: Expected I, but got O
			//IL_057b: Expected O, but got I
			//IL_06a6: Expected I4, but got O
			//IL_06b1: Expected O, but got I
			//IL_06c0: Expected O, but got I
			//IL_0653: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X21_v2 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X21_v32 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			object obj4;
			object obj6 = default(object);
			if (VerboseDebug)
			{
				Type typeFromHandle = typeof(TValue);
				string text = typeFromHandle.ToString();
				obj4 = (long)(IntPtr)this + 16L;
				int count = mMap.Count;
				object obj5 = (long)(IntPtr)obj - 216L;
				obj6 = (int)obj5;
				string message = text + " StrongToWeakDict: count BEFORE culling: " + obj6;
				Debug.Log(message);
			}
			else
			{
				obj4 = (long)(IntPtr)this + 16L;
			}
			Dictionary<TKey, WeakReference<TValue>>.Enumerator enumerator = ((Dictionary<TKey, WeakReference<TValue>>)obj4).GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-D8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-C8]");
			_ = 0;
			List<TKey> list = null;
			IntPtr intPtr3 = (IntPtr)obj6;
			object obj7 = default(object);
			object obj10 = default(object);
			NullReferenceException ex = default(NullReferenceException);
			List<TKey> list4 = default(List<TKey>);
			List<TKey> list6 = default(List<TKey>);
			object obj23 = default(object);
			while (true)
			{
				List<TKey> list2 = (List<TKey>)((long)(IntPtr)obj - 128L);
				list2.Add((TKey)0);
				IntPtr intPtr4;
				int num;
				if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-68]");
					object obj8 = 0;
					object obj9 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ X8_v97+180] (should have been resolved before IL gen)");
					if ((uint)((ulong)(long)(IntPtr)obj10 & 1uL) != 0)
					{
						continue;
					}
					if (list == null)
					{
						List<TKey> list3 = new List<TKey>();
						bool flag = list3 == null;
						list = list3;
						if (flag)
						{
							ex = new NullReferenceException();
							if ((IntPtr)0 != (IntPtr)1)
							{
								break;
							}
							((List<TKey>)(object)ex).Add((TKey)0);
							intPtr4 = (IntPtr)list4;
							list4.Add((TKey)0);
							num = -1;
							list = null;
							goto IL_08af;
						}
					}
					List<TKey> list5 = list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-70]");
					list5.Add((TKey)0);
					intPtr3 = (IntPtr)0;
					continue;
				}
				obj2 = 140;
				num = 0;
				intPtr4 = (IntPtr)null;
				goto IL_08af;
				IL_0531:
				NullReferenceException ex2 = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					break;
				}
				((List<TKey>)(object)ex2).Add((TKey)0);
				intPtr4 = (IntPtr)list6;
				list6.Add((TKey)0);
				goto IL_0580;
				IL_08e5:
				object obj11 = (long)(IntPtr)obj - 216L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v591 @ X0_v13] (should have been resolved before IL gen)");
				int num2 = num + 1;
				bool flag2 = num2 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X27_v1+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X27_v1+10]");
				_ = 0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v672 @ X25_v7 (System.Int32)*4]");
					if ((IntPtr)0 == (IntPtr)140)
					{
						bool flag3 = list == null;
						bool flag4 = !flag3;
						num = -1;
						if (flag4)
						{
							goto IL_04a9;
						}
						goto IL_0735;
					}
				}
				if (intPtr4 != (IntPtr)0)
				{
					goto IL_0707;
				}
				if (list != null)
				{
					goto IL_04a9;
				}
				goto IL_0735;
				IL_0580:
				IntPtr intPtr5 = (IntPtr)0;
				_ = 0;
				_ = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-A0]");
				_ = 0;
				object obj12 = (long)(IntPtr)obj - 216L;
				object obj13 = (long)(IntPtr)obj12 + 16L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ X22_v8 (Il2CppClass<System.Collections.Generic.List`1<TKey>+Enumerator<TKey>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_066c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ X22_v8 (Il2CppClass<System.Collections.Generic.List`1<TKey>+Enumerator<TKey>>)+B0]");
				object obj14 = 0L + 8L;
				int num3 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ X10_v9-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
					{
						break;
					}
					num3++;
					int num4 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ X22_v8 (Il2CppClass<System.Collections.Generic.List`1<TKey>+Enumerator<TKey>>)+126]");
					bool flag5 = (long)num4 < 0L;
					bool flag6 = !flag5;
					obj14 = (long)(IntPtr)obj14 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_066c;
				}
				int num5 = obj14 << 4;
				object obj15 = 0L + (long)num5;
				object obj16 = (long)(IntPtr)obj15 + 304L;
				goto IL_09b9;
				IL_066c:
				List<TKey> list7 = (List<TKey>)((long)(IntPtr)obj - 216L);
				list7.Add((TKey)typeof(IDisposable));
				IntPtr intPtr6 = (IntPtr)null;
				goto IL_09b9;
				IL_09b9:
				object obj17 = (long)(IntPtr)obj - 216L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v946 @ X0_v60] (should have been resolved before IL gen)");
				int num6 = num + 1;
				bool flag7 = num6 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X23_v6+10]");
				_ = 0;
				if (!flag7)
				{
					if (intPtr4 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v672 @ X25_v7 (System.Int32)*4]");
						if ((IntPtr)0 != (IntPtr)201)
						{
							goto IL_0707;
						}
					}
				}
				else if (intPtr4 != (IntPtr)0)
				{
					goto IL_0707;
				}
				goto IL_0735;
				IL_0707:
				throw new TypeLoadException();
				IL_03a5:
				List<TKey> list8 = (List<TKey>)((long)(IntPtr)obj - 216L);
				list8.Add((TKey)typeof(IDisposable));
				intPtr6 = (IntPtr)null;
				goto IL_08e5;
				IL_08af:
				IntPtr intPtr7 = (IntPtr)0;
				_ = 0;
				_ = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-80]");
				_ = 0;
				object obj18 = (long)(IntPtr)obj - 216L;
				object obj19 = (long)(IntPtr)obj18 + 16L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictio…");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03a5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictio…");
				object obj20 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ X10_v14-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X23_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>+WeakReference`1<TKey, TValue, TValue>>+Enumerator<TKey, EasyMobile.Internal.StrongToWeakDictio…");
					bool flag8 = (long)num8 < 0L;
					bool flag9 = !flag8;
					obj20 = (long)(IntPtr)obj20 + 16L;
					if (!flag9)
					{
						continue;
					}
					goto IL_03a5;
				}
				int num9 = obj20 << 4;
				object obj21 = 0L + (long)num9;
				object obj22 = (long)(IntPtr)obj21 + 304L;
				intPtr6 = intPtr3;
				goto IL_08e5;
				IL_04a9:
				List<TKey>.Enumerator enumerator2 = list.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-D8]");
				_ = 0;
				while (true)
				{
					List<TKey> list9 = (List<TKey>)((long)(IntPtr)obj - 160L);
					list9.Add((TKey)0);
					if ((int)((long)(IntPtr)obj23 & 1L) == 0)
					{
						break;
					}
					if (obj4 != null)
					{
						object obj24 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-90]");
						bool flag10 = ((Dictionary<TKey, WeakReference<TValue>>)obj24).Remove((TKey)0);
						intPtr6 = (IntPtr)0;
						continue;
					}
					goto IL_0531;
				}
				num++;
				_ = 201;
				goto IL_0580;
				IL_0735:
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ X21_v9 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr9 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ X21_v15 (Il2CppClass<EasyMobile.Internal.StrongToWeakDictionary`2<TKey, TValue>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (VerboseDebug)
				{
					Type typeFromHandle2 = typeof(TValue);
					string text2 = typeFromHandle2.ToString();
					int count2 = ((Dictionary<TKey, WeakReference<TValue>>)obj4).Count;
					object obj25 = (long)(IntPtr)obj - 216L;
					object obj26 = (int)obj25;
					string message2 = text2 + " StrongToWeakDict: count AFTER culling: " + obj26;
					Debug.Log(message2);
				}
				return;
			}
			((List<TKey>)(object)ex).Add((TKey)0);
		}

		[Token(Token = "0x6000715")]
		[Address(RVA = "0xD91924", Offset = "0xD91924", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EDA468]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20240B5]) = v37;\nL_0015:\n\tv41 = new System.Object();\n\tSystem.Object::.ctor(v41);\n\tv47 = new System.WeakReference();\n\tSystem.WeakReference::.ctor(v47, v41);\n\treturn v47;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static WeakReference AllocWeakRef()
		{
			object target = new object();
			return new WeakReference(target);
		}
	}
}
