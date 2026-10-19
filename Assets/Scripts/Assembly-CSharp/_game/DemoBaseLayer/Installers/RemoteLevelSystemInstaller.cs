using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreSystem.LevelCreator;

namespace _game.DemoBaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000534")]
	public class RemoteLevelSystemInstaller : InstallerSO, ILevelSystemInstaller, IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000535")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001193")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001194")]
			public static Func<Instancer, LevelNavigationResolver> _003C_003E9__1_1;

			[Token(Token = "0x60015D6")]
			[Address(RVA = "0x3D14AF0", Offset = "0x3D14AF0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60015D7")]
			[Address(RVA = "0x3D14B54", Offset = "0x3D14B54", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal LevelNavigationResolver _003CInstallBindings_003Eb__1_1(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RemoteLevelSystemInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_1");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000536")]
		private sealed class _003C_003Ec__DisplayClass1_0
		{
			[Token(Token = "0x4001195")]
			[FieldOffset(Offset = "0x10")]
			public Instancer instancer;

			[Token(Token = "0x60015D9")]
			[Address(RVA = "0x3D14AE8", Offset = "0x3D14AE8", Length = "0x8")]
			public _003C_003Ec__DisplayClass1_0()
			{
			}

			internal LevelNavigationResolver _003CInstallBindings_003Eb__2()
			{
				if (instancer.TryResolve<LevelNavigationResolver>(out var result))
				{
					return result;
				}
				return null;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001192")]
		[FieldOffset(Offset = "0x18")]
		private LevelListSo m_levelListSo;

		[Token(Token = "0x60015D3")]
		[Address(RVA = "0x3D143D8", Offset = "0x3D143D8", Length = "0x280")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteLevelSystemInstaller::InstallBindings");
		}

		[Token(Token = "0x60015D4")]
		[Address(RVA = "0x3D14658", Offset = "0x3D14658", Length = "0x8")]
		public RemoteLevelSystemInstaller()
		{
		}
	}
}
