using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200096C")]
	public class ElephantPushElephantManager : IPushElephantAdapter, IElephantAdapter
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200096D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001FC7")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001FC8")]
			public static Func<bool> _003C_003E9__2_0;

			[Token(Token = "0x4001FC9")]
			public static Action<string> _003C_003E9__2_2;

			[Token(Token = "0x6002847")]
			[Address(RVA = "0x3E50D08", Offset = "0x3E50D08", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6002848")]
			[Address(RVA = "0x3E50D6C", Offset = "0x3E50D6C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CSendDeviceToken_003Eb__2_0()
			{
				ElephantCore instance = ElephantCore.Instance;
				return instance.sdkIsReady;
			}

			internal void _003CSendDeviceToken_003Eb__2_2(string s)
			{
				string message = default(string);
				ElephantLog.Log("SendDeviceToken", message);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200096E")]
		private sealed class _003CSendDeviceToken_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001FCA")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001FCB")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001FCC")]
			[FieldOffset(Offset = "0x20")]
			public ElephantPushElephantManager _003C_003E4__this;

			[Token(Token = "0x17000466")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600284E")]
				[Address(RVA = "0x3E5138C", Offset = "0x3E5138C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000467")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002850")]
				[Address(RVA = "0x3E513D4", Offset = "0x3E513D4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600284B")]
			[Address(RVA = "0x3E50768", Offset = "0x3E50768", Length = "0x2C")]
			public _003CSendDeviceToken_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600284C")]
			[Address(RVA = "0x3E50E4C", Offset = "0x3E50E4C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600284D")]
			[Address(RVA = "0x3E50E50", Offset = "0x3E50E50", Length = "0x53C")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantPushElephantManager._003CSendDeviceToken_003Ed__2::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600284F")]
			[Address(RVA = "0x3E51394", Offset = "0x3E51394", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4001FC6")]
		[FieldOffset(Offset = "0x10")]
		private string _deviceToken;

		[Token(Token = "0x6002840")]
		[Address(RVA = "0x3E50594", Offset = "0x3E50594", Length = "0x15C")]
		public void AskPushPermission()
		{
			ElephantLog.Log("PUSH-ELEPHANT", "AskPushPermission is Called");
			RemoteConfig instance = RemoteConfig.GetInstance();
			int num = instance.GetInt("push_delay_hour", 24);
			long num2 = Utils.Timestamp();
			ElephantCore instance2 = ElephantCore.Instance;
			int num3 = num * 3600000;
			long num4 = instance2.installTime + num3;
			if (num4 < num2)
			{
				ElephantIOS.getNotificationPermission();
			}
		}

		[IteratorStateMachine(typeof(_003CSendDeviceToken_003Ed__2))]
		[Token(Token = "0x6002841")]
		[Address(RVA = "0x3E506F0", Offset = "0x3E506F0", Length = "0x78")]
		private IEnumerator SendDeviceToken()
		{
			_003CSendDeviceToken_003Ed__2 _003CSendDeviceToken_003Ed__3 = (_003CSendDeviceToken_003Ed__2)FormatterServices.GetUninitializedObject(typeof(_003CSendDeviceToken_003Ed__2));
			_003CSendDeviceToken_003Ed__3._003C_003E1__state = 0;
			_003CSendDeviceToken_003Ed__3._003C_003E4__this = this;
			return _003CSendDeviceToken_003Ed__3;
		}

		[Token(Token = "0x6002842")]
		[Address(RVA = "0x3E50794", Offset = "0x3E50794", Length = "0x14C")]
		public void SetDeviceToken(string token)
		{
			ElephantLog.Log("PUSH-ELEPHANT", "SetDeviceToken is Called");
			ElephantLog.Log("SetDeviceToken", token);
			_deviceToken = token;
			_003CSendDeviceToken_003Ed__2 _003CSendDeviceToken_003Ed__3 = (_003CSendDeviceToken_003Ed__2)FormatterServices.GetUninitializedObject(typeof(_003CSendDeviceToken_003Ed__2));
			_003CSendDeviceToken_003Ed__3._003C_003E1__state = 0;
			_003CSendDeviceToken_003Ed__3._003C_003E4__this = this;
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(_003CSendDeviceToken_003Ed__3);
		}

		[Token(Token = "0x6002843")]
		[Address(RVA = "0x3E508E0", Offset = "0x3E508E0", Length = "0x200")]
		public void SendPushNotificationOpenEvent(string combinedIds)
		{
			ElephantLog.Log("PUSH-ELEPHANT", "SendPushNotificationOpenEvent is Called");
			string[] array = combinedIds.Split(';');
			if (array.Length < 4)
			{
				ElephantLog.Log("SendPushNotificationOpenEvent", "Invalid combinedIds format");
				return;
			}
			Params obj = Params.New();
			Params obj2 = obj.Set("notification_id", array[0]);
			Params obj3 = obj.Set("message_id", array[1]);
			Params obj4 = obj.Set("job_id", array[2]);
			Params obj5 = obj.Set("scheduled_at", array[3]);
			Elephant.Event("elephant_push_notification_open", -1, obj);
		}

		[Token(Token = "0x6002844")]
		[Address(RVA = "0x3E50AE0", Offset = "0x3E50AE0", Length = "0x110")]
		public void ReceiveNotificationPermission(string response)
		{
			ElephantLog.Log("PUSH-ELEPHANT", "ReceiveNotificationPermission is Called");
			Params obj = Params.New();
			Params obj2 = obj.Set("status", response);
			Elephant.Event("push_notification_permission", -1, obj);
		}

		[Token(Token = "0x6002845")]
		[Address(RVA = "0x3E50BF0", Offset = "0x3E50BF0", Length = "0x8")]
		public ElephantPushElephantManager()
		{
		}
	}
}
