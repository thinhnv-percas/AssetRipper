using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RemoteManagementSystem;
using Unco.RewardSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006A7")]
	public class CurrentLevelConfigInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006A8")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001699")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400169A")]
			public static Func<Instancer, ILevel> _003C_003E9__0_0;

			[Token(Token = "0x400169B")]
			public static Func<Instancer, LevelContext> _003C_003E9__0_1;

			[Token(Token = "0x6001C28")]
			[Address(RVA = "0x3D68A6C", Offset = "0x3D68A6C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C29")]
			[Address(RVA = "0x3D68AD0", Offset = "0x3D68AD0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal unsafe ILevel _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CurrentLevelConfigInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}

			internal LevelContext _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CurrentLevelConfigInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_1");
				return default;
			}
		}

		[Token(Token = "0x6001C26")]
		[Address(RVA = "0x3D68810", Offset = "0x3D68810", Length = "0x254")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrentLevelConfigInstaller::InstallBindings");
		}

		[Token(Token = "0x6001C27")]
		[Address(RVA = "0x3D68A64", Offset = "0x3D68A64", Length = "0x8")]
		public CurrentLevelConfigInstaller()
		{
		}
	}
}
