using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000046")]
	public abstract class ObiUpdater : MonoBehaviour
	{
		[Token(Token = "0x400015E")]
		private static ProfilerMarker m_BeginStepPerfMarker;

		[Token(Token = "0x400015F")]
		private static ProfilerMarker m_SubstepPerfMarker;

		[Token(Token = "0x4000160")]
		private static ProfilerMarker m_EndStepPerfMarker;

		[Token(Token = "0x4000161")]
		private static ProfilerMarker m_InterpolatePerfMarker;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x18")]
		public List<ObiSolver> solvers;

		[Token(Token = "0x6000360")]
		[Address(RVA = "0x1031178", Offset = "0x1031178", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = &v17 @ X29;\n\tgoto L_001B;\n\tv31 = *([1ECCBE0]);\n\tv32 = *([v31 @ X8_v34]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, stepDeltaTime, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202627B]) = v50;\nL_001B:\n\tv51 = &v52 @ stack_-A0;\n\t*([v17 @ X29-58]) = 0;\n\t*([v17 @ X29-50]) = 0;\n\t*([v17 @ X29-60]) = 0;\n\tgoto L_0031;\n\tv60 = *([v56 @ X0_v2 (Il2CppClass<Obi.ObiUpdater>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v35, v36, v37, v38, v39, v40, stepDeltaTime, v41, v42, v43, v44, v45, v46, v47);\n\tv64 = Obi.ObiUpdater;\nL_0031:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v67.m_BeginStepPerfMarker);\n\tgoto L_003F;\n\tv78 = *([v74 @ X0_v5+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_003F;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v74, v68, v35, v36, v37, v38, v39, v40, stepDeltaTime, v41, v42, v43, v44, v45, v46, v47);\nL_003F:\n\tObi.ObiColliderBase::UpdateColliders();\n\tv86 = Oni::CreateEmpty();\n\tv89 = this.solvers == 0;\n\tif (v89) goto L_007A;\n\tv94 = System.Collections.Generic.List`1<Obi.ObiSolver>::GetEnumerator(this.solvers);\n\tv170 = *([v17 @ X29-78]);\n\t*([v17 @ X29-50]) = *([v17 @ X29-68]);\n\t*([v17 @ X29-60]) = *([v17 @ X29-78]);\nL_0053:\n\tv130 = &v17 @ X29 - 0x60;\n\tv131 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::MoveNext(v130);\n\tv143 = v131 == 0;\n\tif (v143) goto L_0076;\n\tgoto L_0066;\n\tv202 = *([v191 @ X0_v39+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0066;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v191, v129, v118, v36, v37, v38, v39, v40, v102, v41, v42, v43, v44, v45, v46, v47);\nL_0066:\n\tv123 = UnityEngine.Object::op_Inequality(*([v17 @ X29-50]), 0);\n\tv126 = v123 == 0;\n\tif (v126) goto L_0053;\n\tv327 = Obi.ObiSolver::BeginStep(*([v17 @ X29-50]), stepDeltaTime);\n\tOni::AddChild(v86, v327);\n\tgoto L_0053;\nL_0076:\n\t*([v51 @ X22_v1]) = 0x5B;\n\tgoto L_0092;\n\tv106 = new System.NullReferenceException();\nL_007A:\n\tv113 = new System.NullReferenceException();\n\tgoto L_0089;\n\tgoto L_00D3;\n\tgoto L_0089;\n\tgoto L_0089;\n\tgoto L_0089;\nL_0089:\n\tv141 = 0 != 1;\n\tif (v141) goto L_00D3;\n\tv144 = 0x6D2BC0(v113, 0, 0, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\n\tv178 = *([v144 @ X0_v33]);\n\tv199 = 0x6D2490(v144, 0, 0, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\nL_0092:\n\tv236 = &v17 @ X29 - 0x60;\n\tv237 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::Dispose(v236);\n\tv252 = v339 + 1;\n\tv254 = v252 == 0;\n\tif (v254) goto L_00A8;\n\tv267 = *([v51 @ X22_v1+v339 @ X24_v2 (System.Int32)*4]) != 0x5B;\n\tif (v267) goto L_00A8;\n\tgoto L_00AC;\nL_00A8:\n\tv268 = v178 == 0;\n\tv176 = ~v268;\n\tif (v176) goto L_00C6;\nL_00AC:\n\tOni::Schedule(v86);\n\tOni::Complete(v86);\n\tgoto L_00BA;\n\tv368 = *([v364 @ X0_v15+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_00BA;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v364, v235, v227, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\nL_00BA:\n\tObi.ObiColliderBase::ResetColliderTransforms();\n\tv345 = v339 << 2;\n\tv354 = &v52 @ stack_-A0 + v345;\n\t*([v354 @ X8_v14+4]) = 0x7C;\n\tUnity.Profiling.ProfilerMarker::Internal_End(v67.m_BeginStepPerfMarker);\n\tgoto L_00EA;\nL_00C6:\n\tv174 = new System.TypeLoadException();\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\nL_00D3:\n\tv190 = v171 != 1;\n\tif (v190) goto L_00EB;\n\tv200 = 0x6D2BC0(v113, v171, v163, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\n\tv239 = 0x6D2490(v200, v171, v163, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v67.m_BeginStepPerfMarker);\n\tv269 = *([v200 @ X0_v28]) == 0;\n\tv246 = ~v269;\n\tif (v246) goto L_00EF;\nL_00EA:\n\treturn;\nL_00EB:\n\tv201 = 0x6D2380(v113, v171, v163, v36, v37, v38, v39, v40, v170, v41, v42, v43, v44, v45, v46, v47);\nL_00EF:\n\tthrow System.TypeLoadException;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void BeginStep(float stepDeltaTime)
		{
			//IL_0315: Expected I, but got O
			//IL_006c: Expected F4, but got I
			//IL_0329: Expected O, but got I
			//IL_0161: Expected I4, but got O
			//IL_0104: Expected O, but got I4
			//IL_0362: Expected O, but got I
			//IL_02a9: Expected I, but got O
			//IL_00a2: Expected O, but got I
			//IL_00d8: Expected O, but got I
			//IL_021e: Expected O, but got I
			//IL_022e: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			ProfilerMarker.Internal_Begin((IntPtr)m_BeginStepPerfMarker);
			ObiColliderBase.UpdateColliders();
			IntPtr task = Oni.CreateEmpty();
			bool flag = solvers == null;
			int num = 0;
			UnityEngine.Object obj4 = null;
			int num3;
			int num4;
			NullReferenceException ex;
			if (!flag)
			{
				List<ObiSolver>.Enumerator enumerator = solvers.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X29-78]");
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X29-68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X29-78]");
				_ = 0;
				while (true)
				{
					List<ObiSolver>.Enumerator enumerator2 = (List<ObiSolver>.Enumerator)((long)(IntPtr)obj - 96L);
					if (!((List<ObiSolver>.Enumerator*)enumerator2)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X29-50]");
					if ((UnityEngine.Object)0 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X29-50]");
						IntPtr child = ((ObiSolver)0).BeginStep(stepDeltaTime);
						Oni.AddChild(task, child);
						num2 = stepDeltaTime;
					}
				}
				obj2 = 91;
				num3 = 0;
				num4 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_025c;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num4 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num3 = -1;
			}
			List<ObiSolver>.Enumerator enumerator3 = (List<ObiSolver>.Enumerator)((long)(IntPtr)obj - 96L);
			((List<ObiSolver>.Enumerator*)enumerator3)->Dispose();
			if (num3 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X22_v1+v339 @ X24_v2 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)91)
				{
					num3 = -1;
					goto IL_01e1;
				}
			}
			if (num4 == 0)
			{
				goto IL_01e1;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			obj4 = null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_025c;
			IL_025c:
			if ((IntPtr)obj4 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				ProfilerMarker.Internal_End((IntPtr)m_BeginStepPerfMarker);
				object obj6 = default(object);
				if (obj6 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_01e1:
			Oni.Schedule(task);
			Oni.Complete(task);
			ObiColliderBase.ResetColliderTransforms();
			int num5 = num3 << 2;
			object obj7 = (long)(IntPtr)obj3 + (long)num5;
			_ = 124;
			ProfilerMarker.Internal_End((IntPtr)m_BeginStepPerfMarker);
		}

		[Token(Token = "0x6000361")]
		[Address(RVA = "0x1031670", Offset = "0x1031670", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = &v19 @ X29;\n\tgoto L_001C;\n\tv33 = *([1EC3508]);\n\tv34 = *([v33 @ X8_v40]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, substepDeltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202627C]) = v52;\nL_001C:\n\tv53 = &v54 @ stack_-B0;\n\t*([v19 @ X29-68]) = 0;\n\t*([v19 @ X29-60]) = 0;\n\t*([v19 @ X29-70]) = 0;\n\tgoto L_0032;\n\tv62 = *([v58 @ X0_v2 (Il2CppClass<Obi.ObiUpdater>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, substepDeltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv66 = Obi.ObiUpdater;\nL_0032:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v69.m_SubstepPerfMarker);\n\tgoto L_0040;\n\tv80 = *([v76 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_0040;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v76, v70, v37, v38, v39, v40, v41, v42, substepDeltaTime, v43, v44, v45, v46, v47, v48, v49);\nL_0040:\n\tObi.ObiColliderBase::UpdateColliders();\n\tgoto L_004E;\n\tv94 = *([v90 @ X0_v8+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_004E;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v90, v70, v37, v38, v39, v40, v41, v42, substepDeltaTime, v43, v44, v45, v46, v47, v48, v49);\nL_004E:\n\tObi.ObiRigidbodyBase::UpdateAllRigidbodies();\n\tv102 = Oni::CreateEmpty();\n\tv105 = this.solvers == 0;\n\tif (v105) goto L_0089;\n\tv110 = System.Collections.Generic.List`1<Obi.ObiSolver>::GetEnumerator(this.solvers);\n\tv186 = *([v19 @ X29-88]);\n\t*([v19 @ X29-60]) = *([v19 @ X29-78]);\n\t*([v19 @ X29-70]) = *([v19 @ X29-88]);\nL_0062:\n\tv146 = &v19 @ X29 - 0x70;\n\tv147 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::MoveNext(v146);\n\tv159 = v147 == 0;\n\tif (v159) goto L_0085;\n\tgoto L_0075;\n\tv218 = *([v207 @ X0_v46+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_0075;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v207, v145, v134, v38, v39, v40, v41, v42, v118, v43, v44, v45, v46, v47, v48, v49);\nL_0075:\n\tv139 = UnityEngine.Object::op_Inequality(*([v19 @ X29-60]), 0);\n\tv142 = v139 == 0;\n\tif (v142) goto L_0062;\n\tv345 = Obi.ObiSolver::Substep(*([v19 @ X29-60]), substepDeltaTime);\n\tOni::AddChild(v102, v345);\n\tgoto L_0062;\nL_0085:\n\t*([v53 @ X22_v1]) = 0x60;\n\tgoto L_00A1;\n\tv122 = new System.NullReferenceException();\nL_0089:\n\tv129 = new System.NullReferenceException();\n\tgoto L_0098;\n\tgoto L_00EE;\n\tgoto L_0098;\n\tgoto L_0098;\n\tgoto L_0098;\nL_0098:\n\tv157 = 0 != 1;\n\tif (v157) goto L_00EE;\n\tv160 = 0x6D2BC0(v129, 0, 0, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\n\tv194 = *([v160 @ X0_v40]);\n\tv215 = 0x6D2490(v160, 0, 0, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\nL_00A1:\n\tv252 = &v19 @ X29 - 0x70;\n\tv253 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::Dispose(v252);\n\tv268 = v357 + 1;\n\tv270 = v268 == 0;\n\tif (v270) goto L_00B7;\n\tv283 = *([v53 @ X22_v1+v357 @ X25_v2 (System.Int32)*4]) != 0x60;\n\tif (v283) goto L_00B7;\n\tgoto L_00BB;\nL_00B7:\n\tv284 = v194 == 0;\n\tv192 = ~v284;\n\tif (v192) goto L_00E1;\nL_00BB:\n\tOni::Schedule(v102);\n\tOni::Complete(v102);\n\tgoto L_00C9;\n\tv386 = *([v382 @ X0_v18+E0]);\n\tv387 = v386 == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_00C9;\n\tv390 = \"il2cpp_codegen_runtime_class_init\"(v382, v251, v243, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\nL_00C9:\n\tObi.ObiRigidbodyBase::UpdateAllVelocities();\n\tgoto L_00D5;\n\tv398 = *([v394 @ X0_v21+E0]);\n\tv399 = v398 == 0;\n\tv400 = ~v399;\n\tif (v400) goto L_00D5;\n\tv402 = \"il2cpp_codegen_runtime_class_init\"(v394, v251, v243, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\nL_00D5:\n\tObi.ObiColliderBase::ResetColliderTransforms();\n\tv363 = v357 << 2;\n\tv372 = &v54 @ stack_-B0 + v363;\n\t*([v372 @ X8_v18+4]) = 0x86;\n\tUnity.Profiling.ProfilerMarker::Internal_End(v69.m_SubstepPerfMarker);\n\tgoto L_0106;\nL_00E1:\n\tv190 = new System.TypeLoadException();\n\tgoto L_00EE;\n\tgoto L_00EE;\n\tgoto L_00EE;\nL_00EE:\n\tv206 = v187 != 1;\n\tif (v206) goto L_0107;\n\tv216 = 0x6D2BC0(v129, v187, v179, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\n\tv255 = 0x6D2490(v216, v187, v179, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v69.m_SubstepPerfMarker);\n\tv285 = *([v216 @ X0_v35]) == 0;\n\tv262 = ~v285;\n\tif (v262) goto L_010B;\nL_0106:\n\treturn;\nL_0107:\n\tv217 = 0x6D2380(v129, v187, v179, v38, v39, v40, v41, v42, v186, v43, v44, v45, v46, v47, v48, v49);\nL_010B:\n\tthrow System.TypeLoadException;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void Substep(float substepDeltaTime)
		{
			//IL_0329: Expected I, but got O
			//IL_0076: Expected F4, but got I
			//IL_033d: Expected O, but got I
			//IL_016b: Expected I4, but got O
			//IL_010e: Expected O, but got I4
			//IL_0376: Expected O, but got I
			//IL_02bd: Expected I, but got O
			//IL_00ac: Expected O, but got I
			//IL_00e2: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_0242: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			ProfilerMarker.Internal_Begin((IntPtr)m_SubstepPerfMarker);
			ObiColliderBase.UpdateColliders();
			ObiRigidbodyBase.UpdateAllRigidbodies();
			IntPtr task = Oni.CreateEmpty();
			bool flag = solvers == null;
			int num = 0;
			UnityEngine.Object obj4 = null;
			int num3;
			int num4;
			NullReferenceException ex;
			if (!flag)
			{
				List<ObiSolver>.Enumerator enumerator = solvers.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-88]");
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-78]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-88]");
				_ = 0;
				while (true)
				{
					List<ObiSolver>.Enumerator enumerator2 = (List<ObiSolver>.Enumerator)((long)(IntPtr)obj - 112L);
					if (!((List<ObiSolver>.Enumerator*)enumerator2)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-60]");
					if ((UnityEngine.Object)0 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X29-60]");
						IntPtr child = ((ObiSolver)0).Substep(substepDeltaTime);
						Oni.AddChild(task, child);
						num2 = substepDeltaTime;
					}
				}
				obj2 = 96;
				num3 = 0;
				num4 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_0270;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num4 = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num3 = -1;
			}
			List<ObiSolver>.Enumerator enumerator3 = (List<ObiSolver>.Enumerator)((long)(IntPtr)obj - 112L);
			((List<ObiSolver>.Enumerator*)enumerator3)->Dispose();
			if (num3 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X22_v1+v357 @ X25_v2 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)96)
				{
					num3 = -1;
					goto IL_01eb;
				}
			}
			if (num4 == 0)
			{
				goto IL_01eb;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			obj4 = null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_0270;
			IL_0270:
			if ((IntPtr)obj4 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				ProfilerMarker.Internal_End((IntPtr)m_SubstepPerfMarker);
				object obj6 = default(object);
				if (obj6 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_01eb:
			Oni.Schedule(task);
			Oni.Complete(task);
			ObiRigidbodyBase.UpdateAllVelocities();
			ObiColliderBase.ResetColliderTransforms();
			int num5 = num3 << 2;
			object obj7 = (long)(IntPtr)obj3 + (long)num5;
			_ = 134;
			ProfilerMarker.Internal_End((IntPtr)m_SubstepPerfMarker);
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0x1031958", Offset = "0x1031958", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EFB678]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202627D]) = v42;\nL_001E:\n\tgoto L_0029;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<Obi.ObiUpdater>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = Obi.ObiUpdater;\nL_0029:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v59.m_EndStepPerfMarker);\n\tv65 = this.solvers == 0;\n\tif (v65) goto L_005C;\n\tv71 = System.Collections.Generic.List`1<Obi.ObiSolver>::GetEnumerator(this.solvers);\nL_003C:\n\tv112 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::MoveNext(&v70 @ stack_-68_v5 (System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>));\n\tv124 = v112 == 0;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_004E;\n\tv212 = *([v169 @ X0_v30+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_004E;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v169, v110, v101, v27, v28, v29, v30, v31, v83, v33, v34, v35, v36, v37, v38, v39);\nL_004E:\n\tv104 = UnityEngine.Object::op_Inequality(v98, 0);\n\tv107 = v104 == 0;\n\tif (v107) goto L_003C;\n\tObi.ObiSolver::EndStep(v98);\n\tgoto L_003C;\n\tgoto L_0074;\n\tv89 = new System.NullReferenceException();\nL_005C:\n\tv96 = new System.NullReferenceException();\n\tgoto L_006A;\n\t// 94 Jump @b36\n\tgoto L_006A;\n\tgoto L_006A;\nL_006A:\n\tv122 = 0 != 1;\n\tif (v122) goto L_0091;\n\tv125 = 0x6D2BC0(v96, 0, 0, v27, v28, v29, v30, v31, v70, v33, v34, v35, v36, v37, v38, v39);\n\tv165 = *([v125 @ X0_v24]);\n\tv177 = 0x6D2490(v125, 0, 0, v27, v28, v29, v30, v31, v70, v33, v34, v35, v36, v37, v38, v39);\nL_0074:\n\tv241 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::Dispose(&v76 @ stack_-50_v5 (System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>));\n\tv245 = v153 + 1;\n\tv137 = v245 == 0;\n\tv127 = ~v137;\n\tif (v127) goto L_0081;\n\tv259 = v165 == 0;\n\tv163 = ~v259;\n\tif (v163) goto L_0086;\nL_0081:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v59.m_EndStepPerfMarker);\n\tgoto L_00AA;\nL_0086:\n\tv200 = new System.TypeLoadException();\nL_0091:\n\tv211 = v198 != 1;\n\tif (v211) goto L_00AB;\n\tv242 = 0x6D2BC0(v200, v198, v196, v27, v28, v29, v30, v31, v155, v33, v34, v35, v36, v37, v38, v39);\n\tv247 = 0x6D2490(v242, v198, v196, v27, v28, v29, v30, v31, v155, v33, v34, v35, v36, v37, v38, v39);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v59.m_EndStepPerfMarker);\n\tv265 = 0xFFFFFFFF + 1;\n\tv250 = v265 == 0;\n\tv248 = ~v250;\n\tif (v248) goto L_00AA;\n\tv293 = *([v242 @ X0_v13]) == 0;\n\tv257 = ~v293;\n\tif (v257) goto L_00AF;\nL_00AA:\n\treturn;\nL_00AB:\n\tv243 = 0x6D2380(v200, v198, v196, v27, v28, v29, v30, v31, v155, v33, v34, v35, v36, v37, v38, v39);\nL_00AF:\n\tv200 = new System.TypeLoadException();\n\tgoto L_0091;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void EndStep()
		{
			//IL_024b: Expected I, but got O
			//IL_00cc: Expected I4, but got O
			//IL_01a8: Expected I, but got O
			//IL_01bb: Expected O, but got I8
			//IL_015a: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_EndStepPerfMarker);
			bool flag = solvers == null;
			int num = 0;
			List<ObiSolver>.Enumerator enumerator2 = default(List<ObiSolver>.Enumerator);
			List<ObiSolver>.Enumerator enumerator = enumerator2;
			List<ObiSolver>.Enumerator enumerator3 = enumerator2;
			UnityEngine.Object obj = null;
			int num2;
			int num3;
			TypeLoadException ex2;
			if (!flag)
			{
				List<ObiSolver>.Enumerator enumerator4 = solvers.GetEnumerator();
				UnityEngine.Object obj2 = default(UnityEngine.Object);
				while (enumerator2.MoveNext())
				{
					if (obj2 != null)
					{
						((ObiSolver)obj2).EndStep();
					}
				}
				enumerator = enumerator2;
				num2 = 0;
				enumerator3 = enumerator2;
				num3 = 0;
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				bool flag2 = 0 != 1;
				ex2 = (TypeLoadException)(object)ex;
				if (flag2)
				{
					goto IL_02b2;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num3 = (int)obj3;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num2 = -1;
			}
			enumerator.Dispose();
			if (num2 + 1 != 0 || num3 == 0)
			{
				ProfilerMarker.Internal_End((IntPtr)m_EndStepPerfMarker);
				return;
			}
			ex2 = new TypeLoadException();
			num = 0;
			obj = null;
			goto IL_02b2;
			IL_02b2:
			object obj5 = default(object);
			while (true)
			{
				if ((IntPtr)obj == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					ProfilerMarker.Internal_End((IntPtr)m_EndStepPerfMarker);
					object obj4 = 4294967295L + 1;
					if (obj4 != null || obj5 == null)
					{
						break;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				}
				ex2 = new TypeLoadException();
				num = 0;
				obj = null;
			}
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0x1031B3C", Offset = "0x1031B3C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EEA4B0]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, stepDeltaTime, accumulatedTime, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202627E]) = v48;\nL_0022:\n\tgoto L_002D;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<Obi.ObiUpdater>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002D;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v34, v35, v36, v37, v38, v39, stepDeltaTime, accumulatedTime, v40, v41, v42, v43, v44, v45);\n\tv62 = Obi.ObiUpdater;\nL_002D:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v65.m_InterpolatePerfMarker);\n\tv71 = this.solvers == 0;\n\tif (v71) goto L_0062;\n\tv77 = System.Collections.Generic.List`1<Obi.ObiSolver>::GetEnumerator(this.solvers);\nL_0040:\n\tv123 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::MoveNext(&v76 @ stack_-78_v5 (System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>));\n\tv135 = v123 == 0;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_0052;\n\tv225 = *([v182 @ X0_v30+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tif (v227) goto L_0052;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v182, v121, v111, v35, v36, v37, v38, v39, v91, v79, v40, v41, v42, v43, v44, v45);\nL_0052:\n\tv115 = UnityEngine.Object::op_Inequality(v106, 0);\n\tv118 = v115 == 0;\n\tif (v118) goto L_0040;\n\tObi.ObiSolver::Interpolate(v106, stepDeltaTime, accumulatedTime);\n\tgoto L_0040;\n\tgoto L_007A;\n\tv97 = new System.NullReferenceException();\nL_0062:\n\tv104 = new System.NullReferenceException();\n\tgoto L_0070;\n\t// 100 Jump @b36\n\tgoto L_0070;\n\tgoto L_0070;\nL_0070:\n\tv133 = 0 != 1;\n\tif (v133) goto L_0097;\n\tv136 = 0x6D2BC0(v104, 0, 0, v35, v36, v37, v38, v39, v168, v156, v40, v41, v42, v43, v44, v45);\n\tv178 = *([v136 @ X0_v24]);\n\tv190 = 0x6D2490(v136, 0, 0, v35, v36, v37, v38, v39, v168, v156, v40, v41, v42, v43, v44, v45);\nL_007A:\n\tv254 = System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>::Dispose(&v84 @ stack_-60_v5 (System.Collections.Generic.List`1<Obi.ObiSolver>+Enumerator<Obi.ObiSolver>));\n\tv258 = v166 + 1;\n\tv148 = v258 == 0;\n\tv138 = ~v148;\n\tif (v138) goto L_0087;\n\tv272 = v178 == 0;\n\tv176 = ~v272;\n\tif (v176) goto L_008C;\nL_0087:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v65.m_InterpolatePerfMarker);\n\tgoto L_00B2;\nL_008C:\n\tv213 = new System.TypeLoadException();\nL_0097:\n\tv224 = v211 != 1;\n\tif (v224) goto L_00B3;\n\tv255 = 0x6D2BC0(v213, v211, v209, v35, v36, v37, v38, v39, v168, v156, v40, v41, v42, v43, v44, v45);\n\tv260 = 0x6D2490(v255, v211, v209, v35, v36, v37, v38, v39, v168, v156, v40, v41, v42, v43, v44, v45);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v65.m_InterpolatePerfMarker);\n\tv278 = 0xFFFFFFFF + 1;\n\tv263 = v278 == 0;\n\tv261 = ~v263;\n\tif (v261) goto L_00B2;\n\tv309 = *([v255 @ X0_v13]) == 0;\n\tv270 = ~v309;\n\tif (v270) goto L_00B7;\nL_00B2:\n\treturn;\nL_00B3:\n\tv256 = 0x6D2380(v213, v211, v209, v35, v36, v37, v38, v39, v168, v156, v40, v41, v42, v43, v44, v45);\nL_00B7:\n\tv213 = new System.TypeLoadException();\n\tgoto L_0097;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Interpolate(float stepDeltaTime, float accumulatedTime)
		{
			//IL_026b: Expected I, but got O
			//IL_0024: Expected F4, but got O
			//IL_00ec: Expected I4, but got O
			//IL_01c8: Expected I, but got O
			//IL_01db: Expected O, but got I8
			//IL_017a: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_InterpolatePerfMarker);
			bool flag = solvers == null;
			int num = 0;
			List<ObiSolver>.Enumerator enumerator2 = default(List<ObiSolver>.Enumerator);
			List<ObiSolver>.Enumerator enumerator = enumerator2;
			UnityEngine.Object obj = null;
			int num4;
			int num5;
			TypeLoadException ex2;
			if (!flag)
			{
				List<ObiSolver>.Enumerator enumerator3 = solvers.GetEnumerator();
				float num2 = accumulatedTime;
				float num3 = (float)enumerator2;
				UnityEngine.Object obj2 = default(UnityEngine.Object);
				while (enumerator2.MoveNext())
				{
					if (obj2 != null)
					{
						((ObiSolver)obj2).Interpolate(stepDeltaTime, accumulatedTime);
						num2 = accumulatedTime;
						num3 = stepDeltaTime;
					}
				}
				enumerator = enumerator2;
				num4 = 0;
				num5 = 0;
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				bool flag2 = 0 != 1;
				ex2 = (TypeLoadException)(object)ex;
				if (flag2)
				{
					goto IL_02ca;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num5 = (int)obj3;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num4 = -1;
			}
			enumerator.Dispose();
			if (num4 + 1 != 0 || num5 == 0)
			{
				ProfilerMarker.Internal_End((IntPtr)m_InterpolatePerfMarker);
				return;
			}
			ex2 = new TypeLoadException();
			num = 0;
			obj = null;
			goto IL_02ca;
			IL_02ca:
			object obj5 = default(object);
			while (true)
			{
				if ((IntPtr)obj == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					ProfilerMarker.Internal_End((IntPtr)m_InterpolatePerfMarker);
					object obj4 = 4294967295L + 1;
					if (obj4 != null || obj5 == null)
					{
						break;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				}
				ex2 = new TypeLoadException();
				num = 0;
				obj = null;
			}
		}

		[Token(Token = "0x6000364")]
		[Address(RVA = "0x1031D38", Offset = "0x1031D38", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDFD68]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202627F]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<Obi.ObiSolver>();\n\tSystem.Collections.Generic.List`1<Obi.ObiSolver>::.ctor(v42);\n\tthis.solvers = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiUpdater()
		{
			List<ObiSolver> list = new List<ObiSolver>();
			solvers = list;
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0x1031DA8", Offset = "0x1031DA8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EDDF18]);\n\tv15 = *([v14 @ X8_v20]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026280]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"BeginStep\", 0);\n\tv47.m_BeginStepPerfMarker = v41;\n\tv51 = Unity.Profiling.ProfilerMarker::Internal_Create(\"Substep\", 0);\n\tv55.m_SubstepPerfMarker = v51;\n\tv59 = Unity.Profiling.ProfilerMarker::Internal_Create(\"EndStep\", 0);\n\tv63.m_EndStepPerfMarker = v59;\n\tv67 = Unity.Profiling.ProfilerMarker::Internal_Create(\"Interpolate\", 0);\n\tv69.m_InterpolatePerfMarker = v67;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiUpdater()
		{
			//IL_0059: Expected O, but got I
			//IL_007e: Expected O, but got I
			//IL_000e: Expected O, but got I
			//IL_0033: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("BeginStep", default(Unity.Profiling.MarkerFlags));
			m_BeginStepPerfMarker = (ProfilerMarker)(long)intPtr;
			IntPtr intPtr2 = ProfilerMarker.Internal_Create("Substep", default(Unity.Profiling.MarkerFlags));
			m_SubstepPerfMarker = (ProfilerMarker)(long)intPtr2;
			IntPtr intPtr3 = ProfilerMarker.Internal_Create("EndStep", default(Unity.Profiling.MarkerFlags));
			m_EndStepPerfMarker = (ProfilerMarker)(long)intPtr3;
			IntPtr intPtr4 = ProfilerMarker.Internal_Create("Interpolate", default(Unity.Profiling.MarkerFlags));
			m_InterpolatePerfMarker = (ProfilerMarker)(long)intPtr4;
		}
	}
}
