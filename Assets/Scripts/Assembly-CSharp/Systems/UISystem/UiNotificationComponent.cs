using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.GameConditions.Implementations;
using Unco.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.UISystem
{
	[Token(Token = "0x2000028")]
	public class UiNotificationComponent : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_notificationRoot;

		[SerializeField]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x28")]
		private Image m_notificationIcon;

		[SerializeField]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x30")]
		private UncoTMP m_notificationText;

		[SerializeReference]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x38")]
		private ReactiveCondition m_condition;

		[Header("Animation Settings")]
		[SerializeField]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x40")]
		private float m_scaleUpTime;

		[SerializeField]
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x44")]
		private float m_scaleDownTime;

		[SerializeField]
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x48")]
		private Vector3 m_scaleUp;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x58")]
		private Sequence _sequence;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x68")]
		private float _startPositionY;

		[Token(Token = "0x17000022")]
		public bool IsActive
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0x3C66BD8", Offset = "0x3C66BD8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.GameObject::get_activeSelf(this.m_notificationRoot);\n\treturn returnVal1;\n")]
			get
			{
				return m_notificationRoot.activeSelf;
			}
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x3C66BF4", Offset = "0x3C66BF4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_transform(this.m_notificationIcon);\n\tv37 = UnityEngine.Transform::get_localPosition(v15);\n\tthis._startPositionY = v37.y;\n\treturn;\n")]
		private void Awake()
		{
			Transform transform = m_notificationIcon.transform;
			_startPositionY = transform.localPosition.y;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x3C66C34", Offset = "0x3C66C34", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = Unco.GameConditions.Implementations.ReactiveCondition::IsConditionMet(this.m_condition);\n\tSystems.UISystem.UiNotificationComponent::SetNotificationIcon(this, v52);\n\tv65 = new System.Action();\n\tSystem.Action::.ctor(v65, this, Il2CppMethodInfo);\n\tv85 = this.m_condition == 0;\n\tif (v85) goto L_0044;\n\tUnco.GameConditions.Implementations.ReactiveCondition::add_OnConditionChanged(this.m_condition, v65);\n\treturn;\nL_0042:\n\tSystems.UISystem.UiNotificationComponent::SetNotificationIcon(this, 0);\n\treturn;\nL_0044:\n\tthrow v65;\nL_0018:\n\tv44 = this.m_condition == 0;\n\tif (v44) goto L_0042;\n")]
		private void OnEnable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiNotificationComponent::OnEnable");
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x3C66DB0", Offset = "0x3C66DB0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = new System.Action();\n\tSystem.Action::.ctor(v52, this, Il2CppMethodInfo);\n\tUnco.GameConditions.Implementations.ReactiveCondition::remove_OnConditionChanged(this.m_condition, v52);\n\tUnco.GameConditions.Implementations.ReactiveCondition::Dispose(this.m_condition);\n\tPrimeTween.Sequence::Stop(&this._sequence (PrimeTween.Sequence));\n\treturn;\nL_0040:\n\treturn;\nL_0018:\n\tv44 = this.m_condition == 0;\n\tif (v44) goto L_0040;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (m_condition != null)
			{
				Action value = OnConditionChanged;
				m_condition.remove_OnConditionChanged(value);
				m_condition.Dispose();
				_sequence.Stop();
			}
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x3C66E70", Offset = "0x3C66E70", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Unco.GameConditions.Implementations.ReactiveCondition::IsConditionMet(this.m_condition);\n\tSystems.UISystem.UiNotificationComponent::SetNotificationIcon(this, v15);\n\treturn;\n")]
		private void OnConditionChanged()
		{
			bool notificationIcon = m_condition.IsConditionMet();
			SetNotificationIcon(notificationIcon);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x3C66EA8", Offset = "0x3C66EA8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = a;\n\tUnityEngine.GameObject::SetActive(this.m_notificationRoot, isActive);\n\tv45 = this.m_notificationText == 0;\n\tif (v45) goto L_001B;\n\tv48 = System.Int32::ToString(&v12 @ stack_-24_v1 (System.Int32));\n\tUnco.Objects.UncoTMP::SetText(this.m_notificationText, v48);\nL_001B:\n\tv30 = UnityEngine.Component::get_gameObject(this.m_notificationIcon);\n\tUnityEngine.GameObject::SetActive(v30, 0);\n\treturn;\n")]
		public void SetNotificationAmount(bool isActive, int a)
		{
			int num = a;
			m_notificationRoot.SetActive(isActive);
			if ((object)m_notificationText != null)
			{
				string text = num.ToString();
				m_notificationText.SetText(text);
			}
			GameObject gameObject = m_notificationIcon.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x3C66CFC", Offset = "0x3C66CFC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.GameObject::SetActive(this.m_notificationRoot, isActive);\n\tv62 = this.m_notificationText == 0;\n\tif (v62) goto L_0027;\n\tUnco.Objects.UncoTMP::SetText(this.m_notificationText, \"\");\nL_0027:\n\tv54 = UnityEngine.Component::get_gameObject(this.m_notificationIcon);\n\tUnityEngine.GameObject::SetActive(v54, 1);\n\tv80 = ~isActive;\n\tif (v80) goto L_0040;\n\tSystems.UISystem.UiNotificationComponent::PlayAnimation(this);\n\treturn;\nL_0040:\n\treturn;\n")]
		public void SetNotificationIcon(bool isActive)
		{
			m_notificationRoot.SetActive(isActive);
			if ((object)m_notificationText != null)
			{
				m_notificationText.SetText("");
			}
			GameObject gameObject = m_notificationIcon.gameObject;
			gameObject.SetActive(value: true);
			if (isActive)
			{
				PlayAnimation();
			}
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x3C66F28", Offset = "0x3C66F28", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Sequence::Stop(&this._sequence (PrimeTween.Sequence));\n\tv20 = PrimeTween.Sequence::Create(-1, 0, 1, 0, 0);\n\tv21 = v20;\n\tv26 = UnityEngine.UI.Graphic::get_rectTransform(this.m_notificationIcon);\n\tv38 = this._startPositionY + this.m_scaleUp;\n\tv69 = PrimeTween.Tween::LocalPositionY(v26, v38, this.m_scaleUpTime, 0x1B, 1, 0, 0f, 0f, 1);\n\tv73 = PrimeTween.Sequence::Chain(&v21 @ stack_-30_v1 (PrimeTween.Sequence), v69);\n\tv21 = v73;\n\tv106 = UnityEngine.UI.Graphic::get_rectTransform(this.m_notificationIcon);\n\tv110 = PrimeTween.Tween::LocalPositionY(v106, this._startPositionY, this.m_scaleDownTime, 0x1A, 1, 0, 0f, 0f, 1);\n\tv115 = PrimeTween.Sequence::Chain(&v21 @ stack_-30_v1 (PrimeTween.Sequence), v110);\n\tthis._sequence.root.tween = v110;\n\tthis._sequence.root.id = v115;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PlayAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiNotificationComponent::PlayAnimation");
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x3C67044", Offset = "0x3C67044", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UiNotificationComponent()
		{
		}
	}
}
