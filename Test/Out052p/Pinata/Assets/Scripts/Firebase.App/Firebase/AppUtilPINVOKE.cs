using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000002")]
	internal class AppUtilPINVOKE
	{
		[Token(Token = "0x2000003")]
		protected class SWIGExceptionHelper
		{
			[Token(Token = "0x2000004")]
			public delegate void ExceptionDelegate(string message);

			[Token(Token = "0x2000005")]
			public delegate void ExceptionArgumentDelegate(string message, string paramName);

			[Token(Token = "0x4000003")]
			private static ExceptionDelegate applicationDelegate;

			[Token(Token = "0x4000004")]
			private static ExceptionDelegate arithmeticDelegate;

			[Token(Token = "0x4000005")]
			private static ExceptionDelegate divideByZeroDelegate;

			[Token(Token = "0x4000006")]
			private static ExceptionDelegate indexOutOfRangeDelegate;

			[Token(Token = "0x4000007")]
			private static ExceptionDelegate invalidCastDelegate;

			[Token(Token = "0x4000008")]
			private static ExceptionDelegate invalidOperationDelegate;

			[Token(Token = "0x4000009")]
			private static ExceptionDelegate ioDelegate;

			[Token(Token = "0x400000A")]
			private static ExceptionDelegate nullReferenceDelegate;

			[Token(Token = "0x400000B")]
			private static ExceptionDelegate outOfMemoryDelegate;

			[Token(Token = "0x400000C")]
			private static ExceptionDelegate overflowDelegate;

			[Token(Token = "0x400000D")]
			private static ExceptionDelegate systemDelegate;

			[Token(Token = "0x400000E")]
			private static ExceptionArgumentDelegate argumentDelegate;

			[Token(Token = "0x400000F")]
			private static ExceptionArgumentDelegate argumentNullDelegate;

			[Token(Token = "0x4000010")]
			private static ExceptionArgumentDelegate argumentOutOfRangeDelegate;

			[Token(Token = "0x6000018")]
			[Address(RVA = "0x15FC8FC", Offset = "0x15FC8FC", Length = "0x2FC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EF8ED0]);\n\tv17 = *([v16 @ X8_v77]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A148]) = v37;\nL_0015:\n\tv41 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv45 = Il2CppMethodInfo;\n\tv41.m_target = 0;\n\tv41.method = Il2CppMethodInfo;\n\tv41.method_ptr = *([v45 @ X8_v5 (Il2CppMethodInfo)]);\n\tv49.applicationDelegate = v41;\n\tv51 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv54 = Il2CppMethodInfo;\n\tv51.m_target = 0;\n\tv51.method = Il2CppMethodInfo;\n\tv51.method_ptr = *([v54 @ X8_v10 (Il2CppMethodInfo)]);\n\tv57.arithmeticDelegate = v51;\n\tv59 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv62 = Il2CppMethodInfo;\n\tv59.m_target = 0;\n\tv59.method = Il2CppMethodInfo;\n\tv59.method_ptr = *([v62 @ X8_v15 (Il2CppMethodInfo)]);\n\tv65.divideByZeroDelegate = v59;\n\tv67 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv70 = Il2CppMethodInfo;\n\tv67.m_target = 0;\n\tv67.method = Il2CppMethodInfo;\n\tv67.method_ptr = *([v70 @ X8_v20 (Il2CppMethodInfo)]);\n\tv73.indexOutOfRangeDelegate = v67;\n\tv75 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv78 = Il2CppMethodInfo;\n\tv75.m_target = 0;\n\tv75.method = Il2CppMethodInfo;\n\tv75.method_ptr = *([v78 @ X8_v25 (Il2CppMethodInfo)]);\n\tv81.invalidCastDelegate = v75;\n\tv83 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv86 = Il2CppMethodInfo;\n\tv83.m_target = 0;\n\tv83.method = Il2CppMethodInfo;\n\tv83.method_ptr = *([v86 @ X8_v30 (Il2CppMethodInfo)]);\n\tv89.invalidOperationDelegate = v83;\n\tv91 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv94 = Il2CppMethodInfo;\n\tv91.m_target = 0;\n\tv91.method = Il2CppMethodInfo;\n\tv91.method_ptr = *([v94 @ X8_v35 (Il2CppMethodInfo)]);\n\tv97.ioDelegate = v91;\n\tv99 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv102 = Il2CppMethodInfo;\n\tv99.m_target = 0;\n\tv99.method = Il2CppMethodInfo;\n\tv99.method_ptr = *([v102 @ X8_v40 (Il2CppMethodInfo)]);\n\tv105.nullReferenceDelegate = v99;\n\tv107 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv110 = Il2CppMethodInfo;\n\tv107.m_target = 0;\n\tv107.method = Il2CppMethodInfo;\n\tv107.method_ptr = *([v110 @ X8_v45 (Il2CppMethodInfo)]);\n\tv113.outOfMemoryDelegate = v107;\n\tv115 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv118 = Il2CppMethodInfo;\n\tv115.m_target = 0;\n\tv115.method = Il2CppMethodInfo;\n\tv115.method_ptr = *([v118 @ X8_v50 (Il2CppMethodInfo)]);\n\tv121.overflowDelegate = v115;\n\tv123 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionDelegate();\n\tv127 = Il2CppMethodInfo;\n\tv123.m_target = 0;\n\tv123.method = Il2CppMethodInfo;\n\tv123.method_ptr = *([v127 @ X8_v55 (Il2CppMethodInfo)]);\n\tv130.systemDelegate = v123;\n\tv133 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionArgumentDelegate();\n\tv136 = Il2CppMethodInfo;\n\tv133.m_target = 0;\n\tv133.method = Il2CppMethodInfo;\n\tv133.method_ptr = *([v136 @ X8_v60 (Il2CppMethodInfo)]);\n\tv139.argumentDelegate = v133;\n\tv141 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionArgumentDelegate();\n\tv144 = Il2CppMethodInfo;\n\tv141.m_target = 0;\n\tv141.method = Il2CppMethodInfo;\n\tv141.method_ptr = *([v144 @ X8_v65 (Il2CppMethodInfo)]);\n\tv147.argumentNullDelegate = v141;\n\tv149 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper+ExceptionArgumentDelegate();\n\tv152 = Il2CppMethodInfo;\n\tv149.m_target = 0;\n\tv149.method = Il2CppMethodInfo;\n\tv149.method_ptr = *([v152 @ X8_v70 (Il2CppMethodInfo)]);\n\tv155.argumentOutOfRangeDelegate = v149;\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SWIGRegisterExceptionCallbacks_AppUtil(v156.applicationDelegate, v156.arithmeticDelegate, v156.divideByZeroDelegate, v156.indexOutOfRangeDelegate, v156.invalidCastDelegate, v156.invalidOperationDelegate, v156.ioDelegate, v156.nullReferenceDelegate, v156.outOfMemoryDelegate, v169, v156.systemDelegate);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SWIGRegisterExceptionCallbacksArgument_AppUtil(v176.argumentDelegate, v176.argumentNullDelegate, v176.argumentOutOfRangeDelegate);\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			unsafe static SWIGExceptionHelper()
			{
				ExceptionDelegate exceptionDelegate = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)exceptionDelegate).m_target = null;
				((Delegate)exceptionDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingApplicationException);
				((Delegate)exceptionDelegate).method_ptr = method_ptr;
				applicationDelegate = exceptionDelegate;
				ExceptionDelegate exceptionDelegate2 = null;
				IntPtr method_ptr2 = (IntPtr)0;
				((Delegate)exceptionDelegate2).m_target = null;
				((Delegate)exceptionDelegate2).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingArithmeticException);
				((Delegate)exceptionDelegate2).method_ptr = method_ptr2;
				arithmeticDelegate = exceptionDelegate2;
				ExceptionDelegate exceptionDelegate3 = null;
				IntPtr method_ptr3 = (IntPtr)0;
				((Delegate)exceptionDelegate3).m_target = null;
				((Delegate)exceptionDelegate3).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingDivideByZeroException);
				((Delegate)exceptionDelegate3).method_ptr = method_ptr3;
				divideByZeroDelegate = exceptionDelegate3;
				ExceptionDelegate exceptionDelegate4 = null;
				IntPtr method_ptr4 = (IntPtr)0;
				((Delegate)exceptionDelegate4).m_target = null;
				((Delegate)exceptionDelegate4).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingIndexOutOfRangeException);
				((Delegate)exceptionDelegate4).method_ptr = method_ptr4;
				indexOutOfRangeDelegate = exceptionDelegate4;
				ExceptionDelegate exceptionDelegate5 = null;
				IntPtr method_ptr5 = (IntPtr)0;
				((Delegate)exceptionDelegate5).m_target = null;
				((Delegate)exceptionDelegate5).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingInvalidCastException);
				((Delegate)exceptionDelegate5).method_ptr = method_ptr5;
				invalidCastDelegate = exceptionDelegate5;
				ExceptionDelegate exceptionDelegate6 = null;
				IntPtr method_ptr6 = (IntPtr)0;
				((Delegate)exceptionDelegate6).m_target = null;
				((Delegate)exceptionDelegate6).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingInvalidOperationException);
				((Delegate)exceptionDelegate6).method_ptr = method_ptr6;
				invalidOperationDelegate = exceptionDelegate6;
				ExceptionDelegate exceptionDelegate7 = null;
				IntPtr method_ptr7 = (IntPtr)0;
				((Delegate)exceptionDelegate7).m_target = null;
				((Delegate)exceptionDelegate7).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingIOException);
				((Delegate)exceptionDelegate7).method_ptr = method_ptr7;
				ioDelegate = exceptionDelegate7;
				ExceptionDelegate exceptionDelegate8 = null;
				IntPtr method_ptr8 = (IntPtr)0;
				((Delegate)exceptionDelegate8).m_target = null;
				((Delegate)exceptionDelegate8).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingNullReferenceException);
				((Delegate)exceptionDelegate8).method_ptr = method_ptr8;
				nullReferenceDelegate = exceptionDelegate8;
				ExceptionDelegate exceptionDelegate9 = null;
				IntPtr method_ptr9 = (IntPtr)0;
				((Delegate)exceptionDelegate9).m_target = null;
				((Delegate)exceptionDelegate9).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingOutOfMemoryException);
				((Delegate)exceptionDelegate9).method_ptr = method_ptr9;
				outOfMemoryDelegate = exceptionDelegate9;
				ExceptionDelegate exceptionDelegate10 = null;
				IntPtr method_ptr10 = (IntPtr)0;
				((Delegate)exceptionDelegate10).m_target = null;
				((Delegate)exceptionDelegate10).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingOverflowException);
				((Delegate)exceptionDelegate10).method_ptr = method_ptr10;
				overflowDelegate = exceptionDelegate10;
				ExceptionDelegate exceptionDelegate11 = null;
				IntPtr method_ptr11 = (IntPtr)0;
				((Delegate)exceptionDelegate11).m_target = null;
				((Delegate)exceptionDelegate11).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, void>*/)(&SetPendingSystemException);
				((Delegate)exceptionDelegate11).method_ptr = method_ptr11;
				systemDelegate = exceptionDelegate11;
				ExceptionArgumentDelegate exceptionArgumentDelegate = null;
				IntPtr method_ptr12 = (IntPtr)0;
				((Delegate)exceptionArgumentDelegate).m_target = null;
				((Delegate)exceptionArgumentDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, string, void>*/)(&SetPendingArgumentException);
				((Delegate)exceptionArgumentDelegate).method_ptr = method_ptr12;
				argumentDelegate = exceptionArgumentDelegate;
				ExceptionArgumentDelegate exceptionArgumentDelegate2 = null;
				IntPtr method_ptr13 = (IntPtr)0;
				((Delegate)exceptionArgumentDelegate2).m_target = null;
				((Delegate)exceptionArgumentDelegate2).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, string, void>*/)(&SetPendingArgumentNullException);
				((Delegate)exceptionArgumentDelegate2).method_ptr = method_ptr13;
				argumentNullDelegate = exceptionArgumentDelegate2;
				ExceptionArgumentDelegate exceptionArgumentDelegate3 = null;
				IntPtr method_ptr14 = (IntPtr)0;
				((Delegate)exceptionArgumentDelegate3).m_target = null;
				((Delegate)exceptionArgumentDelegate3).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, string, void>*/)(&SetPendingArgumentOutOfRangeException);
				((Delegate)exceptionArgumentDelegate3).method_ptr = method_ptr14;
				argumentOutOfRangeDelegate = exceptionArgumentDelegate3;
				ExceptionDelegate exceptionDelegate12 = default(ExceptionDelegate);
				SWIGRegisterExceptionCallbacks_AppUtil(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, exceptionDelegate12, systemDelegate);
				SWIGRegisterExceptionCallbacksArgument_AppUtil(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
			}

			[Token(Token = "0x6000019")]
			[Address(RVA = "0x15FBCBC", Offset = "0x15FBCBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SWIGExceptionHelper()
			{
			}

			[PreserveSig]
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x15FCC18", Offset = "0x15FCC18", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv48 = *([202A150]);\n\tv44 = *([202A150]) == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0033;\n\tv48 = 0x1844000 + 0x96B;\n\tv62 = 0x8D848C(&v48 @ X8_v6 (System.Int32), arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\t*([202A150]) = v62;\n\tv97 = v62 == 0;\n\tif (v97) goto L_0070;\nL_0033:\n\tv103 = 0x8D8484(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv106 = 0x8D8484(arithmeticDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv112 = 0x8D8484(divideByZeroDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv118 = 0x8D8484(indexOutOfRangeDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv121 = 0x8D8484(invalidCastDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv190 = 0x8D8484(invalidOperationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv193 = 0x8D8484(ioDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv196 = 0x8D8484(nullReferenceDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv199 = 0x8D8484(*([v24 @ X29_v1+10]), arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv202 = 0x8D8484(*([v24 @ X29_v1+18]), arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv205 = 0x8D8484(*([v24 @ X29_v1+20]), arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, v63, v64, v65, v66, v67, v68, v69, v70);\n\t*([202A150])(v161, v103, v106, v112, v118, v121, v190, v193, v196, v63, v64, v65, v66, v67, v68, v69, v70);\n\treturn;\nL_0070:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static extern void SWIGRegisterExceptionCallbacks_AppUtil(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

			[PreserveSig]
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x15FCD9C", Offset = "0x15FCD9C", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([202A158]);\n\tv22 = *([202A158]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0025;\n\tv26 = 0x1844000 + 0x96B;\n\tv40 = 0x8D848C(&v26 @ X8_v5 (System.Int32), argumentNullDelegate, argumentOutOfRangeDelegate, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([202A158]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_003B;\nL_0025:\n\tv83 = 0x8D8484(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv86 = 0x8D8484(argumentNullDelegate, argumentNullDelegate, argumentOutOfRangeDelegate, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv92 = 0x8D8484(argumentOutOfRangeDelegate, argumentNullDelegate, argumentOutOfRangeDelegate, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([202A158])(v100, v83, v86, v92, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_003B:\n\tv89 = new System.NotSupportedException();\n\tthrow v89;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static extern void SWIGRegisterExceptionCallbacksArgument_AppUtil(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B7C0", Offset = "0x73B7C0")]
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x15FC1D4", Offset = "0x15FC1D4", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF9E20]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A160]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.ApplicationException();\n\tSystem.ApplicationException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingApplicationException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				ApplicationException e = new ApplicationException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B824", Offset = "0x73B824")]
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x15FC250", Offset = "0x15FC250", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFC348]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A161]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.ArithmeticException();\n\tSystem.ArithmeticException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingArithmeticException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				ArithmeticException e = new ArithmeticException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B888", Offset = "0x73B888")]
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x15FC2CC", Offset = "0x15FC2CC", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC0B60]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A162]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.DivideByZeroException();\n\tSystem.DivideByZeroException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingDivideByZeroException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				DivideByZeroException e = new DivideByZeroException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B8EC", Offset = "0x73B8EC")]
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x15FC348", Offset = "0x15FC348", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F091C0]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A163]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingIndexOutOfRangeException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				IndexOutOfRangeException e = new IndexOutOfRangeException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B950", Offset = "0x73B950")]
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x15FC3C4", Offset = "0x15FC3C4", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0EE88]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A164]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.InvalidCastException();\n\tSystem.InvalidCastException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingInvalidCastException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				InvalidCastException e = new InvalidCastException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73B9B4", Offset = "0x73B9B4")]
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x15FC440", Offset = "0x15FC440", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB3CC0]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A165]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingInvalidOperationException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				InvalidOperationException e = new InvalidOperationException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BA18", Offset = "0x73BA18")]
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x15FC4BC", Offset = "0x15FC4BC", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECBE40]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A166]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.IO.IOException();\n\tSystem.IO.IOException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingIOException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				IOException e = new IOException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BA7C", Offset = "0x73BA7C")]
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x15FC538", Offset = "0x15FC538", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE7420]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A167]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.NullReferenceException();\n\tSystem.NullReferenceException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingNullReferenceException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				NullReferenceException e = new NullReferenceException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BAE0", Offset = "0x73BAE0")]
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x15FC5B4", Offset = "0x15FC5B4", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECA0C8]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A168]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.OutOfMemoryException();\n\tSystem.OutOfMemoryException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingOutOfMemoryException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				OutOfMemoryException e = new OutOfMemoryException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BB44", Offset = "0x73BB44")]
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x15FC630", Offset = "0x15FC630", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F00678]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A169]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.OverflowException();\n\tSystem.OverflowException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingOverflowException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				OverflowException e = new OverflowException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BBA8", Offset = "0x73BBA8")]
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x15FC6AC", Offset = "0x15FC6AC", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFE0E8]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A16A]) = v40;\nL_0014:\n\tv41 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv47 = new System.SystemException();\n\tSystem.SystemException::.ctor(v47, v38, v41);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v47);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingSystemException(string message)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				SystemException e = new SystemException(message2, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BC0C", Offset = "0x73BC0C")]
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x15FC728", Offset = "0x15FC728", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE8AA0]);\n\tv25 = *([v24 @ X8_v7]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, paramName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A16B]) = v43;\nL_0016:\n\tv44 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv50 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v50, v41, paramName, v44);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v50);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingArgumentException(string message, string paramName)
			{
				Exception innerException = SWIGPendingException.Retrieve();
				string message2 = default(string);
				ArgumentException e = new ArgumentException(message2, paramName, innerException);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BC70", Offset = "0x73BC70")]
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x15FC7AC", Offset = "0x15FC7AC", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB1BC8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, paramName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A16C]) = v41;\nL_0015:\n\tv42 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv43 = v42 == 0;\n\tif (v43) goto L_0027;\n\tv47 = System.Exception::get_Message(v42);\n\tv54 = System.String::Concat(v39, \" Inner Exception: \", v47);\nL_0027:\n\tv67 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v67, paramName, v61);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v67);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingArgumentNullException(string message, string paramName)
			{
				Exception ex = SWIGPendingException.Retrieve();
				bool flag = ex == null;
				string text = default(string);
				string message2 = text;
				if (!flag)
				{
					string message3 = ex.Message;
					string text2 = text + " Inner Exception: " + message3;
					message2 = text2;
				}
				ArgumentNullException e = new ArgumentNullException(paramName, message2);
				SWIGPendingException.Set(e);
			}

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BCD4", Offset = "0x73BCD4")]
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x15FC854", Offset = "0x15FC854", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE6AB0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, paramName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A16D]) = v41;\nL_0015:\n\tv42 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tv43 = v42 == 0;\n\tif (v43) goto L_0027;\n\tv47 = System.Exception::get_Message(v42);\n\tv54 = System.String::Concat(v39, \" Inner Exception: \", v47);\nL_0027:\n\tv67 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v67, paramName, v61);\n\tFirebase.AppUtilPINVOKE+SWIGPendingException::Set(v67);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
			{
				Exception ex = SWIGPendingException.Retrieve();
				bool flag = ex == null;
				string text = default(string);
				string message2 = text;
				if (!flag)
				{
					string message3 = ex.Message;
					string text2 = text + " Inner Exception: " + message3;
					message2 = text2;
				}
				ArgumentOutOfRangeException e = new ArgumentOutOfRangeException(paramName, message2);
				SWIGPendingException.Set(e);
			}
		}

		[Token(Token = "0x2000006")]
		public class SWIGPendingException
		{
			[ThreadStatic]
			[Token(Token = "0x4000011")]
			private static Exception pendingException;

			[Token(Token = "0x4000012")]
			private static int numExceptionsPending;

			[Token(Token = "0x17000001")]
			public static bool Pending
			{
				[Token(Token = "0x6000032")]
				[Address(RVA = "0x15FAFA4", Offset = "0x15FAFA4", Length = "0x70")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv14 = *([1EBFEE8]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A16E]) = v35;\nL_0020:\n\tv51 = v39.numExceptionsPending < 1;\n\tif (v51) goto L_FFFFFFFF;\n\tv52 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv59 = *([v52 @ X0_v5]) == 0;\n\tv64 = ~v59;\n\tgoto L_0035;\nL_0035:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					if (numExceptionsPending >= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
						object obj = default(object);
						bool flag = obj == null;
						return !flag;
					}
					return false;
				}
			}

			[Token(Token = "0x6000033")]
			[Address(RVA = "0x15FCE6C", Offset = "0x15FCE6C", Length = "0x158")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFD180]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A16F]) = v40;\nL_0017:\n\tv44 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv48 = *([v44 @ X0_v3]) == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0043;\n\t*([v47 @ X0_v5]) = e;\n\tgoto L_0030;\n\tv63 = *([v52 @ X0_v16+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0030;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0030:\n\tv72 = System.Type::GetTypeFromHandle(Firebase.AppUtilPINVOKE);\n\tSystem.Threading.Monitor::Enter(v72);\n\tv101 = v99.numExceptionsPending + 1;\n\tv99.numExceptionsPending = v101;\n\tSystem.Threading.Monitor::Exit(v72);\n\treturn;\nL_0043:\n\tv59 = *([v47 @ X0_v5]);\n\tv62 = 0x846A20(*([v47 @ X0_v5]), 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = *([v59 @ X20_v4]);\n\t*([v73 @ X8_v3+160])(v77, *([v47 @ X0_v5]), *([v73 @ X8_v3+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv87 = System.String::Concat(\"FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (\", v77, \")\");\n\tv95 = new System.ApplicationException();\n\tSystem.ApplicationException::.ctor(v95, v87, e);\n\tthrow v95;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void Set(Exception e)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
				object obj = default(object);
				object obj2 = default(object);
				if (obj == null)
				{
					obj2 = e;
					Type typeFromHandle = typeof(AppUtilPINVOKE);
					Monitor.Enter(typeFromHandle);
					int num = numExceptionsPending + 1;
					numExceptionsPending = num;
					Monitor.Exit(typeFromHandle);
					return;
				}
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v73 @ X8_v3+160] (should have been resolved before IL gen)");
				string text = default(string);
				string message = "FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + text + ")";
				ApplicationException ex = new ApplicationException(message, e);
				throw ex;
			}

			[Token(Token = "0x6000034")]
			[Address(RVA = "0x15FB014", Offset = "0x15FB014", Length = "0xF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = *([1EECB20]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202A170]) = v39;\nL_0022:\n\tv55 = v43.numExceptionsPending < 1;\n\tif (v55) goto L_FFFFFFFF;\n\tv56 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv59 = *([v56 @ X0_v6]) == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv85 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv76 = *([v85 @ X0_v8]);\n\tv87 = 0x8D8208(Firebase.AppUtilPINVOKE+SWIGPendingException, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v87 @ X0_v10]) = 0;\n\tgoto L_003F;\n\tv97 = *([v90 @ X0_v11+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_003F;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v90, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003F:\n\tv105 = System.Type::GetTypeFromHandle(Firebase.AppUtilPINVOKE);\n\tSystem.Threading.Monitor::Enter(v105);\n\tv69 = v75.numExceptionsPending - 1;\n\tv75.numExceptionsPending = v69;\n\tSystem.Threading.Monitor::Exit(v105);\n\tgoto L_0054;\nL_0054:\n\treturn v76;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static Exception Retrieve()
			{
				//IL_0056: Expected O, but got I4
				Exception result;
				if (numExceptionsPending >= 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
					object obj = default(object);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
						object obj2 = default(object);
						result = (Exception)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8208");
						object obj3 = 0;
						Type typeFromHandle = typeof(AppUtilPINVOKE);
						Monitor.Enter(typeFromHandle);
						int num = numExceptionsPending - 1;
						numExceptionsPending = num;
						Monitor.Exit(typeFromHandle);
						goto IL_00c5;
					}
				}
				result = null;
				goto IL_00c5;
				IL_00c5:
				return result;
			}
		}

		[Token(Token = "0x2000007")]
		protected class SWIGStringHelper
		{
			[Token(Token = "0x2000008")]
			public delegate string SWIGStringDelegate(string message);

			[Token(Token = "0x4000013")]
			private static SWIGStringDelegate stringDelegate;

			[Token(Token = "0x6000035")]
			[Address(RVA = "0x15FD7C8", Offset = "0x15FD7C8", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F0D9A0]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A171]) = v35;\nL_0014:\n\tv39 = new Firebase.AppUtilPINVOKE+SWIGStringHelper+SWIGStringDelegate();\n\tv42 = Il2CppMethodInfo;\n\tv39.m_target = 0;\n\tv39.method = Il2CppMethodInfo;\n\tv39.method_ptr = *([v42 @ X8_v7 (Il2CppMethodInfo)]);\n\tv47.stringDelegate = v39;\n\tFirebase.AppUtilPINVOKE+SWIGStringHelper::SWIGRegisterStringCallback_AppUtil(v51.stringDelegate);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			unsafe static SWIGStringHelper()
			{
				SWIGStringDelegate sWIGStringDelegate = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)sWIGStringDelegate).m_target = null;
				((Delegate)sWIGStringDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<string, string>*/)(&CreateString);
				((Delegate)sWIGStringDelegate).method_ptr = method_ptr;
				stringDelegate = sWIGStringDelegate;
				SWIGRegisterStringCallback_AppUtil(stringDelegate);
			}

			[Token(Token = "0x6000036")]
			[Address(RVA = "0x15FBCC4", Offset = "0x15FBCC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SWIGStringHelper()
			{
			}

			[PreserveSig]
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x15FD85C", Offset = "0x15FD85C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A178]);\n\tv14 = *([202A178]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v5 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A178]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002C;\nL_0021:\n\tv77 = 0x8D8484(stringDelegate, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A178])(v79, v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002C:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static extern void SWIGRegisterStringCallback_AppUtil(SWIGStringDelegate stringDelegate);

			[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x73BD38", Offset = "0x73BD38")]
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x15FD7C4", Offset = "0x15FD7C4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn cString;\n")]
			private static string CreateString(string cString)
			{
				return cString;
			}
		}

		[Token(Token = "0x4000001")]
		protected static SWIGExceptionHelper swigExceptionHelper;

		[Token(Token = "0x4000002")]
		protected static SWIGStringHelper swigStringHelper;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x15FBC28", Offset = "0x15FBC28", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED2898]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A095]) = v37;\nL_0015:\n\tv41 = new Firebase.AppUtilPINVOKE+SWIGExceptionHelper();\n\tSystem.Object::.ctor(v41);\n\tv47.swigExceptionHelper = v41;\n\tv51 = new Firebase.AppUtilPINVOKE+SWIGStringHelper();\n\tSystem.Object::.ctor(v51);\n\tv55.swigStringHelper = v51;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AppUtilPINVOKE()
		{
			SWIGExceptionHelper sWIGExceptionHelper = new SWIGExceptionHelper();
			swigExceptionHelper = sWIGExceptionHelper;
			SWIGStringHelper sWIGStringHelper = new SWIGStringHelper();
			swigStringHelper = sWIGStringHelper;
		}

		[PreserveSig]
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x15FAEF4", Offset = "0x15FAEF4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A098]);\n\tv14 = *([202A098]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A098]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static extern string AppOptionsInternal_GetDatabaseUrlInternal(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15FB108", Offset = "0x15FB108", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0A0]);\n\tv14 = *([202A0A0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0A0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_AppId_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15FB1B8", Offset = "0x15FB1B8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0A8]);\n\tv14 = *([202A0A8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0A8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_ApiKey_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15FB268", Offset = "0x15FB268", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0B0]);\n\tv14 = *([202A0B0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0B0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_MessageSenderId_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15FB318", Offset = "0x15FB318", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0B8]);\n\tv14 = *([202A0B8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0B8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_StorageBucket_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000007")]
		[Address(RVA = "0x15FB3C8", Offset = "0x15FB3C8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0C0]);\n\tv14 = *([202A0C0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0C0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_ProjectId_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000008")]
		[Address(RVA = "0x15FB478", Offset = "0x15FB478", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0C8]);\n\tv14 = *([202A0C8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0C8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string AppOptionsInternal_PackageName_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x15FACD0", Offset = "0x15FACD0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0D0]);\n\tv14 = *([202A0D0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0D0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static extern void delete_AppOptionsInternal(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x600000A")]
		[Address(RVA = "0x15FBCCC", Offset = "0x15FBCCC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0D8]);\n\tv14 = *([202A0D8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0D8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern IntPtr FirebaseApp_options(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15FBD64", Offset = "0x15FBD64", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0E0]);\n\tv14 = *([202A0E0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0E0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0031;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv80 = 0x8D8470(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = 0x8D8480(v78, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn v80;\nL_0031:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string FirebaseApp_NameInternal_get(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15FBE14", Offset = "0x15FBE14", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([202A0E8]);\n\tv10 = *([202A0E8]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1844000 + 0x96B;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([202A0E8]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern IntPtr FirebaseApp_CreateInternal__SWIG_0();

		[PreserveSig]
		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15FBE9C", Offset = "0x15FBE9C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A0F0]);\n\tv14 = *([202A0F0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([202A0F0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, methodInfo, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static extern void FirebaseApp_ReleaseReferenceInternal(HandleRef jarg1);

		[PreserveSig]
		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15FBF34", Offset = "0x15FBF34", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([202A0F8]);\n\tv10 = *([202A0F8]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1844000 + 0x96B;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([202A0F8]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static extern int FirebaseApp_GetLogLevelInternal();

		[PreserveSig]
		[Token(Token = "0x600000F")]
		[Address(RVA = "0x15FBFBC", Offset = "0x15FBFBC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([202A100]);\n\tv18 = *([202A100]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1844000 + 0x96B;\n\tv36 = 0x8D848C(&v22 @ X8_v5 (System.Int32), jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([202A100]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_0039;\nL_0023:\n\tv80 = 0x8D8464(jarg1, jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv83 = 0x8D8464(jarg2, jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([202A100])(v91, v80, v83, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv93 = 0x8D8480(v80, v83, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv98 = 0x8D8480(v83, v83, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_0039:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static extern void FirebaseApp_RegisterLibraryInternal(string jarg1, string jarg2);

		[PreserveSig]
		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15FC08C", Offset = "0x15FC08C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A108]);\n\tv14 = *([202A108]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v5 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A108]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002F;\nL_0021:\n\tv77 = 0x8D8464(jarg1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A108])(v80, v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv82 = 0x8D8480(v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002F:\n\tv85 = new System.NotSupportedException();\n\tthrow v85;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void FirebaseApp_AppSetDefaultConfigPath(string jarg1);

		[PreserveSig]
		[Token(Token = "0x6000011")]
		[Address(RVA = "0x15FC134", Offset = "0x15FC134", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv71 = *([202A110]);\n\tv12 = *([202A110]) == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_001E;\n\tv16 = 0x1844000 + 0x96B;\n\tv71 = 0x8D848C(&v16 @ X8_v3 (System.Int32), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\t*([202A110]) = v71;\n\tv70 = v71 == 0;\n\tif (v70) goto L_002D;\nL_001E:\n\tv71(v72, v71, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv74 = 0x8D8470(v72, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv77 = 0x8D8480(v72, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn v74;\nL_002D:\n\tv80 = new System.NotSupportedException();\n\tthrow v80;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern string FirebaseApp_DefaultName_get();

		[PreserveSig]
		[Token(Token = "0x6000012")]
		[Address(RVA = "0x15FB5A8", Offset = "0x15FB5A8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([202A118]);\n\tv10 = *([202A118]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1844000 + 0x96B;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([202A118]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(v70, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void PollCallbacks();

		[PreserveSig]
		[Token(Token = "0x6000013")]
		[Address(RVA = "0x15FB6B8", Offset = "0x15FB6B8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A120]);\n\tv14 = *([202A120]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A120]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, jarg1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void AppEnableLogCallback(bool jarg1);

		[PreserveSig]
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x15FB7D8", Offset = "0x15FB7D8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A128]);\n\tv14 = *([202A128]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A128]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, jarg1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void SetEnabledAllAppCallbacks(bool jarg1);

		[PreserveSig]
		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15FB908", Offset = "0x15FB908", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([202A130]);\n\tv18 = *([202A130]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1844000 + 0x96B;\n\tv36 = 0x8D848C(&v22 @ X8_v5 (System.Int32), jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([202A130]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_0033;\nL_0023:\n\tv80 = 0x8D8464(jarg1, jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([202A130])(v84, v80, jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv86 = 0x8D8480(v80, jarg2, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_0033:\n\tv89 = new System.NotSupportedException();\n\tthrow v89;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void SetEnabledAppCallbackByName(string jarg1, bool jarg2);

		[PreserveSig]
		[Token(Token = "0x6000016")]
		[Address(RVA = "0x15FBA50", Offset = "0x15FBA50", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A138]);\n\tv14 = *([202A138]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v5 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A138]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_003B;\nL_0021:\n\tv77 = 0x8D8464(jarg1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A138])(v80, v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv83 = 0x8D8480(v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv91 = v80 == 0;\n\tv100 = ~v91;\n\treturn v100;\nL_003B:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern bool GetEnabledAppCallbackByName(string jarg1);

		[PreserveSig]
		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15FBB8C", Offset = "0x15FBB8C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([202A140]);\n\tv14 = *([202A140]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1844000 + 0x96B;\n\tv32 = 0x8D848C(&v18 @ X8_v5 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A140]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002C;\nL_0021:\n\tv77 = 0x8D8484(jarg1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([202A140])(v79, v77, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002C:\n\tv86 = new System.NotSupportedException();\n\tthrow v86;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static extern void SetLogFunction(LogUtil.LogMessageDelegate jarg1);
	}
}
