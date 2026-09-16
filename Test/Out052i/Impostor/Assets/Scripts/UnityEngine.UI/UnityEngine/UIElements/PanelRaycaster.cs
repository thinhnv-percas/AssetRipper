using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UIElements
{
	[AddComponentMenu("UI Toolkit/Panel Raycaster (UI Toolkit)")]
	[Token(Token = "0x2000095")]
	public class PanelRaycaster : BaseRaycaster, IRuntimePanelComponent
	{
		[Token(Token = "0x40002AA")]
		[FieldOffset(Offset = "0x28")]
		private BaseRuntimePanel m_Panel;

		[Token(Token = "0x17000187")]
		public IPanel panel
		{
			[Token(Token = "0x60005DE")]
			[Address(RVA = "0x1841D44", Offset = "0x1841D44", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005DF")]
			[Address(RVA = "0x1841D4C", Offset = "0x1841D4C", Length = "0xA4")]
			set
			{
			}
		}

		[Token(Token = "0x17000188")]
		private GameObject selectableGameObject
		{
			[Token(Token = "0x60005E3")]
			[Address(RVA = "0x1841F18", Offset = "0x1841F18", Length = "0x18")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000189")]
		public override int sortOrderPriority
		{
			[Token(Token = "0x60005E4")]
			[Address(RVA = "0x1841F30", Offset = "0x1841F30", Length = "0x7C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700018A")]
		public override int renderOrderPriority
		{
			[Token(Token = "0x60005E5")]
			[Address(RVA = "0x1841FAC", Offset = "0x1841FAC", Length = "0x74")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700018B")]
		public override Camera eventCamera
		{
			[Token(Token = "0x60005E7")]
			[Address(RVA = "0x18424B8", Offset = "0x18424B8", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60005E0")]
		[Address(RVA = "0x1841E80", Offset = "0x1841E80", Length = "0x90")]
		private void RegisterCallbacks()
		{
		}

		[Token(Token = "0x60005E1")]
		[Address(RVA = "0x1841DF0", Offset = "0x1841DF0", Length = "0x90")]
		private void UnregisterCallbacks()
		{
		}

		[Token(Token = "0x60005E2")]
		[Address(RVA = "0x1841F10", Offset = "0x1841F10", Length = "0x8")]
		private void OnPanelDestroyed()
		{
		}

		[Token(Token = "0x60005E6")]
		[Address(RVA = "0x1842020", Offset = "0x1842020", Length = "0x498")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0x18424C0", Offset = "0x18424C0", Length = "0x8")]
		public PanelRaycaster()
		{
		}
	}
}
