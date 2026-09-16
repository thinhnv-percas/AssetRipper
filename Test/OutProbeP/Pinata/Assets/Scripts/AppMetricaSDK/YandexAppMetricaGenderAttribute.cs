using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000A")]
public class YandexAppMetricaGenderAttribute
{
	[Token(Token = "0x200001F")]
	public enum Gender
	{
		[Token(Token = "0x4000066")]
		MALE = 0,
		[Token(Token = "0x4000067")]
		FEMALE = 1,
		[Token(Token = "0x4000068")]
		OTHER = 2
	}

	[Token(Token = "0x4000015")]
	private const string AttributeName = "gender";

	[Token(Token = "0x600004E")]
	[Address(RVA = "0x15C307C", Offset = "0x15C307C", Length = "0x11C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EC7890]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([202996E]) = v44;\nL_001A:\n\t// 26 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v56 @ X0_v5, typeof(YandexAppMetricaGenderAttribute+Gender), &value @ X1 (YandexAppMetricaGenderAttribute+Gender)\n\tv59 = *([v56 @ X0_v5]);\n\t*([v59 @ X8_v11+160])(v63, v56, *([v59 @ X8_v11+168]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal1 = \"il2cpp_vm_object_unbox\"(v56, *([v59 @ X8_v11+168]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = v63 == 0;\n\tif (v81) goto L_003A;\n\t// 54 IsInst returnVal1 @ X0_v18 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v63 @ X0_v15\nL_003A:\n\tv89 = v49.Length == 0;\n\tif (v89) goto L_0052;\n\tv49[0] = v63;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v49;\n\treturnBuffer.<AttributeName>k__BackingField = \"gender\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\tv80 = new System.NullReferenceException();\nL_0052:\n\tv93 = new System.IndexOutOfRangeException();\n\tgoto L_0057;\n\tv117 = new System.ArrayTypeMismatchException();\nL_0057:\n\tthrow v116;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(Gender value)
	{
		//IL_0090: Expected native int or pointer, but got O
		//IL_009d: Expected native int or pointer, but got O
		//IL_00ab: Expected native int or pointer, but got O
		//IL_00b9: Expected native int or pointer, but got O
		object[] array = new object[1];
		object obj = value;
		object obj2 = obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X8_v11+160] (should have been resolved before IL gen)");
		Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
		object obj3 = default(object);
		YandexAppMetricaUserProfileUpdate result = default(YandexAppMetricaUserProfileUpdate);
		if (obj3 != null)
		{
			result = (YandexAppMetricaUserProfileUpdate)(obj3 as object);
		}
		if (array.Length != 0)
		{
			array[0] = obj3;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = default(YandexAppMetricaUserProfileUpdate);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "gender");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600004F")]
	[Address(RVA = "0x15C3198", Offset = "0x15C3198", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EB97F8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202996F]) = v41;\nL_0018:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0021:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0042;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002E;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv72 = ~v83;\n\tif (v72) goto L_0042;\n\tgoto L_0042;\n\tv103 = v74;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tgoto L_004F;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v88.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"gender\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v65;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "gender");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaGenderAttribute result = default(YandexAppMetricaGenderAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}

	[Token(Token = "0x6000050")]
	[Address(RVA = "0x15C1208", Offset = "0x15C1208", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaGenderAttribute()
	{
	}
}
