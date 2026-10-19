using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UiFactory.TabUiSystem.Interfaces;
using _game.CoreGameKit.MenuLayer;
using _game.CoreGameKit.UiControllers;

namespace Unco.UiFactory.TabUiSystem.Core.Actions
{
	[Token(Token = "0x2000798")]
	public class TabUiFactoryAction : ITabAction
	{
		[Inject(false)]
		[Token(Token = "0x4001933")]
		[FieldOffset(Offset = "0x10")]
		private UiManager _uiManager;

		[Token(Token = "0x600200B")]
		[Address(RVA = "0x3D95EB0", Offset = "0x3D95EB0", Length = "0x4")]
		public void OnSelectTab(HomeTabId baseId, HomeTabId from)
		{
		}

		[Token(Token = "0x600200C")]
		[Address(RVA = "0x3D95EB4", Offset = "0x3D95EB4", Length = "0x4")]
		public void OnDeselectTab(HomeTabId baseId, HomeTabId to)
		{
		}

		[Token(Token = "0x600200D")]
		[Address(RVA = "0x3D95EB8", Offset = "0x3D95EB8", Length = "0x8")]
		public TabUiFactoryAction()
		{
		}
	}
}
