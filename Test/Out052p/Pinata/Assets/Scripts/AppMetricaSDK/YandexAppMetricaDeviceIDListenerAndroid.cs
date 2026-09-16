using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000013")]
public class YandexAppMetricaDeviceIDListenerAndroid : AndroidJavaProxy
{
	[Token(Token = "0x4000022")]
	[FieldOffset(Offset = "0x20")]
	private readonly Action<string, YandexAppMetricaRequestDeviceIDError?> action;

	[Token(Token = "0x6000087")]
	[Address(RVA = "0x15C10C0", Offset = "0x15C10C0", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF3888]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029961]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.yandex.metrica.AppMetricaDeviceIDListener\");\n\tthis.action = action;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaDeviceIDListenerAndroid(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
		: base("com.yandex.metrica.AppMetricaDeviceIDListener")
	{
		this.action = action;
	}

	[Token(Token = "0x6000088")]
	[Address(RVA = "0x15C1FEC", Offset = "0x15C1FEC", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv22 = *([1EDA5D8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, deviceID, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029962]) = v41;\nL_0023:\n\tSystem.Action`2<System.String, System.Nullable`1<YandexAppMetricaRequestDeviceIDError>>::Invoke(this.action, deviceID, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onLoaded(string deviceID)
	{
		action(deviceID, null);
	}

	[Token(Token = "0x6000089")]
	[Address(RVA = "0x15C2058", Offset = "0x15C2058", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF2D88]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, reason, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029963]) = v41;\nL_0017:\n\tv44 = YandexAppMetricaDeviceIDListenerAndroid::ErrorFromAndroidReason(v39, reason);\n\tSystem.Action`2<System.String, System.Nullable`1<YandexAppMetricaRequestDeviceIDError>>::Invoke(v39.action, 0, v44);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onError(AndroidJavaObject reason)
	{
		YandexAppMetricaRequestDeviceIDError? arg = ErrorFromAndroidReason(reason);
		action(null, arg);
	}

	[Token(Token = "0x600008A")]
	[Address(RVA = "0x15C20D4", Offset = "0x15C20D4", Length = "0x250")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0014;\n\tv20 = *([1F04B80]);\n\tv21 = *([v20 @ X8_v42]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, reason, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029964]) = v40;\nL_0014:\n\tv41 = reason == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv52 = v46;\n\tv53 = 0x8907BC(v52, reason, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = *([v46 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv57 = *([v46 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0044;\n\tv132 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv183 = v132;\n\tv184 = 0x8907BC(v183, reason, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0030:\n\tv185 = *([v132 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv142 = ~v185;\n\tif (v142) goto L_0044;\n\tgoto L_0044;\n\tv210 = v147;\n\tv211 = 0x8907BC(v210, reason, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0044:\n\tgoto L_0050;\n\tv186 = v149;\n\tv187 = 0x8907BC(v186, reason, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0050:\n\tv196 = UnityEngine.AndroidJavaObject::Call(reason, \"toString\", v190.Value);\n\tgoto L_0063;\n\tv214 = *([v203 @ X0_v9+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0063;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v203, v194, v193, v96, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0063:\n\tv223 = System.Type::GetTypeFromHandle(YandexAppMetricaRequestDeviceIDError);\n\tgoto L_0074;\n\tv230 = *([v226 @ X0_v13+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_0074;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v226, v222, v193, v96, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0074:\n\tv240 = System.Enum::Parse(v223, v196);\n\tv118 = &v241 @ stack_-40;\n\tv115 = v240 == 0;\n\tif (v115) goto L_008B;\n\tv257 = v257_asT == 0;\n\tif (v257) goto L_0097;\nL_008B:\n\tv258 = UnityEngine.AndroidJavaObject::Call(v240, YandexAppMetricaRequestDeviceIDError, &v241 @ stack_-40);\n\tgoto L_0096;\nL_0096:\n\treturn returnVal1;\nL_0097:\n\tv259 = new System.InvalidCastException();\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\nL_00A6:\n\tv62 = YandexAppMetricaRequestDeviceIDError != 1;\n\tif (v62) goto L_00C9;\n\tv263 = UnityEngine.AndroidJavaObject::Call(v259, YandexAppMetricaRequestDeviceIDError, 0);\n\tv273 = *([v263 @ X0_v25 (System.String)]);\n\tv276 = \"il2cpp_vm_class_is_assignable_from\"(System.ArgumentException, *([v273 @ X8_v28 (Il2CppClass<System.String>)]), 0, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv277 = v276 & 1;\n\tv116 = v277 == 0;\n\tif (v116) goto L_00BF;\n\tv278 = UnityEngine.AndroidJavaObject::Call(v276, *([v273 @ X8_v28 (Il2CppClass<System.String>)]), 0);\n\tv282 = &v11 @ stack_-10_v2 - 0x18;\n\t*([v10 @ X29_v1-18]) = 0;\n\tv283 = UnityEngine.AndroidJavaObject::Call(v282, 0, Il2CppMethodInfo);\n\treturnVal1 = *([v10 @ X29_v1-18]);\n\tgoto L_0096;\nL_00BF:\n\tv280 = UnityEngine.AndroidJavaObject::Call(8, *([v273 @ X8_v28 (Il2CppClass<System.String>)]), 0);\n\t*([v280 @ X0_v29 (System.String)]) = *([v263 @ X0_v25 (System.String)]);\n\tv166 = 0x1E8A000 + 0x870;\n\tv285 = UnityEngine.AndroidJavaObject::Call(v280, v166, 0);\n\tv267 = UnityEngine.AndroidJavaObject::Call(v285, v166, 0);\nL_00C9:\n\tv271 = UnityEngine.AndroidJavaObject::Call(v178, v166, v168);\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v271, v166, v168);\n\treturn returnVal2;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private YandexAppMetricaRequestDeviceIDError? ErrorFromAndroidReason(AndroidJavaObject reason)
	{
		//IL_00cf: Expected I4, but got O
		//IL_0192: Expected I, but got O
		//IL_022d: Expected O, but got I
		//IL_022d: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_01db: Expected O, but got I
		//IL_01ee: Expected O, but got I
		//IL_0200: Expected O, but got I
		//IL_0219: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		if (reason != null)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			string value = reason.Call<string>("toString", Array.Empty<object>());
			Type typeFromHandle = typeof(YandexAppMetricaRequestDeviceIDError);
			object obj3 = Enum.Parse(typeFromHandle, value);
			object obj4 = default(object);
			object[] result = (object[])obj4;
			if (obj3 == null || (int)((obj3 is YandexAppMetricaRequestDeviceIDError) ? obj3 : null) != 0)
			{
				string text = ((AndroidJavaObject)obj3).Call<string>((string)(object)typeof(YandexAppMetricaRequestDeviceIDError), (object[])obj4);
				return (YandexAppMetricaRequestDeviceIDError?)result;
			}
			InvalidCastException ex = new InvalidCastException();
			bool flag = (IntPtr)typeof(YandexAppMetricaRequestDeviceIDError) != (IntPtr)1;
			string methodName = (string)(object)typeof(YandexAppMetricaRequestDeviceIDError);
			object[] args = null;
			InvalidCastException ex2 = ex;
			if (!flag)
			{
				string text2 = ((AndroidJavaObject)(object)ex).Call<string>((string)(object)typeof(YandexAppMetricaRequestDeviceIDError), (object[])null);
				IntPtr intPtr3 = (IntPtr)text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				AndroidJavaObject androidJavaObject = default(AndroidJavaObject);
				if ((uint)((ulong)(long)(IntPtr)androidJavaObject & 1uL) != 0)
				{
					string text3 = androidJavaObject.Call<string>((string)(long)intPtr3, (object[])null);
					AndroidJavaObject androidJavaObject2 = (AndroidJavaObject)((long)(IntPtr)obj2 - 24L);
					_ = 0;
					string text4 = androidJavaObject2.Call<string>(null, (object[])0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-18]");
					return (YandexAppMetricaRequestDeviceIDError?)(object)0;
				}
				string text5 = ((AndroidJavaObject)8).Call<string>((string)(long)intPtr3, (object[])null);
				text5 = text2;
				methodName = (string)(32022528 + 2160);
				string text6 = ((AndroidJavaObject)(object)text5).Call<string>(methodName, (object[])null);
				string text7 = ((AndroidJavaObject)(object)text6).Call<string>(methodName, (object[])null);
				args = null;
				ex2 = (InvalidCastException)(object)text6;
			}
			string text8 = ((AndroidJavaObject)(object)ex2).Call<string>(methodName, args);
			return (YandexAppMetricaRequestDeviceIDError?)((AndroidJavaObject)(object)text8).Call<string>(methodName, args);
		}
		return null;
	}
}
