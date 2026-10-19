using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006B7")]
	public class SRDebuggerLevelInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x20006B8")]
		private class SRDebuggerLevelSetupService : SRDebuggerOptionServiceBase
		{
			[Token(Token = "0x40016BD")]
			private const string SpeedRequestKey = "srdebug_speed";

			[Token(Token = "0x40016BE")]
			[FieldOffset(Offset = "0x18")]
			private readonly LevelContext _levelContext;

			[Token(Token = "0x40016BF")]
			[FieldOffset(Offset = "0x20")]
			private GameSpeedController _gameSpeedController;

			[Token(Token = "0x40016C0")]
			[FieldOffset(Offset = "0x28")]
			private ILevel _level;

			[Token(Token = "0x6001C72")]
			[Address(RVA = "0x3D6E6EC", Offset = "0x3D6E6EC", Length = "0xE0")]
			public SRDebuggerLevelSetupService(LevelContext levelContext)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerLevelInstaller.SRDebuggerLevelSetupService::.ctor");
			}

			[Inject(false)]
			[Token(Token = "0x6001C73")]
			[Address(RVA = "0x3D6E7CC", Offset = "0x3D6E7CC", Length = "0x3C")]
			private void Construct(GameSpeedController gameSpeedController, ILevel level)
			{
				_gameSpeedController = gameSpeedController;
				_level = level;
				SetupOptions();
			}

			[Token(Token = "0x6001C74")]
			[Address(RVA = "0x3D6E808", Offset = "0x3D6E808", Length = "0x154")]
			private void SetupOptions()
			{
				AddLevelInfoOption();
				AddSpeedOption("Speed x1", 1f, 20, persistent: true);
				AddSpeedOption("Speed x2", 2f, 21, persistent: true);
				AddSpeedOption("Speed x3", 3f, 22, persistent: true);
				AddSpeedOption("Speed x5", 5f, 23, persistent: true);
				AddSpeedOption("Speed x10", 10f, 24, persistent: true);
				AddSpeedOption("Speed x20", 20f, 25, persistent: true);
			}

			[Token(Token = "0x6001C75")]
			[Address(RVA = "0x3D6E95C", Offset = "0x3D6E95C", Length = "0xD0")]
			private void AddLevelInfoOption()
			{
				Action callback = PrintCurrentLevel;
				OptionDefinition option = OptionDefinition.FromMethod("Print Current Level", callback, "2. BaseLayer", 10);
				AddOption(option);
			}

			[Token(Token = "0x6001C76")]
			[Address(RVA = "0x3D6EB4C", Offset = "0x3D6EB4C", Length = "0x1DC")]
			private void PrintCurrentLevel()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerLevelInstaller.SRDebuggerLevelSetupService::PrintCurrentLevel");
			}

			[Token(Token = "0x6001C77")]
			[Address(RVA = "0x3D6EA2C", Offset = "0x3D6EA2C", Length = "0x120")]
			private void AddSpeedOption(string name, float scale, int sort, bool persistent = false)
			{
				Action callback = delegate
				{
					SRDebuggerLevelSetupService sRDebuggerLevelSetupService = this;
					sRDebuggerLevelSetupService._gameSpeedController.SetRequest("srdebug_speed", scale);
					Time.timeScale = scale;
					float num = scale;
					int num2 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					string message = $"[SRDebugger] Game speed set to x{arg}";
					Debug.Log(message);
				};
				OptionDefinition option = OptionDefinition.FromMethod(name, callback, "2. BaseLayer", sort);
				AddOption(option, persistent);
			}

			[Token(Token = "0x6001C78")]
			[Address(RVA = "0x3D6ED30", Offset = "0x3D6ED30", Length = "0x74")]
			private void ApplySpeed(float scale)
			{
				_gameSpeedController.SetRequest("srdebug_speed", scale);
				Time.timeScale = scale;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006BA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40016C3")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40016C4")]
			public static Func<Instancer, SRDebuggerLevelSetupService> _003C_003E9__0_0;

			[Token(Token = "0x6001C7B")]
			[Address(RVA = "0x3D6EEC0", Offset = "0x3D6EEC0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C7C")]
			[Address(RVA = "0x3D6EF24", Offset = "0x3D6EF24", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal SRDebuggerLevelSetupService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				bool flag = instancer.TryResolve<LevelContext>(out var result);
				SRDebuggerLevelSetupService sRDebuggerLevelSetupService = new SRDebuggerLevelSetupService(result);
				SRDebuggerLevelSetupService sRDebuggerLevelSetupService2 = instancer.InjectInstance(sRDebuggerLevelSetupService);
				return sRDebuggerLevelSetupService;
			}
		}

		[Token(Token = "0x6001C70")]
		[Address(RVA = "0x3D6E5BC", Offset = "0x3D6E5BC", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3680;
			Func<Instancer, SRDebuggerLevelSetupService> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					bool flag = instancer.TryResolve<LevelContext>(out var result);
					SRDebuggerLevelSetupService sRDebuggerLevelSetupService = new SRDebuggerLevelSetupService(result);
					SRDebuggerLevelSetupService sRDebuggerLevelSetupService2 = instancer.InjectInstance(sRDebuggerLevelSetupService);
					return sRDebuggerLevelSetupService;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001C71")]
		[Address(RVA = "0x3D6E6E4", Offset = "0x3D6E6E4", Length = "0x8")]
		public SRDebuggerLevelInstaller()
		{
		}
	}
}
