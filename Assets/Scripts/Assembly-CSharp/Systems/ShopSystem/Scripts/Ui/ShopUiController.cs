using Systems.UINavigatonSystem.Interface;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.Tracking.Events;
using _game.CoreGameKit.UiControllers;

namespace Systems.ShopSystem.Scripts.Ui
{
	[Token(Token = "0x200004D")]
	public class ShopUiController : UIController, ISubNavigable
	{
		[Inject(false)]
		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x3C682D8", Offset = "0x3C682D8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(eventBus, 0);\n\treturn;\n")]
		public void Construct(EventBus eventBus)
		{
			eventBus.InvokeEvent(default(UventShopOpened));
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x3C68330", Offset = "0x3C68330", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Show()
		{
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x3C68334", Offset = "0x3C68334", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::Hide(this);\n\treturn;\n")]
		public override void Hide()
		{
			base.Hide();
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x3C6833C", Offset = "0x3C6833C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void NavigateTo(string subSectionName)
		{
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x3C68340", Offset = "0x3C68340", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\n")]
		public ShopUiController()
		{
		}
	}
}
