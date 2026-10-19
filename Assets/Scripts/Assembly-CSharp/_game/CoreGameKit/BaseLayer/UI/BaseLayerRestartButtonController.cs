using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000630")]
	public class BaseLayerRestartButtonController : ServiceButtonComponent
	{
		[SerializeField]
		[Token(Token = "0x400155B")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_restartButton;

		[Inject(false)]
		[Token(Token = "0x400155C")]
		[FieldOffset(Offset = "0x28")]
		private IBaseLayerRestartService _restartService;

		[Inject(false)]
		[Token(Token = "0x6001A7E")]
		[Address(RVA = "0x3D53E80", Offset = "0x3D53E80", Length = "0x154")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerRestartButtonController::Construct");
		}

		[Token(Token = "0x6001A7F")]
		[Address(RVA = "0x3D53FD4", Offset = "0x3D53FD4", Length = "0xB4")]
		protected override void OnInvoke()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerRestartButtonController::OnInvoke");
		}

		[Token(Token = "0x6001A80")]
		[Address(RVA = "0x3D54088", Offset = "0x3D54088", Length = "0x3C")]
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.J))
			{
				InvokeClick();
			}
		}

		[Token(Token = "0x6001A81")]
		[Address(RVA = "0x3D54214", Offset = "0x3D54214", Length = "0x8")]
		public BaseLayerRestartButtonController()
		{
		}
	}
}
