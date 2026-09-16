using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000C")]
public class YandexAppMetricaNotificationsEnabledAttribute
{
	[Token(Token = "0x4000017")]
	private const string AttributeName = "notificationsEnabled";

	[Token(Token = "0x6000054")]
	[Address(RVA = "0x15C3448", Offset = "0x15C3448", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F01688]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029972]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 32 Box v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002D;\n\t// 41 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v54 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_002D:\n\tv70 = v47.Length == 0;\n\tif (v70) goto L_0043;\n\tv47[0] = v54;\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v47;\n\treturnBuffer.<AttributeName>k__BackingField = \"notificationsEnabled\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tv59 = new System.NullReferenceException();\nL_0043:\n\tv75 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv87 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v106;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(bool value)
	{
		//IL_0072: Expected native int or pointer, but got O
		//IL_007f: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		//IL_009b: Expected native int or pointer, but got O
		object[] array = new object[1];
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)value;
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "notificationsEnabled");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000055")]
	[Address(RVA = "0x15C3530", Offset = "0x15C3530", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ECC850]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2029973]) = v41;\nL_0018:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0021:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0042;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002E;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv72 = ~v83;\n\tif (v72) goto L_0042;\n\tgoto L_0042;\n\tv103 = v74;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tgoto L_004F;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\treturnBuffer.<Key>k__BackingField = 0;\n\treturnBuffer.<Values>k__BackingField = v88.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"notificationsEnabled\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v65;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "notificationsEnabled");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaNotificationsEnabledAttribute result = default(YandexAppMetricaNotificationsEnabledAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}

	[Token(Token = "0x6000056")]
	[Address(RVA = "0x15C12D0", Offset = "0x15C12D0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaNotificationsEnabledAttribute()
	{
	}
}
