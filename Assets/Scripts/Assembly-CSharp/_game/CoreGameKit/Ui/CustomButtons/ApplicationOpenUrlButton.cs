using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Systems.RemoteManagementSystem.ScriptableObjects;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using Unco.UncoButtonSystem;
using UnityEngine;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x200055F")]
	public class ApplicationOpenUrlButton : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000560")]
		private sealed class _003CReEnableAfterCooldown_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001265")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001266")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001267")]
			[FieldOffset(Offset = "0x20")]
			public ApplicationOpenUrlButton _003C_003E4__this;

			[Token(Token = "0x17000205")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001686")]
				[Address(RVA = "0x3D1E728", Offset = "0x3D1E728", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000206")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001688")]
				[Address(RVA = "0x3D1E770", Offset = "0x3D1E770", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001683")]
			[Address(RVA = "0x3D1E4C0", Offset = "0x3D1E4C0", Length = "0x2C")]
			public _003CReEnableAfterCooldown_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001684")]
			[Address(RVA = "0x3D1E630", Offset = "0x3D1E630", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001685")]
			[Address(RVA = "0x3D1E634", Offset = "0x3D1E634", Length = "0xF4")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ApplicationOpenUrlButton._003CReEnableAfterCooldown_003Ed__6::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001687")]
			[Address(RVA = "0x3D1E730", Offset = "0x3D1E730", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001261")]
		[FieldOffset(Offset = "0x20")]
		private string _url;

		[SerializeField]
		[Token(Token = "0x4001262")]
		[FieldOffset(Offset = "0x28")]
		private RemoteConfig _config;

		[SerializeField]
		[Token(Token = "0x4001263")]
		[FieldOffset(Offset = "0x30")]
		private UncoButton m_button;

		[Token(Token = "0x4001264")]
		[FieldOffset(Offset = "0x38")]
		private readonly WaitForSeconds _cooldown;

		[Inject(false)]
		[Token(Token = "0x600167E")]
		[Address(RVA = "0x3D1E20C", Offset = "0x3D1E20C", Length = "0x1A0")]
		private void Inject(RemoteConfigManager remoteConfigManager)
		{
			if (_config != null)
			{
				RemoteConfig config = _config;
				if (Enum.TryParse<RemoteKey>(config.Key, ignoreCase: true, out var result))
				{
					string url = remoteConfigManager.GetString(result);
					_url = url;
				}
			}
			Action clickAction = delegate
			{
				Application.OpenURL(_url);
				_003CReEnableAfterCooldown_003Ed__6 _003CReEnableAfterCooldown_003Ed__7 = (_003CReEnableAfterCooldown_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CReEnableAfterCooldown_003Ed__6));
				_003CReEnableAfterCooldown_003Ed__7._003C_003E1__state = 0;
				_003CReEnableAfterCooldown_003Ed__7._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(_003CReEnableAfterCooldown_003Ed__7);
			};
			m_button.AddListener(clickAction);
		}

		[Token(Token = "0x600167F")]
		[Address(RVA = "0x3D1E3AC", Offset = "0x3D1E3AC", Length = "0x9C")]
		private void RegisterListener()
		{
			Action clickAction = delegate
			{
				Application.OpenURL(_url);
				_003CReEnableAfterCooldown_003Ed__6 _003CReEnableAfterCooldown_003Ed__7 = (_003CReEnableAfterCooldown_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CReEnableAfterCooldown_003Ed__6));
				_003CReEnableAfterCooldown_003Ed__7._003C_003E1__state = 0;
				_003CReEnableAfterCooldown_003Ed__7._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(_003CReEnableAfterCooldown_003Ed__7);
			};
			m_button.AddListener(clickAction);
		}

		[IteratorStateMachine(typeof(_003CReEnableAfterCooldown_003Ed__6))]
		[Token(Token = "0x6001680")]
		[Address(RVA = "0x3D1E448", Offset = "0x3D1E448", Length = "0x78")]
		private IEnumerator ReEnableAfterCooldown()
		{
			_003CReEnableAfterCooldown_003Ed__6 _003CReEnableAfterCooldown_003Ed__7 = (_003CReEnableAfterCooldown_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CReEnableAfterCooldown_003Ed__6));
			_003CReEnableAfterCooldown_003Ed__7._003C_003E1__state = 0;
			_003CReEnableAfterCooldown_003Ed__7._003C_003E4__this = this;
			return _003CReEnableAfterCooldown_003Ed__7;
		}

		[Token(Token = "0x6001681")]
		[Address(RVA = "0x3D1E4EC", Offset = "0x3D1E4EC", Length = "0x7C")]
		public ApplicationOpenUrlButton()
		{
			WaitForSeconds cooldown = new WaitForSeconds(1f);
			_cooldown = cooldown;
		}
	}
}
