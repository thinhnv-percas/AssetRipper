using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Firebase.Platform
{
	[Token(Token = "0x2000007")]
	public class FirebaseLogger
	{
		[Token(Token = "0x4000016")]
		private static MainThreadProperty<bool> incompatibleStackUnwindingEnabled;

		[CompilerGenerated]
		[Token(Token = "0x4000017")]
		private static Func<bool> _003C_003Ef__mg_0024cache0;

		[Token(Token = "0x1700000C")]
		public static bool CanRedirectNativeLogs
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x15E8170", Offset = "0x15E8170", Length = "0x15C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F0B3D0]);\n\tv17 = *([v16 @ X8_v31]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F78]) = v37;\nL_0018:\n\tgoto L_0026;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseLogger>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\t// 28 Jump @b31\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.Platform.FirebaseLogger;\nL_0026:\n\tv58 = Firebase.Platform.MainThreadProperty`1<System.Boolean>::get_Value(v51.incompatibleStackUnwindingEnabled);\n\tv74 = v58 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_003C;\n\tv166 = *([v94 @ X0_v16+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_003C;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v94, v57, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003C:\n\tv65 = System.Type::GetTypeFromHandle(UnityEngine.Application);\n\tv232 = System.Type::GetField(v65, \"stackTraceLogType\");\n\tv233 = v232 == 0;\n\tif (v233) goto L_FFFFFFFF;\n\tv234 = *([v232 @ X0_v20 (System.Reflection.FieldInfo)]);\n\tv236 = System.Reflection.FieldInfo::GetValue(v232, 0);\n\tgoto L_FFFFFFFF;\n\tv241 = *([v87 @ X8_v22+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\t// 84 ConditionalJump @b20, v243 @ TEMP_v27\n\tv246 = v87;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v246, v81, v77, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv139 = v139_asT == 0;\n\tif (v139) goto L_0085;\n\tv132 = \"il2cpp_vm_object_unbox\"(v236, UnityEngine.StackTraceLogType, *([v234 @ X8_v21 (Il2CppClass<System.Reflection.FieldInfo>)+268]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv251 = *([v132 @ X0_v26]) < 1;\n\tv125 = ~v251;\n\tv122 = *([v132 @ X0_v26]) - 1;\n\tv116 = v122 == 0;\n\tv252 = ~v116;\n\tv101 = v125 & v252;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_0081;\nL_0081:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\tv91 = new System.NullReferenceException();\nL_0085:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_008a: Expected I, but got O
				//IL_00aa: Expected I4, but got O
				//IL_015d: Expected I4, but got O
				//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Expected O, but got Unknown
				if (!incompatibleStackUnwindingEnabled.Value)
				{
					Type typeFromHandle = typeof(Application);
					FieldInfo field = typeFromHandle.GetField("stackTraceLogType");
					if ((object)field != null)
					{
						IntPtr intPtr = (IntPtr)field;
						object value = field.GetValue(null);
						if ((int)((value is StackTraceLogType) ? value : null) == 0)
						{
							InvalidCastException ex = new InvalidCastException();
							return (byte)(int)ex != 0;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj = default(object);
						bool flag = (long)(IntPtr)obj < 1L;
						bool flag2 = !flag;
						object obj2 = obj - 1;
						bool flag3 = obj2 == null;
						bool flag4 = !flag3;
						if (flag2 && flag4)
						{
							goto IL_0141;
						}
					}
					return true;
				}
				goto IL_0141;
				IL_0141:
				return false;
			}
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x15E7F4C", Offset = "0x15E7F4C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = logType < 1;\n\tv2 = ~v0;\n\tv3 = logType - 1;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\treturn v11;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsStackTraceLogTypeIncompatibleWithNativeLogs(StackTraceLogType logType)
		{
			bool flag = logType < StackTraceLogType.ScriptOnly;
			bool flag2 = !flag;
			int num = (int)(logType - 1);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			return flag2 && flag4;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x15E7F58", Offset = "0x15E7F58", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EEE580]);\n\tv31 = *([v30 @ X8_v35]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([2029F77]) = v51;\nL_0022:\n\tgoto L_002A;\n\tv61 = *([v54 @ X0_v2+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_002A;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v54, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002A:\n\tv70 = System.Type::GetTypeFromHandle(UnityEngine.Application);\n\tv76 = System.Type::GetMethod(v70, \"GetStackTraceLogType\");\n\tv143 = v76 == 0;\n\tif (v143) goto L_00C8;\n\t// 57 NewArr v148 @ X0_v11 (UnityEngine.LogType[]), typeof(UnityEngine.LogType[]), 5\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v148, Il2CppFieldInfo);\n\tv383 = v148.Length;\n\tv281 = v148.Length < 1;\n\tif (v281) goto L_FFFFFFFF;\nL_0058:\n\tv394 = v168 < v383;\n\tv314 = ~v394;\n\tif (v314) goto L_00CB;\n\tv165 = v168 << 2;\n\tv326 = v148 + v165;\n\tv396 = *([v326 @ X8_v22+20]);\n\t// 103 NewArr v398 @ X0_v23 (System.Object[]), typeof(System.Object[]), 1\n\t// 108 Box v321 @ X0_v25, typeof(UnityEngine.LogType), &v396 @ X22_v9\n\tv420 = v321 == 0;\n\tif (v420) goto L_0079;\n\t// 117 IsInst v424 @ X0_v39, typeof(System.Object), v321 @ X0_v25\nL_0079:\n\tv381 = v398.Length == 0;\n\tif (v381) goto L_00CB;\n\tv398[0] = v321;\n\tv429 = System.Reflection.MethodBase::Invoke(v76, 0, v398);\n\tgoto L_FFFFFFFF;\n\tv444 = *([v327 @ X8_v26+E0]);\n\tv445 = v444 == 0;\n\tv446 = ~v445;\n\t// 138 ConditionalJump @b27, v446 @ TEMP_v27\n\tv449 = v327;\n\tv447 = \"il2cpp_codegen_runtime_class_init\"(v449, v319, v211, v153, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv183 = v183_asT == 0;\n\tif (v183) goto L_00CD;\n\tv346 = \"il2cpp_vm_object_unbox\"(v429, UnityEngine.StackTraceLogType, v398, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv453 = *([v346 @ X0_v34]) < 2;\n\tv207 = ~v453;\n\tif (v207) goto L_FFFFFFFF;\n\tv383 = v148.Length;\n\tv168 = v168 + 1;\n\tv336 = v168 < v148.Length;\n\tif (v336) goto L_0058;\n\tgoto L_00C8;\nL_00C8:\n\treturn returnVal2;\n\tv329 = new System.NullReferenceException();\nL_00CB:\n\tv385 = new System.IndexOutOfRangeException();\n\tgoto L_00D1;\nL_00CD:\n\tv439 = new System.InvalidCastException();\n\tv416 = new System.ArrayTypeMismatchException();\nL_00D1:\n\tthrow v385;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CurrentStackTraceLogTypeIsIncompatibleWithNativeLogs()
		{
			//IL_0041: Expected I4, but got O
			//IL_00c4: Expected O, but got I
			//IL_00d4: Expected O, but got I
			//IL_00eb: Expected I4, but got O
			//IL_0178: Expected I4, but got O
			Type typeFromHandle = typeof(Application);
			MethodInfo method = typeFromHandle.GetMethod("GetStackTraceLogType");
			bool flag = (object)method == null;
			bool result = (byte)(int)method != 0;
			if (!flag)
			{
				LogType[] array = new LogType[5]
				{
					LogType.Log,
					LogType.Warning,
					LogType.Error,
					LogType.Assert,
					LogType.Exception
				};
				int num = array.Length;
				if (array.Length < 1)
				{
					goto IL_0203;
				}
				int num2 = 0;
				object obj6 = default(object);
				IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
				while (true)
				{
					if (num2 < num)
					{
						int num3 = num2 << 2;
						object obj = (long)(IntPtr)array + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X8_v22+20]");
						object obj2 = 0;
						object[] array2 = new object[1];
						object obj3 = (LogType)obj2;
						if (obj3 != null)
						{
							object obj4 = obj3 as object;
						}
						if (array2.Length != 0)
						{
							array2[0] = obj3;
							object obj5 = method.Invoke(null, array2);
							if ((int)((obj5 is StackTraceLogType) ? obj5 : null) != 0)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								if ((long)(IntPtr)obj6 >= 2L)
								{
									break;
								}
								num = array.Length;
								num2++;
								if (num2 < array.Length)
								{
									continue;
								}
								goto IL_0203;
							}
							InvalidCastException ex = new InvalidCastException();
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							goto IL_0249;
						}
					}
					ex3 = new IndexOutOfRangeException();
					goto IL_0249;
					IL_0249:
					throw ex3;
				}
				result = true;
			}
			goto IL_0253;
			IL_0203:
			result = false;
			goto IL_0253;
			IL_0253:
			return result;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x15E55E8", Offset = "0x15E55E8", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB5840]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029F79]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1EF3128]);\n\tv63 = *([v62 @ X8_v32]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2022B9C]) = v67;\nL_0031:\n\tgoto L_0039;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0039;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = Firebase.Platform.FirebaseHandler;\nL_0039:\n\tv80 = v79.<AppUtils>k__BackingField;\n\tv84 = *([v80 @ X21_v4 (Firebase.Platform.IFirebaseAppUtils)]);\n\tv88 = *([v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]) == 0;\n\tif (v88) goto L_0060;\n\tv142 = *([v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]) + 8;\nL_004B:\n\tv148 = *([v142 @ X11_v5-8]) == Firebase.Platform.IFirebaseAppUtils;\n\tif (v148) goto L_0063;\n\tv143 = v143 + 1;\n\tv253 = v143 < *([v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]);\n\tv122 = ~v253;\n\tv142 = v142 + 0x10;\n\tv98 = ~v122;\n\tif (v98) goto L_004B;\nL_0060:\n\tv268 = 0x8909C4(v80, Firebase.Platform.IFirebaseAppUtils, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_006A;\nL_0063:\n\tv255 = *([v142 @ X11_v5]) + 4;\n\tv256 = v255 << 4;\n\tv257 = v84 + v256;\n\tv268 = v257 + 0x130;\nL_006A:\n\t*([v268 @ X0_v9])(v220, v80, *([v268 @ X0_v9+8]), 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv167 = v220 <= logLevel;\n\tif (v167) goto L_0080;\nL_007F:\n\treturn;\nL_0080:\n\tv282 = logLevel < 3;\n\tv199 = ~v282;\n\tv187 = logLevel == 3;\n\tif (v199) goto L_00A1;\n\tgoto L_009F;\n\tv289 = *([v285 @ X0_v20+E0]);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_009F;\n\tv293 = \"il2cpp_codegen_runtime_class_init\"(v285, v204, v164, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_009F:\n\tUnityEngine.Debug::Log(message);\n\treturn;\nL_00A1:\n\tif (v187) goto L_00CA;\n\tv168 = logLevel != 4;\n\tif (v168) goto L_007F;\n\tgoto L_00C2;\n\tv312 = *([v303 @ X0_v16+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_00C2;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v303, v204, v164, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00C2:\n\tUnityEngine.Debug::LogError(message);\n\treturn;\nL_00CA:\n\tgoto L_00D9;\n\tv307 = *([v297 @ X0_v12+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_00D9;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v297, v204, v164, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00D9:\n\tUnityEngine.Debug::LogWarning(message);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogMessage(PlatformLogLevel logLevel, string message)
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0099: Expected O, but got I
			IFirebaseAppUtils _003CAppUtils_003Ek__BackingField = FirebaseHandler.AppUtils;
			IntPtr intPtr = (IntPtr)_003CAppUtils_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFirebaseAppUtils))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v10 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_01da;
			IL_00b2:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_01da;
			IL_01da:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v268 @ X0_v9] (should have been resolved before IL gen)");
			int num4 = default(int);
			if (num4 > (int)logLevel)
			{
				return;
			}
			bool flag3 = logLevel < PlatformLogLevel.Warning;
			bool flag4 = !flag3;
			bool flag5 = logLevel == PlatformLogLevel.Warning;
			if (!flag4)
			{
				Debug.Log(message);
			}
			else if (!flag5)
			{
				if (logLevel == PlatformLogLevel.Error)
				{
					Debug.LogError(message);
				}
			}
			else
			{
				Debug.LogWarning(message);
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x15E82CC", Offset = "0x15E82CC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF9A80]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F7A]) = v39;\nL_0017:\n\tv63 = v43.<>f__mg$cache0;\n\tv45 = v43.<>f__mg$cache0 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tv50 = new System.Func`1<System.Boolean>();\n\tSystem.Func`1<System.Boolean>::.ctor(v50, 0, Il2CppMethodInfo);\n\tv58.<>f__mg$cache0 = v50;\n\tv63 = v62.<>f__mg$cache0;\nL_0030:\n\tv68 = new Firebase.Platform.MainThreadProperty`1<System.Boolean>();\n\tFirebase.Platform.MainThreadProperty`1<System.Boolean>::.ctor(v68, v63);\n\tv81.incompatibleStackUnwindingEnabled = v68;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FirebaseLogger()
		{
			Func<bool> getPropertyDelegate = _003C_003Ef__mg_0024cache0;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				Func<bool> func = CurrentStackTraceLogTypeIsIncompatibleWithNativeLogs;
				_003C_003Ef__mg_0024cache0 = func;
				getPropertyDelegate = _003C_003Ef__mg_0024cache0;
			}
			MainThreadProperty<bool> mainThreadProperty = new MainThreadProperty<bool>(getPropertyDelegate);
			incompatibleStackUnwindingEnabled = mainThreadProperty;
		}
	}
}
