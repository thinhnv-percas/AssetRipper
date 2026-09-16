using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C0")]
	public static class SerializableKeyValuePairExtension
	{
		[Token(Token = "0x6000705")]
		[Address(RVA = "0x14ED32C", Offset = "0x14ED32C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = *([v1 @ X2+30]);\n\tv2 = *([v0 @ X8_v1]);\n\tv3 = *([v2 @ X2_v1]);\n\t// 3 IndirectJump v3 @ X3_v1, pair @ X0 (System.Collections.Generic.KeyValuePair`2<K, V>), pair @ X0 (System.Collections.Generic.KeyValuePair`2<K, V>), methodInfo @ X1 (Il2CppMethodInfo), v2 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\n\treturn X0;\n")]
		public static SerializableKeyValuePair<K, V> ToSerializableKeyValuePair<K, V>(this KeyValuePair<K, V> pair)
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X2+30]");
			object obj = 0;
			object obj2 = obj;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000706")]
		[Address(RVA = "0x957308", Offset = "0x957308", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = pairs == 0;\n\tif (v20) goto L_00A3;\n\tv22 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_0017;\n\tv34 = v22;\n\tv35 = 0x8907BC(v34, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]);\nL_0017:\n\tv53 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]) & 0x200;\n\tv54 = v53 == 0;\n\tif (v54) goto L_0033;\n\tv86 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_0024;\n\tv108 = v86;\n\tv109 = 0x8907BC(v108, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0024:\n\tv110 = *([v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+E0]) == 0;\n\tv101 = ~v110;\n\tif (v101) goto L_0033;\n\tgoto L_0033;\n\tv145 = v95;\n\tv146 = 0x8907BC(v145, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0033:\n\tv103 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_003B;\n\tv111 = v103;\n\tv112 = 0x8907BC(v111, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv114 = *([v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+B8]);\n\tv116 = *([v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+8]) == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0092;\n\tv122 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_004A;\n\tv149 = v122;\n\tv150 = 0x8907BC(v149, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv153 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]);\nL_004A:\n\tv154 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]) & 0x200;\n\tv155 = v154 == 0;\n\tif (v155) goto L_006B;\n\tv157 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_0057;\n\tv179 = v157;\n\tv180 = 0x8907BC(v179, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0057:\n\tv181 = *([v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+E0]) == 0;\n\tv172 = ~v181;\n\tif (v172) goto L_006B;\n\tgoto L_006B;\n\tv201 = v166;\n\tv202 = 0x8907BC(v201, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tgoto L_0076;\n\tv182 = v174;\n\tv183 = 0x8907BC(v182, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv186 = Il2CppMethodRgctx<EasyMobile.Internal.SerializableKeyValuePairExtension::ToSerializableKeyValuePairs>;\nL_0076:\n\tgoto L_007A;\n\tv196 = v128;\n\tv197 = 0x8907BC(v196, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007A:\n\tv200 = new Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<K, V>, EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>>();\n\tv206 = System.Func`2<System.Collections.Generic.KeyValuePair`2<K, V>, EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>::.ctor(v200, v187.<>9, Il2CppMethodInfo);\n\tv130 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>;\n\tgoto L_008B;\n\tv211 = v130;\n\tv212 = System.Func`2<System.Collections.Generic.KeyValuePair`2<K, V>, EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>::.ctor(v211, v136, v132, v134);\nL_008B:\n\tv143 = *([v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+B8]);\n\t*([v143 @ X8_v20 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+8]) = v200;\nL_0092:\n\tv62 = Il2CppMethodInfo;\n\t// 154 IndirectJump [v62 @ X2_v2 (Il2CppMethodInfo)], pairs @ X0 (System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<K, V>>), pairs @ X0 (System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<K, V>>), [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+8], methodof(System.Linq.Enumerable::Select), [v62 @ X2_v2 (Il2CppMethodInfo)], v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_00A3:\n\treturn pairs;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable<SerializableKeyValuePair<K, V>> ToSerializableKeyValuePairs<K, V>(this IEnumerable<KeyValuePair<K, V>> pairs)
		{
			if (pairs != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+8]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_0175;
				}
				IntPtr intPtr5 = (IntPtr)0;
				goto IL_0185;
			}
			return (IEnumerable<SerializableKeyValuePair<K, V>>)pairs;
			IL_0175:
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v62 @ X2_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			goto IL_0185;
			IL_0185:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			Func<KeyValuePair<K, V>, SerializableKeyValuePair<K, V>> func = delegate
			{
				//IL_0010: Expected O, but got I
				//IL_0020: Expected O, but got I
				//IL_0030: Expected O, but got I
				//IL_0092: Expected O, but got I
				//IL_00a2: Expected O, but got I
				//IL_00b2: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X3+18]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X8_v1+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v2+28]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X22_v1+12E]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				}
				SerializableKeyValuePair<K, V> result = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X3+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v4+C0]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v5+30]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X3_v1] (should have been resolved before IL gen)");
				return result;
			};
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__1`2<K, V>>)+B8]");
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_0175;
		}

		[Token(Token = "0x6000707")]
		[Address(RVA = "0x957680", Offset = "0x957680", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = pairs == 0;\n\tif (v20) goto L_00A3;\n\tv22 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_0017;\n\tv34 = v22;\n\tv35 = 0x8907BC(v34, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]);\nL_0017:\n\tv53 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]) & 0x200;\n\tv54 = v53 == 0;\n\tif (v54) goto L_0033;\n\tv86 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_0024;\n\tv108 = v86;\n\tv109 = 0x8907BC(v108, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0024:\n\tv110 = *([v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+E0]) == 0;\n\tv101 = ~v110;\n\tif (v101) goto L_0033;\n\tgoto L_0033;\n\tv145 = v95;\n\tv146 = 0x8907BC(v145, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0033:\n\tv103 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_003B;\n\tv111 = v103;\n\tv112 = 0x8907BC(v111, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv114 = *([v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+B8]);\n\tv116 = *([v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+8]) == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0092;\n\tv122 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_004A;\n\tv149 = v122;\n\tv150 = 0x8907BC(v149, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv153 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]);\nL_004A:\n\tv154 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]) & 0x200;\n\tv155 = v154 == 0;\n\tif (v155) goto L_006B;\n\tv157 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_0057;\n\tv179 = v157;\n\tv180 = 0x8907BC(v179, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0057:\n\tv181 = *([v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+E0]) == 0;\n\tv172 = ~v181;\n\tif (v172) goto L_006B;\n\tgoto L_006B;\n\tv201 = v166;\n\tv202 = 0x8907BC(v201, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tgoto L_0076;\n\tv182 = v174;\n\tv183 = 0x8907BC(v182, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv186 = Il2CppMethodRgctx<EasyMobile.Internal.SerializableKeyValuePairExtension::ToKeyValuePairs>;\nL_0076:\n\tgoto L_007A;\n\tv196 = v128;\n\tv197 = 0x8907BC(v196, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007A:\n\tv200 = new Il2CppClass<System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, System.Collections.Generic.KeyValuePair`2<K, V>>>();\n\tv206 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, System.Collections.Generic.KeyValuePair`2<K, V>>::.ctor(v200, v187.<>9, Il2CppMethodInfo);\n\tv130 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>;\n\tgoto L_008B;\n\tv211 = v130;\n\tv212 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, System.Collections.Generic.KeyValuePair`2<K, V>>::.ctor(v211, v136, v132, v134);\nL_008B:\n\tv143 = *([v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+B8]);\n\t*([v143 @ X8_v20 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+8]) = v200;\nL_0092:\n\tv62 = Il2CppMethodInfo;\n\t// 154 IndirectJump [v62 @ X2_v2 (Il2CppMethodInfo)], pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+8], methodof(System.Linq.Enumerable::Select), [v62 @ X2_v2 (Il2CppMethodInfo)], v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_00A3:\n\treturn pairs;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable<KeyValuePair<K, V>> ToKeyValuePairs<K, V>(this IEnumerable<SerializableKeyValuePair<K, V>> pairs)
		{
			if (pairs != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+8]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_0175;
				}
				IntPtr intPtr5 = (IntPtr)0;
				goto IL_0185;
			}
			return (IEnumerable<KeyValuePair<K, V>>)pairs;
			IL_0175:
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v62 @ X2_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			goto IL_0185;
			IL_0185:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			Func<SerializableKeyValuePair<K, V>, KeyValuePair<K, V>> func = delegate(SerializableKeyValuePair<K, V> p)
			{
				K key = p.Key;
				V value = p.Value;
				return new KeyValuePair<K, V>(key, value);
			};
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__2`2<K, V>>)+B8]");
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_0175;
		}

		[Token(Token = "0x6000708")]
		[Address(RVA = "0x9574C4", Offset = "0x9574C4", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = pairs == 0;\n\tif (v20) goto L_00A3;\n\tv22 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_0017;\n\tv34 = v22;\n\tv35 = 0x8907BC(v34, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]);\nL_0017:\n\tv53 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]) & 0x200;\n\tv54 = v53 == 0;\n\tif (v54) goto L_0033;\n\tv86 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_0024;\n\tv108 = v86;\n\tv109 = 0x8907BC(v108, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0024:\n\tv110 = *([v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+E0]) == 0;\n\tv101 = ~v110;\n\tif (v101) goto L_0033;\n\tgoto L_0033;\n\tv145 = v95;\n\tv146 = 0x8907BC(v145, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0033:\n\tv103 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_003B;\n\tv111 = v103;\n\tv112 = 0x8907BC(v111, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv114 = *([v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+B8]);\n\tv116 = *([v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+8]) == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0092;\n\tv122 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_004A;\n\tv149 = v122;\n\tv150 = 0x8907BC(v149, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv153 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]);\nL_004A:\n\tv154 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]) & 0x200;\n\tv155 = v154 == 0;\n\tif (v155) goto L_006B;\n\tv157 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_0057;\n\tv179 = v157;\n\tv180 = 0x8907BC(v179, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0057:\n\tv181 = *([v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+E0]) == 0;\n\tv172 = ~v181;\n\tif (v172) goto L_006B;\n\tgoto L_006B;\n\tv201 = v166;\n\tv202 = 0x8907BC(v201, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tgoto L_0076;\n\tv182 = v174;\n\tv183 = 0x8907BC(v182, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv186 = Il2CppMethodRgctx<EasyMobile.Internal.SerializableKeyValuePairExtension::Keys>;\nL_0076:\n\tgoto L_007A;\n\tv196 = v128;\n\tv197 = 0x8907BC(v196, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007A:\n\tv200 = new Il2CppClass<System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, K>>();\n\tv206 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, K>::.ctor(v200, v187.<>9, Il2CppMethodInfo);\n\tv130 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>;\n\tgoto L_008B;\n\tv211 = v130;\n\tv212 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, K>::.ctor(v211, v136, v132, v134);\nL_008B:\n\tv143 = *([v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+B8]);\n\t*([v143 @ X8_v20 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+8]) = v200;\nL_0092:\n\tv62 = Il2CppMethodInfo;\n\t// 154 IndirectJump [v62 @ X2_v2 (Il2CppMethodInfo)], pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+8], methodof(System.Linq.Enumerable::Select), [v62 @ X2_v2 (Il2CppMethodInfo)], v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_00A3:\n\treturn pairs;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable<K> Keys<K, V>(this IEnumerable<SerializableKeyValuePair<K, V>> pairs)
		{
			if (pairs != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+8]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_0175;
				}
				IntPtr intPtr5 = (IntPtr)0;
				goto IL_0185;
			}
			return (IEnumerable<K>)pairs;
			IL_0175:
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v62 @ X2_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			goto IL_0185;
			IL_0185:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			Func<SerializableKeyValuePair<K, V>, K> func = delegate
			{
				//IL_000e: Expected O, but got I
				IntPtr intPtr10 = (IntPtr)0;
				object obj = (long)intPtr10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X2_v1 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: X0)");
				return (K)null;
			};
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__3`2<K, V>>)+B8]");
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_0175;
		}

		[Token(Token = "0x6000709")]
		[Address(RVA = "0x95CA48", Offset = "0x95CA48", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = pairs == 0;\n\tif (v20) goto L_00A3;\n\tv22 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_0017;\n\tv34 = v22;\n\tv35 = 0x8907BC(v34, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]);\nL_0017:\n\tv53 = *([v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]) & 0x200;\n\tv54 = v53 == 0;\n\tif (v54) goto L_0033;\n\tv86 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_0024;\n\tv108 = v86;\n\tv109 = 0x8907BC(v108, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0024:\n\tv110 = *([v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+E0]) == 0;\n\tv101 = ~v110;\n\tif (v101) goto L_0033;\n\tgoto L_0033;\n\tv145 = v95;\n\tv146 = 0x8907BC(v145, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0033:\n\tv103 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_003B;\n\tv111 = v103;\n\tv112 = 0x8907BC(v111, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv114 = *([v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+B8]);\n\tv116 = *([v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+8]) == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0092;\n\tv122 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_004A;\n\tv149 = v122;\n\tv150 = 0x8907BC(v149, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv153 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]);\nL_004A:\n\tv154 = *([v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]) & 0x200;\n\tv155 = v154 == 0;\n\tif (v155) goto L_006B;\n\tv157 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_0057;\n\tv179 = v157;\n\tv180 = 0x8907BC(v179, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0057:\n\tv181 = *([v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+E0]) == 0;\n\tv172 = ~v181;\n\tif (v172) goto L_006B;\n\tgoto L_006B;\n\tv201 = v166;\n\tv202 = 0x8907BC(v201, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tgoto L_0076;\n\tv182 = v174;\n\tv183 = 0x8907BC(v182, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv186 = Il2CppMethodRgctx<EasyMobile.Internal.SerializableKeyValuePairExtension::Values>;\nL_0076:\n\tgoto L_007A;\n\tv196 = v128;\n\tv197 = 0x8907BC(v196, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007A:\n\tv200 = new Il2CppClass<System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, V>>();\n\tv206 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, V>::.ctor(v200, v187.<>9, Il2CppMethodInfo);\n\tv130 = Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>;\n\tgoto L_008B;\n\tv211 = v130;\n\tv212 = System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>, V>::.ctor(v211, v136, v132, v134);\nL_008B:\n\tv143 = *([v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+B8]);\n\t*([v143 @ X8_v20 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+8]) = v200;\nL_0092:\n\tv62 = Il2CppMethodInfo;\n\t// 154 IndirectJump [v62 @ X2_v2 (Il2CppMethodInfo)], pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), pairs @ X0 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.SerializableKeyValuePair`2<K, V>>), [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+8], methodof(System.Linq.Enumerable::Select), [v62 @ X2_v2 (Il2CppMethodInfo)], v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_00A3:\n\treturn pairs;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable<V> Values<K, V>(this IEnumerable<SerializableKeyValuePair<K, V>> pairs)
		{
			if (pairs != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X21_v2 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X21_v14 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X21_v4 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v7 (Il2CppStaticFields<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+8]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					goto IL_0175;
				}
				IntPtr intPtr5 = (IntPtr)0;
				goto IL_0185;
			}
			return (IEnumerable<V>)pairs;
			IL_0175:
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v62 @ X2_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			goto IL_0185;
			IL_0185:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X21_v8 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X21_v12 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			Func<SerializableKeyValuePair<K, V>, V> func = delegate
			{
				//IL_000e: Expected O, but got I
				IntPtr intPtr10 = (IntPtr)0;
				object obj = (long)intPtr10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X2_v1 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: X0)");
				return (V)null;
			};
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X22_v5 (Il2CppClass<EasyMobile.Internal.SerializableKeyValuePairExtension+<>c__4`2<K, V>>)+B8]");
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_0175;
		}
	}
}
