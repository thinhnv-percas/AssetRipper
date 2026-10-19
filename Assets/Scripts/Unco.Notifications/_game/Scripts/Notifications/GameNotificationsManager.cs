using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using NotificationSamples.iOS;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x200000C")]
	public class GameNotificationsManager : MonoBehaviour
	{
		[Flags]
		[Token(Token = "0x200000D")]
		public enum OperatingMode
		{
			[Token(Token = "0x4000035")]
			NoQueue = 0,
			[Token(Token = "0x4000036")]
			Queue = 1,
			[Token(Token = "0x4000037")]
			ClearOnForegrounding = 2,
			[Token(Token = "0x4000038")]
			RescheduleAfterClearing = 4,
			[Token(Token = "0x4000039")]
			QueueAndClear = 3,
			[Token(Token = "0x400003A")]
			QueueClearAndReschedule = 7
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400003B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400003C")]
			public static Func<PendingNotification, bool> _003C_003E9__34_0;

			[Token(Token = "0x400003D")]
			public static Comparison<PendingNotification> _003C_003E9__34_1;

			[Token(Token = "0x600006A")]
			[Address(RVA = "0x81B8C2C", Offset = "0x81B8C2C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.Notifications.GameNotificationsManager+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600006B")]
			[Address(RVA = "0x81B8C90", Offset = "0x81B8C90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003COnApplicationFocus_003Eb__34_0(PendingNotification notification)
			{
				//IL_0025: Expected I4, but got O
				int? badgeNumber = notification.Notification.BadgeNumber;
				int num = (int)(~badgeNumber);
				return (byte)(1 & num) != 0;
			}

			internal int _003COnApplicationFocus_003Eb__34_1(PendingNotification a, PendingNotification b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager._003C_003Ec::_003COnApplicationFocus_003Eb__34_1");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000011")]
		private sealed class _003CInitialize_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000042")]
			[FieldOffset(Offset = "0x20")]
			public GameNotificationsManager _003C_003E4__this;

			[Token(Token = "0x1700001C")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000075")]
				[Address(RVA = "0x81B9618", Offset = "0x81B9618", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001D")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000077")]
				[Address(RVA = "0x81B9660", Offset = "0x81B9660", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x81B788C", Offset = "0x81B788C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CInitialize_003Ed__35(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x81B9268", Offset = "0x81B9268", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000074")]
			[Address(RVA = "0x81B926C", Offset = "0x81B926C", Length = "0x3AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_007E;\n\tthis.<>1__state = -1;\n\tv78 = v48.Initialized != 1;\n\tif (v78) goto L_0080;\n\tgoto L_0062;\nL_0062:\n\tUnityEngine.Debug::LogWarning(\"NotificationsManager already initialized.\");\n\treturn 0;\nL_006F:\n\tthis.<>1__state = -1;\n\t_game.Scripts.Notifications.GameNotificationsManager::OnForegrounding(this.<>4__this);\nL_007E:\n\treturn 0;\nL_0080:\n\tv48.Initialized = 1;\n\tv252 = new NotificationSamples.iOS.iOSNotificationsPlatform();\n\tNotificationSamples.iOS.iOSNotificationsPlatform::.ctor(v252);\n\tv48.Platform = v252;\n\tv99 = v48.Platform == 0;\n\tif (v99) goto L_007E;\n\tv274 = new System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v274);\n\tv48.PendingNotifications = v274;\n\tv135 = v48.Platform;\n\tv159 = new System.Action`1<_game.Scripts.Notifications.IGameNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.IGameNotification>::.ctor(v159, this.<>4__this, Il2CppMethodInfo);\n\tv297 = *([v135 @ X22_v6 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv331 = *([v297 @ X8_v21 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv299 = *([v297 @ X8_v21 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v299) goto L_00D4;\n\tv330 = *([v297 @ X8_v21 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv330 = v330 + 0x10;\n\tv307 = v331 - 1;\n\tv309 = v331 != 1;\n\tv331 = v307;\n\tif (v309) goto L_00BA;\nL_00D4:\n\tv354 = _game.Scripts.Notifications.IGameNotificationsPlatform::add_NotificationReceived(v135, v159);\n\tv395 = this.<>4__this + 0x48;\n\tv357 = v48.Serializer == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_011B;\n\tgoto L_00EF;\nL_00DC:\n\tv361 = *([v330 @ X10_v13]) << 4;\n\tv362 = v297 + v361;\n\tv363 = v362 + 0x138;\n\t*([v363 @ X0_v50])(v368, v135, v159, *([v363 @ X0_v50+8]), 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv395 = this.<>4__this + 0x48;\n\tv371 = v48.Serializer == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_011B;\nL_00EF:\n\tgoto L_00F2;\nL_00F2:\n\tv473 = UnityEngine.Application::get_persistentDataPath();\n\tgoto L_0102;\n\tv495.filename = v478;\n\t*([v395 @ X20_v8]) = v495;\nL_011B:\n\tgoto L_0142;\nL_0038:\n\tv48 = this.<>4__this;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_006F;\nL_00BA:\n\tv345 = *([v330 @ X10_v13-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v345) goto L_00DC;\nL_0102:\n\tv478 = System.IO.Path::Combine(v473, \"notifications.bin\");\n\tv495 = new _game.Scripts.Notifications.DefaultSerializer();\n\tSystem.Object::.ctor(v495);\nL_0142:\n\tv489 = _game.Scripts.Notifications.IGameNotificationsPlatform::RequestNotificationPermission(v48.Platform);\n\tthis.<>2__current = v489;\n\tthis.<>1__state = 1;\n\treturn 1;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager._003CInitialize_003Ed__35::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x81B9620", Offset = "0x81B9620", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000029")]
		private const string DefaultFilename = "notifications.bin";

		[Token(Token = "0x400002A")]
		private static readonly TimeSpan MinimumNotificationTime;

		[SerializeField]
		[Tooltip("The operating mode for the notifications manager.")]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x20")]
		private OperatingMode mode;

		[SerializeField]
		[Tooltip("Check to make the notifications manager automatically set badge numbers so that they increment.\nSchedule notifications with no numbers manually set to make use of this feature.")]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x24")]
		private bool autoBadging;

		[CompilerGenerated]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x28")]
		internal Action<PendingNotification> LocalNotificationDelivered;

		[CompilerGenerated]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x30")]
		internal Action<PendingNotification> LocalNotificationExpired;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x51")]
		private bool inForeground;

		[Token(Token = "0x17000016")]
		[field: Token(Token = "0x400002F")]
		[field: FieldOffset(Offset = "0x38")]
		public IGameNotificationsPlatform Platform
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x81B5AA8", Offset = "0x81B5AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Platform;\n")]
			get;
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x81B5AB0", Offset = "0x81B5AB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Platform = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000017")]
		[field: Token(Token = "0x4000030")]
		[field: FieldOffset(Offset = "0x40")]
		public List<PendingNotification> PendingNotifications
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x81B5AB8", Offset = "0x81B5AB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PendingNotifications;\n")]
			get;
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x81B5AC0", Offset = "0x81B5AC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.PendingNotifications = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000018")]
		[field: Token(Token = "0x4000031")]
		[field: FieldOffset(Offset = "0x48")]
		public IPendingNotificationsSerializer Serializer
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x81B5AC8", Offset = "0x81B5AC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Serializer;\n")]
			get;
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x81B5AD0", Offset = "0x81B5AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Serializer = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000019")]
		public OperatingMode Mode
		{
			[Token(Token = "0x6000056")]
			[Address(RVA = "0x81B5AD8", Offset = "0x81B5AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Mode;\n")]
			get
			{
				return mode;
			}
		}

		[Token(Token = "0x1700001A")]
		public bool AutoBadging
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x81B5AE0", Offset = "0x81B5AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.AutoBadging;\n")]
			get
			{
				return autoBadging;
			}
		}

		[Token(Token = "0x1700001B")]
		[field: Token(Token = "0x4000032")]
		[field: FieldOffset(Offset = "0x50")]
		public bool Initialized
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x81B5AE8", Offset = "0x81B5AE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Initialized;\n")]
			get;
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x81B5AF0", Offset = "0x81B5AF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Initialized = value;\n\treturn;\n")]
			private set;
		}

		[CompilerGenerated]
		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81B57D8", Offset = "0x81B57D8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.LocalNotificationDelivered;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.LocalNotificationDelivered (System.Action`1<_game.Scripts.Notifications.PendingNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_LocalNotificationDelivered(Action<PendingNotification> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::add_LocalNotificationDelivered");
		}

		[CompilerGenerated]
		[Token(Token = "0x600004D")]
		[Address(RVA = "0x81B588C", Offset = "0x81B588C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.LocalNotificationDelivered;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.LocalNotificationDelivered (System.Action`1<_game.Scripts.Notifications.PendingNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_LocalNotificationDelivered(Action<PendingNotification> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::remove_LocalNotificationDelivered");
		}

		[CompilerGenerated]
		[Token(Token = "0x600004E")]
		[Address(RVA = "0x81B5940", Offset = "0x81B5940", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.LocalNotificationExpired;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.LocalNotificationExpired (System.Action`1<_game.Scripts.Notifications.PendingNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_LocalNotificationExpired(Action<PendingNotification> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::add_LocalNotificationExpired");
		}

		[CompilerGenerated]
		[Token(Token = "0x600004F")]
		[Address(RVA = "0x81B59F4", Offset = "0x81B59F4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.PendingNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.LocalNotificationExpired;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.LocalNotificationExpired (System.Action`1<_game.Scripts.Notifications.PendingNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_LocalNotificationExpired(Action<PendingNotification> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::remove_LocalNotificationExpired");
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x81B5AF8", Offset = "0x81B5AF8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv61 = new System.Action`1<_game.Scripts.Notifications.IGameNotification>();\n\tSystem.Action`1<_game.Scripts.Notifications.IGameNotification>::.ctor(v61, this, Il2CppMethodInfo);\n\tgoto L_005D;\n\tgoto L_008E;\nL_0020:\n\tv48 = this.Platform == 0;\n\tif (v48) goto L_0099;\nL_005D:\n\t_game.Scripts.Notifications.IGameNotificationsPlatform::remove_NotificationReceived(this.Platform, v61);\n\tv218 = 0x21C11D0(this.Platform, System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv219 = v218 == 0;\n\tif (v219) goto L_008F;\nL_008F:\n\tthis.inForeground = 0;\nL_008E:\n\tv239 = System.IDisposable::Dispose(0);\nL_0099:\n\treturn;\n")]
		protected virtual void OnDestroy()
		{
			if (Platform != null)
			{
				Action<IGameNotification> value = OnNotificationReceived;
				Platform.NotificationReceived -= value;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj != null)
				{
					((IDisposable)null).Dispose();
				}
				inForeground = false;
			}
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x81B5C7C", Offset = "0x81B5C7C", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv63 = System.Linq.Enumerable::Any(this.PendingNotifications);\n\tv132 = ~v63;\n\tif (v132) goto L_00E4;\n\tv217 = this.Mode & 1;\n\tv133 = v217 == 0;\n\tif (v133) goto L_00E4;\n\tv221 = this.PendingNotifications;\n\tv117 = v221.Count < 1;\n\tv274 = v221.Count - 1;\n\tif (v117) goto L_00E4;\n\tgoto L_0068;\nL_0054:\n\tv139 = v274 - 1;\n\tv86 = v274 <= 0;\n\tv274 = v139;\n\tif (v86) goto L_00E4;\nL_0068:\n\tv266 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(this.PendingNotifications, v274);\n\tv237 = v266.Notification;\n\tv287 = *([v237 @ X22_v5 (_game.Scripts.Notifications.IGameNotification)]);\n\tv321 = *([v287 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv289 = *([v287 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v289) goto L_0092;\n\tv320 = *([v287 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv320 = v320 + 0x10;\n\tv297 = v321 - 1;\n\tv299 = v321 != 1;\n\tv321 = v297;\n\tif (v299) goto L_0076;\nL_0092:\n\tv392 = *([v318 @ X0_v31+8]);\n\tv343 = _game.Scripts.Notifications.IGameNotification::get_DeliveryTime(v237);\n\tv344 = v343 & 1;\n\tv345 = v344 == 0;\n\tif (v345) goto L_0054;\n\tgoto L_00A9;\nL_0099:\n\t;\n\tv348 = *([v320 @ X10_v8]) + 0x1A;\n\tv349 = v348 << 4;\n\tv350 = v287 + v349;\n\tv351 = v350 + 0x138;\n\tv392 = *([v351 @ X0_v34+8]);\n\t*([v351 @ X0_v34])(v355, v237, *([v351 @ X0_v34+8]), Il2CppMethodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv356 = v355 & 1;\n\tv357 = v356 == 0;\n\tif (v357) goto L_0054;\nL_00A9:\n\tgoto L_00AB;\nL_00AB:\n\tv400 = System.DateTime::get_Now();\n\tgoto L_00B4;\nL_00B4:\n\tv378 = System.DateTime::op_LessThan(v392, v400);\n\tv381 = ~v378;\n\tif (v381) goto L_0054;\n\tgoto L_00CD;\nL_00CD:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(this.PendingNotifications, v274);\n\tv383 = this.LocalNotificationExpired == 0;\n\tif (v383) goto L_0054;\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::Invoke(this.LocalNotificationExpired, v266);\n\tgoto L_0054;\nL_00E4:\n\treturn;\nL_0030:\n\tv56 = this.PendingNotifications == 0;\n\tif (v56) goto L_00E4;\nL_0076:\n\t;\n\tv335 = *([v320 @ X10_v8-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v335) goto L_0099;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::Update");
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x81B5ED8", Offset = "0x81B5ED8", Length = "0xF9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0072;\n\tv74 = this.Initialized != 1;\n\tif (v74) goto L_05FD;\n\tthis.inForeground = hasFocus;\n\tv188 = ~hasFocus;\n\tif (v188) goto L_0097;\n\t_game.Scripts.Notifications.GameNotificationsManager::OnForegrounding(this);\n\treturn;\nL_0097:\n\tv288 = *([v59 @ X21_v2 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv328 = *([v288 @ X8_v5 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv290 = *([v288 @ X8_v5 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v290) goto L_00BB;\n\tv327 = *([v288 @ X8_v5 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv327 = v327 + 0x10;\n\tv301 = v328 - 1;\n\tv303 = v328 != 1;\nL_FFFFFFFF:\n\tv328 = v301;\n\tif (v303) goto L_00A2;\nL_00BB:\n\tv350 = _game.Scripts.Notifications.IGameNotificationsPlatform::OnBackground(this.Platform);\n\tv352 = this.Mode & 1;\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00CF;\n\tgoto L_049A;\nL_00C3:\n\tv360 = *([v327 @ X10_v106]) + 0xB;\n\tv361 = v360 << 4;\n\tv362 = v288 + v361;\n\tv363 = v362 + 0x138;\n\t*([v363 @ X0_v218])(v367, this.Platform, *([v363 @ X0_v218+8]), methodInfo, v538, v40, v41, v42, v43, v406, v45, v46, v47, v48, v49, v50, v51);\n\tv369 = this.Mode & 1;\n\tv370 = v369 == 0;\n\tif (v370) goto L_049A;\nL_00CF:\n\tv389 = this.PendingNotifications;\n\tv510 = v389.Count < 1;\n\tv794 = v389.Count - 1;\nL_FFFFFFFF:\n\tv846 = v389;\n\tif (v510) goto L_01FC;\n\tgoto L_0100;\nL_00EB:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(this.PendingNotifications, v794);\nL_00EC:\n\tv845 = v794 - 1;\n\tv823 = v794 <= 0;\nL_FFFFFFFF:\n\tv794 = v845;\n\tif (v823) goto L_FFFFFFFF;\nL_0100:\n\tv738 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(this.PendingNotifications, v794);\n\tv637 = v738.Notification;\n\tv1204 = *([v637 @ X22_v33 (_game.Scripts.Notifications.IGameNotification)]);\n\tv1297 = *([v1204 @ X8_v135 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv1206 = *([v1204 @ X8_v135 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v1206) goto L_0128;\n\tv1296 = *([v1204 @ X8_v135 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv1296 = v1296 + 0x10;\n\tv1238 = v1297 - 1;\n\tv1240 = v1297 != 1;\nL_FFFFFFFF:\n\tv1297 = v1238;\n\tif (v1240) goto L_0113;\nL_0128:\n\tv1259 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(v637, _game.Scripts.Notifications.IGameNotification);\n\t*([v1259 @ X0_v207])(v1319, v637, *([v1259 @ X0_v207+8]), 0x1C, v538, v40, v41, v42, v43, v406, v45, v46, v47, v48, v49, v50, v51);\n\tv1320 = v1319 & 1;\n\tv1321 = v1320 == 0;\n\tv1322 = ~v1321;\n\tif (v1322) goto L_00EC;\nL_FFFFFFFF:\n\tv560 = 0x1C;\n\tgoto L_013F;\nL_0133:\n\tv1345 = *([v1296 @ X10_v100]) + 0x1C;\n\tv1346 = v1345 << 4;\n\tv1347 = v1204 + v1346;\n\tv1348 = v1347 + 0x138;\n\t*([v1348 @ X0_v210])(v1352, v637, *([v1348 @ X0_v210+8]), Il2CppMethodInfo, v538, v40, v41, v42, v43, v406, v45, v46, v47, v48, v49, v50, v51);\n\tv1353 = v1352 & 1;\n\tv1354 = v1353 == 0;\n\tv1355 = ~v1354;\nL_FFFFFFFF:\n\tv560 = Il2CppMethodInfo;\n\tif (v1355) goto L_00EC;\nL_013F:\n\tv638 = v738.Notification;\n\tv1485 = *([v638 @ X22_v34 (_game.Scripts.Notifications.IGameNotification)]);\n\tv1644 = *([v1485 @ X8_v137 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv1487 = *([v1485 @ X8_v137 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v1487) goto L_0163;\n\tv1363 = *([v1485 @ X8_v137 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv1363 = v1363 + 0x10;\n\tv1557 = v1644 - 1;\n\tv1558 = v1644 != 1;\nL_FFFFFFFF:\n\tv1644 = v1557;\n\tif (v1558) goto L_014E;\nL_0163:\n\tv1568 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(v638, _game.Scripts.Notifications.IGameNotification);\n\t*([v1568 @ X0_v200])(v1398, v638, *([v1568 @ X0_v200+8]), 0x1A, v538, v40, v41, v42, v43, v406, v45, v46, v47, v48, v49, v50, v51);\n\tv1655 = v1398 & 1;\n\tv1402 = v1655 == 0;\n\tif (v1402) goto L_00EC;\n\tgoto L_017F;\nL_016D:\n\tv1365 = *([v1363 @ X10_v95]) + 0x1A;\n\tv1358 = v1365 << 4;\n\tv1761 = v1485 + v1358;\n\tv1762 = v1761 + 0x138;\n\t*([v1762 @ X0_v203])(v1399, v638, *([v1762 @ X0_v203+8]), v560, v538, v40, v41, v42, v43, v406, v45, v46, v47, v48, v49, v50, v51);\n\tv1764 = v1399 & 1;\n\tv1403 = v1764 == 0;\n\tif (v1403) goto L_00EC;\nL_017F:\n\tgoto L_01A6;\nL_01AE:\n\tv2238 = System.DateTime::get_Now();\n\tv2230 = v2113 & 1;\n\tv2231 = v2230 == 0;\n\tif (v2231) goto L_FFFFFFFF;\n\tgoto L_01BC;\nL_01BC:\n\tv2297 = System.DateTime::op_Subtraction(0, v2238);\n\tSystem.Nullable`1<System.TimeSpan>::.ctor(&v106 @ stack_-98 (System.Nullable`1<System.TimeSpan>), v2297);\nL_FFFFFFFF:\n\tv1370 = v106;\nL_FFFFFFFF:\n\tv787 = 0;\n\tgoto L_01DD;\nL_FFFFFFFF:\n\tv1370 = 0;\nL_FFFFFFFF:\n\tv787 = 0;\n\tgoto L_01DD;\n\tgoto L_01ED;\nL_01ED:\n\tv1400 = System.TimeSpan::op_LessThan(v787, v2384.MinimumNotificationTime);\n\tv1404 = ~v1400;\n\tif (v1404) goto L_00EC;\n\tv2433 = this.PendingNotifications == 0;\n\tv758 = ~v2433;\n\tif (v758) goto L_00EB;\n\tgoto L_05FE;\nL_FFFFFFFF:\n\tv846 = this.PendingNotifications;\n\tgoto L_020F;\nL_FFFFFFFF:\n\tv538 = 0;\nL_FFFFFFFF:\n\tv600 = v1122;\n\tv651 = this.AutoBadging != 1;\n\tif (v651) goto L_034B;\n\tgoto L_0239;\nL_0239:\n\tv1262 = v1260.<>9__34_1 == 0;\n\tif (v1262) goto L_0249;\n\tv1328 = this.PendingNotifications == 0;\n\tv759 = ~v1328;\nL_FFFFFFFF:\n\tv642 = v1260.<>9__34_1;\n\tif (v759) goto L_0266;\n\tgoto L_05FE;\nL_0249:\n\tgoto L_0251;\nL_FFFFFFFF:\n\tv538 = 0;\nL_FFFFFFFF:\n\tv642 = v1428;\nL_0266:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::Sort(this.PendingNotifications, v642);\n\tv1492 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::GetEnumerator(this.PendingNotifications);\n\tv967 = v1492.Current;\n\tv84 = v1492._list;\n\tv106 = 0;\nL_FFFFFFFF:\n\tv1104 = 1;\n\tv1083 = v1492.Current == 0;\n\tif (v1083) goto L_0329;\n\tv1084 = v967.Notification == 0;\n\tif (v1084) goto L_032B;\n\tgoto L_02BA;\n\tv1085 = v967.Notification == 0;\n\tif (v1085) goto L_032D;\n\tgoto L_02EC;\n\tSystem.Nullable`1<System.Int32>::.ctor(&v962 @ stack_-A0_v9 (System.Nullable`1<System.Int32>), v1104);\n\tv1086 = v967.Notification == 0;\n\tif (v1086) goto L_032F;\n\tgoto L_0326;\nL_0329:\n\tv1070 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv106 = 0;\n\tgoto L_060C;\nL_032B:\n\tv1068 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv106 = 0;\nL_FFFFFFFF:\n\tv1068 = v1070;\n\tgoto L_060C;\nL_032D:\n\tv1072 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv106 = 0;\n\tgoto L_060C;\nL_032F:\n\tv1068 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv106 = 0;\nL_FFFFFFFF:\n\tv1068 = v1072;\n\tgoto L_060C;\nL_034A:\n\tv1143 = 0x396784C(&v106 @ stack_-98 (System.Nullable`1<System.TimeSpan>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv106 = 0;\nL_034B:\n\tv778 = this.PendingNotifications;\n\tv1217 = v778.Count < 1;\n\tv790 = v778.Count - 1;\n\tif (v1217) goto L_03E4;\n\tgoto L_037B;\nL_0366:\n\t_game.Scripts.Notifications.IGameNotificationsPlatform::ScheduleNotification(this.Platform, v747.Notification);\nL_037B:\n\tv747 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(this.PendingNotifications, v790);\n\tv632 = v747.Notification;\n\tv1578 = *([v632 @ X23_v15 (_game.Scripts.Notifications.IGameNotification)]);\n\tv1768 = *([v1578 @ X8_v80 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv1580 = *([v1578 @ X8_v80 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v1580) goto L_03A3;\n\tv1767 = *([v1578 @ X8_v80 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv1767 = v1767 + 0x10;\n\tv1694 = v1768 - 1;\n\tv1696 = v1768 != 1;\nL_FFFFFFFF:\n\tv1768 = v1694;\n\tif (v1696) goto L_0389;\nL_03A3:\n\tv1715 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(v632, _game.Scripts.Notifications.IGameNotification);\n\t*([v1715 @ X0_v103 (_game.Scripts.N\n// ... truncated")]
		protected unsafe void OnApplicationFocus(bool hasFocus)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::OnApplicationFocus");
		}

		[IteratorStateMachine(typeof(_003CInitialize_003Ed__35))]
		[Token(Token = "0x600005D")]
		[Address(RVA = "0x81B7814", Offset = "0x81B7814", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new _game.Scripts.Notifications.GameNotificationsManager+<Initialize>d__35();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator Initialize(params GameNotificationChannel[] channels)
		{
			_003CInitialize_003Ed__35 _003CInitialize_003Ed__36 = (_003CInitialize_003Ed__35)FormatterServices.GetUninitializedObject(typeof(_003CInitialize_003Ed__35));
			_003CInitialize_003Ed__36._003C_003E1__state = 0;
			_003CInitialize_003Ed__36._003C_003E4__this = this;
			return _003CInitialize_003Ed__36;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x81B78B8", Offset = "0x81B78B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		private static int GetSDKLevel()
		{
			return 0;
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x81B78C0", Offset = "0x81B78C0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv41 = this.Platform;\n\tv42 = this.Platform == 0;\n\tif (v42) goto L_004C;\n\tv49 = *([v41 @ X19_v3 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv165 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv51 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v51) goto L_0045;\n\tv128 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv128 = v128 + 0x10;\n\tv94 = v165 - 1;\n\tv64 = v165 != 1;\n\tv165 = v94;\n\tif (v64) goto L_0027;\nL_0045:\n\tinterfaceTailCallResult = _game.Scripts.Notifications.IGameNotificationsPlatform::CreateNotification(this.Platform);\nL_0045:\n\treturn interfaceTailCallResult;\nL_004C:\n\treturn 0;\nL_004E:\n\tv131 = *([v128 @ X10_v4]) + 3;\n\tv101 = v131 << 4;\n\tv142 = v49 + v101;\n\tv171 = v142 + 0x138;\n\t// 90 IndirectJump [v171 @ X0_v19], this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), [v171 @ X0_v19+8], [v171 @ X0_v19], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_005C:\n\tv44 = 0xB290000 + 0xB18;\n\tv57 = new v44();\n\tv154 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v57, v154);\n\tthrow v57;\nL_0014:\n\tv40 = this.Initialized == 0;\n\tif (v40) goto L_005C;\nL_0027:\n\tv120 = *([v128 @ X10_v4-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v120) goto L_004E;\n")]
		public IGameNotification CreateNotification()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::CreateNotification");
			return default;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x81B79D4", Offset = "0x81B79D4", Length = "0x420")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv51 = notification == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv140 = this.Platform;\n\tv59 = this.Platform == 0;\nL_FFFFFFFF:\n\tv69 = this.Platform;\n\tif (v59) goto L_009D;\n\tv66 = this.Mode & 1;\n\tv67 = v66 == 0;\n\tif (v67) goto L_00B1;\n\tv87 = notification->klass;\n\tv320 = notification->klass->interface_offsets_count;\n\tv89 = *([v87 @ X8_v23 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v89) goto L_0065;\n\tv319 = *([v87 @ X8_v23 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv319 = v319 + 0x10;\n\tv270 = v320 - 1;\n\tv250 = v320 != 1;\nL_FFFFFFFF:\n\tv320 = v270;\n\tif (v250) goto L_004C;\nL_0065:\n\tv333 = _game.Scripts.Notifications.IGameNotification::get_DeliveryTime(notification);\n\tv334 = v333 & 1;\n\tv335 = v334 == 0;\nL_FFFFFFFF:\n\tv170 = 0x1A;\n\tif (v335) goto L_00AB;\nL_006A:\n\tv395 = notification->klass;\n\tv553 = notification->klass->interface_offsets_count;\n\tv397 = *([v395 @ X8_v26 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v397) goto L_008E;\n\tv552 = *([v395 @ X8_v26 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv552 = v552 + 0x10;\n\tv491 = v553 - 1;\n\tv471 = v553 != 1;\nL_FFFFFFFF:\n\tv553 = v491;\n\tif (v471) goto L_0075;\nL_008E:\n\tv566 = _game.Scripts.Notifications.IGameNotification::get_Id(notification);\n\tv567 = v566 & 1;\n\tv568 = v567 == 0;\n\tv569 = ~v568;\nL_FFFFFFFF:\n\tv170 = 2;\n\tif (v569) goto L_00E0;\n\tgoto L_012E;\nL_FFFFFFFF:\n\tv69 = 0;\nL_009F:\n\tv365 = *([v319 @ X10_v29]) + 0x1A;\n\tv366 = v365 << 4;\n\tv367 = v87 + v366;\n\tv368 = v367 + 0x138;\n\t*([v368 @ X0_v66])(v372, notification, *([v368 @ X0_v66+8]), v170, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv373 = v372 & 1;\n\tv374 = v373 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_006A;\nL_00AB:\n\tv140 = this.Platform;\nL_00B1:\n\tv145 = *([v140 @ X21_v12 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv347 = *([v145 @ X8_v19 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv147 = *([v145 @ X8_v19 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v147) goto L_00D1;\n\tv346 = *([v145 @ X8_v19 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv346 = v346 + 0x10;\n\tv299 = v347 - 1;\n\tv279 = v347 != 1;\nL_FFFFFFFF:\n\tv347 = v299;\n\tif (v279) goto L_00BC;\nL_00D1:\n\tv419 = 0x220C5E0(v140, _game.Scripts.Notifications.IGameNotificationsPlatform, 4, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00D8;\nL_00D4:\n\tv401 = *([v346 @ X10_v10]) + 4;\n\tv402 = v401 << 4;\n\tv403 = v145 + v402;\n\tv419 = v403 + 0x138;\n\tgoto L_0111;\nL_0111:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::Add(v455, v583);\n\treturn v583;\nL_011C:\n\tv571 = *([v552 @ X10_v24]) + 2;\n\tv570 = v571 << 4;\n\tv586 = v395 + v570;\n\tv587 = v586 + 0x138;\n\t*([v587 @ X0_v59])(v575, notification, *([v587 @ X0_v59+8]), v170, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv589 = v575 & 1;\n\tv590 = v589 == 0;\n\tv577 = ~v590;\n\tif (v577) goto L_00E0;\nL_012E:\n\tgoto L_0131;\nL_0131:\n\tv605 = System.DateTime::get_Now();\n\tv425 = v605;\n\tv456 = System.DateTime::ToString(&v425 @ stack_-38_v5 (System.DateTime), \"yyMMddHHmmssffffff\");\n\tv620 = System.String::GetHashCode(v456);\n\tgoto L_0151;\nL_0151:\n\tv498 = v620 >= 0;\n\tif (v498) goto L_FFFFFFFF;\n\tv641 = -v620;\n\tgoto L_015C;\nL_FFFFFFFF:\n\tv641 = v620;\n\tv689 = *([v648 @ X8_v39 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv689 = v689 + 0x10;\n\tv675 = v690 - 1;\n\tv655 = v690 != 1;\nL_FFFFFFFF:\n\tv690 = v675;\n\tif (v655) goto L_0165;\nL_017F:\n\t;\n\tgoto L_0186;\nL_0182:\n\tv702 = *([v689 @ X10_v19]) + 3;\n\tv703 = v702 << 4;\n\tv704 = v648 + v703;\n\tv707 = v704 + 0x138;\nL_018C:\n\tv53 = 0xB290000 + 0xB18;\n\tv61 = new v53();\n\tv79 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v61, v79);\n\tthrow v61;\nL_0033:\n\tv47 = this.Initialized == 0;\n\tif (v47) goto L_018C;\nL_009D:\n\treturn v69;\nL_004C:\n\tv325 = *([v319 @ X10_v29-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v325) goto L_009F;\nL_0075:\n\tv558 = *([v552 @ X10_v24-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v558) goto L_011C;\nL_00E0:\n\tv583 = new _game.Scripts.Notifications.PendingNotification();\n\t_game.Scripts.Notifications.PendingNotification::.ctor(v583, notification);\n\tv455 = this.PendingNotifications;\nL_00BC:\n\tv352 = *([v346 @ X10_v10-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v352) goto L_00D4;\nL_00D8:\n\t;\n\tv170 = *([v419 @ X0_v30+8]);\nL_FFFFFFFF:\n\tv528 = notification;\nL_FFFFFFFF:\n\tv531 = v140;\nL_015C:\n\tSystem.Nullable`1<System.Int32>::.ctor(&v496 @ stack_-40_v5 (System.Nullable`1<System.Int32>), v641);\n\tv648 = notification->klass;\n\tv690 = notification->klass->interface_offsets_count;\n\tv534 = *([v648 @ X8_v39 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v534) goto L_017F;\nL_0165:\n\t;\n\tv695 = *([v689 @ X10_v19-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v695) goto L_0182;\nL_0186:\n\t;\n\tv170 = *([v707 @ X0_v48+8]);\nL_FFFFFFFF:\n\tv528 = v496;\nL_FFFFFFFF:\n\tv531 = notification;\n\tgoto L_00DC;\nL_00DC:\n\tv539 = _game.Scripts.Notifications.IGameNotification::set_Id(v531, v528);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PendingNotification ScheduleNotification(IGameNotification notification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::ScheduleNotification");
			return default;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81B7E7C", Offset = "0x81B7E7C", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv51.notificationId = notificationId;\n\tv66 = this.Initialized == 0;\n\tif (v66) goto L_009C;\n\tv136 = this.Platform == 0;\n\tif (v136) goto L_0099;\n\tgoto L_0069;\n\tv193 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::FindIndex(this.PendingNotifications, v119);\n\tv324 = v193 & 0x80000000;\n\tv325 = v324 == 0;\n\tv195 = ~v325;\n\tif (v195) goto L_0099;\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(this.PendingNotifications, v193);\n\treturn;\nL_0099:\n\treturn;\nL_009C:\n\tv161 = 0xB290000 + 0xB18;\n\tv207 = new v161();\n\tv279 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v207, v279);\n\tthrow v207;\nL_0029:\n\tv51 = new _game.Scripts.Notifications.GameNotificationsManager+<>c__DisplayClass39_0();\n\tSystem.Object::.ctor(v51);\nL_0069:\n\t_game.Scripts.Notifications.IGameNotificationsPlatform::CancelNotification(this.Platform, notificationId);\n\tv119 = new System.Predicate`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Predicate`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v119, v51, Il2CppMethodInfo);\n")]
		public void CancelNotification(int notificationId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::CancelNotification");
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81B8074", Offset = "0x81B8074", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv44 = this.Platform;\n\tv45 = this.Platform == 0;\n\tif (v45) goto L_0067;\n\tv102 = *([v44 @ X20_v3 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv223 = *([v102 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv104 = *([v102 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v104) goto L_0043;\n\tv222 = *([v102 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv222 = v222 + 0x10;\n\tv171 = v223 - 1;\n\tv151 = v223 != 1;\n\tv223 = v171;\n\tif (v151) goto L_002A;\nL_0043:\n\tv236 = _game.Scripts.Notifications.IGameNotificationsPlatform::CancelAllScheduledNotifications(this.Platform);\n\tv140 = this.PendingNotifications;\nL_0049:\n\t;\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::Clear(v140);\n\tv112 = v140.Count < 1;\n\tif (v112) goto L_0067;\n\treturn;\nL_0067:\n\treturn;\nL_0069:\n\tv243 = *([v222 @ X10_v8]) + 7;\n\tv244 = v243 << 4;\n\tv245 = v102 + v244;\n\tv246 = v245 + 0x138;\n\t*([v246 @ X0_v25])(v250, this.Platform, *([v246 @ X0_v25+8]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv140 = this.PendingNotifications;\n\tv252 = this.PendingNotifications == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_0049;\n\tthrow System.NullReferenceException;\nL_0077:\n\tv97 = 0xB290000 + 0xB18;\n\tv145 = new v97();\n\tv210 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v145, v210);\n\tthrow v145;\nL_0017:\n\tv41 = this.Initialized == 0;\n\tif (v41) goto L_0077;\nL_002A:\n\tv228 = *([v222 @ X10_v8-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v228) goto L_0069;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CancelAllNotifications()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::CancelAllNotifications");
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x81B81C0", Offset = "0x81B81C0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv47 = this.Platform == 0;\n\tif (v47) goto L_0048;\n\tgoto L_0059;\nL_0048:\n\treturn;\nL_005B:\n\tv49 = 0xB290000 + 0xB18;\n\tv63 = new v49();\n\tv160 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v63, v160);\n\tthrow v63;\nL_0017:\n\tv45 = this.Initialized == 0;\n\tif (v45) goto L_005B;\nL_0059:\n\t_game.Scripts.Notifications.IGameNotificationsPlatform::DismissNotification(this.Platform, notificationId);\n\treturn;\n")]
		public void DismissNotification(int notificationId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::DismissNotification");
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x81B82D4", Offset = "0x81B82D4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv41 = this.Platform;\n\tv42 = this.Platform == 0;\n\tif (v42) goto L_004B;\n\tv49 = *([v41 @ X19_v3 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv164 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv51 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v51) goto L_0045;\n\tv127 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv127 = v127 + 0x10;\n\tv93 = v164 - 1;\n\tv63 = v164 != 1;\n\tv164 = v93;\n\tif (v63) goto L_0027;\nL_0045:\n\t_game.Scripts.Notifications.IGameNotificationsPlatform::DismissAllDisplayedNotifications(this.Platform);\nL_0045:\n\treturn;\nL_004B:\n\treturn;\nL_004D:\n\tv130 = *([v127 @ X10_v4]) + 8;\n\tv100 = v130 << 4;\n\tv141 = v49 + v100;\n\tv170 = v141 + 0x138;\n\t// 89 IndirectJump [v170 @ X0_v18], this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), [v170 @ X0_v18+8], [v170 @ X0_v18], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_005B:\n\tv44 = 0xB290000 + 0xB18;\n\tv56 = new v44();\n\tv153 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v56, v153);\n\tthrow v56;\nL_0014:\n\tv40 = this.Initialized == 0;\n\tif (v40) goto L_005B;\nL_0027:\n\tv119 = *([v127 @ X10_v4-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v119) goto L_004D;\n")]
		public void DismissAllNotifications()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::DismissAllNotifications");
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x81B83E4", Offset = "0x81B83E4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv41 = this.Platform;\n\tv42 = this.Platform == 0;\n\tif (v42) goto L_004C;\n\tv49 = *([v41 @ X19_v3 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv165 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv51 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v51) goto L_0045;\n\tv128 = *([v49 @ X8_v6 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv128 = v128 + 0x10;\n\tv94 = v165 - 1;\n\tv64 = v165 != 1;\n\tv165 = v94;\n\tif (v64) goto L_0027;\nL_0045:\n\tinterfaceTailCallResult = _game.Scripts.Notifications.IGameNotificationsPlatform::GetLastNotification(this.Platform);\nL_0045:\n\treturn interfaceTailCallResult;\nL_004C:\n\treturn 0;\nL_004E:\n\tv131 = *([v128 @ X10_v4]) + 9;\n\tv101 = v131 << 4;\n\tv142 = v49 + v101;\n\tv171 = v142 + 0x138;\n\t// 90 IndirectJump [v171 @ X0_v19], this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), this.Platform (_game.Scripts.Notifications.IGameNotificationsPlatform), [v171 @ X0_v19+8], [v171 @ X0_v19], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_005C:\n\tv44 = 0xB290000 + 0xB18;\n\tv57 = new v44();\n\tv154 = 0xB2F8000 + 0x1C8;\n\tSystem.InvalidOperationException::.ctor(v57, v154);\n\tthrow v57;\nL_0014:\n\tv40 = this.Initialized == 0;\n\tif (v40) goto L_005C;\nL_0027:\n\tv120 = *([v128 @ X10_v4-8]) == _game.Scripts.Notifications.IGameNotificationsPlatform;\n\tif (v120) goto L_004E;\n")]
		public IGameNotification GetLastNotification()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::GetLastNotification");
			return default;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x81B84F8", Offset = "0x81B84F8", Length = "0x69C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv55.deliveredNotification = deliveredNotification;\n\t// 74 NewArr v232 @ X0_v9 (System.String[]), typeof(System.String[]), 12\n\tv232[0] = \"[NOTIFICATION] received: \";\n\tv212 = v55.deliveredNotification;\n\tv588 = *([v212 @ X23_v5 (_game.Scripts.Notifications.IGameNotification)]);\n\tv622 = *([v588 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv590 = *([v588 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v590) goto L_0082;\n\tv495 = *([v588 @ X8_v8 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv495 = v495 + 0x10;\n\tv610 = v622 - 1;\n\tv596 = v622 != 1;\n\tv622 = v610;\n\tif (v596) goto L_0069;\nL_0082:\n\tv646 = _game.Scripts.Notifications.IGameNotification::get_Title(v212);\n\tv557 = v232.Length & -2;\n\tv446 = v557 == 0;\n\tv386 = ~v446;\n\tv104 = 4;\n\tif (v386) goto L_009F;\n\tgoto L_02F7;\nL_008D:\n\tv507 = *([v495 @ X10_v37]) + 4;\n\tv374 = v507 << 4;\n\tv632 = v588 + v374;\n\tv633 = v632 + 0x138;\n\t*([v633 @ X0_v105])(v646, v212, *([v633 @ X0_v105+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_009F:\n\tv232[1] = v646;\n\tv232[2] = \" \";\n\tv213 = v55.deliveredNotification;\n\tv656 = *([v213 @ X23_v8 (_game.Scripts.Notifications.IGameNotification)]);\n\tv688 = *([v656 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv658 = *([v656 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v658) goto L_00DE;\n\tv497 = *([v656 @ X8_v11 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv497 = v497 + 0x10;\n\tv676 = v688 - 1;\n\tv662 = v688 != 1;\n\tv688 = v676;\n\tif (v662) goto L_00C5;\nL_00DE:\n\tv712 = _game.Scripts.Notifications.IGameNotification::get_Data(v213);\n\tv560 = v232.Length & -4;\n\tv448 = v560 == 0;\n\tv388 = ~v448;\n\tv104 = 0xA;\n\tif (v388) goto L_00FB;\n\tgoto L_02F7;\nL_00E9:\n\tv509 = *([v497 @ X10_v32]) + 0xA;\n\tv375 = v509 << 4;\n\tv698 = v656 + v375;\n\tv699 = v698 + 0x138;\n\t*([v699 @ X0_v98])(v712, v213, *([v699 @ X0_v98+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00FB:\n\tv232[3] = v712;\n\tv232[4] = \" \";\n\tv214 = v55.deliveredNotification;\n\tv721 = *([v214 @ X23_v11 (_game.Scripts.Notifications.IGameNotification)]);\n\tv757 = *([v721 @ X8_v14 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv563 = *([v721 @ X8_v14 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v563) goto L_0138;\n\tv499 = *([v721 @ X8_v14 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv499 = v499 + 0x10;\n\tv744 = v757 - 1;\n\tv726 = v757 != 1;\n\tv757 = v744;\n\tif (v726) goto L_011F;\nL_0138:\n\tv789 = _game.Scripts.Notifications.IGameNotification::get_notification_id(v214);\n\tv769 = v232.Length < 5;\n\tv486 = ~v769;\n\tv474 = v232.Length - 5;\n\tv450 = v474 == 0;\n\tv770 = ~v450;\n\tv390 = v486 & v770;\n\tv104 = 0xC;\n\tif (v390) goto L_0160;\n\tgoto L_02F7;\nL_0148:\n\tv511 = *([v499 @ X10_v27]) + 0xC;\n\tv376 = v511 << 4;\n\tv773 = v721 + v376;\n\tv774 = v773 + 0x138;\n\t*([v774 @ X0_v91])(v789, v214, *([v774 @ X0_v91+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0160:\n\tv232[5] = v789;\n\tv232[6] = \" \";\n\tv215 = v55.deliveredNotification;\n\tv798 = *([v215 @ X23_v14 (_game.Scripts.Notifications.IGameNotification)]);\n\tv830 = *([v798 @ X8_v17 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv800 = *([v798 @ X8_v17 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v800) goto L_019D;\n\tv501 = *([v798 @ X8_v17 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv501 = v501 + 0x10;\n\tv818 = v830 - 1;\n\tv804 = v830 != 1;\n\tv830 = v818;\n\tif (v804) goto L_0184;\nL_019D:\n\tv854 = _game.Scripts.Notifications.IGameNotification::get_message_id(v215);\n\tv564 = v232.Length & -8;\n\tv452 = v564 == 0;\n\tv392 = ~v452;\n\tv104 = 0xE;\n\tif (v392) goto L_01BA;\n\tgoto L_02F7;\nL_01A8:\n\tv513 = *([v501 @ X10_v22]) + 0xE;\n\tv377 = v513 << 4;\n\tv840 = v798 + v377;\n\tv841 = v840 + 0x138;\n\t*([v841 @ X0_v84])(v854, v215, *([v841 @ X0_v84+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01BA:\n\tv232[7] = v854;\n\tv232[8] = \" \";\n\tv216 = v55.deliveredNotification;\n\tv863 = *([v216 @ X23_v17 (_game.Scripts.Notifications.IGameNotification)]);\n\tv899 = *([v863 @ X8_v20 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv567 = *([v863 @ X8_v20 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v567) goto L_01F7;\n\tv503 = *([v863 @ X8_v20 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv503 = v503 + 0x10;\n\tv886 = v899 - 1;\n\tv868 = v899 != 1;\n\tv899 = v886;\n\tif (v868) goto L_01DE;\nL_01F7:\n\tv931 = _game.Scripts.Notifications.IGameNotification::get_job_id(v216);\n\tv911 = v232.Length < 9;\n\tv490 = ~v911;\n\tv478 = v232.Length - 9;\n\tv454 = v478 == 0;\n\tv912 = ~v454;\n\tv394 = v490 & v912;\n\tv104 = 0x10;\n\tif (v394) goto L_021F;\n\tgoto L_02F7;\nL_0207:\n\tv515 = *([v503 @ X10_v17]) + 0x10;\n\tv378 = v515 << 4;\n\tv915 = v863 + v378;\n\tv916 = v915 + 0x138;\n\t*([v916 @ X0_v77])(v931, v216, *([v916 @ X0_v77+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_021F:\n\tv232[9] = v931;\n\tv232[10] = \" \";\n\tv256 = v55.deliveredNotification;\n\tv940 = *([v256 @ X22_v7 (_game.Scripts.Notifications.IGameNotification)]);\n\tv976 = *([v940 @ X8_v23 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]);\n\tv556 = *([v940 @ X8_v23 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+12E]) == 0;\n\tif (v556) goto L_025C;\n\tv493 = *([v940 @ X8_v23 (Il2CppClass<_game.Scripts.Notifications.IGameNotification>)+B0]) + 8;\n\tv493 = v493 + 0x10;\n\tv963 = v976 - 1;\n\tv945 = v976 != 1;\n\tv976 = v963;\n\tif (v945) goto L_0243;\nL_025C:\n\tv1010 = _game.Scripts.Notifications.IGameNotification::get_scheduled_at(v256);\nL_026F:\n\tv232[11] = v1010;\n\tv1020 = System.String::Concat(v232);\n\tgoto L_0279;\nL_0279:\n\tUnityEngine.Debug::Log(v1020);\n\tv1032 = this.inForeground == 1;\n\tif (v1032) goto L_029C;\n\tgoto L_02E0;\nL_029C:\n\tv239 = new System.Predicate`1<_game.Scripts.Notifications.PendingNotification>();\n\tSystem.Predicate`1<_game.Scripts.Notifications.PendingNotification>::.ctor(v239, v55, Il2CppMethodInfo);\n\tv1057 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::FindIndex(this.PendingNotifications, v239);\n\tv1064 = v1057 & 0x80000000;\n\tv1065 = v1064 == 0;\n\tv1058 = ~v1065;\n\tif (v1058) goto L_02E0;\n\tv1066 = this.LocalNotificationDelivered == 0;\n\tif (v1066) goto L_02D3;\n\tv1077 = System.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::get_Item(this.PendingNotifications, v1057);\n\tSystem.Action`1<_game.Scripts.Notifications.PendingNotification>::Invoke(this.LocalNotificationDelivered, v1077);\nL_02D3:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::RemoveAt(this.PendingNotifications, v1057);\n\treturn;\nL_02E0:\n\treturn;\nL_02E2:\n\tv505 = *([v493 @ X10_v12]) + 0x12;\n\tv373 = v505 << 4;\n\tv992 = v940 + v373;\n\tv993 = v992 + 0x138;\n\t*([v993 @ X0_v70])(v1010, v256, *([v993 @ X0_v70+8]), v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv996 = v232.Length < 0xB;\n\tv481 = ~v996;\n\tv469 = v232.Length - 0xB;\n\tv445 = v469 == 0;\n\tv997 = ~v445;\n\tv385 = v481 & v997;\n\tif (v385) goto L_026F;\nL_02F7:\n\tv231 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_003A:\n\tv55 = new _game.Scripts.Notifications.GameNotificationsManager+<>c__DisplayClass44_0();\n\tSystem.Object::.ctor(v55);\nL_0069:\n\tv626 = *([v495 @ X10_v37-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v626) goto L_008D;\nL_00C5:\n\tv692 = *([v497 @ X10_v32-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v692) goto L_00E9;\nL_011F:\n\tv762 = *([v499 @ X10_v27-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v762) goto L_0148;\nL_0184:\n\tv834 = *([v501 @ X10_v22-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v834) goto L_01A8;\nL_01DE:\n\tv904 = *([v503 @ X10_v17-8]) == _game.Scripts.Notifications.IGameNotification;\n\tif (v904) goto L_0207;\nL_0243:\n\tv981 = *([v493\n// ... truncated")]
		private void OnNotificationReceived(IGameNotification deliveredNotification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::OnNotificationReceived");
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x81B6E74", Offset = "0x81B6E74", Length = "0x9A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv163 = v56.Count;\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::Clear(v56);\n\tv74 = v56.Count < 1;\n\tif (v74) goto L_0057;\nL_0057:\n\tv177 = this.Platform;\n\tv259 = *([v177 @ X20_v18 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv374 = *([v259 @ X8_v58 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv261 = *([v259 @ X8_v58 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v261) goto L_0081;\n\tv364 = *([v259 @ X8_v58 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv364 = v364 + 0x10;\n\tv356 = v374 - 1;\n\tv338 = v374 != 1;\nL_FFFFFFFF:\n\tv374 = v356;\n\tif (v338) goto L_0068;\nL_0081:\n\tv387 = _game.Scripts.Notifications.IGameNotificationsPlatform::OnForeground(v177);\n\tv435 = this.Serializer;\n\tv389 = this.Serializer == 0;\nL_FFFFFFFF:\n\tv163 = 0xA;\n\tif (v389) goto L_00B9;\nL_008C:\n\tgoto L_00C9;\nL_00AC:\n\tv406 = *([v364 @ X10_v94]) + 0xA;\n\tv407 = v406 << 4;\n\tv408 = v259 + v407;\n\tv409 = v408 + 0x138;\n\t*([v409 @ X0_v148])(v413, v177, *([v409 @ X0_v148+8]), v163, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv435 = this.Serializer;\n\tv415 = this.Serializer == 0;\n\tv416 = ~v415;\n\tif (v416) goto L_008C;\nL_00B9:\n\tv99 = this + 0x20;\n\tv465 = this.Mode & 2;\n\tv466 = v465 == 0;\n\tif (v466) goto L_0392;\nL_FFFFFFFF:\n\tv773 = 0;\n\tgoto L_00D6;\n\tv784 = v591 == 0;\n\tv596 = ~v784;\nL_FFFFFFFF:\n\tv55 = 0;\nL_FFFFFFFF:\n\tv773 = v591;\nL_FFFFFFFF:\n\tv324 = this;\n\tif (v596) goto L_0242;\n\tgoto L_0392;\nL_00D6:\n\tv106 = this.Platform;\n\tv711 = *([v106 @ X21_v18 (_game.Scripts.Notifications.IGameNotificationsPlatform)]);\n\tv897 = *([v711 @ X8_v60 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]);\n\tv713 = *([v711 @ X8_v60 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+12E]) == 0;\n\tif (v713) goto L_00FE;\n\tv527 = *([v711 @ X8_v60 (Il2CppClass<_game.Scripts.Notifications.IGameNotificationsPlatform>)+B0]) + 8;\n\tv527 = v527 + 0x10;\n\tv797 = v897 - 1;\n\tv788 = v897 != 1;\nL_FFFFFFFF:\n\tv897 = v797;\n\tif (v788) goto L_00E5;\nL_00FE:\n\tv592 = _game.Scripts.Notifications.IGameNotificationsPlatform::CancelAllScheduledNotifications(v106);\n\tv900 = v773 == 0;\n\tv597 = ~v900;\n\tif (v597) goto L_010F;\n\tgoto L_0392;\nL_0104:\n\tv584 = *([v527 @ X10_v81]) + 7;\n\tv521 = v584 << 4;\n\tv957 = v711 + v521;\n\tv958 = v957 + 0x138;\n\t*([v958 @ X0_v133])(v593, v106, *([v958 @ X0_v133+8]), v163, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv598 = v773 == 0;\n\tif (v598) goto L_0392;\nL_010F:\n\tv962 = *([v99 @ X23_v15]) & 4;\n\tv599 = v962 == 0;\n\tif (v599) goto L_0392;\n\tgoto L_013E;\nL_FFFFFFFF:\n\tv1376 = v1178;\n\tgoto L_0158;\nL_0150:\n\tv1872.Reschedule = 1;\nL_FFFFFFFF:\n\tv292 = v1711;\nL_0158:\n\tgoto L_017E;\n\tv1329 = v1178 == 0;\n\tif (v1329) goto L_039B;\n\tgoto L_01AF;\n\tgoto L_01DE;\nL_01E8:\n\tv1861 = System.DateTime::get_Now();\n\tv1865 = v1825 & 1;\n\tv1866 = v1865 == 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tif (v1866) goto L_0152;\n\tgoto L_01F6;\nL_01F6:\n\tv1873 = System.DateTime::op_GreaterThan(0, v1861);\n\tv1875 = v1873 == 0;\nL_FFFFFFFF:\n\tv292 = v1861;\n\tif (v1875) goto L_0152;\n\tv1872 = _game.Scripts.Notifications.GameNotificationsManager::ScheduleNotification(this, v1711);\n\tv1890 = v1872 == 0;\n\tv1325 = ~v1890;\n\tif (v1325) goto L_0150;\n\tv1318 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\n\tgoto L_03A0;\nL_0204:\n\tv772 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\n\tv740 = *([v772 @ X8_v74]);\n\tv770 = *([v772 @ X8_v74]) == 0;\nL_FFFFFFFF:\n\tv714 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv55 = v1178;\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv732 = 1;\nL_FFFFFFFF:\n\tv736 = 0;\nL_FFFFFFFF:\n\tv774 = this;\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv55 = v1178;\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv281 = 1;\nL_FFFFFFFF:\n\tv285 = 0;\nL_FFFFFFFF:\n\tv292 = 0;\nL_FFFFFFFF:\n\tv323 = v773;\nL_FFFFFFFF:\n\tv324 = this;\n\tif (v770) goto L_0235;\nL_020E:\n\tgoto L_0234;\n\tv901 = v281 & 1;\n\tv902 = v901 == 0;\n\tv600 = ~v902;\nL_FFFFFFFF:\n\tv773 = v323;\n\tif (v600) goto L_0392;\nL_0242:\n\tgoto L_0268;\nL_FFFFFFFF:\n\tv1149 = v1022;\n\tgoto L_0288;\nL_0280:\n\tSystem.Collections.Generic.List`1<_game.Scripts.Notifications.PendingNotification>::Add(v324.PendingNotifications, v1880);\nL_0282:\n\tv1104 = v1022 == 0;\nL_FFFFFFFF:\n\tv1149 = v1022;\n\tif (v1104) goto L_0393;\nL_0288:\n\tgoto L_02AE;\n\tv1327 = v1022 == 0;\n\tif (v1327) goto L_0397;\n\tgoto L_02DF;\n\tgoto L_030E;\nL_0318:\n\tv1789 = System.DateTime::get_Now();\n\tv1811 = v1750 & 1;\n\tv1812 = v1811 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v1812) goto L_0282;\n\tgoto L_0326;\nL_0326:\n\tv1851 = System.DateTime::op_GreaterThan(0, v1789);\n\tv1855 = v1851 == 0;\n\tif (v1855) goto L_0282;\n\tv1242 = v324.PendingNotifications;\n\tv1880 = new _game.Scripts.Notifications.PendingNotification();\n\t_game.Scripts.Notifications.PendingNotification::.ctor(v1880, v1611);\n\tv1885 = v324.PendingNotifications == 0;\n\tif (v1885) goto L_FFFFFFFF;\n\tv1889 = v1242._version + 1;\n\tv1242._version = v1889;\n\tv1854 = v1242._items == 0;\n\tif (v1854) goto L_FFFFFFFF;\n\tgoto L_0280;\nL_0351:\n\tv1437 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\n\tv1438 = *([v1437 @ X8_v23]) == 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tif (v1438) goto L_FFFFFFFF;\n\tgoto L_0381;\nL_0392:\n\treturn;\nL_0393:\n\tv1109 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\n\tgoto L_03A0;\nL_0395:\n\tv1319 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tgoto L_03A0;\nL_0397:\n\tv1320 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tgoto L_03A0;\nL_0399:\n\tv1321 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\n\tgoto L_03A0;\nL_039B:\n\tv1322 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tgoto L_03A0;\nL_039D:\n\tv1323 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv292 = 0;\n\tgoto L_03A0;\nL_FFFFFFFF:\n\tv262 = &v55 @ stack_-68_v1 (System.Collections.Generic.IEnumerator`1<_game.Scripts.Notifications.IGameNotification>);\nL_FFFFFFFF:\n\tv81 = 0;\n\tthrow v1880;\nL_03A0:\n\t// 928 Interrupt\nL_03A3:\n\tthrow System.OutOfMemoryException;\nL_03A5:\n\tv327 = new System.OutOfMemoryException();\n\tgoto L_03C0;\nL_03C0:\n\tv400 = v292 != 1;\n\tif (v400) goto L_03D0;\n\tv468 = 0x8BF5BC4(v327, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv736 = *([v468 @ X0_v14]);\n\tv623 = 0x8BF5BF4(v468, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv740 = *([v262 @ stack_-70_v3]);\n\tv689 = *([v262 @ stack_-70_v3]) == 0;\n\tv690 = ~v689;\nL_FFFFFFFF:\n\tv714 = v262;\nL_FFFFFFFF:\n\tv81 = *([v468 @ X0_v14]);\nL_FFFFFFFF:\n\tv732 = 0;\nL_FFFFFFFF:\n\tv774 = v324;\n// ... truncated")]
		private void OnForegrounding()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationsManager::OnForegrounding");
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x81B8B9C", Offset = "0x81B8B9C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Mode = 7;\n\tthis.AutoBadging = 1;\n\tthis.inForeground = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GameNotificationsManager()
		{
			mode = OperatingMode.QueueClearAndReschedule;
			autoBadging = true;
			inForeground = true;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x81B8BB8", Offset = "0x81B8BB8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tSystem.TimeSpan::.ctor(&v41 @ stack_-28_v2 (System.TimeSpan), 0, 0, 2);\n\tv47.MinimumNotificationTime = v41;\n\treturn;\n")]
		static GameNotificationsManager()
		{
			TimeSpan minimumNotificationTime = new TimeSpan(0, 0, 2);
			MinimumNotificationTime = minimumNotificationTime;
		}
	}
}
