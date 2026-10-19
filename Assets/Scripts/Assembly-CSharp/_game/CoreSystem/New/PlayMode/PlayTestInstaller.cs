using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;
using _game.CoreSystem.New.LevelGeneratorSystem.PlayReport;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E2")]
	public sealed class PlayTestInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003E3")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000C4D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000C4E")]
			public static Func<Instancer, PlayTestSpeedHandler> _003C_003E9__6_0;

			[Token(Token = "0x4000C4F")]
			public static Func<Instancer, ConveyorSettleProbe> _003C_003E9__6_2;

			[Token(Token = "0x4000C50")]
			public static Func<Instancer, PathPlaybackController> _003C_003E9__6_3;

			[Token(Token = "0x4000C51")]
			public static Func<Instancer, WinDetector> _003C_003E9__6_4;

			[Token(Token = "0x4000C52")]
			public static Func<Instancer, PlayTestWinCheck> _003C_003E9__6_5;

			[Token(Token = "0x600105B")]
			[Address(RVA = "0x3CB2D50", Offset = "0x3CB2D50", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600105C")]
			[Address(RVA = "0x3CB2DB4", Offset = "0x3CB2DB4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal PlayTestSpeedHandler _003CInstallBindings_003Eb__6_0(Instancer x)
			{
				PlayTestSpeedHandler instance = new PlayTestSpeedHandler();
				return x.InjectInstance(instance);
			}

			internal ConveyorSettleProbe _003CInstallBindings_003Eb__6_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PlayTestInstaller._003C_003Ec::_003CInstallBindings_003Eb__6_2");
				return default;
			}

			internal PathPlaybackController _003CInstallBindings_003Eb__6_3(Instancer x)
			{
				PathPlaybackController instance = new PathPlaybackController();
				return x.InjectInstance(instance);
			}

			internal WinDetector _003CInstallBindings_003Eb__6_4(Instancer x)
			{
				WinDetector instance = new WinDetector();
				return x.InjectInstance(instance);
			}

			internal PlayTestWinCheck _003CInstallBindings_003Eb__6_5(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PlayTestInstaller._003C_003Ec::_003CInstallBindings_003Eb__6_5");
				return default;
			}
		}

		[Token(Token = "0x4000C48")]
		[FieldOffset(Offset = "0x10")]
		private readonly LevelPlayMode _mode;

		[Token(Token = "0x4000C49")]
		[FieldOffset(Offset = "0x18")]
		private readonly string _levelId;

		[Token(Token = "0x4000C4A")]
		[FieldOffset(Offset = "0x20")]
		private readonly string _reportDir;

		[Token(Token = "0x4000C4B")]
		[FieldOffset(Offset = "0x28")]
		private readonly string _reportHtmlPath;

		[Token(Token = "0x4000C4C")]
		[FieldOffset(Offset = "0x30")]
		private readonly IReadOnlyList<(int x, int y, string color)> _intended;

		[Token(Token = "0x6001058")]
		[Address(RVA = "0x3CB2290", Offset = "0x3CB2290", Length = "0x88")]
		public PlayTestInstaller(LevelPlayMode mode, string levelId, string reportDir, string reportHtmlPath, IReadOnlyList<(int x, int y, string color)> intended)
		{
			_mode = mode;
			_levelId = levelId;
			_reportDir = reportDir;
			_reportHtmlPath = reportHtmlPath;
			_intended = intended;
		}

		[Token(Token = "0x6001059")]
		[Address(RVA = "0x3CB2318", Offset = "0x3CB2318", Length = "0x810")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestInstaller::InstallBindings");
		}
	}
}
