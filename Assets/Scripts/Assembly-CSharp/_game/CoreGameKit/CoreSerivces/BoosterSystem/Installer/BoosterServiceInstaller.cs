using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Config;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Installer
{
	[CreateAssetMenu(fileName = "BoosterServiceInstaller", menuName = "CoreGameKit/Booster/BoosterServiceInstaller")]
	[Token(Token = "0x2000622")]
	public class BoosterServiceInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000623")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001534")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001535")]
			public static Func<Instancer, BoosterUnlockHandler> _003C_003E9__2_1;

			[Token(Token = "0x4001536")]
			public static Func<Instancer, ScopedBoosterPurchaseHandler> _003C_003E9__2_2;

			[Token(Token = "0x6001A46")]
			[Address(RVA = "0x3D525DC", Offset = "0x3D525DC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001A47")]
			[Address(RVA = "0x3D52640", Offset = "0x3D52640", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal BoosterUnlockHandler _003CInstallBindings_003Eb__2_1(Instancer x)
			{
				BoosterUnlockHandler instance = new BoosterUnlockHandler();
				return x.InjectInstance(instance);
			}

			internal ScopedBoosterPurchaseHandler _003CInstallBindings_003Eb__2_2(Instancer x)
			{
				ScopedBoosterPurchaseHandler instance = new ScopedBoosterPurchaseHandler();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4001532")]
		[FieldOffset(Offset = "0x18")]
		private BoosterDatabase m_boosterDatabase;

		[SerializeField]
		[Token(Token = "0x4001533")]
		[FieldOffset(Offset = "0x20")]
		private BoosterRemoteConfigData[] m_boosterConfigs;

		[Token(Token = "0x6001A43")]
		[Address(RVA = "0x3D5212C", Offset = "0x3D5212C", Length = "0x3D4")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterServiceInstaller::InstallBindings");
		}

		[Token(Token = "0x6001A44")]
		[Address(RVA = "0x3D52500", Offset = "0x3D52500", Length = "0x8")]
		public BoosterServiceInstaller()
		{
		}
	}
}
