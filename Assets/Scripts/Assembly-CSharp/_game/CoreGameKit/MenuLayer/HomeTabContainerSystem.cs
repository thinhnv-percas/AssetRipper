using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.Extensions;
using Unco.GameBootstrap.Config;
using Unco.GameBootstrap.Core;
using Unco.UiFactory.TabUiSystem.Core;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller;
using _game.CoreGameKit.BaseLayer.Runtime;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005DA")]
	public class HomeTabContainerSystem : IAnimatedDisposable, IDisposable
	{
		[Token(Token = "0x4001446")]
		[FieldOffset(Offset = "0x10")]
		private readonly IReadOnlyList<Pair<HomeTabId, TabData>> _tabs;

		[Token(Token = "0x4001447")]
		[FieldOffset(Offset = "0x18")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001448")]
		[FieldOffset(Offset = "0x20")]
		private ScopeRegistry _scopeRegistry;

		[Token(Token = "0x4001449")]
		[FieldOffset(Offset = "0x28")]
		private UiManager _uiManager;

		[Token(Token = "0x17000261")]
		[field: Token(Token = "0x400144A")]
		[field: FieldOffset(Offset = "0x30")]
		public HomeTabId CurrentTabId
		{
			[Token(Token = "0x600192A")]
			[Address(RVA = "0x3D45830", Offset = "0x3D45830", Length = "0x8")]
			get;
			[Token(Token = "0x600192B")]
			[Address(RVA = "0x3D45838", Offset = "0x3D45838", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x600192C")]
		[Address(RVA = "0x3D4562C", Offset = "0x3D4562C", Length = "0x34")]
		public HomeTabContainerSystem(IReadOnlyList<Pair<HomeTabId, TabData>> tabs)
		{
			_tabs = tabs;
		}

		[Inject(false)]
		[Token(Token = "0x600192D")]
		[Address(RVA = "0x3D45840", Offset = "0x3D45840", Length = "0x124")]
		public void Initialize(ContainerManager containerManager, UiManager uiManager)
		{
			ContainerManager containerManager2 = default(ContainerManager);
			_containerManager = containerManager2;
			_uiManager = uiManager;
			GameBootstrapper gameBootstrapper = UnityEngine.Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper != null)
			{
				_scopeRegistry = gameBootstrapper._scopeRegistry;
			}
			else
			{
				Debug.LogError("[HomeTabContainerSystem] GameBootstrapper not found! Cannot access ScopeRegistry.");
			}
			ActivateTab(HomeTabId.PlayTab);
		}

		[Token(Token = "0x600192E")]
		[Address(RVA = "0x3D45DE4", Offset = "0x3D45DE4", Length = "0xB0")]
		public void SelectTab(HomeTabId tabId)
		{
			if (_uiManager != null && _uiManager.Exist<TabUiController>())
			{
				TabUiController tabUiController = _uiManager.Get<TabUiController>();
				tabUiController.SelectTab(tabId);
			}
			else
			{
				ActivateTab(tabId);
			}
		}

		[Token(Token = "0x600192F")]
		[Address(RVA = "0x3D45964", Offset = "0x3D45964", Length = "0x480")]
		public void ActivateTab(HomeTabId tabId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HomeTabContainerSystem::ActivateTab");
		}

		[Token(Token = "0x6001930")]
		[Address(RVA = "0x3D45E9C", Offset = "0x3D45E9C", Length = "0xD0")]
		public void Dispose()
		{
			if (CurrentTabId != HomeTabId.None)
			{
				if (_scopeRegistry != null)
				{
					HomeTabId currentTabId = CurrentTabId;
					object arg = currentTabId;
					string featureTag = $"HomeTab_{arg}";
					_scopeRegistry.DisposeFeatureRuntimeScope(featureTag);
				}
				else if (_containerManager != null)
				{
					_containerManager.DisposeContainer<FeatureRuntimeContainer>();
				}
			}
		}

		[Token(Token = "0x6001931")]
		[Address(RVA = "0x3D45F6C", Offset = "0x3D45F6C", Length = "0x198")]
		public void DisposeAnimated(Action<IAnimatedDisposable> onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HomeTabContainerSystem::DisposeAnimated");
		}
	}
}
