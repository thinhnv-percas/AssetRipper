using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000EA")]
	internal class UnsupportedLocalNotificationClient : ILocalNotificationClient
	{
		[Token(Token = "0x400042A")]
		private const string UNSUPPORTED_MESSAGE = "Notifications are not supported on this platform.";

		[Token(Token = "0x6000894")]
		[Address(RVA = "0xC05824", Offset = "0xC05824", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB1A58]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, settings, listener, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022FDC]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, settings, listener, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Notifications are not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(NotificationsSettings settings, INotificationListener listener)
		{
			Debug.LogWarning("Notifications are not supported on this platform.");
		}

		[Token(Token = "0x6000895")]
		[Address(RVA = "0xC05890", Offset = "0xC05890", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsInitialized()
		{
			return false;
		}

		[Token(Token = "0x6000896")]
		[Address(RVA = "0xC05898", Offset = "0xC05898", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ScheduleLocalNotification(string id, DateTime triggerDate, NotificationContent content)
		{
		}

		[Token(Token = "0x6000897")]
		[Address(RVA = "0xC0589C", Offset = "0xC0589C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content)
		{
		}

		[Token(Token = "0x6000898")]
		[Address(RVA = "0xC058A0", Offset = "0xC058A0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content, NotificationRepeat repeat)
		{
		}

		[Token(Token = "0x6000899")]
		[Address(RVA = "0xC058A4", Offset = "0xC058A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void GetPendingLocalNotifications(Action<NotificationRequest[]> callback)
		{
		}

		[Token(Token = "0x600089A")]
		[Address(RVA = "0xC058A8", Offset = "0xC058A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void CancelPendingLocalNotification(string id)
		{
		}

		[Token(Token = "0x600089B")]
		[Address(RVA = "0xC058AC", Offset = "0xC058AC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void CancelAllPendingLocalNotifications()
		{
		}

		[Token(Token = "0x600089C")]
		[Address(RVA = "0xC058B0", Offset = "0xC058B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void RemoveAllDeliveredNotifications()
		{
		}

		[Token(Token = "0x600089D")]
		[Address(RVA = "0xC058B4", Offset = "0xC058B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedLocalNotificationClient()
		{
		}
	}
}
