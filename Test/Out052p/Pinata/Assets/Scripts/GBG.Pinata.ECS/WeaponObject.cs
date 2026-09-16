using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh.Globals;
using UnityEngine;

[Token(Token = "0x2000009")]
public class WeaponObject : MonoBehaviour
{
	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0x18")]
	public int ID;

	[Token(Token = "0x400001A")]
	[FieldOffset(Offset = "0x1C")]
	private float lastTime;

	[Token(Token = "0x600000D")]
	[Address(RVA = "0xCCD7FC", Offset = "0xCCD7FC", Length = "0x194")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EA79E8]);\n\tv37 = *([v36 @ X8_v18]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, other, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20237AB]) = v55;\nL_001F:\n\tv59 = UnityEngine.Time::get_time();\n\tv59 = this.lastTime;\n\tv59 = v59 + 0.3f;\n\tv76 = v59 <= v59;\n\tif (v76) goto L_008C;\n\tv77 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tv201 = System.Collections.Generic.Dictionary`2<System.String, Morpeh.Globals.GlobalEventInt>::get_Item(v77.GlobalEventsInt, \"EnemyIsKicked\");\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(v201, this.ID);\n\tv202 = UnityEngine.Collision::get_transform(other);\n\tv199 = UnityEngine.Transform::get_position(v202);\n\tv203 = UnityEngine.Component::get_transform(this);\n\tv223 = UnityEngine.Transform::get_position(v203);\n\tgoto L_0075;\n\tv232 = *([v228 @ X0_v16+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0075;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v228, v222, v112, v40, v41, v42, v43, v44, v223, v224, v225, v48, v49, v50, v51, v52);\nL_0075:\n\tv121 = UnityEngine.Vector3::op_Subtraction(v199, v223);\n\tv123 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(&v121 @ V0_v10 (UnityEngine.Vector3), 0);\n\tthis.lastTime = v59;\nL_008C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnCollisionEnter(Collision other)
	{
		float time = Time.time;
		time = lastTime;
		time += 0.3f;
		if (time > time)
		{
			GameConfig instance = GameConfig.Instance;
			GlobalEventInt globalEventInt = ((Dictionary<string, GlobalEventInt>)instance.GlobalEventsInt).get_Item("EnemyIsKicked");
			globalEventInt.Publish(ID);
			Transform transform = other.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Vector3 vector = position - position2;
			((BaseGlobalEvent<int>)vector).Publish(0);
			lastTime = time;
		}
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0xCCD990", Offset = "0xCCD990", Length = "0x1B4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\t// 3 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX8 = *([X19]);\n\tX20 = X1;\n\tX9 = *([X20]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\tC = X9 < 0;\n\tC = ~C;\n\tTEMP1 = X9 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 0;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX9 = TEMPCOND;\n\tX8 = X8 ^ X9;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0053;\n\tX8 = *([X19+4]);\n\tX9 = *([X20+4]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0053;\n\tX8 = *([X19+8]);\n\tX9 = *([X20+8]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0053;\n\tV0 = *([X20+C]);\n\tX0 = X19 + 0xC;\n\tX1 = 0;\n\tX0 = 0xBCCE68(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0053;\n\tV0 = *([X20+10]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19 + 0x10;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 80 ShiftStack 32\n\tX0 = 0xBCCE68(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\nL_0053:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 88 ShiftStack 32\n\treturn;\n\t// 90 ShiftStack -80\n\tstack[20] = X21;\n\tstack[30] = X20;\n\tstack[38] = X19;\n\tstack[40] = X29;\n\tstack[48] = X30;\n\tX29 = &stack[40];\n\tX8 = *([20237AC]);\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006F;\n\tX8 = *([1ED35F0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20237AC]) = X8;\nL_006F:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_007F;\n\tX8 = *([1F02508]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0081;\nL_007F:\n\tX0 = 0;\n\tgoto L_008A;\nL_0081:\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+10]);\n\tX1 = &stack[0];\n\tstack[10] = X8;\n\tV0 = *([X0]);\n\tX0 = X19;\n\tstack[0] = V0;\n\tX0 = 0xCCD998(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008A:\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX21 = stack[20];\n\tX0 = X0 & 1;\n\t// 144 ShiftStack 80\n\treturn;\n\t// 146 ShiftStack -64\n\tstack[0] = X23;\n\tstack[10] = X22;\n\tstack[18] = X21;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX1 = 0;\n\tX19 = X0;\n\tX0 = 0xE8F13C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X19+4]);\n\tX23 = *([X19+8]);\n\tX20 = X0;\n\tX0 = X19 + 0xC;\n\tX1 = 0;\n\tX0 = 0xBCCEB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX0 = X19 + 0x10;\n\tX1 = 0;\n\tX0 = 0xBCCEB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0x18D;\n\tX9 = X20 * X8;\n\tX9 = X9 ^ X22;\n\tX9 = X9 * X8;\n\tX9 = X9 ^ X23;\n\tX9 = X9 * X8;\n\tX9 = X9 ^ X21;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX8 = X9 * X8;\n\tX0 = X8 ^ X0;\n\tX23 = stack[0];\n\t// 184 ShiftStack 64\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public WeaponObject()
	{
	}
}
