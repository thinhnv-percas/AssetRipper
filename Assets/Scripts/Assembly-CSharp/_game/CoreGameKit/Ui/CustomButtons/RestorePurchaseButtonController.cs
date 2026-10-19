using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.InitializationSystem.Runtime;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x2000563")]
	public class RestorePurchaseButtonController : MonoBehaviour, IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x2000564")]
		private sealed class _003CReenableButton_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001273")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001274")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001275")]
			[FieldOffset(Offset = "0x20")]
			public RestorePurchaseButtonController _003C_003E4__this;

			[Token(Token = "0x17000207")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600169D")]
				[Address(RVA = "0x3D1F4D0", Offset = "0x3D1F4D0", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000208")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600169F")]
				[Address(RVA = "0x3D1F518", Offset = "0x3D1F518", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600169A")]
			[Address(RVA = "0x3D1F1EC", Offset = "0x3D1F1EC", Length = "0x2C")]
			public _003CReenableButton_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600169B")]
			[Address(RVA = "0x3D1F448", Offset = "0x3D1F448", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600169C")]
			[Address(RVA = "0x3D1F44C", Offset = "0x3D1F44C", Length = "0x84")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RestorePurchaseButtonController._003CReenableButton_003Ed__10::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600169E")]
			[Address(RVA = "0x3D1F4D8", Offset = "0x3D1F4D8", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400126E")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton _btn;

		[Token(Token = "0x400126F")]
		[FieldOffset(Offset = "0x28")]
		private readonly WaitForSeconds _1sec;

		[Token(Token = "0x4001270")]
		[FieldOffset(Offset = "0x30")]
		private IAPStoreService _iapStoreService;

		[Token(Token = "0x4001271")]
		[FieldOffset(Offset = "0x38")]
		private EventBus _eventBus;

		[Inject(true)]
		[Token(Token = "0x4001272")]
		[FieldOffset(Offset = "0x40")]
		private HoveringTextController _hoveringText;

		[Inject(false)]
		[Token(Token = "0x6001691")]
		[Address(RVA = "0x3D1EDA4", Offset = "0x3D1EDA4", Length = "0x154")]
		private void Inject(IAPStoreService iapStoreService, EventBus eventBus)
		{
			//IL_002e: Expected O, but got I
			UncoButton component = GetComponent<UncoButton>();
			_btn = component;
			_iapStoreService = iapStoreService;
			_eventBus = eventBus;
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v4 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v13+E4]");
			Type type = (((nint)0 == 0) ? typeof(IAPStoreService) : typeof(IAPStoreService));
			if (InitializationManager.IsInitialized(type))
			{
				RegisterButton();
			}
			else
			{
				this.Listen();
			}
		}

		[OnInitialize(new Type[] { typeof(IAPStoreService) })]
		[Token(Token = "0x6001692")]
		[Address(RVA = "0x3D1F07C", Offset = "0x3D1F07C", Length = "0x8")]
		private void OnInitialize(IAPStoreService iapStoreService)
		{
			Inject(iapStoreService, _eventBus);
		}

		[Token(Token = "0x6001693")]
		[Address(RVA = "0x3D1F084", Offset = "0x3D1F084", Length = "0x78")]
		private void OnRestoreSucceed(UventPurchaseRestoreSucceed evt)
		{
			if ((object)_hoveringText != null)
			{
				_hoveringText.Display("Purchases Restored!");
			}
		}

		[Token(Token = "0x6001694")]
		[Address(RVA = "0x3D1F0FC", Offset = "0x3D1F0FC", Length = "0x78")]
		private void OnRestoreFailed(UventPurchaseRestoreFailed evt)
		{
			if ((object)_hoveringText != null)
			{
				_hoveringText.Display("Restore Failed");
			}
		}

		[Token(Token = "0x6001695")]
		[Address(RVA = "0x3D1EEF8", Offset = "0x3D1EEF8", Length = "0x184")]
		private void RegisterButton()
		{
			Action<UventPurchaseRestoreSucceed> observer = OnRestoreSucceed;
			_eventBus.ListenEvent(observer);
			Action<UventPurchaseRestoreFailed> observer2 = OnRestoreFailed;
			_eventBus.ListenEvent(observer2);
			Action clickAction = delegate
			{
				_iapStoreService.Restore();
				_003CReenableButton_003Ed__10 _003CReenableButton_003Ed__11 = (_003CReenableButton_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CReenableButton_003Ed__10));
				_003CReenableButton_003Ed__11._003C_003E1__state = 0;
				_003CReenableButton_003Ed__11._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(_003CReenableButton_003Ed__11);
			};
			_btn.AddListener(clickAction);
		}

		[IteratorStateMachine(typeof(_003CReenableButton_003Ed__10))]
		[Token(Token = "0x6001696")]
		[Address(RVA = "0x3D1F174", Offset = "0x3D1F174", Length = "0x78")]
		private IEnumerator ReenableButton()
		{
			_003CReenableButton_003Ed__10 _003CReenableButton_003Ed__11 = (_003CReenableButton_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CReenableButton_003Ed__10));
			_003CReenableButton_003Ed__11._003C_003E1__state = 0;
			_003CReenableButton_003Ed__11._003C_003E4__this = this;
			return _003CReenableButton_003Ed__11;
		}

		[Token(Token = "0x6001697")]
		[Address(RVA = "0x3D1F218", Offset = "0x3D1F218", Length = "0x120")]
		public void Dispose()
		{
			Action<UventPurchaseRestoreSucceed> observer = OnRestoreSucceed;
			_eventBus.RemoveListener(observer);
			Action<UventPurchaseRestoreFailed> observer2 = OnRestoreFailed;
			_eventBus.RemoveListener(observer2);
		}

		[Token(Token = "0x6001698")]
		[Address(RVA = "0x3D1F338", Offset = "0x3D1F338", Length = "0x7C")]
		public RestorePurchaseButtonController()
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
			_1sec = waitForSeconds;
		}
	}
}
