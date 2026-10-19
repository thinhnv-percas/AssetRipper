using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.Notifications;
using Unco.Notifications.Notifications;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.Scripts.Notifications;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006F2")]
	public class NotificationInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006F3")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001756")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001757")]
			public static Func<Instancer, NotificationManager> _003C_003E9__1_0;

			[Token(Token = "0x4001758")]
			public static Func<Instancer, GameNotificationsManager> _003C_003E9__1_1;

			[Token(Token = "0x6001D5F")]
			[Address(RVA = "0x3D77B60", Offset = "0x3D77B60", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001D60")]
			[Address(RVA = "0x3D77BC4", Offset = "0x3D77BC4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal NotificationManager _003CInstallBindings_003Eb__1_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotificationInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal GameNotificationsManager _003CInstallBindings_003Eb__1_1(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotificationInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_1");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001755")]
		[FieldOffset(Offset = "0x18")]
		private GameNotificationDB m_gameNotificationDB;

		[Token(Token = "0x6001D5C")]
		[Address(RVA = "0x3D77848", Offset = "0x3D77848", Length = "0x258")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationInstaller::InstallBindings");
		}

		[Token(Token = "0x6001D5D")]
		[Address(RVA = "0x3D77AA0", Offset = "0x3D77AA0", Length = "0x8")]
		public NotificationInstaller()
		{
		}
	}
}
