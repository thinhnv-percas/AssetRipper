using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000405")]
	internal class HeadlessFramePresetInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000406")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CB9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CBA")]
			public static Func<Instancer, FramePresetConfig> _003C_003E9__0_0;

			[Token(Token = "0x60010DE")]
			[Address(RVA = "0x3CB9D8C", Offset = "0x3CB9D8C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010DF")]
			[Address(RVA = "0x3CB9DF0", Offset = "0x3CB9DF0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal FramePresetConfig _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HeadlessFramePresetInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x60010DC")]
		[Address(RVA = "0x3CB9C64", Offset = "0x3CB9C64", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HeadlessFramePresetInstaller::InstallBindings");
		}

		[Token(Token = "0x60010DD")]
		[Address(RVA = "0x3CB96D4", Offset = "0x3CB96D4", Length = "0x8")]
		public HeadlessFramePresetInstaller()
		{
		}
	}
}
