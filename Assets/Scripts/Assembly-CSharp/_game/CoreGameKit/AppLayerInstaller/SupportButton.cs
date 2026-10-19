using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006FE")]
	public class SupportButton : MonoBehaviour
	{
		[Token(Token = "0x400176A")]
		private const string SupportEmail = "publishing@uncosoft.com";

		[Token(Token = "0x400176B")]
		private const string Subject = "Sand Out - Support";

		[Token(Token = "0x400176C")]
		private const string UnknownValue = "unknown";

		[Token(Token = "0x400176D")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton _btn;

		[Inject(false)]
		[Token(Token = "0x400176E")]
		[FieldOffset(Offset = "0x28")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x400176F")]
		[FieldOffset(Offset = "0x30")]
		private ILevelList _levelList;

		[Token(Token = "0x6001D7A")]
		[Address(RVA = "0x3D78F78", Offset = "0x3D78F78", Length = "0xD8")]
		private void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SupportButton::Awake");
		}

		[Token(Token = "0x6001D7B")]
		[Address(RVA = "0x3D79050", Offset = "0x3D79050", Length = "0x5C4")]
		private void OpenSupportEmail()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SupportButton::OpenSupportEmail");
		}

		[Token(Token = "0x6001D7C")]
		[Address(RVA = "0x3D79614", Offset = "0x3D79614", Length = "0x4A0")]
		private string GetCurrentLevelTrackingName()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SupportButton::GetCurrentLevelTrackingName");
			return default;
		}

		[Token(Token = "0x6001D7D")]
		[Address(RVA = "0x3D79AB4", Offset = "0x3D79AB4", Length = "0x8")]
		public SupportButton()
		{
		}
	}
}
