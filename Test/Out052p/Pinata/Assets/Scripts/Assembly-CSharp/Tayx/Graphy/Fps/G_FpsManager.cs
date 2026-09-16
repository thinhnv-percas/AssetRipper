using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	[Token(Token = "0x200003B")]
	public class G_FpsManager : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x18")]
		private GameObject m_fpsGraphGameObject;

		[SerializeField]
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x20")]
		private List<GameObject> m_nonBasicTextGameObjects;

		[SerializeField]
		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x28")]
		private List<Image> m_backgroundImages;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x30")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x38")]
		private G_FpsGraph m_fpsGraph;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x40")]
		private G_FpsMonitor m_fpsMonitor;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x48")]
		private G_FpsText m_fpsText;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x58")]
		private List<GameObject> m_childrenGameObjects;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x60")]
		internal GraphyManager.ModuleState m_previousModuleState;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x64")]
		private GraphyManager.ModuleState m_currentModuleState;

		[Token(Token = "0x6000198")]
		[Address(RVA = "0xB12FA0", Offset = "0xB12FA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0xB1334C", Offset = "0xB1334C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this);\n\treturn;\n")]
		private void Start()
		{
			UpdateParameters();
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0xB134D0", Offset = "0xB134D0", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA9968]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, newModulePosition, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2022533]) = v45;\nL_001B:\n\tv49 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tgoto L_002E;\n\tv69 = *([v65 @ X0_v5+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\t// 40 ConditionalJump @b9, v71 @ TEMP_v11\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v48, methodInfo, v30, v31, v32, v33, v34, v49, v53, v37, v38, v39, v40, v41, v42);\nL_002E:\n\tv116 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tv131 = newModulePosition < 3;\n\tv108 = ~v131;\n\tv105 = newModulePosition - 3;\n\tv99 = v105 == 0;\n\tv132 = ~v99;\n\tv84 = v108 & v132;\n\tif (v84) goto L_00EC;\n\tv81 = 0x1819000 + 0x2A4;\n\tv78 = UnityEngine.Mathf::Abs(v49);\n\tv111 = UnityEngine.Mathf::Abs(v116.y);\n\tv126 = *([v81 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]) + v81;\n\t// 67 IndirectJump v126 @ X8_v10, this.m_rectTransform (UnityEngine.RectTransform), this.m_rectTransform (UnityEngine.RectTransform), 0, methodInfo @ X2 (Il2CppMethodInfo), v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v116 @ V0_v3 (UnityEngine.Vector2), v116.y (System.Single), v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 88 MakeStruct AGGB135B4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB135B4_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 98 MakeStruct AGGB135D0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB135D0_1, X1);\n\tX19 = *([X19+50]);\n\tstack[18] = 0;\n\tV0 = -V9;\n\tV1 = -V8;\n\tX0 = &stack[18];\n\tgoto L_00DA;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0077;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0077;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0077:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 126 MakeStruct AGGB13624_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB13624_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 136 MakeStruct AGGB13640_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB13640_1, X1);\n\tX19 = *([X19+50]);\n\tV1 = -V8;\n\tX0 = &stack[18];\n\tV0 = V9;\n\tstack[18] = 0;\n\tgoto L_00DA;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009D:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 164 MakeStruct AGGB13694_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB13694_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 174 MakeStruct AGGB136B0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB136B0_1, X1);\n\tX19 = *([X19+50]);\n\tstack[18] = 0;\n\tV0 = -V9;\n\tX0 = &stack[18];\n\tgoto L_00D9;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00C2;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C2:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 201 MakeStruct AGGB13700_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB13700_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00ED;\n\tX0 = X20;\n\tX1 = 0;\n\t// 211 MakeStruct AGGB1371C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB1371C_1, X1);\n\tX19 = *([X19+50]);\n\tX0 = &stack[18];\n\tV0 = V9;\n\tstack[18] = 0;\nL_00D9:\n\tV1 = V8;\nL_00DA:\n\tX1 = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00ED;\n\tV0 = stack[18];\n\tV1 = stack[1C];\n\tX0 = X19;\n\tX1 = 0;\n\t// 226 MakeStruct AGGB1374C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchoredPosition(X0, AGGB1374C_1, X1);\nL_00EC:\n\treturn;\nL_00ED:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				int num2 = 25268224 + 676;
				float num3 = Mathf.Abs(anchoredPosition.x);
				float num4 = Mathf.Abs(anchoredPosition2.y);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v126 @ X8_v10 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0xB13770", Offset = "0xB13770", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = silentUpdate == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_000C;\n\tthis.m_previousModuleState = this.m_currentModuleState;\nL_000C:\n\tv17 = state < 4;\n\tv19 = ~v17;\n\tv20 = state - 4;\n\tv22 = v20 == 0;\n\tthis.m_currentModuleState = state;\n\tv27 = ~v22;\n\tv28 = v19 & v27;\n\tif (v28) goto L_003B;\n\tv31 = 0x1819000 + 0x2B4;\n\tv33 = *([v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]) + v31;\n\t// 30 IndirectJump v33 @ X8_v4, this @ X0 (Tayx.Graphy.Fps.G_FpsManager), this @ X0 (Tayx.Graphy.Fps.G_FpsManager), state @ X1 (Tayx.Graphy.GraphyManager+ModuleState), silentUpdate @ X2 (System.Boolean), methodInfo @ X3 (Il2CppMethodInfo), v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_009B;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX1 = 0 | 1;\n\tX0 = X19;\n\tTayx.Graphy.Fps.G_FpsManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_009C;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_0086;\n\tX1 = 0;\n\tgoto L_006F;\nL_003B:\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_009B;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_009C;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_0086;\n\tX1 = 0 | 1;\n\tgoto L_006F;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_009B;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = *([X19+20]);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_009C;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_0086;\n\tX1 = 0 | 2;\nL_006F:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 115 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetOneActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_009B;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetGraphActive(X0, X1, X2);\n\tX0 = *([X19+28]);\nL_0086:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 139 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_009B;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 152 ShiftStack 32\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\treturn;\nL_009B:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009C:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				int num2 = 25268224 + 692;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v33 @ X8_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0xB1399C", Offset = "0xB1399C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this, this.m_previousModuleState, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestorePreviousState()
		{
			SetState(m_previousModuleState);
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0xB13350", Offset = "0xB13350", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F02530]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022534]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv151 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv181 = v151 == 0;\n\tif (v181) goto L_0039;\n\tv134 = this.m_graphyManager;\n\tv221 = 0;\n\tgoto L_003D;\n\tv141 = *([v221 @ X0_v29 (System.Int32)]);\n\t*([v141 @ X9_v10+2A0])(v145, 0, *([v141 @ X9_v10+2A8]), v22, v23, v24, v25, v26, v27, v134.m_backgroundColor, v134.m_backgroundColor.g, v134.m_backgroundColor.b, v134.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv187 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005A;\n\tv223 = new System.NullReferenceException();\nL_003D:\n\tv130 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv105 = Il2CppMethodInfo != 1;\n\tif (v105) goto L_007B;\n\tv230 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v130);\n\tv239 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v230);\n\tv169 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv242 = ~v230.m_value;\n\tv171 = ~v242;\n\tif (v171) goto L_007F;\nL_005A:\n\tTayx.Graphy.Fps.G_FpsGraph::UpdateParameters(this.m_fpsGraph);\n\tv228 = this.m_fpsMonitor;\n\tv231 = v228.m_graphyManager;\n\tv228.m_timeToResetMinMaxFps = v231.m_timeToResetMinMaxFps;\n\tv237 = this.m_fpsText;\n\tv234 = v237.m_graphyManager;\n\tv237.m_updateRate = v234.m_fpsTextUpdateRate;\n\tv216 = this.m_graphyManager;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this, v216.m_fpsModuleState, 0);\n\treturn;\n\tv91 = new System.NullReferenceException();\n\tv101 = new System.NullReferenceException();\nL_007B:\n\tv136 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v129);\nL_007F:\n\tthrow System.TypeLoadException;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						goto IL_00da;
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
			goto IL_00da;
			IL_00da:
			m_fpsGraph.UpdateParameters();
			G_FpsMonitor fpsMonitor = m_fpsMonitor;
			GraphyManager graphyManager2 = fpsMonitor.m_graphyManager;
			fpsMonitor.m_timeToResetMinMaxFps = graphyManager2.TimeToResetMinMaxFps;
			G_FpsText fpsText = m_fpsText;
			GraphyManager graphyManager3 = fpsText.m_graphyManager;
			fpsText.m_updateRate = graphyManager3.FpsTextUpdateRate;
			GraphyManager graphyManager4 = m_graphyManager;
			SetState(graphyManager4.FpsModuleState);
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0xB139F0", Offset = "0xB139F0", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F05820]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022535]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv151 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv181 = v151 == 0;\n\tif (v181) goto L_0039;\n\tv134 = this.m_graphyManager;\n\tv221 = 0;\n\tgoto L_003D;\n\tv141 = *([v221 @ X0_v29 (System.Int32)]);\n\t*([v141 @ X9_v10+2A0])(v145, 0, *([v141 @ X9_v10+2A8]), v22, v23, v24, v25, v26, v27, v134.m_backgroundColor, v134.m_backgroundColor.g, v134.m_backgroundColor.b, v134.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv187 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005A;\n\tv223 = new System.NullReferenceException();\nL_003D:\n\tv130 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv105 = Il2CppMethodInfo != 1;\n\tif (v105) goto L_0078;\n\tv230 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v130);\n\tv237 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v230);\n\tv169 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv240 = ~v230.m_value;\n\tv171 = ~v240;\n\tif (v171) goto L_007C;\nL_005A:\n\tTayx.Graphy.Fps.G_FpsGraph::UpdateParameters(this.m_fpsGraph);\n\tv228 = this.m_fpsMonitor;\n\tv231 = v228.m_graphyManager;\n\tv228.m_timeToResetMinMaxFps = v231.m_timeToResetMinMaxFps;\n\tv216 = this.m_fpsText;\n\tv234 = v216.m_graphyManager;\n\tv216.m_updateRate = v234.m_fpsTextUpdateRate;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this, this.m_currentModuleState, 1);\n\treturn;\n\tv91 = new System.NullReferenceException();\n\tv101 = new System.NullReferenceException();\nL_0078:\n\tv136 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v129);\nL_007C:\n\tthrow System.TypeLoadException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						goto IL_00da;
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
			goto IL_00da;
			IL_00da:
			m_fpsGraph.UpdateParameters();
			G_FpsMonitor fpsMonitor = m_fpsMonitor;
			GraphyManager graphyManager2 = fpsMonitor.m_graphyManager;
			fpsMonitor.m_timeToResetMinMaxFps = graphyManager2.TimeToResetMinMaxFps;
			G_FpsText fpsText = m_fpsText;
			GraphyManager graphyManager3 = fpsText.m_graphyManager;
			fpsText.m_updateRate = graphyManager3.FpsTextUpdateRate;
			SetState(m_currentModuleState, silentUpdate: true);
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xB12FA4", Offset = "0xB12FA4", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EA8710]);\n\tv33 = *([v32 @ X8_v43]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022536]) = v52;\nL_001C:\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv58 = UnityEngine.Transform::get_root(v55);\n\tv184 = UnityEngine.Component::GetComponentInChildren(v58);\n\tthis.m_graphyManager = v184;\n\tv220 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v220;\n\tv225 = UnityEngine.Component::GetComponent(this);\n\tthis.m_fpsGraph = v225;\n\tv240 = UnityEngine.Component::GetComponent(this);\n\tthis.m_fpsMonitor = v240;\n\tv302 = UnityEngine.Component::GetComponent(this);\n\tthis.m_fpsText = v302;\n\tv122 = UnityEngine.Component::get_transform(this);\n\tv210 = UnityEngine.Transform::GetEnumerator(v122);\n\tv212 = v210 == 0;\n\tif (v212) goto L_00FD;\nL_0056:\n\tgoto L_007D;\n\tv515 = *([v489 @ X8_v24+B0]);\n\tv516 = 0;\n\tv517 = v515 + 8;\n\tv519 = *([v564 @ X11_v24-8]);\n\tv569 = v519 == v490;\n\tif (v569) goto L_0076;\n\tv539 = v563 + 1;\n\tv574 = v539 < v491;\n\tv537 = ~v574;\n\tv541 = v564 + 0x10;\n\tv521 = ~v537;\n\tif (v521) goto L_FFFFFFFF;\n\tv542 = v131;\n\tv543 = 0;\n\tv544 = 0x8909C4(v542, v490, v543, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_007D;\nL_0076:\n\tv575 = *([v564 @ X11_v24]);\n\tv576 = v575 << 4;\n\tv577 = v489 + v576;\n\tv578 = v577 + 0x130;\nL_007D:\n\tv387 = System.Collections.IEnumerator::MoveNext(v210);\n\tv389 = v387 == 0;\n\tif (v389) goto L_FFFFFFFF;\n\tv583 = *([v210 @ X0_v39 (System.Collections.IEnumerator)]);\n\tv586 = *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v586) goto L_00A3;\n\tv628 = *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008E:\n\tv633 = *([v628 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v633) goto L_00A6;\n\tv627 = v627 + 1;\n\tv638 = v627 < *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv609 = ~v638;\n\tv628 = v628 + 0x10;\n\tv593 = ~v609;\n\tif (v593) goto L_008E;\nL_00A3:\n\tv656 = 0x8909C4(v210, System.Collections.IEnumerator, 1, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AD;\nL_00A6:\n\tv640 = *([v628 @ X11_v19]) + 1;\n\tv641 = v640 << 4;\n\tv642 = v583 + v641;\n\tv656 = v642 + 0x130;\nL_00AD:\n\t*([v656 @ X0_v44])(v661, v210, *([v656 @ X0_v44+8]), v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_FFFFFFFF;\n\tv146 = v146_asT == 0;\n\tif (v146) goto L_00F7;\n\tv695 = UnityEngine.Transform::get_parent(v661);\n\tv698 = UnityEngine.Component::get_transform(this);\n\tgoto L_00E4;\n\tv703 = *([v699 @ X0_v56+E0]);\n\tv704 = v703 == 0;\n\tv705 = ~v704;\n\tif (v705) goto L_00E4;\n\tv707 = \"il2cpp_codegen_runtime_class_init\"(v699, v697, v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00E4:\n\tv484 = UnityEngine.Object::op_Equality(v695, v698);\n\tv487 = v484 == 0;\n\tif (v487) goto L_0056;\n\tv173 = UnityEngine.Component::get_gameObject(v661);\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(this.m_childrenGameObjects, v173);\n\tgoto L_0056;\n\tgoto L_011B;\nL_00F7:\n\tthrow System.InvalidCastException;\n\tv121 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv180 = new System.NullReferenceException();\nL_00FD:\n\tv215 = new System.NullReferenceException();\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\nL_0111:\n\tv235 = 0 != 1;\n\tif (v235) goto L_0166;\n\tv241 = 0x6D2BC0(v215, 0, v254, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv293 = *([v241 @ X0_v20]);\n\tv304 = 0x6D2490(v241, 0, v254, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_011B:\n\t// 283 IsInst v397 @ X0_v6 (System.IDisposable), typeof(System.IDisposable), v393 @ X19_v2 (System.Collections.IEnumerator)\n\tv398 = v397 == 0;\n\tif (v398) goto L_014B;\n\tgoto L_014A;\n\tv432 = *([v399 @ X8_v5+B0]);\n\tv433 = 0;\n\tv434 = v432 + 8;\n\tv436 = *([v504 @ X11_v7-8]);\n\tv509 = v436 == v400;\n\tif (v509) goto L_0143;\n\tv456 = v503 + 1;\n\tv545 = v456 < v401;\n\tv454 = ~v545;\n\tv458 = v504 + 0x10;\n\tv438 = ~v454;\n\tif (v438) goto L_FFFFFFFF;\n\tv459 = v297;\n\tv460 = 0;\n\tv461 = 0x8909C4(v459, v400, v460, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_014A;\nL_0143:\n\tv546 = *([v504 @ X11_v7]);\n\tv547 = v546 << 4;\n\tv548 = v399 + v547;\n\tv549 = v548 + 0x130;\nL_014A:\n\tSystem.IDisposable::Dispose(v397);\nL_014B:\n\tv427 = v245 + 1;\n\tv267 = v427 == 0;\n\tv257 = ~v267;\n\tif (v257) goto L_0161;\n\tv462 = v293 == 0;\n\tv291 = ~v462;\n\tif (v291) goto L_0165;\nL_0161:\n\treturn;\nL_0165:\n\tv289 = new System.TypeLoadException();\nL_0166:\n\tv298 = 0x6D2380(v215, v286, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\n// 221 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			//IL_02e4: Expected I4, but got O
			//IL_00da: Expected I, but got O
			//IL_0115: Expected O, but got I
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01bd: Expected O, but got I
			//IL_01cc: Expected O, but got I
			//IL_0161: Expected O, but got I
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			RectTransform component = GetComponent<RectTransform>();
			m_rectTransform = component;
			G_FpsGraph component2 = GetComponent<G_FpsGraph>();
			m_fpsGraph = component2;
			G_FpsMonitor component3 = GetComponent<G_FpsMonitor>();
			m_fpsMonitor = component3;
			G_FpsText component4 = GetComponent<G_FpsText>();
			m_fpsText = component4;
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
					goto IL_034e;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_017a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag2 = (long)num5 < 0L;
						bool flag3 = !flag2;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_017a;
					}
					object obj3 = obj2 + 1;
					int num6 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num6;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num7 = 0;
					goto IL_03bc;
					IL_017a:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num7 = 1;
					goto IL_03bc;
					IL_03bc:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v656 @ X0_v44] (should have been resolved before IL gen)");
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
			goto IL_034e;
			IL_034e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0xB13954", Offset = "0xB13954", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this.m_fpsGraph, active);\n\tUnityEngine.GameObject::SetActive(this.m_fpsGraphGameObject, active);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetGraphActive(bool active)
		{
			m_fpsGraph.enabled = active;
			m_fpsGraphGameObject.SetActive(active);
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0xB13B68", Offset = "0xB13B68", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDA938]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022537]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v46);\n\tthis.m_nonBasicTextGameObjects = v46;\n\tv54 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v54);\n\tthis.m_backgroundImages = v54;\n\tv60 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v60);\n\tthis.m_childrenGameObjects = v60;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_FpsManager()
		{
			List<GameObject> nonBasicTextGameObjects = new List<GameObject>();
			m_nonBasicTextGameObjects = nonBasicTextGameObjects;
			List<Image> backgroundImages = new List<Image>();
			m_backgroundImages = backgroundImages;
			List<GameObject> childrenGameObjects = new List<GameObject>();
			m_childrenGameObjects = childrenGameObjects;
		}
	}
}
