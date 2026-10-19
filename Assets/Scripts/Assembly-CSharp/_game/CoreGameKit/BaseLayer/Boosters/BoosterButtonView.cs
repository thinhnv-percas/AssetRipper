using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using PrimeTween;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.CoreGameKit.BaseLayer.Boosters
{
	[Token(Token = "0x20006E8")]
	public class BoosterButtonView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001727")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[SerializeField]
		[Token(Token = "0x4001728")]
		[FieldOffset(Offset = "0x28")]
		private ComponentStateHandler m_stateHandler;

		[SerializeField]
		[Token(Token = "0x4001729")]
		[FieldOffset(Offset = "0x30")]
		private ImageView m_boosterIcon;

		[SerializeField]
		[Token(Token = "0x400172A")]
		[FieldOffset(Offset = "0x38")]
		private TextView m_countText;

		[SerializeField]
		[Token(Token = "0x400172B")]
		[FieldOffset(Offset = "0x40")]
		private TextView m_lockText;

		[SerializeField]
		[Token(Token = "0x400172C")]
		[FieldOffset(Offset = "0x48")]
		private Image[] m_conveyorWarningArrows;

		[Token(Token = "0x400172D")]
		[FieldOffset(Offset = "0x50")]
		private string _boosterId;

		[Token(Token = "0x400172E")]
		[FieldOffset(Offset = "0x58")]
		private BoosterButtonState _currentState;

		[Token(Token = "0x400172F")]
		[FieldOffset(Offset = "0x5C")]
		private bool _warningRequested;

		[Token(Token = "0x4001730")]
		[FieldOffset(Offset = "0x5D")]
		private bool _arrowsAnimating;

		[Token(Token = "0x4001731")]
		[FieldOffset(Offset = "0x60")]
		private Tween[] _scaleTweens;

		[Token(Token = "0x4001732")]
		[FieldOffset(Offset = "0x68")]
		private Tween[] _bounceTweens;

		[Token(Token = "0x4001733")]
		[FieldOffset(Offset = "0x70")]
		private float[] _arrowBaseY;

		[CompilerGenerated]
		[Token(Token = "0x4001734")]
		[FieldOffset(Offset = "0x78")]
		private Action<string> OnClicked;

		[Token(Token = "0x4001735")]
		private const string StateKeyHidden = "hidden";

		[Token(Token = "0x4001736")]
		private const string StateKeyLocked = "locked";

		[Token(Token = "0x4001737")]
		private const string StateKeyActive = "active";

		[Token(Token = "0x4001738")]
		private const string StateKeyNoStock = "no_stock";

		[Token(Token = "0x170002DE")]
		public BoosterButtonState CurrentState
		{
			[Token(Token = "0x6001D2B")]
			[Address(RVA = "0x3D7526C", Offset = "0x3D7526C", Length = "0x8")]
			get
			{
				return _currentState;
			}
		}

		[Token(Token = "0x170002DF")]
		public RectTransform RectTransform
		{
			[Token(Token = "0x6001D2C")]
			[Address(RVA = "0x3D75274", Offset = "0x3D75274", Length = "0x6C")]
			get
			{
				RectTransform rectTransform = (RectTransform)base.transform;
				if ((object)rectTransform == null || (object)rectTransform.GetType() == typeof(RectTransform))
				{
					return rectTransform;
				}
				return (RectTransform)(object)new InvalidCastException();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6001D27")]
		[Address(RVA = "0x3D7445C", Offset = "0x3D7445C", Length = "0xB4")]
		public void add_OnClicked(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterButtonView::add_OnClicked");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001D28")]
		[Address(RVA = "0x3D75164", Offset = "0x3D75164", Length = "0xB4")]
		public void remove_OnClicked(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterButtonView::remove_OnClicked");
		}

		[Token(Token = "0x6001D29")]
		[Address(RVA = "0x3D74258", Offset = "0x3D74258", Length = "0x204")]
		public void Init(BoosterDefinition definition, BoosterButtonState state, int count, int unlockLevel = -1)
		{
			//IL_007f: Expected I4, but got I8
			_boosterId = definition.Id;
			UnityEngine.Object lockText;
			if (!(definition.Icon != null))
			{
				lockText = m_lockText;
			}
			else
			{
				m_boosterIcon.SetImage(definition.Icon);
				lockText = m_lockText;
			}
			bool flag = lockText != null;
			if ((int)(unlockLevel & 0x80000000L) == 0 && flag)
			{
				int num = unlockLevel + 1;
				int num2 = num;
				int num3 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string text = $"Lv. {arg}";
				m_lockText.SetText(text);
			}
			Action clickAction = delegate
			{
				if (OnClicked != null)
				{
					OnClicked(_boosterId);
				}
			};
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
			UpdateState(state, count);
		}

		[Token(Token = "0x6001D2A")]
		[Address(RVA = "0x3D74D28", Offset = "0x3D74D28", Length = "0x22C")]
		public void UpdateState(BoosterButtonState state, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterButtonView::UpdateState");
		}

		[Token(Token = "0x6001D2D")]
		[Address(RVA = "0x3D752E0", Offset = "0x3D752E0", Length = "0x48")]
		public void ShowConveyorWarning()
		{
			_warningRequested = true;
			Image[] conveyorWarningArrows = m_conveyorWarningArrows;
			if (m_conveyorWarningArrows == null || conveyorWarningArrows.Length == 0)
			{
				return;
			}
			if ((uint)CurrentState >= 2u)
			{
				if (!_arrowsAnimating)
				{
					_arrowsAnimating = true;
					StartArrowAnimations();
				}
			}
			else if (_arrowsAnimating)
			{
				_arrowsAnimating = false;
				StopArrowAnimations();
			}
		}

		[Token(Token = "0x6001D2E")]
		[Address(RVA = "0x3D75328", Offset = "0x3D75328", Length = "0x2C")]
		public void HideConveyorWarning()
		{
			_warningRequested = false;
			Image[] conveyorWarningArrows = m_conveyorWarningArrows;
			if (m_conveyorWarningArrows != null && conveyorWarningArrows.Length != 0 && _arrowsAnimating)
			{
				_arrowsAnimating = false;
				StopArrowAnimations();
			}
		}

		[Token(Token = "0x6001D2F")]
		[Address(RVA = "0x3D75354", Offset = "0x3D75354", Length = "0x24")]
		private bool ShouldShowArrows()
		{
			if (_warningRequested)
			{
				bool flag = (uint)CurrentState < 1u;
				bool flag2 = !flag;
				int num = (int)(CurrentState - 1);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				return flag2 && flag4;
			}
			return false;
		}

		[Token(Token = "0x6001D30")]
		[Address(RVA = "0x3D75218", Offset = "0x3D75218", Length = "0x54")]
		private void RefreshWarningArrows()
		{
			Image[] conveyorWarningArrows = m_conveyorWarningArrows;
			if (m_conveyorWarningArrows == null || conveyorWarningArrows.Length == 0)
			{
				return;
			}
			if (_warningRequested && (uint)CurrentState >= 2u)
			{
				if (!_arrowsAnimating)
				{
					_arrowsAnimating = true;
					StartArrowAnimations();
				}
			}
			else if (_arrowsAnimating)
			{
				_arrowsAnimating = false;
				StopArrowAnimations();
			}
		}

		[Token(Token = "0x6001D31")]
		[Address(RVA = "0x3D75378", Offset = "0x3D75378", Length = "0x364")]
		private void StartArrowAnimations()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterButtonView::StartArrowAnimations");
		}

		[Token(Token = "0x6001D32")]
		[Address(RVA = "0x3D756DC", Offset = "0x3D756DC", Length = "0x210")]
		private unsafe void StopArrowAnimations()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterButtonView::StopArrowAnimations");
		}

		[Token(Token = "0x6001D33")]
		[Address(RVA = "0x3D758EC", Offset = "0x3D758EC", Length = "0x8")]
		public BoosterButtonView()
		{
		}
	}
}
