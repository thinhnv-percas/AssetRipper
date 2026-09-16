using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace EasyMobile.Internal.Privacy
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x731448", Offset = "0x731448")]
	[Token(Token = "0x20000DD")]
	public class EditorConsentDialogToggleSwitch : Selectable, IEventSystemHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement
	{
		[Serializable]
		[Token(Token = "0x20001BF")]
		public class ToggleEvent : UnityEvent<bool>
		{
			[Token(Token = "0x6000D0D")]
			[Address(RVA = "0xB4D7F8", Offset = "0xB4D7F8", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EAF4F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022744]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ToggleEvent()
			{
			}
		}

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x733A60", Offset = "0x733A60")]
		[SerializeField]
		[Token(Token = "0x40003E3")]
		[FieldOffset(Offset = "0xE8")]
		private Image switchObject;

		[SerializeField]
		[Token(Token = "0x40003E4")]
		[FieldOffset(Offset = "0xF0")]
		private Image background;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x733ABC", Offset = "0x733ABC")]
		[Token(Token = "0x40003E5")]
		[FieldOffset(Offset = "0xF8")]
		private bool m_IsOn;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733B08", Offset = "0x733B08")]
		[Token(Token = "0x40003E6")]
		[FieldOffset(Offset = "0xFC")]
		private Vector2 isOnPosition;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733B54", Offset = "0x733B54")]
		[Token(Token = "0x40003E7")]
		[FieldOffset(Offset = "0x104")]
		private Vector2 isOffPosition;

		[SerializeField]
		[Token(Token = "0x40003E8")]
		[FieldOffset(Offset = "0x10C")]
		private float animationDuration;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733BB0", Offset = "0x733BB0")]
		[Space]
		[Token(Token = "0x40003E9")]
		[FieldOffset(Offset = "0x110")]
		private bool toggleColor;

		[SerializeField]
		[Token(Token = "0x40003EA")]
		[FieldOffset(Offset = "0x114")]
		private Color switchOnColor;

		[SerializeField]
		[Token(Token = "0x40003EB")]
		[FieldOffset(Offset = "0x124")]
		private Color switchOffColor;

		[SerializeField]
		[Token(Token = "0x40003EC")]
		[FieldOffset(Offset = "0x134")]
		private Color backgroundOnColor;

		[SerializeField]
		[Token(Token = "0x40003ED")]
		[FieldOffset(Offset = "0x144")]
		private Color backgroundOffColor;

		[SerializeField]
		[Token(Token = "0x40003EE")]
		[FieldOffset(Offset = "0x158")]
		private ToggleEvent onValueChanged;

		[Token(Token = "0x40003EF")]
		[FieldOffset(Offset = "0x160")]
		private Coroutine switchCoroutine;

		[Token(Token = "0x40003F0")]
		[FieldOffset(Offset = "0x168")]
		private RectTransform switchTransform;

		[Token(Token = "0x1700022F")]
		public ToggleEvent OnValueChanged
		{
			[Token(Token = "0x60007D4")]
			[Address(RVA = "0xB4D094", Offset = "0xB4D094", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.onValueChanged;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OnValueChanged;
			}
		}

		[Token(Token = "0x17000230")]
		public bool isOn
		{
			[Token(Token = "0x60007D5")]
			[Address(RVA = "0xB4D09C", Offset = "0xB4D09C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_IsOn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isOn;
			}
			[Token(Token = "0x60007D6")]
			[Address(RVA = "0xB4D0A4", Offset = "0xB4D0A4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Set(this, value, 1);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Set(value, sendCallback: true);
			}
		}

		[Token(Token = "0x17000231")]
		public bool ShouldToggleColor
		{
			[Token(Token = "0x60007D7")]
			[Address(RVA = "0xB4D0BC", Offset = "0xB4D0BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.toggleColor;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShouldToggleColor;
			}
			[Token(Token = "0x60007D8")]
			[Address(RVA = "0xB4D0C4", Offset = "0xB4D0C4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.toggleColor = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				toggleColor = value;
			}
		}

		[Token(Token = "0x17000232")]
		public float AnimationDuration
		{
			[Token(Token = "0x60007D9")]
			[Address(RVA = "0xB4D0D0", Offset = "0xB4D0D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationDuration;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationDuration;
			}
			[Token(Token = "0x60007DA")]
			[Address(RVA = "0xB4D0D8", Offset = "0xB4D0D8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value < 0;\n\tif (v4) goto L_000B;\n\tthis.animationDuration = value;\nL_000B:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (!(value < 0f))
				{
					animationDuration = value;
				}
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60007EC")]
			[Address(RVA = "0xB4D848", Offset = "0xB4D848", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Component::get_transform(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return base.transform;
			}
		}

		[Token(Token = "0x60007DB")]
		[Address(RVA = "0xB4D0E8", Offset = "0xB4D0E8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F057F8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202273B]) = v38;\nL_0015:\n\tUnityEngine.UI.Selectable::Awake(this);\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v3+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv58 = UnityEngine.Object::op_Inequality(this.switchObject, 0);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0031;\n\tv67 = UnityEngine.UI.Graphic::get_rectTransform(this.switchObject);\nL_0031:\n\tthis.switchTransform = v67;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Awake()
		{
			base.Awake();
			bool flag = switchObject != null;
			bool flag2 = !flag;
			RectTransform rectTransform = null;
			if (!flag2)
			{
				rectTransform = switchObject.rectTransform;
			}
			switchTransform = rectTransform;
		}

		[Token(Token = "0x60007DC")]
		[Address(RVA = "0xB4D18C", Offset = "0xB4D18C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Selectable::OnDisable(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDisable()
		{
			base.OnDisable();
		}

		[Token(Token = "0x60007DD")]
		[Address(RVA = "0xB4D194", Offset = "0xB4D194", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Selectable::OnEnable(this);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::PlayEffect(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnEnable()
		{
			base.OnEnable();
			PlayEffect();
		}

		[Token(Token = "0x60007DE")]
		[Address(RVA = "0xB4D2D4", Offset = "0xB4D2D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::PlayEffect(this);\n\treturn;\n")]
		protected override void Start()
		{
			PlayEffect();
		}

		[Token(Token = "0x60007DF")]
		[Address(RVA = "0xB4D2D8", Offset = "0xB4D2D8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = eventData.<button>k__BackingField == 0;\n\tif (v3) goto L_0006;\n\treturn;\nL_0006:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Toggle(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Toggle();
			}
		}

		[Token(Token = "0x60007E0")]
		[Address(RVA = "0xB4D360", Offset = "0xB4D360", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Toggle(this);\n\treturn;\n")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
			Toggle();
		}

		[Token(Token = "0x60007E1")]
		[Address(RVA = "0xB4D364", Offset = "0xB4D364", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0F818]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, executing, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202273C]) = v41;\nL_0015:\n\tv42 = executing == 0;\n\tif (v42) goto L_002B;\n\treturn;\nL_002B:\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::Invoke(this.onValueChanged, this.m_IsOn);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
			if (executing == CanvasUpdate.Prelayout)
			{
				OnValueChanged.Invoke(isOn);
			}
		}

		[Token(Token = "0x60007E2")]
		[Address(RVA = "0xB4D2FC", Offset = "0xB4D2FC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv29 = v13 == 0;\n\tif (v29) goto L_002C;\n\tv34 = UnityEngine.UI.Selectable::IsInteractable(this);\n\tv36 = v34 == 0;\n\tif (v36) goto L_002C;\n\tv54 = this.m_IsOn == 0;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Set(this, v54, 1);\n\treturn;\nL_002C:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Toggle()
		{
			if (base.IsActive() && base.IsInteractable())
			{
				bool value = !isOn;
				Set(value, sendCallback: true);
			}
		}

		[Token(Token = "0x60007E3")]
		[Address(RVA = "0xB4D3E0", Offset = "0xB4D3E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void LayoutComplete()
		{
		}

		[Token(Token = "0x60007E4")]
		[Address(RVA = "0xB4D3E4", Offset = "0xB4D3E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60007E5")]
		[Address(RVA = "0xB4D1BC", Offset = "0xB4D1BC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EDF7A8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202273D]) = v42;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(this.switchTransform, 0);\n\tv62 = v60 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0063;\n\tv116 = this + 0x104;\n\tv66 = this + 0x108;\n\tv67 = this + 0xFC;\n\tv68 = this + 0x100;\n\tif (this.m_IsOn) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\tif (this.m_IsOn) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tv181 = UnityEngine.Application::get_isPlaying();\n\tv183 = v181 == 0;\n\tif (v183) goto L_0071;\n\tv125 = this.switchCoroutine == 0;\n\tif (v125) goto L_0055;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.switchCoroutine);\nL_0055:\n\t// 85 MakeStruct v84 @ AGGB4D284_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v116 @ X9_v3], [v127 @ X8_v9]\n\tv191 = EasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::SwitchCoroutine(this, v84, this.m_IsOn);\n\tv123 = UnityEngine.MonoBehaviour::StartCoroutine(this, v191);\n\tthis.switchCoroutine = v123;\nL_0063:\n\treturn;\nL_0071:\n\t// 113 MakeStruct v138 @ AGGB4D2CC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v116 @ X9_v3], [v127 @ X8_v9]\n\tUnityEngine.RectTransform::set_anchoredPosition(this.switchTransform, v138);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PlayEffect()
		{
			//IL_0049: Expected O, but got I
			//IL_0055: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_0138: Expected F4, but got O
			//IL_0145: Expected F4, but got O
			//IL_00e8: Expected F4, but got O
			//IL_00f5: Expected F4, but got O
			if (switchTransform == null)
			{
				return;
			}
			object obj = (long)(IntPtr)this + 260L;
			object obj2 = (long)(IntPtr)this + 264L;
			object obj3 = (long)(IntPtr)this + 252L;
			object obj4 = (long)(IntPtr)this + 256L;
			object obj5 = (isOn ? obj4 : obj2);
			if (isOn)
			{
				obj = obj3;
			}
			if (Application.isPlaying)
			{
				if (switchCoroutine != null)
				{
					StopCoroutine(switchCoroutine);
				}
				Vector2 targetPosition = default(Vector2);
				targetPosition.x = (float)obj;
				targetPosition.y = (float)obj5;
				IEnumerator routine = SwitchCoroutine(targetPosition, isOn);
				Coroutine coroutine = StartCoroutine(routine);
				switchCoroutine = coroutine;
			}
			else
			{
				Vector2 anchoredPosition = default(Vector2);
				anchoredPosition.x = (float)obj;
				anchoredPosition.y = (float)obj5;
				switchTransform.anchoredPosition = anchoredPosition;
			}
		}

		[Token(Token = "0x60007E6")]
		[Address(RVA = "0xB4D0B0", Offset = "0xB4D0B0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::Set(this, value, 1);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Set(bool value)
		{
			Set(value, sendCallback: true);
		}

		[Token(Token = "0x60007E7")]
		[Address(RVA = "0xB4D484", Offset = "0xB4D484", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F083B0]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, sendCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202273E]) = v44;\nL_001C:\n\tv50 = this.m_IsOn == 0;\n\tv55 = ~v50;\n\tv57 = v55 ^ value;\n\tv59 = v57 == 0;\n\tif (v59) goto L_0045;\n\tthis.m_IsOn = value;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch::PlayEffect(this);\n\tv64 = sendCallback == 0;\n\tif (v64) goto L_0045;\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::Invoke(this.onValueChanged, this.m_IsOn);\n\treturn;\nL_0045:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Set(bool value, bool sendCallback)
		{
			bool flag = !isOn;
			bool flag2 = !flag;
			if (flag2 ^ value)
			{
				m_IsOn = value;
				PlayEffect();
				if (sendCallback)
				{
					OnValueChanged.Invoke(isOn);
				}
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x738338", Offset = "0x738338")]
		[Token(Token = "0x60007E8")]
		[Address(RVA = "0xB4D3E8", Offset = "0xB4D3E8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EB1F08]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, isOn, methodInfo, v34, v35, v36, v37, v38, targetPosition, v0, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202273F]) = v47;\nL_001D:\n\tv51 = new EasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch+<SwitchCoroutine>d__39();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.<>4__this = this;\n\tv51.targetPosition = targetPosition;\n\tv51.targetPosition.y = targetPosition.y;\n\tv51.isOn = isOn;\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator SwitchCoroutine(Vector2 targetPosition, bool isOn)
		{
			_003CSwitchCoroutine_003Ed__39 _003CSwitchCoroutine_003Ed__40 = null;
			_003CSwitchCoroutine_003Ed__40._003C_003E1__state = 0;
			_003CSwitchCoroutine_003Ed__40._003C_003E4__this = this;
			_003CSwitchCoroutine_003Ed__40.targetPosition = targetPosition;
			_003CSwitchCoroutine_003Ed__40.targetPosition.y = targetPosition.y;
			_003CSwitchCoroutine_003Ed__40.isOn = isOn;
			return _003CSwitchCoroutine_003Ed__40;
		}

		[Token(Token = "0x60007E9")]
		[Address(RVA = "0xB4D554", Offset = "0xB4D554", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC9BF8]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, isOn, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022740]) = v43;\nL_0017:\n\tv45 = ~this.toggleColor;\n\tif (v45) goto L_006C;\n\tgoto L_0029;\n\tv89 = *([v49 @ X0_v3+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0029;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v49, isOn, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0029:\n\tv99 = UnityEngine.Object::op_Inequality(this.switchObject, 0);\n\tv150 = v99 == 0;\n\tif (v150) goto L_004C;\n\tv153 = isOn == 0;\n\tif (v153) goto L_0039;\n\tv191 = this + 0x114;\n\tv192 = this + 0x118;\n\tv159 = this + 0x11C;\n\tv158 = this + 0x120;\n\tv177 = this.switchObject == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_FFFFFFFF;\n\tgoto L_0082;\nL_0039:\n\tv191 = this + 0x124;\n\tv192 = this + 0x128;\n\tv159 = this + 0x12C;\n\tv158 = this + 0x130;\n\tv164 = UnityEngine.UI.Graphic::set_color(this.switchObject, Color_arg);\nL_004C:\n\tgoto L_0055;\n\tv184 = *([v169 @ X0_v8+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tgoto L_0055;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v169, v161, v98, v28, v29, v30, v31, v32, v60, v58, v56, v54, v37, v38, v39, v40);\nL_0055:\n\tv76 = UnityEngine.Object::op_Inequality(this.background, 0);\n\tv78 = v76 == 0;\n\tif (v78) goto L_006C;\n\tv132 = this.background;\n\tv206 = isOn == 0;\n\tif (v206) goto L_006D;\n\tv208 = this + 0x134;\n\tv142 = this + 0x138;\n\tv118 = this + 0x13C;\n\tv115 = this + 0x140;\n\tv207 = v132 == 0;\n\tv200 = ~v207;\n\tif (v200) goto L_0073;\n\tgoto L_0082;\nL_006C:\n\treturn;\nL_006D:\n\tv208 = this + 0x144;\n\tv142 = this + 0x148;\n\tv118 = this + 0x14C;\n\tv115 = this + 0x150;\nL_0073:\n\tv112 = this.backgroundOffColor;\n\tv121 = *([v132 @ X0_v12 (UnityEngine.UI.Image)]);\n\tv109 = *([v142 @ X8_v10]);\n\tv106 = *([v118 @ X10_v3]);\n\tv103 = *([v115 @ X11_v3]);\n\tv124 = *([v121 @ X9_v4 (Il2CppClass<UnityEngine.UI.Image>)+2A0]);\n\tv127 = *([v121 @ X9_v4 (Il2CppClass<UnityEngine.UI.Image>)+2A8]);\n\t// 129 IndirectJump v124 @ X2_v4, v132 @ X0_v12 (UnityEngine.UI.Image), v132 @ X0_v12 (UnityEngine.UI.Image), v127 @ X1_v5, v124 @ X2_v4, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v112 @ V0_v3, v109 @ V1_v3, v106 @ V2_v3, v103 @ V3_v3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0082:\n\tthrow System.NullReferenceException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateColor(bool isOn)
		{
			//IL_00bf: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_00e3: Expected O, but got I
			//IL_00f5: Expected F4, but got O
			//IL_0102: Expected F4, but got O
			//IL_010f: Expected F4, but got O
			//IL_011c: Expected F4, but got O
			//IL_0060: Expected O, but got I
			//IL_006c: Expected O, but got I
			//IL_0078: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_01fa: Expected O, but got I
			//IL_0206: Expected O, but got I
			//IL_0212: Expected O, but got I
			//IL_0227: Expected I, but got O
			//IL_024f: Expected O, but got I
			//IL_025f: Expected O, but got I
			//IL_0190: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_01a8: Expected O, but got I
			//IL_01b4: Expected O, but got I
			if (!ShouldToggleColor)
			{
				return;
			}
			if (switchObject != null)
			{
				object obj;
				object obj2;
				object obj3;
				object obj4;
				if (isOn)
				{
					obj = (long)(IntPtr)this + 276L;
					obj2 = (long)(IntPtr)this + 280L;
					obj3 = (long)(IntPtr)this + 284L;
					obj4 = (long)(IntPtr)this + 288L;
					if ((object)switchObject == null)
					{
						goto IL_0269;
					}
				}
				else
				{
					obj = (long)(IntPtr)this + 292L;
					obj2 = (long)(IntPtr)this + 296L;
					obj3 = (long)(IntPtr)this + 300L;
					obj4 = (long)(IntPtr)this + 304L;
				}
				Color color = default(Color);
				color.r = (float)obj;
				color.g = (float)obj2;
				color.b = (float)obj3;
				color.a = (float)obj4;
				switchObject.color = color;
			}
			if (!(background != null))
			{
				return;
			}
			Image image = background;
			object obj5;
			object obj6;
			object obj7;
			object obj8;
			if (isOn)
			{
				obj5 = (long)(IntPtr)this + 308L;
				obj6 = (long)(IntPtr)this + 312L;
				obj7 = (long)(IntPtr)this + 316L;
				obj8 = (long)(IntPtr)this + 320L;
				if ((object)image == null)
				{
					goto IL_0269;
				}
			}
			else
			{
				obj5 = (long)(IntPtr)this + 324L;
				obj6 = (long)(IntPtr)this + 328L;
				obj7 = (long)(IntPtr)this + 332L;
				obj8 = (long)(IntPtr)this + 336L;
			}
			object obj9 = obj5;
			IntPtr intPtr = (IntPtr)image;
			object obj10 = obj6;
			object obj11 = obj7;
			object obj12 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X9_v4 (Il2CppClass<UnityEngine.UI.Image>)+2A0]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X9_v4 (Il2CppClass<UnityEngine.UI.Image>)+2A8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X2_v4 (should have been resolved before IL gen)");
			goto IL_0269;
			IL_0269:
			throw new NullReferenceException();
		}

		[Token(Token = "0x60007EA")]
		[Address(RVA = "0xB4D6C8", Offset = "0xB4D6C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.EventSystems.UIBehaviour::IsDestroyed(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool ICanvasElement.IsDestroyed()
		{
			return IsDestroyed();
		}

		[Token(Token = "0x60007EB")]
		[Address(RVA = "0xB4D6D0", Offset = "0xB4D6D0", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF0A58]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022741]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Vector2::get_zero();\n\tthis.isOnPosition = v53;\n\tthis.isOnPosition.y = v53.y;\n\tv56 = UnityEngine.Vector2::get_zero();\n\tthis.isOffPosition.x = v56;\n\tthis.isOffPosition.y = v56.y;\n\tthis.animationDuration = 3f;\n\tv60 = UnityEngine.Color::get_white();\n\tthis.switchOnColor.r = v60;\n\tthis.switchOnColor.g = v60.g;\n\tthis.switchOnColor.b = v60.b;\n\tthis.switchOnColor.a = v60.a;\n\tv65 = UnityEngine.Color::get_white();\n\tthis.switchOffColor.r = v65;\n\tthis.switchOffColor.g = v65.g;\n\tthis.switchOffColor.b = v65.b;\n\tthis.switchOffColor.a = v65.a;\n\tv70 = UnityEngine.Color::get_white();\n\tthis.backgroundOnColor.r = v70;\n\tthis.backgroundOnColor.g = v70.g;\n\tthis.backgroundOnColor.b = v70.b;\n\tthis.backgroundOnColor.a = v70.a;\n\tv75 = UnityEngine.Color::get_white();\n\tthis.backgroundOffColor.r = v75;\n\tthis.backgroundOffColor.g = v75.g;\n\tthis.backgroundOffColor.b = v75.b;\n\tthis.backgroundOffColor.a = v75.a;\n\tv82 = new EasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch+ToggleEvent();\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleSwitch+ToggleEvent::.ctor(v82);\n\tthis.onValueChanged = v82;\n\tgoto L_0069;\n\tv90 = *([v86 @ X0_v12+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0069;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v22, v23, v24, v25, v26, v27, v75, v76, v77, v78, v32, v33, v34, v35);\nL_0069:\n\tUnityEngine.UI.Selectable::.ctor(this);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogToggleSwitch()
		{
			Vector2 vector = (isOnPosition = Vector2.zero);
			isOnPosition.y = vector.y;
			Vector2 zero = Vector2.zero;
			isOffPosition.x = zero.x;
			isOffPosition.y = zero.y;
			animationDuration = 3f;
			Color white = Color.white;
			switchOnColor.r = white.r;
			switchOnColor.g = white.g;
			switchOnColor.b = white.b;
			switchOnColor.a = white.a;
			Color white2 = Color.white;
			switchOffColor.r = white2.r;
			switchOffColor.g = white2.g;
			switchOffColor.b = white2.b;
			switchOffColor.a = white2.a;
			Color white3 = Color.white;
			backgroundOnColor.r = white3.r;
			backgroundOnColor.g = white3.g;
			backgroundOnColor.b = white3.b;
			backgroundOnColor.a = white3.a;
			Color white4 = Color.white;
			backgroundOffColor.r = white4.r;
			backgroundOffColor.g = white4.g;
			backgroundOffColor.b = white4.b;
			backgroundOffColor.a = white4.a;
			onValueChanged = new ToggleEvent();
			base._002Ector();
		}
	}
}
