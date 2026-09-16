using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000004")]
	public static class TypeExtensions
	{
		[Token(Token = "0x4000001")]
		private static readonly object GenericConstraintsSatisfaction_LOCK;

		[Token(Token = "0x4000002")]
		private static readonly Dictionary<Type, Type> GenericConstraintsSatisfactionInferredParameters;

		[Token(Token = "0x4000003")]
		private static readonly Dictionary<Type, Type> GenericConstraintsSatisfactionResolvedMap;

		[Token(Token = "0x4000004")]
		private static readonly HashSet<Type> GenericConstraintsSatisfactionProcessedParams;

		[Token(Token = "0x4000005")]
		private static readonly object WeaklyTypedTypeCastDelegates_LOCK;

		[Token(Token = "0x4000006")]
		private static readonly object StronglyTypedTypeCastDelegates_LOCK;

		[Token(Token = "0x4000007")]
		private static readonly DoubleLookupDictionary<Type, Type, Func<object, object>> WeaklyTypedTypeCastDelegates;

		[Token(Token = "0x4000008")]
		private static readonly DoubleLookupDictionary<Type, Type, Delegate> StronglyTypedTypeCastDelegates;

		[Token(Token = "0x4000009")]
		private static HashSet<string> ReservedCSharpKeywords;

		[Token(Token = "0x400000A")]
		public static readonly Dictionary<string, string> TypeNameAlternatives;

		[Token(Token = "0x400000B")]
		private static readonly object CachedNiceNames_LOCK;

		[Token(Token = "0x400000C")]
		private static readonly Dictionary<Type, string> CachedNiceNames;

		[Token(Token = "0x400000D")]
		private static readonly Type VoidPointerType;

		[Token(Token = "0x400000E")]
		private static readonly Dictionary<Type, HashSet<Type>> PrimitiveImplicitCasts;

		[Token(Token = "0x400000F")]
		private static readonly HashSet<Type> ExplicitCastIntegrals;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x1658DA8", Offset = "0x1658DA8", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EEE760]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF2F]) = v40;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Sirenix.Utilities.TypeExtensions>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = Sirenix.Utilities.TypeExtensions;\nL_0026:\n\tSystem.Threading.Monitor::Enter(v55.CachedNiceNames_LOCK);\n\tgoto L_003B;\n\tv64 = *([v60 @ X0_v5 (Il2CppClass<Sirenix.Utilities.TypeExtensions>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\t// 47 Jump @b37\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv68 = Sirenix.Utilities.TypeExtensions;\nL_003B:\n\tv81 = System.Collections.Generic.Dictionary`2<System.Type, System.String>::TryGetValue(v71.CachedNiceNames, type, &v79 @ stack_-28_v4 (System.String));\n\tv84 = v81 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_005B;\n\tgoto L_004B;\n\tv119 = *([v101 @ X0_v23+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_004B;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v101, v80, v78, v77, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004B:\n\tv127 = Sirenix.Utilities.TypeExtensions::CreateNiceName(type);\n\tv97 = v88.CachedNiceNames == 0;\n\tif (v97) goto L_0065;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.String>::Add(v88.CachedNiceNames, type, v127);\nL_005B:\n\tSystem.Threading.Monitor::Exit(v55.CachedNiceNames_LOCK);\nL_0063:\n\treturn v79;\n\tv82 = new System.NullReferenceException();\nL_0065:\n\tv100 = new System.NullReferenceException();\n\tgoto L_0072;\n\tgoto L_0072;\n\tgoto L_0072;\nL_0072:\n\tv130 = 0 != 1;\n\tif (v130) goto L_0080;\n\tv203 = System.Collections.Generic.Dictionary`2<System.Type, System.String>::TryGetValue(v100, 0, v192);\n\tv209 = System.Collections.Generic.Dictionary`2<System.Type, System.String>::TryGetValue(v203, 0, v192);\n\tSystem.Threading.Monitor::Exit(v55.CachedNiceNames_LOCK);\n\tv164 = ~v203.m_value;\n\tif (v164) goto L_0063;\n\tv207 = new System.TypeLoadException();\nL_0080:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Type, System.String>::TryGetValue(v206, v189, 0);\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static string GetCachedNiceName(Type type)
		{
			//IL_0165: Expected O, but got I4
			//IL_0107: Expected O, but got I4
			Monitor.Enter(CachedNiceNames_LOCK);
			if (!CachedNiceNames.TryGetValue(type, out var value))
			{
				string text = CreateNiceName(type);
				bool flag = CachedNiceNames == null;
				Type key = null;
				value = null;
				if (flag)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag2 = 0 != 1;
					Dictionary<Type, string> dictionary = (Dictionary<Type, string>)(object)ex;
					if (!flag2)
					{
						ref string value2 = default(ref string);
						bool flag3 = ((Dictionary<Type, string>)(object)ex).TryGetValue((Type)null, out value2);
						bool flag4 = ((Dictionary<Type, string>)flag3).TryGetValue(null, out value2);
						Monitor.Exit(CachedNiceNames_LOCK);
						if (!((bool*)(flag3 ? 1 : 0))->m_value)
						{
							goto IL_00ab;
						}
						TypeLoadException ex2 = new TypeLoadException();
						key = null;
						dictionary = (Dictionary<Type, string>)(object)ex2;
					}
					return (string)dictionary.TryGetValue(key, out *(string*)null);
				}
				CachedNiceNames.Add(type, text);
				value = text;
			}
			Monitor.Exit(CachedNiceNames_LOCK);
			goto IL_00ab;
			IL_00ab:
			return value;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1658F1C", Offset = "0x1658F1C", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EB5BD0]);\n\tv27 = *([v26 @ X8_v58]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202AF30]) = v46;\nL_001B:\n\tv50 = System.Type::get_IsArray(type);\n\tv90 = v50 == 0;\n\tif (v90) goto L_0057;\n\tv129 = System.Type::GetArrayRank(type);\n\tv135 = System.Type::GetElementType(type);\n\tgoto L_0039;\n\tv202 = *([v139 @ X8_v50+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0039;\n\tv224 = v139;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v224, v134, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0039:\n\tv376 = Sirenix.Utilities.TypeExtensions::GetNiceName(v135);\n\tv238 = v129 != 1;\n\tif (v238) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tgoto L_FFFFFFFF;\nL_0057:\n\tgoto L_005F;\n\tv211 = *([v145 @ X0_v14+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_005F;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v145, v49, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv220 = System.Type::GetTypeFromHandle(System.Nullable`1);\n\tgoto L_0070;\n\tv246 = *([v240 @ X8_v13+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_0070;\n\tv343 = v240;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v343, v219, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0070:\n\tv255 = Sirenix.Utilities.TypeExtensions::InheritsFrom(type, v220);\n\tv345 = v255 == 0;\n\tif (v345) goto L_009D;\n\tv109 = System.Type::GetGenericArguments(type);\n\tv194 = v109.Length == 0;\n\tif (v194) goto L_016D;\n\tgoto L_008B;\n\tv405 = *([v386 @ X8_v42+E0]);\n\tv406 = v405 == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_008B;\n\tv432 = v386;\n\tv409 = \"il2cpp_codegen_runtime_class_init\"(v432, v105, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_008B:\n\tv376 = Sirenix.Utilities.TypeExtensions::GetNiceName(v109[0]);\nL_0099:\n\treturnVal2 = System.String::Concat(v376, v315);\n\treturn returnVal2;\nL_009D:\n\tv372 = System.Type::get_IsByRef(type);\n\tv385 = v372 == 0;\n\tif (v385) goto L_00BB;\n\tv393 = System.Type::GetElementType(type);\n\tgoto L_00B3;\n\tv411 = *([v394 @ X8_v36+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tif (v413) goto L_00B3;\n\tv434 = v394;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v434, v391, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B3:\n\tv417 = Sirenix.Utilities.TypeExtensions::GetNiceName(v393);\n\tgoto L_0099;\nL_00BB:\n\t;\n\tv401 = System.Type::get_IsGenericParameter(type);\n\tv403 = v401 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_00F4;\n\tv422 = System.Type::get_IsGenericType(type);\n\tv424 = v422 == 0;\n\tif (v424) goto L_00F4;\n\tv460 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v460);\n\tv110 = System.Reflection.MemberInfo::get_Name(type);\n\tv80 = System.String::IndexOf(v110, \"`\");\n\tv452 = v80 + 1;\n\tv64 = v452 == 0;\n\tif (v64) goto L_FFFFFFFF;\n\tv79 = System.String::Substring(v110, 0, v80);\n\tgoto L_010B;\nL_00F4:\n\tgoto L_0104;\n\tv441 = *([v428 @ X0_v26+E0]);\n\tv442 = v441 == 0;\n\tv443 = ~v442;\n\tif (v443) goto L_0104;\n\tv445 = \"il2cpp_codegen_runtime_class_init\"(v428, v316, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0104:\n\treturnVal3 = Sirenix.Utilities.TypeExtensions::TypeNameGauntlet(type);\n\treturn returnVal3;\nL_010B:\n\tv463 = System.Text.StringBuilder::Append(v460, v459);\n\tv466 = System.Text.StringBuilder::Append(v460, 0x3C);\n\tv111 = System.Type::GetGenericArguments(type);\n\tv199 = v111.Length;\n\tv479 = v111.Length < 1;\n\tif (v479) goto L_015C;\nL_0128:\n\tv518 = v159 < v199;\n\tv187 = ~v518;\n\tif (v187) goto L_016D;\n\tv520 = v159 == 0;\n\tif (v520) goto L_013F;\n\tv524 = System.Text.StringBuilder::Append(v460, \", \");\nL_013F:\n\tgoto L_0146;\n\tv532 = *([v528 @ X0_v51+E0]);\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\tif (v534) goto L_0146;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v528, v526, v525, v92, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0146:\n\tv539 = Sirenix.Utilities.TypeExtensions::GetNiceName(v111[v159 @ X23_v7 (System.Int32)]);\n\tv502 = System.Text.StringBuilder::Append(v460, v539);\n\tv199 = v111.Length;\n\tv159 = v159 + 1;\n\tv483 = v159 < v111.Length;\n\tif (v483) goto L_0128;\nL_015C:\n\tv509 = System.Text.StringBuilder::Append(v460, 0x3E);\n\tv333 = *([v460 @ X0_v39 (System.Text.StringBuilder)]);\n\tv275 = *([v333 @ X8_v29 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv317 = *([v333 @ X8_v29 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 362 IndirectJump v275 @ X2_v12, v460 @ X0_v39 (System.Text.StringBuilder), v460 @ X0_v39 (System.Text.StringBuilder), v317 @ X1_v23, v275 @ X2_v12, v92 @ X3_v4, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tv124 = new System.NullReferenceException();\nL_016D:\n\tv201 = new System.IndexOutOfRangeException();\n\tthrow v201;\n\treturn returnVal1;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string CreateNiceName(Type type)
		{
			//IL_027e: Expected O, but got I4
			//IL_039d: Expected I, but got O
			//IL_03ad: Expected O, but got I
			//IL_03bd: Expected O, but got I
			string text;
			string text2;
			if (type.IsArray)
			{
				int arrayRank = type.GetArrayRank();
				Type elementType = type.GetElementType();
				text = elementType.GetNiceName();
				text2 = ((arrayRank != 1) ? "[,]" : "[]");
				goto IL_044e;
			}
			Type typeFromHandle = typeof(Nullable<>);
			string text3;
			StringBuilder stringBuilder;
			if (type.InheritsFrom(typeFromHandle))
			{
				Type[] genericArguments = type.GetGenericArguments();
				if (genericArguments.Length != 0)
				{
					text = genericArguments[0].GetNiceName();
					text2 = "?";
					goto IL_044e;
				}
			}
			else
			{
				if (type.IsByRef)
				{
					Type elementType2 = type.GetElementType();
					string niceName = elementType2.GetNiceName();
					text3 = niceName;
					text = "ref ";
					goto IL_03da;
				}
				if (type.IsGenericParameter || !type.IsGenericType)
				{
					return type.TypeNameGauntlet();
				}
				stringBuilder = new StringBuilder();
				string name = type.Name;
				int num = name.IndexOf("`");
				string value;
				if (num + 1 != 0)
				{
					string text4 = name.Substring(0, num);
					object obj = 0;
					value = text4;
				}
				else
				{
					value = name;
				}
				StringBuilder stringBuilder2 = stringBuilder.Append(value);
				StringBuilder stringBuilder3 = stringBuilder.Append('<');
				Type[] genericArguments2 = type.GetGenericArguments();
				int num2 = genericArguments2.Length;
				if (genericArguments2.Length < 1)
				{
					goto IL_0383;
				}
				int num3 = 0;
				while (num3 < num2)
				{
					if (num3 != 0)
					{
						StringBuilder stringBuilder4 = stringBuilder.Append(", ");
					}
					string niceName2 = genericArguments2[num3].GetNiceName();
					StringBuilder stringBuilder5 = stringBuilder.Append(niceName2);
					num2 = genericArguments2.Length;
					num3++;
					if (num3 < genericArguments2.Length)
					{
						continue;
					}
					goto IL_0383;
				}
			}
			goto IL_03c7;
			IL_03da:
			return text + text3;
			IL_03c7:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_044e:
			text3 = text2;
			goto IL_03da;
			IL_0383:
			StringBuilder stringBuilder6 = stringBuilder.Append('>');
			IntPtr intPtr = (IntPtr)stringBuilder;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v29 (Il2CppClass<System.Text.StringBuilder>)+160]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v29 (Il2CppClass<System.Text.StringBuilder>)+168]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v275 @ X2_v12 (should have been resolved before IL gen)");
			goto IL_03c7;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x1659564", Offset = "0x1659564", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB80E8]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF31]) = v38;\nL_001A:\n\treturnVal2 = System.Reflection.MemberInfo::get_Name(type);\n\tgoto L_0039;\n\tv60 = *([v55 @ X8_v9 (Il2CppClass<Sirenix.Utilities.TypeExtensions>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\t// 44 ConditionalJump @b16, v62 @ TEMP_v12\n\tv82 = v55;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v82, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv68 = Sirenix.Utilities.TypeExtensions;\nL_0039:\n\tv89 = System.Collections.Generic.Dictionary`2<System.String, System.String>::TryGetValue(v69.TypeNameAlternatives, returnVal2, &v86 @ stack_-28_v4 (System.String));\n\tv93 = v89 == 0;\n\tv98 = ~v93;\n\tv99 = ~v98;\n\tif (v99) goto L_004C;\n\tgoto L_004C;\nL_004C:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string TypeNameGauntlet(this Type type)
		{
			string text = type.Name;
			if (TypeNameAlternatives.TryGetValue(text, out var value))
			{
				text = value;
			}
			return text;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x1659300", Offset = "0x1659300", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED1628]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF32]) = v38;\nL_0017:\n\tv42 = System.Type::get_IsNested(type);\n\tv46 = v42 == 0;\n\tif (v46) goto L_0029;\n\tv51 = System.Type::get_IsGenericParameter(type);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0037;\nL_0029:\n\tgoto L_0035;\n\tv107 = *([v62 @ X0_v7+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0035;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v62, v56, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0035:\n\treturnVal2 = Sirenix.Utilities.TypeExtensions::GetCachedNiceName(type);\n\treturn returnVal2;\nL_0037:\n\t;\n\tv99 = System.Type::get_DeclaringType(type);\n\tgoto L_004B;\n\tv113 = *([v103 @ X8_v13+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_004B;\n\tv120 = v103;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v120, v98, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004B:\n\tv119 = Sirenix.Utilities.TypeExtensions::GetNiceName(v99);\n\tv123 = Sirenix.Utilities.TypeExtensions::GetCachedNiceName(type);\n\treturnVal3 = System.String::Concat(v119, \".\", v123);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetNiceName(this Type type)
		{
			if (!type.IsNested || type.IsGenericParameter)
			{
				return GetCachedNiceName(type);
			}
			Type declaringType = type.DeclaringType;
			string niceName = declaringType.GetNiceName();
			string cachedNiceName = GetCachedNiceName(type);
			return niceName + "." + cachedNiceName;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0xB8931C", Offset = "0xB8931C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF7BB8]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, inherit, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022A0A]) = v44;\nL_001D:\n\tgoto L_0028;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, inherit, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv63 = Sirenix.Utilities.TypeExtensions::GetCustomAttributes(type, inherit);\n\tv67 = System.Linq.Enumerable::ToArray(v63);\n\tv72 = Sirenix.Utilities.LinqExtensions::IsNullOrEmpty(v67);\n\tv74 = v72 == 0;\n\tif (v74) goto L_003A;\n\tgoto L_0044;\nL_003A:\n\tv80 = v67.Length == 0;\n\tif (v80) goto L_0047;\n\treturnVal1 = v67[0];\nL_0044:\n\treturn returnVal1;\n\tv90 = new System.NullReferenceException();\nL_0047:\n\tv108 = new System.IndexOutOfRangeException();\n\tthrow v108;\n\treturn returnVal2;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetCustomAttribute<T>(this Type type, bool inherit) where T : Attribute
		{
			IEnumerable<T> customAttributes = type.GetCustomAttributes<T>(inherit);
			T[] array = customAttributes.ToArray();
			if (array.IsNullOrEmpty())
			{
				return null;
			}
			if (array.Length != 0)
			{
				return array[0];
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0xB8929C", Offset = "0xB8929C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC0D20]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022A09]) = v41;\nL_001B:\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv61 = Il2CppMethodInfo;\n\tv63 = *([v61 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 44 IndirectJump v63 @ X3_v1, type @ X0 (System.Type), type @ X0 (System.Type), 0, methodof(Sirenix.Utilities.TypeExtensions::GetCustomAttribute), v63 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn X0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetCustomAttribute<T>(this Type type) where T : Attribute
		{
			//IL_0013: Expected O, but got I
			while (true)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x9579E0", Offset = "0x9579E0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1ED8628]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, inherit, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202153D]) = v44;\nL_001F:\n\tgoto L_0027;\n\tv53 = *([v47 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v47, inherit, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0027:\n\tv62 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv65 = type->klass;\n\tv69 = type->klass->vtable[11];\n\tv70 = System.Reflection.MemberInfo::GetCustomAttributes(type, v62, inherit);\n\tv76 = Il2CppMethodInfo;\n\tv77 = *([v76 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 59 IndirectJump v77 @ X2_v2, v70 @ X0_v9 (System.Object[]), v70 @ X0_v9 (System.Object[]), methodof(System.Linq.Enumerable::Cast), v77 @ X2_v2, v69 @ X3_v1, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable<T> GetCustomAttributes<T>(this Type type, bool inherit) where T : Attribute
		{
			//IL_0020: Expected I, but got O
			//IL_0030: Expected O, but got I
			//IL_0053: Expected O, but got I
			while (true)
			{
				Type typeFromHandle = typeof(T);
				IntPtr intPtr = (IntPtr)type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v7 (Il2CppClass<System.Type>)+1E8]");
				object obj = 0;
				object[] customAttributes = type.GetCustomAttributes(typeFromHandle, inherit);
				IntPtr intPtr2 = (IntPtr)0;
				object obj2 = (long)intPtr2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v77 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1659408", Offset = "0x1659408", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F0CD68]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, baseType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF33]) = v41;\nL_001C:\n\tv48 = System.Type::IsAssignableFrom(baseType, type);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002C;\nL_0027:\n\treturn returnVal2;\nL_002C:\n\tv149 = System.Type::get_IsInterface(type);\n\tv181 = v149 == 0;\n\tif (v181) goto L_0038;\n\tv183 = System.Type::get_IsInterface(baseType);\n\tv137 = v183 == 0;\n\tif (v137) goto L_FFFFFFFF;\nL_0038:\n\tv189 = System.Type::get_IsInterface(baseType);\n\tv169 = v189 == 0;\n\tif (v169) goto L_0051;\n\tv195 = System.Type::GetInterfaces(type);\n\treturnVal3 = System.Linq.Enumerable::Contains(v195, baseType);\n\treturn returnVal3;\nL_0051:\n\tv79 = v106 == baseType;\n\tif (v79) goto L_FFFFFFFF;\n\tv210 = System.Type::get_IsGenericTypeDefinition(baseType);\n\tv212 = v210 == 0;\n\tif (v212) goto L_007A;\n\tv217 = System.Type::get_IsGenericType(v106);\n\tv104 = v217 == 0;\n\tif (v104) goto L_007A;\n\tv101 = System.Type::GetGenericTypeDefinition(v106);\n\tv80 = v101 == baseType;\n\tif (v80) goto L_FFFFFFFF;\nL_007A:\n\tv133 = System.Type::get_BaseType(v106);\n\tv225 = v133 == 0;\n\tv136 = ~v225;\n\tif (v136) goto L_0051;\n\tgoto L_0027;\n\tgoto L_0027;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool InheritsFrom(this Type type, Type baseType)
		{
			//IL_01c8: Expected I4, but got O
			if (!baseType.IsAssignableFrom(type))
			{
				if (type.IsInterface && !baseType.IsInterface)
				{
					return false;
				}
				bool isInterface = baseType.IsInterface;
				bool flag = !isInterface;
				Type type2 = type;
				if (!flag)
				{
					IEnumerable<Type> interfaces = type.GetInterfaces();
					return interfaces.Contains(baseType);
				}
				while ((object)type2 != baseType)
				{
					if (baseType.IsGenericTypeDefinition && type2.IsGenericType)
					{
						Type genericTypeDefinition = type2.GetGenericTypeDefinition();
						if ((object)genericTypeDefinition == baseType)
						{
							break;
						}
					}
					Type baseType2 = type2.BaseType;
					bool flag2 = (object)baseType2 == null;
					bool flag3 = !flag2;
					type2 = baseType2;
					if (!flag3)
					{
						return (byte)(int)baseType2 != 0;
					}
				}
			}
			return true;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1659640", Offset = "0x1659640", Length = "0x1BA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv31 = *([1EE96F0]);\n\tv32 = *([v31 @ X8_v194]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([202AF34]) = v52;\nL_001D:\n\tv56 = new System.Object();\n\tSystem.Object::.ctor(v56);\n\tv63.GenericConstraintsSatisfaction_LOCK = v56;\n\tv66 = new System.Collections.Generic.Dictionary`2<System.Type, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::.ctor(v66);\n\tv72.GenericConstraintsSatisfactionInferredParameters = v66;\n\tv74 = new System.Collections.Generic.Dictionary`2<System.Type, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::.ctor(v74);\n\tv78.GenericConstraintsSatisfactionResolvedMap = v74;\n\tv82 = new System.Collections.Generic.HashSet`1<System.Type>();\n\tSystem.Collections.Generic.HashSet`1<System.Type>::.ctor(v82);\n\tv88.GenericConstraintsSatisfactionProcessedParams = v82;\n\tv90 = new System.Object();\n\tSystem.Object::.ctor(v90);\n\tv94.WeaklyTypedTypeCastDelegates_LOCK = v90;\n\tv96 = new System.Object();\n\tSystem.Object::.ctor(v96);\n\tv100.StronglyTypedTypeCastDelegates_LOCK = v96;\n\tv104 = new Sirenix.Utilities.DoubleLookupDictionary`3<System.Type, System.Type, System.Func`2<System.Object, System.Object>>();\n\tSirenix.Utilities.DoubleLookupDictionary`3<System.Type, System.Type, System.Func`2<System.Object, System.Object>>::.ctor(v104);\n\tv110.WeaklyTypedTypeCastDelegates = v104;\n\tv114 = new Sirenix.Utilities.DoubleLookupDictionary`3<System.Type, System.Type, System.Delegate>();\n\tSirenix.Utilities.DoubleLookupDictionary`3<System.Type, System.Type, System.Delegate>::.ctor(v114);\n\tv120.StronglyTypedTypeCastDelegates = v114;\n\tv124 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v124);\n\tv137 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"abstract\");\n\tv171 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"as\");\n\tv178 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"base\");\n\tv184 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"bool\");\n\tv215 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"break\");\n\tv221 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"byte\");\n\tv227 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"case\");\n\tv233 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"catch\");\n\tv239 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"char\");\n\tv245 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"checked\");\n\tv251 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"class\");\n\tv257 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"const\");\n\tv263 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"continue\");\n\tv269 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"decimal\");\n\tv275 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"default\");\n\tv281 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"delegate\");\n\tv287 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"do\");\n\tv293 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"double\");\n\tv299 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"else\");\n\tv305 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"enum\");\n\tv311 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"event\");\n\tv317 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"explicit\");\n\tv323 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"extern\");\n\tv329 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"false\");\n\tv335 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"finally\");\n\tv341 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"fixed\");\n\tv347 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"float\");\n\tv353 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"for\");\n\tv359 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"foreach\");\n\tv365 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"goto\");\n\tv371 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"if\");\n\tv377 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"implicit\");\n\tv383 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"in\");\n\tv389 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"int\");\n\tv395 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"interface\");\n\tv401 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"internal\");\n\tv407 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"is\");\n\tv413 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"lock\");\n\tv419 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"long\");\n\tv425 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"namespace\");\n\tv431 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"new\");\n\tv437 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"null\");\n\tv443 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"object\");\n\tv449 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"operator\");\n\tv455 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"out\");\n\tv461 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"override\");\n\tv467 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"params\");\n\tv473 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"private\");\n\tv479 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"protected\");\n\tv485 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"public\");\n\tv491 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"readonly\");\n\tv497 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"ref\");\n\tv503 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"return\");\n\tv508 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"sbyte\");\n\tv514 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"sealed\");\n\tv519 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"short\");\n\tv525 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"sizeof\");\n\tv531 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"stackalloc\");\n\tv537 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"static\");\n\tv542 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"string\");\n\tv548 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"struct\");\n\tv554 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"switch\");\n\tv560 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"this\");\n\tv566 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"throw\");\n\tv572 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"true\");\n\tv578 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"try\");\n\tv584 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"typeof\");\n\tv589 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"uint\");\n\tv594 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"ulong\");\n\tv600 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"unchecked\");\n\tv606 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"unsafe\");\n\tv611 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"ushort\");\n\tv617 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"using\");\n\tv621 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"static\");\n\tv627 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"void\");\n\tv633 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"volatile\");\n\tv639 = System.Collections.Generic.HashSet`1<System.String>::Add(v124, \"while\"\n// ... truncated")]
		static TypeExtensions()
		{
			object genericConstraintsSatisfaction_LOCK = new object();
			GenericConstraintsSatisfaction_LOCK = genericConstraintsSatisfaction_LOCK;
			Dictionary<Type, Type> genericConstraintsSatisfactionInferredParameters = new Dictionary<Type, Type>();
			GenericConstraintsSatisfactionInferredParameters = genericConstraintsSatisfactionInferredParameters;
			Dictionary<Type, Type> genericConstraintsSatisfactionResolvedMap = new Dictionary<Type, Type>();
			GenericConstraintsSatisfactionResolvedMap = genericConstraintsSatisfactionResolvedMap;
			HashSet<Type> genericConstraintsSatisfactionProcessedParams = new HashSet<Type>();
			GenericConstraintsSatisfactionProcessedParams = genericConstraintsSatisfactionProcessedParams;
			object weaklyTypedTypeCastDelegates_LOCK = new object();
			WeaklyTypedTypeCastDelegates_LOCK = weaklyTypedTypeCastDelegates_LOCK;
			object stronglyTypedTypeCastDelegates_LOCK = new object();
			StronglyTypedTypeCastDelegates_LOCK = stronglyTypedTypeCastDelegates_LOCK;
			DoubleLookupDictionary<Type, Type, Func<object, object>> weaklyTypedTypeCastDelegates = new DoubleLookupDictionary<Type, Type, Func<object, object>>();
			WeaklyTypedTypeCastDelegates = weaklyTypedTypeCastDelegates;
			DoubleLookupDictionary<Type, Type, Delegate> stronglyTypedTypeCastDelegates = new DoubleLookupDictionary<Type, Type, Delegate>();
			StronglyTypedTypeCastDelegates = stronglyTypedTypeCastDelegates;
			HashSet<string> hashSet = new HashSet<string>();
			bool flag = hashSet.Add("abstract");
			bool flag2 = hashSet.Add("as");
			bool flag3 = hashSet.Add("base");
			bool flag4 = hashSet.Add("bool");
			bool flag5 = hashSet.Add("break");
			bool flag6 = hashSet.Add("byte");
			bool flag7 = hashSet.Add("case");
			bool flag8 = hashSet.Add("catch");
			bool flag9 = hashSet.Add("char");
			bool flag10 = hashSet.Add("checked");
			bool flag11 = hashSet.Add("class");
			bool flag12 = hashSet.Add("const");
			bool flag13 = hashSet.Add("continue");
			bool flag14 = hashSet.Add("decimal");
			bool flag15 = hashSet.Add("default");
			bool flag16 = hashSet.Add("delegate");
			bool flag17 = hashSet.Add("do");
			bool flag18 = hashSet.Add("double");
			bool flag19 = hashSet.Add("else");
			bool flag20 = hashSet.Add("enum");
			bool flag21 = hashSet.Add("event");
			bool flag22 = hashSet.Add("explicit");
			bool flag23 = hashSet.Add("extern");
			bool flag24 = hashSet.Add("false");
			bool flag25 = hashSet.Add("finally");
			bool flag26 = hashSet.Add("fixed");
			bool flag27 = hashSet.Add("float");
			bool flag28 = hashSet.Add("for");
			bool flag29 = hashSet.Add("foreach");
			bool flag30 = hashSet.Add("goto");
			bool flag31 = hashSet.Add("if");
			bool flag32 = hashSet.Add("implicit");
			bool flag33 = hashSet.Add("in");
			bool flag34 = hashSet.Add("int");
			bool flag35 = hashSet.Add("interface");
			bool flag36 = hashSet.Add("internal");
			bool flag37 = hashSet.Add("is");
			bool flag38 = hashSet.Add("lock");
			bool flag39 = hashSet.Add("long");
			bool flag40 = hashSet.Add("namespace");
			bool flag41 = hashSet.Add("new");
			bool flag42 = hashSet.Add("null");
			bool flag43 = hashSet.Add("object");
			bool flag44 = hashSet.Add("operator");
			bool flag45 = hashSet.Add("out");
			bool flag46 = hashSet.Add("override");
			bool flag47 = hashSet.Add("params");
			bool flag48 = hashSet.Add("private");
			bool flag49 = hashSet.Add("protected");
			bool flag50 = hashSet.Add("public");
			bool flag51 = hashSet.Add("readonly");
			bool flag52 = hashSet.Add("ref");
			bool flag53 = hashSet.Add("return");
			bool flag54 = hashSet.Add("sbyte");
			bool flag55 = hashSet.Add("sealed");
			bool flag56 = hashSet.Add("short");
			bool flag57 = hashSet.Add("sizeof");
			bool flag58 = hashSet.Add("stackalloc");
			bool flag59 = hashSet.Add("static");
			bool flag60 = hashSet.Add("string");
			bool flag61 = hashSet.Add("struct");
			bool flag62 = hashSet.Add("switch");
			bool flag63 = hashSet.Add("this");
			bool flag64 = hashSet.Add("throw");
			bool flag65 = hashSet.Add("true");
			bool flag66 = hashSet.Add("try");
			bool flag67 = hashSet.Add("typeof");
			bool flag68 = hashSet.Add("uint");
			bool flag69 = hashSet.Add("ulong");
			bool flag70 = hashSet.Add("unchecked");
			bool flag71 = hashSet.Add("unsafe");
			bool flag72 = hashSet.Add("ushort");
			bool flag73 = hashSet.Add("using");
			bool flag74 = hashSet.Add("static");
			bool flag75 = hashSet.Add("void");
			bool flag76 = hashSet.Add("volatile");
			bool flag77 = hashSet.Add("while");
			bool flag78 = hashSet.Add("in");
			bool flag79 = hashSet.Add("get");
			bool flag80 = hashSet.Add("set");
			bool flag81 = hashSet.Add("var");
			ReservedCSharpKeywords = hashSet;
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "Single", "float" },
				{ "Single", "float" }
			};
		}
	}
}
