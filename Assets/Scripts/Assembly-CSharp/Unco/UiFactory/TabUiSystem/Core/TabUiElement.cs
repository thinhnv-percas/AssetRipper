using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.UiFactory.TabUiSystem.Interfaces;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.MenuLayer;
using _game.CoreGameKit.UiControllers;

namespace Unco.UiFactory.TabUiSystem.Core
{
	[Token(Token = "0x2000795")]
	public class TabUiElement : BaseTabUiElement
	{
		[Token(Token = "0x4001922")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _manager;

		[Token(Token = "0x4001923")]
		[FieldOffset(Offset = "0x28")]
		private Instancer _instancer;

		[SerializeField]
		[Token(Token = "0x4001924")]
		[FieldOffset(Offset = "0x30")]
		private HomeTabId _tabUiId;

		[SerializeField]
		[Token(Token = "0x4001925")]
		[FieldOffset(Offset = "0x38")]
		private UncoButton m_button;

		[SerializeReference]
		[Token(Token = "0x4001926")]
		[FieldOffset(Offset = "0x40")]
		private ITabAction[] m_tabActions;

		[SerializeField]
		[Token(Token = "0x4001927")]
		[FieldOffset(Offset = "0x48")]
		private TabAction[] m_monoActions;

		[Token(Token = "0x17000314")]
		public override HomeTabId TabUiId
		{
			[Token(Token = "0x6001FFC")]
			[Address(RVA = "0x3D9553C", Offset = "0x3D9553C", Length = "0x8")]
			get
			{
				return _tabUiId;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001FFD")]
		[Address(RVA = "0x3D95544", Offset = "0x3D95544", Length = "0xC0")]
		private void InjectDependencies(UiManager manager, Instancer instancer)
		{
			UiManager manager2 = default(UiManager);
			_manager = manager2;
			_instancer = instancer;
			ITabAction[] tabActions = m_tabActions;
			if (tabActions.Length >= 1)
			{
				int num = 0;
				do
				{
					ITabAction tabAction = _instancer.InjectInstance(tabActions[num]);
					num++;
				}
				while (num < tabActions.Length);
			}
		}

		[Token(Token = "0x6001FFE")]
		[Address(RVA = "0x3D95604", Offset = "0x3D95604", Length = "0x9C")]
		public void Awake()
		{
			Action clickAction = delegate
			{
				TabUiController tabUiController = _manager.Get<TabUiController>();
				tabUiController.SelectTab(TabUiId);
			};
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001FFF")]
		[Address(RVA = "0x3D956A0", Offset = "0x3D956A0", Length = "0x160")]
		public override void OnSelectTab(HomeTabId from)
		{
			ITabAction[] tabActions = m_tabActions;
			int num = tabActions.Length;
			if (tabActions.Length >= 1)
			{
				int num2 = 0;
				ITabAction tabAction = null;
				do
				{
					if (tabActions[num2] != null)
					{
						tabAction = tabActions[num2];
					}
					if (tabActions[num2] != null)
					{
						tabAction.OnSelectTab(TabUiId, from);
						num = tabActions.Length;
					}
					num2++;
				}
				while (num2 < num);
			}
			TabAction[] monoActions = m_monoActions;
			int num3 = monoActions.Length;
			if (monoActions.Length < 1)
			{
				return;
			}
			int num4 = 0;
			do
			{
				if ((object)monoActions[num4] != null)
				{
					monoActions[num4].OnSelectTab(TabUiId, from);
					num3 = monoActions.Length;
				}
				num4++;
			}
			while (num4 < num3);
		}

		[Token(Token = "0x6002000")]
		[Address(RVA = "0x3D95800", Offset = "0x3D95800", Length = "0x164")]
		public override void OnDeselectTab(HomeTabId to)
		{
			ITabAction[] tabActions = m_tabActions;
			int num = tabActions.Length;
			if (tabActions.Length >= 1)
			{
				int num2 = 0;
				ITabAction tabAction = null;
				do
				{
					if (tabActions[num2] != null)
					{
						tabAction = tabActions[num2];
					}
					if (tabActions[num2] != null)
					{
						tabAction.OnDeselectTab(TabUiId, to);
						num = tabActions.Length;
					}
					num2++;
				}
				while (num2 < num);
			}
			TabAction[] monoActions = m_monoActions;
			int num3 = monoActions.Length;
			if (monoActions.Length < 1)
			{
				return;
			}
			int num4 = 0;
			do
			{
				if ((object)monoActions[num4] != null)
				{
					monoActions[num4].OnDeselectTab(TabUiId, to);
					num3 = monoActions.Length;
				}
				num4++;
			}
			while (num4 < num3);
		}

		[Token(Token = "0x6002001")]
		[Address(RVA = "0x3D95964", Offset = "0x3D95964", Length = "0x8")]
		public TabUiElement()
		{
		}
	}
}
