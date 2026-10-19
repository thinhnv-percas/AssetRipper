using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.GameBootstrap.Core;
using Unco.RemoteManagementSystem;
using Unco.ResourceSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.FeatureUnlock;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Ui.Animations;

namespace _game.CoreGameKit.CoreSerivces
{
	[Token(Token = "0x2000606")]
	public class CoreServiceInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000607")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40014DA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40014DB")]
			public static Func<Instancer, IResourceService> _003C_003E9__2_0;

			[Token(Token = "0x40014DC")]
			public static Func<Instancer, LevelTransactionContextProvider> _003C_003E9__2_2;

			[Token(Token = "0x40014DD")]
			public static Func<Instancer, TransactionContextFactory> _003C_003E9__2_3;

			[Token(Token = "0x60019D1")]
			[Address(RVA = "0x3D4E698", Offset = "0x3D4E698", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60019D2")]
			[Address(RVA = "0x3D4E6FC", Offset = "0x3D4E6FC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal unsafe IResourceService _003CInstallBindings_003Eb__2_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CoreServiceInstaller._003C_003Ec::_003CInstallBindings_003Eb__2_0");
				return default;
			}

			internal LevelTransactionContextProvider _003CInstallBindings_003Eb__2_2(Instancer x)
			{
				LevelTransactionContextProvider instance = new LevelTransactionContextProvider();
				return x.InjectInstance(instance);
			}

			internal TransactionContextFactory _003CInstallBindings_003Eb__2_3(Instancer x)
			{
				bool flag = x.TryResolve<ITransactionContextProvider>(out var result);
				return new TransactionContextFactory(result);
			}
		}

		[SerializeField]
		[Token(Token = "0x40014D8")]
		[FieldOffset(Offset = "0x18")]
		private FeatureUnlockDatabase m_featureUnlockDatabase;

		[SerializeField]
		[Token(Token = "0x40014D9")]
		[FieldOffset(Offset = "0x20")]
		private CurrencyAnimationController m_currencyAnimationController;

		[Token(Token = "0x60019CE")]
		[Address(RVA = "0x3D4DED0", Offset = "0x3D4DED0", Length = "0x608")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CoreServiceInstaller::InstallBindings");
		}

		[Token(Token = "0x60019CF")]
		[Address(RVA = "0x3D4E4E8", Offset = "0x3D4E4E8", Length = "0x8")]
		public CoreServiceInstaller()
		{
		}
	}
}
