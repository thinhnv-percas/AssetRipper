using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Interfaces
{
	[Token(Token = "0x200078D")]
	public abstract class BaseTabUiElement : MonoBehaviour, ITabUiElement
	{
		[Token(Token = "0x17000310")]
		public abstract HomeTabId TabUiId
		{
			[Token(Token = "0x6001FDF")]
			get;
		}

		[Token(Token = "0x6001FE0")]
		public abstract void OnSelectTab(HomeTabId from);

		[Token(Token = "0x6001FE1")]
		public abstract void OnDeselectTab(HomeTabId to);

		[Token(Token = "0x6001FE2")]
		[Address(RVA = "0x3D949FC", Offset = "0x3D949FC", Length = "0x8")]
		protected internal BaseTabUiElement()
		{
		}
	}
}
