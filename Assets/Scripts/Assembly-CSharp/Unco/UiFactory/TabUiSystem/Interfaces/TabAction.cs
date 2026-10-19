using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Interfaces
{
	[Token(Token = "0x2000791")]
	public abstract class TabAction : MonoBehaviour, ITabAction
	{
		[Token(Token = "0x6001FE9")]
		public abstract void OnSelectTab(HomeTabId baseId, HomeTabId from);

		[Token(Token = "0x6001FEA")]
		public abstract void OnDeselectTab(HomeTabId baseId, HomeTabId to);

		[Token(Token = "0x6001FEB")]
		[Address(RVA = "0x3D94A04", Offset = "0x3D94A04", Length = "0x8")]
		protected internal TabAction()
		{
		}
	}
}
