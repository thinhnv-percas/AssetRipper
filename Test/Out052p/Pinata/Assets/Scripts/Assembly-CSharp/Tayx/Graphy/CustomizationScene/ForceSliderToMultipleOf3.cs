using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	[Token(Token = "0x2000045")]
	public class ForceSliderToMultipleOf3 : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x18")]
		private Slider m_slider;

		[Token(Token = "0x6000219")]
		[Address(RVA = "0xB10E74", Offset = "0xB10E74", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EECE30]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022520]) = v40;\nL_0014:\n\tv41 = this.m_slider;\n\tv47 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v47, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v41.m_OnValueChanged, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Slider slider = m_slider;
			UnityAction<float> call = UpdateValue;
			slider.onValueChanged.AddListener(call);
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0xB10F1C", Offset = "0xB10F1C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_slider;\n\tv7 = value * 0x55555556;\n\tv8 = v7 >> 0x3F;\n\tv9 = v7 >> 0x20;\n\tv10 = v9 + v8;\n\tv11 = *([v0 @ X0_v1 (UnityEngine.UI.Slider)]);\n\tv12 = v10 << 1;\n\tv13 = v10 + v12;\n\tv15 = value - v13;\n\tv16 = 3 - v15;\n\tv21 = v15 == 0;\n\tv27 = ~v21;\n\tv28 = ~v27;\n\tif (v28) goto L_FFFFFFFF;\n\tv51 = value - 0x12B;\n\tv67 = v51 < 0;\n\tv66 = v51 == 0;\n\tv54 = value ^ 0x12B;\n\tv55 = value ^ v51;\n\tv56 = v54 & v55;\n\tv62 = v56 < 0;\n\tgoto L_002C;\nL_002C:\n\tv70 = *([v11 @ X11_v2 (Il2CppClass<UnityEngine.UI.Slider>)+420]);\n\tv71 = *([v11 @ X11_v2 (Il2CppClass<UnityEngine.UI.Slider>)+428]);\n\tv72 = v67 == v62;\n\tv73 = ~v66;\n\tv74 = v72 & v73;\n\tv75 = ~v74;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv114 = v117 + value;\n\t// 57 IndirectJump v70 @ X2_v1, v0 @ X0_v1 (UnityEngine.UI.Slider), v0 @ X0_v1 (UnityEngine.UI.Slider), v71 @ X1_v1, v70 @ X2_v1, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v114 @ X8_v2 (System.Single), v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateValue(float value)
		{
			//IL_002d: Expected O, but got F4
			//IL_003b: Expected O, but got F4
			//IL_004a: Expected O, but got I
			//IL_0052: Expected I, but got O
			//IL_006f: Expected O, but got I
			//IL_017e: Expected O, but got I
			//IL_018e: Expected O, but got I
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0110: Expected O, but got F4
			Slider slider = m_slider;
			float num = value * 1.4660156E+13f;
			object obj = num >> 63;
			object obj2 = num >> 32;
			object obj3 = (long)(IntPtr)obj2 + (long)(IntPtr)obj;
			IntPtr intPtr = (IntPtr)slider;
			int num2 = (int)((long)(IntPtr)obj3 << 1);
			object obj4 = (long)(IntPtr)obj3 + (long)num2;
			float num3 = value - (float)obj4;
			float num4 = 4E-45f - num3;
			bool flag;
			bool flag2;
			bool flag3;
			if (num3 != 0f)
			{
				float num5 = value - 4.19E-43f;
				flag = num5 < 0f;
				flag2 = num5 == 0f;
				object obj5 = value ^ 0x12B;
				object obj6 = value ^ num5;
				int num6 = (int)((long)(IntPtr)obj5 & (long)(IntPtr)obj6);
				flag3 = num6 < 0;
			}
			else
			{
				flag3 = false;
				flag2 = false;
				flag = false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X11_v2 (Il2CppClass<UnityEngine.UI.Slider>)+420]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X11_v2 (Il2CppClass<UnityEngine.UI.Slider>)+428]");
			object obj8 = 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float num7 = ((!(flag4 && flag5)) ? num4 : 0f);
			float num8 = num7 + value;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v70 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0xB10F84", Offset = "0xB10F84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ForceSliderToMultipleOf3()
		{
		}
	}
}
