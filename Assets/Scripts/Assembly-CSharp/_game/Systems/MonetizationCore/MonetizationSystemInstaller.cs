using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unco.AdSystem;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RemoteManagementSystem;
using Unco.RewardSystem;
using _game.Systems.ElephantStorage;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x2000771")]
	public class MonetizationSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000772")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40018E4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40018E5")]
			public static Func<Instancer, InterstitialConfig> _003C_003E9__0_0;

			[Token(Token = "0x40018E6")]
			public static Func<Instancer, InterstitialAdService> _003C_003E9__0_1;

			[Token(Token = "0x40018E7")]
			public static Func<Instancer, BannerAdService> _003C_003E9__0_2;

			[Token(Token = "0x6001F69")]
			[Address(RVA = "0x3D8F8B4", Offset = "0x3D8F8B4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001F6A")]
			[Address(RVA = "0x3D8F918", Offset = "0x3D8F918", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal InterstitialConfig _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonetizationSystemInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}

			internal InterstitialAdService _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonetizationSystemInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_1");
				return default;
			}

			internal BannerAdService _003CInstallBindings_003Eb__0_2(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonetizationSystemInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_2");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000773")]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			[Token(Token = "0x40018E8")]
			[FieldOffset(Offset = "0x10")]
			public MonetizationStorageData monetizationData;

			[Token(Token = "0x40018E9")]
			[FieldOffset(Offset = "0x18")]
			public IPlayerDataHandler dataHandler;

			[Token(Token = "0x40018EA")]
			[FieldOffset(Offset = "0x20")]
			public bool hasAdManager;

			[Token(Token = "0x40018EB")]
			[FieldOffset(Offset = "0x28")]
			public IAdManager adManager;

			[Token(Token = "0x6001F6E")]
			[Address(RVA = "0x3D8FC5C", Offset = "0x3D8FC5C", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_0()
			{
			}

			internal void _003CInstallBindings_003Eb__3(IAPShopItemData _)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonetizationSystemInstaller._003C_003Ec__DisplayClass0_0::_003CInstallBindings_003Eb__3");
			}
		}

		[Token(Token = "0x6001F67")]
		[Address(RVA = "0x3D8F5EC", Offset = "0x3D8F5EC", Length = "0x2C0")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonetizationSystemInstaller::InstallBindings");
		}

		[Token(Token = "0x6001F68")]
		[Address(RVA = "0x3D8F8AC", Offset = "0x3D8F8AC", Length = "0x8")]
		public MonetizationSystemInstaller()
		{
		}
	}
}
