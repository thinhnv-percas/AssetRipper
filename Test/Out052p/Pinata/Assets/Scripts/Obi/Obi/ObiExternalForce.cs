using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000053")]
	public abstract class ObiExternalForce : MonoBehaviour
	{
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x18")]
		public float intensity;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x1C")]
		public float turbulence;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x20")]
		public float turbulenceFrequency;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x24")]
		public float turbulenceSeed;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x28")]
		public ObiSolver[] affectedSolvers;

		[Token(Token = "0x6000385")]
		[Address(RVA = "0xE45E58", Offset = "0xE45E58", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EDFEB0]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2024750]) = v50;\nL_0019:\n\tv51 = this.affectedSolvers;\n\tv127 = v51.Length;\n\tv64 = v51.Length < 1;\n\tif (v64) goto L_0074;\nL_0030:\n\tv199 = v86 < v127;\n\tv118 = ~v199;\n\tif (v118) goto L_0075;\n\tgoto L_004A;\n\tv232 = *([v227 @ X0_v9+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_004A;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v227, v189, v188, v69, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004A:\n\tv241 = UnityEngine.Object::op_Inequality(v51[v86 @ X23_v5 (System.Int32)], 0);\n\tv243 = v241 == 0;\n\tif (v243) goto L_005B;\n\tv122 = new Obi.ObiSolver+SolverStepCallback();\n\tObi.ObiSolver+SolverStepCallback::.ctor(v122, this, Il2CppMethodInfo);\n\tObi.ObiSolver::add_OnBeginStep(v51[v86 @ X23_v5 (System.Int32)], v122);\nL_005B:\n\tv127 = v51.Length;\n\tv86 = v86 + 1;\n\tv154 = v86 < v51.Length;\n\tif (v154) goto L_0030;\nL_0074:\n\treturn;\nL_0075:\n\tv231 = new System.IndexOutOfRangeException();\n\tthrow v231;\n\tthrow System.NullReferenceException;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			ObiSolver[] array = affectedSolvers;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				if (array[num2] != null)
				{
					ObiSolver.SolverStepCallback value = Solver_OnStepBegin;
					array[num2].OnBeginStep += value;
				}
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000386")]
		[Address(RVA = "0xE45F74", Offset = "0xE45F74", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE70A8]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2024751]) = v50;\nL_0019:\n\tv51 = this.affectedSolvers;\n\tv127 = v51.Length;\n\tv64 = v51.Length < 1;\n\tif (v64) goto L_0074;\nL_0030:\n\tv199 = v86 < v127;\n\tv118 = ~v199;\n\tif (v118) goto L_0075;\n\tgoto L_004A;\n\tv232 = *([v227 @ X0_v9+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_004A;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v227, v189, v188, v69, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004A:\n\tv241 = UnityEngine.Object::op_Inequality(v51[v86 @ X23_v5 (System.Int32)], 0);\n\tv243 = v241 == 0;\n\tif (v243) goto L_005B;\n\tv122 = new Obi.ObiSolver+SolverStepCallback();\n\tObi.ObiSolver+SolverStepCallback::.ctor(v122, this, Il2CppMethodInfo);\n\tObi.ObiSolver::remove_OnBeginStep(v51[v86 @ X23_v5 (System.Int32)], v122);\nL_005B:\n\tv127 = v51.Length;\n\tv86 = v86 + 1;\n\tv154 = v86 < v51.Length;\n\tif (v154) goto L_0030;\nL_0074:\n\treturn;\nL_0075:\n\tv231 = new System.IndexOutOfRangeException();\n\tthrow v231;\n\tthrow System.NullReferenceException;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			ObiSolver[] array = affectedSolvers;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				if (array[num2] != null)
				{
					ObiSolver.SolverStepCallback value = Solver_OnStepBegin;
					array[num2].OnBeginStep -= value;
				}
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000387")]
		[Address(RVA = "0xE46090", Offset = "0xE46090", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB5298]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, solver, methodInfo, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024752]) = v43;\nL_0018:\n\tv46 = 0;\n\tv47 = solver == 0;\n\tif (v47) goto L_004D;\n\tv49 = solver.actors == 0;\n\tif (v49) goto L_004D;\n\tv55 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(solver.actors);\nL_0029:\n\tv84 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv96 = v84 == 0;\n\tif (v96) goto L_004A;\n\tgoto L_003B;\n\tv123 = *([v99 @ X0_v21+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_003B;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v99, v82, v66, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\nL_003B:\n\tv73 = UnityEngine.Object::op_Inequality(0, 0);\n\tv76 = v73 == 0;\n\tif (v76) goto L_0029;\n\tv74 = Obi.ObiExternalForce::ApplyForcesToActor(this, 0);\n\tgoto L_0029;\nL_004A:\n\tv107 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tgoto L_006D;\nL_004D:\n\tv58 = new System.NullReferenceException();\n\tgoto L_0059;\n\tgoto L_0059;\nL_0059:\n\tv94 = solver != 1;\n\tif (v94) goto L_006E;\n\tv97 = 0x6D2BC0(v58, solver, methodInfo, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\n\tv109 = 0x6D2490(v97, solver, methodInfo, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\n\tv113 = 0xEF9AAC(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>), Il2CppMethodInfo, methodInfo, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\n\tv167 = *([v97 @ X0_v8]) == 0;\n\tv115 = ~v167;\n\tif (v115) goto L_0072;\nL_006D:\n\treturn;\nL_006E:\n\tv98 = 0x6D2380(v58, solver, methodInfo, v28, v29, v30, v31, v32, stepTime, v34, v35, v36, v37, v38, v39, v40);\nL_0072:\n\tthrow System.TypeLoadException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Solver_OnStepBegin(ObiSolver solver, float stepTime)
		{
			List<ObiActor>.Enumerator enumerator = default(List<ObiActor>.Enumerator);
			if ((object)solver != null && solver.actors != null)
			{
				List<ObiActor>.Enumerator enumerator2 = solver.actors.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if ((UnityEngine.Object)null != (UnityEngine.Object)null)
					{
						ApplyForcesToActor(null);
					}
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)solver == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0xE3DBB0", Offset = "0xE3DBB0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EEA640]);\n\tv29 = *([v28 @ X8_v9]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, turbulenceIntensity, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2024753]) = v47;\nL_0019:\n\tv49 = UnityEngine.Time::get_fixedTime();\n\tgoto L_0029;\n\tv59 = *([v55 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v32, v33, v34, v35, v36, v37, v49, v38, v39, v40, v41, v42, v43, v44);\nL_0029:\n\tv66 = v49 * this.turbulenceFrequency;\n\tv69 = UnityEngine.Mathf::PerlinNoise(v66, this.turbulenceSeed);\n\treturnVal1 = v69 * turbulenceIntensity;\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal float GetTurbulence(float turbulenceIntensity)
		{
			float fixedTime = Time.fixedTime;
			float x = fixedTime * turbulenceFrequency;
			float num = Mathf.PerlinNoise(x, turbulenceSeed);
			return num * turbulenceIntensity;
		}

		[Token(Token = "0x6000389")]
		public abstract void ApplyForcesToActor(ObiActor actor);

		[Token(Token = "0x600038A")]
		[Address(RVA = "0xE3DD70", Offset = "0xE3DD70", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.turbulenceFrequency = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiExternalForce()
		{
			turbulenceFrequency = 1f;
		}
	}
}
