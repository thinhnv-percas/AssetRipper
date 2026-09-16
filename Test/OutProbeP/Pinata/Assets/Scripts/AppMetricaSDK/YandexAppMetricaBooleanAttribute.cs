using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000008")]
public class YandexAppMetricaBooleanAttribute
{
	[Token(Token = "0x4000011")]
	private const string AttributeName = "customBoolean";

	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x10")]
	internal readonly string Key;

	[Token(Token = "0x6000048")]
	[Address(RVA = "0x15C133C", Offset = "0x15C133C", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Key = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaBooleanAttribute(string key)
	{
		Key = key;
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0x15C1B00", Offset = "0x15C1B00", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED9620]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202995D]) = v45;\nL_001C:\n\t// 28 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 35 Box v58 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv61 = v58 == 0;\n\tif (v61) goto L_0030;\n\t// 44 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v58 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_0030:\n\tv74 = v51.Length == 0;\n\tif (v74) goto L_0047;\n\tv51[0] = v58;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v51;\n\treturnBuffer.<AttributeName>k__BackingField = \"customBoolean\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tv63 = new System.NullReferenceException();\nL_0047:\n\tv79 = new System.IndexOutOfRangeException();\n\tgoto L_004C;\n\tv92 = new System.ArrayTypeMismatchException();\nL_004C:\n\tthrow v112;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(bool value)
	{
		//IL_0077: Expected native int or pointer, but got O
		//IL_0084: Expected native int or pointer, but got O
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a0: Expected native int or pointer, but got O
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, Key);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "customBoolean");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0x15C1BF8", Offset = "0x15C1BF8", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECBE50]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202995E]) = v45;\nL_001C:\n\t// 28 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 35 Box v58 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv61 = v58 == 0;\n\tif (v61) goto L_0030;\n\t// 44 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v58 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_0030:\n\tv74 = v51.Length == 0;\n\tif (v74) goto L_0047;\n\tv51[0] = v58;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v51;\n\treturnBuffer.<AttributeName>k__BackingField = \"customBoolean\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueIfUndefined\";\n\treturn returnVal1;\n\tv63 = new System.NullReferenceException();\nL_0047:\n\tv79 = new System.IndexOutOfRangeException();\n\tgoto L_004C;\n\tv92 = new System.ArrayTypeMismatchException();\nL_004C:\n\tthrow v112;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValueIfUndefined(bool value)
	{
		//IL_0077: Expected native int or pointer, but got O
		//IL_0084: Expected native int or pointer, but got O
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a0: Expected native int or pointer, but got O
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, Key);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "customBoolean");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withValueIfUndefined");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0x15C1CF0", Offset = "0x15C1CF0", Length = "0x204")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED2EE0]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202995F]) = v46;\nL_001C:\n\tv52 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv57 = v52;\n\tv58 = 0x8907BC(v57, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv61 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv62 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv63 = v62 == 0;\n\tif (v63) goto L_0046;\n\tv65 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv87 = v65;\n\tv88 = 0x8907BC(v87, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv89 = *([v65 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv78 = ~v89;\n\tif (v78) goto L_0046;\n\tgoto L_0046;\n\tv111 = v80;\n\tv112 = 0x8907BC(v111, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0046:\n\tgoto L_0053;\n\tv90 = v82;\n\tv91 = 0x8907BC(v90, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0053:\n\treturnBuffer.<Key>k__BackingField = v72.Key;\n\treturnBuffer.<Values>k__BackingField = v94.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"customBoolean\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v71;\n\tX0 = *([X0]);\n\treturn X0;\n\t*([X0]) = X1;\n\treturn X0;\n\tX0 = *([X0+8]);\n\treturn X0;\n\t*([X0+8]) = X1;\n\treturn X0;\n\tX9 = *([X0+20]);\n\t*([X8+10]) = X9;\n\tV0 = *([X0+10]);\n\t*([X8]) = V0;\n\treturn X0;\n\tX8 = *([X1+10]);\n\tV0 = *([X1]);\n\t*([X0+20]) = X8;\n\t*([X0+10]) = V0;\n\treturn X0;\n\tX0 = *([X0+28]);\n\treturn X0;\n\t*([X0+28]) = X1;\n\treturn X0;\n\tX0 = *([X0+30]);\n\treturn X0;\n\t*([X0+30]) = X1;\n\treturn X0;\n\tX0 = *([X0+32]);\n\treturn X0;\n\t*([X0+32]) = X1;\n\treturn X0;\n\tX0 = *([X0+34]);\n\treturn X0;\n\t*([X0+34]) = X1;\n\treturn X0;\n\tX0 = *([X0+36]);\n\treturn X0;\n\t*([X0+36]) = X1;\n\treturn X0;\n\tX0 = *([X0+38]);\n\treturn X0;\n\t*([X0+38]) = X1;\n\treturn X0;\n\tX9 = *([X0+50]);\n\t*([X8+10]) = X9;\n\tV0 = *([X0+40]);\n\t*([X8]) = V0;\n\treturn X0;\n\tX8 = *([X1+10]);\n\tV0 = *([X1]);\n\t*([X0+50]) = X8;\n\t*([X0+40]) = V0;\n\treturn X0;\n\tX0 = *([X0+58]);\n\treturn X0;\n\t*([X0+58]) = X1;\n\treturn X0;\n\tV0 = *([X0]);\n\treturn X0;\n\t*([X0]) = V0;\n\treturn X0;\n\tV0 = *([X0+8]);\n\treturn X0;\n\t*([X0+8]) = V0;\n\treturn X0;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "customBoolean");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaBooleanAttribute result = default(YandexAppMetricaBooleanAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}
}
