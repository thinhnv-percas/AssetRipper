using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727B04", Offset = "0x727B04")]
	[DisallowMultipleComponent]
	[Token(Token = "0x200003A")]
	public class ToggleGroup : UIBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x18")]
		private bool m_AllowSwitchOff;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x20")]
		private List<Toggle> m_Toggles;

		[Token(Token = "0x17000136")]
		public bool allowSwitchOff
		{
			[Token(Token = "0x6000451")]
			[Address(RVA = "0xEDC4D4", Offset = "0xEDC4D4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000452")]
			[Address(RVA = "0xEDC4DC", Offset = "0xEDC4DC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000453")]
		[Address(RVA = "0xEDC4E8", Offset = "0xEDC4E8", Length = "0x70")]
		protected ToggleGroup()
		{
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0xEDC558", Offset = "0xEDC558", Length = "0x28")]
		protected override void Start()
		{
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0xEDC580", Offset = "0xEDC580", Length = "0x160")]
		private void ValidateToggleIsInGroup(Toggle toggle)
		{
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0xEDC1B0", Offset = "0xEDC1B0", Length = "0x134")]
		public void NotifyToggleOn(Toggle toggle, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0xEDC080", Offset = "0xEDC080", Length = "0x98")]
		public void UnregisterToggle(Toggle toggle)
		{
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0xEDC118", Offset = "0xEDC118", Length = "0x98")]
		public void RegisterToggle(Toggle toggle)
		{
		}

		[Token(Token = "0x6000459")]
		[Address(RVA = "0xEDBCF8", Offset = "0xEDBCF8", Length = "0xB8")]
		public void EnsureValidState()
		{
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0xEDC304", Offset = "0xEDC304", Length = "0x134")]
		public bool AnyTogglesOn()
		{
			return false;
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0xEDC6E0", Offset = "0xEDC6E0", Length = "0xF0")]
		public IEnumerable<Toggle> ActiveToggles()
		{
			return null;
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0xEDC7D0", Offset = "0xEDC7D0", Length = "0x10C")]
		public void SetAllTogglesOff(bool sendCallback = true)
		{
		}
	}
}
