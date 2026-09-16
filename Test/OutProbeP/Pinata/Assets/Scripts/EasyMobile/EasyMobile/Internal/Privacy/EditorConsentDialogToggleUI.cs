using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000DE")]
	public class EditorConsentDialogToggleUI : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001C1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006C4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006C5")]
			public static Action<string> _003C_003E9__21_0;

			[Token(Token = "0x6000D14")]
			[Address(RVA = "0xB4E58C", Offset = "0xB4E58C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB2780]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202274F]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000D15")]
			[Address(RVA = "0xB4E5F0", Offset = "0xB4E5F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CAwake_003Eb__21_0(string link)
			{
				Application.OpenURL(link);
			}
		}

		[SerializeField]
		[Token(Token = "0x40003F1")]
		[FieldOffset(Offset = "0x18")]
		private Button expandButton;

		[SerializeField]
		[Token(Token = "0x40003F2")]
		[FieldOffset(Offset = "0x20")]
		private EditorConsentDialogToggleSwitch toggle;

		[SerializeField]
		[Token(Token = "0x40003F3")]
		[FieldOffset(Offset = "0x28")]
		private EditorConsentDialogClickableText descriptionText;

		[SerializeField]
		[Token(Token = "0x40003F4")]
		[FieldOffset(Offset = "0x30")]
		private Text title;

		[SerializeField]
		[Token(Token = "0x40003F5")]
		[FieldOffset(Offset = "0x38")]
		private Image expandArrow;

		[SerializeField]
		[Token(Token = "0x40003F6")]
		[FieldOffset(Offset = "0x40")]
		private Sprite collapseIcon;

		[SerializeField]
		[Token(Token = "0x40003F7")]
		[FieldOffset(Offset = "0x48")]
		private Sprite expandIcon;

		[SerializeField]
		[Token(Token = "0x40003F8")]
		[FieldOffset(Offset = "0x50")]
		private LayoutElement descriptionLayout;

		[SerializeField]
		[Token(Token = "0x40003F9")]
		[FieldOffset(Offset = "0x58")]
		private float expandAnimationDuration;

		[Token(Token = "0x40003FA")]
		[FieldOffset(Offset = "0x60")]
		public Action<string, bool> OnToggleStateUpdated;

		[CompilerGenerated]
		[Token(Token = "0x40003FB")]
		[FieldOffset(Offset = "0x68")]
		private bool _003CIsDescriptionExpanded_003Ek__BackingField;

		[Token(Token = "0x40003FC")]
		[FieldOffset(Offset = "0x70")]
		private Coroutine expandCoroutine;

		[Token(Token = "0x17000233")]
		public bool IsDescriptionExpanded
		{
			[CompilerGenerated]
			[Token(Token = "0x60007ED")]
			[Address(RVA = "0xB4DABC", Offset = "0xB4DABC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsDescriptionExpanded>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsDescriptionExpanded;
			}
			[CompilerGenerated]
			[Token(Token = "0x60007EE")]
			[Address(RVA = "0xB4DAC4", Offset = "0xB4DAC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsDescriptionExpanded>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsDescriptionExpanded_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000234")]
		public bool IsOn
		{
			[Token(Token = "0x60007EF")]
			[Address(RVA = "0xB4DAD0", Offset = "0xB4DAD0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF3290]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022745]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.toggle, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv59 = this.toggle;\n\tv67 = v59.m_IsOn == 0;\n\tv72 = ~v67;\n\tgoto L_003D;\nL_003D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (toggle != null)
				{
					EditorConsentDialogToggleSwitch editorConsentDialogToggleSwitch = toggle;
					bool flag = !editorConsentDialogToggleSwitch.isOn;
					return !flag;
				}
				return false;
			}
			[Token(Token = "0x60007F0")]
			[Address(RVA = "0xB4DB6C", Offset = "0xB4DB6C", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EAA070]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022746]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.toggle, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Set(this.toggle, value, 1);\n\treturn;\nL_003C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (toggle != null)
				{
					toggle.Set(value, sendCallback: true);
				}
			}
		}

		[Token(Token = "0x17000235")]
		public float ExpandAnimationDuration
		{
			[Token(Token = "0x60007F1")]
			[Address(RVA = "0xB4DC14", Offset = "0xB4DC14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.expandAnimationDuration;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ExpandAnimationDuration;
			}
			[Token(Token = "0x60007F2")]
			[Address(RVA = "0xB4DC1C", Offset = "0xB4DC1C", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value < 0;\n\tif (v4) goto L_000B;\n\tthis.expandAnimationDuration = value;\nL_000B:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (!(value < 0f))
				{
					expandAnimationDuration = value;
				}
			}
		}

		[Token(Token = "0x60007F3")]
		[Address(RVA = "0xB4DC2C", Offset = "0xB4DC2C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1ED1308]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022747]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv64 = UnityEngine.Object::op_Inequality(this.descriptionText, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0064;\n\tgoto L_003A;\n\tv100 = *([v70 @ X0_v21 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_003A;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v70, v62, v63, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv104 = EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c;\nL_003A:\n\tv79 = v107.<>9__21_0;\n\tv109 = v107.<>9__21_0 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_005E;\n\tgoto L_004D;\n\tv140 = *([v103 @ X0_v22 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_004D;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v103, v62, v63, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv216 = EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c;\n\tv147 = *([v216 @ X8_v29+B8]);\nL_004D:\n\tv134 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v134, v146.<>9, Il2CppMethodInfo);\n\tv137.<>9__21_0 = v134;\nL_005E:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText::add_OnHyperlinkClicked(this.descriptionText, v79);\nL_0064:\n\tgoto L_006D;\n\tv111 = *([v95 @ X0_v11+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_006D;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v95, v86, v84, v76, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_006D:\n\tv121 = UnityEngine.Object::op_Inequality(this.expandButton, 0);\n\tv139 = v121 == 0;\n\tif (v139) goto L_0086;\n\tv168 = this.expandButton;\n\tv163 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v163, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v168.m_OnClick, v163);\nL_0086:\n\tv184 = this.descriptionLayout;\n\tthis.<IsDescriptionExpanded>k__BackingField = 0;\n\tv204 = *([v184 @ X0_v16 (UnityEngine.UI.LayoutElement)]);\n\tv211 = *([v204 @ X8_v11 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390]);\n\tv212 = *([v204 @ X8_v11 (Il2CppClass<UnityEngine.UI.LayoutElement>)+398]);\n\t// 151 IndirectJump v211 @ X2_v7, v184 @ X0_v16 (UnityEngine.UI.LayoutElement), v184 @ X0_v16 (UnityEngine.UI.LayoutElement), v212 @ X1_v7, v211 @ X2_v7, v173 @ X3_v4 (Il2CppMethodInfo), v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, 0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Awake()
		{
			//IL_00e5: Expected I, but got O
			//IL_00f5: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_00be: Expected I, but got O
			while (true)
			{
				if (descriptionText != null)
				{
					Action<string> value = _003C_003Ec._003C_003E9__21_0;
					if (_003C_003Ec._003C_003E9__21_0 == null)
					{
						Action<string> action = (_003C_003Ec._003C_003E9__21_0 = delegate(string link)
						{
							Application.OpenURL(link);
						});
						IntPtr intPtr = (IntPtr)0;
						value = action;
					}
					descriptionText.OnHyperlinkClicked += value;
				}
				if (expandButton != null)
				{
					Button button = expandButton;
					UnityAction call = delegate
					{
						ToggleDescription();
					};
					button.onClick.AddListener(call);
					IntPtr intPtr = (IntPtr)null;
				}
				LayoutElement layoutElement = descriptionLayout;
				IsDescriptionExpanded = false;
				IntPtr intPtr2 = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X8_v11 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X8_v11 (Il2CppClass<UnityEngine.UI.LayoutElement>)+398]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v211 @ X2_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007F4")]
		[Address(RVA = "0xB4DDF8", Offset = "0xB4DDF8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.expandAnimationDuration >= 0;\n\tif (v11) goto L_000D;\n\tthis.expandAnimationDuration = 0f;\nL_000D:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnValidate()
		{
			if (ExpandAnimationDuration < 0f)
			{
				expandAnimationDuration = 0f;
			}
		}

		[Token(Token = "0x60007F5")]
		[Address(RVA = "0xB4DE0C", Offset = "0xB4DE0C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = EasyMobile.ConsentDialog+Toggle::get_Description(toggleData);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::UpdateDescription(this, v17);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::UpdateTitle(this, toggleData.title);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::SetupToggle(this, toggleData);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateSettings(ConsentDialog.Toggle toggleData)
		{
			string description = toggleData.Description;
			UpdateDescription(description);
			UpdateTitle(toggleData.Title);
			SetupToggle(toggleData);
		}

		[Token(Token = "0x60007F6")]
		[Address(RVA = "0xB4E174", Offset = "0xB4E174", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED9420]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022748]) = v40;\nL_0015:\n\tv42 = ~this.<IsDescriptionExpanded>k__BackingField;\n\tif (v42) goto L_0025;\n\treturn;\nL_0025:\n\tgoto L_002E;\n\tv84 = *([v51 @ X0_v2+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_002E;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv94 = UnityEngine.Object::op_Inequality(this.expandArrow, 0);\n\tv96 = v94 == 0;\n\tif (v96) goto L_004A;\n\tgoto L_0040;\n\tv118 = *([v97 @ X0_v12+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0040;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v97, v92, v93, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0040:\n\tv109 = UnityEngine.Object::op_Inequality(this.expandIcon, 0);\n\tv112 = v109 == 0;\n\tif (v112) goto L_004A;\n\tUnityEngine.UI.Image::set_sprite(this.expandArrow, this.expandIcon);\nL_004A:\n\tv116 = this.descriptionText;\n\tthis.<IsDescriptionExpanded>k__BackingField = 1;\n\tv125 = UnityEngine.UI.Text::get_preferredHeight(v116);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::AnimateDescription(this, v30);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ExpandDescription()
		{
			if (!IsDescriptionExpanded)
			{
				if (expandArrow != null && expandIcon != null)
				{
					expandArrow.sprite = expandIcon;
				}
				EditorConsentDialogClickableText editorConsentDialogClickableText = descriptionText;
				IsDescriptionExpanded = true;
				float preferredHeight = editorConsentDialogClickableText.preferredHeight;
				float targetHeight = default(float);
				AnimateDescription(targetHeight);
			}
		}

		[Token(Token = "0x60007F7")]
		[Address(RVA = "0xB4E2D4", Offset = "0xB4E2D4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0A038]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022749]) = v40;\nL_0015:\n\tv42 = ~this.<IsDescriptionExpanded>k__BackingField;\n\tif (v42) goto L_0053;\n\tgoto L_0027;\n\tv55 = *([v46 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv65 = UnityEngine.Object::op_Inequality(this.expandArrow, 0);\n\tv94 = v65 == 0;\n\tif (v94) goto L_0042;\n\tgoto L_0038;\n\tv106 = *([v95 @ X0_v8+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0038;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v95, v63, v64, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0038:\n\tv103 = UnityEngine.Object::op_Implicit(this.collapseIcon);\n\tv104 = v103 == 0;\n\tif (v104) goto L_0042;\n\tUnityEngine.UI.Image::set_sprite(this.expandArrow, this.collapseIcon);\nL_0042:\n\tthis.<IsDescriptionExpanded>k__BackingField = 0;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::AnimateDescription(this, 0f);\n\treturn;\nL_0053:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CollapseDescription()
		{
			if (IsDescriptionExpanded)
			{
				if (expandArrow != null && (bool)collapseIcon)
				{
					expandArrow.sprite = collapseIcon;
				}
				IsDescriptionExpanded = false;
				AnimateDescription(0f);
			}
		}

		[Token(Token = "0x60007F8")]
		[Address(RVA = "0xB4E3BC", Offset = "0xB4E3BC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.<IsDescriptionExpanded>k__BackingField;\n\tif (v2) goto L_0005;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::CollapseDescription(this);\n\treturn;\nL_0005:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::ExpandDescription(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ToggleDescription()
		{
			if (IsDescriptionExpanded)
			{
				CollapseDescription();
			}
			else
			{
				ExpandDescription();
			}
		}

		[Token(Token = "0x60007F9")]
		[Address(RVA = "0xB4DF64", Offset = "0xB4DF64", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC9B30]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202274A]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Equality(this.title, 0);\n\tv60 = text == 0;\n\tif (v60) goto L_0040;\n\tv62 = v59 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0040;\n\tv70 = this.title;\n\tv88 = *([v70 @ X0_v6 (UnityEngine.UI.Text)]);\n\tv73 = *([v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv77 = *([v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 57 IndirectJump v73 @ X3_v1, v70 @ X0_v6 (UnityEngine.UI.Text), v70 @ X0_v6 (UnityEngine.UI.Text), text @ X1 (System.String), v77 @ X2_v2, v73 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateTitle(string text)
		{
			//IL_0071: Expected I, but got O
			//IL_0081: Expected O, but got I
			//IL_0091: Expected O, but got I
			bool flag = title == null;
			if (text != null && !flag)
			{
				Text text2 = title;
				IntPtr intPtr = (IntPtr)text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v73 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007FA")]
		[Address(RVA = "0xB4DE64", Offset = "0xB4DE64", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F075E8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202274B]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Equality(this.descriptionText, 0);\n\tv60 = text == 0;\n\tif (v60) goto L_0052;\n\tv62 = v59 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0052;\n\tv109 = UnityEngine.UI.Text::set_text(this.descriptionText, text);\n\tv111 = this.descriptionLayout;\n\tv112 = ~this.<IsDescriptionExpanded>k__BackingField;\n\tif (v112) goto L_0054;\n\tv128 = UnityEngine.UI.Text::get_preferredHeight(this.descriptionText);\nL_0041:\n\tv99 = *([v111 @ X20_v4 (UnityEngine.UI.LayoutElement)]);\n\t// 75 IndirectJump [v99 @ X8_v12 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390], this.descriptionLayout (UnityEngine.UI.LayoutElement), this.descriptionLayout (UnityEngine.UI.LayoutElement), [v99 @ X8_v12 (Il2CppClass<UnityEngine.UI.LayoutElement>)+398], [v99 @ X8_v12 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390], v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, 0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0052:\n\treturn;\nL_0054:\n\tv123 = this.descriptionLayout == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0041;\n\tv117 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateDescription(string text)
		{
			//IL_00aa: Expected I, but got O
			bool flag = descriptionText == null;
			if (text != null && !flag)
			{
				descriptionText.text = text;
				LayoutElement layoutElement = descriptionLayout;
				if (IsDescriptionExpanded)
				{
					float preferredHeight = descriptionText.preferredHeight;
				}
				else if ((object)descriptionLayout == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
				IntPtr intPtr = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v99 @ X8_v12 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390] (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60007FB")]
		[Address(RVA = "0xB4E018", Offset = "0xB4E018", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE1A70]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, toggleData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202274C]) = v41;\nL_0018:\n\tv45 = new EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<>c__DisplayClass29_0();\n\tSystem.Object::.ctor(v45);\n\tv45.toggleData = toggleData;\n\tv45.<>4__this = this;\n\tgoto L_0030;\n\tv86 = *([v52 @ X0_v8+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0030;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v52, v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0030:\n\tv70 = UnityEngine.Object::op_Equality(this.toggle, 0);\n\tv108 = v70 == 0;\n\tif (v108) goto L_003B;\n\treturn;\nL_003B:\n\tv82 = v45.toggleData;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Set(this.toggle, v82.isOn, 1);\n\tv83 = v45.toggleData;\n\tv99 = this.toggle;\n\tv128 = ~v83.interactable;\n\tif (v128) goto L_0072;\n\tv72 = new UnityEngine.Events.UnityAction`1<System.Boolean>();\n\tUnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(v72, v45, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::AddListener(*([v99 @ X0_v13 (UnityEngine.UI.Selectable)+158]), v72);\n\treturn;\nL_0072:\n\tUnityEngine.UI.Selectable::set_interactable(this.toggle, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetupToggle(ConsentDialog.Toggle toggleData)
		{
			//IL_00e7: Expected O, but got I
			if (this.toggle == null)
			{
				return;
			}
			ConsentDialog.Toggle toggle = toggleData;
			this.toggle.Set(toggle.IsOn, sendCallback: true);
			ConsentDialog.Toggle toggle2 = toggleData;
			Selectable selectable = this.toggle;
			if (toggle2.IsInteractable)
			{
				UnityAction<bool> call = delegate(bool isOn)
				{
					//IL_0032: Expected O, but got I
					//IL_0041: Expected O, but got I
					ConsentDialog.Toggle toggle3 = toggleData;
					if (toggle3.ShouldToggleDescription)
					{
						object obj = (long)(IntPtr)toggle3 + 32L;
						object text = (long)(IntPtr)toggle3 + 40L;
						if (isOn)
						{
							text = obj;
						}
						UpdateDescription((string)text);
					}
					EditorConsentDialogToggleUI editorConsentDialogToggleUI = this;
					if (editorConsentDialogToggleUI.OnToggleStateUpdated != null)
					{
						ConsentDialog.Toggle toggle4 = toggleData;
						editorConsentDialogToggleUI.OnToggleStateUpdated(toggle4.Id, isOn);
					}
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X0_v13 (UnityEngine.UI.Selectable)+158]");
				((UnityEvent<bool>)0).AddListener(call);
			}
			else
			{
				this.toggle.interactable = false;
			}
		}

		[Token(Token = "0x60007FC")]
		[Address(RVA = "0xB4E3D4", Offset = "0xB4E3D4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECAAB0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202274D]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.expandButton, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_002F;\n\treturn;\nL_002F:\n\tv66 = this.expandButton;\n\tv102 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v102, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v66.m_OnClick, v102);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetupExpandButton()
		{
			if (expandButton == null)
			{
				return;
			}
			Button button = expandButton;
			UnityAction call = delegate
			{
				if (IsDescriptionExpanded)
				{
					CollapseDescription();
				}
				else
				{
					ExpandDescription();
				}
			};
			button.onClick.AddListener(call);
		}

		[Token(Token = "0x60007FD")]
		[Address(RVA = "0xB4E278", Offset = "0xB4E278", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.expandCoroutine == 0;\n\tif (v15) goto L_0010;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.expandCoroutine);\nL_0010:\n\tv23 = EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::AnimateDescriptionCoroutine(this, targetHeight);\n\tv27 = UnityEngine.MonoBehaviour::StartCoroutine(this, v23);\n\tthis.expandCoroutine = v27;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AnimateDescription(float targetHeight)
		{
			if (expandCoroutine != null)
			{
				StopCoroutine(expandCoroutine);
			}
			IEnumerator routine = AnimateDescriptionCoroutine(targetHeight);
			Coroutine coroutine = StartCoroutine(routine);
			expandCoroutine = coroutine;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7383BC", Offset = "0x7383BC")]
		[Token(Token = "0x60007FE")]
		[Address(RVA = "0xB4E4B4", Offset = "0xB4E4B4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDD1F0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, targetHeight, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202274E]) = v41;\nL_0018:\n\tv45 = new EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI+<AnimateDescriptionCoroutine>d__32();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.targetHeight = targetHeight;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator AnimateDescriptionCoroutine(float targetHeight)
		{
			_003CAnimateDescriptionCoroutine_003Ed__32 _003CAnimateDescriptionCoroutine_003Ed__33 = null;
			_003CAnimateDescriptionCoroutine_003Ed__33._003C_003E1__state = 0;
			_003CAnimateDescriptionCoroutine_003Ed__33._003C_003E4__this = this;
			_003CAnimateDescriptionCoroutine_003Ed__33.targetHeight = targetHeight;
			return _003CAnimateDescriptionCoroutine_003Ed__33;
		}

		[Token(Token = "0x60007FF")]
		[Address(RVA = "0xB4E564", Offset = "0xB4E564", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.expandAnimationDuration = 0.2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogToggleUI()
		{
			expandAnimationDuration = 0.2f;
		}
	}
}
