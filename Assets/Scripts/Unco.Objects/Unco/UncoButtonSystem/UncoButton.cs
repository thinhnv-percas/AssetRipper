using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Lofelt.NiceVibrations;
using Reflex.Attributes;
using Unco.Extensions;
using Unco.SettingsSyste.Core;
using Unco.SoundSystem.Scripts.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unco.UncoButtonSystem
{
	[RequireComponent(typeof(Button))]
	[Token(Token = "0x200000E")]
	public class UncoButton : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
	{
		[SerializeField]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x20")]
		internal Button Button;

		[Inject(false)]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x28")]
		private HapticManager HapticPlayer;

		[Inject(false)]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x30")]
		private SoundManager SoundManager;

		[SerializeField]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x38")]
		private Image TargetImage;

		[SerializeField]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x40")]
		private ButtonAnimationType animationEnum;

		[SerializeField]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x44")]
		private HapticPatterns.PresetType m_hapticType;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x48")]
		public ButtonAnimationConfig animationConfig;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x50")]
		public SoundManager.AudioType useSound;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x58")]
		private IButtonAnimation _animation;

		[Token(Token = "0x17000002")]
		public Image Image
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x81BFD6C", Offset = "0x81BFD6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Image;\n")]
			get
			{
				return TargetImage;
			}
		}

		[Token(Token = "0x17000003")]
		public bool Interactable
		{
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x81BF528", Offset = "0x81BF528", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.Button;\n\treturn v0.interactable;\n")]
			get
			{
				Button button = Button;
				return button.interactable;
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81BFD74", Offset = "0x81BFD74", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv57 = new Unco.UncoButtonSystem.ScalePunchAnimation();\n\tUnco.UncoButtonSystem.ScalePunchAnimation::.ctor(v57, this, this.animationConfig);\nL_FFFFFFFF:\n\tv67 = v57;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv67 = 0;\nL_001E:\n\tv52 = this.animationEnum != 1;\n\tif (v52) goto L_FFFFFFFF;\nL_002C:\n\tthis._animation = v67;\n\treturn;\n")]
		private void OnAnimationChanged()
		{
			ScalePunchAnimation animation;
			if (animationEnum == ButtonAnimationType.Scale)
			{
				ScalePunchAnimation scalePunchAnimation = new ScalePunchAnimation(this, animationConfig);
				animation = scalePunchAnimation;
			}
			else
			{
				animation = null;
			}
			_animation = animation;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81BFE84", Offset = "0x81BFE84", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tUnityEngine.UI.Selectable::set_transition(this.Button, 0);\n\tv72 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv75 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(v72);\n\tv88 = v75 == 0;\n\tif (v88) goto L_0047;\n\treturn;\nL_0047:\n\tv107 = System.Linq.Enumerable::First(v72);\n\tthis.Image = v107;\n\treturn;\nL_0021:\n\tv47 = UnityEngine.Component::GetComponent(this);\n\tthis.Button = v47;\n")]
		private void Reset()
		{
			Button component = GetComponent<Button>();
			Button = component;
			Button.transition = default(Selectable.Transition);
			Image[] componentsInChildren = GetComponentsInChildren<Image>();
			if (!componentsInChildren.IsNullOrEmpty())
			{
				object targetImage = ((IEnumerable<object>)componentsInChildren).First();
				TargetImage = (Image)targetImage;
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81BFF88", Offset = "0x81BFF88", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (Unco.UncoButtonSystem.IButtonAnimation)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\tSystem.IDisposable::Dispose(this._animation);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv93 = *([v119 @ X10_v4]) << 4;\n\tv131 = v43 + v93;\n\tv153 = v131 + 0x138;\n\t// 84 IndirectJump [v153 @ X0_v5], this._animation (Unco.UncoButtonSystem.IButtonAnimation), this._animation (Unco.UncoButtonSystem.IButtonAnimation), [v153 @ X0_v5+8], [v153 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._animation;\n\tv39 = this._animation == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == System.IDisposable;\n\tif (v111) goto L_0049;\n")]
		private void OnDisable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoButton::OnDisable");
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x81C0044", Offset = "0x81C0044", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this.Button, 0);\n\tv68 = ~v59;\n\tv69 = ~v68;\n\tif (v69) goto L_0039;\n\tgoto L_003E;\nL_0039:\n\tUnityEngine.UI.Selectable::set_transition(this.Button, 0);\nL_003E:\n\tv97 = new Unco.UncoButtonSystem.ScalePunchAnimation();\n\tUnco.UncoButtonSystem.ScalePunchAnimation::.ctor(v97, this, this.animationConfig);\n\tthis._animation = v97;\n\tgoto L_005E;\n\tv173 = new Unco.UncoButtonSystem.ScalePunchAnimation();\n\tUnco.UncoButtonSystem.ScalePunchAnimation::.ctor(v173, this, this.animationConfig);\nL_FFFFFFFF:\n\tv181 = v173;\n\tgoto L_0069;\nL_FFFFFFFF:\n\tv181 = 0;\nL_005E:\n\tv112 = this.animationEnum != 1;\n\tif (v112) goto L_FFFFFFFF;\nL_0069:\n\tthis._animation = v181;\n\treturn;\n")]
		private void Awake()
		{
			if (Button != null)
			{
				Button.transition = default(Selectable.Transition);
			}
			ScalePunchAnimation animation = new ScalePunchAnimation(this, animationConfig);
			_animation = animation;
			ScalePunchAnimation animation2;
			if (animationEnum == ButtonAnimationType.Scale)
			{
				ScalePunchAnimation scalePunchAnimation = new ScalePunchAnimation(this, animationConfig);
				animation2 = scalePunchAnimation;
			}
			else
			{
				animation2 = null;
			}
			_animation = animation2;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x81BFDFC", Offset = "0x81BFDFC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv57 = new Unco.UncoButtonSystem.ScalePunchAnimation();\n\tUnco.UncoButtonSystem.ScalePunchAnimation::.ctor(v57, this, this.animationConfig);\nL_FFFFFFFF:\n\tv67 = v57;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv67 = 0;\nL_001E:\n\tv52 = this.animationEnum != 1;\n\tif (v52) goto L_FFFFFFFF;\nL_002C:\n\tthis._animation = v67;\n\treturn;\n")]
		private void InitializeAnimation()
		{
			ScalePunchAnimation animation;
			if (animationEnum == ButtonAnimationType.Scale)
			{
				ScalePunchAnimation scalePunchAnimation = new ScalePunchAnimation(this, animationConfig);
				animation = scalePunchAnimation;
			}
			else
			{
				animation = null;
			}
			_animation = animation;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x81C01A0", Offset = "0x81C01A0", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv57.<>4__this = this;\n\tv57.clickAction = clickAction;\n\tv57.deactivateAfterClick = deactivateAfterClick;\n\tgoto L_0043;\nL_0043:\n\tv202 = UnityEngine.Object::op_Equality(this.Button, 0);\n\tv205 = v202 == 0;\n\tif (v205) goto L_0066;\n\treturn;\nL_0066:\n\tv79 = v57.deactivateAfterClick != 1;\n\tif (v79) goto L_006E;\n\tUnityEngine.UI.Selectable::set_interactable(this.Button, 1);\nL_006E:\n\tv219 = ~removeAllListener;\n\tif (v219) goto L_0078;\n\tv130 = this.Button;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v130.onClick);\nL_0078:\n\tv131 = this.Button;\n\tv119 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v119, v57, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v131.onClick, v119);\n\treturn;\nL_0027:\n\tv57 = new Unco.UncoButtonSystem.UncoButton+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v57);\n")]
		public void AddListener(Action clickAction, bool removeAllListener = true, bool deactivateAfterClick = true)
		{
			if (Button == null)
			{
				return;
			}
			if (deactivateAfterClick)
			{
				Button.interactable = true;
			}
			if (removeAllListener)
			{
				Button button = Button;
				button.onClick.RemoveAllListeners();
			}
			Button button2 = Button;
			UnityAction call = delegate
			{
				ButtonListenerAction(clickAction, deactivateAfterClick);
				UncoButton uncoButton = this;
				if (uncoButton.m_hapticType != HapticPatterns.PresetType.None)
				{
					uncoButton.HapticPlayer.PlayHapticType(uncoButton.m_hapticType);
				}
			};
			button2.onClick.AddListener(call);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81C0358", Offset = "0x81C0358", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Selectable::set_interactable(this.Button, isInteractable);\n\treturn;\n")]
		public void SetInteractable(bool isInteractable)
		{
			Button.interactable = isInteractable;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x81C039C", Offset = "0x81C039C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tUnityEngine.UI.Selectable::set_interactable(this.Button, 0);\nL_001E:\n\tv53 = clickAction == 0;\n\tif (v53) goto L_0025;\n\tSystem.Action::Invoke(clickAction);\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this.SoundManager, this.useSound, 0, 0);\nL_0034:\n\tgoto L_0038;\nL_0038:\n\tv125 = UnityEngine.Object::op_Inequality(this.HapticPlayer, 0);\n\tv127 = ~v125;\n\tif (v127) goto L_0057;\n\tUnco.SettingsSyste.Core.HapticManager::PlaySelection(this.HapticPlayer);\n\treturn;\nL_0057:\n\treturn;\nL_0016:\n\tv44 = ~v47;\n\tif (v44) goto L_001E;\nL_0025:\n\tv81 = this.useSound == 0;\n\tif (v81) goto L_0034;\n")]
		protected virtual void ButtonListenerAction(Action clickAction, bool deactivateAfterClick)
		{
			bool flag = default(bool);
			if (flag)
			{
				Button.interactable = false;
			}
			clickAction?.Invoke();
			if (useSound != SoundManager.AudioType.None)
			{
				SoundManager.PlaySound(useSound);
			}
			if (HapticPlayer != null)
			{
				HapticPlayer.PlaySelection();
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x81C0374", Offset = "0x81C0374", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Button;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v6.onClick);\n\treturn;\n")]
		public void RemoveAllListeners()
		{
			Button button = Button;
			button.onClick.RemoveAllListeners();
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x81C0498", Offset = "0x81C0498", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Button;\n\tUnityEngine.Events.UnityEvent::RemoveListener(v6.onClick, listener);\n\treturn;\n")]
		public void RemoveListener(UnityAction listener)
		{
			Button button = Button;
			button.onClick.RemoveListener(listener);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81C04C0", Offset = "0x81C04C0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationEnum = v39;\n\tgoto L_001F;\n\tv58 = new Unco.UncoButtonSystem.ScalePunchAnimation();\n\tUnco.UncoButtonSystem.ScalePunchAnimation::.ctor(v58, this, this.animationConfig);\nL_FFFFFFFF:\n\tv68 = v58;\n\tgoto L_002D;\nL_FFFFFFFF:\n\tv68 = 0;\nL_001F:\n\tv53 = v39 != 1;\n\tif (v53) goto L_FFFFFFFF;\nL_002D:\n\tthis._animation = v68;\n\treturn;\n")]
		public void SetAnimationType(ButtonAnimationType type)
		{
			ButtonAnimationType buttonAnimationType = default(ButtonAnimationType);
			animationEnum = buttonAnimationType;
			ScalePunchAnimation animation;
			if (buttonAnimationType == ButtonAnimationType.Scale)
			{
				ScalePunchAnimation scalePunchAnimation = new ScalePunchAnimation(this, animationConfig);
				animation = scalePunchAnimation;
			}
			else
			{
				animation = null;
			}
			_animation = animation;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81C054C", Offset = "0x81C054C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (Unco.UncoButtonSystem.IButtonAnimation)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\tUnco.UncoButtonSystem.IButtonAnimation::OnMouseUp(this._animation);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv122 = *([v119 @ X10_v4]) + 1;\n\tv93 = v122 << 4;\n\tv131 = v43 + v93;\n\tv154 = v131 + 0x138;\n\t// 85 IndirectJump [v154 @ X0_v5], this._animation (Unco.UncoButtonSystem.IButtonAnimation), this._animation (Unco.UncoButtonSystem.IButtonAnimation), [v154 @ X0_v5+8], [v154 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._animation;\n\tv39 = this._animation == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == Unco.UncoButtonSystem.IButtonAnimation;\n\tif (v111) goto L_0049;\n")]
		public void OnPointerUp(PointerEventData eventData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoButton::OnPointerUp");
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x81C060C", Offset = "0x81C060C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (Unco.UncoButtonSystem.IButtonAnimation)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<Unco.UncoButtonSystem.IButtonAnimation>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\tUnco.UncoButtonSystem.IButtonAnimation::OnMouseDown(this._animation);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv93 = *([v119 @ X10_v4]) << 4;\n\tv131 = v43 + v93;\n\tv153 = v131 + 0x138;\n\t// 84 IndirectJump [v153 @ X0_v5], this._animation (Unco.UncoButtonSystem.IButtonAnimation), this._animation (Unco.UncoButtonSystem.IButtonAnimation), [v153 @ X0_v5+8], [v153 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._animation;\n\tv39 = this._animation == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == Unco.UncoButtonSystem.IButtonAnimation;\n\tif (v111) goto L_0049;\n")]
		public void OnPointerDown(PointerEventData eventData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoButton::OnPointerDown");
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81C06C8", Offset = "0x81C06C8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationEnum = 1;\n\tthis.useSound = 0x4F;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UncoButton()
		{
			animationEnum = ButtonAnimationType.Scale;
			useSound = SoundManager.AudioType.Click;
		}
	}
}
