using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	[Token(Token = "0x2000036")]
	public class G_RamManager : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x18")]
		private GameObject m_ramGraphGameObject;

		[SerializeField]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x20")]
		private List<Image> m_backgroundImages;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x28")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x30")]
		private G_RamGraph m_ramGraph;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x38")]
		private G_RamText m_ramText;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x40")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x48")]
		private List<GameObject> m_childrenGameObjects;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x50")]
		private GraphyManager.ModuleState m_previousModuleState;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x54")]
		private GraphyManager.ModuleState m_currentModuleState;

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x16426D8", Offset = "0x16426D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Ram.G_RamManager::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x1642A6C", Offset = "0x1642A6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this);\n\treturn;\n")]
		private void Start()
		{
			UpdateParameters();
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x1642BD0", Offset = "0x1642BD0", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ECEC90]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, newModulePosition, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202AB08]) = v45;\nL_001B:\n\tv49 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tgoto L_002E;\n\tv69 = *([v65 @ X0_v5+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\t// 40 ConditionalJump @b9, v71 @ TEMP_v11\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v48, methodInfo, v30, v31, v32, v33, v34, v49, v53, v37, v38, v39, v40, v41, v42);\nL_002E:\n\tv116 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tv131 = newModulePosition < 3;\n\tv108 = ~v131;\n\tv105 = newModulePosition - 3;\n\tv99 = v105 == 0;\n\tv132 = ~v99;\n\tv84 = v108 & v132;\n\tif (v84) goto L_00EC;\n\tv81 = 0x1857000 + 0xBE4;\n\tv78 = UnityEngine.Mathf::Abs(v49);\n\tv111 = UnityEngine.Mathf::Abs(v116.y);\n\tv126 = *([v81 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]) + v81;\n\t// 67 IndirectJump v126 @ X8_v10, this.m_rectTransform (UnityEngine.RectTransform), this.m_rectTransform (UnityEngine.RectTransform), 0, methodInfo @ X2 (Il2CppMethodInfo), v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v116 @ V0_v3 (UnityEngine.Vector2), v116.y (System.Single), v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+40]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 88 MakeStruct AGG1642CB4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1642CB4_1, X1);\n\tX20 = *([X19+40]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 98 MakeStruct AGG1642CD0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1642CD0_1, X1);\n\tX19 = *([X19+40]);\n\tstack[18] = 0;\n\tV0 = -V9;\n\tV1 = -V8;\n\tX0 = &stack[18];\n\tgoto L_00DA;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+40]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0077;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0077;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0077:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 126 MakeStruct AGG1642D24_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1642D24_1, X1);\n\tX20 = *([X19+40]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 136 MakeStruct AGG1642D40_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1642D40_1, X1);\n\tX19 = *([X19+40]);\n\tV1 = -V8;\n\tX0 = &stack[18];\n\tV0 = V9;\n\tstack[18] = 0;\n\tgoto L_00DA;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+40]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009D:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 164 MakeStruct AGG1642D94_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1642D94_1, X1);\n\tX20 = *([X19+40]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 174 MakeStruct AGG1642DB0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1642DB0_1, X1);\n\tX19 = *([X19+40]);\n\tstack[18] = 0;\n\tV0 = -V9;\n\tX0 = &stack[18];\n\tgoto L_00D9;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+40]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00C2;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C2:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 201 MakeStruct AGG1642E00_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1642E00_1, X1);\n\tX20 = *([X19+40]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 211 MakeStruct AGG1642E1C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1642E1C_1, X1);\n\tX19 = *([X19+40]);\n\tX0 = &stack[18];\n\tV0 = V9;\n\tstack[18] = 0;\nL_00D9:\n\tV1 = V8;\nL_00DA:\n\tX1 = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00ED;\n\tV0 = stack[18];\n\tV1 = stack[1C];\n\tX0 = X19;\n\tX1 = 0;\n\t// 226 MakeStruct AGG1642E4C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchoredPosition(X0, AGG1642E4C_1, X1);\nL_00EC:\n\treturn;\nL_00ED:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(GraphyManager.ModulePosition newModulePosition)
		{
			//IL_00d2: Expected O, but got I
			Vector2 anchoredPosition = m_rectTransform.anchoredPosition;
			Vector2 anchoredPosition2 = m_rectTransform.anchoredPosition;
			bool flag = newModulePosition < GraphyManager.ModulePosition.BOTTOM_LEFT;
			bool flag2 = !flag;
			int num = (int)(newModulePosition - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25522176 + 3044;
				float num3 = Mathf.Abs(anchoredPosition.x);
				float num4 = Mathf.Abs(anchoredPosition2.y);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v126 @ X8_v10 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x1642E70", Offset = "0x1642E70", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = silentUpdate == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_000C;\n\tthis.m_previousModuleState = this.m_currentModuleState;\nL_000C:\n\tv17 = state < 4;\n\tv19 = ~v17;\n\tv20 = state - 4;\n\tv22 = v20 == 0;\n\tthis.m_currentModuleState = state;\n\tv27 = ~v22;\n\tv28 = v19 & v27;\n\tif (v28) goto L_003A;\n\tv31 = 0x1857000 + 0xBF4;\n\tv33 = *([v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]) + v31;\n\t// 30 IndirectJump v33 @ X8_v4, this @ X0 (Tayx.Graphy.Ram.G_RamManager), this @ X0 (Tayx.Graphy.Ram.G_RamManager), state @ X1 (Tayx.Graphy.GraphyManager+ModuleState), silentUpdate @ X2 (System.Boolean), methodInfo @ X3 (Il2CppMethodInfo), v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007A;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+48]);\n\tX1 = 0 | 1;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_007B;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_0066;\n\tX1 = 0 | 1;\n\tgoto L_0051;\nL_003A:\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007A;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+48]);\n\tX1 = 0 | 1;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX1 = 0 | 1;\n\tX0 = X19;\n\tTayx.Graphy.Ram.G_RamManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_007B;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_0066;\n\tX1 = 0;\nL_0051:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 84 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetOneActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007A;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetGraphActive(X0, X1, X2);\n\tX0 = *([X19+48]);\n\tX1 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = *([X19+20]);\nL_0066:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX19 = stack[0];\n\t// 106 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007A;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 119 ShiftStack 32\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\treturn;\nL_007A:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007B:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetState(GraphyManager.ModuleState state, bool silentUpdate = false)
		{
			//IL_005d: Expected O, but got I
			if (!silentUpdate)
			{
				m_previousModuleState = m_currentModuleState;
			}
			bool flag = state < GraphyManager.ModuleState.OFF;
			bool flag2 = !flag;
			int num = (int)(state - 4);
			bool flag3 = num == 0;
			m_currentModuleState = state;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25522176 + 3060;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v33 @ X8_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x1643330", Offset = "0x1643330", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Ram.G_RamManager::SetState(this, this.m_previousModuleState, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestorePreviousState()
		{
			SetState(m_previousModuleState);
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x1642A70", Offset = "0x1642A70", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAA690]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB09]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv141 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv175 = v141 == 0;\n\tif (v175) goto L_0039;\n\tv171 = this.m_graphyManager;\n\tv210 = 0;\n\tgoto L_003D;\n\tv130 = *([v210 @ X0_v31 (System.Int32)]);\n\t*([v130 @ X9_v6+2A0])(v134, 0, *([v130 @ X9_v6+2A8]), v22, v23, v24, v25, v26, v27, v171.m_backgroundColor, v171.m_backgroundColor.g, v171.m_backgroundColor.b, v171.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv209 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005B;\n\tv212 = new System.NullReferenceException();\nL_003D:\n\tv167 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv143 = Il2CppMethodInfo != 1;\n\tif (v143) goto L_0070;\n\tv247 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v167);\n\tv248 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v247);\n\tv193 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv251 = ~v247.m_value;\n\tv195 = ~v251;\n\tif (v195) goto L_0074;\nL_005B:\n\tTayx.Graphy.Ram.G_RamGraph::UpdateParameters(this.m_ramGraph);\n\tTayx.Graphy.Ram.G_RamText::UpdateParameters(this.m_ramText);\n\tv122 = this.m_graphyManager;\n\tTayx.Graphy.Ram.G_RamManager::SetState(this, v122.m_ramModuleState, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv125 = new System.NullReferenceException();\nL_0070:\n\tv173 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v166);\nL_0074:\n\tthrow System.TypeLoadException;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateParameters()
		{
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			List<Image>.Enumerator enumerator2 = m_backgroundImages.GetEnumerator();
			if (enumerator.MoveNext())
			{
				GraphyManager graphyManager = m_graphyManager;
				int num = 0;
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)0 == (IntPtr)1)
				{
					bool flag = ((List<Image>.Enumerator*)ex)->MoveNext();
					bool flag2 = (flag ? ((List<Image>.Enumerator*)1) : ((List<Image>.Enumerator*)null))->MoveNext();
					enumerator.Dispose();
					if (!((bool*)(flag ? 1 : 0))->m_value)
					{
						goto IL_00d8;
					}
				}
				else
				{
					NullReferenceException ex2 = default(NullReferenceException);
					bool flag3 = ((List<Image>.Enumerator*)ex2)->MoveNext();
				}
				throw new TypeLoadException();
			}
			enumerator.Dispose();
			goto IL_00d8;
			IL_00d8:
			m_ramGraph.UpdateParameters();
			m_ramText.UpdateParameters();
			GraphyManager graphyManager2 = m_graphyManager;
			SetState(graphyManager2.RamModuleState);
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x16433EC", Offset = "0x16433EC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EFA6E0]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB0A]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv150 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv180 = v150 == 0;\n\tif (v180) goto L_0039;\n\tv133 = this.m_graphyManager;\n\tv217 = 0;\n\tgoto L_003D;\n\tv140 = *([v217 @ X0_v28 (System.Int32)]);\n\t*([v140 @ X9_v5+2A0])(v144, 0, *([v140 @ X9_v5+2A8]), v22, v23, v24, v25, v26, v27, v133.m_backgroundColor, v133.m_backgroundColor.g, v133.m_backgroundColor.b, v133.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv186 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005B;\n\tv219 = new System.NullReferenceException();\nL_003D:\n\tv129 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv104 = Il2CppMethodInfo != 1;\n\tif (v104) goto L_006B;\n\tv224 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v129);\n\tv225 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v224);\n\tv168 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv228 = ~v224.m_value;\n\tv170 = ~v228;\n\tif (v170) goto L_006F;\nL_005B:\n\tTayx.Graphy.Ram.G_RamGraph::UpdateParameters(this.m_ramGraph);\n\tTayx.Graphy.Ram.G_RamText::UpdateParameters(this.m_ramText);\n\tTayx.Graphy.Ram.G_RamManager::SetState(this, this.m_currentModuleState, 1);\n\treturn;\n\tv100 = new System.NullReferenceException();\nL_006B:\n\tv135 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v128);\nL_006F:\n\tthrow System.TypeLoadException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RefreshParameters()
		{
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			List<Image>.Enumerator enumerator2 = m_backgroundImages.GetEnumerator();
			if (enumerator.MoveNext())
			{
				GraphyManager graphyManager = m_graphyManager;
				int num = 0;
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)0 == (IntPtr)1)
				{
					bool flag = ((List<Image>.Enumerator*)ex)->MoveNext();
					bool flag2 = (flag ? ((List<Image>.Enumerator*)1) : ((List<Image>.Enumerator*)null))->MoveNext();
					enumerator.Dispose();
					if (!((bool*)(flag ? 1 : 0))->m_value)
					{
						goto IL_00d8;
					}
				}
				else
				{
					NullReferenceException ex2 = default(NullReferenceException);
					bool flag3 = ((List<Image>.Enumerator*)ex2)->MoveNext();
				}
				throw new TypeLoadException();
			}
			enumerator.Dispose();
			goto IL_00d8;
			IL_00d8:
			m_ramGraph.UpdateParameters();
			m_ramText.UpdateParameters();
			SetState(m_currentModuleState, silentUpdate: true);
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x16426DC", Offset = "0x16426DC", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EEB8F0]);\n\tv33 = *([v32 @ X8_v41]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202AB0B]) = v52;\nL_001C:\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv58 = UnityEngine.Transform::get_root(v55);\n\tv184 = UnityEngine.Component::GetComponentInChildren(v58);\n\tthis.m_graphyManager = v184;\n\tv220 = UnityEngine.Component::GetComponent(this);\n\tthis.m_ramGraph = v220;\n\tv225 = UnityEngine.Component::GetComponent(this);\n\tthis.m_ramText = v225;\n\tv239 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v239;\n\tv122 = UnityEngine.Component::get_transform(this);\n\tv210 = UnityEngine.Transform::GetEnumerator(v122);\n\tv212 = v210 == 0;\n\tif (v212) goto L_00F7;\nL_0050:\n\tgoto L_0077;\n\tv488 = *([v453 @ X8_v22+B0]);\n\tv489 = 0;\n\tv490 = v488 + 8;\n\tv492 = *([v551 @ X11_v24-8]);\n\tv556 = v492 == v454;\n\tif (v556) goto L_0070;\n\tv512 = v550 + 1;\n\tv569 = v512 < v455;\n\tv510 = ~v569;\n\tv514 = v551 + 0x10;\n\tv494 = ~v510;\n\tif (v494) goto L_FFFFFFFF;\n\tv515 = v131;\n\tv516 = 0;\n\tv517 = 0x8909C4(v515, v454, v516, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0077;\nL_0070:\n\tv570 = *([v551 @ X11_v24]);\n\tv571 = v570 << 4;\n\tv572 = v453 + v571;\n\tv573 = v572 + 0x130;\nL_0077:\n\tv382 = System.Collections.IEnumerator::MoveNext(v210);\n\tv384 = v382 == 0;\n\tif (v384) goto L_FFFFFFFF;\n\tv578 = *([v210 @ X0_v37 (System.Collections.IEnumerator)]);\n\tv581 = *([v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v581) goto L_009D;\n\tv623 = *([v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0088:\n\tv628 = *([v623 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v628) goto L_00A0;\n\tv622 = v622 + 1;\n\tv633 = v622 < *([v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv604 = ~v633;\n\tv623 = v623 + 0x10;\n\tv588 = ~v604;\n\tif (v588) goto L_0088;\nL_009D:\n\tv651 = 0x8909C4(v210, System.Collections.IEnumerator, 1, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00A7;\nL_00A0:\n\tv635 = *([v623 @ X11_v19]) + 1;\n\tv636 = v635 << 4;\n\tv637 = v578 + v636;\n\tv651 = v637 + 0x130;\nL_00A7:\n\t*([v651 @ X0_v42])(v656, v210, *([v651 @ X0_v42+8]), v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_FFFFFFFF;\n\tv146 = v146_asT == 0;\n\tif (v146) goto L_00F1;\n\tv690 = UnityEngine.Transform::get_parent(v656);\n\tv693 = UnityEngine.Component::get_transform(this);\n\tgoto L_00DE;\n\tv698 = *([v694 @ X0_v54+E0]);\n\tv699 = v698 == 0;\n\tv700 = ~v699;\n\tif (v700) goto L_00DE;\n\tv702 = \"il2cpp_codegen_runtime_class_init\"(v694, v692, v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00DE:\n\tv448 = UnityEngine.Object::op_Equality(v690, v693);\n\tv451 = v448 == 0;\n\tif (v451) goto L_0050;\n\tv173 = UnityEngine.Component::get_gameObject(v656);\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(this.m_childrenGameObjects, v173);\n\tgoto L_0050;\n\tgoto L_0115;\nL_00F1:\n\tthrow System.InvalidCastException;\n\tv121 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv180 = new System.NullReferenceException();\nL_00F7:\n\tv215 = new System.NullReferenceException();\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\n\tgoto L_010B;\nL_010B:\n\tv235 = 0 != 1;\n\tif (v235) goto L_0160;\n\tv240 = 0x6D2BC0(v215, 0, v253, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv292 = *([v240 @ X0_v20]);\n\tv300 = 0x6D2490(v240, 0, v253, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0115:\n\t// 277 IsInst v392 @ X0_v6 (System.IDisposable), typeof(System.IDisposable), v388 @ X19_v2 (System.Collections.IEnumerator)\n\tv393 = v392 == 0;\n\tif (v393) goto L_0145;\n\tgoto L_0144;\n\tv457 = *([v398 @ X8_v5+B0]);\n\tv458 = 0;\n\tv459 = v457 + 8;\n\tv461 = *([v529 @ X11_v7-8]);\n\tv534 = v461 == v399;\n\tif (v534) goto L_013D;\n\tv481 = v528 + 1;\n\tv561 = v481 < v400;\n\tv479 = ~v561;\n\tv483 = v529 + 0x10;\n\tv463 = ~v479;\n\tif (v463) goto L_FFFFFFFF;\n\tv484 = v296;\n\tv485 = 0;\n\tv486 = 0x8909C4(v484, v399, v485, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0144;\nL_013D:\n\tv562 = *([v529 @ X11_v7]);\n\tv563 = v562 << 4;\n\tv564 = v398 + v563;\n\tv565 = v564 + 0x130;\nL_0144:\n\tSystem.IDisposable::Dispose(v392);\nL_0145:\n\tv426 = v244 + 1;\n\tv266 = v426 == 0;\n\tv256 = ~v266;\n\tif (v256) goto L_015B;\n\tv487 = v292 == 0;\n\tv290 = ~v487;\n\tif (v290) goto L_015F;\nL_015B:\n\treturn;\nL_015F:\n\tv288 = new System.TypeLoadException();\nL_0160:\n\tv297 = 0x6D2380(v215, v285, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			//IL_02d0: Expected I4, but got O
			//IL_00c6: Expected I, but got O
			//IL_0101: Expected O, but got I
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_01a9: Expected O, but got I
			//IL_01b8: Expected O, but got I
			//IL_014d: Expected O, but got I
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_RamGraph component = GetComponent<G_RamGraph>();
			m_ramGraph = component;
			G_RamText component2 = GetComponent<G_RamText>();
			m_ramText = component2;
			RectTransform component3 = GetComponent<RectTransform>();
			m_rectTransform = component3;
			Transform transform2 = base.transform;
			IEnumerator enumerator = transform2.GetEnumerator();
			bool flag = enumerator == null;
			int num = 0;
			IEnumerator enumerator2 = enumerator;
			int num2;
			int num3;
			NullReferenceException ex;
			if (flag)
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_033a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num3 = -1;
			}
			else
			{
				Transform transform4 = default(Transform);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0166;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag2 = (long)num5 < 0L;
						bool flag3 = !flag2;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_0166;
					}
					object obj3 = obj2 + 1;
					int num6 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num6;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num7 = 0;
					goto IL_03a8;
					IL_0166:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num7 = 1;
					goto IL_03a8;
					IL_03a8:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v651 @ X0_v42] (should have been resolved before IL gen)");
					Transform transform3 = transform4 as Transform;
					if ((object)transform3 != null)
					{
						Transform parent = transform4.parent;
						Transform transform5 = base.transform;
						if (parent == transform5)
						{
							GameObject item = transform4.gameObject;
							m_childrenGameObjects.Add(item);
						}
						continue;
					}
					throw new InvalidCastException();
				}
				num3 = 0;
				num2 = 0;
				enumerator2 = enumerator;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num3 + 1 != 0 || num2 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			ex = (NullReferenceException)(object)ex2;
			goto IL_033a;
			IL_033a:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x16430F8", Offset = "0x16430F8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this.m_ramGraph, active);\n\tUnityEngine.GameObject::SetActive(this.m_ramGraphGameObject, active);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetGraphActive(bool active)
		{
			m_ramGraph.enabled = active;
			m_ramGraphGameObject.SetActive(active);
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x164353C", Offset = "0x164353C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB3F00]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB0C]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v42);\n\tthis.m_backgroundImages = v42;\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v50);\n\tthis.m_childrenGameObjects = v50;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_RamManager()
		{
			List<Image> backgroundImages = new List<Image>();
			m_backgroundImages = backgroundImages;
			List<GameObject> childrenGameObjects = new List<GameObject>();
			m_childrenGameObjects = childrenGameObjects;
		}
	}
}
