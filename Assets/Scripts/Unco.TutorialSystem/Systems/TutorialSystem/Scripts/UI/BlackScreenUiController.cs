using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.UiControllers;

namespace Systems.TutorialSystem.Scripts.UI
{
	[Token(Token = "0x2000015")]
	public class BlackScreenUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x48")]
		private Image m_Image;

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x81E1154", Offset = "0x81E1154", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = UnityEngine.UI.Graphic::set_color(v4, Color_arg);\n\treturn;\n")]
		public void Show(Color color)
		{
			Image image = default(Image);
			Color color2 = default(Color);
			image.color = color2;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x81E1178", Offset = "0x81E1178", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\n")]
		public BlackScreenUiController()
		{
		}
	}
}
