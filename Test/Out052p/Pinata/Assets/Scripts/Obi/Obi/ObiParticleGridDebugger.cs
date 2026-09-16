using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744B38", Offset = "0x744B38")]
	[Token(Token = "0x2000057")]
	public class ObiParticleGridDebugger : MonoBehaviour
	{
		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x18")]
		private ObiSolver solver;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x20")]
		private Oni.GridCell[] cells;

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0xC29B78", Offset = "0xC29B78", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB7E18]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023145]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.solver = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiSolver component = GetComponent<ObiSolver>();
			solver = component;
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0xC29BD0", Offset = "0xC29BD0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB13B8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023146]) = v38;\nL_0013:\n\tv39 = this.solver;\n\tv43 = Oni::GetParticleGridSize(v39.oniSolver);\n\t// 30 NewArr v50 @ X0_v8 (GridCell[]), typeof(GridCell[]), v43 @ X0_v6 (System.Int32)\n\tv45 = this.solver;\n\tthis.cells = v50;\n\tOni::GetParticleGrid(v45.oniSolver, v50);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			ObiSolver obiSolver = solver;
			int particleGridSize = Oni.GetParticleGridSize(obiSolver.OniSolver);
			Oni.GridCell[] array = new Oni.GridCell[particleGridSize];
			ObiSolver obiSolver2 = solver;
			cells = array;
			Oni.GetParticleGrid(obiSolver2.OniSolver, array);
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0xC29C60", Offset = "0xC29C60", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.cells;\n\tv26 = this.cells == 0;\n\tif (v26) goto L_0071;\n\tv194 = v24.Length;\n\tv38 = v24.Length < 1;\n\tif (v38) goto L_0071;\nL_001F:\n\tv208 = v174 < v194;\n\tv192 = ~v208;\n\tif (v192) goto L_0072;\n\tv118 = v174 * 0x1C;\n\tv209 = this.cells + v118;\n\tv221 = *([v209 @ X8_v4+38]) <= 0;\n\tif (v221) goto L_0046;\n\tv243 = UnityEngine.Color::get_yellow();\n\tv242 = v243.g;\n\tv241 = v243.b;\n\tv240 = v243.a;\n\tgoto L_004B;\nL_0046:\n\tv243 = UnityEngine.Color::get_red();\n\tv242 = v243.g;\n\tv241 = v243.b;\n\tv240 = v243.a;\nL_004B:\n\t// 75 MakeStruct v40 @ AGGC29CD4_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v243 @ V0_v3 (UnityEngine.Color), v242 @ V1_v3 (System.Single), v241 @ V2_v3 (System.Single), v240 @ V3_v3 (System.Single)\n\tUnityEngine.Gizmos::set_color(v40);\n\t// 84 MakeStruct v46 @ AGGC29CF4_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v209 @ X8_v4+20], [v209 @ X8_v4+24], [v209 @ X8_v4+28]\n\t// 85 MakeStruct v43 @ AGGC29CF4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v209 @ X8_v4+2C], [v209 @ X8_v4+30], [v209 @ X8_v4+34]\n\tUnityEngine.Gizmos::DrawWireCube(v46, v43);\n\tv194 = v24.Length;\n\tv174 = v174 + 1;\n\tv88 = v174 < v24.Length;\n\tif (v88) goto L_001F;\nL_0071:\n\treturn;\nL_0072:\n\tv222 = new System.IndexOutOfRangeException();\n\tthrow v222;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDrawGizmos()
		{
			//IL_007e: Expected O, but got I
			//IL_0176: Expected F4, but got I
			//IL_018b: Expected F4, but got I
			//IL_01a0: Expected F4, but got I
			//IL_01b5: Expected F4, but got I
			//IL_01ca: Expected F4, but got I
			//IL_01df: Expected F4, but got I
			Oni.GridCell[] array = cells;
			if (cells == null)
			{
				return;
			}
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			Color color2 = default(Color);
			Vector3 center = default(Vector3);
			Vector3 size = default(Vector3);
			while (num2 < num)
			{
				int num3 = num2 * 28;
				object obj = (long)(IntPtr)cells + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+38]");
				Color color;
				float g;
				float b;
				float a;
				if (0L > 0L)
				{
					color = Color.yellow;
					g = color.g;
					b = color.b;
					a = color.a;
				}
				else
				{
					color = Color.red;
					g = color.g;
					b = color.b;
					a = color.a;
				}
				color2.r = color.r;
				color2.g = g;
				color2.b = b;
				color2.a = a;
				Gizmos.color = color2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+20]");
				center.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+24]");
				center.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+28]");
				center.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+2C]");
				size.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+30]");
				size.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v4+34]");
				size.z = 0f;
				Gizmos.DrawWireCube(center, size);
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

		[Token(Token = "0x60003B3")]
		[Address(RVA = "0xC29D34", Offset = "0xC29D34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleGridDebugger()
		{
		}
	}
}
