using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.UiFactory.TabUiSystem.Core;
using _game.CoreGameKit.MenuLayer.PlayTabInstallers;
using _game.CoreGameKit.MenuLayer.SideBubbleSystem;
using _game.CoreGameKit.UiControllers;

namespace _game.Systems.Offers
{
	[Token(Token = "0x200075E")]
	public class HomeOfferConsumer : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x400189A")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x400189B")]
		[FieldOffset(Offset = "0x18")]
		private OfferService _offerService;

		[Inject(false)]
		[Token(Token = "0x400189C")]
		[FieldOffset(Offset = "0x20")]
		private Instancer _instancer;

		[Token(Token = "0x400189D")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<Type> _uiStack;

		[Token(Token = "0x400189E")]
		[FieldOffset(Offset = "0x30")]
		private readonly List<Type> _ignoreList;

		[Token(Token = "0x170002F5")]
		private bool IsMainMenuOnTop
		{
			[Token(Token = "0x6001F09")]
			[Address(RVA = "0x3D8B194", Offset = "0x3D8B194", Length = "0xCC")]
			get
			{
				List<Type> uiStack = _uiStack;
				int index = uiStack.Count - 1;
				if (uiStack.Count >= 1)
				{
					Type type = uiStack[index];
					Type typeFromHandle = typeof(MainMenuUiController);
					return type == typeFromHandle;
				}
				return false;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001F0A")]
		[Address(RVA = "0x3D8B260", Offset = "0x3D8B260", Length = "0x120")]
		public void Init()
		{
			Action<UventUiShown> observer = OnUiShown;
			_eventBus.ListenEvent(observer);
			Action<UventUiHidden> observer2 = OnUiHidden;
			_eventBus.ListenEvent(observer2);
		}

		[Token(Token = "0x6001F0B")]
		[Address(RVA = "0x3D8B380", Offset = "0x3D8B380", Length = "0x13C")]
		private void OnUiShown(UventUiShown evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HomeOfferConsumer::OnUiShown");
		}

		[Token(Token = "0x6001F0C")]
		[Address(RVA = "0x3D8B668", Offset = "0x3D8B668", Length = "0xC0")]
		private void OnUiHidden(UventUiHidden evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HomeOfferConsumer::OnUiHidden");
		}

		[Token(Token = "0x6001F0D")]
		[Address(RVA = "0x3D8B728", Offset = "0x3D8B728", Length = "0x120")]
		public void Dispose()
		{
			Action<UventUiShown> observer = OnUiShown;
			_eventBus.RemoveListener(observer);
			Action<UventUiHidden> observer2 = OnUiHidden;
			_eventBus.RemoveListener(observer2);
		}

		[Token(Token = "0x6001F0E")]
		[Address(RVA = "0x3D8AFB4", Offset = "0x3D8AFB4", Length = "0x1E0")]
		public HomeOfferConsumer()
		{
			List<Type> uiStack = new List<Type>();
			_uiStack = uiStack;
			List<Type> list = new List<Type>();
			Type typeFromHandle = typeof(TabUiController);
			list.Add(typeFromHandle);
			Type typeFromHandle2 = typeof(SideBubbleUiController);
			list.Add(typeFromHandle2);
			_ignoreList = list;
		}
	}
}
