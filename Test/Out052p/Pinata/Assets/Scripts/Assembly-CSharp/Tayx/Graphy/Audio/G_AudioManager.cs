using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	[Token(Token = "0x200003F")]
	public class G_AudioManager : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x18")]
		private GameObject m_audioGraphGameObject;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x20")]
		private Text m_audioDbText;

		[SerializeField]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x28")]
		private List<Image> m_backgroundImages;

		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x30")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x38")]
		private G_AudioGraph m_audioGraph;

		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x40")]
		private G_AudioMonitor m_audioMonitor;

		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x48")]
		private G_AudioText m_audioText;

		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x58")]
		private List<GameObject> m_childrenGameObjects;

		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x60")]
		internal GraphyManager.ModuleState m_previousModuleState;

		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x64")]
		private GraphyManager.ModuleState m_currentModuleState;

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0xB0D860", Offset = "0xB0D860", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioManager::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xB0DC0C", Offset = "0xB0DC0C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this);\n\treturn;\n")]
		private void Start()
		{
			UpdateParameters();
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xB0DD84", Offset = "0xB0DD84", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1F054F8]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, newModulePosition, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20224FE]) = v47;\nL_001C:\n\tv51 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tgoto L_002F;\n\tv80 = *([v74 @ X0_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\t// 41 ConditionalJump @b9, v82 @ TEMP_v12\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v74, v50, methodInfo, v32, v33, v34, v35, v36, v51, v57, v39, v40, v41, v42, v43, v44);\nL_002F:\n\tv60 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tUnityEngine.UI.Text::set_alignment(this.m_audioDbText, 2);\n\tv144 = newModulePosition < 3;\n\tv119 = ~v144;\n\tv116 = newModulePosition - 3;\n\tv110 = v116 == 0;\n\tv145 = ~v110;\n\tv95 = v119 & v145;\n\tif (v95) goto L_00F5;\n\tv92 = 0x1819000 + 0x280;\n\tv89 = UnityEngine.Mathf::Abs(v51);\n\tv126 = UnityEngine.Mathf::Abs(v60.y);\n\tv139 = *([v92 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]) + v92;\n\t// 75 IndirectJump v139 @ X8_v10, this.m_audioDbText (UnityEngine.UI.Text), this.m_audioDbText (UnityEngine.UI.Text), 2, 0, v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v60 @ V0_v3 (UnityEngine.Vector2), v60.y (System.Single), v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0059;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0059;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0059:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 96 MakeStruct AGGB0DE88_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0DE88_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 106 MakeStruct AGGB0DEA4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0DEA4_1, X1);\n\tX19 = *([X19+50]);\n\tstack[8] = 0;\n\tV0 = -V9;\n\tV1 = -V8;\n\tX0 = &stack[8];\n\tgoto L_00E2;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_007F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007F:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 134 MakeStruct AGGB0DEF8_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0DEF8_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 144 MakeStruct AGGB0DF14_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0DF14_1, X1);\n\tX19 = *([X19+50]);\n\tV1 = -V8;\n\tX0 = &stack[8];\n\tV0 = V9;\n\tstack[8] = 0;\n\tgoto L_00E2;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A5;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A5;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A5:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 172 MakeStruct AGGB0DF68_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0DF68_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 182 MakeStruct AGGB0DF84_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0DF84_1, X1);\n\tX19 = *([X19+50]);\n\tstack[8] = 0;\n\tV0 = -V9;\n\tX0 = &stack[8];\n\tgoto L_00E1;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00CA;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00CA;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CA:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 209 MakeStruct AGGB0DFD4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0DFD4_1, X1);\n\tX20 = *([X19+50]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00F7;\n\tX0 = X20;\n\tX1 = 0;\n\t// 219 MakeStruct AGGB0DFF0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0DFF0_1, X1);\n\tX19 = *([X19+50]);\n\tX0 = &stack[8];\n\tV0 = V9;\n\tstack[8] = 0;\nL_00E1:\n\tV1 = V8;\nL_00E2:\n\tX1 = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00F7;\n\tV0 = stack[8];\n\tV1 = stack[C];\n\tX0 = X19;\n\tX1 = 0;\n\t// 234 MakeStruct AGGB0E020_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchoredPosition(X0, AGGB0E020_1, X1);\nL_00F5:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00F7:\n\t;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(GraphyManager.ModulePosition newModulePosition)
		{
			//IL_00e7: Expected O, but got I
			Vector2 anchoredPosition = m_rectTransform.anchoredPosition;
			Vector2 anchoredPosition2 = m_rectTransform.anchoredPosition;
			m_audioDbText.alignment = TextAnchor.UpperRight;
			bool flag = newModulePosition < GraphyManager.ModulePosition.BOTTOM_LEFT;
			bool flag2 = !flag;
			int num = (int)(newModulePosition - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 640;
				float num3 = Mathf.Abs(anchoredPosition.x);
				float num4 = Mathf.Abs(anchoredPosition2.y);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v139 @ X8_v10 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xB0E04C", Offset = "0xB0E04C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = silentUpdate == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_000C;\n\tthis.m_previousModuleState = this.m_currentModuleState;\nL_000C:\n\tv17 = state < 4;\n\tv19 = ~v17;\n\tv20 = state - 4;\n\tv22 = v20 == 0;\n\tthis.m_currentModuleState = state;\n\tv27 = ~v22;\n\tv28 = v19 & v27;\n\tif (v28) goto L_003B;\n\tv31 = 0x1819000 + 0x290;\n\tv33 = *([v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]) + v31;\n\t// 30 IndirectJump v33 @ X8_v4, this @ X0 (Tayx.Graphy.Audio.G_AudioManager), this @ X0 (Tayx.Graphy.Audio.G_AudioManager), state @ X1 (Tayx.Graphy.GraphyManager+ModuleState), silentUpdate @ X2 (System.Boolean), methodInfo @ X3 (Il2CppMethodInfo), v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007F;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Audio.G_AudioManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_0080;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_006A;\n\tX1 = 0 | 1;\n\tgoto L_0053;\nL_003B:\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007F;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX1 = 0 | 1;\n\tX0 = X19;\n\tTayx.Graphy.Audio.G_AudioManager::SetGraphActive(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_0080;\n\tX8 = *([X8+1E]);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_006A;\n\tX1 = 0;\nL_0053:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 87 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetOneActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007F;\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\tX0 = X19;\n\tX1 = 0;\n\tTayx.Graphy.Audio.G_AudioManager::SetGraphActive(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\tX0 = *([X19+28]);\nL_006A:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 111 ShiftStack 32\n\tX0 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_007F;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0;\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 124 ShiftStack 32\n\tUnityEngine.GameObject::SetActive(X0, X1, X2);\n\treturn;\nL_007F:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0080:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				int num2 = 25268224 + 656;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v2 (System.Int32)+state @ X1 (Tayx.Graphy.GraphyManager+ModuleState)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v33 @ X8_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xB0E214", Offset = "0xB0E214", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this, this.m_previousModuleState, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestorePreviousState()
		{
			SetState(m_previousModuleState);
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xB0DC10", Offset = "0xB0DC10", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED9948]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224FF]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv145 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv179 = v145 == 0;\n\tif (v179) goto L_0039;\n\tv175 = this.m_graphyManager;\n\tv214 = 0;\n\tgoto L_003D;\n\tv134 = *([v214 @ X0_v31 (System.Int32)]);\n\t*([v134 @ X9_v8+2A0])(v138, 0, *([v134 @ X9_v8+2A8]), v22, v23, v24, v25, v26, v27, v175.m_backgroundColor, v175.m_backgroundColor.g, v175.m_backgroundColor.b, v175.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv213 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005A;\n\tv216 = new System.NullReferenceException();\nL_003D:\n\tv171 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv147 = Il2CppMethodInfo != 1;\n\tif (v147) goto L_0077;\n\tv251 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v171);\n\tv252 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v251);\n\tv197 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv255 = ~v251.m_value;\n\tv199 = ~v255;\n\tif (v199) goto L_007B;\nL_005A:\n\tTayx.Graphy.Audio.G_AudioGraph::UpdateParameters(this.m_audioGraph);\n\tTayx.Graphy.Audio.G_AudioMonitor::UpdateParameters(this.m_audioMonitor);\n\tv125 = this.m_audioText;\n\tv116 = v125.m_graphyManager;\n\tv125.m_updateRate = v116.m_audioTextUpdateRate;\n\tv126 = this.m_graphyManager;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this, v126.m_audioModuleState, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv129 = new System.NullReferenceException();\nL_0077:\n\tv177 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v170);\nL_007B:\n\tthrow System.TypeLoadException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			m_audioGraph.UpdateParameters();
			m_audioMonitor.UpdateParameters();
			G_AudioText audioText = m_audioText;
			GraphyManager graphyManager2 = audioText.m_graphyManager;
			audioText.m_updateRate = graphyManager2.AudioTextUpdateRate;
			GraphyManager graphyManager3 = m_graphyManager;
			SetState(graphyManager3.AudioModuleState);
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xB0E324", Offset = "0xB0E324", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB1528]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022500]) = v38;\nL_0015:\n\tv41 = 0;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv142 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv176 = v142 == 0;\n\tif (v176) goto L_0039;\n\tv172 = this.m_graphyManager;\n\tv211 = 0;\n\tgoto L_003D;\n\tv131 = *([v211 @ X0_v31 (System.Int32)]);\n\t*([v131 @ X9_v8+2A0])(v135, 0, *([v131 @ X9_v8+2A8]), v22, v23, v24, v25, v26, v27, v172.m_backgroundColor, v172.m_backgroundColor.g, v172.m_backgroundColor.b, v172.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv210 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005A;\n\tv213 = new System.NullReferenceException();\nL_003D:\n\tv168 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv144 = Il2CppMethodInfo != 1;\n\tif (v144) goto L_0074;\n\tv249 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v168);\n\tv250 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v249);\n\tv194 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv253 = ~v249.m_value;\n\tv196 = ~v253;\n\tif (v196) goto L_0078;\nL_005A:\n\tTayx.Graphy.Audio.G_AudioGraph::UpdateParameters(this.m_audioGraph);\n\tTayx.Graphy.Audio.G_AudioMonitor::UpdateParameters(this.m_audioMonitor);\n\tv123 = this.m_audioText;\n\tv116 = v123.m_graphyManager;\n\tv123.m_updateRate = v116.m_audioTextUpdateRate;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this, this.m_currentModuleState, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv126 = new System.NullReferenceException();\nL_0074:\n\tv174 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v167);\nL_0078:\n\tthrow System.TypeLoadException;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			m_audioGraph.UpdateParameters();
			m_audioMonitor.UpdateParameters();
			G_AudioText audioText = m_audioText;
			GraphyManager graphyManager2 = audioText.m_graphyManager;
			audioText.m_updateRate = graphyManager2.AudioTextUpdateRate;
			SetState(m_currentModuleState, silentUpdate: true);
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xB0D864", Offset = "0xB0D864", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EB55E8]);\n\tv33 = *([v32 @ X8_v43]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022501]) = v52;\nL_001C:\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv58 = UnityEngine.Transform::get_root(v55);\n\tv184 = UnityEngine.Component::GetComponentInChildren(v58);\n\tthis.m_graphyManager = v184;\n\tv220 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v220;\n\tv225 = UnityEngine.Component::GetComponent(this);\n\tthis.m_audioGraph = v225;\n\tv240 = UnityEngine.Component::GetComponent(this);\n\tthis.m_audioMonitor = v240;\n\tv302 = UnityEngine.Component::GetComponent(this);\n\tthis.m_audioText = v302;\n\tv122 = UnityEngine.Component::get_transform(this);\n\tv210 = UnityEngine.Transform::GetEnumerator(v122);\n\tv212 = v210 == 0;\n\tif (v212) goto L_00FD;\nL_0056:\n\tgoto L_007D;\n\tv515 = *([v489 @ X8_v24+B0]);\n\tv516 = 0;\n\tv517 = v515 + 8;\n\tv519 = *([v564 @ X11_v24-8]);\n\tv569 = v519 == v490;\n\tif (v569) goto L_0076;\n\tv539 = v563 + 1;\n\tv574 = v539 < v491;\n\tv537 = ~v574;\n\tv541 = v564 + 0x10;\n\tv521 = ~v537;\n\tif (v521) goto L_FFFFFFFF;\n\tv542 = v131;\n\tv543 = 0;\n\tv544 = 0x8909C4(v542, v490, v543, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_007D;\nL_0076:\n\tv575 = *([v564 @ X11_v24]);\n\tv576 = v575 << 4;\n\tv577 = v489 + v576;\n\tv578 = v577 + 0x130;\nL_007D:\n\tv387 = System.Collections.IEnumerator::MoveNext(v210);\n\tv389 = v387 == 0;\n\tif (v389) goto L_FFFFFFFF;\n\tv583 = *([v210 @ X0_v39 (System.Collections.IEnumerator)]);\n\tv586 = *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v586) goto L_00A3;\n\tv628 = *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008E:\n\tv633 = *([v628 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v633) goto L_00A6;\n\tv627 = v627 + 1;\n\tv638 = v627 < *([v583 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv609 = ~v638;\n\tv628 = v628 + 0x10;\n\tv593 = ~v609;\n\tif (v593) goto L_008E;\nL_00A3:\n\tv656 = 0x8909C4(v210, System.Collections.IEnumerator, 1, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AD;\nL_00A6:\n\tv640 = *([v628 @ X11_v19]) + 1;\n\tv641 = v640 << 4;\n\tv642 = v583 + v641;\n\tv656 = v642 + 0x130;\nL_00AD:\n\t*([v656 @ X0_v44])(v661, v210, *([v656 @ X0_v44+8]), v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_FFFFFFFF;\n\tv146 = v146_asT == 0;\n\tif (v146) goto L_00F7;\n\tv695 = UnityEngine.Transform::get_parent(v661);\n\tv698 = UnityEngine.Component::get_transform(this);\n\tgoto L_00E4;\n\tv703 = *([v699 @ X0_v56+E0]);\n\tv704 = v703 == 0;\n\tv705 = ~v704;\n\tif (v705) goto L_00E4;\n\tv707 = \"il2cpp_codegen_runtime_class_init\"(v699, v697, v75, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00E4:\n\tv484 = UnityEngine.Object::op_Equality(v695, v698);\n\tv487 = v484 == 0;\n\tif (v487) goto L_0056;\n\tv173 = UnityEngine.Component::get_gameObject(v661);\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(this.m_childrenGameObjects, v173);\n\tgoto L_0056;\n\tgoto L_011B;\nL_00F7:\n\tthrow System.InvalidCastException;\n\tv121 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv180 = new System.NullReferenceException();\nL_00FD:\n\tv215 = new System.NullReferenceException();\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\nL_0111:\n\tv235 = 0 != 1;\n\tif (v235) goto L_0166;\n\tv241 = 0x6D2BC0(v215, 0, v254, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv293 = *([v241 @ X0_v20]);\n\tv304 = 0x6D2490(v241, 0, v254, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_011B:\n\t// 283 IsInst v397 @ X0_v6 (System.IDisposable), typeof(System.IDisposable), v393 @ X19_v2 (System.Collections.IEnumerator)\n\tv398 = v397 == 0;\n\tif (v398) goto L_014B;\n\tgoto L_014A;\n\tv432 = *([v399 @ X8_v5+B0]);\n\tv433 = 0;\n\tv434 = v432 + 8;\n\tv436 = *([v504 @ X11_v7-8]);\n\tv509 = v436 == v400;\n\tif (v509) goto L_0143;\n\tv456 = v503 + 1;\n\tv545 = v456 < v401;\n\tv454 = ~v545;\n\tv458 = v504 + 0x10;\n\tv438 = ~v454;\n\tif (v438) goto L_FFFFFFFF;\n\tv459 = v297;\n\tv460 = 0;\n\tv461 = 0x8909C4(v459, v400, v460, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_014A;\nL_0143:\n\tv546 = *([v504 @ X11_v7]);\n\tv547 = v546 << 4;\n\tv548 = v399 + v547;\n\tv549 = v548 + 0x130;\nL_014A:\n\tSystem.IDisposable::Dispose(v397);\nL_014B:\n\tv427 = v245 + 1;\n\tv267 = v427 == 0;\n\tv257 = ~v267;\n\tif (v257) goto L_0161;\n\tv462 = v293 == 0;\n\tv291 = ~v462;\n\tif (v291) goto L_0165;\nL_0161:\n\treturn;\nL_0165:\n\tv289 = new System.TypeLoadException();\nL_0166:\n\tv298 = 0x6D2380(v215, v286, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\n// 221 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			G_AudioGraph component2 = GetComponent<G_AudioGraph>();
			m_audioGraph = component2;
			G_AudioMonitor component3 = GetComponent<G_AudioMonitor>();
			m_audioMonitor = component3;
			G_AudioText component4 = GetComponent<G_AudioText>();
			m_audioText = component4;
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

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xB0E1CC", Offset = "0xB0E1CC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this.m_audioGraph, active);\n\tUnityEngine.GameObject::SetActive(this.m_audioGraphGameObject, active);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetGraphActive(bool active)
		{
			m_audioGraph.enabled = active;
			m_audioGraphGameObject.SetActive(active);
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xB0E490", Offset = "0xB0E490", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAB600]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022502]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v42);\n\tthis.m_backgroundImages = v42;\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v50);\n\tthis.m_childrenGameObjects = v50;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_AudioManager()
		{
			List<Image> backgroundImages = new List<Image>();
			m_backgroundImages = backgroundImages;
			List<GameObject> childrenGameObjects = new List<GameObject>();
			m_childrenGameObjects = childrenGameObjects;
		}
	}
}
