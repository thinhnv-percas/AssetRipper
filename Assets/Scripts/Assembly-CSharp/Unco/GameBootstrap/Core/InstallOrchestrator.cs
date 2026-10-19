using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007D2")]
	public class InstallOrchestrator
	{
		[Token(Token = "0x20007D3")]
		private class WrapperInstaller : IContainerInstaller
		{
			[Token(Token = "0x4001A27")]
			[FieldOffset(Offset = "0x10")]
			internal readonly IEnumerable<IContainerInstaller> _installers;

			[Token(Token = "0x6002117")]
			[Address(RVA = "0x3DC1B48", Offset = "0x3DC1B48", Length = "0x34")]
			public WrapperInstaller(IEnumerable<IContainerInstaller> installers)
			{
				_installers = installers;
			}

			[Token(Token = "0x6002118")]
			[Address(RVA = "0x3DC1EC0", Offset = "0x3DC1EC0", Length = "0x32C")]
			public unsafe void InstallBindings(ref ContainerInstanceBuilder builder)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator.WrapperInstaller::InstallBindings");
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20007D4")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001A28")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001A29")]
			public static Func<IContainerInstaller, bool> _003C_003E9__10_0;

			[Token(Token = "0x4001A2A")]
			public static Func<IContainerInstaller, bool> _003C_003E9__11_0;

			[Token(Token = "0x6002119")]
			[Address(RVA = "0x3DC21EC", Offset = "0x3DC21EC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600211A")]
			[Address(RVA = "0x3DC2250", Offset = "0x3DC2250", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CInstallPhase_003Eb__10_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}

			internal bool _003CInstallSceneConfig_003Eb__11_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007D5")]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			[Token(Token = "0x4001A2B")]
			[FieldOffset(Offset = "0x10")]
			public HashSet<string> sceneInstallers;

			[Token(Token = "0x600211D")]
			[Address(RVA = "0x3DC18AC", Offset = "0x3DC18AC", Length = "0x8")]
			public _003C_003Ec__DisplayClass11_0()
			{
			}

			internal bool _003CInstallSceneConfig_003Eb__1(IContainerInstaller i)
			{
				Type type = i.GetType();
				string name = type.Name;
				bool flag = sceneInstallers.Contains(name);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}

		[Token(Token = "0x4001A20")]
		[FieldOffset(Offset = "0x10")]
		private readonly ScopeRegistry _scopeRegistry;

		[Token(Token = "0x4001A21")]
		[FieldOffset(Offset = "0x18")]
		private readonly GameModeConfig _config;

		[Token(Token = "0x4001A22")]
		[FieldOffset(Offset = "0x20")]
		internal readonly HashSet<string> _installedInstallers;

		[Token(Token = "0x4001A23")]
		[FieldOffset(Offset = "0x28")]
		private readonly HashSet<LifetimeKind> _lifetimeContainersCreated;

		[Token(Token = "0x4001A24")]
		[FieldOffset(Offset = "0x30")]
		private readonly List<IContainerInstaller> _pendingSingletonInstallers;

		[Token(Token = "0x4001A25")]
		[FieldOffset(Offset = "0x38")]
		private readonly List<IContainerInstaller> _pendingScopedInstallers;

		[Token(Token = "0x4001A26")]
		[FieldOffset(Offset = "0x40")]
		private readonly Dictionary<string, HashSet<string>> _sceneInstallerMap;

		[Token(Token = "0x600210B")]
		[Address(RVA = "0x3DBE708", Offset = "0x3DBE708", Length = "0x1D4")]
		public InstallOrchestrator(ScopeRegistry scopeRegistry, GameModeConfig config)
		{
			HashSet<string> installedInstallers = new HashSet<string>();
			_installedInstallers = installedInstallers;
			_lifetimeContainersCreated = new HashSet<LifetimeKind>();
			_pendingSingletonInstallers = new List<IContainerInstaller>();
			_pendingScopedInstallers = new List<IContainerInstaller>();
			_sceneInstallerMap = new Dictionary<string, HashSet<string>>();
			_scopeRegistry = scopeRegistry;
			_config = config;
		}

		[Token(Token = "0x600210C")]
		[Address(RVA = "0x3DC0CC4", Offset = "0x3DC0CC4", Length = "0x8")]
		public void DisposeSceneScope()
		{
			DisposeSceneScope(null);
		}

		[Token(Token = "0x600210D")]
		[Address(RVA = "0x3DC0CCC", Offset = "0x3DC0CCC", Length = "0x280")]
		public unsafe void DisposeSceneScope(string sceneName)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::DisposeSceneScope");
		}

		[Token(Token = "0x600210E")]
		[Address(RVA = "0x3DC0F4C", Offset = "0x3DC0F4C", Length = "0x3B0")]
		public unsafe void InstallPhase()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::InstallPhase");
		}

		[Token(Token = "0x600210F")]
		[Address(RVA = "0x3DC1374", Offset = "0x3DC1374", Length = "0x538")]
		public unsafe void InstallSceneConfig(SceneConfig sceneConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::InstallSceneConfig");
		}

		[Token(Token = "0x6002110")]
		[Address(RVA = "0x3DC12FC", Offset = "0x3DC12FC", Length = "0x78")]
		private void InstallInstallers(List<IContainerInstaller> installers, LifetimeKind defaultLifetime)
		{
			List<IContainerInstaller> list = default(List<IContainerInstaller>);
			if (list != null && list.Count != 0)
			{
				InstallToSceneScope(list);
			}
		}

		[Token(Token = "0x6002111")]
		[Address(RVA = "0x3DC19AC", Offset = "0x3DC19AC", Length = "0x4")]
		private void InstallToGlobalScope(List<IContainerInstaller> installers)
		{
			InstallToSceneScope(installers);
		}

		[Token(Token = "0x6002112")]
		[Address(RVA = "0x3DC19B0", Offset = "0x3DC19B0", Length = "0x198")]
		private void InstallToSceneScope(List<IContainerInstaller> installers)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::InstallToSceneScope");
		}

		[Token(Token = "0x6002113")]
		[Address(RVA = "0x3DBF558", Offset = "0x3DBF558", Length = "0x2CC")]
		public void InstallOnDemandFeature(string featureTag)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::InstallOnDemandFeature");
		}

		[Token(Token = "0x6002114")]
		[Address(RVA = "0x3DC1CF8", Offset = "0x3DC1CF8", Length = "0x130")]
		private void InstallToFeatureScope(string featureTag, IEnumerable<IContainerInstaller> installers)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InstallOrchestrator::InstallToFeatureScope");
		}

		[Token(Token = "0x6002115")]
		[Address(RVA = "0x3DBF370", Offset = "0x3DBF370", Length = "0x98")]
		public void MarkInstallerAsInstalled(IContainerInstaller installer)
		{
			if (installer != null)
			{
				Type type = installer.GetType();
				string name = type.Name;
				bool flag = _installedInstallers.Add(name);
			}
		}
	}
}
