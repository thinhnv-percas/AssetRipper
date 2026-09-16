using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000B")]
public class YandexAppMetricaNameAttribute
{
	[Token(Token = "0x4000016")]
	private const string AttributeName = "name";

	[Token(Token = "0x6000051")]
	[Address(RVA = "0x15C328C", Offset = "0x15C328C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE22A8]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029970]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = value == 0;\n\tif (v50) goto L_0026;\n\t// 34 IsInst returnVal1 @ X0_v9 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), value @ X1 (System.String)\nL_0026:\n\tv62 = v47.Length == 0;\n\tif (v62) goto L_003B;\n\tv47[0] = value;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v47;\n\treturnBuffer.<AttributeName>k__BackingField = \"name\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tv51 = new System.NullReferenceException();\nL_003B:\n\tv67 = new System.IndexOutOfRangeException();\n\tgoto L_0040;\n\tv79 = new System.ArrayTypeMismatchException();\nL_0040:\n\tthrow v97;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(string value)
	{
		//IL_0072: Expected native int or pointer, but got O
		//IL_007f: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		//IL_009b: Expected native int or pointer, but got O
		object[] array = new object[1];
		bool flag = value == null;
		YandexAppMetricaUserProfileUpdate result = (YandexAppMetricaUserProfileUpdate)array;
		if (!flag)
		{
			result = (YandexAppMetricaUserProfileUpdate)(value as object);
		}
		if (array.Length != 0)
		{
			array[0] = value;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = default(YandexAppMetricaUserProfileUpdate);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "name");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000052")]
	[Address(RVA = "0x15C3354", Offset = "0x15C3354", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EBAE40]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2029971]) = v41;\nL_0018:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0021:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0042;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002E;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv72 = ~v83;\n\tif (v72) goto L_0042;\n\tgoto L_0042;\n\tv103 = v74;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tgoto L_004F;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v88.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"name\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v65;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "name");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaNameAttribute result = default(YandexAppMetricaNameAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}

	[Token(Token = "0x6000053")]
	[Address(RVA = "0x15C126C", Offset = "0x15C126C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaNameAttribute()
	{
	}
}
