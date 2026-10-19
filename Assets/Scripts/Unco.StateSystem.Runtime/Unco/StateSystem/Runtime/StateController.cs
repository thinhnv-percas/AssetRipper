using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.StateSystem.Runtime
{
	[Token(Token = "0x2000007")]
	public abstract class StateController<T> where T : State
	{
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		protected readonly List<T> States;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x0")]
		private IStateMachine _stateMachine;

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x6390518", Offset = "0x6390518", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._stateMachine = stateMachine;\n\treturn;\n")]
		protected void Init(IStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x4423858", Offset = "0x4423858", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tgoto L_001B;\n\tv35 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_004F;\nL_001B:\n\tv48 = Unco.StateSystem.Runtime.StateController`1<T>::TryGetState(this, &v46 @ stack_-28_v2 (Unco.StateSystem.Runtime.State));\n\tv49 = ~v48;\n\tif (v49) goto L_0055;\nL_004F:\n\tUnco.StateSystem.Runtime.IStateMachine::SetState(this._stateMachine, v46);\nL_0055:\n\treturn;\n")]
		public unsafe void SetState<TS>() where TS : T
		{
			State state;
			if (TryGetState<TS>(out *(T*)(&state)))
			{
				_stateMachine.SetState(state);
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x4423938", Offset = "0x4423938", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_001A;\nL_001A:\n\tv92 = this.States;\n\tv50 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tv53 = *([v50 @ X0_v61 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+135]) & 1;\n\tv54 = v53 == 0;\nL_FFFFFFFF:\n\tv128 = this.States;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tif (v54) goto L_003C;\nL_0023:\n\tgoto L_0025;\nL_0025:\n\tv79 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tv82 = *([v79 @ X0_v58 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+135]) & 1;\n\tv83 = v82 == 0;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\nL_FFFFFFFF:\n\tv128 = v92;\nL_FFFFFFFF:\n\tv104 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tif (v83) goto L_004A;\nL_002B:\n\tv99 = *([v93 @ X0_v56 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+B8]);\n\tv124 = *([v99 @ X8_v60 (Il2CppStaticFields<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+8]);\n\tv101 = *([v99 @ X8_v60 (Il2CppStaticFields<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+8]) == 0;\n\tv102 = ~v101;\nL_FFFFFFFF:\n\tv127 = v92;\n\tif (v102) goto L_0095;\nL_FFFFFFFF:\n\tv128 = v92;\n\tgoto L_0051;\n\tv91 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = this.States;\n\tv60 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tv114 = *([v60 @ X0_v70 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+135]) & 1;\n\tv115 = v114 == 0;\n\tv62 = ~v115;\nL_FFFFFFFF:\n\tv128 = this.States;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tif (v62) goto L_0023;\nL_003C:\n\tv71 = 0x220C238(v68, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = *([v71 @ X0_v55+E4]) == 0;\n\tv75 = ~v89;\nL_FFFFFFFF:\n\tv92 = v128;\n\tif (v75) goto L_0025;\n\tv94 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tv110 = *([v94 @ X0_v53 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+135]) & 1;\n\tv111 = v110 == 0;\n\tv96 = ~v111;\nL_FFFFFFFF:\n\tv92 = v128;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\nL_FFFFFFFF:\n\tv104 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tif (v96) goto L_002B;\nL_004A:\n\tv107 = 0x220C238(v104, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv136 = *([v107 @ X0_v50+B8]);\n\tv124 = *([v136 @ X8_v52+8]);\n\tv143 = *([v136 @ X8_v52+8]) == 0;\n\tv133 = ~v143;\nL_FFFFFFFF:\n\tv127 = v128;\n\tif (v133) goto L_0095;\nL_0051:\n\tv149 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tv152 = *([v149 @ X0_v27 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+135]) & 1;\n\tv153 = v152 == 0;\n\tif (v153) goto L_00E4;\n\tgoto L_0061;\nL_0061:\n\tgoto L_006D;\nL_006D:\n\tgoto L_006F;\nL_006F:\n\tv294 = new Il2CppClass<System.Func`2<T, System.Boolean>>();\n\tSystem.Func`2<System.Object, System.Boolean>::.ctor(v294, v236.<>9, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv317 = Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>;\n\tgoto L_0081;\nL_0081:\n\tv318 = *([v317 @ X0_v37 (Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+B8]);\n\t*([v318 @ X8_v40 (Il2CppStaticFields<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>)+8]) = v294;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = v294;\nL_FFFFFFFF:\n\tv127 = v128;\nL_0095:\n\tv142 = System.Linq.Enumerable::FirstOrDefault(v127, v124);\n\t*([state @ X1 (T&)]) = v142;\n\tv161 = *([state @ X1 (T&)]) == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_00D3;\n\tgoto L_00AA;\nL_00AA:\n\tv252 = System.Type::GetTypeFromHandle(Il2CppClass<TS>);\n\tv303 = System.Reflection.MemberInfo::get_Name(v252);\n\tv306 = System.Object::GetType(this);\n\tv328 = System.Reflection.MemberInfo::get_Name(v306);\n\tv198 = System.String::Concat(v303, \" is not added to the \", v328);\n\tgoto L_00CE;\nL_00D3:\n\tv211 = *([state @ X1 (T&)]) == 0;\n\tv216 = ~v211;\n\treturn v216;\nL_00E4:\n\tv159 = 0x220C238(Il2CppClass<Unco.StateSystem.Runtime.StateController`1<T>+<>c__4`1<T, TS>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = *([v159 @ X0_v31+E4]) == 0;\n\tv165 = ~v179;\n\tif (v165) goto L_0061;\n\tgoto L_00F1;\nL_00F1:\n\tgoto L_006D;\nL_00CE:\n\tUnityEngine.Debug::LogError(v198);\n")]
		private bool TryGetState<TS>(out T state) where TS : T
		{
			global::AssetRipperInjected.RecoveryStub.Missing("StateController::TryGetState");
			state = default;
			return default;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x4423620", Offset = "0x4423620", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tgoto L_001A;\n\tv32 = 0x220C2B8(methodInfo, il2cppRetVal, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0036;\nL_004D:\n\treturnVal1 = 0x8BF5F18(il2cppRetVal, *([v51 @ X9_v1 (Il2CppClass<TS>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0050:\n\tv99 = *([A4731E0]);\n\tv110 = *([v99 @ X9_v4]) != *([v23 @ X8_v2]);\n\tif (v110) goto L_0068;\n\treturn returnVal1;\nL_0068:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001A:\n\tv51 = Il2CppClass<TS>;\n\tv55 = *([v51 @ X9_v1 (Il2CppClass<TS>)+FC]) + 0xF;\n\tv56 = v55 & 0x1FFFFFFF0;\n\t// 31 StackAlloc v57 @ X22_v1 (System.Byte*), v56 @ X10_v2 (System.Int32)\n\tv63 = Unco.StateSystem.Runtime.StateController`1<T>::TryGetState(v46, &v62 @ stack_-50_v2 (T));\n\tv65 = v63 == 0;\n\tif (v65) goto L_004D;\nL_0036:\n\tv130 = 0x21C11D0(v62, Il2CppClass<TS>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0045;\nL_0045:\n\tv133 = 0x21C11E0(v130, Il2CppClass<TS>, v57, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x8BF6A1C(il2cppRetVal, v133, *([v51 @ X9_v1 (Il2CppClass<TS>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0050;\n")]
		public unsafe TS GetState<TS>() where TS : T
		{
			//IL_0010: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_00b9: Expected I4, but got I8
			//IL_0052: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X9_v1 (Il2CppClass<TS>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			if (!TryGetState<TS>(out var _))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5F18");
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11E0");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			TS result = default(TS);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			TS result2 = default(TS);
			return result2;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x4423750", Offset = "0x4423750", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_0015;\n\tv35 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0015:\n\tv40 = this._stateMachine;\n\tv46 = *([v40 @ X20_v2 (Unco.StateSystem.Runtime.IStateMachine)]);\n\tv140 = *([v46 @ X8_v6 (Il2CppClass<Unco.StateSystem.Runtime.IStateMachine>)+12E]);\n\tv48 = *([v46 @ X8_v6 (Il2CppClass<Unco.StateSystem.Runtime.IStateMachine>)+12E]) == 0;\n\tif (v48) goto L_003F;\n\tv95 = *([v46 @ X8_v6 (Il2CppClass<Unco.StateSystem.Runtime.IStateMachine>)+B0]) + 8;\n\tv95 = v95 + 0x10;\n\tv128 = v140 - 1;\n\tv118 = v140 != 1;\n\tv140 = v128;\n\tif (v118) goto L_0026;\nL_003F:\n\tv195 = Unco.StateSystem.Runtime.IStateMachine::get_CurrentState(v40);\nL_0043:\n\tv199 = System.Object::GetType(v195);\n\tgoto L_0051;\nL_0051:\n\tv211 = System.Type::GetTypeFromHandle(Il2CppClass<TS>);\n\treturnVal2 = System.Type::op_Equality(v199, v211);\n\treturn returnVal2;\nL_005D:\n\tv99 = *([v95 @ X10_v6]) + 1;\n\tv54 = v99 << 4;\n\tv189 = v46 + v54;\n\tv190 = v189 + 0x138;\n\t*([v190 @ X0_v17])(v195, v40, *([v190 @ X0_v17+8]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv192 = v195 == 0;\n\tv109 = ~v192;\n\tif (v109) goto L_0043;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0026:\n\tv79 = *([v95 @ X10_v6-8]) == Unco.StateSystem.Runtime.IStateMachine;\n\tif (v79) goto L_005D;\n")]
		public bool IsCurrent<TS>() where TS : T
		{
			global::AssetRipperInjected.RecoveryStub.Missing("StateController::IsCurrent");
			return default;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x6390520", Offset = "0x6390520", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0045;\n\treturnVal3 = 0x21C11D0(v169, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = returnVal3 == 0;\n\tif (v127) goto L_006E;\n\treturn returnVal3;\nL_006A:\n\treturn 0;\nL_006E:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_0045:\n\tv169 = Unco.StateSystem.Runtime.IStateMachine::get_CurrentState(this._stateMachine);\n\tgoto L_0053;\nL_0053:\n\tv201 = v169 == 0;\n\tif (v201) goto L_006A;\n")]
		public T GetCurrentState()
		{
			State currentState = _stateMachine.CurrentState;
			if (currentState != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				T val = default(T);
				if (val != null)
				{
					return val;
				}
				return (T)(object)new InvalidCastException();
			}
			return null;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x6390634", Offset = "0x6390634", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tSystem.Collections.Generic.List`1<T>::.ctor(v42);\n\tthis.States = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected StateController()
		{
			List<T> states = new List<T>();
			States = states;
		}
	}
}
