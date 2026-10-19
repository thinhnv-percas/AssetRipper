using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UiFactory.TabUiSystem.Interfaces;
using _game.CoreGameKit.MenuLayer;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace Unco.UiFactory.TabUiSystem.Core.Actions
{
	[Token(Token = "0x200079A")]
	public class TabSettingsAction : ITabAction
	{
		[Inject(false)]
		[Token(Token = "0x4001935")]
		[FieldOffset(Offset = "0x10")]
		private UiManager _uiManager;

		[Token(Token = "0x6002011")]
		[Address(RVA = "0x3D95EE8", Offset = "0x3D95EE8", Length = "0x54")]
		public void OnSelectTab(HomeTabId baseId, HomeTabId from)
		{
			HomeSettingsUiController homeSettingsUiController = _uiManager.Show<HomeSettingsUiController>();
		}

		[Token(Token = "0x6002012")]
		[Address(RVA = "0x3D95F3C", Offset = "0x3D95F3C", Length = "0x54")]
		public void OnDeselectTab(HomeTabId baseId, HomeTabId to)
		{
			_uiManager.Hide<HomeSettingsUiController>();
		}

		[Token(Token = "0x6002013")]
		[Address(RVA = "0x3D95F90", Offset = "0x3D95F90", Length = "0x8")]
		public TabSettingsAction()
		{
		}
	}
}
