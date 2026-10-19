using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.CommonManagers;
using Unco.Notifications.Notifications;
using Unco.SettingsSystem.Core;
using Unco.Utils;
using Unity.Notifications.iOS;
using UnityEngine;
using _game.Scripts.Notifications;
using Debug = UnityEngine.Debug;

namespace Unco.Notifications
{
	[Token(Token = "0x200001E")]
	public class NotificationManager : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200001F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000074")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000075")]
			public static Func<string, PendingNotification, string> _003C_003E9__27_0;

			[Token(Token = "0x4000076")]
			public static Func<PendingNotification, DateTime?> _003C_003E9__32_0;

			[Token(Token = "0x60000E2")]
			[Address(RVA = "0x81BD9D0", Offset = "0x81BD9D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.Notifications.NotificationManager+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x81BDA34", Offset = "0x81BDA34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CGetAllPendingNotifications_003Eb__27_0(string current, PendingNotification notif)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager._003C_003Ec::_003CGetAllPendingNotifications_003Eb__27_0");
				return default;
			}

			internal DateTime? _003CCheckAndCancelNotifications_003Eb__32_0(PendingNotification n)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager._003C_003Ec::_003CCheckAndCancelNotifications_003Eb__32_0");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000020")]
		private sealed class _003CInitManager_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000077")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000078")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000079")]
			[FieldOffset(Offset = "0x20")]
			public NotificationManager _003C_003E4__this;

			[Token(Token = "0x17000033")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000E9")]
				[Address(RVA = "0x81BDF58", Offset = "0x81BDF58", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000034")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000EB")]
				[Address(RVA = "0x81BDFA0", Offset = "0x81BDFA0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x81BB0B4", Offset = "0x81BB0B4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CInitManager_003Ed__16(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x81BDD30", Offset = "0x81BDD30", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x81BDD34", Offset = "0x81BDD34", Length = "0x224")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv62 = this.<>1__state != 1;\n\tif (v62) goto L_00A3;\n\tthis.<>1__state = -1;\n\tv278 = _game.Scripts.Notifications.GameNotificationsManager::GetLastNotification(v48._manager);\n\tUnco.Notifications.NotificationManager::CheckOpenNotification(v48);\n\tv48._initialized = 1;\n\tUnco.Notifications.NotificationManager::LogNotification(v48);\n\tgoto L_00A3;\nL_003E:\n\tthis.<>1__state = -1;\n\tv148 = v48._manager;\n\t// 105 NewArr v204 @ X0_v17 (_game.Scripts.Notifications.GameNotificationChannel[]), typeof(_game.Scripts.Notifications.GameNotificationChannel[]), 1\n\t*([v204 @ X0_v17 (_game.Scripts.Notifications.GameNotificationChannel[])+20]) = v80;\n\t*([v204 @ X0_v17 (_game.Scripts.Notifications.GameNotificationChannel[])+30]) = \"Generic notifications\";\n\t*([v204 @ X0_v17 (_game.Scripts.Notifications.GameNotificationChannel[])+40]) = v286;\n\tgoto L_0088;\n\tv306 = UnityEngine.MonoBehaviour::StartCoroutine(v148.LocalNotificationExpired, v300);\n\tthis.<>2__current = v306;\n\tthis.<>1__state = 1;\nL_0020:\n\tv48 = this.<>4__this;\n\tv49 = this.<>1__state == 0;\n\tif (v49) goto L_003E;\nL_00A3:\n\tv155 = this.<>1__state == 0;\n\treturn v155;\nL_0088:\n\tv300 = new _game.Scripts.Notifications.GameNotificationsManager+<Initialize>d__35();\n\tSystem.Object::.ctor(v300);\n\tv300.<>1__state = 0;\n\tv300.<>4__this = v48._manager;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager._003CInitManager_003Ed__16::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x81BDF60", Offset = "0x81BDF60", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400006A")]
		private const string ChannelId = "game_channel0";

		[Token(Token = "0x400006B")]
		private const string NotifAsked = "notif_request_asked";

		[Token(Token = "0x400006C")]
		private const string IsOldUser = "update_check_asked";

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x20")]
		private int _isOldUser;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x24")]
		private bool _initialized;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x28")]
		private GameNotificationsManager _manager;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x30")]
		private CoroutineManager _coroutineManager;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x38")]
		private IGameNotificationConfig _notificationConfig;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x40")]
		private SettingsManager _settingsManager;

		[Token(Token = "0x4000073")]
		private static readonly Dictionary<IGameNotification.GameNotificationType, double> notificationCooldowns = new Dictionary<IGameNotification.GameNotificationType, double>
		{
			{
				IGameNotification.GameNotificationType.NoShieldsHeadsUp,
				1.0
			},
			{
				IGameNotification.GameNotificationType.ShopDailyFree,
				1.0
			}
		};

		[Token(Token = "0x17000032")]
		public bool IsNotificationEnabled
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x81BAEC8", Offset = "0x81BAEC8", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._settingsManager == 0;\n\tif (v13) goto L_0020;\n\tv15 = Unco.SettingsSystem.Core.SettingsManager::get_IsNotificationPermissionGranted(this._settingsManager);\n\tv19 = ~v15;\n\tif (v19) goto L_0020;\n\treturnVal2 = Unco.SettingsSystem.Core.SettingsManager::IsEnabled(this._settingsManager, 0x20);\n\treturn returnVal2;\nL_0020:\n\treturn 0;\n")]
			get
			{
				if (_settingsManager != null && _settingsManager.IsNotificationPermissionGranted)
				{
					return _settingsManager.IsEnabled(SettingsFlags.Notification);
				}
				return false;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x81BA770", Offset = "0x81BA770", Length = "0x6CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0050;\nL_0050:\n\tgoto L_007B;\nL_0087:\n\tv371 = System.Boolean::ToString(&v70 @ stack_-61_v4 (System.Boolean));\n\tv456 = System.String::Concat(\"[NotificationManager] Injecting NotificationManager with config: \", v371);\n\tgoto L_0096;\n\tthis._notificationConfig = notificationConfig;\n\tthis._settingsManager = settingsManager;\n\tv492 = notificationConfig->klass;\n\tv537 = notificationConfig->klass->interface_offsets_count;\n\tv494 = *([v492 @ X8_v11 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+12E]) == 0;\n\tif (v494) goto L_00D2;\n\tv536 = *([v492 @ X8_v11 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+B0]) + 8;\n\tv536 = v536 + 0x10;\n\tv522 = v537 - 1;\n\tv502 = v537 != 1;\nL_FFFFFFFF:\n\tv537 = v522;\n\tif (v502) goto L_00B9;\nL_00D2:\n\tv550 = Unco.Notifications.Notifications.IGameNotificationConfig::get_EnablePushNotifications(notificationConfig);\n\tv551 = v550 & 1;\n\tv552 = v551 == 0;\n\tif (v552) goto L_0117;\nL_00DA:\n\tUnco.SettingsSystem.Core.SettingsManager::InitializeNotificationPermission(this._settingsManager);\n\tv177 = this._settingsManager;\n\tv642 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v642, this, Il2CppMethodInfo);\n\tv684 = System.Delegate::Combine(v177.OnNotificationPermissionChanged, v642);\n\tv691 = v684 == 0;\n\tif (v691) goto L_0137;\n\tv243 = 0x21C11D0(v684, System.Action`1<System.Boolean>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv246 = v243 == 0;\n\tif (v246) goto L_0248;\n\tv177.OnNotificationPermissionChanged = v243;\n\tv244 = 0x21C11D0(v684, System.Action`1<System.Boolean>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv247 = v244 == 0;\n\tif (v247) goto L_0248;\n\tv720 = this._settingsManager;\n\tv734 = this._settingsManager == 0;\n\tv156 = ~v734;\n\tif (v156) goto L_0142;\n\tgoto L_0245;\nL_0107:\n\tv555 = *([v536 @ X10_v25]) + 2;\n\tv556 = v555 << 4;\n\tv557 = v492 + v556;\n\tv558 = v557 + 0x138;\n\t*([v558 @ X0_v125])(v562, notificationConfig, *([v558 @ X0_v125+8]), 0, notificationConfig, settingsManager, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv563 = v562 & 1;\n\tv564 = v563 == 0;\n\tv565 = ~v564;\n\tif (v565) goto L_00DA;\nL_0117:\n\tgoto L_0208;\nL_0137:\n\tv177.OnNotificationPermissionChanged = 0;\n\tv720 = this._settingsManager;\nL_0142:\n\tv725 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v725, this, Il2CppMethodInfo);\n\tv733 = System.Delegate::Combine(v720.OnNotificationChanged, v725);\n\tv735 = v733 == 0;\n\tif (v735) goto L_01A1;\n\tv308 = 0x21C11D0(v733, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv311 = v308 == 0;\n\tif (v311) goto L_024B;\n\tv720.OnNotificationChanged = v308;\n\tv309 = 0x21C11D0(v733, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv312 = v309 == 0;\n\tif (v312) goto L_024B;\n\tgoto L_0168;\nL_0168:\n\tUnityEngine.Debug::Log(\" NotificationManager Injected\");\n\tgoto L_0179;\nL_017C:\n\tv782 = UnityEngine.Object::op_Inequality(v774.Instance, 0);\n\tv786 = ~v782;\n\tv787 = ~v786;\n\tif (v787) goto L_01B8;\n\tv186 = 0xB29A000 + 0xBF8;\nL_FFFFFFFF:\n\tv168 = this._coroutineManager;\n\tgoto L_018F;\n\tv708 = UnityEngine.MonoBehaviour::StartCoroutine(v168, v867);\n\tgoto L_0232;\nL_01A1:\n\tv720.OnNotificationChanged = 0;\n\tgoto L_0168;\nL_01B8:\n\tgoto L_01BE;\nL_01BE:\n\tUnityEngine.Debug::Log(\" Asking push permission from ElephantSDK\");\n\tv878 = new ElephantSDK.OnNotificationOpened();\n\tElephantSDK.OnNotificationOpened::.ctor(v878, this, Il2CppMethodInfo);\n\tgoto L_01D2;\nL_01D2:\n\tElephantSDK.ElephantCore::add_onNotificationOpened(v878);\n\tv165 = v892.Instance;\n\tgoto L_023B;\nL_0212:\n\tv681 = System.Boolean::ToString(&v70 @ stack_-61_v4 (System.Boolean));\n\tv700 = System.String::Concat(\"[NotificationManager]\", v681);\n\tgoto L_0223;\nL_0232:\n\treturn this;\nL_FFFFFFFF:\n\tv168 = this._coroutineManager;\n\tgoto L_018F;\nL_0245:\n\tthrow System.NullReferenceException;\nL_0248:\n\tthrow System.InvalidCastException;\nL_024B:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_007B:\n\tv358 = Unco.Notifications.Notifications.IGameNotificationConfig::get_EnablePushNotifications(notificationConfig);\n\tv70 = v358;\n\tgoto L_0087;\nL_0096:\n\tUnityEngine.Debug::LogWarning(v456);\n\tthis._coroutineManager = coroutineManager;\n\tthis._manager = manager;\nL_00B9:\n\tv542 = *([v536 @ X10_v25-8]) == Unco.Notifications.Notifications.IGameNotificationConfig;\n\tif (v542) goto L_0107;\nL_0208:\n\tv668 = Unco.Notifications.Notifications.IGameNotificationConfig::get_EnablePushNotifications(notificationConfig);\n\tv70 = v668;\n\tgoto L_0212;\nL_0179:\n\tgoto L_017C;\nL_018F:\n\tv867 = new *([v186 @ X22_v14 (System.Int32)])();\n\tSystem.Object::.ctor(v867);\n\t*([v867 @ X0_v73 (System.Object)+10]) = 0;\n\t*([v867 @ X0_v73 (System.Object)+20]) = this;\nL_023B:\n\tElephantSDK.IPushElephantAdapter::AskPushPermission(v165.PushElephantAdapter);\n\tv186 = 0xB29A000 + 0xBF8;\n\tgoto L_FFFFFFFF;\nL_0223:\n\tUnityEngine.Debug::Log(v700);\n")]
		public NotificationManager Inject(GameNotificationsManager manager, CoroutineManager coroutineManager, IGameNotificationConfig notificationConfig, SettingsManager settingsManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::Inject");
			return default;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x81BAF1C", Offset = "0x81BAF1C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = granted == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tUnco.Notifications.NotificationManager::CancelAllPendingNotifications(this);\n\treturn;\n")]
		private void OnNotificationPermissionChanged(bool granted)
		{
			if (!granted)
			{
				CancelAllPendingNotifications();
			}
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x81BB030", Offset = "0x81BB030", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = state == 0;\n\tif (v0) goto L_0003;\n\treturn;\nL_0003:\n\tUnco.Notifications.NotificationManager::CancelAllPendingNotifications(this);\n\treturn;\n")]
		private void OnNotificationSettingChanged(int state)
		{
			if (state == 0)
			{
				CancelAllPendingNotifications();
			}
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x81BAF28", Offset = "0x81BAF28", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._manager, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0041;\n\tgoto L_0063;\nL_0041:\n\tv90 = this._initialized != 1;\n\tif (v90) goto L_0063;\n\t_game.Scripts.Notifications.GameNotificationsManager::CancelAllNotifications(this._manager);\n\tgoto L_005A;\nL_005A:\n\tUnityEngine.Debug::Log(\" All pending notifications cancelled.\");\n\treturn;\nL_0063:\n\treturn;\n")]
		public void CancelAllPendingNotifications()
		{
			if (!(_manager == null) && _initialized)
			{
				_manager.CancelAllNotifications();
				Debug.Log(" All pending notifications cancelled.");
			}
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x81BAE3C", Offset = "0x81BAE3C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv63 = UnityEngine.MonoBehaviour::StartCoroutine(this._coroutineManager, v46);\n\treturn;\nL_0018:\n\tv46 = new Unco.Notifications.NotificationManager+<InitManager>d__16();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		private void OnAccountStatusInit()
		{
			_003CInitManager_003Ed__16 _003CInitManager_003Ed__17 = (_003CInitManager_003Ed__16)FormatterServices.GetUninitializedObject(typeof(_003CInitManager_003Ed__16));
			_003CInitManager_003Ed__17._003C_003E1__state = 0;
			_003CInitManager_003Ed__17._003C_003E4__this = this;
			Coroutine coroutine = _coroutineManager.StartCoroutine(_003CInitManager_003Ed__17);
		}

		[IteratorStateMachine(typeof(_003CInitManager_003Ed__16))]
		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x81BB03C", Offset = "0x81BB03C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.Notifications.NotificationManager+<InitManager>d__16();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator InitManager()
		{
			_003CInitManager_003Ed__16 _003CInitManager_003Ed__17 = (_003CInitManager_003Ed__16)FormatterServices.GetUninitializedObject(typeof(_003CInitManager_003Ed__16));
			_003CInitManager_003Ed__17._003C_003E1__state = 0;
			_003CInitManager_003Ed__17._003C_003E4__this = this;
			return _003CInitManager_003Ed__17;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x81BB0E0", Offset = "0x81BB0E0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv44 = _game.Scripts.Notifications.GameNotificationsManager::GetLastNotification(this._manager);\n\tv49 = v44 == 0;\n\tif (v49) goto L_0057;\n\tv57 = *([v44 @ X0_v4 (_game.Scripts.Notifications.IGameNotification)]);\n\tv204 = *([v57 @ X8_v12 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv59 = *([v57 @ X8_v12 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v59) goto L_004B;\n\tv203 = *([v57 @ X8_v12 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv203 = v203 + 0x10;\n\tv186 = v204 - 1;\n\tv166 = v204 != 1;\n\tv204 = v186;\n\tif (v166) goto L_0031;\nL_004B:\n\tv218 = _game.Scripts.Notifications.IGameNotification::get_message_id(v44);\n\tgoto L_00BD;\nL_0057:\n\tgoto L_0059;\nL_0059:\n\tv191 = UnityEngine.Application::get_platform();\n\tv232 = v191 != 8;\n\tif (v232) goto L_008D;\n\tgoto L_00BD;\nL_0067:\n\tv237 = *([v203 @ X10_v6]) + 0xE;\n\tv238 = v237 << 4;\n\tv239 = v57 + v238;\n\tv240 = v239 + 0x138;\n\t*([v240 @ X8_v17])(v243, v44, *([v240 @ X8_v17+8]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_00BD;\nL_008D:\n\tv283 = System.String::IsNullOrEmpty(v286.NOTIFICATION_SOURCE);\n\tv298 = v283 == 0;\n\tv285 = ~v298;\n\tif (v285) goto L_00BD;\n\tgoto L_0097;\nL_0097:\n\tv284 = UnityEngine.Application::get_platform();\n\tv249 = v284 != 0xB;\n\tif (v249) goto L_00BD;\n\tUnco.Notifications.NotificationManager::OnNotificationOpened(this);\n\treturn;\nL_00BD:\n\treturn;\nL_0031:\n\tv209 = *([v203 @ X10_v6-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v209) goto L_0067;\n")]
		private void CheckOpenNotification()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::CheckOpenNotification");
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x81BB288", Offset = "0x81BB288", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = UnityEngine.Application::get_platform();\n\tv67 = v50 != 0xB;\n\tif (v67) goto L_0045;\n\tgoto L_0092;\nL_0045:\n\tv94 = this._notificationConfig;\n\tv170 = *([v94 @ X19_v6 (Unco.Notifications.Notifications.IGameNotificationConfig)]);\n\tv207 = *([v170 @ X8_v10 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+12E]);\n\tv172 = *([v170 @ X8_v10 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+12E]) == 0;\n\tif (v172) goto L_006F;\n\tv110 = *([v170 @ X8_v10 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+B0]) + 8;\n\tv110 = v110 + 0x10;\n\tv192 = v207 - 1;\n\tv193 = v207 != 1;\n\tv207 = v192;\n\tif (v193) goto L_0056;\nL_006F:\n\tv149 = Unco.Notifications.Notifications.IGameNotificationConfig::get_IgnoreElephantNotifsIos(v94);\n\tv218 = v149 & 1;\n\tv152 = v218 == 0;\n\tif (v152) goto L_0092;\nL_007A:\n\treturn;\nL_007C:\n\tv114 = *([v110 @ X10_v6]) + 3;\n\tv105 = v114 << 4;\n\tv269 = v170 + v105;\n\tv270 = v269 + 0x138;\n\t*([v270 @ X0_v14])(v148, v94, *([v270 @ X0_v14+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv272 = v148 & 1;\n\tv273 = v272 == 0;\n\tv151 = ~v273;\n\tif (v151) goto L_007A;\nL_0092:\n\tgoto L_0097;\nL_0097:\n\tv181.NOTIFICATION_SOURCE = \"\";\n\treturn;\nL_0056:\n\tv136 = *([v110 @ X10_v6-8]) == Unco.Notifications.Notifications.IGameNotificationConfig;\n\tif (v136) goto L_007C;\n")]
		private void OnNotificationOpened()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::OnNotificationOpened");
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x81BB40C", Offset = "0x81BB40C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void HandleNotificationBehaviour(string action)
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x81BB410", Offset = "0x81BB410", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv48 = this._settingsManager == 0;\n\tif (v48) goto L_0027;\n\tUnco.SettingsSystem.Core.SettingsManager::RefreshNotificationPermission(this._settingsManager);\nL_0027:\n\tUnco.Notifications.NotificationManager::LogNotification(this);\n\treturn;\nL_0033:\n\tv59 = this._initialized != 1;\n\tif (v59) goto L_004E;\n\tv70 = this._settingsManager == 0;\n\tif (v70) goto L_0055;\n\tv86 = Unco.SettingsSystem.Core.SettingsManager::get_IsNotificationPermissionGranted(this._settingsManager);\n\tv92 = ~v86;\n\tif (v92) goto L_0055;\n\tv166 = this._settingsManager == 0;\n\tif (v166) goto L_0064;\n\tv90 = Unco.SettingsSystem.Core.SettingsManager::IsEnabled(this._settingsManager, 0x20);\n\tv78 = v90 == 0;\n\tif (v78) goto L_0055;\n\tUnco.Notifications.NotificationManager::SummonUser(this);\nL_004E:\n\treturn;\nL_0055:\n\tgoto L_0062;\nL_0062:\n\tUnityEngine.Debug::Log(\" Skipping notification scheduling on app close. Notifications are disabled.\");\n\treturn;\nL_0064:\n\tv167 = new System.NullReferenceException();\n\tv155 = v167;\n\tgoto L_009D;\n\tv172 = 0x8BF5BC4(v167, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = 0xB28E000 + 0x98;\n\tv186 = *([v172 @ X0_v17]);\n\tv188 = \"il2cpp_vm_class_is_assignable_from\"(v184, *([v186 @ X8_v10]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = v188 == 0;\n\tif (v177) goto L_0092;\n\tv190 = 0x8BF5BF4(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_008F;\nL_008F:\n\tUnityEngine.Debug::LogException(*([v172 @ X0_v17]));\n\treturn;\nL_0092:\n\tv192 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v192 @ X0_v23]) = *([v172 @ X0_v17]);\n\tv174 = 0xA67A000 + 0x440;\n\tv197 = 0x8BF5C48(v192, v174, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv176 = 0x8BF5BF4(v197, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = v197;\nL_009D:\n\tv181 = 0x8BF0368(v155, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = 0x7C03E68(v181, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0018:\n\tv44 = ~v61;\n\tif (v44) goto L_0033;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool hasFocus)
		{
			bool flag = default(bool);
			if (flag)
			{
				if (_settingsManager != null)
				{
					_settingsManager.RefreshNotificationPermission();
				}
				LogNotification();
			}
			else
			{
				if (!_initialized)
				{
					return;
				}
				if (_settingsManager != null && _settingsManager.IsNotificationPermissionGranted)
				{
					if (_settingsManager == null)
					{
						NullReferenceException ex = new NullReferenceException();
						NullReferenceException ex2 = ex;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @7C03E68 (inside Spine.Unity.Examples.SkeletonRagdoll2D+<Start>d__35::System.Collections.IEnumerator.get_Current +0x8)");
						return;
					}
					if (_settingsManager.IsEnabled(SettingsFlags.Notification))
					{
						SummonUser();
						return;
					}
				}
				Debug.Log(" Skipping notification scheduling on app close. Notifications are disabled.");
			}
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x81BB5AC", Offset = "0x81BB5AC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_002D;\nL_002D:\n\tv68 = UnityEngine.Object::op_Equality(this._manager, 0);\n\tv81 = ~v68;\n\tif (v81) goto L_0066;\n\tgoto L_0041;\nL_0041:\n\tUnityEngine.Debug::LogError(\" Manager is null.\");\n\treturn;\nL_0048:\n\tgoto L_0052;\nL_0052:\n\tUnityEngine.Debug::LogWarning(\" Manager is not initialized.\");\n\treturn;\nL_0066:\n\tv124 = _game.Scripts.Notifications.GameNotificationsManager::GetLastNotification(this._manager);\n\treturn;\nL_0021:\n\tv47 = this._initialized == 0;\n\tif (v47) goto L_0048;\n")]
		private void LogNotification()
		{
			if (_initialized)
			{
				if (_manager == null)
				{
					Debug.LogError(" Manager is null.");
				}
				else
				{
					IGameNotification lastNotification = _manager.GetLastNotification();
				}
			}
			else
			{
				Debug.LogWarning(" Manager is not initialized.");
			}
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x81BB90C", Offset = "0x81BB90C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_0025;\nL_0025:\n\tv62 = System.DateTime::get_UtcNow();\n\tgoto L_003C;\nL_002F:\n\tgoto L_0032;\nL_0032:\n\tv66 = System.DateTime::get_Now();\n\tgoto L_003C;\nL_003C:\n\tv88 = System.DateTime::get_Year(&v86 @ stack_-48_v2 (System.DateTime));\n\tv94 = System.DateTime::get_Month(&v86 @ stack_-48_v2 (System.DateTime));\n\tv99 = System.DateTime::get_Day(&v86 @ stack_-48_v2 (System.DateTime));\n\tSystem.DateTime::.ctor(&v103 @ stack_-50_v2 (System.DateTime), v88, v94, v99, hour, minute, 0, 2);\n\tv113 = System.DateTime::op_LessThan(v103, v86);\n\tv115 = v113 == 0;\n\tif (v115) goto L_0074;\n\tgoto L_005F;\nL_005F:\n\treturnVal2 = System.DateTime::AddDays(&v103 @ stack_-50_v2 (System.DateTime), 1d);\n\treturn returnVal2;\nL_0074:\n\treturn v103;\nL_001E:\n\tv54 = useUtc == 0;\n\tif (v54) goto L_002F;\n")]
		private DateTime GetRemainingDateTime(int hour, int minute = 0, bool useUtc = false)
		{
			if (useUtc)
			{
				DateTime utcNow = DateTime.UtcNow;
			}
			else
			{
				DateTime now = DateTime.Now;
			}
			DateTime dateTime = default(DateTime);
			int year = dateTime.Year;
			int month = dateTime.Month;
			int day = dateTime.Day;
			DateTime dateTime2 = new DateTime(year, month, day, hour, minute, 0, DateTimeKind.Local);
			if (dateTime2 < dateTime)
			{
				return dateTime2.AddDays(1.0);
			}
			return dateTime2;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x81BBA68", Offset = "0x81BBA68", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Inequality(this._manager, 0);\n\tv72 = ~v63;\n\tv73 = ~v72;\n\tif (v73) goto L_0049;\n\tgoto L_00C0;\nL_0049:\n\tv92 = this._manager;\n\tv223 = new System.Action`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v223, this, Il2CppMethodInfo);\n\tv183 = this._manager == 0;\n\tif (v183) goto L_00DB;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv274 = 0;\nL_0073:\n\tv282 = System.Delegate::Combine(v270, v223);\n\tv307 = v282 == 0;\n\tif (v307) goto L_FFFFFFFF;\n\tv311 = 0x21C11D0(v282, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv314 = v311 == 0;\n\tv315 = ~v314;\nL_FFFFFFFF:\n\tv274 = v311;\n\tif (v315) goto L_0064;\n\tgoto L_00B8;\nL_007F:\n\tv231 = this._manager;\n\tv223 = new System.Action`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v223, this, Il2CppMethodInfo);\n\tv226 = this._manager == 0;\n\tif (v226) goto L_00DB;\n\tgoto L_0096;\nL_FFFFFFFF:\n\tv148 = 0;\nL_00AB:\n\tv358 = System.Delegate::Combine(v329, v223);\n\tv359 = v358 == 0;\n\tif (v359) goto L_FFFFFFFF;\n\tv334 = 0x21C11D0(v358, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv362 = v334 == 0;\n\tv335 = ~v362;\nL_FFFFFFFF:\n\tv148 = v334;\n\tif (v335) goto L_009C;\nL_00B8:\n\tthrow System.InvalidCastException;\nL_00C0:\n\tv171 = new Unity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback();\n\tUnity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback::.ctor(v171, this, Il2CppMethodInfo);\n\tgoto L_00D9;\nL_00D9:\n\tUnity.Notifications.iOS.iOSNotificationCenter::add_OnRemoteNotificationReceived(v171);\n\treturn;\nL_00DB:\n\tthrow v223;\nL_005E:\n\tv256 = this._manager + 0x28;\nL_FFFFFFFF:\n\tv270 = v92.LocalNotificationDelivered;\n\tgoto L_0073;\nL_0064:\n\tv276 = 0x220BDA0(v256, v274, v270, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = v276 == v270;\nL_FFFFFFFF:\n\tv270 = v276;\n\tif (v209) goto L_007F;\nL_0096:\n\tv163 = this._manager + 0x30;\nL_FFFFFFFF:\n\tv329 = v231.LocalNotificationExpired;\n\tgoto L_00AB;\nL_009C:\n\tv151 = 0x220BDA0(v163, v148, v329, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv123 = v151 == v329;\nL_FFFFFFFF:\n\tv329 = v151;\n\tif (v123) goto L_00C0;\n")]
		private void OnEnable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::OnEnable");
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x81BBCFC", Offset = "0x81BBCFC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = Unity.Notifications.iOS.iOSNotification::get_Identifier(notification);\n\tv57 = System.String::Concat(\" Received remote notification: \", v52);\n\tgoto L_0030;\nL_0030:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\n")]
		private void OnRemoteNotificationReceived(iOSNotification notification)
		{
			string identifier = notification.Identifier;
			string message = " Received remote notification: " + identifier;
			Debug.Log(message);
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x81BBDB4", Offset = "0x81BBDB4", Length = "0x3EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv343 = this._settingsManager + 0x30;\n\tv63 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v63, this, Il2CppMethodInfo);\n\tv108 = System.Delegate::Remove(v51.OnNotificationPermissionChanged, v63);\n\tv118 = v108 == 0;\n\tif (v118) goto L_0062;\n\tv135 = 0x21C11D0(v108, System.Action`1<System.Boolean>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv222 = v135 == 0;\n\tif (v222) goto L_008C;\n\tv51.OnNotificationPermissionChanged = v135;\n\tv236 = 0x21C11D0(v108, System.Action`1<System.Boolean>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv259 = v236 == 0;\n\tif (v259) goto L_008C;\n\tv273 = this._settingsManager;\n\tv425 = this._settingsManager == 0;\n\tv272 = ~v425;\n\tif (v272) goto L_006C;\n\tgoto L_013D;\nL_0062:\n\tv51.OnNotificationPermissionChanged = 0;\n\tv273 = this._settingsManager;\nL_006C:\n\tv343 = v273 + 0x28;\n\tv279 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v279, this, Il2CppMethodInfo);\n\tv340 = System.Delegate::Remove(v273.OnNotificationChanged, v279);\n\tv342 = v340 == 0;\n\tif (v342) goto L_008E;\n\tv256 = 0x21C11D0(v340, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv260 = v256 == 0;\n\tif (v260) goto L_008C;\n\tv273.OnNotificationChanged = v256;\n\tv255 = 0x21C11D0(v340, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv440 = v255 == 0;\n\tv258 = ~v440;\n\tif (v258) goto L_0097;\nL_008C:\n\tthrow System.InvalidCastException;\nL_008E:\n\t*([v343 @ X20_v16]) = 0;\nL_0097:\n\tgoto L_009B;\nL_009B:\n\tv100 = UnityEngine.Object::op_Inequality(this._manager, 0);\n\tv109 = ~v100;\n\tv110 = ~v109;\n\tif (v110) goto L_00A7;\n\tgoto L_0122;\nL_00A7:\n\tv124 = this._manager;\n\tv128 = new System.Action`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v128, this, Il2CppMethodInfo);\n\tgoto L_00C0;\nL_FFFFFFFF:\n\tv409 = 0;\nL_00D5:\n\tv422 = System.Delegate::Remove(v412, v128);\n\tv426 = v422 == 0;\n\tif (v426) goto L_FFFFFFFF;\n\tv430 = 0x21C11D0(v422, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv433 = v430 == 0;\n\tv434 = ~v433;\nL_FFFFFFFF:\n\tv409 = v430;\n\tif (v434) goto L_00C6;\n\tgoto L_011A;\nL_00E1:\n\tv316 = this._manager;\n\tv310 = new System.Action`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v310, this, Il2CppMethodInfo);\n\tgoto L_00F8;\nL_FFFFFFFF:\n\tv177 = 0;\nL_010D:\n\tv480 = System.Delegate::Remove(v452, v310);\n\tv481 = v480 == 0;\n\tif (v481) goto L_FFFFFFFF;\n\tv456 = 0x21C11D0(v480, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv484 = v456 == 0;\n\tv457 = ~v484;\nL_FFFFFFFF:\n\tv177 = v456;\n\tif (v457) goto L_00FE;\nL_011A:\n\tthrow System.InvalidCastException;\nL_0122:\n\tv212 = new Unity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback();\n\tUnity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback::.ctor(v212, this, Il2CppMethodInfo);\n\tgoto L_013B;\nL_013B:\n\tUnity.Notifications.iOS.iOSNotificationCenter::remove_OnRemoteNotificationReceived(v212);\n\treturn;\nL_013D:\n\tthrow System.NullReferenceException;\nL_0036:\n\tv51 = this._settingsManager;\n\tv52 = this._settingsManager == 0;\n\tif (v52) goto L_0097;\nL_00C0:\n\tv367 = this._manager + 0x28;\nL_FFFFFFFF:\n\tv412 = v124.LocalNotificationDelivered;\n\tgoto L_00D5;\nL_00C6:\n\tv416 = 0x220BDA0(v367, v409, v412, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv289 = v416 == v412;\nL_FFFFFFFF:\n\tv412 = v416;\n\tif (v289) goto L_00E1;\nL_00F8:\n\tv204 = this._manager + 0x30;\nL_FFFFFFFF:\n\tv452 = v316.LocalNotificationExpired;\n\tgoto L_010D;\nL_00FE:\n\tv195 = 0x220BDA0(v204, v177, v452, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv158 = v195 == v452;\nL_FFFFFFFF:\n\tv452 = v195;\n\tif (v158) goto L_0122;\n")]
		private void OnDisable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::OnDisable");
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x81BC1A0", Offset = "0x81BC1A0", Length = "0x880")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = deliveryTime;\n\tgoto L_0058;\n\tv75 = Unco.SettingsSystem.Core.SettingsManager::get_IsNotificationPermissionGranted(this._settingsManager);\n\tv83 = ~v75;\n\tif (v83) goto L_007C;\n\tv81 = Unco.SettingsSystem.Core.SettingsManager::IsEnabled(this._settingsManager, 0x20);\n\tv84 = v81 == 0;\n\tif (v84) goto L_007C;\n\tgoto L_0071;\nL_0071:\n\tv443 = UnityEngine.Object::op_Equality(this._manager, 0);\n\tv449 = v443 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v449) goto L_009B;\n\tgoto L_0367;\nL_007C:\n\tgoto L_008D;\nL_008D:\n\tUnityEngine.Debug::Log(\" Notification not sent. Notifications are disabled in settings.\");\n\treturn;\nL_009B:\n\tv469 = _game.Scripts.Notifications.GameNotificationsManager::CreateNotification(this._manager);\n\tv471 = v469 == 0;\n\tif (v471) goto L_0367;\n\tv488 = ~addRandomness;\nL_FFFFFFFF:\n\tv42 = deliveryTime;\n\tif (v488) goto L_00C1;\n\tgoto L_00AB;\nL_00AB:\n\tUnityEngine.Debug::Log(\" Adding randomness to delivery time.\");\n\tv537 = UnityEngine.Random::Range(0, 0xA);\n\tgoto L_00BC;\nL_00BC:\n\tv502 = System.DateTime::AddMinutes(&v42 @ stack_-68_v1 (System.DateTime), v537);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv42 = v502;\nL_00D7:\n\tUnityEngine.Debug::Log(v531);\n\tgoto L_0106;\nL_FFFFFFFF:\n\tv738 = \"game_channel0\";\n\tgoto L_014E;\nL_FFFFFFFF:\n\tv738 = channelId;\n\tv1112 = *([v1070 @ X8_v39 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv1112 = v1112 + 0x10;\n\tv1098 = v1113 - 1;\n\tv1078 = v1113 != 1;\nL_FFFFFFFF:\n\tv1113 = v1098;\n\tif (v1078) goto L_0211;\nL_022D:\n\t;\n\tv1127 = _game.Scripts.Notifications.IGameNotification::set_Data(v469, key);\n\tv1128 = badgeNumber & 1;\n\tv1129 = v1128 == 0;\n\tv1130 = ~v1129;\n\tif (v1130) goto L_0247;\n\tgoto L_0274;\nL_0237:\n\tv1133 = *([v1112 @ X10_v33]) + 0xB;\n\tv1134 = v1133 << 4;\n\tv1135 = v1070 + v1134;\n\tv1136 = v1135 + 0x138;\n\t*([v1136 @ X0_v102])(v1141, v469, key, *([v1136 @ X0_v102+8]), 0, 0, reschedule, channelId, smallIcon, v537, v53, v54, v55, v56, v57, v58, v59);\n\tv1142 = badgeNumber & 1;\n\tv1143 = v1142 == 0;\n\tif (v1143) goto L_0274;\nL_0247:\n\tgoto L_026F;\nL_0274:\n\tv1215 = _game.Scripts.Notifications.GameNotificationsManager::ScheduleNotification(this._manager, v469);\n\tgoto L_02B8;\n\tgoto L_0330;\n\t// 634 NewArr v208 @ X0_v53 (System.String[]), typeof(System.String[]), 6\n\tv208[0] = \" Scheduled notification: \";\n\tv208[1] = v413;\n\tv208[2] = \" type: \";\n\tv208[3] = key;\n\tv208[4] = \" at \";\n\tv208[5] = v417;\n\tv468 = System.String::Concat(v208);\n\tgoto L_0357;\nL_0058:\n\tv70 = this._settingsManager == 0;\n\tif (v70) goto L_007C;\nL_0367:\n\treturn;\nL_00C1:\n\tv512 = Unco.Notifications.NotificationManager::GetText(this, key);\n\tv531 = System.String::Concat(\" Title: \", v512, \" Body: \", key);\n\tgoto L_00D7;\nL_0106:\n\t_game.Scripts.Notifications.IGameNotification::set_Title(v469, v512);\n\tgoto L_0133;\nL_0133:\n\t_game.Scripts.Notifications.IGameNotification::set_Body(v469, key);\n\tv722 = System.String::IsNullOrEmpty(channelId);\n\tv730 = v722 == 0;\n\tv735 = ~v730;\n\tv135 = ~v735;\n\tif (v135) goto L_FFFFFFFF;\nL_014E:\n\tgoto L_0176;\nL_0176:\n\t_game.Scripts.Notifications.IGameNotification::set_Group(v469, v738);\n\tSystem.Nullable`1<System.DateTime>::.ctor(&v123 @ stack_-90_v5 (System.Nullable`1<System.DateTime>), v42);\n\tgoto L_01AF;\nL_01AF:\n\t_game.Scripts.Notifications.IGameNotification::set_DeliveryTime(v469, v123);\n\tgoto L_01DC;\nL_01DC:\n\t_game.Scripts.Notifications.IGameNotification::set_SmallIcon(v469, smallIcon);\n\tgoto L_0209;\nL_0209:\n\t_game.Scripts.Notifications.IGameNotification::set_LargeIcon(v469, largeIcon);\n\tv1070 = *([v469 @ X0_v19 (_game.Scripts.Notifications.IGameNotification)]);\n\tv1113 = *([v1070 @ X8_v39 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv1072 = *([v1070 @ X8_v39 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v1072) goto L_022D;\nL_0211:\n\t;\n\tv1118 = *([v1112 @ X10_v33-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v1118) goto L_0237;\nL_026F:\n\t_game.Scripts.Notifications.IGameNotification::set_BadgeNumber(v469, badgeNumber);\nL_FFFFFFFF:\n\t;\nL_02B8:\n\tv1321 = _game.Scripts.Notifications.IGameNotification::get_Id(v1215.Notification);\n\tv132 = v1321;\n\tv413 = System.Nullable`1<System.Int32>::ToString(&v132 @ stack_-70_v5 (System.Nullable`1<System.Int32>));\nL_0330:\n\tv1413 = _game.Scripts.Notifications.IGameNotification::get_DeliveryTime(v1215.Notification);\n\tv370 = v1413;\n\tv417 = System.Nullable`1<System.DateTime>::ToString(&v370 @ stack_-80_v4 (System.Nullable`1<System.DateTime>));\nL_0357:\n\tUnityEngine.Debug::Log(v468);\n\tv1215.Reschedule = reschedule;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendNotification(string key, DateTime deliveryTime, bool addRandomness = false, int? badgeNumber = null, bool reschedule = false, string channelId = null, string smallIcon = null, string largeIcon = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::SendNotification");
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x81BCBA4", Offset = "0x81BCBA4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_002F;\nL_002F:\n\tv90 = 0xB2C7000 + 0x688;\n\tv86 = v66.<>9__27_0;\n\tv69 = v66.<>9__27_0 == 0;\n\tv70 = ~v69;\n\tv101 = \"\";\n\tif (v70) goto L_0067;\n\tv101 = \"\";\n\tgoto L_0044;\nL_0044:\n\tgoto L_004C;\nL_0067:\n\treturnVal2 = System.Linq.Enumerable::Aggregate /* +1 sharing this address */(v47.PendingNotifications, v101, v86, *([v90 @ X24_v3 (System.Int32)]));\n\treturn returnVal2;\nL_0022:\n\tv47 = this._manager;\nL_004C:\n\tv148 = new System.Func`3<System.String, _game.Scripts.Notifications.PendingNotification, System.String>();\n\tSystem.Func`3<System.String, _game.Scripts.Notifications.PendingNotification, System.String>::.ctor(v148, v143.<>9, Il2CppMethodInfo);\n\tv153.<>9__27_0 = v148;\n\tv86 = v148;\n")]
		private string GetAllPendingNotifications()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::GetAllPendingNotifications");
			return default;
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x81BCCF0", Offset = "0x81BCCF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnDelivered(PendingNotification deliveredNotification)
		{
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x81BCCF4", Offset = "0x81BCCF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnExpired(PendingNotification obj)
		{
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x81BCCF8", Offset = "0x81BCCF8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = _game.Scripts.Notifications.GameNotificationsManager::GetLastNotification(this._manager);\n\treturn;\n")]
		private void SendEventOnNotificationTap()
		{
			IGameNotification lastNotification = _manager.GetLastNotification();
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x81BCA20", Offset = "0x81BCA20", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tgoto L_0056;\n\tv218 = v199.Title;\n\tv141 = v199.Body;\n\tgoto L_007B;\nL_0063:\n\tv221 = System.String::Concat(\"Notification info not found for \", type);\n\tgoto L_0070;\nL_0056:\n\tv199 = Unco.Notifications.Notifications.IGameNotificationConfig::GetNotificationInfo(this._notificationConfig, type);\n\tv200 = v199 == 0;\n\tif (v200) goto L_0063;\nL_007B:\n\tSystem.ValueTuple`2<System.Object, System.Object>::.ctor(&v135 @ stack_-40_v2 (System.ValueTuple`2<System.String, System.String>), v218, v141);\n\treturn v135;\nL_0070:\n\tUnityEngine.Debug::LogError(v221);\n\tv141 = \"Let's play!\";\n\tv218 = \"Power Slap\";\n")]
		private (string, string) GetText(string type)
		{
			NotificationInfo notificationInfo = _notificationConfig.GetNotificationInfo(type);
			string item;
			string item2;
			if (notificationInfo != null)
			{
				item = notificationInfo.Title;
				item2 = notificationInfo.Body;
			}
			else
			{
				string message = "Notification info not found for " + type;
				Debug.LogError(message);
				item2 = "Let's play!";
				item = "Power Slap";
			}
			return (item, item2);
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x81BCD10", Offset = "0x81BCD10", Length = "0x670")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0057;\n\tgoto L_006B;\n\tgoto L_0079;\nL_008A:\n\tv381 = System.Linq.Enumerable::OrderBy(v61.PendingNotifications, v347);\n\tv309 = System.Linq.Enumerable::ToList(v381);\n\tv495 = v309.Count < 1;\n\tif (v495) goto L_0280;\n\tv563 = 0;\n\tgoto L_00C7;\nL_00AC:\n\tv1071 = _game.Scripts.Notifications.IGameNotification::get_Id(*([v567 @ X0_v13+18]));\n\tv148 = v1071;\n\tv310 = System.Nullable`1<System.Int32>::get_Value(&v148 @ stack_-80_v6 (System.Nullable`1<System.Int32>));\n\t_game.Scripts.Notifications.GameNotificationsManager::CancelNotification(this._manager, v310);\n\tv534 = v990;\nL_00C2:\n\tv525 = v563 >= v309.Count;\n\tif (v525) goto L_0280;\nL_00C7:\n\tv567 = System.Collections.Generic.List`1<System.Object>::get_Item(v309, v563);\n\tv563 = v563 + 1;\n\tv160 = v563 >= v309.Count;\n\tif (v160) goto L_00C2;\n\tv311 = System.Collections.Generic.List`1<System.Object>::get_Item(v309, v563);\n\tv680 = v311 == 0;\n\tif (v680) goto L_00C2;\n\tv134 = *([v311 @ X0_v15+18]);\n\tv704 = *([v134 @ X24_v7 (System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>)]);\n\tv737 = *([v704 @ X8_v12 (Il2CppClass<System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>>)+12E]);\n\tv706 = *([v704 @ X8_v12 (Il2CppClass<System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>>)+12E]) == 0;\n\tif (v706) goto L_0101;\n\tv124 = *([v704 @ X8_v12 (Il2CppClass<System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>>)+B0]) + 8;\n\tv124 = v124 + 0x10;\n\tv722 = v737 - 1;\n\tv713 = v737 != 1;\n\tv737 = v722;\n\tif (v713) goto L_00E7;\nL_0101:\n\tv724 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(v134, _game.Scripts.Notifications.IGameNotification);\n\tv275 = *([v724 @ X0_v74 (_game.Scripts.Notifications.PendingNotification)+8]);\n\t*([v724 @ X0_v74 (_game.Scripts.Notifications.PendingNotification)])(v314, v134, *([v724 @ X0_v74 (_game.Scripts.Notifications.PendingNotification)+8]), 0x1A, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv740 = v567 == 0;\n\tv324 = ~v740;\n\tv286 = 0x1A;\n\tif (v324) goto L_0115;\n\tgoto L_0281;\nL_010A:\n\t;\n\tv296 = *([v124 @ X10_v38]) + 0x1A;\n\tv113 = v296 << 4;\n\tv746 = v704 + v113;\n\tv747 = v746 + 0x138;\n\tv275 = *([v747 @ X0_v77+8]);\n\t*([v747 @ X0_v77])(v314, v134, *([v747 @ X0_v77+8]), Il2CppMethodInfo, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv286 = Il2CppMethodInfo;\nL_0115:\n\tv107 = *([v567 @ X0_v13+18]);\n\tv754 = *([v107 @ X26_v5]);\n\tv786 = *([v754 @ X8_v14+12E]);\n\tv756 = *([v754 @ X8_v14+12E]) == 0;\n\tif (v756) goto L_013D;\n\tv586 = *([v754 @ X8_v14+B0]) + 8;\n\tv586 = v586 + 0x10;\n\tv772 = v786 - 1;\n\tv763 = v786 != 1;\n\tv786 = v772;\n\tif (v763) goto L_0121;\nL_013D:\n\tv811 = *([v774 @ X0_v67+8]);\n\tv673 = _game.Scripts.Notifications.IGameNotification::get_DeliveryTime(v107);\n\tv688 = v673 & v314;\n\tv790 = v688 & 1;\n\tv681 = v790 == 0;\n\tif (v681) goto L_00C2;\n\tgoto L_0158;\nL_0145:\n\t;\n\tv669 = *([v586 @ X10_v33]) + 0x1A;\n\tv583 = v669 << 4;\n\tv793 = v754 + v583;\n\tv794 = v793 + 0x138;\n\tv811 = *([v794 @ X0_v70+8]);\n\t*([v794 @ X0_v70])(v674, v107, *([v794 @ X0_v70+8]), v286, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv689 = v674 & v314;\n\tv797 = v689 & 1;\n\tv682 = v797 == 0;\n\tif (v682) goto L_00C2;\nL_0158:\n\tgoto L_015E;\n\tv93 = 0;\n\tgoto L_0173;\nL_0173:\n\tv90 = System.TimeSpan::get_TotalHours(&v93 @ stack_-78_v5 (System.TimeSpan));\n\tv638 = v90 < 4.000000000465661d;\n\tv596 = ~v638;\n\tif (v596) goto L_00C2;\n\tgoto L_018D;\nL_018D:\n\tv135 = *([v567 @ X0_v13+18]);\n\tv829 = v135.HasValue;\n\tv856 = *([v829 @ X8_v24 (System.Boolean)+12E]);\n\tv831 = *([v829 @ X8_v24 (System.Boolean)+12E]) == 0;\n\tif (v831) goto L_01B1;\n\tv588 = *([v829 @ X8_v24 (System.Boolean)+B0]) + 8;\n\tv588 = v588 + 0x10;\n\tv844 = v856 - 1;\n\tv835 = v856 != 1;\n\tv856 = v844;\n\tif (v835) goto L_0197;\nL_01B1:\n\tv846 = System.Nullable`1<System.TimeSpan>::.ctor(v135, _game.Scripts.Notifications.IGameNotification);\n\tv846.HasValue(v678, v135, v846.value, 2, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv859 = v678 & 1;\n\tv685 = v859 == 0;\n\tif (v685) goto L_00C2;\n\tv288 = 2;\n\tgoto L_01C8;\nL_01BB:\n\t;\n\tv671 = *([v588 @ X10_v28]) + 2;\n\tv584 = v671 << 4;\n\tv862 = v829 + v584;\n\tv863 = v862 + 0x138;\n\t*([v863 @ X0_v59])(v679, v135, *([v863 @ X0_v59+8]), Il2CppMethodInfo, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv865 = v679 & 1;\n\tv686 = v865 == 0;\n\tv288 = Il2CppMethodInfo;\n\tif (v686) goto L_00C2;\nL_01C8:\n\tv136 = *([v567 @ X0_v13+18]);\n\tv868 = *([v136 @ X24_v10]);\n\tv895 = *([v868 @ X8_v26+12E]);\n\tv870 = *([v868 @ X8_v26+12E]) == 0;\n\tif (v870) goto L_01EE;\n\tv129 = *([v868 @ X8_v26+B0]) + 8;\n\tv129 = v129 + 0x10;\n\tv883 = v895 - 1;\n\tv874 = v895 != 1;\n\tv895 = v883;\n\tif (v874) goto L_01D2;\nL_01EE:\n\t;\n\tv920 = _game.Scripts.Notifications.IGameNotification::get_Title(v136);\n\tv907 = *([v311 @ X0_v15+18]);\n\tv898 = *([v311 @ X0_v15+18]) == 0;\n\tv329 = ~v898;\n\tif (v329) goto L_0207;\n\tgoto L_0281;\nL_01F6:\n\t;\n\tv301 = *([v129 @ X10_v23]) + 4;\n\tv117 = v301 << 4;\n\tv901 = v868 + v117;\n\tv902 = v901 + 0x138;\n\t*([v902 @ X0_v52])(v920, v136, *([v902 @ X0_v52+8]), v288, v534, 0, v44, v45, v46, v90, v48, v49, v50, v51, v52, v53, v54);\n\tv907 = *([v311 @ X0_v15+18]);\nL_0207:\n\tgoto L_022E;\n\tgoto L_00AC;\nL_0280:\n\treturn;\nL_0281:\n\tthrow System.NullReferenceException;\nL_0057:\n\tv61 = this._manager;\nL_006B:\n\tv360 = v358.<>9__32_0 == 0;\n\tv361 = ~v360;\n\tv347 = v358.<>9__32_0;\n\tif (v361) goto L_008A;\nL_0079:\n\tv471 = new System.Func`2<_game.Scripts.Notifications.PendingNotification, System.Nullable`1<System.DateTime>>();\n\tSystem.Func`2<_game.Scripts.Notifications.PendingNotification, System.Nullable`1<System.DateTime>>::.ctor(v471, v466.<>9, Il2CppMethodInfo);\n\tv482.<>9__32_0 = v471;\n\tv534 = 0;\n\tv347 = v471;\nL_00E7:\n\t;\n\tv222 = *([v124 @ X10_v38-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v222) goto L_010A;\nL_0121:\n\t;\n\tv628 = *([v586 @ X10_v33-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v628) goto L_0145;\nL_015E:\n\tv816 = System.DateTime::op_Subtraction(v275, v811);\n\tSystem.Nullable`1<System.TimeSpan>::.ctor(&v101 @ stack_-90_v5 (System.Nullable`1<System.TimeSpan>), v816);\n\tv818 = v101 & 1;\n\tv683 = v818 == 0;\n\tif (v683) goto L_00C2;\nL_0197:\n\t;\n\tv633 = *([v588 @ X10_v28-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v633) goto L_01BB;\nL_01D2:\n\t;\n\tv227 = *([v129 @ X10_v23-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v227) goto L_01F6;\nL_022E:\n\tv990 = _game.Scripts.Notifications.IGameNotification::get_Title(v907);\n\tv319 = System.String::Concat(\"Canceling notification \", v920, \" because of \", v990);\n\tgoto L_0245;\nL_0245:\n\tUnityEngine.Debug::Log(v319);\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CheckAndCancelNotifications()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::CheckAndCancelNotifications");
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x81BD380", Offset = "0x81BD380", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\nL_003F:\n\tv74 = Unco.Notifications.NotificationManager::GetLastNotificationTime(notificationType);\n\tgoto L_0048;\nL_0048:\n\tv89 = System.DateTime::get_Now();\n\tv101 = System.Collections.Generic.CollectionExtensions::GetValueOrDefault(v96.notificationCooldowns, notificationType, Il2CppMethodInfo);\n\tv109 = System.DateTime::op_Subtraction(v89, v74);\n\tv113 = v109;\n\tgoto L_0064;\nL_0064:\n\tv128 = System.TimeSpan::get_TotalHours(&v113 @ stack_-70_v1 (System.TimeSpan));\n\tv129 = v128 < 1d;\n\tv133 = v128 == v128;\n\tv134 = 1d == 1d;\n\tv135 = v133 & v134;\n\tv136 = ~v135;\n\tv137 = v129 == v136;\n\tif (v137) goto L_0095;\n\tv140 = notificationType;\n\t// 116 Box v143 @ X0_v39 (System.Object), typeof(_game.Scripts.Notifications.IGameNotification+GameNotificationType), &v140 @ stack_-8C_v2 (_game.Scripts.Notifications.IGameNotification+GameNotificationType)\n\tv151 = 1d;\n\tv153 = 0xB7D5000 + 0x538;\n\tv156 = \"il2cpp_vm_object_box\"(*([v153 @ X8_v14 (System.Int32)+80]), &v151 @ stack_-88_v3 (System.Double), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv162 = v74;\n\t// 128 Box v165 @ X0_v43 (System.Object), typeof(System.DateTime), &v162 @ stack_-98_v3 (System.DateTime)\n\tv198 = System.String::Format(\"Notification {0} not sent. Waiting for cooldown of {1} hours. Last sent at {2}.\", v143, v156, v165);\n\tgoto L_0091;\nL_0095:\n\tv146 = notificationType;\n\t// 152 Box v149 @ X0_v19 (System.Object), typeof(_game.Scripts.Notifications.IGameNotification+GameNotificationType), &v146 @ stack_-98_v2 (_game.Scripts.Notifications.IGameNotification+GameNotificationType)\n\tv179 = System.String::Format(\"Notification scheduled for {0} in 5 seconds\", v149);\n\tgoto L_00A7;\nL_00BA:\n\tv213 = System.DateTime::AddSeconds(&v210 @ stack_-68_v3 (System.DateTime), 4.000000000232831d);\n\tUnco.Notifications.NotificationManager::SendNotification(this, v194, v213, 0, 0, 0, 0, 0, 0);\n\tgoto L_00CE;\nL_00CE:\n\tUnco.Notifications.NotificationManager::SetLastNotificationTime(notificationType, v210);\nL_00DC:\n\treturn;\nL_0038:\n\tgoto L_003F;\nL_0091:\n\tUnityEngine.Debug::Log(v198);\n\tgoto L_00DC;\nL_00A7:\n\tUnityEngine.Debug::Log(v179);\n\tv189 = _game.Scripts.Notifications.IGameNotification+GameNotificationType;\n\tv194 = System.Enum::ToString(&v189 @ stack_-88_v2 (Il2CppClass<_game.Scripts.Notifications.IGameNotification+GameNotificationType>));\n\tgoto L_00BA;\n")]
		private void SendInstantNotificationIfAllowed(IGameNotification.GameNotificationType notificationType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::SendInstantNotificationIfAllowed");
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x81BD65C", Offset = "0x81BD65C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv74 = System.String::IsNullOrEmpty(v69);\n\tv76 = v74 == 0;\n\tif (v76) goto L_004E;\n\tgoto L_0048;\nL_004E:\n\tgoto L_0050;\nL_0050:\n\tv98 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tgoto L_0059;\nL_0059:\n\treturnVal2 = System.DateTime::Parse(v69, v98);\n\treturn returnVal2;\nL_0023:\n\tv49 = notificationType;\n\t// 38 Box v52 @ X0_v3 (System.Object), typeof(_game.Scripts.Notifications.IGameNotification+GameNotificationType), &v49 @ stack_-34_v1 (_game.Scripts.Notifications.IGameNotification+GameNotificationType)\n\tv59 = System.String::Format(\"{0}_LastNotificationTime\", v52);\n\tv64 = 0xB7D5000 + 0x538;\n\tv65 = *([v64 @ X8_v4 (System.Int32)+90]);\n\tv66 = *([v65 @ X8_v5+B8]);\n\tv69 = UnityEngine.PlayerPrefs::GetString(v59, *([v66 @ X8_v6]));\nL_0048:\n\treturn v89.MinValue;\n")]
		private static DateTime GetLastNotificationTime(IGameNotification.GameNotificationType notificationType)
		{
			//IL_00a3: Expected O, but got I
			//IL_00b3: Expected O, but got I
			object arg = notificationType;
			string key = $"{arg}_LastNotificationTime";
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v4 (System.Int32)+90]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v5+B8]");
			object defaultValue = 0;
			string text = PlayerPrefs.GetString(key, (string)defaultValue);
			if (!string.IsNullOrEmpty(text))
			{
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				return DateTime.Parse(text, invariantCulture);
			}
			return DateTime.MinValue;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x81BD7C0", Offset = "0x81BD7C0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = time;\n\tgoto L_0028;\nL_0036:\n\tv77 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tgoto L_003F;\nL_003F:\n\tv100 = System.DateTime::ToString(&v20 @ stack_-48_v1 (System.DateTime), v77);\n\tUnityEngine.PlayerPrefs::SetString(v66, v100);\n\tUnityEngine.PlayerPrefs::Save();\n\treturn;\nL_0028:\n\tv56 = notificationType;\n\t// 43 Box v59 @ X0_v3 (System.Object), typeof(_game.Scripts.Notifications.IGameNotification+GameNotificationType), &v56 @ stack_-4C_v1 (_game.Scripts.Notifications.IGameNotification+GameNotificationType)\n\tv66 = System.String::Format(\"{0}_LastNotificationTime\", v59);\n\tgoto L_0036;\n")]
		private static void SetLastNotificationTime(IGameNotification.GameNotificationType notificationType, DateTime time)
		{
			DateTime dateTime = time;
			object arg = notificationType;
			string key = $"{arg}_LastNotificationTime";
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string value = dateTime.ToString(invariantCulture);
			PlayerPrefs.SetString(key, value);
			PlayerPrefs.Save();
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x81BB6EC", Offset = "0x81BB6EC", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv59 = *([v51 @ X20_v2 (Unco.Notifications.Notifications.IGameNotificationConfig)]);\n\tv158 = *([v59 @ X8_v7 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+12E]);\n\tv61 = *([v59 @ X8_v7 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+12E]) == 0;\n\tif (v61) goto L_0051;\n\tv108 = *([v59 @ X8_v7 (Il2CppClass<Unco.Notifications.Notifications.IGameNotificationConfig>)+B0]) + 8;\n\tv108 = v108 + 0x10;\n\tv143 = v158 - 1;\n\tv133 = v158 != 1;\n\tv158 = v143;\n\tif (v133) goto L_003A;\nL_0051:\n\tv115 = *([v145 @ X0_v31+8]);\n\tv195 = Unco.Notifications.Notifications.IGameNotificationConfig::get_ComeBackTimes(this._notificationConfig);\n\tv123 = v195 == 0;\n\tif (v123) goto L_00A5;\nL_0061:\n\tv209 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>::GetEnumerator(v195);\n\tv227 = v209;\n\tgoto L_007B;\nL_007B:\n\tv387 = System.DateTime::get_Now();\n\tv256 = v387;\n\tv390 = System.DateTime::AddSeconds(&v256 @ stack_-68_v4 (System.DateTime), *([v209 @ X0_v17 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>)+18]));\n\tUnco.Notifications.NotificationManager::SendNotification(this, *([v209 @ X0_v17 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>)+10]), v390, 0, 0, 0, 0, 0, 0);\n\tgoto L_006E;\nL_008E:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>::Dispose(&v227 @ stack_-60_v3 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>));\nL_0098:\n\treturn;\nL_009A:\n\tv112 = *([v108 @ X10_v7]) + 1;\n\tv67 = v112 << 4;\n\tv176 = v59 + v67;\n\tv177 = v176 + 0x138;\n\tv115 = *([v177 @ X0_v34+8]);\n\t*([v177 @ X0_v34])(v195, this._notificationConfig, *([v177 @ X0_v34+8]), v29, v30, v31, v32, v33, v34, 0, v36, v37, v38, v39, v40, v41, v42);\n\tv179 = v195 == 0;\n\tv122 = ~v179;\n\tif (v122) goto L_0061;\nL_00A5:\n\tv127 = new System.NullReferenceException();\n\tgoto L_00B3;\nL_00B3:\n\tv170 = v115 != 1;\n\tif (v170) goto L_00C2;\n\tv210 = 0x8BF5BC4(v127, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv237 = 0x8BF5BF4(v210, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>::Dispose(v275);\n\tv219 = *([v210 @ X0_v10]) == 0;\n\tif (v219) goto L_0098;\n\tv217 = new System.OutOfMemoryException();\n\tv213 = *([v210 @ X0_v10]);\n\tv127 = v217;\nL_00C2:\n\tv224 = 0x396790C(&v213 @ stack_-78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv239 = 0x8BF0368(v127, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv276 = 0x7C03E68(v239, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0029:\n\tv51 = this._notificationConfig;\n\tv52 = this._notificationConfig == 0;\n\tif (v52) goto L_00A5;\nL_003A:\n\tv92 = *([v108 @ X10_v7-8]) == Unco.Notifications.Notifications.IGameNotificationConfig;\n\tif (v92) goto L_009A;\nL_006E:\n\tv273 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>::MoveNext(&v227 @ stack_-60_v3 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Int32>>));\n\tv278 = v273 == 0;\n\tif (v278) goto L_008E;\n")]
		private unsafe void SummonUser()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationManager::SummonUser");
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x81BD8F0", Offset = "0x81BD8F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public NotificationManager()
		{
		}
	}
}
