using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;

namespace Firebase
{
	[Token(Token = "0x2000013")]
	internal sealed class LogUtil : IDisposable
	{
		[Token(Token = "0x2000014")]
		internal delegate void LogMessageDelegate(LogLevel log_level, string message);

		[Token(Token = "0x4000033")]
		private static LogUtil _instance;

		[Token(Token = "0x4000034")]
		private static object InitializeLoggingLock;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x10")]
		private bool _disposed;

		[CompilerGenerated]
		[Token(Token = "0x4000036")]
		private static LogMessageDelegate _003C_003Ef__mg_0024cache0;

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x1600F80", Offset = "0x1600F80", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EA4F60]);\n\tv17 = *([v16 @ X8_v11]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A1A2]) = v37;\nL_0016:\n\tv41._instance = 0;\n\tv45 = new System.Object();\n\tSystem.Object::.ctor(v45);\n\tv49.InitializeLoggingLock = v45;\n\tv50 = new Firebase.LogUtil();\n\tFirebase.LogUtil::.ctor(v50);\n\tv53._instance = v50;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LogUtil()
		{
			_instance = null;
			object initializeLoggingLock = new object();
			InitializeLoggingLock = initializeLoggingLock;
			LogUtil instance = new LogUtil();
			_instance = instance;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x1601010", Offset = "0x1601010", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EEA470]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1A3]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tgoto L_0025;\n\tv47 = *([v43 @ X0_v3 (Il2CppClass<Firebase.LogUtil>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = Firebase.LogUtil;\nL_0025:\n\tv56 = v54.<>f__mg$cache0 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0044;\n\tv62 = new Firebase.LogUtil+LogMessageDelegate();\n\tv79 = Il2CppMethodInfo;\n\tv62.m_target = 0;\n\tv62.method = Il2CppMethodInfo;\n\tv62.method_ptr = *([v79 @ X8_v16 (Il2CppMethodInfo)]);\n\tgoto L_0040;\n\tv97 = *([v80 @ X0_v12 (Il2CppClass<Firebase.LogUtil>)+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0040;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v80, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = Firebase.LogUtil;\nL_0040:\n\tv73.<>f__mg$cache0 = v62;\nL_0044:\n\tgoto L_0052;\n\tv84 = *([v66 @ X0_v5 (Il2CppClass<Firebase.LogUtil>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tgoto L_0052;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v66, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv88 = Firebase.LogUtil;\nL_0052:\n\tFirebase.AppUtil::SetLogFunction(v91.<>f__mg$cache0);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe LogUtil()
		{
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				LogMessageDelegate logMessageDelegate = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)logMessageDelegate).m_target = null;
				((Delegate)logMessageDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<LogLevel, string, void>*/)(&LogMessageFromCallback);
				((Delegate)logMessageDelegate).method_ptr = method_ptr;
				_003C_003Ef__mg_0024cache0 = logMessageDelegate;
			}
			AppUtil.SetLogFunction(_003C_003Ef__mg_0024cache0);
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15FE14C", Offset = "0x15FE14C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EFFCD0]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A1A4]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.LogUtil>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.LogUtil;\nL_0023:\n\tSystem.Threading.Monitor::Enter(v51.InitializeLoggingLock);\n\tFirebase.AppUtil::AppEnableLogCallback(1);\n\tSystem.Threading.Monitor::Exit(v51.InitializeLoggingLock);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0049;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004A;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 71 ShiftStack 32\n\treturn;\nL_0049:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void InitializeLogging()
		{
			Monitor.Enter(InitializeLoggingLock);
			AppUtil.AppEnableLogCallback(arg0: true);
			Monitor.Exit(InitializeLoggingLock);
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x160110C", Offset = "0x160110C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = logLevel < 5;\n\tv2 = ~v0;\n\tv10 = ~v2;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_0010;\nL_0010:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Firebase.Platform.PlatformLogLevel ConvertLogLevel(LogLevel logLevel)
		{
			if (logLevel < LogLevel.Assert)
			{
				return (Firebase.Platform.PlatformLogLevel)logLevel;
			}
			return Firebase.Platform.PlatformLogLevel.Debug;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x16001FC", Offset = "0x16001FC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECAC10]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1A5]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = logLevel < 5;\n\tv58 = ~v57;\n\tv66 = ~v58;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tgoto L_0046;\n\tv75 = *([v71 @ X0_v4+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tgoto L_0046;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v71, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0046:\n\tFirebase.Platform.FirebaseLogger::LogMessage(v70, message);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void LogMessage(LogLevel logLevel, string message)
		{
			LogLevel logLevel2 = ((logLevel >= LogLevel.Assert) ? LogLevel.Debug : logLevel);
			FirebaseLogger.LogMessage((Firebase.Platform.PlatformLogLevel)logLevel2, message);
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BDDC", Offset = "0x73BDDC")]
		[Token(Token = "0x6000087")]
		[Address(RVA = "0x1600ED0", Offset = "0x1600ED0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEFD88]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1A6]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = Firebase.Platform.FirebaseLogger::get_CanRedirectNativeLogs();\n\tv58 = v56 == 0;\n\tif (v58) goto L_0042;\n\tgoto L_003A;\n\tv70 = *([v61 @ X0_v6+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v61, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003A:\n\tFirebase.LogUtil::LogMessage(logLevel, message);\n\treturn;\nL_0042:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void LogMessageFromCallback(LogLevel logLevel, string message)
		{
			if (FirebaseLogger.CanRedirectNativeLogs)
			{
				LogMessage(logLevel, message);
			}
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1601118", Offset = "0x1601118", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._disposed;\n\tv14 = ~v13;\n\tif (v14) goto L_0016;\n\tFirebase.AppUtil::SetLogFunction(0);\n\tthis._disposed = 1;\nL_0016:\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0032;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0033;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 48 ShiftStack 32\n\treturn;\nL_0032:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0033:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~LogUtil()
		{
			if (!_disposed)
			{
				AppUtil.SetLogFunction(null);
				_disposed = true;
			}
			base.Finalize();
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x16011CC", Offset = "0x16011CC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC9CB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1A7]) = v38;\nL_0014:\n\tv40 = ~this._disposed;\n\tv41 = ~v40;\n\tif (v41) goto L_0021;\n\tFirebase.AppUtil::SetLogFunction(0);\n\tthis._disposed = 1;\nL_0021:\n\tgoto L_002E;\n\tv52 = *([v48 @ X0_v3+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tSystem.GC::SuppressFinalize(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (!_disposed)
			{
				AppUtil.SetLogFunction(null);
				_disposed = true;
			}
			GC.SuppressFinalize(this);
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x1601198", Offset = "0x1601198", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this._disposed;\n\tv12 = ~v11;\n\tif (v12) goto L_0012;\n\tFirebase.AppUtil::SetLogFunction(0);\n\tthis._disposed = 1;\nL_0012:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				AppUtil.SetLogFunction(null);
				_disposed = true;
			}
		}
	}
}
