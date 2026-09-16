using System;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.UI;
using Tayx.Graphy.Utils;
using Tayx.Graphy.Utils.NumString;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Advanced
{
	[Token(Token = "0x2000042")]
	public class G_AdvancedData : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x18")]
		private List<Image> m_backgroundImages;

		[SerializeField]
		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x20")]
		private Text m_graphicsDeviceVersionText;

		[SerializeField]
		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x28")]
		private Text m_processorTypeText;

		[SerializeField]
		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x30")]
		private Text m_operatingSystemText;

		[SerializeField]
		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x38")]
		private Text m_systemMemoryText;

		[SerializeField]
		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x40")]
		private Text m_graphicsDeviceNameText;

		[SerializeField]
		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x48")]
		private Text m_graphicsMemorySizeText;

		[SerializeField]
		[Token(Token = "0x40001D7")]
		[FieldOffset(Offset = "0x50")]
		private Text m_screenResolutionText;

		[SerializeField]
		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x58")]
		private Text m_gameWindowResolutionText;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764794", Offset = "0x764794")]
		[SerializeField]
		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x60")]
		private float m_updateRate;

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x68")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x70")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x78")]
		private float m_deltaTime;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x80")]
		private StringBuilder m_sb;

		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x88")]
		internal GraphyManager.ModuleState m_previousModuleState;

		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x8C")]
		private GraphyManager.ModuleState m_currentModuleState;

		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x90")]
		private readonly string[] m_windowStrings;

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xB0AE68", Offset = "0xB0AE68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Advanced.G_AdvancedData::Init(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Init();
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xB0BA74", Offset = "0xB0BA74", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EFFDF0]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224F4]) = v42;\nL_0019:\n\tv47 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv50 = this.m_deltaTime + v47;\n\tthis.m_deltaTime = v50;\n\tv51 = 1f / this.m_updateRate;\n\tv63 = v50 <= v51;\n\tif (v63) goto L_010D;\n\tSystem.Text.StringBuilder::set_Length(this.m_sb, 0);\n\tv225 = this.m_windowStrings;\n\tv287 = v225.Length == 0;\n\tif (v287) goto L_0111;\n\tv315 = System.Text.StringBuilder::Append(this.m_sb, v225[0]);\n\tv317 = UnityEngine.Screen::get_width();\n\tgoto L_0051;\n\tv323 = *([v310 @ X8_v10+E0]);\n\tv324 = v323 == 0;\n\tv325 = ~v324;\n\tif (v325) goto L_0051;\n\tv331 = v310;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v331, v314, v296, v27, v28, v29, v30, v31, v50, v51, v49, v35, v36, v37, v38, v39);\nL_0051:\n\tv301 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v317);\n\tv208 = System.Text.StringBuilder::Append(v315, v301);\n\tv226 = this.m_windowStrings;\n\tv333 = v226.Length < 1;\n\tv199 = ~v333;\n\tv193 = v226.Length - 1;\n\tv181 = v193 == 0;\n\tv334 = ~v199;\n\tv151 = v334 | v181;\n\tif (v151) goto L_0111;\n\tv336 = System.Text.StringBuilder::Append(v208, v226[1]);\n\tv338 = UnityEngine.Screen::get_height();\n\tv302 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v338);\n\tv209 = System.Text.StringBuilder::Append(v336, v302);\n\tv227 = this.m_windowStrings;\n\tv341 = v227.Length < 2;\n\tv200 = ~v341;\n\tv194 = v227.Length - 2;\n\tv182 = v194 == 0;\n\tv342 = ~v200;\n\tv152 = v342 | v182;\n\tif (v152) goto L_0111;\n\tv344 = System.Text.StringBuilder::Append(v209, v227[2]);\n\tv346 = UnityEngine.Screen::get_currentResolution();\n\tv349 = 0x10D3F84(&v346 @ X0_v30 (UnityEngine.Resolution), 0, 0, v27, v28, v29, v30, v31, v50, v51, 1f, v35, v36, v37, v38, v39);\n\tv303 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v349);\n\tv210 = System.Text.StringBuilder::Append(v344, v303);\n\tv228 = this.m_windowStrings;\n\tv352 = v228.Length < 3;\n\tv201 = ~v352;\n\tv195 = v228.Length - 3;\n\tv183 = v195 == 0;\n\tv353 = ~v201;\n\tv153 = v353 | v183;\n\tif (v153) goto L_0111;\n\tv211 = System.Text.StringBuilder::Append(v210, v228[3]);\n\tv229 = this.m_windowStrings;\n\tv354 = v229.Length < 4;\n\tv202 = ~v354;\n\tv196 = v229.Length - 4;\n\tv184 = v196 == 0;\n\tv355 = ~v202;\n\tv154 = v355 | v184;\n\tif (v154) goto L_0111;\n\tv357 = System.Text.StringBuilder::Append(v211, v229[4]);\n\tv359 = UnityEngine.Screen::get_dpi();\n\tgoto L_00D9;\n\tv366 = *([v362 @ X0_v39+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_00D9;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v362, v356, v299, v27, v28, v29, v30, v31, v359, v51, v49, v35, v36, v37, v38, v39);\nL_00D9:\n\tv304 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v359);\n\tv212 = System.Text.StringBuilder::Append(v357, v304);\n\tv230 = this.m_windowStrings;\n\tv374 = v230.Length < 5;\n\tv98 = ~v374;\n\tv96 = v230.Length - 5;\n\tv92 = v96 == 0;\n\tv375 = ~v98;\n\tv82 = v375 | v92;\n\tif (v82) goto L_0111;\n\tv376 = System.Text.StringBuilder::Append(v212, v230[5]);\n\tv305 = System.Text.StringBuilder::ToString(this.m_sb);\n\tthis = UnityEngine.UI.Text::set_text(this.m_gameWindowResolutionText, v305);\n\tthis.m_deltaTime = 0f;\nL_010D:\n\treturn;\n\tv206 = new System.NullReferenceException();\n\tv237 = new System.NullReferenceException();\nL_0111:\n\tv293 = new System.IndexOutOfRangeException();\n\tthrow v293;\n\treturn;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_00d1: Expected O, but got I4
			//IL_018d: Expected O, but got I4
			//IL_0253: Expected O, but got I4
			//IL_02de: Expected O, but got I4
			//IL_039f: Expected O, but got I4
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = (m_deltaTime += unscaledDeltaTime);
			float num2 = 1f / m_updateRate;
			if (!(num > num2))
			{
				return;
			}
			m_sb.Length = 0;
			string[] windowStrings = m_windowStrings;
			if (windowStrings.Length != 0)
			{
				StringBuilder stringBuilder = m_sb.Append(windowStrings[0]);
				int width = Screen.width;
				string value = width.ToStringNonAlloc();
				StringBuilder stringBuilder2 = stringBuilder.Append(value);
				string[] windowStrings2 = m_windowStrings;
				bool flag = windowStrings2.Length < 1;
				bool flag2 = !flag;
				object obj = windowStrings2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					StringBuilder stringBuilder3 = stringBuilder2.Append(windowStrings2[1]);
					int height = Screen.height;
					string value2 = height.ToStringNonAlloc();
					StringBuilder stringBuilder4 = stringBuilder3.Append(value2);
					string[] windowStrings3 = m_windowStrings;
					bool flag5 = windowStrings3.Length < 2;
					bool flag6 = !flag5;
					object obj2 = windowStrings3.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						StringBuilder stringBuilder5 = stringBuilder4.Append(windowStrings3[2]);
						Resolution currentResolution = Screen.currentResolution;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D3F84 (inside UnityEngine.RequireComponent::.ctor +0x48)");
						int value4 = default(int);
						string value3 = value4.ToStringNonAlloc();
						StringBuilder stringBuilder6 = stringBuilder5.Append(value3);
						string[] windowStrings4 = m_windowStrings;
						bool flag9 = windowStrings4.Length < 3;
						bool flag10 = !flag9;
						object obj3 = windowStrings4.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							StringBuilder stringBuilder7 = stringBuilder6.Append(windowStrings4[3]);
							string[] windowStrings5 = m_windowStrings;
							bool flag13 = windowStrings5.Length < 4;
							bool flag14 = !flag13;
							object obj4 = windowStrings5.Length - 4;
							bool flag15 = obj4 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								StringBuilder stringBuilder8 = stringBuilder7.Append(windowStrings5[4]);
								float dpi = Screen.dpi;
								string value5 = dpi.ToStringNonAlloc();
								StringBuilder stringBuilder9 = stringBuilder8.Append(value5);
								string[] windowStrings6 = m_windowStrings;
								bool flag17 = windowStrings6.Length < 5;
								bool flag18 = !flag17;
								object obj5 = windowStrings6.Length - 5;
								bool flag19 = obj5 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									StringBuilder stringBuilder10 = stringBuilder9.Append(windowStrings6[5]);
									string text = m_sb.ToString();
									m_gameWindowResolutionText.text = text;
									m_deltaTime = 0f;
									return;
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0xB0BD44", Offset = "0xB0BD44", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ECF700]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, newModulePosition, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20224F5]) = v45;\nL_0017:\n\tv46 = this.m_backgroundImages;\n\tv49 = v46._size == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0020;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0020:\n\tv69 = v46._items;\n\tv73 = UnityEngine.UI.Graphic::get_rectTransform(v69[0]);\n\tv76 = UnityEngine.RectTransform::get_anchoredPosition(v73);\n\tgoto L_003C;\n\tv145 = *([v141 @ X0_v10+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\t// 54 ConditionalJump @b14, v147 @ TEMP_v16\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v77, methodInfo, v30, v31, v32, v33, v34, v76, v75, v37, v38, v39, v40, v41, v42);\nL_003C:\n\tv124 = UnityEngine.RectTransform::get_anchoredPosition(this.m_rectTransform);\n\tv151 = newModulePosition < 3;\n\tv116 = ~v151;\n\tv113 = newModulePosition - 3;\n\tv107 = v113 == 0;\n\tv152 = ~v107;\n\tv92 = v116 & v152;\n\tif (v92) goto L_0203;\n\tv89 = 0x1819000 + 0x270;\n\tv119 = UnityEngine.Mathf::Abs(v76);\n\tv86 = UnityEngine.Mathf::Abs(v124.y);\n\tv134 = *([v89 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]) + v89;\n\t// 81 IndirectJump v134 @ X8_v13, this.m_rectTransform (UnityEngine.RectTransform), this.m_rectTransform (UnityEngine.RectTransform), 0, methodInfo @ X2 (Il2CppMethodInfo), v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v124 @ V0_v4 (UnityEngine.Vector2), v124.y (System.Single), v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+70]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005F:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 102 MakeStruct AGGB0BE54_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0BE54_1, X1);\n\tX20 = *([X19+70]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 112 MakeStruct AGGB0BE70_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0BE70_1, X1);\n\tX20 = *([X19+70]);\n\tV1 = -V9;\n\tX0 = X29 - 0x18;\n\tV0 = 0;\n\t*([X29-18]) = 0;\n\tgoto L_00C3;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+70]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0085;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0085;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0085:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 140 MakeStruct AGGB0BEC4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0BEC4_1, X1);\n\tX20 = *([X19+70]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_up(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 150 MakeStruct AGGB0BEE0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0BEE0_1, X1);\n\tX20 = *([X19+70]);\n\tV1 = -V9;\n\tX0 = X29 - 0x18;\n\tV0 = 0;\n\t*([X29-18]) = 0;\n\tgoto L_0171;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+70]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00AB;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AB;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AB:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 178 MakeStruct AGGB0BF34_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0BF34_1, X1);\n\tX20 = *([X19+70]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 188 MakeStruct AGGB0BF50_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0BF50_1, X1);\n\tX20 = *([X19+70]);\n\t*([X29-18]) = 0;\n\tX0 = X29 - 0x18;\n\tV0 = 0;\n\tV1 = V9;\nL_00C3:\n\tX1 = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tV0 = *([X29-18]);\n\tV1 = *([X29-14]);\n\tX0 = X20;\n\tX1 = 0;\n\t// 203 MakeStruct AGGB0BF80_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchoredPosition(X0, AGGB0BF80_1, X1);\n\tX20 = *([X19+18]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X20+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D6;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_00D6:\n\tX8 = *([X20+10]);\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.UI.Graphic::get_rectTransform(X0, X1);\n\tX20 = X0;\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_one(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 228 MakeStruct AGGB0BFC8_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0BFC8_1, X1);\n\tX20 = *([X19+18]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X20+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00EF;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_00EF:\n\tX8 = *([X20+10]);\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.UI.Graphic::get_rectTransform(X0, X1);\n\tX20 = X0;\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 253 MakeStruct AGGB0C010_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0C010_1, X1);\n\tX20 = *([X19+18]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X20+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0108;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_0108:\n\tX8 = *([X20+10]);\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.UI.Graphic::get_rectTransform(X0, X1);\n\tX20 = X0;\n\tV0 = -V8;\n\tX0 = &stack[8];\n\tV1 = 0;\n\tX1 = 0;\n\tstack[8] = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tV0 = stack[8];\n\tV1 = stack[C];\n\tX0 = X20;\n\tX1 = 0;\n\t// 283 MakeStruct AGGB0C06C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchoredPosition(X0, AGGB0C06C_1, X1);\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+38]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+40]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+48]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+58]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tUnityEngine.UI.Text::set_alignment(X0, X1, X2);\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0 | 2;\n\tgoto L_01F9;\n\tX8 = *([1EFD6E0]);\n\tX20 = *([X19+70]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0159;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0159;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0159:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_right(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 352 MakeStruct AGGB0C144_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGGB0C144_1, X1);\n\tX20 = *([X19+70]);\n\tX0 = 0;\n\tV0 = UnityEngine.Vector2::get_zero(X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\t// 362 MakeStruct AGGB0C160_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGGB0C160_1, X1);\n\tX20 = *([X19+70]);\n\t*([X29-18]) = 0;\n\tX0 = X29 - 0x18;\n\tV0 = 0;\n\tV1 = V9;\nL_0171:\n\tX1 = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, \n// ... truncated")]
		public void SetPosition(GraphyManager.ModulePosition newModulePosition)
		{
			//IL_0136: Expected O, but got I
			List<Image> backgroundImages = m_backgroundImages;
			if (backgroundImages.Count == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Image[] items = backgroundImages._items;
			RectTransform rectTransform = items[0].rectTransform;
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			Vector2 anchoredPosition2 = m_rectTransform.anchoredPosition;
			bool flag = newModulePosition < GraphyManager.ModulePosition.BOTTOM_LEFT;
			bool flag2 = !flag;
			int num = (int)(newModulePosition - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 624;
				float num3 = Mathf.Abs(anchoredPosition.x);
				float num4 = Mathf.Abs(anchoredPosition2.y);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X9_v2 (System.Int32)+newModulePosition @ X1 (Tayx.Graphy.GraphyManager+ModulePosition)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v134 @ X8_v13 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0xB0C344", Offset = "0xB0C344", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = silentUpdate == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0010;\n\tthis.m_previousModuleState = this.m_currentModuleState;\nL_0010:\n\tthis.m_currentModuleState = state;\n\tv23 = UnityEngine.Component::get_gameObject(this);\n\tv25 = state < 3;\n\tv26 = ~v25;\n\tv34 = ~v26;\n\tUnityEngine.GameObject::SetActive(v23, v34);\n\tv52 = state < 2;\n\tv53 = ~v52;\n\tv54 = state - 2;\n\tv56 = v54 == 0;\n\tv61 = ~v56;\n\tv62 = v53 & v61;\n\tif (v62) goto L_FFFFFFFF;\n\tv85 = this.m_graphyManager;\n\tv96 = v85.m_background == 0;\n\tv101 = ~v96;\n\tgoto L_0045;\nL_0045:\n\tv120 = Tayx.Graphy.Utils.G_ExtensionMethods::SetAllActive(this.m_backgroundImages, v103);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetState(GraphyManager.ModuleState state, bool silentUpdate = false)
		{
			if (!silentUpdate)
			{
				m_previousModuleState = m_currentModuleState;
			}
			m_currentModuleState = state;
			GameObject gameObject = base.gameObject;
			bool flag = state < GraphyManager.ModuleState.BACKGROUND;
			bool flag2 = !flag;
			bool active = !flag2;
			gameObject.SetActive(active);
			bool flag3 = state < GraphyManager.ModuleState.BASIC;
			bool flag4 = !flag3;
			int num = (int)(state - 2);
			bool flag5 = num == 0;
			bool flag6 = !flag5;
			bool active2;
			if (!(flag4 && flag6))
			{
				GraphyManager graphyManager = m_graphyManager;
				bool flag7 = !graphyManager.Background;
				bool flag8 = !flag7;
				active2 = flag8;
			}
			else
			{
				active2 = false;
			}
			List<Image> list = m_backgroundImages.SetAllActive(active2);
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0xB0C3CC", Offset = "0xB0C3CC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this, this.m_previousModuleState, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestorePreviousState()
		{
			SetState(m_previousModuleState);
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0xB0C3D8", Offset = "0xB0C3D8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDCCD8]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224F6]) = v38;\nL_0015:\n\tv41 = 0;\n\tv43 = this.m_backgroundImages == 0;\n\tif (v43) goto L_003E;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv86 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv98 = v86 == 0;\n\tif (v98) goto L_0039;\n\tv67 = this.m_graphyManager;\n\tv174 = 0;\n\tv76 = *([v174 @ X0_v30 (System.Int32)]);\n\t*([v76 @ X9_v6+2A0])(v80, 0, *([v76 @ X9_v6+2A8]), v22, v23, v24, v25, v26, v27, v67.m_backgroundColor, v67.m_backgroundColor.g, v67.m_backgroundColor.b, v67.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv144 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_0058;\n\tv176 = new System.NullReferenceException();\n\tv63 = new System.NullReferenceException();\nL_003E:\n\tv70 = new System.NullReferenceException();\n\tgoto L_004B;\n\tgoto L_004B;\n\tgoto L_004B;\nL_004B:\n\tv96 = Il2CppMethodInfo != 1;\n\tif (v96) goto L_006D;\n\tv99 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v70);\n\tv146 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v99);\n\tv164 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv195 = ~v99.m_value;\n\tv166 = ~v195;\n\tif (v166) goto L_0071;\nL_0058:\n\tv193 = this.m_graphyManager;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetPosition(this, v193.m_advancedModulePosition);\n\tv223 = this.m_graphyManager;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this, v223.m_advancedModuleState, 0);\n\treturn;\n\tv131 = new System.NullReferenceException();\nL_006D:\n\tv138 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v130);\nL_0071:\n\tthrow System.TypeLoadException;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateParameters()
		{
			//IL_003e: Expected O, but got I4
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			if (m_backgroundImages != null)
			{
				List<Image>.Enumerator enumerator2 = m_backgroundImages.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GraphyManager graphyManager = m_graphyManager;
					int num = 0;
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ X9_v6+2A0] (should have been resolved before IL gen)");
				}
				enumerator.Dispose();
				goto IL_00d8;
			}
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
			IL_00d8:
			GraphyManager graphyManager2 = m_graphyManager;
			SetPosition(graphyManager2.AdvancedModulePosition);
			GraphyManager graphyManager3 = m_graphyManager;
			SetState(graphyManager3.AdvancedModuleState);
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xB0C530", Offset = "0xB0C530", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC9818]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224F7]) = v38;\nL_0015:\n\tv41 = 0;\n\tv43 = this.m_backgroundImages == 0;\n\tif (v43) goto L_003E;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.m_backgroundImages);\nL_0022:\n\tv86 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv98 = v86 == 0;\n\tif (v98) goto L_0039;\n\tv67 = this.m_graphyManager;\n\tv174 = 0;\n\tv76 = *([v174 @ X0_v29 (System.Int32)]);\n\t*([v76 @ X9_v6+2A0])(v80, 0, *([v76 @ X9_v6+2A8]), v22, v23, v24, v25, v26, v27, v67.m_backgroundColor, v67.m_backgroundColor.g, v67.m_backgroundColor.b, v67.m_backgroundColor.a, v32, v33, v34, v35);\n\tgoto L_0022;\nL_0039:\n\tv144 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_0058;\n\tv176 = new System.NullReferenceException();\n\tv63 = new System.NullReferenceException();\nL_003E:\n\tv70 = new System.NullReferenceException();\n\tgoto L_004B;\n\tgoto L_004B;\n\tgoto L_004B;\nL_004B:\n\tv96 = Il2CppMethodInfo != 1;\n\tif (v96) goto L_006A;\n\tv99 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v70);\n\tv146 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v99);\n\tv164 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv192 = ~v99.m_value;\n\tv166 = ~v192;\n\tif (v166) goto L_006E;\nL_0058:\n\tv135 = this.m_graphyManager;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetPosition(this, v135.m_advancedModulePosition);\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this, this.m_currentModuleState, 1);\n\treturn;\n\tv131 = new System.NullReferenceException();\nL_006A:\n\tv138 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(v130);\nL_006E:\n\tthrow System.TypeLoadException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RefreshParameters()
		{
			//IL_003e: Expected O, but got I4
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			if (m_backgroundImages != null)
			{
				List<Image>.Enumerator enumerator2 = m_backgroundImages.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GraphyManager graphyManager = m_graphyManager;
					int num = 0;
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ X9_v6+2A0] (should have been resolved before IL gen)");
				}
				enumerator.Dispose();
				goto IL_00da;
			}
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
			IL_00da:
			GraphyManager graphyManager2 = m_graphyManager;
			SetPosition(graphyManager2.AdvancedModulePosition);
			SetState(m_currentModuleState, silentUpdate: true);
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0xB0AE6C", Offset = "0xB0AE6C", Length = "0xC08")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0025;\n\tv32 = *([1ED3470]);\n\tv33 = *([v32 @ X8_v174]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20224F8]) = v52;\nL_0025:\n\tgoto L_002C;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002C:\n\tv72 = Tayx.Graphy.Utils.NumString.G_FloatString::get_Inited();\n\tv74 = v72 == 0;\n\tif (v74) goto L_0068;\n\tgoto L_003B;\n\tv137 = *([v75 @ X0_v240+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_003B;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv123 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MinValue();\n\tv85 = v123 > -1000f;\n\tif (v85) goto L_0068;\n\tgoto L_0056;\n\tv184 = *([v179 @ X0_v243+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0056;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v179, methodInfo, v36, v37, v38, v39, v40, v41, v123, v120, v44, v45, v46, v47, v48, v49);\nL_0056:\n\tv172 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MaxValue();\n\tv83 = v172 >= 16384f;\n\tif (v83) goto L_0077;\nL_0068:\n\tgoto L_0074;\n\tv143 = *([v133 @ X0_v236+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0074;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v133, methodInfo, v36, v37, v38, v39, v40, v41, v121, v118, v44, v45, v46, v47, v48, v49);\nL_0074:\n\tTayx.Graphy.Utils.NumString.G_FloatString::Init(-1001f, 16386f, 1);\nL_0077:\n\tv178 = UnityEngine.Component::get_transform(this);\n\tv191 = UnityEngine.Transform::get_root(v178);\n\tv504 = UnityEngine.Component::GetComponentInChildren(v191);\n\tthis.m_graphyManager = v504;\n\tv553 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v553);\n\tthis.m_sb = v553;\n\tv697 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v697;\n\t// 150 NewArr v376 @ X0_v59 (System.Object[]), typeof(System.Object[]), 5\n\tv705 = \"CPU: \" == 0;\n\tif (v705) goto L_00A5;\n\t// 161 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \"CPU: \"\nL_00A5:\n\tv716 = v376.Length == 0;\n\tif (v716) goto L_03C3;\n\tv376[0] = \"CPU: \";\n\tv721 = UnityEngine.SystemInfo::get_processorType();\n\tv1061 = v721 == 0;\n\tif (v1061) goto L_00B4;\n\t// 177 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v721 @ X0_v67 (System.String)\nL_00B4:\n\tv962 = v376.Length;\n\tv1074 = v376.Length < 1;\n\tv888 = ~v1074;\n\tv872 = v376.Length - 1;\n\tv840 = v872 == 0;\n\tv1075 = ~v888;\n\tv760 = v1075 | v840;\n\tif (v760) goto L_03C3;\n\tv376[1] = v721;\n\tv1139 = \" [\" == 0;\n\tif (v1139) goto L_00CD;\n\t// 201 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \" [\"\n\tv962 = v376.Length;\nL_00CD:\n\tv1143 = v962 < 2;\n\tv897 = ~v1143;\n\tv881 = v962 - 2;\n\tv849 = v881 == 0;\n\tv1144 = ~v897;\n\tv769 = v1144 | v849;\n\tif (v769) goto L_03C3;\n\tv376[2] = \" [\";\n\tv1147 = UnityEngine.SystemInfo::get_processorCount();\n\t*([v22 @ X29_v1-34]) = v1147;\n\tv1149 = &v23 @ stack_-10_v2 - 0x34;\n\t// 227 Box v72 @ X0_v5 (System.Boolean), typeof(System.Int32), v1149 @ X1_v31\n\tv1154 = v72 == 0;\n\tif (v1154) goto L_00ED;\n\t// 234 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v72 @ X0_v5 (System.Boolean)\nL_00ED:\n\tv963 = v376.Length;\n\tv1157 = v376.Length < 3;\n\tv889 = ~v1157;\n\tv873 = v376.Length - 3;\n\tv841 = v873 == 0;\n\tv1158 = ~v889;\n\tv761 = v1158 | v841;\n\tif (v761) goto L_03C3;\n\tv376[3] = v72;\n\tv1164 = \" cores]\" == 0;\n\tif (v1164) goto L_0106;\n\t// 258 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \" cores]\"\n\tv963 = v376.Length;\nL_0106:\n\tv1168 = v963 < 4;\n\tv361 = ~v1168;\n\tv355 = v963 - 4;\n\tv343 = v355 == 0;\n\tv1169 = ~v361;\n\tv313 = v1169 | v343;\n\tif (v313) goto L_03C3;\n\tv376[4] = \" cores]\";\n\tv1101 = System.String::Concat(v376);\n\tv72 = UnityEngine.UI.Text::set_text(this.m_processorTypeText, v1101);\n\tv1181 = UnityEngine.SystemInfo::get_systemMemorySize();\n\t*([v22 @ X29_v1-38]) = v1181;\n\tv1185 = &v23 @ stack_-10_v2 - 0x38;\n\t// 294 Box v1187 @ X0_v85 (System.Object), typeof(System.Int32), v1185 @ X1_v36\n\tv1102 = System.String::Concat(\"RAM: \", v1187, \" MB\");\n\tv72 = UnityEngine.UI.Text::set_text(this.m_systemMemoryText, v1102);\n\tv1199 = UnityEngine.SystemInfo::get_graphicsDeviceVersion();\n\tv1103 = System.String::Concat(\"Graphics API: \", v1199);\n\tv72 = UnityEngine.UI.Text::set_text(this.m_graphicsDeviceVersionText, v1103);\n\tv1134 = this.m_graphicsDeviceNameText;\n\tv1223 = UnityEngine.SystemInfo::get_graphicsDeviceName();\n\tv1104 = System.String::Concat(\"GPU: \", v1223);\n\tv72 = UnityEngine.UI.Text::set_text(v1134, v1104);\n\tv414 = this.m_graphicsMemorySizeText;\n\t// 352 NewArr v377 @ X0_v103 (System.Object[]), typeof(System.Object[]), 6\n\tv1240 = \"VRAM: \" == 0;\n\tif (v1240) goto L_016F;\n\t// 363 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \"VRAM: \"\nL_016F:\n\tv929 = v377.Length == 0;\n\tif (v929) goto L_03C3;\n\tv377[0] = \"VRAM: \";\n\tv1249 = UnityEngine.SystemInfo::get_graphicsMemorySize();\n\t// 377 Box v72 @ X0_v5 (System.Boolean), typeof(System.Int32), &v1249 @ X0_v107 (System.Int32)\n\tv1261 = v72 == 0;\n\tif (v1261) goto L_0183;\n\t// 384 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v72 @ X0_v5 (System.Boolean)\nL_0183:\n\tv964 = v377.Length;\n\tv1275 = v377.Length < 1;\n\tv890 = ~v1275;\n\tv874 = v377.Length - 1;\n\tv842 = v874 == 0;\n\tv1276 = ~v890;\n\tv762 = v1276 | v842;\n\tif (v762) goto L_03C3;\n\tv377[1] = v72;\n\tv1279 = \"MB. Max texture size: \" == 0;\n\tif (v1279) goto L_019C;\n\t// 408 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \"MB. Max texture size: \"\n\tv964 = v377.Length;\nL_019C:\n\tv1281 = v964 < 2;\n\tv898 = ~v1281;\n\tv882 = v964 - 2;\n\tv850 = v882 == 0;\n\tv1282 = ~v898;\n\tv770 = v1282 | v850;\n\tif (v770) goto L_03C3;\n\tv377[2] = \"MB. Max texture size: \";\n\tv1285 = UnityEngine.SystemInfo::get_maxTextureSize();\n\t// 432 Box v72 @ X0_v5 (System.Boolean), typeof(System.Int32), &v1285 @ X0_v114 (System.Int32)\n\tv1290 = v72 == 0;\n\tif (v1290) goto L_01BA;\n\t// 439 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v72 @ X0_v5 (System.Boolean)\nL_01BA:\n\tv965 = v377.Length;\n\tv1293 = v377.Length < 3;\n\tv891 = ~v1293;\n\tv875 = v377.Length - 3;\n\tv843 = v875 == 0;\n\tv1294 = ~v891;\n\tv763 = v1294 | v843;\n\tif (v763) goto L_03C3;\n\tv377[3] = v72;\n\tv1297 = \"px. Shader level: \" == 0;\n\tif (v1297) goto L_01D3;\n\t// 463 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \"px. Shader level: \"\n\tv965 = v377.Length;\nL_01D3:\n\tv1299 = v965 < 4;\n\tv899 = ~v1299;\n\tv883 = v965 - 4;\n\tv851 = v883 == 0;\n\tv1300 = ~v899;\n\tv771 = v1300 | v851;\n\tif (v771) goto L_03C3;\n\tv377[4] = \"px. Shader level: \";\n\tv1303 = UnityEngine.SystemInfo::get_graphicsShaderLevel();\n\t// 487 Box v72 @ X0_v5 (System.Boolean), typeof(System.Int32), &v1303 @ X0_v121 (System.Int32)\n\tv1308 = v72 == 0;\n\tif (v1308) goto L_01F2;\n\t// 494 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v72 @ X0_v5 (System.Boolean)\nL_01F2:\n\tv1311 = v377.Length < 5;\n\tv362 = ~v1311;\n\tv356 = v377.Length - 5;\n\tv344 = v356 == 0;\n\tv1312 = ~v362;\n\tv314 = v1312 | v344;\n\tif (v314) goto L_03C3;\n\tv377[5] = v72;\n\tv1105 = System.String::Concat(v377);\n\tv405 = *([v414 @ X20_v23 (UnityEngine.UI.Text)]);\n\tv72 = UnityEngine.UI.Text::set_text(v414, v1105);\n\tv1318 = UnityEngine.Screen::get_currentResolution();\n\tv415 = this.m_screenResolutionText;\n\t// 529 NewArr v378 @ X0_v132 (System.Object[]), typeof(System.Object[]), 7\n\tv1322 = \"Screen: \" == 0;\n\tif (v1322) goto L_0220;\n\t// 540 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), \"Screen: \"\nL_0220:\n\tv933 = v378.Length == 0;\n\tif (v933) goto L_03C3;\n\tv378[0] = \"Screen: \";\n\tv72 = 0x10D3F74(&v1318 @ X0_v130 (UnityEngine.Resolution), 0, *([v405 @ X8_v78 (Il2CppClass<UnityEngine.UI.Text>)+5C8]), 0, v38, v39, v40, v41, v172, v171, v44, v45, v46, v47, v48, v49);\n\t// 555 Box v72 @ X0_v5 (System.Boolean), typeof(System.Int32), &v72 @ X0_v5 (System.Boolean)\n\tv1333 = v72 == 0;\n\tif (v1333) goto L_0235;\n\t// 562 IsInst v72 @ X0_v5 (System.Boolean), typeof(System.Object), v72 @ X0_v5 (System.Boolean)\nL_0235:\n\tv966 = v378.Length;\n\tv1336 = v378.Le\n// ... truncated")]
		private void Init()
		{
			//IL_0172: Expected I4, but got O
			//IL_01eb: Expected O, but got I4
			//IL_0217: Expected O, but got I4
			//IL_01dc: Expected I4, but got O
			//IL_13f8: Expected O, but got I
			//IL_028a: Expected I4, but got O
			//IL_02ce: Expected O, but got I
			//IL_02d7: Expected I4, but got O
			//IL_02db: Expected I4, but got O
			//IL_0299: Expected O, but got I4
			//IL_0319: Expected O, but got I4
			//IL_0345: Expected O, but got I4
			//IL_0306: Expected O, but got I4
			//IL_030a: Expected I4, but got O
			//IL_038c: Expected O, but got I4
			//IL_1456: Expected O, but got I
			//IL_03b8: Expected I4, but got O
			//IL_03c7: Expected O, but got I4
			//IL_041d: Expected O, but got I
			//IL_0426: Expected I4, but got O
			//IL_050a: Expected I4, but got O
			//IL_0558: Expected I4, but got O
			//IL_0596: Expected O, but got I4
			//IL_05c2: Expected O, but got I4
			//IL_0583: Expected O, but got I4
			//IL_0587: Expected I4, but got O
			//IL_060a: Expected O, but got I4
			//IL_14b4: Expected O, but got I
			//IL_0636: Expected I4, but got O
			//IL_0673: Expected I4, but got O
			//IL_0645: Expected O, but got I4
			//IL_06b1: Expected O, but got I4
			//IL_06dd: Expected O, but got I4
			//IL_069e: Expected O, but got I4
			//IL_06a2: Expected I4, but got O
			//IL_0725: Expected O, but got I4
			//IL_1513: Expected O, but got I
			//IL_0751: Expected I4, but got O
			//IL_078e: Expected I4, but got O
			//IL_0760: Expected O, but got I4
			//IL_07ee: Expected O, but got I4
			//IL_07b9: Expected O, but got I4
			//IL_07bd: Expected I4, but got O
			//IL_0836: Expected O, but got I4
			//IL_0850: Expected I, but got O
			//IL_08af: Expected I4, but got O
			//IL_08fe: Expected I4, but got O
			//IL_093c: Expected O, but got I4
			//IL_0968: Expected O, but got I4
			//IL_0929: Expected O, but got I4
			//IL_092d: Expected I4, but got O
			//IL_09b0: Expected O, but got I4
			//IL_1572: Expected O, but got I
			//IL_09dc: Expected I4, but got O
			//IL_0a1a: Expected I4, but got O
			//IL_09eb: Expected O, but got I4
			//IL_0a58: Expected O, but got I4
			//IL_0a84: Expected O, but got I4
			//IL_0a45: Expected O, but got I4
			//IL_0a49: Expected I4, but got O
			//IL_0acc: Expected O, but got I4
			//IL_15d1: Expected O, but got I
			//IL_0af8: Expected I4, but got O
			//IL_0b36: Expected I4, but got O
			//IL_0b07: Expected O, but got I4
			//IL_0b74: Expected O, but got I4
			//IL_0ba0: Expected O, but got I4
			//IL_0b61: Expected O, but got I4
			//IL_0b65: Expected I4, but got O
			//IL_0be8: Expected O, but got I4
			//IL_1630: Expected O, but got I
			//IL_0c14: Expected I4, but got O
			//IL_0c23: Expected O, but got I4
			//IL_0c9a: Expected I4, but got O
			//IL_0d14: Expected O, but got I4
			//IL_0d40: Expected O, but got I4
			//IL_0d05: Expected I4, but got O
			//IL_168f: Expected O, but got I
			//IL_0db4: Expected I4, but got O
			//IL_0df1: Expected I4, but got O
			//IL_0dc3: Expected O, but got I4
			//IL_0e2f: Expected O, but got I4
			//IL_0e5b: Expected O, but got I4
			//IL_0e1c: Expected O, but got I4
			//IL_0e20: Expected I4, but got O
			//IL_0ea3: Expected O, but got I4
			//IL_16ee: Expected O, but got I
			//IL_0ecf: Expected I4, but got O
			//IL_0ede: Expected O, but got I4
			//IL_172f: Expected O, but got I
			//IL_172f: Expected O, but got F4
			//IL_1054: Expected O, but got I
			//IL_1054: Expected O, but got F4
			//IL_1066: Expected O, but got I4
			//IL_0fe4: Expected O, but got F4
			//IL_0fed: Expected O, but got I4
			//IL_13b6: Expected O, but got I
			//IL_10c2: Expected O, but got I
			//IL_10cd: Expected O, but got I
			//IL_1390: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			float num;
			float maxValue;
			if (G_FloatString.Inited)
			{
				float minValue = G_FloatString.MinValue;
				if (!(minValue > -1000f))
				{
					maxValue = G_FloatString.MaxValue;
					bool flag = !(maxValue < 16384f);
					num = 16384f;
					if (flag)
					{
						goto IL_00c9;
					}
				}
			}
			G_FloatString.Init(-1001f, 16386f);
			num = 16386f;
			maxValue = -1001f;
			goto IL_00c9;
			IL_00c9:
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			StringBuilder sb = new StringBuilder();
			m_sb = sb;
			RectTransform component = GetComponent<RectTransform>();
			m_rectTransform = component;
			object[] array = new object[5];
			if ("CPU: " != null)
			{
				bool flag2 = (byte)(int)("CPU: " as object) != 0;
			}
			List<Text>.Enumerator enumerator2;
			if (array.Length != 0)
			{
				array[0] = "CPU: ";
				string processorType = SystemInfo.processorType;
				if (processorType != null)
				{
					bool flag2 = (byte)(int)(processorType as object) != 0;
				}
				object obj3 = array.Length;
				bool flag3 = array.Length < 1;
				bool flag4 = !flag3;
				object obj4 = array.Length - 1;
				bool flag5 = obj4 == null;
				bool flag6 = !flag4;
				if (!(flag6 || flag5))
				{
					array[1] = processorType;
					if (" [" != null)
					{
						bool flag2 = (byte)(int)(" [" as object) != 0;
						obj3 = array.Length;
					}
					bool flag7 = (long)(IntPtr)obj3 < 2L;
					bool flag8 = !flag7;
					object obj5 = (long)(IntPtr)obj3 - 2L;
					bool flag9 = obj5 == null;
					bool flag10 = !flag8;
					if (!(flag10 || flag9))
					{
						array[2] = " [";
						int processorCount = SystemInfo.processorCount;
						object obj6 = (long)(IntPtr)obj2 - 52L;
						bool flag2 = (byte)(int)(object)(int)obj6 != 0;
						if (flag2)
						{
							flag2 = (byte)(int)(flag2 as object) != 0;
						}
						object obj7 = array.Length;
						bool flag11 = array.Length < 3;
						bool flag12 = !flag11;
						object obj8 = array.Length - 3;
						bool flag13 = obj8 == null;
						bool flag14 = !flag12;
						if (!(flag14 || flag13))
						{
							array[3] = flag2;
							if (" cores]" != null)
							{
								flag2 = (byte)(int)(" cores]" as object) != 0;
								obj7 = array.Length;
							}
							bool flag15 = (long)(IntPtr)obj7 < 4L;
							bool flag16 = !flag15;
							object obj9 = (long)(IntPtr)obj7 - 4L;
							bool flag17 = obj9 == null;
							bool flag18 = !flag16;
							if (!(flag18 || flag17))
							{
								array[4] = " cores]";
								string text = string.Concat(array);
								m_processorTypeText.text = text;
								int systemMemorySize = SystemInfo.systemMemorySize;
								object obj10 = (long)(IntPtr)obj2 - 56L;
								object obj11 = (int)obj10;
								string text2 = string.Concat("RAM: ", obj11, " MB");
								m_systemMemoryText.text = text2;
								string graphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
								string text3 = "Graphics API: " + graphicsDeviceVersion;
								m_graphicsDeviceVersionText.text = text3;
								Text graphicsDeviceNameText = m_graphicsDeviceNameText;
								string graphicsDeviceName = SystemInfo.graphicsDeviceName;
								string text4 = "GPU: " + graphicsDeviceName;
								graphicsDeviceNameText.text = text4;
								Text graphicsMemorySizeText = m_graphicsMemorySizeText;
								object[] array2 = new object[6];
								if ("VRAM: " != null)
								{
									flag2 = (byte)(int)("VRAM: " as object) != 0;
								}
								if (array2.Length != 0)
								{
									array2[0] = "VRAM: ";
									int graphicsMemorySize = SystemInfo.graphicsMemorySize;
									flag2 = (byte)(int)(object)graphicsMemorySize != 0;
									if (flag2)
									{
										flag2 = (byte)(int)(flag2 as object) != 0;
									}
									object obj12 = array2.Length;
									bool flag19 = array2.Length < 1;
									bool flag20 = !flag19;
									object obj13 = array2.Length - 1;
									bool flag21 = obj13 == null;
									bool flag22 = !flag20;
									if (!(flag22 || flag21))
									{
										array2[1] = flag2;
										if ("MB. Max texture size: " != null)
										{
											flag2 = (byte)(int)("MB. Max texture size: " as object) != 0;
											obj12 = array2.Length;
										}
										bool flag23 = (long)(IntPtr)obj12 < 2L;
										bool flag24 = !flag23;
										object obj14 = (long)(IntPtr)obj12 - 2L;
										bool flag25 = obj14 == null;
										bool flag26 = !flag24;
										if (!(flag26 || flag25))
										{
											array2[2] = "MB. Max texture size: ";
											int maxTextureSize = SystemInfo.maxTextureSize;
											flag2 = (byte)(int)(object)maxTextureSize != 0;
											if (flag2)
											{
												flag2 = (byte)(int)(flag2 as object) != 0;
											}
											object obj15 = array2.Length;
											bool flag27 = array2.Length < 3;
											bool flag28 = !flag27;
											object obj16 = array2.Length - 3;
											bool flag29 = obj16 == null;
											bool flag30 = !flag28;
											if (!(flag30 || flag29))
											{
												array2[3] = flag2;
												if ("px. Shader level: " != null)
												{
													flag2 = (byte)(int)("px. Shader level: " as object) != 0;
													obj15 = array2.Length;
												}
												bool flag31 = (long)(IntPtr)obj15 < 4L;
												bool flag32 = !flag31;
												object obj17 = (long)(IntPtr)obj15 - 4L;
												bool flag33 = obj17 == null;
												bool flag34 = !flag32;
												if (!(flag34 || flag33))
												{
													array2[4] = "px. Shader level: ";
													int graphicsShaderLevel = SystemInfo.graphicsShaderLevel;
													flag2 = (byte)(int)(object)graphicsShaderLevel != 0;
													if (flag2)
													{
														flag2 = (byte)(int)(flag2 as object) != 0;
													}
													bool flag35 = array2.Length < 5;
													bool flag36 = !flag35;
													object obj18 = array2.Length - 5;
													bool flag37 = obj18 == null;
													bool flag38 = !flag36;
													if (!(flag38 || flag37))
													{
														array2[5] = flag2;
														string text5 = string.Concat(array2);
														IntPtr intPtr = (IntPtr)graphicsMemorySizeText;
														graphicsMemorySizeText.text = text5;
														Resolution currentResolution = Screen.currentResolution;
														Text screenResolutionText = m_screenResolutionText;
														object[] array3 = new object[7];
														if ("Screen: " != null)
														{
															flag2 = (byte)(int)("Screen: " as object) != 0;
														}
														if (array3.Length != 0)
														{
															array3[0] = "Screen: ";
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D3F74 (inside UnityEngine.RequireComponent::.ctor +0x38)");
															flag2 = (byte)(int)(object)(flag2 ? 1 : 0) != 0;
															if (flag2)
															{
																flag2 = (byte)(int)(flag2 as object) != 0;
															}
															object obj19 = array3.Length;
															bool flag39 = array3.Length < 1;
															bool flag40 = !flag39;
															object obj20 = array3.Length - 1;
															bool flag41 = obj20 == null;
															bool flag42 = !flag40;
															if (!(flag42 || flag41))
															{
																array3[1] = flag2;
																if ("x" != null)
																{
																	flag2 = (byte)(int)("x" as object) != 0;
																	obj19 = array3.Length;
																}
																bool flag43 = (long)(IntPtr)obj19 < 2L;
																bool flag44 = !flag43;
																object obj21 = (long)(IntPtr)obj19 - 2L;
																bool flag45 = obj21 == null;
																bool flag46 = !flag44;
																if (!(flag46 || flag45))
																{
																	array3[2] = "x";
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D3F7C (inside UnityEngine.RequireComponent::.ctor +0x40)");
																	flag2 = (byte)(int)(object)(flag2 ? 1 : 0) != 0;
																	if (flag2)
																	{
																		flag2 = (byte)(int)(flag2 as object) != 0;
																	}
																	object obj22 = array3.Length;
																	bool flag47 = array3.Length < 3;
																	bool flag48 = !flag47;
																	object obj23 = array3.Length - 3;
																	bool flag49 = obj23 == null;
																	bool flag50 = !flag48;
																	if (!(flag50 || flag49))
																	{
																		array3[3] = flag2;
																		if ("@" != null)
																		{
																			flag2 = (byte)(int)("@" as object) != 0;
																			obj22 = array3.Length;
																		}
																		bool flag51 = (long)(IntPtr)obj22 < 4L;
																		bool flag52 = !flag51;
																		object obj24 = (long)(IntPtr)obj22 - 4L;
																		bool flag53 = obj24 == null;
																		bool flag54 = !flag52;
																		if (!(flag54 || flag53))
																		{
																			array3[4] = "@";
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D3F84 (inside UnityEngine.RequireComponent::.ctor +0x48)");
																			flag2 = (byte)(int)(object)(flag2 ? 1 : 0) != 0;
																			if (flag2)
																			{
																				flag2 = (byte)(int)(flag2 as object) != 0;
																			}
																			object obj25 = array3.Length;
																			bool flag55 = array3.Length < 5;
																			bool flag56 = !flag55;
																			object obj26 = array3.Length - 5;
																			bool flag57 = obj26 == null;
																			bool flag58 = !flag56;
																			if (!(flag58 || flag57))
																			{
																				array3[5] = flag2;
																				if ("Hz" != null)
																				{
																					flag2 = (byte)(int)("Hz" as object) != 0;
																					obj25 = array3.Length;
																				}
																				bool flag59 = (long)(IntPtr)obj25 < 6L;
																				bool flag60 = !flag59;
																				object obj27 = (long)(IntPtr)obj25 - 6L;
																				bool flag61 = obj27 == null;
																				bool flag62 = !flag60;
																				if (!(flag62 || flag61))
																				{
																					array3[6] = "Hz";
																					string text6 = string.Concat(array3);
																					screenResolutionText.text = text6;
																					object[] array4 = new object[5];
																					if ("OS: " != null)
																					{
																						flag2 = (byte)(int)("OS: " as object) != 0;
																					}
																					if (array4.Length != 0)
																					{
																						array4[0] = "OS: ";
																						string operatingSystem = SystemInfo.operatingSystem;
																						if (operatingSystem != null)
																						{
																							flag2 = (byte)(int)(operatingSystem as object) != 0;
																						}
																						object obj28 = array4.Length;
																						bool flag63 = array4.Length < 1;
																						bool flag64 = !flag63;
																						object obj29 = array4.Length - 1;
																						bool flag65 = obj29 == null;
																						bool flag66 = !flag64;
																						if (!(flag66 || flag65))
																						{
																							array4[1] = operatingSystem;
																							if (" [" != null)
																							{
																								flag2 = (byte)(int)(" [" as object) != 0;
																								obj28 = array4.Length;
																							}
																							bool flag67 = (long)(IntPtr)obj28 < 2L;
																							bool flag68 = !flag67;
																							object obj30 = (long)(IntPtr)obj28 - 2L;
																							bool flag69 = obj30 == null;
																							bool flag70 = !flag68;
																							if (!(flag70 || flag69))
																							{
																								array4[2] = " [";
																								DeviceType deviceType = SystemInfo.deviceType;
																								flag2 = (byte)(int)(object)deviceType != 0;
																								if (flag2)
																								{
																									flag2 = (byte)(int)(flag2 as object) != 0;
																								}
																								object obj31 = array4.Length;
																								bool flag71 = array4.Length < 3;
																								bool flag72 = !flag71;
																								object obj32 = array4.Length - 3;
																								bool flag73 = obj32 == null;
																								bool flag74 = !flag72;
																								if (!(flag74 || flag73))
																								{
																									array4[3] = flag2;
																									if ("]" != null)
																									{
																										flag2 = (byte)(int)("]" as object) != 0;
																										obj31 = array4.Length;
																									}
																									bool flag75 = (long)(IntPtr)obj31 < 4L;
																									bool flag76 = !flag75;
																									object obj33 = (long)(IntPtr)obj31 - 4L;
																									bool flag77 = obj33 == null;
																									bool flag78 = !flag76;
																									if (!(flag78 || flag77))
																									{
																										array4[4] = "]";
																										string text7 = string.Concat(array4);
																										m_operatingSystemText.text = text7;
																										List<Text> list = new List<Text>();
																										list.Add(m_graphicsDeviceVersionText);
																										list.Add(m_processorTypeText);
																										list.Add(m_systemMemoryText);
																										list.Add(m_graphicsDeviceNameText);
																										list.Add(m_graphicsMemorySizeText);
																										list.Add(m_screenResolutionText);
																										list.Add(m_gameWindowResolutionText);
																										list.Add(m_operatingSystemText);
																										List<Text>.Enumerator enumerator = list.GetEnumerator();
																										object obj34 = default(object);
																										NullReferenceException ex2 = default(NullReferenceException);
																										IntPtr intPtr2 = default(IntPtr);
																										List<Text> list2 = default(List<Text>);
																										float num2 = default(float);
																										Vector2 anchoredPosition2 = default(Vector2);
																										object obj38 = default(object);
																										while (true)
																										{
																											((List<Text>)num2).Add((Text)0);
																											float num3;
																											if (((flag2 ? 1u : 0u) & 1u) != 0)
																											{
																												bool flag79 = obj34 == null;
																												num3 = 0f;
																												enumerator2 = (List<Text>.Enumerator)num2;
																												object obj35 = 0;
																												if (!flag79)
																												{
																													object obj36 = obj34;
																													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1503 @ X8_v125+600] (should have been resolved before IL gen)");
																													if (0 > 0)
																													{
																														object obj37 = obj34;
																														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1495 @ X8_v126+600] (should have been resolved before IL gen)");
																													}
																													continue;
																												}
																												NullReferenceException ex = new NullReferenceException();
																												if ((IntPtr)0 != (IntPtr)1)
																												{
																													((List<Text>)(object)ex2).Add((Text)(long)intPtr2);
																													break;
																												}
																												((List<Text>)(object)ex).Add((Text)0);
																												list2.Add((Text)0);
																												enumerator2.Dispose();
																												if (list2 != null)
																												{
																													break;
																												}
																											}
																											else
																											{
																												((List<Text>)num2).Add((Text)0);
																												num3 = 0f;
																												object obj35 = 0;
																											}
																											List<Image> backgroundImages = m_backgroundImages;
																											if (backgroundImages.Count == 0)
																											{
																												throw new ArgumentOutOfRangeException();
																											}
																											Image[] items = backgroundImages._items;
																											RectTransform rectTransform = items[0].rectTransform;
																											float size = num3 + 10f;
																											rectTransform.SetSizeWithCurrentAnchors(default(RectTransform.Axis), size);
																											List<Image> backgroundImages2 = m_backgroundImages;
																											if (backgroundImages2.Count == 0)
																											{
																												throw new ArgumentOutOfRangeException();
																											}
																											Image[] items2 = backgroundImages2._items;
																											RectTransform rectTransform2 = items2[0].rectTransform;
																											List<Image> backgroundImages3 = m_backgroundImages;
																											if (backgroundImages3.Count == 0)
																											{
																												throw new ArgumentOutOfRangeException();
																											}
																											Image[] items3 = backgroundImages3._items;
																											RectTransform rectTransform3 = items3[0].rectTransform;
																											float num4 = Mathf.Sign(rectTransform3.anchoredPosition.x);
																											List<Image> backgroundImages4 = m_backgroundImages;
																											if (backgroundImages4.Count == 0)
																											{
																												throw new ArgumentOutOfRangeException();
																											}
																											Image[] items4 = backgroundImages4._items;
																											RectTransform rectTransform4 = items4[0].rectTransform;
																											Vector2 anchoredPosition = rectTransform4.anchoredPosition;
																											float num5 = num3 + 15f;
																											float num6 = num5 * 0.5f;
																											float num7 = num6 * num4;
																											num2 = 0f;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
																											anchoredPosition2.x = 0f;
																											anchoredPosition2.y = (float)obj38;
																											rectTransform2.anchoredPosition = anchoredPosition2;
																											UpdateParameters();
																											return;
																										}
																										enumerator2 = default(List<Text>.Enumerator);
																										goto IL_1083;
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			enumerator2 = default(List<Text>.Enumerator);
			goto IL_1083;
			IL_1083:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0xB0C680", Offset = "0xB0C680", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EAED50]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224F9]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v44);\n\tthis.m_backgroundImages = v44;\n\tthis.m_updateRate = 1f;\n\t// 36 NewArr v54 @ X0_v5 (System.String[]), typeof(System.String[]), 6\n\tv60 = \"Window: \" == 0;\n\tif (v60) goto L_0032;\n\t// 47 IsInst v106 @ X0_v32, typeof(System.String), \"Window: \"\nL_0032:\n\tv206 = v54.Length;\n\tv113 = v54.Length == 0;\n\tif (v113) goto L_00BF;\n\tv54[0] = \"Window: \";\n\tv118 = \"x\" == 0;\n\tif (v118) goto L_0042;\n\t// 62 IsInst v254 @ X0_v31, typeof(System.String), \"x\"\n\tv206 = v54.Length;\nL_0042:\n\tv273 = v206 < 1;\n\tv168 = ~v273;\n\tv162 = v206 - 1;\n\tv150 = v162 == 0;\n\tv274 = ~v168;\n\tv120 = v274 | v150;\n\tif (v120) goto L_00BF;\n\tv54[1] = \"x\";\n\tv279 = \"@\" == 0;\n\tif (v279) goto L_005B;\n\t// 87 IsInst v255 @ X0_v30, typeof(System.String), \"@\"\n\tv206 = v54.Length;\nL_005B:\n\tv281 = v206 < 2;\n\tv169 = ~v281;\n\tv163 = v206 - 2;\n\tv151 = v163 == 0;\n\tv282 = ~v169;\n\tv121 = v282 | v151;\n\tif (v121) goto L_00BF;\n\tv54[2] = \"@\";\n\tv285 = \"Hz\" == 0;\n\tif (v285) goto L_0074;\n\t// 112 IsInst v256 @ X0_v29, typeof(System.String), \"Hz\"\n\tv206 = v54.Length;\nL_0074:\n\tv287 = v206 < 3;\n\tv170 = ~v287;\n\tv164 = v206 - 3;\n\tv152 = v164 == 0;\n\tv288 = ~v170;\n\tv122 = v288 | v152;\n\tif (v122) goto L_00BF;\n\tv54[3] = \"Hz\";\n\tv291 = \"[\" == 0;\n\tif (v291) goto L_008D;\n\t// 137 IsInst v257 @ X0_v28, typeof(System.String), \"[\"\n\tv206 = v54.Length;\nL_008D:\n\tv293 = v206 < 4;\n\tv171 = ~v293;\n\tv165 = v206 - 4;\n\tv153 = v165 == 0;\n\tv294 = ~v171;\n\tv123 = v294 | v153;\n\tif (v123) goto L_00BF;\n\tv54[4] = \"[\";\n\tv297 = \"dpi]\" == 0;\n\tif (v297) goto L_00A6;\n\t// 162 IsInst v258 @ X0_v27, typeof(System.String), \"dpi]\"\n\tv206 = v54.Length;\nL_00A6:\n\tv299 = v206 < 5;\n\tv172 = ~v299;\n\tv166 = v206 - 5;\n\tv154 = v166 == 0;\n\tv300 = ~v172;\n\tv124 = v300 | v154;\n\tif (v124) goto L_00BF;\n\tv54[5] = \"dpi]\";\n\tthis.m_windowStrings = v54;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_00BF:\n\tv207 = new System.IndexOutOfRangeException();\n\tgoto L_00C4;\n\tv271 = new System.ArrayTypeMismatchException();\nL_00C4:\n\tthrow v276;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_AdvancedData()
		{
			//IL_0046: Expected O, but got I4
			//IL_0290: Expected O, but got I
			//IL_00b3: Expected O, but got I4
			//IL_02ee: Expected O, but got I
			//IL_0106: Expected O, but got I4
			//IL_034c: Expected O, but got I
			//IL_0159: Expected O, but got I4
			//IL_03aa: Expected O, but got I
			//IL_01ac: Expected O, but got I4
			//IL_0408: Expected O, but got I
			//IL_01ff: Expected O, but got I4
			base._002Ector();
			List<Image> backgroundImages = new List<Image>();
			m_backgroundImages = backgroundImages;
			m_updateRate = 1f;
			string[] array = new string[6];
			if ("Window: " != null)
			{
				object obj = "Window: " as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = "Window: ";
				if ("x" != null)
				{
					object obj3 = "x" as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = "x";
					if ("@" != null)
					{
						object obj5 = "@" as string;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "@";
						if ("Hz" != null)
						{
							object obj7 = "Hz" as string;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = "Hz";
							if ("[" != null)
							{
								object obj9 = "[" as string;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "[";
								if ("dpi]" != null)
								{
									object obj11 = "dpi]" as string;
									obj2 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj2 < 5L;
								bool flag18 = !flag17;
								object obj12 = (long)(IntPtr)obj2 - 5L;
								bool flag19 = obj12 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = "dpi]";
									m_windowStrings = array;
									return;
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
