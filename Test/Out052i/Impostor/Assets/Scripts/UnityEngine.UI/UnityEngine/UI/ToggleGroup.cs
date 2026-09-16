using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Toggle Group", 31)]
	[Token(Token = "0x2000078")]
	public class ToggleGroup : UIBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x20")]
		private bool m_AllowSwitchOff;

		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x28")]
		protected List<Toggle> m_Toggles;

		[Token(Token = "0x17000150")]
		public bool allowSwitchOff
		{
			[Token(Token = "0x60004EA")]
			[Address(RVA = "0x183B004", Offset = "0x183B004", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004EB")]
			[Address(RVA = "0x183B00C", Offset = "0x183B00C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0x183B018", Offset = "0x183B018", Length = "0x7C")]
		protected ToggleGroup()
		{
		}

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0x183B094", Offset = "0x183B094", Length = "0x1C")]
		protected override void Start()
		{
		}

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0x183B0B0", Offset = "0x183B0B0", Length = "0x1C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60004EF")]
		[Address(RVA = "0x183B0CC", Offset = "0x183B0CC", Length = "0x150")]
		private void ValidateToggleIsInGroup(Toggle toggle)
		{
		}

		[Token(Token = "0x60004F0")]
		[Address(RVA = "0x183AD14", Offset = "0x183AD14", Length = "0x10C")]
		public void NotifyToggleOn(Toggle toggle, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60004F1")]
		[Address(RVA = "0x183ABB4", Offset = "0x183ABB4", Length = "0x90")]
		public void UnregisterToggle(Toggle toggle)
		{
		}

		[Token(Token = "0x60004F2")]
		[Address(RVA = "0x183AC44", Offset = "0x183AC44", Length = "0xD0")]
		public void RegisterToggle(Toggle toggle)
		{
		}

		[Token(Token = "0x60004F3")]
		[Address(RVA = "0x183A4E0", Offset = "0x183A4E0", Length = "0x3F0")]
		public void EnsureValidState()
		{
		}

		[Token(Token = "0x60004F4")]
		[Address(RVA = "0x183AE40", Offset = "0x183AE40", Length = "0x138")]
		public bool AnyTogglesOn()
		{
			return false;
		}

		[Token(Token = "0x60004F5")]
		[Address(RVA = "0x183B21C", Offset = "0x183B21C", Length = "0xF4")]
		public IEnumerable<Toggle> ActiveToggles()
		{
			return null;
		}

		[Token(Token = "0x60004F6")]
		[Address(RVA = "0x183B310", Offset = "0x183B310", Length = "0x88")]
		public Toggle GetFirstActiveToggle()
		{
			return null;
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0x183B398", Offset = "0x183B398", Length = "0xF8")]
		public void SetAllTogglesOff(bool sendCallback = true)
		{
		}
	}
}
