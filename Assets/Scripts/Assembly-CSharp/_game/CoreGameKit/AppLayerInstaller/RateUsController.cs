using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using UnityEngine;
using UnityEngine.iOS;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006F7")]
	public class RateUsController
	{
		[Token(Token = "0x400175C")]
		[FieldOffset(Offset = "0x10")]
		private ILevelProgressService _levelProgressService;

		[Token(Token = "0x400175D")]
		[FieldOffset(Offset = "0x18")]
		private RateUsConfig _config;

		[Inject(false)]
		[Token(Token = "0x6001D6A")]
		[Address(RVA = "0x3D7824C", Offset = "0x3D7824C", Length = "0x80")]
		private void Construct(RemoteConfigManager remoteConfigManager, ILevelProgressService levelProgressService)
		{
			_levelProgressService = levelProgressService;
			RateUsConfig json = remoteConfigManager.GetJson<RateUsConfig>(RemoteKey.rate_us_popup_level);
			_config = json;
		}

		[Token(Token = "0x6001D6B")]
		[Address(RVA = "0x3D782CC", Offset = "0x3D782CC", Length = "0x138")]
		public void TriggerLocation(ShowLocation location)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RateUsController::TriggerLocation");
		}

		[Token(Token = "0x6001D6C")]
		[Address(RVA = "0x3D78244", Offset = "0x3D78244", Length = "0x8")]
		public RateUsController()
		{
		}
	}
}
