using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000DB")]
	public class EditorConsentDialogButtonUI : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40003CD")]
		[FieldOffset(Offset = "0x18")]
		private Button button;

		[SerializeField]
		[Token(Token = "0x40003CE")]
		[FieldOffset(Offset = "0x20")]
		private Text text;

		[Token(Token = "0x1700022C")]
		public Button Button
		{
			[Token(Token = "0x60007BC")]
			[Address(RVA = "0xB4A120", Offset = "0xB4A120", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.button;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Button;
			}
		}

		[Token(Token = "0x1700022D")]
		public Text Text
		{
			[Token(Token = "0x60007BD")]
			[Address(RVA = "0xB4A128", Offset = "0xB4A128", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.text;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Text;
			}
		}

		[Token(Token = "0x1700022E")]
		public bool Interactable
		{
			[Token(Token = "0x60007BE")]
			[Address(RVA = "0xB4A130", Offset = "0xB4A130", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDF0B8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022725]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv59 = this.button;\n\tv67 = v59.m_Interactable == 0;\n\tv72 = ~v67;\n\tgoto L_003D;\nL_003D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Button != null)
				{
					Button button = Button;
					bool flag = !button.interactable;
					return !flag;
				}
				return false;
			}
			[Token(Token = "0x60007BF")]
			[Address(RVA = "0xB4A1CC", Offset = "0xB4A1CC", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ED7430]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022726]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tUnityEngine.UI.Selectable::set_interactable(this.button, value);\n\treturn;\nL_003C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Button != null)
				{
					Button.interactable = value;
				}
			}
		}

		[Token(Token = "0x60007C0")]
		[Address(RVA = "0xB4A274", Offset = "0xB4A274", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = action == 0;\n\tif (v6) goto L_0015;\n\tv8 = this.button;\n\tUnityEngine.Events.UnityEvent::AddListener(v8.m_OnClick, action);\n\treturn;\nL_0015:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddListener(UnityAction action)
		{
			if (action != null)
			{
				Button button = Button;
				button.onClick.AddListener(action);
			}
		}

		[Token(Token = "0x60007C1")]
		[Address(RVA = "0xB4A2AC", Offset = "0xB4A2AC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ED90B8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, newText, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022727]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, newText, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.text, 0);\n\tv60 = newText == 0;\n\tif (v60) goto L_003F;\n\tv62 = v59 == 0;\n\tif (v62) goto L_003F;\n\tv69 = this.text;\n\tv87 = *([v69 @ X0_v6 (UnityEngine.UI.Text)]);\n\tv72 = *([v87 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv76 = *([v87 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 56 IndirectJump v72 @ X3_v1, v69 @ X0_v6 (UnityEngine.UI.Text), v69 @ X0_v6 (UnityEngine.UI.Text), newText @ X1 (System.String), v76 @ X2_v2, v72 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateText(string newText)
		{
			//IL_0066: Expected I, but got O
			//IL_0076: Expected O, but got I
			//IL_0086: Expected O, but got I
			bool flag = Text != null;
			if (newText != null && flag)
			{
				Text text = Text;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v72 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007C2")]
		[Address(RVA = "0xB4A360", Offset = "0xB4A360", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = color.g;\n\tv2 = color.b;\n\tv3 = color.a;\n\tgoto L_0025;\n\tv34 = *([1EE7668]);\n\tv35 = *([v34 @ X8_v11]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, color, v0, v2, v3, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022728]) = v50;\nL_0025:\n\tgoto L_002E;\n\tv58 = *([v54 @ X0_v2+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002E;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v38, v39, v40, v41, v42, v43, color, v0, v2, v3, v44, v45, v46, v47);\nL_002E:\n\tv68 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0053;\n\tv82 = UnityEngine.UI.Selectable::get_image(this.button);\n\tv109 = *([v82 @ X0_v9 (UnityEngine.UI.Image)]);\n\tv93 = *([v109 @ X8_v7 (Il2CppClass<UnityEngine.UI.Image>)+2A0]);\n\tv95 = *([v109 @ X8_v7 (Il2CppClass<UnityEngine.UI.Image>)+2A8]);\n\t// 73 IndirectJump v93 @ X2_v2, v82 @ X0_v9 (UnityEngine.UI.Image), v82 @ X0_v9 (UnityEngine.UI.Image), v95 @ X1_v4, v93 @ X2_v2, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, color @ V0 (UnityEngine.Color), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v3 @ V3_v1 (System.Single), v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_0053:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateBackgroundColor(Color color)
		{
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_0095: Expected O, but got I
			float g = color.g;
			float b = color.b;
			float a = color.a;
			if (Button != null)
			{
				Image image = Button.image;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v7 (Il2CppClass<UnityEngine.UI.Image>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v7 (Il2CppClass<UnityEngine.UI.Image>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v93 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007C3")]
		[Address(RVA = "0xB4A440", Offset = "0xB4A440", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = color.g;\n\tv2 = color.b;\n\tv3 = color.a;\n\tgoto L_0025;\n\tv34 = *([1EEB030]);\n\tv35 = *([v34 @ X8_v11]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, color, v0, v2, v3, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022729]) = v50;\nL_0025:\n\tgoto L_002E;\n\tv58 = *([v54 @ X0_v2+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002E;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v38, v39, v40, v41, v42, v43, color, v0, v2, v3, v44, v45, v46, v47);\nL_002E:\n\tv68 = UnityEngine.Object::op_Inequality(this.text, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_004F;\n\tv71 = this.text;\n\tv81 = *([v71 @ X0_v6 (UnityEngine.UI.Text)]);\n\tv86 = *([v81 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+2A0]);\n\tv87 = *([v81 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+2A8]);\n\t// 69 IndirectJump v86 @ X2_v2, v71 @ X0_v6 (UnityEngine.UI.Text), v71 @ X0_v6 (UnityEngine.UI.Text), v87 @ X1_v2, v86 @ X2_v2, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, color @ V0 (UnityEngine.Color), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v3 @ V3_v1 (System.Single), v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateTextColor(Color color)
		{
			//IL_0070: Expected I, but got O
			//IL_0080: Expected O, but got I
			//IL_0090: Expected O, but got I
			float g = color.g;
			float b = color.b;
			float a = color.a;
			if (Text != null)
			{
				Text text = Text;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v86 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007C4")]
		[Address(RVA = "0xB4A514", Offset = "0xB4A514", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogButtonUI()
		{
		}
	}
}
