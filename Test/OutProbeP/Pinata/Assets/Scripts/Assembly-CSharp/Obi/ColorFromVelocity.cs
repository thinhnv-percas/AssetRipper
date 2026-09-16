using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CDB0", Offset = "0x74CDB0")]
	[Token(Token = "0x2000053")]
	public class ColorFromVelocity : MonoBehaviour
	{
		[Token(Token = "0x400025A")]
		[FieldOffset(Offset = "0x18")]
		private ObiActor actor;

		[Token(Token = "0x400025B")]
		[FieldOffset(Offset = "0x20")]
		public float sensibility;

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x98D160", Offset = "0x98D160", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFBE40]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216F1]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.actor = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiActor component = GetComponent<ObiActor>();
			actor = component;
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x98D1B8", Offset = "0x98D1B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnEnable()
		{
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x98D1BC", Offset = "0x98D1BC", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1F00780]);\n\tv39 = *([v38 @ X8_v21]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([20216F2]) = v58;\nL_001F:\n\tv61 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv63 = v61 == 0;\n\tif (v63) goto L_00C1;\n\tv64 = this.actor;\n\tgoto L_0036;\n\tv325 = *([v205 @ X0_v8+E0]);\n\tv326 = v325 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_0036;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v205, v60, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0036:\n\tv175 = UnityEngine.Object::op_Equality(v64.m_Solver, 0);\n\tv333 = v175 == 0;\n\tv179 = ~v333;\n\tif (v179) goto L_00C1;\n\tv184 = this.actor;\nL_0044:\n\tv172 = v184.solverIndices;\n\tv338 = v156 < v172.Length;\n\tv140 = ~v338;\n\tv108 = v156 >= v172.Length;\n\tif (v108) goto L_00C1;\n\tif (v140) goto L_00C3;\n\tv359 = Obi.ObiSolver::get_velocities(v184.m_Solver);\n\tv364 = *([v359 @ X0_v19 (Obi.ObiNativeVector4List)]);\n\tv250 = Obi.ObiNativeVector4List::get_Item(v359, v172[v156 @ X22_v5 (System.Int32)]);\n\tv257 = this.actor;\n\tv366 = Obi.ObiSolver::get_colors(v257.m_Solver);\n\tgoto L_007B;\n\tv370 = *([v258 @ X8_v14+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_007B;\n\tv381 = v258;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v381, v365, v243, v43, v44, v45, v46, v47, v85, v82, v79, v76, v52, v53, v54, v55);\nL_007B:\n\tv376 = 0 / this.sensibility;\n\tv380 = UnityEngine.Mathf::Clamp(v376, -1f, 1f);\n\tv386 = v82 / this.sensibility;\n\tv387 = UnityEngine.Mathf::Clamp(v386, -1f, 1f);\n\tv392 = v79 / this.sensibility;\n\tv393 = UnityEngine.Mathf::Clamp(v392, -1f, 1f);\n\tv394 = v380 * 0.5f;\n\tv395 = v387 * 0.5f;\n\tv396 = v393 * 0.5f;\n\tv214 = v394 + 0.5f;\n\tv82 = v395 + 0.5f;\n\tv79 = v396 + 0.5f;\n\tv209 = 0;\n\tv249 = 0x101059C(&v209 @ stack_-80_v5, 0, *([v364 @ X8_v12 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v43, v44, v45, v46, v47, v214, v82, v79, 1f, v52, v53, v54, v55);\n\tv398 = v172[v156 @ X22_v5 (System.Int32)] < v366.Length;\n\tv239 = ~v398;\n\tif (v239) goto L_00C3;\n\tv222 = v172[v156 @ X22_v5 (System.Int32)] << 4;\n\tv399 = v366 + v222;\n\tv156 = v156 + 1;\n\t*([v399 @ X8_v16+20]) = 0;\n\tv184 = this.actor;\n\tv400 = this.actor == 0;\n\tv251 = ~v400;\n\tif (v251) goto L_0044;\n\tthrow System.NullReferenceException;\nL_00C1:\n\treturn;\n\tv351 = new System.NullReferenceException();\nL_00C3:\n\tv356 = new System.IndexOutOfRangeException();\n\tthrow v356;\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			//IL_00da: Expected I, but got O
			//IL_0201: Expected O, but got I4
			//IL_026c: Expected O, but got I
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			ObiActor obiActor = actor;
			if (obiActor.solver == null)
			{
				return;
			}
			ObiActor obiActor2 = actor;
			int num = 0;
			float num3 = default(float);
			float num5 = default(float);
			while (true)
			{
				int[] solverIndices = obiActor2.solverIndices;
				bool flag = num < solverIndices.Length;
				bool flag2 = !flag;
				if (num < solverIndices.Length)
				{
					if (flag2)
					{
						break;
					}
					ObiNativeVector4List velocities = obiActor2.solver.velocities;
					IntPtr intPtr = (IntPtr)velocities;
					Vector4 vector = velocities.get_Item(solverIndices[num]);
					ObiActor obiActor3 = actor;
					Color[] colors = obiActor3.solver.colors;
					float value = 0f / sensibility;
					float num2 = Mathf.Clamp(value, -1f, 1f);
					float value2 = num3 / sensibility;
					float num4 = Mathf.Clamp(value2, -1f, 1f);
					float value3 = num5 / sensibility;
					float num6 = Mathf.Clamp(value3, -1f, 1f);
					float num7 = num2 * 0.5f;
					float num8 = num4 * 0.5f;
					float num9 = num6 * 0.5f;
					float num10 = num7 + 0.5f;
					num3 = num8 + 0.5f;
					num5 = num9 + 0.5f;
					object obj = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
					if (solverIndices[num] >= colors.Length)
					{
						break;
					}
					int num11 = solverIndices[num] << 4;
					object obj2 = (long)(IntPtr)colors + (long)num11;
					num++;
					_ = 0;
					obiActor2 = actor;
					if ((object)actor == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x98D3EC", Offset = "0x98D3EC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sensibility = 0.2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorFromVelocity()
		{
			sensibility = 0.2f;
		}
	}
}
