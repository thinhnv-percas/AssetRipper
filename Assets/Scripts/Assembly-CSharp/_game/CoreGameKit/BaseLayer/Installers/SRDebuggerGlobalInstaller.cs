using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using SRDebugger;
using Unco.AdSystem;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Core;
using Unco.ResourceSystem;
using Unco.SettingsSystem.Core;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Data;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Flows;
using _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp;
using _game.Systems.ElephantStorage;
using _game.Systems.MonetizationCore;
using _game.Systems.PaymentSystem.Core;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006AD")]
	public class SRDebuggerGlobalInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x20006AE")]
		private class HomeSRDebuggerSetupService : SRDebuggerOptionServiceBase
		{
			[Serializable]
			[CompilerGenerated]
			[Token(Token = "0x20006AF")]
			private sealed class _003C_003Ec
			{
				[Token(Token = "0x40016AD")]
				public static readonly _003C_003Ec _003C_003E9;

				[Token(Token = "0x40016AE")]
				public static Func<int> _003C_003E9__18_19;

				[Token(Token = "0x40016AF")]
				public static Action<int> _003C_003E9__18_20;

				[Token(Token = "0x40016B0")]
				public static Action _003C_003E9__18_22;

				[Token(Token = "0x6001C4F")]
				[Address(RVA = "0x3D6CBA8", Offset = "0x3D6CBA8", Length = "0x64")]
				static _003C_003Ec()
				{
					_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
					_003C_003E9 = _003C_003Ec2;
				}

				[Token(Token = "0x6001C50")]
				[Address(RVA = "0x3D6CC0C", Offset = "0x3D6CC0C", Length = "0x8")]
				public _003C_003Ec()
				{
				}

				internal int _003CSetupSRDebuggerActions_003Eb__18_19()
				{
					return TapSpeedUpDebugOverride.Value;
				}

				internal void _003CSetupSRDebuggerActions_003Eb__18_20(int value)
				{
					TapSpeedUpDebugOverride.Value = value;
					int num = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					string message = $"[SRDebugger] Tap speedup override = {arg}";
					Debug.Log(message);
				}

				internal void _003CSetupSRDebuggerActions_003Eb__18_22()
				{
					//IL_0059: Expected O, but got I4
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DE0B]");
					int num = (int)((nint)0 & (nint)1);
					bool flag = num == 0;
					int num2 = 192466944;
					if (!flag)
					{
						num2 = 187707392 + 3632;
						goto IL_0050;
					}
					goto IL_005f;
					IL_005f:
					_ = 1;
					num2 = 187707392 + 3632;
					goto IL_0050;
					IL_0050:
					Debug.LogError(num2);
					goto IL_005f;
				}
			}

			[Inject(false)]
			[Token(Token = "0x400169D")]
			[FieldOffset(Offset = "0x18")]
			private PaymentExecutor _paymentExecutor;

			[Inject(false)]
			[Token(Token = "0x400169E")]
			[FieldOffset(Offset = "0x20")]
			private Instancer _instancer;

			[Inject(false)]
			[Token(Token = "0x400169F")]
			[FieldOffset(Offset = "0x28")]
			private IResourceService _resourceService;

			[Inject(false)]
			[Token(Token = "0x40016A0")]
			[FieldOffset(Offset = "0x30")]
			private GameStorage _storage;

			[Inject(false)]
			[Token(Token = "0x40016A1")]
			[FieldOffset(Offset = "0x38")]
			private IPlayerDataHandler _dataHandler;

			[Inject(false)]
			[Token(Token = "0x40016A2")]
			[FieldOffset(Offset = "0x40")]
			private IAdManager _adManager;

			[Inject(false)]
			[Token(Token = "0x40016A3")]
			[FieldOffset(Offset = "0x48")]
			private ContainerManager _containerManager;

			[Inject(false)]
			[Token(Token = "0x40016A4")]
			[FieldOffset(Offset = "0x50")]
			private LevelNavigationResolver _navigationResolver;

			[Inject(false)]
			[Token(Token = "0x40016A5")]
			[FieldOffset(Offset = "0x58")]
			private InterstitialAdService _interstitialAdService;

			[Token(Token = "0x40016A6")]
			[FieldOffset(Offset = "0x60")]
			private ILevelProgressService _levelProgressService;

			[Token(Token = "0x40016A7")]
			[FieldOffset(Offset = "0x68")]
			private GameStateController _gameStateController;

			[Token(Token = "0x40016A8")]
			[FieldOffset(Offset = "0x70")]
			private int _setLevelValue;

			[Token(Token = "0x40016A9")]
			[FieldOffset(Offset = "0x74")]
			private int _winAmountValue;

			[Token(Token = "0x40016AA")]
			[FieldOffset(Offset = "0x78")]
			private ResourceType _addResourceType;

			[Token(Token = "0x40016AB")]
			[FieldOffset(Offset = "0x7C")]
			private int _addResourceAmount;

			[Token(Token = "0x40016AC")]
			[FieldOffset(Offset = "0x80")]
			private int _targetFrameRate;

			[Inject(false)]
			[Token(Token = "0x6001C34")]
			[Address(RVA = "0x3D69FA8", Offset = "0x3D69FA8", Length = "0x3C")]
			private void Inject(ILevelProgressService levelProgressService, GameStateController gameStateController)
			{
				_levelProgressService = levelProgressService;
				_gameStateController = gameStateController;
				SetupSRDebuggerActions();
			}

			[Token(Token = "0x6001C35")]
			[Address(RVA = "0x3D6AB1C", Offset = "0x3D6AB1C", Length = "0x1E8")]
			private void DebugLevelChange(Action<LevelNavigationResolver> mutateProgress)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerGlobalInstaller.HomeSRDebuggerSetupService::DebugLevelChange");
			}

			[Token(Token = "0x6001C36")]
			[Address(RVA = "0x3D69FE4", Offset = "0x3D69FE4", Length = "0xB38")]
			private unsafe void SetupSRDebuggerActions()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerGlobalInstaller.HomeSRDebuggerSetupService::SetupSRDebuggerActions");
			}

			[Token(Token = "0x6001C37")]
			[Address(RVA = "0x3D6AD04", Offset = "0x3D6AD04", Length = "0xD8")]
			public HomeSRDebuggerSetupService()
			{
				//IL_0033: Expected I4, but got F8
				_winAmountValue = 0;
				_addResourceAmount = 1000;
				_targetFrameRate = Application.targetFrameRate;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006B1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40016B3")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40016B4")]
			public static Func<Instancer, HomeSRDebuggerSetupService> _003C_003E9__0_0;

			[Token(Token = "0x6001C56")]
			[Address(RVA = "0x3D6CFF8", Offset = "0x3D6CFF8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C57")]
			[Address(RVA = "0x3D6D05C", Offset = "0x3D6D05C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HomeSRDebuggerSetupService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				HomeSRDebuggerSetupService homeSRDebuggerSetupService = new HomeSRDebuggerSetupService();
				HomeSRDebuggerSetupService homeSRDebuggerSetupService2 = instancer.InjectInstance(homeSRDebuggerSetupService);
				return homeSRDebuggerSetupService;
			}
		}

		[Token(Token = "0x6001C32")]
		[Address(RVA = "0x3D69E78", Offset = "0x3D69E78", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3656;
			Func<Instancer, HomeSRDebuggerSetupService> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					HomeSRDebuggerSetupService homeSRDebuggerSetupService = new HomeSRDebuggerSetupService();
					HomeSRDebuggerSetupService homeSRDebuggerSetupService2 = instancer.InjectInstance(homeSRDebuggerSetupService);
					return homeSRDebuggerSetupService;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001C33")]
		[Address(RVA = "0x3D69FA0", Offset = "0x3D69FA0", Length = "0x8")]
		public SRDebuggerGlobalInstaller()
		{
		}
	}
}
