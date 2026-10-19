using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.UI;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C5")]
	public class BaseLayerSettingsComponentState : ComponentState
	{
		[SerializeField]
		[Token(Token = "0x4000FFC")]
		[FieldOffset(Offset = "0x28")]
		private BaseLayerSettingsState m_settingsFlag;

		[Token(Token = "0x170001BA")]
		public BaseLayerSettingsState SettingsFlag
		{
			[Token(Token = "0x600141A")]
			[Address(RVA = "0x3CF2774", Offset = "0x3CF2774", Length = "0x8")]
			get
			{
				return m_settingsFlag;
			}
		}

		[Token(Token = "0x600141B")]
		[Address(RVA = "0x3CF277C", Offset = "0x3CF277C", Length = "0x8")]
		public BaseLayerSettingsComponentState()
		{
		}
	}
}
