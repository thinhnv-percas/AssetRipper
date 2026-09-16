using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000E")]
public class YandexAppMetricaStringAttribute
{
	[Token(Token = "0x400001A")]
	private const string AttributeName = "customString";

	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0x10")]
	internal readonly string Key;

	[Token(Token = "0x600005B")]
	[Address(RVA = "0x15C14EC", Offset = "0x15C14EC", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Key = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaStringAttribute(string key)
	{
		Key = key;
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0x15C3A6C", Offset = "0x15C3A6C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED1C68]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029978]) = v45;\nL_001C:\n\t// 28 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = value == 0;\n\tif (v54) goto L_0029;\n\t// 37 IsInst returnVal1 @ X0_v9 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), value @ X1 (System.String)\nL_0029:\n\tv66 = v51.Length == 0;\n\tif (v66) goto L_003F;\n\tv51[0] = value;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v51;\n\treturnBuffer.<AttributeName>k__BackingField = \"customString\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tv55 = new System.NullReferenceException();\nL_003F:\n\tv71 = new System.IndexOutOfRangeException();\n\tgoto L_0044;\n\tv84 = new System.ArrayTypeMismatchException();\nL_0044:\n\tthrow v103;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(string value)
	{
		//IL_0077: Expected native int or pointer, but got O
		//IL_0084: Expected native int or pointer, but got O
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a0: Expected native int or pointer, but got O
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, Key);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "customString");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0x15C3B3C", Offset = "0x15C3B3C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB0A38]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029979]) = v45;\nL_001C:\n\t// 28 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = value == 0;\n\tif (v54) goto L_0029;\n\t// 37 IsInst returnVal1 @ X0_v9 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), value @ X1 (System.String)\nL_0029:\n\tv66 = v51.Length == 0;\n\tif (v66) goto L_003F;\n\tv51[0] = value;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v51;\n\treturnBuffer.<AttributeName>k__BackingField = \"customString\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueIfUndefined\";\n\treturn returnVal1;\n\tv55 = new System.NullReferenceException();\nL_003F:\n\tv71 = new System.IndexOutOfRangeException();\n\tgoto L_0044;\n\tv84 = new System.ArrayTypeMismatchException();\nL_0044:\n\tthrow v103;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValueIfUndefined(string value)
	{
		//IL_0077: Expected native int or pointer, but got O
		//IL_0084: Expected native int or pointer, but got O
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a0: Expected native int or pointer, but got O
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, Key);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "customString");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueIfUndefined");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0x15C3C0C", Offset = "0x15C3C0C", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECFE88]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202997A]) = v46;\nL_001C:\n\tv52 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv57 = v52;\n\tv58 = 0x8907BC(v57, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv61 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv62 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv63 = v62 == 0;\n\tif (v63) goto L_0046;\n\tv65 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv87 = v65;\n\tv88 = 0x8907BC(v87, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv89 = *([v65 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv78 = ~v89;\n\tif (v78) goto L_0046;\n\tgoto L_0046;\n\tv111 = v80;\n\tv112 = 0x8907BC(v111, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0046:\n\tgoto L_0053;\n\tv90 = v82;\n\tv91 = 0x8907BC(v90, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0053:\n\treturnBuffer.<Key>k__BackingField = v72.Key;\n\treturnBuffer.<Values>k__BackingField = v94.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"customString\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v71;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValueReset()
	{
		//IL_0054: Expected native int or pointer, but got O
		//IL_0062: Expected native int or pointer, but got O
		//IL_0070: Expected native int or pointer, but got O
		//IL_007e: Expected native int or pointer, but got O
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = default(YandexAppMetricaUserProfileUpdate);
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Key, Key);
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->Values, Array.Empty<object>());
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "customString");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaStringAttribute result = default(YandexAppMetricaStringAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}
}
