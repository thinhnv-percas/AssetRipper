using Systems.TutorialSystem.Scripts.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace Systems.TutorialSystem.Scripts.UI
{
	[Token(Token = "0x2000014")]
	public class ArrowUIController : UIController
	{
		[SerializeField]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x48")]
		private RectTransform m_Arrow;

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x81E105C", Offset = "0x81E105C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Systems.TutorialSystem.Scripts.Data.RectData::ApplyData(rectData, this.m_Arrow);\n\treturn;\n")]
		public void Initialize(RectData rectData)
		{
			RectTransform rectTransform = rectData.ApplyData(m_Arrow);
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x81E114C", Offset = "0x81E114C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\n")]
		public ArrowUIController()
		{
		}
	}
}
