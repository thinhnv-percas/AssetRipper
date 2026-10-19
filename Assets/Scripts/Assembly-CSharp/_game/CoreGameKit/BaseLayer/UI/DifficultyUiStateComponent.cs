using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200063A")]
	public class DifficultyUiStateComponent : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001578")]
		[FieldOffset(Offset = "0x20")]
		private ComponentStateHandler m_stateHandler;

		[Inject(true)]
		[Token(Token = "0x6001A99")]
		[Address(RVA = "0x3D555A4", Offset = "0x3D555A4", Length = "0x11C")]
		private void Construct(ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DifficultyUiStateComponent::Construct");
		}

		[Token(Token = "0x6001A9A")]
		[Address(RVA = "0x3D556C0", Offset = "0x3D556C0", Length = "0x8")]
		public DifficultyUiStateComponent()
		{
		}
	}
}
