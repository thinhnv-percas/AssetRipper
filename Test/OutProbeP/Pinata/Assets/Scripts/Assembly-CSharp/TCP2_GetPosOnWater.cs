using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000013")]
public class TCP2_GetPosOnWater : MonoBehaviour
{
	[Token(Token = "0x40000A7")]
	[FieldOffset(Offset = "0x18")]
	public Material WaterMaterial;

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763FD0", Offset = "0x763FD0")]
	[Token(Token = "0x40000A8")]
	[FieldOffset(Offset = "0x20")]
	public bool followWaterHeight;

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x764008", Offset = "0x764008")]
	[Token(Token = "0x40000A9")]
	[FieldOffset(Offset = "0x24")]
	public float heightOffset;

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x764040", Offset = "0x764040")]
	[Token(Token = "0x40000AA")]
	[FieldOffset(Offset = "0x28")]
	public float heightScale;

	[SerializeField]
	[HideInInspector]
	[Token(Token = "0x40000AB")]
	[FieldOffset(Offset = "0x2C")]
	private bool isValid;

	[SerializeField]
	[HideInInspector]
	[Token(Token = "0x40000AC")]
	[FieldOffset(Offset = "0x30")]
	private int sineCount;

	[Token(Token = "0x40000AD")]
	[FieldOffset(Offset = "0x38")]
	private float[] sinePosOffsetsX;

	[Token(Token = "0x40000AE")]
	[FieldOffset(Offset = "0x40")]
	private float[] sinePosOffsetsZ;

	[Token(Token = "0x40000AF")]
	[FieldOffset(Offset = "0x48")]
	private float[] sinePhsOffsetsX;

	[Token(Token = "0x40000B0")]
	[FieldOffset(Offset = "0x50")]
	private float[] sinePhsOffsetsZ;

	[Token(Token = "0x600008A")]
	[Address(RVA = "0xB0866C", Offset = "0xB0866C", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.followWaterHeight;\n\tif (v13) goto L_002D;\n\tv16 = UnityEngine.Component::get_transform(this);\n\tv24 = UnityEngine.Component::get_transform(this);\n\tv64 = UnityEngine.Transform::get_position(v24);\n\tv43 = TCP2_GetPosOnWater::GetPositionOnWater(this, v64);\n\tUnityEngine.Transform::set_position(v16, v43);\n\treturn;\nL_002D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LateUpdate()
	{
		if (followWaterHeight)
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			Vector3 positionOnWater = GetPositionOnWater(position);
			transform.position = positionOnWater;
		}
	}

	[Token(Token = "0x600008B")]
	[Address(RVA = "0xB086E4", Offset = "0xB086E4", Length = "0xADC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EBECF0]);\n\tv41 = *([v40 @ X8_v25]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, worldPosition, v0, v2, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([20224E9]) = v57;\nL_0021:\n\tv59 = ~this.isValid;\n\tif (v59) goto L_0094;\n\tv72 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveFrequency\");\n\tv76 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveHeight\");\n\tv209 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveSpeed\");\n\tv161 = UnityEngine.Time::get_time();\n\tv203 = this.sineCount - 1;\n\tv211 = v203 < 7;\n\tv148 = ~v211;\n\tv144 = v203 - 7;\n\tv136 = v144 == 0;\n\tv212 = ~v136;\n\tv116 = v148 & v212;\n\tif (v116) goto L_04E7;\n\tv113 = 0x1819000 + 0x250;\n\tv190 = v76 * this.heightScale;\n\tv183 = *([v113 @ X9_v2 (System.Int32)+v203 @ X8_v20 (System.Int32)*4]) + v113;\n\t// 89 IndirectJump v183 @ X8_v22, 0, 0, \"_WaveSpeed\", 0, v45 @ X3, v46 @ X4, v47 @ X5, v48 @ X6, v49 @ X7, v161 @ V0_v7 (System.Single), 0, v190 @ V2_v3 (System.Single), v50 @ V3, v51 @ V4, v52 @ V5, v53 @ V6, v54 @ V7\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tV12 = V2;\n\tif (TEMP) goto L_04EA;\n\tX10 = *([1EEBFB8]);\n\tV8 = *([X8+20]);\n\tV10 = *([X9+20]);\n\tX0 = *([X10]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0075;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0075;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0075:\n\tV0 = V11 * V8;\n\tV1 = V13 * V10;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tif (TEMP) goto L_04EA;\n\tV1 = *([X8+20]);\n\tV2 = *([X9+20]);\n\tV8 = V12 * V0;\n\tV0 = V11 * V1;\n\tV1 = V13 * V2;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV1 = V12 * V0;\n\t// 141 Jump @b192\nL_0094:\n\tgoto L_009E;\n\tv92 = *([v64 @ X0_v3+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_009E;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v64, methodInfo, v44, v45, v46, v47, v48, v49, worldPosition, v0, v2, v50, v51, v52, v53, v54);\nL_009E:\n\tUnityEngine.Debug::LogWarning(\"Invalid Water Material, returning the same worldPosition\");\n\tgoto L_04E7;\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tstack[2C] = V2;\n\tX10 = *([X9+18]);\n\tif (TEMP) goto L_04EA;\n\tX10 = *([1EEBFB8]);\n\tV8 = *([X8+20]);\n\tV10 = *([X9+20]);\n\tX0 = *([X10]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00BB;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BB;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BB:\n\tV0 = V11 * V8;\n\tV1 = V13 * V10;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+38]);\n\tV10 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tC = X10 < 1;\n\tC = ~C;\n\tTEMP1 = X10 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ 1;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tV0 = *([X8+24]);\n\tV1 = *([X9+24]);\n\tV0 = V11 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+40]);\n\tV11 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+50]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tif (TEMP) goto L_04EA;\n\tV0 = *([X8+20]);\n\tV1 = *([X9+20]);\n\tV0 = V14 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+40]);\n\tV12 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tX9 = *([X19+50]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tC = X10 < 1;\n\tC = ~C;\n\tTEMP1 = X10 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ 1;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tV0 = V10 + V11;\n\tV11 = stack[2C];\n\tV1 = *([X8+24]);\n\tV2 = *([X9+24]);\n\tV10 = 0.5f;\n\tV0 = V11 * V0;\n\tV8 = V0 * V10;\n\tV0 = V14 * V1;\n\tV1 = V13 * V2;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V12 + V0;\n\tV0 = V11 * V0;\n\tV1 = V0 * V10;\n\t// 296 Jump @b192\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tstack[2C] = V2;\n\tX10 = *([X9+18]);\n\tif (TEMP) goto L_04EA;\n\tX10 = *([1EEBFB8]);\n\tV8 = *([X8+20]);\n\tV10 = *([X9+20]);\n\tX0 = *([X10]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0144;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0144;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0144:\n\tV0 = V11 * V8;\n\tV1 = V13 * V10;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+38]);\n\tV12 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tC = X10 < 1;\n\tC = ~C;\n\tTEMP1 = X10 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ 1;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tV0 = *([X8+24]);\n\tV1 = *([X9+24]);\n\tV0 = V11 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+38]);\n\tV10 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 2;\n\tC = ~C;\n\tTEMP1 = X9 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 2;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tC = X10 < 2;\n\tC = ~C;\n\tTEMP1 = X10 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ 2;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tV0 = *([X8+28]);\n\tV1 = *([X9+28]);\n\tV0 = V11 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 3;\n\tC = ~C;\n\tTEMP1 = X9 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 3;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tX9 = *([X19+48]);\n\tif (TEMP) goto L_04E8;\n\tstack[24] = V0;\n\tX10 = *([X9+18]);\n\tC = X10 < 3;\n\tC = ~C;\n\tTEMP1 = X10 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ 3;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_04EA;\n\tV0 = *([X8+2C]);\n\tV1 = *([X9+2C]);\n\tV0 = V11 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+40]);\n\tV8 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tif (TEMP) goto L_04EA;\n\tX9 = *([X19+50]);\n\tif (TEMP) goto L_04E8;\n\tX10 = *([X9+18]);\n\tif (TEMP) goto L_04EA;\n\tV0 = *([X8+20]);\n\tV1 = *([X9+20]);\n\tV0 = V14 * V0;\n\tV1 = V13 * V1;\n\tV0 = V0 + V1;\n\tX0 = 0x6D2D20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+40]);\n\tV11 = V0;\n\tif (TEMP) goto L_04E8;\n\tX9 = *([X8+18]);\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 =\n// ... truncated")]
	public Vector3 GetPositionOnWater(Vector3 worldPosition)
	{
		//IL_00fb: Expected O, but got I
		if (isValid)
		{
			float num = WaterMaterial.GetFloat("_WaveFrequency");
			float num2 = WaterMaterial.GetFloat("_WaveHeight");
			float num3 = WaterMaterial.GetFloat("_WaveSpeed");
			float time = Time.time;
			int num4 = sineCount - 1;
			bool flag = num4 < 7;
			bool flag2 = !flag;
			int num5 = num4 - 7;
			bool flag3 = num5 == 0;
			bool flag4 = !flag3;
			if (flag2 && flag4)
			{
				goto IL_0134;
			}
			int num6 = 25268224 + 592;
			float num7 = num2 * heightScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X9_v2 (System.Int32)+v203 @ X8_v20 (System.Int32)*4]");
			object obj = 0L + (long)num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v183 @ X8_v22 (should have been resolved before IL gen)");
		}
		Debug.LogWarning("Invalid Water Material, returning the same worldPosition");
		goto IL_0134;
		IL_0134:
		return worldPosition;
	}

	[Token(Token = "0x600008C")]
	[Address(RVA = "0xB091C0", Offset = "0xB091C0", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EA5C00]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224EA]) = v40;\nL_0016:\n\tthis.followWaterHeight = 1;\n\tthis.heightScale = 1f;\n\t// 28 NewArr v47 @ X0_v3 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v47, Il2CppFieldInfo);\n\tthis.sinePosOffsetsX = v47;\n\t// 38 NewArr v55 @ X0_v5 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v55, Il2CppFieldInfo);\n\tthis.sinePosOffsetsZ = v55;\n\t// 48 NewArr v63 @ X0_v7 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v63, Il2CppFieldInfo);\n\tthis.sinePhsOffsetsX = v63;\n\t// 58 NewArr v71 @ X0_v9 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v71, Il2CppFieldInfo);\n\tthis.sinePhsOffsetsZ = v71;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_GetPosOnWater()
	{
		followWaterHeight = true;
		heightScale = 1f;
		sinePosOffsetsX = new float[8] { 1f, 2.2f, 2.7f, 3.4f, 1.4f, 1.8f, 4.2f, 3.6f };
		sinePosOffsetsZ = new float[8] { 0.6f, 1.3f, 3.1f, 2.4f, 1.1f, 2.8f, 1.7f, 4.3f };
		sinePhsOffsetsX = new float[8] { 1f, 1.3f, 0.7f, 1.75f, 0.2f, 2.6f, 0.7f, 3.1f };
		sinePhsOffsetsZ = new float[8] { 2.2f, 0.4f, 3.3f, 2.9f, 0.5f, 4.8f, 3.1f, 2.3f };
	}
}
