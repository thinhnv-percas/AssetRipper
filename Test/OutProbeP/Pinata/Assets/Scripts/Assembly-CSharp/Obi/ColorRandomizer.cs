using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CE14", Offset = "0x74CE14")]
	[Token(Token = "0x2000054")]
	public class ColorRandomizer : MonoBehaviour
	{
		[Token(Token = "0x400025C")]
		[FieldOffset(Offset = "0x18")]
		private ObiActor actor;

		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x20")]
		public Gradient gradient;

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x98D400", Offset = "0x98D400", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EC0E70]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20216F3]) = v44;\nL_001A:\n\tv141 = UnityEngine.Component::GetComponent(this);\n\tthis.actor = v141;\nL_001F:\n\tv154 = v141.solverIndices;\n\tv85 = v138 >= v154.Length;\n\tif (v85) goto L_0075;\n\tv142 = Obi.ObiSolver::get_colors(v141.m_Solver);\n\tv155 = this.actor;\n\tv156 = v155.solverIndices;\n\tv269 = v138 < v156.Length;\n\tv135 = ~v269;\n\tif (v135) goto L_0076;\n\tv64 = UnityEngine.Random::get_value();\n\tv62 = UnityEngine.Gradient::Evaluate(this.gradient, v64);\n\tv274 = v156[v138 @ X22_v5 (System.Int32)] < v142.Length;\n\tv131 = ~v274;\n\tif (v131) goto L_0076;\n\tv72 = v156[v138 @ X22_v5 (System.Int32)] << 4;\n\tv153 = v142 + v72;\n\t*([v153 @ X8_v16+20]) = v62;\n\tv142[v69 @ X23_v7 (System.Int32)].g = v62.g;\n\tv142[v69 @ X23_v7 (System.Int32)].b = v62.b;\n\tv142[v69 @ X23_v7 (System.Int32)].a = v62.a;\n\tv141 = this.actor;\n\tv138 = v138 + 1;\n\tv275 = this.actor == 0;\n\tv146 = ~v275;\n\tif (v146) goto L_001F;\n\tthrow System.NullReferenceException;\nL_0075:\n\treturn;\nL_0076:\n\tv273 = new System.IndexOutOfRangeException();\n\tthrow v273;\n\tthrow System.NullReferenceException;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			//IL_010d: Expected O, but got I
			ObiActor obiActor = (actor = GetComponent<ObiActor>());
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int[] solverIndices = obiActor.solverIndices;
				if (num < solverIndices.Length)
				{
					Color[] colors = obiActor.solver.colors;
					ObiActor obiActor2 = actor;
					int[] solverIndices2 = obiActor2.solverIndices;
					if (num >= solverIndices2.Length)
					{
						break;
					}
					float value = UnityEngine.Random.value;
					Color color = gradient.Evaluate(value);
					if (solverIndices2[num] >= colors.Length)
					{
						break;
					}
					int num2 = solverIndices2[num] << 4;
					object obj = (long)(IntPtr)colors + (long)num2;
					colors[num3].g = color.g;
					colors[num3].b = color.b;
					colors[num3].a = color.a;
					obiActor = actor;
					num++;
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

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x98D51C", Offset = "0x98D51C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F01A80]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216F4]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Gradient();\n\tUnityEngine.Gradient::.ctor(v42);\n\tthis.gradient = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorRandomizer()
		{
			Gradient gradient = new Gradient();
			this.gradient = gradient;
		}
	}
}
