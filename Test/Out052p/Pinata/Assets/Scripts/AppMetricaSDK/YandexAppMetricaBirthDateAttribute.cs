using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000007")]
public class YandexAppMetricaBirthDateAttribute
{
	[Token(Token = "0x4000010")]
	private const string AttributeName = "birthDate";

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x15C1520", Offset = "0x15C1520", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC43D8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, age, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029958]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 32 Box v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Int32), &age @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002D;\n\t// 41 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_002D:\n\tv70 = v47.Length == 0;\n\tif (v70) goto L_0043;\n\tv47[0] = v54;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v47;\n\treturnBuffer.<AttributeName>k__BackingField = \"birthDate\";\n\treturnBuffer.<MethodName>k__BackingField = \"withAge\";\n\treturn returnVal1;\n\tv59 = new System.NullReferenceException();\nL_0043:\n\tv75 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv87 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v105;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithAge(int age)
	{
		//IL_0072: Expected native int or pointer, but got O
		//IL_007f: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		//IL_009b: Expected native int or pointer, but got O
		object[] array = new object[1];
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)age;
		bool flag = (object)yandexAppMetricaUserProfileUpdate == null;
		YandexAppMetricaUserProfileUpdate result = yandexAppMetricaUserProfileUpdate;
		if (!flag)
		{
			result = (YandexAppMetricaUserProfileUpdate)(yandexAppMetricaUserProfileUpdate as object);
		}
		if (array.Length != 0)
		{
			array[0] = yandexAppMetricaUserProfileUpdate;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate2 = default(YandexAppMetricaUserProfileUpdate);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "birthDate");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withAge");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x15C1614", Offset = "0x15C1614", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xE958CC(&date @ X1 (System.DateTime), 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 0xE956B4(&date @ X1 (System.DateTime), 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = 0xE955D0(&date @ X1 (System.DateTime), 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturnVal1 = YandexAppMetricaBirthDateAttribute::WithBirthDate(v40, v18, v36, v40);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaUserProfileUpdate WithBirthDate(DateTime date)
	{
		//IL_0038: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E958CC (inside System.DateTime::GetSystemTimeAsFileTime +0x74)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E956B4 (inside System.DateTime::SpecifyKind +0x1EC)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E955D0 (inside System.DateTime::SpecifyKind +0x108)");
		YandexAppMetricaBirthDateAttribute yandexAppMetricaBirthDateAttribute = default(YandexAppMetricaBirthDateAttribute);
		int year = default(int);
		int month = default(int);
		return yandexAppMetricaBirthDateAttribute.WithBirthDate(year, month, (int)yandexAppMetricaBirthDateAttribute);
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x15C17F4", Offset = "0x15C17F4", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECD6F0]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, year, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029959]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 32 Box v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Int32), &year @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002D;\n\t// 41 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_002D:\n\tv70 = v47.Length == 0;\n\tif (v70) goto L_0043;\n\tv47[0] = v54;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v47;\n\treturnBuffer.<AttributeName>k__BackingField = \"birthDate\";\n\treturnBuffer.<MethodName>k__BackingField = \"withBirthDate\";\n\treturn returnVal1;\n\tv59 = new System.NullReferenceException();\nL_0043:\n\tv75 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv87 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v105;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithBirthDate(int year)
	{
		//IL_0072: Expected native int or pointer, but got O
		//IL_007f: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		//IL_009b: Expected native int or pointer, but got O
		object[] array = new object[1];
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)year;
		bool flag = (object)yandexAppMetricaUserProfileUpdate == null;
		YandexAppMetricaUserProfileUpdate result = yandexAppMetricaUserProfileUpdate;
		if (!flag)
		{
			result = (YandexAppMetricaUserProfileUpdate)(yandexAppMetricaUserProfileUpdate as object);
		}
		if (array.Length != 0)
		{
			array[0] = yandexAppMetricaUserProfileUpdate;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate2 = default(YandexAppMetricaUserProfileUpdate);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "birthDate");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withBirthDate");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x15C18DC", Offset = "0x15C18DC", Length = "0x130")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EFF180]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, year, month, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202995A]) = v47;\nL_001C:\n\t// 28 NewArr v52 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\t// 35 Box v59 @ X0_v5, typeof(System.Int32), &year @ X1 (System.Int32)\n\tv62 = v59 == 0;\n\tif (v62) goto L_0030;\n\t// 44 IsInst v110 @ X0_v22, typeof(System.Object), v59 @ X0_v5\nL_0030:\n\tv117 = v52.Length == 0;\n\tif (v117) goto L_0061;\n\tv52[0] = v59;\n\t// 54 Box v121 @ X0_v17 (YandexAppMetricaUserProfileUpdate), typeof(System.Int32), &month @ X2 (System.Int32)\n\tv195 = v121 == 0;\n\tif (v195) goto L_0041;\n\t// 61 IsInst returnVal2 @ X0_v18 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v121 @ X0_v17 (YandexAppMetricaUserProfileUpdate)\nL_0041:\n\tv200 = v52.Length < 1;\n\tv139 = ~v200;\n\tv137 = v52.Length - 1;\n\tv133 = v137 == 0;\n\tv201 = ~v139;\n\tv123 = v201 | v133;\n\tif (v123) goto L_0061;\n\tv52[1] = v121;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v52;\n\treturnBuffer.<AttributeName>k__BackingField = \"birthDate\";\n\treturnBuffer.<MethodName>k__BackingField = \"withBirthDate\";\n\treturn returnVal2;\nL_0061:\n\tv151 = new System.IndexOutOfRangeException();\n\tgoto L_0066;\n\tv194 = new System.ArrayTypeMismatchException();\nL_0066:\n\tthrow v197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithBirthDate(int year, int month)
	{
		//IL_00d5: Expected O, but got I4
		//IL_0121: Expected native int or pointer, but got O
		//IL_012e: Expected native int or pointer, but got O
		//IL_013c: Expected native int or pointer, but got O
		//IL_014a: Expected native int or pointer, but got O
		object[] array = new object[2];
		object obj = year;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)month;
			bool flag = (object)yandexAppMetricaUserProfileUpdate == null;
			YandexAppMetricaUserProfileUpdate result = yandexAppMetricaUserProfileUpdate;
			if (!flag)
			{
				result = (YandexAppMetricaUserProfileUpdate)(yandexAppMetricaUserProfileUpdate as object);
			}
			bool flag2 = array.Length < 1;
			bool flag3 = !flag2;
			object obj3 = array.Length - 1;
			bool flag4 = obj3 == null;
			bool flag5 = !flag3;
			if (!(flag5 || flag4))
			{
				array[1] = yandexAppMetricaUserProfileUpdate;
				YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate2 = default(YandexAppMetricaUserProfileUpdate);
				System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, null);
				System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
				System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "birthDate");
				System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withBirthDate");
				return result;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0x15C167C", Offset = "0x15C167C", Length = "0x178")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EE34D0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, year, month, day, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([202995B]) = v50;\nL_001E:\n\t// 30 NewArr v55 @ X0_v3 (System.Object[]), typeof(System.Object[]), 3\n\t// 37 Box v62 @ X0_v5, typeof(System.Int32), &year @ X1 (System.Int32)\n\tv65 = v62 == 0;\n\tif (v65) goto L_0032;\n\t// 46 IsInst v118 @ X0_v27, typeof(System.Object), v62 @ X0_v5\nL_0032:\n\tv125 = v55.Length == 0;\n\tif (v125) goto L_007F;\n\tv55[0] = v62;\n\t// 56 Box v129 @ X0_v17, typeof(System.Int32), &month @ X2 (System.Int32)\n\tv238 = v129 == 0;\n\tif (v238) goto L_0043;\n\t// 63 IsInst v227 @ X0_v25, typeof(System.Object), v129 @ X0_v17\nL_0043:\n\tv243 = v55.Length < 1;\n\tv157 = ~v243;\n\tv154 = v55.Length - 1;\n\tv148 = v154 == 0;\n\tv244 = ~v157;\n\tv133 = v244 | v148;\n\tif (v133) goto L_007F;\n\tv55[1] = v129;\n\t// 83 Box v247 @ X0_v20 (YandexAppMetricaUserProfileUpdate), typeof(System.Int32), &day @ X3 (System.Int32)\n\tv248 = v247 == 0;\n\tif (v248) goto L_005E;\n\t// 90 IsInst returnVal2 @ X0_v21 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v247 @ X0_v20 (YandexAppMetricaUserProfileUpdate)\nL_005E:\n\tv251 = v55.Length < 2;\n\tv158 = ~v251;\n\tv155 = v55.Length - 2;\n\tv149 = v155 == 0;\n\tv252 = ~v158;\n\tv134 = v252 | v149;\n\tif (v134) goto L_007F;\n\tv55[2] = v247;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v55;\n\treturnBuffer.<AttributeName>k__BackingField = \"birthDate\";\n\treturnBuffer.<MethodName>k__BackingField = \"withBirthDate\";\n\treturn returnVal2;\nL_007F:\n\tv176 = new System.IndexOutOfRangeException();\n\tgoto L_0084;\n\tv237 = new System.ArrayTypeMismatchException();\nL_0084:\n\tthrow v240;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithBirthDate(int year, int month, int day)
	{
		//IL_00cd: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		//IL_01d0: Expected native int or pointer, but got O
		//IL_01dd: Expected native int or pointer, but got O
		//IL_01eb: Expected native int or pointer, but got O
		//IL_01f9: Expected native int or pointer, but got O
		object[] array = new object[3];
		object obj = year;
		if (obj != null)
		{
			object obj2 = obj as object;
		}
		if (array.Length != 0)
		{
			array[0] = obj;
			object obj3 = month;
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
			}
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj5 = array.Length - 1;
			bool flag3 = obj5 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = obj3;
				YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)day;
				bool flag5 = (object)yandexAppMetricaUserProfileUpdate == null;
				YandexAppMetricaUserProfileUpdate result = yandexAppMetricaUserProfileUpdate;
				if (!flag5)
				{
					result = (YandexAppMetricaUserProfileUpdate)(yandexAppMetricaUserProfileUpdate as object);
				}
				bool flag6 = array.Length < 2;
				bool flag7 = !flag6;
				object obj6 = array.Length - 2;
				bool flag8 = obj6 == null;
				bool flag9 = !flag7;
				if (!(flag9 || flag8))
				{
					array[2] = yandexAppMetricaUserProfileUpdate;
					YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate2 = default(YandexAppMetricaUserProfileUpdate);
					System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, null);
					System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
					System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "birthDate");
					System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withBirthDate");
					return result;
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x15C1A0C", Offset = "0x15C1A0C", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F0F988]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202995C]) = v41;\nL_0018:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0021:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0042;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002E;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv72 = ~v83;\n\tif (v72) goto L_0042;\n\tgoto L_0042;\n\tv103 = v74;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tgoto L_004F;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v88.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"birthDate\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v65;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValueReset()
	{
		//IL_004f: Expected native int or pointer, but got O
		//IL_005d: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		//IL_0079: Expected native int or pointer, but got O
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = default(YandexAppMetricaUserProfileUpdate);
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, Array.Empty<object>());
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "birthDate");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaBirthDateAttribute result = default(YandexAppMetricaBirthDateAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x15C11A4", Offset = "0x15C11A4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaBirthDateAttribute()
	{
	}
}
