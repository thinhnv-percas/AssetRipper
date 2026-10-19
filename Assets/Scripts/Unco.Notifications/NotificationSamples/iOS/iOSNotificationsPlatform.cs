using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Notifications.iOS;
using _game.Scripts.Notifications;

namespace NotificationSamples.iOS
{
	[Token(Token = "0x2000005")]
	public class iOSNotificationsPlatform : IGameNotificationsPlatform<iOSGameNotification>, IGameNotificationsPlatform, IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x2000006")]
		private sealed class _003CRequestNotificationPermission_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400000F")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000010")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000011")]
			[FieldOffset(Offset = "0x20")]
			private AuthorizationRequest _003Crequest_003E5__2;

			[Token(Token = "0x17000014")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000041")]
				[Address(RVA = "0x81B3A70", Offset = "0x81B3A70", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000015")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000043")]
				[Address(RVA = "0x81B3AB8", Offset = "0x81B3AB8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x81B2F7C", Offset = "0x81B2F7C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CRequestNotificationPermission_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x81B36DC", Offset = "0x81B36DC", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = v51.<>1__state - 1;\n\tv16 = v14 == 0;\n\tv21 = ~v16;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tv25 = v51.<>1__state - -3;\n\tv40 = v25 == 0;\n\tgoto L_0022;\nL_FFFFFFFF:\n\tv40 = 1;\n\tgoto L_0033;\n\tv151 = *([v58 @ X19_v4 (Unity.Notifications.iOS.AuthorizationRequest)]);\n\tv177 = *([v151 @ X8_v8 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+12E]);\n\tv119 = *([v151 @ X8_v8 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+12E]) == 0;\n\tif (v119) goto L_0063;\n\tv104 = *([v151 @ X8_v8 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+B0]) + 8;\n\tv104 = v104 + 0x10;\n\tv163 = v177 - 1;\n\tv164 = v177 != 1;\nL_FFFFFFFF:\n\tv177 = v163;\n\tif (v164) goto L_0045;\nL_0063:\n\tSystem.IDisposable::Dispose(v51.<request>5__2);\nL_0063:\n\treturn;\nL_0069:\n\treturn;\nL_006B:\n\tv94 = *([v104 @ X10_v4]) << 4;\n\tv152 = v151 + v94;\n\tv188 = v152 + 0x138;\n\t// 118 IndirectJump [v188 @ X0_v6], v51.<request>5__2 (Unity.Notifications.iOS.AuthorizationRequest), v51.<request>5__2 (Unity.Notifications.iOS.AuthorizationRequest), [v188 @ X0_v6+8], [v188 @ X0_v6], v72 @ X3, v73 @ X4, v74 @ X5, v75 @ X6, v76 @ X7, v77 @ V0, v78 @ V1, v79 @ V2, v80 @ V3, v81 @ V4, v82 @ V5, v83 @ V6, v84 @ V7\nL_0022:\n\tv44 = ~v40;\n\tif (v44) goto L_0069;\nL_0033:\n\tv51.<>1__state = -1;\n\tv58 = v51.<request>5__2;\n\tv56 = v51.<request>5__2 == 0;\n\tif (v56) goto L_0069;\nL_0045:\n\tv140 = *([v104 @ X10_v4-8]) == System.IDisposable;\n\tif (v140) goto L_006B;\n")]
			void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform._003CRequestNotificationPermission_003Ed__4::Dispose");
			}

			[Token(Token = "0x600003F")]
			[Address(RVA = "0x81B37B8", Offset = "0x81B37B8", Length = "0x1F4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv53 = this.<>1__state == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0096;\n\tthis.<>1__state = -1;\n\tv74 = new Unity.Notifications.iOS.AuthorizationRequest();\n\tUnity.Notifications.iOS.AuthorizationRequest::.ctor(v74, 7, 1);\n\tv40.<request>5__2 = v74;\n\tv66 = v40;\n\tv141 = Unity.Notifications.iOS.AuthorizationRequest::get_IsFinished(v66.<request>5__2);\n\tv170 = v141 == 0;\n\tif (v170) goto L_0076;\n\tgoto L_004C;\n\tgoto L_008A;\nL_0076:\n\tv40.<>2__current = 0;\n\tv40.<>1__state = 1;\n\treturn 1;\nL_0096:\n\treturn 0;\nL_0097:\n\tv142 = new System.NullReferenceException();\n\tgoto L_00A6;\nL_00A6:\n\tv86 = v74 != 1;\n\tv147 = 0;\n\tv179 = v142;\n\tif (v86) goto L_00B6;\n\tv204 = 0x8BF5BC4(v142, v74, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv124 = 0x8BF5BF4(v204, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = *([v204 @ X0_v12]) == 0;\n\tif (v127) goto L_0096;\n\tv207 = &v40 @ stack_-28_v2 (NotificationSamples.iOS.iOSNotificationsPlatform+<RequestNotificationPermission>d__4);\n\tv291 = 0x396794C(*([v207 @ X8_v8]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv206 = new System.OutOfMemoryException();\n\tv147 = *([v204 @ X0_v12]);\n\tv179 = v206;\n\treturn returnVal3;\nL_001B:\n\tv48 = this.<>1__state == 1;\n\tv66 = this;\n\tif (v48) goto L_0036;\nL_004C:\n\tv40.<>1__state = -1;\n\tv202 = v40.<request>5__2 == 0;\n\tif (v202) goto L_008D;\nL_008A:\n\tSystem.IDisposable::Dispose(v40.<request>5__2);\nL_00B6:\n\tv210 = 0x39675BC(&v147 @ stack_-38_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv239 = 0x8BF0368(v179, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0x7C03E68(v239, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0036:\n\tv66.<>1__state = -3;\n\tv70 = v66.<request>5__2 == 0;\n\tif (v70) goto L_0097;\nL_008D:\n\tv40.<request>5__2 = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform._003CRequestNotificationPermission_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000040")]
			[Address(RVA = "0x81B39AC", Offset = "0x81B39AC", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv44 = *([v39 @ X19_v2 (Unity.Notifications.iOS.AuthorizationRequest)]);\n\tv151 = *([v44 @ X8_v6 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+12E]);\n\tv46 = *([v44 @ X8_v6 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+12E]) == 0;\n\tif (v46) goto L_0043;\n\tv120 = *([v44 @ X8_v6 (Il2CppClass<Unity.Notifications.iOS.AuthorizationRequest>)+B0]) + 8;\n\tv120 = v120 + 0x10;\n\tv87 = v151 - 1;\n\tv57 = v151 != 1;\n\tv151 = v87;\n\tif (v57) goto L_0025;\nL_0043:\n\tSystem.IDisposable::Dispose(this.<request>5__2);\nL_0043:\n\treturn;\nL_0049:\n\treturn;\nL_004B:\n\tv94 = *([v120 @ X10_v4]) << 4;\n\tv132 = v44 + v94;\n\tv154 = v132 + 0x138;\n\t// 86 IndirectJump [v154 @ X0_v5], this.<request>5__2 (Unity.Notifications.iOS.AuthorizationRequest), this.<request>5__2 (Unity.Notifications.iOS.AuthorizationRequest), [v154 @ X0_v5+8], [v154 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0013:\n\tthis.<>1__state = -1;\n\tv39 = this.<request>5__2;\n\tv40 = this.<request>5__2 == 0;\n\tif (v40) goto L_0049;\nL_0025:\n\tv112 = *([v120 @ X10_v4-8]) == System.IDisposable;\n\tif (v112) goto L_004B;\n")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform._003CRequestNotificationPermission_003Ed__4::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x81B3A78", Offset = "0x81B3A78", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x10")]
		private Action<IGameNotification> _003CNotificationReceived_003Ek__BackingField;

		[Token(Token = "0x14000001")]
		public event Action<IGameNotification> NotificationReceived
		{
			[CompilerGenerated]
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x81B2CFC", Offset = "0x81B2CFC", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.IGameNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.NotificationReceived;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.NotificationReceived (System.Action`1<_game.Scripts.Notifications.IGameNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::add_NotificationReceived");
			}
			[CompilerGenerated]
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x81B2DB0", Offset = "0x81B2DB0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.Scripts.Notifications.IGameNotification>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.NotificationReceived;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.NotificationReceived (System.Action`1<_game.Scripts.Notifications.IGameNotification>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::remove_NotificationReceived");
			}
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81B2E64", Offset = "0x81B2E64", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tgoto L_003D;\nL_003D:\n\tUnity.Notifications.iOS.iOSNotificationCenter::add_OnNotificationReceived(v59);\n\treturn;\nL_0024:\n\tSystem.Object::.ctor(this);\n\tv59 = new Unity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback();\n\tUnity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback::.ctor(v59, this, Il2CppMethodInfo);\n")]
		public iOSNotificationsPlatform()
		{
			iOSNotificationCenter.NotificationReceivedCallback value = OnLocalNotificationReceived;
			iOSNotificationCenter.OnNotificationReceived += value;
		}

		[IteratorStateMachine(typeof(_003CRequestNotificationPermission_003Ed__4))]
		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81B2F20", Offset = "0x81B2F20", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new NotificationSamples.iOS.iOSNotificationsPlatform+<RequestNotificationPermission>d__4();\n\tSystem.Object::.ctor(v40);\n\tv40.<>1__state = 0;\n\treturn v40;\n")]
		public IEnumerator RequestNotificationPermission()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CRequestNotificationPermission_003Ed__4(0);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81B2FA8", Offset = "0x81B2FA8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v120_asT @ TEMPCOND_v4 (NotificationSamples.iOS.iOSGameNotification), typeof(NotificationSamples.iOS.iOSGameNotification), gameNotification @ X1 (_game.Scripts.Notifications.IGameNotification)\n\tv120 = v120_asT == 0;\n\tif (v120) goto L_003D;\n\tNotificationSamples.iOS.iOSNotificationsPlatform::ScheduleNotification(v37, gameNotification);\n\treturn;\nL_003D:\n\tv122 = 0xB290000 + 0xB18;\n\tv129 = new v122();\n\tv135 = 0xB2F8000 + 0xC30;\n\tSystem.InvalidOperationException::.ctor(v129, v135);\n\tthrow v129;\nL_004F:\n\tv105 = 0xB28B000 + 0x600;\n\tv124 = new v105();\n\tv132 = 0xB30A000 + 0xED0;\n\tSystem.ArgumentNullException::.ctor(v124, v132);\n\tthrow v124;\nL_0013:\n\tv41 = gameNotification == 0;\n\tif (v41) goto L_004F;\n")]
		public void ScheduleNotification(IGameNotification gameNotification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::ScheduleNotification");
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81B30B0", Offset = "0x81B30B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_001F;\nL_001F:\n\tUnity.Notifications.iOS.iOSNotificationCenter::ScheduleNotification(notification.InternalNotification);\n\tnotification.Scheduled = 1;\n\treturn;\nL_0029:\n\tv47 = 0xB28B000 + 0x600;\n\tv53 = new v47();\n\tv61 = 0xB30E000 + 0xB0;\n\tSystem.ArgumentNullException::.ctor(v53, v61);\n\tthrow v53;\nL_0012:\n\tv38 = notification == 0;\n\tif (v38) goto L_0029;\n")]
		public void ScheduleNotification(iOSGameNotification notification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::ScheduleNotification");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81B3168", Offset = "0x81B3168", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new NotificationSamples.iOS.iOSGameNotification();\n\tNotificationSamples.iOS.iOSGameNotification::.ctor(v40);\n\treturn v40;\n")]
		IGameNotification IGameNotificationsPlatform.CreateNotification()
		{
			return new iOSGameNotification();
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81B31BC", Offset = "0x81B31BC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new NotificationSamples.iOS.iOSGameNotification();\n\tNotificationSamples.iOS.iOSGameNotification::.ctor(v40);\n\treturn v40;\n")]
		public iOSGameNotification CreateNotification()
		{
			return new iOSGameNotification();
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81B3210", Offset = "0x81B3210", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = notificationId;\n\tv12 = 0xB799000;\n\tv16 = *([B799FE2]) & 1;\n\tv17 = v16 == 0;\n\tif (v17) goto L_0021;\n\tv48 = System.Int32::ToString(&v10 @ stack_-24_v1 (System.Int32));\n\tgoto L_0016;\nL_0016:\n\tUnity.Notifications.iOS.iOSNotificationCenter::RemoveScheduledNotification(v48);\n\treturn;\nL_0021:\n\t*([v12 @ X20_v1+FE2]) = 1;\n\tv48 = System.Int32::ToString(&v10 @ stack_-24_v1 (System.Int32));\n\tgoto L_0016;\n")]
		public void CancelNotification(int notificationId)
		{
			//IL_0011: Expected O, but got I4
			int num = notificationId;
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799FE2]");
			string identifier;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				identifier = num.ToString();
			}
			else
			{
				_ = 1;
				identifier = num.ToString();
			}
			iOSNotificationCenter.RemoveScheduledNotification(identifier);
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81B32BC", Offset = "0x81B32BC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = notificationId;\n\tv12 = 0xB799000;\n\tv16 = *([B799FE3]) & 1;\n\tv17 = v16 == 0;\n\tif (v17) goto L_0021;\n\tv48 = System.Int32::ToString(&v10 @ stack_-24_v1 (System.Int32));\n\tgoto L_0016;\nL_0016:\n\tUnity.Notifications.iOS.iOSNotificationCenter::RemoveDeliveredNotification(v48);\n\treturn;\nL_0021:\n\t*([v12 @ X20_v1+FE3]) = 1;\n\tv48 = System.Int32::ToString(&v10 @ stack_-24_v1 (System.Int32));\n\tgoto L_0016;\n")]
		public void DismissNotification(int notificationId)
		{
			//IL_0011: Expected O, but got I4
			int num = notificationId;
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799FE3]");
			string identifier;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				identifier = num.ToString();
			}
			else
			{
				_ = 1;
				identifier = num.ToString();
			}
			iOSNotificationCenter.RemoveDeliveredNotification(identifier);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81B3368", Offset = "0x81B3368", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0017;\nL_0017:\n\tUnity.Notifications.iOS.iOSNotificationCenter::RemoveAllScheduledNotifications();\n\treturn;\n")]
		public void CancelAllScheduledNotifications()
		{
			iOSNotificationCenter.RemoveAllScheduledNotifications();
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81B33D8", Offset = "0x81B33D8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0017;\nL_0017:\n\tUnity.Notifications.iOS.iOSNotificationCenter::RemoveAllDeliveredNotifications();\n\treturn;\n")]
		public void DismissAllDisplayedNotifications()
		{
			iOSNotificationCenter.RemoveAllDeliveredNotifications();
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81B3448", Offset = "0x81B3448", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = NotificationSamples.iOS.iOSNotificationsPlatform::GetLastNotification(this);\n\treturn returnVal1;\n")]
		IGameNotification IGameNotificationsPlatform.GetLastNotification()
		{
			return GetLastNotification();
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81B344C", Offset = "0x81B344C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv57 = Unity.Notifications.iOS.iOSNotificationCenter::GetLastRespondedNotification();\n\tv52 = v57 == 0;\n\tif (v52) goto L_0043;\n\tv65 = new NotificationSamples.iOS.iOSGameNotification();\n\tSystem.Object::.ctor(v65);\n\tv65.InternalNotification = v57;\n\treturn v65;\nL_0043:\n\treturn 0;\n")]
		public iOSGameNotification GetLastNotification()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::GetLastNotification");
			return default;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81B3514", Offset = "0x81B3514", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0018;\nL_0018:\n\tUnity.Notifications.iOS.iOSNotificationCenter::set_ApplicationBadge(0);\n\treturn;\n")]
		public void OnForeground()
		{
			iOSNotificationCenter.ApplicationBadge = 0;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81B358C", Offset = "0x81B358C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBackground()
		{
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81B3590", Offset = "0x81B3590", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_003A:\n\tUnity.Notifications.iOS.iOSNotificationCenter::remove_OnNotificationReceived(v54);\n\treturn;\nL_0023:\n\tv54 = new Unity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback();\n\tUnity.Notifications.iOS.iOSNotificationCenter+NotificationReceivedCallback::.ctor(v54, this, Il2CppMethodInfo);\n\tgoto L_003A;\n")]
		public void Dispose()
		{
			iOSNotificationCenter.NotificationReceivedCallback value = OnLocalNotificationReceived;
			iOSNotificationCenter.OnNotificationReceived -= value;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81B3640", Offset = "0x81B3640", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv48 = new NotificationSamples.iOS.iOSGameNotification();\n\tSystem.Object::.ctor(v48);\n\tv48.InternalNotification = notification;\n\tSystem.Action`1<_game.Scripts.Notifications.IGameNotification>::Invoke(this.NotificationReceived, v48);\n\treturn;\nL_0037:\n\treturn;\nL_0015:\n\t;\n\tv44 = this.NotificationReceived == 0;\n\tif (v44) goto L_0037;\n")]
		private void OnLocalNotificationReceived(iOSNotification notification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("iOSNotificationsPlatform::OnLocalNotificationReceived");
		}
	}
}
