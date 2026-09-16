using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(RequireComponent), RVA = "0x74CD4C", Offset = "0x74CD4C")]
	[Token(Token = "0x2000052")]
	public class ColorFromPhase : MonoBehaviour
	{
		[Token(Token = "0x4000259")]
		[FieldOffset(Offset = "0x18")]
		private ObiActor actor;

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x98CF4C", Offset = "0x98CF4C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA8A48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216EF]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.actor = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiActor component = GetComponent<ObiActor>();
			actor = component;
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x98CFA4", Offset = "0x98CFA4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB5C00]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20216F0]) = v46;\nL_0019:\n\tv49 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv51 = v49 == 0;\n\tif (v51) goto L_00B0;\n\tv69 = 0x98F780(v49, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n\tX9 = *([X0+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_002E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_002E:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B0;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_00A5;\n\tX24 = *([1F002D8]);\n\tX23 = 0;\nL_003C:\n\tX9 = *([X8+68]);\n\tif (TEMP) goto L_00A5;\n\tX10 = *([X9+18]);\n\tC = X23 < X10;\n\tC = ~C;\n\tTEMP1 = X23 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X10;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_00B0;\n\tif (C) goto L_00B2;\n\tX0 = *([X8+48]);\n\tif (TEMP) goto L_00B1;\n\tTEMPSHIFT = X23 << 2;\n\tX8 = X9 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_phases(X0, X1);\n\tif (TEMP) goto L_00B1;\n\tX8 = *([X0]);\n\tX1 = X20;\n\tX9 = *([X8+180]);\n\tX2 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX0 = Oni::GetGroupFromPhase(X0, X1);\n\tX8 = *([X19+18]);\n\tX22 = X0;\n\tif (TEMP) goto L_00A5;\n\tX0 = *([X8+48]);\n\tif (TEMP) goto L_00B1;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_colors(X0, X1);\n\tX8 = *([X24]);\n\tX21 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0073;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0073;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X24]);\nL_0073:\n\tX8 = *([X8+B8]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_00A5;\n\tX10 = *([X8+18]);\n\tX9 = X22 / X10;\n\tTEMP = X9 * X10;\n\tX9 = X22 - TEMP;\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_00B2;\n\tTEMPSHIFT = X9 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tX1 = 0;\n\tV0 = UnityEngine.Color32::op_Implicit(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tif (TEMP) goto L_00A5;\n\tX8 = *([X21+18]);\n\tC = X20 < X8;\n\tC = ~C;\n\tTEMP1 = X20 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ X8;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_00B2;\n\tTEMPSHIFT = X20 << 4;\n\tX8 = X21 + TEMPSHIFT;\n\t*([X8+20]) = V0;\n\t*([X8+24]) = V1;\n\t*([X8+28]) = V2;\n\t*([X8+2C]) = V3;\n\tX8 = *([X19+18]);\n\tX23 = X23 + 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003C;\nL_00A5:\n\t;\n\tthrow System.NullReferenceException;\nL_00B0:\n\treturn;\nL_00B1:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B2:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			if (base.isActiveAndEnabled)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @98F780 (inside PEButtonScript::.ctor +0x24)");
			}
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x98D158", Offset = "0x98D158", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorFromPhase()
		{
		}
	}
}
