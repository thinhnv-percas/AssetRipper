using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000D")]
public class YandexAppMetricaNumberAttribute
{
	[Token(Token = "0x4000018")]
	private const string AttributeName = "customNumber";

	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0x10")]
	internal readonly string Key;

	[Token(Token = "0x6000057")]
	[Address(RVA = "0x15C145C", Offset = "0x15C145C", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Key = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaNumberAttribute(string key)
	{
		Key = key;
	}

	[Token(Token = "0x6000058")]
	[Address(RVA = "0x15C3624", Offset = "0x15C3624", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EA8E70]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, value, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029974]) = v47;\nL_001D:\n\t// 29 NewArr v53 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 36 Box v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Double), &value @ V0 (System.Double)\n\tv63 = v60 == 0;\n\tif (v63) goto L_0031;\n\t// 45 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_0031:\n\tv76 = v53.Length == 0;\n\tif (v76) goto L_0049;\n\tv53[0] = v60;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v53;\n\treturnBuffer.<AttributeName>k__BackingField = \"customNumber\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValue\";\n\treturn returnVal1;\n\tv65 = new System.NullReferenceException();\nL_0049:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004E;\n\tv95 = new System.ArrayTypeMismatchException();\nL_004E:\n\tthrow v115;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValue(double value)
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "customNumber");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withValue");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0x15C371C", Offset = "0x15C371C", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1F0BED8]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, value, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029975]) = v47;\nL_001D:\n\t// 29 NewArr v53 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 36 Box v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Double), &value @ V0 (System.Double)\n\tv63 = v60 == 0;\n\tif (v63) goto L_0031;\n\t// 45 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_0031:\n\tv76 = v53.Length == 0;\n\tif (v76) goto L_0049;\n\tv53[0] = v60;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v53;\n\treturnBuffer.<AttributeName>k__BackingField = \"customNumber\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueIfUndefined\";\n\treturn returnVal1;\n\tv65 = new System.NullReferenceException();\nL_0049:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004E;\n\tv95 = new System.ArrayTypeMismatchException();\nL_004E:\n\tthrow v115;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithValueIfUndefined(double value)
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
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "customNumber");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withValueIfUndefined");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600005A")]
	[Address(RVA = "0x15C3814", Offset = "0x15C3814", Length = "0x258")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F0C498]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029976]) = v46;\nL_001C:\n\tv52 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv57 = v52;\n\tv58 = 0x8907BC(v57, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv61 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv62 = *([v52 @ X21_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv63 = v62 == 0;\n\tif (v63) goto L_0046;\n\tv65 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv87 = v65;\n\tv88 = 0x8907BC(v87, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv89 = *([v65 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv78 = ~v89;\n\tif (v78) goto L_0046;\n\tgoto L_0046;\n\tv111 = v80;\n\tv112 = 0x8907BC(v111, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0046:\n\tgoto L_0053;\n\tv90 = v82;\n\tv91 = 0x8907BC(v90, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0053:\n\treturnBuffer.<Key>k__BackingField = v72.Key;\n\treturnBuffer.<Values>k__BackingField = v94.Value;\n\treturnBuffer.<AttributeName>k__BackingField = \"customNumber\";\n\treturnBuffer.<MethodName>k__BackingField = \"withValueReset\";\n\treturn v71;\n\tX0 = *([X0]);\n\treturn X0;\n\t*([X0]) = X1;\n\treturn X0;\n\tX0 = *([X0+8]);\n\treturn X0;\n\t*([X0+8]) = X1;\n\treturn X0;\n\t// 102 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([2029977]);\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007B;\n\tX8 = *([1ED9580]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2029977]) = X8;\nL_007B:\n\t*([X19]) = X20;\n\tX8 = *([1EE3E70]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB3468]);\n\tX20 = X0;\n\tX1 = *([X8]);\n\tSystem.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>::.ctor /* +45 sharing this address */(X0, X1);\n\t*([X19+8]) = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 139 ShiftStack 48\n\treturn X0;\n\tX0 = *([X0]);\n\treturn X0;\n\t*([X0]) = X1;\n\treturn X0;\n\tX0 = *([X0+8]);\n\treturn X0;\n\t*([X0+8]) = X1;\n\treturn X0;\n\tX0 = *([X0+10]);\n\treturn X0;\n\t*([X0+10]) = X1;\n\treturn X0;\n\tV0 = *([X0]);\n\treturn X0;\n\t*([X0]) = V0;\n\treturn X0;\n\tX0 = *([X0+8]);\n\treturn X0;\n\t*([X0+8]) = X1;\n\treturn X0;\n\tX0 = *([X0+10]);\n\treturn X0;\n\t*([X0+10]) = X1;\n\treturn X0;\n\tX0 = *([X0+18]);\n\treturn X0;\n\t*([X0+18]) = X1;\n\treturn X0;\n\tV0 = *([X0+30]);\n\t*([X8+10]) = V0;\n\tV0 = *([X0+20]);\n\t*([X8]) = V0;\n\treturn X0;\n\tV0 = *([X1]);\n\tV1 = *([X1+10]);\n\t*([X0+20]) = V0;\n\t*([X0+30]) = V1;\n\treturn X0;\n\tX0 = *([X0+40]);\n\treturn X0;\n\t*([X0+40]) = X1;\n\treturn X0;\n\t*([X0]) = V0;\n\tV0 = 0;\n\t*([X0+8]) = 0;\n\t*([X0+10]) = X1;\n\t*([X0+18]) = 0;\n\t*([X0+40]) = 0;\n\t*([X0+20]) = V0;\n\t*([X0+30]) = V0;\n\treturn X0;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->AttributeName, "customNumber");
		System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate)->MethodName, "withValueReset");
		YandexAppMetricaNumberAttribute result = default(YandexAppMetricaNumberAttribute);
		return (YandexAppMetricaUserProfileUpdate)result;
	}
}
