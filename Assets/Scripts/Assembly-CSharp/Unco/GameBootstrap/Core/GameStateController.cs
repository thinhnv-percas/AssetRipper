using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Runtime;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007CD")]
	public class GameStateController
	{
		[Token(Token = "0x4001A17")]
		[FieldOffset(Offset = "0x10")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001A18")]
		[FieldOffset(Offset = "0x18")]
		private ScopeRegistry _scopeRegistry;

		[Token(Token = "0x4001A19")]
		[FieldOffset(Offset = "0x20")]
		internal GameplayLayer _currentLayer;

		[Inject(false)]
		[Token(Token = "0x4001A1A")]
		[FieldOffset(Offset = "0x28")]
		private RemoteConfigManager _remoteConfigManager;

		[Inject(false)]
		[Token(Token = "0x4001A1B")]
		[FieldOffset(Offset = "0x30")]
		private ILevelProgressService _levelProgressService;

		[Token(Token = "0x17000332")]
		public GameplayLayer CurrentLayer
		{
			[Token(Token = "0x60020FA")]
			[Address(RVA = "0x3DC0340", Offset = "0x3DC0340", Length = "0x8")]
			get
			{
				return _currentLayer;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60020FB")]
		[Address(RVA = "0x3DC0348", Offset = "0x3DC0348", Length = "0xBC")]
		private void Inject(ContainerManager containerManager)
		{
			ContainerManager containerManager2 = default(ContainerManager);
			_containerManager = containerManager2;
			GameBootstrapper gameBootstrapper = UnityEngine.Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper != null)
			{
				_scopeRegistry = gameBootstrapper._scopeRegistry;
			}
			SwitchToMenuLayer();
		}

		[Token(Token = "0x60020FC")]
		[Address(RVA = "0x3DC0404", Offset = "0x3DC0404", Length = "0x11C")]
		public void SwitchToMenuLayer()
		{
			DisposeCurrentFeature();
			GameBootstrapper gameBootstrapper = UnityEngine.Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper == null)
			{
				Debug.LogWarning("[GameplayLayerService] GameBootstrapper not found. Cannot install menu feature.");
				return;
			}
			InstallOnDemandFeatureBasedOnFirstTime();
			_currentLayer = default(GameplayLayer);
		}

		[Token(Token = "0x60020FD")]
		[Address(RVA = "0x3DC0988", Offset = "0x3DC0988", Length = "0x164")]
		public unsafe void StartBaseLayer(bool animated = true)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameStateController::StartBaseLayer");
		}

		[Token(Token = "0x60020FE")]
		[Address(RVA = "0x3DC0AEC", Offset = "0x3DC0AEC", Length = "0x120")]
		private void InstallBaseLayerFeature()
		{
			GameBootstrapper gameBootstrapper = UnityEngine.Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper != null)
			{
				if (gameBootstrapper._installOrchestrator != null)
				{
					gameBootstrapper._installOrchestrator.InstallOnDemandFeature("baselayer");
				}
				else
				{
					Debug.LogError("[GameBootstrapper] Cannot install feature: system not initialized");
				}
				_currentLayer = GameplayLayer.BaseLayer;
			}
		}

		[Token(Token = "0x60020FF")]
		[Address(RVA = "0x3DC0520", Offset = "0x3DC0520", Length = "0x22C")]
		private void DisposeCurrentFeature()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameStateController::DisposeCurrentFeature");
		}

		[Token(Token = "0x6002100")]
		[Address(RVA = "0x3DC074C", Offset = "0x3DC074C", Length = "0x23C")]
		private void InstallOnDemandFeatureBasedOnFirstTime()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameStateController::InstallOnDemandFeatureBasedOnFirstTime");
		}

		[Token(Token = "0x6002101")]
		[Address(RVA = "0x3DC0C0C", Offset = "0x3DC0C0C", Length = "0x10")]
		public GameStateController()
		{
			_currentLayer = GameplayLayer.None;
		}
	}
}
