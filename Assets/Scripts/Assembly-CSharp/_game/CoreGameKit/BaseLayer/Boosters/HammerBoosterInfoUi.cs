using System;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Boosters
{
	[Token(Token = "0x20006EA")]
	public class HammerBoosterInfoUi : UIController
	{
		[Token(Token = "0x4001741")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_closeButton;

		[Token(Token = "0x6001D3F")]
		[Address(RVA = "0x3D761CC", Offset = "0x3D761CC", Length = "0x114")]
		public void Init(Action onClose)
		{
			UncoButton componentInChildren = GetComponentInChildren<UncoButton>();
			m_closeButton = componentInChildren;
			Action clickAction = delegate
			{
				if (onClose != null)
				{
					onClose();
				}
			};
			m_closeButton.AddListener(clickAction);
		}

		[Token(Token = "0x6001D40")]
		[Address(RVA = "0x3D765DC", Offset = "0x3D765DC", Length = "0x8")]
		public HammerBoosterInfoUi()
		{
		}
	}
}
