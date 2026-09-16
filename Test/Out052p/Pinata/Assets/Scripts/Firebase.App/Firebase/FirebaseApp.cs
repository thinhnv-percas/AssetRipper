using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;

namespace Firebase
{
	[Token(Token = "0x200000B")]
	public sealed class FirebaseApp : IDisposable
	{
		[Token(Token = "0x200000C")]
		private delegate FirebaseApp CreateDelegate();

		[Token(Token = "0x400001B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private HandleRef swigCPtr;

		[Token(Token = "0x400001C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private bool swigCMemOwn;

		[Token(Token = "0x400001D")]
		internal static readonly object disposeLock;

		[Token(Token = "0x400001E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private string name;

		[Token(Token = "0x400001F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private EventHandler AppDisposed;

		[Token(Token = "0x4000020")]
		private static Dictionary<string, FirebaseApp> nameToProxy;

		[Token(Token = "0x4000021")]
		private static Dictionary<IntPtr, FirebaseApp> cPtrToProxy;

		[Token(Token = "0x4000022")]
		private static bool AppUtilCallbacksInitialized;

		[Token(Token = "0x4000023")]
		private static object AppUtilCallbacksLock;

		[Token(Token = "0x4000024")]
		private static bool PreventOnAllAppsDestroyed;

		[Token(Token = "0x4000025")]
		private static bool installedCerts;

		[Token(Token = "0x4000026")]
		private static bool crashlyticsInitializationAttempted;

		[Token(Token = "0x4000027")]
		private static int CheckDependenciesThread;

		[Token(Token = "0x4000028")]
		private static object CheckDependenciesThreadLock;

		[Token(Token = "0x4000029")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private FirebaseAppPlatform appPlatform;

		[CompilerGenerated]
		[Token(Token = "0x400002A")]
		private static CreateDelegate _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		[Token(Token = "0x400002B")]
		private static Func<bool> _003C_003Ef__am_0024cache1;

		[Token(Token = "0x17000002")]
		public static FirebaseApp DefaultInstance
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x15FE804", Offset = "0x15FE804", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F02DC8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A187]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Firebase.FirebaseApp::get_DefaultName();\n\treturnVal1 = Firebase.FirebaseApp::GetInstance(v49);\n\tv51 = returnVal1 == 0;\n\tif (v51) goto L_002A;\n\treturn returnVal1;\nL_002A:\n\tgoto L_0034;\n\tv71 = *([v55 @ X0_v6 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0034;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0034:\n\treturnVal2 = Firebase.FirebaseApp::Create();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string defaultName = DefaultName;
				FirebaseApp instance = GetInstance(defaultName);
				if (instance != null)
				{
					return instance;
				}
				return Create();
			}
		}

		[Token(Token = "0x17000003")]
		public string Name
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x15FF74C", Offset = "0x15FF74C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000004")]
		public static LogLevel LogLevel
		{
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x15FF754", Offset = "0x15FF754", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED2A10]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A18A]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.AppUtilPINVOKE>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = Firebase.AppUtilPINVOKE::FirebaseApp_GetLogLevelInternal();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (LogLevel)AppUtilPINVOKE.FirebaseApp_GetLogLevelInternal();
			}
		}

		[Token(Token = "0x17000005")]
		public AppOptions Options
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x1600B60", Offset = "0x1600B60", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECCF68]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A195]) = v38;\nL_0014:\n\tFirebase.FirebaseApp::ThrowIfNull(this);\n\tv41 = Firebase.FirebaseApp::options(this);\n\tv47 = new Firebase.AppOptions();\n\tFirebase.AppOptions::.ctor(v47, v41);\n\treturn v47;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ThrowIfNull();
				AppOptionsInternal other = options();
				return new AppOptions(other);
			}
		}

		[Token(Token = "0x17000006")]
		internal FirebaseAppPlatform AppPlatform
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x1600970", Offset = "0x1600970", Length = "0x108")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = *([1EFCE88]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A196]) = v40;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v43 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Firebase.Platform.FirebaseAppPlatform);\n\tSystem.Threading.Monitor::Enter(v59);\n\tv69 = this.appPlatform;\n\tv63 = this.appPlatform == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0038;\n\tv68 = new Firebase.Platform.FirebaseAppPlatform();\n\tFirebase.Platform.FirebaseAppPlatform::.ctor(v68, this);\n\tthis.appPlatform = v68;\nL_0038:\n\tSystem.Threading.Monitor::Exit(v59);\nL_0039:\n\t;\n\treturn v69;\n\tgoto L_0042;\nL_0042:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_005A;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tX21 = 0;\n\tif (TEMP) goto L_0039;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005A:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type typeFromHandle = typeof(FirebaseAppPlatform);
				Monitor.Enter(typeFromHandle);
				FirebaseAppPlatform result = appPlatform;
				if (appPlatform == null)
				{
					result = (appPlatform = new FirebaseAppPlatform(this));
				}
				Monitor.Exit(typeFromHandle);
				return result;
			}
		}

		[Token(Token = "0x17000007")]
		internal string NameInternal
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x16008D8", Offset = "0x16008D8", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EA65F8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A198]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::FirebaseApp_NameInternal_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.FirebaseApp_NameInternal_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x17000008")]
		public static string DefaultName
		{
			[Token(Token = "0x6000060")]
			[Address(RVA = "0x15FE890", Offset = "0x15FE890", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDE800]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A19D]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.AppUtilPINVOKE>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Firebase.AppUtilPINVOKE::FirebaseApp_DefaultName_get();\n\tv51 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_002A;\n\treturn v49;\nL_002A:\n\tv59 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.FirebaseApp_DefaultName_get();
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x15FDF88", Offset = "0x15FDF88", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.swigCMemOwn = cMemoryOwn;\n\tv21 = 0;\n\tv26 = 0xCE3718(&v21 @ stack_-40_v1 (System.Runtime.InteropServices.HandleRef), this, cPtr, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.swigCPtr = 0;\n\tthis.swigCPtr.m_handle = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal FirebaseApp(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			HandleRef handleRef = default(HandleRef);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
			swigCPtr = default(HandleRef);
			swigCPtr.m_handle = (IntPtr)0;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x15FDFEC", Offset = "0x15FDFEC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EACAA0]);\n\tv19 = *([v18 @ X8_v27]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202A183]) = v39;\nL_0016:\n\tv43 = new System.Object();\n\tSystem.Object::.ctor(v43);\n\tv49.disposeLock = v43;\n\tv53 = new System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::.ctor(v53);\n\tv59.nameToProxy = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>();\n\tSystem.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::.ctor(v63);\n\tv69.cPtrToProxy = v63;\n\tv70.AppUtilCallbacksInitialized = 0;\n\tv72 = new System.Object();\n\tSystem.Object::.ctor(v72);\n\tv76.AppUtilCallbacksLock = v72;\n\tv77.PreventOnAllAppsDestroyed = 0;\n\tv78.installedCerts = 0;\n\tv79.crashlyticsInitializationAttempted = 0;\n\tv80.CheckDependenciesThread = 0xFFFFFFFF;\n\tv83 = new System.Object();\n\tSystem.Object::.ctor(v83);\n\tv87.CheckDependenciesThreadLock = v83;\n\tgoto L_0064;\n\tv94 = *([v90 @ X0_v12 (Il2CppClass<Firebase.LogUtil>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0064;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v90, v84, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\tFirebase.LogUtil::InitializeLogging();\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FirebaseApp()
		{
			object obj = new object();
			disposeLock = obj;
			Dictionary<string, FirebaseApp> dictionary = new Dictionary<string, FirebaseApp>();
			nameToProxy = dictionary;
			Dictionary<IntPtr, FirebaseApp> dictionary2 = new Dictionary<IntPtr, FirebaseApp>();
			cPtrToProxy = dictionary2;
			AppUtilCallbacksInitialized = false;
			object appUtilCallbacksLock = new object();
			AppUtilCallbacksLock = appUtilCallbacksLock;
			PreventOnAllAppsDestroyed = false;
			installedCerts = false;
			crashlyticsInitializationAttempted = false;
			CheckDependenciesThread = -1;
			object checkDependenciesThreadLock = new object();
			CheckDependenciesThreadLock = checkDependenciesThreadLock;
			LogUtil.InitializeLogging();
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15FE214", Offset = "0x15FE214", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBFA50]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A184]) = v38;\nL_0013:\n\tv39 = obj == 0;\n\tif (v39) goto L_001C;\n\treturnVal1 = obj.swigCPtr;\n\tgoto L_0026;\nL_001C:\n\tv43 = 0;\n\tv48 = 0xCE3718(&v43 @ stack_-30_v2 (System.Runtime.InteropServices.HandleRef), 0, 0, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static HandleRef getCPtr(FirebaseApp obj)
		{
			if (obj != null)
			{
				return obj.swigCPtr;
			}
			HandleRef handleRef = default(HandleRef);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
			return default(HandleRef);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x15FE284", Offset = "0x15FE284", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFirebase.FirebaseApp::Dispose(this);\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_002B;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002C;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 41 ShiftStack 32\n\treturn;\nL_002B:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_002C:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~FirebaseApp()
		{
			Dispose();
			base.Finalize();
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15FE2F0", Offset = "0x15FE2F0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF74D0]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A185]) = v40;\nL_0015:\n\tv42 = this.AppDisposed == 0;\n\tif (v42) goto L_0032;\n\tgoto L_0029;\n\tv68 = *([v45 @ X0_v4 (Il2CppClass<System.EventArgs>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0029;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv72 = System.EventArgs;\nL_0029:\n\tSystem.EventHandler::Invoke(this.AppDisposed, this, v61.Empty);\n\tthis.AppDisposed = 0;\nL_0032:\n\tFirebase.FirebaseApp::RemoveReference(this);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (AppDisposed != null)
			{
				AppDisposed(this, EventArgs.Empty);
				AppDisposed = null;
			}
			RemoveReference();
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x15FE5EC", Offset = "0x15FE5EC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE4A10]);\n\tv19 = *([v18 @ X8_v27]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A186]) = v38;\nL_0013:\n\tv39 = closureToExecute == 0;\n\tif (v39) goto L_001F;\n\tSystem.Action::Invoke(closureToExecute);\n\treturn;\nL_001F:\n\tv43 = new System.NullReferenceException();\n\tv58 = v102 != 1;\n\tif (v58) goto L_0093;\n\tv115 = 0x6D2BC0(v43, v102, v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv141 = *([v115 @ X0_v9]);\n\tv145 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v141 @ X19_v4]), v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv146 = v145 & 1;\n\tv147 = v146 == 0;\n\tif (v147) goto L_003F;\n\tv148 = 0x6D2490(v145, *([v141 @ X19_v4]), v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv155 = v141 == 0;\n\tv152 = ~v155;\n\tif (v152) goto L_0046;\n\tthrow System.NullReferenceException;\nL_003F:\n\tv154 = 0x6D1E60(8, *([v141 @ X19_v4]), v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v154 @ X0_v29]) = *([v115 @ X0_v9]);\n\tv158 = 0x1E8A000 + 0x870;\n\tv160 = 0x6D2A00(v154, v158, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tv167 = *([v141 @ X19_v4]);\n\t*([v167 @ X8_v7+190])(v171, v141, *([v167 @ X8_v7+198]), v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv172 = v171 == 0;\n\tif (v172) goto L_008F;\n\tgoto L_FFFFFFFF;\n\tv193 = v193_asT == 0;\n\tif (v193) goto L_008F;\n\tgoto L_0079;\n\tv224 = *([v220 @ X0_v19 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_0079;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v220, v170, v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0079:\n\tv230 = Firebase.ErrorMessages::get_DllNotFoundExceptionErrorMessage();\n\tv235 = new Firebase.InitializationException();\n\tFirebase.InitializationException::.ctor(v235, 1, v230);\n\tthrow v235;\nL_008F:\n\tv214 = new System.TypeLoadException();\n\tv132 = 0x6D2490(v214, 0, Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0093:\n\tv138 = 0x6D2380(v108, 0, v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv104 = 0x846AA4(v138, 0, v162, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void TranslateDllNotFoundException(Action closureToExecute)
		{
			//IL_00f5: Expected I, but got O
			if (closureToExecute != null)
			{
				closureToExecute();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				IntPtr intPtr2;
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					if (obj == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj4 = obj2;
					int num = 32022528 + 2160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					intPtr2 = (IntPtr)null;
				}
				object obj5 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v167 @ X8_v7+190] (should have been resolved before IL gen)");
				object obj6 = default(object);
				if (obj6 != null)
				{
					DllNotFoundException ex3 = obj6 as DllNotFoundException;
					if (ex3 != null)
					{
						string dllNotFoundExceptionErrorMessage = ErrorMessages.DllNotFoundExceptionErrorMessage;
						InitializationException ex4 = new InitializationException(InitResult.FailedMissingDependency, dllNotFoundExceptionErrorMessage);
						throw ex4;
					}
				}
				TypeLoadException ex5 = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				intPtr2 = (IntPtr)0;
				ex2 = (NullReferenceException)(object)ex5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15FE918", Offset = "0x15FE918", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EAD4F0]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A188]) = v42;\nL_001C:\n\tgoto L_0022;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0022:\n\tFirebase.FirebaseApp::ThrowIfCheckDependenciesRunning();\n\tSystem.Threading.Monitor::Enter(v60.nameToProxy);\n\tgoto L_003E;\n\tv67 = *([v63 @ X0_v5 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\t// 50 ConditionalJump @b35, v69 @ TEMP_v26\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v63, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv71 = Firebase.FirebaseApp;\nL_003E:\n\tv84 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::TryGetValue(v74.nameToProxy, name, &v82 @ stack_-38_v5 (Firebase.FirebaseApp));\n\tv91 = v82 == 0;\n\tv97 = v84 & v91;\n\tv99 = v97 == 0;\n\tif (v99) goto L_0065;\n\tgoto L_005B;\n\tv145 = *([v128 @ X0_v23 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_005B;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v128, v83, v81, v80, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv149 = Firebase.FirebaseApp;\nL_005B:\n\tv124 = v126.nameToProxy == 0;\n\tif (v124) goto L_0070;\n\tv139 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::Remove(v126.nameToProxy, name);\nL_0065:\n\tSystem.Threading.Monitor::Exit(v60.nameToProxy);\nL_006E:\n\treturn v171;\n\tv85 = new System.NullReferenceException();\nL_0070:\n\tv127 = new System.NullReferenceException();\n\tgoto L_007C;\n\tgoto L_007C;\nL_007C:\n\tv154 = 0 != 1;\n\tif (v154) goto L_008B;\n\tv223 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::TryGetValue(v127, 0, v209);\n\tv228 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::TryGetValue(v223, 0, v209);\n\tSystem.Threading.Monitor::Exit(v60.nameToProxy);\n\tv181 = ~v223.m_value;\n\tif (v181) goto L_006E;\n\tv227 = new System.TypeLoadException();\nL_008B:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::TryGetValue(v226, v212, 0);\n\treturn returnVal2;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FirebaseApp GetInstance(string name)
		{
			//IL_0158: Expected O, but got I4
			//IL_00f5: Expected O, but got I4
			ThrowIfCheckDependenciesRunning();
			Monitor.Enter(nameToProxy);
			bool flag = nameToProxy.TryGetValue(name, out var value);
			bool flag2 = value == null;
			bool flag3 = flag && flag2;
			bool flag4 = !flag3;
			FirebaseApp result = value;
			if (!flag4)
			{
				bool flag5 = nameToProxy == null;
				string key = null;
				if (flag5)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag6 = 0 != 1;
					Dictionary<string, FirebaseApp> dictionary = (Dictionary<string, FirebaseApp>)(object)ex;
					if (!flag6)
					{
						ref FirebaseApp value2 = default(ref FirebaseApp);
						bool flag7 = ((Dictionary<string, FirebaseApp>)(object)ex).TryGetValue((string)null, out value2);
						bool flag8 = ((Dictionary<string, FirebaseApp>)flag7).TryGetValue(null, out value2);
						Monitor.Exit(nameToProxy);
						bool flag9 = !((bool*)(flag7 ? 1 : 0))->m_value;
						result = null;
						if (flag9)
						{
							goto IL_0099;
						}
						TypeLoadException ex2 = new TypeLoadException();
						key = null;
						dictionary = (Dictionary<string, FirebaseApp>)(object)ex2;
					}
					return (FirebaseApp)dictionary.TryGetValue(key, out *(FirebaseApp*)null);
				}
				bool flag10 = nameToProxy.Remove(name);
				result = value;
			}
			Monitor.Exit(nameToProxy);
			goto IL_0099;
			IL_0099:
			return result;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15FEA9C", Offset = "0x15FEA9C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv16 = *([1EA9B98]);\n\tv17 = *([v16 @ X8_v23]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A189]) = v37;\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.FirebaseApp;\nL_0021:\n\tv53 = v51.<>f__am$cache0 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0040;\n\tv59 = new Firebase.FirebaseApp+CreateDelegate();\n\tv76 = Il2CppMethodInfo;\n\tv59.m_target = 0;\n\tv59.method = Il2CppMethodInfo;\n\tv59.method_ptr = *([v76 @ X8_v16 (Il2CppMethodInfo)]);\n\tgoto L_003C;\n\tv91 = *([v77 @ X0_v14 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_003C;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v77, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv94 = Firebase.FirebaseApp;\nL_003C:\n\tv68.<>f__am$cache0 = v59;\nL_0040:\n\tgoto L_0049;\n\tv81 = *([v63 @ X0_v4 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tgoto L_0049;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v63, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv85 = Firebase.FirebaseApp;\nL_0049:\n\tv90 = Firebase.FirebaseApp::get_DefaultName();\n\tv97 = Firebase.FirebaseApp::GetInstance(v90);\n\treturnVal1 = Firebase.FirebaseApp::CreateAndTrack(v88.<>f__am$cache0, v97);\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FirebaseApp Create()
		{
			if (_003C_003Ef__am_0024cache0 == null)
			{
				CreateDelegate createDelegate = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)createDelegate).m_target = null;
				((Delegate)createDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<FirebaseApp>*/)(&_003CCreate_003Em__0);
				((Delegate)createDelegate).method_ptr = method_ptr;
				_003C_003Ef__am_0024cache0 = createDelegate;
			}
			string defaultName = DefaultName;
			FirebaseApp instance = GetInstance(defaultName);
			return CreateAndTrack(_003C_003Ef__am_0024cache0, instance);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x15FF7B0", Offset = "0x15FF7B0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECCE68]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A18B]) = v40;\nL_001A:\n\tgoto L_0020;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tFirebase.FirebaseApp::ThrowIfCheckDependenciesRunning();\n\tSystem.Threading.Monitor::Enter(v56.nameToProxy);\n\tthis.swigCMemOwn = 1;\n\tgoto L_003D;\n\tv64 = *([v60 @ X0_v5 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\t// 49 ConditionalJump @b32, v66 @ TEMP_v18\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, v55, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv68 = Firebase.FirebaseApp;\nL_003D:\n\tSystem.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::set_Item(v71.nameToProxy, this.name, this);\n\tv84 = v82.cPtrToProxy == 0;\n\tif (v84) goto L_0054;\n\tSystem.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::set_Item(v82.cPtrToProxy, this.swigCPtr.m_handle, this);\n\tSystem.Threading.Monitor::Exit(v56.nameToProxy);\n\treturn;\n\tv80 = new System.NullReferenceException();\nL_0054:\n\tv91 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv113 = 0 != 1;\n\tif (v113) goto L_0072;\n\tv114 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::set_Item(v91, 0, v85);\n\tv159 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::set_Item(v114, 0, v85);\n\tSystem.Threading.Monitor::Exit(v56.nameToProxy);\n\tv163 = *([v114 @ X0_v14 (System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>)]) == 0;\n\tv148 = ~v163;\n\tif (v148) goto L_0076;\n\treturn;\nL_0072:\n\tv115 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::set_Item(v91, 0, v85);\nL_0076:\n\tthrow System.TypeLoadException;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddReference()
		{
			ThrowIfCheckDependenciesRunning();
			Monitor.Enter(nameToProxy);
			swigCMemOwn = true;
			nameToProxy.set_Item(Name, this);
			if (cPtrToProxy != null)
			{
				cPtrToProxy.set_Item(swigCPtr.m_handle, this);
				Monitor.Exit(nameToProxy);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			FirebaseApp value = default(FirebaseApp);
			if (0 == 1)
			{
				((Dictionary<string, FirebaseApp>)(object)ex).set_Item((string)null, value);
				Dictionary<string, FirebaseApp> dictionary = default(Dictionary<string, FirebaseApp>);
				dictionary.set_Item((string)null, value);
				Monitor.Exit(nameToProxy);
				if (dictionary == null)
				{
					return;
				}
			}
			else
			{
				((Dictionary<string, FirebaseApp>)(object)ex).set_Item((string)null, value);
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15FE384", Offset = "0x15FE384", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EEA1B8]);\n\tv29 = *([v28 @ X8_v41]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202A18C]) = v48;\nL_001E:\n\tgoto L_0024;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0024:\n\tFirebase.FirebaseApp::ThrowIfCheckDependenciesRunning();\n\tSystem.Threading.Monitor::Enter(v64.nameToProxy);\n\tv71 = System.IntPtr::op_Inequality(this.swigCPtr.m_handle, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_009D;\n\tgoto L_0041;\n\tv81 = *([v76 @ X0_v12+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0041;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v76, v69, v70, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0041:\n\tSystem.GC::SuppressFinalize(this);\n\tv121 = this + 0x20;\n\tv133 = ~this.swigCMemOwn;\n\tif (v133) goto L_009E;\n\tgoto L_0059;\n\tv210 = *([v155 @ X0_v15 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\t// 79 ConditionalJump @b61, v212 @ TEMP_v40\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v155, v89, v70, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv214 = Firebase.FirebaseApp;\nL_0059:\n\tv255 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::get_Count(v217.nameToProxy);\n\tv272 = System.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::Remove(v258.cPtrToProxy, this.swigCPtr.m_handle);\n\tv300 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::Remove(v281.nameToProxy, this.name);\n\tFirebase.FirebaseApp::ReleaseReferenceInternal(this);\n\tv92 = v255 < 1;\n\tif (v92) goto L_009E;\n\tgoto L_008A;\n\tv314 = *([v309 @ X0_v38 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_008A;\n\tv321 = \"il2cpp_codegen_runtime_class_init\"(v309, v126, v124, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv318 = Firebase.FirebaseApp;\nL_008A:\n\tv297 = v140.nameToProxy == 0;\n\tif (v297) goto L_00BB;\n\tv130 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::get_Count(v140.nameToProxy);\n\tv322 = v130 == 0;\n\tv135 = ~v322;\n\tif (v135) goto L_009E;\n\tgoto L_009B;\n\tv328 = *([v324 @ X0_v42 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv329 = v328 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_009B;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v324, v127, v124, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_009B:\n\tFirebase.FirebaseApp::OnAllAppsDestroyed();\n\tgoto L_009E;\nL_009D:\n\tv121 = this + 0x20;\nL_009E:\n\t*([v121 @ X24_v1]) = 0;\n\tv149 = 0xCE3718(&v145 @ stack_-60_v2 (System.Runtime.InteropServices.HandleRef), 0, 0, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tthis.swigCPtr = v145;\n\tthis.swigCPtr.m_handle = 0;\n\tSystem.Threading.Monitor::Exit(v64.nameToProxy);\nL_00B7:\n\treturn;\n\tv256 = new System.NullReferenceException();\n\tv267 = new System.NullReferenceException();\n\tv282 = new System.NullReferenceException();\nL_00BB:\n\tv298 = new System.NullReferenceException();\n\tgoto L_00CB;\n\tgoto L_00CB;\n\tgoto L_00CB;\n\tgoto L_00CB;\n\tgoto L_00CB;\n\tgoto L_00CB;\nL_00CB:\n\tv167 = v242 != 1;\n\tif (v167) goto L_00D9;\n\tv304 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::Remove(v298, v242);\n\tv313 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::Remove(v304, v242);\n\tSystem.Threading.Monitor::Exit(v64.nameToProxy);\n\tv196 = ~v304.m_value;\n\tif (v196) goto L_00B7;\n\tv308 = new System.TypeLoadException();\nL_00D9:\n\tv244 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::Remove(v307, 0);\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RemoveReference()
		{
			//IL_0149: Expected O, but got I
			//IL_0207: Expected O, but got I4
			//IL_0066: Expected O, but got I
			//IL_01a3: Expected O, but got I4
			ThrowIfCheckDependenciesRunning();
			Monitor.Enter(nameToProxy);
			object obj;
			if (swigCPtr.m_handle != (IntPtr)0)
			{
				GC.SuppressFinalize(this);
				obj = (long)(IntPtr)this + 32L;
				if (swigCMemOwn)
				{
					int count = nameToProxy.Count;
					bool flag = cPtrToProxy.Remove(swigCPtr.m_handle);
					bool flag2 = nameToProxy.Remove(Name);
					ReleaseReferenceInternal(this);
					if (count >= 1)
					{
						if (nameToProxy == null)
						{
							NullReferenceException ex = new NullReferenceException();
							string text = default(string);
							bool flag3 = (IntPtr)text != (IntPtr)1;
							Dictionary<string, FirebaseApp> dictionary = (Dictionary<string, FirebaseApp>)(object)ex;
							if (!flag3)
							{
								bool flag4 = ((Dictionary<string, FirebaseApp>)(object)ex).Remove(text);
								bool flag5 = ((Dictionary<string, FirebaseApp>)flag4).Remove(text);
								Monitor.Exit(nameToProxy);
								if (!((bool*)(flag4 ? 1 : 0))->m_value)
								{
									return;
								}
								TypeLoadException ex2 = new TypeLoadException();
								dictionary = (Dictionary<string, FirebaseApp>)(object)ex2;
							}
							bool flag6 = dictionary.Remove(null);
							return;
						}
						if (nameToProxy.Count == 0)
						{
							OnAllAppsDestroyed();
						}
					}
				}
			}
			else
			{
				obj = (long)(IntPtr)this + 32L;
			}
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
			HandleRef handleRef = default(HandleRef);
			swigCPtr = handleRef;
			swigCPtr.m_handle = (IntPtr)0;
			Monitor.Exit(nameToProxy);
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x15FFB48", Offset = "0x15FFB48", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0A7B8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A18D]) = v38;\nL_0016:\n\tv42 = System.IntPtr::op_Equality(this.swigCPtr.m_handle, 0);\n\tv44 = v42 == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0024;\n\treturn;\nL_0024:\n\tv53 = new System.NullReferenceException();\n\tSystem.NullReferenceException::.ctor(v53, \"App has been disposed\");\n\tthrow v53;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ThrowIfNull()
		{
			if (!(swigCPtr.m_handle == (IntPtr)0))
			{
				return;
			}
			NullReferenceException ex = new NullReferenceException("App has been disposed");
			throw ex;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15FFBDC", Offset = "0x15FFBDC", Length = "0x620")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv31 = *([1EEBDD0]);\n\tv32 = *([v31 @ X8_v83]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([202A18E]) = v52;\nL_001C:\n\tv54 = &v55 @ stack_-E0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\tgoto L_0030;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0030;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, v34, v35, v36, v37, v38, v39, v40, v53, v42, v43, v44, v45, v46, v47, v48);\n\tv67 = Firebase.FirebaseApp;\nL_0030:\n\tv220 = v70.AppUtilCallbacksLock;\n\tSystem.Threading.Monitor::Enter(v70.AppUtilCallbacksLock);\n\tgoto L_0040;\n\tv79 = *([v75 @ X0_v5 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_0040;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v75, v71, v35, v36, v37, v38, v39, v40, v53, v42, v43, v44, v45, v46, v47, v48);\n\tv83 = Firebase.FirebaseApp;\nL_0040:\n\tv88 = ~v86.AppUtilCallbacksInitialized;\n\tif (v88) goto L_0049;\n\tgoto L_01CD;\nL_0049:\n\tv96 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v96);\n\tv190 = v96 == 0;\n\tif (v190) goto L_0162;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Analytics.FirebaseAnalytics, Firebase.Analytics\", \"analytics\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Auth.FirebaseAuth, Firebase.Auth\", \"auth\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Crashlytics.FirebaseCrashlytics, Firebase.Crashlytics\", \"crashlytics\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Database.FirebaseDatabase, Firebase.Database\", \"database\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.DynamicLinks.DynamicLinks, Firebase.DynamicLinks\", \"dynamic_links\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Functions.FirebaseFunctions, Firebase.Functions\", \"functions\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.InstanceId.FirebaseInstanceId, Firebase.InstanceId\", \"instance_id\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Invites.FirebaseInvites, Firebase.Invites\", \"invites\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Messaging.FirebaseMessaging, Firebase.Messaging\", \"messaging\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Performance.FirebasePerformance, Firebase.Performance\", \"performance\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.RemoteConfig.FirebaseRemoteConfig, Firebase.RemoteConfig\", \"remote_config\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"Firebase.Storage.FirebaseStorage, Firebase.Storage\", \"storage\");\n\tv591 = Firebase.Platform.PlatformInformation::get_IsAndroid();\n\t*([v21 @ X29-B0]) = v70.AppUtilCallbacksLock;\n\tv605 = v591 == 0;\n\tif (v605) goto L_00C9;\n\tgoto L_00D0;\nL_00C9:\n\tFirebase.AppUtil::SetEnabledAllAppCallbacks(0);\nL_00D0:\n\tv630 = System.Collections.Generic.Dictionary`2<System.String, System.String>::GetEnumerator(v96);\n\tv639 = 0x1845000 + 0x500;\n\t*([v21 @ X29-60]) = *([v21 @ X29-88]);\n\t*([v21 @ X29-80]) = *([v21 @ X29-A8]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-98]);\n\tgoto L_0153;\nL_00E8:\n\tgoto L_00F0;\n\tv675 = *([v670 @ X0_v60+E0]);\n\tv676 = v675 == 0;\n\tv677 = ~v676;\n\tif (v677) goto L_00F0;\n\tv679 = \"il2cpp_codegen_runtime_class_init\"(v670, v565, v562, v561, v532, v38, v39, v40, v556, v555, v43, v44, v45, v46, v47, v48);\nL_00F0:\n\tv684 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(*([v21 @ X29-70]), v639, v657);\n\tv690 = System.Type::GetType(v684);\n\tv686 = v690 == 0;\n\tv687 = ~v686;\n\tif (v687) goto L_00FB;\n\tv690 = System.Type::GetType(*([v21 @ X29-70]));\nL_00FB:\n\tv695 = v690 == 0;\n\tv700 = ~v695;\nL_0103:\n\tv703 = Firebase.AppUtil::GetEnabledAppCallbackByName(*([v21 @ X29-68]));\n\tv704 = v560 | v703;\n\tv642 = v700 & v704;\n\tv705 = v703 ^ v642;\n\tv706 = v705 & 1;\n\tv707 = v706 == 0;\n\tif (v707) goto L_0134;\n\tv714 = v642 == 0;\n\tv720 = ~v714;\n\tv721 = ~v720;\n\tif (v721) goto L_FFFFFFFF;\n\tgoto L_0121;\nL_0121:\n\tv736 = System.String::Format(\"{0} module '{1}' for '{2}'\", *([v734 @ X8_v69 (System.String)]), *([v21 @ X29-68]), *([v21 @ X29-70]));\n\tgoto L_0131;\n\tv743 = *([v739 @ X0_v72+E0]);\n\tv744 = v743 == 0;\n\tv745 = ~v744;\n\tgoto L_0131;\n\tv747 = \"il2cpp_codegen_runtime_class_init\"(v739, v735, v725, v724, v722, v38, v39, v40, v556, v555, v43, v44, v45, v46, v47, v48);\nL_0131:\n\tFirebase.LogUtil::LogMessage(1, v736);\nL_0134:\n\tFirebase.AppUtil::SetEnabledAppCallbackByName(*([v21 @ X29-68]), v642);\n\tgoto L_0153;\n\tX23 = X20;\n\tX20 = X1;\n\tC = X20 < 1;\n\tC = ~C;\n\tTEMP1 = X20 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ 1;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_018A;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([X20]);\n\tX9 = *([1EDD7C0]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0163;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X23;\n\tX23 = 0;\n\tgoto L_0103;\nL_0153:\n\tv666 = &v21 @ X29 - 0x80;\n\tv568 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::MoveNext(v666);\n\tv668 = v568 == 0;\n\tv570 = ~v668;\n\tif (v570) goto L_00E8;\n\t*([v54 @ X24_v1]) = 0x1C3;\n\tv220 = *([v21 @ X29-B0]);\n\tgoto L_019F;\nL_0162:\n\tthrow System.NullReferenceException;\nL_0163:\n\t;\n\tv413 = *([v96 @ X0_v16 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\t*([v399 @ X0_v34 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]) = v413;\n\tv415 = 0x1E8A000 + 0x870;\n\tv417 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v399, v415, 0, v36);\n\tgoto L_016E;\nL_016E:\n\tv436 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v417, v415, 0, v36);\n\tv447 = *([v24 @ X29_v1-B0]);\n\tgoto L_0196;\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X29-B0]);\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0189;\n\tgoto L_0189;\n\tgoto L_0189;\n\tgoto L_0189;\nL_0189:\n\tX20 = X1;\nL_018A:\n\tX22 = 0x1EAC000;\n\tX21 = *([X29-B0]);\n\tX22 = *([1EAC2C8]);\nL_0196:\n\tv466 = v415 != 1;\n\tif (v466) goto L_01FB;\n\tv475 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v417, v415, 0, v36);\n\tv511 = *([v475 @ X0_v38 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\tv512 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v475, v415, 0, v36);\nL_019F:\n\tv576 = &v21 @ X29 - 0x80;\n\tv577 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::Dispose(v576);\n\tv585 = 0 + 1;\n\tv587 = v585 == 0;\n\tif (v587) goto L_01B5;\n\tv602 = *([v54 @ X24_v1+v609 @ X19_v11 (System.Int32)*4]) != 0x1C3;\n\tif (v602) goto L_01B5;\n\tgoto L_01B8;\nL_01B5:\n\tv603 = v162 == 0;\n\tv499 = ~v603;\n\tif (v499) goto L_01EF;\nL_01B8:\n\tv165 = *([v140 @ X22_v7 (Il2CppClass<Firebase.FirebaseApp>)]);\n\tgoto L_01C3;\n\tv617 = *([v610 @ X0_v25+E0]);\n\tv618 = v617 == 0;\n\tv619 = ~v618;\n\tif (v619) goto L_01C3;\n\tv631 = \"il2cpp_codegen_runtime_class_init\"(v610, v161, v156, v154, v104, v38, v39, v40, v144, v142, v43, v44, v45, v46, v47, v48);\n\tv620 = *([v140 @ X22_v7 (Il2CppClass<Firebase.FirebaseApp>)]);\nL_01C3:\n\t\n// ... truncated")]
		private unsafe static void InitializeAppUtilCallbacks()
		{
			//IL_0012: Expected I, but got O
			//IL_04c0: Expected O, but got I4
			//IL_050a: Expected O, but got I4
			//IL_02d5: Expected O, but got I
			//IL_01c6: Expected O, but got I
			//IL_0313: Expected O, but got I4
			//IL_0323: Expected O, but got I
			//IL_0331: Expected I, but got O
			//IL_0336: Expected I, but got O
			//IL_05e5: Expected O, but got I
			//IL_0580: Expected O, but got I
			//IL_0211: Expected O, but got I
			//IL_02c1: Expected O, but got I
			//IL_03b0: Expected O, but got I
			//IL_062a: Expected O, but got I
			//IL_065a: Expected O, but got I
			//IL_0566: Expected O, but got I
			//IL_0566: Expected O, but got I
			//IL_02a7: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			object obj4 = AppUtilCallbacksLock;
			Monitor.Enter(AppUtilCallbacksLock);
			IntPtr intPtr;
			int num;
			object obj5;
			if (AppUtilCallbacksInitialized)
			{
				intPtr = (IntPtr)null;
				obj5 = obj3;
				num = 0;
				goto IL_04b7;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			IntPtr intPtr3;
			int num6;
			TypeLoadException ex;
			string value2;
			string key2;
			if (dictionary != null)
			{
				dictionary.Add("Firebase.Analytics.FirebaseAnalytics, Firebase.Analytics", "analytics");
				dictionary.Add("Firebase.Auth.FirebaseAuth, Firebase.Auth", "auth");
				dictionary.Add("Firebase.Crashlytics.FirebaseCrashlytics, Firebase.Crashlytics", "crashlytics");
				dictionary.Add("Firebase.Database.FirebaseDatabase, Firebase.Database", "database");
				dictionary.Add("Firebase.DynamicLinks.DynamicLinks, Firebase.DynamicLinks", "dynamic_links");
				dictionary.Add("Firebase.Functions.FirebaseFunctions, Firebase.Functions", "functions");
				dictionary.Add("Firebase.InstanceId.FirebaseInstanceId, Firebase.InstanceId", "instance_id");
				dictionary.Add("Firebase.Invites.FirebaseInvites, Firebase.Invites", "invites");
				dictionary.Add("Firebase.Messaging.FirebaseMessaging, Firebase.Messaging", "messaging");
				dictionary.Add("Firebase.Performance.FirebasePerformance, Firebase.Performance", "performance");
				dictionary.Add("Firebase.RemoteConfig.FirebaseRemoteConfig, Firebase.RemoteConfig", "remote_config");
				dictionary.Add("Firebase.Storage.FirebaseStorage, Firebase.Storage", "storage");
				bool isAndroid = PlatformInformation.IsAndroid;
				_ = AppUtilCallbacksLock;
				int num2;
				if (isAndroid)
				{
					num2 = 0;
				}
				else
				{
					AppUtil.SetEnabledAllAppCallbacks(arg0: false);
					num2 = 1;
				}
				Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator();
				string key = (string)(25448448 + 1280);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
				_ = 0;
				string value = "storage";
				string typeName = default(string);
				while (true)
				{
					Dictionary<string, string>.Enumerator enumerator2 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 128L);
					if (((Dictionary<string, string>.Enumerator*)enumerator2)->MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
						((Dictionary<string, string>)0).Add(key, value);
						Type type = Type.GetType(typeName);
						if ((object)type == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
							type = Type.GetType((string)0);
						}
						bool flag = (object)type == null;
						bool flag2 = !flag;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
						bool enabledAppCallbackByName = AppUtil.GetEnabledAppCallbackByName((string)0);
						int num3 = num2 | (enabledAppCallbackByName ? 1 : 0);
						int num4 = (flag2 ? 1 : 0) & num3;
						int num5 = (enabledAppCallbackByName ? 1 : 0) ^ num4;
						if ((num5 & 1) != 0)
						{
							string arg = ((num4 == 0) ? "Disable" : "Enable");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
							IntPtr intPtr2 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
							string message = $"{arg} module '{(long)intPtr2}' for '{0}'";
							LogUtil.LogMessage(LogLevel.Debug, message);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
							value = (string)0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
						AppUtil.SetEnabledAppCallbackByName((string)0, (byte)num4 != 0);
						continue;
					}
					break;
				}
				obj2 = 451;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
				obj4 = 0;
				intPtr3 = (IntPtr)typeof(FirebaseApp);
				intPtr = (IntPtr)null;
				num6 = 0;
				Dictionary<string, string>.Enumerator enumerator3 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 128L);
				((Dictionary<string, string>.Enumerator*)enumerator3)->Dispose();
				if (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v609 @ X19_v11 (System.Int32)*4]");
					if ((IntPtr)0 == (IntPtr)451)
					{
						num6 = -1;
						goto IL_03a8;
					}
				}
				if (intPtr == (IntPtr)0)
				{
					goto IL_03a8;
				}
				ex = new TypeLoadException();
				value2 = null;
				key2 = null;
				if (0 == 1)
				{
					((Dictionary<string, string>)(object)ex).Add((string)null, (string)null);
					Dictionary<string, string> dictionary2 = default(Dictionary<string, string>);
					dictionary2.Add(null, null);
					Monitor.Exit(obj4);
					if (dictionary2 == null)
					{
						return;
					}
					goto IL_043c;
				}
				goto IL_0454;
			}
			throw new NullReferenceException();
			IL_043c:
			ex = new TypeLoadException();
			value2 = null;
			key2 = null;
			goto IL_0454;
			IL_0454:
			((Dictionary<string, string>)(object)ex).Add(key2, value2);
			return;
			IL_03a8:
			object obj6 = (long)intPtr3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X0_v26+B8]");
			object obj7 = 0;
			num = num6 + 1;
			_ = 1;
			int num7 = num << 2;
			obj5 = (long)(IntPtr)obj3 + (long)num7;
			goto IL_04b7;
			IL_04b7:
			obj5 = 469;
			Monitor.Exit(obj4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v170 @ X19_v4 (System.Int32)*4]");
			if ((IntPtr)0 == (IntPtr)469 || intPtr == (IntPtr)0)
			{
				return;
			}
			goto IL_043c;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x15FF9C0", Offset = "0x15FF9C0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF2D50]);\n\tv17 = *([v16 @ X8_v29]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A18F]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.FirebaseApp;\nL_0021:\n\tv53 = ~v51.PreventOnAllAppsDestroyed;\n\tv54 = ~v53;\n\tif (v54) goto L_0048;\n\tgoto L_0030;\n\tv115 = *([v47 @ X0_v3 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0030;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v47, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv157 = Firebase.FirebaseApp;\n\tv121 = *([v157 @ X8_v24+B8]);\nL_0030:\n\tv106 = v110.nameToProxy == 0;\n\tif (v106) goto L_0086;\n\tv103 = System.Collections.Generic.Dictionary`2<System.String, Firebase.FirebaseApp>::get_Count(v110.nameToProxy);\n\tv62 = v103 <= 0;\n\tif (v62) goto L_004D;\nL_0048:\n\treturn;\nL_004D:\n\tgoto L_0058;\n\tv171 = *([v162 @ X0_v16 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0058;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v162, v98, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv175 = Firebase.FirebaseApp;\nL_0058:\n\tSystem.Threading.Monitor::Enter(v178.AppUtilCallbacksLock);\n\tgoto L_0066;\n\tv188 = *([v184 @ X0_v19 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tgoto L_0066;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v184, v179, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv192 = Firebase.FirebaseApp;\nL_0066:\n\tv197 = ~v195.AppUtilCallbacksInitialized;\n\tif (v197) goto L_0084;\n\tv200 = Firebase.Platform.PlatformInformation::get_IsAndroid();\n\tv207 = v200 == 0;\n\tv208 = ~v207;\n\tif (v208) goto L_0074;\n\tFirebase.AppUtil::SetEnabledAllAppCallbacks(0);\nL_0074:\n\tgoto L_007C;\n\tv215 = *([v211 @ X0_v26 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tif (v217) goto L_007C;\n\tv220 = \"il2cpp_codegen_runtime_class_init\"(v211, v179, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv218 = Firebase.FirebaseApp;\nL_007C:\n\tv204.AppUtilCallbacksInitialized = 0;\nL_0084:\n\tSystem.Threading.Monitor::Exit(v178.AppUtilCallbacksLock);\n\treturn;\nL_0086:\n\tv156 = new System.NullReferenceException();\n\tv63 = v141 != 1;\n\tif (v63) goto L_009E;\n\tv166 = 0x6D2BC0(v156, v141, v124, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv182 = 0x6D2490(v166, v141, v124, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tSystem.Threading.Monitor::Exit(0x202A000);\n\tv107 = *([v166 @ X0_v10]) == 0;\n\tif (v107) goto L_0048;\n\tv170 = new System.TypeLoadException();\nL_009E:\n\tv145 = 0x6D2380(v156, 0, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnAllAppsDestroyed()
		{
			//IL_00cf: Expected O, but got I4
			if (PreventOnAllAppsDestroyed)
			{
				return;
			}
			if (nameToProxy != null)
			{
				int count = nameToProxy.Count;
				if (count > 0)
				{
					return;
				}
				Monitor.Enter(AppUtilCallbacksLock);
				if (AppUtilCallbacksInitialized)
				{
					if (!PlatformInformation.IsAndroid)
					{
						AppUtil.SetEnabledAllAppCallbacks(arg0: false);
					}
					AppUtilCallbacksInitialized = false;
				}
				Monitor.Exit(AppUtilCallbacksLock);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			int num = default(int);
			if (num == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Monitor.Exit(33726464);
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				ex = (NullReferenceException)(object)ex2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x15FAE00", Offset = "0x15FAE00", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE0018]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A190]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(urlString);\n\tv44 = v41 == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_002A;\n\tv49 = new System.Uri();\n\tSystem.Uri::.ctor(v49, urlString);\nL_002A:\n\treturn v57;\n\tgoto L_002C;\nL_002C:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0051;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX8 = *([X19]);\n\tX9 = *([1F0D740]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0047;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = 0;\n\tgoto L_002A;\nL_0047:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Uri UrlStringToUri(string urlString)
		{
			bool flag = string.IsNullOrEmpty(urlString);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Uri result = null;
			if (!flag3)
			{
				Uri uri = new Uri(urlString);
				result = uri;
			}
			return result;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x160029C", Offset = "0x160029C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED9568]);\n\tv17 = *([v16 @ X8_v37]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A191]) = v37;\nL_0016:\n\tv42 = System.Reflection.Assembly::Load(\"Firebase.Crashlytics\");\n\tv50 = System.Reflection.Assembly::GetType(v42, \"Firebase.Crashlytics.Crashlytics\");\n\tv51 = v50 == 0;\n\tif (v51) goto L_0039;\n\tv58 = System.Type::GetMethod(v50, \"Initialize\", 0x28);\n\tv70 = v58 == 0;\n\tif (v70) goto L_004A;\n\tv80 = System.Reflection.MethodBase::Invoke(v58, 0, 0);\nL_0034:\n\treturn 1;\n\tthrow System.NullReferenceException;\nL_0039:\n\tv69 = new Firebase.InitializationException();\n\tFirebase.InitializationException::.ctor(v69, 1, \"Crashlytics initialization failed. Could not find Crashlytics class.\");\n\tthrow v69;\nL_004A:\n\tv96 = new Firebase.InitializationException();\n\tFirebase.InitializationException::.ctor(v96, 1, \"Crashlytics initialization failed. Could not find Crashlytics initializer.\");\n\tthrow v96;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_009E;\n\tv190 = 0x6D2BC0(v157, 0, Il2CppMethodInfo, v81, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv148 = *([v190 @ X0_v16 (Firebase.InitializationException)]);\n\tv137 = *([v148 @ X19_v8 (System.Exception)]);\n\tv205 = \"il2cpp_vm_class_is_assignable_from\"(System.IO.FileNotFoundException, v137, Il2CppMethodInfo, v81, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv206 = v205 & 1;\n\tv144 = v206 == 0;\n\tif (v144) goto L_0079;\n\tv207 = 0x6D2490(v205, v137, Il2CppMethodInfo, v81, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0034;\nL_0079:\n\tv209 = *([v190 @ X0_v16 (Firebase.InitializationException)]);\n\tv210 = *([v209 @ X8_v16 (Il2CppClass<Firebase.InitializationException>)]);\n\tv212 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v210, Il2CppMethodInfo, v81, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv213 = v212 & 1;\n\tv198 = v213 == 0;\n\tif (v198) goto L_0094;\n\tv214 = 0x6D2490(v212, v210, Il2CppMethodInfo, v81, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv230 = new Firebase.InitializationException();\n\tFirebase.InitializationException::.ctor(v230, 1, \"Crashlytics initialization failed with an unexpected error.\", v148, v22);\n\tthrow v230;\nL_0094:\n\tv226 = 0x6D1E60(8, v217, v219, v192, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv199 = *([v191 @ X20_v5 (Firebase.InitializationException)]);\n\t*([v226 @ X0_v23]) = v199;\n\tv193 = 0x1E8A000 + 0x870;\n\tv232 = 0x6D2A00(v226, v193, 0, v192, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv197 = 0x6D2490(v232, v193, 0, v192, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_009E:\n\tv202 = 0x6D2380(v185, v173, v175, v171, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal2 = 0x846AA4(v202, v173, v175, v171, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn returnVal2;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool InitializeCrashlyticsIfPresent()
		{
			Assembly assembly = Assembly.Load("Firebase.Crashlytics");
			Type type = assembly.GetType("Firebase.Crashlytics.Crashlytics");
			if ((object)type != null)
			{
				MethodInfo method = type.GetMethod("Initialize", BindingFlags.Static | BindingFlags.NonPublic);
				if ((object)method != null)
				{
					object obj = method.Invoke(null, null);
					return true;
				}
				InitializationException ex = new InitializationException(InitResult.FailedMissingDependency, "Crashlytics initialization failed. Could not find Crashlytics initializer.");
				throw ex;
			}
			InitializationException ex2 = new InitializationException(InitResult.FailedMissingDependency, "Crashlytics initialization failed. Could not find Crashlytics class.");
			throw ex2;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x15FED20", Offset = "0x15FED20", Length = "0xA2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EA55A8]);\n\tv31 = *([v30 @ X8_v137]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202A192]) = v49;\nL_001B:\n\tv52 = 0;\n\tgoto L_0028;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0028;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0028:\n\tFirebase.FirebaseApp::ThrowIfCheckDependenciesRunning();\n\tgoto L_0039;\n\tv72 = *([v68 @ X0_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0039;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0039:\n\tgoto L_0044;\n\tv84 = *([1EB0F30]);\n\tv85 = *([v84 @ X8_v132]);\n\tv86 = \"il2cpp_codegen_initialize_method\"(v85, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv89 = 0 | 1;\n\t*([202A1B3]) = v89;\nL_0044:\n\tgoto L_0053;\n\tv94 = *([v90 @ X0_v7 (Il2CppClass<Firebase.Platform.FirebaseAppUtils>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tgoto L_0053;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v90, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv98 = Firebase.Platform.FirebaseAppUtils;\nL_0053:\n\tgoto L_005C;\n\tv110 = *([v104 @ X8_v11+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_005C;\n\tv119 = v104;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v119, existingProxy, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_005C:\n\tFirebase.Platform.FirebaseHandler::Create(v103.instance);\n\tSystem.Threading.Monitor::Enter(v122.nameToProxy);\n\tgoto L_0071;\n\tv129 = *([v125 @ X0_v12 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0071;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v125, v121, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0071:\n\tFirebase.FirebaseApp::InitializeAppUtilCallbacks();\n\tv148 = System.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::TryGetValue(&v52 @ stack_-60_v1, 0, 0);\n\tv151 = Firebase.Platform.PlatformInformation::get_DefaultConfigLocation();\n\tgoto L_0088;\n\tv157 = *([v153 @ X0_v18+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0088;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v153, v144, v145, v146, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0088:\n\tFirebase.FirebaseApp::AppSetDefaultConfigPath(v151);\n\tv167 = Firebase.FirebaseApp+CreateDelegate::Invoke(createDelegate);\n\tv171 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv178 = v171 == 0;\n\tv174 = ~v178;\n\tif (v174) goto L_0244;\n\tv184 = v167 == 0;\n\tif (v184) goto L_024D;\n\tgoto L_00A0;\n\tv205 = *([v195 @ X0_v75+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_00A0;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v195, v144, v145, v146, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00A0:\n\tv213 = Firebase.FirebaseApp::getCPtr(v167);\n\tv225 = System.IntPtr::op_Equality(0, 0);\n\tv244 = v225 == 0;\n\tif (v244) goto L_00B1;\n\tgoto L_01DC;\nL_00B1:\n\tgoto L_00C2;\n\tv382 = *([v269 @ X0_v83 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\t// 181 ConditionalJump @b236, v384 @ TEMP_v149\n\tv504 = \"il2cpp_codegen_runtime_class_init\"(v269, v223, v224, v146, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv387 = Firebase.FirebaseApp;\nL_00C2:\n\tv307 = System.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::TryGetValue(v240.cPtrToProxy, 0, &v246 @ stack_-48_v10 (Firebase.FirebaseApp));\n\tv544 = v246 == 0;\n\tif (v544) goto L_00F5;\n\tv305 = v307 ^ 1;\n\tv546 = v305 & 1;\n\tv547 = v546 == 0;\n\tv366 = ~v547;\n\tif (v366) goto L_00F5;\n\tv287 = v246 == existingProxy;\n\tif (v287) goto L_FFFFFFFF;\n\tv575 = System.String::Format(\"Detected multiple FirebaseApp proxies for {0}\", existingProxy.name);\n\tgoto L_00EC;\n\tv609 = *([v585 @ X0_v152+E0]);\n\tv610 = v609 == 0;\n\tv611 = ~v610;\n\tif (v611) goto L_00EC;\n\tv613 = \"il2cpp_codegen_runtime_class_init\"(v585, v572, v350, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00EC:\n\tFirebase.LogUtil::LogMessage(3, v575);\n\tFirebase.FirebaseApp::Dispose(existingProxy);\n\tgoto L_01DC;\nL_00F5:\n\tgoto L_0104;\n\tv554 = *([v549 @ X0_v87 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv555 = v554 == 0;\n\tv556 = ~v555;\n\t// 249 ConditionalJump @b237, v556 @ TEMP_v138\n\tv564 = \"il2cpp_codegen_runtime_class_init\"(v549, v256, v252, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv559 = Firebase.FirebaseApp;\nL_0104:\n\tv568 = System.Collections.Generic.Dictionary`2<System.IntPtr, Firebase.FirebaseApp>::get_Count(v265.cPtrToProxy);\n\tv576 = v568 == 0;\n\tv577 = ~v576;\n\tif (v577) goto L_013B;\n\tv591 = Firebase.Platform.PlatformInformation::get_RuntimeName();\n\tv620 = System.String::Concat(\"fire-\", v591);\n\tgoto L_0125;\n\tv634 = *([1EB0268]);\n\tv635 = *([v634 @ X8_v115]);\n\tv636 = \"il2cpp_codegen_initialize_method\"(v635, v615, v619, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv639 = 0 | 1;\n\t*([202A1B2]) = v639;\nL_0125:\n\tgoto L_012D;\n\tv656 = *([v641 @ X0_v137+E0]);\n\tv657 = v656 == 0;\n\tv658 = ~v657;\n\tgoto L_012D;\n\tv660 = \"il2cpp_codegen_runtime_class_init\"(v641, v615, v619, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_012D:\n\tFirebase.FirebaseApp::RegisterLibraryInternal(v620, \"6.9.0\");\n\tv715 = System.String::Concat(v620, \"-ver\");\n\tv754 = Firebase.Platform.PlatformInformation::get_RuntimeVersion();\n\tFirebase.FirebaseApp::RegisterLibraryInternal(v715, v754);\nL_013B:\n\tv608 = Firebase.FirebaseApp::get_NameInternal(v167);\n\tv167.name = v608;\n\tFirebase.FirebaseApp::AddReference(v167);\n\tgoto L_014C;\n\tv645 = *([v629 @ X0_v95 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv646 = v645 == 0;\n\tv647 = ~v646;\n\tif (v647) goto L_014C;\n\tv664 = \"il2cpp_codegen_runtime_class_init\"(v629, v407, v403, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv649 = Firebase.FirebaseApp;\nL_014C:\n\tv654 = ~v652.installedCerts;\n\tv655 = ~v654;\n\tif (v655) goto L_01BE;\n\tgoto L_015C;\n\tv716 = *([v648 @ X0_v96 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv717 = v716 == 0;\n\tv718 = ~v717;\n\tif (v718) goto L_015C;\n\tv723 = \"il2cpp_codegen_runtime_class_init\"(v648, v407, v403, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv794 = Firebase.FirebaseApp;\n\tv726 = *([v794 @ X8_v101+B8]);\nL_015C:\n\tv725.installedCerts = 1;\n\tgoto L_016E;\n\tv755 = *([v729 @ X0_v110+E0]);\n\tv756 = v755 == 0;\n\tv757 = ~v756;\n\tgoto L_016E;\n\tv761 = \"il2cpp_codegen_runtime_class_init\"(v729, v407, v403, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_016E:\n\tgoto L_017A;\n\tv796 = *([1EAF870]);\n\tv797 = *([v796 @ X8_v98]);\n\tv799 = \"il2cpp_codegen_initialize_method\"(v797, v407, v403, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv803 = 0 | 1;\n\t*([202A1B4]) = v803;\nL_017A:\n\tgoto L_0185;\n\tv830 = *([v804 @ X0_v113 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv831 = v830 == 0;\n\tv832 = ~v831;\n\tgoto L_0185;\n\tv852 = \"il2cpp_codegen_runtime_class_init\"(v804, v407, v403, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv835 = Firebase.Platform.Services;\nL_0185:\n\tv411 = Firebase.FirebaseApp::get_AppPlatform(v167);\n\tv413 = v419.<RootCerts>k__BackingField == 0;\n\tif (v413) goto L_0260;\n\tgoto L_01B9;\n\tv876 = *([v864 @ X8_v92+B0]);\n\tv877 = 0;\n\tv878 = v876 + 8;\n\tv880 = *([v909 @ X11_v9-8]);\n\tv923 = v880 == v867;\n\tif (v923) goto L_01B1;\n\tv886 = v910 + 1;\n\tv928 = v886 < v866;\n\tv902 = ~v928;\n\tv884 = v909 + 0x10;\n\tv882 = ~v902;\n\tif (v882) goto L_FFFFFFFF;\n\tv903 = v417;\n\tv904 = 0;\n\tv905 = 0x8909C4(v903, v867, v904, v250, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_01B9;\n\tgoto L_01DC;\nL_01B1:\n\tv929 = *([v909 @ X11_v9]);\n\tv930 = v929 << 4;\n\tv931 = v864 + v930;\n\tv932 = v931 + 0x130;\nL_01B9:\n\tv937 = Firebase.Platform.ICertificateService::Install(v419.<RootCerts>k__BackingField, v411);\nL_01BE:\n\tgoto L_01C8;\n\tv733 = *\n// ... truncated")]
		private unsafe static FirebaseApp CreateAndTrack(CreateDelegate createDelegate, FirebaseApp existingProxy)
		{
			//IL_0464: Expected O, but got I4
			//IL_022f: Expected I, but got O
			//IL_02ac: Expected I, but got O
			//IL_02b4: Expected I, but got O
			//IL_03ed: Expected O, but got I4
			object obj = 0;
			ThrowIfCheckDependenciesRunning();
			FirebaseHandler.Create(FirebaseAppUtils.instance);
			Monitor.Enter(nameToProxy);
			InitializeAppUtilCallbacks();
			bool flag = ((Dictionary<IntPtr, FirebaseApp>)obj).TryGetValue((IntPtr)0, out *(FirebaseApp*)null);
			string defaultConfigLocation = PlatformInformation.DefaultConfigLocation;
			AppSetDefaultConfigPath(defaultConfigLocation);
			FirebaseApp firebaseApp = createDelegate();
			FirebaseApp result;
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				if (firebaseApp != null)
				{
					HandleRef cPtr = getCPtr(firebaseApp);
					if ((IntPtr)0 == (IntPtr)0)
					{
						result = null;
					}
					else
					{
						bool flag2 = cPtrToProxy.TryGetValue((IntPtr)0, out var value);
						if (value != null)
						{
							int num = (flag2 ? 1 : 0) ^ 1;
							if ((num & 1) == 0)
							{
								if (value != existingProxy)
								{
									string message = $"Detected multiple FirebaseApp proxies for {existingProxy.Name}";
									LogUtil.LogMessage(LogLevel.Warning, message);
									existingProxy.Dispose();
									result = value;
								}
								else
								{
									result = value;
								}
								goto IL_0336;
							}
						}
						int count = cPtrToProxy.Count;
						bool flag3 = count == 0;
						bool flag4 = !flag3;
						IntPtr intPtr = (IntPtr)value;
						IntPtr intPtr2 = (IntPtr)__ldftn(Dictionary<IntPtr, FirebaseApp>.get_Count);
						if (!flag4)
						{
							string runtimeName = PlatformInformation.RuntimeName;
							string text = "fire-" + runtimeName;
							RegisterLibraryInternal(text, "6.9.0");
							string library = text + "-ver";
							string runtimeVersion = PlatformInformation.RuntimeVersion;
							RegisterLibraryInternal(library, runtimeVersion);
							intPtr = (IntPtr)null;
							intPtr2 = (IntPtr)runtimeVersion;
						}
						string text2 = firebaseApp.Name;
						firebaseApp.name = text2;
						firebaseApp.AddReference();
						if (!installedCerts)
						{
							installedCerts = true;
							FirebaseAppPlatform app = firebaseApp.AppPlatform;
							bool flag5 = Services.RootCerts == null;
							result = firebaseApp;
							if (flag5)
							{
								NullReferenceException ex = new NullReferenceException();
								if (intPtr2 == (IntPtr)1)
								{
									bool flag6 = ((Dictionary<IntPtr, FirebaseApp>)(object)ex).TryGetValue(intPtr2, out *(FirebaseApp*)intPtr);
									bool flag7 = ((Dictionary<IntPtr, FirebaseApp>)flag6).TryGetValue(intPtr2, out *(FirebaseApp*)intPtr);
									Monitor.Exit(nameToProxy);
									if (!((bool*)(flag6 ? 1 : 0))->m_value)
									{
										goto IL_0345;
									}
								}
								else
								{
									bool flag8 = ((Dictionary<IntPtr, FirebaseApp>)(object)ex).TryGetValue(intPtr2, out *(FirebaseApp*)intPtr);
								}
								return (FirebaseApp)(object)new TypeLoadException();
							}
							X509CertificateCollection x509CertificateCollection = Services.RootCerts.Install(app);
						}
						bool flag9 = !crashlyticsInitializationAttempted;
						bool flag10 = !flag9;
						result = firebaseApp;
						if (!flag10)
						{
							bool flag11 = IsCheckDependenciesRunning();
							bool flag12 = !flag11;
							result = firebaseApp;
							if (flag12)
							{
								crashlyticsInitializationAttempted = true;
								Monitor.Exit(nameToProxy);
								result = firebaseApp;
								if (_003C_003Ef__am_0024cache1 == null)
								{
									Func<bool> func = [Token(Token = "0x6000062")] [Address(RVA = "0x1600E2C", Offset = "0x1600E2C", Length = "0x5C")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F04B60]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A19F]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = Firebase.FirebaseApp::InitializeCrashlyticsIfPresent();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () => InitializeCrashlyticsIfPresent();
									_003C_003Ef__am_0024cache1 = func;
								}
								bool flag13 = FirebaseHandler.RunOnMainThread(_003C_003Ef__am_0024cache1);
								goto IL_0345;
							}
						}
					}
					goto IL_0336;
				}
				InitializationException ex2 = new InitializationException(InitResult.FailedMissingDependency, "App creation failed with an unknown error.");
				throw ex2;
			}
			Exception ex3 = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
			IL_0336:
			Monitor.Exit(nameToProxy);
			goto IL_0345;
			IL_0345:
			return result;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x15FEB88", Offset = "0x15FEB88", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB61C0]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202A193]) = v39;\nL_0019:\n\tgoto L_0024;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = Firebase.FirebaseApp;\nL_0024:\n\tSystem.Threading.Monitor::Enter(v53.CheckDependenciesThreadLock);\n\tgoto L_0032;\n\tv62 = *([v58 @ X0_v5 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v58, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv66 = Firebase.FirebaseApp;\nL_0032:\n\tv71 = v69.CheckDependenciesThread + 1;\n\tv73 = v71 == 0;\n\tif (v73) goto L_005D;\n\tgoto L_0045;\n\tv120 = *([v65 @ X0_v6 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0045;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v65, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv173 = Firebase.FirebaseApp;\n\tv127 = *([v173 @ X8_v19+B8]);\n\tv123 = *([v127 @ X8_v20+2C]);\nL_0045:\n\tv129 = System.Threading.Thread::get_CurrentThread();\n\tv108 = System.Threading.Thread::get_ManagedThreadId(v129);\n\tv81 = v69.CheckDependenciesThread != v108;\n\tif (v81) goto L_0063;\nL_005D:\n\tSystem.Threading.Monitor::Exit(v53.CheckDependenciesThreadLock);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0063:\n\tv190 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v190, \"Don't call Firebase functions before CheckDependencies has finished\");\n\tthrow v190;\n\tgoto L_007E;\n\tgoto L_007E;\nL_007E:\n\tif (1) goto L_008F;\n\tv202 = 0x6D2BC0(v200, 0, Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv204 = *([v202 @ X0_v22]);\n\tv205 = 0x6D2490(v202, 0, Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tSystem.Threading.Monitor::Exit(v55, 0);\n\tv209 = v204 == 0;\n\tv165 = ~v209;\n\tif (v165) goto L_0093;\n\treturn;\nL_008F:\n\tv203 = 0x6D2380(v200, 0, Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0093:\n\tthrow System.TypeLoadException;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ThrowIfCheckDependenciesRunning()
		{
			Monitor.Enter(CheckDependenciesThreadLock);
			if (CheckDependenciesThread + 1 != 0)
			{
				Thread currentThread = Thread.CurrentThread;
				int managedThreadId = currentThread.ManagedThreadId;
				if (CheckDependenciesThread != managedThreadId)
				{
					InvalidOperationException ex = new InvalidOperationException("Don't call Firebase functions before CheckDependencies has finished");
					throw ex;
				}
			}
			Monitor.Exit(CheckDependenciesThreadLock);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x1600A78", Offset = "0x1600A78", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE5AD8]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A194]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.FirebaseApp;\nL_0023:\n\tSystem.Threading.Monitor::Enter(v51.CheckDependenciesThreadLock);\n\tgoto L_0033;\n\tv60 = *([v56 @ X0_v5 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0033;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v56, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv64 = Firebase.FirebaseApp;\nL_0033:\n\tv71 = v67.CheckDependenciesThread + 1;\n\tv73 = v71 == 0;\n\tv76 = ~v73;\n\tSystem.Threading.Monitor::Exit(v51.CheckDependenciesThreadLock);\nL_003B:\n\t;\n\treturn v76;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0059;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tif (TEMP) goto L_003B;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0059:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsCheckDependenciesRunning()
		{
			Monitor.Enter(CheckDependenciesThreadLock);
			int num = CheckDependenciesThread + 1;
			bool flag = num == 0;
			bool result = !flag;
			Monitor.Exit(CheckDependenciesThreadLock);
			return result;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x1600BD8", Offset = "0x1600BD8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EF3C50]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A197]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::FirebaseApp_options(this.swigCPtr);\n\tv62 = new Firebase.AppOptionsInternal();\n\tFirebase.AppOptionsInternal::.ctor(v62, v56, 0);\n\tv66 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv68 = v66 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_003A;\n\treturn v62;\nL_003A:\n\tv75 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AppOptionsInternal options()
		{
			IntPtr cPtr = AppUtilPINVOKE.FirebaseApp_options(swigCPtr);
			AppOptionsInternal result = new AppOptionsInternal(cPtr, cMemoryOwn: false);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return result;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			return (AppOptionsInternal)(object)new TypeLoadException();
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x1600D14", Offset = "0x1600D14", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F0DAA0]);\n\tv17 = *([v16 @ X8_v15]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A199]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.AppUtilPINVOKE>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = Firebase.AppUtilPINVOKE::FirebaseApp_CreateInternal__SWIG_0();\n\tv55 = System.IntPtr::op_Equality(v51, 0);\n\tv58 = v55 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0030;\n\tv63 = new Firebase.FirebaseApp();\n\tFirebase.FirebaseApp::.ctor(v63, v51, 0);\nL_0030:\n\tv72 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv74 = v72 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003C;\n\treturn v64;\nL_003C:\n\tv81 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static FirebaseApp CreateInternal()
		{
			//IL_0075: Expected I4, but got O
			IntPtr intPtr = AppUtilPINVOKE.FirebaseApp_CreateInternal__SWIG_0();
			bool flag = intPtr == (IntPtr)0;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			FirebaseApp result = null;
			if (!flag3)
			{
				FirebaseApp firebaseApp = new FirebaseApp(intPtr, cMemoryOwn: false);
				result = firebaseApp;
				flag = (byte)(int)firebaseApp != 0;
			}
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return result;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			return (FirebaseApp)(object)new TypeLoadException();
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x15FF904", Offset = "0x15FF904", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F00DC0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A19A]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = Firebase.FirebaseApp::getCPtr(app);\n\tgoto L_0031;\n\tv62 = *([v58 @ X0_v6+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0031;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0031:\n\tFirebase.AppUtilPINVOKE::FirebaseApp_ReleaseReferenceInternal(v53);\n\tv71 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv73 = v71 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003D;\n\treturn;\nL_003D:\n\tv79 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ReleaseReferenceInternal(FirebaseApp app)
		{
			HandleRef cPtr = getCPtr(app);
			AppUtilPINVOKE.FirebaseApp_ReleaseReferenceInternal(cPtr);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x1600840", Offset = "0x1600840", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0C358]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, version, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A19B]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, version, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tFirebase.AppUtilPINVOKE::FirebaseApp_RegisterLibraryInternal(library, version);\n\tv57 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv59 = v57 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0030;\n\treturn;\nL_0030:\n\tv66 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RegisterLibraryInternal(string library, string version)
		{
			AppUtilPINVOKE.FirebaseApp_RegisterLibraryInternal(library, version);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x160054C", Offset = "0x160054C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF5540]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A19C]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tFirebase.AppUtilPINVOKE::FirebaseApp_AppSetDefaultConfigPath(path);\n\tv53 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv55 = v53 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002C;\n\treturn;\nL_002C:\n\tv61 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AppSetDefaultConfigPath(string path)
		{
			AppUtilPINVOKE.FirebaseApp_AppSetDefaultConfigPath(path);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[CompilerGenerated]
		[Token(Token = "0x6000061")]
		[Address(RVA = "0x1600DD0", Offset = "0x1600DD0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAF708]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A19E]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = Firebase.FirebaseApp::CreateInternal();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FirebaseApp _003CCreate_003Em__0()
		{
			return Create();
		}
	}
}
