using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using Unco.Notifications.Notifications;
using Unco.Utils;
using UnityEngine;

namespace Unco.Notifications
{
	[Serializable]
	[Token(Token = "0x2000023")]
	public class RemoteNotificationConfig : IGameNotificationConfig
	{
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x10")]
		public List<NotificationKey> notificationKeys;

		[SerializeField]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x18")]
		private bool ignoreElephantNotifsIos;

		[SerializeField]
		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x20")]
		private List<Pair<string, int>> comeBackTimes;

		[SerializeField]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x28")]
		private bool enablePushNotifications;

		[Token(Token = "0x17000035")]
		public bool IgnoreElephantNotifsIos
		{
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x81BE3DC", Offset = "0x81BE3DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IgnoreElephantNotifsIos;\n")]
			get
			{
				return ignoreElephantNotifsIos;
			}
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x81BE3E4", Offset = "0x81BE3E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IgnoreElephantNotifsIos = value;\n\treturn;\n")]
			set
			{
				ignoreElephantNotifsIos = value;
			}
		}

		[Token(Token = "0x17000036")]
		public bool EnablePushNotifications
		{
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x81BE3EC", Offset = "0x81BE3EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.EnablePushNotifications;\n")]
			get
			{
				return enablePushNotifications;
			}
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x81BE3F4", Offset = "0x81BE3F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.EnablePushNotifications = value;\n\treturn;\n")]
			set
			{
				enablePushNotifications = value;
			}
		}

		[Token(Token = "0x17000037")]
		public List<Pair<string, int>> ComeBackTimes
		{
			[Token(Token = "0x60000F4")]
			[Address(RVA = "0x81BE3FC", Offset = "0x81BE3FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ComeBackTimes;\n")]
			get
			{
				return comeBackTimes;
			}
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x81BE404", Offset = "0x81BE404", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ComeBackTimes = value;\n\treturn;\n")]
			set
			{
				comeBackTimes = value;
			}
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x81BE40C", Offset = "0x81BE40C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.type = type;\n\tv81 = new System.Predicate`1<Unco.Notifications.Notifications.NotificationKey>();\n\tSystem.Predicate`1<Unco.Notifications.Notifications.NotificationKey>::.ctor(v81, v51, Il2CppMethodInfo);\n\tv82 = System.Collections.Generic.List`1<Unco.Notifications.Notifications.NotificationKey>::Find(this.notificationKeys, v81);\n\tgoto L_005D;\nL_0023:\n\tv51 = new Unco.Notifications.RemoteNotificationConfig+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v51);\nL_005D:\n\treturnVal2 = Unco.Extensions.ListExtension::GetRandom(v82.NotificationInfos);\n\treturn returnVal2;\n")]
		public NotificationInfo GetNotificationInfo(string type)
		{
			Predicate<NotificationKey> match = (NotificationKey x) => x.Key == type;
			NotificationKey notificationKey = notificationKeys.Find(match);
			return notificationKey.NotificationInfos.GetRandom();
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x81BE594", Offset = "0x81BE594", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.String, System.Int32>>();\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.String, System.Int32>>::.ctor(v72);\n\tthis.ComeBackTimes = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<Unco.Notifications.Notifications.NotificationKey>();\n\tSystem.Collections.Generic.List`1<Unco.Notifications.Notifications.NotificationKey>::.ctor(v56);\n\tthis.notificationKeys = v56;\n")]
		public RemoteNotificationConfig()
		{
			List<NotificationKey> list = new List<NotificationKey>();
			notificationKeys = list;
			List<Pair<string, int>> list2 = new List<Pair<string, int>>();
			comeBackTimes = list2;
		}
	}
}
