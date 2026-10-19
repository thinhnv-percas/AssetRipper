using System;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.UncoButtonSystem;
using UnityEngine;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006F4")]
	public class PrivacyPolicyButton : MonoBehaviour
	{
		[Token(Token = "0x4001759")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton _btn;

		[Token(Token = "0x6001D63")]
		[Address(RVA = "0x3D77F44", Offset = "0x3D77F44", Length = "0xD4")]
		private void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PrivacyPolicyButton::Awake");
		}

		[Token(Token = "0x6001D64")]
		[Address(RVA = "0x3D78018", Offset = "0x3D78018", Length = "0x8")]
		public PrivacyPolicyButton()
		{
		}
	}
}
