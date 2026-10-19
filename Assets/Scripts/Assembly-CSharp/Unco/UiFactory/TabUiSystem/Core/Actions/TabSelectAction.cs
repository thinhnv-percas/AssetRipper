using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UiFactory.TabUiSystem.Interfaces;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Core.Actions
{
	[Token(Token = "0x2000799")]
	public class TabSelectAction : ITabAction
	{
		[Inject(false)]
		[Token(Token = "0x4001934")]
		[FieldOffset(Offset = "0x10")]
		private HomeTabContainerSystem _homeTabContainerSystem;

		[Token(Token = "0x600200E")]
		[Address(RVA = "0x3D95EC0", Offset = "0x3D95EC0", Length = "0x1C")]
		public void OnSelectTab(HomeTabId baseId, HomeTabId from)
		{
			_homeTabContainerSystem.ActivateTab(baseId);
		}

		[Token(Token = "0x600200F")]
		[Address(RVA = "0x3D95EDC", Offset = "0x3D95EDC", Length = "0x4")]
		public void OnDeselectTab(HomeTabId baseId, HomeTabId to)
		{
		}

		[Token(Token = "0x6002010")]
		[Address(RVA = "0x3D95EE0", Offset = "0x3D95EE0", Length = "0x8")]
		public TabSelectAction()
		{
		}
	}
}
