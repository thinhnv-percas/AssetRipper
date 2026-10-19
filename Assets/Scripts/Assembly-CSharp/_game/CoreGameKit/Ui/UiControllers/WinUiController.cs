using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.Tracking.Tools.Logging;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200055A")]
	public class WinUiController : UIController
	{
		[Inject(false)]
		[Token(Token = "0x4001247")]
		[FieldOffset(Offset = "0x48")]
		private ULogger _logger;

		[Token(Token = "0x600166D")]
		[Address(RVA = "0x3D1D6B8", Offset = "0x3D1D6B8", Length = "0x4")]
		private void OnTriggerStay(Collider other)
		{
		}

		[Token(Token = "0x600166E")]
		[Address(RVA = "0x3D1D6BC", Offset = "0x3D1D6BC", Length = "0x8")]
		public WinUiController()
		{
		}
	}
}
