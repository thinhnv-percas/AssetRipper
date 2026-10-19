using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000641")]
	public class HideUiOnClickComponent : MonoBehaviour, IServiceButtonListener
	{
		[Inject(false)]
		[Token(Token = "0x4001589")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _uiManager;

		[Token(Token = "0x6001AAC")]
		[Address(RVA = "0x3D55E58", Offset = "0x3D55E58", Length = "0x80")]
		public void ServiceCalled()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HideUiOnClickComponent::ServiceCalled");
		}

		[Token(Token = "0x6001AAD")]
		[Address(RVA = "0x3D55ED8", Offset = "0x3D55ED8", Length = "0x8")]
		public HideUiOnClickComponent()
		{
		}
	}
}
