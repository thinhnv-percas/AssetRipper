using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace PlayMaker.ConditionalExpression
{
	[Token(Token = "0x2000004")]
	public class VariableNotFoundException : Exception
	{
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x16813D4", Offset = "0x16813D4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ED71E8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variableName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B5CC]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv49 = variableName == 0;\n\tif (v49) goto L_0026;\n\t// 34 IsInst v54 @ X0_v17, typeof(System.Object), variableName @ X1 (System.String)\nL_0026:\n\tv61 = v46.Length == 0;\n\tif (v61) goto L_0049;\n\tv46[0] = variableName;\n\tv72 = System.String::Format(\"Variable was not found '{0}'.\", v46);\n\tgoto L_0046;\n\tv88 = *([v77 @ X8_v13+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0046;\n\tv103 = v77;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v103, v69, v70, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0046:\n\tSystem.Exception::.ctor(this, v72);\n\treturn;\n\tv50 = new System.NullReferenceException();\nL_0049:\n\tv66 = new System.IndexOutOfRangeException();\n\tgoto L_004E;\n\tv73 = new System.ArrayTypeMismatchException();\nL_004E:\n\tthrow v82;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VariableNotFoundException(string variableName)
		{
			object[] array = new object[1];
			if (variableName != null)
			{
				object obj = variableName as object;
			}
			if (array.Length != 0)
			{
				array[0] = variableName;
				base._002Ector(string.Format("Variable was not found '{0}'.", array));
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
