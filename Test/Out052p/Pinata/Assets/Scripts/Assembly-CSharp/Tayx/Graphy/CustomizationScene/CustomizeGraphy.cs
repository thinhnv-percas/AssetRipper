using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	[Token(Token = "0x2000044")]
	public class CustomizeGraphy : MonoBehaviour
	{
		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x7647F8", Offset = "0x7647F8")]
		[SerializeField]
		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x18")]
		private G_CUIColorPicker m_colorPicker;

		[SerializeField]
		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x20")]
		private Toggle m_backgroundToggle;

		[SerializeField]
		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x28")]
		private Dropdown m_graphyModeDropdown;

		[SerializeField]
		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x30")]
		private Button m_backgroundColorButton;

		[SerializeField]
		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x38")]
		private Dropdown m_graphModulePositionDropdown;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x764884", Offset = "0x764884")]
		[SerializeField]
		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x40")]
		private Dropdown m_fpsModuleStateDropdown;

		[SerializeField]
		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x48")]
		private InputField m_goodInputField;

		[SerializeField]
		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x50")]
		private InputField m_cautionInputField;

		[SerializeField]
		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x58")]
		private Button m_goodColorButton;

		[SerializeField]
		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x60")]
		private Button m_cautionColorButton;

		[SerializeField]
		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x68")]
		private Button m_criticalColorButton;

		[SerializeField]
		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x70")]
		private Slider m_timeToResetMinMaxSlider;

		[SerializeField]
		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x78")]
		private Slider m_fpsGraphResolutionSlider;

		[SerializeField]
		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x80")]
		private Slider m_fpsTextUpdateRateSlider;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x764950", Offset = "0x764950")]
		[SerializeField]
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x88")]
		private Dropdown m_ramModuleStateDropdown;

		[SerializeField]
		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x90")]
		private Button m_reservedColorButton;

		[SerializeField]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x98")]
		private Button m_allocatedColorButton;

		[SerializeField]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0xA0")]
		private Button m_monoColorButton;

		[SerializeField]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0xA8")]
		private Slider m_ramGraphResolutionSlider;

		[SerializeField]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0xB0")]
		private Slider m_ramTextUpdateRateSlider;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x7649EC", Offset = "0x7649EC")]
		[SerializeField]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0xB8")]
		private Dropdown m_audioModuleStateDropdown;

		[SerializeField]
		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0xC0")]
		private Button m_audioGraphColorButton;

		[SerializeField]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0xC8")]
		private Dropdown m_findAudioListenerDropdown;

		[SerializeField]
		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0xD0")]
		private Dropdown m_fttWindowDropdown;

		[SerializeField]
		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0xD8")]
		private Slider m_spectrumSizeSlider;

		[SerializeField]
		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0xE0")]
		private Slider m_audioGraphResolutionSlider;

		[SerializeField]
		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0xE8")]
		private Slider m_audioTextUpdateRateSlider;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x764A98", Offset = "0x764A98")]
		[SerializeField]
		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0xF0")]
		private Dropdown m_advancedModulePositionDropdown;

		[SerializeField]
		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0xF8")]
		private Toggle m_advancedModuleToggle;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x764AF4", Offset = "0x764AF4")]
		[SerializeField]
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x100")]
		private Button m_musicButton;

		[SerializeField]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x108")]
		private Button m_sfxButton;

		[SerializeField]
		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x110")]
		private Slider m_musicVolumeSlider;

		[SerializeField]
		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x118")]
		private Slider m_sfxVolumeSlider;

		[SerializeField]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x120")]
		private AudioSource m_musicAudioSource;

		[SerializeField]
		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x128")]
		private AudioSource m_sfxAudioSource;

		[SerializeField]
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x130")]
		private List<AudioClip> m_sfxAudioClips;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x138")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xB0EC84", Offset = "0xB0EC84", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB98C8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202250C]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = Tayx.Graphy.Utils.G_Singleton`1<Tayx.Graphy.GraphyManager>::get_Instance();\n\tthis.m_graphyManager = v55;\n\tTayx.Graphy.CustomizationScene.CustomizeGraphy::SetupCallbacks(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			GraphyManager instance = G_Singleton<GraphyManager>.Instance;
			m_graphyManager = instance;
			SetupCallbacks();
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xB0ECFC", Offset = "0xB0ECFC", Length = "0xC64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EB95F0]);\n\tv35 = *([v34 @ X8_v145]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202250D]) = v54;\nL_001B:\n\tv55 = this.m_backgroundToggle;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v55.onValueChanged);\n\tv497 = this.m_backgroundColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v497.m_OnClick);\n\tv498 = this.m_graphyModeDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v498.m_OnValueChanged);\n\tv499 = this.m_graphModulePositionDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v499.m_OnValueChanged);\n\tv500 = this.m_fpsModuleStateDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v500.m_OnValueChanged);\n\tv501 = this.m_goodInputField;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v501.m_OnValueChanged);\n\tv502 = this.m_cautionInputField;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v502.m_OnValueChanged);\n\tv503 = this.m_goodColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v503.m_OnClick);\n\tv504 = this.m_cautionColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v504.m_OnClick);\n\tv505 = this.m_criticalColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v505.m_OnClick);\n\tv506 = this.m_timeToResetMinMaxSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v506.m_OnValueChanged);\n\tv507 = this.m_fpsGraphResolutionSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v507.m_OnValueChanged);\n\tv508 = this.m_fpsTextUpdateRateSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v508.m_OnValueChanged);\n\tv509 = this.m_ramModuleStateDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v509.m_OnValueChanged);\n\tv510 = this.m_reservedColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v510.m_OnClick);\n\tv511 = this.m_allocatedColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v511.m_OnClick);\n\tv512 = this.m_monoColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v512.m_OnClick);\n\tv513 = this.m_ramGraphResolutionSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v513.m_OnValueChanged);\n\tv514 = this.m_ramTextUpdateRateSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v514.m_OnValueChanged);\n\tv515 = this.m_audioModuleStateDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v515.m_OnValueChanged);\n\tv516 = this.m_audioGraphColorButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v516.m_OnClick);\n\tv517 = this.m_findAudioListenerDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v517.m_OnValueChanged);\n\tv518 = this.m_fttWindowDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v518.m_OnValueChanged);\n\tv519 = this.m_spectrumSizeSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v519.m_OnValueChanged);\n\tv520 = this.m_audioGraphResolutionSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v520.m_OnValueChanged);\n\tv521 = this.m_audioTextUpdateRateSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v521.m_OnValueChanged);\n\tv522 = this.m_advancedModulePositionDropdown;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v522.m_OnValueChanged);\n\tv523 = this.m_advancedModuleToggle;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v523.onValueChanged);\n\tv524 = this.m_musicButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v524.m_OnClick);\n\tv525 = this.m_sfxButton;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v525.m_OnClick);\n\tv526 = this.m_musicVolumeSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v526.m_OnValueChanged);\n\tv527 = this.m_sfxVolumeSlider;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v527.m_OnValueChanged);\n\tv528 = this.m_backgroundToggle;\n\tv337 = new UnityEngine.Events.UnityAction`1<System.Boolean>();\n\tUnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(v337, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::AddListener(v528.onValueChanged, v337);\n\tv530 = this.m_backgroundColorButton;\n\tv339 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v339, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v530.m_OnClick, v339);\n\tv532 = this.m_graphyModeDropdown;\n\tv341 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v341, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v532.m_OnValueChanged, v341);\n\tv534 = this.m_graphModulePositionDropdown;\n\tv343 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v343, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v534.m_OnValueChanged, v343);\n\tv536 = this.m_fpsModuleStateDropdown;\n\tv345 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v345, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v536.m_OnValueChanged, v345);\n\tv538 = this.m_goodInputField;\n\tv347 = new UnityEngine.Events.UnityAction`1<System.String>();\n\tUnityEngine.Events.UnityAction`1<System.String>::.ctor(v347, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.String>::AddListener(v538.m_OnValueChanged, v347);\n\tv540 = this.m_cautionInputField;\n\tv349 = new UnityEngine.Events.UnityAction`1<System.String>();\n\tUnityEngine.Events.UnityAction`1<System.String>::.ctor(v349, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.String>::AddListener(v540.m_OnValueChanged, v349);\n\tv542 = this.m_goodColorButton;\n\tv351 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v351, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v542.m_OnClick, v351);\n\tv544 = this.m_cautionColorButton;\n\tv353 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v353, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v544.m_OnClick, v353);\n\tv546 = this.m_criticalColorButton;\n\tv355 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v355, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v546.m_OnClick, v355);\n\tv548 = this.m_timeToResetMinMaxSlider;\n\tv357 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v357, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v548.m_OnValueChanged, v357);\n\tv550 = this.m_fpsGraphResolutionSlider;\n\tv359 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v359, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v550.m_OnValueChanged, v359);\n\tv552 = this.m_fpsTextUpdateRateSlider;\n\tv361 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v361, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v552.m_OnValueChanged, v361);\n\tv554 = this.m_ramModuleStateDropdown;\n\tv363 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v363, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v554.m_OnValueChanged, v363);\n\tv556 = this.m_reservedColorButton;\n\tv365 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v365, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v556.m_OnClick, v365);\n\tv558 = this.m_allocatedColorButton;\n\tv367 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v367, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v558.m_OnClick, v367);\n\tv560 = this.m_monoColorButton;\n\tv369 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v369, this, Il2CppMethodInfo);\n\tUnityEng\n// ... truncated")]
		private unsafe void SetupCallbacks()
		{
			Toggle backgroundToggle = m_backgroundToggle;
			backgroundToggle.onValueChanged.RemoveAllListeners();
			Button backgroundColorButton = m_backgroundColorButton;
			backgroundColorButton.onClick.RemoveAllListeners();
			Dropdown graphyModeDropdown = m_graphyModeDropdown;
			graphyModeDropdown.onValueChanged.RemoveAllListeners();
			Dropdown graphModulePositionDropdown = m_graphModulePositionDropdown;
			graphModulePositionDropdown.onValueChanged.RemoveAllListeners();
			Dropdown fpsModuleStateDropdown = m_fpsModuleStateDropdown;
			fpsModuleStateDropdown.onValueChanged.RemoveAllListeners();
			InputField goodInputField = m_goodInputField;
			goodInputField.onValueChange.RemoveAllListeners();
			InputField cautionInputField = m_cautionInputField;
			cautionInputField.onValueChange.RemoveAllListeners();
			Button goodColorButton = m_goodColorButton;
			goodColorButton.onClick.RemoveAllListeners();
			Button cautionColorButton = m_cautionColorButton;
			cautionColorButton.onClick.RemoveAllListeners();
			Button criticalColorButton = m_criticalColorButton;
			criticalColorButton.onClick.RemoveAllListeners();
			Slider timeToResetMinMaxSlider = m_timeToResetMinMaxSlider;
			timeToResetMinMaxSlider.onValueChanged.RemoveAllListeners();
			Slider fpsGraphResolutionSlider = m_fpsGraphResolutionSlider;
			fpsGraphResolutionSlider.onValueChanged.RemoveAllListeners();
			Slider fpsTextUpdateRateSlider = m_fpsTextUpdateRateSlider;
			fpsTextUpdateRateSlider.onValueChanged.RemoveAllListeners();
			Dropdown ramModuleStateDropdown = m_ramModuleStateDropdown;
			ramModuleStateDropdown.onValueChanged.RemoveAllListeners();
			Button reservedColorButton = m_reservedColorButton;
			reservedColorButton.onClick.RemoveAllListeners();
			Button allocatedColorButton = m_allocatedColorButton;
			allocatedColorButton.onClick.RemoveAllListeners();
			Button monoColorButton = m_monoColorButton;
			monoColorButton.onClick.RemoveAllListeners();
			Slider ramGraphResolutionSlider = m_ramGraphResolutionSlider;
			ramGraphResolutionSlider.onValueChanged.RemoveAllListeners();
			Slider ramTextUpdateRateSlider = m_ramTextUpdateRateSlider;
			ramTextUpdateRateSlider.onValueChanged.RemoveAllListeners();
			Dropdown audioModuleStateDropdown = m_audioModuleStateDropdown;
			audioModuleStateDropdown.onValueChanged.RemoveAllListeners();
			Button audioGraphColorButton = m_audioGraphColorButton;
			audioGraphColorButton.onClick.RemoveAllListeners();
			Dropdown findAudioListenerDropdown = m_findAudioListenerDropdown;
			findAudioListenerDropdown.onValueChanged.RemoveAllListeners();
			Dropdown fttWindowDropdown = m_fttWindowDropdown;
			fttWindowDropdown.onValueChanged.RemoveAllListeners();
			Slider spectrumSizeSlider = m_spectrumSizeSlider;
			spectrumSizeSlider.onValueChanged.RemoveAllListeners();
			Slider audioGraphResolutionSlider = m_audioGraphResolutionSlider;
			audioGraphResolutionSlider.onValueChanged.RemoveAllListeners();
			Slider audioTextUpdateRateSlider = m_audioTextUpdateRateSlider;
			audioTextUpdateRateSlider.onValueChanged.RemoveAllListeners();
			Dropdown advancedModulePositionDropdown = m_advancedModulePositionDropdown;
			advancedModulePositionDropdown.onValueChanged.RemoveAllListeners();
			Toggle advancedModuleToggle = m_advancedModuleToggle;
			advancedModuleToggle.onValueChanged.RemoveAllListeners();
			Button musicButton = m_musicButton;
			musicButton.onClick.RemoveAllListeners();
			Button sfxButton = m_sfxButton;
			sfxButton.onClick.RemoveAllListeners();
			Slider musicVolumeSlider = m_musicVolumeSlider;
			musicVolumeSlider.onValueChanged.RemoveAllListeners();
			Slider sfxVolumeSlider = m_sfxVolumeSlider;
			sfxVolumeSlider.onValueChanged.RemoveAllListeners();
			Toggle backgroundToggle2 = m_backgroundToggle;
			UnityAction<bool> call = delegate(bool value)
			{
				GraphyManager graphyManager = m_graphyManager;
				graphyManager.m_background = value;
				graphyManager.UpdateAllParameters();
			};
			backgroundToggle2.onValueChanged.AddListener(call);
			Button backgroundColorButton2 = m_backgroundColorButton;
			UnityAction call2 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_backgroundColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_backgroundColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					GraphyManager graphyManager = m_graphyManager;
					graphyManager.m_backgroundColor = color2;
					graphyManager.m_backgroundColor.g = color2.g;
					graphyManager.m_backgroundColor.b = color2.b;
					graphyManager.m_backgroundColor.a = color2.a;
					graphyManager.UpdateAllParameters();
				};
				colorPicker2._onValueChange = onValueChange;
			};
			backgroundColorButton2.onClick.AddListener(call2);
			Dropdown graphyModeDropdown2 = m_graphyModeDropdown;
			UnityAction<int> call3 = delegate(int value)
			{
				Slider fpsGraphResolutionSlider3;
				float maxValue;
				if (value != 1)
				{
					if (value != 0)
					{
						goto IL_00a9;
					}
					fpsGraphResolutionSlider3 = m_fpsGraphResolutionSlider;
					maxValue = 300f;
				}
				else
				{
					fpsGraphResolutionSlider3 = m_fpsGraphResolutionSlider;
					maxValue = 128f;
				}
				fpsGraphResolutionSlider3.maxValue = maxValue;
				m_ramGraphResolutionSlider.maxValue = maxValue;
				m_audioGraphResolutionSlider.maxValue = maxValue;
				goto IL_00a9;
				IL_00a9:
				GraphyManager graphyManager = m_graphyManager;
				graphyManager.m_graphyMode = (GraphyManager.Mode)value;
				graphyManager.UpdateAllParameters();
			};
			graphyModeDropdown2.onValueChanged.AddListener(call3);
			Dropdown graphModulePositionDropdown2 = m_graphModulePositionDropdown;
			UnityAction<int> call4 = delegate(int value)
			{
				m_graphyManager.GraphModulePosition = (GraphyManager.ModulePosition)value;
			};
			graphModulePositionDropdown2.onValueChanged.AddListener(call4);
			Dropdown fpsModuleStateDropdown2 = m_fpsModuleStateDropdown;
			UnityAction<int> call5 = delegate(int value)
			{
				m_graphyManager.FpsModuleState = (GraphyManager.ModuleState)value;
			};
			fpsModuleStateDropdown2.onValueChanged.AddListener(call5);
			InputField goodInputField2 = m_goodInputField;
			UnityAction<string> call6 = delegate(string value)
			{
				object obj2 = default(object);
				object obj = obj2;
				ref int result = ref *(int*)((long)(IntPtr)obj2 - 4L);
				_ = 0;
				if (int.TryParse(value, out result))
				{
					GraphyManager graphyManager = m_graphyManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-4]");
					graphyManager.GoodFPSThreshold = 0;
				}
			};
			goodInputField2.onValueChange.AddListener(call6);
			InputField cautionInputField2 = m_cautionInputField;
			UnityAction<string> call7 = delegate(string value)
			{
				object obj2 = default(object);
				object obj = obj2;
				ref int result = ref *(int*)((long)(IntPtr)obj2 - 4L);
				_ = 0;
				if (int.TryParse(value, out result))
				{
					GraphyManager graphyManager = m_graphyManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-4]");
					graphyManager.CautionFPSThreshold = 0;
				}
			};
			cautionInputField2.onValueChange.AddListener(call7);
			Button goodColorButton2 = m_goodColorButton;
			UnityAction call8 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_goodColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_goodColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.GoodFPSColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			goodColorButton2.onClick.AddListener(call8);
			Button cautionColorButton2 = m_cautionColorButton;
			UnityAction call9 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_cautionColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_cautionColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.CautionFPSColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			cautionColorButton2.onClick.AddListener(call9);
			Button criticalColorButton2 = m_criticalColorButton;
			UnityAction call10 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_criticalColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_criticalColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.CriticalFPSColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			criticalColorButton2.onClick.AddListener(call10);
			Slider timeToResetMinMaxSlider2 = m_timeToResetMinMaxSlider;
			UnityAction<float> call11 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.TimeToResetMinMaxFps = (int)value;
			};
			timeToResetMinMaxSlider2.onValueChanged.AddListener(call11);
			Slider fpsGraphResolutionSlider2 = m_fpsGraphResolutionSlider;
			UnityAction<float> call12 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.FpsGraphResolution = (int)value;
			};
			fpsGraphResolutionSlider2.onValueChanged.AddListener(call12);
			Slider fpsTextUpdateRateSlider2 = m_fpsTextUpdateRateSlider;
			UnityAction<float> call13 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.FpsTextUpdateRate = (int)value;
			};
			fpsTextUpdateRateSlider2.onValueChanged.AddListener(call13);
			Dropdown ramModuleStateDropdown2 = m_ramModuleStateDropdown;
			UnityAction<int> call14 = delegate(int value)
			{
				m_graphyManager.RamModuleState = (GraphyManager.ModuleState)value;
			};
			ramModuleStateDropdown2.onValueChanged.AddListener(call14);
			Button reservedColorButton2 = m_reservedColorButton;
			UnityAction call15 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_reservedColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_reservedColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.ReservedRamColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			reservedColorButton2.onClick.AddListener(call15);
			Button allocatedColorButton2 = m_allocatedColorButton;
			UnityAction call16 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_allocatedColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_allocatedColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.AllocatedRamColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			allocatedColorButton2.onClick.AddListener(call16);
			Button monoColorButton2 = m_monoColorButton;
			UnityAction call17 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_monoColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_monoColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.MonoRamColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			monoColorButton2.onClick.AddListener(call17);
			Slider ramGraphResolutionSlider2 = m_ramGraphResolutionSlider;
			UnityAction<float> call18 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.RamGraphResolution = (int)value;
			};
			ramGraphResolutionSlider2.onValueChanged.AddListener(call18);
			Slider ramTextUpdateRateSlider2 = m_ramTextUpdateRateSlider;
			UnityAction<float> call19 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.RamTextUpdateRate = (int)value;
			};
			ramTextUpdateRateSlider2.onValueChanged.AddListener(call19);
			Dropdown audioModuleStateDropdown2 = m_audioModuleStateDropdown;
			UnityAction<int> call20 = delegate(int value)
			{
				m_graphyManager.AudioModuleState = (GraphyManager.ModuleState)value;
			};
			audioModuleStateDropdown2.onValueChanged.AddListener(call20);
			Button audioGraphColorButton2 = m_audioGraphColorButton;
			UnityAction call21 = delegate
			{
				//IL_0048: Expected F4, but got O
				//IL_0055: Expected F4, but got O
				//IL_0062: Expected F4, but got O
				//IL_006f: Expected F4, but got O
				G_CUIColorPicker colorPicker = m_colorPicker;
				colorPicker._onValueChange = null;
				Image component = m_audioGraphColorButton.GetComponent<Image>();
				Color color = component.color;
				Color inputColor = default(Color);
				object obj = default(object);
				inputColor.r = (float)obj;
				object obj2 = default(object);
				inputColor.g = (float)obj2;
				object obj3 = default(object);
				inputColor.b = (float)obj3;
				object obj4 = default(object);
				inputColor.a = (float)obj4;
				m_colorPicker.Setup(inputColor);
				G_CUIColorPicker colorPicker2 = m_colorPicker;
				Action<Color> onValueChange = delegate
				{
					Image component2 = m_audioGraphColorButton.GetComponent<Image>();
					Color color2 = default(Color);
					component2.color = color2;
					m_graphyManager.AudioGraphColor = color2;
				};
				colorPicker2._onValueChange = onValueChange;
			};
			audioGraphColorButton2.onClick.AddListener(call21);
			Dropdown findAudioListenerDropdown2 = m_findAudioListenerDropdown;
			UnityAction<int> call22 = delegate(int value)
			{
				m_graphyManager.FindAudioListenerInCameraIfNull = (GraphyManager.LookForAudioListener)value;
			};
			findAudioListenerDropdown2.onValueChanged.AddListener(call22);
			Dropdown fttWindowDropdown2 = m_fttWindowDropdown;
			UnityAction<int> call23 = delegate(int value)
			{
				m_graphyManager.FftWindow = (FFTWindow)value;
			};
			fttWindowDropdown2.onValueChanged.AddListener(call23);
			Slider spectrumSizeSlider2 = m_spectrumSizeSlider;
			UnityAction<float> call24 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.SpectrumSize = (int)value;
			};
			spectrumSizeSlider2.onValueChanged.AddListener(call24);
			Slider audioGraphResolutionSlider2 = m_audioGraphResolutionSlider;
			UnityAction<float> call25 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.AudioGraphResolution = (int)value;
			};
			audioGraphResolutionSlider2.onValueChanged.AddListener(call25);
			Slider audioTextUpdateRateSlider2 = m_audioTextUpdateRateSlider;
			UnityAction<float> call26 = delegate(float value)
			{
				//IL_000f: Expected I4, but got F4
				m_graphyManager.AudioTextUpdateRate = (int)value;
			};
			audioTextUpdateRateSlider2.onValueChanged.AddListener(call26);
			Dropdown advancedModulePositionDropdown2 = m_advancedModulePositionDropdown;
			UnityAction<int> call27 = delegate(int value)
			{
				m_graphyManager.AdvancedModulePosition = (GraphyManager.ModulePosition)value;
			};
			advancedModulePositionDropdown2.onValueChanged.AddListener(call27);
			Toggle advancedModuleToggle2 = m_advancedModuleToggle;
			UnityAction<bool> call28 = delegate(bool value)
			{
				GraphyManager.ModuleState advancedModuleState = ((!value) ? GraphyManager.ModuleState.OFF : default(GraphyManager.ModuleState));
				m_graphyManager.AdvancedModuleState = advancedModuleState;
			};
			advancedModuleToggle2.onValueChanged.AddListener(call28);
			Button musicButton2 = m_musicButton;
			UnityAction call29 = ToggleMusic;
			musicButton2.onClick.AddListener(call29);
			Button sfxButton2 = m_sfxButton;
			UnityAction call30 = PlayRandomSFX;
			sfxButton2.onClick.AddListener(call30);
			Slider musicVolumeSlider2 = m_musicVolumeSlider;
			UnityAction<float> call31 = delegate(float value)
			{
				float volume = value / 100f;
				m_musicAudioSource.volume = volume;
			};
			musicVolumeSlider2.onValueChanged.AddListener(call31);
			Slider sfxVolumeSlider2 = m_sfxVolumeSlider;
			UnityAction<float> call32 = delegate(float value)
			{
				float volume = value / 100f;
				m_sfxAudioSource.volume = volume;
			};
			sfxVolumeSlider2.onValueChanged.AddListener(call32);
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xB0F960", Offset = "0xB0F960", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.AudioSource::get_isPlaying(this.m_musicAudioSource);\n\tv40 = v13 == 0;\n\tif (v40) goto L_001F;\n\tUnityEngine.AudioSource::Pause(this.m_musicAudioSource);\n\treturn;\nL_001F:\n\tUnityEngine.AudioSource::Play(this.m_musicAudioSource);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ToggleMusic()
		{
			if (m_musicAudioSource.isPlaying)
			{
				m_musicAudioSource.Pause();
			}
			else
			{
				m_musicAudioSource.Play();
			}
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xB0F9C0", Offset = "0xB0F9C0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF2D68]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202250E]) = v42;\nL_0015:\n\tv43 = this.m_sfxAudioClips;\n\tv56 = v43._size < 1;\n\tif (v56) goto L_0056;\n\tv99 = UnityEngine.Random::Range(0, v43._size);\n\tv131 = v43._size < v99;\n\tv86 = ~v131;\n\tv83 = v43._size - v99;\n\tv77 = v83 == 0;\n\tv132 = ~v77;\n\tv62 = v86 & v132;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv162 = v43._items;\n\tUnityEngine.AudioSource::set_clip(this.m_sfxAudioSource, v162[v99 @ X0_v7 (System.Int32)]);\n\tUnityEngine.AudioSource::Play(this.m_sfxAudioSource);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PlayRandomSFX()
		{
			List<AudioClip> sfxAudioClips = m_sfxAudioClips;
			if (sfxAudioClips.Count >= 1)
			{
				int num = UnityEngine.Random.Range(0, sfxAudioClips.Count);
				bool flag = sfxAudioClips.Count < num;
				bool flag2 = !flag;
				int num2 = sfxAudioClips.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				AudioClip[] items = sfxAudioClips._items;
				m_sfxAudioSource.clip = items[num];
				m_sfxAudioSource.Play();
			}
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xB0FA84", Offset = "0xB0FA84", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEF5F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202250F]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.AudioClip>();\n\tSystem.Collections.Generic.List`1<UnityEngine.AudioClip>::.ctor(v42);\n\tthis.m_sfxAudioClips = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CustomizeGraphy()
		{
			List<AudioClip> sfxAudioClips = new List<AudioClip>();
			m_sfxAudioClips = sfxAudioClips;
		}
	}
}
