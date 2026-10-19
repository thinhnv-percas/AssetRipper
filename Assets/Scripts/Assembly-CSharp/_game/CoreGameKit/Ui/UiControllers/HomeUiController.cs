using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000548")]
	public class HomeUiController : UIController
	{
		[Inject(false)]
		[Token(Token = "0x600161B")]
		[Address(RVA = "0x3D18C60", Offset = "0x3D18C60", Length = "0x4")]
		public void Initialize()
		{
		}

		[Token(Token = "0x600161C")]
		[Address(RVA = "0x3D18C64", Offset = "0x3D18C64", Length = "0x4")]
		public void Dispose()
		{
		}

		[Token(Token = "0x600161D")]
		[Address(RVA = "0x3D18C68", Offset = "0x3D18C68", Length = "0x8")]
		public HomeUiController()
		{
		}
	}
}
