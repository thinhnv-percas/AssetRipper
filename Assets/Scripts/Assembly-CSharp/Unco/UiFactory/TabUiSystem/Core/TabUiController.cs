using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using PrimeTween;
using Unco.UiFactory.TabUiSystem.Interfaces;
using UnityEngine;
using _game.CoreGameKit.MenuLayer;
using _game.CoreGameKit.UiControllers;

namespace Unco.UiFactory.TabUiSystem.Core
{
	[Token(Token = "0x2000792")]
	public class TabUiController : UIController
	{
		[CompilerGenerated]
		[Token(Token = "0x2000794")]
		private sealed class _003CInitSelectorPosition_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400191F")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001920")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001921")]
			[FieldOffset(Offset = "0x20")]
			public TabUiController _003C_003E4__this;

			[Token(Token = "0x17000312")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001FF9")]
				[Address(RVA = "0x3D954EC", Offset = "0x3D954EC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000313")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001FFB")]
				[Address(RVA = "0x3D95534", Offset = "0x3D95534", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001FF6")]
			[Address(RVA = "0x3D94B0C", Offset = "0x3D94B0C", Length = "0x2C")]
			public _003CInitSelectorPosition_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001FF7")]
			[Address(RVA = "0x3D95294", Offset = "0x3D95294", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001FF8")]
			[Address(RVA = "0x3D95298", Offset = "0x3D95298", Length = "0x254")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						TabUiController tabUiController = _003C_003E4__this;
						_003C_003E1__state = -1;
						Predicate<BaseTabUiElement> match = delegate(BaseTabUiElement x)
						{
							HomeTabId tabUiId = x.TabUiId;
							int num = tabUiId - _003C_003E4__this.m_defaultTabId;
							return num == 0;
						};
						UnityEngine.Object obj = tabUiController.m_tabUiElements.Find(match);
						UnityEngine.Object obj2;
						if (!(obj == null))
						{
							obj2 = obj;
						}
						else
						{
							List<BaseTabUiElement> tabUiElements = tabUiController.m_tabUiElements;
							bool flag = tabUiElements.Count < 1;
							obj2 = obj;
							if (!flag)
							{
								int index = tabUiElements.Count >> 1;
								BaseTabUiElement baseTabUiElement = tabUiElements[index];
								obj2 = baseTabUiElement;
							}
						}
						if (!(obj2 == null) && !(tabUiController.m_selector == null))
						{
							float selectorTargetX = _003C_003E4__this.GetSelectorTargetX((BaseTabUiElement)obj2);
							Vector2 anchoredPosition = tabUiController.m_selector.anchoredPosition;
							Vector2 anchoredPosition2 = default(Vector2);
							anchoredPosition2.x = selectorTargetX;
							anchoredPosition2.y = anchoredPosition.y;
							tabUiController.m_selector.anchoredPosition = anchoredPosition2;
						}
					}
				}
				else
				{
					_003C_003E2__current = null;
					_003C_003E1__state = -1;
					_003C_003E1__state = 1;
				}
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001FFA")]
			[Address(RVA = "0x3D954F4", Offset = "0x3D954F4", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001915")]
		[FieldOffset(Offset = "0x48")]
		private HomeTabId m_defaultTabId;

		[SerializeField]
		[Token(Token = "0x4001916")]
		[FieldOffset(Offset = "0x50")]
		private List<BaseTabUiElement> m_tabUiElements;

		[Token(Token = "0x4001917")]
		[FieldOffset(Offset = "0x58")]
		private HomeTabId _activeTabId;

		[SerializeField]
		[Token(Token = "0x4001918")]
		[FieldOffset(Offset = "0x60")]
		private RectTransform m_selector;

		[SerializeField]
		[Token(Token = "0x4001919")]
		[FieldOffset(Offset = "0x68")]
		private float m_selectorXScale;

		[SerializeField]
		[Token(Token = "0x400191A")]
		[FieldOffset(Offset = "0x6C")]
		private float m_selectorDuration;

		[SerializeField]
		[Token(Token = "0x400191B")]
		[FieldOffset(Offset = "0x70")]
		private Ease m_selectorEase;

		[Token(Token = "0x400191C")]
		[FieldOffset(Offset = "0x78")]
		private Sequence _selectorSequence;

		[Token(Token = "0x6001FEC")]
		[Address(RVA = "0x3D94A0C", Offset = "0x3D94A0C", Length = "0x88")]
		private void Start()
		{
			_activeTabId = m_defaultTabId;
			_003CInitSelectorPosition_003Ed__9 _003CInitSelectorPosition_003Ed__10 = (_003CInitSelectorPosition_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CInitSelectorPosition_003Ed__9));
			_003CInitSelectorPosition_003Ed__10._003C_003E1__state = 0;
			_003CInitSelectorPosition_003Ed__10._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CInitSelectorPosition_003Ed__10);
		}

		[IteratorStateMachine(typeof(_003CInitSelectorPosition_003Ed__9))]
		[Token(Token = "0x6001FED")]
		[Address(RVA = "0x3D94A94", Offset = "0x3D94A94", Length = "0x78")]
		private IEnumerator InitSelectorPosition()
		{
			_003CInitSelectorPosition_003Ed__9 _003CInitSelectorPosition_003Ed__10 = (_003CInitSelectorPosition_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CInitSelectorPosition_003Ed__9));
			_003CInitSelectorPosition_003Ed__10._003C_003E1__state = 0;
			_003CInitSelectorPosition_003Ed__10._003C_003E4__this = this;
			return _003CInitSelectorPosition_003Ed__10;
		}

		[Token(Token = "0x6001FEE")]
		[Address(RVA = "0x3D94B38", Offset = "0x3D94B38", Length = "0x230")]
		public void SelectTab(HomeTabId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabUiController::SelectTab");
		}

		[Token(Token = "0x6001FEF")]
		[Address(RVA = "0x3D94D70", Offset = "0x3D94D70", Length = "0x254")]
		private void MoveSelectorTo(BaseTabUiElement tab)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabUiController::MoveSelectorTo");
		}

		[Token(Token = "0x6001FF0")]
		[Address(RVA = "0x3D94FC4", Offset = "0x3D94FC4", Length = "0x1D8")]
		private float GetSelectorTargetX(BaseTabUiElement tab)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabUiController::GetSelectorTargetX");
			return default;
		}

		[Token(Token = "0x6001FF1")]
		[Address(RVA = "0x3D9519C", Offset = "0x3D9519C", Length = "0x24")]
		public TabUiController()
		{
			m_defaultTabId = HomeTabId.PlayTab;
			m_selectorXScale = 0.95f;
			m_selectorDuration = 0.2f;
			m_selectorEase = Ease.OutCubic;
		}
	}
}
