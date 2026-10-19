using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.SettingsSystem.Core;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;

namespace _game.Scripts.Ui
{
	[Token(Token = "0x2000704")]
	public class NotificationSettingsButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001781")]
		[FieldOffset(Offset = "0x20")]
		private ComponentStateHandler m_stateHandler;

		[SerializeField]
		[Token(Token = "0x4001782")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_button;

		[Header("Slide Settings")]
		[SerializeField]
		[Token(Token = "0x4001783")]
		[FieldOffset(Offset = "0x30")]
		private RectTransform m_slidingIcon;

		[SerializeField]
		[Token(Token = "0x4001784")]
		[FieldOffset(Offset = "0x38")]
		private float m_activeMargin;

		[SerializeField]
		[Token(Token = "0x4001785")]
		[FieldOffset(Offset = "0x3C")]
		private float m_inactiveMargin;

		[SerializeField]
		[Token(Token = "0x4001786")]
		[FieldOffset(Offset = "0x40")]
		private float m_slideDuration;

		[SerializeField]
		[Token(Token = "0x4001787")]
		[FieldOffset(Offset = "0x44")]
		private Ease m_slideEase;

		[Inject(false)]
		[Token(Token = "0x4001788")]
		[FieldOffset(Offset = "0x48")]
		private SettingsManager m_settingsManager;

		[Token(Token = "0x4001789")]
		[FieldOffset(Offset = "0x50")]
		private Tween m_slideTween;

		[Inject(false)]
		[Token(Token = "0x6001D95")]
		[Address(RVA = "0x3D7AE7C", Offset = "0x3D7AE7C", Length = "0x178")]
		public void Inject()
		{
			InitVisual(animate: false);
			Action clickAction = delegate
			{
				bool flag = m_settingsManager.IsEnabled(SettingsFlags.Notification);
				SettingsManager settingsManager2 = m_settingsManager;
				int notification;
				if (flag)
				{
					notification = 0;
				}
				else
				{
					bool isNotificationPermissionGranted = m_settingsManager.IsNotificationPermissionGranted;
					settingsManager2 = m_settingsManager;
					if (!isNotificationPermissionGranted)
					{
						m_settingsManager.OpenNotificationSettings();
						return;
					}
					notification = 1;
				}
				settingsManager2.SetNotification(notification);
				InitVisual(animate: true);
			};
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
			SettingsManager settingsManager = m_settingsManager;
			Action<bool> b = OnPermissionChanged;
			Delegate obj = Delegate.Combine(settingsManager.OnNotificationPermissionChanged, b);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				Action<bool> action = default(Action<bool>);
				if (action != null)
				{
					settingsManager.OnNotificationPermissionChanged = action;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 != null)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			settingsManager.OnNotificationPermissionChanged = null;
		}

		[Token(Token = "0x6001D96")]
		[Address(RVA = "0x3D7B1AC", Offset = "0x3D7B1AC", Length = "0x14")]
		private void OnEnable()
		{
			if (m_settingsManager != null)
			{
				InitVisual(animate: false);
			}
		}

		[Token(Token = "0x6001D97")]
		[Address(RVA = "0x3D7B1C0", Offset = "0x3D7B1C0", Length = "0x8")]
		private void OnPermissionChanged(bool granted)
		{
			InitVisual(animate: true);
		}

		[Token(Token = "0x6001D98")]
		[Address(RVA = "0x3D7B1C8", Offset = "0x3D7B1C8", Length = "0x18")]
		private void OnApplicationFocus(bool hasFocus)
		{
			if (hasFocus && m_settingsManager != null)
			{
				m_settingsManager.RefreshNotificationPermission();
			}
		}

		[Token(Token = "0x6001D99")]
		[Address(RVA = "0x3D7B1E0", Offset = "0x3D7B1E0", Length = "0x118")]
		private void OnDestroy()
		{
			SettingsManager settingsManager = m_settingsManager;
			if (m_settingsManager == null)
			{
				return;
			}
			Action<bool> value = OnPermissionChanged;
			Delegate obj = Delegate.Remove(settingsManager.OnNotificationPermissionChanged, value);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				Action<bool> action = default(Action<bool>);
				if (action != null)
				{
					settingsManager.OnNotificationPermissionChanged = action;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 != null)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			settingsManager.OnNotificationPermissionChanged = null;
		}

		[Token(Token = "0x6001D9A")]
		[Address(RVA = "0x3D7B2F8", Offset = "0x3D7B2F8", Length = "0x144")]
		private float GetTargetX(bool active)
		{
			Transform parent = m_slidingIcon.parent;
			UnityEngine.Object obj;
			if ((object)parent != null)
			{
				Transform transform = (((object)parent.GetType() != typeof(RectTransform)) ? null : parent);
				obj = transform;
			}
			else
			{
				obj = null;
			}
			if (obj == null)
			{
				return 0f;
			}
			Rect rect = ((RectTransform)obj).rect;
			Rect rect2 = m_slidingIcon.rect;
			float num = rect.width * 0.5f;
			float num2 = rect2.width * 0.5f;
			float num3 = num - num2;
			float num4 = num3 - m_activeMargin;
			float num5 = num3 - m_inactiveMargin;
			float result = 0f - num5;
			if (active)
			{
				result = num4;
			}
			return result;
		}

		[Token(Token = "0x6001D9B")]
		[Address(RVA = "0x3D7AFF4", Offset = "0x3D7AFF4", Length = "0x1B8")]
		private void InitVisual(bool animate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationSettingsButton::InitVisual");
		}

		[Token(Token = "0x6001D9C")]
		[Address(RVA = "0x3D7B43C", Offset = "0x3D7B43C", Length = "0xE8")]
		private void EditorGoActivePosition()
		{
			if (!(m_slidingIcon == null))
			{
				Vector2 anchoredPosition = m_slidingIcon.anchoredPosition;
				float targetX = GetTargetX(active: true);
				Vector2 anchoredPosition2 = default(Vector2);
				anchoredPosition2.x = targetX;
				anchoredPosition2.y = anchoredPosition.y;
				m_slidingIcon.anchoredPosition = anchoredPosition2;
			}
		}

		[Token(Token = "0x6001D9D")]
		[Address(RVA = "0x3D7B524", Offset = "0x3D7B524", Length = "0xE8")]
		private void EditorGoInactivePosition()
		{
			if (!(m_slidingIcon == null))
			{
				Vector2 anchoredPosition = m_slidingIcon.anchoredPosition;
				float targetX = GetTargetX(active: false);
				Vector2 anchoredPosition2 = default(Vector2);
				anchoredPosition2.x = targetX;
				anchoredPosition2.y = anchoredPosition.y;
				m_slidingIcon.anchoredPosition = anchoredPosition2;
			}
		}

		[Token(Token = "0x6001D9E")]
		[Address(RVA = "0x3D7B60C", Offset = "0x3D7B60C", Length = "0x14")]
		public NotificationSettingsButton()
		{
			m_slideDuration = 0.25f;
		}
	}
}
