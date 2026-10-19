using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.RemoteManagementSystem;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.Installers
{
	[Token(Token = "0x2000413")]
	public class GameSpeedConfigInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000414")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CDE")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CDF")]
			public static Func<Instancer, object> _003C_003E9__0_0;

			[Token(Token = "0x6001116")]
			[Address(RVA = "0x3CBCB10", Offset = "0x3CBCB10", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001117")]
			[Address(RVA = "0x3CBCB74", Offset = "0x3CBCB74", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal object _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				bool flag = x.TryResolve<RemoteConfigManager>(out var result);
				object json = result.GetJson<GameSpeedConfig>(RemoteKey.game_speed_config);
				if (json != null)
				{
					return json;
				}
				return new GameSpeedConfig();
			}
		}

		[Token(Token = "0x6001114")]
		[Address(RVA = "0x3CBC9CC", Offset = "0x3CBC9CC", Length = "0x144")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Type typeFromHandle = typeof(GameSpeedConfig);
			Func<Instancer, object> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					bool flag = x.TryResolve<RemoteConfigManager>(out var result);
					object json = result.GetJson<GameSpeedConfig>(RemoteKey.game_speed_config);
					return (json != null) ? json : new GameSpeedConfig();
				});
			}
			containerBuilder.AddSingletonFactory(typeFromHandle, factory);
		}

		[Token(Token = "0x6001115")]
		[Address(RVA = "0x3CB1198", Offset = "0x3CB1198", Length = "0x8")]
		public GameSpeedConfigInstaller()
		{
		}
	}
}
