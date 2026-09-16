using System;
using System.Runtime.InteropServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x200000D")]
	internal sealed class AppOptionsInternal : IDisposable
	{
		[Token(Token = "0x400002C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private HandleRef swigCPtr;

		[Token(Token = "0x400002D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private bool swigCMemOwn;

		[Token(Token = "0x17000009")]
		public Uri DatabaseUrl
		{
			[Token(Token = "0x600006A")]
			[Address(RVA = "0x15FA63C", Offset = "0x15FA63C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0DBF8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A087]) = v38;\nL_0014:\n\tv40 = Firebase.AppOptionsInternal::GetDatabaseUrlInternal(this);\n\tgoto L_0029;\n\tv48 = *([v44 @ X8_v5+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv61 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\treturnVal1 = Firebase.FirebaseApp::UrlStringToUri(v40);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string databaseUrlInternal = GetDatabaseUrlInternal();
				return FirebaseApp.UrlStringToUri(databaseUrlInternal);
			}
		}

		[Token(Token = "0x1700000A")]
		public string AppId
		{
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x15FA6B0", Offset = "0x15FA6B0", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EC0718]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A089]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_AppId_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_AppId_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x1700000B")]
		public string ApiKey
		{
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x15FA748", Offset = "0x15FA748", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1ED41B0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A08A]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_ApiKey_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_ApiKey_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x1700000C")]
		public string MessageSenderId
		{
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x15FA7E0", Offset = "0x15FA7E0", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EAAB50]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A08B]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_MessageSenderId_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_MessageSenderId_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x1700000D")]
		public string StorageBucket
		{
			[Token(Token = "0x600006F")]
			[Address(RVA = "0x15FA878", Offset = "0x15FA878", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EE5910]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A08C]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_StorageBucket_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_StorageBucket_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x1700000E")]
		public string ProjectId
		{
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x15FA910", Offset = "0x15FA910", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1F0FD38]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A08D]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_ProjectId_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_ProjectId_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x1700000F")]
		public string PackageName
		{
			[Token(Token = "0x6000071")]
			[Address(RVA = "0x15FA9A8", Offset = "0x15FA9A8", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1ECB040]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A08E]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_PackageName_get(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = AppUtilPINVOKE.AppOptionsInternal_PackageName_get(swigCPtr);
				if (!AppUtilPINVOKE.SWIGPendingException.Pending)
				{
					return result;
				}
				Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x15FAA8C", Offset = "0x15FAA8C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.swigCMemOwn = cMemoryOwn;\n\tv21 = 0;\n\tv26 = 0xCE3718(&v21 @ stack_-40_v1 (System.Runtime.InteropServices.HandleRef), this, cPtr, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.swigCPtr = 0;\n\tthis.swigCPtr.m_handle = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AppOptionsInternal(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			HandleRef handleRef = default(HandleRef);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
			swigCPtr = default(HandleRef);
			swigCPtr.m_handle = (IntPtr)0;
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x15FAAF0", Offset = "0x15FAAF0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFirebase.AppOptionsInternal::Dispose(this);\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_002B;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002C;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 41 ShiftStack 32\n\treturn;\nL_002B:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_002C:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~AppOptionsInternal()
		{
			Dispose();
			base.Finalize();
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x15FAB5C", Offset = "0x15FAB5C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFCCE0]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A086]) = v42;\nL_001B:\n\tgoto L_0026;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = Firebase.FirebaseApp;\nL_0026:\n\tSystem.Threading.Monitor::Enter(v56.disposeLock);\n\tv64 = System.IntPtr::op_Inequality(this.swigCPtr.m_handle, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0054;\n\tv68 = ~this.swigCMemOwn;\n\tif (v68) goto L_0049;\n\tthis.swigCMemOwn = 0;\n\tgoto L_0042;\n\tv126 = *([v104 @ X0_v16+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0042;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v104, v62, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tFirebase.AppUtilPINVOKE::delete_AppOptionsInternal(this.swigCPtr);\nL_0049:\n\tv89 = 0xCE3718(&v78 @ stack_-40_v3 (System.Runtime.InteropServices.HandleRef), 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tthis.swigCPtr = v78;\n\tthis.swigCPtr.m_handle = 0;\nL_0054:\n\tgoto L_005C;\n\tv117 = *([v96 @ X0_v8+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tgoto L_005C;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v96, v86, v84, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005C:\n\tSystem.GC::SuppressFinalize(this);\n\tSystem.Threading.Monitor::Exit(v56.disposeLock);\nL_0067:\n\treturn;\n\tgoto L_006B;\n\tgoto L_006B;\n\tgoto L_006B;\nL_006B:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0082;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tif (TEMP) goto L_0067;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0082:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			Monitor.Enter(FirebaseApp.disposeLock);
			if (swigCPtr.m_handle != (IntPtr)0)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					AppUtilPINVOKE.delete_AppOptionsInternal(swigCPtr);
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
				HandleRef handleRef = default(HandleRef);
				swigCPtr = handleRef;
				swigCPtr.m_handle = (IntPtr)0;
			}
			GC.SuppressFinalize(this);
			Monitor.Exit(FirebaseApp.disposeLock);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x15FAD68", Offset = "0x15FAD68", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EE6110]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A088]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = Firebase.AppUtilPINVOKE::AppOptionsInternal_GetDatabaseUrlInternal(this.swigCPtr);\n\tv58 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0031;\n\treturn v56;\nL_0031:\n\tv67 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal string GetDatabaseUrlInternal()
		{
			string result = AppUtilPINVOKE.AppOptionsInternal_GetDatabaseUrlInternal(swigCPtr);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return result;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			return (string)(object)new TypeLoadException();
		}
	}
}
