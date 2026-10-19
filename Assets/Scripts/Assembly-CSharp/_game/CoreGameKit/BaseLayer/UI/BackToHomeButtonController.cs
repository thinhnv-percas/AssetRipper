using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200062F")]
	public class BackToHomeButtonController : ServiceButtonComponent
	{
		[SerializeField]
		[Token(Token = "0x4001558")]
		[FieldOffset(Offset = "0x20")]
		public UncoButton m_homeButton;

		[Inject(false)]
		[Token(Token = "0x4001559")]
		[FieldOffset(Offset = "0x28")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x400155A")]
		[FieldOffset(Offset = "0x30")]
		private IBaseLayerExitService _exitService;

		[Inject(false)]
		[Token(Token = "0x6001A7B")]
		[Address(RVA = "0x3D53C68", Offset = "0x3D53C68", Length = "0x154")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BackToHomeButtonController::Construct");
		}

		[Token(Token = "0x6001A7C")]
		[Address(RVA = "0x3D53DBC", Offset = "0x3D53DBC", Length = "0xB4")]
		protected override void OnInvoke()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BackToHomeButtonController::OnInvoke");
		}

		[Token(Token = "0x6001A7D")]
		[Address(RVA = "0x3D53E70", Offset = "0x3D53E70", Length = "0x8")]
		public BackToHomeButtonController()
		{
		}
	}
}
