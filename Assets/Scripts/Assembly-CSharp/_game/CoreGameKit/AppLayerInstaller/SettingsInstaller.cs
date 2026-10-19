using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.SettingsSyste.Core;
using Unco.SettingsSystem.Core;
using Unco.SoundSystem.Scripts.Runtime;
using UnityEngine;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Serializable]
	[Token(Token = "0x20006FC")]
	public class SettingsInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006FD")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001768")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001769")]
			public static Func<Instancer, HapticManager> _003C_003E9__1_0;

			[Token(Token = "0x6001D77")]
			[Address(RVA = "0x3D78EB4", Offset = "0x3D78EB4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001D78")]
			[Address(RVA = "0x3D78F18", Offset = "0x3D78F18", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HapticManager _003CInstallBindings_003Eb__1_0(Instancer instancer)
			{
				return instancer.AddComponent<HapticManager>();
			}
		}

		[SerializeField]
		[Token(Token = "0x4001767")]
		[FieldOffset(Offset = "0x18")]
		private SoundManager m_soundManagerPrefab;

		[Token(Token = "0x6001D74")]
		[Address(RVA = "0x3D78C8C", Offset = "0x3D78C8C", Length = "0x1B8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			SettingsManager instance = new SettingsManager();
			containerBuilder.AddSingleton(instance);
			Func<Instancer, HapticManager> factory = _003C_003Ec._003C_003E9__1_0;
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__1_0 = (Instancer instancer) => instancer.AddComponent<HapticManager>());
			}
			containerBuilder.AddSingleton(factory);
			Func<Instancer, SoundManager> factory2 = (Instancer instancer) => instancer.Instantiate(m_soundManagerPrefab);
			containerBuilder.AddSingleton(factory2);
		}

		[Token(Token = "0x6001D75")]
		[Address(RVA = "0x3D78E44", Offset = "0x3D78E44", Length = "0x8")]
		public SettingsInstaller()
		{
		}
	}
}
