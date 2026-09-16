using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	[Token(Token = "0x2000046")]
	public class ForceSliderToPowerOf2 : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x18")]
		private Slider m_slider;

		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x20")]
		private int[] m_powerOf2Values;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x28")]
		private Text m_text;

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xB10F8C", Offset = "0xB10F8C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBC9E8]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022521]) = v40;\nL_0014:\n\tv41 = this.m_slider;\n\tv47 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v47, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v41.m_OnValueChanged, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Slider slider = m_slider;
			UnityAction<float> call = UpdateValue;
			slider.onValueChanged.AddListener(call);
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0xB11034", Offset = "0xB11034", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EE0F58]);\n\tv33 = *([v32 @ X8_v16]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, value, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022522]) = v51;\nL_001A:\n\tv188 = this.m_powerOf2Values;\nL_0024:\n\tv170 = v188.Length;\n\tv137 = v130 < v188.Length;\n\tv138 = ~v137;\n\tv146 = v130 >= v188.Length;\n\tif (v146) goto L_0061;\n\tif (v138) goto L_0081;\n\tv203 = UnityEngine.Mathf;\n\tv170 = *([v203 @ X0_v12 (Il2CppClass<UnityEngine.Mathf>)+12F]);\n\tgoto L_003E;\n\tv230 = *([v203 @ X0_v12 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_003E;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v203, v126, v36, v37, v38, v39, v40, v41, value, v42, v43, v44, v45, v46, v47, v48);\nL_003E:\n\tv237 = value - v188[v130 @ X21_v7 (System.Int32)];\n\tv108 = UnityEngine.Mathf::Abs(v237);\n\tv86 = v108 - v105;\n\tv83 = v86 < 0;\n\tv77 = v108 ^ v105;\n\tv74 = v108 ^ v86;\n\tv71 = v77 & v74;\n\tv68 = v71 < 0;\n\tv259 = v83 == v68;\n\tv260 = ~v259;\n\tv261 = ~v260;\n\tif (v261) goto L_0053;\n\tgoto L_0053;\nL_0053:\n\tv292 = v83 == v68;\n\tv65 = ~v292;\n\tv62 = ~v65;\n\tif (v62) goto L_005B;\n\tgoto L_005B;\nL_005B:\n\tv130 = v130 + 1;\n\tv295 = this.m_powerOf2Values == 0;\n\tv110 = ~v295;\n\tif (v110) goto L_0024;\n\tv191 = new System.NullReferenceException();\nL_0061:\n\tv202 = v114 < v170;\n\tv166 = ~v202;\n\tif (v166) goto L_0081;\n\tv184 = this.m_slider;\n\tv241 = *([v184 @ X0_v8 (UnityEngine.UI.Slider)]);\n\tv247 = *([v241 @ X9_v4 (Il2CppClass<UnityEngine.UI.Slider>)+420]);\n\tv248 = *([v241 @ X9_v4 (Il2CppClass<UnityEngine.UI.Slider>)+428]);\n\t// 128 IndirectJump v247 @ X2_v2, v184 @ X0_v8 (UnityEngine.UI.Slider), v184 @ X0_v8 (UnityEngine.UI.Slider), v248 @ X1_v5, v247 @ X2_v2, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v188[v114 @ X20_v9 (System.Int32)], v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\nL_0081:\n\tv229 = new System.IndexOutOfRangeException();\n\tthrow v229;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateValue(float value)
		{
			//IL_0155: Expected I, but got O
			//IL_0165: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_0041: Expected I, but got O
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected I4, but got Unknown
			int[] powerOf2Values = m_powerOf2Values;
			int num = 0;
			int num2 = 100000;
			int num3 = 0;
			while (true)
			{
				int num4 = powerOf2Values.Length;
				bool flag = num < powerOf2Values.Length;
				bool flag2 = !flag;
				if (num < powerOf2Values.Length)
				{
					if (flag2)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)typeof(Mathf);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X0_v12 (Il2CppClass<UnityEngine.Mathf>)+12F]");
					num4 = 0;
					int value2 = (int)(value - powerOf2Values[num]);
					int num5 = Mathf.Abs(value2);
					int num6 = num5 - num2;
					bool flag3 = num6 < 0;
					int num7 = num5 ^ num2;
					int num8 = num5 ^ num6;
					int num9 = num7 & num8;
					bool flag4 = num9 < 0;
					if (flag3 != flag4)
					{
						num2 = num5;
					}
					if (flag3 != flag4)
					{
						num3 = num;
					}
					num++;
					bool flag5 = m_powerOf2Values == null;
					bool flag6 = !flag5;
					powerOf2Values = m_powerOf2Values;
					if (flag6)
					{
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					powerOf2Values = m_powerOf2Values;
					num3 = num3;
				}
				if (num3 < num4)
				{
					Slider slider = m_slider;
					IntPtr intPtr2 = (IntPtr)slider;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X9_v4 (Il2CppClass<UnityEngine.UI.Slider>)+420]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X9_v4 (Il2CppClass<UnityEngine.UI.Slider>)+428]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v247 @ X2_v2 (should have been resolved before IL gen)");
				}
				break;
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0xB11150", Offset = "0xB11150", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF8A58]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022523]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Int32[]), typeof(System.Int32[]), 7\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v43, Il2CppFieldInfo);\n\tthis.m_powerOf2Values = v43;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ForceSliderToPowerOf2()
		{
			m_powerOf2Values = new int[7] { 128, 256, 512, 1024, 2048, 4096, 8192 };
		}
	}
}
